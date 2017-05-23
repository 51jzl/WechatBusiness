using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HN.Model
{
	//用户部门关系表
	public class UsersOrganizeInfo
	{
   		private int _userid;
		private int _orgid;
				
      	/// <summary>
		/// 用户ID
        /// </summary>
        public int UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
		/// <summary>
		/// 部门ID
        /// </summary>
        public int OrgID
        {
            get{ return _orgid; }
            set{ _orgid = value; }
        }        
				
    }
}

