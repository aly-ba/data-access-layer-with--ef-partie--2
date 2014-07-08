using System;
using System.Collections.Generic;

namespace SalesModel.DomainClasses
{
  public class Customer
  {
    private ICollection<Address> _addresses;
    private ICollection<Order> _orders;

    public Customer()
    {
      _orders = new List<Order>();
      _addresses = new List<Address>();
    }

    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public  ContactDetail ContactDetail { get; set; }
    public DateTime ModifiedDate { get; set; }

    public string FullName
    {
      get { return FirstName.Trim() + " " + LastName; }
    }

    public ICollection<Order> Orders
    {
      get { return _orders; }
      set { _orders = value; }
    }
    public ICollection<Address> Addresses
    {
      get { return _addresses; }
      set { _addresses = value; }
    }

  }
}