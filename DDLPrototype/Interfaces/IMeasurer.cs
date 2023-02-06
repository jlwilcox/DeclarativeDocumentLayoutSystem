namespace DeclarativeLayout
{
    using DeclarativeLayout.Structs;

    public interface IMeasurer
    {
        Size MeasureString(string text, string fontFamily, double fontSize);
    }
}
