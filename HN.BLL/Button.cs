using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using HN.Model;
using HN.Utility;

namespace HN.BLL
{
    /// <summary>
    /// 按钮表
    /// Author 2015-08-11
    /// </summary>
    public class Button
    {
        private readonly DAL.Button dal = new DAL.Button();
        public Button()
        { }

        #region 是否存在该记录 Exists(object tran,int BtnID)
        /// <summary>
        /// 是否存在该记录
        /// Author 2015-08-11
        /// </summary>
        public bool Exists(object tran, int BtnID)
        {
            return dal.Exists(tran, BtnID);
        }
        #endregion

        #region 增加一条数据 Add(object tran,ButtonInfo model)
        /// <summary>
        /// 增加一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Add(object tran, ButtonInfo model)
        {
            return dal.Add(tran, model);
        }
        #endregion

        #region 更新一条数据 Update(object tran,ButtonInfo model)
        /// <summary>
        /// 更新一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Update(object tran, ButtonInfo model)
        {
            return dal.Update(tran, model);
        }
        #endregion

        #region  删除一条数据 Delete(object tran,int BtnID)
        /// <summary>
        /// 删除一条数据
        /// Author 2015-08-11
        /// </summary>
        public bool Delete(object tran, int BtnID)
        {
            return dal.Delete(tran, BtnID);
        }
        #endregion

        #region 得到一个对象实体 ButtonInfo GetModel(object tran,int BtnID)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ButtonInfo GetModel(object tran, int BtnID)
        {
            return dal.GetModel(tran, BtnID);
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

        #region 获得数据列表 GetList(string btnCode,string btnName)
        /// <summary>
        /// 获得数据列表
        /// pxd 2015-09-22
        /// </summary>
        /// <param name="btnCode"></param>
        /// <param name="btnName"></param>
        /// <returns></returns>
        public DataTable GetList(string btnCode, string btnName)
        {
            return dal.GetList(btnCode, btnName);
        }
        #endregion

        #region 添加/编辑按钮 AddOrEditButton(ButtonInfo model)
        /// <summary>
        /// 添加/编辑按钮
        /// pxd 2015-09-23
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddOrEditButton(ButtonInfo model)
        {
            string strReturn = "";
            try
            {
                if (model.BtnID == 0)  //新增
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

        #region 判断按钮是否已经被引用 IsRelation(int btnID)
        /// <summary>
        /// 判断按钮是否已经被引用
        /// pxd 2015-09-22
        /// </summary>
        /// <param name="btnID"></param>
        /// <returns></returns>
        public bool IsRelation(int btnID)
        {
            return dal.IsRelation(btnID);
        }
        #endregion

        #region 删除按钮  DeleteButton(int btnID)
        /// <summary>
        /// 删除按钮 
        /// pxd 2015-09-24
        /// </summary>
        /// <param name="btnID"></param>
        /// <returns></returns>
        public string DeleteButton(int btnID)
        {
            string strReturn = "";
            //先判断是否关联其他数据
            if (!IsRelation(btnID))
            {
                if (!Delete(null,btnID))
                {
                    strReturn = ErrorPrompt.DeleError;
                }
            }
            else
            {
                strReturn = ErrorPrompt.RelateError;     
            }
            return strReturn;
        }
        #endregion
    }
}