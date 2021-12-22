using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Data.BaseModeling
{
    public class DefaultEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
