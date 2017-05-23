using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;
using HN.Utility;

namespace HN.BLL
{
    /// <summary>
    /// 模块表
    /// Author 2015-09-22
    /// </summary>
    public class Module
    {
        private readonly DAL.Module dal = new DAL.Module();
        public Module()
        { }

        #region 是否存在该记录 Exists(object tran,int ModID)
        /// <summary>
        /// 是否存在该记录
        /// Author 2015-09-22
        /// </summary>
        public bool Exists(object tran, int ModID)
        {
            return dal.Exists(tran, ModID);
        }
        #endregion

        #region 增加一条数据 Add(object tran,ModuleInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Add(object tran, ModuleInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,ModuleInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Update(object tran, ModuleInfo model)
        {
            return dal.Update(tran, model);
        }
        #endregion

        #region  删除一条数据 Delete(object tran,int ModID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Delete(object tran, int ModID)
        {
            return dal.Delete(tran, ModID);
        }
        #endregion

        #region 得到一个对象实体 ModuleInfo GetModel(object tran,int ModID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ModuleInfo GetModel(object tran, int ModID)
        {
            return dal.GetModel(tran, ModID);
        }
        #endregion

        #region 判断是否存在下级菜单 ExistsChildren(object tran, int ModID)
        /// <summary>
        /// 判断是否存在下级菜单
        /// Author 2015-09-22
        /// </summary>
        public bool ExistsChildren(object tran, int ModID)
        {
            return dal.ExistsChildren(tran, ModID);
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

        #region 获得菜单列表 GetModuleList()
        /// <summary>
        /// 获得菜单列表
        /// pxd 2015-09-27
        /// </summary>
        /// <returns></returns>
        public string GetModuleList()
        {
            string strReturn = "";
            DataTable dtTree = GetList("");
            strReturn =Tools.ConvertJsonString("[" + GetTreeJson(0, dtTree) + "]");
            return strReturn;
        }
        #endregion

        #region 递归拼Json树 GetTreeJson(int pid, DataTable dt)
        /// <summary>
        /// 获得菜单列表
        /// pxd 2015-09-27
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string GetTreeJson(int pid, DataTable dt)
        {
            StringBuilder bulider = new StringBuilder();
            DataRow[] drs = dt.Select("ParentID=" + pid, "Sort");
            if (drs.Length != 0)
            {
                foreach (DataRow dr in drs)
                {
                    bulider.Append("{");
                    bulider.Append("\"ModID\":" + dr["ModID"]);
                    bulider.Append(",\"ModName\":\"" + dr["ModName"] + "\"");
                    bulider.Append(",\"ParentID\":\"" + dr["ParentID"] + "\"");
                    bulider.Append(",\"iconCls\":\"icon-" + dr["Icon"] + "\"");
                    bulider.Append(",\"ModTitle\":\"" + dr["ModTitle"] + "\"");
                    bulider.Append(",\"Targe\":\"" + dr["Targe"] + "\"");
                    bulider.Append(",\"Link\":\"" + dr["Link"] + "\"");
                    bulider.Append(",\"IsEnable\":" + dr["IsEnable"] + "");
                    bulider.Append(",\"Type\":" + dr["Type"] + "");
                    bulider.Append(",\"Sort\":" + dr["Sort"] + "");
                    //加载tree
                    string strChildren = GetTreeJson((int)dr["ModID"], dt);
                    if (strChildren != "")
                    {
                        bulider.Append(",children:[");
                        bulider.Append(strChildren);
                        bulider.Append("]");
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

        #region 获得菜单列表-编辑菜单时调用 GetModuleListForEdit()
        /// <summary>
        /// 获得菜单列表
        /// pxd 2015-10-14
        /// </summary>
        /// <returns></returns>
        public string GetModuleListForEdit()
        {
            string strReturn = "";
            DataTable dtTree = GetList("");
            strReturn =Tools.ConvertJsonString("[{\"id\":\"0\",\"text\":\"选择上级菜单\",\"children\":[" + GetTreeJsonForEdit(0, dtTree) + "]}]");
            return strReturn;
        }
        #endregion

        #region 递归拼Json树-编辑菜单时调用 GetTreeJsonForEdit(int pid, DataTable dt)
        /// <summary>
        /// 获得菜单列表
        /// pxd 2015-10-14
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string GetTreeJsonForEdit(int pid, DataTable dt)
        {
            StringBuilder bulider = new StringBuilder();
            DataRow[] drs = dt.Select("ParentID=" + pid, "Sort");
            if (drs.Length != 0)
            {
                foreach (DataRow dr in drs)
                {
                    bulider.Append("{");
                    bulider.Append("\"id\":" + dr["ModID"]);
                    bulider.Append(",\"text\":\"" + dr["ModName"] + "\"");
                    bulider.Append(",\"iconCls\":\"icon-" + dr["Icon"] + "\"");
                    //加载tree
                    string strChildren = GetTreeJsonForEdit((int)dr["ModID"], dt);
                    if (strChildren != "")
                    {
                        bulider.Append(",children:[");
                        bulider.Append(strChildren);
                        bulider.Append("]");
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

        #region 添加/编辑菜单 AddOrEditModule(ModuleInfo model)
        /// <summary>
        /// 添加/编辑菜单
        /// pxd 2015-10-14
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddOrEditModule(ModuleInfo model)
        {
            string strReturn = "";
            try
            {
                if (model.ModID == 0)  //新增
                {
                    if (!Add(null, model))
                    {
                        strReturn = ErrorPrompt.AddError;
                    }
                }
                else  //编辑
                {
                    if (!Update(null, model))
                    {
                        strReturn = ErrorPrompt.UpdateError;
                    }
                }
            }
            catch (Exception ex)
            {
                strReturn = ex.Message.ToString();
            }

            return strReturn;
        }
        #endregion

        #region 删除菜单 DeleteModule(int modID)
        /// <summary>
        /// 删除菜单
        /// pxd 2015-10-14
        /// </summary>
        /// <param name="modID"></param>
        /// <returns></returns>
        public string DeleteModule(int modID)
        {
            string strReturn = "";
            try
            {
                if (ExistsChildren(null,modID))
                {
                    throw new Exception("删除失败！请先删除下级菜单！");
                }
                //先判断是否已被引用
                if (new RoleModule().IsRelate(null, modID))
                {
                    throw new Exception(ErrorPrompt.RelateError);
                }
                //判断菜单有按钮的话先删除按钮
                if (new ModuleButton().Exists(null, modID))
                {
                    if (!new ModuleButton().Delete(null, modID))
                    {
                        throw new Exception("删除菜单按钮失败！");
                    }
                }
                if (!Delete(null, modID))
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