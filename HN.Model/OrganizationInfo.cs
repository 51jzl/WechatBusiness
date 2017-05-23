using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HN.Model
{
	//组织表
	public class OrganizationInfo
	{
   		private int _orgid;
		private string _orgcode;
		private string _orgname;
		private string _manager;
		private string _assistantmanager;
		private string _innerphone;
		private string _outerphone;
		private string _fax;
		private int _sort;
		private string _address;
		private string _remark;
		private int _parentid;
		private int _deletemark;
		private int _createid;
		private string _createname;
		private DateTime _createdate;
				
      	/// <summary>
		/// 组织ID
        /// </summary>
        public int OrgID
        {
            get{ return _orgid; }
            set{ _orgid = value; }
        }        
		/// <summary>
		/// OrgCode
        /// </summary>
        public string OrgCode
        {
            get{ return _orgcode; }
            set{ _orgcode = value; }
        }        
		/// <summary>
		/// 组织名称
        /// </summary>
        public string OrgName
        {
            get{ return _orgname; }
            set{ _orgname = value; }
        }        
		/// <summary>
		/// 主负责人
        /// </summary>
        public string Manager
        {
            get{ return _manager; }
            set{ _manager = value; }
        }        
		/// <summary>
		/// 副负责人
        /// </summary>
        public string AssistantManager
        {
            get{ return _assistantmanager; }
            set{ _assistantmanager = value; }
        }        
		/// <summary>
		/// 内线电话
        /// </summary>
        public string InnerPhone
        {
            get{ return _innerphone; }
            set{ _innerphone = value; }
        }        
		/// <summary>
		/// 外线电话
        /// </summary>
        public string OuterPhone
        {
            get{ return _outerphone; }
            set{ _outerphone = value; }
        }        
		/// <summary>
		/// 传真
        /// </summary>
        public string Fax
        {
            get{ return _fax; }
            set{ _fax = value; }
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
		/// 所在地址
        /// </summary>
        public string Address
        {
            get{ return _address; }
            set{ _address = value; }
        }        
		/// <summary>
		/// 说明
        /// </summary>
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }        
		/// <summary>
		/// 上级ID 0代表顶级
        /// </summary>
        public int ParentID
        {
            get{ return _parentid; }
            set{ _parentid = value; }
        }        
		/// <summary>
		/// 删除标志 0正常 1删除
        /// </summary>
        public int DeleteMark
        {
            get{ return _deletemark; }
            set{ _deletemark = value; }
        }        
		/// <summary>
		/// 添加人ID
        /// </summary>
        public int CreateID
        {
            get{ return _createid; }
            set{ _createid = value; }
        }        
		/// <summary>
		/// 添加人名称
        /// </summary>
        public string CreateName
        {
            get{ return _createname; }
            set{ _createname = value; }
        }        
		/// <summary>
		/// 添加时间
        /// </summary>
        public DateTime CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }        
				
    }
}

