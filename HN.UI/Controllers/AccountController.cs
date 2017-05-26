using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HN.UI.Controllers
{
    [GlobalFilter(false)]
    public class AccountController : Controller
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

    }
}
