using DaintStudio.Services.Blockchain;

namespace DaintStudio
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();

            Environment.SetEnvironmentVariable("TELEGRAM_BOT_TOKEN", "8101815767:AAGJGSN3qrpuHuHItzvBUbe1Eb6Wkmfi0Lw");

            //string botToken = Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN")
            //    ?? throw new InvalidOperationException("TELEGRAM_BOT_TOKEN environment variable is not set");

            TelegramService.Register().Wait();

            Application.Run(new EntryForm());

        }

    }
}