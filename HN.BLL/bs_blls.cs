using HN.DAL;
using HN.Model;
using System.Collections.Generic;

namespace HN.BLL
{
    public class bs_ProjectBll
    {
        private readonly bs_ProjectDal dal = new bs_ProjectDal();

        /// <summary>
        /// 根据用户id查询
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IEnumerable<bs_Project> Query(int userid)
        {
            return dal.Query(userid);
        }

        /// <summary>
        /// 根据项目id获取项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bs_Project Get(long id)
        {
            return dal.Get(id);
        }

        /// <summary>
        /// 创建项目
        /// </summary>
        /// <param name="model"></param>
        public void Create(bs_Project model)
        {
            dal.Create(model);
        }

        /// <summary>
        /// 更新项目
        /// </summary>
        /// <param name="model"></param>
        public bool Update(bs_Project model)
        {
            return dal.Update(model);
        }
    }
}
