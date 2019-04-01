using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using Ts_zyys_public;
using ts_zyhs_classes;

namespace Ts_zyys_yzgl
{
    public partial class FrmStopOrders : Form
    {
        private Guid BinID = Guid.Empty;
        private long BabyID = 0;
        private long DeptID = 0;
        private long YS_ID = 0;

        private DbQuery myQuery = new DbQuery();
        private BaseFunc myFunc = new BaseFunc();

        string sPaintLong = "", sPaintPSLong = "", sPaintWZXLong = "";//皮试，未执行
        int max_len10 = 0, max_len11 = 0, max_len12 = 0;//最长的医嘱长度,最长的医嘱长度(有数量单位的),最长的数量单位长度		
        string sPaint = "", sPaintPS = "", sPaintWZX = "";//皮试，未执行
        int max_len0 = 0, max_len1 = 0, max_len2 = 0;//最长的医嘱长度,最长的医嘱长度(有数量单位的),最长的数量单位长度	

        public FrmStopOrders(Guid _BinId, long _BabyId, long DeptID, long _YsId)
        {
            InitializeComponent();

            YS_ID = _YsId;
            BinID = _BinId;
            BabyID = _BabyId;
        }

        private void FrmStopOrders_Load(object sender, EventArgs e)
        {
            string strcfg = (new SystemCfg(6007)).Config;
            int cfg = Convert.ToInt16(strcfg);
            this.dateTimePicker1.Value = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            this.dateTimePicker1.MaxDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).AddDays(cfg);
            string longtimes = "00:00:00";
            this.dateTimePicker1.MinDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).AddDays(-cfg).ToString("yyyy-MM-dd") + " " + longtimes);

            InitGrd_LongOrder();

            DataTable myTb = myQuery.GetBinOrders(3, this.BabyID, this.BinID, this.DeptID);

            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Boolean");
            col.AllowDBNull = false;
            col.ColumnName = "选";
            col.DefaultValue = false;
            myTb.Columns.Add(col);

            DataTable myTbb = CheckGrdDataLong(myTb);

            this.dataGrid_LongOrder.DataSource = myTbb;

            //Modify By tany 2011-04-12 
            if (myTbb != null && myTbb.Rows.Count > 0)
            {
                this.dataGrid_LongOrder.CurrentRowIndex = myTbb.Rows.Count - 1;
            }

            dataGrid_LongOrder.isShowRowHeadId = true;
        }

        private void InitGrd_LongOrder()
        {
            ////增加新列
            //int i = 0;

            //DataGridEnableTextBoxColumn aColumnTextColumn;
            //dataGrid_LongOrder.TableStyles[0].GridColumnStyles.Clear();//先清空列
            //for (i = 0; i <= 19; i++)
            //{
            //    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
            //    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
            //    dataGrid_LongOrder.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);

            //}

            //dataGrid_LongOrder.RowHeaderWidth = 25; //use if no tablestyle
            ////建立网格格式
            //for (i = 0; i <= dataGrid_LongOrder.TableStyles[0].GridColumnStyles.Count - 1; i++)
            //{
            //    dataGrid_LongOrder.TableStyles[0].GridColumnStyles[i].NullText = "";
            //    this.dataGrid_LongOrder.TableStyles[0].AllowSorting = false;
            //}
            string[] GrdMapppingName = { "选", "ID", "类", "嘱号", "开始时间", "类型", "医嘱内容", "规格", "剂量", "单位", "用法", "频率", "首日执行次数", "末日次数", "剂数", "滴量", "执行护士", "执行时间", "停嘱时间", "下嘱医生", "停嘱医生", "执行科室" };
            string[] GrdHeaderText =   { "选", "ID*", "类*", "嘱号*", "录入时间", "类型*", "医嘱内容", "规格", "剂量", "单位*", "用法", "频率", "首次", "末次", "剂数", "滴量", "执行人", "执行时间*", "停嘱时间*", "下嘱医生", "停嘱医生", "执行科室*" };
            int[] GrdWidth =           { 16, 0, 0, 0, 110, 0, 230, 80, 35, 40, 55, 40, 30, 30, 0, 30, 45, 70, 70, 55, 55, 0 };
            bool[] RedOnly =           { true, true, true, true, true, true, true, true, true, true, true, true, true, false, true, true, true, true, true, true, true, true };
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
        public void InitmyGrd(string[] GrdMappingName, string[] GrdHeaderText, int[] GrdWidth, bool[] GrdReadOnly, DataGridEx myDataGrid)
        {
            //int i = 0;
            //DataTable myTb = new DataTable();

            //for (i = 0; i <= GrdMappingName.Length - 1; i++)
            //{
            //    myTb.Columns.Add(GrdMappingName[i].ToString());
            //}
            //myTb.Rows.Add(myTb.NewRow());
            //dataGrid.DataSource = myTb;
            myDataGrid.TableStyles[0].AllowSorting = false;

            myDataGrid.TableStyles[0].RowHeaderWidth = 5;
            //for (i = 0; i <= GrdMappingName.Length - 1; i++)
            //{
            //    if (GrdMappingName[i].ToString().Trim() == "选" || GrdMappingName[i].ToString().Trim() == "P")
            //    {
            //        DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
            //        if (GrdMappingName[i].ToString().Trim() == "P")
            //        {
            //            myBoolCol.AllowNull = false;
            //            myBoolCol.TrueValue = (short)1;
            //            myBoolCol.FalseValue = (short)0;
            //            myBoolCol.NullValue = (short)0;
            //        }
            //        myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
            //        dataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
            //        dataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
            //        dataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
            //    }
            //    else
            //    {
            //        dataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
            //        dataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
            //        dataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
            //        if (GrdWidth[i] != 0) dataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdHeaderText[i].ToString();
            //        dataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = GrdReadOnly[i];
            //    }
            //}
            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "选" || GrdMappingName[i].ToString().Trim() == "P")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    if (GrdMappingName[i].ToString().Trim() == "P")
                    {
                        myBoolCol.AllowNull = false;
                        myBoolCol.TrueValue = (short)1;
                        myBoolCol.FalseValue = (short)0;
                        myBoolCol.NullValue = (short)0;
                    }
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
                    myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = GrdReadOnly[i];
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
                    myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = GrdReadOnly[i];
                }
            }
        }

        private DataTable CheckGrdDataLong(DataTable myTb)
        {
            int i, j = 1;
            int grouprows = 1;
            string RowString = "";
            this.sPaintLong = "";
            int l = 0, group_rows = 1;//,max_len=0;    //同组中的医嘱个数,最长的长度		
            this.sPaintLong = "";
            this.sPaintPSLong = "";
            this.sPaintWZXLong = "";

            #region 算出长度
            max_len10 = 0;
            max_len11 = 0;
            max_len12 = 0;
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
                myTb.Rows[0]["停嘱医生"] = System.DBNull.Value;
            }
            else if ((RowString == "术后医嘱" || RowString == "产后医嘱" || RowString == "转科医嘱") && Convert.ToInt32(myTb.Rows[0]["status_flag"].ToString().Trim()) >= 1)
            {
                myTb.Rows[0]["开始时间"] = System.DBNull.Value;
                myTb.Rows[0]["剂量"] = System.DBNull.Value;
                myTb.Rows[0]["用法"] = System.DBNull.Value;
                myTb.Rows[0]["频率"] = System.DBNull.Value;
                myTb.Rows[0]["开始时间"] = System.DBNull.Value;
                myTb.Rows[0]["首日执行次数"] = System.DBNull.Value;
                myTb.Rows[0]["末日次数"] = System.DBNull.Value;
                myTb.Rows[0]["剂数"] = System.DBNull.Value;
                myTb.Rows[0]["滴量"] = System.DBNull.Value;
                myTb.Rows[0]["执行护士"] = System.DBNull.Value;
                myTb.Rows[0]["执行时间"] = System.DBNull.Value;
                myTb.Rows[0]["停嘱时间"] = System.DBNull.Value;
                myTb.Rows[0]["下嘱医生"] = System.DBNull.Value;
                myTb.Rows[0]["停嘱医生"] = System.DBNull.Value;
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
                        myTb.Rows[i]["停嘱医生"] = System.DBNull.Value;
                    }
                    else if ((RowString == "术后医嘱" || RowString == "产后医嘱" || RowString == "转科医嘱") && Convert.ToInt32(myTb.Rows[i]["status_flag"].ToString().Trim()) >= 1)
                    {
                        myTb.Rows[i]["开始时间"] = System.DBNull.Value;
                        myTb.Rows[i]["剂量"] = System.DBNull.Value;
                        myTb.Rows[i]["用法"] = System.DBNull.Value;
                        myTb.Rows[i]["频率"] = System.DBNull.Value;
                        myTb.Rows[i]["开始时间"] = System.DBNull.Value;
                        myTb.Rows[i]["首日执行次数"] = System.DBNull.Value;
                        myTb.Rows[i]["末日次数"] = System.DBNull.Value;
                        myTb.Rows[i]["剂数"] = System.DBNull.Value;
                        myTb.Rows[i]["滴量"] = System.DBNull.Value;
                        myTb.Rows[i]["执行护士"] = System.DBNull.Value;
                        myTb.Rows[i]["执行时间"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱时间"] = System.DBNull.Value;
                        myTb.Rows[i]["下嘱医生"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱医生"] = System.DBNull.Value;
                    }
                    if (myTb.Rows[i]["status_flag"].ToString().Trim() == "2") myTb.Rows[i]["停嘱时间"] = System.DBNull.Value;//取消欲停恢复有效长嘱后


                    //如果一组中的医嘱个数大于1
                    if (group_rows != 1)
                    {
                        //[3i2]0 代表第三行是一组医嘱的最后一条，该组医嘱有两条医嘱，status_flag=0
                        this.sPaintLong += "[" + i.ToString() + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i - 1]["status_flag"].ToString().Trim();
                    }
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
                        myTb.Rows[i]["末日次数"] = System.DBNull.Value;
                        myTb.Rows[i]["剂数"] = System.DBNull.Value;
                        myTb.Rows[i]["滴量"] = System.DBNull.Value;
                        if (j != grouprows)
                        {
                            myTb.Rows[i]["执行护士"] = System.DBNull.Value;
                            myTb.Rows[i]["执行时间"] = System.DBNull.Value;
                            myTb.Rows[i]["下嘱医生"] = System.DBNull.Value;
                            myTb.Rows[i]["停嘱医生"] = System.DBNull.Value;
                        }
                        if (myTb.Rows[i]["status_flag"].ToString().Trim() == "2") myTb.Rows[i]["停嘱时间"] = System.DBNull.Value;//取消欲停恢复有效长嘱后

                        if (myTb.Rows[i]["类型"].ToString() == "1-西药" || myTb.Rows[i]["类型"].ToString() == "2-中成药" || myTb.Rows[i]["类型"].ToString() == "3-中草药") group_rows += 1;
                        if (i == myTb.Rows.Count - 1 && j > 1 && group_rows != 1)
                        {
                            this.sPaintLong += "[" + Convert.ToString(i + 1) + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i]["status_flag"].ToString().Trim();
                        }

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

                #region //显示未执行
                //				if (myTb.Rows[i]["c1"].ToString().Trim().IndexOf("X",0,myTb.Rows[i]["c1"].ToString().Trim().Length)>=0)
                //				{
                //					this.sPaintWZXLong+="i"+i.ToString()+"X";
                //				}
                #endregion

                #region 显示皮试
                //if (myTb.Rows[i]["c1"].ToString().Trim().IndexOf("+",0,myTb.Rows[i]["c1"].ToString().Trim().Length)>=0)
                if (myTb.Rows[i]["ps_flag"].ToString() == "2")
                {
                    this.sPaintPSLong += "[" + i.ToString() + "+" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim()) + "]";
                }
                //if (myTb.Rows[i]["c1"].ToString().Trim().IndexOf("-",0,myTb.Rows[i]["c1"].ToString().Trim().Length)>=0)
                if (myTb.Rows[i]["ps_flag"].ToString() == "1")
                {
                    this.sPaintPSLong += "[" + i.ToString() + "-" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim()) + "]" + myTb.Rows[i]["status_flag"].ToString().Trim();
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

        public void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;
            DataTable myTb = new DataTable();
            myTb = (DataTable)this.dataGrid_LongOrder.DataSource;
            if (myTb == null) return;
            try
            {
                //通过医嘱的status_flag来设置
                if (myTb.Rows[e.Row]["ID"].ToString().Trim() == "" || new Guid(myTb.Rows[e.Row]["ID"].ToString()) == Guid.Empty)
                {
                    e.BackColor = Color.FromArgb(240, 240, 240);
                }
                if (myTb.Rows[e.Row]["status_flag"].ToString() == "0" || myTb.Rows[e.Row]["status_flag"].ToString() == "9")
                {
                    //				e.BackColor=Color.FromArgb(240,240,240);
                    e.BackColor = Color.Pink;
                }
                else if (myTb.Rows[e.Row]["status_flag"].ToString() == "1")
                {
                    e.ForeColor = Color.SeaGreen;
                }
                else if (myTb.Rows[e.Row]["status_flag"].ToString() == "2")
                {
                    e.ForeColor = Color.Blue;
                }
                else if (myTb.Rows[e.Row]["status_flag"].ToString() == "3")
                {
                    e.ForeColor = Color.Gray;
                }
                if (myTb.Rows[e.Row]["医嘱内容"].ToString().Trim() == "术后医嘱" || myTb.Rows[e.Row]["医嘱内容"].ToString().Trim() == "产后医嘱")
                {
                    e.ForeColor = Color.Red;
                }
                if (myTb.Rows[e.Row]["选"].ToString() == "True")
                {
                    e.BackColor = Color.GreenYellow;
                }
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGrid_LongOrder_Paint(object sender, PaintEventArgs e)
        {
            if (this.dataGrid_LongOrder.DataSource == null) return;
            int i = 0;
            int yDelta = dataGrid_LongOrder.GetCellBounds(i, 0).Height + 1;
            int y = dataGrid_LongOrder.GetCellBounds(i, 0).Top + 2;
            int index_start = 0, index_i = 0, index_p = 0, index_end = 0;
            int start_row = 0, start_point = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[dataGrid_LongOrder.DataSource, dataGrid_LongOrder.DataMember];
            while (y < dataGrid_LongOrder.Height - yDelta && i <= cm.Count)
            {
                //get & draw the header text...
                //y+= yDelta;
                //皮试+
                index_start = this.sPaintPSLong.IndexOf("[" + i.ToString() + "+", 0, this.sPaintPSLong.Trim().Length);
                if (index_start >= 0)
                {
                    index_p = this.sPaintPSLong.IndexOf("+", index_start, this.sPaintPSLong.Trim().Length - index_start);
                    index_end = this.sPaintPSLong.IndexOf("]", index_p, this.sPaintPSLong.Trim().Length - index_p);
                    start_point = 145 + Convert.ToInt16(this.sPaintPSLong.Substring(index_p + 1, index_end - index_p - 1)) * 6;
                    e.Graphics.DrawString("(+)", this.dataGrid_LongOrder.Font, new SolidBrush(Color.Red), start_point, y);
                }

                //皮试-
                index_start = this.sPaintPSLong.IndexOf("[" + i.ToString() + "-", 0, this.sPaintPSLong.Trim().Length);
                if (index_start >= 0)
                {
                    index_p = this.sPaintPSLong.IndexOf("-", index_start, this.sPaintPSLong.Trim().Length - index_start);
                    index_end = this.sPaintPSLong.IndexOf("]", index_p, this.sPaintPSLong.Trim().Length - index_p);
                    start_point = 125 + Convert.ToInt16(this.sPaintPSLong.Substring(index_p + 1, index_end - index_p - 1)) * 6;
                    switch (this.sPaintPSLong.Substring(index_end + 1, 1))
                    {
                        case "2":  //已审核
                            e.Graphics.DrawString("  (-)", this.dataGrid_LongOrder.Font, new SolidBrush(Color.Blue), start_point, y);
                            break;
                        case "5":  //已停止
                            e.Graphics.DrawString("  (-)", this.dataGrid_LongOrder.Font, new SolidBrush(Color.Gray), start_point, y);
                            break;
                        default:
                            e.Graphics.DrawString("  (-)", this.dataGrid_LongOrder.Font, new SolidBrush(Color.Black), start_point, y);
                            break;
                    }
                }

                //组线
                index_start = this.sPaintLong.IndexOf("[" + i.ToString() + "i", 0, this.sPaintLong.Trim().Length);
                if (index_start >= 0)
                {
                    index_i = index_start + i.ToString().Trim().Length + 1;
                    index_end = this.sPaintLong.IndexOf("]", index_i, this.sPaintLong.Trim().Length - index_i);
                    start_row = Convert.ToInt16(this.sPaintLong.Substring(index_i + 1, index_end - index_i - 1));
                    if (this.max_len11 == 0) start_point = 150 + (this.max_len10 + 4) * 6;
                    else start_point = 150 + (this.max_len11 + this.max_len12 + 4) * 6;
                    switch (this.sPaintLong.Substring(index_end + 1, 1))
                    {
                        case "1":  //已发送未转抄
                            e.Graphics.DrawLine(System.Drawing.Pens.SeaGreen, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        case "2":  //已审核
                            e.Graphics.DrawLine(System.Drawing.Pens.Blue, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        case "3":  //欲停
                            e.Graphics.DrawLine(System.Drawing.Pens.Gray, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        case "5":  //已停止
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        default:
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                    }
                }

                i++;
                y += yDelta;
            }
        }

        private void dataGrid_LongOrder_Click(object sender, EventArgs e)
        {
            //控制BOOL列
            int nrow, ncol;
            nrow = this.dataGrid_LongOrder.CurrentCell.RowNumber;
            ncol = this.dataGrid_LongOrder.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0 && nrow > 0) this.dataGrid_LongOrder.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.dataGrid_LongOrder.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.dataGrid_LongOrder.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            //非"选"字段
            if (this.dataGrid_LongOrder.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() != "选") return;
            if (nrow > myTb.Rows.Count - 1) return;

            if (myTb.Rows[nrow]["选"].ToString().Trim() == "1")
            {
                myTb.Rows[nrow]["选"] = false;
                return;
            }

            bool isResult = myTb.Rows[nrow]["选"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["选"] = isResult;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["嘱号"].ToString().Trim() == myTb.Rows[nrow]["嘱号"].ToString().Trim()
                    && myTb.Rows[i]["选"].ToString() != isResult.ToString())
                {
                    this.dataGrid_LongOrder.CurrentCell = new DataGridCell(i, ncol);
                    myTb.Rows[i]["选"] = isResult;
                    //this.dataGrid_LongOrder.CurrentCell=new DataGridCell(i,ncol);	
                }
            }

            this.dataGrid_LongOrder.DataSource = myTb;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int iSelectRows = 0;
            int GroupID = -999;
            DataTable myTb = (DataTable)dataGrid_LongOrder.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            #region 有效性判断
            if (radBt2.Checked)
            {
                if (!Convertor.IsNumeric(numericUpDown1.Value.ToString()))
                {
                    MessageBox.Show("请输入有效的末日次数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    numericUpDown1.Focus();
                    return;
                }
            }
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True")
                {
                    iSelectRows += 1;
                    //如果组号与上一条医嘱相同，则不判断
                    if (GroupID == Convert.ToInt32(myTb.Rows[i]["嘱号"]))
                    {
                        continue;
                    }
                    if (radBt3.Checked)
                    {
                        if (!Convertor.IsNumeric(myTb.Rows[i]["末日次数"].ToString()))
                        {
                            MessageBox.Show("请输入有效的末日次数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            dataGrid_LongOrder.Focus();
                            dataGrid_LongOrder.CurrentCell = new DataGridCell(i, 13);
                            return;
                        }
                    }
                    GroupID = Convert.ToInt32(myTb.Rows[i]["嘱号"]);
                }
            }
            #endregion

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "对不起，没有选择医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int iDays = ((TimeSpan)(dateTimePicker1.Value - DateManager.ServerDateTimeByDBType(InstanceForm._database))).Days;

            if (MessageBox.Show(this, "停止日期与当前日期相差：【" + iDays + "天】\r\r您确认停止医嘱吗?", "停医嘱", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (MessageBox.Show(this, "您确认停止医嘱吗?", "停医嘱", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(6023).Config == "0")
            {
                string dlgvalue = DlgPW.Show();
                string pwStr = dlgvalue; //YS.Password;
                bool bOk = InstanceForm._currentUser.CheckPassword(pwStr);
                if (!bOk)
                {
                    FrmMessageBox.Show("你没有通过权限确认，不能发送医嘱！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            int num = 0;

            try
            {
                GroupID = -999;
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    //如果是选择发送
                    if (myTb.Rows[i]["选"].ToString() == "False")
                        continue;

                    //如果组号与上一条医嘱相同，则不执行
                    if (GroupID == Convert.ToInt32(myTb.Rows[i]["嘱号"]))
                    {
                        continue;
                    }

                    if (radBt1.Checked == true)
                    {
                        num = -1;
                    }
                    else if (radBt2.Checked)
                    {
                        num = Convert.ToInt16(this.numericUpDown1.Value);
                    }
                    else
                    {
                        num = Convert.ToInt32(myTb.Rows[i]["末日次数"]);
                    }

                    GroupID = Convert.ToInt32(myTb.Rows[i]["嘱号"]);

                    myQuery.StopOrders(YS_ID, this.dateTimePicker1.Value, num, GroupID, Guid.Empty, BinID, BabyID, 0);//停一组

                }

                MessageBox.Show("停医嘱成功！");

                string binSql = "select * from vi_zy_vinpatient_bed where inpatient_id='" + BinID + "' and baby_id=" + BabyID;
                DataTable binTb = FrmMdiMain.Database.GetDataTable(binSql);
                string msg_wardid = InstanceForm._currentDept.WardId;
                long msg_deptid = 0;
                long msg_empid = 0;
                string msg_sender = FrmMdiMain.CurrentDept.DeptName + "：" + FrmMdiMain.CurrentUser.Name;
                string msg_msg = binTb.Rows[0]["bed_no"].ToString().Trim() + " 床 " + binTb.Rows[0]["name"].ToString().Trim() + " 有停医嘱，请处理！";
                TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.住院护士站, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void btnqx_Click(object sender, EventArgs e)
        {
            DataTable myTb = (DataTable)dataGrid_LongOrder.DataSource;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                 myTb.Rows[i]["选"] = "True";      
            }
        }

        private void btnfx_Click(object sender, EventArgs e)
        {
            DataTable myTb = (DataTable)dataGrid_LongOrder.DataSource;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
               if( myTb.Rows[i]["选"].ToString() == "True")
                   myTb.Rows[i]["选"] = "False"; 
               else
                   myTb.Rows[i]["选"]= "True"; 
            }
        }
    }
}