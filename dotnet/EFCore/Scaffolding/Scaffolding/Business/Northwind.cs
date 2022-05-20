using Scaffolding.Data;
using Scaffolding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaffolding.Business
{
    public class Northwind
    {
        public void test()
        {
            using var db = new NorthwindContext();

            var Employee1 = db.Employees.Find(1);
            Console.WriteLine($"{Employee1.FirstName} {Employee1.LastName}");

            var cust = db.Customers.Find("ALFKI");
            Console.WriteLine($"{cust.CompanyName}");

            var Employees = db.Employees.ToList();
            foreach (var Employee in Employees)
            {
                Console.WriteLine($"{Employee.FirstName} {Employee.LastName}");
            }

            var custs = db.Customers
                .OrderBy(c => c.CustomerId)
                .Skip(10)
                .Take(10)
                .ToList();
            foreach (var cust1 in custs)
            {
                Console.WriteLine($"{cust1.CustomerId} {cust1.CompanyName}");
            }

        }
    }
}
