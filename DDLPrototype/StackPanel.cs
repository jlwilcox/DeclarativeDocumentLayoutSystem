namespace DeclarativeLayout
{
    using System;
    using DeclarativeLayout.Structs;

    public class StackPanel : Panel
    {
        public bool Horizontal { get; set; } = false;

        public override Size Measure(Size availableSize, IMeasurer measurer)
        {
            base.Measure(availableSize, measurer);

            Size remainingSize = this.ContentRectangle.Size;
            Size contentSize = new Size();

            foreach (IElement child in this.Children)
            {
                child.Measure(remainingSize, measurer);

                if (this.Horizontal)
                {
                    // horizontal
                    contentSize.Width += child.DesiredSize.Width;
                    contentSize.Height = Math.Max(child.DesiredSize.Height, contentSize.Height);

                    // deduct desired width of child
                    remainingSize.Width -= child.DesiredSize.Width;
                }
                else
                {         
                    // vertical
                    contentSize.Height += child.DesiredSize.Height;
                    contentSize.Width = Math.Max(child.DesiredSize.Width, contentSize.Width);

                    // deduct desired height of child
                    remainingSize.Height -= child.DesiredSize.Height;
                }
            }

            if (this.HorizontalAlignment == HorizontalAlignment.Stretch)
            {
               contentSize.Width = availableSize.Width;
            }

            this.DesiredSize = this.GetDesiredSize(availableSize, contentSize);

            return this.DesiredSize;
        }

        public override void Arrange(Structs.Rectangle finalRect)
        {
            double top = finalRect.Location.Y + this.Margin.Top + this.Padding.Top;
            double left = finalRect.Location.X + this.Margin.Left + this.Padding.Left;
            double right = finalRect.Location.X + finalRect.Size.Width - this.Margin.Right  + this.Padding.Right;

            if (this.Horizontal)
            {
                foreach (IElement child in this.Children)
                {
                    // horizontal alignment
                    double x = left;

                    Structs.Rectangle rect = new Structs.Rectangle
                    {
                        Location = new Location
                        {
                            X = x,
                            Y = top
                        },
                        Size = new Size
                        {
                            Width = child.DesiredSize.Width,
                            Height = child.DesiredSize.Height
                        }
                    };
                    left += child.DesiredSize.Width;
                    child.Arrange(rect);
                }
            }
            else
            {
                // vertical
                foreach (IElement child in this.Children)
                {
                    // determine x depending on horizontal alignment
                    double x = left;

                    if (this.HorizontalAlignment == HorizontalAlignment.Stretch)
                    {
                        if (child.HorizontalAlignment == HorizontalAlignment.Right)
                        {
                            x = right - child.DesiredSize.Width;
                        }
                        else if (child.HorizontalAlignment == HorizontalAlignment.Center)
                        {
                            x = (finalRect.Size.Width / 2) - (child.DesiredSize.Width / 2) + (child.Margin.Left / 2) - (child.Margin.Right / 2);
                            Console.WriteLine(child.Margin.Left);
                        }
                    }

                    Structs.Rectangle rect = new Structs.Rectangle
                    {
                        Location = new Location
                        {
                            X = x,
                            Y = top
                        },
                        Size = new Size
                        {
                            Width = child.DesiredSize.Width,
                            Height = child.DesiredSize.Height
                        }
                    };
                    top += child.DesiredSize.Height;
                    child.Arrange(rect);
                }
            }

            base.Arrange(finalRect);
        }
    }
}