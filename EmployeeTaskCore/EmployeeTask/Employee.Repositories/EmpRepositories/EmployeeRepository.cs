using Employee.Data.DbContexts;
using Employee.Data.DbModels.AdministrationSchema;
using Employee.Repositories.EmpRepositories.Generic;
using Employee.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Repositories.EmpRepositories
{
	public class EmployeeRepository : EmployeesGenericRepository<Employees>, IEmployeeRepository
    {
        private readonly EmployeesDBContext _empDbContext;
        public EmployeeRepository(EmployeesDBContext empDbContext) : base(empDbContext)
        {
            _empDbContext = empDbContext;
        }
    }
}