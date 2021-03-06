﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apress.EF6Recipes.Concurrency.Recipe5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class Recipe5Context : DbContext
    {
        public Recipe5Context()
            : base("name=Recipe5Context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Account> Accounts { get; set; }
    
        public virtual int DeleteAccount(string accountNumber, byte[] timeStamp, ObjectParameter rowsAffected)
        {
            var accountNumberParameter = accountNumber != null ?
                new ObjectParameter("AccountNumber", accountNumber) :
                new ObjectParameter("AccountNumber", typeof(string));
    
            var timeStampParameter = timeStamp != null ?
                new ObjectParameter("TimeStamp", timeStamp) :
                new ObjectParameter("TimeStamp", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteAccount", accountNumberParameter, timeStampParameter, rowsAffected);
        }
    
        public virtual int InsertAccount(string accountNumber, string name, Nullable<decimal> balance, ObjectParameter rowsAffected)
        {
            var accountNumberParameter = accountNumber != null ?
                new ObjectParameter("AccountNumber", accountNumber) :
                new ObjectParameter("AccountNumber", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var balanceParameter = balance.HasValue ?
                new ObjectParameter("Balance", balance) :
                new ObjectParameter("Balance", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertAccount", accountNumberParameter, nameParameter, balanceParameter, rowsAffected);
        }
    
        public virtual int UpdateAccount(string accountNumber, string name, Nullable<decimal> balance, byte[] timeStamp, ObjectParameter rowsAffected)
        {
            var accountNumberParameter = accountNumber != null ?
                new ObjectParameter("AccountNumber", accountNumber) :
                new ObjectParameter("AccountNumber", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var balanceParameter = balance.HasValue ?
                new ObjectParameter("Balance", balance) :
                new ObjectParameter("Balance", typeof(decimal));
    
            var timeStampParameter = timeStamp != null ?
                new ObjectParameter("TimeStamp", timeStamp) :
                new ObjectParameter("TimeStamp", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateAccount", accountNumberParameter, nameParameter, balanceParameter, timeStampParameter, rowsAffected);
        }
    }
}
