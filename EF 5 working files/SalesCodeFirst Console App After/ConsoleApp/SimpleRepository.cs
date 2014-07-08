using System.Collections.Generic;
using System.Linq;
using SalesModel.DataLayer;
using SalesModel.DomainClasses;
using System.Data.Entity;

namespace ConsoleApp
{
  public class SimpleRepository
  {
    readonly SalesModelContext _context=new SalesModelContext();
    

    public void InsertCustomerAndSave(ref Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    public List<Customer> GetCustomersAndOrders()
    {
      return _context.Customers.Include(c => c.Orders).ToList();
    }
      
    public Customer GetCustomerById(int id)
    {
      return _context.Customers.Find(id);
    }

    public List<Customer> GetCustomers()
    {
      return _context.Customers.ToList();
    }

    public void UpdateCustomerAndSave(ref Customer customer)
    {
      _context.Customers.Attach(customer);
      _context.SaveChanges();
    }


  }
}
