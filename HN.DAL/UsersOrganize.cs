using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using HN.Utility;
using HN.Model;

namespace HN.DAL
{
    /// <summary>
    /// 用户部门关系表
    /// Author 2015-08-11
    /// </summary>
    public class UsersOrganize
    {
        #region 判断是否存在 Exists(object tran, int UserID,int OrgID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int UserID, int OrgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UsersOrganize");
            strSql.Append(" where ");
            strSql.Append(" UserID = @UserID and  ");
            strSql.Append(" OrgID = @OrgID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@OrgID", SqlDbType.Int,4)			};
            parameters[0].Value = UserID;
            parameters[1].Value = OrgID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,UsersOrganizeInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, UsersOrganizeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UsersOrganize(");
            strSql.Append("UserID,OrgID");
            strSql.Append(") values (");
            strSql.Append("@UserID,@OrgID");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@OrgID", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.UserID;
            parameters[1].Value = model.OrgID;
            int rows = SQLHelper.ExecuteNonQuery((SqlTransaction)tran, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 更新一条数据 Update(object tran,UsersOrganizeInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, UsersOrganizeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UsersOrganize set ");

            strSql.Append("UserID=@UserID,");
            strSql.Append("OrgID=@OrgID");
            strSql.Append(" where UserID=@UserID and OrgID=@OrgID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@OrgID", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.UserID;
            parameters[1].Value = model.OrgID;
            int rows = SQLHelper.ExecuteNonQuery((SqlTransaction)tran, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 删除一条数据 Delete(object tran,int UserID,int OrgID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int UserID, int OrgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UsersOrganize ");
            strSql.Append(" where UserID=@UserID and OrgID=@OrgID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@OrgID", SqlDbType.Int,4)			};
            parameters[0].Value = UserID;
            parameters[1].Value = OrgID;


            int rows = SQLHelper.ExecuteNonQuery((SqlTransaction)tran, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 得到一个对象实体 GetModel(object tran,int UserID,int OrgID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-08-11
        /// </summary>
        public UsersOrganizeInfo GetModel(object tran, int UserID, int OrgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,OrgID ");
            strSql.Append(" from UsersOrganize ");
            strSql.Append(" where UserID=@UserID and OrgID=@OrgID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@OrgID", SqlDbType.Int,4)			};
            parameters[0].Value = UserID;
            parameters[1].Value = OrgID;


            UsersOrganizeInfo model = new UsersOrganizeInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrgID"].ToString() != "")
                {
                    model.OrgID = int.Parse(ds.Tables[0].Rows[0]["OrgID"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 获得数据列表 GetList(string strWhere)
        /// <summary>
        /// 示例 获得数据列表，根据业务需求自定义查询条件
        /// Author 2015-08-11
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.UserID,a.OrgID ");
            strSql.Append(" from UsersOrganize a");

            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, null, null, null, null);
            return dtReturn;
        }
        #endregion

        #region 根据组织ID判断是否存在用户 ExistsUserByOrgID(object tran,int orgID)
        /// <summary>
        /// 根据组织ID判断是否存在用户
        /// pxd 2015-10-21
        /// </summary>
        public bool ExistsUserByOrgID(object tran, int orgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UsersOrganize");
            strSql.Append(" where ");
            strSql.Append(" OrgID = @OrgID  ");
            SqlParameter[] parameters = { new SqlParameter("@OrgID", SqlDbType.Int, 4) };
            parameters[0].Value = orgID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 获取用户所在的组织 GetUserOrg(int userID)
        /// <summary>
        /// 根据用户ID获取所有组织及用户所在的组织
        /// pxd 2015-10-23
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetUserOrg(int userID)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.OrgID,a.OrgName,a.OrgCode,a.Manager,a.ParentID,a.Sort,b.OrgID Chk");
            strSql.Append(" from Organization a ");
            strSql.Append(" left join UsersOrganize b on a.OrgID=b.OrgID and b.UserID=@UserID");
            SqlParameter[] parameters = { new SqlParameter("@UserID", userID) };
            dtReturn = SQLHelper.GetDataSet(strSql.ToString(), parameters).Tables[0];
            return dtReturn;
        }

        #endregion

        #region 判断用户是否已选择组织 ExistsByUserID(object tran, int userID)
        /// <summary>
        /// 判断用户是否已选择组织
        /// pxd 2015-10-23
        /// </summary>
        public bool ExistsByUserID(object tran, int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UsersOrganize");
            strSql.Append(" where ");
            strSql.Append(" UserID = @UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = userID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 删除用户所在的组织 DeleteByUserID(object tran, int userID)
        /// <summary>
        /// 判断用户是否已选择组织
        /// pxd 2015-10-23
        /// </summary>
        public bool DeleteByUserID(object tran, int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UsersOrganize ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = userID;

            int rows = SQLHelper.ExecuteNonQuery((SqlTransaction)tran, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}

