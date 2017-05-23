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
    /// 登录日志
    /// Author 2015-08-11
    /// </summary>
    public class LoginLog
    {
        #region 判断是否存在 Exists(object tran, int LogID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int LogID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LoginLog");
            strSql.Append(" where ");
            strSql.Append(" LogID = @LogID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,LoginLogInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, LoginLogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LoginLog(");
            strSql.Append("UserID,LoginName,State,LoginIP,IPAddress,LoginTime");
            strSql.Append(") values (");
            strSql.Append("@UserID,@LoginName,@State,@LoginIP,@IPAddress,@LoginTime");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@LoginName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@State", SqlDbType.Int,4) ,            
                        new SqlParameter("@LoginIP", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@IPAddress", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@LoginTime", SqlDbType.DateTime)             
             };

            parameters[0].Value = model.UserID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.State;
            parameters[3].Value = model.LoginIP;
            parameters[4].Value = model.IPAddress;
            parameters[5].Value = model.LoginTime;
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

        #region 更新一条数据 Update(object tran,LoginLogInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, LoginLogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LoginLog set ");

            strSql.Append("UserID=@UserID,");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("State=@State,");
            strSql.Append("LoginIP=@LoginIP,");
            strSql.Append("IPAddress=@IPAddress,");
            strSql.Append("LoginTime=@LoginTime");
            strSql.Append(" where LogID=@LogID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@LogID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@LoginName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@State", SqlDbType.Int,4) ,            
                        new SqlParameter("@LoginIP", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@IPAddress", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@LoginTime", SqlDbType.DateTime)             
             };

            parameters[0].Value = model.LogID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.LoginName;
            parameters[3].Value = model.State;
            parameters[4].Value = model.LoginIP;
            parameters[5].Value = model.IPAddress;
            parameters[6].Value = model.LoginTime;
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

        #region 删除一条数据 Delete(object tran,int LogID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int LogID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LoginLog ");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogID;


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

        #region 得到一个对象实体 GetModel(object tran,int LogID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-08-11
        /// </summary>
        public LoginLogInfo GetModel(object tran, int LogID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LogID,UserID,LoginName,State,LoginIP,IPAddress,LoginTime ");
            strSql.Append(" from LoginLog ");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogID;


            LoginLogInfo model = new LoginLogInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["LogID"].ToString() != "")
                {
                    model.LogID = int.Parse(ds.Tables[0].Rows[0]["LogID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoginName"].ToString() != "")
                {
                    model.LoginName =ds.Tables[0].Rows[0]["LoginName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                model.LoginIP = ds.Tables[0].Rows[0]["LoginIP"].ToString();
                model.IPAddress = ds.Tables[0].Rows[0]["IPAddress"].ToString();
                if (ds.Tables[0].Rows[0]["LoginTime"].ToString() != "")
                {
                    model.LoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LoginTime"].ToString());
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
            strSql.Append("select a.LogID,a.UserID,a.LoginName,a.State,a.LoginIP,a.IPAddress,a.LoginTime ");
            strSql.Append(" from LoginLog a");

            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, null, null, null, null);
            return dtReturn;
        }
        #endregion

        #region 根据条件获取日志列表 GetLogList(int userID,string startDate, string endDate, int pageSize, int pageIndex)
        /// <summary>
        /// 根据条件获取日志列表
        /// pxd 2015-10-27
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable GetLogList(int userID,string startDate, string endDate, int pageSize, int pageIndex)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.LogID,a.UserID,a.LoginName,a.State,a.LoginIP,a.IPAddress,Convert(varchar(20),a.LoginTime,120) LoginTime");
            strSql.Append(" from LoginLog a");

            string strWhere = "UserID=@UserID";

            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@UserID", userID));
            if (!string.IsNullOrEmpty(startDate))
            {
                strWhere += " and a.LoginTime>=@StartDate";
                parameter.Add(new SqlParameter("@StartDate", startDate));
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strWhere += " and a.LoginTime<=@EndDate";
                parameter.Add(new SqlParameter("@EndDate", endDate));
            }

            string strOrderBy = "LoginTime desc";
            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, parameter.ToArray(), strOrderBy, pageSize, pageIndex);
            return dtReturn;
        }
        #endregion

        #region 获得数据列表 GetList(int pageSize, int pageIndex)
        /// <summary>
        /// 示例 获得数据列表,条件,排序自定义
        /// Author 2017-04-01
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// </summary>
        public DataTable GetList(int pageSize, int pageIndex)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.LogID,a.UserID,a.LoginName,a.State,a.LoginIP,a.IPAddress,a.LoginTime,a.UserType ");
            strSql.Append(" from LoginLog a");
            string strWhere = "1=1";
            List<SqlParameter> parameter = new List<SqlParameter>();

            //参数示例     
            //if (!string.IsNullOrEmpty(startDate))
            //{
            //    strWhere += " and a.CreateDate>=@StartDate";
            //    parameter.Add(new SqlParameter("@StartDate", startDate));
            //}
            //if (!string.IsNullOrEmpty(Phone))
            //{
            //    strWhere += " and a.Phone like @Phone";
            //    parameter.Add(new SqlParameter("@Phone", "%" + Phone + "%"));
            //}

            string strOrderBy = "";
            dtReturn = Tools.GetPagerList(null, strSql.ToString(), strWhere, parameter, strOrderBy, pageSize, pageIndex);

            return dtReturn;
        }
        #endregion

    }
}

