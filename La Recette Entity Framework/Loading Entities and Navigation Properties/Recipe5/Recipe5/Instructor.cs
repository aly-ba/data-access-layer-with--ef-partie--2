//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Recipe5
{
    using System;
    using System.Collections.Generic;
    
    public partial class Instructor
    {
        public Instructor()
        {
            this.Sections = new HashSet<Section>();
        }
    
        public int InstructorId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Section> Sections { get; set; }
    }
}
