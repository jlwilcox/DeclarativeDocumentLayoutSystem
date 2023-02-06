namespace DeclarativeLayout
{
    using DeclarativeLayout.Structs;

    public class Border : Decorator
    {
        public Color BorderColor { get; set; } = new Color(0, 255, 0);

        public float BorderThickness { get; set; } = 1;

        public override Structs.Size Measure(Size availableSize, IMeasurer measurer)
        {
            Size desiredSize = base.Measure(availableSize, measurer);
            desiredSize.Height += this.BorderThickness * 2;
            desiredSize.Width += this.BorderThickness * 2;
            this.DesiredSize = desiredSize;
            return this.DesiredSize;
        }

        public override void Arrange(Structs.Rectangle finalRect)
        {
            Structs.Rectangle childRect = finalRect;
            childRect.Location.X += this.BorderThickness;
            childRect.Location.Y += this.BorderThickness;
            childRect.Size.Width -= this.BorderThickness * 2;
            childRect.Size.Height -= this.BorderThickness * 2;

            Child.Arrange(childRect);
            this.UpdateChild = false;
            base.Arrange(finalRect);
        }

        public override void Render(IRenderer renderer)
        {
            base.Render(renderer);
            if (this.CanRender)
            {
                base.Render(renderer);

                renderer.DrawRectangle(this.LayoutRectangle, this.BorderThickness, this.BorderColor);
            }
        }
    }
}
