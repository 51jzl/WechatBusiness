using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HN.BLL;
using HN.Model;
using System.Data;
using Newtonsoft.Json;


namespace HN.UI.Controllers
{
    public class LoginLogController : Controller
    {
        LoginLog loginlogbll = new LoginLog();

        #region View-登录日志 Index()
        [GlobalFilter("menu")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Method-获取登录日志列表 GetButtonList(string btnCode,string btnName)
        public string GetLogList(string startDate, string endDate, int rows, int page)
        {
            DataTable dt = loginlogbll.GetLogList(Convert.ToInt32(SessionInfo.UserID), startDate, endDate,rows,page);
            int pageCount = Convert.ToInt32(dt.DataSet.Tables["Page_TotalCount"].Rows[0][0].ToString());
            return JsonConvert.SerializeObject(new { rows = dt, total = pageCount });
        }
        #endregion

    }
}
