using VictoriaHelperBot.CommandsHandles;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace VictoriaHelperBot;

public class BotClient
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly CancellationTokenSource _receiverCancellationToken;

    private readonly PrivateCommandsController _commandController;

    public BotClient(string apiKey)
    {
        _telegramBotClient = new TelegramBotClient(apiKey);
        _receiverCancellationToken = new CancellationTokenSource();
        _commandController = new PrivateCommandsController();
    }

    public async Task StartReceiver()
    {
        var receiverOptions = new ReceiverOptions { AllowedUpdates = { } };

        await _telegramBotClient.ReceiveAsync(OnMessage, OnErrorMessage, receiverOptions, _receiverCancellationToken.Token);
    }

    private async Task OnMessage(ITelegramBotClient botClient, Update update, CancellationToken token)
    {
        if (update != null)
        {
            if (update.Type == UpdateType.Message && update.Message != null)
            {
                if (update.Message.Text != null && update.Message.Chat.Type == ChatType.Private &&
                    await _commandController.TryHandleCommand(botClient, update.Message, token))
                {
                    return;
                }
            }
        }
    }

    private async Task OnErrorMessage(ITelegramBotClient botClient, Exception exception, CancellationToken token)
    {
        if (exception is ApiRequestException e)
        {
            await botClient.SendTextMessageAsync("", e.Message, cancellationToken: token);
        }
    }

}