using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using HN.BLL;
using HN.Model;
using HN.Utility;
using Newtonsoft.Json;

namespace HN.UI.Controllers
{
    public class RolesController : Controller
    {
        Roles rolesbll = new Roles();
        RoleModule rolemodulebll = new RoleModule();
        UsersRole usersrolebll = new UsersRole();

        #region View-角色管理 Index()
        [GlobalFilter("menu")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Method-获取角色列表 GetRoleList()
        [HttpPost]
        public string GetRoleList()
        {
            DataTable dt = rolesbll.GetList("");
            return JsonConvert.SerializeObject(new { rows = dt });
        }
        #endregion

        #region View-添加/编辑角色 Edit(string id)
        [GlobalFilter("btn", "/Roles/Index")]
        public ActionResult Edit(string id)
        {
            RolesInfo model = new RolesInfo();
            if (!string.IsNullOrEmpty(id))
            {
                model = rolesbll.GetModel(null, Convert.ToInt32(id));
            }
            return View(model);
        }
        #endregion

        #region Method-添加/编辑角色 Edit(RolesInfo model)
        [HttpPost]
        [GlobalFilter("btn", "/Roles/Index")]
        public string Edit(RolesInfo model)
        {
            return rolesbll.AddOrEditRoles(model);
        }
        #endregion

        #region Method-删除角色 Delete(int id)
        [HttpPost]
        [GlobalFilter("btn", "/Roles/Index")]
        public string Delete(int id)
        {
            return rolesbll.DeleteRole(id);
        }
        #endregion

        #region View-分配权限 Allot(int id)
        [GlobalFilter("btn", "/Roles/Index")]
        public ActionResult Allot(int id)
        {
            ViewBag.RoleName = new Roles().GetModel(null, id).RoleName;
            ViewBag.RoleID = id;
            return View();
        }
        #endregion

        #region Method-分配权限保存 Allot(int roleID,List<int>modID,List<string>mbID)
        [HttpPost]
        public string Allot(int roleID, List<int> modID, List<string> mbID)
        {
            return rolemodulebll.Allot(roleID, modID, mbID);
        }
        #endregion

        #region Method-获取角色菜单列表及对应按钮 GetModuleList(int id)
        [HttpPost]
        public string GetModuleList(int id)
        {
            return rolemodulebll.GetModuleAndButtonByRoleID(id);
        }
        #endregion

        #region View-角色分配用户 AllotUser(int id)
        [GlobalFilter("btn", "/Roles/Index")]
        public ActionResult AllotUser(int id)
        {
            ViewBag.RoleID = id;
            return View();
        }
        #endregion

        #region Method-获取未分配的用户 GetNotAllotUser(int roleID,string key,string orgID)
        [HttpPost]
        public string GetNotAllotUser(int roleID, string key, string orgID)
        {
            bool bAdmin = SessionInfo.IsAdmin == 1 ? true : false;
            DataTable dt = usersrolebll.GetUserNotInRole(key, roleID, orgID, bAdmin);
            return JsonConvert.SerializeObject(new { rows = dt });
        }
        #endregion

        #region Method-获取角色已分配的用户 GetRoleUser(int roleID)
        [HttpPost]
        public string GetRoleUser(int roleID)
        {
            bool bAdmin = SessionInfo.IsAdmin == 1 ? true : false;
            return usersrolebll.GetRoleUser(roleID, bAdmin);
        }
        #endregion

        #region Method-从角色中移除用户 RemoveUser(int roleID)
        [HttpPost]
        public string RemoveUser(int roleID, int userID)
        {
            string strReturn = "";
            if (!usersrolebll.Delete(null, userID, roleID))
            {
                strReturn = ErrorPrompt.DeleError;
            }
            return strReturn;
        }
        #endregion

        #region Method 向角色中添加用户 AddUser(int roleID, string userIDs)
        [HttpPost]
        public string AddUser(int roleID, string userIDs)
        {
            return usersrolebll.AddUser(roleID, userIDs);
        }
        #endregion
    }
}
