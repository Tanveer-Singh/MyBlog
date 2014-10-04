using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class ArchiveController : Controller
    {
        //
        // GET: /Archive/

        public string Entry(string entryDate) 
        {
            return "You requested the entry from " + entryDate.ToString(); ;
        }
    }
}
