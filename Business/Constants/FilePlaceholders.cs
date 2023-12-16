namespace LogGenerator.Business.Constants
{
	public static class FilePlaceholders
	{
		public const string LOG_ERROR_SHORT_DESC_STARTING = "## ERROR_SHORT_DESCRIPTION {{ ##";
		public const string LOG_ERROR_SHORT_DESC_ENDING = "## ERROR_SHORT_DESCRIPTION }} ##";
		public const string LOG_ERROR_DETAILED_DESC_STARTING = "## ERROR_DETAILED_DESCRIPTION {{ ##";
		public const string LOG_ERROR_DETAILED_DESC_ENDING = "## ERROR_DETAILED_DESCRIPTION }} ##";

		public const string SOLN_CONV_LINE_STARTING = "## CONVERSATION ## ";
		public const string SOLN_CONV_TICKET_NUMBER = "##TICKET_NUMBER##";
	}
}