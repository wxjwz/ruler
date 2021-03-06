﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ruler
{
	public partial class SetSizeForm : Form
	{
		private readonly int originalWidth;
		private readonly int originalHeight;

		public SetSizeForm(int initWidth, int initHeight)
		{
			this.InitializeComponent();

			this.originalWidth = initWidth;
			this.originalHeight = initHeight;

			this.txtWidth.Text = initWidth.ToString();
			this.txtHeight.Text = initHeight.ToString();

			this.txtHeight.GotFocus += this.HandleTextBoxFocus;
			this.txtWidth.GotFocus += this.HandleTextBoxFocus;
		}

		private void HandleTextBoxFocus(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private void BtnCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void BtnOkClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		public Size GetNewSize() 
            => new Size
			{
				Width = int.TryParse(this.txtWidth.Text, out int width) ? width : this.originalWidth,
				Height = int.TryParse(this.txtHeight.Text, out int height) ? height : this.originalHeight
			};
		
	}
}
