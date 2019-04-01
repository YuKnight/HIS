using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;

namespace ts_mz_class
{
    public partial class Frmghjl : Form
    {
        public bool Bok = false;
        public DataRow ReturnRow;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private int Nrow = 0;
        public Frmghjl(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void Frmsf_Load(object sender, EventArgs e)
        {
            
        }

        private void butok_Click(object sender, EventArgs e)
        {
            Bok = true;
            this.Close();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            Bok = false ;
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            int nrow = dataGridView1.CurrentCell.RowIndex;
            ReturnRow = tb.Rows[nrow];
            Bok = true;
            this.Close();
        }



        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }





        private void Frmghjl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                if (tb.Rows.Count > 0)
                {
                    ReturnRow = tb.Rows[nrow];
                    Bok = true;
                }
                else
                {
                    ReturnRow = null;
                    Bok = false;
                }
                this.Close();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (e.KeyData == Keys.Down)
            {
                
                int i = dataGridView1.Rows.GetNextRow(dataGridView1.CurrentRow.Index, DataGridViewElementStates.None); //获取原选定下一行索引
                if (i <= tb.Rows.Count - 1 && i>=0)
                {
                    dataGridView1.CurrentCell = dataGridView1["姓名", i]; //指针下移
                    dataGridView1.Rows[i].Selected = true; //选中整行
                }
            }
            if (e.KeyData == Keys.Up)
            {
                int i = dataGridView1.Rows.GetPreviousRow(dataGridView1.CurrentRow.Index, DataGridViewElementStates.None); //获取原选定下一行索引
                if (i <= tb.Rows.Count - 1 && i >= 0)
                {
                    dataGridView1.CurrentCell = dataGridView1["姓名", i]; //指针上移
                    dataGridView1.Rows[i].Selected = true; //选中整行
                }
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0];
            }
            catch { }
        }
    }
}