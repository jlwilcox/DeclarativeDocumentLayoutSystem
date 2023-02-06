namespace DeclarativeLayout
{
    using DeclarativeLayout.Structs;

    public class TextBlock : VisualElement
    {
        public TextBlock(string text)
        {
            this.Text = text;
        }

        public TextBlock()
        {
        }

        public string Text { get; set; }

        public string FontFamily { get; set; } = "Arial";

        public double FontSize { get; set; } = 16;

        public Color FontColor { get; set; }

        public override string DefaultProperty
        {
            get { return "Text"; }
        }

        public override Size Measure(Size availableSize, IMeasurer measurer)
        {
            Size desiredSize = base.Measure(availableSize, measurer);

            Size size = measurer.MeasureString(this.Text, this.FontFamily, this.FontSize);

            desiredSize.Width += size.Width;
            desiredSize.Height += size.Height;
            this.DesiredSize = desiredSize;

            return this.DesiredSize;
        }

        public override void Render(IRenderer renderer)
        {
            if (this.CanRender)
            {
                base.Render(renderer);

                renderer.DrawString(this.Text, this.FontFamily, this.FontSize, this.FontColor, this.ContentRectangle, this.HorizontalAlignment);
            }
        }
    }
}