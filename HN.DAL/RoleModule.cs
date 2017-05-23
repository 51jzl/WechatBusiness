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
    /// 角色节点权限
    /// Author 2015-08-11
    /// </summary>
    public class RoleModule
    {
        #region 判断是否存在 Exists(object tran, int RoleID,int ModID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int RoleID, int ModID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RoleModule");
            strSql.Append(" where ");
            strSql.Append(" RoleID = @RoleID and  ");
            strSql.Append(" ModID = @ModID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ModID", SqlDbType.Int,4)			};
            parameters[0].Value = RoleID;
            parameters[1].Value = ModID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,RoleModuleInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, RoleModuleInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RoleModule(");
            strSql.Append("RoleID,ModID");
            strSql.Append(") values (");
            strSql.Append("@RoleID,@ModID");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@RoleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModID", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.ModID;
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

        #region 更新一条数据 Update(object tran,RoleModuleInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, RoleModuleInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoleModule set ");

            strSql.Append("RoleID=@RoleID,");
            strSql.Append("ModID=@ModID");
            strSql.Append(" where RoleID=@RoleID and ModID=@ModID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@RoleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModID", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.ModID;
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

        #region 删除一条数据 Delete(object tran,int RoleID,int ModID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int RoleID, int ModID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RoleModule ");
            strSql.Append(" where RoleID=@RoleID and ModID=@ModID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ModID", SqlDbType.Int,4)			};
            parameters[0].Value = RoleID;
            parameters[1].Value = ModID;


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

        #region 得到一个对象实体 GetModel(object tran,int RoleID,int ModID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-08-11
        /// </summary>
        public RoleModuleInfo GetModel(object tran, int RoleID, int ModID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleID,ModID ");
            strSql.Append(" from RoleModule ");
            strSql.Append(" where RoleID=@RoleID and ModID=@ModID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ModID", SqlDbType.Int,4)			};
            parameters[0].Value = RoleID;
            parameters[1].Value = ModID;


            RoleModuleInfo model = new RoleModuleInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModID"].ToString() != "")
                {
                    model.ModID = int.Parse(ds.Tables[0].Rows[0]["ModID"].ToString());
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
            strSql.Append("select a.RoleID,a.ModID ");
            strSql.Append(" from RoleModule a");

            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, null, null, null, null);
            return dtReturn;
        }
        #endregion

        #region 根据登录人获取节点 GetRoleModuleList(int userID, string type)
        /// <summary>
        /// 根据登录人获取节点
        /// pxd 2015-09-20
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetRoleModuleList(int userID, string type)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.ModID,a.ParentID,a.ModName,a.ModTitle,a.Icon,a.Link,a.Sort");
            strSql.Append(" from Module a");
            strSql.Append(" inner join RoleModule b on a.ModID=b.ModID");
            strSql.Append(" inner join Roles c on c.RoleID=b.RoleID");
            strSql.Append(" inner join UsersRole d on c.RoleID=d.RoleID and d.UserID=@UserID");
            strSql.Append(" where a.Targe='Iframe' and a.IsEnable=1");
            if (!string.IsNullOrEmpty(type))
            {
                strSql.Append(" and a.Type=" + type + "");
            }
            strSql.Append(" group by a.ModID,a.ParentID,a.ModName,a.ModTitle,a.Icon,a.Link,a.Sort");
            strSql.Append(" order by a.Sort");

            SqlParameter[] parameters = { new SqlParameter("@UserID", userID), };

            dtReturn = SQLHelper.GetDataSet(null, strSql.ToString(), parameters).Tables[0];
            return dtReturn;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.RoleID,a.ModID from Module a");
            strSql.Append(" inner join RoleModule b on a.ModID=b.ModID ");
            strSql.Append(" inner join UsersRole c on b.RoleID=c.RoleID");
            strSql.Append(" where c.UserID=@UserID");
            strSql.Append(" and a.Link=@Link");
            strSql.Append(" and a.IsEnable=1");

            SqlParameter[] parameters = { new SqlParameter("@UserID", userID),
                                        new SqlParameter("@Link", link),};
            DataTable dtReturn = SQLHelper.GetDataSet(strSql.ToString(), parameters).Tables[0];

            return dtReturn;
        }
        #endregion

        #region 判断菜单是否已关联角色 IsRelate(object tran,int ModID)
        /// <summary>
        /// 判断菜单是否已关联角色
        /// pxd 2015-10-14
        /// </summary>
        public bool IsRelate(object tran, int ModID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RoleModule");
            strSql.Append(" where ");
            strSql.Append(" ModID = @ModID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModID", SqlDbType.Int,4)			};
            parameters[0].Value = ModID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 根据角色ID判断是否存在 ExistsByRoleID(object tran, int roleID)
        /// <summary>
        /// 根据角色ID判断是否存在
        /// pxd 2015-10-15
        /// </summary>
        public bool ExistsByRoleID(object tran, int roleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RoleModule");
            strSql.Append(" where RoleID = @RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)		};
            parameters[0].Value = roleID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 根据角色ID删除 DeleteByRoleID(object tran, int RoleID)
        /// <summary>
        /// 根据角色ID删除
        /// pxd 2015-10-15
        /// </summary>
        public bool DeleteByRoleID(object tran, int roleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RoleModule ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)	};
            parameters[0].Value = roleID;

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

        #region 根据角色获取菜单节点-角色分配权限时调用 GetModuleListByRoleID(int roleID, string type)
        /// <summary>
        /// 根据角色获取菜单节点
        /// pxd 2015-10-16
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public DataTable GetModuleListByRoleID(int roleID, string type)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.ModID,a.ParentID,a.ModName,a.Icon,b.RoleID,a.Sort,'' ButtonList");
            strSql.Append(" from Module a");
            strSql.Append(" left join RoleModule b on a.ModID=b.ModID and b.RoleID=@RoleID");
            strSql.Append(" where a.Targe='Iframe' and a.IsEnable=1");
            if (!string.IsNullOrEmpty(type))
            {
                strSql.Append(" and a.Type=" + type + "");
            }
   
            SqlParameter[] parameters = { new SqlParameter("@RoleID", roleID), };

            dtReturn = SQLHelper.GetDataSet(null, strSql.ToString(), parameters).Tables[0];
            return dtReturn;
        }
        #endregion
    }
}

