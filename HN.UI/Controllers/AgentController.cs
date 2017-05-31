using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HN.UI.Controllers
{
    public class AgentController : Controller
    {
        /// <summary>
        /// 创建代理
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateLevel() {
            return View();
        }

        /// <summary>
        /// 代理详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            return View();
        }

    }
}
