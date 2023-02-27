using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace Prilutskiy.ClassFolder
{
    class ExportClass
    {
        public static void ToExcelFile(DataGrid listDataGrid, string nameList)
        {
            Excel.Application excelApplication = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet sheet = null;
            var process = Process.GetProcessesByName("EXCEL");

            SaveFileDialog openDig = new SaveFileDialog();
            openDig.FileName = nameList;
            openDig.Filter = "Excel (.xls)|*.xls |Excel (.xlsx)|*.xlsx |All files (*.*)|*.*";
            openDig.FilterIndex = 2;
            openDig.RestoreDirectory = true;
            string path = openDig.FileName;

            if (openDig.ShowDialog() == true)
            {
                excelApplication = new Excel.Application();
                excelApplication.Visible = true;
                workbook = excelApplication.Workbooks.Add(System.Reflection.Missing.Value);
                sheet = (Excel.Worksheet)workbook.Sheets[1];

                for (int j = 0; j < listDataGrid.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet.Cells[1, j + 1];
                    sheet.Cells[1, j + 1].Font.Bold = true;
                    sheet.Cells[1, j + 1].Style.HorizontalAligment = Excel.XlHAlign.xlHAlignCenter;
                    myRange.Value2 = listDataGrid.Columns[j].Header;
                }
                for (int i = 0; i < listDataGrid.Columns.Count; i++)
                {
                    for (int j = 0; j < listDataGrid.Items.Count; j++)
                    {
                        TextBlock b = listDataGrid.Columns[i].GetCellContent(listDataGrid.Items[j]) as TextBlock;
                        Excel.Range myRange = (Excel.Range)sheet.Cells[j + 2, i + 1];
                        myRange.Value2 = b.Text;
                    }
                }

                sheet.Columns.AutoFit();
            }
        }
    }
}
