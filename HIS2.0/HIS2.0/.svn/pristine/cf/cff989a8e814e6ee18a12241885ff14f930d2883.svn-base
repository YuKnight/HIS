using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;

namespace ts_mzys_blcflr
{
    public partial class 用药申请 : Form
    {
        public 用药申请()
        {
            InitializeComponent();
        }

        public 用药申请(int shy_n)
        {
            InitializeComponent();
            this.shy_n = shy_n;

        }

        public int shy;

        public string bz = "";

        public int shy_n;

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
                f.StartPosition = FormStartPosition.CenterScreen;
                //f.Top = txtYs.DisplayRectangle.Top + txtYs.Height;
                //f.Left = txtYs.DisplayRectangle.Left;

                //f.Top = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Top + dataGridView1.Top;
                //buthelp.Left = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Left + dataGridView1.Left + dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Width - buthelp.Width;
                
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

        private void butOk_Click(object sender, EventArgs e)
        {
            shy = Convert.ToInt32(txtYs.Tag.ToString());
            bz = txtbz.Text.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void 用药申请_Load(object sender, EventArgs e)
        {
            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
            if (shy_n != 0)
            {
                txtYs.Tag = shy_n;
                txtYs.Text = Fun.SeekEmpName(shy_n, InstanceForm.BDatabase);
            }
        }
    }
}