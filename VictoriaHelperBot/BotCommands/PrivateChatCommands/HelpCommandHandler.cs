using Telegram.Bot;
using Telegram.Bot.Types;

namespace VictoriaHelperBot.BotCommands.PrivateChatCommands
{
    public class HelpCommandHandler : IBotCommandHandler
    {
        public async Task Execute(ITelegramBotClient botClient, Message message, CancellationToken token)
        {
            await botClient.SendTextMessageAsync
                (
                    chatId: message.Chat.Id,
                    text: "It is help message, which will be created in future :D",
                    messageThreadId: message.MessageThreadId,
                    cancellationToken: token
                );
        }
    }
}
