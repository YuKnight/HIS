using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_yp_kjbb.Condiction
{
    public partial class UCCondictionYP : UserControl, IParameterEx, ISelectionItemValidate
    {
        private DataTable dtYPCD;

        public UCCondictionYP()
        {
            InitializeComponent();
            cboDeptType.SelectedIndexChanged += delegate(object sender, EventArgs e)
            {
                string sql = " select  DEPTID,KSMC from YP_YJKS where KSLX='" + cboDeptType.Text + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
                cboDept.DisplayMember = "KSMC";
                cboDept.ValueMember = "DEPTID";
                cboDept.DataSource = tb;
            };
            checkBox1.CheckedChanged += delegate(object sender, EventArgs e)
            {
                cboMonth.Enabled = checkBox1.Checked;
            };
            for (int i = 2014; i < 2024; i++)
                cboYear.Items.Add(i.ToString());
            for (int i = 1; i <= 12; i++)
                cboMonth.Items.Add(i.ToString());

            this.cboYear.Text = DateTime.Now.Year.ToString();
            this.cboMonth.Text = DateTime.Now.Month.ToString();
            this.checkBox1.Checked = true;

            this.Load += new EventHandler(UCCondictionYP_Load);
        }

        void UCCondictionYP_Load(object sender, EventArgs e)
        {
            dtYPCD = InstanceForm.BDatabase.GetDataTable("select cjid,PYM,WBM,YPPM,YPSPM,YPGG,S_YPDW from VI_YP_YPCD ");
            this.labelTextBox1.ShowCardProperty[0].ShowCardDataSource = dtYPCD;
        }

        #region IParameterEx 成员

        public ParameterEx[] GetStoreProcedureParameters()
        {
            List<ParameterEx> list = new List<ParameterEx>();
            ParameterEx p;

            p = new ParameterEx();
            p.Text = "DEPTID";
            p.Value = Convert.ToInt32(cboDept.SelectedValue);
            list.Add(p);

            p = new ParameterEx();
            p.Text = "@yk";
            p.Value = cboDeptType.Text == "药库" ? 1 : 0;
            list.Add(p);

            p = new ParameterEx();
            p.Text = "@jhjetj";
            p.Value = radioButton1.Checked ? 1 : 0;
            list.Add(p);

            p = new ParameterEx();
            p.Text = "@year";
            p.Value = Convert.ToInt32(cboYear.Text);
            list.Add(p);

            p = new ParameterEx();
            p.Text = "@month";
            p.Value = checkBox1.Checked ? Convert.ToInt32(cboMonth.Text) : 0;
            list.Add(p);

            int cjid = 0, ecjid = 0;
            if (rdoDgyp.Checked)
            {
                cjid = Convert.ToInt32(Convertor.IsNull(this.labelTextBox1.SelectedValue, "0"));
                ecjid = cjid;
            }
            if (rdoYpbm.Checked)
            {
                cjid = Convert.ToInt32(Convertor.IsNull(this.txtYpbmB.Text, "0"));
                ecjid = Convert.ToInt32(Convertor.IsNull(this.txtYpbmE.Text, "0"));
            }

            p = new ParameterEx();
            p.Text = "@cjid";
            p.Value = cjid;
            list.Add(p);

            p = new ParameterEx();
            p.Text = "@ecjid";
            p.Value = ecjid;
            list.Add(p);

            p = new ParameterEx();
            p.Text = "@ERR_CODE";
            p.Value = 0;
            p.ParaDirection = ParameterDirection.Output;
            list.Add(p);

            p = new ParameterEx();
            p.Text = "@ERR_TEXT";
            p.ParaSize = 200;
            p.ParaDirection = ParameterDirection.Output;
            list.Add(p);

            return list.ToArray();
        }

        public ParameterEx[] GetReportParameters()
        {
            List<ParameterEx> list = new List<ParameterEx>();
            ParameterEx p;
            p = new ParameterEx();
            p.Text = ReportParameterDefine.库房类型;
            p.Value = cboDeptType.Text;
            list.Add(p);

            p = new ParameterEx();
            p.Text = ReportParameterDefine.库房名称;
            p.Value = cboDept.Text.Trim();
            list.Add(p);

            p = new ParameterEx();
            p.Text = ReportParameterDefine.价格统计方式;
            p.Value = radioButton1.Checked ? "按进价" : "按零售价";
            list.Add(p);

            p = new ParameterEx();
            p.Text = ReportParameterDefine.统计年份;
            p.Value = Convert.ToInt32(cboYear.Text);
            list.Add(p);

            p = new ParameterEx();
            p.Text = ReportParameterDefine.统计月份;
            p.Value = checkBox1.Checked ? Convert.ToInt32(cboMonth.Text) : 0;
            list.Add(p);

            int cjid = Convert.ToInt32(Convertor.IsNull(this.labelTextBox1.SelectedValue, "0"));
            YpClass.Ypcj cj = new YpClass.Ypcj(cjid, InstanceForm.BDatabase);

            p = new ParameterEx();
            p.Text = ReportParameterDefine.药品名称;
            p.Value = string.Format("{0}({1})", cj.S_YPPM, cj.S_YPSPM);
            list.Add(p);

            p = new ParameterEx();
            p.Text = ReportParameterDefine.药品规格;
            p.Value = cj.S_YPGG;
            list.Add(p);

            p = new ParameterEx();
            p.Text = ReportParameterDefine.药品单位;
            p.Value = cj.S_YPDW;
            list.Add(p);

            p = new ParameterEx();
            p.Text = ReportParameterDefine.药品货号;
            p.Value = cj.CJID;
            list.Add(p);

            return list.ToArray();
        }

        #endregion

        #region ISelectionItemValidate 成员

        public bool Validing(out string message)
        {
            message = "";
            if (cboDeptType.SelectedIndex == -1)
            {
                message = "库房类型没有选择";
                return false;
            }
            if (cboDept.SelectedIndex == -1)
            {
                message = "库房没有选择";
                return false;
            }
            if (cboYear.SelectedIndex == -1)
            {
                message = "统计年份没有选择";
                return false;
            }
            //Modify By Tany 2016-04-20
            if (rdoDgyp.Checked && Convertor.IsNull(this.labelTextBox1.SelectedValue, "0") == "0")
            {
                message = "没有选择药品";
                return false;
            }
            //Add By Tany 2016-04-20
            if (rdoYpbm.Checked)
            {
                if (!Convertor.IsNumeric(this.txtYpbmB.Text))
                {
                    message = "请输入开始药品编码";
                    txtYpbmB.Focus();
                    txtYpbmB.SelectAll();
                    return false;
                }
                if (!Convertor.IsNumeric(this.txtYpbmE.Text))
                {
                    message = "请输入结束药品编码";
                    txtYpbmE.Focus();
                    txtYpbmE.SelectAll();
                    return false;
                }
                if (Convert.ToDecimal(this.txtYpbmB.Text) > Convert.ToDecimal(this.txtYpbmE.Text))
                {
                    message = "结束药品编码不能小于开始药品编码";
                    txtYpbmE.Focus();
                    txtYpbmE.SelectAll();
                    return false;
                }
            }
            return true;
        }

        #endregion

        private void rdoDgyp_CheckedChanged(object sender, EventArgs e)
        {
            labelTextBox1.Enabled = rdoDgyp.Checked;
        }

        private void rdoYpbm_CheckedChanged(object sender, EventArgs e)
        {
            txtYpbmB.Enabled = rdoYpbm.Checked;
            txtYpbmE.Enabled = rdoYpbm.Checked;
        }

    }
}
