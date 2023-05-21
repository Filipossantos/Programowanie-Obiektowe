using System.Web.Mvc;
using Stock_Information_System.App_Data.Users;

public class LoggingController : Controller
{
    private db_connection dbConnection = new db_connection();

    [HttpGet]
    public ActionResult Contact()
    {
        return View("~/Views/Home/Contact.cshtml"); 
    }

    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        if (dbConnection.AuthenticateUser(username, password))
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid username or password";
            return View("~/Views/Home/Contact.cshtml");
        }
    }
}