using System.Text;

using LogGenerator.Business.Constants;
using LogGenerator.Business.Enums;
using LogGenerator.Extensions;

namespace LogGenerator.Business.Entities
{
	public sealed class LogEntry
	{
		// Fields
		private static int runningNumber = 0;
		private readonly LogGenerationOptions options;

		// Properties
		public LogEntryType LogEntryType { get; private set; }

		public DateTime LogDateTime { get; private set; }

		public string LogEntryUniqueId { get; private set; }

		public string AppName { get; set; }

		public string ModuleName { get; set; }

		public string ErrorShortDescription { get; set; }

		public string ErrorDetailedDescription { get; set; }

		// Constructors
		public LogEntry (bool isErrorLog, LogGenerationOptions options)
		{
			this.options = options;

			this.AppName = "ICW";
			this.ModuleName = "PolicyMgmt";

			if (isErrorLog)
			{
				// This is an error log
				this.LogEntryType = LogEntryType.FatalError;
				this.ErrorShortDescription = options.SampleErrorShortDescription;
				this.ErrorDetailedDescription = options.SampleErrorDetailedDescription;
			}
			else
			{
				// Normal log. Randomly set Info or Warning
				var randomNumber = new Random ().Next (1, 3);
				this.LogEntryType = (LogEntryType) (new Random ().Next (2));

				if (this.LogEntryType == LogEntryType.Info)
				{
					// Information
					this.ErrorShortDescription = randomNumber switch
					{
						1 => $"Quote issued",
						2 => $"Converted quote to Proposal",
						3 => $"Policy issued on Proposal"
					};
					this.ErrorDetailedDescription = randomNumber switch
					{
						1 => $"Successfully issued quote for Travel. Quote ID: QTE{new Random ().Next (1000000, 9999999)}.",
						2 => $"Successfully converted Quote QTE{new Random ().Next (1000000, 9999999)} to proposal. Proposal ID: PPS{new Random ().Next (1000000, 9999999)}.",
						3 => $"Successfully converted Proposal PPS{new Random ().Next (1000000, 9999999)} to policy. Policy ID: POL{new Random ().Next (1000000, 9999999)}.\","
					};
				}
				else
				{
					// Warning
					this.ErrorShortDescription = randomNumber switch
					{
						1 => $"Drive space is becoming low",
						2 => $"Processor overload detected",
						3 => $"Uploaded PDF contents are suspecious"
					};
					this.ErrorDetailedDescription = randomNumber switch
					{
						1 => $"Please clean C:\\ drive and make more disk space available",
						2 => $"High concurrency is causing the processor to slow down",
						3 => $"The uploaded PDF document by the customer did not pass content validation"
					};
				}
			}

			this.LogDateTime = DateTime.Now;
			this.LogEntryUniqueId = options.LogUniqueId switch
			{
				LogUniqueIds.Guid => Guid.NewGuid ().ToString (),
				LogUniqueIds.RunningNumber => (++LogEntry.runningNumber).ToString (),
				LogUniqueIds.RunningHexNumber => (++LogEntry.runningNumber).ToString ("X").PadLeft (10, '0')
			};
		}

		public override string ToString ()
		{
			var builder = new StringBuilder ();
			var delimiter = this.options.FieldDelemiter.ToText ();

			// Date Time
			if (this.options.LogFields [LogFields.LOG_DATE_TIME])
			{
				builder.Append (this.LogDateTime.ToString (this.options.DateFormat));
				builder.Append (delimiter);
			}

			// Unique ID of the log entry
			if (this.options.LogFields [LogFields.LOG_ENTRY_UNIQUE_ID])
			{
				builder.Append (this.LogEntryUniqueId);
				builder.Append (delimiter);
			}

			// Log entry type
			if (this.options.LogFields [LogFields.LOG_ENTRY_TYPE])
			{
				builder.Append (this.LogEntryType);
				builder.Append (delimiter);
			}

			// App name
			if (this.options.LogFields [LogFields.LOG_APP_NAME])
			{
				builder.Append (this.AppName);
				builder.Append (delimiter);
			}

			// Module name
			if (this.options.LogFields [LogFields.LOG_MODULE_NAME])
			{
				builder.Append (this.ModuleName);
				builder.Append (delimiter);
			}

			// Log entry short description
			if (this.options.LogFields [LogFields.LOG_SHORT_DESC])
			{
				builder.Append (this.ErrorShortDescription);
				builder.Append (delimiter);
			}

			// Log entry detailed description
			if (this.options.LogFields [LogFields.LOG_DETAILED_DESC])
			{
				builder.Append (this.ErrorDetailedDescription);
				builder.Append (delimiter);
			}

			return builder.ToString ();
		}
	}
}