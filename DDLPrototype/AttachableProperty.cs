namespace DeclarativeLayout
{
    using System;

    public class AttachableProperty : IAttachableProperty
    {
        public AttachableProperty(string name, Type propertyType, Type targetElementType, object defaultValue)
        {
            this.Name = name;
            this.PropertyType = propertyType;
            this.TargetElementType = targetElementType;
            this.DefaultValue = defaultValue;
        }

        public string Name { get; set; }

        public Type PropertyType { get; set; }

        public Type TargetElementType { get; set; }

        public object DefaultValue { get; set; }
    }
}
