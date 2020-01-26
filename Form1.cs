using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading;
using System.IO;
using System.Diagnostics;

using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace New_Bot_Abcc
{

    
    public partial class Form1 : Form
    {

        BackgroundWorker bw;

        public Form1()
        {

            ///CHAT ID -271196401\          


            InitializeComponent();
            this.bw = new BackgroundWorker();
            this.bw.DoWork += bw_DoWork;

            /*
            Cards[] Cards = new Cards[32];
            Cards[0] = new Cards { Name = "Прачечная", Price = "1 000 QZT" };
            Cards[1] = new Cards { Name = "Мельница", Price = "2 000 QZT" };
            Cards[2] = new Cards { Name = "Конюшня", Price = "3 000 QZT" };
            Cards[3] = new Cards { Name = "Оранжерея", Price = "4 000 QZT" };
            Cards[4] = new Cards { Name = "Киоск с мороженым", Price = "5 000 QZT" };
            Cards[5] = new Cards { Name = "Мясная лавка", Price = "6 000 QZT" };
            Cards[6] = new Cards { Name = "Кафе", Price = "7 000 QZT" };
            Cards[7] = new Cards { Name = "Лапшичная", Price = "8 000 QZT" };
            Cards[8] = new Cards { Name = "Бар", Price = "9 000 QZT" };
            Cards[9] = new Cards { Name = "Кузница", Price = "11 000 QZT" };
            Cards[10] = new Cards { Name = "Дом сапожника", Price = "13 000 QZT" };
            Cards[11] = new Cards { Name = "Аптека", Price = "15 000 QZT" };
            Cards[12] = new Cards { Name = "СТО", Price = "17 000 QZT" };
            Cards[13] = new Cards { Name = "Чайная", Price = "19 000 QZT" };
            Cards[14] = new Cards { Name = "Фабрика игрушек", Price = "21 000 QZT" };
            Cards[15] = new Cards { Name = "Кондитерская", Price = "25 000 QZT" };
            Cards[16] = new Cards { Name = "Молокозавод", Price = "50 000 QZT" };
            Cards[17] = new Cards { Name = "Покерный клуб", Price = "75 000 QZT" };
            Cards[18] = new Cards { Name = "Таксопарк", Price = "100 000 QZT" };
            Cards[19] = new Cards { Name = "Фитнес зал", Price = "125 000 QZT" };
            Cards[20] = new Cards { Name = "Заправка", Price = "150 000 QZT" };
            Cards[21] = new Cards { Name = "Пилорама", Price = "300 000 QZT" };
            Cards[22] = new Cards { Name = "Хостел", Price = "400 000 QZT" };
            Cards[23] = new Cards { Name = "Аквапарк", Price = "500 000 QZT" };
            Cards[24] = new Cards { Name = "Кинотеатр", Price = "600 000 QZT" };
            Cards[25] = new Cards { Name = "Ювелирка", Price = "700 000 QZT" };
            Cards[26] = new Cards { Name = "Причал", Price = "900 000 QZT" };
            Cards[27] = new Cards { Name = "ЖД Вокзал", Price = "1 100 000 QZT" };
            Cards[28] = new Cards { Name = "Аэропорт", Price = "1 300 000 QZT" };
            Cards[29] = new Cards { Name = "Банк", Price = "1 500 000 QZT" };
            Cards[30] = new Cards { Name = "xBet", Price = "2 900 000 QZT" };
            Cards[31] = new Cards { Name = "SpaceX", Price = "4 000 000 QZT" };*/

            

        }

        async void bw_DoWork(object sender, DoWorkEventArgs e)
        {

            
            var worker = sender as BackgroundWorker;
            var key = e.Argument as String; // получаем ключ из аргументов
            try
            {
                

                var Bot = new Telegram.Bot.TelegramBotClient(key); // инициализируем API

                try
                {
                    
                    await Bot.SetWebhookAsync(""); // !!!!!!!!!!!!!!!!!!!!!!ЦИКЛ ПЕРЕЗАПУСКА

                }
                catch
                {
                    await Bot.SetWebhookAsync("");
                }


                // Inlin'ы
                Bot.OnInlineQuery += async (object si, Telegram.Bot.Args.InlineQueryEventArgs ei) =>
                {

                    var query = ei.InlineQuery.Query;


                };

                Bot.OnCallbackQuery += async (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
                {
                    var message = ev.CallbackQuery.Message;
                    if (ev.CallbackQuery.Data == "CallDaily")
                    {
                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                        await Bot.SendTextMessageAsync(message.Chat.Id, "CallDaily", ParseMode.Html, false, false, 0, null);
                    }
                    
                    if (ev.CallbackQuery.Data == "PutDaily")
                    {
                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                        await Bot.SendTextMessageAsync(message.Chat.Id, "PutDaily", ParseMode.Html, false, false, 0, null);
                    }
                     
                    if (ev.CallbackQuery.Data == "Call6Hr")
                    {
                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                        await Bot.SendTextMessageAsync(message.Chat.Id, "Call6Hr", ParseMode.Html, false, false, 0, null);
                    }
                     
                    if (ev.CallbackQuery.Data == "Put6Hr")
                    {
                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                        await Bot.SendTextMessageAsync(message.Chat.Id, "Put6Hr", ParseMode.Html, false, false, 0, null);
                    }
                };

                Bot.OnUpdate += async (object su, Telegram.Bot.Args.UpdateEventArgs evu) =>
                {



                    try
                    {
                        var update = evu.Update;
                        var message = update.Message;
                        if (message == null) return;



                        if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                        {
                            for (; ; )
                        {
                                TronScan.tronscan();
                                for (int i = 0; i < TronScan.message.Count; i++)
                                {

                                    await Bot.SendTextMessageAsync(message.Chat.Id = 460657014, TronScan.message[i], ParseMode.Html, false, false, 0, null);
                                 
                                }
                                Thread.Sleep(60000);
                            }

                      
                          


                           




                        
                            

                        if (message.Text == "/price_option@TestTestTestTestTest111_bot")
                            {
                                try
                                {

                                    var inlineMainKeyboard = new InlineKeyboardMarkup(new[]
                    {
                        new []
                        {
                           new InlineKeyboardButton  { Text = "Call Daily Options ", CallbackData = "CallDaily"  },

                          new   InlineKeyboardButton { Text = "Put Daily Options ", CallbackData = "PutDaily" } },
                         new []
                        {
                           new InlineKeyboardButton  { Text = "Call 6Hr Daily Options ", CallbackData = "Call6Hr"  },

                          new   InlineKeyboardButton { Text = "Put 6Hr Daily Options ", CallbackData = "Put6Hr" } }
                                    });


                                    string Current_price, Exercise_Price, Change, Potential, Contracts;
                                    await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);

                                    await Bot.SendTextMessageAsync(message.Chat.Id,"<b>Цена на опционы!</b>", ParseMode.Html, false, false, 0, inlineMainKeyboard);



                                }
                                catch
                                {

                                }

                            }

                        }



                        if (message.Type == MessageType.ChatMemberLeft)
                        {
                            try
                            {
                                await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            }
                            catch
                            {

                            }
                            return;

                        }
                        if (Data.HI==1 & message.Type == MessageType.ChatMembersAdded)
                        {
                            try
                            {
                                await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            }
                            catch
                            {

                            }
                            return;

                        }
                        if (message.Text == "/stop_hello_func@TestTestTestTestTest111_bot")
                        {
                            try
                            {
                                Data.HI = 1;
                            }


                            catch
                            {

                            }
                        }
                        if (message.Text == "/start_hello_func@TestTestTestTestTest111_bot")
                        {
                            try
                            {
                                Data.HI = 0;
                            }


                            catch
                            {

                            }
                        }

                        if (Data.HI == 0 & message.Type == MessageType.ChatMembersAdded)
                        {
                            try
                            {
                                var inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                                {

                                      new  [] { new InlineKeyboardButton { Text = "Скачать мобильное приложение!", CallbackData = "demo", Url = "https://medium.com/@abcc.com/our-mobile-app-is-ready-41fdd6663869 " } }

                                });
                                if (Hi.one == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string one = update.Message.From.Username;
                                        Hi.one = "@" + one;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string one = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.one = one;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }

                                if (Hi.two == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string two = update.Message.From.Username;
                                        Hi.two = "@" + two;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string two = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.two = two;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.three == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string three = update.Message.From.Username;
                                        Hi.three = "@" + three;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string three = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.three = three;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.four == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string four = update.Message.From.Username;
                                        Hi.four = "@" + four;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string four = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.four = four;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.five == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string five = update.Message.From.Username;
                                        Hi.five = "@" + five;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string five = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.five = five;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.six == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string six = update.Message.From.Username;
                                        Hi.six = "@" + six;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string six = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.six = six;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.seven == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string seven = update.Message.From.Username;
                                        Hi.seven = "@" + seven;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string seven = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.seven = seven;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.eight == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string eight = update.Message.From.Username;
                                        Hi.eight = "@" + eight;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string eight = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.eight = eight;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.nine == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string nine = update.Message.From.Username;
                                        Hi.nine = "@" + nine;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string nine = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.nine = nine;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.ten == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string ten = update.Message.From.Username;
                                        Hi.ten = "@" + ten;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string ten = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.ten = ten;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.H11 == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string H11 = update.Message.From.Username;
                                        Hi.H11 = "@" + H11;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string H11 = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.H11 = H11;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.H12 == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string H12 = update.Message.From.Username;
                                        Hi.H12 = "@" + H12;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string H12 = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.H12 = H12;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.H13 == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string H13 = update.Message.From.Username;
                                        Hi.H13 = "@" + H13;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string H13 = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.H13 = H13;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.H14 == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string H14 = update.Message.From.Username;
                                        Hi.H14 = "@" + H14;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string H14 = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.H14 = H14;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.H15 == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string H15 = update.Message.From.Username;
                                        Hi.H15 = "@" + H15;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string H15 = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.H15 = H15;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.H16 == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string H16 = update.Message.From.Username;
                                        Hi.H16 = "@" + H16;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string H16 = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.H16 = H16;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.H17 == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string H17 = update.Message.From.Username;
                                        Hi.H17 = "@" + H17;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string H17 = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.H17 = H17;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.H17 == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string H17 = update.Message.From.Username;
                                        Hi.H17 = "@" + H17;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string H17 = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.H17 = H17;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.H18 == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string H18 = update.Message.From.Username;
                                        Hi.H18 = "@" + H18;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string H18 = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.H18 = H18;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.H19 == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string H19 = update.Message.From.Username;
                                        Hi.H19 = "@" + H19;

                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                    else
                                    {
                                        string H19 = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.H19 = H19;

                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        return;
                                    }
                                }
                                if (Hi.H20 == null)
                                {
                                    if (update.Message.From.Username != null)
                                    {
                                        string H20 = update.Message.From.Username;
                                        Hi.H20 = "@" + H20;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        await Bot.SendTextMessageAsync(message.Chat.Id, $"{Hi.one + ", " + Hi.two + ", " + Hi.three + ", " + Hi.four + ", " + Hi.five + ", " + Hi.six + ", " + Hi.seven + ", " + Hi.eight + ", " + Hi.nine + ", " + Hi.ten + ", " + Hi.H11 + ", " + Hi.H12 + ", " + Hi.H13 + ", " + Hi.H14 + ", " + Hi.H15 + ", " + Hi.H16 + ", " + Hi.H17 + ", " + Hi.H18 + ", " + Hi.H19 + ", " + Hi.H20  } \n<b>Добро пожаловать в наш уютный чат ABCC СНГ \nМы всегда рады тебе в нашем чате!😉\n" + "Воспользуйся нашим ботом</b> @TestTestTestTestTest111_bot <b>с множеством полезных команд!\n</b><b>Последний блок</b> /last_block@TestTestTestTestTest111_bot \n<b>Цена АТ</b> /at_usdt@TestTestTestTestTest111_bot \n<b>Цена BTC</b> /btc_usdt@TestTestTestTestTest111_bot \n<b>Цена ETH</b> /eth_usdt@TestTestTestTestTest111_bot \n<b>А также множество других команд! Нажми / и действуй!</b> \n<b>Обучающий ролик!</b>" + "\n" + @" <a href=""https://www.youtube.com/watch?v=shzrEeLKZWU"">📈📈📈</a>", ParseMode.Html, false, false, 0, inlineKeyboardMarkup);

                                        //https://www.youtube.com/watch?v=shzrEeLKZWU&t=1s
                                        Hi.one = null;
                                        Hi.two = null;
                                        Hi.three = null;
                                        Hi.four = null;
                                        Hi.five = null;
                                        Hi.six = null;
                                        Hi.seven = null;
                                        Hi.eight = null;
                                        Hi.nine = null;
                                        Hi.ten = null;
                                        Hi.H11 = null;
                                        Hi.H12 = null;
                                        Hi.H13 = null;
                                        Hi.H14 = null;
                                        Hi.H15 = null;
                                        Hi.H16 = null;
                                        Hi.H17 = null;
                                        Hi.H18 = null;
                                        Hi.H19 = null;
                                        Hi.H20 = null;

                                        return;
                                    }
                                    else
                                    {
                                        string H20 = update.Message.From.FirstName + " " + update.Message.From.LastName;
                                        Hi.H20 = H20;
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        await Bot.SendTextMessageAsync(message.Chat.Id, $"{Hi.one + ", " + Hi.two + ", " + Hi.three + ", " + Hi.four + ", " + Hi.five + ", " + Hi.six + ", " + Hi.seven + ", " + Hi.eight + ", " + Hi.nine + ", " + Hi.ten + ", " + Hi.H11 + ", " + Hi.H12 + ", " + Hi.H13 + ", " + Hi.H14 + ", " + Hi.H15 + ", " + Hi.H16 + ", " + Hi.H17 + ", " + Hi.H18 + ", " + Hi.H19 + ", " + Hi.H20  } \n<b>Добро пожаловать в наш уютный чат ABCC СНГ \nМы всегда рады тебе в нашем чате!😉\n" + "Воспользуйся нашим ботом</b> @TestTestTestTestTest111_bot <b>с множеством полезных команд!\n</b><b>Последний блок</b> /last_block@TestTestTestTestTest111_bot \n<b>Цена АТ</b> /at_usdt@TestTestTestTestTest111_bot \n<b>Цена BTC</b> /btc_usdt@TestTestTestTestTest111_bot \n<b>Цена ETH</b> /eth_usdt@TestTestTestTestTest111_bot \n<b>А также множество других команд! Нажми / и действуй!</b> \n<b>Обучающий ролик!</b>" + "\n" + @" <a href=""https://www.youtube.com/watch?v=shzrEeLKZWU"">!</a>", ParseMode.Html, false, false, 0, inlineKeyboardMarkup);

                                        Hi.one = null;
                                        Hi.two = null;
                                        Hi.three = null;
                                        Hi.four = null;
                                        Hi.five = null;
                                        Hi.six = null;
                                        Hi.seven = null;
                                        Hi.eight = null;
                                        Hi.nine = null;
                                        Hi.ten = null;
                                        Hi.H11 = null;
                                        Hi.H12 = null;
                                        Hi.H13 = null;
                                        Hi.H14 = null;
                                        Hi.H15 = null;
                                        Hi.H16 = null;
                                        Hi.H17 = null;
                                        Hi.H18 = null;
                                        Hi.H19 = null;
                                        Hi.H20 = null;

                                        return;
                                    }
                                }
                                return;
                            }
                            catch
                            {

                            }

                        }

                        var entities = message.Entities.Where(t => t.Type == MessageEntityType.Url
                                           || t.Type == MessageEntityType.Mention);
                        foreach (var entity in entities)
                        {
                            if (entity.Type == MessageEntityType.Url)
                            {
                                try
                                {
                                    //40103694 - @off_fov
                                    //571522545 -  @ProAggressive                                    
                                    //320968789 - @timcheg1
                                    //273228404 - @hydranik
                                    //435567580 - Никита                           
                                    //352345393 - @i_am_zaytsev
                                    //430153320 - @KingOfMlnD
                                    //579784 - @kamiyar
                                    //536915847 - @m1Bean
                                    //460657014 - @DenisSenatorov

                                    if (message.From.Username == @"off_fov"|| message.From.Username == @"LindaMao" || message.From.Username == @"XiniW" || message.From.Username == @"ProAggressive" || message.From.Username == @"timcheg1" || message.From.Username == @"hydranik" || message.From.Username == @"i_am_zaytsev" || message.From.Username == @"KingOfMlnD" || message.From.Username == @"kamiyar" || message.From.Username == @"m1Bean" || message.From.Username == @"DenisSenatorov" || message.From.Id == 435567580)
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                        if (update.Message.From.Username != null)
                                        {
                                            await Bot.SendTextMessageAsync(message.Chat.Id, "@" + message.From.Username + ", Ссылки запрещены!");
                                            return;
                                        }
                                        else
                                        {
                                            await Bot.SendTextMessageAsync(message.Chat.Id, message.From.FirstName + ", Ссылки запрещены!");
                                            return;
                                        }
                                    }
                                }
                                catch
                                {

                                }
                                return;

                            }
                        }
                    }
                    catch
                    {

                    }
                };

                Bot.StartReceiving();

                // запускаем прием обновлений

            }

            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.Message); // если ключ не подошел - пишем об этом в консоль отладки
            }

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            //var text = @"737461958:AAFiybxVZYkkAC9gcly-aENm-AaLViizLX8"; // получаем содержимое текстового поля txtKey в переменную text

            // 673649420:AAG2O4s9qDmBVpmFtt4wG12dZ3nV-nBm3JA    //test test test test test 

        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }


        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void txtKey_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void BtnRun_Click_1(object sender, EventArgs e)
        {
            var text = @txtKey.Text; // получаем содержимое текстового поля txtKey в переменную text
            if (text != "" && this.bw.IsBusy != true)
            {
                this.bw.RunWorkerAsync(text); // передаем эту переменную в виде аргумента методу bw_DoWork
                BtnRun.Text = "Бот запущен...";
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}

