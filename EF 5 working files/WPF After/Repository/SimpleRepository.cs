using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using SalesModel.DataLayer;
using SalesModel.DomainClasses;
using System.Data.Entity;


namespace Repository
{
  public class SimpleRepository
  {
    readonly SalesModelContext _context = new SalesModelContext();

    public SimpleRepository()
    {
      App_Start.EntityFrameworkProfilerBootstrapper.PreStart();
    }

    public Customer NewCustomerWithContactDetail()
    {
      var customer = new Customer
      {
        ContactDetail = new ContactDetail()
      };
      _context.Customers.Add(customer);
      return customer;
    }

    public Customer GetCustomerGraph(int id)
    {
      return _context.Customers.Include(c => c.ContactDetail)
        .Include(c => c.Orders)
        .FirstOrDefault(c => c.CustomerId == id);
    }

    public Customer GetCustomerById(int id)
    {
      return _context.Customers.Find(id);
    }

    public List<Customer> GetCustomers()
    {
      return _context.Customers.ToList();
    }

    public ObservableCollection<Customer> CustomersInMemory()
    {
      if (_context.Customers.Local.Count == 0)
      {
        GetCustomers();
      }
      return _context.Customers.Local;
    } 

    public void Save()
    {
      //you can't remove from or add to a collection in a foreach loop
      for (int i = _context.Customers.Local.Count; i > 0; i--)
      {
        var cust = _context.Customers.Local[i - 1];
        if (_context.Entry(cust).State == EntityState.Added 
          && !cust.IsDirty && !cust.ContactDetail.IsDirty)
        {
          //note that ContactDetail also gets removed from memory
          //by Code First default Cascade Delete
          _context.Customers.Remove(cust);
        }
        
      }
      _context.SaveChanges();
    }

    public void DeleteCurrentCustomer(Customer customer)
    {
      _context.Customers.Remove(customer);
      Save();
    }
  }
}
