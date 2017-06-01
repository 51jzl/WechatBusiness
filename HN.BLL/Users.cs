using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;
using HN.Utility;

namespace HN.BLL
{
    /// <summary>
    /// 用户表
    /// Author 2015-08-11
    /// </summary>
    public class Users
    {
        private readonly DAL.Users dal = new DAL.Users();
        public Users()
        { }

        #region 是否存在该记录 Exists(object tran,int UserID)
        /// <summary>
        /// 是否存在该记录
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int UserID)
        {
            return dal.Exists(tran, UserID);
        }
        #endregion

        #region 增加一条数据 Add(object tran,UsersInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, UsersInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,UsersInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, UsersInfo model)
        {
            return dal.Update(tran, model);
        }
        #endregion

        #region  删除一条数据 Delete(object tran,int UserID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int UserID)
        {
            return dal.Delete(tran, UserID);
        }
        #endregion

        #region 得到一个对象实体 UsersInfo GetModel(object tran,int UserID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UsersInfo GetModel(object tran, int UserID)
        {
            return dal.GetModel(tran, UserID);
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
            return dal.GetModelByName(loginName, pwd);
        }
        #endregion

        #region 修改密码 UpdatePass(string pwd, int userID)
        /// <summary>
        /// 更新一条数据
        /// pxd 2015-09-09
        /// </summary>
        public bool UpdatePass(string pwd, int userID)
        {
            return dal.UpdatePass(pwd, userID);
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
            return dal.GetUserList(loginName, userName, phone, bAdmin, orgID, pageSize, pageIndex);
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
            return dal.DeleteUser(userID);
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
            return dal.ExistsLoginName(tran, loginName);
        }
        #endregion

        #region 添加/编辑用户 AddOrUpdate(UsersInfo model, List<int> userOrgs)
        /// <summary>
        /// 添加/编辑用户
        ///pxd 2015-09-25
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userOrgs"></param>
        /// <returns></returns>
        public string AddOrUpdate(UsersInfo model, List<int> userOrgs)
        {
            string strReturn = "";
            Transaction transaction = new Transaction();
            object tran = transaction.CreatTransaction();
            try
            {
                if (model.DimissionDate.ToString() == "0001/1/1 0:00:00")
                {
                    model.DimissionDate = null;
                }
                if (model.UserID == 0)//添加
                {
                    //判断登录名是否重复
                    if (ExistsLoginName(tran, model.LoginName))
                    {
                        throw new Exception("登录名[" + model.LoginName + "]已存在，请重新输入！");
                    }

                    model.Pwd = Utility.DESEncrypt.GetMd5Str("123456");//添加时默认密码
                    model.CreateID = Convert.ToInt32(SessionInfo.UserID);
                    model.CreateName = SessionInfo.UserName.ToString();
                    model.FirstPY = new CharPY().GetFirstPY(model.UserName);  //拼音码

                    if (!Add(tran, model))
                    {
                        throw new Exception(ErrorPrompt.AddError);
                    }
                    model.UserID = new Tools().GetCurrentID(tran);
                }
                else   //编辑
                {
                    UsersInfo usersinfo = GetModel(tran, model.UserID);
                    //判断登录名是否重复
                    if (!(string.IsNullOrEmpty(model.LoginName) || usersinfo.LoginName.ToLower() == model.LoginName.ToLower() || !ExistsLoginName(tran, model.LoginName)))
                    {
                        throw new Exception("登录名[" + model.LoginName + "]已存在，请重新输入！");
                    }
                    model.FirstPY = new CharPY().GetFirstPY(model.UserName);  //拼音码
                    if (!Update(tran, model))
                    {
                        throw new Exception(ErrorPrompt.UpdateError);
                    }
                }
                #region 添加用户所属组织
                //判断是否存在 存在则先删除
                if (new UsersOrganize().ExistsByUserID(tran, model.UserID))
                {
                    if (!new UsersOrganize().DeleteByUserID(tran, model.UserID))
                    {
                        throw new Exception("删除用户所在组织出错！");
                    }
                }
                #endregion

                if (userOrgs != null)
                {
                    foreach (int orgID in userOrgs)
                    {
                        if (!new UsersOrganize().Add(tran, new UsersOrganizeInfo() { UserID = model.UserID, OrgID = orgID }))
                        {
                            throw new Exception("添加用户所在组织出错！");
                        }
                    }
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

        #region 重置密码 ResetPwd(int userID)
        /// <summary>
        /// 重置密码
        /// pxd 2015-09-25
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool ResetPwd(int userID)
        {
            return dal.ResetPwd(userID);
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
        public DataTable GetExportList(string loginName, string userName, string phone, string orgID)
        {
            return dal.GetExportList(loginName, userName, phone, orgID);
        }
        #endregion

        #region 扩展用户操作

        /// <summary>
        /// 添加/编辑用户
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orgID">组织ID</param>
        /// <returns></returns>
        public string Create(UsersInfo model, int? orgID)
        {
            model.UserCode = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), Tools.GetUniqueKey());
            string strReturn = string.Empty;
            Transaction transaction = new Transaction();
            object tran = transaction.CreatTransaction();
            try
            {
                if (model.DimissionDate.ToString() == "0001/1/1 0:00:00")
                {
                    model.DimissionDate = null;
                }
                if (model.UserID == 0)//添加
                {
                    //判断登录名是否重复
                    if (ExistsLoginName(tran, model.LoginName))
                    {
                        throw new Exception("登录名[" + model.LoginName + "]已存在，请重新输入！");
                    }

                    model.Pwd = Utility.DESEncrypt.GetMd5Str("123456");//添加时默认密码
                    model.CreateID = 0;
                    model.CreateName = "系统";
                    model.FirstPY = new CharPY().GetFirstPY(model.UserName);  //拼音码
                    model.CreateDate = DateTime.Now;
                    if (!Add(tran, model))
                    {
                        throw new Exception(ErrorPrompt.AddError);
                    }
                    model.UserID = new Tools().GetCurrentID(tran);
                }
                #region 添加用户所属组织
                //判断是否存在 存在则先删除
                if (new UsersOrganize().ExistsByUserID(tran, model.UserID))
                {
                    if (!new UsersOrganize().DeleteByUserID(tran, model.UserID))
                    {
                        throw new Exception("删除用户所在组织出错！");
                    }
                }
                #endregion

                if (orgID != null && orgID > 0)
                {
                    if (!new UsersOrganize().Add(tran, new UsersOrganizeInfo() { UserID = model.UserID, OrgID = orgID.Value }))
                    {
                        throw new Exception("添加用户所在组织出错！");
                    }
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