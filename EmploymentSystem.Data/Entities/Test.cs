using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Data.Entities
{
    public class Test : BaseEntity
    {
        public bool Available { get; set; }
        public virtual Job Job { get; set; }
    }
}
