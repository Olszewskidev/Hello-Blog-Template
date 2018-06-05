using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Classes
{
    public interface IDb
    {
         IQueryable<Posts> QueryFor3FreshPosts();
         IEnumerable<Posts> AllPostsInDb();
         IQueryable<Posts> QueryGetPostByID(int id);
    }
    public interface ISendEmail
    {
        string SendEmail(EmailData eData);
    }
    public interface ILogin
    {
        bool IsCorrect(UserInfo UsI, int numOfToken);
        int RandomToken();
    }
}
