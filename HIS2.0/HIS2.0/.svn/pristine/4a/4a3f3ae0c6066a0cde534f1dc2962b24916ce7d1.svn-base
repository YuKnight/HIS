using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using ts_mz_class;

namespace ts_mz_tjbb
{
    public partial class FrmBaseReportHtdw : FrmBaseReport
    {
        public FrmBaseReportHtdw()
        {
            InitializeComponent();
        }

        public FrmBaseReportHtdw(MenuTag menuTag, string chineseName, Form mdiParent, string reportFilename)
        {
            InitializeComponent();

            FunAddComboBox.AddHtdwLx(false, cmbdwlx, InstanceForm.BDatabase);

            cmbdwlx.SelectedValue = 1;

            base.InitForm(menuTag, chineseName, mdiParent, reportFilename);

        }

        protected override void ReportInit()
        {
            base.ReportInit();
            if (report.ParameterByName("htdwmc") != null)
                report.ParameterByName("htdwmc").AsString = this.txthtdw.Text.Trim();
            //定义数据集的各个字段
            IGRRecordset RecordSet = report.DetailGrid.Recordset;

            report.DetailGrid.Columns.RemoveAll();
            report.DetailGrid.Recordset.Fields.RemoveAll();

            RecordSet.AddField("姓名", GRFieldType.grftString).Format = "";
            IGRColumn ColumnBrxm = report.DetailGrid.AddColumn("姓名", "姓名", "姓名", 1.5);
            ColumnBrxm.TitleCell.TextAlign = GRTextAlign.grtaMiddleCenter;
            ColumnBrxm.ContentCell.TextAlign = GRTextAlign.grtaMiddleCenter;
            ColumnBrxm.ContentCell.Font.Point = 9;

            RecordSet.AddField("安全员", GRFieldType.grftString).Format = "";
            IGRColumn ColumnAqy = report.DetailGrid.AddColumn("安全员", "安全员", "安全员", 1.5);
            ColumnAqy.TitleCell.TextAlign = GRTextAlign.grtaMiddleCenter;
            ColumnAqy.ContentCell.TextAlign = GRTextAlign.grtaMiddleCenter;
            ColumnAqy.ContentCell.Font.Point = 9;

            RecordSet.AddField("记账收费员", GRFieldType.grftString).Format = "";
            IGRColumn ColumnSfy = report.DetailGrid.AddColumn("记账收费员", "记账收费员", "记账收费员", 2);
            ColumnSfy.TitleCell.TextAlign = GRTextAlign.grtaMiddleCenter;
            ColumnSfy.ContentCell.TextAlign = GRTextAlign.grtaMiddleCenter;
            ColumnSfy.ContentCell.Font.Point = 9;

            RecordSet.AddField("记账日期", GRFieldType.grftString).Format = "";
            IGRColumn ColumnRq = report.DetailGrid.AddColumn("记账日期", "记账日期", "记账日期", 2);
            ColumnRq.TitleCell.TextAlign = GRTextAlign.grtaMiddleCenter;
            ColumnRq.ContentCell.TextAlign = GRTextAlign.grtaMiddleCenter;
            ColumnRq.ContentCell.Font.Point = 9;

            if (_menuTag.Function_Name == "Fun_MZSF_HTDWMX")
            {

                RecordSet.AddField("回款员", GRFieldType.grftString).Format = "";
                IGRColumn ColumnHky = report.DetailGrid.AddColumn("回款员", "回款员", "回款员", 2);
                ColumnHky.TitleCell.TextAlign = GRTextAlign.grtaMiddleCenter;
                ColumnHky.ContentCell.TextAlign = GRTextAlign.grtaMiddleCenter;
                ColumnHky.ContentCell.Font.Point = 9;

                RecordSet.AddField("回款日期", GRFieldType.grftString).Format = "";
                IGRColumn ColumnHkrq = report.DetailGrid.AddColumn("回款日期", "回款日期", "回款日期", 2);
                ColumnHkrq.TitleCell.TextAlign = GRTextAlign.grtaMiddleCenter;
                ColumnHkrq.ContentCell.TextAlign = GRTextAlign.grtaMiddleCenter;
                ColumnHkrq.ContentCell.Font.Point = 9;

                RecordSet.AddField("发票号", GRFieldType.grftString).Format = "";
                IGRColumn ColumnFph = report.DetailGrid.AddColumn("发票号", "发票号", "发票号", 2);
                ColumnFph.TitleCell.TextAlign = GRTextAlign.grtaMiddleCenter;
                ColumnFph.ContentCell.TextAlign = GRTextAlign.grtaMiddleCenter;
                ColumnFph.ContentCell.Font.Point = 9;
            }

            RecordSet.AddField("门诊号", GRFieldType.grftString).Format = "";
            IGRColumn ColumnBlh = report.DetailGrid.AddColumn("门诊号", "门诊号", "门诊号", 3);
            ColumnBlh.TitleCell.TextAlign = GRTextAlign.grtaMiddleCenter;
            ColumnBlh.ContentCell.TextAlign = GRTextAlign.grtaMiddleCenter;
            ColumnBlh.ContentCell.Font.Point = 9;
            

            foreach (DataColumn Col in dt.Columns)
            {

                string baseField = Col.ColumnName;
                if (baseField == "门诊号" || baseField == "安全员" || baseField == "姓名" || baseField == "记账日期" || baseField == "发票号" || baseField == "回款日期" || baseField == "记账收费员" || baseField == "回款员" || baseField == "记账收费员") continue;
                IGRColumn ColumnBase;

                switch (Col.DataType.Name.ToString())
                {
                    case "int":
                        RecordSet.AddField(baseField, GRFieldType.grftInteger).Format = "0;;#";
                        break;
                    case "float":
                        RecordSet.AddField(baseField, GRFieldType.grftFloat).Format = "0.00;;#";
                        break;
                    case "Decimal":
                        RecordSet.AddField(baseField, GRFieldType.grftFloat).Format = "0.00;;#";
                        break;
                    default:
                        RecordSet.AddField(baseField, GRFieldType.grftString).Format = "";
                        break;
                }

                ColumnBase = report.DetailGrid.AddColumn(baseField, baseField, baseField, 1.5);
                ColumnBase.TitleCell.TextAlign = GRTextAlign.grtaMiddleCenter;

                ColumnBase.ContentCell.FreeCell = true;
                ColumnBase.ContentCell.Controls.RemoveAll();
                IGRMemoBox memoBox = ColumnBase.ContentCell.Controls.Add(GRControlType.grctMemoBox) as IGRMemoBox;
                memoBox.Text = "[#" + baseField + ":0.00;;##]";
                memoBox.Dock = GRDockStyle.grdsFill;
                memoBox.TextAlign = GRTextAlign.grtaMiddleRight;
            }
        }

        protected override object[] SetParams()
        {
            object[] procedureParams = new object[4];

            procedureParams[0] = this.dtpBegin.Value.Date;
            procedureParams[1] = this.dtpEnd.Value.Date;

            procedureParams[2] = Convertor.IsNull(this.txthtdw.Tag,"0").ToString();

            procedureParams[3] = cmbdwlx.SelectedValue.ToString();

            return procedureParams;
        }
        private void txtHtdw_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 8)
            {
                txthtdw.Tag = "0";
                txthtdw.Text = "";
                return;
            }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "单位名称", "数字码", "拼音码", "五笔码" };
                string[] mappingname = new string[] { "dwmc", "szm", "pym", "wbm" };
                string[] searchfields = new string[] { "dwmc", "szm", "pym", "wbm" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new TrasenFrame.Forms.FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = InstanceForm.BDatabase.GetDataTable("select * from jc_htdw");
                f.WorkForm = this;
                f.srcControl = txthtdw;
                f.Font = txthtdw.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txthtdw.Focus();
                    e.Handled = true;
                }
                else
                {
                    txthtdw.Tag = Convert.ToInt32(f.SelectDataRow["id"]);
                    txthtdw.Text = f.SelectDataRow["dwmc"].ToString().Trim();

                    e.Handled = true;


                    //txtYs.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    //txtYs.Text = f.SelectDataRow["name"].ToString().Trim();
                    //txtYs.Focus();
                    //e.Handled = true;
                }
            }
            else
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtHtdw_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Text.Trim() == "")
            {
                control.Tag = "0";
            }
        }

        private void cmbdwlx_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmbdwlx.SelectedValue == null) return;
            if (cmbdwlx.SelectedValue.ToString() == "1")
            {
                txthtdw.Visible = true;
                label1.Visible = true;
            }
            else
            {
                txthtdw.Visible = false;
                label1.Visible = false;
                txthtdw.Tag = "0";
                txthtdw.Text = "";
            }
        }
    }
}