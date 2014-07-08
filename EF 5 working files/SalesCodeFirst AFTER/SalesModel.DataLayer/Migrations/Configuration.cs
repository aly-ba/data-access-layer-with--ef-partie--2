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
      var customers = new List<Customer>{
            new Customer{FirstName="Sampson",LastName="TheNewfie",DateOfBirth=new DateTime(2008,1,28)},
            new Customer{FirstName="Yogi", LastName="TheBear",DateOfBirth=new DateTime(1958,1,1)}
            };
      context.Customers.AddOrUpdate(
        c => new { c.FirstName, c.LastName }, customers.ToArray());
    }
  }
}

