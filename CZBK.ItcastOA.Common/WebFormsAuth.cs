using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using UPSTAR.System.ViewModel;

namespace CZBK.ItcastOA.Common
{
    public class WebFormsAuth
    {
        public static void SignIn(string loginName, object userData,bool RememberMe, int expireMin)
        {
            if (string.IsNullOrEmpty(loginName))
                throw new ArgumentNullException("loginName");
            if (userData == null)
                throw new ArgumentNullException("userData");

            var data = JsonConvert.SerializeObject(userData);

            //创建一个FormsAuthenticationTicket，它包含登录名以及额外的用户数据。
            var ticket = new FormsAuthenticationTicket(2,
                loginName, DateTime.Now, DateTime.Now.AddMinutes(expireMin), RememberMe, data);

            //加密Ticket，变成一个加密的字符串。
            var cookieValue = FormsAuthentication.Encrypt(ticket);

            //根据加密结果创建登录Cookie
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue)
            {
                Name="upstarAuth",
                HttpOnly = true,
                Secure = FormsAuthentication.RequireSSL,
                Domain = FormsAuthentication.CookieDomain,
                Path = FormsAuthentication.FormsCookiePath
            };
            if (RememberMe && expireMin > 0)
                cookie.Expires = DateTime.Now.AddMinutes(expireMin);

            var context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException();

            //写登录Cookie
            context.Response.Cookies.Remove(cookie.Name);
            context.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 安全退出
        /// </summary>
        public static void SingOut()
        {
            FormsAuthentication.SignOut();
        }

        public static LoginViewModel GetUserData()
        {
            return GetUserData<LoginViewModel>();
        }

        public static T GetUserData<T>() where T : class, new()
        {
            var UserData = new T();
            try
            {
                var context = HttpContext.Current;
                var cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                UserData = JsonConvert.DeserializeObject<T>(ticket.UserData);
            }
            catch
            { }

            return UserData;
        }

    }
}
