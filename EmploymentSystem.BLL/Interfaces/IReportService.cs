using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmploymentSystem.BLL.Services.ReportService;

namespace EmploymentSystem.BLL.Interfaces
{
    public interface IReportService
    {
        List<ReportData> ProgressReport();
    }
}
