using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HN.BLL;
using HN.Model;
using Newtonsoft.Json;
using System.Data;
using System.Web.Security;
using System.Data.OleDb;

namespace HN.UI.Controllers
{
    public class HomeController : Controller
    {
        Users usersbll = new Users();
        LoginLog loginlogbll = new LoginLog();
        RoleModule rolemodulebll = new RoleModule();

        #region View-登录 Login()
        [GlobalFilter(false)]
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region Method-输出验证码 VerifyCode()
        [GlobalFilter(false)]
        public void VerifyCode()
        {
            BLL.VerifyCode.CreateVerifyCode();
        }
        #endregion

        #region Method-系统登录 Login(string loginName, string pwd, string code)
        [HttpPost]
        [GlobalFilter(false)]
        public JsonResult Login(string loginName, string pwd)
        {
            MessageJSON message = new MessageJSON();
            UsersInfo usersinfo = usersbll.GetModelByName(loginName, Utility.DESEncrypt.GetMd5Str(pwd));
            if (usersinfo != null)
            {
                if (usersinfo.DeleteMark == 0)
                {
                    //清空验证码
                    Session["verifyCode"] = null;

                    //保存用户登录信息
                    SessionInfo.UserID = usersinfo.UserID;
                    SessionInfo.UserName = usersinfo.UserName;
                    SessionInfo.LoginName = usersinfo.LoginName;
                    SessionInfo.IsAdmin = usersinfo.IsAdmin;

                    //添加登录日志
                    LoginLogInfo loginloginfo = new LoginLogInfo();
                    loginloginfo.UserID = usersinfo.UserID;
                    loginloginfo.LoginName = usersinfo.LoginName;
                    loginloginfo.State = 1;
                    loginloginfo.LoginIP = Request.UserHostAddress;
                    loginloginfo.IPAddress = "";
                    loginlogbll.Add(null, loginloginfo);
                    message = new MessageJSON() { State = MessageState.success, Icon = MessageIcon.yes, Content = "登录成功" };
                }
                else
                {
                    message = new MessageJSON() { State = MessageState.fail, Icon = MessageIcon.no, Content = "用户已被删除" };
                }
            }
            else
            {
                message = new MessageJSON() { State = MessageState.fail, Icon = MessageIcon.no, Content = "账户或密码有错误" };
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        #endregion

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register() {
            return View();
        }

        #region View-主页 Default()
        public ActionResult Default()
        {
            string skin = "default";  //主题
            HttpCookie cookies = Request.Cookies["skin"];
            if (Request.Cookies["skin"] != null)
            {
                skin = Request.Cookies["skin"].Value;
            }
            else
            {
                cookies = new HttpCookie("skin");
                cookies.Value = skin;
                cookies.Expires = DateTime.MaxValue;
                Response.AppendCookie(cookies);
            }
            ViewBag.UserName = SessionInfo.UserName.ToString();
            ViewBag.skin = skin;
            return View();
        }
        #endregion

        #region Method-切换主题 ToggleTheme(string skin)
        public ActionResult ToggleTheme(string skin)
        {
            HttpCookie cookies = Request.Cookies["skin"];
            if (cookies != null)
            {
                cookies.Value = skin;
            }
            else
            {
                cookies = new HttpCookie("skin");
                cookies.Value = skin;
            }
            cookies.Expires = DateTime.MaxValue;
            Response.AppendCookie(cookies);
            return Content("<script>location.href='/Home/Default'</script>");
        }
        #endregion

        #region Method-退出登录 Logout()
        public ActionResult Logout()
        {
            SessionInfo.UserID = null;
            SessionInfo.UserName = null;
            return RedirectToAction("Login", "Home");
        }
        #endregion

        #region Method-修改密码 UpdatePass(string oldPwd,string newPwd)
        [HttpPost]
        public string UpdatePass(string oldPwd, string newPwd)
        {
            string strReturn = "";
            UsersInfo model = usersbll.GetModel(null, Convert.ToInt32(SessionInfo.UserID));
            if (Utility.DESEncrypt.GetMd5Str(oldPwd) != model.Pwd)
            {
                strReturn = "旧密码输入错误！";
            }
            else if (!usersbll.UpdatePass(Utility.DESEncrypt.GetMd5Str(newPwd), Convert.ToInt32(SessionInfo.UserID)))
            {
                strReturn = "修改失败，请联系管理员！";
            }
            return strReturn;
        }
        #endregion

        #region Method-获取菜单列表Json GetMenuList(string pid)
        [HttpPost]
        public string GetMenuList(string pid)
        {
            return rolemodulebll.GetMenuList(Convert.ToInt32(SessionInfo.UserID), !string.IsNullOrEmpty(pid) ? int.Parse(pid) : 0);
        }
        #endregion

        #region Method-提供页面跳转 ReturnTo()
        [GlobalFilter(false)]
        public ActionResult ReturnTo()
        {
            return Content("<script>top.location.href='/Home/Login';</script>");
        }
        #endregion

    }
}
