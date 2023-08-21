using StringTransforms.Interfaces;

namespace StringTransforms.Transforms
{
    public class TruncateProperties : IEditableProperties
    {
        public string Truncate { get; set; }
        public bool FromStart { get; set; }
        public bool IgnoreCase { get; set; }
    }
}