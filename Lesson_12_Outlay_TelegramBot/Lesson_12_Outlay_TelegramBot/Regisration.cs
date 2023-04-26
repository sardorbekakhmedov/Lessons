using Telegram.Bot;

static class Regisration
{
    public static void SignUp(ITelegramBotClient bot, User user, string messageText)
    {
        switch (user.NextMessage)
        {
            case ENextMessage.FirstName:
                {
                    SendMessage._SendMessage(bot, user, $"Your name: {messageText}");
                    user.Name = messageText;

                    SendMessage._SendMessage(bot, user, "Enter phone number: ");
                    user.NextMessage = ENextMessage.Phone;
                }
                break;
            case ENextMessage.Phone:
                {
                    SendMessage._SendMessage(bot, user, $"Your name: {messageText}");
                    user.Phone = messageText;

                    user.NextMessage = ENextMessage.Result;
                }
                break;
        }
    }

    public static string GetInfoUser(User user)
    {
        user.NextMessage = ENextMessage.Menu;
        return $"User chatId: {user.ChatId}" +
            $"\nUser name: {user.Name}" +
            $"\nPhone number: {user.Phone}";
    } 
}

