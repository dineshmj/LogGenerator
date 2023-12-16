namespace LogGenerator.Business.Events
{
	public sealed class GenerationStartedEventArgs
		: EventArgs
	{
		public string CurrentActivity { get; }

		public GenerationStartedEventArgs (string currentActivity)
		{
			CurrentActivity = currentActivity;
		}
	}
}