namespace DeclarativeLayout
{
    using DeclarativeLayout.Structs;

    public class Image : VisualElement
    {
        public string Source { get; set; }

        public StretchMode StretchMode { get; set; } = StretchMode.Uniform;

        public override void Render(IRenderer renderer)
        {
            if (this.CanRender)
            {
                base.Render(renderer);

                renderer.DrawImage(this.ContentRectangle, this.Source, this.StretchMode);
            }
        }
    }
}
