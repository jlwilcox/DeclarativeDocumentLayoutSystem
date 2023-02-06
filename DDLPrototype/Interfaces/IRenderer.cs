namespace DeclarativeLayout
{
    using DeclarativeLayout.Structs;

    public interface IRenderer
    {
        void DrawRectangle(Structs.Rectangle rectangle, double thickness, Color color);

        void DrawImage(Structs.Rectangle rectangle, string imagePath, StretchMode stretchMode);

        void FillRectangle(Structs.Rectangle rectangle, Color color);

        void DrawString(string text, string fontFamily, double fontSize, Color fontColor, Structs.Rectangle rectangle, HorizontalAlignment horizontalAlignment);
    }
}
