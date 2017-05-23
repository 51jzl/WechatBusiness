namespace HN.UI
{
    /// <summary>
    /// 消息实体
    /// </summary>
    public class MessageJSON
    {
        /// <summary>
        /// 详细状态
        /// </summary>
        public MessageState State { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public MessageIcon Icon { get; set; }
    }

    /// <summary>
    /// 消息状态
    /// </summary>
    public enum MessageState
    {
        /// <summary>
        /// 状态成功
        /// </summary>
        success = 1,
        /// <summary>
        /// 状态异常
        /// </summary>
        abnormality = 2,
        /// <summary>
        /// 失败
        /// </summary>
        fail = 3
    }

    /// <summary>
    /// 消息图标
    /// </summary>
    public enum MessageIcon
    {
        /// <summary>
        /// 对的
        /// </summary>
        yes = 1,
        /// <summary>
        /// 错的
        /// </summary>
        no = 2,
        /// <summary>
        /// 疑问
        /// </summary>
        question = 3,
        /// <summary>
        /// 锁
        /// </summary>
        locks = 4,
        /// <summary>
        /// 不开心
        /// </summary>
        unhappy = 5,
        /// <summary>
        /// 开心
        /// </summary>
        happy = 6,
        /// <summary>
        /// 警告
        /// </summary>
        warning = 7
    }
}