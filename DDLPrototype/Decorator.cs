namespace DeclarativeLayout
{
    using DeclarativeLayout.Structs;

    public abstract class Decorator : VisualElement
    {
        public bool UpdateChild
        { get; set; } = true;

        public VisualElement Child { get; set; }

        public override Size Measure(Size availableSize, IMeasurer measurer)
        {
            base.Measure(availableSize, measurer);
            this.DesiredSize = this.Child.Measure(availableSize, measurer);
            return this.DesiredSize;
        }

        public override void Arrange(Structs.Rectangle finalRect)
        {
            if (this.UpdateChild)
            {
                this.Child.Arrange(finalRect);
            }

            base.Arrange(finalRect);
        }

        public override void Render(IRenderer renderer)
        {
            base.Render(renderer);
            this.Child.Render(renderer);
        }
    }
}
