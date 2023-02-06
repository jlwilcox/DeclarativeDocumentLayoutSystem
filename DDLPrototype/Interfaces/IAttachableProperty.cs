namespace DeclarativeLayout
{
    using System;

    public interface IAttachableProperty
    {
        string Name { get; set; }

        Type PropertyType { get; set; }

        Type TargetElementType { get; set; }

        object DefaultValue { get; set; }
    }
}
