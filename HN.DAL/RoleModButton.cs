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
    /// 角色页面按钮表
    /// Author 2015-09-22
    /// </summary>
    public class RoleModButton
    {
        #region 判断是否存在 Exists(object tran, int RoleID,int ModID,int BtnID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int RoleID, int ModID, int BtnID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RoleModButton");
            strSql.Append(" where ");
            strSql.Append(" RoleID = @RoleID and  ");
            strSql.Append(" ModID = @ModID and  ");
            strSql.Append(" BtnID = @BtnID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ModID", SqlDbType.Int,4),
					new SqlParameter("@BtnID", SqlDbType.Int,4)			};
            parameters[0].Value = RoleID;
            parameters[1].Value = ModID;
            parameters[2].Value = BtnID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,ModuleButtonInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, RoleModButtonInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RoleModButton(");
            strSql.Append("RoleID,ModID,BtnID");
            strSql.Append(") values (");
            strSql.Append("@RoleID,@ModID,@BtnID");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@RoleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModID", SqlDbType.Int,4) ,            
                        new SqlParameter("@BtnID", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.ModID;
            parameters[2].Value = model.BtnID;
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
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, RoleModButtonInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoleModButton set ");

            strSql.Append("RoleID=@RoleID,");
            strSql.Append("ModID=@ModID,");
            strSql.Append("BtnID=@BtnID");
            strSql.Append(" where RoleID=@RoleID and ModID=@ModID and BtnID=@BtnID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@RoleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModID", SqlDbType.Int,4) ,            
                        new SqlParameter("@BtnID", SqlDbType.Int,4)             
             };

            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.ModID;
            parameters[2].Value = model.BtnID;
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

        #region 删除一条数据 Delete(object tran,int RoleID,int ModID,int BtnID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int RoleID, int ModID, int BtnID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RoleModButton ");
            strSql.Append(" where RoleID=@RoleID and ModID=@ModID and BtnID=@BtnID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ModID", SqlDbType.Int,4),
					new SqlParameter("@BtnID", SqlDbType.Int,4)			};
            parameters[0].Value = RoleID;
            parameters[1].Value = ModID;
            parameters[2].Value = BtnID;


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

        #region 得到一个对象实体 GetModel(object tran,int RoleID,int ModID,int BtnID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-08-11
        /// </summary>
        public RoleModButtonInfo GetModel(object tran, int RoleID, int ModID, int BtnID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleID,ModID,BtnID ");
            strSql.Append(" from RoleModButton ");
            strSql.Append(" where RoleID=@RoleID and ModID=@ModID and BtnID=@BtnID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ModID", SqlDbType.Int,4),
					new SqlParameter("@BtnID", SqlDbType.Int,4)			};
            parameters[0].Value = RoleID;
            parameters[1].Value = ModID;
            parameters[2].Value = BtnID;


            RoleModButtonInfo model = new RoleModButtonInfo();
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
        /// Author 2015-08-11
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            DataTable dtReturn = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.RoleID,a.ModID,a.BtnID ");
            strSql.Append(" from RoleModButton a");

            dtReturn = Tools.GetList_N(null, strSql.ToString(), strWhere, null, null, null, null);
            return dtReturn;
        }
        #endregion

        #region 根据用户获取页面按钮 GetButtonList(int userID, int modID,string type)
        /// <summary>
        /// 根据用户获取页面按钮
        /// pxd 2015-09-20
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="modID">页面ID</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public DataTable GetButtonList(int userID, int modID,string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.BtnCode,a.BtnName,a.btnTitle,a.BtnClick,a.Icon from Button a");
            strSql.Append(" inner join RoleModButton b on b.BtnID=a.BtnID");
            strSql.Append(" inner join UsersRole c on c.RoleID=b.RoleID");
            strSql.Append(" inner join ModuleButton d on d.BtnID=b.BtnID and d.ModID=b.ModID");
            strSql.Append(" where b.ModID=@ModID");
            strSql.Append(" and c.UserID=@UserID");
            
            if (!string.IsNullOrEmpty(type)) 
            {
                 strSql.Append(" and a.Type="+type+"");
            }
            strSql.Append(" group by a.BtnCode,a.BtnName,a.btnTitle,a.BtnClick,a.Icon,a.Sort");
            strSql.Append(" order by a.Sort");
            SqlParameter[] parameters = { new SqlParameter("@UserID", userID),
                                        new SqlParameter("@ModID", modID),};
            DataTable dtReturn = SQLHelper.GetDataSet(strSql.ToString(), parameters).Tables[0];

            return dtReturn;
        }
        #endregion

        #region 判断按钮权限 IsButtonPower(int userID, string url, string action)
        /// <summary>
        /// 判断按钮权限
        /// pxd 2015-09-22
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="url"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool IsButtonPower(int userID, string url, string action)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(1) from RoleModButton a");
            strSql.Append(" inner join Module b on a.ModID=b.ModID");
            strSql.Append(" inner join Button c on c.BtnID=a.BtnID");
            strSql.Append(" inner join UsersRole d on d.RoleID=a.RoleID");
            strSql.Append(" where d.UserID=@UserID");
            strSql.Append(" and b.Link=@Link");
            strSql.Append(" and c.Action=@Action");
            strSql.Append(" and b.IsEnable=1");

            SqlParameter[] parameters = { new SqlParameter("@UserID", userID),
                                new SqlParameter("@Link", url),
                                new SqlParameter("@Action", action),};

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

        #region 根据角色ID判断是否存在 ExistsByRoleID(object tran, int roleID)
        /// <summary>
        /// 根据角色ID判断是否存在
        /// pxd 2015-10-15
        /// </summary>
        public bool ExistsByRoleID(object tran, int roleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RoleModButton");
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
            strSql.Append("delete from RoleModButton ");
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

        #region 根据角色获取按钮 GetButtonListByRoleID(int roleID, string type)
        /// <summary>
        /// 根据角色获取按钮
        /// pxd 2015-10-16
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetButtonListByRoleID(int roleID, string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.BtnID,c.BtnName,a.ModID,c.Sort,b.ModID Chk from ModuleButton a");
            strSql.Append(" left join RoleModButton b on a.ModID=b.ModID and a.BtnID=b.BtnID and b.RoleID=@RoleID");
            strSql.Append(" left join Button c on a.BtnID=c.BtnID");

            if (!string.IsNullOrEmpty(type))
            {
                strSql.Append(" where c.Type=" + type + "");
            }
            SqlParameter[] parameters = { new SqlParameter("@RoleID", roleID)};
            DataTable dtReturn = SQLHelper.GetDataSet(strSql.ToString(), parameters).Tables[0];

            return dtReturn;
        }
        #endregion
    }
}

