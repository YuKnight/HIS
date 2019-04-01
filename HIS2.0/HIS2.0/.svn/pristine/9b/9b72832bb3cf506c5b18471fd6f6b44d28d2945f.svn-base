using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mzys_class;
using ts_mz_class;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace ts_mzys_blcflr
{
    public partial class frmZyzCx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public frmZyzCx()
        {
            InitializeComponent();
        }
        public frmZyzCx(MenuTag menuTag, string chineseName, Form mdiParent)
        {

            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

        }
        private void butref_Click(object sender, EventArgs e)
        {
            try
            {
                string rq1 = chkrq.Checked == true ? dtp1.Value.ToShortDateString() : "";
                string rq2 = chkrq.Checked == true ? dtp2.Value.ToShortDateString() : "";

                DataTable tb = mzys_zyz.GetRecord(rq1, rq2, InstanceForm.BCurrentUser.EmployeeId, -1,
                    Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh1.Text.Trim(), txtbrxm.Text.Trim(), Guid.Empty, InstanceForm.BDatabase);
                dataGridView1.DataSource = tb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void butclose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkrq_CheckedChanged(object sender, EventArgs e)
        {
            dtp1.Enabled = chkrq.Checked == true ? true : false;
            dtp2.Enabled = chkrq.Checked == true ? true : false;
        }

        private void txtkh1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                txtkh1.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh1.Text.Trim(), InstanceForm.BDatabase);
                butref_Click(sender, e);
            }
        }

        private void txtbrxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                butref_Click(sender, e);
        }

        private void frmZyzCx_Load(object sender, EventArgs e)
        {
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
        }

        private void butexport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;
            ts_jc_log.ExcelOper.ExportData_ForDataTable(dataGridView1, "住院证查询");
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataGridViewRow currentRow = dataGridView1.CurrentRow;
            if (currentRow == null) return; 
            ParameterEx[] paramters = new ParameterEx[11];
            paramters[0].Text = "医院名称";
            paramters[0].Value = Constant.HospitalName;
            paramters[1].Text = "门诊号";
            paramters[1].Value = Convertor.IsNull(currentRow.Cells["clMzh"].Value, "");
            paramters[2].Text = "姓名";
            paramters[2].Value = Convertor.IsNull(currentRow.Cells["姓名"].Value, "");
            paramters[3].Text = "临时诊断";
            paramters[3].Value = Convertor.IsNull(currentRow.Cells["门诊诊断"].Value, "");
            paramters[4].Text = "申请科室";
            paramters[4].Value = Convertor.IsNull(currentRow.Cells["clDjDept"].Value, "");
            paramters[5].Text = "申请医师";
            paramters[5].Value = Convertor.IsNull(currentRow.Cells["clDjy"].Value, "");
            paramters[6].Text = "申请时间";
            paramters[6].Value = Convertor.IsNull(currentRow.Cells["clDjsj"].Value, "");
            paramters[7].Text = "护士注意事项";
            paramters[7].Value = Convertor.IsNull(currentRow.Cells["备注"].Value, "");
            paramters[8].Text = "年龄";
            paramters[8].Value = Convertor.IsNull(currentRow.Cells["年龄"].Value, "");
            paramters[9].Text = "性别";
            paramters[9].Value = Convertor.IsNull(currentRow.Cells["性别"].Value, "");
            paramters[10].Text = "入院科室";
            paramters[10].Value = Convertor.IsNull(currentRow.Cells["入院科室"].Value, ""); 
            
            DataSet _dset = new DataSet();
            DataTable dt = new DataTable("收费明细");
            dt.Columns.Add("item_name", Type.GetType("System.String"));
            dt.Columns.Add("je", Type.GetType("System.String"));
            _dset.Tables.Add(dt);

            string reportFile = Constant.ApplicationDirectory + "\\Report\\MZ_住院证.rpt";
            TrasenFrame.Forms.FrmReportView fView = new TrasenFrame.Forms.FrmReportView(_dset, reportFile, paramters, true);
             
        }
    }
}