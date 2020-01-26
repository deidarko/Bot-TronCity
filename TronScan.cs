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
    class TronScan
    {
       static public List<string> message = new List<string>();
        public static List<string> tronscan()
        {



        



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
            Cards[31] = new Cards { Name = "SpaceX", Price = "4 000 000 QZT" };


            var MinutesBack = 60; // Проверять транзакции за пооследние Х минут
            var TimeEnd = DateTimeOffset.UtcNow.ToUnixTimeSeconds() * 1000; // Текущее время
            var TimeStart = TimeEnd - MinutesBack * 60 * 1000; // Время Х минут назад
            var API_URL = "https://apilist.tronscan.org/api/contracts/transaction?sort=-timestamp&count=true&limit=10000&start=0&start_timestamp=" + TimeStart + "&end_timestamp=" + TimeEnd + "&contract=TPoQ7e2yBV3wbUQoKPf9Lk6S6QtfxLzxR2";

            System.Net.WebClient wc = new System.Net.WebClient();
            String Response = wc.DownloadString(API_URL);
            JObject JsonResponse = JObject.Parse(Response);
            var TransactionsCount = JsonResponse["total"];

            Console.WriteLine("Найдено транзакций: " + TransactionsCount);
            string s = null;
            for (var i = 0; i < Convert.ToInt32(TransactionsCount); i++)
            {
                var Hash = JsonResponse["data"][i]["txHash"];
                var API_URL_2 = "https://apilist.tronscan.org/api/transaction-info?hash=" + Hash;
                var TxURl = "https://tronscan.org/#/transaction/" + Hash;
                var Owner_Address = JsonResponse["data"][i]["ownAddress"];
                double TxTime = Convert.ToDouble(JsonResponse["data"][i]["timestamp"]);


                System.Net.WebClient wc2 = new System.Net.WebClient();
                String Response2 = wc.DownloadString(API_URL_2);
                JObject JsonResponse2 = JObject.Parse(Response2);

                var Method = JsonResponse2["trigger_info"]["method"];
                var Parameter = "";
                var Status = "";

                if (Convert.ToString(Method).Contains("buyBuild")) { Method = "Покупка карточки"; Parameter = Cards[Convert.ToInt32(JsonResponse2["trigger_info"]["parameter"]["build"])].Name + " за " + Cards[Convert.ToInt32(JsonResponse2["trigger_info"]["parameter"]["build"])].Price; Status = Convert.ToString(JsonResponse2["contractRet"]); }
                else if (Convert.ToString(Method).Contains("withdraw")) { Method = "Вывод средств"; Parameter = Convert.ToString(Convert.ToDouble(JsonResponse2["trigger_info"]["parameter"]["value"]) / 100 / 1e06) + " TRX"; Status = Convert.ToString(JsonResponse2["contractRet"]); }
                else if (Convert.ToString(Method).Contains("deposit")) { Method = "Депозит"; Parameter = Convert.ToString(Convert.ToDouble(JsonResponse2["trigger_info"]["call_value"]) / 1e06) + " TRX"; Status = Convert.ToString(JsonResponse2["contractRet"]); }
                else if (Convert.ToString(Method).Contains("sellBuild")) { Method = "Продажа карточки"; Parameter = Cards[Convert.ToInt32(JsonResponse2["trigger_info"]["parameter"]["number"])].Name; Status = Convert.ToString(JsonResponse2["contractRet"]); }
                else if (Convert.ToString(Method).Contains("roulette")) { Method = "Вращение рулетки"; Parameter = "25 000 QZT"; Status = Convert.ToString(JsonResponse2["contractRet"]); }
                else { Parameter = "Не распознано " + TxURl; Status = Convert.ToString(JsonResponse2["contractRet"]); };

                DateTime HumanTime = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(TxTime / 1000);

                Console.WriteLine(HumanTime + " " + Method + " " + Parameter + " Игрок: " + Owner_Address + " Статус: " + Status + " " + TxURl);
                message.Add(HumanTime + " " + Method + " " + Parameter + " Игрок: " + Owner_Address + " Статус: " + Status + " " + TxURl);





               





            }
            return message;
        }
    }
}
