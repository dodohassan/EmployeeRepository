using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Data.BaseModeling
{
    public class DefaultAuditEntity
    {
        public DateTime DateOfAction { get; set; }
        public int Action { get; set; }
        public string ActionedBy { get; set; }
    }
}
