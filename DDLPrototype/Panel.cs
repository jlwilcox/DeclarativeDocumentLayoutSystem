namespace DeclarativeLayout
{
    using System;
    using System.Collections.Generic;

    public abstract class Panel : VisualElement, IParent
    {
        public List<IElement> Children { get; set; } = new List<IElement>();

        public override void Render(IRenderer renderer)
        {
            base.Render(renderer);

            this.UpdateChildrenShowRectangles(this.ShowLayoutRectangles);

            if (this.CanRender)
            {
                foreach (IElement child in this.Children)
                {
                    child.Render(renderer);
                }
            }
        }

        public object GetAttachedPropertyValue(IAttachedProperties element, string propertyName, Type targetType)
        {
            IAttachableProperty attachedProperty = GlobalAttachedPropertyManager.GetAttachedProperty(propertyName, targetType);
            object value = element.GetAttachedPropertyValue(attachedProperty);

            return value;
        }

        private void UpdateChildrenShowRectangles(bool show)
        {
            foreach (IElement child in this.Children)
            {
                child.ShowLayoutRectangles = show;
            }
        }
    }
}
