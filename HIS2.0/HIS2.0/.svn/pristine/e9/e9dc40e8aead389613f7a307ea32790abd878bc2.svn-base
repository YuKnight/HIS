using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ts_zyhs_czbr
{
    public class DgvExportExcel
    {
        public static void ExportExcel(DataGridView dt)
        {
            if (dt == null || dt.Rows.Count == 0) return;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                return;
            }
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range;
            long totalCount = dt.Rows.Count;
            long rowRead = 0;
            float percent = 0;
            int n = 1;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].Visible)
                {
                    worksheet.Cells[1, n++] = dt.Columns[i].HeaderText;
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
                    range.Interior.ColorIndex = 15;
                    range.Font.Bold = true;
                }
              
            }
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                n = 1;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                   
                    if (dt.Columns[i].Visible)
                    {
                        worksheet.Cells[r + 2, n++] = dt.Rows[r].Cells[i].Value;
                    }
                }
                rowRead++;
                percent = ((float)(100 * rowRead)) / totalCount;
            }
            xlApp.Visible = true;
        }

    }
}
