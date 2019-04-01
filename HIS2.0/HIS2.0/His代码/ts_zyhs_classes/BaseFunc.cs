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
using System.Collections.Generic;
using Ts_Clinicalpathway_Factory;
using HospitalManage.Services;
using TrasenHIS.BLL;
using ts_ybznsh_interface;
using System.Net;
using System.IO;

namespace ts_zyhs_classes
{
    /// <summary>
    /// 护士站的基本函数
    /// </summary>
    public class BaseFunc
    {
        /// <summary>
        /// 医嘱执行参数管理类//Modify by jchl 2017-09-01护士执行改造
        /// </summary>
        public ClsConfigList _cfgList;

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

        private long Dept_ID = -1;
        private long Opr_ID = -1;

        public void SetOprInfo(long dept, long opr)
        {
            Dept_ID = dept;
            Opr_ID = opr;
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
        /// 查询病人的历史医嘱 add by 岳成成 2014-11-02
        /// </summary>
        /// <param name="sSql">sSql</param>
        /// <param name="BinID">BinID</param>
        /// <param name="BabyID">BabyID</param>
        /// <param name="SelType">SelType</param>
        /// <param name="SelKind">SelKind</param>
        /// <param name="Doc">Doc</param>
        /// <param name="ExecDate">ExecDate</param>
        /// <param name="ward_id">ward_id</param>
        /// <param name="dept_id">dept_id</param>
        /// <returns></returns>
        public DataTable GetBinOrdrs_H(string sSql, Guid BinID, long BabyID, int SelType, int SelKind, long Doc, DateTime ExecDate, string ward_id, long dept_id)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[8];

            sSql = "SP_ZYHS_ORDERS_SELECT_H";
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

        /// <summary>
        /// 病人医嘱查询-手术麻醉
        /// </summary>
        /// <returns></returns>
        public DataTable GetBinOrdrsSSYZ(string sSql, Guid BinID, long BabyID, int SelType, int SelKind, long Doc, DateTime ExecDate, string ward_id)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[7];

            sSql = "SP_ZYHS_ORDERS_SELECT_SSYZ";
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
        public string ChildBearing(string sSql, int nMode, int nCWF, Guid BinID, int current_no, string sSex, string sName, long OperID, DateTime sDate, int Jgbm, string fmfs, string iszt, string ispbfm)//int fmfs, int iszt, int ispbfm add by 岳成成 2014-09-05
        {
            string _outmsg = "";
            ParameterEx[] parameters = new ParameterEx[14];
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
            parameters[11].Value = fmfs;// 分娩方式 add by 岳成成 2014-09-05
            parameters[11].Text = "@fmfs";// add by 岳成成 2014-09-05
            parameters[12].Value = iszt;//镇痛 add by 岳成成 2014-09-05
            parameters[12].Text = "@iszt";// add by 岳成成 2014-09-05
            parameters[13].Value = ispbfm;//陪伴分娩 add by 岳成成 2014-09-05
            parameters[13].Text = "@ispbfm";// add by 岳成成 2014-09-05
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
        public DataTable SetItemInfo(Guid order_id, long HOitemID, double num, string Use_Name, int Jgbm)
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
                if (Kind == 3 || Kind == 4)
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
                Application.DoEvents();
            }

            #region"医保智审接口调用"

            //DataTable dtAll = myDataGrid.DataSource as DataTable
            //string strMsg = "";
            //bool bSuc = DoVaildYbFee(dtAll, MNGType, Kind, BinID, BabyID, out strMsg);
            bool CanAudit = ClsAuditCheck.CheckIsAuditCheck(BinID.ToString(), database);//是否需要智审
            if (CanAudit)
            {
                if (BabyID == 0)
                {
                    string strMsg = "";
                    bool bSuc = DoVaildYbFee(myTb, MNGType, Kind, BinID, BabyID, out strMsg);
                    if (!bSuc)
                    {
                        //Modify by jchl 2016-01-25【护士站医保智审不提示】
                        //MessageBox.Show(strMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            #endregion

            progressBar1.Value = 0;

            return true;
        }


        /// <summary>
        /// 智审控费接口调用
        /// </summary>
        /// <param name="myTb"></param>
        /// <param name="MNGType"></param>
        /// <param name="Kind"></param>
        /// <param name="BinID"></param>
        /// <param name="BabyID"></param>
        /// <returns></returns>
        private bool DoVaildYbFee(DataTable myTb, int MNGType, int Kind, Guid BinID, long BabyID, out string strMsg)
        {
            BmiAuditClass clsAdtChk = new BmiAuditClass();
            ClsAuditCheck cls = new ClsAuditCheck(database);
            strMsg = "";
            string strRet = "";

            string yblx = "";
            string ybzlx = "";
            string zyh = "";
            try
            {
                string inAGENCIES_ID = "";
                string ssql = string.Format("select YBLX,XZLX,INPATIENT_NO from VI_ZY_VINPATIENT_ALL where INPATIENT_ID ='{0}' ", BinID.ToString());
                try
                {
                    DataTable dtInp = database.GetDataTable(ssql);

                    if (dtInp == null || dtInp.Rows.Count <= 0)
                        throw new Exception("未找到该住院号的病人信息\r");

                    yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
                    ybzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
                    zyh = dtInp.Rows[0]["INPATIENT_NO"].ToString().Trim();
                    if (yblx.Equals("1"))
                    {
                        inAGENCIES_ID = "1";
                    }
                    else if (yblx.Equals("3") && ybzlx.Equals("55"))
                    {
                        inAGENCIES_ID = "2";
                    //}
                    //else if (yblx.Equals("-1"))//自费病人
                    //{
                    //    inAGENCIES_ID = "0";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("未找到该住院号的病人信息\r" + ex.Message);
                }

                //wait to filter myTb
                DataTable dtVal = DoGetValidateFeeInfo(myTb, MNGType, Kind);

                //当天首次执行的医嘱   与开单时自动上传的未计费医嘱当天重复   需删除开单上传的费用
                DataTable dtDel = cls.GetNoneFeeOrdInfo(dtVal, MNGType, Kind, BinID, BabyID);
                if (dtDel != null && dtDel.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDel.Rows.Count; i++)
                    {
                        string ordId = dtDel.Rows[i]["order_id"].ToString();

                        strRet = clsAdtChk.deleteDetail4Hospital(BinID.ToString(), ordId, inAGENCIES_ID);

                        if (strRet.Trim().Equals("0"))
                        {
                            //日志记录wait log
                            SaveLog(FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "医保智审", "删除医嘱明细--病人：" + BinID.ToString() + "  医嘱：" + ordId + "  返回结果：" + strRet, 1, 4);
                        }
                        ////日志记录wait log
                        //SaveLog(FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "医保智审", "删除医嘱明细--病人：" + BinID.ToString() + "  医嘱：" + ordId + "  返回结果：" + strRet, 1, 4);
                    }
                }

                DataTable dtFeeDetails = cls.GetPostFeeInfo(dtVal, MNGType, Kind, BinID, BabyID);
                decimal sum = 0M;
                DataTable dtDetail = cls.GetDetailFeeInfo(dtFeeDetails, yblx, ybzlx, out sum);

                //Modify By jchl 2015-06-17 没有明细不调用
                if (dtDetail.Rows.Count <= 0)
                    return true;

                ////string strZyh=database.GetDataResult
                //string sql = string.Format(@"select INPATIENT_NO from ZY_INPATIENT where INPATIENT_ID='{0}'", BinID.ToString());
                //string zyh = database.GetDataResult(sql).ToString();


                DataTable dtMain = ClsAuditCheck.RetAfSetMainInfo(BinID.ToString(), zyh, sum, database);

                //Modify By jchl 2015-06-17 护士保存强制不弹框
                //strRet = clsAdtChk.ClaimAudit4Hospital_N(dtMain, dtDetail);
                strRet = clsAdtChk.ClaimAudit4Hospital_S(dtMain, dtDetail);

                if (strRet.Equals("0") || strRet.Equals("2"))
                {
                    ///返回： 0：审核失败
                    //1：审核结果正常
                    //2：调用步骤出错
                    //3：审核结果有违规（取消）
                    //4：审核结果有违规（保存）；申明方法如下：
                    string err = (strRet.Equals("0") ? "医保智审【审核失败！】" : "医保智审【调用步骤出错！】");
                    err = err + "\r\r返回原因：" + clsAdtChk.l_error_message;
                    throw new Exception(err + "\r\r请手动上传该病人费用到中公网！");
                }
                else if (strRet.Equals("3"))
                {
                    //取消,不保存上传费用
                    //但是his费用已经产生
                    //强行保存这部分费用
                    strRet = clsAdtChk.ClaimAudit4Hospital_S(dtMain, dtDetail);
                    string err = (strRet.Equals("0") ? "医保智审【审核失败！】" : "医保智审【调用步骤出错！】");
                    err = err + "\r\r返回原因：" + clsAdtChk.l_error_message;
                    if (strRet.Equals("0") || strRet.Equals("2"))
                    {
                        throw new Exception("数据保存成功,上传中公网数据成功！ \r\t医保智能审核检测到存在违规数据,请停止违规医嘱,并冲正费用,再手动上传该病人所有费用到中公网！");
                    }

                    //
                    bool bSc = cls.UpdateScbz(dtDetail);
                    throw new Exception("数据保存成功,上传中公网数据成功," + (bSc ? "成功更新本地标识" : "失败更新本地标识") + "！\r\t医保智能审核检测到存在违规数据,请停止违规医嘱,并冲正费用！ \r\t请在 问题数据处理界面 重新查看该医嘱");
                }
                //强制提交是否需要日志记录或者相关信息 wait jchl

                strMsg = "";
                bool bSc1 = cls.UpdateScbz(dtDetail);
                if (!bSc1)
                {
                    throw new Exception("数据保存成功,上传中公网数据成功,失败更新本地标识！请手动上传该病人费用！");
                }

                return true;
            }
            catch (Exception ex)
            {
                strMsg = "医保智审数据上传错误" + "：" + ex.Message.ToString().Trim();
                SaveLog(FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "医保智审", BinID.ToString() + "医保智审数据上传错误" + "：" + ex.Message.ToString().Trim(), 1, 4);
                //wait  log
                return false;
            }
        }

        /// <summary>
        /// 获取界面上 需要 进行医保智审的数据（有效的）
        /// </summary>
        /// <param name="myTb"></param>
        /// <returns></returns>
        private DataTable DoGetValidateFeeInfo(DataTable myTb, int MNGType, int Kind)
        {
            try
            {
                DataTable dtVal = myTb.Clone();

                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    //如果是选择发送
                    if (MNGType != 9 && Kind == 1)
                    {
                        if (myTb.Rows[i]["选"].ToString() == "False")
                            continue;

                        //dtVal.Rows.Add(myTb.Rows[i]);
                        dtVal.ImportRow(myTb.Rows[i]);
                    }
                }

                return dtVal;
            }
            catch
            {
                throw new Exception("输出有效的需要 进行医保智审的数据 的医嘱费用出错 ");
            }
        }

        //private bool UpdateScbz(DataTable myTb)
        //{
        //    int iSel = 0;
        //    string strCnd = "(";
        //    for (int i = 0; i <= myTb.Rows.Count - 1; i++)
        //    {
        //        strCnd += "'" + myTb.Rows[i]["id"] + "',";
        //        iSel++;
        //    }

        //    if (iSel > 0)
        //    {
        //        strCnd = strCnd.Substring(0, strCnd.Length - 1);
        //        strCnd += ")";
        //    }

        //    try
        //    {
        //        database.BeginTransaction();

        //        //for 循环 性能较差,可靠性强（可以记录未更新到的费用id）
        //        string sql = string.Format(@"update ZY_YBZNSH_Info set scbz=1 where id in {0}", strCnd);
        //        database.DoCommand(sql);

        //        database.CommitTransaction();
        //        return true;
        //    }
        //    catch
        //    {
        //        database.RollbackTransaction();
        //        return false;
        //    }
        //}

        #region 保存相关信息日志
        /// <summary>
        /// 保存相关信息日志
        /// </summary>
        public int SaveLog(long DeptID, long Operator, string typestr, string Content, int errlevel, int type)
        {
            IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            string workstation = "主机名：" + Dns.GetHostName() + "  IP：" + addressList[0].ToString();

            string sSql = "insert into his_log (dept_ID,operator_id,operator_type,Contents,starttime,errlevel,workstation,module_id) " +
                "values(" + DeptID.ToString() + "," + Operator.ToString() + ",'" + typestr.Trim() + "','" + Content.Trim() + "',GetDate()," + errlevel.ToString() + ",'" + workstation + "'," + type.ToString() + ")";
            try
            {
                return database.DoCommand(sSql);
            }
            catch
            {
                return -1;
            }
        }
        #endregion

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
                    if (tbtmb != null && tbtmb.Rows.Count > 0)
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
                    //string sql = "select * from zy_orderexec_lock(nolock) where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID;
                    //Modify by jchl 2016-04-20
                    string sql = "select lock_bit from zy_orderexec_lock(nolock) where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID;
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
                        //if (Convert.ToInt32(tb.Rows[0]["lock_bit"]) == 1)
                        //Modify by jchl 2016-04-20
                        if (Convert.ToInt32(tb.Rows[0]["lock_bit"]) >= 1)
                        {
                            return "";
                        }
                        else
                        {
                            //sql = "select * from zy_orderexec_lock(nolock) where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID;
                            //DataTable  tbtemp = database.GetDataTable(sql);

                            //如果没有被锁，则上锁
                            //int i = database.DoCommand("update zy_orderexec_lock set lock_bit=1 where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID + "  and lock_bit=0 ");

                            //Modify by jchl 2016-04-20
                            int i = database.DoCommand("update zy_orderexec_lock set lock_bit=lock_bit+1 where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID + "  and lock_bit=0 ");
                            // add by zouchihua 2013-9-22 如果没有更新到lock_bit=0的行，说明已经上锁了 ，必须返回
                            if (i == 0)
                                return "";

                            //Modify by jchl 2016-04-20 如果lock_bit被反复更新到则，说明已经上锁了 ，必须返回
                            sql = "select lock_bit from zy_orderexec_lock(nolock) where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID;
                            DataTable dtLock = database.GetDataTable(sql);
                            if (Convert.ToInt32(dtLock.Rows[0]["lock_bit"]) > 1)
                            {
                                return "";
                            }
                        }
                    }
                    if (tb == null || tb.Rows.Count == 0)
                    {
                        //add by zouchihua 2013-9-22 再次判断   如果大于两条则自动删除一条，并且返回
                        //sql = "select * from zy_orderexec_lock(nolock) where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID;

                        //Modify by jchl 2016-04-20
                        sql = "select id from zy_orderexec_lock(nolock) where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID;
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

                bool bUseNewExec = false;//是否使用新版本执行
                bool bAllUser = false;//是否全部使用新版本执行
                SystemCfg cfg6231 = new SystemCfg(6231);
                if (cfg6231.Config.ToString().Trim().Equals("1"))
                {
                    //6231:是否全部使用新版本护士执行 0：否 1：是
                    bAllUser = true;
                }

                int iCnt = 0;
                if (!bAllUser)
                {
                    //未全部开启新版本控制
                    int sendDept = FrmMdiMain.CurrentDept.DeptId;
                    string strSql = string.Format(@"select count(1) as Num from  Vi_JC_NewDept_OrderExec where  dept_id='{0}' ", sendDept);

                    iCnt = int.Parse(Convertor.IsNull(database.GetDataResult(strSql), "0"));
                }

                if (bAllUser || iCnt > 0)
                {
                    //如果全部开启 或者 登陆科室为配置了的上线科室
                    bUseNewExec = true;
                }

                //Modify by jchl 2017-09-01护士执行改造(存储过程执行或者程序执行 待加参数)
                if (!bUseNewExec)
                {
                    string strLog = string.Format(@"sp_zyhs_order_exe-BinID：{0} GroupID：{1} ExecDate：{2}", BinID.ToString(), GroupID.ToString(), ExecDate.ToString("yyyy-MM-dd"));
                    //ExecTimeLogger log = ExecTimeLogger.Run(strLog);

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

                    //log.Stop();
                }
                else
                {
                    string strLog = string.Format(@"医嘱发送代码执行-BinID：{0} GroupID：{1} ExecDate：{2}", BinID.ToString(), GroupID.ToString(), ExecDate.ToString("yyyy-MM-dd"));
                    //ExecTimeLogger log = ExecTimeLogger.Run(strLog);

                    //Modify by jchl 2017-09-01护士执行改造
                    if (_cfgList == null)
                    {
                        _cfgList = new ClsConfigList(database);
                    }
                    int iGroupID = Convert.ToInt32(GroupID);
                    ClsOrderExec clsOrdExec = new ClsOrderExec(BinID, BabyID, iGroupID, MNGType, BookDate, ExecDate, execUser, Jgbm, _cfgList, database);
                    clsOrdExec.ExecOrders(out _outcode, out _outmsg);
                    if (_outcode != 0)
                        throw new Exception(_outmsg);

                    //log.Stop();
                }

                //向中药房发送消息
                GetZcyExectMessage(BinID.ToString(), BabyID.ToString(), GroupID.ToString());
                return _outmsg;
            }
            catch (Exception ex)
            {
                string strLog = string.Format(@"医嘱发送代码执行err-BinID：{0} GroupID：{1} ExecDate：{2} errInfo：{3}", BinID.ToString(), GroupID.ToString(), ExecDate.ToString("yyyy-MM-dd"), ex.Message);
                ExecTimeLogger log = ExecTimeLogger.Run(strLog);
                log.Stop();
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
        private void GetZcyExectMessage(string inpatient_id, string baby_id, string group_id)
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
            catch (Exception EX) { return; }
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
        /// 小药房发药
        /// </summary>
        /// <param name="rtnTb"></param>
        /// <param name="WardDeptId"></param>
        public void Xyf_fy(DataTable rtnTb, int WardDeptId)
        {
            //使用小药房 ，优先扣科室小药房里面库存
            string YF_XYF_YJKS = "select * from YF_XYF_YJKS where QYBZ=1 and  DEPTID=" + WardDeptId;
            DataTable tb_xyf_yjks = database.GetDataTable(YF_XYF_YJKS);
            if (tb_xyf_yjks.Rows.Count > 0)
            {
                rtnTb.TableName = "ddd";
                rtnTb.WriteXml("sssdfsa" + rtnTb.Rows.Count.ToString() + ".xml");
                //WriteLog("找到发药明细" + rtnTb.Rows.Count.ToString());
                #region
                DataTable tbfy = new DataTable();// 需要发药的
                tbfy = rtnTb.Clone();
                tbfy.Columns.Add("kcid", typeof(System.String));
                tbfy.Columns.Add("yppch", typeof(System.String));
                tbfy.Columns.Add("ypph", typeof(System.String));
                tbfy.Columns.Add("ypxq", typeof(System.String));

                DataTable tbkcph = database.GetDataTable("select * from YF_XYF_KCPH where  kcl>0 and  deptid=" + WardDeptId + " order by djsj,yppch asc");
                DataTable tbkcph_lkc = database.GetDataTable("select * from YF_XYF_KCPH where     deptid=" + WardDeptId + " order by djsj,yppch asc");

                string[] GroupByField1 = new string[] { "CJID", "dwbl", "yppch" };
                string[] ComputeField1 = new string[] { "kcl" };
                string[] Cfield1 = new string[] { "sum" };
                DataTable tbkcph_sum = GroupByDataTable(tbkcph.Copy(), GroupByField1, ComputeField1, Cfield1);


                string[] GroupByField = new string[] { "CJID", "UNITRATE" };
                string[] ComputeField = new string[] { "数量" };
                string[] Cfield = new string[] { "sum" };
                DataTable tbcompute = GroupByDataTable(rtnTb.Copy(), GroupByField, ComputeField, Cfield);

                for (int i = 0; i < tbcompute.Rows.Count; i++)
                {
                    string cjid = tbcompute.Rows[i]["CJID"].ToString();
                    //int zxdw = int.Parse(tbcompute.Rows[i]["zxdw"].ToString());
                    int dwbl = int.Parse(tbcompute.Rows[i]["UNITRATE"].ToString());
                    //查询是否库存有
                    DataRow[] _row = tbkcph_sum.Select("CJID='" + cjid + "' ");//and  convert(kcl, 'System.Decimal') >0 //如果没有库存可以退货

                    DataRow[] _row11 = tbkcph.Select("CJID='" + cjid + "' ");
                    DataRow[] _rowlkc = tbkcph_lkc.Select("CJID='" + cjid + "' ");//如果没有这个库存，那么直接走统领，或者有这个库存
                    //只要没有这个库存厂家库存，无条件不发到本科室
                    if (
                        _rowlkc.Length == 0 ||
                        (_row.Length <= 0
                        &&
                        (
                           decimal.Parse(tbcompute.Rows[i]["数量"].ToString()) > 0
                           || _row11.Length < 0

                        )
                        )
                        )
                    {
                        //WriteLog("负数" + cjid.ToString() + "ddd" + _rowlkc.Length);
                        //如果发药的库存小于0，说明退要大于发药，那么是可以发药的

                        //如果没有库存,直接走统领单，移除掉
                        #region
                        try
                        {
                            DataRow[] _rowss;
                            if (_rowlkc.Length != 0)
                                _rowss = rtnTb.Select("CJID=" + cjid + " and 数量>0");//只移除正的
                            else
                                _rowss = rtnTb.Select("CJID=" + cjid + " ");//全部移除
                            for (int j = 0; j < _rowss.Length; j++)
                            {
                                rtnTb.Rows.Remove(_rowss[j]);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(" 如果没有库存,直接走统领单,移除掉出错 " + ex.ToString());
                        }
                        #endregion
                    }
                    //else
                    {

                        try
                        {
                            rtnTb.DefaultView.RowFilter = "CJID=" + cjid + " and 数量>0 and UNITRATE=" + dwbl;

                            DataTable tb_zs = rtnTb.DefaultView.ToTable();
                            rtnTb.DefaultView.RowFilter = "CJID=" + cjid + "  and  数量<0 and UNITRATE=" + dwbl;
                            DataTable tb_fs = rtnTb.DefaultView.ToTable();
                            //如果有库存convert(数量, 'System.Decimal') /UNITRATE
                            try
                            {
                                #region//先抵消正负的
                                //rtnTb.DefaultView.RowFilter = "CJID=" + cjid + " and 数量>0 and UNITRATE=" + dwbl;

                                //DataTable tb_zs = rtnTb.DefaultView.ToTable();
                                //rtnTb.DefaultView.RowFilter = "CJID=" + cjid + "  and  数量<0 and UNITRATE=" + dwbl;
                                //DataTable tb_fs = rtnTb.DefaultView.ToTable();
                                for (int j = 0; j < tb_fs.Rows.Count; j++)
                                {
                                    for (int w = 0; w < tb_zs.Rows.Count; w++)
                                    {
                                        if (Math.Abs(decimal.Parse(tb_fs.Rows[j]["数量"].ToString())) == decimal.Parse(tb_zs.Rows[w]["数量"].ToString()))
                                        {
                                            tbfy.Rows.Add(tb_fs.Rows[j].ItemArray);
                                            tbfy.Rows.Add(tb_zs.Rows[w].ItemArray);
                                            DataRow[] _rowss = tbkcph.Select("cjid=" + cjid);
                                            if (_rowss.Length <= 0)
                                            {
                                                DataTable temptbkc = database.GetDataTable("select * from YF_XYF_KCPH where     deptid=" + WardDeptId + " order by djsj,yppch asc");
                                                _rowss = temptbkc.Select("cjid=" + cjid, " djsj,yppch desc");
                                            }
                                            tbfy.Rows[tbfy.Rows.Count - 1]["kcid"] = _rowss[0]["id"].ToString();
                                            tbfy.Rows[tbfy.Rows.Count - 1]["ypph"] = _rowss[0]["ypph"].ToString();
                                            tbfy.Rows[tbfy.Rows.Count - 1]["yppch"] = _rowss[0]["yppch"].ToString();
                                            tbfy.Rows[tbfy.Rows.Count - 1]["ypxq"] = _rowss[0]["ypxq"].ToString();
                                            tbfy.Rows[tbfy.Rows.Count - 2]["kcid"] = _rowss[0]["id"].ToString();
                                            tbfy.Rows[tbfy.Rows.Count - 2]["ypph"] = _rowss[0]["ypph"].ToString();
                                            tbfy.Rows[tbfy.Rows.Count - 2]["yppch"] = _rowss[0]["yppch"].ToString();
                                            tbfy.Rows[tbfy.Rows.Count - 2]["ypxq"] = _rowss[0]["ypxq"].ToString();


                                            DataRow[] row1 = rtnTb.Select("ZY_ID='" + tb_fs.Rows[j]["ZY_ID"] + "'");
                                            rtnTb.Rows.Remove(row1[0]);
                                            row1 = rtnTb.Select("ZY_ID='" + tb_zs.Rows[w]["ZY_ID"] + "'");
                                            rtnTb.Rows.Remove(row1[0]);
                                            tb_zs.Rows.Remove(tb_zs.Rows[w]);//移除掉
                                            break;
                                        }
                                    }
                                }
                                #endregion
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(" 抵消正负出错 " + ex.ToString());
                            }
                            try
                            {
                                #region//分配负数
                                rtnTb.DefaultView.RowFilter = "CJID=" + cjid + " and 数量<0 and UNITRATE=" + dwbl;
                                tb_fs = rtnTb.DefaultView.ToTable();

                                // WriteLog("分配负数" + cjid.ToString() + " MMMMMMMMM" + tb_fs.Rows.Count.ToString());
                                for (int g = 0; g < tb_fs.Rows.Count; g++)
                                {

                                    decimal sl = decimal.Parse(tb_fs.Rows[g]["数量"].ToString());
                                    DataRow[] select_kcph = tbkcph.Select("cjid=" + cjid + " and kcl>0", "djsj,yppch asc");
                                    if (select_kcph.Length == 0)
                                    {
                                        //如果没有库存大于0的，那么看是否全部为0了
                                        DataTable tbkcph_temp = database.GetDataTable("select isnull(sum(kcl),0) kcl from YF_XYF_KCPH where  kcl>=0 and cjid=" + cjid + " and  deptid=" + WardDeptId + "  ");
                                        if (tbkcph_temp.Rows.Count > 0 && decimal.Parse(tbkcph_temp.Rows[0]["kcl"].ToString()) == 0)
                                        {
                                            DataTable tbkcph_yppc = database.GetDataTable("select * from YF_XYF_KCPH where     deptid=" + WardDeptId + " order by djsj,yppch");
                                            // 如果没有一个批次大于0，那么就去最新批次的药品
                                            select_kcph = tbkcph_yppc.Select("cjid=" + cjid + "", "djsj,yppch desc");
                                            //   WriteLog("负数(((" + select_kcph.Length.ToString());
                                        }
                                    }
                                    for (int j = 0; j < select_kcph.Length; j++)
                                    {
                                        decimal sl_kcsl = sl * int.Parse(select_kcph[j]["dwbl"].ToString()) / dwbl;
                                        tbfy.Rows.Add(tb_fs.Rows[g].ItemArray);
                                        tbfy.Rows[tbfy.Rows.Count - 1]["kcid"] = select_kcph[j]["id"].ToString();
                                        tbfy.Rows[tbfy.Rows.Count - 1]["ypph"] = select_kcph[j]["ypph"].ToString();
                                        tbfy.Rows[tbfy.Rows.Count - 1]["yppch"] = select_kcph[j]["yppch"].ToString();
                                        tbfy.Rows[tbfy.Rows.Count - 1]["ypxq"] = select_kcph[j]["ypxq"].ToString();
                                        //移除行
                                        DataRow[] row1 = rtnTb.Select("ZY_ID='" + tb_fs.Rows[g]["ZY_ID"].ToString() + "'");
                                        rtnTb.Rows.Remove(row1[0]);
                                        select_kcph[j]["kcl"] = decimal.Parse(select_kcph[j]["kcl"].ToString()) + sl_kcsl;//更新库存
                                        break;
                                    }
                                }
                                #endregion
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(" 分配负数 " + ex.ToString());
                            }
                            try
                            {
                                #region//先分配正的
                                rtnTb.DefaultView.RowFilter = "CJID=" + cjid + " and 数量>0 and UNITRATE=" + dwbl;
                                tb_zs = rtnTb.DefaultView.ToTable();
                                for (int k = 0; k < tb_zs.Rows.Count; k++)
                                {
                                    decimal sl = decimal.Parse(tb_zs.Rows[k]["数量"].ToString());
                                    DataRow[] select_kcph = tbkcph.Select("cjid=" + cjid + " and  kcl>0", "djsj,yppch asc");
                                    for (int j = 0; j < select_kcph.Length; j++)
                                    {
                                        //转化为库存量
                                        decimal sl_kcsl = sl * int.Parse(select_kcph[j]["dwbl"].ToString()) / dwbl;
                                        if (sl_kcsl <= decimal.Parse(select_kcph[j]["kcl"].ToString()))
                                        {
                                            //库存足的时候，添加行
                                            tbfy.Rows.Add(tb_zs.Rows[k].ItemArray);
                                            tbfy.Rows[tbfy.Rows.Count - 1]["kcid"] = select_kcph[j]["id"].ToString();
                                            tbfy.Rows[tbfy.Rows.Count - 1]["ypph"] = select_kcph[j]["ypph"].ToString();
                                            tbfy.Rows[tbfy.Rows.Count - 1]["yppch"] = select_kcph[j]["yppch"].ToString();
                                            tbfy.Rows[tbfy.Rows.Count - 1]["ypxq"] = select_kcph[j]["ypxq"].ToString();
                                            //移除行
                                            DataRow[] row1 = rtnTb.Select("ZY_ID='" + tb_zs.Rows[k]["ZY_ID"].ToString() + "'");
                                            if (row1.Length > 0)
                                            {
                                                // throw new Exception("没有找到相应的行记录 " + tb_zs.Rows[k]["ZY_ID"].ToString());
                                                rtnTb.Rows.Remove(row1[0]);
                                            }
                                            select_kcph[j]["kcl"] = decimal.Parse(select_kcph[j]["kcl"].ToString()) - sl_kcsl;//更新库存
                                            break;
                                        }
                                        else
                                        {
                                            object ob_kcl = tbkcph.Compute("sum(kcl)", "cjid=" + cjid + " and kcl>0 ");
                                            decimal kcl_hj = decimal.Parse(ob_kcl.ToString());
                                            if (sl_kcsl <= kcl_hj)
                                            {
                                                //如果跨批次的时候,无条件分配到最早有库存上面
                                                select_kcph[j]["kcl"] = 0;
                                                tbfy.Rows.Add(tb_zs.Rows[k].ItemArray);
                                                tbfy.Rows[tbfy.Rows.Count - 1]["kcid"] = select_kcph[j]["id"].ToString();
                                                tbfy.Rows[tbfy.Rows.Count - 1]["ypph"] = select_kcph[j]["ypph"].ToString();
                                                tbfy.Rows[tbfy.Rows.Count - 1]["yppch"] = select_kcph[j]["yppch"].ToString();
                                                tbfy.Rows[tbfy.Rows.Count - 1]["ypxq"] = select_kcph[j]["ypxq"].ToString();
                                                //移除行
                                                DataRow[] row1 = rtnTb.Select("ZY_ID='" + tb_zs.Rows[k]["ZY_ID"].ToString() + "'");
                                                if (row1.Length > 0)
                                                {
                                                    //throw new Exception("没有找到相应的行记录111 " + tb_zs.Rows[k]["ZY_ID"].ToString());
                                                    rtnTb.Rows.Remove(row1[0]);
                                                }
                                                break;
                                            }
                                            else
                                                break;
                                        }
                                    }
                                }
                                #endregion
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(" 分配正数 " + ex.ToString());
                            }

                        }
                        catch (Exception ex)
                        {
                            throw new Exception(" else " + ex.ToString());
                        }
                    }
                }

                Xyf(tbfy, (int)WardDeptId);
                #endregion
            }
        }
        /// <summary>
        /// 小药房发药
        /// </summary>
        /// <param name="tbfy"></param>
        public void Xyf(DataTable tbfy, int ksid)
        {
            if (tbfy.Rows.Count == 0)
            {
                WriteLog("*********发药未找到发药明细");
                return;
            }
            tbfy.TableName = "xxxxxxxx";
            tbfy.WriteXml("xxxxx.xml");
            //tbfy.TableName = "ss";
            //tbfy.WriteXml("xmfy.xml");
            string[] GroupByField1 = new string[] { "kcid", "单价", "UNITRATE", "cjid", "ypph", "yppch", "ypxq", "单位", "批发价" };
            string[] ComputeField1 = new string[] { "数量", "金额", "批发金额" };
            string[] Cfield1 = new string[] { "sum", "sum", "sum" };
            DataTable tbkcph_sum = GroupByDataTable(tbfy.Copy(), GroupByField1, ComputeField1, Cfield1);
            decimal lsjhj = 0;
            decimal dj = 0;
            decimal sl = 0;
            decimal pfje = 0;
            decimal yfsl = 0;
            int djh = 0;

            #region 库存再次处理
            for (int i = 0; i < tbkcph_sum.Rows.Count; i++)
            {
                //扣库存明细时，再查一次库存,如果不足就不扣
                DataTable tb_yfpchjkc = database.GetDataTable("select sum( kcl) kcl,dwbl from YF_XYF_KCPH nolock where  cjid='" + tbkcph_sum.Rows[i]["cjid"].ToString() + "' and DEPTID=" + ksid + " group by DWBL");
                if (tb_yfpchjkc.Rows.Count == 0)
                    throw new Exception(" 没有找到" + tbkcph_sum.Rows[i]["cjid"].ToString() + "的字典记录");
                try
                {
                    yfsl = decimal.Parse(tbkcph_sum.Rows[i]["数量"].ToString()) * int.Parse(tb_yfpchjkc.Rows[0]["dwbl"].ToString()) / int.Parse(tbkcph_sum.Rows[i]["UNITRATE"].ToString());
                    if (decimal.Parse(tb_yfpchjkc.Rows[0]["kcl"].ToString()) < yfsl)
                    {
                        decimal sl1 = 0;
                        DataRow[] _rowselect = tbfy.Select("cjid='" + tbkcph_sum.Rows[i]["cjid"].ToString() + "'  ");
                        //如果库存不足的时候，那么就全部不扣
                        for (int k = 0; k < _rowselect.Length; k++)
                        {
                            sl1 += decimal.Parse(_rowselect[k]["数量"].ToString()) * int.Parse(tb_yfpchjkc.Rows[0]["dwbl"].ToString()) / int.Parse(_rowselect[k]["UNITRATE"].ToString());
                            if (sl1 < decimal.Parse(tb_yfpchjkc.Rows[0]["kcl"].ToString()))
                            {

                            }
                            else
                            {
                                //如果大于时，说明科室药房不够
                                tbfy.Rows.Remove(_rowselect[k]);
                            }
                        }
                    }
                }
                catch (Exception ex) { throw ex; }
            }
            #endregion
            GroupByField1 = new string[] { "kcid", "单价", "UNITRATE", "cjid", "ypph", "yppch", "ypxq", "单位", "批发价" };
            ComputeField1 = new string[] { "数量", "金额", "批发金额" };
            Cfield1 = new string[] { "sum", "sum", "sum" };
            tbkcph_sum = GroupByDataTable(tbfy.Copy(), GroupByField1, ComputeField1, Cfield1);
            RelationalDatabase _Databasenew = new MsSqlServer();
            _Databasenew.Initialize(database.ConnectionString);
            _Databasenew.BeginTransaction();
            try
            {
                //现插入单据头表
                DataTable tbdh = _Databasenew.GetDataTable("update yf_xyf_djh set djh=djh+1 where ywlx='004'  and  DEPTID=" + ksid + "  select max(djh) djh from yf_xyf_djh where ywlx='004' and  DEPTID=" + ksid);
                if (tbdh.Rows.Count == 0)
                {
                    throw new Exception("获得单据号失败");
                }
                djh = int.Parse(tbdh.Rows[0]["djh"].ToString());
                Guid id = Guid.NewGuid();
                //插入单据头表
                lsjhj = 0;
                dj = 0;
                sl = 0;
                pfje = 0;
                for (int i = 0; i < tbkcph_sum.Rows.Count; i++)
                {

                    //扣库存明细时，再查一次库存,如果不足就不扣
                    DataTable tb_yfpchjkc = _Databasenew.GetDataTable("select sum( kcl) kcl,dwbl from YF_XYF_KCPH nolock where  cjid='" + tbkcph_sum.Rows[i]["cjid"].ToString() + "' and deptid=" + ksid + " group by DWBL");
                    if (tb_yfpchjkc.Rows.Count == 0)
                        throw new Exception(" 没有找到" + tbkcph_sum.Rows[i]["cjid"].ToString() + "的字典记录");
                    try
                    {
                        yfsl = decimal.Parse(tbkcph_sum.Rows[i]["数量"].ToString()) * int.Parse(tb_yfpchjkc.Rows[0]["dwbl"].ToString()) / int.Parse(tbkcph_sum.Rows[i]["UNITRATE"].ToString());
                        if (decimal.Parse(tb_yfpchjkc.Rows[0]["kcl"].ToString()) < yfsl)
                        {
                            //如果库存不足的时候，那么就全部不扣
                            //不足的时候，还是要全部扣库存
                            continue;
                        }
                    }
                    catch (Exception ex) { throw ex; }

                    try
                    {
                        if (decimal.Parse(tbkcph_sum.Rows[i]["数量"].ToString()) != 0)
                        {
                            lsjhj = lsjhj + decimal.Parse(tbkcph_sum.Rows[i]["金额"].ToString());
                            dj = decimal.Parse(tbkcph_sum.Rows[i]["单价"].ToString());
                            sl = sl + decimal.Parse(tbkcph_sum.Rows[i]["数量"].ToString());
                            pfje = pfje + decimal.Parse(tbkcph_sum.Rows[i]["批发金额"].ToString());

                        }
                        else
                        {
                            lsjhj = lsjhj + 0;
                            dj = decimal.Parse(tbkcph_sum.Rows[i]["单价"].ToString());
                            sl = sl + decimal.Parse(tbkcph_sum.Rows[i]["数量"].ToString());
                            pfje = pfje + 0;
                        }
                        //lsjhj =   decimal.Parse(tbkcph_sum.Rows[i]["金额"].ToString());
                        //dj = decimal.Parse(tbkcph_sum.Rows[i]["单价"].ToString());
                        //sl =   decimal.Parse(tbkcph_sum.Rows[i]["数量"].ToString());
                        //pfje =   decimal.Parse(tbkcph_sum.Rows[i]["批发金额"].ToString());
                    }
                    catch (Exception ex)
                    {
                        WriteLog(" lsjhj " + ex.ToString() + tbkcph_sum.Rows[i]["金额"].ToString() + "!" + tbkcph_sum.Rows[i]["单价"].ToString()
                            + "!" + tbkcph_sum.Rows[i]["数量"].ToString() + "! " + tbkcph_sum.Rows[i]["批发金额"].ToString());
                    }
                    string ypph = tbkcph_sum.Rows[i]["ypph"].ToString();
                    string yppch = tbkcph_sum.Rows[i]["yppch"].ToString();
                    string ypxq = tbkcph_sum.Rows[i]["ypxq"].ToString();
                    string cjid = tbkcph_sum.Rows[i]["cjid"].ToString();
                    string kcid = tbkcph_sum.Rows[i]["kcid"].ToString();
                    string ypdw = tbkcph_sum.Rows[i]["单位"].ToString();
                    string dwbl = tbkcph_sum.Rows[i]["UNITRATE"].ToString();
                    string pfj = tbkcph_sum.Rows[i]["批发价"].ToString();
                    DataTable tb_cjd = _Databasenew.GetDataTable("select * from YP_YPCJD nolock where   BDELETE=0 and CJID=" + cjid + "   ");
                    if (tb_cjd.Rows.Count == 0)
                        throw new Exception(" 没有找到" + cjid + "的字典记录");
                    try
                    {
                        string sql_djmx = string.Format(@"insert into dbo.YF_XYF_DJMX(
ID, DJID, CJID, KWID, SHH, YPPM, YPSPM, YPGG, SCCJ, YPPH, YPXQ, 
YPPCH, KCID, SQSL, YPSL, YPDW, NYPDW, YDWBL,
 JHJ, PFJ, LSJ, JHJE, PFJE, LSJE, DJH, DEPTID, YWLX, BZ ) values
(newid(),'{0}',{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}',
'{10}','{11}',{12},{13},'{14}','{15}','{16}',
{17},{18},{19},{20},{21},{22},'{23}',{24},'004',null)"
                            , id, cjid, 0, tb_cjd.Rows[0]["SHH"].ToString(), tb_cjd.Rows[0]["S_YPPM"].ToString(), tb_cjd.Rows[0]["S_YPSPM"].ToString(), tb_cjd.Rows[0]["S_YPGG"].ToString(),
                            tb_cjd.Rows[0]["S_SCCJ"].ToString(), ypph, ypxq.Trim(),
                            yppch, kcid, decimal.Parse(tbkcph_sum.Rows[i]["数量"].ToString()), decimal.Parse(tbkcph_sum.Rows[i]["数量"].ToString()), ypdw, dwbl, dwbl,
                            "0", pfj, dj, "0", decimal.Parse(tbkcph_sum.Rows[i]["数量"].ToString()) == 0 ? 0 : decimal.Parse(tbkcph_sum.Rows[i]["批发金额"].ToString()), decimal.Parse(tbkcph_sum.Rows[i]["数量"].ToString()) == 0 ? 0 : decimal.Parse(tbkcph_sum.Rows[i]["金额"].ToString()), djh, ksid);
                        _Databasenew.DoCommand(sql_djmx);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(" sql_djmx" + ex.ToString());
                    }
                    //扣库存明细时，再查一次库存
                    DataTable tb_yfpc = _Databasenew.GetDataTable("select cjid,dwbl, kcl from YF_XYF_KCPH nolock where  id='" + kcid + "'");
                    if (tb_yfpc.Rows.Count == 0)
                        throw new Exception(" 没有找到" + cjid + "的字典记录");
                    try
                    {
                        yfsl = decimal.Parse(tbkcph_sum.Rows[i]["数量"].ToString()) * int.Parse(tb_yfpc.Rows[0]["dwbl"].ToString()) / int.Parse(dwbl);
                    }
                    catch { MessageBox.Show(dwbl.ToString() + " dwbl"); }
                    int outint = 0;
                    string outsrt = "";
                    //AddUpdateKcmx(id, out outint, out outsrt, FrmMdiMain.Jgbm, _Databasenew);
                    #region 更新库存
                    try
                    {
                        if (yfsl < decimal.Parse(tb_yfpc.Rows[0]["kcl"].ToString()))
                        {
                            //如果改批次库存量足
                            string update_kc = "update YF_XYF_KCPH set kcl=kcl-(" + yfsl + ") where id='" + kcid + "'";
                            int i1 = database.DoCommand(update_kc);//更新库存
                            if (i1 == 0)
                                throw new Exception("更新YF_XYF_KCPH时没有更新到行");
                            update_kc = "update YF_XYF_KCMX set kcl=kcl-(" + yfsl + ") where cjid='" + cjid + "'  and  DEPTID=" + ksid;
                            i1 = database.DoCommand(update_kc);//更新库存
                            if (i1 == 0)
                                throw new Exception("更新YF_XYF_KCMX时没有更新到行" + update_kc);
                            //WriteLog(update_kc);
                        }
                        else
                        {
                            //如果不足，就先扣第一个批次的,否则循环扣
                            DataTable tbtempyppc = database.GetDataTable("select cjid,dwbl, kcl,id from YF_XYF_KCPH nolock where kcl>0  and DEPTID=" + ksid + " and  cjid='" + cjid + "'   order by djsj,yppch asc");
                            for (int y = 0; y < tbtempyppc.Rows.Count; y++)
                            {
                                if (yfsl < decimal.Parse(tbtempyppc.Rows[y]["kcl"].ToString()))
                                {
                                    string update = "update YF_XYF_KCPH set kcl=kcl-(" + yfsl + ") where id='" + tbtempyppc.Rows[y]["id"].ToString() + "'  and kcl>=" + yfsl;
                                    int i1 = database.DoCommand(update);//更新库存
                                    // WriteLog(update);
                                    if (i1 == 0)
                                        throw new Exception("更新YF_XYF_KCPH时没有更新到行" + update);
                                    string update_kc = "update YF_XYF_KCMX set kcl=kcl-(" + yfsl + ") where cjid=" + cjid + " and  DEPTID=" + ksid + " and kcl>=" + yfsl;
                                    i1 = database.DoCommand(update_kc);//更新库存
                                    //WriteLog(update_kc);
                                    if (i1 == 0)
                                        throw new Exception("更新YF_XYF_KCMX时没有更新到行" + update_kc);
                                    break;
                                }
                                else
                                {
                                    yfsl = yfsl - decimal.Parse(tbtempyppc.Rows[y]["kcl"].ToString());
                                    string update = "update YF_XYF_KCPH set kcl=kcl-(" + decimal.Parse(tbtempyppc.Rows[y]["kcl"].ToString()) + ") where id='" + tbtempyppc.Rows[y]["id"].ToString() + "'  and kcl>=" + decimal.Parse(tbtempyppc.Rows[y]["kcl"].ToString());
                                    int w = database.DoCommand(update);//更新库存
                                    //WriteLog(update);
                                    if (w == 0)
                                        throw new Exception("更新YF_XYF_KCPH时没有更新到行" + update);
                                    string update_kc = "update YF_XYF_KCMX set kcl=kcl-(" + decimal.Parse(tbtempyppc.Rows[y]["kcl"].ToString()) + ") where cjid=" + cjid + "  and  DEPTID=" + ksid + "and kcl>=" + decimal.Parse(tbtempyppc.Rows[y]["kcl"].ToString());
                                    w = database.DoCommand(update_kc);//更新库存
                                    //WriteLog(update_kc);
                                    if (w == 0)
                                        throw new Exception("更新YF_XYF_KCMX时没有更新到行" + update_kc);
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog(" 更新库存" + ex.ToString());
                        throw new Exception(" 更新库存" + ex.ToString());
                    }
                    #endregion
                }
                try
                {
                    string sqlinsert = string.Format(@"insert into dbo.YF_XYF_DJ (
           ID, JGBM, DJH, DEPTID, YWLX, WLDW, DJY, DJRQ, SHBZ, SHY, SHRQ, YJID, BZ, 
            SQDH, SUMJHJE, SUMPFJE, SUMLSJE, YDJID, BPRINT) values(
            '{0}',{1},{2},{3},'004',{4},{5},getdate(),1,{6},getdate(),null,null,
             0,0,{7},{8},null,0
)  ",
                    id, FrmMdiMain.Jgbm, djh, ksid, ksid, FrmMdiMain.CurrentUser.EmployeeId, FrmMdiMain.CurrentUser.EmployeeId,
                    pfje, lsjhj);
                    _Databasenew.DoCommand(sqlinsert);
                }
                catch (Exception ex)
                {

                    throw new Exception(" 插入 YF_XYF_DJ " + ex.ToString());
                }
                //更新费用表
                for (int i = 0; i < tbfy.Rows.Count; i++)
                {



                    string sql = @" update ZY_FEE_SPECI set fy_bit=1,fy_date=getdate(),charge_bit=1,tlfs='12' ,bz=isnull(bz,'')+'  【病区药房减库存】', charge_date=(case when charge_date is null then getdate() else charge_date end) 
                        ,apply_id='" + id + "',group_id='" + id + "' ,CHARGE_USER=" + FrmMdiMain.CurrentUser.EmployeeId +
                                     @",kcid='" + tbfy.Rows[i]["kcid"].ToString() + "' where id='" + tbfy.Rows[i]["zy_id"].ToString() + "' and fy_bit=0";

                    int i1 = _Databasenew.DoCommand(sql);
                    if (i1 == 0)
                        throw new Exception("更新ZY_FEE_SPECI时没有更新到行");
                }
                _Databasenew.CommitTransaction();
            }
            catch (Exception ex)
            {
                _Databasenew.RollbackTransaction();
                throw ex;
            }
            finally
            {
                _Databasenew.Close();
                _Databasenew.Dispose();
            }

        }



        //private int Docommand(string ConnectionString,string commandText)
        //{
        //    System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection();
        //    try
        //    {
        //        connect.ConnectionString = ConnectionString;
        //        connect.Open();
        //        System.Data.SqlClient.SqlCommand _command = new System.Data.SqlClient.SqlCommand(commandText, connect);
        //        int i = _command.ExecuteNonQuery();
        //        connect.Close();
        //        connect.Dispose();
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //    return i;
        //}
        //更新小药房库存
        public void AddUpdateKcmx(Guid djid, out int err_code, out string err_text, long jgbm, RelationalDatabase db)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@djid";
                parameters[0].Value = djid;

                parameters[1].Text = "@err_code";
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[1].DataType = System.Data.DbType.Int32;
                parameters[1].ParaSize = 100;

                parameters[2].Text = "@err_text";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;

                parameters[3].Text = "@jgbm";
                parameters[3].Value = jgbm;

                db.DoCommand("sp_yf_xyf_updatekcmx", parameters, 120);
                err_code = Convert.ToInt32(parameters[1].Value);
                err_text = Convert.ToString(parameters[2].Value);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        private void WriteLog(string ss)
        {
            //写LOG
            DateTime date = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            string path = Application.StartupPath + "\\小药房\\" + "LOG" + date.ToString("yyyyMMdd") + ".txt";

            if (!System.IO.Directory.Exists(Application.StartupPath + "\\小药房"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\小药房");
            }
            if (!File.Exists(path))//如果文件不存在 
            {
                File.Create(path).Close();
            }

            StreamWriter sr = File.AppendText(path);
            sr.WriteLine("机器：" + System.Net.Dns.GetHostName() + " " + System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())[0].ToString());
            sr.WriteLine("时间：" + date.ToString());
            sr.WriteLine(ss);
            sr.WriteLine("-------------------------------------------");
            sr.Close();
        }
        public DataTable GroupByDataTable(DataTable tbtb, string[] GroupByField, string[] ComputeField, string[] Cfield)
        {
            DataTable tbCompute = new DataTable();
            //if (tbtb.Rows.Count <= 0)
            //    return tbCompute;
            List<string> lstCol = new List<string>();
            List<string> lstHj = new List<string>();

            #region 数据验证
            for (int i = 0; i < tbtb.Columns.Count; i++)
            {
                lstCol.Add(tbtb.Columns[i].ColumnName.ToLower().Trim());
            }

            for (int i = 0; i < GroupByField.Length; i++)
            {
                if (!lstCol.Contains(GroupByField[i].Trim().ToLower()))
                {
                    throw new Exception(string.Format("分组发生错误:找不到GroupByField:{0}", GroupByField[i].Trim().ToLower()));
                }
            }

            for (int i = 0; i < ComputeField.Length; i++)
            {
                if (!lstCol.Contains(ComputeField[i].ToLower().Trim()))
                {
                    throw new Exception(string.Format("分组发生错误:找不到ComputeField:{0}", ComputeField[i].Trim().ToLower()));
                }
            }
            lstHj.Add("sum");
            lstHj.Add("max");
            lstHj.Add("min");
            lstHj.Add("count");
            for (int i = 0; i < Cfield.Length; i++)
            {
                if (!lstHj.Contains(Cfield[i].ToLower().Trim()))
                {
                    throw new Exception(string.Format("分组发生错误:不支持Cfield:{0}", Cfield[i]));
                }
            }

            if (ComputeField.Length != Cfield.Length)
            {
                throw new Exception("分组发生错误:ComputeField与Cfield数组长度不一致");
            }
            #endregion

            #region 添加列
            for (int i = 0; i <= GroupByField.Length - 1; i++)
                tbCompute.Columns.Add(GroupByField[i]);
            for (int i = 0; i <= ComputeField.Length - 1; i++)
                tbCompute.Columns.Add(ComputeField[i]);
            if (tbtb.Rows.Count <= 0) return tbCompute;
            #endregion

            #region 计算
            DataTable tb = tbtb.Copy();
            string strFilter = " 1=1 ";
            try
            {

                for (int i = 0; 0 < tb.Rows.Count; i++)
                {
                    DataRow insertRow = tbCompute.NewRow();
                    strFilter = " 1=1 ";
                    for (int j = 0; j < GroupByField.Length; j++)
                    {

                        if (tb.Rows[0][GroupByField[j]] is DBNull)
                        {
                            strFilter += string.Format(" and {0} is null ", GroupByField[j].ToString().Trim()
                            );
                        }
                        else
                        {
                            strFilter += string.Format(" and {0}='{1}'", GroupByField[j].ToString().Trim(),
                              tb.Rows[0][GroupByField[j]].ToString().Trim());
                        }

                        //分组列赋值
                        insertRow[GroupByField[j]] = tb.Rows[0][GroupByField[j]];
                    }

                    tb.DefaultView.RowFilter = strFilter;
                    DataTable tbTemp = tb.DefaultView.ToTable();

                    //求汇总
                    for (int mm = 0; mm < ComputeField.Length; mm++)
                    {
                        string strCompute = string.Format("{0}({1})", Cfield[mm], ComputeField[mm]);
                        insertRow[ComputeField[mm]] = tbTemp.Compute(strCompute, "").ToString();
                    }

                    tbCompute.Rows.Add(insertRow);
                    DataRow[] rows = tb.Select(strFilter);
                    if (rows.Length <= 0)
                    {
                        throw new Exception("分组发生错误,未成成功移除行:" + strFilter);
                    }
                    for (int w = 0; w < rows.Length; w++)
                    {
                        tb.Rows.Remove(rows[w]);
                    }

                }
            }
            catch (Exception err)
            {
                throw new Exception("分组发生错误" + strFilter + " " + err.Message);
            }
            #endregion

            return tbCompute;
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
                                else if (cfg7104 == "2")//只有长期医嘱摆药（满足摆药条件）
                                {
                                    _where[j] = " MNGTYPE=0  and  ypjx in (" + ypjx[j] + ") and ypyf in (" + ypyf[j] + ") ";
                                }
                                else
                                    if (cfg7104 == "3")//拆零口服药进摆药单 ：不区分临时和长期
                                        _where[j] += "UNITRATE>1  and  tlfl in " + whereIN;
                                    else
                                    {
                                        if (cfg7104 == "4")//拆零口服药并且领药不是药库单位整数倍 进摆药单 ：不区分临时和长期
                                        {
                                            _where[j] += "UNITRATE>1 and  convert(convert(数量, 'System.Decimal') /UNITRATE , 'System.Int32')<>convert(数量 , 'System.Decimal') /UNITRATE  and  tlfl in " + whereIN;
                                            //2014-11-27 pengy 
                                            _where[j] += " and ypjx in (" + ypjx[j] + ") and ypyf in (" + ypyf[j] + ")  and (YPLX<>'02' or CJID in(2102,1895,1836)) and CJID not in ('6849','5042','4288','4825' ,'4778','6869','7013','4900','6591','4719','415','6523','2804','2217','33','379','4296','312','1420','6966','6561','435','4946','4957','7011') ";
                                        }
                                        else
                                            _where[j] = " ypjx in (" + ypjx[j] + ") and ypyf in (" + ypyf[j] + ") ";
                                    }
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
                //写错误日志 Add By Tany 2015-09-06
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "生成药品统领单错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(database), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                throw err;
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
        public void SendYPzcgl(DataTable tab, string WardID, long EmpID, System.DateTime SendDate, long ExecDept_Id, int MsgType, int Jgbm)
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
                                            if (cfg7104 == "4")//拆零口服药并且领药不是药库单位整数倍 进摆药单 ：不区分临时和长期
                                                _where[j] += "UNITRATE>1 and  convert(convert(数量, 'System.Decimal') /UNITRATE , 'System.Int32')<>convert(数量 , 'System.Decimal') /UNITRATE  and  tlfl in " + whereIN;
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
                //    scdj(tab, (int)ExecDept_Id);
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
        /// <summary>
        /// 生成药品统领单
        /// </summary>
        /// <param name="tb">格式参见SP_ZYHS_YPFY_SELECT出参</param>
        /// <param name="WardID">病区ID</param>
        /// <param name="EmpID">用户ID</param>
        /// <param name="SendDate">发送日期</param>
        /// <param name="Jgbm">机构编码</param>
        public void SendYPzcgl(DataTable tab, string WardID, long EmpID, System.DateTime SendDate, long ExecDept_Id, int MsgType, int Jgbm, int ywlx)
        {

            //
            // database.BeginTransaction();
            try
            {
                scdj(tab, (int)ExecDept_Id, ywlx);
                //   database.CommitTransaction();
            }
            catch (Exception err)
            {
                // database.RollbackTransaction();
                MessageBox.Show(err.Message + " SendYPzcgl");
            }
            return;
            //
            SystemCfg cfg7117 = new SystemCfg(7117);
            string zcyexecdeptid = cfg7117.Config.Trim();
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
                                " VALUES('" + _applyid + "','" + SendDate + "'," + EmpID + "," + deptlyTb.Rows[k]["dept_ly"].ToString() + ",'" + zcyexecdeptid + "'," + MsgType + ",'99',DBO.FUN_GETEMPTYGUID()," + Jgbm + ") ";
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
                                            if (cfg7104 == "4")//拆零口服药并且领药不是药库单位整数倍 进摆药单 ：不区分临时和长期
                                                _where[j] += "UNITRATE>1 and  convert(convert(数量, 'System.Decimal') /UNITRATE , 'System.Int32')<>convert(数量 , 'System.Decimal') /UNITRATE  and  tlfl in " + whereIN;
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
                                            " VALUES('" + _applyid + "','" + SendDate + "'," + EmpID + ",'" + deptlyTb.Rows[k]["dept_ly"].ToString() + "','" + zcyexecdeptid + "'," + MsgType + ",'" + lyflTb.Rows[j]["code"].ToString() + "',DBO.FUN_GETEMPTYGUID()," + Jgbm + ") ";
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
                                    " VALUES('" + _applyid + "','" + SendDate + "'," + EmpID + ",'" + deptlyTb.Rows[k]["dept_ly"].ToString() + "','" + zcyexecdeptid + "'," + MsgType + ",'99',DBO.FUN_GETEMPTYGUID()," + Jgbm + ") ";
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
                //    scdj(tab, (int)ExecDept_Id);
                scdj(tab, (int)ExecDept_Id, ywlx);
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
        private void scdj(DataTable tb, int zxksid)
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
                                                              + @"," + (decimal.Parse(tbflcjid.Rows[j]["ypsl"].ToString()) == 0 ? 0 : (decimal.Parse(tbflcjid.Rows[j]["金额"].ToString()) / (decimal.Parse(tbflcjid.Rows[j]["ypsl"].ToString()))))
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
        private void scdj(DataTable tb, int zxksid, int ywlx)
        {
            SystemCfg cfg7117 = new SystemCfg(7117);
            string zcyexecdeptid = cfg7117.Config.Trim();
            FrmJdt jdt = new FrmJdt();
            jdt.Show();
            //jdt.progressBar1.Value = 50;
            //jdt.labjd.Text = "完成" + System.Math.Round((decimal)(50 + 1) / 100) * 100 + "%";
            //return;
            //System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle
            //jdt.AddOwnedForm(((Form)TrasenFrame.Forms.FrmMdiMain));
            try
            {
                //string[] GroupbyField1 ={ "cjid", "dept_ly", "ZXDW", "tlfl", "单价", "dwbl" };
                //string[] ComputeField1 ={ "数量", "金额", "ypsl" };
                //string[] CField1 ={ "sum", "sum", "sum" };
                //TrasenFrame.Classes.TsSet tsset1 = new TrasenFrame.Classes.TsSet();
                //tsset1.TsDataTable = tb;
                //DataTable tbflcjid = tsset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
                DataTable tbflcjid = groupby(tb);
                string[] updatesql = new string[tbflcjid.Rows.Count];
                string[] insertdjxx = new string[tbflcjid.Rows.Count];

                jdt.progressBar1.Maximum = tbflcjid.Rows.Count;
                jdt.progressBar1.Value = 0;
                for (int j = 0; j < tbflcjid.Rows.Count; j++)
                {
                    // writelog( "第["+j.ToString()+"]开始事物");
                    database.BeginTransaction();
                    try
                    {
                        //库存量减少，暂存基数变大
                        updatesql[j] = "  update dbo.Zy_ZcyKcmx set kcl=a.kcl-(" + tbflcjid.Rows[j]["数量"].ToString() + ")*a.DWBL/(" + tbflcjid.Rows[j]["UNITRATE"].ToString() + "),zcjs=zcjs+(" + tbflcjid.Rows[j]["数量"].ToString() + ")*a.DWBL/(" + tbflcjid.Rows[j]["UNITRATE"].ToString() + ")"
                                       + " from Zy_ZcyKcmx a join YF_KCMX b  on a.cjid=b.cjid and b.DEPTID=a.yfksid where a.cjid=" + tbflcjid.Rows[j]["cjid"].ToString() +
                                        " and  ksid=" + tbflcjid.Rows[j]["dept_ly"].ToString()
                                        + " and  yfksid=" + zxksid;
                        // writelog(updatesql[j] + " ****" + j.ToString());
                        database.DoCommand(updatesql[j]);
                        // writelog("更新Zy_ZcyKcmx完毕");
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
                                                                  + @"," + ywlx + "," + zxksid + @",getdate(),"//2 表示暂存药发送到药房
                                                                  + FrmMdiMain.CurrentUser.EmployeeId + @",'" + tbflcjid.Rows[j]["tlfl"].ToString()
                                                                  + @"'," + tbflcjid.Rows[j]["cjid"].ToString() + @"," + tbflcjid.Rows[j]["zxdw"].ToString()
                                                                  + @"," + tbflcjid.Rows[j]["ypsl"].ToString()
                                                                  + @"," + (decimal.Parse(tbflcjid.Rows[j]["ypsl"].ToString()) == 0 ? 0 : (decimal.Parse(tbflcjid.Rows[j]["金额"].ToString()) / (decimal.Parse(tbflcjid.Rows[j]["ypsl"].ToString()))))
                                                                  + @",1," + FrmMdiMain.CurrentUser.EmployeeId + @",getdate()," + tbflcjid.Rows[j]["DWBL"].ToString() + @""
                                                                  + @")"
                                                              );
                        //  writelog(insertdjxx[j] + " ****" + j.ToString());
                        database.DoCommand(insertdjxx[j]);
                        // writelog("插入zy_zcydjxx完毕");
                        #region//插入单据明细
                        string filter = "cjid=" + tbflcjid.Rows[j]["cjid"].ToString() + " and  dept_ly=" + tbflcjid.Rows[j]["dept_ly"].ToString()
                                          + "  and  ZXDW=" + tbflcjid.Rows[j]["zxdw"].ToString();
                        DataRow[] _row = tb.Select(filter);
                        //  writelog("************");
                        // writelog("插入zy_zcydjxx开始");
                        string swhere = "";
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
                            if (swhere == "")
                            {
                                swhere = "'" + feeid + "'";
                            }
                            else
                            {
                                swhere += ",'" + feeid + "'";
                            }

                            //string update = "update ZY_FEE_SPECI set  bz=cast(EXECDEPT_ID as varchar(20)),fy_bit=1,FY_DATE=getdate(),APPLY_ID=INPATIENT_ID,FY_USER =" + FrmMdiMain.CurrentUser.EmployeeId + " , EXECDEPT_ID=" + zcyexecdeptid + " where id= '" + feeid + "'";
                            //database.DoCommand(update);
                            // update = "update ZY_FEE_SPECI_h set  bz=cast(EXECDEPT_ID as varchar(20)),fy_bit=1,FY_DATE=getdate(),APPLY_ID=INPATIENT_ID,FY_USER =" + FrmMdiMain.CurrentUser.EmployeeId + " , EXECDEPT_ID=" + zcyexecdeptid + " where id= '" + feeid + "'";
                            //database.DoCommand(update);
                        }
                        // writelog("插入zy_zcydjxx完毕");
                        // writelog("开始跟新ZY_FEE_SPECI完毕");
                        string update = "update ZY_FEE_SPECI set  bz=cast(EXECDEPT_ID as varchar(20)),fy_bit=1,FY_DATE=getdate(),APPLY_ID=INPATIENT_ID,FY_USER =" + FrmMdiMain.CurrentUser.EmployeeId + " , EXECDEPT_ID=" + zcyexecdeptid + " where id IN (" + swhere + ")";
                        database.DoCommand(update);
                        update = "update ZY_FEE_SPECI_h set  bz=cast(EXECDEPT_ID as varchar(20)),fy_bit=1,FY_DATE=getdate(),APPLY_ID=INPATIENT_ID,FY_USER =" + FrmMdiMain.CurrentUser.EmployeeId + " , EXECDEPT_ID=" + zcyexecdeptid + " where id  IN (" + swhere + ")";
                        database.DoCommand(update);
                        //  writelog("ZY_FEE_SPECI完毕");

                        #endregion
                        database.CommitTransaction();
                        jdt.progressBar1.Value = j + 1;
                        jdt.labjd.Text = "目前已经完成 " + System.Math.Round((decimal)(j + 1) / jdt.progressBar1.Maximum) * 100 + "%";
                        jdt.Refresh();
                        //writelog("第[" + j.ToString() + "]事物结束");
                    }
                    catch (Exception e)
                    {
                        database.RollbackTransaction();
                        jdt.Close();
                        throw new Exception(e.Message);
                    }

                }
                //InstanceForm.BDatabase.DoCommand(null, null, null, updatesql);
                //InstanceForm.BDatabase.DoCommand(null, null, null, insertdjxx);
                jdt.Close();
            }
            catch (Exception ex)
            {
                jdt.Close();
                throw new Exception(ex.Message + "生成单据为2 的类型时错误");
            }
        }
        public void Cszcyp(DataTable tb, string Wardeptid, long EmpID, long ExecDept_Id, DateTime dt, int Jgbm, out Guid group_id)
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
                Guid Group_id = Guid.NewGuid();
                group_id = Group_id;
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
                parameters1[4].Value = Int32.Parse(Wardeptid);
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
        public DataTable HS_ORDERPRINT(Guid _inpatient_id, long _baby_id, int _OrderType, int _Type, long _user_id, int _bpage, int _epage, int _bRow, int _Erow)
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
                rtnTb.DefaultView.RowFilter = tj;
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
        public string HS_ORDERPRINT(Guid _inpatient_id, long _baby_id, int _OrderType, int _Type, long _user_id, int _bpage, int _epage, int onlyexec, int _brow, int _erow)
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
            SystemCfg cfg7204 = new SystemCfg(7204);
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
            if (cfg7204.Config == "1")
            {
                try
                {
                    //add by yaokx 2014-06-18 
                    string s = @"select * from ZY_INPATIENT_SUPPLY where INPATIENT_ID='" + _inpatientid + "'";
                    DataTable mydt = database.GetDataTable(s);
                    if (mydt != null && mydt.Rows.Count > 0)
                    {
                        //记账
                        if (mydt.Rows[0]["PATIENTTYPE"].ToString() == "1")
                        {
                            switch (mydt.Rows[0]["CHARGETYPE"].ToString())
                            {
                                //合同单位
                                case "0":
                                    string sqlht = @"select * from JC_HTDW where ID=" + mydt.Rows[0]["HTDW"].ToString() + "";
                                    DataTable mydt_ht = database.GetDataTable(sqlht);
                                    if (mydt_ht != null && mydt_ht.Rows.Count > 0 && mydt.Rows[0]["audit_flag"].ToString() == "1")
                                    {
                                        rtnYE = rtnYE + (-1 * Convert.ToDecimal(Convertor.IsNull(mydt_ht.Rows[0]["maxmoney"], "0")));
                                    }
                                    else
                                    {
                                        rtnYE = -99999999;
                                    }
                                    break;
                                //职工担保
                                case "1":
                                    //string sqlzg = @"select ASSURERID from ZY_ASSURE where INPATIENTID='" + ClassStatic.Current_BinID + "' and DELETEBIT=0";
                                    //DataTable mydt_zg = FrmMdiMain.Database.GetDataTable(sqlzg);
                                    //if (mydt_zg != null && mydt_zg.Rows.Count > 0)
                                    //{
                                    //    AssureServices assureServices = new AssureServices();
                                    //    if (assureServices != null)
                                    //    {
                                    //        if (!assureServices.IsEmpContinueAssure(Convert.ToInt32(mydt_zg.Rows[0]["ASSURERID"].ToString())))
                                    //        {
                                    //            rtnYE = rtnYE + (-1 * Convert.ToDecimal(Convertor.IsNull(new SystemCfg(5130).Config, "0")));
                                    //        }
                                    //    }  
                                    //}

                                    AssureServices assureServices = new AssureServices();
                                    rtnYE = rtnYE + (-1 * assureServices.GetCanAssureMoney(_inpatientid));
                                    break;
                                //特殊担保
                                case "2":
                                    ZyInpatientServices zyInpatientServices = new ZyInpatientServices();
                                    decimal maxCredit = zyInpatientServices.GetMaxCreditOfInpatient(_inpatientid);
                                    rtnYE = rtnYE + (-1 * maxCredit);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                            if (mydt.Rows[0]["PATIENTTYPE"].ToString() == "2")
                            {
                                AssureServices assureServices = new AssureServices();
                                rtnYE = rtnYE + (-1 * assureServices.GetCanAssureMoney(_inpatientid));
                            }
                            else
                            {
                                ZyInpatientServices zyInpatientServices = new ZyInpatientServices();
                                decimal maxCredit = zyInpatientServices.GetMaxCreditOfInpatient(_inpatientid);
                                rtnYE = rtnYE + (-1 * maxCredit);
                                // rtnYE = rtnYE + (-1 * Convert.ToDecimal(Convertor.IsNull(mydt.Rows[0]["NEWRANG_MONEY"], "0")));
                            }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex);
                }
            }
            // MessageBox.Show(rtnYE.ToString());
            return rtnYE;
        }
        /// <summary>
        /// 获取病人余额度，药房发药用
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public DataTable GetBrYe(DataTable tb)
        {
            try
            {
                tb.Columns.Add("brye", typeof(System.Decimal));
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    decimal brye = GetYfMinExeye(new Guid(tb.Rows[i]["brid"].ToString()));
                    tb.Rows[i]["brye"] = brye;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取病人可用余额出错：" + ex.Message);
            }
            return tb;
        }
        /// <summary>
        /// 用于药房发药记账的欠费，此函数获得可用余额
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <returns></returns>
        public decimal GetYfMinExeye(Guid inpatient_id)
        {
            decimal kyfy = 0;//可以费用
            SystemCfg cfg7186 = new SystemCfg(7186);
            decimal qfye = GetPatMinExecYE(inpatient_id);
            decimal _ye = 0;
            //_ye-qfye
            string sql = "select DISCHARGETYPE,DBO.FUN_ZY_SEEKPATFEEINFO(INPATIENT_ID,0,0) fsfy , DBO.FUN_ZY_SEEKPATFEEINFO(INPATIENT_ID,0,2) yjj from ZY_INPATIENT  where inpatient_id='" + inpatient_id.ToString() + "'";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                decimal fee = 0;
                decimal yjj = 0;
                yjj = Convert.ToDecimal(tb.Rows[0]["yjj"].ToString());
                fee = Convert.ToDecimal(tb.Rows[0]["fsfy"].ToString());//发生费用
                //Modify By Tany 2010-06-18 如果是医保病人，余额=预交金-总费用*费用比例
                if (tb.Rows[0]["DISCHARGETYPE"].ToString() == "1")
                {


                    if (cfg7186.Config.Trim() == "0")
                    {
                        //首先判断费用比例是不是小于1，如果等于1，则不需要计算
                        decimal bl = Convert.ToDecimal(Convertor.IsNull(database.GetDataResult("select b.yjj_bl from zy_inpatient a left join jc_yblx b on a.yblx=b.id where a.dischargetype=1 and a.inpatient_id='" + ClassStatic.Current_BinID + "'"), "1"));
                        //Modify By Tany 2010-08-07 比例=0的时候相当于不控制欠费
                        if (bl >= 0 && bl < 1)
                        {
                            _ye = yjj - (fee * bl);
                        }
                    }
                    else
                    {

                        #region  add by zouchihua 2014-3-10按照医保试算进行控制
                        string ybfy = @"select isnull(SUM(XJZF),0) fee from 
                                (
                                select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id='" + inpatient_id + @"'  order by YBJS_DATE desc
                                 union all
                                select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and DISCHARGE_BIT=0 and inpatient_id='" + inpatient_id + @"'
                                ) aa
                                ";
                        DataTable tbybfy = database.GetDataTable(ybfy);
                        if (tbybfy.Rows.Count > 0)
                        {
                            fee = decimal.Parse(tbybfy.Rows[0]["fee"].ToString());
                        }
                        _ye = yjj - (fee);
                        #endregion
                    }
                }
                else
                {
                    _ye = yjj - (fee);
                }
                if (_ye - qfye < 0)
                    kyfy = 0;//欠费的可以余额 
                else
                    kyfy = _ye - qfye;

            }
            return kyfy;
        }

        /// <summary>
        /// 得到该病人医嘱执行的最小余额
        /// </summary>
        public decimal GetPatMinExecYE(Guid _inpatientid, RelationalDatabase database)
        {
            decimal rtnYE = 0;
            SystemCfg cfg7204 = new SystemCfg(7204);
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
            if (cfg7204.Config == "1")
            {
                try
                {
                    //add by yaokx 2014-06-18 
                    string s = @"select * from ZY_INPATIENT_SUPPLY where INPATIENT_ID='" + _inpatientid + "'";
                    DataTable mydt = database.GetDataTable(s);
                    if (mydt != null && mydt.Rows.Count > 0)
                    {
                        //记账
                        if (mydt.Rows[0]["PATIENTTYPE"].ToString() == "1")
                        {
                            switch (mydt.Rows[0]["CHARGETYPE"].ToString())
                            {
                                //合同单位
                                case "0":
                                    string sqlht = @"select * from JC_HTDW where ID=" + mydt.Rows[0]["HTDW"].ToString() + "";
                                    DataTable mydt_ht = database.GetDataTable(sqlht);
                                    if (mydt_ht != null && mydt_ht.Rows.Count > 0)
                                    {
                                        rtnYE = rtnYE + (-1 * Convert.ToDecimal(Convertor.IsNull(mydt_ht.Rows[0]["maxmoney"], "0")));
                                    }
                                    break;
                                //职工担保
                                case "1":
                                //特殊担保
                                case "2":
                                    ZyInpatientServices zyInpatientServices = new ZyInpatientServices();
                                    decimal maxCredit = zyInpatientServices.GetMaxCreditOfInpatient(ClassStatic.Current_BinID);
                                    rtnYE = rtnYE + (-1 * maxCredit);
                                    // rtnYE = rtnYE + (-1 * Convert.ToDecimal(Convertor.IsNull(mydt.Rows[0]["NEWRANG_MONEY"], "0")));
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        rtnYE = rtnYE + (-1 * Convert.ToDecimal(Convertor.IsNull(mydt.Rows[0]["NEWRANG_MONEY"], "0")));
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex);
                }
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
        public DataTable ZYHS_YPFY_SELECT(int _tlfs, int _msg_type, long DeptLy, string WardId, Guid _inpatient_id, long _baby_id, long _execdept_id, bool Ls)
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

                //add by jchl
                sSql = string.Format("select YBLX,INPATIENT_BANO from VI_ZY_VINPATIENT_ALL where INPATIENT_ID='{0}' and BABY_ID='{1}'", _inpatientid, _babyid);
                DataTable dtPat = database.GetDataTable(sSql);

                string yblx = "";
                string lxtid = "";
                if (dtPat != null && dtPat.Rows.Count > 0)
                {
                    yblx = Convertor.IsNull(dtPat.Rows[0]["YBLX"], "0");
                    lxtid = Convertor.IsNull(dtPat.Rows[0]["INPATIENT_BANO"], "");
                }

                //add by jchl
                sSql = string.Format(@"select isnull(SUM(SDVALUE),0) as SDVALUE from ZY_FEE_SPECI 
                                        where INPATIENT_ID='{0}' and BABY_ID='{1}' and DELETE_BIT=0", _inpatientid, _babyid);
                decimal fee = decimal.Parse(database.GetDataResult(sSql).ToString().Trim());

                //医保病人住院费用小于1500
                if (yblx.Equals("1"))
                {
                    if (fee <= 1500)
                    {
                        if (MessageBox.Show("该医保病人住院费用小于1500,请走OA流程：医保办-医保病人住院费用小于1500元审批。是否继续打印出院通知单？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }

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
                feeTb.TableName = "tabFyhj";

                //获取药品相关信息
                string sql = string.Format(@"select  ITEM_NAME as ypmc,GG as ypgg,case when c.id is null then a.FREQUENCY else dbo.fun_getcfyf(c.id) end zxpc,
                                            convert(varchar,convert(decimal(18,2),SUM(b.NUM)))+ltrim(rtrim(b.unit)) as zl,SUM(b.ACVALUE) as zje,
                                            a.ORDER_USAGE yf,a.NUM yl,a.UNIT dw,a.order_doc,f.HWMC hwh
                                             from ZY_ORDERRECORD a inner join 
                                            ZY_FEE_SPECI b on a.ORDER_ID  = b.ORDER_ID 
                                            inner join JC_FREQUENCY c on upper(a.FREQUENCY)=upper(c.name)
                                            left join YP_YPCJD d on a.ITEM_CODE=d.CJID
                                            left join YP_HWSZ f on b.EXECDEPT_ID=f.DEPTID and d.GGID=f.GGID 
                                            where b.TLFS =3 and a.INPATIENT_ID = '{0}' 
                                            group by ITEM_NAME,GG,FREQUENCY,b.unit,c.memo,a.ORDER_USAGE ,a.NUM ,a.UNIT,c.id,a.order_doc,f.HWMC ", _inpatientid);
                DataTable ypTb = database.GetDataTable(sql);

                //add by zhujh 2017-02-28
                ThoughtWorks.QRCode.Codec.QRCodeEncoder qrCodeEncoder = new ThoughtWorks.QRCode.Codec.QRCodeEncoder();
                //生成二维码图片
                Bitmap bit = qrCodeEncoder.Encode(patTb.Rows[0]["inpatient_no"].ToString().Trim());
                string strName = DateTime.Now.ToString("yyyyMMddHHmmss") + patTb.Rows[0]["inpatient_no"].ToString().Trim();
                string strPathName = Constant.ApplicationDirectory + "\\report\\" + strName + ".bmp";
                //保存在本地，rpt读取本地图片转换成byte[]可以显示，否则rpt显示不了二维码
                bit.Save(strPathName);

                FileStream fs = File.OpenRead(strPathName);
                byte[] content = new byte[fs.Length];
                fs.Read(content, 0, content.Length);
                fs.Close();
                try
                {
                    //删除保存在本地的二维码
                    File.Delete(strPathName);
                }
                catch { }

                //Modify By Tany 2015-12-3 增加入参
                TheReportDateSet rds = new TheReportDateSet();
                DataTable newypTb = rds.tabcytzdmx;
                for (int i = 0; i < ypTb.Rows.Count; i++)
                {
                    DataRow dr = newypTb.NewRow();
                    dr["ypmc"] = ypTb.Rows[i]["ypmc"];
                    dr["ypgg"] = ypTb.Rows[i]["ypgg"];
                    dr["zxpc"] = ypTb.Rows[i]["zxpc"];
                    dr["zl"] = ypTb.Rows[i]["zl"];
                    dr["zje"] = ypTb.Rows[i]["zje"];
                    dr["yf"] = ypTb.Rows[i]["yf"];
                    dr["yl"] = ypTb.Rows[i]["yl"];
                    dr["dw"] = ypTb.Rows[i]["dw"];
                    dr["image"] = GetImageByte((Convertor.IsNull(ypTb.Rows[i]["order_doc"], "0")));
                    //dr["image"] = GetImageByte("4870");
                    dr["ewmimage"] = content;//add by zhujh 2017-02-28
                    dr["hwh"] = ypTb.Rows[i]["hwh"];//add  by  chenli 2017-08-17
                    newypTb.Rows.Add(dr);
                }
                //Add by zhujh 2017-02-28
                if (newypTb.Rows.Count == 0)
                {
                    DataRow dr = newypTb.NewRow();
                    dr["ypmc"] = "";
                    dr["ypgg"] = "";
                    dr["zxpc"] = "";
                    dr["zl"] = "";
                    dr["zje"] = "";
                    dr["yf"] = "";
                    dr["yl"] = "";
                    dr["dw"] = "";
                    dr["image"] = new byte[0];
                    //dr["image"] = GetImageByte("4870");
                    dr["ewmimage"] = content;//add by zhujh 2017-02-28
                    dr["hwh"] = "";//add  by  chenli 2017-08-17
                    newypTb.Rows.Add(dr);
                }

                DataTable dsTb = newypTb.Copy();
                dsTb.TableName = "tabcytzdmx";

                DataSet ds = new DataSet();
                ds.Tables.AddRange(new DataTable[] { feeTb, dsTb });

                //获取病人性别 年龄
                sql = string.Format(@"select 
	            isnull(a.DRUGSTORE_ID,'-1') as DRUGSTORE_ID,
                case when  sex = '1' then '男' when sex = '2' then '女' else '其它' end sex ,
                cast(CAST(
                cast(datepart(yyyy,GETDATE()) as numeric(10,4)) - cast(datepart(yyyy,BIRTHDAY) as numeric(10,4))  +
                (cast(datepart(dy,GETDATE()) as numeric(10,4)) - cast(datepart(dy,BIRTHDAY) as numeric(10,4)) )/365 as INT) as varchar)+'岁' as BIRTHDAY 
                from zy_inpatient t
                left join JC_DEPT_DRUGSTORE a on t.DEPT_ID=a.DEPT_ID
                where INPATIENT_ID = '{0}'
	            and DRUGSTORE_ID in (359,399,142,779)", _inpatientid);
                DataTable dt = database.GetDataTable(sql);
                string dbz = "";
                string sql_dbz = string.Format(@"select  a.bzmc,b.bzmc as bzmc1  from  zy_inpatient_dbz a left join jc_dbz b  on a.bzbm=b.ssbm where inpatient_id='{0}'", _inpatientid);
                DataTable dt_dbz = database.GetDataTable(sql_dbz);
                if (dt_dbz.Rows.Count > 0)
                {
                    dbz =dt_dbz.Rows[0]["bzmc1"].ToString()+"【"+dt_dbz.Rows[0]["bzmc"].ToString()+"】";
                }
                //打印数据
                FrmReportView frmRptView = null;
                string _reportName = "";
                ParameterEx[] _parameters = new ParameterEx[13];

                _reportName = "ZYHS_出院通知单.rpt";

                _parameters[0].Text = "病人";
                _parameters[0].Value = patTb.Rows[0]["name"].ToString().Trim();
                _parameters[1].Text = "住院号";
                _parameters[1].Value = patTb.Rows[0]["inpatient_no"].ToString().Trim().Remove(0, 2);
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
                _parameters[8].Text = "性别";
                _parameters[8].Value = dt.Rows[0]["sex"] != null && dt.Rows[0]["sex"] != DBNull.Value ? dt.Rows[0]["sex"].ToString().Trim() : "0";
                _parameters[9].Text = "年龄";
                _parameters[9].Value = dt.Rows[0]["BIRTHDAY"].ToString().Trim();
                _parameters[10].Text = "领药科室";
                _parameters[10].Value = dt.Rows[0]["DRUGSTORE_ID"].ToString().Trim();
                _parameters[11].Text = "ID";
                _parameters[11].Value = lxtid;
                _parameters[12].Text = "结算病种";
                _parameters[12].Value = dbz;
                frmRptView = new FrmReportView(ds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);

                frmRptView.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// 打印出院通知单(加货位号)
        /// </summary>
        /// <param name="_inpatientid"></param>
        /// <param name="_babyid"></param>
        public void PrintOutNotice_hwh(Guid _inpatientid, int _babyid)
        {
            try
            {
                //Add by Tany 2009-12-22
                string sSql = "";

                //add by jchl
                sSql = string.Format("select YBLX,INPATIENT_BANO from VI_ZY_VINPATIENT_ALL where INPATIENT_ID='{0}' and BABY_ID='{1}'", _inpatientid, _babyid);
                DataTable dtPat = database.GetDataTable(sSql);

                string yblx = "";
                string lxtid = "";
                if (dtPat != null && dtPat.Rows.Count > 0)
                {
                    yblx = Convertor.IsNull(dtPat.Rows[0]["YBLX"], "0");
                    lxtid = Convertor.IsNull(dtPat.Rows[0]["INPATIENT_BANO"], "");
                }

                //add by jchl
                sSql = string.Format(@"select isnull(SUM(SDVALUE),0) as SDVALUE from ZY_FEE_SPECI 
                                        where INPATIENT_ID='{0}' and BABY_ID='{1}' and DELETE_BIT=0", _inpatientid, _babyid);
                decimal fee = decimal.Parse(database.GetDataResult(sSql).ToString().Trim());

                //医保病人住院费用小于1500
                if (yblx.Equals("1"))
                {
                    if (fee <= 1500)
                    {
                        if (MessageBox.Show("该医保病人住院费用小于1500,请走OA流程：医保办-医保病人住院费用小于1500元审批。是否继续打印出院通知单？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }

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
                feeTb.TableName = "tabFyhj";

                //获取药品相关信息
                string sql = string.Format(@"select  ITEM_NAME as ypmc,GG as ypgg,case when c.id is null then a.FREQUENCY else dbo.fun_getcfyf(c.id) end zxpc,
                            convert(varchar,convert(decimal(18,2),SUM(b.NUM)))+ltrim(rtrim(b.unit)) as zl,SUM(b.ACVALUE) as zje,
                            a.ORDER_USAGE yf,a.NUM yl,a.UNIT dw,a.order_doc,d.SHH
                            from ZY_ORDERRECORD a inner join 
                            ZY_FEE_SPECI b on a.ORDER_ID  = b.ORDER_ID 
                            inner join JC_FREQUENCY c on upper(a.FREQUENCY)=upper(c.name)
                            left  join yp_ypcjd d on a.item_code=d.cjid 
                            where b.TLFS =3 and a.INPATIENT_ID = '{0}'
                            group by ITEM_NAME,GG,FREQUENCY,b.unit,c.memo,a.ORDER_USAGE ,a.NUM ,a.UNIT,c.id,a.order_doc", _inpatientid);
                DataTable ypTb = database.GetDataTable(sql);

                //add by zhujh 2017-02-28
                ThoughtWorks.QRCode.Codec.QRCodeEncoder qrCodeEncoder = new ThoughtWorks.QRCode.Codec.QRCodeEncoder();
                //生成二维码图片
                Bitmap bit = qrCodeEncoder.Encode(patTb.Rows[0]["inpatient_no"].ToString().Trim());
                string strName = DateTime.Now.ToString("yyyyMMddHHmmss") + patTb.Rows[0]["inpatient_no"].ToString().Trim();
                string strPathName = Constant.ApplicationDirectory + "\\report\\" + strName + ".bmp";
                //保存在本地，rpt读取本地图片转换成byte[]可以显示，否则rpt显示不了二维码
                bit.Save(strPathName);

                FileStream fs = File.OpenRead(strPathName);
                byte[] content = new byte[fs.Length];
                fs.Read(content, 0, content.Length);
                fs.Close();
                try
                {
                    //删除保存在本地的二维码
                    File.Delete(strPathName);
                }
                catch { }

                //Modify By Tany 2015-12-3 增加入参
                TheReportDateSet rds = new TheReportDateSet();
                DataTable newypTb = rds.tabcytzdmx;
                for (int i = 0; i < ypTb.Rows.Count; i++)
                {
                    DataRow dr = newypTb.NewRow();
                    dr["ypmc"] = ypTb.Rows[i]["ypmc"];
                    dr["hwh"] = ypTb.Rows[i]["SHH"];//add by  chenli  2017-08-15
                    dr["ypgg"] = ypTb.Rows[i]["ypgg"];
                    dr["zxpc"] = ypTb.Rows[i]["zxpc"];
                    dr["zl"] = ypTb.Rows[i]["zl"];
                    dr["zje"] = ypTb.Rows[i]["zje"];
                    dr["yf"] = ypTb.Rows[i]["yf"];
                    dr["yl"] = ypTb.Rows[i]["yl"];
                    dr["dw"] = ypTb.Rows[i]["dw"];
                    dr["image"] = GetImageByte((Convertor.IsNull(ypTb.Rows[i]["order_doc"], "0")));
                    //dr["image"] = GetImageByte("4870");
                    dr["ewmimage"] = content;//add by zhujh 2017-02-28
                    newypTb.Rows.Add(dr);
                }
                //Add by zhujh 2017-02-28
                if (newypTb.Rows.Count == 0)
                {
                    DataRow dr = newypTb.NewRow();
                    dr["ypmc"] = "";
                    dr["SHH"] = "";//add by  chenli  2017-08-15(货位号)
                    dr["ypgg"] = "";
                    dr["zxpc"] = "";
                    dr["zl"] = "";
                    dr["zje"] = "";
                    dr["yf"] = "";
                    dr["yl"] = "";
                    dr["dw"] = "";
                    dr["image"] = new byte[0];
                    //dr["image"] = GetImageByte("4870");
                    dr["ewmimage"] = content;//add by zhujh 2017-02-28
                    newypTb.Rows.Add(dr);
                }

                DataTable dsTb = newypTb.Copy();
                dsTb.TableName = "tabcytzdmx";

                DataSet ds = new DataSet();
                ds.Tables.AddRange(new DataTable[] { feeTb, dsTb });

                //获取病人性别 年龄
                sql = string.Format(@"select 
	            isnull(a.DRUGSTORE_ID,'-1') as DRUGSTORE_ID,
                case when  sex = '1' then '男' when sex = '2' then '女' else '其它' end sex ,
                cast(CAST(
                cast(datepart(yyyy,GETDATE()) as numeric(10,4)) - cast(datepart(yyyy,BIRTHDAY) as numeric(10,4))  +
                (cast(datepart(dy,GETDATE()) as numeric(10,4)) - cast(datepart(dy,BIRTHDAY) as numeric(10,4)) )/365 as INT) as varchar)+'岁' as BIRTHDAY 
                from zy_inpatient t
                left join JC_DEPT_DRUGSTORE a on t.DEPT_ID=a.DEPT_ID
                where INPATIENT_ID = '{0}'
	            and DRUGSTORE_ID in (359,399,142,779)", _inpatientid);
                DataTable dt = database.GetDataTable(sql);

                //打印数据
                FrmReportView frmRptView = null;
                string _reportName = "";
                ParameterEx[] _parameters = new ParameterEx[12];

                _reportName = "ZYHS_出院通知单.rpt";

                _parameters[0].Text = "病人";
                _parameters[0].Value = patTb.Rows[0]["name"].ToString().Trim();
                _parameters[1].Text = "住院号";
                _parameters[1].Value = patTb.Rows[0]["inpatient_no"].ToString().Trim().Remove(0, 2);
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
                _parameters[8].Text = "性别";
                _parameters[8].Value = dt.Rows[0]["sex"] != null && dt.Rows[0]["sex"] != DBNull.Value ? dt.Rows[0]["sex"].ToString().Trim() : "0";
                _parameters[9].Text = "年龄";
                _parameters[9].Value = dt.Rows[0]["BIRTHDAY"].ToString().Trim();
                _parameters[10].Text = "领药科室";
                _parameters[10].Value = dt.Rows[0]["DRUGSTORE_ID"].ToString().Trim();
                _parameters[11].Text = "ID";
                _parameters[11].Value = lxtid;
                frmRptView = new FrmReportView(ds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);

                frmRptView.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        /// <summary>
        /// Convert Image to Byte[] Add by zhujh 2017-02-27
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public byte[] ImageToBytes(Image image)
        {
            //将Image转换成流数据，并保存为byte[] 
            MemoryStream mstream = new MemoryStream();
            image.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new byte[mstream.Length];
            mstream.Read(byData, 0, byData.Length);
            mstream.Close();
            return byData;
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
        public bool OprateXnkc(Guid inpatient_id, long baby_id, Guid Order_id, int Group_id, int type)
        {
            string sql = "select * from zy_orderrecord where inpatient_id='" + inpatient_id + "'and  baby_id=" + baby_id + " and  GROUP_ID=" + Group_id + "  and xmly=1 ";
            DataTable Tb = database.GetDataTable(sql);
            int i = 0;
            decimal jl = 0;
            database.BeginTransaction();
            try
            {
                for (i = 0; i < Tb.Rows.Count; i++)
                {
                    if (Tb.Rows[i]["xmly"].ToString() == "1")
                    {
                        DataTable myTb = new DataTable();
                        string _dwlx = "1";
                        //if (Tb.Rows[i]["MNGTYPE"].ToString().Trim() == "1" || Tb.Rows[i]["MNGTYPE"].ToString().Trim() == "5")
                        //    _dwlx = Tb.Rows[i]["jldwlx"].ToString();
                        // if (Tb.Rows[i]["MNGTYPE"].ToString().Trim() == "0" )
                        //    _dwlx = Tb.Rows[i]["dwlx"].ToString();

                        _dwlx = Tb.Rows[i]["dwlx"].ToString();
                        string _num = "0";
                        if (Tb.Rows[i]["mngtype"].ToString().Trim() == "1" || Tb.Rows[i]["mngtype"].ToString().Trim() == "5")//临时医嘱用总数量
                        {
                            if (Tb.Rows[i]["ts"].ToString().Trim() == "")
                                _num = Tb.Rows[i]["num"].ToString();
                            else
                                _num = Tb.Rows[i]["zsl"].ToString();
                            if (decimal.Parse(_num) == 0)
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
                        int cs = 1;//频次

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
                        string rtnStr = "";
                        rtnStr = parameters[5].Value.ToString().Trim();
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

        public bool CzJxnkc(Guid feeid, decimal czcs, decimal sl)
        {
            decimal num_cz = Convert.ToDecimal(czcs.ToString()) * sl;
            string sql = "select xmid as cjid,EXECDEPT_ID,UNITRATE,num from zy_fee_speci where id='" + feeid + "'";
            string _cjid = "";
            string _execdeptID = "";
            string _dwbl = "";
            try
            {
                DataTable tb = database.GetDataTable(sql);
                if (tb == null || tb.Rows.Count == 0)
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
                if (outcode == "-1" || rtnStr != "保存成功")
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
        public void SendZc(DataTable tb, string user_id, string user_name, bool IsupdateZckc, Int64 zxksid)
        {
            //药品医嘱是否直接记帐
            SystemCfg cfg7031 = new SystemCfg(7031);
            string[] GroupbyField1 ={ "cjid", "dept_ly", "ZXDW", "tlfl", "单价", "DWBL" };
            string[] ComputeField1 ={ "数量", "金额", "ypsl" };
            string[] CField1 ={ "sum", "sum", "sum" };
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
                        string sql = "";
                        if (cfg7031.Config.Trim() == "是")
                            sql = "update ZY_FEE_SPECI set TLFS=9  where ID='" + tb.Rows[i]["zy_id"].ToString() + "'";
                        else
                            sql = "update ZY_FEE_SPECI set TLFS=9 ,CHARGE_BIT=1,CHARGE_DATE=(case  when CHARGE_BIT=0 then getdate() else CHARGE_DATE end),CHARGE_USER=" + user_id + " where ID='" + tb.Rows[i]["zy_id"].ToString() + "'   ";
                        database.DoCommand(sql);
                    }

                }
                //是否更行暂存库存,更暂存基数和库存量
                if (IsupdateZckc)
                {
                    string[] updatesql = new string[tbflcjid.Rows.Count];
                    string insertdjxx = "";
                    for (int j = 0; j < tbflcjid.Rows.Count; j++)
                    {
                        //如果没有就插入记录
                        string sql = " select * from Zy_ZcyKcmx (nolock) where bscbz=0 and  cjid=" + tbflcjid.Rows[j]["cjid"].ToString() +
                                        " and  ksid=" + tbflcjid.Rows[j]["dept_ly"].ToString()
                                        + " and  yfksid=" + zxksid;
                        DataTable tbKcmx = database.GetDataTable(sql);
                        //如果没有暂存管理，就不进行插入操作
                        if (tbKcmx.Rows.Count == 0)
                        {

                            string insert = @" insert into Zy_ZcyKcmx(id, cjid, ggid, kcl, dj, zxdw, dwbl, zcjs, ksid, yfksid, book_date, bscbz)
                                                       values(NEWID()," + tbflcjid.Rows[j]["cjid"].ToString() + ",null,0," + tbflcjid.Rows[j]["单价"].ToString()
                                                       + "," + tbflcjid.Rows[j]["zxdw"].ToString() + "," + tbflcjid.Rows[j]["dwbl"].ToString() + ",9999," + tbflcjid.Rows[j]["dept_ly"].ToString()
                                                       + "," + zxksid + ",getdate(),0)";
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
                                                                   + @"," + (decimal.Parse(tbflcjid.Rows[j]["金额"].ToString()) / decimal.Parse(tbflcjid.Rows[j]["ypsl"].ToString()))
                                                                   + @",1," + FrmMdiMain.CurrentUser.EmployeeId + @",getdate()," + tbflcjid.Rows[j]["DWBL"].ToString() + @""
                                                                   + @")"
                                                               );
                        database.DoCommand(insertdjxx);
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
        public DataTable Gxypsl(DataTable tb, int xsl, string cjid, ref int ReturnValue, ref decimal je)
        {
            int i = 0;
            int count = 0;
            je = 0;
            for (i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["cjid"].ToString() == cjid.ToString())
                {
                    if (count + Convert.ToInt32(tb.Rows[i]["数量"].ToString()) <= xsl)
                    {
                        count = count + Convert.ToInt32(tb.Rows[i]["数量"].ToString());
                        je += decimal.Parse(tb.Rows[i]["金额"].ToString());
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
        public string GetExectime(string exectime, string times, DateTime dt, int type)
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
        public int GetFirsttimes(string pl, DateTime dt)
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
        public int GetLasttimes(string pl, DateTime dt)
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

        private DataTable GetZY_zcgl(int ksid, int yfksid)
        {
            string sql = "select * from  Zy_ZcyKcmx  where bscbz=0 and ksid=" + ksid + " and yfksid=" + yfksid;
            return database.GetDataTable(sql);
        }
        /// <summary>
        /// 获取发送到暂存药品的表和需要发送到药房的表
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="deptly"></param>
        /// <param name="yfksid"></param>
        /// <returns></returns>
        public DataSet GetZcAndYFfs_Tb(DataTable tb, int deptly, int yfksid)
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
                DataRow[] _addrow = tb.Select("cjid=" + tbflcjid.Rows[i]["cjid"].ToString());
                //先看这个有没有暂存基数管理
                DataRow[] row = Zy_ZcyKcmx.Select("cjid=" + tbflcjid.Rows[i]["cjid"].ToString());
                if (row.Length == 0)
                {

                    for (int z = 0; z < _addrow.Length; z++)
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
                    for (int j = 0; j < _addrow.Length; j++)
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
                //入院与出院相同情况，是不需要冲正
                string in_datestr = "select * from vi_zy_vinpatient_all where   inpatient_id='" + inpatientID.ToString() + "'  and CONVERT(varchar,IN_DATE,23)=CONVERT(varchar,OUT_DATE,23) ";//得到入院日期
                DataTable dt = new DataTable();
                dt = FrmMdiMain.Database.GetDataTable(in_datestr);
                if (dt.Rows.Count > 0)
                    return;
                string outflag = Convert.ToString(database.GetDataResult("select flag from vi_zy_vinpatient_all where inpatient_id='" + inpatientID.ToString() + "'and BABY_ID=" + BabyID + " and OUT_DATE>='" + dTime.ToString("yyyy-MM-dd 00:00:00.000") + "' and  OUT_DATE<='" + dTime.ToString("yyyy-MM-dd 23:59:59.999") + "'"));
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

        private DataTable groupby(DataTable tbtb)
        {
            string[] GroupbyField1 ={ "cjid", "dept_ly", "ZXDW", "tlfl", "单价", "dwbl" };
            string[] ComputeField1 ={ "数量", "金额", "ypsl" };
            string[] CField1 ={ "sum", "sum", "sum" };
            int j = 0;
            DataTable tbcompute = new DataTable();
            tbcompute.Columns.Add("cjid", typeof(int));
            tbcompute.Columns.Add("dept_ly", typeof(int));
            tbcompute.Columns.Add("ZXDW", typeof(int));
            tbcompute.Columns.Add("tlfl", typeof(string));
            tbcompute.Columns.Add("单价", typeof(decimal));
            tbcompute.Columns.Add("dwbl", typeof(int));
            tbcompute.Columns.Add("数量", typeof(decimal));
            tbcompute.Columns.Add("金额", typeof(decimal));
            tbcompute.Columns.Add("ypsl", typeof(decimal));
            tbcompute.Columns.Add("UNITRATE", typeof(int));
            DataTable tb = tbtb.Copy();
            for (int i = 0; 0 < tb.Rows.Count; i++)
            {
                string cjid = tb.Rows[0]["cjid"].ToString();
                string dept_ly = tb.Rows[0]["dept_ly"].ToString();
                string ZXDW = tb.Rows[0]["ZXDW"].ToString();
                string tlfl = tb.Rows[0]["tlfl"].ToString();
                string 单价 = tb.Rows[0]["单价"].ToString();
                string dwbl = tb.Rows[0]["dwbl"].ToString();
                string UNITRATE = tb.Rows[0]["UNITRATE"].ToString();
                DataRow insertrow = tbcompute.NewRow();
                insertrow["cjid"] = tb.Rows[0]["cjid"];
                insertrow["dept_ly"] = tb.Rows[0]["dept_ly"];
                insertrow["ZXDW"] = tb.Rows[0]["ZXDW"];
                insertrow["tlfl"] = tb.Rows[0]["tlfl"];
                insertrow["单价"] = tb.Rows[0]["单价"];
                insertrow["dwbl"] = tb.Rows[0]["dwbl"];
                insertrow["UNITRATE"] = tb.Rows[0]["UNITRATE"];
                tb.DefaultView.RowFilter = "cjid=" + cjid + " and dept_ly=" + dept_ly + " and  ZXDW=" + ZXDW + " and  tlfl='" + tlfl + "' and 单价=" + 单价 + " and dwbl=" + dwbl + "   and UNITRATE=" + UNITRATE + "";
                DataTable temp = tb.DefaultView.ToTable();

                insertrow["数量"] = decimal.Parse(temp.Compute("sum(数量)", "").ToString());
                // writelog("获得数量");
                insertrow["金额"] = decimal.Parse(temp.Compute("sum(金额)", "").ToString());
                // writelog("获得金额");
                insertrow["ypsl"] = decimal.Parse(temp.Compute("sum(ypsl)", "").ToString());
                tbcompute.Rows.Add(insertrow);

                DataRow[] row = tb.Select("cjid=" + cjid + " and dept_ly=" + dept_ly + " and  ZXDW=" + ZXDW + " and  tlfl='" + tlfl + "' and 单价=" + 单价 + " and dwbl=" + dwbl + " and UNITRATE=" + UNITRATE + "");

                for (int w = 0; w < row.Length; w++)
                {
                    tb.Rows.Remove(row[w]);
                    j++;
                }



            }
            tbcompute.TableName = "tbcompute";
            tbcompute.WriteXml("tbcompute.xml");
            return tbcompute;
        }
        /// <summary>
        /// 住院销号，同步电子病历
        /// </summary>
        /// <param name="inpateint_id"></param>
        public static void ZyXh_tbdzbl(Guid inpateint_id)
        {
            SystemCfg cfg6104 = new SystemCfg(6104);
            if (cfg6104.Config.Trim() == "0")
                return;
            //需要增加参数控制
            try
            {
                string isuseEmr = "1";
                string sql = "exec sp_EmrSynchroCancelNoForInpatient " + isuseEmr + ",'" + inpateint_id + "'";
                FrmMdiMain.Database.DoCommand(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("销号同步电子病历数据是出错:" + ex.Message);
            }
        }
        /// <summary>
        /// 入院登记时调用同步
        /// </summary>
        /// <param name="inpateint_id"></param>
        public static void rydj_tbdzbl(Guid inpateint_id, int in_dept)
        {
            SystemCfg cfg6104 = new SystemCfg(6104);
            if (cfg6104.Config.Trim() == "0")
                return;
            string isuseEmr = "1";
            //需要增加参数控制
            try
            {
                string sql = "exec sp_EmrSynchroInpDoctorForInpatient " + isuseEmr + ",'" + inpateint_id + "',0," + in_dept + "," + in_dept + ",1";
                FrmMdiMain.Database.DoCommand(sql);
                sql = "exec sp_EMRRemindTimeLimitDetialForInpatientId " + isuseEmr + "," + in_dept + ",'" + inpateint_id + "'";
                FrmMdiMain.Database.DoCommand(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("新入院同步电子病历数据是出错:" + ex.Message);
            }
        }
        /// <summary>
        /// 病人转科时同步
        /// </summary>
        /// <param name="inpateint_id"></param>
        /// <param name="baby_flag"></param>
        /// <param name="s_deptid"></param>
        /// <param name="d_deptid"></param>
        public static void brzk_tbdzbl(Guid inpateint_id, int baby_flag, int s_deptid, int d_deptid)
        {
            SystemCfg cfg6104 = new SystemCfg(6104);
            if (cfg6104.Config.Trim() == "0")
                return;
            //       @isuseEmr TINYINT ,
            //@inpatient_id VARCHAR(40) ,--住院标识
            //@Baby_flag INT ,--婴儿标识
            //@before_deptid BIGINT ,--转科前科室，如果是新入院的，并且不是更改的记录，@before_deptid与@after_deptid一致
            //@after_deptid BIGINT ,--转科后科室
            //@is_new TINYINT 
            try
            {
                string isuseEmr = "1";
                string sql = "exec sp_EmrSynchroInpDoctorForInpatient " + isuseEmr + ",'" + inpateint_id + "'," + baby_flag + "," + s_deptid + "," + d_deptid + ",0";
                FrmMdiMain.Database.DoCommand(sql);

            }
            catch (Exception ex)
            {
                throw new Exception("转科同步电子病历数据是出错:" + ex.Message);
            }
        }
        public static void brzk_tbdzbl(Guid inpateint_id, int baby_flag, int s_deptid, int d_deptid, int isuseEmr)
        {
            SystemCfg cfg6104 = new SystemCfg(6104);
            if (cfg6104.Config.Trim() == "0")
                return;
            //       @isuseEmr TINYINT ,
            //@inpatient_id VARCHAR(40) ,--住院标识
            //@Baby_flag INT ,--婴儿标识
            //@before_deptid BIGINT ,--转科前科室，如果是新入院的，并且不是更改的记录，@before_deptid与@after_deptid一致
            //@after_deptid BIGINT ,--转科后科室
            //@is_new TINYINT 
            try
            {
                // string isuseEmr = "1";
                string sql = "exec sp_EmrSynchroInpDoctorForInpatient " + isuseEmr + ",'" + inpateint_id + "'," + baby_flag + "," + s_deptid + "," + d_deptid + "," + isuseEmr;
                FrmMdiMain.Database.DoCommand(sql);

            }
            catch (Exception ex)
            {
                throw new Exception("转科同步电子病历数据是出错:" + ex.Message);
            }
        }

        private byte[] GetImageByte(string strEmployeeId)
        {
            string ss = "select sign from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID=" + strEmployeeId + "";
            DataTable tb = FrmMdiMain.Database.GetDataTable(ss);
            if (tb == null || tb.Rows.Count == 0 || tb.Rows[0]["sign"].GetType().ToString() == "System.DBNull")
                return null;
            else
                return ((byte[])tb.Rows[0]["sign"]);
        }
    }
}















