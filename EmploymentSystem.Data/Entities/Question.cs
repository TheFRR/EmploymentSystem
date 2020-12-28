using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Data.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public virtual Test Test { get; set; }
    }
}
