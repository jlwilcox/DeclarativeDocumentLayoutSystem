namespace DeclarativeLayout
{
    using System;
    using System.Windows.Forms;

    public class Layout
    {
        private Form form;

        public Layout(Form form, Grid grid = null)
        {
            this.Grid = grid;

            if (this.Grid == null)
            {
                this.Grid = new Grid();
            }

            this.form = form;
        }

        public Grid Grid { get; set; }

        public void Refresh(IMeasurer measurer)
        {
            this.LayOut(measurer);
            this.Arrange();
            this.form.Invalidate();
        }

        public void Render(IRenderer renderer)
        {
            this.Grid.Render(renderer);
            this.form.Invalidate();
        }

        protected void Arrange()
        {
            // Arrange
            Structs.Rectangle formRectangle = new Structs.Rectangle
            {
                Location = new Structs.Location
                {
                    X = 0,
                    Y = 0
                },
                Size = new Structs.Size
                {
                    Width = this.form.ClientRectangle.Width,
                    Height = this.form.ClientRectangle.Height
                }
            };

            Grid.Arrange(formRectangle);
        }

        protected void LayOut(IMeasurer measurer)
        {
            // Lay out
            Structs.Size size = new Structs.Size
            {
                Width = this.form.ClientRectangle.Width,
                Height = this.form.ClientRectangle.Height
            };

            Structs.Size panelSize = Grid.Measure(size, measurer);
            Console.WriteLine("Panel size: " + panelSize.ToString());
        }
    }
}
