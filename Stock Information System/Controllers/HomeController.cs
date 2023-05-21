using System.Web.Mvc;
using Stock_Information_System.App_Data.Stock;

namespace Stock_Information_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            StockMarket stockMarket = new StockMarket();
            string updatedLastChange = stockMarket.GetExchangeRate();
            ViewBag.StockData = updatedLastChange;

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