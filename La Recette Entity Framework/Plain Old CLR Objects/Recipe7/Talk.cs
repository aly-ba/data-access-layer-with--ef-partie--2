//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POCORecipe77
{
    using System;
    using System.Collections.Generic;
    
    public partial class Talk
    {
        public int TalkId { get; set; }
        public string Title { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime RevisedDate { get; set; }
        public ICollection<Speaker> Speakers { get; set; }
    }
}
