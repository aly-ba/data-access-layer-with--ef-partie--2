﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apress.EF6Recipes.StoredProcedures.Recipe3
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class Recipe3Context : DbContext
    {
        public Recipe3Context()
            : base("name=Recipe3Context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ATMMachine> ATMMachines { get; set; }
        public DbSet<ATMWithdrawal> ATMWithdrawals { get; set; }
    
        public virtual ObjectResult<Nullable<decimal>> GetWithdrawals(Nullable<int> aTMId, Nullable<System.DateTime> withdrawalDate)
        {
            var aTMIdParameter = aTMId.HasValue ?
                new ObjectParameter("ATMId", aTMId) :
                new ObjectParameter("ATMId", typeof(int));
    
            var withdrawalDateParameter = withdrawalDate.HasValue ?
                new ObjectParameter("WithdrawalDate", withdrawalDate) :
                new ObjectParameter("WithdrawalDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("GetWithdrawals", aTMIdParameter, withdrawalDateParameter);
        }
    }
}
