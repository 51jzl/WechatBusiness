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
    /// 字典主表
    /// Author 2015-08-11
    /// </summary>
    public class DictKey
    {
        #region 判断是否存在 Exists(object tran, int KeyID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int KeyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DictKey");
            strSql.Append(" where ");
            strSql.Append(" KeyID = @KeyID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
            parameters[0].Value = KeyID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,DictKeyInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, DictKeyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DictKey(");
            strSql.Append("KeyName,Sort,Remark");
            strSql.Append(") values (");
            strSql.Append("@KeyName,@Sort,@Remark");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@KeyName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200)             
             };

            parameters[0].Value = model.KeyName;
            parameters[1].Value = model.Sort;
            parameters[2].Value = model.Remark;
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

        #region 更新一条数据 Update(object tran,DictKeyInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, DictKeyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DictKey set ");

            strSql.Append("KeyName=@KeyName,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where KeyID=@KeyID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@KeyID", SqlDbType.Int,4) ,            
                        new SqlParameter("@KeyName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200)             
             };

            parameters[0].Value = model.KeyID;
            parameters[1].Value = model.KeyName;
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

        #region 删除一条数据 Delete(object tran,int KeyID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int KeyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DictKey ");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
            parameters[0].Value = KeyID;


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

        #region 得到一个对象实体 GetModel(object tran,int KeyID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-08-11
        /// </summary>
        public DictKeyInfo GetModel(object tran, int KeyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select KeyID,KeyName,Sort,Remark ");
            strSql.Append(" from DictKey ");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
            parameters[0].Value = KeyID;


            DictKeyInfo model = new DictKeyInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["KeyID"].ToString() != "")
                {
                    model.KeyID = int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
                }
                model.KeyName = ds.Tables[0].Rows[0]["KeyName"].ToString();
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
            strSql.Append("select a.KeyID,a.KeyName,a.Sort,a.Remark ");
            strSql.Append(" from DictKey a");
            strSql.Append(" order by sort");
            dtReturn = SQLHelper.GetDataSet(strSql.ToString(),null).Tables[0];
            return dtReturn;
        }
        #endregion

    }
}

