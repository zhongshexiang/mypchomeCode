using CZBK.ItcastOA.Common;
using CZBK.ItcastOA.IBLL;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPSTAR.System.ViewModel;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IBLL.IUserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            ViewBag.Title = "和鑫科技管理系统";
            ViewBag.SubTitle = "UPSTAR MVC Mangange System";
            return View();
        }

        #region 完成用户登录
        [ValidateJsonAntiForgeryToken]
        public JsonResult LoginAction(LoginViewModel LoginModel)
        {
            if (!ModelState.IsValid)
            {
                if (ModelState["UserName"].Errors.Count > 0)
                    return Json(new { status = "no", message = ModelState["UserName"].Errors[0].ErrorMessage }, JsonRequestBehavior.DenyGet);
                if (ModelState["Password"].Errors.Count > 0)
                    return Json(new { status = "no", message = ModelState["Password"].Errors[0].ErrorMessage }, JsonRequestBehavior.DenyGet);
                if (ModelState["CheckCode"].Errors.Count > 0)
                    return Json(new { status = "no", message = ModelState["CheckCode"].Errors[0].ErrorMessage }, JsonRequestBehavior.DenyGet);
                return Json(new { status = "no", message = "未定义错误" }, JsonRequestBehavior.DenyGet);
            }
            else
            {
                if (Convert.ToString(Session["validateCode"]).ToLower() != LoginModel.CheckCode.ToLower())
                    return Json(new { status = "no", message = "验证码错误" }, JsonRequestBehavior.DenyGet);

                var md5Pwd = Encryption.GetMd5Hash(LoginModel.UserName + LoginModel.Password);
                var model = UserInfoService.LoadEntities(u => u.UserName == LoginModel.UserName && u.Password == md5Pwd).FirstOrDefault();
                if (model == null)
                {
                    return Json(new { status = "no", message = "用户名或密码错误" }, JsonRequestBehavior.DenyGet);
                }

                var effectiveHours = SysConfig.GetConfigInt("LoginEffectiveHours");
                WebFormsAuth.SignIn(LoginModel.UserName, LoginModel, LoginModel.RememberMe, 60 * effectiveHours);

                //记录用户的登录日志

                Session["validateCode"] = null;
                return Json(new { status = "ok", message = "登陆成功！" }, JsonRequestBehavior.DenyGet);
            }
            //string validateCode = Session["validateCode"] != null ? Session["validateCode"].ToString() : string.Empty;
            //if (string.IsNullOrEmpty(validateCode))
            //{
            //    return Content("no:验证码错误!!");
            //}
            //Session["validateCode"] = null;
            //string txtCode = Request["vCode"];
            //if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            //{
            //    return Content("no:验证码错误!!");
            //}
            //string userName = Request["LoginCode"];
            //string userPwd = Request["LoginPwd"];
            //根据用户名找用户
            //if (userInfo != null)
            //{
            //    // Session["userInfo"] = userInfo;
            //    //产生一个GUID值作为Memache的键.
            //    //  System.Web.Script.Serialization.JavaScriptSerializer
            //    string sessionId = Guid.NewGuid().ToString();
            //    Common.MemcacheHelper.Set(sessionId, Common.SerializeHelper.SerializeToString(userInfo)
            //        , DateTime.Now.AddMinutes(20));//将登录用户信息存储到Memcache中。
            //    Response.Cookies["sessionId"].Value = sessionId;//将Memcache的key以Cookie的形式返回给浏览器。


            //    return Content("ok:登录成功");
            //}
            //else
            //{

            //    return Content("no:登录失败");
            //}
            //}

        }
        #endregion

        #region 显示验证码
        public ActionResult ShowValidateCode()
        {
            string code = string.Empty;
            byte[] bytes = new Common.ValidateCode().CreateValidateGraphic(out code, 4, 100, 30, 20);
            Session["validateCode"] = code;
            //var aaa = Common.MemcacheHelper.Set("CZBK.ItcastOA.WebApp.Controllers.key", "nima");
            //var bbb = Common.MemcacheHelper.Get("CZBK.ItcastOA.WebApp.Controllers.key");
            ////Response.Cookies["sessionId"].Value = sessionId;//将Memcache的key以Cookie的形式返回给浏览器。
            return File(bytes, @"image/jpeg");
        }
        #endregion
    }
}
