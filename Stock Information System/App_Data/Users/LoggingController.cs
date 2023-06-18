
using System.Web.Mvc;

using Npgsql;


public class LoggingController : Controller
{
    private string connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";

    [HttpGet]
    public ActionResult Contact()
    {
        if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
        {
            return View("~/Views/Home/Contact.cshtml");
        }
        
        return RedirectToAction("Login");
    }

    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        bool isAdmin;
        if (AuthenticateUser(username, password, out isAdmin))
        {
            if (isAdmin)
            {
                ViewBag.IsAuthenticated = true;
                return View("~/Views/Home/About.cshtml");
            }
            else
            {
                ViewBag.IsAuthenticated = false;
            }
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid username or password";
            return View("~/Views/Home/Contact.cshtml");
        }

        return RedirectToAction("Index", "Home");
    }

    private bool AuthenticateUser(string login, string password, out bool isAdmin)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();

            using (var cmd = new NpgsqlCommand("SELECT Is_admin FROM user_data WHERE login = @login AND password = @password", conn))
            {
                cmd.Parameters.AddWithValue("login", login);
                cmd.Parameters.AddWithValue("password", password);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                       
                        isAdmin = reader.GetBoolean(0);
                        return true;
                    }
                    
                }
            }
        }

        isAdmin = false;
        return false;
    }
}
