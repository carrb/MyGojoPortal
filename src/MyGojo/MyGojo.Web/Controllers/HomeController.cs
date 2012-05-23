using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGojo.Web.Controllers
{
    public class HomeController : Controller
    {


        // See:  http://www.ihatetermsandconditions.com/
        // 
        // for generating Terms and Conditions!




        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Home/

        public ActionResult Terms()
        {
            return View();
        }

    }
}
