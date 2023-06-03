using System.Web.Mvc;
using Stock_Information_System.App_Data.Stock;

namespace Stock_Information_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            Stocks stocks = new Stocks();

            /*string updatedLastChangeBtc = stockMarket.UpdateStockData();*/
            string updatedLastChangeBtc = stocks.GetExchangeRateFromDatabase("BTC");
            ViewBag.StockDataBtc = updatedLastChangeBtc;

            string updatedLastChangeAapl = stocks.GetExchangeRateFromDatabase("AAPL");
            ViewBag.StockDataAapl = updatedLastChangeAapl;

            string updatedLastChangeTsla = stocks.GetExchangeRateFromDatabase("TSLA");
            ViewBag.StockDataTsla = updatedLastChangeTsla;

            string updatedLastChangeMeta = stocks.GetExchangeRateFromDatabase("META");
            ViewBag.StockDataMeta = updatedLastChangeMeta;

            string updatedLastChangeAmzn = stocks.GetExchangeRateFromDatabase("AMZN");
            ViewBag.StockDataAmzn = updatedLastChangeAmzn;

            string updatedLastUpdateTime = stocks.GetLastUpdateTime();
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
