using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Data.DbContexts
{
	public class EmployeeDataSeedingIntialization
    {
        private static EmployeesDBContext _employeeDbContext;

        public static void Seed(EmployeesDBContext employeesDbContext)
        {
            employeesDbContext = _employeeDbContext;
            employeesDbContext.Database.EnsureCreated();


            employeesDbContext.SaveChanges();
        }
    }
}
