using System.ComponentModel;

namespace LogGenerator.UI
{
	[DefaultEvent ("Click")]
	public partial class ImageButton
		: UserControl
	{
		public ImageButton ()
		{
			this.InitializeComponent ();
		}

		public Image Image
		{
			get { return this.imageButtonPicture.Image; }
			set { this.imageButtonPicture.Image = value; }
		}

		public string ButtonText
		{
			get { return this.clickButton.Text; }
			set { this.clickButton.Text = value; }
		}

		private void ImageButton_SizeChanged (object sender, EventArgs e)
		{
			try
			{
				// Label resizing
				this.clickButton.Location = new Point (3, 3);
				this.clickButton.Size = new Size (this.Width - 6, this.Height - 6);

				// Picture box resizing
				this.imageButtonPicture.Location = new Point (9, 9);
				this.imageButtonPicture.Size = new Size (this.Height - 18, this.Height - 18);
			}
			catch
			{
			}
		}

		private void clickButton_Click (object sender, EventArgs e)
		{
			OnClick (EventArgs.Empty);
		}

		private void imageButtonPicture_Click (object sender, EventArgs e)
		{
			OnClick (EventArgs.Empty);
		}
	}
}