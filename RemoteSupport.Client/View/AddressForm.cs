﻿using System;
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
	public partial class AddressForm : Form
	{
		public string Address
		{
			get { return textBox1.Text; }
			set { textBox1.Text = value; }
		}

		public AddressForm()
		{
			InitializeComponent();
		}
	}
}
