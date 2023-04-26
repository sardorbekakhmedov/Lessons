using JFA.Telegram.Console;
using System.Globalization;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var users = new List<User>();
var rooms = new List<Room>();


var botManager = new TelegramBotManager();
var bot = botManager.Create("5674695715:AAEGpPEyu_tUbeJp_C4slf89laNWGq9PQM0");

var me = await bot.GetMeAsync();

Console.WriteLine($"{me.FirstName}:  Bot is working! ");


botManager.Start(NewMessage);


void NewMessage(Update update)
{
    if (update.Type != UpdateType.Message)
        return;

    Console.WriteLine($"Username: {update.Message.From.FirstName}, Message text:  {update.Message!.Text}\n");

    var message = update.Message.Text;

    var user = CheckUser(update);

    switch (user.NextMessage)
    {
        case ENextMessage.Created: SendEnterName(user); break;
        case ENextMessage.UserName: SeveUserNameAndSendMenu(user, message!); break;
        case ENextMessage.CreatOrJoinRoomMenu: CreateRoomOrJoinMenu(user, message!); break;
        case ENextMessage.RoomName: CreateNewRoom(user, message!); break;
        case ENextMessage.ChooseOutlaysMenu: ChooseOutlaysMenu(user, message); break;
        case ENextMessage.SaveOutlayName: SaveSendOutlayName(user, message, update); break;
        case ENextMessage.EnterPrice: SaveSendOutlayPrice(user, message!); break;
        case ENextMessage.CheckKey: CheckRoomName(user, message!); break;
        default: bot.SendTextMessageAsync(user.ChatId, "Unknown command!!!"); break;
    }
}



User CheckUser(Update update)
{
    var chatId = update.Message.From.Id;

    User? user = users.FirstOrDefault(user => user.ChatId == chatId);

    if (user == null)
    {
        user = new User();
        user.ChatId = chatId;
        users.Add(user);
        user.NextMessage = ENextMessage.Created;
    }

    return user;
}

void SendEnterName(User user)
{
    bot.SendTextMessageAsync(user.ChatId, "Enter your name: ");
    user.NextMessage = ENextMessage.UserName;
}

void SeveUserNameAndSendMenu(User user, string message)
{
    user.Name = message;
    user.NextMessage = ENextMessage.CreatOrJoinRoomMenu;

    SendMenu(user);
}

void SendMenu(User user)
{
    var roomMenu = $"Menu: \nCreated room  \nJoin room  \nMy rooms";

    var keyboardButtonStart = new ReplyKeyboardMarkup(new List<List<KeyboardButton>>()
    {
         new List<KeyboardButton>() { new KeyboardButton("Created room" ) },
         new List<KeyboardButton>() { new KeyboardButton("Join room")    },
         new List<KeyboardButton>() { new KeyboardButton("My rooms")    }
    });

    keyboardButtonStart.ResizeKeyboard = true;
    bot.SendTextMessageAsync(user.ChatId, roomMenu, replyMarkup: keyboardButtonStart);
}

void CreateRoomOrJoinMenu(User user, string message)
{
    switch (message.ToLower())
    {
        case "created room": CreatedRoom(user); break;
        case "join room": JoinRoom(user, message); break;
        case "my rooms": MyRooms(user); break;
        default:
            {
                bot.SendTextMessageAsync(user.ChatId, "Vatiantlardan birini tanlang!");
                CreateRoomOrJoinMenu(user, message);
            }
            break;
    }
}

void MyRooms(User user)
{
    if (user.MyRooms == null || user.MyRooms.Count == 0 )
    {
        bot.SendTextMessageAsync(user.ChatId, "You currently have no rooms!");
        SendMenu(user);
    }
    else 
    {   
        string myRooms = "My  all  rooms: \n\n";
        foreach (var roomName in user.CurrentRoom.Name)
        {
            myRooms += $"{roomName}\n";
        }
        bot.SendTextMessageAsync(user.ChatId, myRooms);
        SendMenu(user);
    }
}



void CreatedRoom(User user)
{
    bot.SendTextMessageAsync(user.ChatId, "Enter room name: ", replyMarkup: new ReplyKeyboardRemove());
    user.NextMessage = ENextMessage.RoomName;
}

void CreateNewRoom(User user, string message)
{
    bool roomName = CheckRomName(rooms, message);

    if (roomName)
    {
        bot.SendTextMessageAsync(user.ChatId, "Invalid name! try agin new room name");
        CreatedRoom(user);
    }
    else
    {
        var newRoom = new Room
        {
            Name = message,
            OwnerChatId = user.ChatId,
            UserIds = new List<long> { user.ChatId },
            Outlays = new List<Outlay>(),
        };

        user.CurrentRoom = newRoom;
        rooms.Add(newRoom);
    //    user.MyRooms.Add(newRoom.Name);
        bot.SendTextMessageAsync(user.ChatId, "Success room name!");

        SendRoomMenu(user);
    }
}

bool CheckRomName(List<Room> rooms, string message)
{
    if (rooms.Where(rom => rom.Name == message).FirstOrDefault() != null)
        return true;

    return false;
}

void SendRoomMenu(User user)
{
    var roomMenu = $"<< Room name:   {user.CurrentRoom.Name} >> \n\nAddOutlay" + "\nShowOutlays" +
                         "\nShowRoomdetails, \nConculate, \nExit";

    var keyboardButtonStart = new ReplyKeyboardMarkup(new List<List<KeyboardButton>>()
    {
         new List<KeyboardButton>() {  new KeyboardButton("AddOutlay"),  new KeyboardButton("ShowOutlays") },
         new List<KeyboardButton>() {  new KeyboardButton("ShowRoomdetails") },
         new List<KeyboardButton>() {  new KeyboardButton("Conculate") },
         new List<KeyboardButton>() {  new KeyboardButton("Exit")  }
    });

    keyboardButtonStart.ResizeKeyboard = true;
    bot.SendTextMessageAsync(user.ChatId, roomMenu, replyMarkup: keyboardButtonStart);

    user.NextMessage = ENextMessage.ChooseOutlaysMenu;
}

void ChooseOutlaysMenu(User user, string? message)
{
    switch (message)
    {
        case "AddOutlay": AddOutlay(user); break;
        case "ShowOutlays": SendOutlays(user); break;
        case "ShowRoomdetails": ShowRoomdetails(user); break;
        case "Conculate": Conculate(user); break;
        case "Exit": Exit(user); break;
        default:
            {
                bot.SendTextMessageAsync(user.ChatId, "Vatiantlardan birini tanlang!");
                SendRoomMenu(user);
            }
            break;
    }
}

void AddOutlay(User user)
{
    bot.SendTextMessageAsync(user.ChatId, "Enter outlay name: ", replyMarkup: new ReplyKeyboardRemove());
    user.NextMessage = ENextMessage.SaveOutlayName;
}

void SaveSendOutlayName(User user, string? messsage, Update update)
{
    Outlay outlay = new()
    {
        PruductName = messsage,
        UserChatId = user.ChatId,
        UserName = update.Message.From.FirstName,
        CreatedTime = DateTime.Now,
    };

    user.CurrentRoom.Outlays.Add(outlay);
    user.CurrentAddingOutlay = outlay;

    bot.SendTextMessageAsync(user.ChatId, "Enter outlay Price: ");
    user.NextMessage = ENextMessage.EnterPrice;
}


void SaveSendOutlayPrice(User user, string messsage)
{
    try
    {
        user.CurrentAddingOutlay!.ProductPrice = Convert.ToInt64(messsage); ;
        user.NextMessage = ENextMessage.ChooseOutlaysMenu;

        SendRoomMenu(user);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        bot.SendTextMessageAsync(user.ChatId, "Incorrect format: try again:  ");
        user.NextMessage = ENextMessage.EnterPrice;
    }
}


void SendOutlays(User user)
{
    var rows = new List<List<InlineKeyboardButton>>();

    foreach (var outlay in user.CurrentRoom.Outlays)
    {
        var chatId = InlineKeyboardButton.WithCallbackData(outlay.UserName!);
        var name = InlineKeyboardButton.WithCallbackData(outlay.PruductName!);
        var price = InlineKeyboardButton.WithCallbackData(outlay.ProductPrice.ToString());
        var time = InlineKeyboardButton.WithCallbackData(outlay.CreatedTime.ToShortDateString());

        rows.Add(new List<InlineKeyboardButton>() { chatId, name, price, time });
    }

    var keyboard = new InlineKeyboardMarkup(rows);

    bot.SendTextMessageAsync(user.ChatId, "All Outlays\n", replyMarkup: keyboard);
}

void Conculate(User user)
{

    var totalPriceSum = user.CurrentRoom.Outlays.Sum(u => u.ProductPrice);

    var averageSum = totalPriceSum / user.CurrentRoom.UserIds.Count;

    string result = $"\nRoom name:   {user.CurrentRoom.Name} \n\nTotal sum: {totalPriceSum} \nAverage sum {averageSum}\n";

    foreach (var userId in user.CurrentRoom.UserIds)
    {
        user = users.Where(u => u.ChatId == userId).FirstOrDefault()!;

        var userSum = user.CurrentRoom!.Outlays!.Where(c => c.UserChatId == userId).
            Sum(u => u.ProductPrice);

        result += $"\nUser name:   {user.Name},   " +
                     $"User sum:   {userSum},   " +
                     $"Difference:   {userSum - averageSum}\n";
    }

    bot.SendTextMessageAsync(user.ChatId, result);
}


void ShowRoomdetails(User user)
{
    var room = user.CurrentRoom.GetShowRoom(user.CurrentRoom.OwnerChatId, user.CurrentRoom.Name,
        user.CurrentRoom.Outlays, user.CurrentRoom.UserIds);

    bot.SendTextMessageAsync(user.ChatId, room);
}


void JoinRoom(User user, string message)
{
    bot.SendTextMessageAsync(user.ChatId, "Enter room name to join:  ");
    user.NextMessage = ENextMessage.CheckKey;
}


void CheckRoomName(User user, string message)
{
    var room = rooms.FirstOrDefault(u => u.Name == message);

    if (room == null)
    {
        bot.SendTextMessageAsync(user.ChatId, "Invalid room name!");
        SendMenu(user);
    }
    else
    {
        user.CurrentRoom = room;
        room.UserIds.Add(user.ChatId);

        bot.SendTextMessageAsync(user.ChatId, "Success join:  ");
       // user.MyRooms.Add(room.Name);
        SendRoomMenu(user);
    }
}


void Exit(User user)
{
    user.CurrentRoom = null;
    user.NextMessage = ENextMessage.CreatOrJoinRoomMenu;
    bot.SendTextMessageAsync(user.ChatId, "Exit ");

    SendMenu(user);
}




