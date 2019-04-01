using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using YpClass;
using TrasenFrame.Classes;

namespace ts_yf_tjbb
{
    public partial class FrmPDRate : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;

        public FrmPDRate()
        {
            InitializeComponent();
        }

        public FrmPDRate(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void FrmPDRate_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                dtp1.Value = dt.AddDays((1 - dt.Day));
                dtp2.Value = dt.AddDays((1 - dt.Day)).AddMonths(1).AddDays(-1);
                //初始化
                FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");

                //Yp.AddcmbYear(InstanceForm.BCurrentDept.DeptId, this.cmbypzlx, InstanceForm.BDatabase);
                //Yp.AddCmbYplx(true,InstanceForm.BCurrentDept.DeptId,cmbyplx, InstanceForm.BDatabase);
                this.rdo1.Checked = true;

                Yp.AddcmbYjks(cmbyjks, DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

                if (YpConfig.kslx(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) != DeptType.未知)
                {
                    cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    cmbyjks.Enabled = false;
                }
                Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);

            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();


            if (rdo1.Checked == true)
            {
                dtp1.Enabled = true;
                dtp2.Enabled = true;
                cmbyear.Enabled = false;
                cmbmonth.Enabled = false;
            }
            else
            {
                dtp1.Enabled = false;
                dtp2.Enabled = false;
                cmbyear.Enabled = true;
                cmbmonth.Enabled = true;
            }
        }

        private void cmbyjks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);
        }

        private void cmbyear_SelectedValueChanged(object sender, EventArgs e)
        {
            Yp.AddcmbMonth(Convert.ToInt32(cmbyjks.SelectedValue), Convert.ToInt32(this.cmbyear.Text), cmbyear, cmbmonth, InstanceForm.BDatabase);
        }

        private void cmbmonth_SelectedValueChanged(object sender, EventArgs e)
        {
            Yp.Seekkjqj(Convert.ToInt32(cmbyear.Text), Convert.ToInt32(cmbmonth.Text), Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);
        }

        private void buttj_Click(object sender, EventArgs e)
        {

            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                this.buttj.Enabled = false;
                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Value = Convert.ToInt32(cmbyjks.SelectedValue);
                parameters[1].Value = dtp1.Value.ToShortDateString() + " 00:00:00";
                parameters[2].Value = dtp2.Value.ToShortDateString() + " 23:59:59";

                parameters[0].Text = "@deptid";
                parameters[1].Text = "@rq1";
                parameters[2].Text = "@rq2";

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YF_TJ_PDRate", parameters, 30);
                FunBase.AddRowtNo(tb);
                this.myDataGrid1.DataSource = tb;
            }
            catch
            {
            }
            finally
            {
                this.buttj.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}