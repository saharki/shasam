using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

/// ************************ MUSIC MAKER ********************
/// By Michael Gold
/// Copyright 2000.  All Rights Reserved
/// *********************************************************


namespace MusicMaker
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class InputStringForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button CANCELButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InputStringForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public string  QueryString
		{
			get 
			{
				return textBox1.Text;
			}
			
			set
			{
				textBox1.Text = value;
			}
		}

		public string  QueryLabel
		{
			set
			{
               label1.Text = value;
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.OKButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.CANCELButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(88, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(304, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "textBox1";
			// 
			// OKButton
			// 
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(136, 80);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(80, 24);
			this.OKButton.TabIndex = 2;
			this.OKButton.Text = "OK";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Song Title:";
			// 
			// CANCELButton
			// 
			this.CANCELButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CANCELButton.Location = new System.Drawing.Point(240, 80);
			this.CANCELButton.Name = "CANCELButton";
			this.CANCELButton.TabIndex = 0;
			this.CANCELButton.Text = "Cancel";
			// 
			// InputStringForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CANCELButton;
			this.ClientSize = new System.Drawing.Size(420, 113);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.CANCELButton,
																		  this.OKButton,
																		  this.label1,
																		  this.textBox1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "InputStringForm";
			this.Text = "Enter The Song Title";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
