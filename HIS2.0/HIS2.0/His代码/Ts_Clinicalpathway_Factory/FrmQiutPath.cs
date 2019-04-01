using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using System.Drawing.Drawing2D;
namespace Ts_Clinicalpathway_Factory
{
    public partial class FrmQiutPath : Form
    {
        public string _pathway_id;
        public string _exe_step_id;
        public string _pathway_exe_id;
        public int _iscp = 0;
        public FrmQiutPath(string pathway_id,string exe_step_id,string pathway_exe_id,int iscp)
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            _pathway_id = pathway_id;
            _exe_step_id = exe_step_id;
            _pathway_exe_id = pathway_exe_id;
            _iscp = iscp;
            this.label2.Text = _iscp == 0 ? "请写出退出路径的理由：" : "请写出退出单病种的理由：";
            DataTable tbreason = FrmMdiMain.Database.GetDataTable("select * from  PATH_UNEXE_REASON where delete_bit=0 and ntype=1 ");
            this.dataGridView1.DataSource = tbreason;
            this.dataGridView1.EnableHeadersVisualStyles = false;
           // this.dataGridView1.AutoResizeColumns( DataGridViewAutoSizeColumnsMode.Fill);
            
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.Text.Trim() == "")
            {
                MessageBox.Show("理由不能为空，必须填写！");
                this.richTextBox1.Focus();
                return;
            }
            try
            {
                string sql = "select * from PATH_VARIANT where 1=2";
                DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
                DataRow row = tb.NewRow();
                tb.Rows.Add(row);
                row["PATH_VARIANT_ID"] = _pathway_exe_id;//改为执行id
                row["PATHWAY_ID"] = new Guid(_pathway_id);
                row["CONTENT"] = this.richTextBox1.Text;
                row["CREATE_DATE"] = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                row["EMPID_CREATE"] = FrmMdiMain.CurrentUser.EmployeeId;
                PublicFunction.databaseupdate(sql, tb);
                PublicFunction.UpdatePathWayStatus(FrmMdiMain.Database, _pathway_exe_id, 3);
                PublicFunction.UpdatePathStepStatus(FrmMdiMain.Database, _exe_step_id, 1);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i=this.dataGridView1.CurrentCell.RowIndex;
            this.richTextBox1.Text += this.dataGridView1.Rows[i].Cells[0].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable temp = (DataTable)this.dataGridView1.DataSource;
            temp.DefaultView.RowFilter = "pym like '%" + this.textBox1.Text.Trim() + "%' or wmb like '%" + this.textBox1.Text.Trim() + "%'";

        }
    }
}