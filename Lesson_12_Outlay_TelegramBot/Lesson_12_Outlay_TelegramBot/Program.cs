using JFA.Telegram.Console;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var users = new List<User>();
var outlay = new Outlay();

const string TOKEN = "5674695715:AAEGpPEyu_tUbeJp_C4slf89laNWGq9PQM0";
var client = new TelegramBotManager();
var bot = client.Create(TOKEN);

var me = await bot.GetMeAsync();

Console.WriteLine($"{me.FirstName}:  Bot ishlashdan to'xtadi!");

client.Start(NewMessage);

void NewMessage(Update update)
{
    if (update.Type != UpdateType.Message)
        return;

    User user;

    var chatId = update.Message.From.Id;
    var messageText = update.Message.Text;

    if (users.Any(user => user.ChatId == chatId))
    {
        user = users.First(user => user.ChatId == chatId);
    }
    else
    {
        user = new User();
        user.ChatId = chatId;
        user.outlays = new List<Outlay>();
        users.Add(user);
        user.NextMessage = ENextMessage.Welcome;
    }

    switch (user.NextMessage)
    {
        case ENextMessage.Welcome:
            {
                SendMessage._SendMessage(bot, user, "Welcome! ");
                SendMessage._SendMessage(bot, user, OutlayAppMenu.RegistrationMenu(user));
                user.NextMessage = ENextMessage.Menu;
            }
            break;
        case ENextMessage.Menu:
            {
                switch (messageText)
                {
                    case "1":
                        {
                            SendMessage._SendMessage(bot, user, "Enter your name: ");
                            user.NextMessage = ENextMessage.FirstName;
                        }
                        break;
                    case "2":
                        {
                            SendMessage._SendMessage(bot, user, "Iltimos oldin ro'yxatdan o'ting!");
                            SendMessage._SendMessage(bot, user, OutlayAppMenu.RegistrationMenu(user));
                            user.NextMessage = ENextMessage.Menu;
                        }
                        break;
                    default:
                        {
                            SendMessage._SendMessage(bot, user, "Unknown command! ");
                            user.NextMessage = ENextMessage.Menu;
                        }
                        break;
                }
            }
            break;
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
                user.Phone = messageText;
                SendMessage._SendMessage(bot, user, $"Your phone number: {messageText}");
                user.NextMessage = ENextMessage.OutlayMenu;
                SendMessage._SendMessage(bot, user, OutlayAppMenu.GetOutlayMenu());
            }
            break;
        case ENextMessage.OutlayMenu:
            {
                switch (messageText)
                {
                    case "1":
                        {                        
                            SendMessage._SendMessage(bot, user, "Enter product name: ");
                            user.NextMessage = ENextMessage.ProductName;
                        }
                        break;
                    case "2":
                        {
                            SendMessage._SendMessage(bot, user, "Iltimos oldin ro'yxatdan o'ting!");
                            SendMessage._SendMessage(bot, user, OutlayAppMenu.RegistrationMenu(user));
                            user.NextMessage = ENextMessage.OutlayMenu;
                        }
                        break;
                    default:
                        {
                            SendMessage._SendMessage(bot, user, "Unknown command! ");
                            user.NextMessage = ENextMessage.OutlayMenu;
                        }
                        break;
                }
            }
            break;
        case ENextMessage.ProductName:
            {
                outlay.PruductName = messageText;
                user.NextMessage = ENextMessage.ProductPrice;
            }
            break;
        case ENextMessage.ProductPrice:
            {
                
                    outlay.ProductPrice = Convert.ToInt32(messageText);
                    user.NextMessage = ENextMessage.ProductPrice;
                
            }
            break;


            /*       default:
                       {
                           SendMessage._SendMessage(bot, user, "Unknown command! ");
                           user.NextMessage = ENextMessage.Menu;
                       }
                       break;*/
    }
}










