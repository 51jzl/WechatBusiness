using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using HN.Utility;

namespace HN.DAL
{
    public class Transaction 
    {
        public Transaction()
        { }
        /// <summary>
        /// 创建事务
        /// </summary>
        /// <returns>事务</returns>
        public object CreatTransaction()
        {
            try
            {
                return SQLHelper.CreatTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 创建事务
        /// </summary>
        /// <param name="conn">连接字符串</param>
        /// <returns>事务</returns>
        public object CreatTransaction(string conn)
        {
            try
            {
                return SQLHelper.CreatTransaction(conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="tran"></param>
        public void Commit(object tran)
        {
            try
            {
                ((SqlTransaction)tran).Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="tran"></param>
        public void Rollback(object tran)
        {
            try
            {
                ((SqlTransaction)tran).Rollback();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
