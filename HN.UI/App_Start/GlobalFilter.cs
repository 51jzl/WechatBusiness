using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HN.Model;
using HN.BLL;
using System.Data;

namespace HN.UI
{
    /// <summary>
    /// ***全局过滤器***
    /// 1.验证是否登录
    /// 2.验证菜单权限
    /// 3.验证按钮权限
    /// </summary>
    public class GlobalFilter : ActionFilterAttribute
    {
        private bool _isEnable = true;   //标识是否验证Session 
        private string _type;            //验证的权限类型 menu 左侧菜单 btn 按钮或弹出窗口
        private string _pageUrl;         //页面路径 用来判断按钮属于哪个页面

        public GlobalFilter()
        { }
        public GlobalFilter(bool IsEnable)
        {
            _isEnable = IsEnable;
        }
        public GlobalFilter(string Type, string PageUrl = "")
        {
            _type = Type;
            _pageUrl = PageUrl;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_isEnable)
            {
                if (SessionInfo.UserID != null)  //判断是否登录
                {
                    var route = filterContext.RouteData.Values;
                    if (_type == "menu") //菜单权限
                    {
                        #region 验证菜单权限  
                        var link = string.Format("/{0}/{1}", route["controller"], route["action"]);
                        DataTable dt = new RoleModule().GetRoleModule(Convert.ToInt32(SessionInfo.UserID), link);
                        if (dt.Rows.Count > 0)
                        {
                            var strButton = new RoleModButton().GetButtonHtml(Convert.ToInt32(SessionInfo.UserID), Convert.ToInt32(dt.Rows[0]["ModID"]));
                            //返回页面按钮
                            filterContext.Controller.ViewBag.btnHtml = strButton;
                        }
                        else
                        {
                            filterContext.Result = new ContentResult() { Content = "<strong>您没有访问此功能的权限，请联系管理员！</strong>" };
                        }
                        #endregion
                    }
                    else if (_type == "btn") //按钮/弹出页面权限
                    {
                        #region 验证按钮权限
                        string action = filterContext.RouteData.Values["Action"].ToString();
                        var id = filterContext.RouteData.Values["id"];  //如果存在id是编辑，否则是添加
                        if (action=="Edit"&&(id == null||id.ToString()=="0"))
                        {
                            action = "Add";
                        }
                        bool b = new RoleModButton().IsButtonPower(Convert.ToInt32(SessionInfo.UserID), _pageUrl,action);
                        if (!b)
                        {
                            filterContext.Result = new ContentResult() { Content = "<strong>您没有访问此功能的权限，请联系管理员！</strong>" };
                        }
                        #endregion
                    }
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Home/ReturnTo");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}