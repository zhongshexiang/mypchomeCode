using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.Model
{
    /// <summary>
    /// code first模式的entity framwork
    /// </summary>
    public class DBEntitiesContext : DbContext
    {
        /// <summary>
        /// 与数据库连接的entityFramwork
        /// </summary>
        public DBEntitiesContext()
            : base("name=DBEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名,表名后面不要加s
        }

        public DbSet<UserInfo> UserInfo { get; set; }
    }
}
