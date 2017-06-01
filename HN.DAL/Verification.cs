using HN.Model;
using PetaPoco;
using System.Collections.Generic;

namespace HN.DAL
{
    public class Verification
    {
        Database db = new Database("connstr");

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="type"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public IEnumerable<Model.Verification> Query(VerificationType type, string to)
        {
            Sql sql = new Sql("SELECT * FROM tn_Verification");
            Sql whereSql = new Sql();
            Sql orderSql = new Sql();
            whereSql.Where("[Type]=@0", type);
            whereSql.Where("[To]=@0", to);
            whereSql.Where("DATEDIFF(MINUTE,DateCreated,GETDATE())<3");
            orderSql.OrderBy("DateCreated desc");
            sql.Append(whereSql).Append(orderSql);
            return db.Query<Model.Verification>(sql);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        public void Create(Model.Verification entity)
        {
            db.Insert(entity);
        }
    }
}
