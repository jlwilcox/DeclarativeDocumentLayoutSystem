namespace DeclarativeLayout
{
    using System;
    using DeclarativeLayout.Structs;

    public enum Dock
    {
        Left,
        Top,
        Right,
        Bottom,
    }

    public class DockPanel : Panel
    {
        public override Size Measure(Size availableSize, IMeasurer measurer)
        {
            base.Measure(availableSize, measurer);

            Size remainingSize = this.ContentRectangle.Size;
            Size contentSize = new Size();

            foreach (IElement child in this.Children)
            {
                child.Measure(remainingSize, measurer);

                switch (this.GetAttachedPropertyValue((IAttachedProperties)child, "Dock", typeof(DockPanel)))
                {
                    case Dock.Left:
                    case Dock.Right:
                        contentSize.Height = Math.Max(contentSize.Height, contentSize.Height + child.DesiredSize.Height);

                        // deduct desired width of child
                        remainingSize.Width -= child.DesiredSize.Width;
                        break;

                    case Dock.Top:
                    case Dock.Bottom:
                        contentSize.Width = Math.Max(contentSize.Width, contentSize.Width + child.DesiredSize.Width);

                        // deduct desired height of child
                        remainingSize.Height -= child.DesiredSize.Height;
                        break;
                }
            }

            if (this.HorizontalAlignment == HorizontalAlignment.Stretch)
            {
               contentSize.Width = availableSize.Width;
            }

            this.DesiredSize = this.GetDesiredSize(contentSize);

            return this.DesiredSize;
        }

        public override void Arrange(Structs.Rectangle finalRect)
        {
            double top = finalRect.Location.Y + this.Margin.Top + this.Padding.Top;
            double left = finalRect.Location.X + this.Margin.Left + this.Padding.Left;
            double right = finalRect.Location.X + finalRect.Size.Width - this.Margin.Right  + this.Padding.Right;
            double bottom = finalRect.Location.Y + finalRect.Size.Height - this.Margin.Bottom + this.Padding.Bottom;

            double accumulatedLeft = 0;
            double accumulatedTop = 0;
            double accumulatedRight = 0;
            double accumulatedBottom = 0;

            foreach (IElement child in this.Children)
            {
                Structs.Rectangle rect = new Structs.Rectangle
                {
                    Location = new Location
                    {
                        X = left + accumulatedLeft,
                        Y = top + accumulatedTop
                    },
                    Size = new Size
                    {
                        Width = Math.Max(0.0, right - left - (accumulatedLeft + accumulatedRight)),
                        Height = Math.Max(0.0, bottom - top - (accumulatedTop + accumulatedBottom))
                    }
                };

                switch (this.GetAttachedPropertyValue((IAttachedProperties)child, "Dock", typeof(DockPanel)))
                {
                    case Dock.Left:
                        accumulatedLeft += child.DesiredSize.Width;
                        rect.Size.Width = child.DesiredSize.Width;
                        break;

                    case Dock.Right:
                        accumulatedRight += child.DesiredSize.Width;
                        rect.Location.X = Math.Max(0.0, right - accumulatedRight);
                        rect.Size.Width = child.DesiredSize.Width;
                        break;

                    case Dock.Top:
                        accumulatedTop += child.DesiredSize.Height;
                        rect.Size.Height = child.DesiredSize.Height;
                        break;

                    case Dock.Bottom:
                        accumulatedBottom += child.DesiredSize.Height;
                        rect.Location.Y = Math.Max(0.0, bottom - accumulatedBottom);
                        rect.Size.Height = child.DesiredSize.Height;
                        break;
                }

                child.Arrange(rect);
            }

            base.Arrange(finalRect);
        }
    }
}
