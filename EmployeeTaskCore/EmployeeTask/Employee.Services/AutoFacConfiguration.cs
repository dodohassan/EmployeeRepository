using Autofac;
using Employee.Repositories.EmpRepositories;
using Employee.Repositories.EmpRepositories.Audit;
using Employee.Repositories.UOW;
using Employee.Services.EmpDataService.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Services
{
    public class AutoFacConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region UOW
            //Register Unit of work service
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>));
            #endregion  

            #region Employee
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<EmployeeServices>().As<IEmployeeServices>();

            #endregion

            #region EmployeeAudit
            builder.RegisterType<EmployeeAuditRepository>().As<IEmployeeAuditRepository>();

            #endregion

                
        }
    }
}
