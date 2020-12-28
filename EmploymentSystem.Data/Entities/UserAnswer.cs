using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Data.Entities
{
    public class UserAnswer : BaseEntity
    {
        public virtual User JobSeeker { get; set; }
        public virtual Test Test { get; set; }
        public virtual Question Question { get; set; }
        public virtual Variant Variant { get; set; }
    }
}
