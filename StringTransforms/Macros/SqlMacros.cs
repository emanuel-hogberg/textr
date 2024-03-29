﻿using System;
using System.Collections.Generic;
using StringTransforms.BatchTransforms;
using StringTransforms.Interfaces;
using StringTransforms.Transforms;

namespace StringTransforms.Macros
{
    internal static class SqlMacros
    {
        public static List<ITransform> CreateSqlSelectFormat()
        => new Macros()
            .AddTransform(new RemoveNewLineTransform())
            .AddTransform(new FindReplaceTransform(",", ", "))
            .AddTransform(new NewLineAfterXOccurencesOfY(5, ", "))
            .ToList();

        public static List<ITransform> CreateSqlQueryFormat()
        => new Macros()
            .AddTransform(new FindReplaceTransform(",", ", "))
            .AddTransform(new FindReplaceTransform("select", "SELECT\n", false))
            .AddTransform(new FindReplaceTransform("from", "\nFROM", false))
            .AddTransform(new FindReplaceTransform("where", "\nWHERE\n", false))
            .AddTransform(new FindReplaceTransform("inner join", "\nINNER§JOIN", false))
            .AddTransform(new FindReplaceTransform("left join", "\nLEFT§JOIN", false))
            .AddTransform(new FindReplaceTransform("left outer join", "\nLEFT OUTER§JOIN", false))
            .AddTransform(new FindReplaceTransform("right join", "\nRIGHT§JOIN", false))
            .AddTransform(new FindReplaceTransform(" join", "\nJOIN", false))
            .AddTransform(new FindReplaceTransform("§JOIN", " JOIN"))
            .ToList();

        private static Macros SqlGroupTransformList(GroupTransform groupTransform)
        => new Macros()
            .AddTransform(new DistinctTransform())
            .AddTransform(new RemoveBlankLinesTransform())
            .AddTransform(groupTransform)
            .AddTransform(new TruncateTransform() { Truncate = Environment.NewLine })
            .AddTransform(new TruncateTransform() { Truncate = "," });

        public static List<ITransform> CreateSqlListStringComma()
        => SqlGroupTransformList(new GroupTransform("123")
                .Select("*")
                .SetTransform("'*',") as GroupTransform)
            .ToList();

        public static List<ITransform> CreateSqlListComma()
        => SqlGroupTransformList(new GroupTransform("123")
                .Select("*")
                .SetTransform("*,") as GroupTransform)
            .ToList();

        public static List<ITransform> CreateSqlValues()
        => new Macros()
            .AddTransforms(CreateSqlListComma())
            .AddTransform(new RemoveNewLineTransform())
            .AddTransform(new FindReplaceTransform(", ", "), ("))
            .AddTransform(new GroupTransform("123")
                .Select("*")
                .SetTransform("FROM ( VALUES (*)\n) t (id)"))
            .AddTransform(new NewLineAfterXOccurencesOfY(10, ","))
            .AddTransform(new NewLineCharFix())
            .ToList();

        public static List<ITransform> CreateSqlAddTableNamesToSelect()
        => new Macros()
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
