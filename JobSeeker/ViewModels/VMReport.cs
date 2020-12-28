using EmploymentSystem.BLL.Interfaces;
using JobSeeker.Infrastructure.Commands;
using JobSeeker.Interfaces;
using JobSeeker.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmploymentSystem.BLL.Services.ReportService;

namespace JobSeeker.ViewModels
{
    class VMReport : VMBase
    {
        private readonly IMainNavigation navigation;
        private readonly IReportService reportService;
        private List<ReportData> reportData;
        public List<ReportData> ReportData
        {
            set
            {
                OnPropertyChanged("ReportData");
            }
            get
            {
                reportData = reportService.ProgressReport(FirstDate, SecondDate);
                return reportData;
            }
        }
        private DateTime firstDate;
        public DateTime FirstDate 
        {
            set
            {
                firstDate = value;
                OnPropertyChanged("FirstDate");
                OnPropertyChanged("ReportData");
            }
            get
            {
                return firstDate;
            } 
        }
        private DateTime secondDate;
        public DateTime SecondDate
        {
            set
            {
                secondDate = value;
                OnPropertyChanged("SecondDate");
                OnPropertyChanged("ReportData");
                if (FirstDate > SecondDate)
                {
                    FirstDate = SecondDate;
                    OnPropertyChanged("FirstDate");
                }
            }
            get
            {
                return secondDate;
            }
        }

        private RelayCommand backToAdminSelection;
        public RelayCommand BackToAdminSelection
        {
            get
            {
                return backToAdminSelection ?? (backToAdminSelection = new RelayCommand(obj =>
                {
                    navigation.Navigate(new AdminSelection());
                }));
            }
        }

        private ExportReportCommand exportReportCommand;
        public ExportReportCommand ExportReportCommand => exportReportCommand ??
            (exportReportCommand = new ExportReportCommand());

        public VMReport()
        {
            navigation = IoC.IoC.Get<IMainNavigation>();
            reportService = IoC.IoC.Get<IReportService>();
            FirstDate = DateTime.Today;
            SecondDate = DateTime.Today;
        }
    }
}
