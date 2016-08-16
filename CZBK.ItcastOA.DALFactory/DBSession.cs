using CZBK.ItcastOA.DAL;
using CZBK.ItcastOA.IDAL;
using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CZBK.ItcastOA.DALFactory
{
    /// <summary>
    /// 数据会话层：就是一个工厂类，负责完成所有数据操作类实例的创建，
    /// 然后业务层通过数据会话层来获取要操作数据类的实例。所以数据会话层将业务层与数据层解耦。
    /// 在数据会话层中提供一个方法：完成所有数据的保存。
    /// </summary>
    public partial class DBSession : IDBSession
    {
        /// <summary>
        /// 关联数据库的线程内唯一的EF对象
        /// </summary>
        public DbContext Db
        {
            get
            {
                return DBContextFactory.CreateDbContext();
            }
        }

        /// <summary>
        /// 一个业务中经常涉及到对多张操作，我们希望链接一次数据库，完成对张表数据的操作。提高性能。 工作单元模式。
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }
        public int ExecuteSql(string sql, params SqlParameter[] pars)
        {
            return Db.Database.ExecuteSqlCommand(sql, pars);
        }
        public List<T> ExecuteQuery<T>(string sql, params SqlParameter[] pars)
        {
            return Db.Database.SqlQuery<T>(sql, pars).ToList();
        }

        #region 处理当前会话能够提供的业务处理类
        //private IActionInfoDal _ActionInfoDal;
        //public IActionInfoDal ActionInfoDal
        //{
        //    get
        //    {
        //        if (_ActionInfoDal == null)
        //        {
        //            _ActionInfoDal = AbstractFactory.CreateActionInfoDal();
        //        }
        //        return _ActionInfoDal;
        //    }
        //    set { _ActionInfoDal = value; }
        //}

        //private IBooksDal _BooksDal;
        //public IBooksDal BooksDal
        //{
        //    get
        //    {
        //        if (_BooksDal == null)
        //        {
        //            _BooksDal = AbstractFactory.CreateBooksDal();
        //        }
        //        return _BooksDal;
        //    }
        //    set { _BooksDal = value; }
        //}

        //private IDepartmentDal _DepartmentDal;
        //public IDepartmentDal DepartmentDal
        //{
        //    get
        //    {
        //        if (_DepartmentDal == null)
        //        {
        //            _DepartmentDal = AbstractFactory.CreateDepartmentDal();
        //        }
        //        return _DepartmentDal;
        //    }
        //    set { _DepartmentDal = value; }
        //}

        //private IKeyWordsRankDal _KeyWordsRankDal;
        //public IKeyWordsRankDal KeyWordsRankDal
        //{
        //    get
        //    {
        //        if (_KeyWordsRankDal == null)
        //        {
        //            _KeyWordsRankDal = AbstractFactory.CreateKeyWordsRankDal();
        //        }
        //        return _KeyWordsRankDal;
        //    }
        //    set { _KeyWordsRankDal = value; }
        //}

        //private IR_UserInfo_ActionInfoDal _R_UserInfo_ActionInfoDal;
        //public IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal
        //{
        //    get
        //    {
        //        if (_R_UserInfo_ActionInfoDal == null)
        //        {
        //            _R_UserInfo_ActionInfoDal = AbstractFactory.CreateR_UserInfo_ActionInfoDal();
        //        }
        //        return _R_UserInfo_ActionInfoDal;
        //    }
        //    set { _R_UserInfo_ActionInfoDal = value; }
        //}

        //private IRoleInfoDal _RoleInfoDal;
        //public IRoleInfoDal RoleInfoDal
        //{
        //    get
        //    {
        //        if (_RoleInfoDal == null)
        //        {
        //            _RoleInfoDal = AbstractFactory.CreateRoleInfoDal();
        //        }
        //        return _RoleInfoDal;
        //    }
        //    set { _RoleInfoDal = value; }
        //}

        //private ISearchDetailsDal _SearchDetailsDal;
        //public ISearchDetailsDal SearchDetailsDal
        //{
        //    get
        //    {
        //        if (_SearchDetailsDal == null)
        //        {
        //            _SearchDetailsDal = AbstractFactory.CreateSearchDetailsDal();
        //        }
        //        return _SearchDetailsDal;
        //    }
        //    set { _SearchDetailsDal = value; }
        //}


        private IUserInfoDal _UserInfoDal;
        /// <summary>
        /// 登录用户处理
        /// </summary>
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if (_UserInfoDal == null)
                {
                    _UserInfoDal = AbstractFactory.CreateUserInfoDal();
                }
                return _UserInfoDal;
            }
            set { _UserInfoDal = value; }
        }
        #endregion
    }
}
