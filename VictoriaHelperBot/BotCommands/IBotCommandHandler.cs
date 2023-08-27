using Telegram.Bot.Types;
using Telegram.Bot;

namespace VictoriaHelperBot.BotCommands
{
    public interface IBotCommandHandler
    {
        Task Execute(ITelegramBotClient botClient, Message message, CancellationToken token);
    }
}