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
using YpClass;
using ts_zyhs_classes;
namespace ts_zyhs_ypxx
{
    public partial class FrmZcySj : Form
    {
        BaseFunc myFunc = new BaseFunc();
        public FrmZcySj()
        {
            InitializeComponent();
            //this.dataGridView1.AutoGenerateColumns = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             DateTime date1 = DateTime.Parse(this.dateTimePicker1.Value.ToShortDateString() + "  00:00:00");
             DateTime date2 = DateTime.Parse(this.dateTimePicker2.Value.AddDays(1).ToShortDateString() + "  00:00:00");
            if (暂存药品上传 == wizard1.SelectedPage)
            {
                DataTable tmpable;
                DataTable Yptable = null;
               
                DataTable tbyf = (DataTable)this.cmbZxyf.DataSource;
                if (this.cmbZxyf.SelectedValue.ToString() == "-1")
                {
                    for (int i = 1; i < tbyf.Rows.Count; i++)
                    {
                        tmpable = ZcyBill.ZYHS_YPFY_SELECT(9, 0, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, Guid.Empty, 0, Convert.ToInt32(tbyf.Rows[i]["DEPTID"].ToString())
                                  , date1, date2);

                        if (Yptable == null)
                            Yptable = tmpable.Clone();
                        for (int j = 0; j < tmpable.Rows.Count; j++)
                        {
                            Yptable.ImportRow(tmpable.Rows[j]);
                        }
                        tmpable = ZcyBill.ZYHS_YPFY_SELECT(9, 1, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, Guid.Empty, 0, Convert.ToInt32(tbyf.Rows[i]["DEPTID"].ToString())
                             , date1, date2);
                        for (int j = 0; j < tmpable.Rows.Count; j++)
                        {
                            Yptable.ImportRow(tmpable.Rows[j]);
                        }
                    }
                }
                else
                {
                    tmpable = ZcyBill.ZYHS_YPFY_SELECT(9, 0, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, Guid.Empty, 0, Convert.ToInt32(this.cmbZxyf.SelectedValue.ToString())
                                 , date1, date2);

                    if (Yptable == null)
                        Yptable = tmpable.Clone();
                    for (int j = 0; j < tmpable.Rows.Count; j++)
                    {
                        Yptable.ImportRow(tmpable.Rows[j]);
                    }
                    tmpable = ZcyBill.ZYHS_YPFY_SELECT(9, 1, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, Guid.Empty, 0, Convert.ToInt32(this.cmbZxyf.SelectedValue.ToString())
                         , date1, date2);
                    for (int j = 0; j < tmpable.Rows.Count; j++)
                    {
                        Yptable.ImportRow(tmpable.Rows[j]);
                    }
                }

                FunBase.AddRowtNo(Yptable);
                this.dataGridView1.DataSource = Yptable;
                for (int j = 14; j < this.dataGridView1.Columns.Count; j++)
                {
                    this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (j >= 14)
                        this.dataGridView1.Columns[j].Visible = false;
                    else
                        this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                this.dataGridView1.Columns["数量"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                this.dataGridView1.Columns["数量"].DefaultCellStyle.ForeColor = Color.Blue;
                this.dataGridView1.ReadOnly = true;
                //增加一行合计
                DataRow r = Yptable.NewRow();
                decimal hjje = 0;
                for (int i = 0; i < Yptable.Rows.Count; i++)
                {
                    hjje += decimal.Parse(Yptable.Rows[i]["金额"].ToString());
                }
                r["类型"] = "合计";
                r["金额"] = hjje;
                Yptable.Rows.Add(r);
                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Yellow;
                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Blue;
                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].ReadOnly = true;
            }
            else
            {
                int ls = 9990;
                this.dataGridView2.DataSource = ZcyBill.Getzcysjjl(date1, date2, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId);
                for (int j = 0; j < this.dataGridView2.Columns.Count; j++)
                {
                    this.dataGridView2.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (this.dataGridView2.Columns[j].Name.Trim() == "cjid")
                    {
                        ls = j;
                    }
                    if (j >= ls)
                        this.dataGridView2.Columns[j].Visible = false;
                }
            }
        }

        private void FrmZcySj_Load(object sender, EventArgs e)
        {
            string sSql = "";
            sSql = " select '全部' ksmc,-1 deptid union all Select distinct b.KSMC,b.DEPTID from jc_DEPT_DRUGSTORE a inner join YP_YJKS b on a.drugstore_id=b.deptid " +
                " where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + InstanceForm.BCurrentDept.DeptId + ")";
           DataTable   yfTb = InstanceForm.BDatabase.GetDataTable(sSql);
           this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddMonths(-1);
            if (yfTb == null || yfTb.Rows.Count == 0)
            {
                return;
            }
            cmbZxyf.DisplayMember = "KSMC";
            cmbZxyf.ValueMember = "DEPTID";
            cmbZxyf.DataSource = yfTb;
            cmbZxyf.SelectedValueChanged += new EventHandler(cmbZxyf_SelectedValueChanged);
        }

        void cmbZxyf_SelectedValueChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
             

            SystemCfg cfg7117 = new SystemCfg(7117);
            string execdeptid = cfg7117.Config.Trim();
            DataTable Yptable1 = (DataTable)this.dataGridView1.DataSource;
            DataTable Yptable = Yptable1.Copy();
            if (Yptable == null || Yptable.Rows.Count == 0)
                return;
            Yptable.Rows.Remove(Yptable.Rows[Yptable.Rows.Count - 1]);
            //   myFunc.SendYP(Yptable, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), Convert.ToInt64(execdeptid), 0, FrmMdiMain.Jgbm);
            string[] GroupbyField1 ={ "EXECDEPT_ID" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };
            TrasenFrame.Classes.TsSet tsset1 = new TrasenFrame.Classes.TsSet();
            tsset1.TsDataTable = Yptable;
            DataTable tbfl = tsset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");

            if (MessageBox.Show("暂存数据上传【可能】需要几分钟甚至更长时间, 您确定要处理吗？\r\n点击是【处理】，请您耐心等待 ||  否【不处理】”？\n",
                       "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;


            try
            {
                //生成暂存药品统领单 这部可以省略
                for (int i = 0; i < tbfl.Rows.Count; i++)
                {
                   // writelog("搜索内存表");
                    Yptable.DefaultView.RowFilter = "EXECDEPT_ID=" + tbfl.Rows[i]["EXECDEPT_ID"].ToString();
                    DataTable tbtemp = Yptable.DefaultView.ToTable();
                   // writelog("搜索内存表完毕");
                    myFunc.SendYPzcgl(tbtemp, FrmMdiMain.CurrentDept.WardId, FrmMdiMain.CurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), Convert.ToInt64(tbfl.Rows[i]["EXECDEPT_ID"].ToString()), 0, FrmMdiMain.Jgbm, 5);
                }

                button1_Click(null, null);
                MessageBox.Show("发送成功！");
                this.wizard1.NavigateNext();
                button1_Click(null, null);
            }
            catch (Exception ex)
            {
                button1_Click(null, null);
                MessageBox.Show(ex.Message);
            }
            #region
            //Cursor.Current =PubStaticFun.WaitCursor();
            //FrmMdiMain.Database.BeginTransaction();
            //try
            //{
            //    writelog( "开始更新费用表");
            //    for (int i = 0; i < Yptable.Rows.Count; i++)
            //    {
            //        string update = "update ZY_FEE_SPECI set  bz=cast(EXECDEPT_ID as varchar(20)),fy_bit=1,FY_DATE=getdate(),FY_USER =" + FrmMdiMain.CurrentUser.EmployeeId + " , EXECDEPT_ID=" + execdeptid + " where id= '" + Yptable.Rows[i]["zy_id"].ToString() + "'";
            //        //sqlerr = update;
            //        FrmMdiMain.Database.DoCommand(update);
            //    }
            //    writelog( "更新费用表完毕");
            //    //生成发药信息
            //    Guid group_id = Guid.Empty;
            //    ZcyBill.Cszcyp(FrmMdiMain.Database, Yptable, InstanceForm.BCurrentDept.WardDeptId.ToString(), InstanceForm.BCurrentUser.EmployeeId, long.Parse(execdeptid), DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), FrmMdiMain.Jgbm, out  group_id);
            //    writelog( "生成暂存药品");
            //    //删除领药消息 add by zouchihua 2012-12-15
            //    string udpatess = " update ZY_APPLY_DRUG set DELETE_BIT=1,GROUP_ID='" + group_id + "' where APPLY_NURSE=" + FrmMdiMain.CurrentUser.EmployeeId + " and DELETE_BIT=0 and EXECDEPT_ID=" + execdeptid + " ";

            //    FrmMdiMain.Database.DoCommand(udpatess);
            //    Cursor.Current = Cursors.Default;
            //    FrmMdiMain.Database.CommitTransaction();
            //    button1_Click(null, null);
            //    MessageBox.Show("发送成功！");
            //    this.wizard1.NavigateNext();
            //    button1_Click(null, null);

            //}
            //catch(Exception ex) {
            //    FrmMdiMain.Database.RollbackTransaction();
            //    Cursor.Current = Cursors.Default;
            //    MessageBox.Show(ex.Message);
            //}
            #endregion

        }

        private void wizard1_WizardPageChanged(object sender, DevComponents.DotNetBar.WizardPageChangeEventArgs e)
        {
            if (wizard1.SelectedPageIndex == 0)
            {
                button3.Visible = false;
                button2.Visible = true; 
            }
            else
            {
                this.button2.Visible = false;
                button3.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Parse(this.dateTimePicker1.Value.ToShortDateString() + "  00:00:00");
            DateTime date2 = DateTime.Parse(this.dateTimePicker2.Value.AddDays(1).ToShortDateString() + "  00:00:00");
            DataTable tb = (DataTable)this.dataGridView2.DataSource;
            if (tb == null)
            {
                MessageBox.Show("请先查询");
                return;
            }
            string[] GroupbyField1 ={ "cjid", "deptly", "ywlx", "deptly", "zxdw", "单价", "dwbl", "wldw" };//
            string[] ComputeField1 ={"借药数量", "还药数量", "暂存上缴数量"  };//
            string[] CField1 ={"sum", "sum", "sum" };// 
            TrasenFrame.Classes.TsSet tsset1 = new TrasenFrame.Classes.TsSet();
            tsset1.TsDataTable = tb;
            DataTable tbfl = tsset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
            if (tbfl.Rows.Count == 0)
                return;
            int deptly=InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId;
            decimal zsl=0;
            decimal xj_kcl = 0;
            Guid sjpc =  Guid.NewGuid();
            InstanceForm.BDatabase.BeginTransaction();
            try
            {
                //暂存数量+还药数量-借药数量 
                for (int i = 0; i < tbfl.Rows.Count; i++)
                {
                    Guid sjid = Guid.NewGuid();
                    zsl = decimal.Parse(tbfl.Rows[i]["暂存上缴数量"].ToString()) + decimal.Parse(tbfl.Rows[i]["还药数量"].ToString())
                    - decimal.Parse(tbfl.Rows[i]["借药数量"].ToString());
                    xj_kcl = decimal.Parse(tbfl.Rows[i]["借药数量"].ToString()) - decimal.Parse(tbfl.Rows[i]["还药数量"].ToString());
                    //插入Zy_zcySjjl上缴记录
                    string sql = string.Format(@"insert into  dbo.Zy_zcySjjl (
                                                         sjid, sjrq, sjr, kssj, jssj, lyks, wldw, cjid, dwbl, zxdw, lsj, zsl, je, jysl, hysl, zcsjsl, sjpc,jlzt)
                                                          values
                                                        ('{0}',GETDATE(),{1},'{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},'{15}',{16})"
                        , sjid, FrmMdiMain.CurrentUser.EmployeeId, date1, date2, deptly,
                        int.Parse(tbfl.Rows[i]["wldw"].ToString()), int.Parse(tbfl.Rows[i]["cjid"].ToString()),
                        int.Parse(tbfl.Rows[i]["dwbl"].ToString()),
                        int.Parse(tbfl.Rows[i]["zxdw"].ToString()),
                        decimal.Parse(tbfl.Rows[i]["单价"].ToString()), zsl, zsl * decimal.Parse(tbfl.Rows[i]["单价"].ToString()),
                        decimal.Parse(tbfl.Rows[i]["借药数量"].ToString()), decimal.Parse(tbfl.Rows[i]["还药数量"].ToString()),
                        decimal.Parse(tbfl.Rows[i]["暂存上缴数量"].ToString()), sjpc, 0
                        );
                    InstanceForm.BDatabase.DoCommand(sql);
                    //更新zy_zcydjxx表
                    DataRow[] rowupdate = tb.Select(" cjid=" + tbfl.Rows[i]["cjid"].ToString() + " and wldw=" + tbfl.Rows[i]["wldw"].ToString()
                        + "  and ywlx=" + tbfl.Rows[i]["ywlx"].ToString() + " and deptly=" + tbfl.Rows[i]["deptly"].ToString()
                        + " and 单价=" + tbfl.Rows[i]["单价"].ToString() + "  and zxdw=" + tbfl.Rows[i]["zxdw"].ToString() +
                        " and dwbl=" + tbfl.Rows[i]["dwbl"].ToString());
                    string updatesql = " id in (";
                    for (int j = 0; j < rowupdate.Length; j++)
                    {
                        updatesql += " '" + rowupdate[j]["id"] + "',";
                    }
                    if (updatesql != " id in (")
                    {
                        updatesql = updatesql.Substring(0, updatesql.Length - 1) + ")";
                        updatesql = "update zy_zcydjxx set sjid='" + sjid + "' where " + updatesql;
                        InstanceForm.BDatabase.DoCommand(updatesql);
                    }
                    //更新库存
                    updatesql = @"update Zy_ZcyKcmx  set kcl=a.kcl+(" + xj_kcl + ")*a.dwbl/" + tbfl.Rows[i]["dwbl"].ToString() +
                               ", zcjs=zcjs-(" + xj_kcl + ")*a.dwbl/" + tbfl.Rows[i]["dwbl"].ToString() +
                               "  from Zy_ZcyKcmx a "
                               + " where  cjid='" + tbfl.Rows[i]["cjid"].ToString() + "' and ksid=" + tbfl.Rows[i]["deptly"].ToString()
                    + "  and yfksid=" + tbfl.Rows[i]["wldw"].ToString();
                    InstanceForm.BDatabase.DoCommand(updatesql);
                }
                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show(" 操作成功！");
                button1_Click(null, null);
            }
            catch (Exception ex)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(ex.Message);
            }
        }
    }
}