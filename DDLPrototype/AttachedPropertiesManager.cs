namespace DeclarativeLayout
{
    using System;
    using System.Collections.Generic;

    public class AttachedPropertiesManager : IAttachedProperties
    {
        private Dictionary<IAttachableProperty, object> propertyValues = new Dictionary<IAttachableProperty, object>();

        public void SetAttachedProperty(IAttachableProperty attachedProperty, object value)
        {
            if (GlobalAttachedPropertyManager.AttachedPropertyRegistered(attachedProperty))
            {
                if (value.GetType() != attachedProperty.PropertyType)
                {
                    throw new InvalidOperationException("Incorrect type.");
                }

                if (this.propertyValues.ContainsKey(attachedProperty))
                {
                    this.propertyValues[attachedProperty] = value;
                }
                else
                {
                    this.propertyValues.Add(attachedProperty, value);
                }
            }
            else
            {
                throw new InvalidOperationException("Not a registered property of target element.");
            }
        }

        public object GetAttachedPropertyValue(IAttachableProperty attachedProperty)
        {
            if (this.propertyValues.ContainsKey(attachedProperty))
            {
                return this.propertyValues[attachedProperty];
            }
            else
            {
                return attachedProperty.DefaultValue;
            }
        }
    }
}
