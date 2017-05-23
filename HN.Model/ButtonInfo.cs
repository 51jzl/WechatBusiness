using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace HN.Model
{
    //按钮表
    public class ButtonInfo
    {
        private int _btnid;
        private string _btncode;
        private string _btnname;
        private string _btntitle;
        private string _btnclick;
        private string _icon;
        private int _type;
        private string _action;
        private int _sort;

        /// <summary>
        /// 主键ID
        /// </summary>
        public int BtnID
        {
            get { return _btnid; }
            set { _btnid = value; }
        }
        /// <summary>
        /// 按钮控件ID
        /// </summary>
        public string BtnCode
        {
            get { return _btncode; }
            set { _btncode = value; }
        }
        /// <summary>
        /// 按钮名称
        /// </summary>
        public string BtnName
        {
            get { return _btnname; }
            set { _btnname = value; }
        }
        /// <summary>
        /// 按钮Title
        /// </summary>
        public string BtnTitle
        {
            get { return _btntitle; }
            set { _btntitle = value; }
        }
        /// <summary>
        /// 按钮执行的JS事件
        /// </summary>
        public string BtnClick
        {
            get { return _btnclick; }
            set { _btnclick = value; }
        }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
        /// <summary>
        /// 按钮类型 0通用 1 System
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// 动作 对应控制器中方法名
        /// </summary>
        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
    }
}
