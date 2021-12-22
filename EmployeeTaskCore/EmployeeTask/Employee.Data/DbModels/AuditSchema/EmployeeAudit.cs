using Employee.Data.BaseModeling;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Data.DbModels.AuditSchema
{
    [Table(name: "EmployeeAudits", Schema = "Audit")]
    public class EmployeeAudit : DefaultAuditEntity
    {
        [Key]
        public long ID { get; set; }
        public long EmployeeId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
