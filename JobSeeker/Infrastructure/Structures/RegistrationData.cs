using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JobSeeker.Infrastructure.Structures
{
    class RegistrationData
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public PasswordBox PasswordBox { get; set; }
    }
}
