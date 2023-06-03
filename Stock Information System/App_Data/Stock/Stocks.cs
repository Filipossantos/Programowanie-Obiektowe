using System;
using Npgsql;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Stock_Information_System.App_Data.Stock
{
    public class Stocks
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
            string aapl = GetExchangeRateAapl();
            string tsla = GetExchangeRateTsla();
            string meta = GetExchangeRateMeta();
            string btc = GetExchangeRateBtc();
            string amzn = GetExchangeRateAmzn();
            UpdateStockValueAndTime("AAPL", double.Parse(aapl));
            UpdateStockValueAndTime("TSLA", double.Parse(tsla));
            UpdateStockValueAndTime("META", double.Parse(meta));
            UpdateStockValueAndTime("BTC", double.Parse(btc));
            UpdateStockValueAndTime("AMZN", double.Parse(amzn));
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

        public string GetExchangeRateBtc()
        {
            string btc =
                "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=BTC&to_currency=USD&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponseBtc = client.DownloadString(btc);
                JObject responseJson = JObject.Parse(apiResponseBtc);
                double lastchangeBtc = (double)responseJson["Realtime Currency Exchange Rate"]["5. Exchange Rate"];
                string updatedLastChangeBtc = lastchangeBtc.ToString();
                return updatedLastChangeBtc;
            }
        }

        public string GetExchangeRateAapl()
        {
            string aapl =
                "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=AAPL&interval=5min&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponseAapl = client.DownloadString(aapl);
                JObject responseJson = JObject.Parse(apiResponseAapl);
                string lastRefreshedAapl = (string)responseJson["Meta Data"]["3. Last Refreshed"];
                double lastchangeAapl = (double)responseJson["Time Series (5min)"][lastRefreshedAapl]["4. close"];
                string updatedLastChangeAapl = lastchangeAapl.ToString();
                return updatedLastChangeAapl;
            }
        }

        public string GetExchangeRateTsla()
        {
            string tsla =
                "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=TSLA&interval=5min&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponseTsla = client.DownloadString(tsla);
                JObject responseJson = JObject.Parse(apiResponseTsla);
                string lastRefreshedTsla = (string)responseJson["Meta Data"]["3. Last Refreshed"];
                double lastchangeTsla = (double)responseJson["Time Series (5min)"][lastRefreshedTsla]["4. close"];
                string updatedLastChangeTsla = lastchangeTsla.ToString();
                return updatedLastChangeTsla;
            }
        }

        public string GetExchangeRateMeta()
        {
            string meta =
                "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=META&interval=5min&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponseMeta = client.DownloadString(meta);
                JObject responseJson = JObject.Parse(apiResponseMeta);
                string lastRefreshedMeta = (string)responseJson["Meta Data"]["3. Last Refreshed"];
                double lastchangeMeta = (double)responseJson["Time Series (5min)"][lastRefreshedMeta]["4. close"];
                string updatedLastChangeMeta = lastchangeMeta.ToString();
                return updatedLastChangeMeta;
            }
        }

        public string GetExchangeRateAmzn()
        {
            string amzn =
                "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=AMZN&interval=5min&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponseAmzn = client.DownloadString(amzn);
                JObject responseJson = JObject.Parse(apiResponseAmzn);
                string lastRefreshedAmzn = (string)responseJson["Meta Data"]["3. Last Refreshed"];
                double lastchangeAmzn = (double)responseJson["Time Series (5min)"][lastRefreshedAmzn]["4. close"];
                string updatedLastChangeAmzn = lastchangeAmzn.ToString();
                return updatedLastChangeAmzn;
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
