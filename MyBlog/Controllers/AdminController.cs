﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.DataLayer;
using MyBlog.Entities;

namespace MyBlog.Controllers
{
    public class AdminController : Controller
    {
        BlogContext dbBlog = new BlogContext();
        //
        // GET: /Admin/

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "PostHeading,SecondaryText,Title,PostDescription")]Posts collection)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    string FolderName = Server.MapPath("~/MyBlogImages/" + collection.Title);
                    HttpPostedFileBase file = Request.Files[0];
                    byte[] imageSize = new byte[file.ContentLength];
                    file.InputStream.Read(imageSize, 0, (int)file.ContentLength);
                    string image = file.FileName.Split('\\').Last();
                    int size = file.ContentLength;

                    if (size > 0)
                    {
                        if (Directory.Exists(FolderName))
                        {
                            file.SaveAs(Path.Combine(FolderName, image.ToString()));
                        }
                        else
                        {
                            Directory.CreateDirectory(FolderName);
                            file.SaveAs(Path.Combine(FolderName, image.ToString()));
                        }

                        //Save image url to database
                        collection.PostImage = Path.Combine(@"~\MyBlogImages", collection.Title, image.ToString());
                        dbBlog.Posts.Add(collection);
                        dbBlog.SaveChanges();
                    }
                    return RedirectToAction("Index","Home");
 
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }


        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
