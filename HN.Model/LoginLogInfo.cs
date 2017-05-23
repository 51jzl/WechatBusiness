using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace HN.Model
{
	//登录日志
	public class LoginLogInfo
	{
   		private int _logid;
		private int _userid;
		private string _loginname;
		private int _state;
		private string _loginip;
		private string _ipaddress;
		private DateTime _logintime=DateTime.Now;
				
      	/// <summary>
		/// 主键ID
        /// </summary>
        public int LogID
        {
            get{ return _logid; }
            set{ _logid = value; }
        }        
		/// <summary>
		/// 用户ID
        /// </summary>
        public int UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
		/// <summary>
		/// 登录账户
        /// </summary>
        public string LoginName
        {
            get{ return _loginname; }
            set{ _loginname = value; }
        }        
		/// <summary>
		/// 登录状态 0失败 1成功
        /// </summary>
        public int State
        {
            get{ return _state; }
            set{ _state = value; }
        }        
		/// <summary>
		/// 登录IP
        /// </summary>
        public string LoginIP
        {
            get{ return _loginip; }
            set{ _loginip = value; }
        }        
		/// <summary>
		/// IP所在地址
        /// </summary>
        public string IPAddress
        {
            get{ return _ipaddress; }
            set{ _ipaddress = value; }
        }        
		/// <summary>
		/// 登录时间
        /// </summary>
        public DateTime LoginTime
        {
            get{ return _logintime; }
            set{ _logintime = value; }
        }        
				
    }
}

