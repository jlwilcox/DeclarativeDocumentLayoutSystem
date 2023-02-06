namespace DeclarativeLayout
{
    using DeclarativeLayout.Structs;

    public class Rectangle : VisualElement
    {
        public Color Fill { get; set; } = new Color(0, 255, 0);

        public override void Render(IRenderer renderer)
        {
            if (this.CanRender)
            {
                base.Render(renderer);

                renderer.FillRectangle(this.ContentRectangle, this.Fill);
            }
        }
    }
}
