using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using ts_zyhs_classes;

namespace ts_zyhs_yzgl
{
    public partial class FrmPvsCancelScn : Form
    {
        private BaseFunc myFunc;
        public FrmPvsCancelScn()
        {
            InitializeComponent();
            myFunc = new BaseFunc();
        }

        private void FrmPvsCancelScn_Load(object sender, EventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();

            this.myDataGrid1.Enabled = true;

            this.ShowData();

            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName ={"选", "医嘱日期","频次","内容","规格","数量","单位","次数","剂数","单价","金额",
										 "发送信息","执行科室","记账信息","发药信息","记账类型","charge_bit", "finish_bit","delete_bit",
                                         "Order_ID","ID","EXECDEPT_ID","dept_br","dept_id","item_code","day1","day2","发送护士","记账员",
                                         "基数药","isJZ","jz_flag","DISCHARGE_BIT","名称","iskdksly","xmly",//36
                                         "发药单号",
                    "药品批次","药品批号",
                    "发药时间","发药人","领药科室","领药类型","操作人","操作时间","type","statitem_code","转打包"};//名称是给汇总用的//Add By Tany 2010-12-15 增加statitem_code
            int[] GrdWidth ={ 2, 10, 4, 24, 10, 6, 6, 4, 4, 8, 8, 12, 10, 12, 12, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8,
                    8,8
                    ,15, 8, 10, 8, 8, 15, 0, 0, 6 };
            int[] Alignment ={ 0, 0, 0, 0, 0, 2, 1, 2, 2, 2, 2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2,
                    2,2
                    ,0, 2, 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            this.InitGridYZ(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);
            PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);//去掉网格

            Cursor.Current = Cursors.Default;
        }

        private void ShowData()
        {
            Cursor.Current = PubStaticFun.WaitCursor();

            DataTable myTb = DoGetScanBit(txtZyh.Text.Trim(), 0, FrmMdiMain.CurrentDept.DeptId, dtpStr.Value, dtpEnd.Value);

            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Boolean");
            col.AllowDBNull = false;
            col.ColumnName = "选";

            col.DefaultValue = false;
            myTb.Columns.Add(col);

            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.TableStyles[0].RowHeaderWidth = 5;

            if (myTb.Rows.Count != 0)
            {
                for (int i = myTb.Rows.Count - 1; i >= 0; i--)
                {
                    myTb.Rows[i]["数量"] = string.Format("{0:F2}", myTb.Rows[i]["数量"]);
                    if (myTb.Rows[i]["发送信息"].ToString().Trim() != "")
                    {
                        myTb.Rows[i]["发送信息"] = myTb.Rows[i]["发送信息"].ToString().Trim() + "-" + myTb.Rows[i]["day1"].ToString().Trim() + " " + myTb.Rows[i]["发送护士"].ToString().Trim();
                    }
                    if (myTb.Rows[i]["记账信息"].ToString().Trim() != "")
                    {
                        myTb.Rows[i]["记账信息"] = myTb.Rows[i]["记账信息"].ToString().Trim() + "-" + myTb.Rows[i]["day2"].ToString().Trim() + " " + myTb.Rows[i]["记账员"].ToString().Trim();
                    }
                    if (myTb.Rows[i]["发药信息"].ToString().Trim() != "")
                    {
                        myTb.Rows[i]["发药信息"] = myTb.Rows[i]["发药信息"].ToString().Trim() + "-" + myTb.Rows[i]["day3"].ToString().Trim() + " " + myTb.Rows[i]["发药员"].ToString().Trim();
                    }
                }
            }

            PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);

            Cursor.Current = Cursors.Default;
        }

        private DataTable DoGetScanBit(string inpatNo, long _baby_id, long WardDeptId, DateTime strDate, DateTime endDate)
        {
            DataTable rtnTb = new DataTable();
            string sSql = "";
            ParameterEx[] parameters = new ParameterEx[5];

            try
            {
                sSql = "SP_ZYHS_Pivas_SELECTFEE";

                parameters[0].Value = inpatNo;
                parameters[0].Text = "@BINID";
                parameters[1].Value = _baby_id;
                parameters[1].Text = "@BABYID";
                parameters[2].Value = WardDeptId;
                parameters[2].Text = "@WARDDEPTID";

                parameters[3].Value = strDate;
                parameters[3].Text = "@strDate";
                parameters[4].Value = endDate;
                parameters[4].Text = "@endDate";


                rtnTb = FrmMdiMain.Database.GetDataTable(sSql, parameters, 60);

                return rtnTb;
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "SP_ZYHS_Pivas_SELECTFEE错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return rtnTb;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnCancelScan_Click(object sender, EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            if (MessageBox.Show(this, "确认选择的每组药单取消进仓吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            

            try
            {
                FrmMdiMain.Database.BeginTransaction();
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["选"].ToString() == "True")
                    {
                        string sql = string.Format(@"update ZY_FEE_SPECI set is_PvsScn=0 where ID='{0}' ", myTb.Rows[i]["ID"].ToString());
                        int iRet = FrmMdiMain.Database.DoCommand(sql);

                        if (iRet <= 0)
                        {
                            throw new Exception("未取消扫描标志，更新" + myTb.Rows[i]["医嘱日期"].ToString().Trim() + "：" + myTb.Rows[i]["内容"].ToString().Trim() + " 频次：" + myTb.Rows[i]["频次"].ToString().Trim() + " 时出错！");
                        }
                    }
                }
                FrmMdiMain.Database.CommitTransaction();

                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
            }
            catch (Exception ex)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show("提示", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void myDataGrid1_Click(object sender, EventArgs e)
        {
            //控制BOOL列
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0 && nrow > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            //非"选"字段
            //			if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim()!="选") return;
            if (nrow > myTb.Rows.Count - 1) return;

            bool isResult = myTb.Rows[nrow]["选"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["选"] = isResult;

            //Modify by jchl Pivas冲正改造（每条医嘱当做每组医嘱   每组医嘱加入pivas序号判断）
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["医嘱日期"].ToString().Trim() == myTb.Rows[nrow]["医嘱日期"].ToString().Trim()
                    && myTb.Rows[i]["记账类型"].ToString().Trim() == myTb.Rows[nrow]["记账类型"].ToString().Trim()
                    && myTb.Rows[i]["频次"].ToString().Trim() == myTb.Rows[nrow]["频次"].ToString().Trim()
                    && myTb.Rows[i]["GROUP_NO"].ToString().Trim() == myTb.Rows[nrow]["GROUP_NO"].ToString().Trim())
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                    myTb.Rows[i]["选"] = isResult;
                }
            }

            this.myDataGrid1.DataSource = myTb;
        }

        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            //myDataGrid.TableStyles[0].AllowSorting=false; //不允许排序

            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "选")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
                    //myBoolCol.tool
                    //this.toolTip2
                    //myBoolCol.too
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            //用色彩区分医嘱的状态 
            int ChargeCol = 16;	 //charge_bit列

            //删除标志
            if (Convert.ToInt16(this.myDataGrid1[e.Row, ChargeCol + 2]) == 1)
            {
                e.ForeColor = Color.Gray;  //灰色
                e.BackColor = Color.White;
                return;
            }

            int iCZ = this.myDataGrid1[e.Row, ChargeCol - 1].ToString().Trim() == "冲帐费用" ? 1 : 0; //1代表冲账
            int iCharge = Convert.ToInt16(this.myDataGrid1[e.Row, ChargeCol]);			//1代表已记账
            int iFinish = Convert.ToInt16(this.myDataGrid1[e.Row, ChargeCol + 1]) == 1 ? 1 : 0;	//1代表已完成（已发药） (2是非基数药冲正时还没产生药品消息的中间过度标志)
            int iDisCharge = Convert.ToInt16(this.myDataGrid1[e.Row, 31]);			//1代表已结算


            if (iCharge == 0 && iFinish == 0 && iCZ == 0) e.ForeColor = Color.Black;		//未记账  未完成  未冲账  黑
            if (iCharge == 0 && iFinish == 0 && iCZ == 1) e.ForeColor = Color.DarkRed;	//未记账  未完成    冲账  黑红			}
            if (iCharge == 1 && iFinish == 0 && iCZ == 0) e.ForeColor = Color.RoyalBlue;  //已记账  未完成  未冲账  浅蓝
            if (iCharge == 1 && iFinish == 0 && iCZ == 1) e.ForeColor = Color.LightCoral; //已记账  未完成    冲账  浅红
            if (iCharge == 1 && iFinish == 1 && iCZ == 0) e.ForeColor = Color.Blue;		//已记账  已完成  未冲账  蓝
            if (iCharge == 1 && iFinish == 1 && iCZ == 1) e.ForeColor = Color.Red;		//已记账  已完成    冲账  红

            if (iDisCharge == 1) e.ForeColor = Color.Green; //已经结算

            if (this.myDataGrid1[e.Row, 0].ToString() == "True")
                e.BackColor = Color.GreenYellow;
            else
                e.BackColor = Color.White;
        }
    }
}