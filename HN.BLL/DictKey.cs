using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using HN.Model;

namespace HN.BLL
{
	/// <summary>
	/// 字典主表
	/// Author 2015-08-11
	/// </summary>
	public class DictKey
	{
		private readonly DAL.DictKey dal=new DAL.DictKey();
		public DictKey()
		{}
		
		#region 是否存在该记录 Exists(object tran,int KeyID)
		/// <summary>
		/// 是否存在该记录
	    /// Author 2015-08-11
		/// </summary>
		public bool Exists(object tran,int KeyID)
		{
			return dal.Exists(tran,KeyID);
		}
        #endregion
        
        #region 增加一条数据 Add(object tran,DictKeyInfo model)
		/// <summary>
		/// 增加一条数据
		/// Author 2015-08-11
		/// </summary>
		public bool Add(object tran,DictKeyInfo model)
		{
			return dal.Add(tran,model);		
		}
        #endregion
        
        #region 更新一条数据 Update(object tran,DictKeyInfo model)
		/// <summary>
		/// 更新一条数据
		/// Author 2015-08-11
		/// </summary>
		public bool Update(object tran,DictKeyInfo model)
		{
			return dal.Update(tran,model);
		}
        #endregion
        
        #region  删除一条数据 Delete(object tran,int KeyID)
		/// <summary>
		/// 删除一条数据
		/// Author 2015-08-11
		/// </summary>
		public bool Delete(object tran,int KeyID)
		{
			return dal.Delete(tran,KeyID);
		}
        #endregion
        
        #region 得到一个对象实体 DictKeyInfo GetModel(object tran,int KeyID)
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DictKeyInfo GetModel(object tran,int KeyID)
		{
			return dal.GetModel(tran,KeyID);
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

        #region 获取Tree Json  GetTreeJson()
        /// <summary>
        ///  获取Tree Json 
        ///  pxd 2015-09-26
        /// </summary>
        /// <returns></returns>
        public string GetTreeJson()
        {
            StringBuilder bulider = new StringBuilder();
            DataTable dt = GetList("");
            bulider.Append("[{");
            bulider.Append("\"id\":\"\"");
            bulider.Append(",\"text\":\"关键字\"");

            if (dt.Rows.Count > 0)
            {
                bulider.Append(",\"children\":[");
                foreach (DataRow dr in dt.Rows)
                {
                    bulider.Append("{");
                    bulider.Append("\"id\":\"" + dr["KeyID"] + "\"");
                    bulider.Append(",\"text\":\"" + dr["KeyName"] + "\"");
                    bulider.Append(",\"iconCls\":\"icon-tree-folder\"");
                    bulider.Append("},");
                }
                bulider.Append("]");
            }
            bulider.Append("}]");

            string strReturn =Tools.ConvertJsonString(bulider.ToString());
            return strReturn;
        }
        #endregion
	}
}