using System.Text;

using LogGenerator.Business.Entities;
using LogGenerator.Business.Events;
using LogGenerator.Extensions;

namespace LogGenerator.Business
{
	public sealed class LogAndSolutionConversationsGenerator
		: ILogAndSolutionConversationsGenerator
	{
		// Events
		public event GenerationStartedEventHandler GenerationStarted;
		public event GenerationCompletedEventHandler GenerationCompleted;
		public event GenerationStoppedEventHandler GenerationStopped;
		public event ProgressChangedEventHandler ProgressChanged;

		// Fields
		private bool stopGeneratingLogs = false;

		// Constructors
		public void StopGeneratingLogs ()
		{
			this.stopGeneratingLogs = true;
		}

		// Methods
		public bool GenerateLogsAndConversations (LogGenerationOptions options)
		{
			// Distribution value must be between 10% and 70%.
			if (options.DistributionPercentage < 10 || options.DistributionPercentage > 70)
			{
				throw new ArgumentOutOfRangeException (nameof (options.DistributionPercentage), "Distribution percentage must be between 10 and 70.");
			}

			// Fresh start
			this.stopGeneratingLogs = false;

			// Generate logs
			this.GenerateOutputLogFile (options, out var errorLogUniqeIds);

			if (this.stopGeneratingLogs == false)
			{
				// Generate solution conversation logs, if previous step
				// wasn't aborted
				this.GenerateOutputSolutionConversationFile (options, errorLogUniqeIds);
			}

			return !this.stopGeneratingLogs;
		}

		#region Private methods

		// Generate log output file
		private void GenerateOutputLogFile (LogGenerationOptions options, out string [] errorLogUniqeIds)
		{
			// File name
			var logOutputFile = $"{AppContext.BaseDirectory}Output_log.txt";

			// Create the log file
			var builder = new StringBuilder ();
			builder.AppendLine (this.FormLogFileTitleRow (options));
			File.WriteAllText (logOutputFile, builder.ToString ());
			builder.Clear ();

			//
			// Based on the log file size, compute the error log entries and normal log entries
			//
			var maxCharsInFile = options.LogFileSizeInMB * 1024 * 1024;

			var sampleInfoLogEntry = new LogEntry (false, options).ToString ();
			var sampleErrorLogEntry = new LogEntry (true, options).ToString ();

			// Compute the number of normal and error log lines.
			var normalLogCount = maxCharsInFile / sampleInfoLogEntry.Length * (100 - options.DistributionPercentage) / 100;
			var errorLogCount = maxCharsInFile  / sampleErrorLogEntry.Length * options.DistributionPercentage / 100;

			var totalRowsCount = normalLogCount + errorLogCount;

			// Randomly select the indices for the error log entries.
			var errorLogIndices = Utilities.GetRandomIndices (totalRowsCount-1, errorLogCount);

			//
			// Prepare for writing the log entries. Keep a HashSet<string> for the Log Unique IDs,
			// which are needed in the solution log file for cross-referencing.
			//
			var uniqueIdsHashSet = new HashSet<string> ();
			var lastPercent = 0;
			var progressPercent = 0;

			// Fire event "Started"
			this.FireStarted ("Output Log file generation");

			for (var i = 0; i < totalRowsCount; i++)
			{
				// If user opted to abort, break
				if (this.stopGeneratingLogs)
				{
					break;
				}

				// Based on the index, it would be either an error log, or a normal one.
				var isErrorLog = errorLogIndices.Contains (i);

				// Create a log entry, and add to the file
				var logEntry = new LogEntry (isErrorLog, options);
				builder.AppendLine (logEntry.ToString ());

				// Remember the Unique ID, if it is an error log
				if (isErrorLog)
				{
					uniqueIdsHashSet.Add (logEntry.LogEntryUniqueId);
				}

				// Fire "Progress Changed"
				progressPercent = (i * 100 / (totalRowsCount - 1));

				if (progressPercent != lastPercent)
				{
					lastPercent = progressPercent;
					this.FireProgressChanged (progressPercent);
				}

				// At every 200 lines, append the log entries to the output file.
				if (i % 200 == 0)
				{
					File.AppendAllText (logOutputFile, builder.ToString ());
					builder.Clear ();
				}
			}

			// Output log file successfully generated. 
			File.AppendAllText (logOutputFile, builder.ToString ());

			// Fire "Stopped"
			if (this.stopGeneratingLogs)
			{
				this.FireStopped ();
			}

			// The "out" variable for the next step (Solution Conversation log output file)
			errorLogUniqeIds = uniqueIdsHashSet.ToArray ();
		}

		// Generate Solution Conversation log file
		private void GenerateOutputSolutionConversationFile (LogGenerationOptions options, string [] errorLogUniqeIds)
		{
			// Output file name
			var solutionConvOutputFile = $"{AppContext.BaseDirectory}Output_solutionConversationsLog.txt";

			// Write the output file
			var builder = new StringBuilder ();
			builder.AppendLine (this.FormSolutionConvFileTitleRow (options));
			File.WriteAllText (solutionConvOutputFile, builder.ToString ());
			builder.Clear ();

			// Compute the number of regular, and solution entries.
			var sampleTicketNumber = $"INC{new Random ().Next (1000000, 9999999)}";
			var sampleSysSolutionConvEntry = new SolutionConversationEntry (false, "", "", "", options).ToString ();
			var sampleIncSolutionConvEntry = new SolutionConversationEntry (true, Guid.NewGuid ().ToString (), sampleTicketNumber, sampleTicketNumber, options).ToString ();

			var maxCharsInFile = options.SolutionConversationFileSizeInMB * 1024 * 1024;

			// Considering 6 repetitions for solution entries for each error log entry
			var solutionBytesCount = errorLogUniqeIds.Length * 6 * sampleIncSolutionConvEntry.Length;
			var remainingBytesCount = maxCharsInFile - solutionBytesCount;
			var errorSolutionConvCount = errorLogUniqeIds.Length;
			var normalSolutionConvCount = (int)(remainingBytesCount / sampleSysSolutionConvEntry.Length * 0.18);
			// 0.18 for factoring for \r\n newlines and randomizations.

			// Get total rows count
			var solutionConvCount = normalSolutionConvCount + errorSolutionConvCount;

			// Form random indices for the error rows
			var errorLogIndices
				= Utilities.GetRandomIndices (solutionConvCount - 1, errorSolutionConvCount);

			var lastPercent = 0;
			var logEntryIndex = 0;
			this.FireStarted ("Output Solution Conversation file generation");

			//
			// Prepare to create the solution conversation log entries
			//

			var runningTicketNumber = string.Empty;
			var previousTicketNumber = string.Empty;

			for (var i = 0; i < solutionConvCount; i++)
			{
				if (this.stopGeneratingLogs)
				{
					// Did user opt to abort?
					break;
				}

				var logEntryUniqueId = string.Empty;

				// Check if index is an error index
				var isErrorLog = errorLogIndices.Contains (i);

				if (isErrorLog)
				{
					// Get the cross-reference field Log Unique ID to cross-reference with the
					// Log output file rows.
					logEntryUniqueId = errorLogUniqeIds [logEntryIndex];
					logEntryIndex++;

					previousTicketNumber = runningTicketNumber;

					// Protect against out-of-bound exception
					if (logEntryIndex >= errorLogUniqeIds.Length)
					{
						logEntryIndex = errorLogUniqeIds.Length - 1;
					}
				}

				// Form a solution conversation entry
				var solutionConvEntry = new SolutionConversationEntry (isErrorLog, logEntryUniqueId, runningTicketNumber, previousTicketNumber, options);

				if (isErrorLog)
				{
					runningTicketNumber = solutionConvEntry.TicketNumber;
				}

				// Write to the output file, 6 times with various descriptions and resolving engineer ID.
				for (var j = 0; j < 6; j++)
				{
					builder.AppendLine (solutionConvEntry.ToString ());
					solutionConvEntry.RandomizeConversation ();
				}

				// Compute progress percentage
				var progressPercent = (i * 100 / (solutionConvCount - 1));

				if (progressPercent != lastPercent)
				{
					lastPercent = progressPercent;
					this.FireProgressChanged (progressPercent);
				}

				// At every 200 iterations, append to the output file.
				if (i % 200 == 0)
				{
					File.AppendAllText (solutionConvOutputFile, builder.ToString ());
					builder.Clear ();
				}
			}

			// Generation of Solution Conversation log file completed.
			File.AppendAllText (solutionConvOutputFile, builder.ToString ());

			// Fire "Completed"
			if (this.stopGeneratingLogs == false)
			{
				this.FireCompleted ("Solution Conversation generation successful");
				return;
			}

			// Fire "Stopped" if the user aborted.
			if (this.stopGeneratingLogs)
			{
				this.FireStopped ();
			}
		}

		private string FormLogFileTitleRow (LogGenerationOptions options)
		{
			return
				string.Join (
					options.FieldDelemiter.ToText (),
					options
						.LogFields
							.Where (kv => kv.Value)
							.ToList ()
							.Select (kv => kv.Key)
							.ToArray ()
				);
		}

		private string FormSolutionConvFileTitleRow (LogGenerationOptions options)
		{
			return
				string.Join (
					options.FieldDelemiter.ToText (),
					options
						.SolutionConversationFields
							.Where (kv => kv.Value)
							.ToList ()
							.Select (kv => kv.Key)
							.ToArray ()
				);
		}

		private void FireStarted (string activity)
		{
			if (this.GenerationStarted != null)
			{
				this.GenerationStarted (this, new (activity));
			}
		}

		private void FireStopped ()
		{
			if (this.stopGeneratingLogs)
			{
				this.stopGeneratingLogs = false;
				if (this.GenerationStopped != null)
				{
					this.GenerationStopped (this, new ());
				}
			}
		}

		private void FireCompleted (string activityStatus)
		{
			if (this.GenerationCompleted != null)
			{
				this.GenerationCompleted (this, new (activityStatus));
			}
		}

		private void FireProgressChanged (int progressPercent)
		{
			if (this.ProgressChanged != null)
			{
				this.ProgressChanged (this, new (progressPercent));
			}
		}

		#endregion
	}
}