using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
//using ts_mz_class;
using YpClass;
using TrasenFrame.Forms;
namespace ts_yf_tjbb
{
    public partial class FrmLYYP_KS : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;

        private DataTable Tbks = new DataTable();
        public FrmLYYP_KS()
        {
            InitializeComponent();
        }

        public FrmLYYP_KS(MenuTag menuTag, string chineseName, Form mdiParent)
		{
            InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;

		}

        private void FrmLYYP_KS_Load(object sender, EventArgs e)
        {            

            #region 药剂科室
            string sqlyjks = @"select 0 deptid,'全部' ksmc
                            union
                            select deptid,ksmc from YP_YJKS where KSLX='药房'";
            DataTable dt_yjks = InstanceForm.BDatabase.GetDataTable(sqlyjks);
            if (dt_yjks.Rows.Count > 0)//药房
            {
                cmbyjks.DataSource = dt_yjks;
                cmbyjks.DisplayMember = "ksmc";
                cmbyjks.ValueMember = "deptid";
                cmbyjks.SelectedIndex = 0;
            }
            #endregion

            #region 领药方式
            DataTable dt_lyfs = GetLYFS();
            if (dt_lyfs.Rows.Count > 0)
            {
                cmbtlfs.DataSource = dt_lyfs;
                cmbtlfs.DisplayMember = "name";
                cmbtlfs.ValueMember = "id";
                cmbtlfs.SelectedIndex = 0;
            }
            #endregion

            Getks();
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                buttj.Enabled = false;
                #region 统计
                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Value = dtp1.Value.ToString("yyyy-MM-dd");
                parameters[1].Value = dtp2.Value.ToString("yyyy-MM-dd");
                parameters[2].Value = cmbyjks.SelectedValue;
                parameters[3].Value = Convertor.IsNull(txtks.Tag,"");
                parameters[4].Value = Convertor.IsNull(cmbtlfs.SelectedValue, "0");

                parameters[0].Text = "@rq1";
                parameters[1].Text = "@rq2";
                parameters[2].Text = "@yfdm";
                parameters[3].Text = "@ksdm";
                parameters[4].Text = "@lyfs";

                //DataSet dset = new DataSet();
                //InstanceForm.BDatabase.AdapterFillDataSet("SP_yp_yply_kslx", parameters, dset, "kss", 660);
                //dataGridView1.Columns.Clear();
                //dset.Tables[0].TableName = "Tb";
                //this.dataGridView1.DataSource = dset.Tables[0];
                //Fun.AddRowtNo(dset.Tables[0]);


                DataView dv = new DataView();
                dv = InstanceForm.BDatabase.GetDataTable("SP_yp_yply_kslx", parameters, 660).DefaultView;
                FunBase.AddRowtNo(dv.Table);

                DataTable tb = dv.Table;
                decimal sumjhje = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(进货金额)", ""), "0"));
                decimal sumpfje = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(批发金额)", ""), "0"));
                decimal sumlsje = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(零售金额)", ""), "0"));
                decimal sumplce = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(批零差额)", ""), "0"));
                decimal sumjlce = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(进零差额)", ""), "0"));
                decimal sumdjzs = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(单据张数)", ""), "0"));

                this.statusBar1.Panels[0].Text = "进货金额 " + sumjhje.ToString("0.00");
                this.statusBar1.Panels[1].Text = "批发金额 " + sumpfje.ToString("0.00");
                this.statusBar1.Panels[2].Text = "零售金额 " + sumlsje.ToString("0.00");
                this.statusBar1.Panels[3].Text = "批零差额 " + sumplce.ToString("0.00");
                this.statusBar1.Panels[4].Text = "进零差额 " + sumjlce.ToString("0.00");
                this.statusBar1.Panels[5].Text = "单据张数 " + sumdjzs;

                DataRow row = tb.NewRow();
                row["序号"] = "合计";
                row["进货金额"] = sumjhje.ToString();
                row["批发金额"] = sumpfje.ToString();
                row["零售金额"] = sumlsje.ToString();
                row["批零差额"] = sumplce.ToString();
                row["进零差额"] = sumjlce.ToString();
                row["单据张数"] = sumdjzs.ToString();
                row["领药科室"] = "";
                tb.Rows.Add(row);

                tb.TableName = "Tb";
                this.myDataGrid1.DataSource = dv;

                #endregion
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                buttj.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        #region 统领方式
        private DataTable GetLYFS()
        {
            DataTable Tb = new DataTable("Datas");
            Tb.Columns.Add("id", Type.GetType("System.String"));//Int32
            Tb.Columns.Add("name", Type.GetType("System.String"));
            Tb.Rows.Add(new object[] { "0", "全部" });//
            Tb.Rows.Add(new object[] { "1", "统领" });
            Tb.Rows.Add(new object[] { "2", "摆药" });
            Tb.Rows.Add(new object[] { "3", "处方" });
            Tb.Rows.Add(new object[] { "4", "其他" });

            return Tb;
        }
        #endregion

        private void butexcel_Click(object sender, EventArgs e)
        {
            //ts_jc_log.ExcelOper.ExportData_ForDataTable(myDataGrid1, "门诊处方用药统计表");
            try
            {
                #region 导出

                this.butexcel.Enabled = false;
                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string title = "";
                string where1 = "";
                title = "药剂科室:" + Convert.ToString(cmbyjks.Text).Trim() + "    领药方式:" + Convert.ToString(cmbtlfs.Text);

                if (txtks.Text != "")
                    title += "    科室编码包含:" + txtks.Text;
                

                where1 = title + where1;

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
                myExcel.Cells[1, 1] = TrasenFrame.Classes.Constant.HospitalName + "科室领药情况";
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

                ////最后一行为黄色
                //myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;

                //让Excel文件可见
                myExcel.Visible = true;
                #endregion
            }
            catch (System.Exception err)
            {

                MessageBox.Show(err.Message);
            }
            finally
            {
                this.butexcel.Enabled = true;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 科室输入提示

        public DataTable Getks()
        {
            string ssql = @"select  a.DEPT_ID,a.NAME,D_CODE,PY_CODE,wb_code from JC_DEPT_PROPERTY a,JC_DEPT_TYPE_RELATION b where a.DEPT_ID=b.DEPT_ID and b.TYPE_CODE='009'
                          and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " ";
            Tbks=InstanceForm.BDatabase.GetDataTable(ssql);
            return Tbks;
        }

        private void ks_select(object sender, KeyPressEventArgs e)
        {            
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
                    control.Tag = strCode;
                    control.Text = strName;           
                    e.Handled = true;
                }
            }
        }
        #endregion

        private void txtks_KeyPress(object sender, KeyPressEventArgs e)
        {
            ks_select(sender, e);
        }
    }
}