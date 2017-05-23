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
    /// 按钮表
    /// Author 2015-09-22
    /// </summary>
    public class Button
    {
        #region 判断是否存在 Exists(object tran, int BtnID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-09-22
        /// </summary>
        public bool Exists(object tran, int BtnID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Button");
            strSql.Append(" where ");
            strSql.Append(" BtnID = @BtnID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@BtnID", SqlDbType.Int,4)
			};
            parameters[0].Value = BtnID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,ButtonInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Add(object tran, ButtonInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Button(");
            strSql.Append("BtnCode,BtnName,BtnTitle,BtnClick,Icon,Type,Action,Sort");
            strSql.Append(") values (");
            strSql.Append("@BtnCode,@BtnName,@BtnTitle,@BtnClick,@Icon,@Type,@Action,@Sort");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@BtnCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BtnName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BtnTitle", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BtnClick", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Icon", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Action", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.BtnCode;
            parameters[1].Value = model.BtnName;
            parameters[2].Value = model.BtnTitle;
            parameters[3].Value = model.BtnClick;
            parameters[4].Value = model.Icon;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.Action;
            parameters[7].Value = model.Sort;
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

        #region 更新一条数据 Update(object tran,ButtonInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Update(object tran, ButtonInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Button set ");

            strSql.Append("BtnCode=@BtnCode,");
            strSql.Append("BtnName=@BtnName,");
            strSql.Append("BtnTitle=@BtnTitle,");
            strSql.Append("BtnClick=@BtnClick,");
            strSql.Append("Icon=@Icon,");
            strSql.Append("Type=@Type,");
            strSql.Append("Action=@Action,");
            strSql.Append("Sort=@Sort");
            strSql.Append(" where BtnID=@BtnID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@BtnID", SqlDbType.Int,4) ,            
                        new SqlParameter("@BtnCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BtnName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BtnTitle", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BtnClick", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Icon", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Action", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.BtnID;
            parameters[1].Value = model.BtnCode;
            parameters[2].Value = model.BtnName;
            parameters[3].Value = model.BtnTitle;
            parameters[4].Value = model.BtnClick;
            parameters[5].Value = model.Icon;
            parameters[6].Value = model.Type;
            parameters[7].Value = model.Action;
            parameters[8].Value = model.Sort;
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

        #region 删除一条数据 Delete(object tran,int BtnID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Delete(object tran, int BtnID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Button ");
            strSql.Append(" where BtnID=@BtnID");
            SqlParameter[] parameters = {
					new SqlParameter("@BtnID", SqlDbType.Int,4)
			};
            parameters[0].Value = BtnID;


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

        #region 得到一个对象实体 GetModel(object tran,int BtnID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-09-22
        /// </summary>
        public ButtonInfo GetModel(object tran, int BtnID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BtnID,BtnCode,BtnName,BtnTitle,BtnClick,Icon,Type,Action,Sort ");
            strSql.Append(" from Button ");
            strSql.Append(" where BtnID=@BtnID");
            SqlParameter[] parameters = {
					new SqlParameter("@BtnID", SqlDbType.Int,4)
			};
            parameters[0].Value = BtnID;


            ButtonInfo model = new ButtonInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BtnID"].ToString() != "")
                {
                    model.BtnID = int.Parse(ds.Tables[0].Rows[0]["BtnID"].ToString());
                }
                model.BtnCode = ds.Tables[0].Rows[0]["BtnCode"].ToString();
                model.BtnName = ds.Tables[0].Rows[0]["BtnName"].ToString();
                model.BtnTitle = ds.Tables[0].Rows[0]["BtnTitle"].ToString();
                model.BtnClick = ds.Tables[0].Rows[0]["BtnClick"].ToString();
                model.Icon = ds.Tables[0].Rows[0]["Icon"].ToString();
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                model.Action = ds.Tables[0].Rows[0]["Action"].ToString();
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
            strSql.Append("select a.BtnID,a.BtnCode,a.BtnName,a.BtnTitle,a.BtnClick,a.Icon,a.Type,a.Action,a.Sort ");
            strSql.Append(" from Button a");

            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, null, null, null, null);
            return dtReturn;
        }
        #endregion

        #region 获得数据列表 GetList(string btnCode,string btnName)
        /// <summary>
        /// 获得数据列表
        /// pxd 2015-09-22
        /// </summary>
        /// <param name="btnCode"></param>
        /// <param name="btnName"></param>
        /// <returns></returns>
        public DataTable GetList(string btnCode, string btnName)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.BtnID,a.BtnCode,a.BtnName,a.BtnTitle,a.BtnClick,a.Icon,a.Type,a.Action,a.Sort ");
            strSql.Append(" from Button a");
            strSql.Append(" where 1=1");
            
            List<SqlParameter> parameter = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(btnCode))
            {
                strSql.Append(" and a.BtnCode like @BtnCode");
                parameter.Add(new SqlParameter("@BtnCode", "%" + btnCode + "%"));
            }
            if (!string.IsNullOrEmpty(btnName))
            {
                strSql.Append(" and a.BtnName like @BtnName");
                parameter.Add(new SqlParameter("@BtnName", "%" + btnName + "%"));
            }
            strSql.Append(" order by Sort");

            dtReturn = SQLHelper.GetDataSet(strSql.ToString(), parameter.ToArray()).Tables[0];
            return dtReturn;
        }
        #endregion

        #region 判断按钮是否已经被引用 IsRelation(int btnID)
        /// <summary>
        /// 判断按钮是否已经被引用
        /// pxd 2015-09-22
        /// </summary>
        /// <param name="btnID"></param>
        /// <returns></returns>
        public bool IsRelation(int btnID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from(");
            strSql.Append(" select ModID,BtnID from ModuleButton where BtnID=@BtnID");
            strSql.Append(" union select ModID,BtnID from RoleModButton where BtnID=@BtnID");
            strSql.Append(" )aa");

            SqlParameter[] parameters = { new SqlParameter("@BtnID", btnID)};

            object obj = SQLHelper.ExecuteScalar(strSql.ToString(), parameters);
            if (Convert.ToInt32(obj) > 0)
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
