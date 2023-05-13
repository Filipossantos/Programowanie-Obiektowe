using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace Stock_Information_System.App_Data.Stock
{
    public class StockMarket
    {
        public string LastChange;

        public void GetExchangeRate()
        {
            string queryUrl = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=BTC&to_currency=USD&apikey=LS940H9ZIP5YTPM6";
            Uri queryUri = new Uri(queryUrl);

            using (WebClient client = new WebClient())
            {
                string jsonData = client.DownloadString(queryUri);
                Dictionary<string, dynamic> data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonData);
                this.LastChange = data["Realtime Currency Exchange Rate"]["8. Bid Price"];
            }
        }
    }
}