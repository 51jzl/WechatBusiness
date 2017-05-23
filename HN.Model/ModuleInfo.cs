using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace HN.Model
{
    //模块表
    public class ModuleInfo
    {
        private int _modid;
        private int _parentid;
        private string _targe;
        private string _modname;
        private string _modtitle;
        private string _link;
        private string _icon;
        private int _isend;
        private int _isenable;
        private int _type;
        private int _sort;

        /// <summary>
        /// 主键
        /// </summary>
        public int ModID
        {
            get { return _modid; }
            set { _modid = value; }
        }
        /// <summary>
        /// 上级节点 0为顶级
        /// </summary>
        public int ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// 链接目标 Iframe Open
        /// </summary>
        public string Targe
        {
            get { return _targe; }
            set { _targe = value; }
        }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModName
        {
            get { return _modname; }
            set { _modname = value; }
        }
        /// <summary>
        /// 模块Title
        /// </summary>
        public string ModTitle
        {
            get { return _modtitle; }
            set { _modtitle = value; }
        }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Link
        {
            get { return _link; }
            set { _link = value; }
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
        /// 是否末级节点 
        /// </summary>
        public int IsEnd
        {
            get { return _isend; }
            set { _isend = value; }
        }
        /// <summary>
        /// 是否可用
        /// </summary>
        public int IsEnable
        {
            get { return _isenable; }
            set { _isenable = value; }
        }
        /// <summary>
        /// 菜单类型 0通用 1system
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
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

