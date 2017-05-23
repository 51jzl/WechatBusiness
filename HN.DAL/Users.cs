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
    /// 用户表
    /// Author 2015-08-11
    /// </summary>
    public class Users
    {
        #region 判断是否存在 Exists(object tran, int UserID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where ");
            strSql.Append(" UserID = @UserID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,UsersInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, UsersInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Users(");
            strSql.Append("UserCode,FirstPY,LoginName,Pwd,UserName,Gender,Birthday,Email,Tel,Phone,QQ,Description,ProFessTitle,IDCard,NativePlace,HomeAddress,Nation,Major,Education,School,Degree,JoinInDate,DimissionDate,DimissionCause,DeleteMark,CreateID,CreateName,CreateDate");
            strSql.Append(") values (");
            strSql.Append("@UserCode,@FirstPY,@LoginName,@Pwd,@UserName,@Gender,@Birthday,@Email,@Tel,@Phone,@QQ,@Description,@ProFessTitle,@IDCard,@NativePlace,@HomeAddress,@Nation,@Major,@Education,@School,@Degree,@JoinInDate,@DimissionDate,@DimissionCause,@DeleteMark,@CreateID,@CreateName,@CreateDate");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@FirstPY", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@LoginName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Pwd", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UserName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@Gender", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Birthday", SqlDbType.DateTime) ,            
                        new SqlParameter("@Email", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Tel", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Phone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@QQ", SqlDbType.VarChar,12) ,            
                        new SqlParameter("@Description", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@ProFessTitle", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@IDCard", SqlDbType.VarChar,18) ,            
                        new SqlParameter("@NativePlace", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@HomeAddress", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@Nation", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Major", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Education", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@School", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Degree", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@JoinInDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@DimissionDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@DimissionCause", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@DeleteMark", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@CreateID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime)             
             };

            parameters[0].Value = model.UserCode;
            parameters[1].Value = model.FirstPY;
            parameters[2].Value = model.LoginName;
            parameters[3].Value = model.Pwd;
            parameters[4].Value = model.UserName;
            parameters[5].Value = model.Gender;
            parameters[6].Value = model.Birthday;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.Tel;
            parameters[9].Value = model.Phone;
            parameters[10].Value = model.QQ;
            parameters[11].Value = model.Description;
            parameters[12].Value = model.ProFessTitle;
            parameters[13].Value = model.IDCard;
            parameters[14].Value = model.NativePlace;
            parameters[15].Value = model.HomeAddress;
            parameters[16].Value = model.Nation;
            parameters[17].Value = model.Major;
            parameters[18].Value = model.Education;
            parameters[19].Value = model.School;
            parameters[20].Value = model.Degree;
            parameters[21].Value = model.JoinInDate;
            parameters[22].Value = model.DimissionDate;
            parameters[23].Value = model.DimissionCause;
            parameters[24].Value = model.DeleteMark;
            parameters[25].Value = model.CreateID;
            parameters[26].Value = model.CreateName;
            parameters[27].Value = model.CreateDate;
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

        #region 更新一条数据 Update(object tran,UsersInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, UsersInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("UserCode=@UserCode,");
            strSql.Append("FirstPY=@FirstPY,");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("Email=@Email,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("Description=@Description,");
            strSql.Append("ProFessTitle=@ProFessTitle,");
            strSql.Append("IDCard=@IDCard,");
            strSql.Append("NativePlace=@NativePlace,");
            strSql.Append("HomeAddress=@HomeAddress,");
            strSql.Append("Nation=@Nation,");
            strSql.Append("Major=@Major,");
            strSql.Append("Education=@Education,");
            strSql.Append("School=@School,");
            strSql.Append("Degree=@Degree,");
            strSql.Append("JoinInDate=@JoinInDate,");
            strSql.Append("DimissionDate=@DimissionDate,");
            strSql.Append("DimissionCause=@DimissionCause");
            strSql.Append(" where UserID=@UserID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@FirstPY", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@LoginName", SqlDbType.VarChar,50) ,                       
                        new SqlParameter("@UserName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@Gender", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Birthday", SqlDbType.DateTime) ,            
                        new SqlParameter("@Email", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Tel", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Phone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@QQ", SqlDbType.VarChar,12) ,            
                        new SqlParameter("@Description", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@ProFessTitle", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@IDCard", SqlDbType.VarChar,18) ,            
                        new SqlParameter("@NativePlace", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@HomeAddress", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@Nation", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Major", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Education", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@School", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Degree", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@JoinInDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@DimissionDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@DimissionCause", SqlDbType.NVarChar,100) ,                        
             };

            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserCode;
            parameters[2].Value = model.FirstPY;
            parameters[3].Value = model.LoginName;
            parameters[4].Value = model.UserName;
            parameters[5].Value = model.Gender;
            parameters[6].Value = model.Birthday;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.Tel;
            parameters[9].Value = model.Phone;
            parameters[10].Value = model.QQ;
            parameters[11].Value = model.Description;
            parameters[12].Value = model.ProFessTitle;
            parameters[13].Value = model.IDCard;
            parameters[14].Value = model.NativePlace;
            parameters[15].Value = model.HomeAddress;
            parameters[16].Value = model.Nation;
            parameters[17].Value = model.Major;
            parameters[18].Value = model.Education;
            parameters[19].Value = model.School;
            parameters[20].Value = model.Degree;
            parameters[21].Value = model.JoinInDate;
            parameters[22].Value = model.DimissionDate;
            parameters[23].Value = model.DimissionCause;
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

        #region 删除一条数据 Delete(object tran,int UserID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Users ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;


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

        #region 得到一个对象实体 GetModel(object tran,int UserID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-08-11
        /// </summary>
        public UsersInfo GetModel(object tran, int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,UserCode,FirstPY,LoginName,Pwd,UserName,Gender,Birthday,Email,Tel,Phone,QQ,Description,ProFessTitle,IDCard,NativePlace,HomeAddress,Nation,Major,Education,School,Degree,JoinInDate,DimissionDate,DimissionCause,DeleteMark,CreateID,CreateName,CreateDate,IsAdmin ");
            strSql.Append(" from Users ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;

            UsersInfo model = new UsersInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserCode = ds.Tables[0].Rows[0]["UserCode"].ToString();
                model.FirstPY = ds.Tables[0].Rows[0]["FirstPY"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.Pwd = ds.Tables[0].Rows[0]["Pwd"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(ds.Tables[0].Rows[0]["Gender"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.ProFessTitle = ds.Tables[0].Rows[0]["ProFessTitle"].ToString();
                model.IDCard = ds.Tables[0].Rows[0]["IDCard"].ToString();
                model.NativePlace = ds.Tables[0].Rows[0]["NativePlace"].ToString();
                model.HomeAddress = ds.Tables[0].Rows[0]["HomeAddress"].ToString();
                model.Nation = ds.Tables[0].Rows[0]["Nation"].ToString();
                model.Major = ds.Tables[0].Rows[0]["Major"].ToString();
                model.Education = ds.Tables[0].Rows[0]["Education"].ToString();
                model.School = ds.Tables[0].Rows[0]["School"].ToString();
                model.Degree = ds.Tables[0].Rows[0]["Degree"].ToString();
                if (ds.Tables[0].Rows[0]["JoinInDate"].ToString() != "")
                {
                    model.JoinInDate = DateTime.Parse(ds.Tables[0].Rows[0]["JoinInDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DimissionDate"].ToString() != "")
                {
                    model.DimissionDate = DateTime.Parse(ds.Tables[0].Rows[0]["DimissionDate"].ToString());
                }
                model.DimissionCause = ds.Tables[0].Rows[0]["DimissionCause"].ToString();
                if (ds.Tables[0].Rows[0]["DeleteMark"].ToString() != "")
                {
                    model.DeleteMark = int.Parse(ds.Tables[0].Rows[0]["DeleteMark"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(ds.Tables[0].Rows[0]["CreateID"].ToString());
                }
                model.CreateName = ds.Tables[0].Rows[0]["CreateName"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsAdmin"].ToString() != "")
                {
                    model.IsAdmin = int.Parse(ds.Tables[0].Rows[0]["IsAdmin"].ToString());
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
            strSql.Append("select a.UserID,a.UserCode,a.FirstPY,a.LoginName,a.Pwd,a.UserName,a.Gender,a.Birthday,a.Email,a.Tel,a.Phone,a.QQ,a.Description,a.ProFessTitle,a.IDCard,a.NativePlace,a.HomeAddress,a.Nation,a.Major,a.Education,a.School,a.Degree,a.JoinInDate,a.DimissionDate,a.DimissionCause,a.DeleteMark,a.CreateID,a.CreateName,a.CreateDate ");
            strSql.Append(" from Users a");

            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, null, null, null, null);
            return dtReturn;
        }
        #endregion

        #region 根据账户和密码获取数据 GetModelByName(string loginName,string pwd)
        /// <summary>
        /// 根据账户和密码获取数据
        /// pxd 2015-08-16
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public UsersInfo GetModelByName(string loginName, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,UserCode,FirstPY,LoginName,Pwd,UserName,Gender,Birthday,Email,Tel,Phone,QQ,Description,ProFessTitle,IDCard,NativePlace,HomeAddress,Nation,Major,Education,School,Degree,JoinInDate,DimissionDate,DimissionCause,DeleteMark,CreateID,CreateName,CreateDate,IsAdmin ");
            strSql.Append(" from Users ");
            strSql.Append(" where LoginName=@LoginName");
            strSql.Append(" and Pwd=@Pwd");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
                    new SqlParameter("@Pwd", SqlDbType.VarChar,16)
			};
            parameters[0].Value = loginName;
            parameters[1].Value = pwd;

            UsersInfo model = new UsersInfo();
            DataSet ds = SQLHelper.GetDataSet(null, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserCode = ds.Tables[0].Rows[0]["UserCode"].ToString();
                model.FirstPY = ds.Tables[0].Rows[0]["FirstPY"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.Pwd = ds.Tables[0].Rows[0]["Pwd"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(ds.Tables[0].Rows[0]["Gender"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.ProFessTitle = ds.Tables[0].Rows[0]["ProFessTitle"].ToString();
                model.IDCard = ds.Tables[0].Rows[0]["IDCard"].ToString();
                model.NativePlace = ds.Tables[0].Rows[0]["NativePlace"].ToString();
                model.HomeAddress = ds.Tables[0].Rows[0]["HomeAddress"].ToString();
                model.Nation = ds.Tables[0].Rows[0]["Nation"].ToString();
                model.Major = ds.Tables[0].Rows[0]["Major"].ToString();
                model.Education = ds.Tables[0].Rows[0]["Education"].ToString();
                model.School = ds.Tables[0].Rows[0]["School"].ToString();
                model.Degree = ds.Tables[0].Rows[0]["Degree"].ToString();
                if (ds.Tables[0].Rows[0]["JoinInDate"].ToString() != "")
                {
                    model.JoinInDate = DateTime.Parse(ds.Tables[0].Rows[0]["JoinInDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DimissionDate"].ToString() != "")
                {
                    model.DimissionDate = DateTime.Parse(ds.Tables[0].Rows[0]["DimissionDate"].ToString());
                }
                model.DimissionCause = ds.Tables[0].Rows[0]["DimissionCause"].ToString();
                if (ds.Tables[0].Rows[0]["DeleteMark"].ToString() != "")
                {
                    model.DeleteMark = int.Parse(ds.Tables[0].Rows[0]["DeleteMark"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(ds.Tables[0].Rows[0]["CreateID"].ToString());
                }
                model.CreateName = ds.Tables[0].Rows[0]["CreateName"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsAdmin"].ToString() != "")
                {
                    model.IsAdmin = int.Parse(ds.Tables[0].Rows[0]["IsAdmin"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 修改密码 UpdatePass(string pwd, int userID)
        /// <summary>
        /// 更新一条数据
        /// pxd 2015-09-09
        /// </summary>
        public bool UpdatePass(string pwd, int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("Pwd=@Pwd");
            strSql.Append(" where UserID=@UserID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,              
                        new SqlParameter("@Pwd", SqlDbType.VarChar,16) ,                      
             };

            parameters[0].Value = userID;
            parameters[1].Value = pwd;
            int rows = SQLHelper.ExecuteNonQuery(null, strSql.ToString(), parameters);
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

        #region 获取用户列表-带分页 GetUserList(string loginName, string userName, string phone, bool bAdmin, string orgID, int pageSize, int pageIndex)
        /// <summary>
        /// 获取用户列表
        /// pxd 2015-09-19
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="userName"></param>
        /// <param name="phone"></param>
        /// <param name="bAdmin"></param>
        /// <param name="orgID"></param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">也索引</param>
        /// <returns></returns>
        public DataTable GetUserList(string loginName, string userName, string phone, bool bAdmin, string orgID, int pageSize, int pageIndex)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.UserID,a.UserCode,a.LoginName,a.UserName,a.Gender,a.Birthday,a.Email,a.Tel,a.Phone,a.HomeAddress,a.CreateName,a.CreateDate");
            strSql.Append(" from Users a");
            string strWhere = "a.DeleteMark=0";
            List<SqlParameter> parameter = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(loginName))
            {
                strWhere += " and a.LoginName like @LoginName";
                parameter.Add(new SqlParameter("@LoginName", "%" + loginName + "%"));
            }
            if (!string.IsNullOrEmpty(userName))
            {
                strWhere += " and a.UserName like @UserName";
                parameter.Add(new SqlParameter("@UserName", "%" + userName + "%"));
            }
            if (!string.IsNullOrEmpty(phone))
            {
                strWhere += " and a.Phone like @Phone";
                parameter.Add(new SqlParameter("@Phone", "%" + phone + "%"));
            }
            if (!string.IsNullOrEmpty(orgID))
            {
                strWhere += " and a.UserID in(select UserID from UsersOrganize where OrgID=@OrgID)";
                parameter.Add(new SqlParameter("@OrgID", orgID));
            }
            if (!bAdmin)
            {
                strWhere += " and a.IsAdmin=0";
            }
            string strOrderBy = "CreateDate desc";
            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, parameter.ToArray(), strOrderBy, pageSize, pageIndex);
            return dtReturn;
        }
        #endregion

        #region 删除用户-逻辑删除 DeleteUser(int userID)
        /// <summary>
        /// 删除用户-逻辑删除
        /// pxd 2015-09-22
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool DeleteUser(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("DeleteMark=1");
            strSql.Append(" where UserID=@UserID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", userID) ,            
             };

            int rows = SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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

        #region 判断登录名是否重复 ExistsLoginName(object tran, string loginName)
        /// <summary>
        /// 判断登录名是否重复
        /// pxd 2015-09-25
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool ExistsLoginName(object tran, string loginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Count(1) from Users  ");
            strSql.Append(" where LoginName=@LoginName");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", loginName),
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

        #region 重置密码 ResetPwd(int userID)
        /// <summary>
        /// 重置密码
        /// pxd 2015-09-25
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool ResetPwd(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("Pwd='" + Utility.DESEncrypt.GetMd5Str("123456") + "'");
            strSql.Append(" where UserID=@UserID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UserID",userID) ,                                         
             };

            int rows = SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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

        #region 获取用户列表-导出 GetExportList(string loginName, string userName, string phone,string orgID)
        /// <summary>
        /// 获取用户列表
        /// pxd 2015-09-19
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="userName"></param>
        /// <param name="phone"></param>
        /// <param name="orgID"></param>
        /// <returns></returns>
        public DataTable GetExportList(string loginName, string userName, string phone,string orgID)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.UserCode,a.LoginName,a.UserName,Case a.Gender when 0 then '男' else '女' end Gender,Convert(varchar(10),a.Birthday,23)Birthday,a.Phone,a.Tel,a.Email,a.HomeAddress");
            strSql.Append(" from Users a");
            string strWhere = " where a.DeleteMark=0 and IsAdmin=0";
            List<SqlParameter> parameter = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(loginName))
            {
                strWhere += " and a.LoginName like @LoginName";
                parameter.Add(new SqlParameter("@LoginName", "%" + loginName + "%"));
            }
            if (!string.IsNullOrEmpty(userName))
            {
                strWhere += " and a.UserName like @UserName";
                parameter.Add(new SqlParameter("@UserName", "%" + userName + "%"));
            }
            if (!string.IsNullOrEmpty(phone))
            {
                strWhere += " and a.Phone like @Phone";
                parameter.Add(new SqlParameter("@Phone", "%" + phone + "%"));
            }
            if (!string.IsNullOrEmpty(orgID))
            {
                strWhere += " and a.UserID in(select UserID from UsersOrganize where OrgID=@OrgID)";
                parameter.Add(new SqlParameter("@OrgID", orgID));
            }
            string strOrderBy = "CreateDate desc";
            dtReturn = SQLHelper.GetDataSet(strSql.ToString() + strWhere, parameter.ToArray()).Tables[0];
            return dtReturn;
        }
        #endregion

    }
}

