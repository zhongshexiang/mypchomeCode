using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.DAL
{
   public class DBContextFactory
    {
       public static DbContext CreateDbContext()
       {
           DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
           if (dbContext == null)
           {
               dbContext = new DBEntitiesContext();
               CallContext.SetData("dbContext", dbContext);
           }
           return dbContext;
       }
    }
}
