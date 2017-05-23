using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HN.Model
{
	//用户角色表
	public class UsersRoleInfo
	{
   		private int _userid;
		private int _roleid;
				
      	/// <summary>
		/// 用户ID
        /// </summary>
        public int UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
		/// <summary>
		/// 角色ID
        /// </summary>
        public int RoleID
        {
            get{ return _roleid; }
            set{ _roleid = value; }
        }        
				
    }
}

