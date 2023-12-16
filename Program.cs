using Microsoft.Extensions.DependencyInjection;

using LogGenerator.Business;

namespace LogGenerator
{
	internal static class Program
	{
		//  The main entry point for the application.
		[STAThread]
		static void Main ()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.

			// Configure services
			var serviceProvider
				= new ServiceCollection ()
					.AddTransient<ILogAndSolutionConversationsGenerator, LogAndSolutionConversationsGenerator> ()
					.AddTransient<LogGeneratorScreen> ()
					.BuildServiceProvider ();

			ApplicationConfiguration.Initialize ();
			Application.Run (serviceProvider.GetRequiredService<LogGeneratorScreen> ());
		}
	}
}