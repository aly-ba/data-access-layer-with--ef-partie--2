//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apress.EF6Recipes.BeyondModelingBasics.Recipe12
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class Car
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public Nullable<int> Year { get; set; }
        public string Color { get; set; }
    
        public virtual Dealer Dealer { get; set; }
    }
}
