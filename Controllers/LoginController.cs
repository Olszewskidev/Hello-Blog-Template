using System;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        readonly ILogin loginInterF;
        public LoginController(ILogin IL)
        {
            this.loginInterF=IL;
        }
        public ActionResult Login()
        {
            ViewBag.RanNum = loginInterF.RandomToken();
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserInfo UsI, string ReturnUrl)
        {
            int numToken = Convert.ToInt32(TempData["TokenNumb"]);
            if (loginInterF.IsCorrect(UsI, numToken))
            {
                FormsAuthentication.SetAuthCookie(UsI.Name, false);
                return Redirect(ReturnUrl);
            }
            else
                return View();
        }
    }
}