using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WebApplication1.Models;

namespace WebApplication1.Classes
{
    public class DbRepo: IDb
    {
        HelloBlogEntities db = new HelloBlogEntities();

        public IQueryable<Posts> QueryFor3FreshPosts()
        {
            var data = db.Posts.OrderByDescending(x => x.DateTime).Take(3);
            foreach (var item in data)
            {
                item.Body = item.Body.Substring(0, 372);
                item.Body= Regex.Replace(item.Body, "<.*?>", String.Empty);
            }
            return data;
        }
        public IEnumerable<Posts> AllPostsInDb()
        {
            var data= db.Posts.OrderByDescending(x => x.DateTime);
            foreach(var item in data)
            {
                item.Body = item.Body.Substring(0, 372);
                item.Body = Regex.Replace(item.Body, "<.*?>", String.Empty);
            }
            return data;
        }
        public IQueryable<Posts> QueryGetPostByID(int id)
        {
            return db.Posts.Where(x => x.ID==id);
        }
    }
}