using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.DataLayer;
using MyBlog.Entities;
using MyBlog.Entities.DataModels;
using MyBlog.Utilites;
using MyBlog.Helpers;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        BlogContext dbBlog = new BlogContext();

        public ActionResult Index()
        {
            //List<
            var postModel = from posts in dbBlog.Posts
                            join users in dbBlog.Users on posts.UserID equals users.UserID
                            into gj
                            from subposts in gj.DefaultIfEmpty()
                            where posts.PostActive == (int)PostStatus.Active
                            select new PostModel
                            {
                                PostID = posts.PostID,
                                UserID = subposts.UserID,
                                UserName = subposts.FirstName,
                                PostHeading = posts.PostHeading,
                                SecondaryText = posts.SecondaryText,
                                Title = posts.Title,
                                PostDescription = posts.PostDescription,
                                PostImage = posts.PostImage,
                                CreatedDate = posts.CreatedDate
                            };

            ViewBag.description = "abc";
            ViewBag.keywords = "abc";
            return View(postModel.ToList().OrderByDescending(x => x.CreatedDate).Take(3));
        }

        public ActionResult View(int id = 0,string name="")
        {

            Posts posts = dbBlog.Posts.Find(id);
            Users user = dbBlog.Users.Find(posts.UserID);
            PostModel postModel = new PostModel()
            {
                PostID = posts.PostID,
                UserID = posts.UserID,
                UserName = user.FirstName,
                Title = posts.Title,
                PostHeading = posts.PostHeading,
                SecondaryText = posts.SecondaryText,
                PostDescription = posts.PostDescription,
                PostImage = posts.PostImage,
                CreatedDate = posts.CreatedDate
            };

            ////if (name != postModel.Title.ToSeoUrl())
            ////{
            ////    return RedirectToActionPermanent("View", new { id = id, name = postModel.Title.ToSeoUrl() });
            ////}
            return View(postModel);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostHeading,SecondaryText,Title,PostDescription")] Posts student)
        {
            if (ModelState.IsValid)
            {
                dbBlog.Posts.Add(student);
                dbBlog.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
