using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HN.UI.Controllers
{
    public class ProjectController : Controller
    {
        /// <summary>
        /// 创建项目
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult projectDialog()
        {
            return View();
        }
    }
}
