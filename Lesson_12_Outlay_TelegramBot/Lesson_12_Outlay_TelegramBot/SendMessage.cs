using Telegram.Bot;
using Telegram.Bot.Types;

static class SendMessage
{
    public static void _SendMessage(ITelegramBotClient bot, User user, string message)
    {
        bot.SendTextMessageAsync(user.ChatId, message);
    }
}