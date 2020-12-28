using JobSeeker.Infrastructure.Commands;
using JobSeeker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.ViewModels
{
    class VMLackOfTests : VMBase
    {
        private BackToTestsCommand backToTestsCommand;
        public BackToTestsCommand BackToTestsCommand => backToTestsCommand ??
                  (backToTestsCommand = new BackToTestsCommand(IoC.IoC.Get<IMainNavigation>()));
    }
}
