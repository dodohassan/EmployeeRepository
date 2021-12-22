using Employee.Data.ConnectionStrings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Data.DbContexts
{
	public class EmployeeDBContextFactory : IDesignTimeDbContextFactory<EmployeesDBContext>
    {
        public EmployeeDBContextFactory() { }
        private string defaultSalesDbConnection { get; set; }
        public EmployeesDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EmployeesDBContext>();
            defaultSalesDbConnection = DataConectionString.LocalEMPDbConnectionString;

            builder.UseSqlServer(defaultSalesDbConnection);

            return new EmployeesDBContext(builder.Options);
        }
    }
}
