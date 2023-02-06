namespace DeclarativeLayout
{
    using System;
    using DeclarativeLayout.Structs;

    public abstract class VisualElement : IElement, IAttachedProperties
    {
        private bool canArrange = false;

        private AttachedPropertiesManager attachedPropertyManager = new AttachedPropertiesManager();

        public Structs.Rectangle LayoutRectangle { get; set; }

        public bool CanRender { get; private set; } = false;

        public Thickness Margin { get; set; } = new Thickness(0);

        public Structs.Rectangle BorderRectangle
        {
            get
            {
                return SubtractThickness(this.LayoutRectangle, this.Margin);
            }
        }

        public Structs.Rectangle ContentRectangle
        {
            get
            {
                return SubtractThickness(this.BorderRectangle, this.Padding);
            }
        }

        public Thickness Padding { get; set; } = new Thickness(0);

        public double Width { get; set; } = double.NaN;

        public double Height { get; set; } = double.NaN;

        public virtual bool ShowLayoutRectangles { get; set; }

        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Left;

        public Size DesiredSize { get; protected set; }

        public virtual string DefaultProperty
        {
            get
            {
                return null;
            }
        }

        public virtual Size Measure(Size availableSize, IMeasurer measurer)
        {
            this.DesiredSize = this.GetDesiredSize(availableSize);
            this.canArrange = true;
            return this.DesiredSize;
        }

        public Size GetDesiredSize(Size availableSize, Size contentSize)
        {
            // the height and width is the size of the content + margins + padding
            double height = contentSize.Height + this.Margin.Height + this.Padding.Height + this.GetDimensionValue(this.Height);
            double width = contentSize.Width + this.Margin.Width + this.Padding.Width + this.GetDimensionValue(this.Width);

            // if horizontal alignment is stretch and width not set, the element will request the entire width
            if (this.HorizontalAlignment == HorizontalAlignment.Stretch && double.IsNaN(this.Width))
            {
                if (width < availableSize.Width)
                {
                    width = availableSize.Width;
                }
            }

            return new Size
            {
                Height = height,
                Width = width
            };
        }

        public Size GetDesiredSize(Size availableSize)
        {
            return this.GetDesiredSize(availableSize, new Size());
        }

        public virtual void Arrange(Structs.Rectangle finalRect)
        {
            // arrangement can only be made if measurements have been made
            if (this.canArrange)
            {
                this.LayoutRectangle = finalRect;
                this.CanRender = true;
            }
            else
            {
                throw new InvalidOperationException("Cannot arrange as not measured");
            }
        }

        public virtual void Render(IRenderer renderer)
        {
            // can only render if arrangement has been made
            if (this.CanRender && this.ShowLayoutRectangles)
            {
                // if show layout rectangles flag true, draw rectangles indicating layout, margin and padding

                // layout
                renderer.DrawRectangle(this.LayoutRectangle, 2, new Color(255, 0, 0)); // red

                if (this.Margin.Exists)
                {
                    renderer.DrawRectangle(this.BorderRectangle, 2, new Color(255, 255, 0)); // Yellow
                }

                if (this.Padding.Exists)
                {
                    renderer.DrawRectangle(this.ContentRectangle, 2, new Color(0, 0, 255)); // blue
                }
            }
        }

        public void SetAttachedProperty(IAttachableProperty attachedProperty, object value)
        {
            ((IAttachedProperties)this.attachedPropertyManager).SetAttachedProperty(attachedProperty, value);
        }

        public object GetAttachedPropertyValue(IAttachableProperty attachedProperty)
        {
            return ((IAttachedProperties)this.attachedPropertyManager).GetAttachedPropertyValue(attachedProperty);
        }

        private static Structs.Rectangle SubtractThickness(Structs.Rectangle rect, Thickness thickness)
        {
            // substract given thickness from given rectangle
            rect.Location.X += thickness.Left;
            rect.Size.Width -= thickness.Width;

            rect.Location.Y += thickness.Top;
            rect.Size.Height -= thickness.Height;

            return rect;
        }

        private double GetDimensionValue(double value)
        {
            if (double.IsNaN(value))
            {
                return 0;
            }

            return value;
        }
    }
}