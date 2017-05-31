using System;

namespace HN.Model
{
    /// <summary>
    /// 验证
    /// </summary>
    public class Verification
    {
        /// <summary>
        /// 序号
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public VerificationType Type { get; set; }

        /// <summary>
        /// 手机号码|email
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
    
    /// <summary>
    /// 短信验证接收类型
    /// </summary>
    public enum VerificationType {
        /// <summary>
        /// 手机
        /// </summary>
        Phone=0,
        /// <summary>
        /// 邮箱
        /// </summary>
        Email=1
    }
}
