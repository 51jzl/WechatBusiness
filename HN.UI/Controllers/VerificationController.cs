using HN.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HN.UI.Controllers
{
    public class VerificationController : Controller
    {
        Verification verificationbll = new Verification();

        /// <summary>
        /// 获取短信验证
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetPhoneCode(string mobile)
        {
            verificationbll.Create(Model.VerificationType.Phone, mobile);
            return Json(new MessageJSON(MessageState.success, "发送短信成功", MessageIcon.yes), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 判断短信验证
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult JudgePhoneCode(string mobile, string code)
        {
            MessageJSON mj = new MessageJSON(MessageState.fail, "短信验证码错误", MessageIcon.no);
            IEnumerable<Model.Verification> verifications = verificationbll.Query(Model.VerificationType.Phone, mobile);
            if (verifications.Count() > 0)
            {
                if (verifications.First().VerifyCode == code)
                    mj = new MessageJSON(MessageState.success, "短信验证成功", MessageIcon.yes);
            }
            return Json(mj, JsonRequestBehavior.AllowGet);
        }

    }
}
