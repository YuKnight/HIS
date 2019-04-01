using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;


namespace ts_yk_tjbb
{
    public partial class Frmrkhztj_jy : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        public Frmrkhztj_jy()
        {
            InitializeComponent();
        }

        public Frmrkhztj_jy(MenuTag menuTag, string chineseName, Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
        private void Frmrkhztj_jy_Load(object sender, EventArgs e)
        {
            try
            {
                dtp1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                dtp2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                //初始化
                //FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");

                this.rdo1.Checked = true;

                Yp.AddCmbYjks(false, InstanceForm.BCurrentDept.DeptId, cmbyjks, InstanceForm.BDatabase);

                Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);

            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                this.buttj.Enabled = false;
                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Value = Convert.ToInt32(cmbyjks.SelectedValue);
                parameters[1].Value = dtp1.Value.ToShortDateString() + " 00:00:00";
                parameters[2].Value = dtp2.Value.ToShortDateString() + " 23:59:59";
                parameters[3].Value = 0;//Convert.ToInt32(cmbyplx.SelectedValue);

                parameters[0].Text = "@deptid";
                parameters[1].Text = "@rq1";
                parameters[2].Text = "@rq2";
                parameters[3].Text = "@yplx";
                parameters[4].Text = "@year";
                parameters[5].Text = "@month";
                parameters[6].Text = "@deptid_ck";
                parameters[6].Value = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));

                if (rdo1.Checked == true)//按日期
                {
                    parameters[4].Value = 0;
                    parameters[5].Value = 0;
                }
                else//按月份
                {
                    parameters[4].Value = Convert.ToInt32(cmbyear.Text);
                    parameters[5].Value = Convert.ToInt32(cmbmonth.Text);
                }

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YK_TJ_RKHZ_JY", parameters, 30);
                FunBase.AddRowtNo(tb);

                decimal sumypsl = 0;//数量
                decimal sumpfje = 0;//批发金额
                decimal sumlsje = 0;//零售金额

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    sumypsl = sumypsl + Convert.ToDecimal(tb.Rows[i]["数量"]);
                    sumpfje = sumpfje + Convert.ToDecimal(tb.Rows[i]["批发金额"]);
                    sumlsje = sumlsje + Convert.ToDecimal(tb.Rows[i]["零售金额"]);
                }
                DataRow newrow = tb.NewRow();
                newrow["数量"] = sumypsl.ToString("0.00");
                newrow["批发金额"] = sumpfje.ToString("0.00");
                newrow["零售金额"] = sumlsje.ToString("0.00");
                newrow["批发价"] = "";
                newrow["零售价"] = "";
                newrow["货号"] = "";
                newrow["品名"] = "";
                newrow["规格"] = "";
                newrow["厂家"] = "";
                newrow["送货单位"] = "";
                newrow["序号"] = "合计";
                tb.Rows.Add(newrow);

                this.statusBar1.Panels[0].Text = "数量:" + sumypsl.ToString("0.00");
                this.statusBar1.Panels[1].Text = "批发金额:" + sumpfje.ToString("0.00");
                this.statusBar1.Panels[2].Text = "零售金额:" + sumlsje.ToString("0.00");


                tb.TableName = "Tb";
                this.myDataGrid1.DataSource = tb;
                this.buttj.Enabled = true;


            }
            catch (System.Exception err)
            {
                this.buttj.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                #region 简单打印

                this.butexcel.Enabled = false;
                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string title = ":";
                if (rdo1.Checked == true)
                    title = title + "日期:" + dtp1.Value.ToShortDateString() + " 到:" + dtp2.Value.ToShortDateString();
                else
                    title = title + "年份:" + cmbyear.Text.Trim() + " 月份:" + cmbmonth.Text.Trim();
                string where1 = "";


                where1 = "药剂科室:" + cmbyjks.Text.Trim() + " 仓库名称:" + cmbck.Text.Trim();
                where1 = where1 + title;

                //写入行头
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = tb.Columns.Count;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    myExcel.Cells[5, 1 + j] = tb.Columns[j].ColumnName;

                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        myExcel.Cells[6 + i, 1 + j] = "" + tb.Rows[i][j].ToString();
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                //myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                myExcel.Cells[1, 1] = TrasenFrame.Classes.Constant.HospitalName + "基本药物入库汇总统计";
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                myExcel.Cells[3, 1] = where1.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //最后一行为黄色
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;

                //让Excel文件可见
                myExcel.Visible = true;
                this.butexcel.Enabled = true;
                #endregion
            }
            catch (System.Exception err)
            {
                //this.butprint.Enabled = true;
                MessageBox.Show(err.Message);
            }

        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdo1_CheckedChanged(object sender, System.EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            if (tb != null)
            {
                tb.Rows.Clear();
            }

            this.statusBar1.Panels[0].Text = "";
            this.statusBar1.Panels[1].Text = "";
            this.statusBar1.Panels[2].Text = "";
            this.statusBar1.Panels[3].Text = "";

            if (rdo1.Checked == true)
            {
                dtp1.Enabled = true;
                dtp2.Enabled = true;
                cmbyear.Enabled = false;
                cmbmonth.Enabled = false;
                this.statusBar1.Panels[3].Text = "";
            }
            else
            {
                dtp1.Enabled = false;
                dtp2.Enabled = false;
                cmbyear.Enabled = true;
                cmbmonth.Enabled = true;
                this.statusBar1.Panels[3].Text = Yp.Seekkjqj(Convert.ToInt32(cmbyear.Text), Convert.ToInt32(cmbmonth.Text), Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);
            }
        }


        private void cmbyear_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Yp.AddcmbMonth(Convert.ToInt32(cmbyjks.SelectedValue), Convert.ToInt32(this.cmbyear.Text), cmbyear, cmbmonth, InstanceForm.BDatabase);
        }


        private void cmbmonth_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.rdo2.Checked == true)
                this.statusBar1.Panels[3].Text = Yp.Seekkjqj(Convert.ToInt32(cmbyear.Text), Convert.ToInt32(cmbmonth.Text), Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);
        }

        private void cmbyjks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);
            Yp.AddCmbYjks_ck(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbck, InstanceForm.BDatabase);
            if (this.rdo2.Checked == true)
                this.statusBar1.Panels[3].Text = Yp.Seekkjqj(Convert.ToInt32(cmbyear.Text), Convert.ToInt32(cmbmonth.Text), Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);

            if (cmbck.Items.Count == 1)
            {
                cmbck.Visible = false;
                lblck.Visible = false;
            }
            else
            {
                cmbck.Visible = true;
                lblck.Visible = true;
            }
        }

        private void butprint_Click(object sender, EventArgs e)
        {
            try
            {
                string where1 = "";
                //if (cmbck.Visible == true) where1 = "仓库名称:" + cmbck.Text.Trim() + "  ";
                where1 = "药剂科室:" + cmbyjks.Text.Trim() + "  ";
                if (cmbck.Visible == true && cmbck.Text.Trim() != cmbyjks.Text.Trim()) where1 = where1 + "仓库名称:" + cmbck.Text.Trim() + "  ";

                if (rdo1.Checked == true)
                {
                    where1 = where1 + "按日期统计  日期:" + dtp1.Value.ToShortDateString();
                    where1 = where1 + " 到:" + dtp2.Value.ToShortDateString();
                }
                else
                {
                    where1 = where1 + "按会计月份统计  日期:" + this.statusBar1.Panels[3].Text;
                }

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();

                DataRow myrow;
                int ii = 0;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    myrow = Dset.单据汇总统计.NewRow();
                    ii = ii + 1;
                    myrow["xh"] = ii.ToString();
                    myrow["yppm"] = Convert.ToString(tb.Rows[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(tb.Rows[i]["规格"]);
                    //myrow["jhje"] = Convert.ToDecimal(tb.Rows[i]["进货金额"]);
                    //myrow["pfje"] = Convert.ToDecimal(tb.Rows[i]["批发金额"]);
                    //myrow["lsje"] = Convert.ToDecimal(tb.Rows[i]["零售金额"]);
                    //myrow["jlce"] = Convert.ToDecimal(tb.Rows[i]["进零差额"]);
                    //myrow["plce"] = Convert.ToDecimal(tb.Rows[i]["批零差额"]);
                    //myrow["djzs"] = Convert.ToDecimal(tb.Rows[i]["单据张数"]);

                    Dset.单据汇总统计.Rows.Add(myrow);

                }

                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "where1";
                parameters[0].Value = where1.Trim();
                parameters[1].Text = "where2";
                parameters[1].Value = "";
                parameters[2].Text = "title";
                parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + cmbyjks.Text.Trim() + ")" + "入库汇总表";

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.单据汇总统计, Constant.ApplicationDirectory + "\\Report\\YP_test.rpt", parameters);
                if (f.LoadReportSuccess) f.Show(); else f.Dispose();


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Frmrkhztj_jy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }
    }
}