using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;

namespace HN.BLL
{
    /// <summary>
    /// 角色页面按钮表
    /// Author 2015-09-22
    /// </summary>
    public class RoleModButton
    {
        private readonly DAL.RoleModButton dal = new DAL.RoleModButton();
        public RoleModButton()
        { }

        #region 是否存在该记录 Exists(object tran,int RoleID,int ModID,int BtnID)
        /// <summary>
        /// 是否存在该记录
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int RoleID, int ModID, int BtnID)
        {
            return dal.Exists(tran, RoleID, ModID, BtnID);
        }
        #endregion

        #region 增加一条数据 Add(object tran,ModuleButtonInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, RoleModButtonInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,ModuleButtonInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, RoleModButtonInfo model)
        {
            return dal.Update(tran, model);
        }
        #endregion

        #region  删除一条数据 Delete(object tran,int RoleID,int ModID,int BtnID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int RoleID, int ModID, int BtnID)
        {
            return dal.Delete(tran, RoleID, ModID, BtnID);
        }
        #endregion

        #region 得到一个对象实体 ModuleButtonInfo GetModel(object tran,int RoleID,int ModID,int BtnID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RoleModButtonInfo GetModel(object tran, int RoleID, int ModID, int BtnID)
        {
            return dal.GetModel(tran, RoleID, ModID, BtnID);
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

        #region 根据用户获取页面按钮 GetButtonList(int userID, int modID,string type)
        /// <summary>
        /// 根据用户获取页面按钮
        /// pxd 2015-09-20
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="modID">页面ID</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public DataTable GetButtonList(int userID, int modID, string type)
        {
            return dal.GetButtonList(userID, modID, type);
        }
        #endregion

        #region 获取页面按钮列表Html GetButtonHtml(int userID,int modID)
        /// <summary>
        /// 获取页面按钮列表Html
        /// pxd 2015-09-20
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="modID"></param>
        /// <returns></returns>
        public string GetButtonHtml(int userID, int modID)
        {
            StringBuilder builder = new StringBuilder();
            string type = SessionInfo.IsAdmin == 0 ? "0" : "";
            DataTable dt = GetButtonList(userID, modID, type);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                builder.Append("<a id='" + dt.Rows[i]["BtnCode"] + "'");
                builder.Append(" title='" + dt.Rows[i]["BtnTitle"] + "'");
                builder.Append(" href='#' class='easyui-linkbutton'");
                builder.Append(" data-options=\"plain:true,iconCls:'icon-" + dt.Rows[i]["Icon"] + "'\"");
                builder.Append(" onclick='" + dt.Rows[i]["BtnClick"] + "'>");
                builder.Append(dt.Rows[i]["BtnName"] + "</a>");
            }
            return builder.ToString();
        }
        #endregion

        #region 判断按钮权限 IsButtonPower(int userID, string url, string action)
        /// <summary>
        /// 判断按钮权限
        /// pxd 2015-09-22
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="url"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool IsButtonPower(int userID, string url, string action)
        {
            return dal.IsButtonPower(userID, url, action);
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

        #region 根据角色ID删除 DeleteByRoleID(object tran, int RoleID)
        /// <summary>
        /// 根据角色ID删除
        /// pxd 2015-10-15
        /// </summary>
        public bool DeleteByRoleID(object tran, int roleID)
        {
            return dal.DeleteByRoleID(tran, roleID);
        }
        #endregion

        #region 根据角色获取按钮 GetButtonListByRoleID(int roleID, string type)
        /// <summary>
        /// 根据角色获取按钮
        /// pxd 2015-10-16
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetButtonListByRoleID(int roleID, string type)
        {
            return dal.GetButtonListByRoleID(roleID, type);
        }
        #endregion
    }
}