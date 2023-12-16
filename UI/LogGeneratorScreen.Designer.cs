using LogGenerator.UI;

namespace LogGenerator
{
    partial class LogGeneratorScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (LogGeneratorScreen));
			logAndSolutionGroupBox = new GroupBox ();
			solutionConversationsFileListBox = new ListBox ();
			logEntryFileListBox = new ListBox ();
			solutionConversationsFileFolderButton = new Button ();
			logEntryFileFolderButton = new Button ();
			solutionConversationsFileLabel = new Label ();
			logEntryFileLabel = new Label ();
			folderDialog = new FolderBrowserDialog ();
			logEntryIdentifiersGroupBox = new GroupBox ();
			solutionFileSizeInMbDropDownList = new ComboBox ();
			logFileSizeInMbDropDownList = new ComboBox ();
			fieldDelimiterDropDownList = new ComboBox ();
			logEntryUniqueIdTypeDropDownList = new ComboBox ();
			sampleDateTimeTextBox = new TextBox ();
			dateTimeFormatTextBox = new TextBox ();
			solutionFileSizeInMbLabel = new Label ();
			logFileSizeInMbLabel = new Label ();
			label1 = new Label ();
			logEntryUniqueIdTypeLabel = new Label ();
			sampleDateTimeTextLabel = new Label ();
			dateTimeFormatLabel = new Label ();
			logAndSolutionFileFieldsGroupBox = new GroupBox ();
			solutionFileFieldsLabel = new Label ();
			solutionFileFieldsCheckedListBox = new CheckedListBox ();
			logFileFieldsCheckedListBox = new CheckedListBox ();
			logFileFieldsLabel = new Label ();
			generatelogImageButton = new ImageButton ();
			logProgressBar = new ProgressBar ();
			currentActivityLabel = new Label ();
			currentActivityDescriptionLabel = new Label ();
			abortButton = new Button ();
			label2 = new Label ();
			logAndSolutionGroupBox.SuspendLayout ();
			logEntryIdentifiersGroupBox.SuspendLayout ();
			logAndSolutionFileFieldsGroupBox.SuspendLayout ();
			SuspendLayout ();
			// 
			// logAndSolutionGroupBox
			// 
			logAndSolutionGroupBox.Controls.Add (solutionConversationsFileListBox);
			logAndSolutionGroupBox.Controls.Add (logEntryFileListBox);
			logAndSolutionGroupBox.Controls.Add (solutionConversationsFileFolderButton);
			logAndSolutionGroupBox.Controls.Add (logEntryFileFolderButton);
			logAndSolutionGroupBox.Controls.Add (solutionConversationsFileLabel);
			logAndSolutionGroupBox.Controls.Add (logEntryFileLabel);
			logAndSolutionGroupBox.Location = new Point (8, 7);
			logAndSolutionGroupBox.Margin = new Padding (2);
			logAndSolutionGroupBox.Name = "logAndSolutionGroupBox";
			logAndSolutionGroupBox.Padding = new Padding (2);
			logAndSolutionGroupBox.Size = new Size (484, 182);
			logAndSolutionGroupBox.TabIndex = 0;
			logAndSolutionGroupBox.TabStop = false;
			logAndSolutionGroupBox.Text = "Log && Solution Entries";
			// 
			// solutionConversationsFileListBox
			// 
			solutionConversationsFileListBox.FormattingEnabled = true;
			solutionConversationsFileListBox.ItemHeight = 15;
			solutionConversationsFileListBox.Location = new Point (15, 121);
			solutionConversationsFileListBox.Margin = new Padding (2);
			solutionConversationsFileListBox.Name = "solutionConversationsFileListBox";
			solutionConversationsFileListBox.Size = new Size (408, 49);
			solutionConversationsFileListBox.TabIndex = 1;
			solutionConversationsFileListBox.SelectedIndexChanged += ListIndexChanged;
			// 
			// logEntryFileListBox
			// 
			logEntryFileListBox.FormattingEnabled = true;
			logEntryFileListBox.ItemHeight = 15;
			logEntryFileListBox.Location = new Point (15, 43);
			logEntryFileListBox.Margin = new Padding (2);
			logEntryFileListBox.Name = "logEntryFileListBox";
			logEntryFileListBox.Size = new Size (408, 49);
			logEntryFileListBox.TabIndex = 1;
			logEntryFileListBox.SelectedIndexChanged += ListIndexChanged;
			// 
			// solutionConversationsFileFolderButton
			// 
			solutionConversationsFileFolderButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			solutionConversationsFileFolderButton.BackgroundImage = (Image) resources.GetObject ("solutionConversationsFileFolderButton.BackgroundImage");
			solutionConversationsFileFolderButton.BackgroundImageLayout = ImageLayout.Stretch;
			solutionConversationsFileFolderButton.Location = new Point (426, 124);
			solutionConversationsFileFolderButton.Margin = new Padding (2);
			solutionConversationsFileFolderButton.Name = "solutionConversationsFileFolderButton";
			solutionConversationsFileFolderButton.Size = new Size (53, 42);
			solutionConversationsFileFolderButton.TabIndex = 0;
			solutionConversationsFileFolderButton.UseVisualStyleBackColor = true;
			solutionConversationsFileFolderButton.Click += solutionConversationsFileFolderButton_Click;
			// 
			// logEntryFileFolderButton
			// 
			logEntryFileFolderButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			logEntryFileFolderButton.BackgroundImage = (Image) resources.GetObject ("logEntryFileFolderButton.BackgroundImage");
			logEntryFileFolderButton.BackgroundImageLayout = ImageLayout.Stretch;
			logEntryFileFolderButton.Location = new Point (426, 46);
			logEntryFileFolderButton.Margin = new Padding (2);
			logEntryFileFolderButton.Name = "logEntryFileFolderButton";
			logEntryFileFolderButton.Size = new Size (53, 42);
			logEntryFileFolderButton.TabIndex = 0;
			logEntryFileFolderButton.UseVisualStyleBackColor = true;
			logEntryFileFolderButton.Click += logEntryFileFolderButton_Click;
			// 
			// solutionConversationsFileLabel
			// 
			solutionConversationsFileLabel.Font = new Font ("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point,  0);
			solutionConversationsFileLabel.Location = new Point (15, 103);
			solutionConversationsFileLabel.Margin = new Padding (2, 0, 2, 0);
			solutionConversationsFileLabel.Name = "solutionConversationsFileLabel";
			solutionConversationsFileLabel.Size = new Size (407, 16);
			solutionConversationsFileLabel.TabIndex = 2;
			solutionConversationsFileLabel.Text = "Solution Conversations File :";
			solutionConversationsFileLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// logEntryFileLabel
			// 
			logEntryFileLabel.Font = new Font ("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point,  0);
			logEntryFileLabel.Location = new Point (15, 24);
			logEntryFileLabel.Margin = new Padding (2, 0, 2, 0);
			logEntryFileLabel.Name = "logEntryFileLabel";
			logEntryFileLabel.Size = new Size (407, 17);
			logEntryFileLabel.TabIndex = 2;
			logEntryFileLabel.Text = "Log Entry File :";
			logEntryFileLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// folderDialog
			// 
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
			// 
			// logEntryIdentifiersGroupBox
			// 
			logEntryIdentifiersGroupBox.Controls.Add (label2);
			logEntryIdentifiersGroupBox.Controls.Add (solutionFileSizeInMbDropDownList);
			logEntryIdentifiersGroupBox.Controls.Add (logFileSizeInMbDropDownList);
			logEntryIdentifiersGroupBox.Controls.Add (fieldDelimiterDropDownList);
			logEntryIdentifiersGroupBox.Controls.Add (logEntryUniqueIdTypeDropDownList);
			logEntryIdentifiersGroupBox.Controls.Add (sampleDateTimeTextBox);
			logEntryIdentifiersGroupBox.Controls.Add (dateTimeFormatTextBox);
			logEntryIdentifiersGroupBox.Controls.Add (solutionFileSizeInMbLabel);
			logEntryIdentifiersGroupBox.Controls.Add (logFileSizeInMbLabel);
			logEntryIdentifiersGroupBox.Controls.Add (label1);
			logEntryIdentifiersGroupBox.Controls.Add (logEntryUniqueIdTypeLabel);
			logEntryIdentifiersGroupBox.Controls.Add (sampleDateTimeTextLabel);
			logEntryIdentifiersGroupBox.Controls.Add (dateTimeFormatLabel);
			logEntryIdentifiersGroupBox.Location = new Point (505, 7);
			logEntryIdentifiersGroupBox.Margin = new Padding (2);
			logEntryIdentifiersGroupBox.Name = "logEntryIdentifiersGroupBox";
			logEntryIdentifiersGroupBox.Padding = new Padding (2);
			logEntryIdentifiersGroupBox.Size = new Size (510, 242);
			logEntryIdentifiersGroupBox.TabIndex = 1;
			logEntryIdentifiersGroupBox.TabStop = false;
			logEntryIdentifiersGroupBox.Text = "Log Entry Identifiers";
			// 
			// solutionFileSizeInMbDropDownList
			// 
			solutionFileSizeInMbDropDownList.DropDownStyle = ComboBoxStyle.DropDownList;
			solutionFileSizeInMbDropDownList.FormattingEnabled = true;
			solutionFileSizeInMbDropDownList.Items.AddRange (new object [] { "2 MB", "5 MB", "10 MB", "20 MB", "50 MB", "100 MB", "200 MB", "500 MB", "1 GB", "1.2 GB", "1.5 GB", "2 GB" });
			solutionFileSizeInMbDropDownList.Location = new Point (204, 170);
			solutionFileSizeInMbDropDownList.Margin = new Padding (2);
			solutionFileSizeInMbDropDownList.Name = "solutionFileSizeInMbDropDownList";
			solutionFileSizeInMbDropDownList.Size = new Size (292, 23);
			solutionFileSizeInMbDropDownList.TabIndex = 2;
			solutionFileSizeInMbDropDownList.SelectedIndexChanged += ListIndexChanged;
			// 
			// logFileSizeInMbDropDownList
			// 
			logFileSizeInMbDropDownList.DropDownStyle = ComboBoxStyle.DropDownList;
			logFileSizeInMbDropDownList.FormattingEnabled = true;
			logFileSizeInMbDropDownList.Items.AddRange (new object [] { "2 MB", "5 MB", "10 MB", "20 MB", "50 MB", "100 MB", "200 MB", "500 MB", "1 GB", "1.2 GB", "1.5 GB", "2 GB" });
			logFileSizeInMbDropDownList.Location = new Point (204, 143);
			logFileSizeInMbDropDownList.Margin = new Padding (2);
			logFileSizeInMbDropDownList.Name = "logFileSizeInMbDropDownList";
			logFileSizeInMbDropDownList.Size = new Size (292, 23);
			logFileSizeInMbDropDownList.TabIndex = 2;
			logFileSizeInMbDropDownList.SelectedIndexChanged += ListIndexChanged;
			// 
			// fieldDelimiterDropDownList
			// 
			fieldDelimiterDropDownList.AutoCompleteCustomSource.AddRange (new string [] { "TAB", "!!#!!", "~!~", "%$%" });
			fieldDelimiterDropDownList.DropDownStyle = ComboBoxStyle.DropDownList;
			fieldDelimiterDropDownList.FormattingEnabled = true;
			fieldDelimiterDropDownList.Items.AddRange (new object [] { "Tab", "##!##", "~~!~~" });
			fieldDelimiterDropDownList.Location = new Point (204, 116);
			fieldDelimiterDropDownList.Margin = new Padding (2);
			fieldDelimiterDropDownList.Name = "fieldDelimiterDropDownList";
			fieldDelimiterDropDownList.Size = new Size (292, 23);
			fieldDelimiterDropDownList.TabIndex = 2;
			fieldDelimiterDropDownList.SelectedIndexChanged += ListIndexChanged;
			// 
			// logEntryUniqueIdTypeDropDownList
			// 
			logEntryUniqueIdTypeDropDownList.DropDownStyle = ComboBoxStyle.DropDownList;
			logEntryUniqueIdTypeDropDownList.FormattingEnabled = true;
			logEntryUniqueIdTypeDropDownList.Items.AddRange (new object [] { "Guid", "Running Number", "Running Hex Number" });
			logEntryUniqueIdTypeDropDownList.Location = new Point (204, 89);
			logEntryUniqueIdTypeDropDownList.Margin = new Padding (2);
			logEntryUniqueIdTypeDropDownList.Name = "logEntryUniqueIdTypeDropDownList";
			logEntryUniqueIdTypeDropDownList.Size = new Size (292, 23);
			logEntryUniqueIdTypeDropDownList.TabIndex = 2;
			logEntryUniqueIdTypeDropDownList.SelectedIndexChanged += ListIndexChanged;
			// 
			// sampleDateTimeTextBox
			// 
			sampleDateTimeTextBox.BackColor = Color.FromArgb (  224,   224,   224);
			sampleDateTimeTextBox.Enabled = false;
			sampleDateTimeTextBox.Font = new Font ("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point,  0);
			sampleDateTimeTextBox.Location = new Point (204, 60);
			sampleDateTimeTextBox.Margin = new Padding (2);
			sampleDateTimeTextBox.Name = "sampleDateTimeTextBox";
			sampleDateTimeTextBox.Size = new Size (292, 25);
			sampleDateTimeTextBox.TabIndex = 1;
			// 
			// dateTimeFormatTextBox
			// 
			dateTimeFormatTextBox.Font = new Font ("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point,  0);
			dateTimeFormatTextBox.Location = new Point (204, 31);
			dateTimeFormatTextBox.Margin = new Padding (2);
			dateTimeFormatTextBox.Name = "dateTimeFormatTextBox";
			dateTimeFormatTextBox.Size = new Size (292, 25);
			dateTimeFormatTextBox.TabIndex = 1;
			dateTimeFormatTextBox.Text = "M/d/yyyy H:mm:ss:fff zzz";
			dateTimeFormatTextBox.TextChanged += dateTimeFormatTextBox_TextChanged;
			// 
			// solutionFileSizeInMbLabel
			// 
			solutionFileSizeInMbLabel.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
			solutionFileSizeInMbLabel.Location = new Point (14, 170);
			solutionFileSizeInMbLabel.Margin = new Padding (2, 0, 2, 0);
			solutionFileSizeInMbLabel.Name = "solutionFileSizeInMbLabel";
			solutionFileSizeInMbLabel.Size = new Size (186, 23);
			solutionFileSizeInMbLabel.TabIndex = 0;
			solutionFileSizeInMbLabel.Text = "Solution Conversation File Size :";
			solutionFileSizeInMbLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// logFileSizeInMbLabel
			// 
			logFileSizeInMbLabel.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
			logFileSizeInMbLabel.Location = new Point (26, 142);
			logFileSizeInMbLabel.Margin = new Padding (2, 0, 2, 0);
			logFileSizeInMbLabel.Name = "logFileSizeInMbLabel";
			logFileSizeInMbLabel.Size = new Size (174, 23);
			logFileSizeInMbLabel.TabIndex = 0;
			logFileSizeInMbLabel.Text = "Log File Size :";
			logFileSizeInMbLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
			label1.Location = new Point (26, 116);
			label1.Margin = new Padding (2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new Size (174, 23);
			label1.TabIndex = 0;
			label1.Text = "Field Delimiter :";
			label1.TextAlign = ContentAlignment.MiddleRight;
			// 
			// logEntryUniqueIdTypeLabel
			// 
			logEntryUniqueIdTypeLabel.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
			logEntryUniqueIdTypeLabel.Location = new Point (26, 89);
			logEntryUniqueIdTypeLabel.Margin = new Padding (2, 0, 2, 0);
			logEntryUniqueIdTypeLabel.Name = "logEntryUniqueIdTypeLabel";
			logEntryUniqueIdTypeLabel.Size = new Size (174, 23);
			logEntryUniqueIdTypeLabel.TabIndex = 0;
			logEntryUniqueIdTypeLabel.Text = "Log Entry Unique ID Type :";
			logEntryUniqueIdTypeLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// sampleDateTimeTextLabel
			// 
			sampleDateTimeTextLabel.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
			sampleDateTimeTextLabel.Location = new Point (26, 60);
			sampleDateTimeTextLabel.Margin = new Padding (2, 0, 2, 0);
			sampleDateTimeTextLabel.Name = "sampleDateTimeTextLabel";
			sampleDateTimeTextLabel.Size = new Size (174, 23);
			sampleDateTimeTextLabel.TabIndex = 0;
			sampleDateTimeTextLabel.Text = "Sample Date / Time Text :";
			sampleDateTimeTextLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// dateTimeFormatLabel
			// 
			dateTimeFormatLabel.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
			dateTimeFormatLabel.Location = new Point (26, 32);
			dateTimeFormatLabel.Margin = new Padding (2, 0, 2, 0);
			dateTimeFormatLabel.Name = "dateTimeFormatLabel";
			dateTimeFormatLabel.Size = new Size (174, 23);
			dateTimeFormatLabel.TabIndex = 0;
			dateTimeFormatLabel.Text = "Date / Time Format :";
			dateTimeFormatLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// logAndSolutionFileFieldsGroupBox
			// 
			logAndSolutionFileFieldsGroupBox.Controls.Add (solutionFileFieldsLabel);
			logAndSolutionFileFieldsGroupBox.Controls.Add (solutionFileFieldsCheckedListBox);
			logAndSolutionFileFieldsGroupBox.Controls.Add (logFileFieldsCheckedListBox);
			logAndSolutionFileFieldsGroupBox.Controls.Add (logFileFieldsLabel);
			logAndSolutionFileFieldsGroupBox.Location = new Point (8, 194);
			logAndSolutionFileFieldsGroupBox.Name = "logAndSolutionFileFieldsGroupBox";
			logAndSolutionFileFieldsGroupBox.Size = new Size (484, 190);
			logAndSolutionFileFieldsGroupBox.TabIndex = 2;
			logAndSolutionFileFieldsGroupBox.TabStop = false;
			logAndSolutionFileFieldsGroupBox.Text = "Log && Solution File Fields";
			// 
			// solutionFileFieldsLabel
			// 
			solutionFileFieldsLabel.Font = new Font ("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point,  0);
			solutionFileFieldsLabel.Location = new Point (246, 19);
			solutionFileFieldsLabel.Margin = new Padding (2, 0, 2, 0);
			solutionFileFieldsLabel.Name = "solutionFileFieldsLabel";
			solutionFileFieldsLabel.Size = new Size (225, 23);
			solutionFileFieldsLabel.TabIndex = 6;
			solutionFileFieldsLabel.Text = "Solution Conversation File Fields :";
			solutionFileFieldsLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// solutionFileFieldsCheckedListBox
			// 
			solutionFileFieldsCheckedListBox.FormattingEnabled = true;
			solutionFileFieldsCheckedListBox.Items.AddRange (new object [] { "Conversation Date & Time", "Ticket Number", "Log Entry Unique ID", "Problem Classification", "Resolving Engineer ID", "Conversation Text", "Resolution Provided" });
			solutionFileFieldsCheckedListBox.Location = new Point (246, 45);
			solutionFileFieldsCheckedListBox.Name = "solutionFileFieldsCheckedListBox";
			solutionFileFieldsCheckedListBox.Size = new Size (225, 130);
			solutionFileFieldsCheckedListBox.TabIndex = 5;
			solutionFileFieldsCheckedListBox.ItemCheck += solutionFileFieldsCheckedListBox_ItemCheck;
			solutionFileFieldsCheckedListBox.SelectedIndexChanged += ListIndexChanged;
			// 
			// logFileFieldsCheckedListBox
			// 
			logFileFieldsCheckedListBox.FormattingEnabled = true;
			logFileFieldsCheckedListBox.Items.AddRange (new object [] { "Date & Time", "Log Entry Unique ID", "Application Name", "Module Name", "Error Short Description", "Error Detailed Description" });
			logFileFieldsCheckedListBox.Location = new Point (15, 45);
			logFileFieldsCheckedListBox.Name = "logFileFieldsCheckedListBox";
			logFileFieldsCheckedListBox.Size = new Size (225, 130);
			logFileFieldsCheckedListBox.TabIndex = 4;
			logFileFieldsCheckedListBox.ItemCheck += logFileFieldsCheckedListBox_ItemCheck;
			logFileFieldsCheckedListBox.SelectedIndexChanged += ListIndexChanged;
			// 
			// logFileFieldsLabel
			// 
			logFileFieldsLabel.Font = new Font ("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point,  0);
			logFileFieldsLabel.Location = new Point (15, 19);
			logFileFieldsLabel.Margin = new Padding (2, 0, 2, 0);
			logFileFieldsLabel.Name = "logFileFieldsLabel";
			logFileFieldsLabel.Size = new Size (225, 23);
			logFileFieldsLabel.TabIndex = 3;
			logFileFieldsLabel.Text = "Log File Fields :";
			logFileFieldsLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// generatelogImageButton
			// 
			generatelogImageButton.ButtonText = "Generate Logs";
			generatelogImageButton.Enabled = false;
			generatelogImageButton.Image = (Image) resources.GetObject ("generatelogImageButton.Icon");
			generatelogImageButton.Location = new Point (864, 323);
			generatelogImageButton.Name = "generatelogImageButton";
			generatelogImageButton.Size = new Size (151, 61);
			generatelogImageButton.TabIndex = 3;
			generatelogImageButton.Click += generatelogImageButton_Click;
			// 
			// logProgressBar
			// 
			logProgressBar.Location = new Point (502, 351);
			logProgressBar.Name = "logProgressBar";
			logProgressBar.Size = new Size (296, 28);
			logProgressBar.Step = 100;
			logProgressBar.TabIndex = 4;
			logProgressBar.Visible = false;
			// 
			// currentActivityLabel
			// 
			currentActivityLabel.Font = new Font ("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point,  0);
			currentActivityLabel.Location = new Point (498, 328);
			currentActivityLabel.Margin = new Padding (2, 0, 2, 0);
			currentActivityLabel.Name = "currentActivityLabel";
			currentActivityLabel.Size = new Size (98, 20);
			currentActivityLabel.TabIndex = 5;
			currentActivityLabel.Text = "Current Activity:";
			currentActivityLabel.TextAlign = ContentAlignment.MiddleLeft;
			currentActivityLabel.Visible = false;
			// 
			// currentActivityDescriptionLabel
			// 
			currentActivityDescriptionLabel.Font = new Font ("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point,  0);
			currentActivityDescriptionLabel.Location = new Point (600, 328);
			currentActivityDescriptionLabel.Margin = new Padding (2, 0, 2, 0);
			currentActivityDescriptionLabel.Name = "currentActivityDescriptionLabel";
			currentActivityDescriptionLabel.Size = new Size (255, 20);
			currentActivityDescriptionLabel.TabIndex = 6;
			currentActivityDescriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
			currentActivityDescriptionLabel.Visible = false;
			// 
			// abortButton
			// 
			abortButton.Location = new Point (802, 351);
			abortButton.Name = "abortButton";
			abortButton.Size = new Size (63, 28);
			abortButton.TabIndex = 7;
			abortButton.Text = "Abort";
			abortButton.UseVisualStyleBackColor = true;
			abortButton.Visible = false;
			abortButton.Click += abortButton_Click;
			// 
			// label2
			// 
			label2.Font = new Font ("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point,  0);
			label2.Location = new Point (204, 195);
			label2.Margin = new Padding (2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new Size (292, 34);
			label2.TabIndex = 3;
			label2.Text = "(* Due to randomization of Text field values, the exact file size can be different)";
			label2.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// LogGeneratorScreen
			// 
			AutoScaleDimensions = new SizeF (7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size (1031, 391);
			Controls.Add (abortButton);
			Controls.Add (currentActivityDescriptionLabel);
			Controls.Add (currentActivityLabel);
			Controls.Add (logProgressBar);
			Controls.Add (generatelogImageButton);
			Controls.Add (logAndSolutionFileFieldsGroupBox);
			Controls.Add (logEntryIdentifiersGroupBox);
			Controls.Add (logAndSolutionGroupBox);
			Icon = (Icon) resources.GetObject ("$this.Icon");
			Margin = new Padding (2);
			MaximizeBox = false;
			Name = "LogGeneratorScreen";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Log Generator";
			logAndSolutionGroupBox.ResumeLayout (false);
			logEntryIdentifiersGroupBox.ResumeLayout (false);
			logEntryIdentifiersGroupBox.PerformLayout ();
			logAndSolutionFileFieldsGroupBox.ResumeLayout (false);
			ResumeLayout (false);
		}

		#endregion

		private GroupBox logAndSolutionGroupBox;
        private Button logEntryFileFolderButton;
        private ListBox logEntryFileListBox;
        private FolderBrowserDialog folderDialog;
		private GroupBox logEntryIdentifiersGroupBox;
		private Label dateTimeFormatLabel;
		private TextBox sampleDateTimeTextBox;
		private TextBox dateTimeFormatTextBox;
		private Label sampleDateTimeTextLabel;
		private Label logEntryUniqueIdTypeLabel;
		private ComboBox logEntryUniqueIdTypeDropDownList;
		private ListBox solutionConversationsFileListBox;
		private Button solutionConversationsFileFolderButton;
		private Label logEntryFileLabel;
		private Label solutionConversationsFileLabel;
		private GroupBox logAndSolutionFileFieldsGroupBox;
		private Label logFileFieldsLabel;
		private CheckedListBox solutionFileFieldsCheckedListBox;
		private CheckedListBox logFileFieldsCheckedListBox;
		private Label solutionFileFieldsLabel;
		private ComboBox solutionFileSizeInMbDropDownList;
		private ComboBox logFileSizeInMbDropDownList;
		private Label solutionFileSizeInMbLabel;
		private Label logFileSizeInMbLabel;
		private ComboBox fieldDelimiterDropDownList;
		private Label label1;
		private ImageButton generatelogImageButton;
		private ProgressBar logProgressBar;
		private Label currentActivityLabel;
		private Label currentActivityDescriptionLabel;
		private Button abortButton;
		private Label label2;
	}
}