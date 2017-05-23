using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;
using HN.Utility;

namespace HN.BLL
{
    /// <summary>
    /// 用户角色表
    /// Author 2015-09-10
    /// </summary>
    public class UsersRole
    {
        private readonly DAL.UsersRole dal = new DAL.UsersRole();
        public UsersRole()
        { }

        #region 是否存在该记录 Exists(object tran,int UserID,int RoleID)
        /// <summary>
        /// 是否存在该记录
        /// Author 2015-09-10
        /// </summary>
        public bool Exists(object tran, int UserID, int RoleID)
        {
            return dal.Exists(tran, UserID, RoleID);
        }
        #endregion

        #region 增加一条数据 Add(object tran,UsersRoleInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-09-10
        /// </summary>
        public bool Add(object tran, UsersRoleInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,UsersRoleInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-09-10
        /// </summary>
        public bool Update(object tran, UsersRoleInfo model)
        {
            return dal.Update(tran, model);
        }
        #endregion

        #region  删除一条数据 Delete(object tran,int UserID,int RoleID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-09-10
        /// </summary>
        public bool Delete(object tran, int UserID, int RoleID)
        {
            return dal.Delete(tran, UserID, RoleID);
        }
        #endregion

        #region 得到一个对象实体 UsersRoleInfo GetModel(object tran,int UserID,int RoleID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UsersRoleInfo GetModel(object tran, int UserID, int RoleID)
        {
            return dal.GetModel(tran, UserID, RoleID);
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

        #region 判断角色是否存在用户 ExistsByRoleID(object tran,int roleID)
        /// <summary>
        /// 判断角色是否存在用户
        /// pxd 2015-10-15
        /// </summary>
        public bool ExistsByRoleID(object tran, int roleID)
        {
            return dal.ExistsByRoleID(tran, roleID);
        }
        #endregion

        #region 查询角色用户 GetUserByRoleID(string strKey,int roleID,int type, bool bAdmin)
        /// <summary>
        /// 查询角色用户
        /// </summary>
        /// <param name="strKey">查询关键字</param>
        /// <param name="roleID">角色ID</param>
        /// <param name="orgID">组织ID</param>
        /// <param name="type">0表示当前角色未分配的用户 1表示当前角色已分配的用户</param>
        /// <param name="bAdmin">是否管理员</param>
        /// <returns></returns>
        public DataTable GetUserByRoleID(string strKey, int roleID, string orgID, int type, bool bAdmin)
        {
            return dal.GetUserByRoleID(strKey, roleID, orgID, type, bAdmin);
        }
        #endregion

        #region 查询角色中未分配的用户 GetUserNotInRole(string strKey,int roleID,bool bAdmin)
        /// <summary>
        /// 查询角色中未分配的用户
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="roleID"></param>
        /// <param name="bAdmin"></param>
        /// <returns></returns>
        public DataTable GetUserNotInRole(string strKey, int roleID, string orgID, bool bAdmin)
        {
            return GetUserByRoleID(strKey, roleID, orgID, 0, bAdmin);
        }
        #endregion

        #region 查询角色中分配的用户 GetRoleUser(string strKey,int roleID,bool bAdmin)
        /// <summary>
        /// 查询角色中分配的用户
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="roleID"></param>
        /// <param name="bAdmin"></param>
        /// <returns></returns>
        public string GetRoleUser(int roleID, bool bAdmin)
        {
            DataTable dt = GetUserByRoleID("", roleID, "", 1, bAdmin);
            RolesInfo model = new Roles().GetModel(null, roleID);
            StringBuilder bulider = new StringBuilder();
            bulider.Append("[{\"id\":\"\",\"text\":\"" + model.RoleName + "\",\"iconCls\":\"icon-group\",\"children\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bulider.Append("{\"id\":" + dt.Rows[i]["UserID"]);
                bulider.Append(",\"text\":\"" + dt.Rows[i]["UserName"] + "\"");
                bulider.Append(",\"iconCls\":\"icon-user\"},");
            }
            bulider.Append("]}]");
            return Tools.ConvertJsonString(bulider.ToString());
        }
        #endregion

        #region 向角色中添加用户
        public string AddUser(int roleID, string userIDs)
        {
            string strReturn = "";
            Transaction transaction = new Transaction();
            object tran = transaction.CreatTransaction();
            try
            {
                string[] userID = userIDs.Split(new char[] { ',' });
                for (int i = 0; i < userID.Length; i++)
                {
                    //判断是否存在该用户
                    if (!Exists(tran, Convert.ToInt32(userID[i]), roleID))
                    {
                        if (!Add(tran, new UsersRoleInfo() { UserID = Convert.ToInt32(userID[i]), RoleID = roleID }))
                        {
                            throw new Exception(ErrorPrompt.AddError);
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