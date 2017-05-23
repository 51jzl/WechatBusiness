using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;

namespace HN.BLL
{
    /// <summary>
    /// 登录日志
    /// Author 2015-08-11
    /// </summary>
    public class LoginLog
    {
        private readonly DAL.LoginLog dal = new DAL.LoginLog();
        public LoginLog()
        { }

        #region 是否存在该记录 Exists(object tran,int LogID)
        /// <summary>
        /// 是否存在该记录
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int LogID)
        {
            return dal.Exists(tran, LogID);
        }
        #endregion

        #region 增加一条数据 Add(object tran,LoginLogInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, LoginLogInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,LoginLogInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, LoginLogInfo model)
        {
            return dal.Update(tran, model);
        }
        #endregion

        #region  删除一条数据 Delete(object tran,int LogID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int LogID)
        {
            return dal.Delete(tran, LogID);
        }
        #endregion

        #region 得到一个对象实体 LoginLogInfo GetModel(object tran,int LogID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LoginLogInfo GetModel(object tran, int LogID)
        {
            return dal.GetModel(tran, LogID);
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
        public DataTable GetLogList(int userID, string startDate, string endDate, int pageSize, int pageIndex)
        {
            return dal.GetLogList(userID, startDate, endDate, pageSize, pageIndex);
        }
        #endregion
    }
}