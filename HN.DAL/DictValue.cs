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
    /// 字典表子表
    /// Author 2015-08-11
    /// </summary>
    public class DictValue
    {
        #region 判断是否存在 Exists(object tran, int ValID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int ValID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DictValue");
            strSql.Append(" where ");
            strSql.Append(" ValID = @ValID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ValID", SqlDbType.Int,4)
			};
            parameters[0].Value = ValID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,DictValueInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, DictValueInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DictValue(");
            strSql.Append("KeyID,ValName,FirstPY,Sort,Remark");
            strSql.Append(") values (");
            strSql.Append("@KeyID,@ValName,@FirstPY,@Sort,@Remark");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@KeyID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ValName", SqlDbType.NVarChar,50) , 
                        new SqlParameter("@FirstPY", SqlDbType.VarChar,50) , 
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200)             
             };

            parameters[0].Value = model.KeyID;
            parameters[1].Value = model.ValName;
            parameters[2].Value = model.FirstPY;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.Remark;
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

        #region 更新一条数据 Update(object tran,DictValueInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, DictValueInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DictValue set ");

            strSql.Append("ValName=@ValName,");
            strSql.Append("FirstPY=@FirstPY,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ValID=@ValID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ValID", SqlDbType.Int,4) ,                        
                        new SqlParameter("@ValName", SqlDbType.NVarChar,50) ,   
                        new SqlParameter("@FirstPY", SqlDbType.VarChar,50) ,  
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200)             
             };

            parameters[0].Value = model.ValID;
            parameters[1].Value = model.ValName;
            parameters[2].Value = model.FirstPY;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.Remark;
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

        #region 删除一条数据 Delete(object tran,int ValID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int ValID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DictValue ");
            strSql.Append(" where ValID=@ValID");
            SqlParameter[] parameters = {
					new SqlParameter("@ValID", SqlDbType.Int,4)
			};
            parameters[0].Value = ValID;


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

        #region 得到一个对象实体 GetModel(object tran,int ValID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-08-11
        /// </summary>
        public DictValueInfo GetModel(object tran, int ValID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ValID,KeyID,ValName,FirstPY,Sort,Remark ");
            strSql.Append(" from DictValue ");
            strSql.Append(" where ValID=@ValID");
            SqlParameter[] parameters = {
					new SqlParameter("@ValID", SqlDbType.Int,4)
			};
            parameters[0].Value = ValID;

            DictValueInfo model = new DictValueInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ValID"].ToString() != "")
                {
                    model.ValID = int.Parse(ds.Tables[0].Rows[0]["ValID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KeyID"].ToString() != "")
                {
                    model.KeyID = int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
                }
                model.ValName = ds.Tables[0].Rows[0]["ValName"].ToString();
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
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
            strSql.Append("select a.ValID,a.KeyID,a.ValName,a.FirstPY,a.Sort,a.Remark ");
            strSql.Append(" from DictValue a");

            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, null, null, null, null);
            return dtReturn;
        }
        #endregion

        #region 根据关键字查询值列表 GetValueList(string keyID, int pageSize, int pageIndex)
        /// <summary>
        /// 根据关键字查询值列表
        /// pxd 2015-09-26
        /// </summary>
        /// <param name="keyID"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable GetValueList(string keyID, int pageSize, int pageIndex)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.ValID,a.ValName,a.FirstPY,a.Sort,a.Remark,b.KeyName,b.Sort SortK ");
            strSql.Append(" from DictValue a");
            strSql.Append(" inner join DictKey b on a.KeyID=b.KeyID");
            string strWhere = null;
            SqlParameter[] parameter = null;

            if (!string.IsNullOrEmpty(keyID))
            {
                strWhere += " a.KeyID=@KeyID";
                parameter = new[] { new SqlParameter("@KeyID", keyID) };
            }

            string strOrderBy = "SortK,Sort";
            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, parameter, strOrderBy, pageSize, pageIndex);
            return dtReturn;
        }


        #endregion

        #region 判断值是否存在 ExistsValName(object tran, int keyID,string valName)
        /// <summary>
        /// 判断值是否存在
        /// pxd 2015-09-26
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool ExistsValName(object tran, int keyID, string valName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Count(1) from DictValue");
            strSql.Append(" where KeyID=@KeyID");
            strSql.Append(" and ValName=@ValName");
            SqlParameter[] parameters = {
                    new SqlParameter("@KeyID", keyID),
					new SqlParameter("@ValName", valName),
			};
            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
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

        #region 根据关键字查询选项值 GetListByKey(string keyName,bool bf,string ftext)
        /// <summary>
        /// 根据关键字查询选项值
        /// pxd 2015-10-27
        /// </summary>
        public List<DictValueInfo> GetListByKey(string keyName, bool bf, string ftext)
        {
            List<DictValueInfo> modelList = new List<DictValueInfo>();
            StringBuilder strSql = new StringBuilder();
            if (bf)
            {
                strSql.Append("select '' Remark,'" + ftext + "' ValName,-1 Sort union all");
            }
            strSql.Append(" select a.ValName Remark,a.ValName,a.Sort from DictValue a");
            strSql.Append(" inner join DictKey b on a.KeyID=b.KeyID and b.KeyName=@KeyName");
            strSql.Append(" order by Sort");

            SqlParameter[] parameter = { new SqlParameter("@KeyName", keyName) };

            DataTable dt = SQLHelper.GetDataSet(strSql.ToString(), parameter).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DictValueInfo model = new DictValueInfo();
                model.Remark = dt.Rows[i]["Remark"].ToString();
                model.ValName = dt.Rows[i]["ValName"].ToString();
                modelList.Add(model);
            }
            return modelList;
        }
        #endregion

    }
}

