using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem.Classes
{
    public class ExcelUtlity
    {
        /// <summary>
        /// FUNCTION FOR EXPORTING TO EXCEL
        /// </summary>
        /// <param name="minutesworked"></param>
        /// <param name="worksheetName"></param>
        /// <param name="saveAsLocation"></param>
        /// <returns></returns>
        public bool WriteDataTableToExcel(List<int> minutesworked, string worksheetName, string saveAsLocation, int eid, string ename, int Week, DateTime firstdate, int smins)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get the Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // make the Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Work sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;


                excelSheet.Cells[1, 1] = "Shop ID: 429";
                excelSheet.Cells[1, 2] = "Employee ID: " + eid.ToString();
                excelSheet.Cells[1, 3] = ename;
                excelSheet.Cells[2, 1] = "Week: " + Week.ToString();
                excelSheet.Cells[2, 2] = "Year: " + firstdate.Date.ToString("yyyy");


                // loop through each row and add values to our sheet
                int rowcount = 3, daycount = 0 ;

                foreach (int mins in minutesworked)
                {
                    excelSheet.Cells[rowcount, 1] = firstdate.AddDays(daycount).DayOfWeek.ToString();
                    excelSheet.Cells[rowcount, 2] = firstdate.AddDays(daycount).ToString("yyyy-MM-dd");
                    excelSheet.Cells[rowcount, 3] = (mins/60).ToString()+":"+(mins%60).ToString();
                    if (rowcount % 2 == 0)
                    {
                        excelCellrange = excelSheet.Range[excelSheet.Cells[rowcount, 1], excelSheet.Cells[rowcount, 3]];
                        FormattingExcelCells(excelCellrange, "#CCCCFF", System.Drawing.Color.Black, false);
                    }
                    daycount++;
                    rowcount++;
                }

                excelSheet.Cells[rowcount, 1] = "Sick Leave Hours:";
                excelSheet.Cells[rowcount, 2] = "All week";
                excelSheet.Cells[rowcount, 3] = (smins / 60).ToString() + ":" + (smins % 60).ToString();

                excelCellrange = excelSheet.Range[excelSheet.Cells[rowcount, 1], excelSheet.Cells[rowcount, 3]];
                FormattingExcelCells(excelCellrange, "#FF3399", System.Drawing.Color.White, false);


                // now we resize the columns
                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowcount, 3]];
                excelCellrange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;


                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[2, 3]];
                FormattingExcelCells(excelCellrange, "#000099", System.Drawing.Color.White, true);


                //now save the workbook and exit Excel


                excelworkBook.SaveAs(saveAsLocation+"-"+eid.ToString()+"-"+ firstdate.Date.ToString("yyyy")+"-"+Week.ToString()+".xlsx");
                excelworkBook.Close();
                excel.Quit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }

        }

        /// <summary>
        /// FUNCTION FOR FORMATTING THE EXCEL CELLS
        /// </summary>
        /// <param name="range"></param>
        /// <param name="HTMLcolorCode"></param>
        /// <param name="fontColor"></param>
        /// <param name="IsFontbool"></param>
        public void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }

    }
}
