using Employee.Data.BaseModeling;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Data.DbModels.AdministrationSchema
{
    [Table(name: "Employee", Schema = "Administration")]
    public class Employees : DefaultEntity
    {
        [Key]
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
