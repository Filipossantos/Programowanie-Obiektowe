using System.Web.Mvc;

namespace Stock_Information_System.App_Data.Stock
{
    public class StocksController : Controller
    {
        [HttpGet]
        public ActionResult Update()
        {
            // Instantiate the StockMarket class
            Stocks stocks = new Stocks();
        
            // Execute the UpdateStockData() function
            stocks.UpdateStockData();
        
            // Optionally, you can return a response to indicate the success of the operation
            return Content("Stock data updated successfully.");
        }
    }
}