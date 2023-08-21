namespace StringTransforms.Interfaces
{
    public interface IMathService
    {
        bool MathExpression(string stringExpression, out string error, out double calculation);
        string SplitOutHooks(string t);
    }
}