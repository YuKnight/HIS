using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using ts_mzys_class;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace ts_mzys_blcflr
{
    public partial class 用药级别审核 : Form
    {
        public 用药级别审核()
        {
            InitializeComponent();
        }
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public 用药级别审核(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }
        private DataTable Tbys;//医生数据

        private void txtYs_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Text.Trim() == "") control.Tag = "";
        }

        private void txtYs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 8)
            {
                txtYs.Tag = "0";
                txtYs.Text = "";
                return;
            }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new TrasenFrame.Forms.FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
                f.WorkForm = this;
                f.srcControl = txtYs;
                f.Font = txtYs.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtYs.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtYs.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    txtYs.Text = f.SelectDataRow["name"].ToString().Trim();
                    txtYs.Focus();
                    e.Handled = true;
                }

            }
            else
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void 用药级别审核_Load(object sender, EventArgs e)
        {
            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            butcx_Click(null, null);
        }

        private void txtmzh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    txtmzh.Text = Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                    butcx_Click(null, null);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    txtkh.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
                    butcx_Click(null, null);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void butcx_Click(object sender, EventArgs e)
        {
            string where_sql = " where a.BSCBZ= 0 and shy ="+InstanceForm.BCurrentUser.EmployeeId;
            if (chksqrq.Checked) where_sql += " and sqsj >= '" + dateTimePicker1.Value.ToShortDateString() + "' and sqsj < '" + dateTimePicker1.Value.AddDays(1).ToShortDateString() + "'";


            if (txtkh.Text.Trim() != "") where_sql += " and KH = '" + txtkh.Text.Trim() + "'";
            if (txtmzh.Text.Trim() != "") where_sql += " and BLH = '" + txtmzh.Text.Trim() + "'";

            if (txtYs.Tag != null && txtYs.Tag.ToString() != "0")
                where_sql += " and sqys =" + txtYs.Tag.ToString();

            string queryString = "";

            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                queryString = @"select 0 选择, ypsqid,BRXM 病人姓名,blh 门诊号,dbo.fun_getEmpName(sqys) 申请医生,sqysjb 医生级别,sqsj 申请时间,BZ 备注,yppm 品名,YPSPM 商品名,YPGG 规格,(select dwmc from YP_YPDW where ID= ypdw) 单位,CFJB 处方级别 from MZYS_YPSQ_RECORD a
left join MZ_GHXX b on a.ghxxid = b.GHXXID
left join YY_BRXX c on b.BRXXID = c.BRXXID
left join YY_KDJB d on d.KDJID = b.KDJID  ";
                where_sql += " and isnull(bzt,0) =0";
                dataGridView1.DataSource = InstanceForm.BDatabase.GetDataTable(queryString + where_sql);
            }
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                queryString = @"select BRXM 病人姓名,blh 门诊号,dbo.fun_getEmpName(sqys) 申请医生,sqysjb 医生级别,sqsj 申请时间,BZ 备注,yppm 品名,YPSPM 商品名,YPGG 规格,(select dwmc from YP_YPDW where ID= ypdw) 单位,CFJB 处方级别,
dbo.fun_getEmpName(shy) 审核人,shsj 审核时间 from MZYS_YPSQ_RECORD a
left join MZ_GHXX b on a.ghxxid = b.GHXXID
left join YY_BRXX c on b.BRXXID = c.BRXXID
left join YY_KDJB d on d.KDJID = b.KDJID";
                where_sql = " and isnull(bzt,0) =1";

                dataGridView2.DataSource = InstanceForm.BDatabase.GetDataTable(queryString + where_sql);
            }
            
        }

        private void Audit(Guid sqid,int shy,string shsj)
        {
            Guid _NewYpsqid = Guid.Empty;
            int _err_code = -1;
            string _err_text = "";
            mzys.SentYpsqRecord(sqid, Guid.Empty, 0, "", "", 0, "", 0, 0, 0, "", 0, 1, shy, shsj,"", out _NewYpsqid, out _err_code, out _err_text, InstanceForm.BDatabase);

            if ((_NewYpsqid == Guid.Empty && _NewYpsqid == Guid.Empty) || _err_code != 0) throw new Exception(_err_text);            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            DataTable tb = (DataTable)dataGridView1.DataSource;

            int nrow = dataGridView1.CurrentCell.RowIndex;
            int ncol = dataGridView1.CurrentCell.ColumnIndex;

            string shsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");


            if (tb.Rows[e.RowIndex]["选择"].ToString() == "0")
                tb.Rows[e.RowIndex]["选择"] = "1";
            else
                tb.Rows[e.RowIndex]["选择"] = "0";

            if (dataGridView1.Columns[ncol].Name == "操作")
            {
                Audit(new Guid(tb.Rows[nrow]["ypsqid"].ToString()), InstanceForm.BCurrentUser.EmployeeId, shsj);
                MessageBox.Show("审核成功！");
                butcx_Click(null, null);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                butsh.Visible = true;
                butall.Visible = true;
            }
            else
            {
                butsh.Visible = false;
                butall.Visible = false;
            }
            butcx_Click(null, null);
        }

        private void butsh_Click(object sender, EventArgs e)
        {
            DataTable tab = (DataTable)dataGridView1.DataSource;
            DataRow[] rows = tab.Select("选择=1");
            string shsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");
            for (int i = 0; i <= rows.Length - 1; i++)
                Audit(new Guid(rows[i]["ypsqid"].ToString()), InstanceForm.BCurrentUser.EmployeeId, shsj);

            MessageBox.Show("审核成功！");
            butcx_Click(null, null);

        }

        private void butall_Click(object sender, EventArgs e)
        {
            DataTable tab = (DataTable)dataGridView1.DataSource;
            string shsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");
            for (int i = 0; i <= tab.Rows.Count - 1; i++)
                Audit(new Guid(tab.Rows[i]["ypsqid"].ToString()), InstanceForm.BCurrentUser.EmployeeId, shsj);

            MessageBox.Show("审核成功！");
            butcx_Click(null, null);
        }
    }
}