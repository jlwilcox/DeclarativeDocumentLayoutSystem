namespace DeclarativeLayout
{
    using System;
    using DeclarativeLayout.Structs;
    using SkiaSharp;

    public class SkiaRenderer : IRenderer
    {
        private SKSurface surface = null;

        private GenericFileObjectCache<SKImage> imageCach = new GenericFileObjectCache<SKImage>();

        public void SetGraphics(SKSurface surface)
        {
            this.surface = surface;
        }

        public void DrawImage(Structs.Rectangle rectangle, string imagePath, StretchMode stretchMode)
        {
            this.CheckGraphicsIsSet();

            SKRect drawRect = LayoutRectToSKRect(rectangle);

            // Anonymous function demonstration
            SKImage source = this.imageCach.CacheAndGetItem(imagePath, () =>
            {
                SKBitmap bitmap = SKBitmap.Decode(imagePath);
                return SKImage.FromBitmap(bitmap); 
            });

            SKPaint paint = new SKPaint()
            {
                FilterQuality = SKFilterQuality.High
            };

            switch (stretchMode)
            {
                case StretchMode.Fill:
                    this.surface.Canvas.DrawImage(source, drawRect, paint);
                    break;
                case StretchMode.None:
                    this.surface.Canvas.DrawImage(source, LayoutRectToSKPoint(rectangle), paint);
                    break;
                case StretchMode.Uniform:
                    this.DrawImageUniform(source, drawRect, this.surface, false);
                    break;
                case StretchMode.UniformToFill:
                    this.DrawImageUniform(source, drawRect, this.surface, true);
                    break;
            }
        }

        public void DrawRectangle(Structs.Rectangle rectangle, double thickness, Color color)
        {
            this.CheckGraphicsIsSet();

            SKRect drawRectangle = LayoutRectToSKRect(rectangle);

            SKPaint paint = new SKPaint()
            {
                Color = ColorToSKColor(color),
                IsStroke = true,
                StrokeWidth = (float)thickness
            };

            this.surface.Canvas.DrawRect(drawRectangle, paint);
        }

        public void DrawString(string text, string fontFamily, double fontSize, Structs.Color fontColor, Structs.Rectangle rectangle, HorizontalAlignment horizontalAlignment)
        {
            this.CheckGraphicsIsSet();

            SKTextAlign textAlign = SKTextAlign.Left;

            SkiaMeasurer skiaMeasurer = new SkiaMeasurer();

            SKPoint point = LayoutRectToSKPoint(rectangle);
            point.Y += (float)skiaMeasurer.MeasureString(text, fontFamily, fontSize).Height;

            switch (horizontalAlignment)
            {
                case HorizontalAlignment.Center:
                case HorizontalAlignment.Stretch:
                    textAlign = SKTextAlign.Center;
                    point.X += (float)rectangle.Size.Width / 2;
                    break;
                case HorizontalAlignment.Right:
                    textAlign = SKTextAlign.Right;
                    point.X += (float)rectangle.Size.Width;
                    break;
            }

            SKColor color = ColorToSKColor(fontColor);

            SKTypeface typeface = SKTypeface.FromFamilyName(fontFamily);

            SKPaint paint = new SKPaint
            {
                TextSize = (float)fontSize,
                IsAntialias = true,
                Color = color,
                Typeface = typeface,
                TextAlign = textAlign,
            };

            point.Y -= paint.FontMetrics.Descent;

            this.surface.Canvas.DrawText(text, point, paint);
        }

        public void FillRectangle(Structs.Rectangle rectangle, Structs.Color color)
        {
            this.CheckGraphicsIsSet();

            SKRect drawRectangle = LayoutRectToSKRect(rectangle);

            SKShader shader = SKShader.CreateColor(ColorToSKColor(color));

            SKPaint paint = new SKPaint()
            {
                Shader = shader
            };

            this.surface.Canvas.DrawRect(drawRectangle, paint);
        }

        private static SKRect LayoutRectToSKRect(Structs.Rectangle rect)
        {
            return new SKRect((float)rect.Location.X, (float)rect.Location.Y, (float)(rect.Size.Width + rect.Location.X), (float)(rect.Size.Height + rect.Location.Y));
        }

        private static SKPoint LayoutRectToSKPoint(Structs.Rectangle rect)
        {
            return new SKPoint((float)rect.Location.X, (float)rect.Location.Y);
        }

        private static SKPaint ColorToSKPaintStroke(Color color, double strokeWidth)
        {
            SKPaint paint = new SKPaint()
            {
                Color = ColorToSKColor(color),
                IsStroke = true,
                StrokeWidth = (float)strokeWidth
            };

            return paint;
        }

        private static SKColor ColorToSKColor(Color color)
        {
            return new SKColor((byte)color.R, (byte)color.G, (byte)color.B, (byte)color.A);
        }

        private void CheckGraphicsIsSet()
        {
            if (this.surface == null)
            {
                throw new InvalidOperationException("Graphics must be set before rendering can occur.");
            }
        }

        private void DrawImageUniform(SKImage image, SKRect rectangle, SKSurface surface, bool fill)
        {
            float horizontalScale = rectangle.Width / image.Width;
            float verticalScale = rectangle.Height / image.Height;

            float verticalWidth = image.Width * verticalScale;
            float verticalHeight = image.Height * verticalScale;

            float horizontalWidth = image.Width * horizontalScale;
            float horizontalHeight = image.Height * horizontalScale;

            SKPaint paint = new SKPaint()
            {
                FilterQuality = SKFilterQuality.High
            };

            if ((verticalWidth > rectangle.Width && !fill) || (verticalWidth < rectangle.Width && fill))
            {
                float y = rectangle.Top + ((rectangle.Height - horizontalHeight) / 2);

                SKRect drawRectangle = new SKRect(rectangle.Left, y, rectangle.Left + horizontalWidth, y + horizontalHeight);

                surface.Canvas.DrawImage(image, drawRectangle, paint);
            }
            else
            {
                float x = rectangle.Left + ((rectangle.Width - verticalWidth) / 2);

                SKRect drawRectangle = new SKRect(x, rectangle.Top, verticalWidth + x, verticalHeight + rectangle.Top);

                surface.Canvas.DrawImage(image, drawRectangle, paint);
            }
        }
    }
}
