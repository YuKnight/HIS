using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;

namespace ts_zyhs_yzgl
{
    public partial class FrmQFZX : Form
    {
        public FrmQFZX()
        {
            InitializeComponent();
        }

        病人信息.PatientInfo brxx = new 病人信息.PatientInfo();
        private BaseFunc myFunc = new BaseFunc();

        string sPaint = "", sPaintPS = "", sPaintWZX = "", sName = "";
        int max_len0 = 0, max_len1 = 0, max_len2 = 0;//最长的医嘱长度,最长的医嘱长度(有数量单位的),最长的数量单位长度		
        private void FrmQFZX_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            this.myDataGrid.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName ={ "床号", "住院号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY", "IN_DATE" };
            string[] GrdHeaderText = new string[] {"床号", "住院号", "姓名", "", "", "", "", "" };
            int[] GrdWidth ={ 5,9, 8, 0, 0, 0, 0 ,0};
            int[] Alignment ={ 1,1, 0, 0, 0, 0, 0 ,0};
            int[] ReadOnly ={ 0,0, 0, 0, 0, 0, 0, 0};
            BRData();
            myFunc.InitGrid(GrdMappingName,GrdHeaderText, GrdWidth, Alignment, ReadOnly, this.myDataGrid);

            DataTable myTb = (DataTable)myDataGrid.DataSource;


            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
           
            string[] GrdMappingName1 ={ "status_flag","Order_ID","Group_ID","Num","Unit","dwlx","Order_Usage","frequency","Dropsper","Dosage",
										"ntype","exec_dept","day1","second1","day2","second2", "AUDITING_USER","AUDITING_USER1",
										"order_euser","order_euser1","item_code","xmly",     
										"选",
										"开日期","开时间","医嘱内容","费用","开嘱医生","开嘱转抄","开嘱核对",
										"停日期","停时间","停嘱医生","停嘱转抄","停嘱核对",
										"执行时间","执行人","执行科室","发送时间","发送护士",//"执行时间","执行人",
										"ps_flag","ps_orderid","ps_user","wzx_flag","P","hoitem_id","isprintypgg"};//isggdy add by zouchihua 2011-11-30
 
            int[] GrdWidth1 ={0,0,0,0,0,0,0,0,0,0,
									 0,0,0,0,0,0,0,0,
									 0,0,0,0,
									 2,
									 6,6,50,6,8,8,0,//开嘱核对不显示
									 6,6,8,8,0,//停嘱核对不显示
									 15,8,8,15,8,
									 0,0,0,0,2,0,0};//isggwide
            int[] Alignment1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 };
            int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1};
            this.InitGridYZ(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                //if (rbTszl.Checked == false)
                //{
                //    rbTszl.Checked = true;
                //    rb_Click(null, null);
                //    return;
                //}
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClassStatic.Current_BinID = Guid.Empty;
                ClassStatic.Current_BabyID = 0;
                ClassStatic.Current_DeptID = 0;
                ClassStatic.Current_isMYTS = 0;
                ClassStatic.Current_isMY = 0;

            }
        }

        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            myDataGrid.TableStyles[0].AllowSorting = false; //不允许排序

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
        private void BRData()
        {
            //检索该病区的所有病人
            string sql = @"select BED_NO as 床号,INPATIENT_NO as 住院号,NAME as 姓名,INPATIENT_ID,BABY_ID,DEPT_ID,ISMY,IN_DATE from VI_ZY_VINPATIENT_BED where WARD_ID='" + FrmMdiMain.CurrentDept.WardId + "'and flag in(1,3,4)  order by BED_NO";
            DataTable dt= FrmMdiMain.Database.GetDataTable(sql);
            if (dt == null) return;
          
            for (int i =dt.Rows.Count - 1; i >= 0; i--)
            {
                //检索病人费用信息
                DataRow dr=dt.Rows[i];
                DataTable dtf= brxx.GetInpatientInfo(new Guid(dr["INPATIENT_ID"].ToString()), Convert.ToInt64(dr["BABY_ID"]), Convert.ToInt32(dr["ISMY"]));
                if(dtf==null) continue;
                decimal _ye =Convert.ToDecimal(dtf.Rows[0]["YE"].ToString() == "" ? "0" : dtf.Rows[0]["YE"].ToString());
                if (_ye < myFunc.GetPatMinExecYE(new Guid(dr["INPATIENT_ID"].ToString())))
                {
                    // 增加对病人入院时间的判断
                    //7072病人入院？小时后控制欠费（0=立即控制）
                    int _hour = Convert.ToInt32(new SystemCfg(7072, InstanceForm.BDatabase).Config);
                    DateTime _rysj = Convert.ToDateTime(dr["IN_DATE"].ToString());
                    if (_rysj.AddHours(_hour) <= DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase))
                    {
                        //欠费病人
                    }else
                    {    //移除不欠费的病人
                        dt.Rows.RemoveAt(i);
                    }
                }
                else
                {    //移除不欠费的病人
                    dt.Rows.RemoveAt(i);
                }

            }
            this.myDataGrid.DataSource = dt;
        }

        private int GetMNGType()
        {
            switch (this.tabControl1.SelectedTab.Text.Trim())
            {
                case "有效长嘱":
                    return 0;
                case "有效长期账单":
                    return 2;
                
                default:
                    return 0;
            }
        }
        private void ShowDate()
        {
            //5=临嘱交病人
            //0-长嘱  1,5-临嘱  2-长期账单  3-临时账单  （MNGTYPE）
            int nType = this.GetMNGType();
            int nKind = this.tabControl1.SelectedTab.Text.Trim().IndexOf("有效", 0, this.tabControl1.SelectedTab.Text.Trim().Length) >= 0 ? 0 : 1;

            DataTable myTb = new DataTable();
      
            myTb = myFunc.GetBinOrdrs("", ClassStatic.Current_BinID, ClassStatic.Current_BabyID, nType, nKind, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), InstanceForm.BCurrentDept.WardId,  0);

            DataView dv = myTb.DefaultView;
            dv.RowFilter = "status_flag = 4";
            DataTable newmyTb = dv.ToTable();
         
            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Boolean");
            col.AllowDBNull = true;
            col.ColumnName = "选";
            col.DefaultValue = false;
            newmyTb.Columns.Add(col);
    
            CheckGrdData(newmyTb, nType);
            if(newmyTb.Rows.Count==0)
               this.myDataGrid1.DataSource = newmyTb;
        }
        private void CheckGrdData(DataTable myTb, int nType)
        {
            if (myTb.Rows.Count == 0) return;

            string sNum = "";
            int i = 0, iDay = 0, iTime = 0;                //记录上一个显示日期和时间的行号
            int l = 0, group_rows = 1;    //同组中的医嘱个数
            int ii = 0;
            this.sPaint = "";
            this.sPaintPS = "";
            this.sPaintWZX = "";

            #region 算出长度
            max_len0 = 0;
            max_len1 = 0;
            max_len2 = 0;
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                sNum = this.GetNumUnit(myTb, i);
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
                //最长医嘱
                max_len0 = max_len0 > l ? max_len0 : l;
                if (sNum.Trim() != "")
                {
                    //最长医嘱
                    max_len1 = max_len1 > l ? max_len1 : l;
                    l = System.Text.Encoding.Default.GetByteCount(sNum);
                    //最长单位
                    max_len2 = max_len2 > l ? max_len2 : l;
                }
            }
            #endregion

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                #region 显示日期时间
                myTb.Rows[i]["开日期"] = myFunc.getDate(myTb.Rows[i]["开日期"].ToString().Trim(), myTb.Rows[i]["day1"].ToString().Trim());
                myTb.Rows[i]["开时间"] = myFunc.getTime(myTb.Rows[i]["开时间"].ToString().Trim(), myTb.Rows[i]["second1"].ToString().Trim());
                myTb.Rows[i]["停日期"] = myFunc.getDate(myTb.Rows[i]["停日期"].ToString().Trim(), myTb.Rows[i]["day2"].ToString().Trim());
                myTb.Rows[i]["停时间"] = myFunc.getTime(myTb.Rows[i]["停时间"].ToString().Trim(), myTb.Rows[i]["second2"].ToString().Trim());
                if (i != 0)
                {
                    if (myTb.Rows[i]["开日期"].ToString().Trim() == myTb.Rows[iDay]["开日期"].ToString().Trim())
                    {
                        myTb.Rows[i]["开日期"] = System.DBNull.Value;
                    }
                    else
                    {
                        iDay = i;
                    }
                    // 时间相同，日期不同要显示时间 Modify by zouchihua 2012-11-14
                    if (myTb.Rows[i]["开时间"].ToString().Trim() == myTb.Rows[iTime]["开时间"].ToString().Trim() && (myTb.Rows[i]["开日期"].ToString().Trim() == myTb.Rows[iTime]["开日期"].ToString().Trim() || myTb.Rows[i]["开日期"].ToString().Trim() == ""))
                    {
                        myTb.Rows[i]["开时间"] = System.DBNull.Value;
                    }
                    else
                    {
                        iTime = i;
                    }
                }
                #endregion
                #region 显示医嘱内容

                //“医嘱内容”+= “医嘱内容”+“空格”+“数量单位”
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
                sNum = this.GetNumUnit(myTb, i);
                if (sNum.Trim() != "")
                    myTb.Rows[i]["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString().Trim() + myFunc.Repeat_Space(max_len1 - l) + sNum;//加一个空格 Modify by zouchiua 2012-6-29
                else
                    myTb.Rows[i]["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString().Trim() + myFunc.Repeat_Space(max_len0 - l) + sNum;

                if ((i == myTb.Rows.Count - 1) || (i != myTb.Rows.Count - 1 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i + 1]["Group_id"].ToString().Trim()))
                {
                    //如果是最后一行或本行和上一行的医嘱号不一致

                    //同组中第一条医嘱的“医嘱内容”+=“用法”+“滴速”+ “频率”
                    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1]["医嘱内容"].ToString().Trim());
                    if (sNum.Trim() != "")
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(max_len1 + max_len2 - l + 4);//Modify By Tany 2005-01-25			
                    else
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(max_len2 + 4);//Modify By Tany 2005-01-25			
                    if (myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();
                    if (myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim();// +"滴/min"; Modify by zouchihua 2012-4-27先去调
                    if (myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != ""
                        && myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "1"
                        //						&&(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 
                        //						    ||(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD"))
                        )
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                    int cd = 0;
                    //add by zouchihua 2012-6-23 增加天数
                    if ((nType == 1 || nType == 5) && myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() != ""
                        && int.Parse(myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim()) > 1
                        //						&&(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 
                        //						    ||(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD"))
                        )
                    {
                        cd = System.Text.Encoding.Default.GetByteCount(" " + myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() + "天");
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() + "天" + myFunc.Repeat_Space(6 - cd);
                    }
                    else
                    {
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(6 - cd);
                    }
                    int len = 0;
                    for (int x = 0; x < group_rows; x++)
                    {

                        #region//总量显示
                        if ((nType == 1 || nType == 5) && Convert.ToInt32(myTb.Rows[i - group_rows + 1 + x]["ntype"].ToString().Trim()) < 4 && myTb.Rows[i - group_rows + 1 + x]["zsl"].ToString().Trim() != "")//如果是药品
                        {
                            string ssNum = "";

                            if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1 + x]["zsl"]) == Convert.ToInt64(myTb.Rows[i - group_rows + 1 + x]["zsl"]))
                            {
                                ssNum = String.Format("{0:F0}", myTb.Rows[i - group_rows + 1 + x]["zsl"]).Trim();
                                if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1 + x]["zsl"]) == 0)
                                    ssNum = "";
                            }
                            else
                            {
                                ssNum = String.Format("{0:F3}", myTb.Rows[i - group_rows + 1 + x]["zsl"]).Trim();
                            }
                            if (x == 0)
                            {
                                len = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1 + x]["医嘱内容"].ToString());
                                myTb.Rows[i - group_rows + 1 + x]["医嘱内容"] += " " + ssNum + myTb.Rows[i - group_rows + 1 + x]["zsldw"].ToString().Trim();
                            }
                            else
                            {
                                int blen = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1 + x]["医嘱内容"].ToString());
                                myTb.Rows[i - group_rows + 1 + x]["医嘱内容"] += myFunc.Repeat_Space(len - blen) + " " + ssNum + myTb.Rows[i - group_rows + 1 + x]["zsldw"].ToString().Trim();
                            }
                        }
                        #endregion
                    }

                    //如果一组中的医嘱个数大于1
                    if (group_rows != 1)
                    {
                        //[3i2]0 代表第三行是一组医嘱的最后一条，该组医嘱有两条医嘱，status_flag=0
                        this.sPaint += "[" + i.ToString() + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i]["status_flag"].ToString().Trim();
                    }

                    ii = i - group_rows + 1;

                    group_rows = 1;
                }
                else
                {
                    try
                    {

                        //如果不是第一行，且本行和下一行的医嘱号一致
                        myTb.Rows[i]["开嘱医生"] = System.DBNull.Value;
                        myTb.Rows[i]["开嘱转抄"] = System.DBNull.Value;
                        myTb.Rows[i]["开嘱核对"] = System.DBNull.Value;
                        myTb.Rows[i]["停日期"] = System.DBNull.Value;
                        myTb.Rows[i]["停时间"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱医生"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱转抄"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱核对"] = System.DBNull.Value;
                        if (myTb.Rows[i]["ntype"].ToString() == "1" || myTb.Rows[i]["ntype"].ToString() == "2" || myTb.Rows[i]["ntype"].ToString() == "3") group_rows += 1;

                        ii = i;
                    }
                    catch (System.Data.OleDb.OleDbException err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
                #region//总量显示
                //if ((nType == 1 || nType == 5) && Convert.ToInt32(myTb.Rows[i]["ntype"].ToString().Trim()) < 4 && myTb.Rows[i]["zsl"].ToString().Trim() != "")//如果是药品
                //{
                //    string ssNum = "";

                //    if (Convert.ToDecimal(myTb.Rows[i]["zsl"]) == Convert.ToInt64(myTb.Rows[i]["zsl"]))
                //    {
                //        ssNum = String.Format("{0:F0}", myTb.Rows[i]["zsl"]).Trim();
                //        if (Convert.ToDecimal(myTb.Rows[i]["zsl"]) == 0)
                //            ssNum = "";
                //    }
                //    else
                //    {
                //        ssNum = String.Format("{0:F3}", myTb.Rows[i]["zsl"]).Trim();
                //    }
                //    myTb.Rows[i]["医嘱内容"] += " " + ssNum + myTb.Rows[i]["zsldw"].ToString().Trim();
                //}
                #endregion
                #endregion

                #region 显示未执行
                if (Convert.ToInt16(myTb.Rows[i]["wzx_flag"]) > 0)
                {
                    this.sPaintWZX += "i" + i.ToString() + "X";
                }
                #endregion

                #region 显示皮试
                //阳性
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 2 &&
                    (myTb.Rows[ii]["医嘱内容"].ToString().Trim().IndexOf("皮试", 0) > 0
                    || myTb.Rows[ii]["医嘱内容"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "+" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["医嘱内容"].ToString().Trim()) + "]";
                }
                //阴性
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 1 &&
                    (myTb.Rows[ii]["医嘱内容"].ToString().Trim().IndexOf("皮试", 0) > 0
                    || myTb.Rows[ii]["医嘱内容"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "-" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["医嘱内容"].ToString().Trim()) + "]" + myTb.Rows[ii]["status_flag"].ToString().Trim();
                }
                #endregion
            }
            this.myDataGrid1.DataSource = myTb;
        }

        //返回“数量+单位”，检查是否显示小数
        private string GetNumUnit(DataTable myTb, int i)
        {
            string sNum = "";
            if (Convert.ToDecimal(myTb.Rows[i]["Num"]) == Convert.ToInt64(myTb.Rows[i]["Num"]))
            {
                sNum = String.Format("{0:F0}", myTb.Rows[i]["Num"]).Trim();
            }
            else
            {
                sNum = String.Format("{0:F3}", myTb.Rows[i]["Num"]).Trim();
            }
            //Modify By Tany 2004-10-27
            if ((sNum == "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "1"
                && myTb.Rows[i]["ntype"].ToString().Trim() != "2"
                && myTb.Rows[i]["ntype"].ToString().Trim() != "3"
                && GetMNGType() != 2
                && GetMNGType() != 3)
                || sNum == "0" || sNum == "")
                return "";
            else
                return "" + sNum + myTb.Rows[i]["Unit"].ToString().Trim();//Modify by zouchihua 2012-6-29 加一个空格
        }
        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            //用色彩区分医嘱的状态 
            int ColorCol = 0;		 //状态列
            e.BackColor = Color.White;
            if (this.myDataGrid1[e.Row, ColorCol].ToString() != "")
            {
                if (Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) > 1 && Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) < 5)   //已审核
                {
                    e.ForeColor = Color.Blue;
                    //选择列
                    if (this.myDataGrid1[e.Row, 22].ToString() == "True") e.BackColor = Color.GreenYellow;
                }
            }
           
            //已经执行的医嘱显示红色 Modify By Tany 2007-10-27
            if (this.myDataGrid1[e.Row, 38].ToString() != "")
            {
                if (Convert.ToDateTime(this.myDataGrid1[e.Row, 38]) >= Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd")))
                {
                    e.ForeColor = Color.Red;
                    if (this.myDataGrid1[e.Row, 22].ToString() == "True") e.BackColor = Color.GreenYellow;
                }
            }
        }

        //private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        //{
        //    myDataGrid.TableStyles[0].AllowSorting = false; //不允许排序

        //    DataGridEnableTextBoxColumn aColumnTextColumn;
        //    for (int i = 0; i <= GrdMappingName.Length - 1; i++)
        //    {
        //        if (GrdMappingName[i].ToString().Trim() == "选" || GrdMappingName[i].ToString().Trim() == "P" || GrdMappingName[i].ToString().Trim() == "isprintypgg")
        //        {
        //            DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
        //            if (GrdMappingName[i].ToString().Trim() == "P" || GrdMappingName[i].ToString().Trim() == "isprintypgg")
        //            {
        //                myBoolCol.AllowNull = false;
        //                myBoolCol.TrueValue = (short)1;
        //                myBoolCol.FalseValue = (short)0;
        //                myBoolCol.NullValue = (short)0;
        //            }
        //            myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
        //            myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
        //            myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
        //            myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
        //            //add by zouchihua 2011-11-30
        //            if (GrdMappingName[i].ToString().Trim() == "isprintypgg")
        //            {
        //                myBoolCol.AllowNull = false;
        //                myBoolCol.TrueValue = 1;
        //                myBoolCol.FalseValue = 0;
        //                myBoolCol.NullValue = 0;
        //                myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = "打印规格";
        //            }
        //        }
        //        else
        //        {
        //            aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
        //            aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
        //            myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
        //            myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
        //            myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
        //            myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
        //            if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
        //        }
        //    }
        //}

        private void myDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable myTb1 = (DataTable)myDataGrid.DataSource;
            if (myTb1 == null || myTb1.Rows.Count == 0)
            {
                return;
            }

            int nrow = this.myDataGrid.CurrentCell.RowNumber;
            this.myDataGrid.Select(nrow);
            //Modify By Tany 2010-01-29 有床号显示床号，没有床号显示住院号
            string bz = "";
            if (myTb1.Columns.Contains("床号"))
            {
                bz = "(" + Convert.ToString(myTb1.Rows[nrow]["床号"]).Trim() + "床)";
            }
            else if (myTb1.Columns.Contains("住院号"))
            {
                bz = "(" + Convert.ToString(myTb1.Rows[nrow]["住院号"]).Trim() + ")";
            }
            this.sName = Convert.ToString(myTb1.Rows[nrow]["姓名"]).Trim() + bz;
            ClassStatic.Current_BinID = new Guid(myTb1.Rows[nrow]["inpatient_id"].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(myTb1.Rows[nrow]["baby_id"]);
            ClassStatic.Current_DeptID = Convert.ToInt64(myTb1.Rows[nrow]["dept_id"]);
            ClassStatic.Current_isMY = Convert.ToInt16(myTb1.Rows[nrow]["ismy"]);

       
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb != null)
                myTb.Rows.Clear();
                this.myDataGrid1.DataSource = myTb;
                this.ShowDate();
            

           
        }

        private void buttzx_Click(object sender, EventArgs e)
        {
            bool _qfExeCurDeptOrder = false;//欠费是否能够发送本科室医嘱

            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            decimal _orderfee = 0;
            int GroupID = -999;
            int iMNGType = 0;
            int iSelectRows = 0;
            DataTable myTb = (DataTable)myDataGrid1.DataSource;
            DateTime ExecDate = Convert.ToDateTime(Convertor.IsNull(((Button)sender).Tag, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString()));

            #region 有效性判断
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True")
                {
                    iSelectRows += 1;
                }
            }

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "对不起，没有选择医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            iMNGType = GetMNGType();
            progressBar1.Maximum = myTb.Rows.Count;
            progressBar1.Value = 0;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                //如果是选择发送
                if (myTb.Rows[i]["选"].ToString() == "True")
                {
                    //如果组号与上一条医嘱相同，则不执行
                    if (GroupID == Convert.ToInt32(myTb.Rows[i]["Group_ID"]))
                    {
                        if (_orderfee > 0)
                        {
                            myTb.Rows[i]["选"] = false;
                        }
                        continue;
                    }

                    GroupID = Convert.ToInt32(myTb.Rows[i]["Group_ID"]);
                  
                    _orderfee = myFunc.GetOrderFee(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, iMNGType, GroupID, ExecDate, ExecDate);
                    progressBar1.Value += 1;

                    if(_orderfee >0)
                    {
                        myTb.Rows[i]["选"] = false;
                    }
                }
            }
            try
            {
                string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
                int BrJgbm = Convert.ToInt32(rtnSql[1]);
                //发送
                myFunc.ExecOrdersWithData(this.myDataGrid1, iMNGType, 1, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);
                //myFunc.ExecOrdersWithData(this.myDataGrid1, 2, 1, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);
                MessageBox.Show("发送完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //刷新界面
                this.tabControl1_SelectedIndexChanged(sender, e);
            }
            catch (Exception err)
            {
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "医嘱执行错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source + "\n\n数据已经回滚，请检查后重新执行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 0;
              
                return;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.ShowDate();  
        }

        private void myDataGrid1_Paint(object sender, PaintEventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int i = 0;
            int yDelta = this.myDataGrid1.GetCellBounds(i, 0).Height + 1;
            int y = this.myDataGrid1.GetCellBounds(i, 0).Top + 2;

            int index_start = 0, index_i = 0, index_p = 0, index_end = 0;
            int start_row = 0, start_point = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[this.myDataGrid1.DataSource, this.myDataGrid1.DataMember];

            while (y < this.myDataGrid1.Height - yDelta && i < cm.Count)
            {
                y += yDelta;

                //未执行
                index_start = this.sPaintWZX.IndexOf("i" + i.ToString() + "X", 0, this.sPaintWZX.Trim().Length);
                if (index_start >= 0)
                {
                    e.Graphics.DrawString("未执行", this.myDataGrid1.Font, new SolidBrush(Color.Red), 650, y - yDelta);
                }

                //皮试+
                index_start = this.sPaintPS.IndexOf("[" + i.ToString() + "+", 0, this.sPaintPS.Trim().Length);
                if (index_start >= 0)
                {
                    index_p = this.sPaintPS.IndexOf("+", index_start, this.sPaintPS.Trim().Length - index_start);
                    index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                    start_point = 119 + Convert.ToInt16(this.sPaintPS.Substring(index_p + 1, index_end - index_p - 1)) * 6;
                    e.Graphics.DrawString("(+)", this.myDataGrid1.Font, new SolidBrush(Color.Red), start_point, y - yDelta);

                }

                //皮试-
                index_start = this.sPaintPS.IndexOf("[" + i.ToString() + "-", 0, this.sPaintPS.Trim().Length);
                if (index_start >= 0)
                {
                    index_p = this.sPaintPS.IndexOf("-", index_start, this.sPaintPS.Trim().Length - index_start);
                    index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                    start_point = 119 + Convert.ToInt16(this.sPaintPS.Substring(index_p + 1, index_end - index_p - 1)) * 6;
                    switch (this.sPaintPS.Substring(index_end + 1, 1))
                    {
                        case "1":  //未审核
                            e.Graphics.DrawString("(-)", this.myDataGrid1.Font, new SolidBrush(Color.Black), start_point, y - yDelta);
                            break;
                        case "5":  //已停止
                            e.Graphics.DrawString("(-)", this.myDataGrid1.Font, new SolidBrush(Color.Gray), start_point, y - yDelta);
                            break;
                        default: //已审核
                            e.Graphics.DrawString("(-)", this.myDataGrid1.Font, new SolidBrush(Color.Blue), start_point, y - yDelta);
                            break;
                    }

                }

                //组线
                index_start = this.sPaint.IndexOf("[" + i.ToString() + "i", 0, this.sPaint.Trim().Length);
                if (index_start >= 0)
                {
                    index_i = index_start + i.ToString().Trim().Length + 1;
                    index_end = this.sPaint.IndexOf("]", index_i, this.sPaint.Trim().Length - index_i);
                    start_row = Convert.ToInt16(this.sPaint.Substring(index_i + 1, index_end - index_i - 1));
                    if (this.max_len1 == 0) start_point = 119 + (this.max_len0 + 4) * 6;
                    else start_point = 119 + (this.max_len1 + this.max_len2 + 4) * 6;
                    switch (this.sPaint.Substring(index_end + 1, 1))
                    {
                        case "1":  //未审核
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        case "5":  //已停止
                            e.Graphics.DrawLine(System.Drawing.Pens.Gray, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        default: //已审核
                            e.Graphics.DrawLine(System.Drawing.Pens.Blue, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                    }
                }
                i++;
            }
        }

        private void bt全选_Click(object sender, EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["status_flag"].ToString().Trim() == "1") continue;
                this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                myTb.Rows[i]["选"] = true;
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private void bt反选_Click(object sender, EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["status_flag"].ToString().Trim() == "1") continue;
                this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private void myDataGrid1_Click(object sender, EventArgs e)
        {
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0 && nrow > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            bool isResult = myTb.Rows[nrow]["选"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["选"] = isResult;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["Group_id"].ToString().Trim() == myTb.Rows[nrow]["Group_id"].ToString().Trim()
                    && myTb.Rows[i]["选"].ToString() != isResult.ToString())
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                    myTb.Rows[i]["选"] = isResult;
                    //this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
                }
            }

            this.myDataGrid1.DataSource = myTb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            FrmQFZX_Load(null,null);
            Cursor.Current = Cursors.Default;
        }


    }
}