using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using Ts_zyys_public;
using grproLib;

namespace Ts_zyys_yzgl
{
    public partial class FrmKssSpecialApply : Form
    {
        private DataTable _dtKss;
        private 病人信息.PatientInfo _patientInfo;
        public bool _isOk = false;

        private bool _isPrint = false;
        long _babyID = -1;
        Guid _binID = Guid.Empty;
        string _grpID = "";

        public Dictionary<string, Entity_KjSq> myEntity;//key：yzid  value:申请表明细实体

        public FrmKssSpecialApply()
        {
            InitializeComponent();

            myEntity = new Dictionary<string, Entity_KjSq>();

            btnClose.Click += new EventHandler(delegate(object s, EventArgs e)
            {
                this.Close();
            });

            button1.Click += new EventHandler(delegate(object s, EventArgs e)
            {
                DoSetGridProp(true);
            });

            button2.Click += new EventHandler(delegate(object s, EventArgs e)
            {
                DoSetGridProp(false);
            });

            btnPrint.Click += new EventHandler(btnPrint_Click);
        }

        public FrmKssSpecialApply(DataTable dtKss, 病人信息.PatientInfo patientInfo)
        {
            InitializeComponent();

            _dtKss = dtKss;
            _patientInfo = patientInfo;
            _isPrint = false;

            myEntity = new Dictionary<string, Entity_KjSq>();

            btnClose.Click += new EventHandler(delegate(object s, EventArgs e)
            {
                this.Close();
            });

            button1.Click += new EventHandler(delegate(object s, EventArgs e)
            {
                DoSetGridProp(true);
            });

            button2.Click += new EventHandler(delegate(object s, EventArgs e)
            {
                DoSetGridProp(false);
            });

            btnSave.Click += new EventHandler(btnSave_Click);

            btnPrint.Click += new EventHandler(btnPrint_Click);
        }

        public FrmKssSpecialApply(DataTable dtKss, 病人信息.PatientInfo patientInfo, long babyID, Guid binID, string grpID, bool isPrint)
        {
            InitializeComponent();

            _dtKss = dtKss;
            _patientInfo = patientInfo;
            _isPrint = isPrint;
            _babyID = babyID;
            _binID = binID;
            _grpID = grpID;

            myEntity = new Dictionary<string, Entity_KjSq>();

            btnClose.Click += new EventHandler(delegate(object s, EventArgs e)
            {
                this.Close();
            });

            button1.Click += new EventHandler(delegate(object s, EventArgs e)
            {
                DoSetGridProp(true);
            });

            button2.Click += new EventHandler(delegate(object s, EventArgs e)
            {
                DoSetGridProp(false);
            });

            btnSave.Click += new EventHandler(btnSave_Click);

            btnPrint.Click += new EventHandler(btnPrint_Click);
        }

        private void FrmKssSpecialApply_Load(object sender, EventArgs e)
        {
            //绑定主任医生
            try
            {
                string sql = string.Format(@"select distinct b.py_code 拼音码, b.name as 姓名, b.wb_code 五笔码,a.doc_id 数字码,b.employee_id 
                                              from jc_role_doctor a ,jc_employee_property b,jc_EMP_DEPT_ROLE c 
                                             where a.employee_id=b.employee_id and c.employee_id=b.employee_id 
                                                   and c.dept_id='{0}'
                                                   and b.delete_bit=0", InstanceForm._currentDept.DeptId);

                DataTable dt = InstanceForm._database.GetDataTable(sql);

                cmbDept.DataSource = dt;
                cmbDept.DisplayMember = "姓名";
                cmbDept.ValueMember = "employee_id";
                cmbDept.SelectedIndex = 0;
            }
            catch { }

            try
            {
                txtZyZd.ReadOnly = false;

                dataGrid_LongOrder.ReadOnly = true;
                //初始化申请用药目的控件
                ucApplyInfos1.DoIniCt(_dtKss);

                lblDept.Text = InstanceForm._currentDept.DeptName;

                txtXm.Text = _patientInfo.lbName.Text;
                txtZyh.Text = _patientInfo.lbID.Text;
                txtNn.Text = _patientInfo.lbAge.Text;
                txtXb.Text = _patientInfo.lbSex.Text;
                txtCh.Text = _patientInfo.lbBed.Text;
                txtZyZd.Text = _patientInfo.lbRYZD.Text;

                txtSqYs.Text = InstanceForm._currentUser.Name;

                //dataGridView1.DataSource = _dtKss;
                InitGrd_LongOrder();  //长期医嘱网格
                loadGrid_LongOrder();

            }
            catch { }

            try
            {
                //如果是打印界面
                if (_isPrint)
                {
                    myEntity.Clear();
                    foreach (DataRow dr in _dtKss.Rows)
                    {
                        //特殊级药物
                        if (!dr["MEMO"].ToString().Equals("3"))
                        {
                            continue;
                        }

                        string id = dr["ID"].ToString();
                        string grpId = "";// dr[""].ToString();
                        if (_dtKss.Columns.Contains("嘱号"))
                        {
                            grpId = dr["嘱号"].ToString();
                        }
                        else if (_dtKss.Columns.Contains("group_id".ToUpper()))
                        {
                            grpId = dr["group_id".ToUpper()].ToString();
                        }

                        //申请用药理由
                        UcApplyInfo ucSqly = ucApplyInfos1.myCts[id];

                        //查询初始化给控件赋值
                        ucSqly.rbtYfxyy.Checked = dr["purp_1".ToUpper()].ToString().Equals("1");
                        ucSqly.rbtZlxyy.Checked = dr["purp_1".ToUpper()].ToString().Equals("0");
                        ucSqly.txtYymdZl.Text = dr["purp_1_memo".ToUpper()].ToString();

                        ucSqly.rbtByjcYes.Checked = dr["purp_2".ToUpper()].ToString().Equals("1");
                        ucSqly.rbtByjcNo.Checked = dr["purp_2".ToUpper()].ToString().Equals("0");

                        ucSqly.rbtXjpyYes.Checked = dr["purp_3".ToUpper()].ToString().Equals("1");
                        ucSqly.rbtXjpyNo.Checked = dr["purp_3".ToUpper()].ToString().Equals("0");
                        ucSqly.txtByj.Text = dr["purp_3_memo".ToUpper()].ToString();

                        ucSqly.rbtYjmgYes.Checked = dr["purp_4".ToUpper()].ToString().Equals("1");
                        ucSqly.rbtYjmgNo.Checked = dr["purp_4".ToUpper()].ToString().Equals("0");

                        ucSqly.txtMemo.Text = dr["purp_5_memo".ToUpper()].ToString();

                        //打印界面初始化参数变量
                        Entity_KjSq entity = new Entity_KjSq();

                        entity.drYzInfo = dr;
                        entity.order_id = id;
                        entity.group_id = grpId;

                        //1、用药目的
                        entity.purp_1 = ucSqly.rbtYfxyy.Checked ? "1" : ucSqly.rbtZlxyy.Checked ? "0" : "";
                        entity.purp_1_memo = ucSqly.rbtZlxyy.Checked ? ucSqly.txtYymdZl.Text : "";

                        //2、是否已送病原学检查
                        entity.purp_2 = ucSqly.rbtByjcYes.Checked ? "1" : ucSqly.rbtByjcNo.Checked ? "0" : "";
                        entity.purp_2_memo = "";

                        //3、是否已有细菌培养及药敏结果
                        entity.purp_3 = ucSqly.rbtXjpyYes.Checked ? "1" : ucSqly.rbtXjpyNo.Checked ? "0" : "";
                        entity.purp_3_memo = ucSqly.rbtXjpyYes.Checked ? ucSqly.txtByj.Text : "";

                        //4、所申请药物是否对该病原菌敏感
                        entity.purp_4 = ucSqly.rbtYjmgYes.Checked ? "1" : ucSqly.rbtYjmgNo.Checked ? "0" : "";
                        entity.purp_4_memo = "";

                        //5、其他
                        entity.purp_5_memo = ucSqly.txtMemo.Text;

                        myEntity.Add(dr["ID"].ToString(), entity);
                    }
                }
            }
            catch { }
        }

        private void InitGrd_LongOrder()
        {
            int jsdwide = 0;
            int dywide = 0;
            int dyggwide = 0;
            bool redonlydt = true;

            string[] GrdMapppingName = { "ID", "类", "嘱号", "开始时间", "类型", "警示灯", "医嘱内容", "规格", "剂量", "单位", "用法", "频率", "首日执行次数", "末日次数", "剂数", "滴量", "执行护士", "执行时间", "停嘱时间", "下嘱医生", "停嘱医生", "执行科室", "不打印", "打印规格" };
            string[] GrdHeaderText =   { "ID*", "类*", "嘱号*", "录入时间", "类型*", "警示灯", "医嘱内容", "规格", "剂量", "单位*", "用法", "频率", "首次", "末次", "剂数", "滴量", "执行人", "执行时间*", "停嘱时间*", "下嘱医生", "停嘱医生", "执行科室*", "打印", "打印规格" };
            bool[] RedOnly =           { true, true, true, redonlydt, true, true, false, true, false, true, false, false, false, true, true, false, true, true, true, true, true, true, false, false };
            int[] GrdWidth = { 0, 0, 0, 105, 0, jsdwide, 230, 80, 35, 40, 55, 40, 30, 30, 0, 30, 45, 70, 70, 55, 55, 0, dywide, dyggwide };//Modify by zouchihua 2012-1-31
            InitmyGrd(GrdMapppingName, GrdHeaderText, GrdWidth, RedOnly, this.dataGrid_LongOrder);
        }

        /// <summary>
        /// 初始化dataGrid
        /// </summary>
        /// <param name="GrdMappingName"></param> MappingName数组
        /// <param name="GrdHeaderText"></param>  GrdHeaderText数组
        /// <param name="GrdWidth"></param>       Width数组
        /// <param name="GrdReadOnly"></param>    ReadOnly数组
        /// <param name="mydataGrid"></param>
        public void InitmyGrd(string[] GrdMappingName, string[] GrdHeaderText, int[] GrdWidth, bool[] GrdReadOnly, DataGridEx dataGrid)
        {
            int i = 0;
            DataTable myTb = new DataTable();
            this.dataGrid_LongOrder.TableStyles[0].AllowSorting = false;

            for (i = 0; i <= GrdMappingName.Length - 1; i++)
            {

                myTb.Columns.Add(GrdMappingName[i].ToString());
            }
            myTb.Rows.Add(myTb.NewRow());
            dataGrid.DataSource = myTb;

            if (dataGrid.TableStyles.Count > 0)
            {
                dataGrid.TableStyles[0].RowHeaderWidth = 5;
                for (i = 0; i <= dataGrid.TableStyles[0].GridColumnStyles.Count - 1; i++)
                {
                    //add by zouchihua 增加警示灯列 2011-12-23
                    if (GrdHeaderText[i] == "警示灯")
                    {
                        dataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
                        dataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                        dataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
                        if (GrdWidth[i] != 0) dataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdHeaderText[i].ToString();
                        dataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = GrdReadOnly[i];
                    }
                    else
                    {
                        dataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
                        dataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                        dataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
                        if (GrdWidth[i] != 0) dataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdHeaderText[i].ToString();
                        dataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = GrdReadOnly[i];
                    }

                }
            }
        }

        public void InitmyGrd(string[] GrdMappingName, string[] GrdHeaderText, int[] GrdWidth, int[] GrdReadOnly, DataGridEx dataGrid)
        {
            int i = 0;
            DataTable myTb = new DataTable();

            for (i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                myTb.Columns.Add(GrdMappingName[i].ToString());
            }
            myTb.Rows.Add(myTb.NewRow());
            dataGrid.DataSource = myTb;

            dataGrid.TableStyles[0].RowHeaderWidth = 5;
            for (i = 0; i <= dataGrid.TableStyles[0].GridColumnStyles.Count - 1; i++)
            {
                dataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
                dataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                dataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
                dataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdHeaderText[i].ToString();
                if (GrdReadOnly[i] != 0) dataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = false;
                else dataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
            }
        }

        private void loadGrid_LongOrder()
        {
            try
            {
                if (this.dataGrid_LongOrder.VisibleRowCount > 0) this.dataGrid_LongOrder.CurrentCell = new DataGridCell(0, 0);
            }
            catch
            {

            }
            DataTable dtNeed = new DataTable();

            if (_isPrint)
            {
                DataTable dtOrdRec = new DbQuery().GetBinOrders(1, _babyID, _binID, InstanceForm._currentDept.DeptId);
                DataTable dtOrdRec1 = new DbQuery().GetBinOrders(2, _babyID, _binID, InstanceForm._currentDept.DeptId);
                dtNeed = dtOrdRec.Clone();
                foreach (DataRow drNeed in dtOrdRec.Rows)
                {
                    if (drNeed["嘱号"].ToString().Trim().Equals(_grpID))
                    {
                        dtNeed.Rows.Add(drNeed.ItemArray);
                    }
                }
                foreach (DataRow drNeed in dtOrdRec1.Rows)
                {
                    if (drNeed["嘱号"].ToString().Trim().Equals(_grpID))
                    {
                        DataRow dr1 = dtNeed.NewRow();
                        foreach (DataColumn dc in dtOrdRec1.Columns)
                        {
                            if (dtNeed.Columns.Contains(dc.ColumnName))
                            {
                                dr1[dc.ColumnName] = drNeed[dc.ColumnName];
                            }
                        }
                        dtNeed.Rows.Add(dr1);
                    }
                }
                dtNeed.AcceptChanges();
            }

            DataTable myTb = _isPrint ? dtNeed : _dtKss;

            DataView tempDataView = new DataView(myTb, "", "开始时间,嘱号,serial_no", DataViewRowState.CurrentRows);
            myTb = insertRow(tempDataView, myTb);//将数据视图转化为表
            tempDataView.Dispose();

            for (int i = 0; i < myTb.Rows.Count; i++)
            {   //去多余的“0”
                myTb.Rows[i]["剂量"] = removeZero(Convert.ToDecimal(myTb.Rows[i]["剂量"].ToString()));
            }
            DataTable myTbb = CheckGrdDataLong(myTb);
            //DataRow myRow = myTbb.NewRow();
            ////myRow["ID"]=1;//ID为0，表示不为正规行
            //myTbb.Rows.Add(myRow);
            DataTable myTbBk = myTbb.Copy();
            this.dataGrid_LongOrder.DataSource = null;
            this.dataGrid_LongOrder.DataSource = myTbBk;
            //以前的
            //this.dataGrid_LongOrder.CurrentRowIndex = myTbBk.Rows.Count - 1;
            try
            {
                DataGridCell cel;
                if (myTbBk.Rows.Count - 2 >= 0)
                {
                    cel = new DataGridCell(myTbBk.Rows.Count - 2, 0);

                    this.dataGrid_LongOrder.CurrentCell = cel;
                }
            }
            catch { }

            if (this.dataGrid_LongOrder.TableStyles.Count > 0)
            {
                this.dataGrid_LongOrder.TableStyles[0].ReadOnly = true;
            }
            Cursor = Cursors.Default;
        }

        private decimal removeZero(decimal dc)
        {
            string str = "";
            Int64 i = Convert.ToInt64(dc);
            if (dc == i)
            {
                return Convert.ToDecimal(i.ToString());
            }
            else
            {
                str = dc.ToString();

                for (i = 0; i <= str.Length; i++)
                {
                    if (str.Substring(str.Length - 1, 1) == "0") str = str.Substring(0, str.Length - 1);
                    else break;
                }
                return Convert.ToDecimal(str);
            }
        }

        private DataTable insertRow(DataView myView, DataTable dt)
        {
            DataTable myTb = dt.Copy();
            myTb.Rows.Clear();
            myView.Sort = "嘱号 ASC,开始时间 DESC";
            foreach (DataRowView myDRV in myView)
            {
                DataRow newDR = myTb.NewRow();
                for (int i = 0; i < myView.Table.Columns.Count; i++)
                {
                    newDR[i] = myDRV[i];
                }
                if (newDR["医嘱内容"] == DBNull.Value)
                    continue;
                myTb.Rows.Add(newDR);
            }
            return myTb;
        }

        private DataTable CheckGrdDataLong(DataTable myTb)
        {
            int i, j = 1;
            int grouprows = 1;
            string RowString = "";
            int l = 0, group_rows = 1;//,max_len=0;    //同组中的医嘱个数,最长的长度	

            #region 算出长度
            int max_len10 = 0;
            int max_len11 = 0;
            int max_len12 = 0;
            //////////			for(i=0;i<=myTb.Rows.Count-1;i++)
            //////////			{				
            //////////				if(myTb.Rows[i]["类型"].ToString()=="1-西药" || myTb.Rows[i]["类型"].ToString()=="2-中成药" || myTb.Rows[i]["类型"].ToString()=="3-中草药")
            //////////				{
            //////////					l=System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
            //////////					max_len10=max_len10>l?max_len10:l;
            //////////				}
            //////////			}
            #endregion

            if (myTb.Rows.Count < 2) return myTb.Copy();

            #region 按嘱号将医嘱分开
            //			for(i=1;i<=myTb.Rows.Count-1;i++)
            //			{
            //				//如果嘱号不同 就插入一行
            //				if(myTb.Rows[i]["嘱号"].ToString().Trim() != myTb.Rows[i-1]["嘱号"].ToString().Trim() )
            //				{
            //					myTb=InsertRow(myTb,i);
            //					i++;
            //				}
            //			}
            #endregion

            //算出长度
            if (myTb.Rows[0]["类型"].ToString() == "1-西药" || myTb.Rows[0]["类型"].ToString() == "2-中成药" || myTb.Rows[0]["类型"].ToString() == "3-中草药")
            {
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[0]["医嘱内容"].ToString().Trim() + " ");
                max_len10 = max_len10 > l ? max_len10 : l;
            }

            #region 医嘱的公用属性至上

            if (!(myTb.Rows[0]["类型"].ToString() == "3-中草药" && Convert.ToInt32(myTb.Rows[0]["status_flag"].ToString()) > 1))
            {
                //				j=myQuery.GetMaxZYnum(this.BinID,this.BabyID,this.DeptID,Convert.ToInt32(myTb.Rows[0]["嘱号"].ToString()));//同组中的医嘱记录个数
                j = GetMaxZYnum(myTb, myTb.Rows[0]["嘱号"].ToString());
            }
            else j = 1;

            RowString = myTb.Rows[0]["医嘱内容"].ToString().Trim();

            if (j != 1)
            {
                myTb.Rows[0]["执行护士"] = System.DBNull.Value;
                myTb.Rows[0]["执行时间"] = System.DBNull.Value;
                myTb.Rows[0]["停嘱时间"] = System.DBNull.Value;
                myTb.Rows[0]["下嘱医生"] = System.DBNull.Value;
                //myTb.Rows[0]["停嘱医生"] = System.DBNull.Value;
            }
            else if ((RowString == "术后医嘱" || RowString == "产后医嘱" || RowString == "转科医嘱") && Convert.ToInt32(myTb.Rows[0]["status_flag"].ToString().Trim()) >= 1)
            {
                myTb.Rows[0]["开始时间"] = System.DBNull.Value;
                myTb.Rows[0]["剂量"] = System.DBNull.Value;
                myTb.Rows[0]["用法"] = System.DBNull.Value;
                myTb.Rows[0]["频率"] = System.DBNull.Value;
                myTb.Rows[0]["开始时间"] = System.DBNull.Value;
                myTb.Rows[0]["首日执行次数"] = System.DBNull.Value;
                //myTb.Rows[0]["末日次数"] = System.DBNull.Value;
                myTb.Rows[0]["剂数"] = System.DBNull.Value;
                myTb.Rows[0]["滴量"] = System.DBNull.Value;
                myTb.Rows[0]["执行护士"] = System.DBNull.Value;
                myTb.Rows[0]["执行时间"] = System.DBNull.Value;
                myTb.Rows[0]["停嘱时间"] = System.DBNull.Value;
                myTb.Rows[0]["下嘱医生"] = System.DBNull.Value;
                //myTb.Rows[0]["停嘱医生"] = System.DBNull.Value;
            }
            else if (myTb.Rows[0]["status_flag"].ToString().Trim() == "2") myTb.Rows[0]["停嘱时间"] = System.DBNull.Value;//取消欲停恢复有效长嘱后

            for (i = 1; i <= myTb.Rows.Count - 1; i++)
            {
                //算出长度
                if (myTb.Rows[i]["类型"].ToString() == "1-西药" || myTb.Rows[i]["类型"].ToString() == "2-中成药" || myTb.Rows[i]["类型"].ToString() == "3-中草药")
                {
                    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
                    max_len10 = max_len10 > l ? max_len10 : l;
                }

                //				j=myQuery.GetMaxZYnum(this.BinID,this.BabyID,this.DeptID,Convert.ToInt32(myTb.Rows[i]["嘱号"].ToString()));//同组中的医嘱记录个数
                j = GetMaxZYnum(myTb, myTb.Rows[i]["嘱号"].ToString());

                RowString = myTb.Rows[i]["医嘱内容"].ToString().Trim();

                #region 显示医嘱内容
                if (myTb.Rows[i]["嘱号"].ToString().Trim() != myTb.Rows[i - 1]["嘱号"].ToString().Trim())
                {
                    if (j != 1)
                    {
                        myTb.Rows[i]["执行护士"] = System.DBNull.Value;
                        myTb.Rows[i]["执行时间"] = System.DBNull.Value;
                        myTb.Rows[i]["下嘱医生"] = System.DBNull.Value;
                        //myTb.Rows[i]["停嘱医生"] = System.DBNull.Value;
                    }
                    else if ((RowString == "术后医嘱" || RowString == "产后医嘱" || RowString == "转科医嘱") && Convert.ToInt32(myTb.Rows[i]["status_flag"].ToString().Trim()) >= 1)
                    {
                        myTb.Rows[i]["开始时间"] = System.DBNull.Value;
                        myTb.Rows[i]["剂量"] = System.DBNull.Value;
                        myTb.Rows[i]["用法"] = System.DBNull.Value;
                        myTb.Rows[i]["频率"] = System.DBNull.Value;
                        myTb.Rows[i]["开始时间"] = System.DBNull.Value;
                        myTb.Rows[i]["首日执行次数"] = System.DBNull.Value;
                        //myTb.Rows[i]["末日次数"] = System.DBNull.Value;
                        myTb.Rows[i]["剂数"] = System.DBNull.Value;
                        myTb.Rows[i]["滴量"] = System.DBNull.Value;
                        myTb.Rows[i]["执行护士"] = System.DBNull.Value;
                        myTb.Rows[i]["执行时间"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱时间"] = System.DBNull.Value;
                        myTb.Rows[i]["下嘱医生"] = System.DBNull.Value;
                        //myTb.Rows[i]["停嘱医生"] = System.DBNull.Value;
                    }
                    if (myTb.Rows[i]["status_flag"].ToString().Trim() == "2") myTb.Rows[i]["停嘱时间"] = System.DBNull.Value;//取消欲停恢复有效长嘱后


                    //如果一组中的医嘱个数大于1
                    //if (group_rows != 1)
                    //{
                    //    //[3i2]0 代表第三行是一组医嘱的最后一条，该组医嘱有两条医嘱，status_flag=0
                    //    //this.sPaintLong += "[" + i.ToString() + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i - 1]["status_flag"].ToString().Trim();
                    //}
                    group_rows = 1;
                    grouprows = 1;
                }
                else
                {
                    try
                    {
                        grouprows++;
                        //如果不是第一行，且本行和上一行的医嘱号一致
                        myTb.Rows[i]["用法"] = System.DBNull.Value;
                        myTb.Rows[i]["频率"] = System.DBNull.Value;
                        myTb.Rows[i]["开始时间"] = System.DBNull.Value;
                        myTb.Rows[i]["首日执行次数"] = System.DBNull.Value;
                        //myTb.Rows[i]["末日次数"] = System.DBNull.Value;
                        myTb.Rows[i]["剂数"] = System.DBNull.Value;
                        myTb.Rows[i]["滴量"] = System.DBNull.Value;
                        if (j != grouprows)
                        {
                            myTb.Rows[i]["执行护士"] = System.DBNull.Value;
                            myTb.Rows[i]["执行时间"] = System.DBNull.Value;
                            myTb.Rows[i]["下嘱医生"] = System.DBNull.Value;
                            //myTb.Rows[i]["停嘱医生"] = System.DBNull.Value;
                        }
                        if (myTb.Rows[i]["status_flag"].ToString().Trim() == "2") myTb.Rows[i]["停嘱时间"] = System.DBNull.Value;//取消欲停恢复有效长嘱后

                        if (myTb.Rows[i]["类型"].ToString() == "1-西药" || myTb.Rows[i]["类型"].ToString() == "2-中成药" || myTb.Rows[i]["类型"].ToString() == "3-中草药") group_rows += 1;
                        //if (i == myTb.Rows.Count - 1 && j > 1 && group_rows != 1)
                        //{
                        //    //this.sPaintLong += "[" + Convert.ToString(i + 1) + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i]["status_flag"].ToString().Trim();
                        //}

                    }
                    catch (System.Data.OleDb.OleDbException err)
                    {
                        MessageBox.Show(err.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                #endregion
            }
            #endregion

            return myTb.Copy();
        }

        /// <summary>
        /// 获得最大医嘱号
        /// </summary>
        /// <param name="myTb"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        private int GetMaxZYnum(DataTable myTb, string groupID)
        {
            int j = 0;
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["嘱号"].ToString().Trim() == groupID) j++;
            }
            return j;
        }

        /// <summary>
        /// 保存
        /// </summary>
        void btnSave_Click(object sender, EventArgs e)
        {
            if (_isPrint)
            {
                //修改  本界面的 事务中插入数据
            }
            else
            {
                //新增yzgl里面的事务中插入数据
                try
                {
                    myEntity.Clear();
                    foreach (DataRow dr in _dtKss.Rows)
                    {
                        //特殊级药物
                        if (!dr["MEMO"].ToString().Equals("3"))
                        {
                            continue;
                        }

                        Entity_KjSq entity = new Entity_KjSq();

                        entity.drYzInfo = dr;

                        entity.DJID = TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString();
                        entity.INPATIENT_ID = "";
                        entity.baby_id = "";
                        entity.order_id = dr["ID"].ToString();
                        entity.group_id = dr["嘱号"].ToString();
                        entity.dept_id = InstanceForm._currentDept.DeptId.ToString();
                        entity.zyzd = txtZyZd.Text;
                        entity.shyj = txtShyj.Text;
                        entity.apply_id = InstanceForm._currentUser.EmployeeId.ToString();
                        entity.apply_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        entity.shr = cmbDept.SelectedValue == null ? "-1" : cmbDept.SelectedValue.ToString();//审核人未取
                        entity.shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        //申请用药理由
                        UcApplyInfo ucSqly = ucApplyInfos1.myCts[entity.order_id];

                        //1、用药目的
                        entity.purp_1 = ucSqly.rbtYfxyy.Checked ? "1" : ucSqly.rbtZlxyy.Checked ? "0" : "";
                        entity.purp_1_memo = ucSqly.rbtZlxyy.Checked ? ucSqly.txtYymdZl.Text : "";

                        //2、是否已送病原学检查
                        entity.purp_2 = ucSqly.rbtByjcYes.Checked ? "1" : ucSqly.rbtByjcNo.Checked ? "0" : "";
                        entity.purp_2_memo = "";

                        //3、是否已有细菌培养及药敏结果
                        entity.purp_3 = ucSqly.rbtXjpyYes.Checked ? "1" : ucSqly.rbtXjpyNo.Checked ? "0" : "";
                        entity.purp_3_memo = ucSqly.rbtXjpyYes.Checked ? ucSqly.txtByj.Text : "";

                        //4、所申请药物是否对该病原菌敏感
                        entity.purp_4 = ucSqly.rbtYjmgYes.Checked ? "1" : ucSqly.rbtYjmgNo.Checked ? "0" : "";
                        entity.purp_4_memo = "";

                        //5、其他
                        entity.purp_5_memo = ucSqly.txtMemo.Text;

                        myEntity.Add(dr["ID"].ToString(), entity);

                        #region"sql"
                        //                    string strSql = string.Format(@"insert into zy_kss_sqb(DJID
                        //                                                                           INPATIENT_ID		
                        //                                                                           baby_id			
                        //                                                                           order_id			
                        //                                                                           group_id			
                        //                                                                           dept_id			
                        //                                                                           zyzd				
                        //                                                                           shyj				
                        //                                                                           apply_id			
                        //                                                                           apply_time		
                        //                                                                           shr				
                        //                                                                           shsj				
                        //                                                                           purp_1			
                        //                                                                           purp_1_memo		
                        //                                                                           purp_2			
                        //                                                                           purp_2_memo		
                        //                                                                           purp_3			
                        //                                                                           purp_3_memo		
                        //                                                                           purp_4			
                        //                                                                           purp_4_memo		
                        //                                                                           purp_5_memo) VALUES
                        //                                                                        ('{0}','{1}',{2},'{3}','{4}','{5}',{6},'{7}','{8}','{9}',{10},'{11}','{12}','{13}',{14},'{15}','{16}','{17}',{18},'{19}','{20}')",
                        //                                                   entity.DJID, entity.INPATIENT_ID, entity.baby_id, entity.order_id, entity.group_id, entity.dept_id, entity.zyzd, entity.shyj, entity.apply_id, entity.apply_time,
                        //                                                   entity.shr, entity.shsj, entity.purp_1, entity.purp_1_memo, entity.purp_2, entity.purp_2_memo, entity.purp_3, entity.purp_3_memo, entity.purp_4, entity.purp_4_memo, entity.purp_5_memo);

                        #endregion
                    }
                    _isOk = true;
                    if (MessageBox.Show("操作成功,是否打印！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        btnPrint_Click(null,null);
                    }
                }
                catch
                {
                    _isOk = false;
                    MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void DoSetGridProp(bool add)
        {
            float iSize = dataGrid_LongOrder.Font.Size;
            dataGrid_LongOrder.Font = new Font("宋体", add ? ++iSize : --iSize);
        }

        private DataTable DoGetPrintData()
        {
            try
            {
                if (_dtKss.Rows.Count <= 0)
                    return null;

                DataTable dtPrint = new DataTable();
                dtPrint.Columns.Add("zyh", typeof(string));
                dtPrint.Columns.Add("age", typeof(string));
                dtPrint.Columns.Add("name", typeof(string));
                dtPrint.Columns.Add("sex", typeof(string));
                dtPrint.Columns.Add("bed", typeof(string));
                dtPrint.Columns.Add("zyzd", typeof(string));
                dtPrint.Columns.Add("mc", typeof(string));
                dtPrint.Columns.Add("yf", typeof(string));
                dtPrint.Columns.Add("gg", typeof(string));
                dtPrint.Columns.Add("num", typeof(string));
                dtPrint.Columns.Add("yfxyy", typeof(string));
                dtPrint.Columns.Add("zlxyy", typeof(string));
                dtPrint.Columns.Add("grzd", typeof(string));
                dtPrint.Columns.Add("byjcyes", typeof(string));
                dtPrint.Columns.Add("byjcno", typeof(string));
                dtPrint.Columns.Add("ymjgyes", typeof(string));
                dtPrint.Columns.Add("ymjgno", typeof(string));
                dtPrint.Columns.Add("byj", typeof(string));
                dtPrint.Columns.Add("byjmgyes", typeof(string));
                dtPrint.Columns.Add("byjmgno", typeof(string));
                dtPrint.Columns.Add("memo", typeof(string));
                dtPrint.Columns.Add("applyer", typeof(string));
                dtPrint.Columns.Add("kszr", typeof(string));
                dtPrint.Columns.Add("sqrq", typeof(string));
                dtPrint.Columns.Add("shyj", typeof(string));

                foreach (KeyValuePair<string, Entity_KjSq> kvp in myEntity)
                {
                    DataRow dr = dtPrint.NewRow();

                    Entity_KjSq entity = kvp.Value;
                    string id = kvp.Key;
                    string grpId = entity.group_id;

                    DataTable dtGrp = dataGrid_LongOrder.DataSource as DataTable;
                    dr["gg"] = entity.drYzInfo["单位"];
                    for (int i = 0; i < dtGrp.Rows.Count; i++)
                    {
                        if (id.Equals(dtGrp.Rows[i]["ID"].ToString()))
                        {
                            if (dtGrp.Columns.Contains("规格"))
                            {
                                dr["gg"] = dtGrp.Rows[i]["规格"].ToString();
                            }
                        }

                        if (dtGrp.Rows[i]["嘱号"].ToString().Equals(grpId))
                        {
                            if (!dtGrp.Rows[i]["用法"].ToString().Trim().Equals(""))
                            {
                                dr["yf"] = dtGrp.Rows[i]["用法"].ToString().Trim();
                            }
                        }
                    }

                    dr["zyh"] = _patientInfo.lbID.Text;
                    dr["age"] = _patientInfo.lbAge.Text;
                    dr["name"] = _patientInfo.lbName.Text;
                    dr["sex"] = _patientInfo.lbSex.Text;
                    dr["bed"] = _patientInfo.lbBed.Text;
                    dr["zyzd"] = txtZyZd.Text;

                    dr["mc"] = entity.drYzInfo["医嘱内容"];
                    dr["num"] = entity.drYzInfo["剂量"];

                    dr["yfxyy"] = entity.purp_1.Equals("1") ? "√" : "";
                    dr["zlxyy"] = entity.purp_1.Equals("0") ? "√" : "";
                    dr["grzd"] = entity.purp_1_memo;

                    dr["byjcyes"] = entity.purp_2.Equals("1") ? "√" : "";
                    dr["byjcno"] = entity.purp_2.Equals("0") ? "√" : "";

                    dr["ymjgyes"] = entity.purp_3.Equals("1") ? "√" : "";
                    dr["ymjgno"] = entity.purp_3.Equals("0") ? "√" : "";
                    dr["byj"] = entity.purp_3_memo;

                    dr["byjmgyes"] = entity.purp_4.Equals("1") ? "√" : "";
                    dr["byjmgno"] = entity.purp_4.Equals("0") ? "√" : "";

                    dr["memo"] = entity.purp_5_memo;

                    dr["applyer"] = txtSqYs.Text;
                    dr["kszr"] = cmbDept.Text;
                    dr["sqrq"] = dtpDate.Value.ToString("yyyy年MM月dd日");
                    dr["shyj"] = txtShyj.Text;

                    dtPrint.Rows.Add(dr);
                }

                return dtPrint;
            }
            catch { return null; }
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPrint = DoGetPrintData();

                if (dtPrint == null || dtPrint.Rows.Count <= 0)
                {
                    MessageBox.Show("没有可打印的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                PrintReport(dtPrint);
            }
            catch { }
        }

        private void PrintReport(DataTable dtData)
        {
            try
            {
                grproLib.GridppReportClass gridReportObject = new grproLib.GridppReportClass();
                gridReportObject.LoadFromFile(Reports.药库药品明细三级分类账);
                //gridReportObject.get_ReportHeader( 1 ).Visible = false;
                //gridReportObject.get_ReportFooter( 1 ).Visible = false;
                gridReportObject.ParameterByName("科室").AsString = InstanceForm._currentDept.DeptName;
                gridReportObject.FetchRecord += delegate()
                {
                    if (dtData != null)
                    {
                        int index;
                        MatchFieldPairType[] typeArray = new MatchFieldPairType[Math.Min(gridReportObject.DetailGrid.Recordset.Fields.Count, dtData.Columns.Count)];
                        int num = 0;
                        for (index = 0; index < dtData.Columns.Count; index++)
                        {
                            foreach (grproLib.IGRField field in gridReportObject.DetailGrid.Recordset.Fields)
                            {
                                if (string.Compare(field.Name, dtData.Columns[index].ColumnName, true) == 0)
                                {
                                    typeArray[num].grField = field;
                                    typeArray[num].MatchColumnIndex = index;
                                    num++;
                                    break;
                                }
                            }
                        }

                        foreach (DataRow row in dtData.Rows)
                        {
                            gridReportObject.DetailGrid.Recordset.Append();
                            for (index = 0; index < num; index++)
                            {
                                if (!row.IsNull(typeArray[index].MatchColumnIndex))
                                {
                                    typeArray[index].grField.Value = row[typeArray[index].MatchColumnIndex];
                                }
                            }
                            gridReportObject.DetailGrid.Recordset.Post();
                        }

                    }
                };

                gridReportObject.PrintPreviewEx(grproLib.GRPrintGenerateStyle.grpgsOnlyContent, true, false);
            }
            catch { }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string ssql = "select ID,NAME,PY_CODE,WB_CODE from JC_DISEASE where BSCBZ=0 ";

                TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "ID", "NAME", "PY_CODE", "WB_CODE" },
                                                                                   new string[] { "代码", "主要诊断", "拼音码", "五笔码" },
                                                                                   new string[] { "ID", "NAME", "PY_CODE", "WB_CODE" },
                                                                                   new int[] { 80, 150, 80, 80 });

                frmSelectCard.sourceDataTable = InstanceForm._database.GetDataTable(ssql);
                frmSelectCard.srcControl = txtZyZd;
                frmSelectCard.WorkForm = this;
                //frmSelectCard.ReciveString = cmbbs1.Text;
                if (frmSelectCard.ShowDialog() == DialogResult.OK)
                {
                    txtZyZd.Text += string.IsNullOrEmpty(txtZyZd.Text.Trim()) ? (frmSelectCard.SelectDataRow["NAME"].ToString() + ";") : (";"+frmSelectCard.SelectDataRow["NAME"].ToString() + ";");
                }
            }
            catch { }
        }
    }
}