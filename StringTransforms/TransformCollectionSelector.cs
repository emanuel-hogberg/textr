using StringTransforms.Interfaces;

namespace StringTransforms
{
    public class TransformCollectionSelector : ITransformCollectionSelector
    {
        public int SelectedIndex { get; internal set; } = -1;

        public void SetIndex(int selectedIndex)
        {
            SelectedIndex = selectedIndex;
        }

        public int GetIndex()
            => SelectedIndex;
    }
}
