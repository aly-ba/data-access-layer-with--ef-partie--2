//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apress.EF6Recipes.BeyondModelingBasics.Recipe1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Organizer
    {
        public Organizer()
        {
            this.Events = new HashSet<Event>();
        }
    
        public int OrganizerId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Event> Events { get; set; }
    }
}
