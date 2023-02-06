namespace DeclarativeLayout
{
    using System.Collections.Generic;

    public interface IParent
    {
        List<IElement> Children { get; set; }
    }
}
