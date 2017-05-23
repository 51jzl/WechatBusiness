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
    /// 拼音表
    /// Author 2015-08-11
    /// </summary>
    public class CharPY
    {
        #region 判断是否存在 Exists(object tran, int PYID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int PYID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CharPY");
            strSql.Append(" where ");
            strSql.Append(" PYID = @PYID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@PYID", SqlDbType.Int,4)
			};
            parameters[0].Value = PYID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,CharPYInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, CharPYInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CharPY(");
            strSql.Append("CharName,PY,FirstPY");
            strSql.Append(") values (");
            strSql.Append("@CharName,@PY,@FirstPY");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@CharName", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@PY", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@FirstPY", SqlDbType.Char,1)             
             };

            parameters[0].Value = model.CharName;
            parameters[1].Value = model.PY;
            parameters[2].Value = model.FirstPY;
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

        #region 更新一条数据 Update(object tran,CharPYInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, CharPYInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CharPY set ");

            strSql.Append("CharName=@CharName,");
            strSql.Append("PY=@PY,");
            strSql.Append("FirstPY=@FirstPY");
            strSql.Append(" where PYID=@PYID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@PYID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CharName", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@PY", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@FirstPY", SqlDbType.Char,1)             
             };

            parameters[0].Value = model.PYID;
            parameters[1].Value = model.CharName;
            parameters[2].Value = model.PY;
            parameters[3].Value = model.FirstPY;
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

        #region 删除一条数据 Delete(object tran,int PYID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int PYID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CharPY ");
            strSql.Append(" where PYID=@PYID");
            SqlParameter[] parameters = {
					new SqlParameter("@PYID", SqlDbType.Int,4)
			};
            parameters[0].Value = PYID;


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

        #region 得到一个对象实体 GetModel(object tran,int PYID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-08-11
        /// </summary>
        public CharPYInfo GetModel(object tran, int PYID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PYID,CharName,PY,FirstPY ");
            strSql.Append(" from CharPY ");
            strSql.Append(" where PYID=@PYID");
            SqlParameter[] parameters = {
					new SqlParameter("@PYID", SqlDbType.Int,4)
			};
            parameters[0].Value = PYID;


            CharPYInfo model = new CharPYInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PYID"].ToString() != "")
                {
                    model.PYID = int.Parse(ds.Tables[0].Rows[0]["PYID"].ToString());
                }
                model.CharName = ds.Tables[0].Rows[0]["CharName"].ToString();
                model.PY = ds.Tables[0].Rows[0]["PY"].ToString();
                model.FirstPY = ds.Tables[0].Rows[0]["FirstPY"].ToString();

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
            strSql.Append("select a.PYID,a.CharName,a.PY,a.FirstPY ");
            strSql.Append(" from CharPY a");

            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, null, null, null, null);
            return dtReturn;
        }
        #endregion

        #region 获取拼音首字母 GetFirstPY(string strName)
        /// <summary>
        /// 获取拼音首字母
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns></returns>
        public string GetFirstPY(string strName)
        {
            string strSql = "Select dbo.FUN_GETFIRSTPY(@Name) FirstPY";
            SqlParameter[] parameters ={
                                      new SqlParameter("@Name",strName)
            };
            object obj = SQLHelper.ExecuteScalar(strSql, parameters);
            string strReturn = "";
            if (obj != null)
            {
                strReturn = obj.ToString();
            }
            return strReturn;
        }
        #endregion
    }
}

