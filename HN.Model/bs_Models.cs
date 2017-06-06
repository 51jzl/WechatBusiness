using PetaPoco;

namespace HN.Model
{
    /// <summary>
    /// 微商项目
    /// </summary>
    [TableName("bs_Project")]
    [PrimaryKey("ID", AutoIncrement = true)]
    public class bs_Project
    {
        /// <summary>
        /// 序号
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 项目名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; }
    }
}
