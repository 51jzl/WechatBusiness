using System;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json;
using HN.BLL;
using HN.Model;
using HN.Utility;

namespace HN.UI.Controllers
{
    public class DictController : Controller
    {
        DictKey dictkeybll = new DictKey();
        DictValue dictvaluebll = new DictValue();

        #region View-数据字典 Index()
        [GlobalFilter("menu")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 获取字典关键字树 GetKeyTree()
        [HttpPost]
        public string GetKeyTree()
        {
            return dictkeybll.GetTreeJson();
        }
        #endregion
       
        #region Method-获取字典值列表 GetValue(string keyID, int rows, int page)
        [HttpPost]
        public string GetValue(string keyID, int rows, int page)
        {
            DataTable dt = dictvaluebll.GetValueList(keyID, rows, page);
            int pageCount = Convert.ToInt32(dt.DataSet.Tables["Page_TotalCount"].Rows[0][0].ToString());
            return JsonConvert.SerializeObject(new { rows = dt, total = pageCount });
        }
        #endregion

        #region View-添加/编辑数据字典 Edit(string id,string keyID,string keyName)
        [GlobalFilter("btn", "/Dict/Index")]
        public ActionResult Edit(string id, string keyID, string keyName)
        {
            DictValueInfo model = new DictValueInfo();
            if (!string.IsNullOrEmpty(id))
            {
                model = dictvaluebll.GetModel(null, Convert.ToInt32(id));
                DictKeyInfo dictkeyinfo = dictkeybll.GetModel(null, model.KeyID);
                keyName = dictkeyinfo.KeyName;
            }
            else
            {
                model.KeyID = Convert.ToInt32(keyID);
            }
            ViewBag.KeyName = keyName;
            return View(model);
        }
        #endregion

        #region Method-添加/编辑数据字典 Edit(DictValueInfo model)
        [HttpPost]
        [GlobalFilter("btn", "/Dict/Index")]
        public string Edit(DictValueInfo model)
        {
            return dictvaluebll.AddOrEdit(model);
        }
        #endregion

        #region Method-删除按钮 Delete(int id)
        [HttpPost]
        [GlobalFilter("btn", "/Dict/Index")]
        public string Delete(int id)
        {
            string strReturn = "";
            if (!dictvaluebll.Delete(null, id))
            {
                strReturn = ErrorPrompt.DeleError;
            }
            return strReturn;
        }
        #endregion
    }
}
