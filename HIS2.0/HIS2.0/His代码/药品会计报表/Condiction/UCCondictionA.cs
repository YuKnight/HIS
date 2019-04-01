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
    public partial class UCCondictionA : UserControl, IParameterEx, ISelectionItemValidate
    {
        public UCCondictionA()
        {
            InitializeComponent();
            this.Load += new EventHandler(UCCondictionA_Load);
            checkBox1.CheckedChanged += delegate(object sender, EventArgs e)
            {
                cboMonth.Enabled = checkBox1.Checked;
            };
            checkBox2.CheckedChanged += delegate(object sender, EventArgs e)
            {
                cmbEndMonth.Enabled = checkBox2.Checked;
            };
        }

        void UCCondictionA_Load(object sender, EventArgs e)
        {
            for (int i = 2014; i < 2024; i++)
                cboYear.Items.Add(i.ToString());
            for (int i = 1; i <= 12; i++)
                cboMonth.Items.Add(i.ToString());

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            if (month == 1)
            {
                year = year - 1;
                month = 12;
            }
            else
            {
                month = month - 1;
            }

            this.cboYear.Text = year.ToString();
            this.cboMonth.Text = month.ToString();
            this.checkBox1.Checked = true;

            //Modify By Tany 2016-03-01 增加结束时间
            for (int i = 2014; i < 2024; i++)
                cmbEndYear.Items.Add(i.ToString());
            for (int i = 1; i <= 12; i++)
                cmbEndMonth.Items.Add(i.ToString());

            this.cmbEndYear.Text = year.ToString();
            this.cmbEndMonth.Text = month.ToString();
            this.checkBox2.Checked = true;

            cboDeptType.SelectedIndex = 0;

            //Modify By Tany 2016-03-01 增加院区
            string ss = "select distinct YQID,YQMC from jc_dept_property where YQID>0 order by YQID";
            DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(ss);

            DataRow row = tb.NewRow();
            row["YQMC"] = "全部";
            row["YQID"] = "0";
            tb.Rows.InsertAt(row, 0);

            cmbYq.ValueMember = "YQID";
            cmbYq.DisplayMember = "YQMC";
            cmbYq.DataSource = tb;

            cmbYq.SelectedIndex = 0;
        }

        #region IParameterEx 成员

        public ParameterEx[] GetStoreProcedureParameters()
        {
            List<ParameterEx> list = new List<ParameterEx>();
            ParameterEx p;
            p = new ParameterEx();
            p.Text = "@yk";
            p.Value = cboDeptType.SelectedIndex;
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

            //Add By Tany 2016-03-01
            p = new ParameterEx();
            p.Text = "@endyear";
            p.Value = Convert.ToInt32(cmbEndYear.Text);
            list.Add(p);

            p = new ParameterEx();
            p.Text = "@endmonth";
            p.Value = checkBox2.Checked ? Convert.ToInt32(cmbEndMonth.Text) : 0;
            list.Add(p);

            p = new ParameterEx();
            p.Text = "@yq";
            p.Value = Convert.ToInt32(cmbYq.SelectedValue);
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

            //Add By Tany 2016-03-01
            p = new ParameterEx();
            p.Text = ReportParameterDefine.院区名称;
            p.Value = cmbYq.Text;
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
            if (cboYear.SelectedIndex == -1)
            {
                message = "统计年份没有选择";
                return false;
            }
            return true;
        }

        #endregion
    }
}
