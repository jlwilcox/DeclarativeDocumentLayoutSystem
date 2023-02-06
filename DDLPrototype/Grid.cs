namespace DeclarativeLayout
{
    using DeclarativeLayout.Structs;

    public class Grid : Panel
    {
        public override Size Measure(Size availableSize, IMeasurer measurer)
        {
            base.Measure(availableSize, measurer);

            Size desiredSize = this.ContentRectangle.Size;

            foreach (IElement child in this.Children)
            {
                child.Measure(availableSize, measurer);
                if (child.DesiredSize.Width > desiredSize.Width)
                {
                    desiredSize.Width = child.DesiredSize.Width;
                }

                if (child.DesiredSize.Height > desiredSize.Height)
                {
                    desiredSize.Height = child.DesiredSize.Height;
                }
            }

            this.DesiredSize = desiredSize;
            return this.DesiredSize;
        }

        public override void Arrange(Structs.Rectangle finalRectangle)
        {
            foreach (IElement child in this.Children)
            {
                Structs.Rectangle rectangle = new Structs.Rectangle
                {
                    Location = new Location
                    {
                        X = finalRectangle.Location.X,
                        Y = finalRectangle.Location.Y
                    },
                    Size = new Size
                    {
                        Width = finalRectangle.Size.Width,
                        Height = finalRectangle.Size.Height
                    }
                };
                child.Arrange(rectangle);
            }

            base.Arrange(finalRectangle);
        }
    }
}
