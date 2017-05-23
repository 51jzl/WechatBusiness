using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HN.Model
{
	//角色页面按钮表
	public class RoleModButtonInfo
	{
   		private int _roleid;
		private int _modid;
		private int _btnid;
				
      	/// <summary>
		/// 角色ID
        /// </summary>
        public int RoleID
        {
            get{ return _roleid; }
            set{ _roleid = value; }
        }        
		/// <summary>
		/// 模块ID
        /// </summary>
        public int ModID
        {
            get{ return _modid; }
            set{ _modid = value; }
        }        
		/// <summary>
		/// 按钮ID
        /// </summary>
        public int BtnID
        {
            get{ return _btnid; }
            set{ _btnid = value; }
        }        
				
    }
}

