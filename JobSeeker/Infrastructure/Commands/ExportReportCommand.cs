using Microsoft.Win32;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static EmploymentSystem.BLL.Services.ReportService;

namespace JobSeeker.Infrastructure.Commands
{
    class ExportReportCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            List<ReportData> reportData = (List<ReportData>)parameter;
            XWPFDocument doc = new XWPFDocument();

            XWPFParagraph paragraph = doc.CreateParagraph();
            paragraph.Alignment = ParagraphAlignment.CENTER;
            XWPFRun r0 = paragraph.CreateRun();
            r0.SetText("Отчёт об успешности прохождения тестов");

            XWPFTable table = doc.CreateTable(reportData.Count + 1, 4);
         
            table.GetRow(0).GetCell(0).SetText("Должность");
            table.GetRow(0).GetCell(1).SetText("Выполнили на ⩾ 50% (чел.)");
            table.GetRow(0).GetCell(2).SetText("Выполнили на ⩾ 75% (чел.)");
            table.GetRow(0).GetCell(3).SetText("Выполнили на 100% (чел.)");

            for (int i = 1; i < 3; i++)
                table.GetRow(i).GetCell(0).SetText(reportData[i - 1].Job.Name);
            for (int i = 1; i < 3; i++)
                table.GetRow(i).GetCell(1).SetText(reportData[i - 1].minimalPercent.ToString());
            for (int i = 1; i < 3; i++)
                table.GetRow(i).GetCell(2).SetText(reportData[i - 1].highPercent.ToString());
            for (int i = 1; i < 3; i++)
                table.GetRow(i).GetCell(3).SetText(reportData[i - 1].fullPercent.ToString());

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream Out = new FileStream(saveFileDialog.FileName, FileMode.Create);
                doc.Write(Out);
                Out.Close();
            }
        }
    }
}
