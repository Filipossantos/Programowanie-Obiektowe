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

        public string GetExchangeRateBtc()
        {
            string btc =
                "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=BTC&to_currency=USD&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponseBtc = client.DownloadString(btc);
                JObject responseJson = JObject.Parse(apiResponseBtc);
                double lastchangeBtc = (double)responseJson["Realtime Currency Exchange Rate"]["5. Exchange Rate"];

                string connectionString =
                    "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE data SET lastchange = @exchangeRateBtc WHERE symbol = 'BTC'";
                    using (var command = new NpgsqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@exchangeRateBtc", lastchangeBtc);
                        command.ExecuteNonQuery();
                    }

                    string selectQuery = "SELECT lastchange FROM data WHERE symbol = 'BTC'";
                    using (var command = new NpgsqlCommand(selectQuery, connection))
                    {
                        string updatedLastChangeBtc = command.ExecuteScalar().ToString();
                        return updatedLastChangeBtc;
                    }

                }
            }
        }
        public string GetExchangeRateIbm()
        {
            string ibm =
                "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponseIbm = client.DownloadString(ibm);
                JObject responseJson = JObject.Parse(apiResponseIbm);
                string lastRefreshedIbm = (string)responseJson["Meta Data"]["3. Last Refreshed"];
                double lastchangeIbm = (double)responseJson["Time Series (5min)"][lastRefreshedIbm]["4. close"];
                string updatedLastChangeIbm = lastchangeIbm.ToString();
                return updatedLastChangeIbm;

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
        public string GetExchangeRateMsft()
        {
            string msft =
                "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=MSFT&interval=5min&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponseMsft = client.DownloadString(msft);
                JObject responseJson = JObject.Parse(apiResponseMsft);
                string lastRefreshedMsft = (string)responseJson["Meta Data"]["3. Last Refreshed"];
                double lastchangeMsft = (double)responseJson["Time Series (5min)"][lastRefreshedMsft]["4. close"];
                string updatedLastChangeMsft = lastchangeMsft.ToString();
                return updatedLastChangeMsft;

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
        public string GetExchangeRateGoogl()
        {
            string googl =
                "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=GOGGL&interval=5min&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponseGoogl = client.DownloadString(googl);
                JObject responseJson = JObject.Parse(apiResponseGoogl);
                string lastRefreshedGoogl = (string)responseJson["Meta Data"]["3. Last Refreshed"];
                double lastchangeGoogl = (double)responseJson["Time Series (5min)"][lastRefreshedGoogl]["4. close"];
                string updatedLastChangeGoogl = lastchangeGoogl.ToString();
                return updatedLastChangeGoogl;

            }
        }
        
    }
}