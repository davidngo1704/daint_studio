using System;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace DaintStudio.Services.Blockchain;

public class TelegramService
{
    private static TelegramBotClient? bot;
    private static CancellationTokenSource? cts;

    public static async Task Register()
    {
        string botToken = Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN")
            ?? throw new InvalidOperationException("TELEGRAM_BOT_TOKEN environment variable is not set");

        bot = new TelegramBotClient(botToken);

        cts = new CancellationTokenSource();

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = new[] { UpdateType.Message }
        };

        bot.StartReceiving(
            updateHandler: HandleUpdateAsync,
            errorHandler: HandleErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        var me = await bot.GetMe();

        Console.WriteLine($"Bot started: @{me.Username}");

        Console.ReadLine();

        cts.Cancel();
        cts.Dispose();
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        try
        {
            if (update.Message is not { } message)
                return;

            if (message.Text is not { } messageText)
                return;

            Console.WriteLine($"Received: {messageText}");

            string response = messageText switch
            {
                "/start" => "Bot online 👽",
                "/ping" => "pong",
                _ => $"Bạn nói: {messageText}"
            };

            await client.SendMessage(
                chatId: message.Chat.Id,
                text: response,
                cancellationToken: cancellationToken
            );

            Console.WriteLine("Message sent successfully!");
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine($"Message sending was canceled: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error handling update: {ex.GetType().Name} - {ex.Message}");
        }
    }

    private static Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Polling Error: {exception.GetType().Name} - {exception.Message}");
        if (exception.InnerException is not null)
        {
            Console.WriteLine($"Inner Exception: {exception.InnerException.GetType().Name} - {exception.InnerException.Message}");
        }
        return Task.CompletedTask;
    }
}