using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteSupport.Client.View
{
	public partial class PermissionDialog : Form
	{
		public string Name
		{
			get { return nameLabel.Text; }
			set { nameLabel.Text = value; }
		}

		public PermissionDialog(string name = "")
		{
			InitializeComponent();
			Name = name;
		}
	}
}
