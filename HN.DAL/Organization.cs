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
    /// 组织表
    /// Author 2015-08-11
    /// </summary>
    public class Organization
    {
        #region 判断是否存在 Exists(object tran, int OrgID)
        /// <summary>
        /// 判断是否存在
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int OrgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Organization");
            strSql.Append(" where ");
            strSql.Append(" OrgID = @OrgID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrgID", SqlDbType.Int,4)
			};
            parameters[0].Value = OrgID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 增加一条数据 Add(object tran,OrganizationInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, OrganizationInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Organization(");
            strSql.Append("OrgCode,OrgName,Manager,AssistantManager,InnerPhone,OuterPhone,Fax,Sort,Address,Remark,ParentID,DeleteMark,CreateID,CreateName,CreateDate");
            strSql.Append(") values (");
            strSql.Append("@OrgCode,@OrgName,@Manager,@AssistantManager,@InnerPhone,@OuterPhone,@Fax,@Sort,@Address,@Remark,@ParentID,@DeleteMark,@CreateID,@CreateName,@CreateDate");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@OrgCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OrgName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Manager", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@AssistantManager", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@InnerPhone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@OuterPhone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Fax", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Address", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@ParentID", SqlDbType.Int,4) ,            
                        new SqlParameter("@DeleteMark", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@CreateID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime)             
             };

            parameters[0].Value = model.OrgCode;
            parameters[1].Value = model.OrgName;
            parameters[2].Value = model.Manager;
            parameters[3].Value = model.AssistantManager;
            parameters[4].Value = model.InnerPhone;
            parameters[5].Value = model.OuterPhone;
            parameters[6].Value = model.Fax;
            parameters[7].Value = model.Sort;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.ParentID;
            parameters[11].Value = model.DeleteMark;
            parameters[12].Value = model.CreateID;
            parameters[13].Value = model.CreateName;
            parameters[14].Value = model.CreateDate;
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

        #region 更新一条数据 Update(object tran,OrganizationInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, OrganizationInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Organization set ");

            strSql.Append("OrgCode=@OrgCode,");
            strSql.Append("OrgName=@OrgName,");
            strSql.Append("Manager=@Manager,");
            strSql.Append("AssistantManager=@AssistantManager,");
            strSql.Append("InnerPhone=@InnerPhone,");
            strSql.Append("OuterPhone=@OuterPhone,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Address=@Address,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("ParentID=@ParentID");
            strSql.Append(" where OrgID=@OrgID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@OrgID", SqlDbType.Int,4) ,            
                        new SqlParameter("@OrgCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OrgName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Manager", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@AssistantManager", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@InnerPhone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@OuterPhone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Fax", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Address", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@ParentID", SqlDbType.Int,4)           
             };

            parameters[0].Value = model.OrgID;
            parameters[1].Value = model.OrgCode;
            parameters[2].Value = model.OrgName;
            parameters[3].Value = model.Manager;
            parameters[4].Value = model.AssistantManager;
            parameters[5].Value = model.InnerPhone;
            parameters[6].Value = model.OuterPhone;
            parameters[7].Value = model.Fax;
            parameters[8].Value = model.Sort;
            parameters[9].Value = model.Address;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.ParentID;

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

        #region 删除一条数据 Delete(object tran,int OrgID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int OrgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Organization ");
            strSql.Append(" where OrgID=@OrgID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrgID", SqlDbType.Int,4)
			};
            parameters[0].Value = OrgID;


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

        #region 得到一个对象实体 GetModel(object tran,int OrgID)
        /// <summary>
        /// 得到一个对象实体
        /// Author 2015-08-11
        /// </summary>
        public OrganizationInfo GetModel(object tran, int OrgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrgID,OrgCode,OrgName,Manager,AssistantManager,InnerPhone,OuterPhone,Fax,Sort,Address,Remark,ParentID,DeleteMark,CreateID,CreateName,CreateDate ");
            strSql.Append(" from Organization ");
            strSql.Append(" where OrgID=@OrgID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrgID", SqlDbType.Int,4)
			};
            parameters[0].Value = OrgID;


            OrganizationInfo model = new OrganizationInfo();
            DataSet ds = SQLHelper.GetDataSet((SqlTransaction)tran, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrgID"].ToString() != "")
                {
                    model.OrgID = int.Parse(ds.Tables[0].Rows[0]["OrgID"].ToString());
                }
                model.OrgCode = ds.Tables[0].Rows[0]["OrgCode"].ToString();
                model.OrgName = ds.Tables[0].Rows[0]["OrgName"].ToString();
                model.Manager = ds.Tables[0].Rows[0]["Manager"].ToString();
                model.AssistantManager = ds.Tables[0].Rows[0]["AssistantManager"].ToString();
                model.InnerPhone = ds.Tables[0].Rows[0]["InnerPhone"].ToString();
                model.OuterPhone = ds.Tables[0].Rows[0]["OuterPhone"].ToString();
                model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
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
            strSql.Append("select a.OrgID,a.OrgCode,a.OrgName,a.Manager,a.AssistantManager,a.InnerPhone,a.OuterPhone,a.Fax,a.Sort,a.Address,a.Remark,a.ParentID,a.DeleteMark,a.CreateID,a.CreateName,a.CreateDate ");
            strSql.Append(" from Organization a");
            strSql.Append(" where a.DeleteMark=0");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" Order by a.Sort");
            dtReturn = SQLHelper.GetDataSet(strSql.ToString()).Tables[0];
            return dtReturn;
        }
        #endregion

        #region 判断组织编号或名称是否存在 ExistsNameOrCode(object tran, int OrgID)
        /// <summary>
        /// 判断组织编号或名称是否存在
        /// pxd 2015-10-21
        /// </summary>
        public bool ExistsNameOrCode(object tran, string orgCode, string orgName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Organization");
            strSql.Append(" where ");
            strSql.Append(" OrgCode = @OrgCode  ");
            strSql.Append(" or OrgName = @OrgName  ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrgCode",orgCode),
                    new SqlParameter("@OrgName",orgName)
			};

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion

        #region 判断是否存在下级组织 ExistsChildren(object tran, int orgID)
        /// <summary>
        /// 判断是否存在下级组织
        /// pxd 2015-10-21
        /// <param name="orgID"></param>
        /// </summary>
        public bool ExistsChildren(object tran, int orgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Organization");
            strSql.Append(" where ");
            strSql.Append(" ParentID = @OrgID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrgID", SqlDbType.Int,4)
			};
            parameters[0].Value = orgID;

            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql.ToString(), parameters);
            return obj.ToString() == "0" ? false : true;
        }
        #endregion
    }
}

