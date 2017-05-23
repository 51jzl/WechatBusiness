using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HN.Model;
using HN.BLL;
using Newtonsoft.Json;
using System.Data;

namespace HN.UI.Controllers
{
    public class ModuleController : Controller
    {
        Module modulebll = new Module();
        ModuleButton modulebuttonbll = new ModuleButton();

        #region View-菜单管理 Index()
        [GlobalFilter("menu")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Method-获取菜单列表 GetList()
        [HttpPost]
        public string GetList()
        {
            return modulebll.GetModuleList();
        }
        #endregion

        #region View-添加/编辑菜单 Edit(string id)
        [GlobalFilter("btn", "/Module/Index")]
        public ActionResult Edit(string id)
        {
            ModuleInfo model = new ModuleInfo();
            if (!string.IsNullOrEmpty(id))
            {
                model = modulebll.GetModel(null, Convert.ToInt32(id));
            }
            else
            {
                model.IsEnable = 1;
            }
            return View(model);
        }
        #endregion

        #region Method-获取所有的菜单树 GetModuleList()
        [HttpPost]
        public string GetModuleList()
        {
            return modulebll.GetModuleListForEdit();
        }
        #endregion

        #region Method-添加/编辑菜单 Edit(DictValueInfo model)
        [HttpPost]
        [GlobalFilter("btn", "/Module/Index")]
        public string Edit(ModuleInfo model)
        {
            return modulebll.AddOrEditModule(model);
        }
        #endregion

        #region Method-删除菜单 Delete(int id)
        [HttpPost]
        [GlobalFilter("btn", "/Module/Index")]
        public string Delete(int id)
        {
            return modulebll.DeleteModule(id);
        }
        #endregion

        #region View-设置按钮 SetButton(int id)
        [GlobalFilter("btn", "/Module/Index")]
        public ActionResult SetButton(int id)
        {
            DataTable dt = modulebuttonbll.GetListByModID(id);
            ViewBag.ButtonList = dt;
            ViewBag.ModID = id;
            return View();
        }
        #endregion

        #region Method-设置按钮 SetButton(int id)
        [HttpPost]
        [GlobalFilter("btn", "/Module/Index")]
        public string SetButton(int id,List<int> BtnID)
        {
            return modulebuttonbll.SetButton(id, BtnID);
        }
        #endregion
    }
}
