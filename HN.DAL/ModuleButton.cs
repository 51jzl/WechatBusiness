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
    /// 页面按钮表
    /// Author 2015-09-22
    /// </summary>
    public class ModuleButton
    {
        #region 判断是否存在 Exists(object tran, int ModID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-09-22
        /// </summary>
        public bool Exists(object tran, int ModID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ModuleButton");
            strSql.Append(" where ");
            strSql.Append(" ModID = @ModID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModID", SqlDbType.Int,4)	};
            parameters[0].Value = ModID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,ModuleButtonInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Add(object tran, ModuleButtonInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ModuleButton(");
            strSql.Append("ModID,BtnID");
            strSql.Append(") values (");
            strSql.Append("@ModID,@BtnID");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ModID", SqlDbType.Int,4) ,            
                        new SqlParameter("@BtnID", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.ModID;
            parameters[1].Value = model.BtnID;
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

        #region 更新一条数据 Update(object tran,ModuleButtonInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Update(object tran, ModuleButtonInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ModuleButton set ");

            strSql.Append("ModID=@ModID,");
            strSql.Append("BtnID=@BtnID");
            strSql.Append(" where ModID=@ModID and BtnID=@BtnID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ModID", SqlDbType.Int,4) ,            
                        new SqlParameter("@BtnID", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.ModID;
            parameters[1].Value = model.BtnID;
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
            strSql.Append("delete from ModuleButton ");
            strSql.Append(" where ModID=@ModID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModID", SqlDbType.Int,4)		};
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

        #region 得到一个对象实体 GetModel(object tran,int ModID,int BtnID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-09-22
        /// </summary>
        public ModuleButtonInfo GetModel(object tran, int ModID, int BtnID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModID,BtnID ");
            strSql.Append(" from ModuleButton ");
            strSql.Append(" where ModID=@ModID and BtnID=@BtnID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModID", SqlDbType.Int,4),
					new SqlParameter("@BtnID", SqlDbType.Int,4)			};
            parameters[0].Value = ModID;
            parameters[1].Value = BtnID;

            ModuleButtonInfo model = new ModuleButtonInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ModID"].ToString() != "")
                {
                    model.ModID = int.Parse(ds.Tables[0].Rows[0]["ModID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BtnID"].ToString() != "")
                {
                    model.BtnID = int.Parse(ds.Tables[0].Rows[0]["BtnID"].ToString());
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
            strSql.Append("select a.ModID,a.BtnID ");
            strSql.Append(" from ModuleButton a");

            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, null, null, null, null);
            return dtReturn;
        }
        #endregion

        #region 根据页面ID获取所有按钮和页面所选择的按钮 GetListByModID(int modID)
        /// <summary>
        /// 获取所有按钮和页面所选择的按钮
        /// pxd 2015-10-15
        /// </summary>
        /// <param name="modID"></param>
        /// <returns></returns>
        public DataTable GetListByModID(int modID)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.BtnID,a.BtnName,a.BtnTitle,a.Icon,b.ModID");
            strSql.Append(" from Button a");
            strSql.Append(" left join ModuleButton b on a.BtnID=b.BtnID and b.ModID=@ModID");
            strSql.Append(" Order by a.Sort");

            SqlParameter[] parameter = { new SqlParameter("@ModID", modID) };
           
            dtReturn = SQLHelper.GetDataSet(strSql.ToString(),parameter).Tables[0];
            return dtReturn;
        }
        #endregion
    }
}


