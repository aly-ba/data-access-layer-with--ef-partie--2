//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apress.EF6Recipes.BeyondModelingBasics.Recipe15
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle
    {
        public Vehicle()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    
        public string LicenseNumber { get; set; }
        public string Model { get; set; }
    
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}