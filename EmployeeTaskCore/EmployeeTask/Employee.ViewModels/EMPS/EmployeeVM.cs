using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Employee.ViewModels.EMPS
{
    public class EmployeeVM
    {
        public long ID { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Email")]

        public string Email { get; set; }
        [DisplayName("Phone Number")]

        public string PhoneNumber { get; set; }
        [DisplayName("Address")]

        public string Address { get; set; }
        public bool IsDeleted { get; set; }

    }

}
