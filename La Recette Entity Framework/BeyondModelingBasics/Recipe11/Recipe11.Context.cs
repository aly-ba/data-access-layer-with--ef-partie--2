﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apress.EF6Recipes.BeyondModelingBasics.Recipe11
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class Recipe11Context : DbContext
    {
        public Recipe11Context()
            : base("name=Recipe11Context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Member> Members { get; set; }
    
        public virtual int DeleteMember(Nullable<int> memberId)
        {
            var memberIdParameter = memberId.HasValue ?
                new ObjectParameter("MemberId", memberId) :
                new ObjectParameter("MemberId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteMember", memberIdParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> InsertMember(string name, string phone, Nullable<int> age)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("InsertMember", nameParameter, phoneParameter, ageParameter);
        }
    
        public virtual int UpdateMember(string name, string phone, Nullable<int> age, Nullable<int> memberId)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var memberIdParameter = memberId.HasValue ?
                new ObjectParameter("MemberId", memberId) :
                new ObjectParameter("MemberId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateMember", nameParameter, phoneParameter, ageParameter, memberIdParameter);
        }
    }
}
