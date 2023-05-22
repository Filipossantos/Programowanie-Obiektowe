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
        bool isAdmin;
        if (dbConnection.AuthenticateUser(username, password, out isAdmin))
        {
            if (isAdmin)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                
            }
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid username or password";
            return View("~/Views/Home/Contact.cshtml");
        }
        return RedirectToAction("Index", "Home");
    }
}