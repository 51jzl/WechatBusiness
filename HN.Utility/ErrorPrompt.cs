using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HN.Utility
{
    public class ErrorPrompt
    {
        public static string AddError { get { return "添加了零条数据，添加失败！"; } }
        public static string UpdateError { get { return "更新了零条数据，更新失败！"; } }
        public static string DeleError { get { return "删除了零条数据，删除失败！"; } }
        public static string RelateError { get { return "删除失败，数据已经被引用，请删除引用数据后重试!"; } }
    }
}
