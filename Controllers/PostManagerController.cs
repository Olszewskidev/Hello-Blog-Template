using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //This is admin panell, all have actions have to be authorize by correct Login, Password and Token.
    [Authorize]
    public class PostManagerController : Controller
    {
        public ActionResult AddNewPostToHB()
        {
            Posts newPost = new Posts();
            return View(newPost);
        }
        [HttpPost]
        public ActionResult AddNewPostToHB(Posts p, bool Today, bool LinkPic)
        {
            if(!LinkPic)
                checkPic(p);

            if (Today)
                p.DateTime = DateTime.Now;
          
            using(HelloBlogEntities db=new HelloBlogEntities())
            {
                db.Posts.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("AddNewPostToHB");
        }
        [HttpGet]
        public ActionResult EditPost(int? id)
        {
            Posts postToEdit = new Posts();
            if (id != null)
            {
                HelloBlogEntities db = new HelloBlogEntities();
                postToEdit = db.Posts.Where(x => x.ID == id).SingleOrDefault();
                if (postToEdit == null)
                    ViewBag.MessageToShow = "Post o podanym ID nie istnieje w bazie danych";
            }
            return View(postToEdit);
        }
        [HttpPost]
        public ActionResult EditPost(Posts p, bool LinkPicEdit)
        {
            using (HelloBlogEntities db = new HelloBlogEntities())
            {
                var item = db.Posts.Where(x => x.ID == p.ID).FirstOrDefault();
                if(!LinkPicEdit)
                    checkPic(p);
                item.PicImg = p.PicImg ?? item.PicImg;
                item.Title = p.Title ?? item.Title;
                item.Body = p.Body ?? item.Body;
                db.SaveChanges();
            }
            return RedirectToAction("EditPost");
        }
        private void checkPic(Posts p)
        {
            if(p.ImgPost != null)
            {
                string FileName = Path.GetFileNameWithoutExtension(p.ImgPost.FileName);
                string Extension = Path.GetExtension(p.ImgPost.FileName);
                FileName = FileName + DateTime.Now.ToString("yymmssfff") + Extension;
                p.PicImg = "~/Images/" + FileName;
                p.ImgPost.SaveAs(Path.Combine(Server.MapPath("~/Images/"), FileName));
            }
        }
    }
}