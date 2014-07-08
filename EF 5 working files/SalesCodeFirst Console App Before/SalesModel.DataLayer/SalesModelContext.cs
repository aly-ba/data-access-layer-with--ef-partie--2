
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using SalesModel.DomainClasses;

namespace SalesModel.DataLayer
{
  public class SalesModelContext : DbContext
  {
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<LineItem> LineItems { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Product> Products    { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new ContactDetailMappings());
      modelBuilder.Ignore<Category>();
      base.OnModelCreating(modelBuilder);
    }
  }

  public class ContactDetailMappings : EntityTypeConfiguration<ContactDetail>
  {
    public ContactDetailMappings()
    {
      this.HasKey(c => c.CustomerId);
      Property(c => c.MobilePhone).HasColumnName("CellPhone");
      Property(c => c.HomePhone).HasMaxLength(20);
      HasRequired(c => c.Customer).WithOptional(cu => cu.ContactDetail).WillCascadeOnDelete(true);
    }
  }   

}
  