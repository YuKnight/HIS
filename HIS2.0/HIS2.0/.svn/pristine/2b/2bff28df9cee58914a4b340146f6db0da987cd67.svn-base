using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;

namespace Ts_zyys_yzgl
{
    public partial class FrmKJMD : Form
    {
        public FrmKJMD()
        {
            InitializeComponent();
          
        }
        private string strId = string.Empty;
        private DataTable dtAll = new DataTable();
        public FrmKJMD(DataTable dtTemp)
        {
            InitializeComponent();
            dtAll = dtTemp;
            DataColumn dc = new DataColumn("KJYWZY", Type.GetType("System.Int32")); 
            dtAll.Columns.Add(dc); 
            this.dgvList.AutoGenerateColumns = false;
        }
        
        private void FrmKJMD_Load(object sender, EventArgs e)
        { 
            DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();
            dataGridViewComboBoxColumn = (DataGridViewComboBoxColumn)this.dgvList.Columns[2];
            dataGridViewComboBoxColumn.ValueMember = "ID";
            dataGridViewComboBoxColumn.DisplayMember = "NAME"; 
            dataGridViewComboBoxColumn.DataSource = BingKjzy(); 
            this.dgvList.DataSource = GetShowDt();
            this.dgvList.Focus();
        }

        private DataTable GetShowDt()
        {
            foreach (DataRow row in dtAll.Rows)
            {
                string strSql = string.Format(@"SELECT KJYWZY FROM  ZY_ORDERRECORD WHERE ORDER_ID='{0}'",row["ID"].ToString());
                DataTable dt =FrmMdiMain.Database.GetDataTable(strSql);
                if (dt.Rows.Count == 0) row[0] = 0;
                else
                {
                    if (string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                        row["KJYWZY"] = 0; 
                    else
                        row["KJYWZY"] = Convert.ToInt32(dt.Rows[0][0].ToString());
                }
            }
            return dtAll;
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private DataTable BingKjzy()
        {
            string strSql = string.Format(@"SELECT ID,NAME FROM JC_KJYP_Purpose union all select 0 AS ID,'' as NAME ");
            DataTable dt= FrmMdiMain.Database.GetDataTable(strSql.ToString());
            return dt; 
        } 
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.label1.Text = "";
            try
            {
                FrmMdiMain.Database.BeginTransaction();
                foreach (DataGridViewRow row in dgvList.Rows)
                {
                    if (row.Cells[2].Value.ToString() == "0")
                    {
                       // dgvList.EditMode = DataGridViewEditMode.EditProgrammatically;//.EditOnKeystroke;//.EditOnEnter;
                        dgvList.BeginEdit(true);
                        dgvList.CurrentCell = row.Cells[2];
                       //  MessageBox.Show("请全部补齐，再保存！");
                        this.label1.Text = "请填写完用药目的，再保存！";
                        FrmMdiMain.Database.RollbackTransaction();
                         return;
                    }
                    string strSql = string.Format(@"UPDATE ZY_ORDERRECORD SET KJYWZY={0} WHERE ORDER_ID='{1}'", row.Cells[2].Value.ToString(), row.Cells[8].Value.ToString());
                    FrmMdiMain.Database.DoCommand(strSql.ToString());

                }
                
                FrmMdiMain.Database.CommitTransaction();
                //MessageBox.Show("完成");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show(ex.Message);
            } 
        }

        private void dgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
             //e.Cancel = true;
             e.ThrowException = false;
        }

         

        private void dgvList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            dgvList.Rows[e.RowIndex].Cells["clYwmd"].ErrorText =
                    ""; 
            if (dgvList.Columns[e.ColumnIndex].Name == "clYwmd")
            {
              //  this.BindingContext[((DataTable)this.dgvList.DataSource)].EndCurrentEdit();
                if (e.FormattedValue.ToString() == String.Empty)
                {
                    dgvList.Rows[e.RowIndex].Cells["clYwmd"].ErrorText =
                      "理由不能为空";
                    if (!this.btnCancle.Focused)
                    {
                         MessageBox.Show("理由不能为空");
                       e.Cancel = true;
                    }
                    else
                    {
                        
                    }
                   // dgvList.EndEdit();
                    
                }
                
            }
        } 
    }
}