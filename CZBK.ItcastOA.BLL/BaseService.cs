using CZBK.ItcastOA.DALFactory;
using CZBK.ItcastOA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.BLL
{
   public abstract class BaseService<T> where T:class,new()
    {
       public IDBSession CurrentDBSession
       {
           get
           {
               return DBSessionFactory.CreateDBSession();
           }
       }
       /// <summary>
       /// 当前具体业务处理类的数据层
       /// </summary>
       public IDAL.IBaseDal<T> CurrentDal { get; set; }
       public abstract void SetCurrentDal();//子类一定要实现抽象方法。
       public BaseService()
       {
           SetCurrentDal();
       }
       /// <summary>
       /// 查询
       /// </summary>
       /// <param name="whereLambda"></param>
       /// <returns></returns>
       public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
       {
           return CurrentDal.LoadEntities(whereLambda);
       }
       /// <summary>
       /// 分页
       /// </summary>
       /// <typeparam name="s"></typeparam>
       /// <param name="pageIndex"></param>
       /// <param name="pageSize"></param>
       /// <param name="totalCount"></param>
       /// <param name="whereLambda"></param>
       /// <param name="orderbyLambda"></param>
       /// <param name="isAsc"></param>
       /// <returns></returns>
       public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc)
       {
           return CurrentDal.LoadPageEntities<s>(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, isAsc);
       }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
       public bool DeleteEntity(T entity)
       {
           CurrentDal.DeleteEntity(entity);
           return CurrentDBSession.SaveChanges();
       }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
       public bool EditEntity(T entity)
       {
           CurrentDal.EditEntity(entity);
           return CurrentDBSession.SaveChanges();
       }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
       public T AddEntity(T entity)
       {
           CurrentDal.AddEntity(entity);
           CurrentDBSession.SaveChanges();
           return entity;
       }
    }
}
