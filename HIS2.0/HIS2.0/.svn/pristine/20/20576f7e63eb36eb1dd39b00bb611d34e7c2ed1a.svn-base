using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using YpClass;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_yf_tjbb
{
    public partial class FrmJyxsHZtj : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        string ksname_bh = "";
        public FrmJyxsHZtj()
        {
            InitializeComponent();
        }
        public FrmJyxsHZtj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }
        private void FrmJyxsHZtj_Load(object sender, EventArgs e)
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
        }

       

        #region 输入提示
        private void ks_selectKS(object sender, KeyPressEventArgs e)
        {
            //--select distinct b.DEPT_ID,b.NAME,D_CODE,PY_CODE,wb_code from VI_YF_DJ a,JC_DEPT_PROPERTY b where a.DEPTID=b.DEPT_ID and b.deleted='0'--union 
            // string sql = " select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from JC_DEPT_PROPERTY where MZ_FLAG=1 or ZY_FLAG=1 and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and deleted=0 order by DEPT_ID";	
            string sql = " select  b.DEPT_ID,b.NAME,D_CODE,PY_CODE,wb_code from JC_DEPT_PROPERTY b where   b.deleted=0 and LAYER=3";
            DataTable Tbks = InstanceForm.BDatabase.GetDataTable(sql) ;
            if ((int)e.KeyChar == 8 || (int)e.KeyChar == 46)
            {
                txtks.Text = "";
                txtks.Tag = "";
                return;
            }

            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "科室名称", "数字码", "拼音码", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbks;
                f.WorkForm = this;
                f.srcControl = txtks;
                f.Font = txtks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                    return;
                }
                else
                {
                    string strName = f.SelectDataRow["name"].ToString().Trim();
                    string strCode = Convert.ToInt32(f.SelectDataRow["dept_id"]).ToString();
                    if (control.Name == "txtks")
                    {
                        if (Convert.ToString("," + txt_KsNot.Text + ",").Contains("," + strName + ",") == false)
                        {
                            if (txt_KsNot.Text.Trim() != "") txt_KsNot.Text += ",";
                            txt_KsNot.Text += strName;
                        }
                        if (txt_KsNot.Tag == null) txt_KsNot.Tag = "";
                        if (Convert.ToString("," + txt_KsNot.Tag.ToString() + ",").Contains("," + strCode + ",") == false)
                        {
                            if (txt_KsNot.Tag.ToString() != "") txt_KsNot.Tag = txt_KsNot.Tag.ToString() + ",";
                            txt_KsNot.Tag = txt_KsNot.Tag.ToString() + strCode;
                        }

                    }
                    else
                    {
                        control.Tag = strCode;
                        control.Text = strName;
                    }
                    e.Handled = true;
                }
            }
        }

        #endregion
        private void btnTJ_Click(object sender, EventArgs e)
        {
            try
            {
                ksname_bh = txt_KsNot.Text;
                this.Cursor = PubStaticFun.WaitCursor();
                this.btnTJ.Enabled = false;
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Value = dtp1.Value.ToShortDateString() ;
                parameters[1].Value = dtp2.Value.ToShortDateString() ;
                parameters[2].Value = Convert.ToInt32(cmbyplx.SelectedValue);//药品类型
                parameters[3].Value = Convert.ToInt32(cmbyjks.SelectedValue);//药剂科室
                parameters[4].Value = Convert.ToInt32(cmbypsx.SelectedIndex);//药品属性 \
                if (txt_KsNot.Tag == null)
                    txt_KsNot.Tag = "";
                parameters[5].Value = txt_KsNot.Tag;//科室

                parameters[0].Text = "@rq1";
                parameters[1].Text = "@rq2";
                parameters[2].Text = "@yplx";
                parameters[3].Text = "@deptid";
                parameters[4].Text = "@ypsx";
                parameters[5].Text = "@ksname";


                DataTable tb = InstanceForm.BDatabase.GetDataTable("sp_yf_tj_xstjbyks", parameters);
                FunBase.AddRowtNo(tb);

                decimal sumlsje = 0;
                decimal sumlsje_JY = 0;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    sumlsje = sumlsje + Convert.ToDecimal(tb.Rows[i]["药品销售金额"]);
                    sumlsje_JY = sumlsje_JY + Convert.ToDecimal(tb.Rows[i]["基药销售金额"]);
                }
                DataRow newrow = tb.NewRow();
                newrow["药品销售金额"] = sumlsje.ToString("0.00");
                newrow["基药销售金额"] = sumlsje_JY.ToString("0.00");
                newrow["序号"] = "合计";
                newrow["科室"] = " ";
                if (sumlsje == 0 || sumlsje_JY == 0)
                    newrow["基药销售占比"] = "0";
                else
                    newrow["基药销售占比"] = (sumlsje_JY * 100 / sumlsje).ToString("0.00");
                tb.Rows.Add(newrow);

                //this.statusBar1.Panels[0].Text = "进货金额:" + sumjhje.ToString("0.00");
                //this.statusBar1.Panels[1].Text = "零售金额:" + sumlsje.ToString("0.00");
                //this.statusBar1.Panels[2].Text = "进零差额:" + sumjlce.ToString("0.00");


                tb.TableName = "Tb";
                this.myDataGrid1.DataSource = tb;
                this.btnTJ.Enabled = true;

                this.statusBar1.Panels[0].Text ="药品销售金额:"+Convert.ToString(newrow["药品销售金额"]);
                this.statusBar1.Panels[1].Text = "基药销售金额:" + newrow["基药销售金额"];
                this.statusBar1.Panels[2].Text = "基药销售占比" + newrow["基药销售占比"];

            }
            catch (System.Exception err)
            {
                this.btnTJ.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                #region 简单打印

                this.btnexcel.Enabled = false;
                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string title = "";
                string where1 = "";
                    title = title + "日期:" + dtp1.Value.ToShortDateString() + " 到:" + dtp2.Value.ToShortDateString();
                    where1 = "药剂科室:" + cmbyjks.Text.Trim();
                    //where1 = where1 + " 日期:" + dtp1.Value.ToShortDateString() + " 到:" + dtp2.Value.ToShortDateString() + "";
                    where1 = where1 + " 药品类型:" + cmbyplx.Text + "  药品属性:" + cmbypsx.Text + " ";
                if(ksname_bh!="")
                    where1 += " 科室（包括）:" + ksname_bh;
                
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
                myExcel.Cells[1, 1] = TrasenFrame.Classes.Constant.HospitalName + this.Text;
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
                this.btnexcel.Enabled = true;
                #endregion
            }
            catch (System.Exception err)
            {
                //this.btnprint.Enabled = true;
                MessageBox.Show(err.Message);
            }
        }

        private void cmbyjks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbyplx, InstanceForm.BDatabase);
        }

        private void txtks_KeyPress(object sender, KeyPressEventArgs e)
        {
            ks_selectKS(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txt_KsNot.Text = "";
            this.txt_KsNot.Tag = "";
        }

        private void FrmJyxsHZtj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }

        
    }
}