namespace RemoteSupport.Client.View
{
	partial class StreamForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StreamForm));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x1080ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x768ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x720ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x576ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x450ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x360ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x270ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.autoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.centerLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(36, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(787, 431);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.toolStrip1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(36, 431);
			this.panel1.TabIndex = 4;
			this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.Color.White;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
			this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton4});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(36, 431);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
			this.toolStrip1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.AutoSize = false;
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(29, 28);
			this.toolStripButton1.Text = "Disconnect";
			this.toolStripButton1.ToolTipText = "Disconnect";
			this.toolStripButton1.Click += new System.EventHandler(this.disconnect_Btn_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(33, 6);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.AutoSize = false;
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(33, 28);
			this.toolStripButton2.Text = "Full screen";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.AutoSize = false;
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.x1080ToolStripMenuItem,
            this.x768ToolStripMenuItem,
            this.x720ToolStripMenuItem,
            this.x576ToolStripMenuItem,
            this.x450ToolStripMenuItem,
            this.x360ToolStripMenuItem,
            this.x270ToolStripMenuItem});
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.White;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(35, 28);
			this.toolStripDropDownButton1.Text = "Resolution";
			this.toolStripDropDownButton1.ToolTipText = "Resolution";
			// 
			// autoToolStripMenuItem
			// 
			this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
			this.autoToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.autoToolStripMenuItem.Tag = "0";
			this.autoToolStripMenuItem.Text = "Auto";
			this.autoToolStripMenuItem.Visible = false;
			this.autoToolStripMenuItem.Click += new System.EventHandler(this.resolutionToolStripMenuItem_Click);
			// 
			// x1080ToolStripMenuItem
			// 
			this.x1080ToolStripMenuItem.Name = "x1080ToolStripMenuItem";
			this.x1080ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x1080ToolStripMenuItem.Tag = "7";
			this.x1080ToolStripMenuItem.Text = "1920 x 1080";
			this.x1080ToolStripMenuItem.Click += new System.EventHandler(this.resolutionToolStripMenuItem_Click);
			// 
			// x768ToolStripMenuItem
			// 
			this.x768ToolStripMenuItem.Name = "x768ToolStripMenuItem";
			this.x768ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x768ToolStripMenuItem.Tag = "6";
			this.x768ToolStripMenuItem.Text = "1366 x 768";
			this.x768ToolStripMenuItem.Click += new System.EventHandler(this.resolutionToolStripMenuItem_Click);
			// 
			// x720ToolStripMenuItem
			// 
			this.x720ToolStripMenuItem.Name = "x720ToolStripMenuItem";
			this.x720ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x720ToolStripMenuItem.Tag = "5";
			this.x720ToolStripMenuItem.Text = "1280 x 720";
			this.x720ToolStripMenuItem.Click += new System.EventHandler(this.resolutionToolStripMenuItem_Click);
			// 
			// x576ToolStripMenuItem
			// 
			this.x576ToolStripMenuItem.Name = "x576ToolStripMenuItem";
			this.x576ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x576ToolStripMenuItem.Tag = "4";
			this.x576ToolStripMenuItem.Text = "1024 x 576";
			this.x576ToolStripMenuItem.Click += new System.EventHandler(this.resolutionToolStripMenuItem_Click);
			// 
			// x450ToolStripMenuItem
			// 
			this.x450ToolStripMenuItem.Checked = true;
			this.x450ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.x450ToolStripMenuItem.Name = "x450ToolStripMenuItem";
			this.x450ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x450ToolStripMenuItem.Tag = "3";
			this.x450ToolStripMenuItem.Text = "800 x 450";
			this.x450ToolStripMenuItem.Click += new System.EventHandler(this.resolutionToolStripMenuItem_Click);
			// 
			// x360ToolStripMenuItem
			// 
			this.x360ToolStripMenuItem.Name = "x360ToolStripMenuItem";
			this.x360ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x360ToolStripMenuItem.Tag = "2";
			this.x360ToolStripMenuItem.Text = "640 x 360";
			this.x360ToolStripMenuItem.Click += new System.EventHandler(this.resolutionToolStripMenuItem_Click);
			// 
			// x270ToolStripMenuItem
			// 
			this.x270ToolStripMenuItem.Name = "x270ToolStripMenuItem";
			this.x270ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x270ToolStripMenuItem.Tag = "1";
			this.x270ToolStripMenuItem.Text = "480 x 270";
			this.x270ToolStripMenuItem.Click += new System.EventHandler(this.resolutionToolStripMenuItem_Click);
			// 
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.AutoSize = false;
			this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem1,
            this.toolStripMenuItem5,
            this.toolStripMenuItem4,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2,
            this.toolStripMenuItem6});
			this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
			this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.White;
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.Size = new System.Drawing.Size(35, 28);
			this.toolStripDropDownButton2.Text = "Frames per second";
			// 
			// autoToolStripMenuItem1
			// 
			this.autoToolStripMenuItem1.Name = "autoToolStripMenuItem1";
			this.autoToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
			this.autoToolStripMenuItem1.Tag = "0";
			this.autoToolStripMenuItem1.Text = "Auto";
			this.autoToolStripMenuItem1.Click += new System.EventHandler(this.fpsToolStripMenuItem1_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(100, 22);
			this.toolStripMenuItem5.Tag = "5";
			this.toolStripMenuItem5.Text = "30";
			this.toolStripMenuItem5.Click += new System.EventHandler(this.fpsToolStripMenuItem1_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(100, 22);
			this.toolStripMenuItem4.Tag = "4";
			this.toolStripMenuItem4.Text = "20";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.fpsToolStripMenuItem1_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Checked = true;
			this.toolStripMenuItem3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(100, 22);
			this.toolStripMenuItem3.Tag = "3";
			this.toolStripMenuItem3.Text = "15";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.fpsToolStripMenuItem1_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
			this.toolStripMenuItem2.Tag = "2";
			this.toolStripMenuItem2.Text = "10";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.fpsToolStripMenuItem1_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(100, 22);
			this.toolStripMenuItem6.Tag = "1";
			this.toolStripMenuItem6.Text = "5";
			this.toolStripMenuItem6.Click += new System.EventHandler(this.fpsToolStripMenuItem1_Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.AutoSize = false;
			this.toolStripButton3.CheckOnClick = true;
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.White;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(33, 28);
			this.toolStripButton3.Text = "JPEG compression";
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(33, 6);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.AutoSize = false;
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(33, 28);
			this.toolStripButton4.Text = "Chat";
			this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
			// 
			// centerLabel
			// 
			this.centerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.centerLabel.AutoSize = true;
			this.centerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.centerLabel.ForeColor = System.Drawing.Color.White;
			this.centerLabel.Location = new System.Drawing.Point(378, 200);
			this.centerLabel.Name = "centerLabel";
			this.centerLabel.Size = new System.Drawing.Size(127, 24);
			this.centerLabel.TabIndex = 5;
			this.centerLabel.Text = "Connecting ...";
			// 
			// StreamForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(823, 431);
			this.Controls.Add(this.centerLabel);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "StreamForm";
			this.Text = "StreamForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StreamForm_FormClosing);
			this.Shown += new System.EventHandler(this.StreamForm_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StreamForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StreamForm_KeyUp);
			this.Resize += new System.EventHandler(this.StreamForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem x768ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x576ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x450ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x360ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x270ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripMenuItem x1080ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x720ToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.Label centerLabel;
	}
}