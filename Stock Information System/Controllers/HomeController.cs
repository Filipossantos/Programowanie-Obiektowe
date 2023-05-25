using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Stock_Information_System.App_Data.Stock;

namespace Stock_Information_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string amzn =
                "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=AMZN&interval=5min&apikey=LS940H9ZIP5YTPM6";

            using (WebClient client = new WebClient())
            {
                string apiResponseAmzn = client.DownloadString(amzn);
                JObject responseJson = JObject.Parse(apiResponseAmzn);

                StockMarket stockMarketBtc = new StockMarket();
                string updatedLastChangeBtc = stockMarketBtc.GetExchangeRateBtc();
                ViewBag.StockDataBtc = updatedLastChangeBtc;

                StockMarket stockMarketAapl = new StockMarket();
                string updatedLastChangeAapl = stockMarketAapl.GetExchangeRateAapl();
                ViewBag.StockDataAapl = updatedLastChangeAapl;

                StockMarket stockMarketTsla = new StockMarket();
                string updatedLastChangeTsla = stockMarketTsla.GetExchangeRateTsla();
                ViewBag.StockDataTsla = updatedLastChangeTsla;

                StockMarket stockMarketMeta = new StockMarket();
                string updatedLastChangeMeta = stockMarketMeta.GetExchangeRateMeta();
                ViewBag.StockDataMeta = updatedLastChangeMeta;

                StockMarket stockMarketAmzn = new StockMarket();
                string updatedLastChangeAmzn = stockMarketAmzn.GetExchangeRateAmzn(responseJson);
                ViewBag.StockDataAmzn = updatedLastChangeAmzn;

                string dateAndTime = stockMarketAmzn.GetLastUpdateTime(responseJson);
                ViewBag.StockDataTime = dateAndTime;

                return View();
            }
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}