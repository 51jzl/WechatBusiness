using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;

namespace HN.BLL
{
    /// <summary>
    /// 用户部门关系表
    /// Author 2015-08-11
    /// </summary>
    public class UsersOrganize
    {
        private readonly DAL.UsersOrganize dal = new DAL.UsersOrganize();
        public UsersOrganize()
        { }

        #region 是否存在该记录 Exists(object tran,int UserID,int OrgID)
        /// <summary>
        /// 是否存在该记录
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int UserID, int OrgID)
        {
            return dal.Exists(tran, UserID, OrgID);
        }
        #endregion

        #region 增加一条数据 Add(object tran,UsersOrganizeInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, UsersOrganizeInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,UsersOrganizeInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, UsersOrganizeInfo model)
        {
            return dal.Update(tran, model);
        }
        #endregion

        #region  删除一条数据 Delete(object tran,int UserID,int OrgID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int UserID, int OrgID)
        {
            return dal.Delete(tran, UserID, OrgID);
        }
        #endregion

        #region 得到一个对象实体 UsersOrganizeInfo GetModel(object tran,int UserID,int OrgID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UsersOrganizeInfo GetModel(object tran, int UserID, int OrgID)
        {
            return dal.GetModel(tran, UserID, OrgID);
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

        #region 根据组织ID判断是否存在用户 ExistsUserByOrgID(object tran,int orgID)
        /// <summary>
        /// 根据组织ID判断是否存在用户
        /// pxd 2015-10-21
        /// </summary>
        public bool ExistsUserByOrgID(object tran, int orgID)
        {
            return dal.ExistsUserByOrgID(tran, orgID);
        }
        #endregion

        #region 根据用户ID获取所有组织及用户所在的组织 GetUserOrg(int userID)
        /// <summary>
        /// 根据用户ID获取所有组织及用户所在的组织
        /// pxd 2015-10-23
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetUserOrg(int userID)
        {
            return dal.GetUserOrg(userID);
        }

        #endregion

        #region 判断用户是否已选择组织 ExistsByUserID(object tran, int userID)
        /// <summary>
        /// 判断用户是否已选择组织
        /// pxd 2015-10-23
        /// </summary>
        public bool ExistsByUserID(object tran, int userID)
        {
            return dal.ExistsByUserID(tran, userID);
        }
        #endregion

        #region 删除用户所在的组织 DeleteByUserID(object tran, int userID)
        /// <summary>
        /// 判断用户是否已选择组织
        /// pxd 2015-10-23
        /// </summary>
        public bool DeleteByUserID(object tran, int userID)
        {
            return dal.DeleteByUserID(tran, userID);
        }
        #endregion
    }
}