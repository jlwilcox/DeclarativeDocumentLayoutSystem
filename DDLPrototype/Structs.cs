namespace DeclarativeLayout.Structs
{
    public enum StretchMode
    {
        Fill,
        None,
        Uniform,
        UniformToFill
    }

    public enum HorizontalAlignment
    {
        Left,
        Center,
        Right,
        Stretch
    }

    public struct Size
    {
        public double Width;
        public double Height;

        public override string ToString()
        {
            return this.Width.ToString() + ", " + this.Height.ToString();
        }
    }

    public struct Location
    {
        public double X;
        public double Y;

        public override string ToString()
        {
            return this.X.ToString() + ", " + this.Y.ToString();
        }
    }

    public struct Rectangle
    {
        public Location Location;
        public Size Size;

        public override string ToString()
        {
            return this.Location.ToString() + ", " + this.Size.ToString();
        }
    }

    public struct Color
    {
        public int A, R, G, B;

        public Color(int r, int g, int b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = 255;
        }

        public Color(int a, int r, int g, int b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }
    }

    public struct Thickness
    {
        public double Bottom;
        public double Left;
        public double Right;
        public double Top;

        public Thickness(double thickness)
        {
            this.Bottom = this.Left = this.Right = this.Top = thickness;
        }

        public double Width
        {
            get
            {
                return this.Left + this.Right;
            }
        }

        public double Height
        {
            get
            {
                return this.Top + this.Bottom;
            }
        }

        public bool Exists
        {
            get
            {
                return this.Top > 0 || this.Bottom > 0 || this.Left > 0 || this.Right > 0;
            }
        }
    }
}