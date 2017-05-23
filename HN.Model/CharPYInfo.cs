using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HN.Model
{
	//拼音表
	public class CharPYInfo
	{
   		private int _pyid;
		private string _charname;
		private string _py;
		private string _firstpy;
				
      	/// <summary>
		/// 主键ID
        /// </summary>
        public int PYID
        {
            get{ return _pyid; }
            set{ _pyid = value; }
        }        
		/// <summary>
		/// 字符
        /// </summary>
        public string CharName
        {
            get{ return _charname; }
            set{ _charname = value; }
        }        
		/// <summary>
		/// 拼音
        /// </summary>
        public string PY
        {
            get{ return _py; }
            set{ _py = value; }
        }        
		/// <summary>
		/// 拼音首字母
        /// </summary>
        public string FirstPY
        {
            get{ return _firstpy; }
            set{ _firstpy = value; }
        }        
				
    }
}

