using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HN.Model
{
	//角色表
	public class RolesInfo
	{
   		private int _roleid;
		private string _rolename;
        private int _isdefault = 0;
		private int _sort;
		private string _remark;
				
      	/// <summary>
		/// 角色主键
        /// </summary>
        public int RoleID
        {
            get{ return _roleid; }
            set{ _roleid = value; }
        }        
		/// <summary>
		/// 角色名称
        /// </summary>
        public string RoleName
        {
            get{ return _rolename; }
            set{ _rolename = value; }
        }
        /// <summary>
        /// 是否默认角色
        /// </summary>
        public int IsDefault
        {
            get { return _isdefault; }
            set { _isdefault = value; }
        }   
		/// <summary>
		/// 排序
        /// </summary>
        public int Sort
        {
            get{ return _sort; }
            set{ _sort = value; }
        }        
		/// <summary>
		/// 备注
        /// </summary>
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }        		
    }
}

