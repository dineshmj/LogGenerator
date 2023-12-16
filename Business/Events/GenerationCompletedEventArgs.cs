namespace LogGenerator.Business.Events
{
	public sealed class GenerationCompletedEventArgs
		: EventArgs
	{
		public string ActivityStatus { get; }

		public GenerationCompletedEventArgs (string activityStatus)
		{
			ActivityStatus = activityStatus;
		}
	}
}