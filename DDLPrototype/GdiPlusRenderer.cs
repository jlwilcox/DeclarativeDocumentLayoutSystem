namespace DeclarativeLayout
{
    using System;
    using System.Drawing;
    using DeclarativeLayout.Structs;

    public class GdiPlusRenderer : IRenderer
    {
        private Graphics graphics = null;

        private GenericFileObjectCache<System.Drawing.Image> imageCach = new GenericFileObjectCache<System.Drawing.Image>();

        public void SetGraphics(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void DrawImage(Structs.Rectangle rectangle, string imagePath, StretchMode stretchMode)
        {
            this.CheckGraphicsIsSet();

            RectangleF drawRectF = LayoutRectToDrawingRectF(rectangle);

            // Anonymous function demonstration
            System.Drawing.Image source = this.imageCach.CacheAndGetItem(imagePath, () => { return System.Drawing.Image.FromFile(imagePath); });

            switch (stretchMode)
            {
                case StretchMode.Fill:
                    this.graphics.DrawImage(source, drawRectF);
                    break;
                case StretchMode.None:
                    System.Drawing.Rectangle drawRect = LayoutRectToDrawingRect(rectangle);
                    this.graphics.DrawImageUnscaled(source, drawRect);
                    break;
                case StretchMode.Uniform:
                    this.DrawImageUniform(source, drawRectF, this.graphics, false);
                    break;
                case StretchMode.UniformToFill:
                    this.DrawImageUniform(source, drawRectF, this.graphics, true);
                    break;
            }
        }

        public void DrawRectangle(Structs.Rectangle rectangle, double thickness, Structs.Color color)
        {
            this.CheckGraphicsIsSet();

            System.Drawing.Rectangle drawRectangle = LayoutRectToDrawingRect(rectangle);

            Pen pen = new Pen(ColorToGDIColor(color), (float)thickness);

            this.graphics.DrawRectangle(pen, drawRectangle);
        }

        public void DrawString(string text, string fontFamily, double fontSize, Structs.Color fontColor, Structs.Rectangle rectangle, HorizontalAlignment horizontalAlignment)
        {
            this.CheckGraphicsIsSet();

            Font font = new Font(fontFamily, (float)fontSize, GraphicsUnit.Pixel);

            this.graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic)
            { FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip | StringFormatFlags.NoWrap };

            switch (horizontalAlignment)
            {
                case HorizontalAlignment.Center:
                case HorizontalAlignment.Stretch:
                    stringFormat.Alignment = StringAlignment.Center;
                    break;
                case HorizontalAlignment.Right:
                    stringFormat.Alignment = StringAlignment.Far;
                    break;
            }

            System.Drawing.Color gdiColor = ColorToGDIColor(fontColor);

            this.graphics.DrawString(text, font, new SolidBrush(gdiColor), LayoutRectToDrawingRectF(rectangle), stringFormat);
        }

        public void FillRectangle(Structs.Rectangle rectangle, Structs.Color color)
        {
            this.CheckGraphicsIsSet();

            RectangleF drawRectangle = LayoutRectToDrawingRectF(rectangle);

            Brush brush = new SolidBrush(ColorToGDIColor(color));

            this.graphics.FillRectangle(brush, drawRectangle);
        }

        private static System.Drawing.Rectangle LayoutRectToDrawingRect(Structs.Rectangle rect)
        {
            return new System.Drawing.Rectangle((int)rect.Location.X, (int)rect.Location.Y, (int)rect.Size.Width, (int)rect.Size.Height);
        }

        private static PointF LayoutRectToPointF(Structs.Rectangle rect)
        {
            return new PointF((float)rect.Location.X, (float)rect.Location.Y);
        }

        private static RectangleF LayoutRectToDrawingRectF(Structs.Rectangle rect)
        {
            return new RectangleF((float)rect.Location.X, (float)rect.Location.Y, (float)rect.Size.Width, (float)rect.Size.Height);
        }

        private static System.Drawing.Color ColorToGDIColor(Structs.Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private void CheckGraphicsIsSet()
        {
            if (this.graphics == null)
            {
                throw new InvalidOperationException("Graphics must be set before rendering can occur.");
            }

            try
            {
                Region region = this.graphics.Clip;
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException("Graphics must be set again before rendering can occur.", ex);
            }
        }

        private void DrawImageUniform(System.Drawing.Image image, RectangleF rectangle, Graphics graphics, bool fill)
        {
            float horizontalScale = rectangle.Width / image.Width;
            float verticalScale = rectangle.Height / image.Height;

            float verticalWidth = image.Width * verticalScale;
            float verticalHeight = image.Height * verticalScale;

            float horizontalWidth = image.Width * horizontalScale;
            float horizontalHeight = image.Height * horizontalScale;

            if ((verticalWidth > rectangle.Width && !fill) || (verticalWidth < rectangle.Width && fill))
            {
                float y = rectangle.Y + ((rectangle.Height - horizontalHeight) / 2);

                RectangleF drawRectangle = new RectangleF(rectangle.X, y, horizontalWidth, horizontalHeight);

                graphics.DrawImage(image, drawRectangle);
            }
            else
            {
                float x = rectangle.X + ((rectangle.Width - verticalWidth) / 2);

                RectangleF drawRectangle = new RectangleF(x, rectangle.Y, verticalWidth, verticalHeight);

                graphics.DrawImage(image, drawRectangle);
            }
        }
    }
}
