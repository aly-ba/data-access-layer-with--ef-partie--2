using System;
using System.Data.Entity;
using System.Linq;
using SalesModel.DataLayer;
using SalesModel.DataLayer.Migrations;
namespace ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {

     Database.SetInitializer(
        new MigrateDatabaseToLatestVersion<SalesModelContext,Configuration>());
       GetCustomers();
    }

    private static void GetCustomers()
    {
      using (var context = new SalesModelContext())
      {
        var customers = context.Customers.ToList();
        foreach (var customer in customers)
        {
          Console.WriteLine(customer.FirstName);
        }
      }
    }
  }
}
