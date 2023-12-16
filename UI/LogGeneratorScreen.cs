using System.Diagnostics;
using System.Globalization;

using LogGenerator.Business;
using LogGenerator.Business.Constants;
using LogGenerator.Business.Entities;
using LogGenerator.Business.Events;
using LogGenerator.Extensions;

namespace LogGenerator
{
	public sealed partial class LogGeneratorScreen
		: Form
	{
		// Log generator
		private ILogAndSolutionConversationsGenerator logGenerator;

		// Input text file folders
		private string logEntryFilesFolder;
		private string solutionConversationFilesFolder;

		public LogGeneratorScreen (ILogAndSolutionConversationsGenerator logGenerator)
		{
			this.InitializeComponent ();

			// Log and solution conversation directories.
			var logFilesFolder = $@"{AppContext.BaseDirectory}LogEntryFiles\";
			var solutionFilesFolder = $@"{AppContext.BaseDirectory}SolutionConversationFiles\";

			this.logEntryFilesFolder
				= (Directory.Exists (logFilesFolder))
					? logFilesFolder
					: AppContext.BaseDirectory;

			this.solutionConversationFilesFolder
				= (Directory.Exists (solutionFilesFolder))
					? solutionFilesFolder
					: AppContext.BaseDirectory;

			// Log files and Solution conversation files
			this.logEntryFileListBox.DataSource = (new DirectoryInfo (this.logEntryFilesFolder)).GetFiles ();
			this.logEntryFileListBox.DisplayMember = nameof (FileInfo.Name);
			this.solutionConversationsFileListBox.DataSource = (new DirectoryInfo (this.solutionConversationFilesFolder)).GetFiles ();
			this.solutionConversationsFileListBox.DisplayMember = nameof (FileInfo.Name);

			// Date format
			this.dateTimeFormatTextBox.Text = "dd-MMM-yyyy hh:mm:ss:fff zzz";

			// Select all Log file fields
			for (int i = 0; i < this.logFileFieldsCheckedListBox.Items.Count; i++)
			{
				this.logFileFieldsCheckedListBox.SetItemChecked (i, true);
			}

			// Select all Solution Conversations file fields
			for (int i = 0; i < this.solutionFileFieldsCheckedListBox.Items.Count; i++)
			{
				this.solutionFileFieldsCheckedListBox.SetItemChecked (i, true);
			}

			// Unique Log Entry ID.
			this.logEntryUniqueIdTypeDropDownList.SelectedIndex = 0;
			this.fieldDelimiterDropDownList.SelectedIndex = 0;
			this.logFileSizeInMbDropDownList.SelectedIndex = 4;         // 50 MB
			this.solutionFileSizeInMbDropDownList.SelectedIndex = 4;    // 50 MB

			// Log generator
			this.logGenerator = logGenerator;

			// Subscribe to the events of the Log generator.
			this.logGenerator.GenerationStarted += this.LogGenerationStarted;
			this.logGenerator.GenerationCompleted += this.LogGenerationCompleted;
			this.logGenerator.GenerationStopped += this.LogGenerationStopped;
			this.logGenerator.ProgressChanged+= this.ProgressChanged;
		}

		private void LogGenerationStarted (object sender, GenerationStartedEventArgs e)
		{
			// Enable / disable controls
			this.generatelogImageButton.Enabled = false;
			this.FreezeFrames (true);

			// Show / hide controls
			this.abortButton.Visible = true;
			this.currentActivityLabel.Visible = true;
			this.currentActivityDescriptionLabel.Visible = true;
			this.logProgressBar.Visible = true;

			// Set updates
			this.currentActivityDescriptionLabel.Text = e.CurrentActivity;
			this.logProgressBar.Value = 0;

			this.Refresh ();
		}

		private void LogGenerationCompleted (object sender, GenerationCompletedEventArgs e)
		{
			MessageBox.Show ("Log generation completed successfully.", "Log generation completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

			// Enable / disable controls
			this.generatelogImageButton.Enabled = true;
			this.FreezeFrames (false);

			// Show / hide controls
			this.abortButton.Visible = false;
			this.currentActivityLabel.Visible = false;
			this.currentActivityDescriptionLabel.Visible = false;
			this.logProgressBar.Visible = false;

			// Set updates
			this.logProgressBar.Value = 0;
			this.currentActivityDescriptionLabel.Text = string.Empty;
		}

		private void LogGenerationStopped (object sender, EventArgs e)
		{
			MessageBox.Show ("Log generation was aborted.", "Log generation aborted", MessageBoxButtons.OK, MessageBoxIcon.Information);

			// Enable / disable controls
			this.generatelogImageButton.Enabled = true;
			this.FreezeFrames (false);

			// Show / hide controls
			this.abortButton.Visible = false;
			this.currentActivityLabel.Visible = false;
			this.currentActivityDescriptionLabel.Visible = false;
			this.logProgressBar.Visible = false;

			// Set updates
			this.logProgressBar.Value = 0;
			this.currentActivityDescriptionLabel.Text = string.Empty;
		}

		private void ProgressChanged (object sender, ProgressChangedEventArgs e)
		{
			Application.DoEvents ();
			this.logProgressBar.Value = e.ProgressPercentage;
		}

		private void abortButton_Click (object sender, EventArgs e)
		{
			this.logGenerator.StopGeneratingLogs ();
		}

		private void dateTimeFormatTextBox_TextChanged (object sender, EventArgs e)
		{
			this.sampleDateTimeTextBox.Text = DateTime.Now.ToString (this.dateTimeFormatTextBox.Text, CultureInfo.InvariantCulture);
			this.ListIndexChanged (sender, e);
		}

		private void logEntryFileFolderButton_Click (object sender, EventArgs e)
		{
			// Log entry input file folder
			this.folderDialog.SelectedPath = this.logEntryFilesFolder;

			if (this.folderDialog.ShowDialog () == DialogResult.OK)
			{
				this.logEntryFilesFolder = this.folderDialog.SelectedPath;

				// Show files in the folder in the list box
				this.logEntryFileListBox.DataSource = (new DirectoryInfo (this.logEntryFilesFolder)).GetFiles ();
				this.logEntryFileListBox.DisplayMember = nameof (FileInfo.Name);
			}
		}

		private void solutionConversationsFileFolderButton_Click (object sender, EventArgs e)
		{
			// Solution Conversation log entries input file folder
			this.folderDialog.SelectedPath = this.solutionConversationFilesFolder;

			if (this.folderDialog.ShowDialog () == DialogResult.OK)
			{
				this.solutionConversationFilesFolder = this.folderDialog.SelectedPath;

				// Show files in the folder in the list box
				this.solutionConversationsFileListBox.DataSource = (new DirectoryInfo (this.solutionConversationFilesFolder)).GetFiles ();
				this.solutionConversationsFileListBox.DisplayMember = nameof (FileInfo.Name);
			}
		}

		private void logFileFieldsCheckedListBox_ItemCheck (object sender, ItemCheckEventArgs e)
		{
			var mandatoryFields
				= new [] {
					LogFields.LOG_DATE_TIME,
					LogFields.LOG_ENTRY_UNIQUE_ID,
					LogFields.LOG_ENTRY_TYPE,
					LogFields.LOG_SHORT_DESC,
					LogFields.LOG_DETAILED_DESC
				};

			// Get the "checked" text
			var selectedItemText = this.logFileFieldsCheckedListBox.Items [e.Index].ToString ();

			// Is it mandatory, and cannot be unchecked?
			if (e.NewValue == CheckState.Unchecked && selectedItemText.IsOneOf (mandatoryFields))
			{
				MessageBox.Show ($"'{selectedItemText}' is mandatory and cannot be removed from Log fields.", "Field is mandatory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.NewValue = CheckState.Checked;
			}
		}

		private void solutionFileFieldsCheckedListBox_ItemCheck (object sender, ItemCheckEventArgs e)
		{
			var mandatoryFields
				= new [] {
					SolutionFields.SOLN_DATE_TIME,
					SolutionFields.SOLN_LOG_ENTRY_UNIQUE_ID,
					SolutionFields.SOLN_TICKET_NUMBER,
					SolutionFields.SOLN_CONVERSATION_TEXT,
					SolutionFields.SOLN_RESOLUTION_PROVIDED
				};

			// Get the "checked" text
			var selectedItemText = this.solutionFileFieldsCheckedListBox.Items [e.Index].ToString ();

			// Is it mandatory, and cannot be unchecked?
			if (e.NewValue == CheckState.Unchecked && selectedItemText.IsOneOf (mandatoryFields))
			{
				MessageBox.Show ($"'{selectedItemText}' is mandatory and cannot be removed from Solution Conversation fields.", "Field is mandatory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.NewValue = CheckState.Checked;
			}
		}

		private void ListIndexChanged (object sender, EventArgs e)
		{
			// Is it the Fie Size in MB dropdowns?
			var senderName = ((Control) sender).Name;

			if (senderName.IsOneOf (nameof (this.logFileSizeInMbDropDownList), nameof (this.solutionFileSizeInMbDropDownList)))
			{
				// Yes. Set the same value to the other dropdown.
				var selectedIndex = ((ComboBox) sender).SelectedIndex;

				this.logFileSizeInMbDropDownList.SelectedIndex = selectedIndex;
				this.solutionFileSizeInMbDropDownList.SelectedIndex = selectedIndex;
			}

			// Generate log button
			this.generatelogImageButton.Enabled
				= this.sampleDateTimeTextBox.Text.Trim () != string.Empty
					&& DateTime.TryParseExact (this.sampleDateTimeTextBox.Text, this.dateTimeFormatTextBox.Text, null, DateTimeStyles.None, out var _)
					&& this.logEntryFileListBox.SelectedIndex != -1
					&& this.solutionConversationsFileListBox.SelectedIndex != -1
					&& this.logFileFieldsCheckedListBox.CheckedItems.Count > 0
					&& this.solutionFileFieldsCheckedListBox.CheckedItems.Count > 0
					&& this.logEntryUniqueIdTypeDropDownList.SelectedIndex != -1
					&& this.fieldDelimiterDropDownList.SelectedIndex != -1
					&& this.logFileSizeInMbDropDownList.SelectedIndex != -1
					&& this.solutionFileSizeInMbDropDownList.SelectedIndex != -1;
		}

		private void generatelogImageButton_Click (object sender, EventArgs e)
		{
			// Get the input file where sample log entry texts are there
			var logInputFile = (FileInfo) this.logEntryFileListBox.SelectedItem;
			var solutionConvInputFile = (FileInfo) this.solutionConversationsFileListBox.SelectedItem;

			if (logInputFile == null || solutionConvInputFile == null)
			{
				MessageBox.Show ("Cannot read log or solution conversation input file!", "Input file reading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Process input log entry file.
			string errorShortDescription, errorDetailedDescription;

			if (this.GetShortAndDetailedErrorDescriptionsFrom (logInputFile, out errorShortDescription, out errorDetailedDescription) == false)
			{
				MessageBox.Show ("The log file does not have expected placeholders for short and detailed error descriptions", "Log File not in correct format", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Process input solution conversation entry file.
			if (this.GetSolutionConversationsFrom (solutionConvInputFile, out var conversationLines) == false)
			{
				MessageBox.Show ("The log file does not have expected placeholders for short and detailed error descriptions", "Log File not in correct format", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Form the options
			var logGenerationOptions = new LogGenerationOptions
			{
				DateFormat = this.dateTimeFormatTextBox.Text,
				LogUniqueId = this.logEntryUniqueIdTypeDropDownList.Text.ToLogUniqueId (),
				FieldDelemiter = this.fieldDelimiterDropDownList.SelectedItem.ToString ().ToFieldDelimiter (),
				DistributionPercentage = 60,
				LogFields = this.logFileFieldsCheckedListBox.GetCheckedItemsDictionary (),
				SolutionConversationFields = this.solutionFileFieldsCheckedListBox.GetCheckedItemsDictionary (),
				LogFileSizeInMB = this.logFileSizeInMbDropDownList.SelectedItem.ToString ().GetFileSizeInMbFromText (),
				SolutionConversationFileSizeInMB = this.solutionFileSizeInMbDropDownList.SelectedItem.ToString ().GetFileSizeInMbFromText (),
				SampleErrorShortDescription = errorShortDescription,
				SampleErrorDetailedDescription = errorDetailedDescription,
				SolutionConversationLines = conversationLines
			};

			// Start log generation.
			if (this.logGenerator.GenerateLogsAndConversations (logGenerationOptions))
			{
				this.OpenOutputFolder ();
			}
		}

		#region Private methods

		// Enable or disable group boxes of the UI
		private void FreezeFrames (bool freeze)
		{
			this.logAndSolutionGroupBox.Enabled = !freeze;
			this.logAndSolutionFileFieldsGroupBox.Enabled = !freeze;
			this.logEntryIdentifiersGroupBox.Enabled = !freeze;
		}

		// Read "short" and "detailed" description texts from the input log file
		private bool GetShortAndDetailedErrorDescriptionsFrom (FileInfo logFileInfo, out string errorShortDescription, out string errorDetailedDescription)
		{
			errorShortDescription = string.Empty;
			errorDetailedDescription = string.Empty;
			var newLineCharacters = new char [] { '\r', '\n' };

			// Read the input file
			var logFileText = File.ReadAllText (logFileInfo.FullName);

			// Look for placeholders
			var shortDescStarting = logFileText.IndexOf (FilePlaceholders.LOG_ERROR_SHORT_DESC_STARTING);
			var shortDescEnding = logFileText.IndexOf (FilePlaceholders.LOG_ERROR_SHORT_DESC_ENDING);

			var longDescStarting = logFileText.IndexOf (FilePlaceholders.LOG_ERROR_DETAILED_DESC_STARTING);
			var longDescEnding = logFileText.IndexOf (FilePlaceholders.LOG_ERROR_DETAILED_DESC_ENDING);

			if (
				shortDescStarting == -1
				|| shortDescEnding == -1
				|| shortDescEnding < shortDescStarting
				|| longDescStarting == -1
				|| longDescEnding == -1
				|| longDescEnding < shortDescStarting
				)
			{
				return false;
			}

			// Get the short description
			errorShortDescription
				= logFileText
					.Substring (
						shortDescStarting + FilePlaceholders.LOG_ERROR_SHORT_DESC_STARTING.Length,
						shortDescEnding - shortDescStarting - FilePlaceholders.LOG_ERROR_SHORT_DESC_STARTING.Length)
					.TrimStart (newLineCharacters)
					.TrimEnd (newLineCharacters);

			// Get the detailed description
			errorDetailedDescription
				= logFileText
					.Substring (
						longDescStarting + FilePlaceholders.LOG_ERROR_DETAILED_DESC_STARTING.Length,
						longDescEnding - longDescStarting - FilePlaceholders.LOG_ERROR_DETAILED_DESC_STARTING.Length)
					.TrimStart (newLineCharacters)
					.TrimEnd (newLineCharacters);

			return true;
		}

		private bool GetSolutionConversationsFrom (FileInfo solutionConversationFile, out string [] conversationLines)
		{
			// Get solution conversation lines from input file
			conversationLines =
				File
					.ReadAllLines (solutionConversationFile.FullName)
					.Where (l => l.StartsWith (FilePlaceholders.SOLN_CONV_LINE_STARTING))
					.Select (l => l.Replace (FilePlaceholders.SOLN_CONV_LINE_STARTING, string.Empty))
					.ToArray ();

			if (conversationLines == null || conversationLines.Length == 0)
			{
				return false;
			}

			return true;
		}

		private void OpenOutputFolder ()
		{
			try
			{
				dynamic shell = Activator.CreateInstance (Type.GetTypeFromProgID ("Shell.Application"));
				shell.Open (AppContext.BaseDirectory);
			}
			catch
			{
			}
		}

		#endregion
	}
}