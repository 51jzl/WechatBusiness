using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HN.Model
{
    /// <summary>
    /// 非数据库表 用来存放Session信息
    /// </summary>
    public class SessionInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public static object UserID
        {
            get { return System.Web.HttpContext.Current.Session["UserID"]; }
            set { System.Web.HttpContext.Current.Session["UserID"] = value; }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        public static string LoginName
        {
            get { return System.Web.HttpContext.Current.Session["UserName"].ToString(); }
            set { System.Web.HttpContext.Current.Session["UserName"] = value; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public static string UserName
        {
            get { return System.Web.HttpContext.Current.Session["UserName"].ToString(); }
            set { System.Web.HttpContext.Current.Session["UserName"] = value; }
        }

        /// <summary>
        /// 是否系统管理员
        /// </summary>
        public static int IsAdmin
        {
            get { return int.Parse(System.Web.HttpContext.Current.Session["IsAdmin"].ToString()); }
            set { System.Web.HttpContext.Current.Session["IsAdmin"] = value; }
        }
    }
}
