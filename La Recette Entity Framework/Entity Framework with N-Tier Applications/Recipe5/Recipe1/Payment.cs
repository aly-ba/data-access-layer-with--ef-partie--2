//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Recipe1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public byte[] TimeStamp { get; set; }
        public int InvoiceId { get; set; }
    
        public virtual Invoice Invoice { get; set; }
    }
}
