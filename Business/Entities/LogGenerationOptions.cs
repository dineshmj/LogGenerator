using LogGenerator.Business.Enums;

namespace LogGenerator.Business.Entities
{
	public sealed class LogGenerationOptions
	{
		public string DateFormat { get; set; }

		public LogUniqueIds LogUniqueId { get; set; }

		public FieldDelimiter FieldDelemiter { get; set; }

		public int DistributionPercentage { get; set; }

		public IDictionary<string, bool> LogFields { get; set; }

		public IDictionary<string, bool> SolutionConversationFields { get; set; }

		public int LogFileSizeInMB { get; set; }

		public int SolutionConversationFileSizeInMB { get; set; }

		public string SampleErrorShortDescription { get; set; }

		public string SampleErrorDetailedDescription { get; set; }

		public string [] SolutionConversationLines { get; set; }
	}
}