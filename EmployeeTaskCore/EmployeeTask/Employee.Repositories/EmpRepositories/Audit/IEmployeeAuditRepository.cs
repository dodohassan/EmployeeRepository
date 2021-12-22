using Employee.Data.DbModels.AuditSchema;
using Employee.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Repositories.EmpRepositories.Audit
{
	public interface IEmployeeAuditRepository:IGRepository<EmployeeAudit>
	{
	}
}
