using System.Text;

using LogGenerator.Business.Constants;
using LogGenerator.Business.Enums;
using LogGenerator.Extensions;

namespace LogGenerator.Business.Entities
{
	public sealed class SolutionConversationEntry
	{
		// Resolving Engineers
		private readonly string [] engineers = { "Matt", "Ron", "Lee", "Kerry", "Elisa", "John", "Carla" };

		// Normal log conversations
		private readonly string [] systemPatchConversations =
		{
			"This is due to wsa011x64.exe patch missing on the VDI. Install the same.",
			"Refer to the KB article on microsoft: https://windows.microsoft.com/patch/wsa011x64",
			"Referring to the System team for approval of OS patch",
			"Install patch wsa011x64.exe from https://windows.microsoft.com/patch/wsa011x64",
			"Elevated privilege required for installing patch wsa011x64.exe. Referring to next level"
		};

		// Normal log resolutions
		private readonly string [] providedResolutions =
		{
			"Scheduled patch is Software Center",
			"Updated VDI with OS patch",
			"TBD",
			"Deferred due to lack of elevated privileges",
			"Abandoned, as the user's VDI has been decommissioned"
		};

		private readonly LogGenerationOptions options;

		//
		// Properties
		//

		public DateTime ConversationDateTime { get; private set; }

		public string LogEntryUniqueId { get; private set; }

		public string TicketNumber { get; set; }

		public ProblemClassification ProblemClassification { get; private set; }

		public string ResolvingEngineerId { get; set; }

		public string ConversationText { get; set; }

		public string ResolutionProvided { get; set; }

		// Constructors
		public SolutionConversationEntry
			(
				bool isSolutionEntry,
				string logEntryUniqueId,
				string runningTicketNumber,
				string previousTicketNumber,
				LogGenerationOptions options
			)
		{
			this.options = options;
			this.ConversationDateTime = DateTime.Now;

			// Solution Conversation
			if (isSolutionEntry)
			{
				// Cross-referencing log unique ID.
				this.LogEntryUniqueId = logEntryUniqueId;

				// Ticket # starts with "INC"
				this.TicketNumber
					=  string.IsNullOrEmpty (runningTicketNumber) || string.IsNullOrWhiteSpace (runningTicketNumber)
						? $"INC{new Random ().Next (1000000, 9999999)}"
						: runningTicketNumber;
				this.ProblemClassification = ProblemClassification.LoBApplication;
				this.ResolvingEngineerId = this.engineers.Random ();

				// Assign random solution conversation text
				this.ConversationText = options.SolutionConversationLines.Random ();

				// If Ticket # reference is there, refer to the previous ticket #
				if (this.ConversationText.IndexOf (FilePlaceholders.SOLN_CONV_TICKET_NUMBER) >= 0)
				{
					this.ConversationText = this.ConversationText.Replace (FilePlaceholders.SOLN_CONV_TICKET_NUMBER, previousTicketNumber);
				}

				this.ResolutionProvided = "Applied KB Article # KB00195372";
			}
			else
			{
				// Normal conversation log entries
				this.LogEntryUniqueId = $"XIS{new Random ().Next (10000, 99999)}";
				this.TicketNumber =  $"SYS{new Random ().Next (1000000, 9999999)}";
				this.ProblemClassification = ProblemClassification.SystemApplication;
				this.ResolvingEngineerId = this.engineers.Random ();
				this.ConversationText = this.systemPatchConversations.Random ();
				this.ResolutionProvided = this.providedResolutions.Random ();
			}
		}

		// Change the Solution Conversation & Resolving Engineer
		public void RandomizeConversation ()
		{
			this.ConversationText = this.systemPatchConversations.Random ();
			this.ResolvingEngineerId = this.engineers.Random ();
		}


		public override string ToString ()
		{
			var builder = new StringBuilder ();
			var delimiter = this.options.FieldDelemiter.ToText ();

			// Conversation Date Time
			if (this.options.SolutionConversationFields [SolutionFields.SOLN_DATE_TIME])
			{
				builder.Append (this.ConversationDateTime.ToString (this.options.DateFormat));
				builder.Append (delimiter);
			}

			// Unique ID of the log entry
			if (this.options.SolutionConversationFields [SolutionFields.SOLN_LOG_ENTRY_UNIQUE_ID])
			{
				builder.Append (this.LogEntryUniqueId);
				builder.Append (delimiter);
			}

			// Ticket Number
			if (this.options.SolutionConversationFields [SolutionFields.SOLN_TICKET_NUMBER])
			{
				builder.Append (this.TicketNumber);
				builder.Append (delimiter);
			}

			// Problem Classification
			if (this.options.SolutionConversationFields [SolutionFields.SOLN_PROBLEM_CLASSIFICATION])
			{
				builder.Append (this.ProblemClassification);
				builder.Append (delimiter);
			}

			// Resolving Engineer
			if (this.options.SolutionConversationFields [SolutionFields.SOLN_RESOLVING_ENGINEER_ID])
			{
				builder.Append (this.ResolvingEngineerId);
				builder.Append (delimiter);
			}

			// Conversation text
			if (this.options.SolutionConversationFields [SolutionFields.SOLN_CONVERSATION_TEXT])
			{
				builder.Append (this.ConversationText);
				builder.Append (delimiter);
			}

			// Resolution Provided
			if (this.options.SolutionConversationFields [SolutionFields.SOLN_RESOLUTION_PROVIDED])
			{
				builder.Append (this.ResolutionProvided);
				builder.Append (delimiter);
			}

			return builder.ToString ();
		}
	}
}