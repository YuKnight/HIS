using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace ts_zyhs_yzgl
{
    public partial class UCWzxm : UserControl
    {
        public UCWzxm()
        {
            InitializeComponent();
        }

        private string _itemidsf;

        public string Itemidsf
        {
            get { return _itemidsf; }
            set { _itemidsf = value; }
        }

        private Guid _BinID;

        public Guid BinID
        {
            get { return _BinID; }
            set { _BinID = value; }
        }

        private long _BabyID;

        public long BabyID
        {
            get { return _BabyID; }
            set { _BabyID = value; }
        }

        private bool _rbIn;

        public bool RbIn
        {
            get { return _rbIn; }
            set { _rbIn = value; }
        }
        private int _yztype;

        public int Yztype
        {
            get { return _yztype; }
            set { _yztype = value; }
        }

        private bool _isSSMZ;

        public bool IsSSMZ
        {
            get { return _isSSMZ; }
            set { _isSSMZ = value; }
        }

        private bool _rbTszl;

        public bool RbTszl
        {
            get { return _rbTszl; }
            set { _rbTszl = value; }
        }

        private DataTable myTb;

        public DataTable MyTb
        {
            get { return myTb; }
            set { myTb = value; }
        }

        private int nrow;

        public int Nrow
        {
            get { return nrow; }
            set { nrow = value; }
        }

        private string first_times;

        public string First_times
        {
            get { return first_times; }
            set { first_times = value; }
        }

        private int dept_id;

        public int Dept_id
        {
            get { return dept_id; }
            set { dept_id = value; }
        }

        private string order_id;
        public string Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }

        private int _fjfy_yzid;
        /// <summary>
        /// 附加费用医嘱id
        /// </summary>
        public int Fjfy_yzid
        {
            get { return _fjfy_yzid; }
            set { _fjfy_yzid = value; }
        }


        public void BingData()
        {
//            string sql = @" select  '0' as SELECTED,t4.HOITEM_ID as ORDER_ID,
//             (select ORDER_NAME from JC_HOITEMDICTION where ORDER_ID=t4.HOITEM_ID) as ITEM_NAME,v.ITEM_UNIT,v.NUM,v.COST_PRICE,v.PY_CODE,v.WB_CODE,v.BZ
//              from(
//             select t3.*,t1.NUM,t.BZ
//           from JC_HOITEMDICTION t inner join
//          JC_HOI_HDI t1 on t.ORDER_ID=t1.HOITEM_ID
//          inner join jc_sf_wz t2 on t1.HDITEM_ID=t2.item_id_sf
//          inner join JC_HSITEM t3 on t2.item_id_wz=t3.ITEM_ID
//          where t.ORDER_ID='{1}'
//          and t.DELETE_BIT=0 and t2.deleted=0 and t3.DELETE_BIT=0
//          )v left join JC_HOI_HDI t4 on v.ITEM_ID=t4.HDITEM_ID where (('{0}'='' and 1=1) or v.ITEM_NAME LIKE '%{0}%' or v.PY_CODE LIKE '%{0}%' or v.WB_CODE LIKE '%{0}%')";

            string sql = @"select '0' as SELECTED,d.ORDER_ID,b.ITEM_NAME,b.ITEM_UNIT,c.NUM,b.RETAIL_PRICE COST_PRICE,b.PY_CODE,b.WB_CODE,
                    d.BZ from jc_sf_wz a inner join JC_HSITEM b on a.item_id_wz=b.ITEM_ID
                    inner join JC_HOI_HDI c on c.HDITEM_ID=b.ITEM_ID
                    inner join JC_HOITEMDICTION d on c.HOITEM_ID=d.ORDER_ID
                    where a.sf_orderid in ('{1}','{2}') and
                    a.deleted=0 and d.DELETE_BIT=0 and b.DELETE_BIT=0 
                    and(('{0}'='' and 1=1) or b.ITEM_NAME LIKE '%{0}%' or b.PY_CODE LIKE '%{0}%' or b.WB_CODE LIKE '%{0}%')";
            this.dataGridView1.DataSource = InstanceForm.BDatabase.GetDataTable(string.Format(sql, this.textBox1.Text.Trim().Replace(",", ""), _itemidsf,this.Fjfy_yzid));
        }
        private void buttQD_Click(object sender, EventArgs e)
        {
            //DataTable pattb = (DataTable)this.myDataGrid2.DataSource;

            //#region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
            string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(_BinID);
            if (rtnSql[0] != "0")
            {
                MessageBox.Show("由于跨院转科或者特殊治疗，该病人记录已经冻结不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int BrJgbm = Convert.ToInt32(rtnSql[1]);

            //#endregion
            if (_rbIn)
            {
                #region//Add by yaokx 2013-12-05 判断病人是不是当前科室，主要是为了阻止临时跨科室业务的病人操作
                string sql_dept = "select * from VI_ZY_VINPATIENT_INFO where inpatient_id ='" + _BinID + "'  and baby_id=" + _BabyID;
                DataTable table_dept = FrmMdiMain.Database.GetDataTable(sql_dept);
                if (table_dept.Rows.Count > 0)
                {
                    string flag = table_dept.Rows[0]["FLAG"].ToString();
                    string sql = "  select * from JC_WARDRDEPT where dept_id=" + InstanceForm.BCurrentDept.DeptId.ToString() + "";
                    DataTable tbtemp = InstanceForm.BDatabase.GetDataTable(sql);
                    if (tbtemp.Rows.Count <= 0)
                    {
                        MessageBox.Show("该病人已转科不属于本科室，不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (flag.Equals("2") || flag.Equals("5") || flag.Equals("6"))
                    {
                        MessageBox.Show("该病人已经出区，不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                #endregion
            }
            int i, serial_no = 0, iYZH = 0;
            int yztype = _yztype;//(this.tabControl1.SelectedTab.Text.Trim() == sTab0 ? 2 : 3);
            string sSql = "";
            DataTable myTbwz = (DataTable)this.dataGridView1.DataSource;

            //Modify by zouchihfua 2011-10-31 
            Guid tsapply_id = Guid.Empty;
            int Apply_type = 0;//0=正常  包括 1=特殊治疗，2=手术申请，3=转科 4=会诊 ;
            //1 特殊治疗
            if (_rbTszl)
            {
                //获得特殊治疗id
                string ssql = "select id from ZY_TS_APPLY where TS_DEPT =" + FrmMdiMain.CurrentDept.DeptId.ToString() + " and inpatient_id='" + ClassStatic.Current_BinID + "' and STATUS_FLAG !=2 and DELETE_BIT=0";
                DataTable Tstable = FrmMdiMain.Database.GetDataTable(ssql);
                if (Tstable.Rows.Count > 0)
                {
                    tsapply_id = new Guid(Tstable.Rows[0]["id"].ToString());
                    Apply_type = 1;
                }
            }


            //3 转科
            if (Apply_type == 0)
            {
                string zk = "select id from ZY_TRANSFER_DEPT where INPATIENT_ID='" + _BinID + "' and  CANCEL_BIT=0 and FINISH_BIT=1 order by TRANSFER_DATE desc";//最近一次转科
                DataTable temptb = FrmMdiMain.Database.GetDataTable(zk);
                if (temptb.Rows.Count > 0)
                {
                    tsapply_id = new Guid(temptb.Rows[0]["id"].ToString());
                    Apply_type = 3;
                }
            }
            if (_isSSMZ)
            {
                //获得特殊治疗id
                string ssql = "select a.id from  ss_apprecord a inner join ss_arrrecord b on a.sno=b.sno and b.wcbj=0 and a.bdelete=0 where  a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.BDELETE=0 and b.BDELETE=0 and a.apbj=1";
                DataTable Tstable = FrmMdiMain.Database.GetDataTable(ssql);
                if (Tstable.Rows.Count > 0)
                {
                    tsapply_id = new Guid(Tstable.Rows[0]["id"].ToString());
                    Apply_type = 2;
                }
            }

            //初始化医嘱
            sSql = @"select max(Group_Id) as YZH " +
                "  from Zy_OrderRecord " +
                " where inpatient_id='" + _BinID + "'" +
                "       and baby_id=" + _BabyID;//+
            //				"       and mngtype=" + yztype.ToString();
            DataTable myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
            if (myTempTb.Rows[0]["YZH"].ToString().Trim() == "")
            {
                iYZH = 0;
            }
            else
            {
                iYZH = Convert.ToInt32(myTempTb.Rows[0]["YZH"]);
            }

            //			//生成数据访问对象
            //			RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
            //			database.Initialize("");
            //			database.Open();
            //			//开始一个事物
            //			database.BeginTransaction();

            //是否开单科室领药，包含冲账权限
            int _iskdksly = 0;
            if (_rbTszl)
            {
                _iskdksly = Convert.ToInt32(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select iskdksly from jc_dept_tszl where deptid=" + myTb.Rows[nrow]["dept_id"]), "0"));
            }
            InstanceForm.BDatabase.BeginTransaction();

            try
            {
                #region 循环保存数据
                for (i = 0; i <= myTbwz.Rows.Count - 1; i++)
                {
                    if (myTbwz.Rows[i]["SELECTED"].ToString().Trim() == "1")
                    {
                        //首次
                        int j = 1;
                        if (first_times != ""&&first_times.Trim()!="0")
                        {
                            j = Convert.ToInt32(first_times);
                        }
                        if (myTbwz.Rows[i]["ORDER_ID"] == null || myTbwz.Rows[i]["ORDER_ID"].ToString() == "")
                        {
                            InstanceForm.BDatabase.RollbackTransaction();
                            MessageBox.Show(this, "保存数据失败！找不到收费项目医嘱id", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string hoitemid = myTbwz.Rows[i]["ORDER_ID"].ToString();
                        //取医嘱号
                        //if ((i == 0) || (i > 0 && myTb.Rows[nrow]["group_id"].ToString() != myTb.Rows[nrow - 1]["group_id"].ToString()))
                        //{
                        iYZH += 1;
                        serial_no = 0;
                        //}
                        //else serial_no += 1;

                        decimal v_price = Convert.ToDecimal(myTbwz.Rows[i]["COST_PRICE"].ToString().Trim());
                        //构成SQL语句,并执行
                        //Modify By Tany 2004-10-23 加入price 主要针对单价为0的项目
                        sSql = @"INSERT INTO ZY_ORDERRECORD( " +
                            "ORDER_ID,INPATIENT_ID,Baby_ID,WARD_ID,DEPT_BR,DEPT_ID, " +
                            "MNGTYPE,ORDER_BDATE,GROUP_ID,NTYPE, " +
                            "HOITEM_ID,XMLY,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_USAGE,FREQUENCY, " +
                            "EXEC_DEPT,FIRST_TIMES,STATUS_FLAG, " +
                            "AUDITING_USER,AUDITING_DATE,OPERATOR,BOOK_DATE,SERIAL_NO,jgbm,iskdksly,tsapply_id,Apply_type,MEMO2,ppcl_yzid) " +
                            "VALUES('" + PubStaticFun.NewGuid() + "' ,'" +
                            _BinID + "'," + _BabyID + ",'" + new Department(ClassStatic.Current_DeptID, InstanceForm.BDatabase).WardId + "'," + ClassStatic.Current_DeptID + "," + dept_id + "," +
                            _yztype + ",'" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "'," + iYZH.ToString() + ","
                            + myTb.Rows[nrow]["ntype"].ToString() + "," +
                            hoitemid + ",2,'"
                            + myTbwz.Rows[i]["ITEM_NAME"] + "',"
                             + myTbwz.Rows[i]["NUM"] + ","
                            + myTb.Rows[nrow]["DOSAGE"] + ",'"
                            + myTbwz.Rows[i]["ITEM_UNIT"] + "','"
                            + myTb.Rows[nrow]["ORDER_USAGE"] + "','"
                            + myTb.Rows[nrow]["FREQUENCY"] + "'," +
                            myTb.Rows[nrow]["Exec_Dept"] + "," + myTbwz.Rows[i]["NUM"] + ",2," +
                            InstanceForm.BCurrentUser.EmployeeId + ",getdate() ," + InstanceForm.BCurrentUser.EmployeeId + ",getdate()," + serial_no.ToString() +
                            "," + BrJgbm + "," + _iskdksly + ",'" + tsapply_id + "'," + Apply_type + ",'物资匹配'"
                            //+
                            // myTbwz.Rows[i]["NUM"].ToString()//增加首次
                            +",'"+this.Order_id
                            +"')";

                        InstanceForm.BDatabase.DoCommand(sSql);
                    }
                }
                #endregion

                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show(this, "保存数据成功", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BingData();
            }
            catch (System.Data.OleDb.OleDbException err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(this, "保存数据失败！（" + err.ToString() + "）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(this, "保存数据失败！（" + err.ToString() + "）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UCWzxm_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmWzxm frm = new FrmWzxm();
            frm.Order_id = this.Order_id;//add by zouchihua 2014-8-25 增加医嘱id ,可以关联到是哪条医嘱id产生的匹配材料
            frm.Fjfy_yzid = this.Fjfy_yzid;//add by zouchihua 2014-8-25 增加附加费用关联的医嘱项目，附加费用也可以用配套材料
            frm.Itemidsf =_itemidsf;
            frm.BinID =_BinID;
            frm.BabyID = _BabyID;
            frm.RbIn = _rbIn;
            frm.Yztype = _yztype;
            frm.IsSSMZ = _isSSMZ;
            frm.RbTszl = _rbTszl;
            frm.MyTb = myTb;
            frm.Nrow = nrow;
            frm.First_times = first_times;
            frm.Dept_id =dept_id;
            frm.ShowDialog();
        }
        public void isHide(int count)
        {
            if (count > 0)
            {
                this.button1.Visible = true;
                this.buttQD.Visible = true;
            }
            else
            {
                this.button1.Visible = false;
                this.buttQD.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BingData();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //判断是否可以编辑  
            if (dgv.Columns[e.ColumnIndex].Name == "COST_PRICE" &&
                (decimal)dgv["COST_PRICE", e.RowIndex].Value > 0)
            {
                //编辑不能  
                e.Cancel = true;
            }
        }
    }
}
