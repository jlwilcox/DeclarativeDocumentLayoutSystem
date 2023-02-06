namespace DeclarativeLayout
{
    using DeclarativeLayout.Structs;

    public interface IElement
    {
        Structs.Rectangle LayoutRectangle { get; set; }

        bool CanRender { get; }

        Thickness Margin { get; set; }

        Structs.Rectangle BorderRectangle { get; }

        Structs.Rectangle ContentRectangle { get; }

        Thickness Padding { get; set; }

        double Width { get; set; }

        double Height { get; set; }

        bool ShowLayoutRectangles { get; set; }

        HorizontalAlignment HorizontalAlignment { get; set; }

        string DefaultProperty { get;  }

        Size DesiredSize { get; }

        Size Measure(Size availableSize, IMeasurer measurer);

        Size GetDesiredSize(Size availableSize, Size contentSize);

        Size GetDesiredSize(Size availableSize);

        void Arrange(Structs.Rectangle finalRectangle);

        void Render(IRenderer renderer);
    }
}
