using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Data.Entities
{
    public class Variant : BaseEntity
    {
        public string Text { get; set; }
        public bool Correctness { get; set; }
        public virtual Question Question { get; set; }
    }
}
