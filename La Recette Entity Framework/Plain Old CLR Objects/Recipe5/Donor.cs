//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POCORecipe55
{
    using System;
    using System.Collections.Generic;
    
    public partial class Donor
    {
        public Donor()
        {
            this.Donations = new HashSet<Donation>();
        }
    
        public int DonorId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Donation> Donations { get; set; }
    }
}
