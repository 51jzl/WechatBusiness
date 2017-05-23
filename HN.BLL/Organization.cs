using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;
using HN.Utility;

namespace HN.BLL
{
    /// <summary>
    /// 组织表
    /// Author 2015-08-11
    /// </summary>
    public class Organization
    {
        private readonly DAL.Organization dal = new DAL.Organization();
        public Organization()
        { }

        #region 是否存在该记录 Exists(object tran,int OrgID)
        /// <summary>
        /// 是否存在该记录
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int OrgID)
        {
            return dal.Exists(tran, OrgID);
        }
        #endregion

        #region 增加一条数据 Add(object tran,OrganizationInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, OrganizationInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,OrganizationInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, OrganizationInfo model)
        {
            return dal.Update(tran, model);
        }
        #endregion

        #region  删除一条数据 Delete(object tran,int OrgID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int OrgID)
        {
            return dal.Delete(tran, OrgID);
        }
        #endregion

        #region 得到一个对象实体 OrganizationInfo GetModel(object tran,int OrgID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrganizationInfo GetModel(object tran, int OrgID)
        {
            return dal.GetModel(tran, OrgID);
        }
        #endregion

        #region 获得数据列表 GetList(string strWhere)
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
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
            return dal.ExistsChildren(tran, orgID);
        }
        #endregion

        #region 判断组织编号或名称是否存在 ExistsNameOrCode(object tran, int OrgID)
        /// <summary>
        /// 判断组织编号或名称是否存在
        /// pxd 2015-10-21
        /// </summary>
        public bool ExistsNameOrCode(object tran, string orgCode, string orgName)
        {
            return dal.ExistsNameOrCode(tran, orgCode, orgName);
        }
        #endregion

        #region 添加/编辑组织 AddOrEditOrg(OrganizationInfo model)
        /// <summary>
        /// 添加/编辑组织
        /// pxd 2015-10-21
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddOrEditOrg(OrganizationInfo model)
        {
            string strReturn = "";
            try
            {
                if (model.OrgID == 0)  //添加
                {
                    if (!ExistsNameOrCode(null, model.OrgCode, model.OrgName))
                    {
                        model.DeleteMark = 0;
                        model.CreateID = Convert.ToInt32(SessionInfo.UserID);
                        model.CreateName = SessionInfo.UserName.ToString();
                        model.CreateDate = DateTime.Now;
                        if (!Add(null, model))
                        {
                            strReturn = ErrorPrompt.AddError;
                        }
                    }
                    else
                    {
                        strReturn = "组织编号或名称已存在，请重新输入！";
                    }
                }
                else  //编辑
                {
                    OrganizationInfo organizatinfo = GetModel(null, model.OrgID);
                    if (organizatinfo.OrgCode.ToLower() == model.OrgCode.ToLower() && organizatinfo.OrgName.ToLower() == model.OrgName.ToLower() || !ExistsNameOrCode(null, model.OrgCode, "") || !ExistsNameOrCode(null, "", model.OrgName))
                    {
                        if (!Update(null, model))
                        {
                            strReturn = ErrorPrompt.UpdateError;
                        }
                    }
                    else
                    {
                        strReturn = "商品名称或购买参数已存在，请不要重复添加";
                    }
                }
            }
            catch (Exception ex)
            {
                strReturn = new Tools().GetErrorInfo(ex);
            }
            return strReturn;
        }
        #endregion

        #region 获取组织列表 GetOrgList(int type)
        /// <summary>
        /// 获取组织列表
        /// pxd 2015-09-27
        /// </summary>
        /// <param name="type">0表示列表 1表示在添加或编辑时选择上级组织 2表示用户列表页面</param>
        /// <returns></returns>
        public string GetOrgList(int type)
        {
            string strReturn = "";
            DataTable dtTree = GetList("");
            if (type == 0)
            {
                strReturn = Tools.ConvertJsonString("[" + GetTreeJson(0, dtTree, type) + "]");
            }
            else if (type == 1)
            {
                strReturn = Tools.ConvertJsonString("[{\"id\":\"0\",\"text\":\"选择上级组织\",\"children\":[" + GetTreeJson(0, dtTree, type) + "]}]");
            }
            else if (type == 2)
            {
                strReturn =Tools.ConvertJsonString("[" + GetTreeJson(0, dtTree, type) + "]");
            }

            return strReturn;
        }
        #endregion

        #region 获取用户所在组织 GetUserOrg(int userID)
        /// <summary>
        /// 获取用户所在组织
        /// pxd 2015-10-23
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string GetUserOrg(int userID)
        {
            string strReturn = "";
            DataTable dtTree = new UsersOrganize().GetUserOrg(userID);
            strReturn = Tools.ConvertJsonString("[" + GetTreeJson(0, dtTree, 3) + "]");
            return strReturn;
        }
        #endregion

        #region 递归拼Json树 GetTreeJson(int pid, DataTable dt)
        /// <summary>
        /// pxd 2015-09-27
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="dt"></param>
        /// <param name="type">0表示列表 1表示在添加或编辑时选择上级组织 2表示用户列表页面 3表示在添加/编辑用户时设置组织</param>
        /// <returns></returns>
        private string GetTreeJson(int pid, DataTable dt, int type)
        {
            StringBuilder bulider = new StringBuilder();
            DataRow[] drs = dt.Select("ParentID=" + pid, "Sort");
            if (drs.Length != 0)
            {
                foreach (DataRow dr in drs)
                {
                    bulider.Append("{");
                    if (type == 0)
                    {
                        bulider.Append("\"OrgID\":" + dr["OrgID"]);
                        bulider.Append(",\"OrgName\":\"" + dr["OrgName"] + "\"");
                        bulider.Append(",\"OrgCode\":\"" + dr["OrgCode"] + "\"");
                        bulider.Append(",\"Manager\":\"" + dr["Manager"] + "\"");
                        bulider.Append(",\"InnerPhone\":\"" + dr["InnerPhone"] + "\"");
                        bulider.Append(",\"OuterPhone\":\"" + dr["OuterPhone"] + "\"");
                        bulider.Append(",\"Fax\":\"" + dr["Fax"] + "\"");
                        bulider.Append(",\"Sort\":" + dr["Sort"] + "");
                    }
                    else if (type == 1 || type == 2)
                    {
                        bulider.Append("\"id\":" + dr["OrgID"]);
                        bulider.Append(",\"text\":\"" + dr["OrgName"] + "\"");
                    }
                    else if (type == 3)
                    {
                        bulider.Append("\"OrgID\":" + dr["OrgID"]);
                        bulider.Append(",\"OrgName\":\"" + dr["OrgName"] + "\"");
                        bulider.Append(",\"OrgCode\":\"" + dr["OrgCode"] + "\"");
                        bulider.Append(",\"Manager\":\"" + dr["Manager"] + "\"");
                        bulider.Append(",\"ParentID\":\"" + dr["ParentID"] + "\"");
                        bulider.Append(",\"Chk\":\"" + dr["Chk"] + "\"");
                    }
                    //加载tree
                    string strChildren = GetTreeJson((int)dr["OrgID"], dt, type);
                    if (strChildren != "")
                    {
                        bulider.Append(",children:[");
                        bulider.Append(strChildren);
                        bulider.Append("]");
                    }
                    else
                    {
                        bulider.Append(",\"iconCls\":\"icon-tree-folder\"");
                    }
                    bulider.Append("},");
                }
                bulider.Remove(bulider.Length - 1, 1);
                return bulider.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 删除组织 DeleteOrg(int orgID)
        /// <summary>
        /// 删除组织
        /// pxd 2015-10-21
        /// </summary>
        /// <param name="orgID"></param>
        /// <returns></returns>
        public string DeleteOrg(int orgID)
        {
            string strReturn = "";
            try
            {
                if (ExistsChildren(null, orgID))
                {
                    throw new Exception("删除失败！请先删除下级组织！");
                }
                //先判断是否已被引用
                if (new UsersOrganize().ExistsUserByOrgID(null, orgID))
                {
                    throw new Exception(ErrorPrompt.RelateError);
                }

                if (!Delete(null, orgID))
                {
                    strReturn = ErrorPrompt.DeleError;
                }
            }
            catch (Exception ex)
            {
                strReturn = new Tools().GetErrorInfo(ex);
            }
            return strReturn;
        }
        #endregion
    }
}