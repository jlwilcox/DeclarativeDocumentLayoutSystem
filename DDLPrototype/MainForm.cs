namespace DeclarativeLayout
{
    using System;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private Layout layout;
        private GdiPlusRenderer gdiPlusRenderer = new GdiPlusRenderer();
        private GdiPlusMeasurer gdiPlusMeasurer = new GdiPlusMeasurer();

        private SkiaRenderer skiaRenderer = new SkiaRenderer();
        private SkiaMeasurer skiaMeasurer = new SkiaMeasurer();

        private IRenderer activeRenderer;
        private IMeasurer activeMeasurer;

        public MainForm()
        {
            this.InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Register attached properties
            GlobalAttachedPropertyManager.RegisterAttachedProperty(new AttachableProperty("Dock", typeof(Dock), typeof(DockPanel), DeclarativeLayout.Dock.Left));

            this.activeRenderer = this.gdiPlusRenderer;
            this.activeMeasurer = this.gdiPlusMeasurer;

            this.FindDemos();
        }

        private void FindDemos()
        {
            foreach (string file in System.IO.Directory.EnumerateFiles(Application.StartupPath + @"\demos", "*.ddl"))
            {
                comboBoxDemos.Items.Add(System.IO.Path.GetFileName(file));
            }

            comboBoxDemos.SelectedIndex = 0;
        }

        private void LoadLayout(string file)
        {
            Grid grid = DdlParser.LoadGrid(Application.StartupPath + @"\demos\" + file);

            if (this.layout == null)
            {
                this.layout = new Layout(this, grid);
            }
            else
            {
                this.layout.Grid = grid;
            }

            this.layout.Refresh(this.activeMeasurer);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (!this.checkBoxRenderSkia.Checked && this.layout != null)
            {
                this.gdiPlusRenderer.SetGraphics(e.Graphics);
                this.layout.Render(this.activeRenderer);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.layout != null)
            {
                this.layout.Refresh(this.activeMeasurer);
            }
        }

        private void checkBoxShowRectangles_CheckedChanged(object sender, EventArgs e)
        {
            this.layout.Grid.ShowLayoutRectangles = this.checkBoxShowRectangles.Checked;

            if (this.checkBoxRenderSkia.Checked)
            {
                this.skControl.Invalidate();
            }
            else
            {
                this.Invalidate();
            }
        }

        private void checkBoxRenderSkia_CheckedChanged(object sender, EventArgs e)
        {
            this.skControl.Visible = this.checkBoxRenderSkia.Checked;

            if (this.checkBoxRenderSkia.Checked)
            {
                this.activeRenderer = this.skiaRenderer;
                this.activeMeasurer = this.skiaMeasurer;
            }
            else
            {
                this.activeRenderer = this.gdiPlusRenderer;
                this.activeMeasurer = this.gdiPlusMeasurer;
            }

            this.layout.Refresh(this.activeMeasurer);
            this.Invalidate();
        }

        private void skControl_PaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            if (this.checkBoxRenderSkia.Checked)
            {
                this.skiaRenderer.SetGraphics(e.Surface);
                this.layout.Render(this.skiaRenderer);
            }
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            this.LoadLayout(comboBoxDemos.SelectedItem.ToString());
        }
    }
}