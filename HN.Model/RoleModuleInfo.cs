using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HN.Model
{
	//角色节点权限
	public class RoleModuleInfo
	{
   		private int _roleid;
		private int _modid;
				
      	/// <summary>
		/// 角色ID
        /// </summary>
        public int RoleID
        {
            get{ return _roleid; }
            set{ _roleid = value; }
        }        
		/// <summary>
		/// 模块主键ID
        /// </summary>
        public int ModID
        {
            get{ return _modid; }
            set{ _modid = value; }
        }        
				
    }
}

