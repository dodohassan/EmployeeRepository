using Employee.Data.DbModels.AdministrationSchema;
using Employee.Services.IResponseServices;
using Employee.ViewModels.EMPS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Services.EmpDataService.Employee
{
	public interface IEmployeeServices
	{
		ResponseListVM<EmployeeVM> GetAll();
		ResponseObjVM<EmployeeVM> SaveEmp(EmployeeVM employeeVM);
		ResponseObjVM<Employees> Delete(long EmployeeId);
		ResponseObjVM<EmployeeVM> GetById(long EmployeeId);

	}
}
