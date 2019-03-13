using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using emanuel.Transforms;

namespace emanuel.Macros
{
    public class SqlMacros
    {
        private List<ITransform> transforms = new List<ITransform>();

        private SqlMacros AddTransform(ITransform transform)
        {
            transforms.Add(transform);
            return this;
        }

        private SqlMacros AddTransforms(List<ITransform> transforms)
        {
            this.transforms.AddRange(transforms);
            return this;
        }

        private List<ITransform> ToList() => transforms;
        
        private SqlMacros SqlGroupTransformList(GroupTransform groupTransform)
        => new SqlMacros()
            .AddTransform(new DistinctTransform())
                .AddTransform(new RemoveBlankLinesTransform())
                .AddTransform(groupTransform)
                .AddTransform(new TruncateTransform() { Truncate = Environment.NewLine })
                .AddTransform(new TruncateTransform() { Truncate = "," });

        public static List<ITransform> SqlSelectFormat()
        => new SqlMacros()
            .AddTransform(new RemoveNewLineTransform())
            .AddTransform(new FindReplaceTransform(",", ", "))
            .AddTransform(new NewLineAfterXOccurencesOfY(5, ", "))
            .ToList();

        public static List<ITransform> SqlQueryFormat()
        => new SqlMacros()
            //.AddTransform(new RemoveNewLineTransform())
            .AddTransform(new FindReplaceTransform(",", ", "))
            //.AddTransform(new NewLineAfterXOccurencesOfY(5, ", "))
            .AddTransform(new FindReplaceTransform("select", "SELECT\n", false))
            .AddTransform(new FindReplaceTransform("from", "\nFROM", false))
            .AddTransform(new FindReplaceTransform("where", "\nWHERE\n", false))
            .AddTransform(new FindReplaceTransform("inner join", "\nINNER§JOIN", false))
            .AddTransform(new FindReplaceTransform("left join", "\nLEFT§JOIN", false))
            .AddTransform(new FindReplaceTransform("left outer join", "\nLEFT OUTER§JOIN", false))
            .AddTransform(new FindReplaceTransform("right join", "\nRIGHT§JOIN", false))
            .AddTransform(new FindReplaceTransform(" join", "\nJOIN", false))
            .AddTransform(new FindReplaceTransform("§JOIN", " JOIN"))
            //.AddTransform(new NewLineCharFix())
            .ToList();

        public static List<ITransform> SqlListStringComma()
        => new SqlMacros()
            .SqlGroupTransformList(new GroupTransform("123")
                .Select("*")
                .SetTransform("'*',") as GroupTransform)
            .ToList();

        public static List<ITransform> SqlListComma()
        => new SqlMacros()
            .SqlGroupTransformList(new GroupTransform("123")
                .Select("*")
                .SetTransform("*,") as GroupTransform)
            .ToList();

        public static List<ITransform> SqlValues()
        => new SqlMacros()
            .AddTransforms(SqlListComma())
            .AddTransform(new RemoveNewLineTransform())
            .AddTransform(new FindReplaceTransform(", ", "), ("))
            .AddTransform(new GroupTransform("123")
                .Select("*")
                .SetTransform("FROM ( VALUES (*)\n) t (id)"))
            .AddTransform(new NewLineAfterXOccurencesOfY(10, ","))
            .AddTransform(new NewLineCharFix())
            .ToList();

        internal static List<ITransform> SqlAddTableNamesToSelect()
        => new SqlMacros()
            .AddTransform(new FindReplaceTransform("*", "§"))
            .AddTransform(new FindReplaceTransform("select", "SELECT"))
            .AddTransform(new FindReplaceTransform("from", "FROM"))
            .AddTransform(new FindReplaceTransform("where", "WHERE "))
            .AddTransform(new FindReplaceTransform("  ", " "))
            .AddTransform(new FormatTransform("123")
                .Select(" § FROM * ")
                .SetTransform(" '*:' '*:', § FROM * "))
            .AddTransform(new FindReplaceTransform("§", "*"))
            .ToList();
    }
}
