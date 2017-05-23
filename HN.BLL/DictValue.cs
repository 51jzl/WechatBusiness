using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;
using HN.Utility;

namespace HN.BLL
{
    /// <summary>
    /// 字典表子表
    /// Author 2015-08-11
    /// </summary>
    public class DictValue
    {
        private readonly DAL.DictValue dal = new DAL.DictValue();
        public DictValue()
        { }

        #region 是否存在该记录 Exists(object tran,int ValID)
        /// <summary>
        /// 是否存在该记录
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int ValID)
        {
            return dal.Exists(tran, ValID);
        }
        #endregion

        #region 增加一条数据 Add(object tran,DictValueInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, DictValueInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,DictValueInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, DictValueInfo model)
        {
            return dal.Update(tran, model);
        }
        #endregion

        #region  删除一条数据 Delete(object tran,int ValID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int ValID)
        {
            return dal.Delete(tran, ValID);
        }
        #endregion

        #region 得到一个对象实体 DictValueInfo GetModel(object tran,int ValID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DictValueInfo GetModel(object tran, int ValID)
        {
            return dal.GetModel(tran, ValID);
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

        #region 根据关键字查询值列表 GetValueList(string keyID, int pageSize, int pageIndex)
        /// <summary>
        /// 根据关键字查询值列表
        /// pxd 2015-09-26
        /// </summary>
        /// <param name="keyID"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable GetValueList(string keyID, int pageSize, int pageIndex)
        {
            return dal.GetValueList(keyID, pageSize, pageIndex);
        }
        #endregion

        #region 根据关键字查询选项值 GetListByKey(string keyName,bool bf,string ftext)
        /// <summary>
        /// 根据关键字查询选项值
        /// pxd 2015-10-27
        /// </summary>
        public List<DictValueInfo> GetListByKey(string keyName, bool bf, string ftext)
        {
            return dal.GetListByKey(keyName, bf, ftext);
        }
        #endregion

        #region 判断值是否存在 ExistsValName(object tran, int keyID,string valName)
        /// <summary>
        /// 判断值是否存在
        /// pxd 2015-09-26
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool ExistsValName(object tran, int keyID, string valName)
        {
            return dal.ExistsValName(tran, keyID, valName);
        }
        #endregion

        #region 添加/编辑字典值 AddOrEdit(DictValueInfo model)
        /// <summary>
        /// 添加/编辑字典值
        /// pxd 2015-09-26
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddOrEdit(DictValueInfo model)
        {
            string strReturn = "";
            Transaction transaction = new Transaction();
            object tran = transaction.CreatTransaction();
            try
            {
                if (model.ValID == 0)//添加
                {
                    //判断登录名是否重复
                    if (!ExistsValName(tran, model.KeyID, model.ValName))
                    {
                        model.FirstPY = new CharPY().GetFirstPY(model.ValName); //拼音码
                        if (!Add(tran, model))
                        {
                            strReturn = ErrorPrompt.AddError;
                        }
                    }
                    else
                    {
                        strReturn = "选项值[" + model.ValName + "]已存在，请重新输入！";
                    }

                }
                else   //编辑
                {
                    DictValueInfo dictvalueinfo = GetModel(tran, model.ValID);
                    //判断登录名是否重复
                    if (dictvalueinfo.ValName.ToLower() == model.ValName.ToLower() || !ExistsValName(tran, model.KeyID, model.ValName))
                    {
                        model.FirstPY = new CharPY().GetFirstPY(model.ValName); //拼音码
                        if (!Update(tran, model))
                        {
                            strReturn = ErrorPrompt.UpdateError;
                        }
                    }
                    else
                    {
                        strReturn = "选项值[" + model.ValName + "]已存在，请重新输入！";
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