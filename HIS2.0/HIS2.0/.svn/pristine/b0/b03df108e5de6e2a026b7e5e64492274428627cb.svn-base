using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenFrame.Classes;

namespace ts_mz_tjbb
{
    public partial class FrmBaseReportLsh : FrmBaseReport
    {
        public FrmBaseReportLsh()
        {
            InitializeComponent();
        }

        public FrmBaseReportLsh(MenuTag menuTag, string chineseName, Form mdiParent, string reportFilename)
        {
            InitializeComponent();

            base.InitForm(menuTag, chineseName, mdiParent, reportFilename);

            FunAddComboBox.AddOperator(true, cmbuser, InstanceForm.BDatabase);

            cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
        }

        protected override void ReportInit()
        {
            base.ReportInit();
            //ÅÌµãºÅ
            if (report.ParameterByName("lsh") != null)
                report.ParameterByName("lsh").AsString = this.txtLsh.Text.ToString();
            if (report.ParameterByName("jky") != null)
                report.ParameterByName("jky").AsString = this.ckbJky.Checked ? this.cmbuser.Text.ToString() : "È«²¿";
        }

        protected override object[] SetParams()
        {
            object[] procedureParams = new object[4];

            procedureParams[0] = this.ckbDate.Checked ? this.dtpBegin.Value.Date.ToString() : "";
            procedureParams[1] = this.ckbDate.Checked ? this.dtpEnd.Value.Date.ToString() : "";

            procedureParams[2] =  this.txtLsh.Text.ToString().Trim() == "" ? 0 : Convert.ToInt32(this.txtLsh.Text.ToString().Trim());

            procedureParams[3] = (this.ckbJky.Checked == false) ? 0 : Convert.ToInt32(cmbuser.SelectedValue.ToString());

            return procedureParams;
        }

        private void txtLsh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                this.ckbDate.Checked = false;
                this.ckbJky.Checked = false;
                btnRetrieve_Click(null, null);
            }
        }

       
    }
}