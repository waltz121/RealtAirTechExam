using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class RealAirTechExamContext: DbContext
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserTask> UserTasks { get; set; }

        public void Update(object updateEntity)
        {
            this.Entry(updateEntity).State = EntityState.Modified;
        }

        public void Save()
        {
            this.SaveChanges();
        }

        public void Delete(object deletedEntity)
        {
            this.Entry(deletedEntity).State = EntityState.Deleted;
        }
    }
}
