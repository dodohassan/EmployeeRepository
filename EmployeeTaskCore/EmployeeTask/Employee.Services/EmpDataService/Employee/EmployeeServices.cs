using AutoMapper;
using Employee.Core.Enums;
using Employee.Core.Resources.EmployeeServiceResources;
using Employee.Data.DbContexts;
using Employee.Data.DbModels.AdministrationSchema;
using Employee.Data.DbModels.AuditSchema;
using Employee.Repositories.EmpRepositories;
using Employee.Repositories.EmpRepositories.Audit;
using Employee.Repositories.UOW;
using Employee.Services.IResponseServices;
using Employee.ViewModels.EMPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Services.EmpDataService.Employee
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<EmployeesDBContext> _employeesUnitOfWork;
        private readonly IEmployeeAuditRepository _employeeAuditRepository;
        public EmployeeServices(
            IEmployeeRepository employeeRepository,
            IMapper mapper,
            IUnitOfWork<EmployeesDBContext> employeesUnitOfWork,
            IEmployeeAuditRepository employeeAuditRepository

            )
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _employeesUnitOfWork = employeesUnitOfWork;
            _employeeAuditRepository = employeeAuditRepository;

        }

    
      
       ResponseObjVM<EmployeeVM> Update(EmployeeVM employeeVM, string loggedinEmail)
        {
            try
            {
                if (employeeVM == null)
                    return EmpMessages.FailUpdate;

                var Employee = _employeeRepository.GetFirst(e => e.ID == employeeVM.ID);
                if(Employee==null)
                    return EmpMessages.FailUpdate;

                Employee=_mapper.Map<Employees>(employeeVM);

                 _employeeRepository.Update(Employee);

                int empSave = _employeesUnitOfWork.Save();

                if (empSave != 0)
                {
                    var EmployeeAudt = _mapper.Map<EmployeeAudit>(Employee);
                    EmployeeAudt.DateOfAction = DateTime.Now;
                    EmployeeAudt.ActionedBy = loggedinEmail;
                    EmployeeAudt.Action = (int)ActionOfAuditEnum.Update;
                    EmployeeAudt.EmployeeId = Employee.ID;
                    _employeeAuditRepository.Add(EmployeeAudt);
                    _employeesUnitOfWork.Save();
                    employeeVM = _mapper.Map<EmployeeVM>(Employee);

                    return new ResponseObjVM<EmployeeVM>(employeeVM, EmpMessages.CreateEmployeeSuccess);

                }
                else
                    return EmpMessages.FailUpdate;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
		ResponseListVM<EmployeeVM> IEmployeeServices.GetAll()
		{
            try
            
            
            {
                ResponseListVM<EmployeeVM> empList = new ResponseListVM<EmployeeVM>();
                
                var EmpList = _employeeRepository.GetAll(e => e.IsDeleted == false).Select(e => _mapper.Map<EmployeeVM>(e)).ToList();

                return new ResponseListVM<EmployeeVM>(EmpList, EmpMessages.ListRetunedDataSuccessfully);

            }


            catch (Exception ex)
            {
                throw ex;
            }
        }

		
		
		ResponseObjVM<Employees> IEmployeeServices.Delete(long employeeId)
		{
            try
            {
                var emp = _employeeRepository.GetAll(e => e.IsDeleted == false).FirstOrDefault(e => e.ID == employeeId);
                if (emp == null)
                    return EmpMessages.EmNotExist;
                //soft delete
                emp.IsDeleted = true;
                _employeeRepository.Remove(emp);
                var save = _employeesUnitOfWork.Save();
                if (save == 0)
                    return EmpMessages.FailedToDelete;

                var EmployeeAudt = _mapper.Map<EmployeeAudit>(emp);
                EmployeeAudt.ID = 0;
                EmployeeAudt.DateOfAction = DateTime.Now;
                EmployeeAudt.Action = (int)ActionOfAuditEnum.Delete;
                EmployeeAudt.EmployeeId = emp.ID;
                _employeeAuditRepository.Add(EmployeeAudt);
                _employeesUnitOfWork.Save();

                return new ResponseObjVM<Employees>(emp, EmpMessages.EmpDeleted);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ResponseObjVM<EmployeeVM> IEmployeeServices.GetById(long EmployeeId)
		{
            try
            {
                var emp = _employeeRepository.GetAll().Where(e => e.IsDeleted == false).FirstOrDefault(e => e.ID == EmployeeId);
                if (emp == null)
                    return EmpMessages.EmNotExist;
                var empVM = _mapper.Map<EmployeeVM>(emp);
                return new ResponseObjVM<EmployeeVM>(empVM, EmpMessages.GetDone);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		ResponseObjVM<EmployeeVM> IEmployeeServices.SaveEmp(EmployeeVM employeeVM)
		{
            try
            {
                if (employeeVM == null)
                    return EmpMessages.FailUpdate;

                var Employee = _employeeRepository.GetFirst(e => e.ID == employeeVM.ID);
                if (Employee == null)
                {
                    var newEmployee = _mapper.Map<Employees>(employeeVM);
                    _employeeRepository.Add(newEmployee);
                    int empSave = _employeesUnitOfWork.Save();
                    return new ResponseObjVM<EmployeeVM>(employeeVM, EmpMessages.CreateEmployeeSuccess);

                }
                else
                {
                    Employee = _mapper.Map<Employees>(employeeVM);
                    _employeeRepository.Update(Employee);

                    int empSave = _employeesUnitOfWork.Save();

                    if (empSave != 0)
                    {
                        var EmployeeAudt = _mapper.Map<EmployeeAudit>(Employee);
                        EmployeeAudt.ID = 0;
                        EmployeeAudt.DateOfAction = DateTime.Now;
                        EmployeeAudt.ActionedBy = "";
                        EmployeeAudt.Action = (int)ActionOfAuditEnum.Update;
                        EmployeeAudt.EmployeeId = Employee.ID;
                        _employeeAuditRepository.Add(EmployeeAudt);
                        _employeesUnitOfWork.Save();
                        employeeVM = _mapper.Map<EmployeeVM>(Employee);

                        return new ResponseObjVM<EmployeeVM>(employeeVM, EmpMessages.CreateEmployeeSuccess);

                    }
                    else
                        return EmpMessages.FailUpdate;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}