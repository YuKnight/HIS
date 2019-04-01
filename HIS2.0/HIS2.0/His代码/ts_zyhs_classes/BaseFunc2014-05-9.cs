using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_yzgl;
using Ts_Clinicalpathway_Factory;
namespace ts_zyhs_classes
{
    /// <summary>
    /// 护士站的基本函数
    /// </summary>
    public class BaseFunc
    {
        private RelationalDatabase database;
        /// <summary>
        /// 临床路径接口
        /// </summary>
        Ts_Clinicalpathway_Factory.ts_cp_interface Cpinterface;
        public BaseFunc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            database = FrmMdiMain.Database;
        }

        //Add By tany 2011-06-20 增加数据库连接
        public BaseFunc(RelationalDatabase db)
        {
            database = db;
        }

        /// <summary>
        /// 初始化datagird
        /// </summary>
        /// <param name="GrdMappingName"></param> MappingName数组
        /// <param name="GrdHeaderText"></param>  GrdHeaderText数组
        /// <param name="GrdWidth"></param> Width数组
        /// <param name="myTb"></param> 
        /// <param name="dataGrid1"></param>
        public void InitGrd(string[] GrdMappingName, string[] GrdHeaderText, int[] GrdWidth, DataGrid dataGrid)
        {
            DataTable myTb = new DataTable();

            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                myTb.Columns.Add(GrdMappingName[i].ToString());
            }
            myTb.Rows.Add(myTb.NewRow());
            dataGrid.DataSource = myTb;

            InitGrd_sub(GrdMappingName, GrdHeaderText, GrdWidth, dataGrid);
            /*
            dataGrid.TableStyles[0].RowHeaderWidth=15;	
            for(i=0;i<=dataGrid.TableStyles[0].GridColumnStyles.Count-1;i++)
            {
                dataGrid.TableStyles[0].GridColumnStyles[i].NullText="";
                dataGrid.TableStyles[0].GridColumnStyles[i].MappingName=GrdMappingName[i].ToString();
                dataGrid.TableStyles[0].GridColumnStyles[i].Width=GrdWidth[i];
                if (GrdWidth[i]!=0) dataGrid.TableStyles[0].GridColumnStyles[i].HeaderText=GrdHeaderText[i].ToString();
            }
            */
        }

        /// <summary>
        /// 初始化网格
        /// </summary>
        /// <param name="GrdMappingName"></param>
        /// <param name="GrdHeaderText"></param>
        /// <param name="GrdWidth"></param>
        /// <param name="dataGrid"></param>
        public void InitGrd_sub(string[] GrdMappingName, string[] GrdHeaderText, int[] GrdWidth, DataGrid dataGrid)
        {
            dataGrid.TableStyles[0].RowHeaderWidth = 15;
            for (int i = 0; i <= dataGrid.TableStyles[0].GridColumnStyles.Count - 1; i++)
            {
                dataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
                dataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                dataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
                if (GrdWidth[i] != 0) dataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdHeaderText[i].ToString();
            }
        }


        /// <summary>
        /// 初始化mydatagird
        /// </summary>
        /// <param name="GrdMappingName"></param> MappingName数组
        /// <param name="GrdHeaderText"></param>  GrdHeaderText数组
        /// <param name="GrdWidth"></param>       Width数组
        /// <param name="GrdReadOnly"></param>    ReadOnly数组
        /// <param name="mydataGrid"></param>
        public void InitmyGrd(string[] GrdMappingName, string[] GrdHeaderText, int[] GrdWidth, bool[] GrdReadOnly, DataGridEx mydataGrid)
        {
            int i = 0;
            DataTable myTb = new DataTable();

            for (i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                myTb.Columns.Add(GrdMappingName[i].ToString());
            }
            myTb.Rows.Add(myTb.NewRow());
            mydataGrid.DataSource = myTb;

            mydataGrid.TableStyles[0].RowHeaderWidth = 5;
            for (i = 0; i <= mydataGrid.TableStyles[0].GridColumnStyles.Count - 1; i++)
            {
                mydataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
                mydataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                mydataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
                if (GrdWidth[i] != 0) mydataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdHeaderText[i].ToString();
                mydataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = GrdReadOnly[i];
            }
        }
/// <summary>
/// 
/// </summary>
/// <param name="sSql"></param>
/// <param name="GrdMappingName"></param>
/// <param name="GrdWidth"></param>
/// <param name="Alignment"></param>
/// <param name="myDataGrid"></param>
        public void InitGridSQL(string sSql, string[] GrdMappingName, int[] GrdWidth, int[] Alignment, DataGridEx myDataGrid)
        {
            DataTable myTb = database.GetDataTable(sSql);
            myTb.TableName = "yyy";
            myDataGrid.DataSource = myTb;
            myDataGrid.TableStyles[0].MappingName = myTb.TableName;
            myDataGrid.TableStyles[0].RowHeaderWidth = 5;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                this.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
            }
        }

        public void InitGrid(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            DataGridEnableTextBoxColumn aColumnTextColumn;

            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "选")
                {
                    myDataGrid.Tag = "包含选择列";
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    myBoolCol.NullValue = false;
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : GrdWidth[i] * 7 + 2;
                    myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = false;
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    aColumnTextColumn.NullText = "";
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    this.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = false;
                    else myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        public void InitGrid(string[] GrdMappingName, string[] GrdHeaderText, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            DataGridEnableTextBoxColumn aColumnTextColumn;

            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "选")
                {
                    myDataGrid.Tag = "包含选择列";
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    myBoolCol.NullValue = false;
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdHeaderText[i].ToString().Trim();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : GrdWidth[i] * 7 + 2;
                    myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = false;
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    aColumnTextColumn.NullText = "";
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdHeaderText[i].ToString().Trim();
                    this.InitGrid_Sub(i, GrdMappingName, GrdHeaderText, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = false;
                    else myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        public void InitGridEx(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            DataGridTextBoxColumn aColumnTextColumn;

            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "选")
                {
                    myDataGrid.Tag = "包含选择列";
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    myBoolCol.NullValue = false;
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : GrdWidth[i] * 7 + 2;
                    myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = false;
                }
                else
                {
                    aColumnTextColumn = new DataGridTextBoxColumn();
                    aColumnTextColumn.NullText = "";
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    this.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = false;
                    else myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        public void InitGridEx(string[] GrdMappingName, string[] GrdHeaderText, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            DataGridTextBoxColumn aColumnTextColumn;

            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                aColumnTextColumn = new DataGridTextBoxColumn();
                aColumnTextColumn.NullText = "";
                myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdHeaderText[i].ToString().Trim();
                this.InitGrid_Sub(i, GrdMappingName, GrdHeaderText, GrdWidth, Alignment, myDataGrid);
                if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = false;
                else myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
            }
        }

        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;

            string TypeStr = sender.GetType().ToString();
            if (sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn"
                || sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn")
            {

                DataGridEx DataGrid = new DataGridEx();
                switch (TypeStr)
                {
                    case "TrasenClasses.GeneralControls.DataGridEnableBoolColumn":
                        {
                            DataGrid = (TrasenClasses.GeneralControls.DataGridEx)((((TrasenClasses.GeneralControls.DataGridEnableBoolColumn)sender).DataGridTableStyle).DataGrid);
                            break;
                        }
                    case "TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn":
                        {
                            DataGrid = (TrasenClasses.GeneralControls.DataGridEx)((((TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn)sender).DataGridTableStyle).DataGrid);
                            break;
                        }
                }

                DataTable myTb = (DataTable)DataGrid.DataSource;
                if (myTb == null || myTb.Rows.Count == 0)
                    return;

                int nrow = e.Row;

                if (nrow >= myTb.Rows.Count)
                    return;

                if (Convertor.IsNull(DataGrid.Tag, "") == "包含选择列")
                {
                    if (myTb.Rows[nrow]["选"].ToString() == "True")
                    {
                        e.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        e.BackColor = Color.White;
                    }
                }

                //Add By Tany 2011-06-07 增加默认颜色
                if (myTb.Columns.Contains("颜色"))
                {
                    try
                    {
                        if (myTb.Columns.Contains("项目内容"))
                        {
                            if (myTb.Columns[e.Col - 1].ColumnName == "项目内容")
                            {
                                string _color = Convertor.IsNull(myTb.Rows[nrow]["颜色"], "");
                                if (_color != "")
                                {
                                    Color cl = Color.FromName(_color); 
                                    if (cl.ToArgb() != 0)
                                    {
                                       e.BackColor = cl;
                                       // e.ForeColor = Color.White;
                                    }
                                }
                            }
                        }
                        //add by zouchihua 2013-1-14已经执行过
                        if (myTb.Columns.Contains("最近执行日期"))
                        {
                             
                                string _color = Convertor.IsNull(myTb.Rows[nrow]["颜色"], "");
                                if (_color != "")
                                {
                                    Color cl = Color.FromName(_color); 
                                    if (cl.ToArgb() != 0)
                                    {
                                        //e.BackColor = cl;
                                        e.ForeColor = Color.Red;
                                    }
                                }
                            
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        public void InitGrid_Sub(int i, string[] GrdMappingName, int[] GrdWidth, int[] Alignment, DataGridEx myDataGrid)
        {
            string s = "";

            myDataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
            myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : GrdWidth[i] * 7 + 2;
            if (GrdWidth[i] != 0)
            {
                s = this.Repeat_Space((GrdWidth[i] - GrdMappingName[i].ToString().Trim().Length * 2) / 2);
                switch (Alignment[i])
                {
                    case 0:  //左
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = s + GrdMappingName[i].ToString().Trim();
                        break;
                    case 1:  //中
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                        myDataGrid.TableStyles[0].GridColumnStyles[i].Alignment = HorizontalAlignment.Center;
                        break;
                    case 2:  //右
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim() + s;
                        myDataGrid.TableStyles[0].GridColumnStyles[i].Alignment = HorizontalAlignment.Right;
                        break;
                }
            }
        }

        public void InitGrid_Sub(int i, string[] GrdMappingName, string[] GrdHeaderText, int[] GrdWidth, int[] Alignment, DataGridEx myDataGrid)
        {
            string s = "";

            myDataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
            myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : GrdWidth[i] * 7 + 2;
            if (GrdWidth[i] != 0)
            {
                s = this.Repeat_Space((GrdWidth[i] - GrdHeaderText[i].ToString().Trim().Length * 2) / 2);
                switch (Alignment[i])
                {
                    case 0:  //左
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = s + GrdHeaderText[i].ToString().Trim();
                        break;
                    case 1:  //中
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdHeaderText[i].ToString().Trim();
                        myDataGrid.TableStyles[0].GridColumnStyles[i].Alignment = HorizontalAlignment.Center;
                        break;
                    case 2:  //右
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdHeaderText[i].ToString().Trim() + s;
                        myDataGrid.TableStyles[0].GridColumnStyles[i].Alignment = HorizontalAlignment.Right;
                        break;
                }
            }
        }

        public void ShowGrid(int isSelect, string sSql, DataGridEx myDataGrid)
        {
            DataTable myTb = new DataTable();
            myTb = database.GetDataTable(sSql, 60);

            if (isSelect == 1)
            {
                DataColumn col = new DataColumn();
                col.DataType = System.Type.GetType("System.Boolean");
                col.AllowDBNull = false;
                col.ColumnName = "选";
                col.DefaultValue = false;
                myTb.Columns.Add(col);
            }

            myDataGrid.BeginInit();
            myDataGrid.DataSource = myTb;
            myDataGrid.EndInit();
            myDataGrid.TableStyles[0].RowHeaderWidth = 5;
        }

        public void ShowGrid(int isSelect, string sSql, DataGridEx myDataGrid, int nStyleIdx)
        {
            DataTable myTb = new DataTable();
            myTb = database.GetDataTable(sSql);

            if (isSelect == 1)
            {
                DataColumn col = new DataColumn();
                col.DataType = System.Type.GetType("System.Boolean");
                col.AllowDBNull = false;
                col.ColumnName = "选";
                col.DefaultValue = false;
                myTb.Columns.Add(col);
            }

            myDataGrid.BeginInit();
            myDataGrid.DataSource = myTb;
            myDataGrid.EndInit();
            myDataGrid.TableStyles[0].RowHeaderWidth = 5;

            PubStaticFun.ModifyDataGridStyle(myDataGrid, nStyleIdx);
        }

        public void SelCol_Click(DataGridEx myDataGrid)
        {
            //控制BOOL列			
            int nrow = myDataGrid.CurrentCell.RowNumber;
            int ncol = myDataGrid.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0 && nrow >= 0) myDataGrid.CurrentCell = new DataGridCell(nrow, ncol - 1);
            myDataGrid.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = (DataTable)myDataGrid.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            //非"选"字段
            if (myDataGrid.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() != "选") return;
            if (nrow > myTb.Rows.Count - 1) return;

            bool isResult = myTb.Rows[nrow]["选"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["选"] = isResult;

            myDataGrid.DataSource = myTb;
        }

        //kind 0 全选   1反选  2全部不选
        public void SelectAll(int kind, DataGridEx myDataGrid)
        {
            DataTable myTb = ((DataTable)myDataGrid.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "1") continue;
                myDataGrid.CurrentCell = new DataGridCell(i, 0);
                if (kind == 0)
                {
                    myTb.Rows[i]["选"] = true;
                }
                else if (kind == 1)
                {
                    myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
                }
                else
                {
                    myTb.Rows[i]["选"] = false;
                }
            }
            myDataGrid.DataSource = myTb;
        }

        public int SelRow(DataGridEx myDataGrid)
        {
            DataTable myTb = (DataTable)myDataGrid.DataSource;
            if (myTb == null) return 0;
            if (myTb.Rows.Count == 0) return -1;
            int nrow = myDataGrid.CurrentCell.RowNumber;
            myDataGrid.Select(nrow);
            return nrow;
        }

        //isSet 是否设置当前病人
        public void SelectBin(bool isSet, DataGridEx myDataGrid, int Index_BinID, int Index_Baby, int Index_curdept, int Index_isMY)
        {
            bool isSelect = false;
            DataTable myTb = (DataTable)myDataGrid.DataSource;

            if (myTb == null || myTb.Rows.Count == 0)
            {
                return;
            }

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if ((Convert.ToString(myDataGrid[i, Index_BinID]).Trim() == ClassStatic.Current_BinID.ToString().Trim()) && (Convert.ToString(myDataGrid[i, Index_Baby]).Trim() == ClassStatic.Current_BabyID.ToString()))
                {
                    //选择当前病人
                    myDataGrid.CurrentRowIndex = i;
                    isSelect = true;
                    break;
                }
            }

            if (isSelect == false)
            {
                //选择第一个病人
                myDataGrid.CurrentRowIndex = 0;
                if (isSet)
                {
                    ClassStatic.Current_BinID = new Guid(myDataGrid[0, Index_BinID].ToString());
                    ClassStatic.Current_BabyID = Convert.ToInt64(myDataGrid[0, Index_Baby]);
                    ClassStatic.Current_DeptID = Convert.ToInt64(myDataGrid[0, Index_curdept]);
                    ClassStatic.Current_isMY = Convert.ToInt16(myDataGrid[0, Index_isMY]);
                }
            }
            int nrow = myDataGrid.CurrentCell.RowNumber;
            myDataGrid.Select(nrow);
        }

        //Modify By Tany 2010-01-28 重载
        public void SelectBin(bool isSet, DataGridEx myDataGrid, string Index_BinID, string Index_Baby, string Index_curdept, string Index_isMY)
        {
            bool isSelect = false;
            DataTable myTb = (DataTable)myDataGrid.DataSource;

            if (myTb == null || myTb.Rows.Count == 0)
            {
                return;
            }

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if ((Convert.ToString(myTb.Rows[i][Index_BinID]).Trim() == ClassStatic.Current_BinID.ToString().Trim()) && (Convert.ToString(myTb.Rows[i][Index_Baby]).Trim() == ClassStatic.Current_BabyID.ToString()))
                {
                    //选择当前病人
                    myDataGrid.CurrentRowIndex = i;
                    isSelect = true;
                    break;
                }
            }

            if (isSelect == false)
            {
                //选择第一个病人
                myDataGrid.CurrentRowIndex = 0;
                if (isSet)
                {
                    ClassStatic.Current_BinID = new Guid(myTb.Rows[0][Index_BinID].ToString());
                    ClassStatic.Current_BabyID = Convert.ToInt64(myTb.Rows[0][Index_Baby]);
                    ClassStatic.Current_DeptID = Convert.ToInt64(myTb.Rows[0][Index_curdept]);
                    ClassStatic.Current_isMY = Convert.ToInt16(myTb.Rows[0][Index_isMY]);
                }
            }
            int nrow = myDataGrid.CurrentCell.RowNumber;
            myDataGrid.Select(nrow);
        }

        //返回指定长度len的空格字符串
        public string Repeat_Space(int len)
        {
            string s = "";
            if (len > 0)
            {
                for (int i = 0; i <= len - 1; i++)
                {
                    s += " ";
                }
            }
            return s;
        }

        public void InidNamecomboBox(ComboBox comboBox1)
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();

            string sSql = "SELECT A.NAME,a.BABY_ID from vi_ZY_vInpatient_All a,zy_beddiction b" +
                    " where a.INPATIENT_ID=b.INPATIENT_ID and a.Bed_ID=b.bed_id " +
                    "       and a.INPATIENT_ID='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID +
                    " order by a.BABY_ID";
            DataTable tempTab = database.GetDataTable(sSql);
            ClassStatic.MYTS_Count = tempTab.Rows.Count;
            if (ClassStatic.MYTS_Count == 0)
            {
                comboBox1.Items.Clear();
                return;
            }
            for (int i = 0; i <= tempTab.Rows.Count - 1; i++)
            {
                ClassStatic.MYTS_Name[i] = tempTab.Rows[i]["NAME"].ToString().Trim();
                ClassStatic.MYTS_BabyID[i] = tempTab.Rows[i]["BABY_ID"].ToString().Trim();
                comboBox1.Items.Add(ClassStatic.MYTS_Name[i]);
                if (ClassStatic.MYTS_BabyID[i] == ClassStatic.Current_BabyID.ToString())
                {
                    comboBox1.Text = ClassStatic.MYTS_Name[i];
                }
            }
        }

        public void NamecomboBox_SelectedIndexChanged(ComboBox comboBox1)
        {
            ClassStatic.Current_BabyID = Convert.ToInt64(ClassStatic.MYTS_BabyID[comboBox1.SelectedIndex]);
        }

        //病人是否是母婴同室的婴儿
        public bool isMYTSBaby(int isMYTS, long Baby_ID)
        {
            if (isMYTS == 0)
                return false;
            if (Baby_ID == 0)
                return false;
            else
                return true;
        }

        public string getTime(string sHour, string sMinute)
        {
            if (sHour == "") return "";
            if (sMinute.Length == 1) return sHour + ":0" + sMinute;
            else return sHour + ":" + sMinute;
        }

        public string getDate(string sMonth, string sDay)
        {
            if (sMonth == "") return "";
            if (sDay.Length == 1) return sMonth + "-0" + sDay;
            else return sMonth + "-" + sDay;
        }

        public bool IsFCK() //检查是否妇产科，如果不是则退出
        {
            bool IsFCK = false;

            SystemCfg cfg = new SystemCfg(7010);
            //Modify By tany 2010-11-26 更改产科判断方式，支持多个产科
            string[] fckId = cfg.Config.Split(',');

            for (int i = 0; i < fckId.Length; i++)
            {
                if (fckId[i].Trim() == FrmMdiMain.CurrentDept.WardId)
                {
                    IsFCK = true;
                    break;
                }
            }

            return IsFCK;
        }

        //Modify By tany 2011-03-07 重载
        public bool IsFCK(string ward_id) //检查是否妇产科，如果不是则退出
        {
            bool IsFCK = false;

            SystemCfg cfg = new SystemCfg(7010);
            //Modify By tany 2010-11-26 更改产科判断方式，支持多个产科
            string[] fckId = cfg.Config.Split(',');

            for (int i = 0; i < fckId.Length; i++)
            {
                if (fckId[i].Trim() == ward_id.Trim())
                {
                    IsFCK = true;
                    break;
                }
            }

            return IsFCK;
        }

        //医嘱显像卡
        public DataTable GetSelCard(string sSql, string SelData, int SelType)
        {
            DataTable myTb = new DataTable();

            sSql = "SELECT AA.拼音码 ,AA.医嘱内容 as 内容, AA.单位,AA.单价,1 as 剂量," +
                "       CAST(CAST(ORDER_ID AS INT) AS CHARACTER(10) ) AS 医嘱编号,Hoicode as 标准码,Order_Type as type " +
                "  FROM (SELECT  a.order_name as 医嘱内容,order_unit as 单位,cost_price as 单价,a.py_code as 拼音码," +
                "                default_dept,a.ORDER_ID,a.Order_Type,a.Hoicode " +
                "          FROM  jc_HOItemDiction a,jc_HOI_HDI b,jc_HSItemDiction c " +
                "         WHERE a.ORDER_ID=b.Hoitem_id and c.item_id=b.Hditem_id and a.delete_bit=0 )  AS AA ";

            try
            {
                myTb = database.GetDataTable(sSql);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //返回数据表对象
            return myTb;
        }

        /// <summary>
        /// 病人医嘱查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetBinOrdrs(string sSql, Guid BinID, long BabyID, int SelType, int SelKind, long Doc, DateTime ExecDate, string ward_id, long dept_id)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[8];

            sSql = "sp_zyhs_orders_select";
            parameters[0].Value = BinID;
            parameters[0].Text = "@binid";
            parameters[1].Value = BabyID;
            parameters[1].Text = "@babyid";
            parameters[2].Value = SelType;
            parameters[2].Text = "@seltype";
            parameters[3].Value = SelKind;
            parameters[3].Text = "@selkind";
            parameters[4].Value = Doc;
            parameters[4].Text = "@doc";
            parameters[5].Value = ExecDate;
            parameters[5].Text = "@execdate";
            parameters[6].Value = ward_id;
            parameters[6].Text = "@wardid";
            parameters[7].Value = dept_id;
            parameters[7].Text = "@deptid";

            try
            {
                int groupId = 0;
                int j = 0;
                myTb = database.GetDataTable(sSql, parameters, 120);
                SystemCfg cfg6084 = new SystemCfg(6084);
                if (SelType == 0 && cfg6084.Config.Trim() == "0")
                {
                    //长期医嘱也不显示明细 
                    for (int i = 0; i - j < myTb.Rows.Count; i++)
                    {
                        if (groupId == int.Parse(myTb.Rows[i - j]["GROUP_ID"].ToString()))
                        {
                            myTb.Rows.RemoveAt(i - j);
                            j++;
                        }
                        else if (int.Parse(myTb.Rows[i - j]["STATUS_FLAG"].ToString()) >= 2 && int.Parse(myTb.Rows[i - j]["ntype"].ToString()) == 3)
                        {
                            myTb.Rows[i - j]["ORDER_ID"] = new Guid("00000000-0000-0000-0000-000000000000");
                            myTb.Rows[i - j]["UNIT"] = "付";
                            myTb.Rows[i - j]["num"] = myTb.Rows[i - j]["DOSAGE"];
                            myTb.Rows[i - j]["医嘱内容"] = (myTb.Rows[i - j]["医嘱内容"].ToString().Contains("取消") ? "【取消】" : "") + "中草药处方";
                            groupId = int.Parse(myTb.Rows[i - j]["GROUP_ID"].ToString());
                        }

                    }
                }
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //返回数据表对象
            return myTb;
        }

        /// <summary>
        /// 病人医嘱查询-手术麻醉
        /// </summary>
        /// <returns></returns>
        public DataTable GetBinOrdrsSSMZ(string sSql, Guid BinID, long BabyID, int SelType, int SelKind, long Doc, DateTime ExecDate, string ward_id)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[7];

            sSql = "sp_zyhs_orders_select_ssmz";
            parameters[0].Value = BinID;
            parameters[0].Text = "@binid";
            parameters[1].Value = BabyID;
            parameters[1].Text = "@babyid";
            parameters[2].Value = SelType;
            parameters[2].Text = "@seltype";
            parameters[3].Value = SelKind;
            parameters[3].Text = "@selkind";
            parameters[4].Value = Doc;
            parameters[4].Text = "@doc";
            parameters[5].Value = ExecDate;
            parameters[5].Text = "@execdate";
            parameters[6].Value = ward_id;
            parameters[6].Text = "@wardid";

            try
            {
                myTb = database.GetDataTable(sSql, parameters, 60);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //返回数据表对象
            return myTb;
        }

        //查询转抄的医嘱等
        public DataTable GetBinOrdrszc(string sSql, string ward_id, int kind, int type, DateTime Date1, DateTime Date2)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[5];

            sSql = "sp_zyhs_orders_selectzc";
            parameters[0].Value = ward_id;
            parameters[0].Text = "@wardid";
            parameters[1].Value = kind;
            parameters[1].Text = "@selkind";
            parameters[2].Value = type;
            parameters[2].Text = "@seltype";
            parameters[3].Value = Date1;
            parameters[3].Text = "@begindate";
            parameters[4].Value = Date2;
            parameters[4].Text = "@enddate";

            try
            {
                myTb = database.GetDataTable(sSql, parameters, 60);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //返回数据表对象
            return myTb;
        }

        //查询转抄的医嘱等，查找单病人
        //Add By Tany 2005-03-15 
        public DataTable GetBinOrdrszcInpatient(string sSql, string ward_id, int kind, int type, DateTime Date1, DateTime Date2, Guid inpatient_id, long baby_id)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[7];

            sSql = "sp_zyhs_orders_selectzc_inpatient";
            parameters[0].Value = ward_id;
            parameters[0].Text = "@wardid";
            parameters[1].Value = kind;
            parameters[1].Text = "@selkind";
            parameters[2].Value = type;
            parameters[2].Text = "@seltype";
            parameters[3].Value = Date1;
            parameters[3].Text = "@begindate";
            parameters[4].Value = Date2;
            parameters[4].Text = "@enddate";
            parameters[5].Value = inpatient_id;
            parameters[5].Text = "@inpatient_id";
            parameters[6].Value = baby_id;
            parameters[6].Text = "@baby_id";

            try
            {
                myTb = database.GetDataTable(sSql, parameters, 60);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //返回数据表对象
            return myTb;
        }

        //分配床位
        public string AssignBed(string sSql, int nMode, Guid bedID, long deptID, Guid inpatientID, long BabyID, string sex, string Room_NO, int isBF, int isMYTS, DateTime d_Date, long OperID, int isInput_ZD, int isUpdate, int isTmpin, int Jgbm)
        {
            //后台处理错误 Tany 2004-12-2
            string _outmsg = "";
            ParameterEx[] parameters = new ParameterEx[18];

            sSql = "sp_zyhs_bedassign";
            parameters[0].Value = nMode;
            parameters[0].Text = "@nmode";
            parameters[1].Value = bedID;
            parameters[1].Text = "@bedid";
            parameters[2].Value = FrmMdiMain.CurrentDept.WardId;
            parameters[2].Text = "@wardid";
            parameters[3].Value = deptID;
            parameters[3].Text = "@deptid";
            parameters[4].Value = inpatientID;
            parameters[4].Text = "@inpatientid";
            parameters[5].Value = BabyID;
            parameters[5].Text = "@babyid";
            parameters[6].Value = sex;
            parameters[6].Text = "@sex";
            parameters[7].Value = Room_NO;
            parameters[7].Text = "@roomno";
            parameters[8].Value = isBF;
            parameters[8].Text = "@isbf";
            parameters[9].Value = isMYTS;
            parameters[9].Text = "@ismyts";
            parameters[10].Value = d_Date;
            parameters[10].Text = "@date";
            parameters[11].Value = OperID;
            parameters[11].Text = "@operid";
            parameters[12].Value = isInput_ZD;
            parameters[12].Text = "@isinputzd";
            parameters[13].Value = isUpdate;
            parameters[13].Text = "@isupdateindate";
            parameters[14].Value = isTmpin;
            parameters[14].Text = "@tmpin";
            parameters[15].Text = "@outcode";
            parameters[15].ParaSize = 100;
            parameters[15].ParaDirection = ParameterDirection.Output;
            parameters[16].Text = "@outmsg";
            parameters[16].ParaSize = 50;
            parameters[16].ParaDirection = ParameterDirection.Output;
            parameters[17].Value = Jgbm;
            parameters[17].Text = "@jgbm";

            try
            {
                database.DoCommand(sSql, parameters, 60);
                _outmsg = parameters[16].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            return _outmsg;
        }

        //取消分配床位
        public string CancelAssignBed(string sSql, Guid inpatientID, Guid assignID, long userID)
        {
            string _outmsg = "";
            ParameterEx[] parameters = new ParameterEx[5];

            sSql = "sp_zyhs_bedassigncancel";
            parameters[0].Value = inpatientID;//Convert.ToDecimal(myTb.Rows[myDataGrid3.CurrentCell.RowNumber]["inpatient_id"].ToString());
            parameters[0].Text = "@inpatient_id";
            parameters[1].Value = assignID;//Convert.ToDecimal(myTb.Rows[myDataGrid3.CurrentCell.RowNumber]["assign_id"].ToString());
            parameters[1].Text = "@assign_id";
            parameters[2].Value = userID;//Convert.ToDecimal(InstanceForm.BCurrentUser.EmployeeId);
            parameters[2].Text = "@user_id";
            parameters[3].Text = "@outcode";
            parameters[3].ParaSize = 100;
            parameters[3].ParaDirection = ParameterDirection.Output;
            parameters[4].Text = "@outmsg";
            parameters[4].ParaSize = 50;
            parameters[4].ParaDirection = ParameterDirection.Output;

            try
            {
                database.DoCommand(sSql, parameters, 60);
                _outmsg = parameters[4].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            return _outmsg;
        }

        //转床或空出床位
        public string ChangeBed(string sSql, int nMode, Guid oldbedID, Guid newbedID, long OperID, int Jgbm)
        {
            string _outmsg = "";
            ParameterEx[] parameters = new ParameterEx[7];

            sSql = "sp_zyhs_bedchange";
            parameters[0].Value = nMode;
            parameters[0].Text = "@nmode";
            parameters[1].Value = oldbedID;
            parameters[1].Text = "@oldbedid";
            parameters[2].Value = newbedID;
            parameters[2].Text = "@newbedid";
            parameters[3].Value = OperID;
            parameters[3].Text = "@operid";
            parameters[4].ParaDirection = ParameterDirection.Output;
            parameters[4].Text = "@outcode";
            parameters[4].ParaSize = 100;
            parameters[5].ParaDirection = ParameterDirection.Output;
            parameters[5].Text = "@outmsg";
            parameters[5].ParaSize = 50;
            parameters[6].Value = Jgbm;
            parameters[6].Text = "@Jgbm";

            try
            {
                database.DoCommand(sSql, parameters, 60);
                _outmsg = parameters[5].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            return _outmsg;
        }

        //修改病人资料
        public string ChangeDOC(string sSql, int nMode, Guid inpatientID, long BabyID, long DocID, long OperID, int Jgbm)
        {
            string _outmsg = "";
            ParameterEx[] parameters = new ParameterEx[8];

            sSql = "sp_zyhs_docchange";
            parameters[0].Value = nMode;
            parameters[0].Text = "@nmode";
            parameters[1].Value = inpatientID;
            parameters[1].Text = "@inpatientid";
            parameters[2].Value = BabyID;
            parameters[2].Text = "@babyid";
            parameters[3].Value = DocID;
            parameters[3].Text = "@docid";
            parameters[4].Value = OperID;
            parameters[4].Text = "@operid";
            parameters[5].ParaDirection = ParameterDirection.Output;
            parameters[5].Text = "@outcode";
            parameters[5].ParaSize = 100;
            parameters[6].ParaDirection = ParameterDirection.Output;
            parameters[6].Text = "@outmsg";
            parameters[6].ParaSize = 50;
            parameters[7].Value = Jgbm;
            parameters[7].Text = "@Jgbm";

            try
            {
                database.DoCommand(sSql, parameters, 60);
                _outmsg = parameters[6].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            return _outmsg;
        }

        //分娩
        public string ChildBearing(string sSql, int nMode, int nCWF, Guid BinID, int current_no, string sSex, string sName, long OperID, DateTime sDate, int Jgbm)
        {
            string _outmsg = "";
            ParameterEx[] parameters = new ParameterEx[11];

            sSql = "sp_zyhs_childbearing";
            parameters[0].Value = nMode;
            parameters[0].Text = "@nmode";
            parameters[1].Value = nCWF;
            parameters[1].Text = "@cwf";
            parameters[2].Value = BinID;
            parameters[2].Text = "@inpatient_id";
            parameters[3].Value = current_no;
            parameters[3].Text = "@baby_no";
            parameters[4].Value = sSex;
            parameters[4].Text = "@sex";
            parameters[5].Value = sName;
            parameters[5].Text = "@babyname";
            parameters[6].Value = OperID;
            parameters[6].Text = "@operid";
            parameters[7].Value = sDate;
            parameters[7].Text = "@date";
            parameters[8].ParaDirection = ParameterDirection.Output;
            parameters[8].Text = "@outcode";
            parameters[8].ParaSize = 100;
            parameters[9].ParaDirection = ParameterDirection.Output;
            parameters[9].Text = "@outmsg";
            parameters[9].ParaSize = 50;
            parameters[10].Value = Jgbm;
            parameters[10].Text = "@Jgbm";

            try
            {
                database.DoCommand(sSql, parameters, 60);
                _outmsg = parameters[9].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            return _outmsg;
        }

        public string TransfeDept(string sSql, int nMode, Guid BinID, long BabyID, long sDept, long dDept, long OperID, DateTime transDate, Guid TransId)
        {
            string _outmsg = "";
            ParameterEx[] parameters = new ParameterEx[10];

            sSql = "sp_zyhs_transferdept";
            parameters[0].Value = nMode;
            parameters[0].Text = "@mode";
            parameters[1].Value = BinID;
            parameters[1].Text = "@inpatient_id";
            parameters[2].Value = BabyID;
            parameters[2].Text = "@baby_id";
            parameters[3].Value = sDept;
            parameters[3].Text = "@sdept_id";
            parameters[4].Value = dDept;
            parameters[4].Text = "@ddept_id";
            parameters[5].Value = OperID;
            parameters[5].Text = "@operator";
            parameters[6].Value = transDate;
            parameters[6].Text = "@date";
            parameters[7].Value = TransId;
            parameters[7].Text = "@transid";
            parameters[8].ParaDirection = ParameterDirection.Output;
            parameters[8].Text = "@outcode";
            parameters[8].ParaSize = 100;
            parameters[9].ParaDirection = ParameterDirection.Output;
            parameters[9].Text = "@outmsg";
            parameters[9].ParaSize = 50;

            try
            {
                database.DoCommand(sSql, parameters, 60);
                _outmsg = parameters[9].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            return _outmsg;
        }

        public string ApplyOut(string sSql, int nMode, Guid BinID, long BabyID, long OperID, int Jgbm)
        {
            string _outmsg = "";
            ParameterEx[] parameters = new ParameterEx[7];

            sSql = "sp_zyhs_applyout";
            parameters[0].Value = nMode;
            parameters[0].Text = "@mode";
            parameters[1].Value = BinID;
            parameters[1].Text = "@inpatient_id";
            parameters[2].Value = BabyID;
            parameters[2].Text = "@baby_id";
            parameters[3].Value = OperID;
            parameters[3].Text = "@operator";
            parameters[4].Value = Jgbm;
            parameters[4].Text = "@jgbm";
            parameters[5].ParaDirection = ParameterDirection.Output;
            parameters[5].Text = "@outcode";
            parameters[5].ParaSize = 100;
            parameters[6].ParaDirection = ParameterDirection.Output;
            parameters[6].Text = "@outmsg";
            parameters[6].ParaSize = 50;

            try
            {
                database.DoCommand(sSql, parameters, 60);
                _outmsg = parameters[6].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            return _outmsg;
        }
        public DataTable SetItemInfo(string sSql, long HOitemID, double num, string Use_Name, int Jgbm)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[4];

            sSql = "sp_zyhs_order_getfee";
            parameters[0].Value = HOitemID;
            parameters[0].Text = "@hoitemid";
            parameters[1].Value = num;
            parameters[1].Text = "@num";
            parameters[2].Value = Use_Name;
            parameters[2].Text = "@use_name";
            parameters[3].Value = Jgbm;
            parameters[3].Text = "@Jgbm";

            try
            {
                myTb = database.GetDataTable(sSql, parameters, 60);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //返回数据表对象
            return myTb;
        }
        /// <summary>
        /// Modiby by zouchihua 2013-3-17 把Ssql 传入医嘱id
        /// </summary>
        /// <param name="sSql"></param>
        /// <param name="HOitemID"></param>
        /// <param name="num"></param>
        /// <param name="Use_Name"></param>
        /// <param name="Jgbm"></param>
        /// <returns></returns>
        public DataTable SetItemInfo(Guid  order_id, long HOitemID, double num, string Use_Name, int Jgbm)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[5];

            string sSql = "SP_ZYHS_ORDER_GETFEE_orderid";
            parameters[0].Value = HOitemID;
            parameters[0].Text = "@hoitemid";
            parameters[1].Value = num;
            parameters[1].Text = "@num";
            parameters[2].Value = Use_Name;
            parameters[2].Text = "@use_name";
            parameters[3].Value = Jgbm;
            parameters[3].Text = "@Jgbm";
            parameters[4].Value = order_id;
            parameters[4].Text = "@order_id";

            try
            {
                myTb = database.GetDataTable(sSql, parameters, 60);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //返回数据表对象
            return myTb;
        }

         

        /// <summary>
        /// 药品统领单
        /// </summary>
        /// <param name="_applyId"></param>
        /// <param name="_wardId"></param>
        /// <param name="_tlfs"></param>统领方式（0=普通1=缺药）
        /// <returns></returns>
        public DataTable GetYPTLD(Guid _applyId, string _wardId, int _tlfs)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[3];

            string sSql = "sp_zyhs_yptld";
            parameters[0].Value = _applyId;
            parameters[0].Text = "@apply_id";
            parameters[1].Value = _wardId;
            parameters[1].Text = "@ward_id";
            parameters[2].Value = _tlfs;
            parameters[2].Text = "@tlfs";

            try
            {
                myTb = database.GetDataTable(sSql, parameters, 120);
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "GetYPTLD(" + _applyId + ",'" + _wardId + "'," + _tlfs + ")错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show(err.ToString());
            }

            //返回数据表对象
            return myTb;
        }

        /// <summary>
        /// 基数药统领单（按单种药品统计）
        /// </summary>
        /// <param name="wardid">病区ID</param>
        /// <param name="shh">药品货号</param>
        /// <returns></returns>
        //基数药统领单（按单种药品统计） Add By Tany 2005-02-01
        public DataTable GetJSYTLD(string wardid, string shh)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[2];

            string sSql = "SP_ZYHS_JSYTLD";
            parameters[0].Value = wardid;
            parameters[1].Value = shh;

            try
            {
                myTb = database.GetDataTable(sSql, parameters, 60);
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-02-01
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "GetJSYTLD('" + wardid + "','" + shh + "')错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show(err.ToString());
            }

            //返回数据表对象
            return myTb;
        }

        //明细单
        public DataTable GetPatientYPMXD(string sSql, Guid InpatientID, int FinishBit, System.DateTime beginDate, System.DateTime endDate)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[4];

            sSql = "REN_YPMXD";
            parameters[0].Value = InpatientID;
            parameters[1].Value = FinishBit;
            parameters[2].Value = beginDate;
            parameters[3].Value = endDate;

            myTb = database.GetDataTable(sSql, parameters, 60);

            //返回数据表对象
            return myTb;
        }

        /// <summary>
        /// 发送医嘱
        /// </summary>
        /// <param name="myDataGrid"></param>指定发送网格内选定数据
        /// <param name="MNGType"></param>医嘱类型 0长期医嘱 1临时医嘱 2长期账单 4临时账单 9所有医嘱和账单
        /// <param name="Kind"></param>0所有 1选择 2不发送 3仅药品,(4 全部药品，5 仅口服药，6 非口服药  add by zouchihua 2012-01-13 )
        /// <param name="progressBar1"></param>滚动条
        /// <param name="BinID"></param>病人inpatient_id
        /// <param name="BabyID"></param>baby_id
        /// <param name="BookDate"></param>操作时间
        /// <param name="ExecDate"></param>执行时间
        /// <param name="_isExecCurDeptOrder"></param>是否只执行执行科室为本科室医嘱
        /// <returns></returns>
        public bool ExecOrdersWithData(DataGridEx myDataGrid, int MNGType, int Kind, System.Windows.Forms.ProgressBar progressBar1, Guid BinID, long BabyID, System.DateTime BookDate, System.DateTime ExecDate, bool _isExecCurDeptOrder, int Jgbm)
        {
            if (MNGType != 9 && Kind == 2)
                return true;

            //Modify By Tany 2009-12-11
            //判断执行时间是否符合医嘱有效执行时间，暂不判断手术麻醉等地方，只判断护士工作站
            string _begintime = new SystemCfg(7056).Config;
            string _endtime = new SystemCfg(7057).Config;
            DateTime _now = DateManager.ServerDateTimeByDBType(database);
            if (_now < Convert.ToDateTime(_now.ToShortDateString() + " " + _begintime)
                || _now > Convert.ToDateTime(_now.ToShortDateString() + " " + _endtime))
            {
                MessageBox.Show("医嘱执行有效时间为" + _begintime + "至" + _endtime + "，请在有效时间范围内执行医嘱！");
                return true;
            }

            int GroupID = -999;
            int iMNGType = 0;
            string sSql = "";
            int mngType2 = MNGType == 1 ? 5 : MNGType;

            DataTable myTb = new DataTable();
            //add by zouchihua 2012-01-13
            string kfycode = new SystemCfg(7048).Config.ToString();
            if ((MNGType == 9) || (MNGType != 9 && Kind == 0))
            {
                //查询这个病人所有的医嘱,执行只能执行本病区的医嘱
                sSql = @"select distinct Group_ID ,MNGType " +
                    "  from zy_orderrecord " +
                    " where (status_flag>=2 and status_flag<5) " +
                    "   and dept_id not in (select deptid from ss_dept)" +
                    "   and delete_bit=0" +
                    "   and inpatient_id='" + BinID.ToString() + "' and Baby_ID=" + BabyID.ToString();
                if (MNGType != 9) sSql += " and (mngtype=" + MNGType + " or mngtype=" + mngType2 + ")";
                myTb = database.GetDataTable(sSql);
            }
            else if (Kind >= 3)
            {
                if (Kind == 3||Kind == 4)
                {
                    //查询这个病人所有的药品长期医嘱,只能执行本病区的医嘱
                    //Add By Tany 2004-10-12
                    sSql = @"select distinct Group_ID ,MNGType " +
                        "  from zy_orderrecord " +
                        " where (ntype in (1,2,3) and xmly=1) and (status_flag>=2 and status_flag<5) " +
                        "   and dept_id not in (select deptid from ss_dept)" +
                        "   and delete_bit=0" +
                        "   and inpatient_id='" + BinID.ToString() + "' and Baby_ID=" + BabyID.ToString() + " and mngtype=" + MNGType;
                }
                else
                    if (Kind == 5)
                    {
                        //仅口服药
                        sSql = @"select distinct Group_ID ,MNGType " +
                        "  from zy_orderrecord a left join vi_yp_ypcd b on XMLY=1 and a.HOITEM_ID=b.cjid and CHARINDEX(b.tlfl,'" + kfycode + "')>0" +
                        " where (ntype in (1,2,3) and xmly=1) and (status_flag>=2 and status_flag<5) " +
                        "   and dept_id not in (select deptid from ss_dept)" +
                        "   and delete_bit=0 and  CHARINDEX(b.tlfl,'" + kfycode + "')>0 " +
                        "   and inpatient_id='" + BinID.ToString() + "' and Baby_ID=" + BabyID.ToString() + " and mngtype=" + MNGType;
                    }
                    else
                        if (Kind == 6)
                    {
                        //非口服药
                        sSql = @"select distinct Group_ID ,MNGType " +
                        "  from zy_orderrecord a left join vi_yp_ypcd b on XMLY=1 and a.HOITEM_ID=b.cjid and CHARINDEX(b.tlfl,'" + kfycode + "')=0" +
                        " where (ntype in (1,2,3) and xmly=1) and (status_flag>=2 and status_flag<5) " +
                        "   and dept_id not in (select deptid from ss_dept)" +
                        "   and delete_bit=0 and  CHARINDEX(b.tlfl,'" + kfycode + "')=0 " +
                        "   and inpatient_id='" + BinID.ToString() + "' and Baby_ID=" + BabyID.ToString() + " and mngtype=" + MNGType;
                    }
                myTb = database.GetDataTable(sSql);
            }
            else
            {
                myTb = (DataTable)myDataGrid.DataSource;
            }
            progressBar1.Maximum = myTb.Rows.Count;
            progressBar1.Value = 0;

            bool isUseProc = true;//是否使用后台存储过程发送医嘱
            SystemCfg cfg = new SystemCfg(7027);
            isUseProc = cfg.Config == "是" ? true : false;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                //如果是选择发送
                if (MNGType != 9 && Kind == 1)
                {
                    if (myTb.Rows[i]["选"].ToString() == "False")
                        continue;
                }

                //如果组号与上一条医嘱相同，则不执行
                if (GroupID == Convert.ToInt32(myTb.Rows[i]["Group_ID"])
                    && (MNGType != 9 || (MNGType == 9 && iMNGType == Convert.ToInt32(myTb.Rows[i]["MNGType"]))))
                {
                    continue;
                }

                //如果只发送执行科室为本科室的医嘱
                if (_isExecCurDeptOrder)
                {
                    bool isExec = false;

                    //看看这组有不有本科室执行的
                    string deptSql = "select 1 from zy_orderrecord a" +
                        " where (exec_dept=dept_id or exec_dept in (select dept_id from jc_ward where ward_id=a.ward_id)) " +
                        " and group_id=" + myTb.Rows[i]["Group_ID"].ToString() +
                        " and inpatient_id='" + BinID.ToString() + "' and Baby_ID=" + BabyID.ToString();
                    DataTable deptTb = database.GetDataTable(deptSql);

                    //如果没有
                    if (deptTb == null || deptTb.Rows.Count == 0)
                    {
                        isExec = false;
                    }
                    else
                    {
                        //看看这组有多少条医嘱
                        deptSql = "select 1 from zy_orderrecord a" +
                            " where group_id=" + myTb.Rows[i]["Group_ID"].ToString() +
                            " and inpatient_id='" + BinID.ToString() + "' and Baby_ID=" + BabyID.ToString();
                        DataTable deptTb1 = database.GetDataTable(deptSql);

                        //如果这组里面不全是本科室的，也不执行
                        if (deptTb.Rows.Count != deptTb1.Rows.Count)
                        {
                            isExec = false;
                        }
                        else
                        {
                            isExec = true;
                        }
                    }

                    if (isExec == false)
                    {
                        continue;
                    }
                }

                GroupID = Convert.ToInt32(myTb.Rows[i]["Group_ID"]);
                iMNGType = MNGType == 9 ? Convert.ToInt16(myTb.Rows[i]["MNGType"]) : MNGType;
                int iMNGType2 = iMNGType == 1 ? 5 : iMNGType;

                if (isUseProc)
                {
                    try
                    {
                        ExecOrders("", BinID, BabyID, GroupID, iMNGType, BookDate, ExecDate, FrmMdiMain.CurrentUser.EmployeeId, Jgbm);
                    }
                    catch (Exception err)
                    {
                        if (MessageBox.Show(err.Message + "\n\n是否继续执行？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    //					ExecOrdersNew(BinID,BabyID,GroupID,iMNGType,BookDate,ExecDate,FrmMdiMain.CurrentUser.EmployeeId);
                }

                progressBar1.Value += 1;
            }

            progressBar1.Value = 0;

            return true;
        }

        #region 暂时屏蔽
        /*
		/// <summary>
		/// 发送医嘱
		/// </summary>
		/// <param name="myDataGrid"></param>指定发送网格内选定数据
		/// <param name="MNGType"></param>医嘱类型 0长期医嘱 1临时医嘱 2长期账单 4临时账单 9所有医嘱和账单
		/// <param name="Kind"></param>0所有 1选择 2不发送 3仅药品
		/// <param name="progressBar1"></param>滚动条
		/// <param name="BinID"></param>病人inpatient_id
		/// <param name="BabyID"></param>baby_id
		/// <param name="ExecDate"></param>执行时间
		/// <param name="_isExecCurDeptOrder"></param>是否只执行执行科室为本科室医嘱
		/// <returns></returns>
		public string ExecOrdersWithData1(DataGridEx myDataGrid,int MNGType,int Kind,System.Windows.Forms.ProgressBar progressBar1,long BinID,long BabyID,System.DateTime ExecDate,bool _isExecCurDeptOrder) 
		{
			string sMsg="";

			if (MNGType!=9 && Kind==2 )  
				return sMsg;

			int GroupID=-999;
			int iMNGType=0; 
			int nType=-999;
			string sSql="";
			int mngType2 = MNGType==1?5:MNGType;
			System.DateTime BookDate;
			
			DataTable myTb=new DataTable();	
			if ( (MNGType==9) || (MNGType!=9 && Kind==0 ) )
			{	
				//查询这个病人所有的医嘱,执行只能执行本病区的医嘱
				sSql=@"select distinct Group_ID ,MNGType,ntype "+
					"  from zy_orderrecord "+
					" where (status_flag>=2 and status_flag<=5) " + // Modify By Tany 2004-11-22 有可能已经停止了但是要冲正的
					"   and dept_id not in (select deptid from ss_dept)" + 
					"   and delete_bit=0" +
					"   and inpatient_id=" + BinID+ " and Baby_ID=" + BabyID ;
				if (MNGType!=9) sSql+=" and (mngtype="+MNGType+" or mngtype="+mngType2+")" ;
				myTb=database.GetDataTable(sSql);
			}
			else if(Kind==3)
			{
				//查询这个病人所有的药品长期医嘱,只能执行本病区的医嘱
				//Add By Tany 2004-10-12
				sSql=@"select distinct Group_ID ,MNGType ,ntype"+
					"  from zy_orderrecord "+
					" where (ntype in (1,2,3) and cjid>0) and (status_flag>=2 and status_flag<=5) " + // Modify By Tany 2004-11-22 有可能已经停止了但是要冲正的
					"   and dept_id not in (select deptid from ss_dept)" + 
					"   and delete_bit=0" +
					"   and inpatient_id=" + BinID.ToString()+ " and Baby_ID=" + BabyID.ToString()+" and mngtype="+MNGType ;
				myTb=database.GetDataTable(sSql);
			}
			else
			{
				myTb=(DataTable)myDataGrid.DataSource;	
			}						
			progressBar1.Maximum=myTb.Rows.Count;

			//生成数据访问对象
			RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
			database.Initialize("");
			database.Open();

			bool isUseProc=true;//是否使用后台存储过程发送医嘱
			isUseProc=PublicStaticFun.GetSystemConfig(11027)=="是"?true:false;

			for(int i=0;i<=myTb.Rows.Count-1;i++)
			{
				//如果是选择发送
				if (MNGType!=9 && Kind==1)
				{
					if (myTb.Rows[i]["选"].ToString()=="False") 
					{
						progressBar1.Value+=1;	
						continue;
					}
				}

				//如果组号与上一条医嘱相同，则不执行
				if (GroupID==Convert.ToInt32(myTb.Rows[i]["Group_ID"]) 
					&& (MNGType!=9 || ( MNGType==9 && iMNGType==Convert.ToInt32(myTb.Rows[i]["MNGType"]) ) ) ) 
				{
					progressBar1.Value+=1;	
					continue;
				}

				//如果只发送执行科室为本科室的医嘱
				if(_isExecCurDeptOrder)
				{
					bool isExec=false;

					//看看这组有不有本科室执行的
					string deptSql="select 1 from zy_orderrecord a"+
						" where (exec_dept=dept_id or exec_dept in (select dept_id from jc_ward where ward_id=a.ward_id)) "+
						" and group_id="+myTb.Rows[i]["Group_ID"].ToString()+
						" and inpatient_id=" + BinID.ToString()+ " and Baby_ID=" + BabyID.ToString();
					DataTable deptTb=database.GetDataTable(deptSql);

					//如果没有
					if(deptTb==null || deptTb.Rows.Count==0)
					{
						isExec=false;
					}
					else
					{
						//看看这组有多少条医嘱
						deptSql="select 1 from zy_orderrecord a"+
							" where group_id="+myTb.Rows[i]["Group_ID"].ToString()+
							" and inpatient_id=" + BinID.ToString()+ " and Baby_ID=" + BabyID.ToString();
						DataTable deptTb1=database.GetDataTable(deptSql);

						//如果这组里面不全是本科室的，也不执行
						if(deptTb.Rows.Count != deptTb1.Rows.Count)
						{
							isExec=false;
						}
						else
						{
							isExec=true;
						}
					}

					if(isExec==false)
					{
						continue;
					}
				}
				
				GroupID=Convert.ToInt32(myTb.Rows[i]["Group_ID"]);
				iMNGType=MNGType==9?Convert.ToInt16(myTb.Rows[i]["MNGType"]):MNGType;
				nType=Convert.ToInt32(myTb.Rows[i]["ntype"]);

				//每次重新得到数据库时间，保证数据不会重复
				//Modify By Tany 2005-07-15
				BookDate=DateManager.ServerDateTimeByDBType(database);

				if(isUseProc)
				{
					//不用前台事务
					//开始一个事务
//					database.BeginTransaction();
//
//					try
//					{
						ExecOrders("",BinID,BabyID,GroupID,iMNGType,BookDate,ExecDate,FrmMdiMain.CurrentUser.EmployeeId,database);

						//提交
//						database.CommitTransaction();
//					}
//					catch(Exception err)
//					{
//						database.RollbackTransaction();
//
//						//写错误日志 Add By Tany 2005-01-12
//						SystemLog _systemErrLog=new SystemLog(-1,FrmMdiMain.CurrentDept.DeptId,FrmMdiMain.CurrentUser.EmployeeId,"程序错误","执行医嘱错误："+err.Message+"  Source："+err.Source,DateManager.ServerDateTimeByDBType(database),1,"主机名："+System.Environment.MachineName,39);
//						_systemErrLog.Save();
//						_systemErrLog=null;
//
//						sMsg+=BinID.ToString()+",";
//
//						break;
//					}
				}
				else
				{
					ExecOrdersNew(BinID,BabyID,GroupID,iMNGType,BookDate,ExecDate,FrmMdiMain.CurrentUser.EmployeeId);
				}

				progressBar1.Value+=1;												
			}		

			database.Close();
					
			progressBar1.Value=0;

			return sMsg;
		}
		*/
        #endregion

        /// <summary>
        /// 发送医嘱（手术麻醉用），执行直接发送药品
        /// </summary>
        /// <param name="DeptId"></param>科室ID
        /// <param name="WardId"></param>病区ID
        /// <param name="EmpId"></param>employee_id
        /// <param name="BinID"></param>病人inpatient_id
        /// <param name="BabyID"></param>baby_id
        /// <param name="ExecDate"></param>执行时间
        /// <returns></returns>
        public string ExecOrdersWithData(long DeptId, string WardId, long WardDeptId, long EmpId, Guid BinID, long BabyID, System.DateTime ExecDate, int Jgbm)
        {
            string sMsg = "";
            SystemCfg cfg6035 = new SystemCfg(6035);
            int GroupID = -999;
            int iMNGType = 0;
            int nType = -999;
            string sSql = "";
            System.DateTime BookDate;


            //查询这个病人所有的医嘱,执行只能执行本病区的医嘱
            sSql = @"select distinct Group_ID ,MNGType,ntype,DEPT_BR  " +
                "  from zy_orderrecord " +
                " where (status_flag>=2 and status_flag<5) " +
                "   and dept_id=" + DeptId +
                "   and delete_bit=0" +
                "   and inpatient_id='" + BinID + "' and Baby_ID=" + BabyID;
            DataTable myTb = database.GetDataTable(sSql);

            //			//生成数据访问对象
            //			RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
            //			database.Initialize("");
            //			database.Open();

            bool isUseProc = true;//是否使用后台存储过程发送医嘱
            SystemCfg cfg = new SystemCfg(7027);
            isUseProc = cfg.Config == "是" ? true : false;
            //add by zouchihua 增加病人所在科室 2012-4-2
            string dept_br = "-1";
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                //add by zouchihua 增加病人所在科室 2012-4-2
                dept_br = myTb.Rows[i]["DEPT_BR"].ToString();
                //如果组号与上一条医嘱相同，则不执行
                if (GroupID == Convert.ToInt32(myTb.Rows[i]["Group_ID"])
                    && iMNGType == Convert.ToInt32(myTb.Rows[i]["MNGType"]))
                {
                    continue;
                }

                GroupID = Convert.ToInt32(myTb.Rows[i]["Group_ID"]);
                iMNGType = Convert.ToInt16(myTb.Rows[i]["MNGType"]);
                nType = Convert.ToInt32(myTb.Rows[i]["ntype"]);

                //每次重新得到数据库时间，保证数据不会重复
                //Modify By Tany 2005-07-15
                BookDate = DateManager.ServerDateTimeByDBType(database);

                if (isUseProc)
                {
                    try
                    {

                        //add by zouchihua 2012-5-11减掉虚拟库存
                        if (cfg6035.Config.Trim() == "1")
                            OprateXnkc(BinID, BabyID, Guid.Empty, GroupID, 0);
                        ExecOrders("", BinID, BabyID, GroupID, iMNGType, BookDate, ExecDate, EmpId, Jgbm);
                      
                    }
                    catch (Exception err)
                    {
                        //如果报错那么把该条医嘱更改为 0的状态
                        string upsql = "update ZY_ORDERRECORD set STATUS_FLAG=0 where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID + "";
                        database.DoCommand(upsql);
                        if (MessageBox.Show(err.Message + "\n\n是否继续执行？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    //					ExecOrdersNew(BinID,BabyID,GroupID,iMNGType,BookDate,ExecDate,FrmMdiMain.CurrentUser.EmployeeId);
                }
            }

            //			database.Close();

            //医嘱发送（冲账）是否自动生成药品统领信息
            //Modify By Tany 2005-11-05
         
            cfg = new SystemCfg(7022);
            if (cfg.Config == "是")
            {
                //string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                //    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + WardId + "') or a.dept_id=" + DeptId + ")";
                
                string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                   " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + WardId + "') or a.dept_id=" + DeptId + ")";
                DataTable yfTb = database.GetDataTable(yfSql);
               
                for (int i = 0; i < yfTb.Rows.Count; i++)
                {
                    //新统领药品（领药）消息 Modify By Tany 2005-09-13
                    SendYPFY(0, 0, WardId, WardDeptId == 0 ? DeptId : WardDeptId, EmpId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                    ////Modify by zouchihua 增加病人所在病区
                    DataTable tbtmb = database.GetDataTable(" SELECT WARD_ID FROM JC_WARD WHERE WARD_ID in (SELECT WARD_ID FROM JC_WARDRDEPT WHERE DEPT_ID=" + dept_br + " )");
                    if (tbtmb != null && tbtmb.Rows.Count>0)
                    {
                        for (int j = 0; j < tbtmb.Rows.Count; j++)
                        {
                            SendYPFY(0, 0, tbtmb.Rows[j]["WARD_ID"].ToString(), WardDeptId == 0 ? DeptId : WardDeptId, EmpId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                        }
                    }
                }
            }

            //Modify By Tany 2009-08-03
            //冲账和发送分开
            cfg = new SystemCfg(7047);
            if (cfg.Config == "是")
            {
                string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + WardId + "') or a.dept_id=" + DeptId + ")";
                DataTable yfTb = database.GetDataTable(yfSql);

                for (int i = 0; i < yfTb.Rows.Count; i++)
                {
                    //新统领药品（退药）消息 Modify By Tany 2005-09-13
                    SendYPFY(0, 1, WardId, WardDeptId == 0 ? DeptId : WardDeptId, EmpId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                }
            }

            return sMsg;
        }

        public string ExecOrders(string sSql, Guid BinID, long BabyID, long GroupID, int MNGType, System.DateTime BookDate, System.DateTime ExecDate, long execUser, int Jgbm)
        {
            try
            {
                //Modify By Tany 2011-04-12 这一段如果出错就不执行，但是让执行过程继续
                try 
                {
                    //Modify By Tany 2011-04-09 增加锁定记录表，避免医嘱执行时重复执行同一医嘱
                    DataTable tb = new DataTable();
                    string sql = "select * from zy_orderexec_lock(nolock) where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID;
                    tb = database.GetDataTable(sql);

                    //如果没有找到记录，则插入一条新记录，并直接锁定
                    if (tb == null || tb.Rows.Count == 0)
                    {
                        sql = "insert into zy_orderexec_lock(inpatient_id,baby_id,group_id,lock_bit) values('" + BinID + "'," + BabyID + "," + GroupID + ",1)";
                        database.DoCommand(sql);
                    }
                    else
                    {
                        //如果已经被锁定，则退出
                        if (Convert.ToInt32(tb.Rows[0]["lock_bit"]) == 1)
                        {
                            return "";
                        }
                        else
                        {
                           //sql = "select * from zy_orderexec_lock(nolock) where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID;
                           //DataTable  tbtemp = database.GetDataTable(sql);
                           
                            //如果没有被锁，则上锁
                           int i= database.DoCommand("update zy_orderexec_lock set lock_bit=1 where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID + "  and lock_bit=0 ");
                           // add by zouchihua 2013-9-22 如果没有更新到lock_bit=0的行，说明已经上锁了 ，必须返回
                            if (i == 0)
                               return "";
                        }
                    }
                    if (tb == null || tb.Rows.Count == 0)
                    {
                        //add by zouchihua 2013-9-22 再次判断   如果大于两条则自动删除一条，并且返回
                        sql = "select * from zy_orderexec_lock(nolock) where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID;
                        DataTable tb1 = database.GetDataTable(sql);
                        if (tb1.Rows.Count > 1)
                        {
                            sql = "delete from zy_orderexec_lock where id=" + tb1.Rows[0]["id"].ToString() + " ";
                            database.DoCommand(sql);
                            return "";
                        }
                    }

                }
                catch
                {
                    return "";
                }

                string _outmsg = "";
                int _outcode = 0;
                ParameterEx[] parameters = new ParameterEx[10];

                sSql = "sp_zyhs_order_exe";
                parameters[0].Value = BinID;
                parameters[0].Text = "@inpatientid";
                parameters[1].Value = BabyID;
                parameters[1].Text = "@babyid";
                parameters[2].Value = GroupID;
                parameters[2].Text = "@groupid";
                parameters[3].Value = MNGType;
                parameters[3].Text = "@mngtype";
                parameters[4].Value = BookDate;
                parameters[4].Text = "@bookdate";
                parameters[5].Value = ExecDate;
                parameters[5].Text = "@execdate";
                parameters[6].Value = execUser;
                parameters[6].Text = "@exeuser";
                parameters[7].ParaDirection = ParameterDirection.Output;
                parameters[7].Text = "@outcode";
                parameters[7].ParaSize = 100;
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].Text = "@outmsg";
                parameters[8].ParaSize = 200;
                parameters[9].Value = Jgbm;
                parameters[9].Text = "@Jgbm";

                database.DoCommand(sSql, parameters, 300);
                _outcode = Convert.ToInt32(parameters[7].Value);
                _outmsg = parameters[8].Value.ToString();
                if (_outcode != 0)
                    throw new Exception(_outmsg);
                //向中药房发送消息
                GetZcyExectMessage(BinID.ToString(), BabyID.ToString(), GroupID.ToString());
                return _outmsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //执行完毕解锁
                database.DoCommand("update zy_orderexec_lock set lock_bit=0 where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID);
              
            }
        }
        /// <summary>
        /// 获
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="baby_id"></param>
        /// <param name="group_id"></param>
        /// <returns></returns>
        private void  GetZcyExectMessage(string inpatient_id,string baby_id,string group_id) 
        {
            try
            {
                string sql = string.Format(@"select EXEC_DEPT  from zy_orderrecord where status_flag<=5 AND  ntype=3 and  INPATIENT_ID='{0}' and baby_id={1} and group_id={2}", inpatient_id, baby_id, group_id);
                DataTable tb = database.GetDataTable(sql);
                if (tb.Rows.Count > 0)
                {

                    DateTime time = DateTime.Parse(DateManager.ServerDateTimeByDBType(database).ToString("yyyy-MM-dd HH:mm"));
                    if (System.IO.File.Exists("ZcySendTime.txt"))
                    {
                        System.IO.StreamReader sr = new System.IO.StreamReader("ZcySendTime.txt");
                        DateTime time1 = DateTime.Parse(sr.ReadLine());
                        sr.Close();
                        sr.Dispose();
                        TimeSpan ts = time1.Subtract(time);
                        if (ts.Duration().Minutes < 10)
                            return;
                        else
                        {
                            System.IO.FileStream fi = new System.IO.FileStream("ZcySendTime.txt", System.IO.FileMode.Create);
                            fi.Dispose();
                        }
                    }

                    System.IO.File.Create("ZcySendTime.txt").Close();
                    System.IO.StreamWriter sr1 = new System.IO.StreamWriter("ZcySendTime.txt");
                    sr1.WriteLine(time.ToString());
                    sr1.Close();
                    sr1.Dispose();

                

                    int ExecDept_Id = int.Parse(tb.Rows[0]["EXEC_DEPT"].ToString());
                    string msg_wardid = "";
                    long msg_deptid = ExecDept_Id;
                    long msg_empid = 0;
                    string msg_sender = FrmMdiMain.CurrentDept.WardName + "：" + FrmMdiMain.CurrentUser.Name;
                    string msg_msg = "有新的药品消息！";
                    TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.药品系统, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
                    return;
                }
              
                 
                    return;
            }
            catch(Exception EX) { return; }
        }
        /// <summary>
        /// 药品统领
        /// </summary>
        /// <param name="TLFS">统领方式（0=普通[1=缺药 该种状态仅供查询]2=重新发送）</param>
        /// <param name="MsgType">消息类型（0=普通1=退药）</param>
        /// <param name="WardID">病区</param>
        /// <param name="WardDeptId">病区科室</param>
        /// <param name="NurseID">执行护士</param>
        /// <param name="SendDate">日期</param>
        /// <param name="ExecDept_Id">执行药房</param>
        /// <returns></returns>
        public string SendYPFY(int TLFS, int MsgType, string WardID, long WardDeptId, long NurseID, System.DateTime SendDate, long ExecDept_Id, int Jgbm)
        {
            #region 不再使用
            //string sSql = "";
            //string _outmsg = "";
            //int _outcode = 0;
            //ParameterEx[] parameters = new ParameterEx[9];

            //sSql = "sp_zyhs_ypfy_dept";
            //parameters[0].Value = TLFS;
            //parameters[0].Text = "@tlfs";
            //parameters[1].Value = MsgType;
            //parameters[1].Text = "@msg_type";
            //parameters[2].Value = WardID;
            //parameters[2].Text = "@wardid";
            //parameters[3].Value = NurseID;
            //parameters[3].Text = "@user";
            //parameters[4].Value = SendDate;
            //parameters[4].Text = "@senddate";
            //parameters[5].Value = ExecDept_Id;
            //parameters[5].Text = "@execdept_id";
            //parameters[6].ParaDirection = ParameterDirection.Output;
            //parameters[6].Text = "@outcode";
            //parameters[6].ParaSize = 100;
            //parameters[7].ParaDirection = ParameterDirection.Output;
            //parameters[7].Text = "@outmsg";
            //parameters[7].ParaSize = 50;
            //parameters[8].Value = Jgbm;
            //parameters[8].Text = "@Jgbm";

            //try
            //{
            //    database.DoCommand(sSql, parameters, 120);
            //    _outcode = Convert.ToInt32(parameters[6].Value);
            //    _outmsg = parameters[7].Value.ToString();
            //    if (_outcode != 0)
            //        throw new Exception(_outmsg);
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.ToString());
            //}
            #endregion

            string _outmsg = "";

            DataTable tab = ZYHS_YPFY_SELECT(TLFS, MsgType, WardDeptId, WardID, Guid.Empty, 0, ExecDept_Id);
           
            if (tab == null || tab.Rows.Count == 0)
            {
                _outmsg = "没有要发送的药品记录";
                return _outmsg;
            }
            #region yaokx 2-14-03-28 控制大输液的药品是直接发送大输液库房发药
            //add yaokx 2-14-03-28 控制大输液的药品是直接发送大输液库房发药
            /*string execdeptid = (new SystemCfg(7190)).Config;
            DataTable newdt = new DataTable();
            newdt = tab.Clone();
            DataRow[] dr = tab.Select("TLFL='03'");
            for (int i = 0; i < dr.Length; i++)
            {
                newdt.ImportRow((DataRow)dr[i]);
                tab.Rows.Remove((DataRow)dr[i]);
            }

            if (execdeptid != "")
            {
                if (newdt.Rows.Count>0)
                    SendYP(newdt, WardID, NurseID, SendDate, Convert.ToInt64(execdeptid), MsgType, Jgbm);
            }*/
            #endregion
            SendYP(tab, WardID, NurseID, SendDate, ExecDept_Id, MsgType, Jgbm);
            
            return _outmsg;
        }

        /// <summary>
        /// 生成药品统领单
        /// </summary>
        /// <param name="tb">格式参见SP_ZYHS_YPFY_SELECT出参</param>
        /// <param name="WardID">病区ID</param>
        /// <param name="EmpID">用户ID</param>
        /// <param name="SendDate">发送日期</param>
        /// <param name="Jgbm">机构编码</param>
        public void SendYP(DataTable tab, string WardID, long EmpID, System.DateTime SendDate, long ExecDept_Id, int MsgType, int Jgbm)
        {
            if (tab == null || tab.Rows.Count == 0)
            {
                return;
            }
            string swhere = "";
            string[] sql = new string[3];

            string lyflSql = "select * from jc_yplyflk where delete_bit=0 order by code";
            DataTable lyflTb = database.GetDataTable(lyflSql);

            TsSet tsset = new TsSet();
            string[] GroupbyField1 ={ "dept_ly" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };

            tsset.TsDataTable = tab;
            DataTable deptlyTb = tsset.GroupTable(GroupbyField1, ComputeField1, CField1, "");

            try
            {
                //如果没有设置领药分类，那么默认99
                if (lyflTb == null || lyflTb.Rows.Count == 0)
                {
                    
                    for (int k = 0; k < deptlyTb.Rows.Count; k++)
                    {
                        DataRow[] drs = tab.Select("dept_ly=" + deptlyTb.Rows[k]["dept_ly"].ToString());
                        DataTable tmpTab = tab.Clone();

                        foreach (DataRow dr in drs)
                        {
                            tmpTab.ImportRow(dr);
                        }

                        swhere = "";
                        for (int i = 0; i < tmpTab.Rows.Count; i++)
                        {
                            if (swhere == "")
                            {
                                swhere = "'" + tmpTab.Rows[i]["zy_id"].ToString().Trim() + "'";
                            }
                            else
                            {
                                swhere += ",'" + tmpTab.Rows[i]["zy_id"].ToString().Trim() + "'";
                            }
                        }

                        Guid _applyid = PubStaticFun.NewGuid();
                        sql[0] = "INSERT INTO ZY_APPLY_DRUG(APPLY_ID,APPLY_DATE,APPLY_NURSE,DEPT_LY,EXECDEPT_ID,MSG_TYPE,LYFLCODE,GROUP_ID,JGBM) " +
                                " VALUES('" + _applyid + "','" + SendDate + "'," + EmpID + "," + deptlyTb.Rows[k]["dept_ly"].ToString() + ",'" + ExecDept_Id + "'," + MsgType + ",'99',DBO.FUN_GETEMPTYGUID()," + Jgbm + ") ";
                        sql[1] = "UPDATE ZY_FEE_SPECI SET APPLY_ID='" + _applyid + "' " +
                                " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";
                        //增加对历史表处理 add by zouchihua 2013-5-24
                        sql[2] = "UPDATE ZY_FEE_SPECI_H SET APPLY_ID='" + _applyid + "' " +
                                " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";
                        database.DoCommand(null, null, null, sql);
                    }
                }
                else
                {
                    //add by zouchihua  2012-3-2
                 
                    string cfg7104 = "0";
                    string cfg7048 = new SystemCfg(7048).Config.Trim();
                    cfg7104 = new SystemCfg(7104).Config.Trim();
                    string[] spistr = cfg7048.Split(',');
                    string whereIN = "('999'";
                    for (int i = 0; i < spistr.Length; i++)
                    {
                        whereIN += ",'"+spistr[i] + "'";
                    }
                    whereIN += ")";
                        for (int k = 0; k < deptlyTb.Rows.Count; k++)
                        {
                            DataRow[] drs = tab.Select("dept_ly=" + deptlyTb.Rows[k]["dept_ly"].ToString());
                            DataTable tmpTab = tab.Clone();

                            foreach (DataRow dr in drs)
                            {
                                tmpTab.ImportRow(dr);
                            }

                            string[] ypjx = new string[lyflTb.Rows.Count];
                            string[] ypyf = new string[lyflTb.Rows.Count];
                            string[] _where = new string[lyflTb.Rows.Count];
                            string[] _notwhere = new string[lyflTb.Rows.Count];

                            DataTable tmpTb = tmpTab.Copy();
                            for (int j = 0; j < lyflTb.Rows.Count; j++)
                            {
                                _where[j] = "";
                                //_notwhere[j] = "";
                                ypjx[j] = lyflTb.Rows[j]["ypjx"].ToString().Trim();
                                ypyf[j] = lyflTb.Rows[j]["ypyf"].ToString().Trim();

                                if (ypjx[j] != "" && ypyf[j] != "")
                                {
                                    //add by zouchihua 2012-3-2未拆零口服药统领    长期医嘱，01 ，拆零的
                                    //如果领药分类为01 摆药单，且不拆零 只有长期医嘱并且为01的
                                    if (cfg7104 == "1") //优先是拆零口服药
                                    {
                                        _where[j] += "UNITRATE>1 and MNGTYPE=0 and  tlfl in " + whereIN;//('" + cfg7048 + "','999') ";
                                    }
                                    else
                                        if (cfg7104 == "2")//只有长期医嘱摆药（满足摆药条件）
                                        {
                                            _where[j] = " MNGTYPE=0  and  ypjx in (" + ypjx[j] + ") and ypyf in (" + ypyf[j] + ") ";
                                        }
                                        else
                                            if (cfg7104 == "3")//拆零口服药进摆药单 ：不区分临时和长期
                                                _where[j] += "UNITRATE>1  and  tlfl in " + whereIN;
                                            else
                                            _where[j] = " ypjx in (" + ypjx[j] + ") and ypyf in (" + ypyf[j] + ") ";
                                    _notwhere[j] = " ypjx not in (" + ypjx[j] + ") and ypyf not in (" + ypyf[j] + ") ";
                                }

                                if (_where[j] != "")
                                {
                                    DataRow[] tmprows = tmpTb.Select(_where[j]);
                                    DataTable tmptb = tmpTb.Clone();
                                    for (int i = 0; i < tmprows.Length; i++)
                                    {
                                        tmptb.ImportRow(tmprows[i]);
                                        tmpTb.Rows.Remove(tmprows[i]);
                                    }

                                    swhere = "";
                                    for (int i = 0; i < tmptb.Rows.Count; i++)
                                    {
                                        if (swhere == "")
                                        {
                                            swhere = "'" + tmptb.Rows[i]["zy_id"].ToString().Trim() + "'";
                                        }
                                        else
                                        {
                                            swhere += ",'" + tmptb.Rows[i]["zy_id"].ToString().Trim() + "'";
                                        }
                                    }

                                    if (swhere != "")
                                    {
                                        Guid _applyid = PubStaticFun.NewGuid();
                                        sql[0] = "INSERT INTO ZY_APPLY_DRUG(APPLY_ID,APPLY_DATE,APPLY_NURSE,DEPT_LY,EXECDEPT_ID,MSG_TYPE,LYFLCODE,GROUP_ID,JGBM) " +
                                                " VALUES('" + _applyid + "','" + SendDate + "'," + EmpID + ",'" + deptlyTb.Rows[k]["dept_ly"].ToString() + "','" + ExecDept_Id + "'," + MsgType + ",'" + lyflTb.Rows[j]["code"].ToString() + "',DBO.FUN_GETEMPTYGUID()," + Jgbm + ") ";
                                        sql[1] = "UPDATE ZY_FEE_SPECI SET APPLY_ID='" + _applyid + "' " +
                                                " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";
                                        //增加对历史表处理 add by zouchihua 2013-5-24
                                        sql[2] = "UPDATE ZY_FEE_SPECI_H SET APPLY_ID='" + _applyid + "' " +
                                                " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";

                                        database.DoCommand(null, null, null, sql);
                                    }
                                }
                            }

                            //其他的
                            swhere = "";
                            for (int i = 0; i < tmpTb.Rows.Count; i++)
                            {
                                if (swhere == "")
                                {
                                    swhere = "'" + tmpTb.Rows[i]["zy_id"].ToString().Trim() + "'";
                                }
                                else
                                {
                                    swhere += ",'" + tmpTb.Rows[i]["zy_id"].ToString().Trim() + "'";
                                }
                            }

                            if (swhere != "")
                            {
                                Guid _applyid = PubStaticFun.NewGuid();
                                sql[0] = "INSERT INTO ZY_APPLY_DRUG(APPLY_ID,APPLY_DATE,APPLY_NURSE,DEPT_LY,EXECDEPT_ID,MSG_TYPE,LYFLCODE,GROUP_ID,JGBM) " +
                                        " VALUES('" + _applyid + "','" + SendDate + "'," + EmpID + ",'" + deptlyTb.Rows[k]["dept_ly"].ToString() + "','" + ExecDept_Id + "'," + MsgType + ",'99',DBO.FUN_GETEMPTYGUID()," + Jgbm + ") ";
                                sql[1] = "UPDATE ZY_FEE_SPECI SET APPLY_ID='" + _applyid + "' " +
                                        " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";
                                //增加对历史表处理 add by zouchihua 2013-5-24
                                sql[2] = "UPDATE ZY_FEE_SPECI_H SET APPLY_ID='" + _applyid + "' " +
                                        " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";
                                database.DoCommand(null, null, null, sql);
                            }
                        }
                }
                // scdj(tab, (int)ExecDept_Id);
                string msg_wardid = "";
                long msg_deptid = ExecDept_Id;
                long msg_empid = 0;
                string msg_sender = FrmMdiMain.CurrentDept.WardName + "：" + FrmMdiMain.CurrentUser.Name;
                string msg_msg = "有新的药品消息！";
                TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.药品系统, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        /// <summary>
        /// 生成药品统领单
        /// </summary>
        /// <param name="tb">格式参见SP_ZYHS_YPFY_SELECT出参</param>
        /// <param name="WardID">病区ID</param>
        /// <param name="EmpID">用户ID</param>
        /// <param name="SendDate">发送日期</param>
        /// <param name="Jgbm">机构编码</param>
        public  void SendYPzcgl(DataTable tab, string WardID, long EmpID, System.DateTime SendDate, long ExecDept_Id, int MsgType, int Jgbm)
        {
            if (tab == null || tab.Rows.Count == 0)
            {
                return;
            }

            string swhere = "";
            string[] sql = new string[3];

            string lyflSql = "select * from jc_yplyflk where delete_bit=0 order by code";
            DataTable lyflTb = database.GetDataTable(lyflSql);

            TsSet tsset = new TsSet();
            string[] GroupbyField1 ={ "dept_ly" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };

            tsset.TsDataTable = tab;
            DataTable deptlyTb = tsset.GroupTable(GroupbyField1, ComputeField1, CField1, "");
            database.BeginTransaction();
            try
            {
                //如果没有设置领药分类，那么默认99
                if (lyflTb == null || lyflTb.Rows.Count == 0)
                {
                    for (int k = 0; k < deptlyTb.Rows.Count; k++)
                    {
                        DataRow[] drs = tab.Select("dept_ly=" + deptlyTb.Rows[k]["dept_ly"].ToString());
                        DataTable tmpTab = tab.Clone();

                        foreach (DataRow dr in drs)
                        {
                            tmpTab.ImportRow(dr);
                        }

                        swhere = "";
                        for (int i = 0; i < tmpTab.Rows.Count; i++)
                        {
                            if (swhere == "")
                            {
                                swhere = "'" + tmpTab.Rows[i]["zy_id"].ToString().Trim() + "'";
                            }
                            else
                            {
                                swhere += ",'" + tmpTab.Rows[i]["zy_id"].ToString().Trim() + "'";
                            }
                        }

                        Guid _applyid = PubStaticFun.NewGuid();
                        sql[0] = "INSERT INTO ZY_APPLY_DRUG(APPLY_ID,APPLY_DATE,APPLY_NURSE,DEPT_LY,EXECDEPT_ID,MSG_TYPE,LYFLCODE,GROUP_ID,JGBM) " +
                                " VALUES('" + _applyid + "','" + SendDate + "'," + EmpID + "," + deptlyTb.Rows[k]["dept_ly"].ToString() + ",'" + ExecDept_Id + "'," + MsgType + ",'99',DBO.FUN_GETEMPTYGUID()," + Jgbm + ") ";
                        database.DoCommand(sql[0]);
                        sql[1] = "UPDATE ZY_FEE_SPECI SET APPLY_ID='" + _applyid + "' " +
                                " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";
                        database.DoCommand(sql[1]);
                        //增加对历史表处理 add by zouchihua 2013-5-24
                        sql[2] = "UPDATE ZY_FEE_SPECI_H SET APPLY_ID='" + _applyid + "' " +
                                " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";
                        database.DoCommand(sql[2]);
                        //  InstanceForm.BDatabase.DoCommand(null, null, null, sql);
                    }
                }
                else
                {
                    //add by zouchihua  2012-3-2
                    string cfg7104 = "0";
                    string cfg7048 = new SystemCfg(7048).Config.Trim();
                    cfg7104 = new SystemCfg(7104).Config.Trim();
                    string[] spistr = cfg7048.Split(',');
                    string whereIN = "('999'";
                    for (int i = 0; i < spistr.Length; i++)
                    {
                        whereIN += ",'" + spistr[i] + "'";
                    }
                    whereIN += ")";
                    for (int k = 0; k < deptlyTb.Rows.Count; k++)
                    {
                        DataRow[] drs = tab.Select("dept_ly=" + deptlyTb.Rows[k]["dept_ly"].ToString());
                        DataTable tmpTab = tab.Clone();

                        foreach (DataRow dr in drs)
                        {
                            tmpTab.ImportRow(dr);
                        }

                        string[] ypjx = new string[lyflTb.Rows.Count];
                        string[] ypyf = new string[lyflTb.Rows.Count];
                        string[] _where = new string[lyflTb.Rows.Count];
                        string[] _notwhere = new string[lyflTb.Rows.Count];

                        DataTable tmpTb = tmpTab.Copy();
                        for (int j = 0; j < lyflTb.Rows.Count; j++)
                        {
                            _where[j] = "";
                            //_notwhere[j] = "";
                            ypjx[j] = lyflTb.Rows[j]["ypjx"].ToString().Trim();
                            ypyf[j] = lyflTb.Rows[j]["ypyf"].ToString().Trim();

                            if (ypjx[j] != "" && ypyf[j] != "")
                            {
                                //add by zouchihua 2012-3-2未拆零口服药统领    长期医嘱，01 ，拆零的
                                //如果领药分类为01 摆药单，且不拆零 只有长期医嘱并且为01的
                                if (cfg7104 == "1") //优先是拆零口服药
                                {
                                    _where[j] += "UNITRATE>1 and MNGTYPE=0 and  tlfl in " + whereIN;//('" + cfg7048 + "','999') ";
                                }
                                else
                                    if (cfg7104 == "2")//只有长期医嘱摆药（满足摆药条件）
                                    {
                                        _where[j] = " MNGTYPE=0  and  ypjx in (" + ypjx[j] + ") and ypyf in (" + ypyf[j] + ") ";
                                    }
                                    else
                                        if (cfg7104 == "3")//拆零口服药进摆药单 ：不区分临时和长期
                                            _where[j] += "UNITRATE>1  and  tlfl in " + whereIN;
                                        else
                                            _where[j] = " ypjx in (" + ypjx[j] + ") and ypyf in (" + ypyf[j] + ") ";
                                _notwhere[j] = " ypjx not in (" + ypjx[j] + ") and ypyf not in (" + ypyf[j] + ") ";
                            }

                            if (_where[j] != "")
                            {
                                DataRow[] tmprows = tmpTb.Select(_where[j]);
                                DataTable tmptb = tmpTb.Clone();
                                for (int i = 0; i < tmprows.Length; i++)
                                {
                                    tmptb.ImportRow(tmprows[i]);
                                    tmpTb.Rows.Remove(tmprows[i]);
                                }

                                swhere = "";
                                for (int i = 0; i < tmptb.Rows.Count; i++)
                                {
                                    if (swhere == "")
                                    {
                                        swhere = "'" + tmptb.Rows[i]["zy_id"].ToString().Trim() + "'";
                                    }
                                    else
                                    {
                                        swhere += ",'" + tmptb.Rows[i]["zy_id"].ToString().Trim() + "'";
                                    }
                                }

                                if (swhere != "")
                                {
                                    Guid _applyid = PubStaticFun.NewGuid();
                                    sql[0] = "INSERT INTO ZY_APPLY_DRUG(APPLY_ID,APPLY_DATE,APPLY_NURSE,DEPT_LY,EXECDEPT_ID,MSG_TYPE,LYFLCODE,GROUP_ID,JGBM) " +
                                            " VALUES('" + _applyid + "','" + SendDate + "'," + EmpID + ",'" + deptlyTb.Rows[k]["dept_ly"].ToString() + "','" + ExecDept_Id + "'," + MsgType + ",'" + lyflTb.Rows[j]["code"].ToString() + "',DBO.FUN_GETEMPTYGUID()," + Jgbm + ") ";
                                    database.DoCommand(sql[0]);
                                    sql[1] = "UPDATE ZY_FEE_SPECI SET APPLY_ID='" + _applyid + "' " +
                                            " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";
                                    database.DoCommand(sql[1]);
                                    //增加对历史表处理 add by zouchihua 2013-5-24
                                    sql[2] = "UPDATE ZY_FEE_SPECI_H SET APPLY_ID='" + _applyid + "' " +
                                            " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";
                                    database.DoCommand(sql[2]);
                                    // InstanceForm.BDatabase.DoCommand(null, null, null, sql);
                                }
                            }
                        }

                        //其他的
                        swhere = "";
                        for (int i = 0; i < tmpTb.Rows.Count; i++)
                        {
                            if (swhere == "")
                            {
                                swhere = "'" + tmpTb.Rows[i]["zy_id"].ToString().Trim() + "'";
                            }
                            else
                            {
                                swhere += ",'" + tmpTb.Rows[i]["zy_id"].ToString().Trim() + "'";
                            }
                        }

                        if (swhere != "")
                        {
                            Guid _applyid = PubStaticFun.NewGuid();
                            sql[0] = "INSERT INTO ZY_APPLY_DRUG(APPLY_ID,APPLY_DATE,APPLY_NURSE,DEPT_LY,EXECDEPT_ID,MSG_TYPE,LYFLCODE,GROUP_ID,JGBM) " +
                                    " VALUES('" + _applyid + "','" + SendDate + "'," + EmpID + ",'" + deptlyTb.Rows[k]["dept_ly"].ToString() + "','" + ExecDept_Id + "'," + MsgType + ",'99',DBO.FUN_GETEMPTYGUID()," + Jgbm + ") ";
                            database.DoCommand(sql[0]);
                            sql[1] = "UPDATE ZY_FEE_SPECI SET APPLY_ID='" + _applyid + "' " +
                                    " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";
                            database.DoCommand(sql[1]);
                            //增加对历史表处理 add by zouchihua 2013-5-24
                            sql[2] = "UPDATE ZY_FEE_SPECI_H SET APPLY_ID='" + _applyid + "' " +
                                    " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";
                            database.DoCommand(sql[2]);
                            //   InstanceForm.BDatabase.DoCommand(null, null, null, sql);
                        }
                    }
                }
                scdj(tab, (int)ExecDept_Id);

                database.CommitTransaction();
                string msg_wardid = "";
                long msg_deptid = ExecDept_Id;
                long msg_empid = 0;
                string msg_sender = FrmMdiMain.CurrentDept.WardName + "：" + FrmMdiMain.CurrentUser.Name;
                string msg_msg = "有新的药品消息！";
                TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.药品系统, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
            }
            catch (Exception err)
            {
                database.RollbackTransaction();
                MessageBox.Show(err.Message);
            }
        }
        private  void scdj(DataTable tb, int zxksid)
        {
            try
            {
                string[] GroupbyField1 ={ "cjid", "dept_ly", "ZXDW", "tlfl", "单价", "dwbl" };
                string[] ComputeField1 ={ "数量", "金额", "ypsl" };
                string[] CField1 ={ "sum", "sum", "sum" };
                TrasenFrame.Classes.TsSet tsset1 = new TrasenFrame.Classes.TsSet();
                tsset1.TsDataTable = tb;
                DataTable tbflcjid = tsset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
                string[] updatesql = new string[tbflcjid.Rows.Count];
                string[] insertdjxx = new string[tbflcjid.Rows.Count];
                for (int j = 0; j < tbflcjid.Rows.Count; j++)
                {
                    //库存量减少，暂存基数变大
                    updatesql[j] = "  update dbo.Zy_ZcyKcmx set kcl=a.kcl-(" + tbflcjid.Rows[j]["数量"].ToString() + ")*a.DWBL/(" + tbflcjid.Rows[j]["UNITRATE"].ToString() + "),zcjs=zcjs+(" + tbflcjid.Rows[j]["数量"].ToString() + ")*a.DWBL/(" + tbflcjid.Rows[j]["UNITRATE"].ToString() + ")"
                                   + " from Zy_ZcyKcmx a join YF_KCMX b  on a.cjid=b.cjid and b.DEPTID=a.yfksid where a.cjid=" + tbflcjid.Rows[j]["cjid"].ToString() +
                                    " and  ksid=" + tbflcjid.Rows[j]["dept_ly"].ToString()
                                    + " and  yfksid=" + zxksid;
                    database.DoCommand(updatesql[j]);
                    Guid djid = Guid.NewGuid();
                    //同时还要插入单据信息 zy_zcydjxx
                    insertdjxx[j] = string.Format(@"insert into zy_zcydjxx
                                                                    (
                                                                       id, jgbm, deptid, ywlx, wldw, djrq,
                                                                       djy, tlfl, cjid, zxdw, sl, dj,
                                                                        shzt,shry,shsj,ydwbl
                                                                    )
                                                                   values
                                                                   ('" + djid + "', " + FrmMdiMain.Jgbm + @","
                                                              + tbflcjid.Rows[j]["dept_ly"].ToString()
                                                              + @",2," + zxksid + @",getdate(),"//2 表示暂存药发送到药房
                                                              + FrmMdiMain.CurrentUser.EmployeeId + @",'" + tbflcjid.Rows[j]["tlfl"].ToString()
                                                              + @"'," + tbflcjid.Rows[j]["cjid"].ToString() + @"," + tbflcjid.Rows[j]["zxdw"].ToString()
                                                              + @"," + tbflcjid.Rows[j]["ypsl"].ToString()
                                                              + @"," + (decimal.Parse(tbflcjid.Rows[j]["金额"].ToString()) / decimal.Parse(tbflcjid.Rows[j]["ypsl"].ToString()))
                                                              + @",1," + FrmMdiMain.CurrentUser.EmployeeId + @",getdate()," + tbflcjid.Rows[j]["DWBL"].ToString() + @""
                                                              + @")"
                                                          );
                    database.DoCommand(insertdjxx[j]);
                    #region//插入单据明细
                    string filter = "cjid=" + tbflcjid.Rows[j]["cjid"].ToString() + " and  dept_ly=" + tbflcjid.Rows[j]["dept_ly"].ToString()
                                      + "  and  ZXDW=" + tbflcjid.Rows[j]["zxdw"].ToString();
                    DataRow[] _row = tb.Select(filter);
                    for (int k = 0; k < _row.Length; k++)
                    {
                        string feeid = _row[k]["ZY_ID"].ToString();
                        string cjid = _row[k]["CJID"].ToString();
                        string sl = _row[k]["数量"].ToString();

                        string insertdjmx = string.Format(@"insert into zy_zcydjxxmx (  id, djid, feeid, cjid, sl, zxks, scbz)
                                                                              values
                                                                           (dbo.FUN_GETGUID(newid(),getdate()),'" + djid + "','" + feeid + "',"
                                                                             + cjid + "," + sl + "," + zxksid + ",0" +
                                                                           @")");
                        database.DoCommand(insertdjmx);
                    }
                    #endregion
                }
                //InstanceForm.BDatabase.DoCommand(null, null, null, updatesql);
                //InstanceForm.BDatabase.DoCommand(null, null, null, insertdjxx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cszcyp(DataTable tb, string Wardeptid, long EmpID, long ExecDept_Id,DateTime dt,int Jgbm,out Guid group_id)
        {
            database.BeginTransaction();
            group_id = Guid.Empty;
            try
            {
                if (tb == null || tb.Rows.Count == 0)
                    return;
                decimal SUMPFJE = 0;
                decimal SUMLSJE = 0;
                ParameterEx[] parameters = new ParameterEx[24];
                Guid Group_id =Guid.NewGuid();
                group_id=Group_id;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    SUMPFJE += decimal.Parse(tb.Rows[i]["批发金额"].ToString());
                    SUMLSJE += decimal.Parse(tb.Rows[i]["金额"].ToString());
                    parameters[0].Text = "GROUPID";
                    parameters[0].Value = Group_id;
                    parameters[1].Text = "CJID";
                    parameters[1].Value = Int32.Parse(tb.Rows[i]["cjid"].ToString());
                    parameters[2].Text = "SHH";
                    parameters[2].Value = tb.Rows[i]["货号"].ToString();
                    parameters[3].Text = "YPPM";
                    parameters[3].Value = tb.Rows[i]["品名"].ToString();
                    parameters[4].Text = "YPSPM";
                    parameters[4].Value = tb.Rows[i]["商品名"].ToString();
                    parameters[5].Text = "YPGG";
                    parameters[5].Value = tb.Rows[i]["规格"].ToString();
                    parameters[6].Text = "YPDW";
                    parameters[6].Value = tb.Rows[i]["单位"].ToString();
                    parameters[7].Text = "SCCJ";
                    parameters[7].Value = tb.Rows[i]["厂家"].ToString();
                    parameters[8].Text = "KCL";//不设计到库存量
                    parameters[8].Value = 9999;
                    parameters[9].Text = "YPSL";
                    parameters[9].Value = Convert.ToDecimal(tb.Rows[i]["数量"].ToString());
                    parameters[10].Text = "QysL";
                    parameters[10].Value = 0;
                    parameters[11].Text = "PFJ";
                    parameters[11].Value = decimal.Parse(tb.Rows[i]["批发价"].ToString());
                    parameters[12].Text = "LSJ";
                    parameters[12].Value = decimal.Parse(tb.Rows[i]["单价"].ToString());
                    parameters[13].Text = "PFJE";
                    parameters[13].Value = decimal.Parse(tb.Rows[i]["批发金额"].ToString());
                    parameters[14].Text = "LSJE";
                    parameters[14].Value = decimal.Parse(tb.Rows[i]["金额"].ToString());
                    parameters[15].Text = "TLFL";
                    parameters[15].Value = tb.Rows[i]["TLFL"].ToString();
                    parameters[16].Text = "DWBL";
                    parameters[16].Value = tb.Rows[i]["UNITRATE"].ToString();
                    parameters[17].Text = "bkc";
                    parameters[17].Value = 0;
                    parameters[18].Text = "deptid";
                    parameters[18].Value = ExecDept_Id;
                    parameters[19].Text = "ypph";
                    parameters[19].Value = "";
                    parameters[20].Text = "fyid";
                    parameters[20].Value = Guid.Empty;
                    parameters[20].ParaDirection = ParameterDirection.Output;
                    parameters[21].Text = "ERR_CODE";
                    parameters[21].Value = 0;
                    parameters[21].ParaDirection = ParameterDirection.Output;
                    parameters[22].Text = "ERR_TEXT";
                    parameters[22].Value = "";
                    parameters[22].ParaDirection = ParameterDirection.Output;
                    parameters[23].Text = "hwh";
                    parameters[23].Value = "";
                    database.DoCommand("sp_YF_TLDMX_zcy", parameters, 60);
                }
                ParameterEx[] parameters1 = new ParameterEx[18];
                parameters1[0].Text = "DJH";
                parameters1[0].Value = 0;
                parameters1[1].Text = "DEPTID";
                parameters1[1].Value = ExecDept_Id;
                parameters1[2].Text = "FYRQ";
                parameters1[2].Value = dt.ToString();
                parameters1[3].Text = "FYR";
                parameters1[3].Value = EmpID;
                parameters1[4].Text = "dept_ly";
                parameters1[4].Value =Int32.Parse( Wardeptid);
                parameters1[5].Text = "NURSEID";
                parameters1[5].Value = 0;
                parameters1[6].Text = "PYR";
                parameters1[6].Value = EmpID;
                parameters1[7].Text = "bz";
                parameters1[7].Value = "";
                parameters1[8].Text = "SUMPFJE";
                parameters1[8].Value = SUMPFJE;
                parameters1[9].Text = "SUMLSJE";
                parameters1[9].Value = SUMLSJE;
                parameters1[10].Text = "STYPE";
                parameters1[10].Value = "统领";
                parameters1[11].Text = "ywlx";
                parameters1[11].Value = "020";
                parameters1[12].Text = "GROUPID";
                parameters1[12].Value = Group_id;
                parameters1[13].Text = "ERR_CODE";
                parameters1[13].Value = 0;
                parameters1[13].ParaDirection = ParameterDirection.Output;
                parameters1[14].Text = "ERR_TEXT";
                parameters1[14].Value = "";
                parameters1[14].ParaDirection = ParameterDirection.Output;
                parameters1[15].Text = "jgbm";
                parameters1[15].Value = Jgbm;
                parameters1[16].Text = "wkdz";
                parameters1[16].Value = "";
                parameters1[17].Text = "LYLX";
                parameters1[17].Value = 0;
                database.DoCommand("sp_YF_TLD_zcy", parameters1, 120);
                database.CommitTransaction();
            }
            catch (Exception ex)
            {
                database.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetFeeTotal(string sSql, int kind, string WardID, System.DateTime bDate, System.DateTime eDate)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[4];

            sSql = "SP_ZYHS_GET_FEETOTAL";
            parameters[0].Value = kind;
            parameters[1].Value = WardID;
            parameters[2].Value = bDate.ToString();
            parameters[3].Value = eDate.ToString();

            myTb = database.GetDataTable(sSql, parameters, 60);

            //返回数据表对象
            return myTb;
        }

        #region HS_HLITEMCONFIG（废）
        //		public string HS_HLITEMCONFIG(int v_kind, decimal v_hlitem_id, string v_hlitem_name, decimal v_item_id, string v_item_name, int v_flag)
        //		{
        //			try
        //			{
        //				string rtnStr="";
        //				OleDbCommand myCmd = new OleDbCommand();
        //				OleDbParameter parm;
        //
        //				myCmd.CommandText="ZYHS_HLITEMCONFIG";
        //				myCmd.CommandTimeout=60;
        //				myCmd.Connection=new OleDbConnection(DatabaseAccess.GetConnectionString(DatabaseType.IbmDb2ZY));
        //				myCmd.CommandType=CommandType.StoredProcedure;
        //				parm=myCmd.Parameters.Add("@kind",OleDbType.Integer);
        //				parm.Direction=ParameterDirection.Input;
        //				parm.Value=v_kind;
        //				parm=myCmd.Parameters.Add("@hlitem_id",OleDbType.Decimal,18);
        //				parm.Direction=ParameterDirection.Input;
        //				parm.Value=v_hlitem_id;
        //				parm=myCmd.Parameters.Add("@hlitem_name",OleDbType.Char,20);
        //				parm.Direction=ParameterDirection.Input;
        //				parm.Value=v_hlitem_name;
        //				parm=myCmd.Parameters.Add("@item_id",OleDbType.Decimal,18);
        //				parm.Direction=ParameterDirection.Input;
        //				parm.Value=v_item_id;
        //				parm=myCmd.Parameters.Add("@item_name",OleDbType.Char,50);
        //				parm.Direction=ParameterDirection.Input;
        //				parm.Value=v_item_name;
        //				parm=myCmd.Parameters.Add("@flag",OleDbType.Integer);
        //				parm.Direction=ParameterDirection.Input;
        //				parm.Value=v_flag;
        //				parm=myCmd.Parameters.Add("@out_msg",OleDbType.Char,1024);
        //				parm.Direction=ParameterDirection.Output;
        //				myCmd.ExecuteNonQuery();
        //				rtnStr=myCmd.Parameters["@out_msg"].Value.ToString().Trim();
        //
        //				
        //				return rtnStr;
        //			}
        //			catch(Exception err)
        //			{
        //				//写错误日志 Add By Tany 2005-01-12
        //				SystemLog _systemErrLog=new SystemLog(-1,FrmMdiMain.CurrentDept.DeptId,FrmMdiMain.CurrentUser.EmployeeId,"程序错误","ZYHS_HLITEMCONFIG错误："+err.Message+"  Source："+err.Source,DateManager.ServerDateTimeByDBType(database),1,"主机名："+System.Environment.MachineName,39);
        //				_systemErrLog.Save();
        //				_systemErrLog=null;
        //
        //				MessageBox.Show("错误："+err.Message+"\n"+"Source："+err.Source,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
        //				
        //				return "F程序错误！";
        //			}
        //		}
        #endregion

        public DataTable HS_ORDERPRINT(Guid _inpatient_id, long _baby_id, int _OrderType, int _Type, long _user_id, int _bpage, int _epage)
        {
            DataTable rtnTb = new DataTable();
            string sSql = "";
            string _outmsg = "";
            int _outcode = 0;
            ParameterEx[] parameters = new ParameterEx[11];

            try
            {
                sSql = "SP_ZYHS_ORDERPRINT";

                parameters[0].Value = _inpatient_id;
                parameters[0].Text = "@inpatient_id";
                parameters[1].Value = _baby_id;
                parameters[1].Text = "@baby_id";
                parameters[2].Value = _OrderType;
                parameters[2].Text = "@order_type";
                parameters[3].Value = _Type;
                parameters[3].Text = "@type";
                parameters[4].Value = _user_id;
                parameters[4].Text = "@user_id";
                parameters[5].Value = _bpage;
                parameters[5].Text = "@bpage_no";
                parameters[6].Value = _epage;
                parameters[6].Text = "@epage_no";
                parameters[7].ParaDirection = ParameterDirection.Output;
                parameters[7].Text = "@outcode";
                parameters[7].ParaSize = 100;
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].Text = "@outmsg";
                parameters[8].ParaSize = 50;


                parameters[9].Value = -1;
                parameters[9].Text = "@brow";
                parameters[10].Value = -1;
                parameters[10].Text = "@erow";
                rtnTb = database.GetDataTable(sSql, parameters, 60);

                _outcode = Convert.ToInt32(parameters[7].Value);
                _outmsg = parameters[8].Value.ToString().Trim();
                if (_outcode != 0)
                {
                    MessageBox.Show(_outmsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return rtnTb;
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "SP_ZYHS_ORDERPRINT错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return rtnTb;
            }
        }
        public DataTable HS_ORDERPRINT_cz(Guid _inpatient_id, long _baby_id, int _OrderType, int _Type, long _user_id, int _bpage, int _epage)
        {
            DataTable rtnTb = new DataTable();
            string sSql = "";
            string _outmsg = "";
            int _outcode = 0;
            ParameterEx[] parameters = new ParameterEx[11];

            try
            {
                sSql = "SP_ZYHS_ORDERPRINT_cz";

                parameters[0].Value = _inpatient_id;
                parameters[0].Text = "@inpatient_id";
                parameters[1].Value = _baby_id;
                parameters[1].Text = "@baby_id";
                parameters[2].Value = _OrderType;
                parameters[2].Text = "@order_type";
                parameters[3].Value = _Type;
                parameters[3].Text = "@type";
                parameters[4].Value = _user_id;
                parameters[4].Text = "@user_id";
                parameters[5].Value = _bpage;
                parameters[5].Text = "@bpage_no";
                parameters[6].Value = _epage;
                parameters[6].Text = "@epage_no";
                parameters[7].ParaDirection = ParameterDirection.Output;
                parameters[7].Text = "@outcode";
                parameters[7].ParaSize = 100;
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].Text = "@outmsg";
                parameters[8].ParaSize = 50;


                parameters[9].Value = -1;
                parameters[9].Text = "@brow";
                parameters[10].Value = -1;
                parameters[10].Text = "@erow";
                rtnTb = database.GetDataTable(sSql, parameters, 60);

                _outcode = Convert.ToInt32(parameters[7].Value);
                _outmsg = parameters[8].Value.ToString().Trim();
                if (_outcode != 0)
                {
                    MessageBox.Show(_outmsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return rtnTb;
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "SP_ZYHS_ORDERPRINT错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return rtnTb;
            }
        }
        /// <summary>
        /// 重打时调用
        /// </summary>
        /// <param name="_inpatient_id"></param>
        /// <param name="_baby_id"></param>
        /// <param name="_OrderType"></param>
        /// <param name="_Type"></param>
        /// <param name="_user_id"></param>
        /// <param name="_bpage"></param>
        /// <param name="_epage"></param>
        /// <param name="_bRow"></param>
        /// <param name="_Erow"></param>
        /// <returns></returns>
        public DataTable HS_ORDERPRINT(Guid _inpatient_id, long _baby_id, int _OrderType, int _Type, long _user_id, int _bpage, int _epage,int _bRow,int _Erow)
        {
            DataTable rtnTb = new DataTable();
            string sSql = "";
            string _outmsg = "";
            int _outcode = 0;
            ParameterEx[] parameters = new ParameterEx[11];

            try
            {
                sSql = "SP_ZYHS_ORDERPRINT";

                parameters[0].Value = _inpatient_id;
                parameters[0].Text = "@inpatient_id";
                parameters[1].Value = _baby_id;
                parameters[1].Text = "@baby_id";
                parameters[2].Value = _OrderType;
                parameters[2].Text = "@order_type";
                parameters[3].Value = _Type;
                parameters[3].Text = "@type";
                parameters[4].Value = _user_id;
                parameters[4].Text = "@user_id";
                parameters[5].Value = _bpage;
                parameters[5].Text = "@bpage_no";
                parameters[6].Value = _epage;
                parameters[6].Text = "@epage_no";
                parameters[7].ParaDirection = ParameterDirection.Output;
                parameters[7].Text = "@outcode";
                parameters[7].ParaSize = 100;
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].Text = "@outmsg";
                parameters[8].ParaSize = 50;

                parameters[9].Value = _bRow;
                parameters[9].Text = "@brow";
                parameters[10].Value = _Erow;
                parameters[10].Text = "@erow";
                rtnTb = database.GetDataTable(sSql, parameters, 60);

                _outcode = Convert.ToInt32(parameters[7].Value);
                _outmsg = parameters[8].Value.ToString().Trim();
                if (_outcode != 0)
                {
                    MessageBox.Show(_outmsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                string tj = "1=1 ";
                if (_bRow != -1)
                {
                    tj += "  and ((PAGENO=" + _bpage + " and ROWNO>=" + _bRow + " ) or PAGENO>" + _bpage + ") ";
                }
                if (_Erow != -1)
                {
                    tj += " and ((PAGENO=" + _epage + " and  ROWNO<=" + _Erow + " ) or PAGENO<" + _epage + ") ";
                }
                rtnTb.DefaultView.RowFilter=tj;
                rtnTb = rtnTb.DefaultView.ToTable();
                return rtnTb;
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "SP_ZYHS_ORDERPRINT错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return rtnTb;
            }
        }
        /// <summary>
        /// 不在使用
        /// </summary>
        /// <param name="_inpatient_id"></param>
        /// <param name="_baby_id"></param>
        /// <param name="_OrderType"></param>
        /// <param name="_Type"></param>
        /// <param name="_user_id"></param>
        /// <param name="_bpage"></param>
        /// <param name="_epage"></param>
        /// <param name="onlyexec"></param>
        /// <returns></returns>
        public string HS_ORDERPRINT(Guid _inpatient_id, long _baby_id, int _OrderType, int _Type, long _user_id, int _bpage, int _epage, int onlyexec)
        {
            string rtnStr = "";
            string sSql = "";
            string _outmsg = "";
            int _outcode = 0;
            ParameterEx[] parameters = new ParameterEx[9];

            try
            {
                sSql = "SP_ZYHS_ORDERPRINT";

                parameters[0].Value = _inpatient_id;
                parameters[0].Text = "@inpatient_id";
                parameters[1].Value = _baby_id;
                parameters[1].Text = "@baby_id";
                parameters[2].Value = _OrderType;
                parameters[2].Text = "@order_type";
                parameters[3].Value = _Type;
                parameters[3].Text = "@type";
                parameters[4].Value = _user_id;
                parameters[4].Text = "@user_id";
                parameters[5].Value = _bpage;
                parameters[5].Text = "@bpage_no";
                parameters[6].Value = _epage;
                parameters[6].Text = "@epage_no";
                parameters[7].ParaDirection = ParameterDirection.Output;
                parameters[7].Text = "@outcode";
                parameters[7].ParaSize = 100;
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].Text = "@outmsg";
                parameters[8].ParaSize = 50;

                database.DoCommand(sSql, parameters, 60);

                rtnStr = parameters[8].Value.ToString().Trim();

                return rtnStr;
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "SP_ZYHS_ORDERPRINT错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return rtnStr;
            }
        }
        public string HS_ORDERPRINT(Guid _inpatient_id, long _baby_id, int _OrderType, int _Type, long _user_id, int _bpage, int _epage, int onlyexec,int _brow,int _erow)
        {
            string rtnStr = "";
            string sSql = "";
            string _outmsg = "";
            int _outcode = 0;
            ParameterEx[] parameters = new ParameterEx[11];

            try
            {
                sSql = "SP_ZYHS_ORDERPRINT";

                parameters[0].Value = _inpatient_id;
                parameters[0].Text = "@inpatient_id";
                parameters[1].Value = _baby_id;
                parameters[1].Text = "@baby_id";
                parameters[2].Value = _OrderType;
                parameters[2].Text = "@order_type";
                parameters[3].Value = _Type;
                parameters[3].Text = "@type";
                parameters[4].Value = _user_id;
                parameters[4].Text = "@user_id";
                parameters[5].Value = _bpage;
                parameters[5].Text = "@bpage_no";
                parameters[6].Value = _epage;
                parameters[6].Text = "@epage_no";
                parameters[7].ParaDirection = ParameterDirection.Output;
                parameters[7].Text = "@outcode";
                parameters[7].ParaSize = 100;
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].Text = "@outmsg";
                parameters[8].ParaSize = 50;
                parameters[9].Value = _brow;
                parameters[9].Text = "@brow";
                parameters[10].Value = _erow;
                parameters[10].Text = "@erow";

                database.DoCommand(sSql, parameters, 60);

                rtnStr = parameters[8].Value.ToString().Trim();

                return rtnStr;
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "SP_ZYHS_ORDERPRINT错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return rtnStr;
            }
        }

        public decimal GetOrderFee(Guid inpatient_id, long baby_id, int mngtype, int group_id, DateTime bookdate, DateTime execdate)
        {
            //查询一组医嘱的价格
            string sSql = "sp_zyhs_getorderfee";
            decimal rtnValue = 0;

            ParameterEx[] parameters = new ParameterEx[6];

            parameters[0].Value = inpatient_id;
            parameters[0].Text = "@inpatientid";
            parameters[1].Value = baby_id;
            parameters[1].Text = "@babyid";
            parameters[2].Value = group_id;
            parameters[2].Text = "@groupid";
            parameters[3].Value = mngtype;
            parameters[3].Text = "@mngtype";
            parameters[4].Value = bookdate;
            parameters[4].Text = "@bookdate";
            parameters[5].Value = execdate;
            parameters[5].Text = "@execdate";

            try
            {
                rtnValue = Convert.ToDecimal(Convertor.IsNull(database.GetDataResult(sSql, parameters, 120), "0"));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return 0;
            }

            return rtnValue;
        }

        public decimal GetOrderFeeTotal(DataGridEx myDataGrid, int MNGType, int Kind, System.Windows.Forms.ProgressBar progressBar1, Guid BinID, long BabyID, System.DateTime BookDate, System.DateTime ExecDate)
        {
            decimal rtnValue = 0;

            if (MNGType != 9 && Kind == 2)
                return 0;

            int GroupID = -999;
            int iMNGType = 0;
            string sSql = "";
            int mngType2 = MNGType == 1 ? 5 : MNGType;

            DataTable myTb = new DataTable();
            if ((MNGType == 9) || (MNGType != 9 && Kind == 0))
            {
                //查询这个病人所有的医嘱,执行只能执行本病区的医嘱
                sSql = @"select distinct Group_ID ,MNGType " +
                    "  from zy_orderrecord " +
                    " where (status_flag>=2 and status_flag<5) " +
                    "   and dept_id not in (select deptid from ss_dept)" +
                    "   and delete_bit=0" +
                    "   and inpatient_id='" + BinID.ToString() + "' and Baby_ID=" + BabyID.ToString();
                if (MNGType != 9) sSql += " and (mngtype=" + MNGType + " or mngtype=" + mngType2 + ")";
                myTb = database.GetDataTable(sSql);
            }
            else if (Kind == 3)
            {
                //查询这个病人所有的药品长期医嘱,只能执行本病区的医嘱
                //Add By Tany 2004-10-12
                sSql = @"select distinct Group_ID ,MNGType " +
                    "  from zy_orderrecord " +
                    " where (ntype in (1,2,3) and xmly=1) and (status_flag>=2 and status_flag<5) " +
                    "   and dept_id not in (select deptid from ss_dept)" +
                    "   and delete_bit=0" +
                    "   and inpatient_id='" + BinID.ToString() + "' and Baby_ID=" + BabyID.ToString() + " and mngtype=" + MNGType;
                myTb = database.GetDataTable(sSql);
            }
            else
            {
                myTb = (DataTable)myDataGrid.DataSource;
            }
            progressBar1.Maximum = myTb.Rows.Count;
            progressBar1.Value = 0;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                //如果是选择发送
                if (MNGType != 9 && Kind == 1)
                {
                    if (myTb.Rows[i]["选"].ToString() == "False")
                        continue;
                }

                //如果组号与上一条医嘱相同，则不执行
                if (GroupID == Convert.ToInt32(myTb.Rows[i]["Group_ID"])
                    && (MNGType != 9 || (MNGType == 9 && iMNGType == Convert.ToInt32(myTb.Rows[i]["MNGType"]))))
                {
                    continue;
                }

                GroupID = Convert.ToInt32(myTb.Rows[i]["Group_ID"]);
                iMNGType = MNGType == 9 ? Convert.ToInt16(myTb.Rows[i]["MNGType"]) : MNGType;
                int iMNGType2 = iMNGType == 1 ? 5 : iMNGType;

                //DateTime CruDate=BookDate;
                //while(CruDate.Date<=ExecDate.Date)
                //{
                rtnValue += GetOrderFee(BinID, BabyID, iMNGType, GroupID, BookDate, ExecDate);
                //    CruDate = CruDate.Date.AddDays(1).Date;
                //}

                progressBar1.Value += 1;
            }

            progressBar1.Value = 0;

            return rtnValue;
        }

        /// <summary>
        /// 得到该科室医嘱执行的最小余额
        /// </summary>
        //public decimal GetMinExecYE(long Dept_Id)
        //{
        //    decimal rtnYE=0;

        //    string sSql="select * from jc_WARDRDEPT where dept_id="+Dept_Id;
        //    DataTable myTb=database.GetDataTable(sSql);

        //    if(myTb==null || myTb.Rows.Count==0)
        //    {
        //        rtnYE=0;
        //    }
        //    else
        //    {
        //        rtnYE=Convert.ToDecimal(myTb.Rows[0]["MINEXECYE"]);
        //    }

        //    return rtnYE;
        //}

        /// <summary>
        /// 得到该科室医嘱执行的最小余额
        /// </summary>
        //public decimal GetMinExecYE(long Dept_Id,RelationalDatabase database)
        //{
        //    decimal rtnYE=0;

        //    string sSql="select * from jc_WARDRDEPT where dept_id="+Dept_Id;
        //    DataTable myTb=database.GetDataTable(sSql);

        //    if(myTb==null || myTb.Rows.Count==0)
        //    {
        //        rtnYE=0;
        //    }
        //    else
        //    {
        //        rtnYE=Convert.ToDecimal(myTb.Rows[0]["MINEXECYE"]);
        //    }

        //    return rtnYE;
        //}

        /// <summary>
        /// 得到该病人医嘱执行的最小余额
        /// </summary>
        public decimal GetPatMinExecYE(Guid _inpatientid)
        {
            decimal rtnYE = 0;

            //Modify by tany 2010-06-18 最小余额=担保金额-欠费限额
            string sSql = "select dbje-yjj_limit as dbje from zy_inpatient where inpatient_id='" + _inpatientid + "'";
            DataTable myTb = database.GetDataTable(sSql);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                rtnYE = 0;
            }
            else
            {
                rtnYE = -1 * Convert.ToDecimal(Convertor.IsNull(myTb.Rows[0]["dbje"], "0"));
            }

            return rtnYE;
        }

        /// <summary>
        /// 得到该病人医嘱执行的最小余额
        /// </summary>
        public decimal GetPatMinExecYE(Guid _inpatientid, RelationalDatabase database)
        {
            decimal rtnYE = 0;

            //Modify by tany 2010-06-18 最小余额=担保金额-欠费限额
            string sSql = "select dbje-yjj_limit as dbje from zy_inpatient where inpatient_id='" + _inpatientid + "'";
            DataTable myTb = database.GetDataTable(sSql);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                rtnYE = 0;
            }
            else
            {
                rtnYE = -1 * Convert.ToDecimal(Convertor.IsNull(myTb.Rows[0]["dbje"], "0"));
            }

            return rtnYE;
        }

        /// <summary>
        /// 是否护士长
        /// </summary>
        /// <param name="emp_id"></param>
        /// <returns></returns>
        public bool IsHSZ(int emp_id)
        {
            bool YesOrNo = false;

            //			string sSql=@"Select a.id group_id from PUB_GROUP a "+
            //				" inner join PUB_GROUP_USER b on a.id=b.group_id "+
            //				" inner join PUB_USER c on b.user_id=c.id and c.employee_id="+emp_id;
            //			DataTable tempTab=database.GetDataTable(sSql);	
            //
            //			if(tempTab.Rows.Count != 0 && tempTab != null)
            //			{
            //				for(int i=0;i<tempTab.Rows.Count;i++)
            //				{
            //					SystemCfg cfg = new SystemCfg(7019);
            //					if(tempTab.Rows[i]["group_id"].ToString().Trim()==cfg.Config)//护士长组
            //					{
            //						YesOrNo=true;
            //						break;
            //					}
            //				}
            //			}

            try
            {
                Nurse _nurse = new Nurse(emp_id, database);

                if (_nurse == null)
                {
                    YesOrNo = false;
                }
                else if (_nurse.Nurse_Type == TrasenClasses.GeneralClasses.NurseType.护士长)
                {
                    YesOrNo = true;
                }

                return YesOrNo;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 是否组长护士
        /// </summary>
        /// <param name="emp_id"></param>
        /// <returns></returns>
        public bool IsZZHS(int emp_id)
        {
            bool YesOrNo = false;

            //			string sSql=@"Select a.id group_id from PUB_GROUP a "+
            //				" inner join PUB_GROUP_USER b on a.id=b.group_id "+
            //				" inner join PUB_USER c on b.user_id=c.id and c.employee_id="+emp_id;
            //			DataTable tempTab=database.GetDataTable(sSql);	
            //
            //			if(tempTab.Rows.Count != 0 && tempTab != null)
            //			{
            //				for(int i=0;i<tempTab.Rows.Count;i++)
            //				{
            //					SystemCfg cfg = new SystemCfg(7020);
            //					if(tempTab.Rows[i]["group_id"].ToString().Trim()==cfg.Config)//组长护士组
            //					{
            //						YesOrNo=true;
            //						break;
            //					}
            //				}
            //			}

            try
            {
                Nurse _nurse = new Nurse(emp_id, database);


                if (_nurse == null)
                {
                    YesOrNo = false;
                }
                else if (_nurse.Nurse_Type == TrasenClasses.GeneralClasses.NurseType.组长护士)
                {
                    YesOrNo = true;
                }

                return YesOrNo;
            }
            catch
            {
                return false;
            }
        }

        #region 判断是否是出院或死亡状态
        /// <summary>
        /// 判断是否是出院或死亡状态
        /// </summary>
        /// <param name="inpatientID"></param>
        /// <returns></returns>
        public bool OutFlag(Guid inpatientID, long BabyID)
        {
            int outflag = Convert.ToInt32(database.GetDataResult("select flag from vi_zy_vinpatient_all where inpatient_id='" + inpatientID.ToString() + "' and baby_id=" + BabyID.ToString() + ""));
            if (outflag >= 4) return true;
            else return false;
        }
        #endregion

        #region 去多余的“0”
        public decimal removeZero(decimal dc)
        {
            string str = "";
            int i = Convert.ToInt32(dc);
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
        #endregion

        #region 去多余的“0”
        public double removeZero(double dc)
        {
            string str = "";
            int i = Convert.ToInt32(dc);
            if (dc == i)
            {
                return Convert.ToDouble(i.ToString());
            }
            else
            {
                str = dc.ToString();

                for (i = 0; i <= str.Length; i++)
                {
                    if (str.Substring(str.Length - 1, 1) == "0") str = str.Substring(0, str.Length - 1);
                    else break;
                }
                return Convert.ToDouble(str);
            }
        }
        #endregion

        public DataTable ZYHS_ORDERS_SELECTFEE(Guid _inpatient_id, long _baby_id, long groupid, long WardDeptId, long MNGType, long MNGType2, int deletebit)
        {
            DataTable rtnTb = new DataTable();
            string sSql = "";
            ParameterEx[] parameters = new ParameterEx[7];

            try
            {
                sSql = "SP_ZYHS_ORDERS_SELECTFEE";

                parameters[0].Value = _inpatient_id;
                parameters[0].Text = "@BINID";
                parameters[1].Value = _baby_id;
                parameters[1].Text = "@BABYID";
                parameters[2].Value = groupid;
                parameters[2].Text = "@GROUPID";
                parameters[3].Value = WardDeptId;
                parameters[3].Text = "@WARDDEPTID";
                parameters[4].Value = MNGType;
                parameters[4].Text = "@MNGTYPE";
                parameters[5].Value = MNGType2;
                parameters[5].Text = "@MNGTYPE2";
                parameters[6].Value = deletebit;
                parameters[6].Text = "@DELETEBIT";


                rtnTb = database.GetDataTable(sSql, parameters, 60);

                return rtnTb;
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "SP_ZYHS_ORDERS_SELECTFEE错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return rtnTb;
            }
        }

        public DataTable ZYHS_YPFY_SELECT(int _tlfs, int _msg_type, long DeptLy, string WardId, Guid _inpatient_id, long _baby_id, long _execdept_id)
        {
            DataTable rtnTb = new DataTable();
            string sSql = "";
            ParameterEx[] parameters = new ParameterEx[7];

            try
            {
                sSql = "SP_ZYHS_YPFY_SELECT";

                parameters[0].Value = _tlfs;
                parameters[0].Text = "@tlfs";
                parameters[1].Value = _msg_type;
                parameters[1].Text = "@msg_type";
                parameters[2].Value = DeptLy;
                parameters[2].Text = "@DEPTLY";
                parameters[3].Value = WardId;
                parameters[3].Text = "@WardId";
                parameters[4].Value = _inpatient_id;
                parameters[4].Text = "@INPATIENT_ID";
                parameters[5].Value = _baby_id;
                parameters[5].Text = "@BABY_ID";
                parameters[6].Value = _execdept_id;
                parameters[6].Text = "@execdept_id";
               // DateTime dt11 = System.DateTime.Now;
                rtnTb = database.GetDataTable(sSql, parameters, 120);
               // DateTime dt12 = System.DateTime.Now;
                //TimeSpan ts = dt12 - dt11;
                //MessageBox.Show(ts.Seconds.ToString());
                return rtnTb;
            }
            catch (Exception err)
            {
                //写错误日志
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "SP_ZYHS_YPFY_SELECT错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return rtnTb;
            }
        }
        /// <summary>
        /// 查询历史库
        /// </summary>
        /// <param name="_tlfs"></param>
        /// <param name="_msg_type"></param>
        /// <param name="DeptLy"></param>
        /// <param name="WardId"></param>
        /// <param name="_inpatient_id"></param>
        /// <param name="_baby_id"></param>
        /// <param name="_execdept_id"></param>
        /// <param name="Ls"></param>
        /// <returns></returns>
        public DataTable ZYHS_YPFY_SELECT(int _tlfs, int _msg_type, long DeptLy, string WardId, Guid _inpatient_id, long _baby_id, long _execdept_id,bool Ls)
        {
            DataTable rtnTb = new DataTable();
            string sSql = "";
            ParameterEx[] parameters = new ParameterEx[7];

            try
            {
                sSql = "SP_ZYHS_YPFY_SELECT_H";

                parameters[0].Value = _tlfs;
                parameters[0].Text = "@tlfs";
                parameters[1].Value = _msg_type;
                parameters[1].Text = "@msg_type";
                parameters[2].Value = DeptLy;
                parameters[2].Text = "@DEPTLY";
                parameters[3].Value = WardId;
                parameters[3].Text = "@WardId";
                parameters[4].Value = _inpatient_id;
                parameters[4].Text = "@INPATIENT_ID";
                parameters[5].Value = _baby_id;
                parameters[5].Text = "@BABY_ID";
                parameters[6].Value = _execdept_id;
                parameters[6].Text = "@execdept_id";
                // DateTime dt11 = System.DateTime.Now;
                rtnTb = database.GetDataTable(sSql, parameters, 120);
                // DateTime dt12 = System.DateTime.Now;
                //TimeSpan ts = dt12 - dt11;
                //MessageBox.Show(ts.Seconds.ToString());
                return rtnTb;
            }
            catch (Exception err)
            {
                //写错误日志
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "SP_ZYHS_YPFY_SELECT错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return rtnTb;
            }
        }
        /// <summary>
        /// 打印出院通知单
        /// </summary>
        /// <param name="_inpatientid"></param>
        /// <param name="_babyid"></param>
        public void PrintOutNotice(Guid _inpatientid, int _babyid)
        {
            try
            {
                //Add by Tany 2009-12-22
                string sSql = "";
                ParameterEx[] parameters = new ParameterEx[3];

                //病人基本信息
                sSql = "sp_zyhs_getbininfo";
                parameters[0].Value = _inpatientid;
                parameters[0].Text = "@binid";
                parameters[1].Value = _babyid;
                parameters[1].Text = "@babyid";
                parameters[2].Value = 0;
                parameters[2].Text = "@ismy";

                DataTable patTb = database.GetDataTable(sSql, parameters, 60);

                //病人费用信息
                parameters = new ParameterEx[4];

                //病人基本信息
                sSql = "SP_ZYHS_BRFYHJ";
                parameters[0].Value = _inpatientid;
                parameters[0].Text = "@INPATIENT_ID";
                parameters[1].Value = _babyid;
                parameters[1].Text = "@BABY_ID";
                parameters[2].Value = "";
                parameters[2].Text = "@DATE1";
                parameters[3].Value = "";
                parameters[3].Text = "@DATE2";

                DataTable feeTb = database.GetDataTable(sSql, parameters, 60);

                //打印数据
                FrmReportView frmRptView = null;
                string _reportName = "";
                ParameterEx[] _parameters = new ParameterEx[8];

                _reportName = "ZYHS_出院通知单.rpt";

                _parameters[0].Text = "病人";
                _parameters[0].Value = patTb.Rows[0]["name"].ToString().Trim();
                _parameters[1].Text = "住院号";
                _parameters[1].Value = patTb.Rows[0]["inpatient_no"].ToString().Trim();
                _parameters[2].Text = "入院日期";
                _parameters[2].Value = Convert.ToDateTime(patTb.Rows[0]["in_date"]).Date;
                _parameters[3].Text = "出院日期";
                _parameters[3].Value = Convert.ToDateTime(patTb.Rows[0]["out_date"]).Date;
                _parameters[4].Text = "住院天数";
                _parameters[4].Value = patTb.Rows[0]["ryts"].ToString().Trim();
                _parameters[5].Text = "科室";
                _parameters[5].Value = patTb.Rows[0]["CUR_DEPT_NAME"].ToString().Trim();
                _parameters[6].Text = "总费用";
                _parameters[6].Value = patTb.Rows[0]["WJSZFY"].ToString().Trim();
                _parameters[7].Text = "预交款";
                _parameters[7].Value = patTb.Rows[0]["yjk"].ToString().Trim();

                frmRptView = new FrmReportView(feeTb, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);
                frmRptView.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //Add By Tany 2010-08-10
        /// <summary>
        /// 获取医保病人余额
        /// </summary>
        /// <param name="zfy">总费用</param>
        /// <param name="yjj">预交金</param>
        /// <param name="inpatient_id">病人ID</param>
        /// <returns></returns>
        public decimal GetYbye(decimal zfy, decimal yjj, Guid inpatient_id)
        {
            decimal bl = Convert.ToDecimal(Convertor.IsNull(database.GetDataResult("select b.yjj_bl from zy_inpatient a left join jc_yblx b on a.yblx=b.id where a.dischargetype=1 and a.inpatient_id='" + inpatient_id + "'"), "1"));
            decimal ye = yjj - (zfy * bl);

            return ye;
        }
        /// <summary>
        /// 获取病人的状态 >1、冻结状态 2、病人所在科室的机构编码
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <returns>rtnStr[0] 冻结状态，rtnStr[1] 机构编码 rtnStr[2] 未完成跨院特殊治疗数 </returns>
        public static string[] GetBrzt(Guid inpatient_id)
        {
            //Add By Tany 2011-10-11 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
            string patSql = "select a.freeze_flag,b.jgbm from zy_inpatient a inner join jc_dept_property b on a.dept_id=b.dept_id where a.inpatient_id='" + inpatient_id + "'";
            DataTable patTb = FrmMdiMain.Database.GetDataTable(patSql);
            //Add By Tany 2011-10-11 判断病人是否还有未完成特殊治疗，主要是为了阻止临时跨院业务的病人操作
            string tszlSql = "select count(*) as sl from ZY_TS_APPLY "
            + "  where cast(id as varchar(36)) in (select yzj from ts_update_log where CZLX in (501,502) and BSCBZ=0 ) "
            + " and inpatient_id='" + inpatient_id + "'  and  status_flag!=2 and delete_bit=0 ";
            DataTable TszlTb = FrmMdiMain.Database.GetDataTable(tszlSql);

            string[] rtnStr = new string[3];
            if (patTb != null && patTb.Rows.Count > 0)
            {

                rtnStr[0] = patTb.Rows[0]["freeze_flag"].ToString();
                rtnStr[1] = patTb.Rows[0]["jgbm"].ToString();
                if (TszlTb.Rows.Count > 0)
                    rtnStr[2] = TszlTb.Rows[0]["sl"].ToString();
                else
                    rtnStr[2] = "0";
            }
            else
            {
                throw new Exception("未找到有效的病人记录！");
            }

            return rtnStr;
        }
        /// <summary>
        /// 更新虚拟库存
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="baby_id"></param>
        /// <param name="Order_id"></param>
        /// <param name="Group_id"></param>
        /// <param name="type">0=减 1=加</param>
        /// <returns></returns>
        public bool OprateXnkc(Guid inpatient_id,long baby_id, Guid Order_id, int Group_id,int type)
        {
           string sql="select * from zy_orderrecord where inpatient_id='"+inpatient_id+"'and  baby_id="+ baby_id+" and  GROUP_ID="+Group_id+"  and xmly=1 ";
           DataTable Tb = database.GetDataTable(sql);
           int i=0;
           decimal jl=0;
           database.BeginTransaction();
            try
            {
               for (i = 0; i < Tb.Rows.Count;i++ )
               {
                   if (Tb.Rows[i]["xmly"].ToString() == "1")
                   {
                       DataTable myTb = new DataTable();
                       string _dwlx="1";
                       //if (Tb.Rows[i]["MNGTYPE"].ToString().Trim() == "1" || Tb.Rows[i]["MNGTYPE"].ToString().Trim() == "5")
                       //    _dwlx = Tb.Rows[i]["jldwlx"].ToString();
                       // if (Tb.Rows[i]["MNGTYPE"].ToString().Trim() == "0" )
                       //    _dwlx = Tb.Rows[i]["dwlx"].ToString();
                      
                       _dwlx = Tb.Rows[i]["dwlx"].ToString();
                       string _num="0";
                       if (Tb.Rows[i]["mngtype"].ToString().Trim() == "1" || Tb.Rows[i]["mngtype"].ToString().Trim() == "5")//临时医嘱用总数量
                       {
                           if (Tb.Rows[i]["ts"].ToString().Trim() == "")
                               _num = Tb.Rows[i]["num"].ToString();
                           else
                               _num = Tb.Rows[i]["zsl"].ToString();
                           if(decimal.Parse(_num)==0)
                               _num = Tb.Rows[i]["num"].ToString();
                       }
                       else
                           _num = Tb.Rows[i]["num"].ToString();
                       string _cjid = Tb.Rows[i]["hoitem_id"].ToString();
                       string _execdeptID = Tb.Rows[i]["EXEC_DEPT"].ToString();//执行科室为-1跳出
                       if (Convert.ToInt32(_execdeptID) <= 0)
                           continue;
                       string sSql = "";
                       string _dwbl = "";
                       decimal yl = 0;
                       decimal bcxyyl = 0;//当天需要用量
                       int cs=1;//频次
                       
                           sSql = "EXEC SP_FUN_DW_NUM " + _dwlx + "," + _num + ",1,1,1," + _cjid + "," + _execdeptID + ",0";
                           myTb = database.GetDataTable(sSql);
                           if (myTb.Rows.Count > 0)
                           {
                               yl = decimal.Parse(myTb.Rows[0]["yl"].ToString());
                               if (yl == 0)
                                   throw new Exception("cjid=" + _cjid + "该种药品被禁用或找不到该种药品信息或药品数量计算=0!!");
                               _dwbl = myTb.Rows[0]["ydwbl"].ToString();
                           }
                           if (Tb.Rows[i]["MNGTYPE"].ToString().Trim() == "0")
                           {
                               bcxyyl = int.Parse(Tb.Rows[i]["FIRST_TIMES"].ToString()) * int.Parse(Tb.Rows[i]["DOSAGE"].ToString()) * yl * (type == 0 ? -1 : 1);
                           }
                           if (Tb.Rows[i]["MNGTYPE"].ToString().Trim() == "1" || Tb.Rows[i]["MNGTYPE"].ToString().Trim() == "5")
                           {
                               bcxyyl = yl * (type == 0 ? -1 : 1);//剂量不需要乘 //int.Parse(Tb.Rows[i]["DOSAGE"].ToString())*yl*(type==0?-1:1);
                           }
                           ParameterEx[] parameters = new ParameterEx[6];
                           parameters[0].Text = "@cjid";
                           parameters[0].Value = Convert.ToInt32(_cjid);
                           parameters[1].Text = "@ypsl";
                           parameters[1].Value = Convert.ToInt32(bcxyyl);
                           parameters[2].Text = "@ydwbl";
                           parameters[2].Value = Convert.ToInt32(_dwbl);
                           parameters[3].Text = "@deptid ";
                           parameters[3].Value = Convert.ToInt32(_execdeptID);
                           parameters[4].Text = "@err_code";
                           parameters[4].ParaSize = 100;
                           parameters[4].ParaDirection = ParameterDirection.Output;
                           parameters[5].Text = "@Err_Text";
                           parameters[5].ParaSize = 200;
                           parameters[5].ParaDirection = ParameterDirection.Output;
                           database.DoCommand("sp_yf_updatekcmx_xnkcl", parameters, 60);
                           string   rtnStr="";
                           rtnStr= parameters[5].Value.ToString().Trim();
                           string outcode = "0";
                           outcode = parameters[5].Value.ToString().Trim();
                           //sSql = "EXEC SP_FUN_DW_NUM " + _cjid + "," + bcxyyl+"," +_dwlx+","+_execdeptID+",0,' ' ";
                           if (outcode == "-1" || rtnStr != "保存成功")
                               throw new Exception(rtnStr.Trim());
                      
                      
                   }
               }
               database.CommitTransaction();
               return true;
          }
          catch (Exception err)
          {
            database.RollbackTransaction();
            throw err;
            return false;
          }
        }

        public bool CzJxnkc(Guid feeid,decimal czcs,decimal sl)
        {
            decimal num_cz = Convert.ToDecimal(czcs.ToString()) * sl;
            string sql = "select xmid as cjid,EXECDEPT_ID,UNITRATE,num from zy_fee_speci where id='" + feeid + "'";
            string _cjid = "";
            string _execdeptID = "";
            string _dwbl = "";
            try
            {
                DataTable tb = database.GetDataTable(sql);
                if (tb == null || tb.Rows.Count ==0)
                    throw new Exception("没有找该费用信息");
                //取消冲正的费用
                if (Convert.ToInt32(tb.Rows[0]["num"]) < 0)
                    num_cz = Convert.ToDecimal(tb.Rows[0]["num"].ToString());
                _cjid = tb.Rows[0]["cjid"].ToString();
                _execdeptID = tb.Rows[0]["EXECDEPT_ID"].ToString();
                _dwbl = tb.Rows[0]["UNITRATE"].ToString();
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@cjid";
                parameters[0].Value = Convert.ToInt32(_cjid);
                parameters[1].Text = "@ypsl";
                parameters[1].Value = Convert.ToInt32(num_cz);
                parameters[2].Text = "@ydwbl";
                parameters[2].Value = Convert.ToInt32(_dwbl);
                parameters[3].Text = "@deptid ";
                parameters[3].Value = Convert.ToInt32(_execdeptID);
                parameters[4].Text = "@err_code";
                parameters[4].ParaSize = 100;
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[5].Text = "@Err_Text";
                parameters[5].ParaSize = 100;
                parameters[5].ParaDirection = ParameterDirection.Output;
                database.DoCommand("sp_yf_updatekcmx_xnkcl", parameters, 60);
                string rtnStr = "";
                rtnStr = parameters[5].Value.ToString().Trim();
                string outcode = "0";
                outcode = parameters[5].Value.ToString().Trim();
                //sSql = "EXEC SP_FUN_DW_NUM " + _cjid + "," + bcxyyl+"," +_dwlx+","+_execdeptID+",0,' ' ";
                if ( outcode=="-1"|| rtnStr != "保存成功")
                    throw new Exception(rtnStr.Trim());
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// 发送到暂存 9为暂存药
        /// </summary>
        /// <param name="tb"></param>
        public void SendZc(DataTable tb,string user_id,string user_name,bool IsupdateZckc,Int64 zxksid)
        {
            //药品医嘱是否直接记帐
            SystemCfg cfg7031 = new SystemCfg(7031);
            string[] GroupbyField1 ={ "cjid", "dept_ly", "ZXDW", "tlfl","单价","DWBL" };
            string[] ComputeField1 ={ "数量", "金额","ypsl" };
            string[] CField1 ={ "sum", "sum","sum" };
            TrasenFrame.Classes.TsSet tsset1 = new TrasenFrame.Classes.TsSet();
            tsset1.TsDataTable = tb;
            DataTable tbflcjid = tsset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
          
            database.BeginTransaction();
            try
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (tb.Rows[i]["选"].ToString().Trim() == "1")
                    {
                        //如果不是直接记账，转入到暂存药时要记账
                        string sql="";
                        if(cfg7031.Config.Trim()=="是")
                            sql= "update ZY_FEE_SPECI set TLFS=9  where ID='" + tb.Rows[i]["zy_id"].ToString() + "'";
                        else
                            sql = "update ZY_FEE_SPECI set TLFS=9 ,CHARGE_BIT=1,CHARGE_DATE=getdate(),CHARGE_USER=" + user_id + " where ID='" + tb.Rows[i]["zy_id"].ToString() + "'";
                        database.DoCommand(sql);
                    }

                }
                //是否更行暂存库存,更暂存基数和库存量
                if (IsupdateZckc)
                {
                    string[] updatesql =new string[tbflcjid.Rows.Count];
                    string insertdjxx = "";
                    for (int j = 0; j < tbflcjid.Rows.Count; j++)
                    {
                        //如果没有就插入记录
                        string sql = " select * from Zy_ZcyKcmx (nolock) where bscbz=0 and  cjid=" + tbflcjid.Rows[j]["cjid"].ToString() + 
                                        " and  ksid="+tbflcjid.Rows[j]["dept_ly"].ToString()
                                        +" and  yfksid="+zxksid;
                        DataTable tbKcmx = database.GetDataTable(sql);
                        //如果没有暂存管理，就不进行插入操作
                        if (tbKcmx.Rows.Count == 0)
                        {
                           
                            string insert = @" insert into Zy_ZcyKcmx(id, cjid, ggid, kcl, dj, zxdw, dwbl, zcjs, ksid, yfksid, book_date, bscbz)
                                                       values(NEWID()," + tbflcjid.Rows[j]["cjid"].ToString() + ",null,0," + tbflcjid.Rows[j]["单价"].ToString()
                                                       + "," + tbflcjid.Rows[j]["zxdw"].ToString() + "," + tbflcjid.Rows[j]["dwbl"].ToString() + ",9999," + tbflcjid.Rows[j]["dept_ly"].ToString()
                                                       + ","+zxksid+",getdate(),0)";
                            database.DoCommand(insert);
                        }
                        updatesql[j] = "  update dbo.Zy_ZcyKcmx set kcl=a.kcl+(" + tbflcjid.Rows[j]["数量"].ToString() + ")*a.DWBL/(" + tbflcjid.Rows[j]["UNITRATE"].ToString() + "),zcjs=zcjs-(" + tbflcjid.Rows[j]["数量"].ToString() + ")*a.DWBL/(" + tbflcjid.Rows[j]["UNITRATE"].ToString() + ")"
                                       + " from Zy_ZcyKcmx a join YF_KCMX b  on a.cjid=b.cjid and b.DEPTID=a.yfksid where a.cjid=" + tbflcjid.Rows[j]["cjid"].ToString() +
                                        " and  ksid=" + tbflcjid.Rows[j]["dept_ly"].ToString()
                                        + " and  yfksid=" + zxksid;
                        database.DoCommand(updatesql[j]);
                        Guid djid = Guid.NewGuid();
                        //同时还要插入单据信息 zy_zcydjxx
                        insertdjxx = string.Format(@"insert into zy_zcydjxx
                                                                    (
                                                                       id, jgbm, deptid, ywlx, wldw, djrq,
                                                                       djy, tlfl, cjid, zxdw, sl, dj,
                                                                        shzt,shry,shsj,ydwbl
                                                                    )
                                                                   values
                                                                   ('" + djid + "', " + FrmMdiMain.Jgbm + @","
                                                                   + tbflcjid.Rows[j]["dept_ly"].ToString()
                                                                   + @",1," + zxksid + @",getdate(),"//1 表示发送到暂存药 
                                                                   + FrmMdiMain.CurrentUser.EmployeeId + @",'" + tbflcjid.Rows[j]["tlfl"].ToString()
                                                                   + @"'," + tbflcjid.Rows[j]["cjid"].ToString() + @"," + tbflcjid.Rows[j]["zxdw"].ToString()
                                                                   + @"," + tbflcjid.Rows[j]["ypsl"].ToString()
                                                                   + @"," + (decimal.Parse( tbflcjid.Rows[j]["金额"].ToString()) /decimal.Parse( tbflcjid.Rows[j]["ypsl"].ToString()))
                                                                   + @",1," + FrmMdiMain.CurrentUser.EmployeeId + @",getdate()," + tbflcjid.Rows[j]["DWBL"].ToString() + @""
                                                                   + @")"
                                                               );
                        database.DoCommand(insertdjxx);
                        #region//插入单据明细
                        string filter="cjid="+tbflcjid.Rows[j]["cjid"].ToString()+" and  dept_ly="+tbflcjid.Rows[j]["dept_ly"].ToString()
                                          +"  and  ZXDW="+ tbflcjid.Rows[j]["zxdw"].ToString() ;
                        DataRow[] _row=tb.Select(filter);
                        for(int k=0;k<_row.Length;k++)
                        {
                            string feeid=_row[k]["ZY_ID"].ToString();
                            string cjid=_row[k]["CJID"].ToString();
                            string sl=_row[k]["数量"].ToString();
                            
                        string insertdjmx = string.Format(@"insert into zy_zcydjxxmx (  id, djid, feeid, cjid, sl, zxks, scbz)
                                                                              values
                                                                           (dbo.FUN_GETGUID(newid(),getdate()),'"+djid+"','"+feeid+"',"
                                                                             +cjid+","+sl+","+zxksid+",0"+
                                                                           @")");
                       database.DoCommand(insertdjmx);
                        }
                        #endregion
                       // database.DoCommand(insertdjxx);
                    }
                  
                }
                database.CommitTransaction();
            }
            catch (Exception ex)
            {
                database.RollbackTransaction();
                throw ex;
            }
        }
        /// <summary>
        /// 根据输入数量，选择勾选的数量
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="xsl"></param>
        /// <param name="cjid"></param>
        /// <param name="ReturnValue"></param>
        /// <param name="je"></param>
        /// <returns></returns>
        public DataTable Gxypsl(DataTable tb, int xsl, string cjid,ref int ReturnValue,ref decimal je)
        {
            int i = 0;
            int count=0;
            je = 0;
            for (i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["cjid"].ToString() == cjid.ToString())
                {
                    if (count + Convert.ToInt32(tb.Rows[i]["数量"].ToString()) <= xsl)
                    {
                        count = count + Convert.ToInt32(tb.Rows[i]["数量"].ToString());
                        je +=decimal.Parse(tb.Rows[i]["金额"].ToString());
                        tb.Rows[i]["选"] = (short)1;
                    }
                    else
                        tb.Rows[i]["选"] = (short)0;
                }
            }
            ReturnValue = count;
            return tb;
        }

        /// <summary>
        /// 获得cp状态
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="bayb_id"></param>
        /// <returns>0表示正常</returns>
        public string GetCpzt(string inpatient_id, string bayb_id)
        {
            try
            {
                string ifqy = ApiFunction.GetIniString("SfQy", "SfQy", Constant.ApplicationDirectory + "\\Cpset.ini");
                if (ifqy == "0")
                    return "0";
                string typename = ApiFunction.GetIniString("Tpype", "typename", Constant.ApplicationDirectory + "\\Cpset.ini");
                Cpinterface = Ts_Clinicalpathway_Factory.Ts_Cp_factory.Cpinterface(typename);
                return Cpinterface.GetCpstatus(new Guid(inpatient_id), Int16.Parse(bayb_id));
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exectime"></param>
        /// <param name="times"></param>
        /// <param name="dt"></param>
        /// <param name="type">1=首次，2=末次</param>
        /// <returns></returns>
        #region 根据时间点计算默认频率次数
        public  string GetExectime(string exectime, string times, DateTime dt, int type)
        {
            try
            {
                if (exectime == "") return times;
                string[] Exectime = exectime.Split('/');
                if (Exectime.Length == 0) return times;
                string dtime = dt.ToShortTimeString();   //databaseZy.GetSevertime().ToShortTimeString();
                decimal hourStr = Convert.ToDecimal(dtime.Replace(":", "."));
                int i;
                for (i = 0; i < Exectime.Length; i++)
                {
                    if (Convert.ToDecimal(dtime.Replace(":", ".")) < Convert.ToDecimal(Exectime[i].Replace(":", ".")))
                    {
                        //					return Convert.ToString(Exectime.Length-i);
                        break;
                    }
                }
                if (type == 1)
                    return Convert.ToString(Convert.ToInt32(times) - i);
                else
                    return i.ToString();
            }
            catch
            {
                return times.ToString();
            }
        }
        #endregion
        /// <summary>
        /// 根据时间获得首次
        /// </summary>
        /// <param name="pl"></param>
        /// <param name="dt">医嘱开始时间</param>
        /// <returns></returns>
        public  int GetFirsttimes(string pl, DateTime dt)
        {
            DataTable tb = FrmMdiMain.Database.GetDataTable("select * from JC_FREQUENCY where name='" + pl + "'");
            if (tb != null && tb.Rows.Count > 0)
            {
                string cs = GetExectime(tb.Rows[0]["EXECTIME"].ToString().Trim(), tb.Rows[0]["EXECNUM"].ToString().Trim(), dt, 1);
                return Convert.ToInt32(cs);
            }
            else
                return 1;
        }
        /// <summary>
        /// 根据时间获得末次
        /// </summary>
        /// <param name="pl"></param>
        /// <param name="dt">医嘱开始时间</param>
        /// <returns></returns>
        public  int GetLasttimes(string pl, DateTime dt)
        {
            DataTable tb = FrmMdiMain.Database.GetDataTable("select * from JC_FREQUENCY where name='" + pl + "'");
            if (tb != null && tb.Rows.Count > 0)
            {
                string cs = GetExectime(tb.Rows[0]["EXECTIME"].ToString().Trim(), tb.Rows[0]["EXECNUM"].ToString().Trim(), dt, 2);
                return Convert.ToInt32(cs);
            }
            else
                return 1;//末次为1
        }

        public void ChangeFirtorLastTime(string inpatient_id, string group_id, int typeStop, int cs, string pl, string tlfl)
        {
            try
            {
                DataTable tb = database.GetDataTable("select ORDER_BDATE,FIRST_TIMES,TERMINAL_TIMES,ORDER_EDATE from  ZY_ORDERRECORD   a join VI_YP_YPCD b on a.HOITEM_ID=b.cjid   where inpatient_id='" + inpatient_id + "' and group_id=" + group_id + " and xmly=1 and b.TLFL='" + tlfl + "'");
                if (tb.Rows.Count > 0)
                {
                    string sql = "";
                    int newcs = typeStop == 0 ? GetFirsttimes(pl, DateTime.Parse(tb.Rows[0]["ORDER_BDATE"].ToString())) : GetLasttimes(pl, DateTime.Parse(tb.Rows[0]["ORDER_EDATE"].ToString()));
                    if (typeStop == 0)//开医嘱转抄
                    {
                        if (newcs != int.Parse(tb.Rows[0]["FIRST_TIMES"].ToString()))
                        {
                            sql = "update ZY_ORDERRECORD set FIRST_TIMES=" + newcs + " where inpatient_id='" + inpatient_id + "' and group_id=" + group_id + "";
                        }
                    }
                    else//停医嘱转抄
                    {
                        if (newcs != int.Parse(tb.Rows[0]["TERMINAL_TIMES"].ToString()))
                        {
                            sql = "update ZY_ORDERRECORD set TERMINAL_TIMES=" + newcs + " where inpatient_id='" + inpatient_id + "' and group_id=" + group_id + "";
                        }
                        
                    }
                    if (sql != "")
                        database.DoCommand(sql); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable  GetZY_zcgl( int ksid, int yfksid)
        {
            string sql = "select * from  Zy_ZcyKcmx  where bscbz=0 and ksid=" + ksid + " and yfksid="+yfksid;
            return database.GetDataTable(sql);
        }
        /// <summary>
        /// 获取发送到暂存药品的表和需要发送到药房的表
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="deptly"></param>
        /// <param name="yfksid"></param>
        /// <returns></returns>
        public DataSet  GetZcAndYFfs_Tb(DataTable tb,int deptly,int yfksid)
        {
            //暂存管理中，勾选药品以后，分为两个表，第一个是需要发送到暂存的药品。第二个是直接发送到药房
            DataSet Dsset = new DataSet();
            DataTable tbzcgl = tb.Clone();//发送到暂存管理的表
            DataTable tbFsyf = tb.Clone();//直接发送到药房
            tbFsyf.TableName = "tbFsyf";
            DataTable Zy_ZcyKcmx = GetZY_zcgl(deptly, yfksid);
            int i = 0;
            decimal count = 0;
             //汇总当前的分类
            string[] GroupbyField1 ={ "cjid" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };
            TrasenFrame.Classes.TsSet tsset1 = new TrasenFrame.Classes.TsSet();
            tsset1.TsDataTable = tb;
            DataTable tbflcjid = tsset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");

            //先要排序
            for (i = 0; i < tbflcjid.Rows.Count; i++)
            {
                count = 0;
                DataRow[] _addrow=tb.Select("cjid=" + tbflcjid.Rows[i]["cjid"].ToString());
                //先看这个有没有暂存基数管理
                DataRow[] row = Zy_ZcyKcmx.Select("cjid=" + tbflcjid.Rows[i]["cjid"].ToString());
                if (row.Length == 0)
                {
                    
                    for(int z=0;z<_addrow.Length;z++)
                    {
                        //添加到暂存管理的表
                        tbzcgl.Rows.Add(_addrow[z].ItemArray);
                    }
                    continue;//不存在直接方法暂存表
                }
                else
                {
                    //存在的话,判断暂存基数
                    int _zcjs = Convert.ToInt32(Convertor.IsNull(row[0]["zcjs"], "0"));//获取暂存基数,按道理是不会出现多个的
                    for(int j=0;j<_addrow.Length;j++)
                    {
                        if (count + Convert.ToInt32(_addrow[j]["数量"].ToString()) <= _zcjs)
                        {
                            count = count + Convert.ToInt32(_addrow[j]["数量"].ToString());
                            // je += decimal.Parse(_addrow[j]["金额"].ToString());
                            // tb.Rows[i]["选"] = (short)1;
                            tbzcgl.Rows.Add(_addrow[j].ItemArray);
                        }
                        else
                        {
                            tbFsyf.Rows.Add(_addrow[j].ItemArray);
                        }
                    }
                }
                
            }
            Dsset.Tables.Add(tbzcgl);
            Dsset.Tables.Add(tbFsyf);
            return Dsset;
        }

        /// <summary>
        /// 出院自动冲账床位费  yaokx2014-03-15
        /// </summary>
        /// <param name="inpatientID"></param>
        /// <param name="str"></param>
        public void GetCZcy(Guid inpatientID, long BabyID, string str, DateTime dTime)
        {
          try
           {
            // FrmMdiMain.Database.BeginTransaction();
            //定义出院
           
             string outflag =Convert.ToString(database.GetDataResult("select flag from vi_zy_vinpatient_all where inpatient_id='" + inpatientID.ToString() + "'and BABY_ID="+BabyID+" and OUT_DATE>='" + dTime.ToString("yyyy-MM-dd 00:00:00.000") + "' and  OUT_DATE<='" + dTime.ToString("yyyy-MM-dd 23:59:59.999") + "'"));
            if (outflag == "") return;
            if (Convert.ToInt32(outflag) >= 4)
            {
                string s = @"select DBO.FUN_ZY_SEEKFEETYPENAME(t.CZ_FLAG) as '记账类型', * from ZY_FEE_SPECI t inner join " +
                                               " zy_ORDEREXEC t1 on t.ORDER_ID=t1.ORDER_ID and t.ORDEREXEC_ID=t1.ID" +
                                              " where t1.EXECDATE>='" + dTime.ToString("yyyy-MM-dd 00:00:00.000") + "'" +
                                              " and XMID in (" + str + ")" +
                                              " and t.INPATIENT_ID='" + inpatientID + "'";

                DataTable feetb = FrmMdiMain.Database.GetDataTable(s);
                if (feetb.Rows.Count == 0) return;
                else
                {
                    for (int a = 0; a < feetb.Rows.Count; a++)
                    {
                        if (feetb.Rows[a]["记账类型"].ToString() == "记帐费用")
                        {
                            string insert_s = @"INSERT INTO ZY_FEE_SPECI (" +
                              " id,jgbm,Order_id,prescription_id,orderexec_id,presc_date,book_date," +
                              " book_user,presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID," +
                              " baby_id,item_name,subcode,unit,unitrate,dosage, cost_price, retail_Price, " +
                              " agio, EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj, " +
                              " CZ_FLAG," +
                              " CZ_ID," +
                              " DELETE_BIT," +
                              " DISCHARGE_BIT," +
                              " num,sdValue,acValue,type,tlfs,gcys,charge_bit,charge_date,charge_user,BZ )" +
                              " SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),a.jgbm,Order_id,prescription_id,orderexec_id,presc_date," +
                              " getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name," +
                              " subcode,unit,unitrate,dosage,cost_price, retail_Price, agio,EXECDEPT_ID,dept_id,dept_br," +
                              " dept_ly,doc_id,gg,cj," +
                              " 2,a.id,0,0,-1*NUM," +
                              " -1*convert(decimal(18,2),1.00/1*retail_Price)," +
                              " -1*convert(decimal(18,2),1.00/1*retail_Price)," +
                              " type,tlfs,gcys,1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + ",'【系统自动冲正】' from zy_fee_speci a " +
                              " where id='" + new Guid(feetb.Rows[a]["id"].ToString()) + "'";

                            string update_s = "update zy_fee_speci set cz_flag=1 where id='" + new Guid(feetb.Rows[a]["id"].ToString()) + "'";
                            FrmMdiMain.Database.DoCommand(update_s);
                            FrmMdiMain.Database.DoCommand(insert_s);
                        }
                    }
                  }
                }
               // FrmMdiMain.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
               //FrmMdiMain.Database.RollbackTransaction();
               MessageBox.Show(ex.Message);
                return;
            }

        }
    }
}















