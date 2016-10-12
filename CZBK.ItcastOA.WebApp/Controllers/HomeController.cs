using CZBK.ItcastOA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPSTAR.System.ViewModel;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        
        public ActionResult Index()
        {
            var loginer = WebFormsAuth.GetUserData<LoginViewModel>();
            ViewBag.UserName = loginer.UserName;
            ViewBag.Title = "和鑫科技管理系统";
            return View();
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult changePWAction(changePWViewModel Model)
        {
            if (!ModelState.IsValid)
            {
                if (ModelState["oldPw"].Errors.Count > 0)
                    return Json(new { status = "no", message = ModelState["oldPw"].Errors[0].ErrorMessage }, JsonRequestBehavior.DenyGet);
                if (ModelState["newPw"].Errors.Count > 0)
                    return Json(new { status = "no", message = ModelState["newPw"].Errors[0].ErrorMessage }, JsonRequestBehavior.DenyGet);
                if (ModelState["confirmPw"].Errors.Count > 0)
                    return Json(new { status = "no", message = ModelState["confirmPw"].Errors[0].ErrorMessage }, JsonRequestBehavior.DenyGet);
                return Json(new { status = "no", message = "未定义错误" }, JsonRequestBehavior.DenyGet);
            }
            string ErrMsg = string.Empty;
            if (UserInfoService.ChangePW(WebFormsAuth.GetUserData().UserName, Model.oldPw, Model.newPw, out ErrMsg))
                return Json(new { status = "ok", message = string.Empty }, JsonRequestBehavior.DenyGet);
            else
                return Json(new { status = "error", message = ErrMsg }, JsonRequestBehavior.DenyGet);
        }

        public ActionResult Logout()
        {
            WebFormsAuth.SingOut();
            return Redirect("~/Login");
        }
    }
}
