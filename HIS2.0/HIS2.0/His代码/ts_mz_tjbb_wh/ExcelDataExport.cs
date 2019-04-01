using System;
using System.Collections.Generic;
using System.Text;

namespace ts_mz_tjbb
{
    public delegate void ExportingHandle(int totalRow, int row );

    public class ExcelDataExport
    {
        public event ExportingHandle Exporting;

        private object datasource;
        private Excel.Application myExcel;
        private int startrow;

        public ExcelDataExport( Excel.Application MyExcel , object dataSource , int StartRow )
        {
            myExcel = MyExcel;
            datasource = dataSource;
            startrow = StartRow;
        }

        public void Export( out int lastRowIndex,out int lastColIndex)
        {
            int excelRowIndex = startrow;
            int excelColIndex = 1;
            if ( datasource is System.Data.DataTable )
            {
                System.Data.DataTable tb = (System.Data.DataTable)datasource;

                for ( int i = 0 ; i < tb.Rows.Count ; i++ )
                {
                    excelColIndex = 1;
                    for ( int j = 0 ; j < tb.Columns.Count ; j++ )
                    {
                        myExcel.Cells[excelRowIndex , excelColIndex] = tb.Rows[i][j];
                        excelColIndex++;
                    }
                    if ( Exporting != null )
                        Exporting( tb.Rows.Count , excelRowIndex );

                    excelRowIndex++;
                }
            }
            else if ( datasource is System.Windows.Forms.DataGridView || datasource is RowMergeView )
            {
                System.Windows.Forms.DataGridView dgvList = (System.Windows.Forms.DataGridView)datasource;

                for ( int i = 0 ; i < dgvList.Rows.Count ; i++ )
                {
                    excelColIndex = 1;
                    for ( int j = 0 ; j < dgvList.Columns.Count ; j++ )
                    {
                        myExcel.Cells[excelRowIndex , excelColIndex] = dgvList[j , i].Value;
                        excelColIndex++;
                    }
                    if ( Exporting != null )
                        Exporting( dgvList.Rows.Count , excelRowIndex );
                    excelRowIndex++;
                }
            }
            lastRowIndex = excelRowIndex;
            lastColIndex = excelColIndex;
        }
        
    }
}
