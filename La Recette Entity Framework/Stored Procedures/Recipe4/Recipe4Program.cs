using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apress.EF6Recipes.StoredProcedures.Recipe4
{
    public static class Recipe4Program
    {
        public static void Run()
        {
            using (var context = new Recipe4Context())
            {
                var emp1 = new Employee
                {
                    Name = "Lisa Jefferies",
                    Address = new EmployeeAddress
                    {
                        Address = "100 E. Main",
                        City = "Fort Worth",
                        State = "TX",
                        ZIP = "76106"
                    }
                };
                var emp2 = new Employee
                {
                    Name = "Robert Jones",
                    Address = new EmployeeAddress
                    {
                        Address = "3920 South Beach",
                        City = "Fort Worth",
                        State = "TX",
                        ZIP = "76102"
                    }
                };
                var emp3 = new Employee
                {
                    Name = "Steven Chue",
                    Address = new EmployeeAddress
                    {
                        Address = "129 Barker",
                        City = "Euless",
                        State = "TX",
                        ZIP = "76092"
                    }
                };
                var emp4 = new Employee
                {
                    Name = "Karen Stevens",
                    Address = new EmployeeAddress
                    {
                        Address = "108 W. Parker",
                        City = "Fort Worth",
                        State = "TX",
                        ZIP = "76102"
                    }
                };
                context.Employees.Add(emp1);
                context.Employees.Add(emp2);
                context.Employees.Add(emp3);
                context.Employees.Add(emp4);
                context.SaveChanges();
            }

            using (var context = new Recipe4Context())
            {
                Console.WriteLine("Employee addresses in Fort Worth, TX");
                foreach (var address in context.GetEmployeeAddresses("Fort Worth"))
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", address.Address,
                                       address.City, address.State, address.ZIP);
                }
            }
            
        }
    }
}
