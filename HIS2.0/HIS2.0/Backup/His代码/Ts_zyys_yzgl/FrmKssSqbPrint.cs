using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;

namespace Ts_zyys_yzgl
{
    public partial class FrmKssSqbPrint : Form
    {
        public FrmKssSqbPrint()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            dtpStrDate.Enabled = false;
            dtpEndDate.Enabled = false;

            txtDept.Enabled = false;
            txtZyh.Enabled = false;

            chkDate.CheckedChanged += new EventHandler(delegate(object s, EventArgs e)
            {
                dtpStrDate.Enabled = chkDate.Checked;
                dtpEndDate.Enabled = chkDate.Checked;
            });

            chkZyh.CheckedChanged += new EventHandler(delegate(object s, EventArgs e)
            {
                if (chkZyh.Checked)
                {
                    txtZyh.Focus();
                }
                else
                {
                    txtZyh.Text = "";
                }
                txtZyh.Enabled = chkZyh.Checked;
            });

            chkDept.CheckedChanged += new EventHandler(delegate(object s, EventArgs e)
            {
                if (chkZyh.Checked)
                {
                    txtDept.Focus();
                }
                else
                {
                    txtDept.Text = "";
                    txtDept.Tag = "";
                }
                txtDept.Enabled = chkDept.Checked;
            });

            btnQuery.Click += new EventHandler(delegate(object s, EventArgs e)
            {
                DoQuery();
            });

            dataGrid_LongOrder.DoubleClick += new EventHandler(dataGrid_LongOrder_DoubleClick);

            dataGrid_LongOrder.Click += new EventHandler(delegate(object s, EventArgs e)
            {
                for(int i=0;i< (dataGrid_LongOrder.DataSource as DataTable).Rows.Count;i++)
                {
                    dataGrid_LongOrder.UnSelect(i);
                }
                if (dataGrid_LongOrder.CurrentRowIndex != -1)
                {
                    dataGrid_LongOrder.Select(dataGrid_LongOrder.CurrentRowIndex);
                }
            });
        }

        private void FrmKssSqbPrint_Load(object sender, EventArgs e)
        {
            try
            {
                InitGrd_LongOrder();
                DoQuery();
            }
            catch { }
        }

        private void DoQuery()
        {
            try
            {
                string strSql = string.Format(@"select t2.NAME,t2.INPATIENT_NO,t5.NAME as DEPT_NAME,t3.BED_NO,t4.ORDER_CONTEXT as 医嘱内容,t4.NUM as 剂量,t4.UNIT as 单位,t4.ORDER_USAGE as 用法,t4.FREQUENCY as 频率,t4.HOITEM_ID,DJID,t1.INPATIENT_ID,t1.baby_id,t1.order_id as ID,t1.group_id,t1.dept_id,t1.zyzd,shyj,apply_id,apply_time,shr,shsj,purp_1,purp_1_memo,purp_2,purp_3,purp_3_memo,purp_4,purp_5_memo,3 as MEMO 
	from zy_kss_sqb t1,ZY_INPATIENT t2,ZY_BEDDICTION t3,ZY_ORDERRECORD t4,JC_DEPT_PROPERTY t5 where t1.INPATIENT_ID=t2.INPATIENT_ID and t3.BED_ID=t2.BED_ID  and t1.order_id=t4.ORDER_ID and t1.dept_id=t5.DEPT_ID and t1.DEL_BIT=0 and {0}='{1}' and {2}>='{3}' and {4}<='{5}' and {6}='{7}'",
                                                chkZyh.Checked ? "t2.INPATIENT_NO" : "'1'", chkZyh.Checked ? txtZyh.Text : "1",
                                                chkDate.Checked ? "t1.apply_time" : "'1'", chkDate.Checked ? dtpStrDate.Value.ToString("yyyy-MM-dd") : "1",
                                                chkDate.Checked ? "t1.apply_time" : "'1'", chkDate.Checked ? dtpEndDate.Value.ToString("yyyy-MM-dd") : "1",
                                                chkDept.Checked ? "t1.dept_id" : "'1'", chkDept.Checked ? txtDept.Text : "1"
                                                );

                DataTable dt = InstanceForm._database.GetDataTable(strSql);

                dataGrid_LongOrder.DataSource = dt;
            }
            catch { }
        }

        private void InitGrd_LongOrder()
        {
            dataGrid_LongOrder.ReadOnly = true;
            //{ "ID", "类", "嘱号", "开始时间", "类型", "警示灯", "医嘱内容", "规格", "剂量", "单位", "用法", "频率", "首日执行次数", "末日次数", "剂数", "滴量", "执行护士", "执行时间", "停嘱时间", "下嘱医生", "停嘱医生", "执行科室", "不打印", "打印规格" };
            string[] GrdMapppingName = { "NAME", "INPATIENT_NO", "DEPT_NAME", "BED_NO", "医嘱内容", "剂量", "单位", "用法", "频率", "HOITEM_ID", "DJID", "INPATIENT_ID", "baby_id", "ID", "group_id", "dept_id", "zyzd", "shyj", "apply_id", "apply_time", "shr", "shsj", "purp_1", "purp_1_memo", "purp_2", "purp_3", "purp_3_memo", "purp_4", "purp_5_memo", "MEMO" };
            string[] GrdHeaderText =   { "姓名", "住院号", "科室", "床位", "医嘱内容", "剂量", "单位", "用法", "频率", "HOITEM_ID", "DJID", "INPATIENT_ID", "baby_id", "order_id", "嘱号", "dept_id", "主要诊断", "审核意见", "申请人", "申请时间", "审核人", "审核时间", "purp_1", "purp_1_memo", "purp_2", "purp_3", "purp_3_memo", "purp_4", "purp_5_memo", "MEMO" };
            int[] GrdWidth = { 60, 100, 80, 40, 150, 40, 40, 60, 40, 0, 0, 0, 0, 0, 60, 0, 180, 180, 35, 100, 55, 100, 0, 0, 0, 0, 0, 0, 0, 0 };
            InitmyGrd(GrdMapppingName, GrdHeaderText, GrdWidth, dataGrid_LongOrder);
        }

        /// <summary>
        /// 初始化dataGrid
        /// </summary>
        /// <param name="GrdMappingName"></param> MappingName数组
        /// <param name="GrdHeaderText"></param>  GrdHeaderText数组
        /// <param name="GrdWidth"></param>       Width数组
        /// <param name="GrdReadOnly"></param>    ReadOnly数组
        /// <param name="mydataGrid"></param>
        public void InitmyGrd(string[] GrdMappingName, string[] GrdHeaderText, int[] GrdWidth, DataGrid dataGrid)
        {
            int i = 0;
            DataTable myTb = new DataTable();

            for (i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                myTb.Columns.Add(GrdMappingName[i].ToString().ToUpper());
            }
            myTb.Rows.Add(myTb.NewRow());
            dataGrid.DataSource = myTb;

            if (dataGrid.TableStyles.Count > 0)
            {
                dataGrid.TableStyles[0].RowHeaderWidth = 5;
                for (i = 0; i <= dataGrid.TableStyles[0].GridColumnStyles.Count - 1; i++)
                {
                    dataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
                    dataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString().ToUpper();
                    dataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
                    if (GrdWidth[i] != 0) dataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdHeaderText[i].ToString().ToUpper();
                    dataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;// GrdReadOnly[i];
                }
            }
        }

        void dataGrid_LongOrder_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dataGrid_LongOrder.DataSource as DataTable;
                DataRow dr = dt.Rows[dataGrid_LongOrder.CurrentRowIndex];
                Guid BidID = new Guid(dr["INPATIENT_ID"].ToString());
                long babyID = long.Parse(dr["baby_id".ToUpper()].ToString());
                string grpID = dr["group_id".ToUpper()].ToString();

                DataTable dtKss = dt.Clone();
                dtKss.Rows.Add(dr.ItemArray);
                病人信息.PatientInfo patientInfo1 = new 病人信息.PatientInfo();
                patientInfo1.SetInpatientInfo(BidID, babyID, 0);

                FrmKssSpecialApply frmKss = new FrmKssSpecialApply();
                //如果仍然有未登记的医嘱组，继续弹框
                if (dtKss.Rows.Count > 0)
                {
                    frmKss = new FrmKssSpecialApply(dtKss, patientInfo1, babyID, BidID, grpID, true);
                    frmKss.StartPosition = FormStartPosition.CenterScreen;
                    //frmKss.WindowState = FormWindowState.Maximized;
                    frmKss.btnSave.Enabled = false;
                    frmKss.ShowInTaskbar = false;
                    frmKss.ShowDialog();
                }
            }
            catch { }
        }

        private void txtDept_TextChanged(object sender, EventArgs e)
        {
            if (txtDept.Text.Trim() != string.Empty)
            {
                try
                {
                    string ssql = @"select a.NAME as name,a.PY_CODE pym,a.WB_CODE wbm  from JC_DEPT_PROPERTY a 
                                left join JC_DEPT_PROPERTY parentKs on a.P_DEPT_ID = parentKs.DEPT_ID ";
                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "name", "pym", "wbm" },
                                                                                       new string[] { "科室名称", "拼音码", "五笔码" },
                                                                                       new string[] { "name", "pym", "wbm" },
                                                                                       new int[] { 150, 80, 80 });
                    DataTable datalist = InstanceForm._database.GetDataTable(ssql);                   
                    frmSelectCard.sourceDataTable = datalist;
                    frmSelectCard.srcControl = txtDept;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.Text = txtDept.Text.Trim();                    
                    //frmSelectCard.ReciveString = cmbbs1.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        txtDept.Text += string.IsNullOrEmpty(txtDept.Text.Trim()) ? (frmSelectCard.SelectDataRow["name"].ToString() + ";") : (";" + frmSelectCard.SelectDataRow["name"].ToString() + ";");
                    }
                }
                catch { }
            }
        }
    }
}