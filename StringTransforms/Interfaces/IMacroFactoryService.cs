using System.Collections.Generic;

namespace StringTransforms.Interfaces
{
    public interface IMacroFactoryService
    {
        List<ITransform> CreateGremlinFormat();
        List<ITransform> CreateSqlAddTableNamesToSelect();
        List<ITransform> CreateSqlListComma();
        List<ITransform> CreateSqlListStringComma();
        List<ITransform> CreateSqlQueryFormat();
        List<ITransform> CreateSqlSelectFormat();
        List<ITransform> CreateSqlValues();
    }
}
