using System.Web.Mvc;
using Stock_Information_System.App_Data.Stock;

namespace Stock_Information_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            StockMarket stockMarket = new StockMarket();

            /*string updatedLastChangeBtc = stockMarket.UpdateStockData();*/
            string updatedLastChangeBtc = stockMarket.GetExchangeRateFromDatabase("BTC");
            ViewBag.StockDataBtc = updatedLastChangeBtc;

            string updatedLastChangeAapl = stockMarket.GetExchangeRateFromDatabase("AAPL");
            ViewBag.StockDataAapl = updatedLastChangeAapl;

            string updatedLastChangeTsla = stockMarket.GetExchangeRateFromDatabase("TSLA");
            ViewBag.StockDataTsla = updatedLastChangeTsla;

            string updatedLastChangeMeta = stockMarket.GetExchangeRateFromDatabase("META");
            ViewBag.StockDataMeta = updatedLastChangeMeta;

            string updatedLastChangeAmzn = stockMarket.GetExchangeRateFromDatabase("AMZN");
            ViewBag.StockDataAmzn = updatedLastChangeAmzn;

            string updatedLastUpdateTime = stockMarket.GetLastUpdateTime();
            ViewBag.StockDataTime = updatedLastUpdateTime;
            return View();
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
