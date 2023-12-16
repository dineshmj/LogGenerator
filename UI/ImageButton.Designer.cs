namespace LogGenerator.UI
{
	partial class ImageButton
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			imageButtonPicture = new PictureBox ();
			clickButton = new Button ();
			((System.ComponentModel.ISupportInitialize) imageButtonPicture).BeginInit ();
			SuspendLayout ();
			// 
			// imageButtonPicture
			// 
			imageButtonPicture.BackColor = Color.Transparent;
			imageButtonPicture.Location = new Point (0, 0);
			imageButtonPicture.Margin = new Padding (0);
			imageButtonPicture.Name = "imageButtonPicture";
			imageButtonPicture.Size = new Size (108, 108);
			imageButtonPicture.SizeMode = PictureBoxSizeMode.Zoom;
			imageButtonPicture.TabIndex = 0;
			imageButtonPicture.TabStop = false;
			imageButtonPicture.Click += imageButtonPicture_Click;
			// 
			// clickButton
			// 
			clickButton.Location = new Point (0, 0);
			clickButton.Name = "clickButton";
			clickButton.Size = new Size (414, 114);
			clickButton.TabIndex = 2;
			clickButton.Text = "imageButton1";
			clickButton.TextAlign = ContentAlignment.MiddleRight;
			clickButton.UseVisualStyleBackColor = true;
			clickButton.Click += clickButton_Click;
			// 
			// ImageButton
			// 
			Controls.Add (imageButtonPicture);
			Controls.Add (clickButton);
			Name = "ImageButton";
			Size = new Size (420, 120);
			SizeChanged += ImageButton_SizeChanged;
			((System.ComponentModel.ISupportInitialize) imageButtonPicture).EndInit ();
			ResumeLayout (false);
		}

		#endregion

		private PictureBox imageButtonPicture;
		private Button clickButton;
	}
}
