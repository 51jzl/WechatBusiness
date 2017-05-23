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
    /// 用户角色表
    /// Author 2015-09-10
    /// </summary>
    public class UsersRole
    {
        #region 判断是否存在 Exists(object tran, int UserID,int RoleID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-09-10
        /// </summary>
        public bool Exists(object tran, int UserID, int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UsersRole");
            strSql.Append(" where ");
            strSql.Append(" UserID = @UserID and  ");
            strSql.Append(" RoleID = @RoleID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4)			};
            parameters[0].Value = UserID;
            parameters[1].Value = RoleID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,UsersRoleInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-09-10
        /// </summary>
        public bool Add(object tran, UsersRoleInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UsersRole(");
            strSql.Append("UserID,RoleID");
            strSql.Append(") values (");
            strSql.Append("@UserID,@RoleID");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleID", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.UserID;
            parameters[1].Value = model.RoleID;
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

        #region 更新一条数据 Update(object tran,UsersRoleInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-09-10
        /// </summary>
        public bool Update(object tran, UsersRoleInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UsersRole set ");

            strSql.Append("UserID=@UserID,");
            strSql.Append("RoleID=@RoleID");
            strSql.Append(" where UserID=@UserID and RoleID=@RoleID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleID", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.UserID;
            parameters[1].Value = model.RoleID;
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

        #region 删除一条数据 Delete(object tran,int UserID,int RoleID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-09-10
        /// </summary>
        public bool Delete(object tran, int UserID, int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UsersRole ");
            strSql.Append(" where UserID=@UserID and RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4)			};
            parameters[0].Value = UserID;
            parameters[1].Value = RoleID;


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

        #region 得到一个对象实体 GetModel(object tran,int UserID,int RoleID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-09-10
        /// </summary>
        public UsersRoleInfo GetModel(object tran, int UserID, int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,RoleID ");
            strSql.Append(" from UsersRole ");
            strSql.Append(" where UserID=@UserID and RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4)			};
            parameters[0].Value = UserID;
            parameters[1].Value = RoleID;


            UsersRoleInfo model = new UsersRoleInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
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
        /// Author 2015-09-10
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.UserID,a.RoleID ");
            strSql.Append(" from UsersRole a");

            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, null, null, null, null);
            return dtReturn;
        }
        #endregion

        #region 判断角色是否存在用户 ExistsByRoleID(object tran,int roleID)
        /// <summary>
        /// 判断角色是否存在用户
        /// pxd 2015-10-15
        /// </summary>
        public bool ExistsByRoleID(object tran, int roleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UsersRole");
            strSql.Append(" where ");
            strSql.Append(" RoleID = @RoleID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)			};
            parameters[0].Value = roleID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
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
        public DataTable GetUserByRoleID(string strKey, int roleID,string orgID, int type, bool bAdmin)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.UserID,a.UserCode,a.UserName from Users a");
            strSql.Append(" left join UsersRole b on a.UserID=b.UserID and b.RoleID=@RoleID");
            strSql.Append(" where a.DeleteMark=0");

            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@RoleID", roleID));

            if (!string.IsNullOrEmpty(strKey))
            {
                strSql.Append(" and a.UserName like @UserName");
                strSql.Append(" or a.UserCode like @UserName");
                parameter.Add(new SqlParameter("@UserName", "%" + strKey + "%"));
            }
            if (!string.IsNullOrEmpty(orgID))
            {
                strSql.Append(" and a.UserID in(select UserID from UsersOrganize where OrgID=@OrgID)");
                parameter.Add(new SqlParameter("@OrgID", orgID));
            }
            strSql.Append(" and b.RoleID is " + (type == 0 ? "" : "not") + " null");
            if (!bAdmin)
            {
                strSql.Append(" and a.IsAdmin=0");
            }

            dtReturn = SQLHelper.GetDataSet(strSql.ToString(), parameter.ToArray()).Tables[0];
            return dtReturn;
        }
        #endregion
    }
}

