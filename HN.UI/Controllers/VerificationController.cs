using HN.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HN.UI.Controllers
{
    [GlobalFilter(false)]
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
            if (string.IsNullOrEmpty(mobile) || mobile.Length != 11)
            {
                return Json(new MessageJSON(MessageState.abnormality, "请输入正确的手机号码", MessageIcon.no), JsonRequestBehavior.AllowGet);
            }
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

        /// <summary>
        /// 获取授权验证码 如登录、注册图片验证码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AuthorizationVerifyCode(string code)
        {
            MessageJSON mj = new MessageJSON(MessageState.fail, "验证码错误");
            if (Session["verifyCode"] != null)
                if (Session["verifyCode"].ToString().ToLower() == code.ToLower())
                    mj = new MessageJSON(MessageState.success, "验证码通过", MessageIcon.yes);
            return Json(mj, JsonRequestBehavior.AllowGet);
        }

    }
}
