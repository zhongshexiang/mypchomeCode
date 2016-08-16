using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.Common
{
    public class SysConfig
    {
        /// <summary>
        /// 得到AppSettings中的配置字符串信息
        /// </summary>
        /// <param name="key">AppSetting中关键字KEY</param>
        /// <returns>AppSettings中的配置字符串信息</returns>
        public static string GetConfigString(string key)
        {
            string AppStr = ConfigurationManager.AppSettings[key].ToString();
            return AppStr;
        }

        #region 得到Connection中配置字符串信息
        /// <summary>
        /// 得到Connection中配置字符串信息
        /// </summary>
        /// <param name="key">Connection中name的值</param>
        /// <returns>Connection中name的值</returns>
        public static string GetConnectionString(string key)
        {
            string ConnStr = ConfigurationManager.ConnectionStrings[key].ToString();
            return ConnStr;
        }
        #endregion

        #region 得到AppSettings中的配置Bool信息
        /// <summary>
        /// 得到AppSettings中的配置Bool信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetConfigBool(string key)
        {
            bool result = false;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                try
                {
                    result = bool.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }
            return result;
        }
        #endregion

        #region 得到AppSettings中的配置Decimal信息
        /// <summary>
        /// 得到AppSettings中的配置Decimal信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetConfigDecimal(string key)
        {
            decimal result = 0;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                try
                {
                    result = decimal.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }

            return result;
        }
        #endregion

        #region 得到AppSettings中的配置int信息
        /// <summary>
        /// 得到AppSettings中的配置int信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetConfigInt(string key)
        {
            int result = 0;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                try
                {
                    result = int.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }

            return result;
        }
        #endregion

    }
}
