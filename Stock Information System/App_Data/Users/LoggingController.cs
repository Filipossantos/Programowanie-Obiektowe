using System.Web.Mvc;
using Stock_Information_System.App_Data.Users;

public class LoggingController : Controller
{
  

    [HttpGet]
    public ActionResult Home()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        if (AuthenticateUser(username, password))
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid username or password";
            return View("Contact"); // Change the view name to "Contact"
        }
    }

    private bool AuthenticateUser(string username, string password)
    {
        User user = GetUserFromDatabase(username);
        if (user != null && user.Password == password)
        {
            return true;
        }
        return false;
    }

    private User GetUserFromDatabase(string username)
    {
        var user = db.Users.FirstOrDefault(u => u.Username == username);
        return user;
    }
}

