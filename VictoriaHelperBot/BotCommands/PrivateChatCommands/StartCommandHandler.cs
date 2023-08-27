using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace VictoriaHelperBot.BotCommands.PrivateChatCommands;


public class StartCommandHandler : IBotCommandHandler
{
    public async Task Execute(ITelegramBotClient botClient, Message message, CancellationToken token)
    {

        InlineKeyboardMarkup inlineKeyboard = new(new[]
                 {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: "help", callbackData: "/help"),
                    }
                });

        await botClient.SendTextMessageAsync
                (
                    chatId: message.Chat.Id,
                    text: "Hello, friend\nI am your the best helper,\nwhich improve your life (~˘▾˘)~",
                    messageThreadId: message.MessageThreadId,
                    replyMarkup: inlineKeyboard,
                    cancellationToken: token
                );
    }
}