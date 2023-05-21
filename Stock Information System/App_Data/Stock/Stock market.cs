using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Npgsql;

namespace Stock_Information_System.App_Data.Stock
{
    public class StockMarket
    {
        public string LastChange;

        public string GetExchangeRate()
        {
            string apiUrl =
                "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=BTC&to_currency=USD&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponse = client.DownloadString(apiUrl);
                JObject responseJson = JObject.Parse(apiResponse);
                double lastchange = (double)responseJson["Realtime Currency Exchange Rate"]["5. Exchange Rate"];
                string connectionString =
                    "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE data SET lastchange = @exchangeRate WHERE symbol = 'BTC'";
                    using (var command = new NpgsqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@exchangeRate", lastchange);
                        command.ExecuteNonQuery();
                    }

                    string selectQuery = "SELECT lastchange FROM data WHERE symbol = 'BTC'";
                    using (var command = new NpgsqlCommand(selectQuery, connection))
                    {
                        string updatedLastChange = command.ExecuteScalar().ToString();
                        return updatedLastChange;
                    }
                    
                }
            }
        }


    }
}