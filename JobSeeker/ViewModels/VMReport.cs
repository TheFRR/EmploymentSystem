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
        public List<ReportData> reportData { get; set; }

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
            reportData = reportService.ProgressReport();
        }
    }
}
