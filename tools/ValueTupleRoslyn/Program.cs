using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// Simple Roslyn-based rewriter that converts `new ValueTuple<T1,T2>(a,b)` and
// `new System.ValueTuple<T1,T2>(a,b)` into tuple expressions `(a, b)`.
// Usage:
// dotnet run --project tools/ValueTupleRoslyn -- --path <root> [--apply]

class Program
{
    static int Main(string[] args)
    {
        var opts = ParseArgs(args);
        if (opts == null)
        {
            Console.WriteLine("Usage: --path <root> [--apply]");
            return 1;
        }

        // Register MSBuild so Roslyn can load projects if needed (not strictly used here)
        var instances = MSBuildLocator.QueryVisualStudioInstances().ToArray();
        if (instances.Length > 0)
        {
            MSBuildLocator.RegisterInstance(instances[0]);
        }

        var csFiles = Directory.GetFiles(opts.Path, "*.cs", SearchOption.AllDirectories)
            // skip bin/obj folders quickly
            .Where(p => !p.Contains(Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar) && !p.Contains(Path.DirectorySeparatorChar + "obj" + Path.DirectorySeparatorChar))
            .ToList();

        int totalMatches = 0;
        var edits = new List<(string file, string before, string after)>();

        foreach (var file in csFiles)
        {
            var text = File.ReadAllText(file);
            var tree = CSharpSyntaxTree.ParseText(text);
            var root = tree.GetRoot();

            var rewriter = new ValueTupleRewriter();
            var newRoot = rewriter.Visit(root);

            if (!ReferenceEquals(root, newRoot))
            {
                var newText = newRoot.ToFullString();
                edits.Add((file, text, newText));
                totalMatches += rewriter.Changes; 
            }
        }

        Console.WriteLine($"Found {totalMatches} potential replacement(s) across {edits.Count} file(s).");
        foreach (var e in edits)
        {
            Console.WriteLine($"- {e.file}");
        }

        if (edits.Count == 0)
        {
            Console.WriteLine("No changes necessary.");
            return 0;
        }

        if (!opts.Apply)
        {
            Console.WriteLine("Run again with --apply to write the changes to disk.");
            return 0;
        }

        // Backup files and write changes
        foreach (var e in edits)
        {
            var bak = e.file + ".bak.vtuples";
            File.Copy(e.file, bak, overwrite: true);
            File.WriteAllText(e.file, e.after);
            Console.WriteLine($"Patched {e.file} (backup -> {bak})");
        }

        Console.WriteLine("All done.");
        return 0;
    }

    record Options(string Path, bool Apply);

    static Options? ParseArgs(string[] args)
    {
        string? path = null;
        bool apply = false;
        for (int i = 0; i < args.Length; i++)
        {
            var a = args[i];
            if (a == "--path" && i + 1 < args.Length) { path = args[++i]; }
            else if (a == "--apply") apply = true;
            else if (a == "--dry") apply = false;
        }
        if (path == null) return null;
        return new Options(System.IO.Path.GetFullPath(path), apply);
    }
}

class ValueTupleRewriter : CSharpSyntaxRewriter
{
    public int Changes { get; private set; } = 0;

    public override SyntaxNode? VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
    {
        // Only handle cases with an argument list (ignore default constructor)
        if (node.ArgumentList == null || node.ArgumentList.Arguments.Count == 0)
            return base.VisitObjectCreationExpression(node);

        // Determine if the type being created is ValueTuple (possibly qualified)
        var type = node.Type;
        string? id = GetRightmostIdentifier(type);
        if (!string.Equals(id, "ValueTuple", StringComparison.Ordinal))
            return base.VisitObjectCreationExpression(node);

        // Build a tuple expression from the arguments
        var args = node.ArgumentList.Arguments.Select(a => SyntaxFactory.Argument(a.Expression!.WithoutTrivia())).ToArray();
        if (args.Length == 0)
            return base.VisitObjectCreationExpression(node);

        var separated = SyntaxFactory.SeparatedList(args.Select(a => a.WithoutTrivia()));
        var tuple = SyntaxFactory.TupleExpression(separated)
            .WithLeadingTrivia(node.GetLeadingTrivia())
            .WithTrailingTrivia(node.GetTrailingTrivia());

        Changes++;
        return tuple;
    }

    static string? GetRightmostIdentifier(TypeSyntax type)
    {
        switch (type)
        {
            case GenericNameSyntax g:
                return g.Identifier.Text;
            case IdentifierNameSyntax id:
                return id.Identifier.Text;
            case QualifiedNameSyntax q:
                return GetRightmostIdentifier(q.Right);
            case AliasQualifiedNameSyntax a:
                return GetRightmostIdentifier(a.Name);
            default:
                return null;
        }
    }
}
