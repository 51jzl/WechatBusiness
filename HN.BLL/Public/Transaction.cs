using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;

namespace HN.BLL
{
    public class Transaction
    {
        private DAL.Transaction _itran = new DAL.Transaction();
        public Transaction()
        {}

        /// <summary>
        /// 创建事务
        /// </summary>
        /// <returns>事务</returns>
        public object CreatTransaction()
        {
            return _itran.CreatTransaction();
        }

        /// <summary>
        /// 创建事务
        /// </summary>
        /// <param name="conn">连接字符串</param>
        /// <returns>事务</returns>
        public object CreatTransaction(string conn)
        {
            return _itran.CreatTransaction(conn);
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="tran">事务</param>
        public void Commit(object tran)
        {
            _itran.Commit(tran);
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="tran">事务</param>
        public void Rollback(object tran)
        {
            _itran.Rollback(tran);
        }

    }
}
