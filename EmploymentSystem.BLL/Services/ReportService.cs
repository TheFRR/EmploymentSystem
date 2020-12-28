using EmploymentSystem.BLL.Interfaces;
using EmploymentSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.BLL.Services
{
    public class ReportService : IReportService
    {
        private readonly IBaseManager baseManager;
        public class ReportData
        {
            public Job Job { get; set; }
            public int minimalPercent { get; set; }
            public int highPercent { get; set; }
            public int fullPercent { get; set; }
        }
        public ReportService(IBaseManager baseManager)
        {
            this.baseManager = baseManager;
        }
        public List<ReportData> ProgressReport()
        {
            List<ReportData> request = new List<ReportData>();
            var userLines = baseManager.GetAllUserLines();
            if (userLines == null) return null;
            var jobs = baseManager.GetAllJobs();
            foreach (Job job in jobs)
            {
                ReportData reportData = new ReportData();
                reportData.Job = job;
                foreach (UserLine userLine in userLines)
                    if (userLine.Test.Job.Id == job.Id)
                    {
                        if ((double)(userLine.CorrectAnswers) / (double)userLine.AllAnswers >= 0.5) reportData.minimalPercent++;
                        if ((double)(userLine.CorrectAnswers) / (double)userLine.AllAnswers >= 0.75) reportData.highPercent++;
                        if ((double)(userLine.CorrectAnswers) / (double)userLine.AllAnswers == 1) reportData.fullPercent++;
                    }
                request.Add(reportData);
            }
            return request;
        }

    }
}
