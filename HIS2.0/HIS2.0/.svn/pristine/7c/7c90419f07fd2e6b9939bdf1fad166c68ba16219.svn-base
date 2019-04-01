using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
namespace ts_zyhs_yzgl
{
    public partial class FrmCzxx : Form
    {
        DataTable tbry = new DataTable();
        DataTable tbdept = new DataTable();
        public FrmCzxx()
        {
            InitializeComponent();
        }

        private void FrmCzxx_Load(object sender, EventArgs e)
        {

            string sql = "select -1 id,'全部' name union all  select  a.dept_id id,dbo.fun_getDeptname(a.DEPT_ID) name from JC_DEPT_TYPE_RELATION a join jc_dept_property b on a.dept_id=b.dept_id  where b.zy_flag=1 ";//a.type_code='004' and 
            tbdept = FrmMdiMain.Database.GetDataTable(sql);

            DataTable ks=FrmMdiMain.Database .GetDataTable("select a.dept_id  from JC_WARDRDEPT  a  join jc_dept_property b on a.dept_id=b.dept_id where  b.zy_flag=1 and ward_id in(select ward_id from JC_WARDRDEPT where DEPT_ID=" + FrmMdiMain.CurrentDept.DeptId + ")");
            //判断是否存在科室
            this.combdept.DisplayMember = "name";
            this.combdept.ValueMember = "id";
            this.combdept.DataSource = tbdept;
            if (ks.Rows.Count > 0)
            {
                this.combdept.SelectedValue = ks.Rows[0]["dept_id"];
                this.combdept.Enabled = false;
            }
            else
            {
                this.combdept.SelectedValue = -1;
            }
            sql = "select distinct NAME 姓名,a.EMPLOYEE_ID ID,PY_CODE,WB_CODE from JC_ROLE_NURSE a join JC_EMPLOYEE_PROPERTY b on a.EMPLOYEE_ID=b.EMPLOYEE_ID left join  JC_EMP_DEPT_ROLE c on a.EMPLOYEE_ID=c.EMPLOYEE_ID ";
            if (ks.Rows.Count > 0)
              sql+= "  where c.dept_id in (select dept_id  from JC_WARDRDEPT where ward_id in(select ward_id from JC_WARDRDEPT where DEPT_ID=" + FrmMdiMain.CurrentDept.DeptId + ") ) ";
            tbry = FrmMdiMain.Database.GetDataTable(sql);
            this.serchText1.tb = tbry;
            this.combdept.SelectedIndexChanged += new EventHandler(combdept_SelectedIndexChanged);
        }

        void combdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btncx_Click(null,null);
        }

        private void btncx_Click(object sender, EventArgs e)
        {

            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                string sql = "select   c.NAME 病人姓名,dbo.fun_getDeptname(b.DEPT_BR) 病人科室, c.bed_no 床号,a.BOOK_DATE 冲正日期,dbo.fun_getEmpName(a.BOOK_USER) 冲正人 ,b.ORDER_BDATE 开医嘱时间,b.ORDER_CONTEXT 医嘱内容, "
                +"   a.NUM 数量,a.COST_PRICE 单价,a.ACVALUE 金额,dbo.fun_getEmpName(b.ORDER_DOC) 开嘱医生,dbo.fun_getEmpName( b.AUDITING_USER) 转抄护士, "
                          +"  dbo.fun_getDeptname(b.EXEC_DEPT) 执行科室 , dbo.fun_getDeptname(b.DEPT_ID) 开单科室  "
                           +"    "

                          + "   from ZY_FEE_SPECI a join ZY_ORDERRECORD b on a.ORDER_ID=b.ORDER_ID  left join VI_ZY_VINPATIENT_ALL c on a.INPATIENT_ID=c.INPATIENT_ID and a.BABY_ID=c.BABY_ID   "
                          + "   where CZ_FLAG=2 and TYPE=1   ";
               
                sql += " and  a.book_date >='" + this.dateTimePicker1.Value.ToShortDateString() + " 00:00:00'  and a.book_date<='" + this.dateTimePicker2.Value.ToShortDateString() + " 23:59:59'";
                if (this.serchText1.textBox1.Tag != null && this.serchText1.textBox1.Text.Trim() != "")
                    sql += "  and  a.book_user=" + this.serchText1.textBox1.Tag.ToString();
                if (this.combdept.SelectedValue.ToString() != "-1")
                {
                    sql += "   and b.DEPT_BR in (select dept_id  from JC_WARDRDEPT where ward_id in(select ward_id from JC_WARDRDEPT where DEPT_ID=" + this.combdept.SelectedValue.ToString() + ") )  ";
                }
                //add by zouchihua 2023-8-26 增加是否显示自动冲正
                if (!this.checkBox1.Checked)
                {
                   sql+=" and BZ not like '%系统自动冲正%'";
                }  

                DataTable tb = FrmMdiMain.Database.GetDataTable(sql,60); 
                this.dataGridView1.DataSource = tb;
                this.Cursor = Cursors.Default;
            }
            catch(Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }

        }

        private void serchText1_fz()
        {
            if (serchText1.row == null)
                return;
            DataRow row = serchText1.row;
            this.serchText1.textBox1.Text = row["姓名"].ToString().Trim();
            this.serchText1.textBox1.Tag = row["id"].ToString().Trim();
        }

        private void serchText1_TextChage()
        {
            serchText1.BringToFront();
            tbry.DefaultView.RowFilter = "PY_CODE like '%" + this.serchText1.textBox1.Text.Trim() + "%' or WB_CODE like '%" + this.serchText1.textBox1.Text.Trim() + "%' or 姓名 like '%" + this.serchText1.textBox1.Text.Replace("%", "") + "%'";
            this.serchText1.tb = tbry.DefaultView.ToTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                #region 简单打印
                DataTable tb = (DataTable)this.dataGridView1.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }



                Excel.Application myExcel = new Excel.ApplicationClass(); //new Excel.Application();
                //关闭时不显示提示
                //myExcel.DefaultFilePath = "";
                //myExcel.DisplayAlerts = false;
                //myExcel.SheetsInNewWorkbook = 1;
                Excel.Workbook xlBook = myExcel.Application.Workbooks.Add(true);

                //查询条件
                string rq = "日期:" + this.dateTimePicker1.Value.ToShortDateString() + " 到 " + this.dateTimePicker2.Value.ToShortDateString();
                string ks = "";

                string swhere = rq + ks;


                //写入行头

                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                {
                    if (this.dataGridView1.Columns[j].Visible)
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = "" + this.dataGridView1.Columns[j].HeaderText;
                    }
                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        if (this.dataGridView1.Columns[j].Visible)
                        {
                            ncol = ncol + 1;
                            myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();
                            //if (tb.Columns[j].ColumnName.IndexOf("比例") >= 0)
                            //{
                            //    myExcel.Cells[6 + i, ncol] = "'" + Convert.ToDecimal(Convert.ToDecimal(tb.Rows[i][j].ToString().Trim()) * 100).ToString("0.00") + "%";
                            //}
                        }
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();//6
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();//6

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = TrasenFrame.Classes.Constant.HospitalName + "冲正信息表";
                myExcel.Cells[1, 1] = ss;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                myExcel.Cells[3, 1] = swhere.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //最后一行为黄色
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;

                //xlBook.SaveCopyAs("d:\\yy.xls");
                //让Excel文件可见
                myExcel.Visible = true;
                //myExcel.Workbooks.Close();
                if (xlBook != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);
                    xlBook = null;

                }
                if (myExcel != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcel);
                    myExcel = null;
                    //xlApp.Quit(); 

                }
                GC.Collect();

                #endregion
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                //this.btExcel.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}