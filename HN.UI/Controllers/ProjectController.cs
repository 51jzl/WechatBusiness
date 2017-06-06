using HN.BLL;
using HN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HN.UI.Controllers
{
    public class ProjectController : Controller
    {
        bs_ProjectBll bs_ProjectBll = new bs_ProjectBll();

        /// <summary>
        /// 创建项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 创建项目子页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult projectDialog()
        {
            return View();
        }

        #region 接口

        /// <summary>
        /// 创建、更新项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CORU(bs_Project model)
        {
            MessageJSON mj = new MessageJSON(MessageState.fail, "操作失败", MessageIcon.no);
            if (model.ID == 0)
            {
                bs_ProjectBll.Create(model);
                if (model != null && model.ID > 0)
                    mj = new MessageJSON(MessageState.success, "创建项目成功", MessageIcon.yes);
                else
                    mj = new MessageJSON(MessageState.fail, "项目名不为空且项目&公司不重复", MessageIcon.no);
            }
            else
            {
                if (bs_ProjectBll.Update(model))
                    mj = new MessageJSON(MessageState.success, "更新项目成功", MessageIcon.yes);
                else
                    mj = new MessageJSON(MessageState.fail, "更新项目失败", MessageIcon.no);
            }
            return Json(mj, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取用户项目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UserGet()
        {
            MessageJSON mj = new MessageJSON(MessageState.fail, "操作失败", MessageIcon.no);
            if (SessionInfo.UserID != null)
            {
                IEnumerable<bs_Project> data = bs_ProjectBll.Query((int)SessionInfo.UserID);
                mj = new MessageJSON(MessageState.success, "请求成功", MessageIcon.yes, data: data);
            }
            else
            {
                mj = new MessageJSON(MessageState.abnormality, "登录异常，请刷新页面！", MessageIcon.warning);
            }
            return Json(mj, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
