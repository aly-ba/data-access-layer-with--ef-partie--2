//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Recipe8
{
    using System;
    using System.Collections.Generic;
    
    public partial class ResumeDetail
    {
        public string Body { get; set; }
        public int ResumeId { get; set; }
    
        public virtual Resume Resume { get; set; }
    }
}
