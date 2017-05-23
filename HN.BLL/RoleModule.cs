using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;
using HN.Utility;

namespace HN.BLL
{
    /// <summary>
    /// 角色节点权限
    /// Author 2015-08-11
    /// </summary>
    public class RoleModule
    {
        private readonly DAL.RoleModule dal = new DAL.RoleModule();
        public RoleModule()
        { }

        #region 是否存在该记录 Exists(object tran,int RoleID,int ModID)
        /// <summary>
        /// 是否存在该记录
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int RoleID, int ModID)
        {
            return dal.Exists(tran, RoleID, ModID);
        }
        #endregion

        #region 增加一条数据 Add(object tran,RoleModuleInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, RoleModuleInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,RoleModuleInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, RoleModuleInfo model)
        {
            return dal.Update(tran, model);
        }
        #endregion

        #region  删除一条数据 Delete(object tran,int RoleID,int ModID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int RoleID, int ModID)
        {
            return dal.Delete(tran, RoleID, ModID);
        }
        #endregion

        #region 得到一个对象实体 RoleModuleInfo GetModel(object tran,int RoleID,int ModID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RoleModuleInfo GetModel(object tran, int RoleID, int ModID)
        {
            return dal.GetModel(tran, RoleID, ModID);
        }
        #endregion

        #region 获得数据列表 GetList(string strWhere)
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        #endregion

        #region 根据登录人获取节点 GetRoleModuleList(int userID)
        /// <summary>
        /// 根据登录人获取节点
        /// pxd 2015-09-20
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetRoleModuleList(int userID)
        {
            string type = SessionInfo.IsAdmin == 0 ? "0" : "";
            return dal.GetRoleModuleList(userID, type);
        }
        #endregion

        #region 递归拼Json树 GetTreeJson(int pid,DataTable dt)
        /// <summary>
        /// 递归拼Json树
        /// pxd 2015-09-20
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string GetTreeJson(int pid, DataTable dt)
        {
            StringBuilder bulider = new StringBuilder();
            DataRow[] drs = dt.Select("ParentID=" + pid, "Sort");
            if (drs.Length != 0)
            {
                foreach (DataRow dr in drs)
                {
                    bulider.Append("{");
                    bulider.Append("\"id\":" + dr["ModID"]);
                    bulider.Append(",\"text\":\"" + dr["ModName"] + "\"");
                    bulider.Append(",\"iconCls\":\"icon-" + dr["Icon"] + "\"");
                    //pid为0时加载顶级菜单
                    if (pid != 0)
                    {
                        //加载tree
                        string strChildren = GetTreeJson((int)dr["ModID"], dt);

                        bulider.Append(",\"attributes\": {\"url\":\"" + dr["Link"] + "\"}");
                        if (strChildren != "")
                        {
                            bulider.Append(",\"state\": \"closed\"");
                            bulider.Append(",children:[");
                            bulider.Append(strChildren);
                            bulider.Append("]");
                        }
                    }
                    bulider.Append("},");
                }
                bulider.Remove(bulider.Length - 1, 1);
                return bulider.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 获取用户所拥有的操作菜单 GetMenuList(int userID, int pid)
        public string GetMenuList(int userID, int pid)
        {
            string strReturn = "";
            DataTable dtTree = GetRoleModuleList(userID);
            strReturn = "[" + GetTreeJson(pid, dtTree) + "]";
            return strReturn;
        }
        #endregion

        #region 获取菜单权限 GetRoleModule(int userID,string link)
        /// <summary>
        /// 获取菜单权限
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public DataTable GetRoleModule(int userID, string link)
        {
            return dal.GetRoleModule(userID, link);
        }
        #endregion

        #region 判断菜单是否已关联角色 IsRelate(object tran,int ModID)
        /// <summary>
        /// 判断菜单是否已关联角色
        /// pxd 2015-10-14
        /// </summary>
        public bool IsRelate(object tran, int ModID)
        {
            return dal.IsRelate(tran, ModID);
        }
        #endregion

        #region 根据角色ID判断是否存在 ExistsByRoleID(object tran, int roleID)
        /// <summary>
        /// 根据角色ID判断是否存在
        /// pxd 2015-10-15
        /// </summary>
        public bool ExistsByRoleID(object tran, int roleID)
        {
            return dal.ExistsByRoleID(tran, roleID);
        }
        #endregion

        #region 根据角色ID删除 DeleteByRoleID(object tran, int roleID)
        /// <summary>
        /// 根据角色ID删除
        /// pxd 2015-10-15
        /// </summary>
        public bool DeleteByRoleID(object tran, int roleID)
        {
            return dal.DeleteByRoleID(tran, roleID);
        }
        #endregion

        #region 根据角色获取菜单节点-角色分配权限时调用 GetModuleListByRoleID(int roleID)
        /// <summary>
        /// 根据角色获取菜单节点
        /// pxd 2015-10-16
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public DataTable GetModuleListByRoleID(int roleID, string type)
        {
            return dal.GetModuleListByRoleID(roleID, type);
        }
        #endregion

        #region 递归获取树-分配权限时调用 GetTreeJsonForAllot(int pid, DataTable dt)
        /// <summary>
        /// 递归获取树
        /// pxd 2015-10-16
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string GetTreeJsonForAllot(int pid, DataTable dt)
        {
            StringBuilder bulider = new StringBuilder();
            DataRow[] drs = dt.Select("ParentID=" + pid, "Sort");
            if (drs.Length != 0)
            {
                foreach (DataRow dr in drs)
                {
                    bulider.Append("{");
                    bulider.Append("\"ModID\":" + dr["ModID"]);
                    bulider.Append(",\"ModName\":\"" + dr["ModName"] + "\"");
                    bulider.Append(",\"ParentID\":\"" + dr["ParentID"] + "\"");
                    bulider.Append(",\"iconCls\":\"icon-" + dr["Icon"] + "\"");
                    bulider.Append(",\"ButtonList\":\"" + dr["ButtonList"] + "\"");
                    bulider.Append(",\"Chk\":\"" + dr["RoleID"] + "\"");
                    //if (dr["RoleID"].ToString() != "")
                    //{
                    //    bulider.Append(",\"checked\":true");
                    //}
                    //加载tree
                    string strChildren = GetTreeJsonForAllot((int)dr["ModID"], dt);
                    if (strChildren != "")
                    {
                        bulider.Append(",children:[");
                        bulider.Append(strChildren);
                        bulider.Append("]");
                    }
                    bulider.Append("},");
                }
                bulider.Remove(bulider.Length - 1, 1);
                return bulider.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 获取角色菜单和角色菜单按钮 GetModuleAndButtonByRoleID(int roleID)
        /// <summary>
        /// 获取角色菜单和角色菜单按钮
        /// pxd 2015-10-16
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public string GetModuleAndButtonByRoleID(int roleID)
        {
            string strReturn = "";
            string type = SessionInfo.IsAdmin == 0 ? "0" : "";
            //菜单
            DataTable dtModule = GetModuleListByRoleID(roleID, type);
            //按钮
            DataTable dtButton = new RoleModButton().GetButtonListByRoleID(roleID, type);
            for (int i = 0; i < dtModule.Rows.Count; i++)
            {
                DataRow[] drs = dtButton.Select("ModID=" + dtModule.Rows[i]["ModID"], "Sort");
                string strBtn = "";
                foreach (var dr in drs)
                {
                    strBtn += dr["Chk"] + ",";
                    strBtn += dr["BtnID"] + ",";
                    strBtn += dr["BtnName"] + "|";
                }
                dtModule.Rows[i]["ButtonList"] = strBtn.Length > 0 ? strBtn.Substring(0, strBtn.Length - 1) : "";
            }
            strReturn = Tools.ConvertJsonString("[" + GetTreeJsonForAllot(0, dtModule) + "]");
            return strReturn;
        }

        #endregion

        #region 分配菜单和按钮权限 Allot(int roleID, List<int> modID, List<string> mbID)
        /// <summary>
        /// 分配菜单和按钮权限
        /// pxd 2015-10-19
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="modID"></param>
        /// <param name="mbID"></param>
        /// <returns></returns>
        public string Allot(int roleID, List<int> modID, List<string> mbID)
        {
            string strReturn = "";
            Transaction transaction = new Transaction();
            object tran = transaction.CreatTransaction();
            try
            {
                //判断存在角色菜单权限则先删除
                if (new RoleModule().ExistsByRoleID(tran,roleID))
                {
                    if (!new RoleModule().DeleteByRoleID(tran,roleID))
                    {
                        throw new Exception("删除角色菜单权限失败！");
                    }
                }

                //判断存在角色按钮权限则先删除
                if (new RoleModButton().ExistsByRoleID(tran, roleID))
                {
                    if (!new RoleModButton().DeleteByRoleID(tran, roleID))
                    {
                        throw new Exception("删除角色菜单权限失败！");
                    }
                }

                //添加角色菜单权限
                if (modID!=null)
                {
                    for (int i = 0; i < modID.Count; i++)
                    {
                        RoleModuleInfo model = new RoleModuleInfo()
                        {
                            RoleID = roleID,
                            ModID = modID[i],
                        };
                        if (!Add(tran, model))
                        {
                            throw new Exception("添加角色菜单权限失败！");
                        }
                    }
                }

                //添加角色按钮权限
                if (mbID != null)
                {
                    RoleModButtonInfo model = new RoleModButtonInfo();
                    model.RoleID = roleID;
                    for (int i = 0; i < mbID.Count; i++)
                    {
                        string [] mbID_Arr = mbID[i].Split(new char[] { ',' });
                        model.ModID = int.Parse(mbID_Arr[0]);
                        model.BtnID = int.Parse(mbID_Arr[1]);
                        if (!new RoleModButton().Add(tran, model))
                        {
                            throw new Exception("添加角色按钮权限失败！");
                        }
                    }
                }

                transaction.Commit(tran);
            }
            catch (Exception ex)
            {
                transaction.Rollback(tran);
                strReturn = new Tools().GetErrorInfo(ex);
            }
            return strReturn;
        }
        #endregion
    }
}