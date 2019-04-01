using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using YpClass;
using TrasenFrame.Classes;

namespace ts_yf_tjbb
{
    public partial class Xspm_kss : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        string ifZFPH = "0";//是否查询增幅表
        string strYLFLtxt = "";//
        public Xspm_kss(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.WindowState = FormWindowState.Maximized;
            //if (_menuTag.Function_Name == "Fun_ts_yf_tjbb_xspm" )
            //{
            //    this.pan1.Visible = false;
            //}
        }
        private void Xspm_kss_Load(object sender, EventArgs e)
        {
            try
            {
                Yp.AddcmbYjks(true, cmbyjks, DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                if (YpConfig.kslx(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) != DeptType.未知)
                {
                    cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    cmbyjks.Enabled = false;
                }
                Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), this.cmbyplx, InstanceForm.BDatabase);

                cmbypsx.SelectedIndex = 10;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            //this.dtp2.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            this.dtp1.Text = DateTime.Now.ToString("yyyy-MM-")+"01" ;
        }

        private void txtYLFL_KeyPress(object sender, KeyPressEventArgs e)
        {
            ks_select(sender,e);
        }
        #region 输入提醒
        private void ks_select(object sender, KeyPressEventArgs e)
        {
            string sqlYLFL = "select ID,FLMC,dbo.FUN_YP_ylfl(FID) as fid,PYM,WBM from YP_YLFL where BDELETE='0' and FLBH<>'0' order by id";
            DataTable dtYLFL = InstanceForm.BDatabase.GetDataTable(sqlYLFL);
            if ((int)e.KeyChar == 8 || (int)e.KeyChar == 46)
            {
                txtYLFL.Text = "";
                txtYLFL.Tag = "";
                return;
            }

            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "ID", "药理分类", "父类型", "拼音码","五笔码" };
                string[] mappingname = new string[] { "ID", "FLMC", "fid", "PYM", "WBM" };
                string[] searchfields = new string[] { "PYM", "WBM" };
                int[] colwidth = new int[] { 0, 150, 100, 80,80 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = dtYLFL;
                f.WorkForm = this;
                f.srcControl = txtYLFL;
                f.Font = txtYLFL.Font;
                f.Width = 450;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtYLFL.Focus();
                    return;
                }
                else
                {
                    txtYLFL.Text = f.SelectDataRow["FLMC"].ToString().Trim();
                    txtYLFL.Tag = f.SelectDataRow["ID"].ToString();
                    e.Handled = true;
                }
            }

        }
        #endregion

        private void btntj_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                btntj.Enabled = false;
                ifZFPH = "0";
                if (chkZFPH.Checked)
                    ifZFPH = "1";
                else
                    ifZFPH = "0";
                strYLFLtxt = txtYLFL.Text;
                string rq1Str = dtp1.Value.ToString("yyyy-MM-dd");
                string rq2Str = dtp2.Value.ToString("yyyy-MM-dd");
                //if (Convert.ToInt32(Convertor.IsNull(txtnum.Text, "0")) == 0) { MessageBox.Show("请输入排名"); return; }
                ParameterEx[] parameters = new ParameterEx[9];
                parameters[0].Value = Convert.ToInt32(this.rdoje.Checked);
                parameters[1].Value = Convert.ToInt32(cmbyplx.SelectedValue);
                parameters[2].Value = dtp1.Value.ToString();
                parameters[3].Value = dtp2.Value.ToString();
                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(txtnum.Text, "0"));
                parameters[5].Value = Convert.ToInt32(cmbyjks.SelectedValue);
                parameters[6].Value = Convert.ToInt32(cmbypsx.SelectedIndex);
                parameters[7].Value = Convert.ToString(txtYLFL.Tag);//药理分类
                parameters[8].Value = ifZFPH;//是否查询每月增幅金额                


                parameters[0].Text = "@type";
                parameters[1].Text = "@yplx";
                parameters[2].Text = "@dtp1";
                parameters[3].Text = "@dtp2";
                parameters[4].Text = "@mc";
                parameters[5].Text = "@deptid";
                parameters[6].Text = "@ypsx";//药品属性
                parameters[7].Text = "@ypylfl";//药理分类
                parameters[8].Text = "@ifZFPH";
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YF_tj_xspmtj", parameters, 30);
                FunBase.AddRowtNo(tb);
                tb.TableName = "Tb";
                this.myDataGrid1.DataSource = tb;

                decimal sumpfje = 0;//批发金额
                decimal sumlsje = 0;
                decimal sumplce = 0;//批零差额
                int _rows = 0;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    sumpfje = sumpfje + Convert.ToDecimal(tb.Rows[i]["批发金额"]);
                    sumlsje = sumlsje + Convert.ToDecimal(tb.Rows[i]["零售金额"]);
                    _rows++;
                }
                sumplce = sumlsje - sumpfje;
                this.statusBar1.Panels[0].Text = "批发金额 " + sumpfje.ToString("0.00");
                this.statusBar1.Panels[1].Text = "零售金额 " + sumlsje.ToString("0.00");
                this.statusBar1.Panels[2].Text = "批零差额 " + sumplce.ToString("0.00");
                this.statusBar1.Panels[3].Text = _rows.ToString()+" 种药品数";
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                btntj.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void cmbyjks_SelectedValueChanged(object sender, EventArgs e)
        {
            Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbyplx, InstanceForm.BDatabase);
        }

        private void chkZFPH_CheckedChanged(object sender, EventArgs e)
        {
            if (chkZFPH.Checked)
            {
                this.rdoje.Text = "按销售数量(增幅)";
                this.rdosl.Text = "按销售金额(增幅)";
            }
            else
            {
                this.rdoje.Text = "按销售数量";
                this.rdosl.Text = "按销售金额";
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {                
                #region 简单打印
                this.Cursor = PubStaticFun.WaitCursor();
                this.btnexcel.Enabled = false;
                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string title = "排名方式:";
                if (rdoje.Checked == true)
                    title = title + "按金额排名";
                else
                    title = title + "按数量排名";
                string where1 = "";


                where1 = "药剂科室:" + cmbyjks.Text.Trim();
                where1 = where1 + " 日期:" + dtp1.Value.ToShortDateString() + " 到:" + dtp2.Value.ToShortDateString() + "";
                where1 = where1 + " 药品类型:" + cmbyplx.Text + "  药品属性:" + cmbypsx.Text + " ";
                if (strYLFLtxt != "")
                   where1 = where1 + " 药理分类:"+txtYLFL.Text+"  ";
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
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                if(ifZFPH=="0")
                    myExcel.Cells[1, 1] = TrasenFrame.Classes.Constant.HospitalName + "销售排名统计";
                else
                    myExcel.Cells[1, 1] = TrasenFrame.Classes.Constant.HospitalName + "与上月对比增幅排名统计";
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
                //myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;

                //让Excel文件可见
                myExcel.Visible = true;
                this.btnexcel.Enabled = true;
                #endregion
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally 
            {
                this.btnexcel.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Xspm_kss_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }
    }
}