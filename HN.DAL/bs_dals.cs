using HN.Model;
using PetaPoco;
using System.Collections.Generic;

namespace HN.DAL
{
    public class bs_ProjectDal
    {
        Database db = new Database("connstr");

        /// <summary>
        /// 根据用户id查询
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IEnumerable<bs_Project> Query(int userid)
        {
            Sql sql = new Sql("SELECT * FROM bs_Project");
            return db.Query<bs_Project>(sql);
        }

        /// <summary>
        /// 根据项目id获取项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bs_Project Get(long id)
        {
            Sql sql = new Sql("SELECT * FROM bs_Project");
            Sql whereSql = new Sql();
            whereSql.Where("ID=@0", id);
            sql.Append(whereSql);
            return db.SingleOrDefault<bs_Project>(sql);
        }

        /// <summary>
        /// 创建项目
        /// </summary>
        /// <param name="model"></param>
        public void Create(bs_Project model)
        {
            try
            {
                db.Insert(model);
            }
            catch (System.Exception)
            {

            }
        }

        /// <summary>
        /// 更新项目
        /// </summary>
        /// <param name="model"></param>
        public bool Update(bs_Project model)
        {
            if (db.Update(model) > 0)
                return true;
            return false;
        }
    }
}
