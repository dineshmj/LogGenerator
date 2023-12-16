namespace LogGenerator.Business.Events
{
	public sealed class ProgressChangedEventArgs
		: EventArgs
	{
		public int ProgressPercentage { get; }

		public ProgressChangedEventArgs (int progressPercentage)
		{
			this.ProgressPercentage = progressPercentage;
		}
	}
}