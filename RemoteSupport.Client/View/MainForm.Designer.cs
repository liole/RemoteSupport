namespace RemoteSupport.Client.View
{
	partial class MainForm
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
			this.changeBtn = new System.Windows.Forms.Button();
			this.userNameLbl = new System.Windows.Forms.Label();
			this.userNameTxt = new System.Windows.Forms.TextBox();
			this.connectToTxt = new System.Windows.Forms.TextBox();
			this.connectToLbl = new System.Windows.Forms.Label();
			this.connectBtn = new System.Windows.Forms.Button();
			this.StatusLbl = new System.Windows.Forms.Label();
			this.StatusValueLbl = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// changeBtn
			// 
			this.changeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.changeBtn.Enabled = false;
			this.changeBtn.Location = new System.Drawing.Point(215, 50);
			this.changeBtn.Name = "changeBtn";
			this.changeBtn.Size = new System.Drawing.Size(87, 23);
			this.changeBtn.TabIndex = 1;
			this.changeBtn.Text = "Change";
			this.changeBtn.UseVisualStyleBackColor = true;
			this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
			// 
			// userNameLbl
			// 
			this.userNameLbl.AutoSize = true;
			this.userNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.userNameLbl.Location = new System.Drawing.Point(12, 50);
			this.userNameLbl.Name = "userNameLbl";
			this.userNameLbl.Size = new System.Drawing.Size(91, 20);
			this.userNameLbl.TabIndex = 2;
			this.userNameLbl.Text = "User name:";
			// 
			// userNameTxt
			// 
			this.userNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.userNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.userNameTxt.Location = new System.Drawing.Point(109, 47);
			this.userNameTxt.Name = "userNameTxt";
			this.userNameTxt.Size = new System.Drawing.Size(100, 26);
			this.userNameTxt.TabIndex = 6;
			// 
			// connectToTxt
			// 
			this.connectToTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.connectToTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.connectToTxt.Location = new System.Drawing.Point(109, 79);
			this.connectToTxt.Name = "connectToTxt";
			this.connectToTxt.Size = new System.Drawing.Size(100, 26);
			this.connectToTxt.TabIndex = 3;
			// 
			// connectToLbl
			// 
			this.connectToLbl.AutoSize = true;
			this.connectToLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.connectToLbl.Location = new System.Drawing.Point(12, 82);
			this.connectToLbl.Name = "connectToLbl";
			this.connectToLbl.Size = new System.Drawing.Size(91, 20);
			this.connectToLbl.TabIndex = 5;
			this.connectToLbl.Text = "Connect to:";
			// 
			// connectBtn
			// 
			this.connectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.connectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.connectBtn.Location = new System.Drawing.Point(215, 79);
			this.connectBtn.Name = "connectBtn";
			this.connectBtn.Size = new System.Drawing.Size(87, 67);
			this.connectBtn.TabIndex = 4;
			this.connectBtn.Text = "Connect";
			this.connectBtn.UseVisualStyleBackColor = true;
			this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
			// 
			// StatusLbl
			// 
			this.StatusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.StatusLbl.AutoSize = true;
			this.StatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.StatusLbl.Location = new System.Drawing.Point(13, 117);
			this.StatusLbl.Name = "StatusLbl";
			this.StatusLbl.Size = new System.Drawing.Size(48, 16);
			this.StatusLbl.TabIndex = 7;
			this.StatusLbl.Text = "Status:";
			// 
			// StatusValueLbl
			// 
			this.StatusValueLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StatusValueLbl.AutoSize = true;
			this.StatusValueLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.StatusValueLbl.ForeColor = System.Drawing.Color.Orange;
			this.StatusValueLbl.Location = new System.Drawing.Point(67, 117);
			this.StatusValueLbl.Name = "StatusValueLbl";
			this.StatusValueLbl.Size = new System.Drawing.Size(101, 16);
			this.StatusValueLbl.TabIndex = 8;
			this.StatusValueLbl.Text = "Connecting ...";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(78, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 25);
			this.label1.TabIndex = 9;
			this.label1.Text = "Remote Support";
			// 
			// MainForm
			// 
			this.AcceptButton = this.connectBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(314, 161);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.StatusValueLbl);
			this.Controls.Add(this.StatusLbl);
			this.Controls.Add(this.connectToTxt);
			this.Controls.Add(this.connectToLbl);
			this.Controls.Add(this.connectBtn);
			this.Controls.Add(this.userNameTxt);
			this.Controls.Add(this.userNameLbl);
			this.Controls.Add(this.changeBtn);
			this.MaximumSize = new System.Drawing.Size(500, 200);
			this.MinimumSize = new System.Drawing.Size(300, 200);
			this.Name = "MainForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
        private System.Windows.Forms.Button changeBtn;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.TextBox userNameTxt;
        private System.Windows.Forms.TextBox connectToTxt;
        private System.Windows.Forms.Label connectToLbl;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label StatusLbl;
        private System.Windows.Forms.Label StatusValueLbl;
		private System.Windows.Forms.Label label1;
    }
}

