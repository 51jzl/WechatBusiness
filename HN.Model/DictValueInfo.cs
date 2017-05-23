using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HN.Model
{
	//字典表子表
	public class DictValueInfo
	{
   		private int _valid;
		private int _keyid;
		private string _valname;
        private string _firstpy;
		private int _sort;
		private string _remark;
				
      	/// <summary>
		/// 主键ID
        /// </summary>
        public int ValID
        {
            get{ return _valid; }
            set{ _valid = value; }
        }        
		/// <summary>
		/// 主表ID
        /// </summary>
        public int KeyID
        {
            get{ return _keyid; }
            set{ _keyid = value; }
        }        
		/// <summary>
		/// 值
        /// </summary>
        public string ValName
        {
            get{ return _valname; }
            set{ _valname = value; }
        }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string FirstPY
        {
            get { return _firstpy; }
            set { _firstpy = value; }
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
		/// Remark
        /// </summary>
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }        
				
    }
}

