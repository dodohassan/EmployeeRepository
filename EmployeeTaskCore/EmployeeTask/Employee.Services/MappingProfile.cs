using AutoMapper;
using Employee.Data.DbModels.AdministrationSchema;
using Employee.Data.DbModels.AuditSchema;
using Employee.ViewModels.EMPS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Employee
            CreateMap<Employees, EmployeeVM>().ReverseMap();
            #endregion


            #region EmployeeAudt
            CreateMap<Employees, EmployeeAudit>().ReverseMap();
            #endregion

        }
    }

}
