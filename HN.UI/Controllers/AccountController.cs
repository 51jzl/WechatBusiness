using HN.BLL;
using HN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HN.UI.Controllers
{
    [GlobalFilter(false)]
    public class AccountController : Controller
    {
        Users usersbll = new Users();

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Register(UsersInfo model)
        {
            MessageJSON mj = new MessageJSON(MessageState.fail, "创建用户失败", MessageIcon.no);
            string result = usersbll.Create(model, null);
            if (string.IsNullOrEmpty(result))
                mj = new MessageJSON(MessageState.success, "创建用户成功", MessageIcon.yes);
            else
                mj = new MessageJSON(MessageState.fail, "创建用户失败 ex:" + result, MessageIcon.no);
            return Json(mj, JsonRequestBehavior.AllowGet);
        }

    }
}
