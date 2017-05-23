using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HN.Model;
using HN.BLL;

namespace HN.UI.Controllers
{
    public class OrganizatController : Controller
    {
        Organization organizationbll = new Organization();

        #region View-组织管理 Index()
        [GlobalFilter("menu")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Method-获取组织列表 GetOrgList(string t)
        [HttpPost]
        public string GetOrgList(string t)
        {
            int type = 0;
            if (!string.IsNullOrEmpty(t))
            {
                type = Convert.ToInt32(t);
            }
            return organizationbll.GetOrgList(type);
        }
        #endregion

        #region View-添加/编辑组织 Edit(string id)
        [GlobalFilter("btn", "/Organizat/Index")]
        public ActionResult Edit(string id)
        {
            OrganizationInfo model = new OrganizationInfo();
            if (!string.IsNullOrEmpty(id))
            {
                model = organizationbll.GetModel(null, Convert.ToInt32(id));
            }
            return View(model);
        }
        #endregion

        #region Method-添加/编辑组织 Edit(RolesInfo model)
        [HttpPost]
        [GlobalFilter("btn", "/Organizat/Index")]
        public string Edit(OrganizationInfo model)
        {
            return organizationbll.AddOrEditOrg(model);
        }
        #endregion

        #region Method-删除组织 Delete(int id)
        [HttpPost]
        [GlobalFilter("btn", "/Organizat/Index")]
        public string Delete(int id)
        {
            return organizationbll.DeleteOrg(id);
        }
        #endregion

        #region Method-获取用户所在的组织 GetUserOrg(int id)
        [HttpPost]
        public string GetUserOrg(int id)
        {
            return organizationbll.GetUserOrg(id);
        }
        #endregion
    }
}
