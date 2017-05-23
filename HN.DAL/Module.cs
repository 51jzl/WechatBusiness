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
    /// 模块表
    /// Author 2015-09-22
    /// </summary>
    public class Module
    {
        #region 判断是否存在 Exists(object tran, int ModID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-09-22
        /// </summary>
        public bool Exists(object tran, int ModID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Module");
            strSql.Append(" where ");
            strSql.Append(" ModID = @ModID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModID", SqlDbType.Int,4)
			};
            parameters[0].Value = ModID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,ModuleInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Add(object tran, ModuleInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Module(");
            strSql.Append("ParentID,Targe,ModName,ModTitle,Link,Icon,IsEnd,IsEnable,Type,Sort");
            strSql.Append(") values (");
            strSql.Append("@ParentID,@Targe,@ModName,@ModTitle,@Link,@Icon,@IsEnd,@IsEnable,@Type,@Sort");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ParentID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Targe", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@ModName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@ModTitle", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@Link", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Icon", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@IsEnd", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@IsEnable", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.Targe;
            parameters[2].Value = model.ModName;
            parameters[3].Value = model.ModTitle;
            parameters[4].Value = model.Link;
            parameters[5].Value = model.Icon;
            parameters[6].Value = model.IsEnd;
            parameters[7].Value = model.IsEnable;
            parameters[8].Value = model.Type;
            parameters[9].Value = model.Sort;
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

        #region 更新一条数据 Update(object tran,ModuleInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Update(object tran, ModuleInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Module set ");

            strSql.Append("ParentID=@ParentID,");
            strSql.Append("Targe=@Targe,");
            strSql.Append("ModName=@ModName,");
            strSql.Append("ModTitle=@ModTitle,");
            strSql.Append("Link=@Link,");
            strSql.Append("Icon=@Icon,");
            strSql.Append("IsEnd=@IsEnd,");
            strSql.Append("IsEnable=@IsEnable,");
            strSql.Append("Type=@Type,");
            strSql.Append("Sort=@Sort");
            strSql.Append(" where ModID=@ModID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ModID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ParentID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Targe", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@ModName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@ModTitle", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@Link", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Icon", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@IsEnd", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@IsEnable", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.ModID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.Targe;
            parameters[3].Value = model.ModName;
            parameters[4].Value = model.ModTitle;
            parameters[5].Value = model.Link;
            parameters[6].Value = model.Icon;
            parameters[7].Value = model.IsEnd;
            parameters[8].Value = model.IsEnable;
            parameters[9].Value = model.Type;
            parameters[10].Value = model.Sort;
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

        #region 删除一条数据 Delete(object tran,int ModID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Delete(object tran, int ModID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Module ");
            strSql.Append(" where ModID=@ModID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModID", SqlDbType.Int,4)
			};
            parameters[0].Value = ModID;


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

        #region 得到一个对象实体 GetModel(object tran,int ModID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-09-22
        /// </summary>
        public ModuleInfo GetModel(object tran, int ModID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModID,ParentID,Targe,ModName,ModTitle,Link,Icon,IsEnd,IsEnable,Type,Sort ");
            strSql.Append(" from Module ");
            strSql.Append(" where ModID=@ModID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModID", SqlDbType.Int,4)
			};
            parameters[0].Value = ModID;


            ModuleInfo model = new ModuleInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ModID"].ToString() != "")
                {
                    model.ModID = int.Parse(ds.Tables[0].Rows[0]["ModID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                model.Targe = ds.Tables[0].Rows[0]["Targe"].ToString();
                model.ModName = ds.Tables[0].Rows[0]["ModName"].ToString();
                model.ModTitle = ds.Tables[0].Rows[0]["ModTitle"].ToString();
                model.Link = ds.Tables[0].Rows[0]["Link"].ToString();
                model.Icon = ds.Tables[0].Rows[0]["Icon"].ToString();
                if (ds.Tables[0].Rows[0]["IsEnd"].ToString() != "")
                {
                    model.IsEnd = int.Parse(ds.Tables[0].Rows[0]["IsEnd"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsEnable"].ToString() != "")
                {
                    model.IsEnable = int.Parse(ds.Tables[0].Rows[0]["IsEnable"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
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
        /// Author 2015-09-22
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.ModID,a.ParentID,a.Targe,a.ModName,a.ModTitle,a.Link,a.Icon,a.IsEnd,a.IsEnable,a.Type,a.Sort ");
            strSql.Append(" from Module a");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where "+strWhere);
            }
            strSql.Append(" order by Sort");
            dtReturn = SQLHelper.GetDataSet(strSql.ToString(),null).Tables[0];
            return dtReturn;
        }
        #endregion

        #region 判断是否存在下级菜单 ExistsChildren(object tran, int ModID)
        /// <summary>
        /// 判断是否存在下级菜单
        /// Author 2015-09-22
        /// </summary>
        public bool ExistsChildren(object tran, int ModID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Module");
            strSql.Append(" where ");
            strSql.Append(" ParentID = @ModID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModID", SqlDbType.Int,4)
			};
            parameters[0].Value = ModID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion
    }
}

