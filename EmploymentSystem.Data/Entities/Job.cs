using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Data.Entities
{
    public class Job : BaseEntity
    {
        public string Name { get; set; }
        public bool Available { get; set; }
    }
}
