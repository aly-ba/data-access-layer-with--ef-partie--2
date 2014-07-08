using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using SalesModel.DomainClasses;
using SalesModel.DomainClasses.Enums;

namespace ConsoleApp
{
  internal class Program
  {
    private static SimpleRepository _repo;
    private static void Main()
    {
      App_Start.EntityFrameworkProfilerBootstrapper.PreStart();
      _repo = new SimpleRepository();
      InsertCustomer();
    }

    private static void InsertCustomer()
    {
      var customer = new Customer
      {
        FirstName = "Julie",
        LastName = "Lerman",
        DateOfBirth = DateTime.Now,
      };
      _repo.InsertCustomerAndSave(ref customer);
      DisplayCustomer(customer.CustomerId);

    }

    private static void DisplayCustomer(int id)
    {
      //using (var context = new SalesModelContext())
      //{
      //  var customer = context.Customers.Find(id);

      //  Console.WriteLine(customer.FirstName);
      //  Console.WriteLine(customer.DateOfBirth);
      //}
      var customer = _repo.GetCustomerById(id);
      Console.WriteLine(customer.FirstName);
      Console.WriteLine(customer.DateOfBirth);
      Console.WriteLine("-------------");
      Console.ReadKey();
    }


    private static void DisplayCustomersWithOrderCount()
    {
      foreach (var customer in _repo.GetCustomersAndOrders())
      {
        Console.WriteLine("{0} Order Count: {1}",
          customer.FullName,
          customer.Orders.Count());
      }
      Console.ReadKey();
    }

  
    private static void GetCustomers()
    {
      //using (var context = new SalesModelContext())
      //{
      //  foreach (var customer in context.Customers)

      foreach (var customer in _repo.GetCustomers())
      {
        Console.WriteLine(customer.FirstName);
      }
      Console.WriteLine("-------------");
      Console.ReadKey();
      
      //  }

    }
  }
}




