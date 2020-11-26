using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JobSeeker.Infrastructure.Navigation
{
    public abstract class BaseNavigation
    {
        public event PropertyChangedEventHandler CurrentPageChanged;

        private Page currentPage;
        public Page CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                CurrentPageChanged?.Invoke(null, new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        public void Navigate(Page page)
        {
            CurrentPage = page;
        }
    }
}
