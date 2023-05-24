using System.Web.Mvc;
using Stock_Information_System.App_Data.Stock;

namespace Stock_Information_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            StockMarket stockMarketBtc = new StockMarket();
            string updatedLastChangeBtc = stockMarketBtc.GetExchangeRateBtc();
            ViewBag.StockDataBtc = updatedLastChangeBtc;

            StockMarket stockMarketIbm = new StockMarket();
            string updatedLastChangeIbm = stockMarketIbm.GetExchangeRateIbm();
            ViewBag.StockDataIbm = updatedLastChangeIbm;
            
            StockMarket stockMarketAapl = new StockMarket();
            string updatedLastChangeAapl = stockMarketAapl.GetExchangeRateAapl();
            ViewBag.StockDataAapl = updatedLastChangeAapl;
            
            StockMarket stockMarketTsla = new StockMarket();
            string updatedLastChangeTsla = stockMarketTsla.GetExchangeRateTsla();
            ViewBag.StockDataTsla = updatedLastChangeTsla;
            
            StockMarket stockMarketMeta = new StockMarket();
            string updatedLastChangeMeta = stockMarketMeta.GetExchangeRateMeta();
            ViewBag.StockDataMeta = updatedLastChangeMeta;
            
            StockMarket stockMarketMsft = new StockMarket();
            string updatedLastChangeMsft = stockMarketMsft.GetExchangeRateMsft();
            ViewBag.StockDataMsft = updatedLastChangeMsft;
            
            StockMarket stockMarketAmzn = new StockMarket();
            string updatedLastChangeAmzn = stockMarketAmzn.GetExchangeRateAmzn();
            ViewBag.StockDataAmzn = updatedLastChangeAmzn;

            StockMarket stockMarketGoogl = new StockMarket();
            string updatedLastChangeGoogl = stockMarketGoogl.GetExchangeRateGoogl();
            ViewBag.StockDataGoogl = updatedLastChangeGoogl;
            
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