using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;
using HN.Utility;

namespace HN.BLL
{
    /// <summary>
    /// 页面按钮表
    /// Author 2015-08-11
    /// </summary>
    public class ModuleButton
    {
        private readonly DAL.ModuleButton dal = new DAL.ModuleButton();
        public ModuleButton()
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

        #region 增加一条数据 Add(object tran,ModuleButtonInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Add(object tran, ModuleButtonInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,ModuleButtonInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-09-22
        /// </summary>
        public bool Update(object tran, ModuleButtonInfo model)
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

        #region 得到一个对象实体 ModuleButtonInfo GetModel(object tran,int ModID,int BtnID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ModuleButtonInfo GetModel(object tran, int ModID, int BtnID)
        {
            return dal.GetModel(tran, ModID, BtnID);
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

        #region 根据页面ID获取所有按钮和页面所选择的按钮 GetListByModID(int modID)
        /// <summary>
        /// 获取所有按钮和页面所选择的按钮
        /// pxd 2015-10-15
        /// </summary>
        /// <param name="modID"></param>
        /// <returns></returns>
        public DataTable GetListByModID(int modID)
        {
            return dal.GetListByModID(modID);
        }
        #endregion

        #region 给菜单页面设置按钮 SetButton(int modID, List<int> btnIDList)
        /// <summary>
        /// 给菜单页面设置按钮
        /// pxd 2015-10-15
        /// </summary>
        /// <param name="modID"></param>
        /// <param name="btnIDList"></param>
        /// <returns></returns>
        public string SetButton(int modID, List<int> btnIDList)
        {
            string strReturn = "";
            Transaction transaction = new Transaction();
            object tran = transaction.CreatTransaction();
            try
            {
                //先判断页面按钮是否存在
                if (Exists(tran, modID))
                {
                    //先删除页面按钮
                    if (!Delete(tran, modID))
                    {
                        throw new Exception(ErrorPrompt.DeleError);
                    }
                }
                ModuleButtonInfo model = new ModuleButtonInfo();
                model.ModID = modID;
                if (btnIDList != null)
                {
                    foreach (int btnID in btnIDList)
                    {
                        model.BtnID = btnID;
                        if (!Add(tran, model))
                        {
                            throw new Exception(ErrorPrompt.AddError);
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
    }
}