using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;

namespace HN.BLL
{
    /// <summary>
    /// 拼音表
    /// Author 2015-08-11
    /// </summary>
    public class CharPY
    {
        private readonly DAL.CharPY dal = new DAL.CharPY();
        public CharPY()
        { }

        #region 是否存在该记录 Exists(object tran,int PYID)
        /// <summary>
        /// 是否存在该记录
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int PYID)
        {
            return dal.Exists(tran, PYID);
        }
        #endregion

        #region 增加一条数据 Add(object tran,CharPYInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, CharPYInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,CharPYInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, CharPYInfo model)
        {
            return dal.Update(tran, model);
        }
        #endregion

        #region  删除一条数据 Delete(object tran,int PYID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int PYID)
        {
            return dal.Delete(tran, PYID);
        }
        #endregion

        #region 得到一个对象实体 CharPYInfo GetModel(object tran,int PYID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CharPYInfo GetModel(object tran, int PYID)
        {
            return dal.GetModel(tran, PYID);
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

        #region 获取拼音首字母 GetFirstPY(string strName)
        /// <summary>
        /// 获取拼音首字母
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns></returns>
        public string GetFirstPY(string strName)
        {
            return dal.GetFirstPY(strName);
        }
        #endregion

    }
}