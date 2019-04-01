using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mzys_blcflr
{
    public partial class FrmSelectGlfy : Form
    {
        public DataTable fytb = new DataTable();
        public bool bok = false;
        public FrmSelectGlfy(DataTable _fytb)
        {
            InitializeComponent();
            fytb = _fytb;
            //string[] GroupbyField1 ={ "hsitem_id", "selected", "day", "item", "num" };
            //string[] ComputeField1 ={ "ZJE", "num" };
            //string[] CField1 ={ "sum", "sum" };
            TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
            xcset1.TsDataTable = fytb;
            //dataGridView1.DataSource = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
            dataGridView1.DataSource = fytb;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnter_Click(sender, e);
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            //selected
            DataTable tb = (DataTable)dataGridView1.DataSource;
            DataRow[] rows = tb.Select( "selected='true'" );

            fytb = tb.Clone();
            for ( int i = 0 ; i < rows.Length ; i++ )
                fytb.Rows.Add( rows[i].ItemArray );

            //fytb = (DataTable)dataGridView1.DataSource;
            bok = true;
            this.Close();
        }



        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "天数")
            {
                if (string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())) return;
                int num = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) * Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Remark"].Value);
                dataGridView1.Rows[e.RowIndex].Cells["总量"].Value = num;
                decimal zje = Convert.ToDecimal( num ) * Convert.ToDecimal( dataGridView1.Rows[e.RowIndex].Cells["单价"].Value );
                dataGridView1.Rows[e.RowIndex].Cells["总金额"].Value = zje;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "总量")
            {
                if (string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())) return;
                dataGridView1.Rows[e.RowIndex].Cells["总量"].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                dataGridView1.Rows[e.RowIndex].Cells["总金额"].Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["单价"].Value);
            }
        }



        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}