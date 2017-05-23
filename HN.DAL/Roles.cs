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
    /// 角色表
    /// Author 2015-08-11
    /// </summary>
    public class Roles
    {
        #region 判断是否存在 Exists(object tran, string RoleName)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, string RoleName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Roles");
            strSql.Append(" where ");
            strSql.Append(" RoleName = @RoleName  ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName",RoleName)
			};

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,RolesInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, RolesInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Roles(");
            strSql.Append("RoleName,IsDefault,Sort,Remark");
            strSql.Append(") values (");
            strSql.Append("@RoleName,@IsDefault,@Sort,@Remark");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@RoleName", SqlDbType.NVarChar,50) ,  
                        new SqlParameter("@IsDefault", SqlDbType.Int,4) ,     
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200)             
             };

            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.IsDefault;
            parameters[2].Value = model.Sort;
            parameters[3].Value = model.Remark;
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

        #region 更新一条数据 Update(object tran,RolesInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, RolesInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Roles set ");

            strSql.Append("RoleName=@RoleName,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where RoleID=@RoleID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@RoleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200)             
             };

            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.RoleName;
            parameters[2].Value = model.Sort;
            parameters[3].Value = model.Remark;
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

        #region 删除一条数据 Delete(object tran,int RoleID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Roles ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleID;


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

        #region 得到一个对象实体 GetModel(object tran,int RoleID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-08-11
        /// </summary>
        public RolesInfo GetModel(object tran, int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleID,RoleName,IsDefault,Sort,Remark ");
            strSql.Append(" from Roles ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleID;


            RolesInfo model = new RolesInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                model.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                if (ds.Tables[0].Rows[0]["IsDefault"].ToString() != "")
                {
                    model.IsDefault = int.Parse(ds.Tables[0].Rows[0]["IsDefault"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();

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
            strSql.Append("select a.RoleID,a.RoleName,a.IsDefault,a.Sort,a.Remark ");
            strSql.Append(" from Roles a");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" Order by a.Sort");
            dtReturn = SQLHelper.GetDataSet(strSql.ToString()).Tables[0];

            return dtReturn;
        }
        #endregion

    }
}

