namespace DeclarativeLayout
{
    public interface IAttachedProperties
    {
        void SetAttachedProperty(IAttachableProperty attachedProperty, object value);

        object GetAttachedPropertyValue(IAttachableProperty attachedProperty);
    }
}
