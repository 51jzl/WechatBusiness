using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;
using HN.Utility;

namespace HN.BLL
{
    /// <summary>
    /// 角色表
    /// Author 2015-08-11
    /// </summary>
    public class Roles
    {
        private readonly DAL.Roles dal = new DAL.Roles();
        public Roles()
        { }

        #region 是否存在该记录 Exists(object tran,string RoleName)
        /// <summary>
        /// 是否存在该记录
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, string RoleName)
        {
            return dal.Exists(tran, RoleName);
        }
        #endregion

        #region 增加一条数据 Add(object tran,RolesInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, RolesInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,RolesInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, RolesInfo model)
        {
            return dal.Update(tran, model);
        }
        #endregion

        #region  删除一条数据 Delete(object tran,int RoleID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int RoleID)
        {
            return dal.Delete(tran, RoleID);
        }
        #endregion

        #region 得到一个对象实体 RolesInfo GetModel(object tran,int RoleID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RolesInfo GetModel(object tran, int RoleID)
        {
            return dal.GetModel(tran, RoleID);
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

        #region 添加/编辑角色 AddOrEditRoles(RolesInfo model)
        /// <summary>
        /// 添加/编辑角色
        /// pxd 2015-10-15
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddOrEditRoles(RolesInfo model)
        {
            string strReturn = "";
            try
            {
                if (model.RoleID == 0)//添加
                {
                    if (!Exists(null, model.RoleName))
                    {
                        if (!Add(null, model))
                        {
                            strReturn = ErrorPrompt.AddError;
                        }
                    }
                    else
                    {
                        strReturn = "角色[" + model.RoleName + "]已存在，请重新输入！";
                    }
                }
                else  //编辑
                {
                    RolesInfo rolesinfo = GetModel(null, model.RoleID);
                    //判断登录名是否重复
                    if (rolesinfo.RoleName.ToLower() == model.RoleName.ToLower() || !Exists(null, model.RoleName))
                    {
                        if (!Update(null, model))
                        {
                            strReturn = ErrorPrompt.UpdateError;
                        }
                    }
                    else
                    {
                        strReturn = "角色[" + model.RoleName + "]已存在，请重新输入！";
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

        #region 删除角色 DeleteRole(int roleID)
        /// <summary>
        /// 删除角色
        /// pxd 2015-10-15
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public string DeleteRole(int roleID)
        {
            string strReturn = "";
            Transaction transaction = new Transaction();
            object tran = transaction.CreatTransaction();
            try
            {
                RolesInfo model = GetModel(tran, roleID);
                if (model.IsDefault==1)
                {
                    throw new Exception("不允许删除系统默认角色！");
                }
                //判断是否已经被引用
                if (new UsersRole().ExistsByRoleID(null, roleID))
                {
                    throw new Exception(ErrorPrompt.RelateError);
                }
                //先判断角色菜单权限
                if (new RoleModule().ExistsByRoleID(tran, roleID))
                {
                    //删除角色菜单权限
                    if (!new RoleModule().DeleteByRoleID(tran, roleID))
                    {
                        throw new Exception("删除角色菜单权限失败！");
                    }
                }
                //先判断角色按钮权限
                if (new RoleModButton().ExistsByRoleID(tran, roleID))
                {
                    //删除角色按钮权限
                    if (!new RoleModButton().DeleteByRoleID(tran, roleID))
                    {
                        throw new Exception("删除角色按钮权限失败！");
                    }
                }
                //删除角色
                if (!Delete(tran, roleID))
                {
                    strReturn = ErrorPrompt.DeleError;
                }
                transaction.Commit(tran);
            }
            catch (Exception ex)
            {
                transaction.Rollback(tran);
                strReturn = new Tools().GetErrorInfo(ex);
            }
            return strReturn;
        }
        #endregion

    }
}