using System.Web.Mvc;
using WebApplication1.Classes;
using WebApplication1.Models;
using X.PagedList;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        readonly IDb dbRepository;
        readonly ISendEmail sendEmail;
        public HomeController(IDb repository, ISendEmail mailRepo)
        {
            this.dbRepository = repository;
            this.sendEmail = mailRepo;
        }
        public ActionResult Index()
        {
            var fresh3Posts = dbRepository.QueryFor3FreshPosts();
            return View(fresh3Posts);
        }

        public ActionResult AllPosts(int? page)
        {
            var allPostsFromDb=dbRepository.AllPostsInDb().ToPagedList(page ?? 1, 5);
            return View(allPostsFromDb);
        }

        public ActionResult Contact()
        {
            EmailData emData = new EmailData();
            return View(emData);
        }
        [HttpPost]
        public ActionResult Contact(EmailData eM)
        {
            var message = sendEmail.SendEmail(eM);
            return Json(message);
        }
        public ActionResult Post(int? id)
        {
            var postWithID = dbRepository.QueryGetPostByID(id ?? 1);
            return View(postWithID);
        }

    }
}