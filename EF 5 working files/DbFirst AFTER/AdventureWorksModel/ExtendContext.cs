using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksModel
{
  public partial class AWEntities
  {
    public override int SaveChanges()
    {
      foreach (var entry in this.ChangeTracker.Entries()
        .Where(e => e.Entity is Customer &&
           (e.State == EntityState.Added ||
             e.State == EntityState.Modified)
            )
            )
      {
        ((Customer)entry.Entity).ModifiedDate = DateTime.Now;
      }


      return base.SaveChanges();
    }
  }
}
