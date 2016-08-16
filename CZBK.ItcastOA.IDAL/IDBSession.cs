using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.IDAL
{

    public partial interface IDBSession
    {
        DbContext Db { get; }
        bool SaveChanges();
        int ExecuteSql(string sql, params SqlParameter[] pars);
        List<T> ExecuteQuery<T>(string sql, params SqlParameter[] pars);

        #region 处理当前会话能够提供的业务处理类
        //IActionInfoDal ActionInfoDal { get; set; }
        //IBooksDal BooksDal { get; set; }
        //IDepartmentDal DepartmentDal { get; set; }
        //IKeyWordsRankDal KeyWordsRankDal { get; set; }
        //IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get; set; }
        //IRoleInfoDal RoleInfoDal { get; set; }
        //ISearchDetailsDal SearchDetailsDal { get; set; }
        IUserInfoDal UserInfoDal { get; set; }
        #endregion
    }
}
