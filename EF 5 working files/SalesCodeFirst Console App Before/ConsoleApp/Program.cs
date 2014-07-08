using System;
using System.Linq;
using SalesModel.DataLayer;
using SalesModel.DomainClasses;
using System.Data.Entity;

namespace ConsoleApp
{
  internal class Program
  {
    private static void Main()
    {
    
      //GetCustomers();
      //GetCustomer(2);
      //InsertCustomer();
    
   
    }

    private static void DisplayCustomersWithOrderCount()
    {
      using (var context = new SalesModelContext())
      {
        foreach (var customer in context.Customers.Include(c => c.Orders).ToList())
        {
          Console.WriteLine("{0} Order Count: {1}",
                            customer.FullName,
                            customer.Orders.Count());
        }
      }
      Console.ReadKey();
    }

   

    private static void InsertCustomer()
    {
      var customer = new Customer
                       {
                         FirstName = "Julie",
                         LastName = "Lerman",
                         DateOfBirth = DateTime.Now
                       };
      using (var context = new SalesModelContext())
      {
        context.Customers.Add(customer);
        context.SaveChanges();
      }
      DisplayCustomer(customer.CustomerId);

    }

    private static void DisplayCustomer(int id)
    {
      using (var context = new SalesModelContext())
      {
        var customer = context.Customers.Find(id);
        Console.WriteLine(customer.FullName);
        Console.WriteLine(customer.DateOfBirth);
      }
      Console.WriteLine("-------------");
      Console.ReadKey();
    }

    private static void GetCustomers()
    {
      using (var context = new SalesModelContext())
      {
        //   var customers = context.Customers.ToList();
        foreach (var customer in context.Customers)
        {
          Console.WriteLine(customer.FullName);
        }
        Console.WriteLine("-------------");
        Console.ReadKey();


      }
    }
  }
}




