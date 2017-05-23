using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HN.BLL;
using HN.Model;
using System.Data;
using Newtonsoft.Json;
using HN.Utility;
using System.IO;
using System.Text;
using HN.UI.App_Start;

namespace HN.UI.Controllers
{
    public class UsersController : Controller
    {
        Users usersbll = new Users();

        #region View-用户管理首页 Index()
        [GlobalFilter("menu")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Method-获取用户列表 GetUserList(string loginName, string userName, string phone, string orgID, int rows, int page)
        public string GetUserList(string loginName, string userName, string phone, string orgID, int rows, int page)
        {
            bool bAdmin = SessionInfo.IsAdmin == 1 ? true : false;
            DataTable dt = usersbll.GetUserList(loginName, userName, phone, bAdmin, orgID, rows, page);
            int pageCount = Convert.ToInt32(dt.DataSet.Tables["Page_TotalCount"].Rows[0][0].ToString());
            return JsonConvert.SerializeObject(new { rows = dt, total = pageCount });
        }
        #endregion

        #region Method-删除用户(逻辑删除) Delete(int id)
        [HttpPost]
        [GlobalFilter("btn", "/Users/Index")]
        public string Delete(int id)
        {
            string strReturn = "";
            if (!usersbll.DeleteUser(id))
            {
                strReturn = ErrorPrompt.DeleError;
            }
            return strReturn;
        }
        #endregion

        #region View-添加/编辑用户 Edit(string id)
        [GlobalFilter("btn", "/Users/Index")]
        public ActionResult Edit(string id)
        {
            UsersInfo model = new UsersInfo();
            if (!string.IsNullOrEmpty(id))
            {
                model = usersbll.GetModel(null, Convert.ToInt32(id));
            }
            ViewBag.EducationList = new SelectList(new DictValue().GetListByKey("学历", true, "==请选择=="), "Remark", "ValName");
            ViewBag.DegreeList = new SelectList(new DictValue().GetListByKey("学位", true, "==请选择=="), "Remark", "ValName");
            return View(model);
        }
        #endregion

        #region Method-添加/编辑用户 Edit(string id)
        [HttpPost]
        [GlobalFilter("btn", "/Users/Index")]
        public string Edit(UsersInfo model, List<int> OrgID)
        {
            return usersbll.AddOrUpdate(model, OrgID);
        }
        #endregion

        #region Method-重置密码 Reset(int id)
        [HttpPost]
        [GlobalFilter("btn", "/Users/Index")]
        public string Reset(int id)
        {
            string strReturn = "";
            if (!usersbll.ResetPwd(id))
            {
                strReturn = "重置密码失败，请联系管理员";
            }
            return strReturn;
        }
        #endregion

        #region Method-导出Excel Export(string loginName, string userName, string phone, string orgID)
        [GlobalFilter("btn", "/Users/Index")]
        public void Export(string loginName, string userName, string phone, string orgID)
        {
            DataTable dt = usersbll.GetExportList(loginName, userName, phone, orgID);
            Response.ToExcel("用户信息", ExcelHelper.GetExcelStream(dt, new string[] { "编号", "登录名", "姓名", "性别", "出生日期", "手机", "固话", "邮箱", "地址" }));
        }
        #endregion

    }
}
