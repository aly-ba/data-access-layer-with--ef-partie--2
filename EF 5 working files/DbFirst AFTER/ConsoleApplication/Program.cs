using System;
using AdventureWorksModel;


namespace ConsoleApplication
{
  class Program
  {
    static void Main(string[] args)
    {
     
      InsertUpdateAndDeleteEntityWithMappedSprocs();
    }

    private static void InsertUpdateAndDeleteEntityWithMappedSprocs()
    {
      var customer = new Customer
                       {
                         First = "Julie",
                         LastName = "Lerman",
                         ModifiedDate = DateTime.Now
                         };
      using (var context=new AWEntities())
      {
        context.Customers.Add(customer);
        context.SaveChanges();

        customer.Title = "Princess";
        customer.CompanyName = "The Data Farm";
        context.SaveChanges();

        context.Customers.Remove(customer);
        context.SaveChanges();
      }
      
  
    }
  }
}

