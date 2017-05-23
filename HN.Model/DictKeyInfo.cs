using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HN.Model
{
	//字典主表
	public class DictKeyInfo
	{
   		private int _keyid;
		private string _keyname;
		private int _sort;
		private string _remark;
				
      	/// <summary>
		/// 主键ID
        /// </summary>
        public int KeyID
        {
            get{ return _keyid; }
            set{ _keyid = value; }
        }        
		/// <summary>
		/// 名称
        /// </summary>
        public string KeyName
        {
            get{ return _keyname; }
            set{ _keyname = value; }
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

