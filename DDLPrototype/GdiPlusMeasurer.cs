namespace DeclarativeLayout
{
    using System;
    using System.Drawing;
    using Size = Structs.Size;

    public class GdiPlusMeasurer : IMeasurer
    {
        public Size MeasureString(string text, string fontFamily, double fontSize)
        {
            Font font = new Font(fontFamily, (float)fontSize, GraphicsUnit.Pixel);

            Size size = new Size();

            StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic)
            { FormatFlags = StringFormatFlags.MeasureTrailingSpaces };

            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF textSize = g.MeasureString(text, font, int.MaxValue, stringFormat);
                size.Height = textSize.Height;
                size.Width = textSize.Width;
            }

            return size;
        }
    }
}
