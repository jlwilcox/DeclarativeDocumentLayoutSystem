namespace DeclarativeLayout
{
    public partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxShowRectangles = new System.Windows.Forms.CheckBox();
            this.skControl = new SkiaSharp.Views.Desktop.SKControl();
            this.checkBoxRenderSkia = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxDemos = new System.Windows.Forms.ComboBox();
            this.buttonReload = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxShowRectangles
            // 
            this.checkBoxShowRectangles.AutoSize = true;
            this.checkBoxShowRectangles.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxShowRectangles.Checked = true;
            this.checkBoxShowRectangles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowRectangles.Location = new System.Drawing.Point(3, 3);
            this.checkBoxShowRectangles.Name = "checkBoxShowRectangles";
            this.checkBoxShowRectangles.Size = new System.Drawing.Size(145, 17);
            this.checkBoxShowRectangles.TabIndex = 0;
            this.checkBoxShowRectangles.Text = "Show Layout Rectangles";
            this.checkBoxShowRectangles.UseVisualStyleBackColor = true;
            this.checkBoxShowRectangles.CheckedChanged += new System.EventHandler(this.checkBoxShowRectangles_CheckedChanged);
            // 
            // skControl
            // 
            this.skControl.BackColor = System.Drawing.SystemColors.Control;
            this.skControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skControl.Location = new System.Drawing.Point(0, 0);
            this.skControl.Name = "skControl";
            this.skControl.Size = new System.Drawing.Size(800, 450);
            this.skControl.TabIndex = 1;
            this.skControl.Text = "skControl1";
            this.skControl.Visible = false;
            this.skControl.PaintSurface += new System.EventHandler<SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs>(this.skControl_PaintSurface);
            // 
            // checkBoxRenderSkia
            // 
            this.checkBoxRenderSkia.AutoSize = true;
            this.checkBoxRenderSkia.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxRenderSkia.Location = new System.Drawing.Point(3, 26);
            this.checkBoxRenderSkia.Name = "checkBoxRenderSkia";
            this.checkBoxRenderSkia.Size = new System.Drawing.Size(107, 17);
            this.checkBoxRenderSkia.TabIndex = 2;
            this.checkBoxRenderSkia.Text = "Render with Skia";
            this.checkBoxRenderSkia.UseVisualStyleBackColor = true;
            this.checkBoxRenderSkia.CheckedChanged += new System.EventHandler(this.checkBoxRenderSkia_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.comboBoxDemos);
            this.panel1.Controls.Add(this.buttonReload);
            this.panel1.Controls.Add(this.checkBoxShowRectangles);
            this.panel1.Controls.Add(this.checkBoxRenderSkia);
            this.panel1.Location = new System.Drawing.Point(0, 406);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 44);
            this.panel1.TabIndex = 3;
            // 
            // comboBoxDemos
            // 
            this.comboBoxDemos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDemos.FormattingEnabled = true;
            this.comboBoxDemos.Location = new System.Drawing.Point(155, 10);
            this.comboBoxDemos.Name = "comboBoxDemos";
            this.comboBoxDemos.Size = new System.Drawing.Size(182, 21);
            this.comboBoxDemos.TabIndex = 4;
            // 
            // buttonReload
            // 
            this.buttonReload.Location = new System.Drawing.Point(343, 9);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(75, 23);
            this.buttonReload.TabIndex = 3;
            this.buttonReload.Text = "Load";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.skControl);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Declarative Layout System Prototype";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxShowRectangles;
        private SkiaSharp.Views.Desktop.SKControl skControl;
        private System.Windows.Forms.CheckBox checkBoxRenderSkia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.ComboBox comboBoxDemos;
    }
}

