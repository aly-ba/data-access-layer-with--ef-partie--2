//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Recipe3_14
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssociateSalary
    {
        public int SalaryID { get; set; }
        public int AssociateID { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public Nullable<System.DateTime> SalaryDate { get; set; }
    
        public virtual Associate Associate { get; set; }
    }
}
