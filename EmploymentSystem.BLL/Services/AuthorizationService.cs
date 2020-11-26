using EmploymentSystem.BLL.Interfaces;
using EmploymentSystem.BLL.Properties;
using EmploymentSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.BLL.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private IBaseManager manager;

        public AuthorizationService(IBaseManager manager)
        {
            this.manager = manager;
        }

        public bool LogIn(string login, string password)
        {
            var user = manager.User.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user != null)
            {
                Settings.Default["login"] = login;
                Settings.Default["password"] = password;
                Settings.Default.Save();
            }
            return user != null;
        }

        public void LogOut()
        {
            Settings.Default["login"] = string.Empty;
            Settings.Default["password"] = string.Empty;
            Settings.Default.Save();
        }

        public User GetCurrentUser()
        {
            string login = Settings.Default["login"].ToString();
            string password = Settings.Default["password"].ToString();
            return manager.User.FirstOrDefault(u => u.Login == login && u.Password == password);
        }
    }
}
