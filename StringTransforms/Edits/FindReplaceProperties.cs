using StringTransforms.Interfaces;

namespace StringTransforms.Transforms
{
    public class FindReplaceProperties : IEditableProperties
    {
        public string Find { get; set; }
        public string Replace { get; set; }
        public bool CaseSensitive { get; set; }
    }
}
