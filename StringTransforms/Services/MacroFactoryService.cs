using StringTransforms.Interfaces;
using StringTransforms.Macros;
using System.Collections.Generic;

namespace StringTransforms.Services
{
    public class MacroFactoryService : IMacroFactoryService
    {
        public List<ITransform> CreateGremlinFormat()
            => GremlinMacros.CreateGremlinFormat();

        public List<ITransform> CreateSqlAddTableNamesToSelect()
            => SqlMacros.CreateSqlAddTableNamesToSelect();

        public List<ITransform> CreateSqlListComma()
            => SqlMacros.CreateSqlListComma();

        public List<ITransform> CreateSqlListStringComma()
            => SqlMacros.CreateSqlListStringComma();

        public List<ITransform> CreateSqlQueryFormat()
            => SqlMacros.CreateSqlQueryFormat();

        public List<ITransform> CreateSqlSelectFormat()
            => SqlMacros.CreateSqlSelectFormat();

        public List<ITransform> CreateSqlValues()
            => SqlMacros.CreateSqlValues();
    }
}
