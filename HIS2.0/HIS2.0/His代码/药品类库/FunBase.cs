using System;
using TrasenClasses.GeneralControls;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace YpClass
{
    /// <summary>
    /// 有关药品模块界面处理的一些方法
    /// </summary>
    public class FunBase
    {
        public FunBase()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 初始化mydataGrid网格
        /// </summary>
        /// <param name="mydataGrid"></param>
        /// <param name="HeaderText"></param>
        /// <param name="ColumnMappingName"></param>
        /// <param name="BoolColumn"></param>
        /// <param name="GrdWidth"></param>
        /// <param name="AllowSorting"></param>
        public static void csMydataGrid(myDataGrid.myDataGrid mydataGrid, string[] HeaderText, string[] ColumnMappingName, bool[] BoolColumn, int[] GrdWidth, bool AllowSorting)
        {
            mydataGrid.TableStyles[0].MappingName = "dataGridTableStyle1";
            mydataGrid.TableStyles[0].MappingName = "Tb";
            mydataGrid.TableStyles[0].AllowSorting = AllowSorting; //不允许排序


            for (int i = 0; i <= ColumnMappingName.Length - 1; i++)
            {
                if (BoolColumn[i] == false)
                {

                    System.Windows.Forms.DataGridTextBoxColumn aColumnTextColumn;
                    aColumnTextColumn = new DataGridTextBoxColumn();
                    mydataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                }
                else
                {
                    System.Windows.Forms.DataGridBoolColumn aColumnBoolColumn;
                    aColumnBoolColumn = new DataGridBoolColumn();
                    aColumnBoolColumn.AllowNull = false;
                    aColumnBoolColumn.NullValue = ((short)(0));
                    aColumnBoolColumn.FalseValue = ((short)(0));
                    aColumnBoolColumn.TrueValue = ((short)(1));
                    mydataGrid.TableStyles[0].GridColumnStyles.Add(aColumnBoolColumn);
                }
                mydataGrid.TableStyles[0].GridColumnStyles[i].MappingName = ColumnMappingName[i].ToString();
                mydataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = HeaderText[i].ToString().Trim();
                mydataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
                mydataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
            }

        }

        /// <summary>
        /// 初始化mydataGrid网格
        /// </summary>
        /// <param name="myDataGrid"></param>
        /// <param name="e"></param>
        /// <param name="TableName"></param>
        public static void CsDataGrid(myDataGrid.myDataGrid myDataGrid, System.Windows.Forms.DataGridTableStyle e, string TableName)
        {
            DataTable myTb = new DataTable();
            myTb.TableName = TableName;
            for (int i = 0; i <= e.GridColumnStyles.Count - 1; i++)
            {
                if (e.GridColumnStyles[i].GetType().ToString() == "System.Windows.Forms.DataGridBoolColumn")
                    myTb.Columns.Add(e.GridColumnStyles[i].HeaderText, Type.GetType("System.Int16"));
                else
                    myTb.Columns.Add(e.GridColumnStyles[i].HeaderText, Type.GetType("System.String"));

                e.GridColumnStyles[i].MappingName = e.GridColumnStyles[i].HeaderText;
                e.GridColumnStyles[i].NullText = "";
            }
            myDataGrid.DataSource = myTb;
            e.MappingName = TableName;
        }


        /// <summary>
        /// 初始化mydataGrid网格
        /// </summary>
        /// <param name="mydataGrid"></param>
        /// <param name="gridcolumn"></param>

        public static void myGridSelect(myDataGrid.myDataGrid mydataGrid, System.Windows.Forms.GridColumnStylesCollection gridcolumn)
        {
            for (int i = 0; i <= gridcolumn.Count - 1; i++)
            {
                if (gridcolumn[i].GetType().ToString() == "System.Windows.Forms.DataGridTextBoxColumn")
                {
                    DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)gridcolumn[i];

                    txtCol.TextBox.Parent.Controls.Remove(txtCol.TextBox);
                }
            }
        }

        public static void myGridSelect(TrasenClasses.GeneralControls.ButtonDataGridEx mydataGrid, System.Windows.Forms.GridColumnStylesCollection gridcolumn)
        {
            for (int i = 0; i <= gridcolumn.Count - 1; i++)
            {
                if (gridcolumn[i].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn")
                {
                    DataGridEnableTextBoxColumn txtCol = (DataGridEnableTextBoxColumn)gridcolumn[i];
                    if (txtCol.TextBox.Parent != null)
                        txtCol.TextBox.Parent.Controls.Remove(txtCol.TextBox);
                }
            }
        }


        public static void AddRowtNo(DataTable tb)
        {
            if (tb.Columns.Contains("序号") == true)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i]["序号"] = i + 1;
            }
        }



        public static DataTable GroupbyDataTable(DataTable tb, string[] GroupbyField, string[] ComputeField, string[] CField, DataTable hz)
        {


            //生成汇总空表
            if (hz == null)
            {
                hz = new DataTable();
                for (int i = 0; i <= GroupbyField.Length - 1; i++)
                    hz.Columns.Add(GroupbyField[i]);
                for (int i = 0; i <= ComputeField.Length - 1; i++)
                    hz.Columns.Add(ComputeField[i]);
            }

            if (tb.Rows.Count == 0) return hz;
            //生成查询条件
            string Sel = "";
            try
            {
                for (int i = 0; i <= GroupbyField.Length - 1; i++)
                {
                    if (Sel == "")
                    {
                        if (tb.Rows[0][GroupbyField[i].Trim()] is DBNull) //ncq 20140508 添加空值判断
                        {
                            Sel = GroupbyField[i] + " is null ";
                        }
                        else
                        {
                            Sel = GroupbyField[i] + "='" + tb.Rows[0][GroupbyField[i].Trim()] + "'";
                        }
                    }
                    else
                    {
                        if (tb.Rows[0][GroupbyField[i].Trim()] is DBNull)
                        {
                            Sel = Sel + " and " + GroupbyField[i] + " is null ";
                        }
                        else
                        {
                            Sel = Sel + " and " + GroupbyField[i] + "='" + tb.Rows[0][GroupbyField[i].Trim()] + "'";
                        }
                    }
                }


                DataRow[] Selrow = tb.Select(Sel);

                if (Selrow.Length == 0) throw new Exception("GroupbyDataTable发生异常");

                //在汇总表添加一条记录,该记录的值等于第一行的记录值
                DataRow hzNewRow = hz.NewRow();
                for (int i = 0; i <= hz.Columns.Count - 1; i++)
                    hzNewRow[hz.Columns[i].ColumnName] = tb.Rows[0][hz.Columns[i].ColumnName];

                //记算
                for (int i = 0; i <= ComputeField.Length - 1; i++)
                {
                    string compute = CField[i] + "(" + ComputeField[i] + ")";
                    decimal nvalue = Convert.IsDBNull(tb.Compute(compute, Sel)) == true ? 0 : Convert.ToDecimal(tb.Compute(compute, Sel));

                    hzNewRow[ComputeField[i]] = nvalue;
                }
                hz.Rows.Add(hzNewRow);


                //移除计算过的行
                if (Selrow.Length != 0)
                {
                    for (int i = 0; i <= Selrow.Length - 1; i++)
                        tb.Rows.Remove(Selrow[i]);
                }
                if (tb.Rows.Count != 0)
                    GroupbyDataTable(tb, GroupbyField, ComputeField, CField, hz);

            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message+tb.Rows[0][0].ToString() + "    a" + tb.Rows[0]["货号"].ToString() + "   b" + Sel.ToString());
            }
            return hz;

        }

        public static string returnMzh(string mzh, RelationalDatabase _DataBase,long jgbm)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@JGBM";
                parameters[0].Value =jgbm;

                parameters[1].Text = "@input";
                parameters[1].Value = mzh;

                parameters[2].Text = "@MZH";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;

                _DataBase.DoCommand("SP_MZGH_GETMZH", parameters, 30);

                string smzh = Convert.ToString(parameters[2].Value);
                return smzh;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        public static string returnZyh(string zyh)
        {
            int i = Convert.ToInt32(new SystemCfg(5026).Config);
            //if (zyh.Length > i)
            //{
            //    return zyh;
            //}

            string tmp1 = "0000000000000";
            if (zyh.Length == 0)
                return zyh;
            else
                return tmp1.Substring(0, i - zyh.Length) + zyh;
        }

        public static RelationalDatabase Database(ConnectionType connectionType, string ConnectString)
        {
            RelationalDatabase database = null;
            //连接数据库
            switch (connectionType)
            {
                case ConnectionType.SQLSERVER:
                    database = new MsSqlServer();
                    break;
                case ConnectionType.IBMDB2:
                    database = new IbmDb2();
                    break;
                case ConnectionType.MSACCESS:
                    database = new MsAccess();
                    break;
                case ConnectionType.ORACLE:
                    database = new Oracle();
                    break;
                default:
                    break;
            }
            //初始化数据库连接
            if (database != null)
                database.Initialize(ConnectString);
            else
                throw new Exception("初始化数据库时没有成功，连接失败");
            return database;
        }

        public static bool IsExistsInGrid( object[] keys , DataTable tbData ,string[] PrimaryKey )
        {
            DataTable tb = tbData.Copy();
            DataColumn[] columns = new DataColumn[PrimaryKey.Length];
            for (int i = 0; i < PrimaryKey.Length; i++)
                columns[i] = tb.Columns[PrimaryKey[i]];
            tb.PrimaryKey = columns;
            DataRow r = tb.Rows.Find(keys);
            if (r == null)
                return false;
            else
                return true;
        
        }

        
    }
}
