namespace DeclarativeLayout
{
    using DeclarativeLayout.Structs;
    using SkiaSharp;

    public class SkiaMeasurer : IMeasurer
    {
        public Size MeasureString(string text, string fontFamily, double fontSize)
        {
            SKTypeface typeface = SKTypeface.FromFamilyName(fontFamily);

            SKPaint paint = new SKPaint
            {
                TextSize = (float)fontSize,
                IsAntialias = true,
                Typeface = typeface
            };

            Size size = new Size();

            size.Height = paint.FontMetrics.Ascent * -1;
            size.Height += paint.FontMetrics.Descent;
            size.Width = paint.MeasureText(text);

            return size;
        }
    }
}
