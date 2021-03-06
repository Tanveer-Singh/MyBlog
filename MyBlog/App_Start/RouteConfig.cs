﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Blog", // Route name 
                url: "{controller}/{entryDate}", // URL with parameters 
                defaults: new { controller = "Archive", action = "Entry" } // Parameter defaults 
                             );


            //routes.MapRoute(
            //        name: "BlogPost",
            //        url: "blog/posts/{postId}",
            //            defaults: new
            //        {
            //            controller = "Posts",
            //            action = "GetPost",
            //        },
            //        new { postId = @"\d+" }
            //    );
        }
    }
}