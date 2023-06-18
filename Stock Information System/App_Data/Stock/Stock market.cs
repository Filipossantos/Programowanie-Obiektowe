using System;
using Npgsql;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Stock_Information_System.App_Data.Stock
{
    public class StockMarket
    {
        string connectionString =
            "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";

        public string GetExchangeRateFromDatabase(string symbol)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT lastchange FROM data WHERE symbol = @symbol";
                using (var command = new NpgsqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@symbol", symbol);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        double lastChange = Convert.ToDouble(result);
                        return lastChange.ToString();
                    }

                    return string.Empty;
                }
            }
        }

        public string UpdateStockData()
        {
            UpdateStockValueAndTime("AAPL", GetExchangeRate("AAPL"));
            UpdateStockValueAndTime("TSLA", GetExchangeRate("TSLA"));
            UpdateStockValueAndTime("META", GetExchangeRate("META"));
            UpdateStockValueAndTime("BTC", double.Parse(GetExchangeRateBtc()));
            UpdateStockValueAndTime("AMZN", GetExchangeRate("AMZN"));
            return string.Empty;
        }

        private void UpdateStockValueAndTime(string symbol, double stockValue)
        {
            string lastRefreshed = DateTime.Now.ToString();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery =
                    "UPDATE data SET lastchange = @stockValue, time = @lastRefreshed WHERE symbol = @symbol";
                using (var command = new NpgsqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@stockValue", stockValue);
                    command.Parameters.AddWithValue("@lastRefreshed", lastRefreshed);
                    command.Parameters.AddWithValue("@symbol", symbol);
                    command.ExecuteNonQuery();
                }
            }
        }

        private double GetExchangeRate(string symbol)
        {
            string url =
                $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval=5min&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponse = client.DownloadString(url);
                JObject responseJson = JObject.Parse(apiResponse);
                string lastRefreshed = (string)responseJson["Meta Data"]["3. Last Refreshed"];
                double lastChange = (double)responseJson["Time Series (5min)"][lastRefreshed]["4. close"];
                return lastChange;
            }
        }

        public string GetExchangeRateBtc()
        {
            string url =
                "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=BTC&to_currency=USD&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponse = client.DownloadString(url);
                JObject responseJson = JObject.Parse(apiResponse);
                double lastChange = (double)responseJson["Realtime Currency Exchange Rate"]["5. Exchange Rate"];
                return lastChange.ToString();
            }
        }

        public string GetLastUpdateTime()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT time FROM data ORDER BY id ASC LIMIT 1";
                using (var command = new NpgsqlCommand(selectQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        string lastUpdateTime = result.ToString();
                        return lastUpdateTime;
                    }

                    return string.Empty;
                }
            }
        }
    }
}
