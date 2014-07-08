using System.Linq;

namespace SalesModel.DataLayer.Migrations
{
  using DomainClasses;
  using System;
  using System.Collections.Generic;
  using System.Data.Entity.Migrations;

  public sealed class Configuration : DbMigrationsConfiguration<SalesModel.DataLayer.SalesModelContext>
  {
    public Configuration()
    {
      
      AutomaticMigrationsEnabled = true;
      AutomaticMigrationDataLossAllowed = true;
    }

    protected override void Seed(SalesModelContext context)
    {
      if (!context.Customers.Any())
      {
        var customers = new List<Customer>
                          {
                            new Customer
                              {
                                FirstName = "Sampson",
                                LastName = "TheNewfie",
                                DateOfBirth = new DateTime(2008, 1, 28)
                              },
                            new Customer
                              {
                                FirstName = "Yogi",
                                LastName = "TheBear",
                                DateOfBirth = new DateTime(1958, 1, 1)
                              }
                          };
        context.Customers.AddOrUpdate(
          c => new {c.FirstName, c.LastName}, customers.ToArray());

        var dogstuff = new Category() {Name = "Dog stuff"};
        var bearstuff = new Category() {Name = "Bear stuff"};
        var products = new List<Product>()
                         {
                           new Product()
                             {
                               Name = "Bone",
                               Description = "Juicy Dog Bone",
                               Categories = {dogstuff},
                               ProductionStart = DateTime.Now
                             },
                           new Product()
                             {
                               Name = "Katie's Bumper Toy",
                               Description = "Super fun dog toy",
                               Categories = {dogstuff},
                               ProductionStart = DateTime.Now
                             },
                           new Product()
                             {
                               Name = "Picnic Basket",
                               Description = "To carry your food",
                               Categories = {bearstuff},
                               ProductionStart = DateTime.Now
                             },
                           new Product()
                             {
                               Name = "Honey",
                               Description = "For bears who like honey",
                               Categories = {bearstuff},
                               ProductionStart = DateTime.Now
                             }
                         };
        context.Products.AddOrUpdate(p => p.Name, products.ToArray());
      }
    }
  }
}

