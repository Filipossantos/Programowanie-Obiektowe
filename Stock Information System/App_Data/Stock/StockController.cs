using System.Web.Mvc;

namespace Stock_Information_System.App_Data.Stock
{
    public class StockController : Controller
    {
        [HttpGet]
        public ActionResult Update()
        {
            // Instantiate the StockMarket class
            StockMarket stockMarket = new StockMarket();
        
            // Execute the UpdateStockData() function
            stockMarket.UpdateStockData();
        
            // Optionally, you can return a response to indicate the success of the operation
            return Content("Stock data updated successfully.");
        }
    }
}