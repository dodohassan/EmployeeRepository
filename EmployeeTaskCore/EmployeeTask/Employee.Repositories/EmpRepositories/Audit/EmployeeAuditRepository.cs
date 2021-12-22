using Employee.Data.DbContexts;
using Employee.Data.DbModels.AuditSchema;
using Employee.Repositories.EmpRepositories.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Repositories.EmpRepositories.Audit
{
	public class EmployeeAuditRepository:EmployeesGenericRepository<EmployeeAudit>, IEmployeeAuditRepository
	{

        private readonly EmployeesDBContext _empDbContext;
        public EmployeeAuditRepository(EmployeesDBContext empDbContext) : base(empDbContext)
        {
            _empDbContext = empDbContext;
        }
    }
}