namespace DeclarativeLayout
{
    using System;
    using System.Collections.Generic;

    public class GlobalAttachedPropertyManager
    {
        private static List<IAttachableProperty> registeredProperties = new List<IAttachableProperty>();

        public static void RegisterAttachedProperty(IAttachableProperty attachedProperty)
        {
            if (registeredProperties.Contains(attachedProperty))
            {
                throw new InvalidOperationException("Property already registered.");
            }

            registeredProperties.Add(attachedProperty);
        }

        public static IAttachableProperty GetAttachedProperty(string name, Type targetElementType)
        {
            foreach (IAttachableProperty attachedProperty in registeredProperties)
            {
                if (attachedProperty.Name == name && targetElementType == attachedProperty.TargetElementType)
                {
                    return attachedProperty;
                }
            }

            throw new InvalidOperationException("Property is not registed.");
        }

        public static bool AttachedPropertyRegistered(IAttachableProperty attachedProperty)
        {
            return registeredProperties.Contains(attachedProperty);
        }
    }
}
