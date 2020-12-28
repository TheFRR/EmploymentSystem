using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Data.Entities
{
    public class UserLine : BaseEntity
    {
        public virtual JobSeeker JobSeeker { get; set; }
        public virtual Test Test { get; set; }
        public int CorrectAnswers { get; set; }
        public int AllAnswers { get; set; }
        public DateTime PassingDate { get; set; }
        public bool Hired { get; set; }
    }
}
