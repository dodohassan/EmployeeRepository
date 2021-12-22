using Employee.Data.DbModels.AdministrationSchema;
using Employee.Data.DbModels.AuditSchema;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Data.DbContexts
{
	public class EmployeesDBContext : DbContext
    {
        public EmployeesDBContext() { }
        public EmployeesDBContext(DbContextOptions<EmployeesDBContext> options) : base(options)
        {

        }
       
        #region AdminstrationSchema
        public DbSet<Employees> Employees { get; set; }
        #endregion
        #region AuditSchema
        public DbSet<EmployeeAudit> EmployeeAudits { get; set; }
    
        #endregion
    }
}
