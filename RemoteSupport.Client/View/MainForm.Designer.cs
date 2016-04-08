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
            this.SuspendLayout();
            // 
            // changeBtn
            // 
            this.changeBtn.Location = new System.Drawing.Point(197, 48);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(75, 23);
            this.changeBtn.TabIndex = 1;
            this.changeBtn.Text = "Change";
            this.changeBtn.UseVisualStyleBackColor = true;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Location = new System.Drawing.Point(13, 53);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(61, 13);
            this.userNameLbl.TabIndex = 2;
            this.userNameLbl.Text = "User name:";
            // 
            // userNameTxt
            // 
            this.userNameTxt.Location = new System.Drawing.Point(80, 48);
            this.userNameTxt.Name = "userNameTxt";
            this.userNameTxt.Size = new System.Drawing.Size(100, 20);
            this.userNameTxt.TabIndex = 3;
            // 
            // connectToTxt
            // 
            this.connectToTxt.Location = new System.Drawing.Point(80, 87);
            this.connectToTxt.Name = "connectToTxt";
            this.connectToTxt.Size = new System.Drawing.Size(100, 20);
            this.connectToTxt.TabIndex = 6;
            // 
            // connectToLbl
            // 
            this.connectToLbl.AutoSize = true;
            this.connectToLbl.Location = new System.Drawing.Point(13, 92);
            this.connectToLbl.Name = "connectToLbl";
            this.connectToLbl.Size = new System.Drawing.Size(62, 13);
            this.connectToLbl.TabIndex = 5;
            this.connectToLbl.Text = "Connect to:";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(197, 87);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 4;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Location = new System.Drawing.Point(13, 153);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(37, 13);
            this.StatusLbl.TabIndex = 7;
            this.StatusLbl.Text = "Status";
            // 
            // StatusValueLbl
            // 
            this.StatusValueLbl.AutoSize = true;
            this.StatusValueLbl.Location = new System.Drawing.Point(77, 153);
            this.StatusValueLbl.Name = "StatusValueLbl";
            this.StatusValueLbl.Size = new System.Drawing.Size(114, 13);
            this.StatusValueLbl.TabIndex = 8;
            this.StatusValueLbl.Text = "Waiting for connection";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.StatusValueLbl);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.connectToTxt);
            this.Controls.Add(this.connectToLbl);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.userNameTxt);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.changeBtn);
            this.Name = "MainForm";
            this.Text = "MainForm";
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
    }
}

