using Microsoft.VisualBasic;
using VictoriaHelperBot.BotCommands.PrivateChatCommands;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace VictoriaHelperBot.CommandsHandles
{
    public class PrivateCommandsController
    {
        public async Task<bool> TryHandleCommand(ITelegramBotClient botClient, Message message, CancellationToken token)
        {
            string[] commandWithArgs = message.Text.ToLower().Split();
            string command = commandWithArgs[0];

            if(message.Chat.Type == ChatType.Private)
            {
                if (commandWithArgs[0] == "/start")
                {
                    await new StartCommandHandler().Execute(botClient, message, token);
                    return true;
                }
            }
            else if (message.Chat.Type == ChatType.Supergroup || message.Chat.Type == ChatType.Private)
            {
                if (commandWithArgs[0] == "/help")
                {
                    await new HelpCommandHandler().Execute(botClient, message, token);
                    return true;
                }
            }
               
            return false;
        }
    }
}
