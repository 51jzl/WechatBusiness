using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json;
using HN.Model;
using HN.BLL;

namespace HN.UI.Controllers
{
    public class ButtonController : Controller
    {
        Button buttonbll = new Button();

        #region View-按钮管理 Index()
        [GlobalFilter("menu")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Method-获取按钮列表 GetButtonList(string btnCode,string btnName)
        public string GetButtonList(string btnCode, string btnName)
        {
            DataTable dt = buttonbll.GetList(btnCode, btnName);
            return JsonConvert.SerializeObject(new { rows = dt, total = dt.Rows.Count });
        }
        #endregion

        #region View-添加/编辑按钮 Edit(string id)
        [GlobalFilter("btn", "/Button/Index")]
        public ActionResult Edit(string id)
        {
            ButtonInfo model = new ButtonInfo();
            if (!string.IsNullOrEmpty(id))
            {
                model = buttonbll.GetModel(null, Convert.ToInt32(id));
            }
            return View(model);
        }
        #endregion

        #region Method-添加/编辑按钮 Edit(ButtonInfo model)
        [HttpPost]
        [GlobalFilter("btn", "/Button/Index")]
        public string Edit(ButtonInfo model)
        {
            return buttonbll.AddOrEditButton(model);
        }
        #endregion

        #region Method-删除按钮 Delete(int id)
        [HttpPost]
        [GlobalFilter("btn", "/Button/Index")]
        public string Delete(int id)
        {
            return buttonbll.DeleteButton(id);
        }
        #endregion

    }
}
