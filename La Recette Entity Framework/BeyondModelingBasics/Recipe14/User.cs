//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apress.EF6Recipes.BeyondModelingBasics.Recipe14
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.PasswordHistories = new HashSet<PasswordHistory>();
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
    
        public virtual ICollection<PasswordHistory> PasswordHistories { get; set; }
    }
}
