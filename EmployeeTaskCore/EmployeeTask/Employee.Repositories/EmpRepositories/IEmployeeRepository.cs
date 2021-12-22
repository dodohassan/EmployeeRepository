using Employee.Data.DbModels.AdministrationSchema;
using Employee.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Repositories.EmpRepositories
{
	public interface IEmployeeRepository : IGRepository<Employees>
	{
	}
}
