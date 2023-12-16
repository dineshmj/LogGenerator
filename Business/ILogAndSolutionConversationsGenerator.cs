using LogGenerator.Business.Entities;
using LogGenerator.Business.Events;

namespace LogGenerator.Business
{
	public interface ILogAndSolutionConversationsGenerator
	{
		void StopGeneratingLogs ();

		bool GenerateLogsAndConversations (LogGenerationOptions options);

		event GenerationStartedEventHandler GenerationStarted;
		event GenerationCompletedEventHandler GenerationCompleted;
		event GenerationStoppedEventHandler GenerationStopped;
		event ProgressChangedEventHandler ProgressChanged;
	}
}