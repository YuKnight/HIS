using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ts_Ba_tj;
using System.Windows.Forms;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using System.Collections;
using System.Runtime.InteropServices;
using System.Reflection;
namespace Ts_Clinicalpathway_Factory
{
    public class PublicFunction
    {
        // private Bitmap BackgroundBitmap;
        public static int AW_HOR_POSITIVE = 0x0001;//从左向右显示
        public static int AW_HOR_NEGATIVE = 0x0002;//从右向左显示
        public static int AW_VER_POSITIVE = 0x0004;//从上到下显示
        public static int AW_VER_NEGATIVE = 0x0008;//从下到上显示
        public static int AW_CENTER = 0x0010;//从中间向四周
        public static int AW_HIDE = 0x10000;
        public static int AW_ACTIVATE = 0x20000;//普通显示
        public static int AW_SLIDE = 0x40000;
        public static int AW_BLEND = 0x80000;//透明渐变显示
        [DllImport("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);
        [DllImport("user32.dll")]
        public static extern int SetSystemCursor(int hcur, int id);
        [DllImport("User32.dll")]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process,
            int minSize,
            int maxSize
        );
        public class Item
        {
            public string id;
            public string name;
            public Item()
            {

            }
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            public string Id
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;
                }
            }
            public override string ToString()
            {
                return name.Trim();
            }
        }
        /// <summary>
        /// dgv列的类型
        /// </summary>
        public static class DgvColStype
        {
            public const string TextBoxColumn = "DataGridViewTextBoxColumn";
            public const string ButtonColumn = "DataGridViewButtonColumn";
            public const string GroupColumn = "DataGridViewGroupColumn";
            public const string ComboBoxColumn = "DataGridViewComboBoxColumn";
            public const string ImageColumn = "DataGridViewImageColumn";
            public const string CheckBoxColumn = "DataGridViewCheckBoxColumn";
            public const string ViewLinkColumn = "DataGridViewLinkColumn";
            public const string DateTimePickerColumn = "DataGridViewDateTimePickerColumn";
            public const string NumericUpDownColumn = "DataGridViewNumericUpDownColumn";
        }
        /// <summary>
        /// 分组显示数据
        /// </summary>
        public static void GruopShow(DataTable datatable, string Ftj, string Fstring, DataGridView dgv, string Parentstring, int Index)
        {
            DataTable tb = datatable;//获得数据
            if (tb == null || tb.Rows.Count == 0) return;
            SortTreeTable(tb, Ftj, Fstring, Parentstring);
            DataTable temptable = tb;

            dgv.DataSource = temptable;//
            // return;

            DataRow[] row = temptable.Select(Ftj);
            try
            {


                for (int i = 0; i < row.Length; i++)
                {
                    DataGridViewGroupCell cell = dgv.Rows[temptable.Rows.IndexOf(row[i])].Cells[Index] as DataGridViewGroupCell;//父节点
                    cell.Index = Index;
                    string Parent_id = row[i][Fstring].ToString();//父节点值
                    AddRow(temptable, (DataGridViewGroupCell)cell, Parent_id, Ftj, Fstring, dgv, Parentstring, Index);//递归添加子节点
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            try
            {
                dgv.Rows[0].Selected = false;
            }
            catch { }
            dgv.Refresh();
        }


        /// <summary>
        /// 分组显示数据 提高效率
        /// </summary>
        public static void GruopShow(DataTable datatable, string Ftj, string Fstring, DataGridView dgv, string Parentstring, int Index, int int_new)
        {
            DataTable tb = datatable;//获得数据
            if (tb == null || tb.Rows.Count == 0) return;
            SortTreeTable(tb, Ftj, Fstring, Parentstring);
            DataTable temptable = tb;

            dgv.DataSource = temptable;//
            // return;

            DataRow[] row = temptable.Select(Ftj);
            try
            {
                for (int i = 0; i < row.Length; i++)
                {
                    //DataGridViewGroupCell cell = dgv.Rows[temptable.Rows.IndexOf(row[i])].Cells[Index] as DataGridViewGroupCell;//父节点
                    //cell.Index = Index;
                    int cellrowindex = temptable.Rows.IndexOf(row[i]);
                    string Parent_id = row[i][Fstring].ToString();//父节点值
                    AddRow(temptable, cellrowindex, Parent_id, Ftj, Fstring, dgv, Parentstring, Index);//递归添加子节点
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            try
            {
                dgv.Rows[0].Selected = false;
            }
            catch { }
            dgv.Refresh();
        }
        /// <summary>
        /// 分组显示数据 
        /// </summary>
        public static void GruopShow(DataTable datatable, string Ftj, string Fstring, DataGridView dgv, string Parentstring, int Index, bool Isfb)
        {
            DataTable tb = datatable;//获得数据
            if (tb == null || tb.Rows.Count == 0) return;
            SortTreeTable(tb, Ftj, Fstring, Parentstring);
            DataTable temptable = tb;
            DataRow[] row = temptable.Select(Ftj);
            for (int i = 0; i < row.Length; i++)
            {
                DataGridViewGroupCell cell = dgv.Rows[temptable.Rows.IndexOf(row[i])].Cells[Index] as DataGridViewGroupCell;//父节点
                cell.Index = Index;
                cell.Isfb = Isfb;
                string Parent_id = row[i][Fstring].ToString();//父节点值
                AddRow(temptable, cell, Parent_id, Ftj, Fstring, dgv, Parentstring, Index, Isfb);//递归添加子节点
            }
            try
            {
                dgv.Rows[0].Selected = false;
            }
            catch { }
            dgv.Refresh();
        }
        /// <summary>
        /// 添加子单元 提高效率
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="cell"></param>
        public static void AddRow(DataTable tb, int cell_rowindex, string Parent_id, string Ftj, string Fstring, DataGridView dgv, string Parentstring, int Index)
        {
            DataRow[] row = tb.Select(Parentstring + "='" + Parent_id.ToString() + "'");
            DataGridViewGroupCell parentcell;
            if (row.Length > 0)
            {
                parentcell = dgv.Rows[cell_rowindex].Cells[Index] as DataGridViewGroupCell;
            }
            else
                return;
            for (int i = 0; i < row.Length; i++)
            {
                int _newcell_rowindex = tb.Rows.IndexOf(row[i]);
                // DataGridViewCell cdel = dgv.Rows[_newcell_rowindex].Cells[Index];
                DataGridViewGroupCell childcell = dgv.Rows[_newcell_rowindex].Cells[Index] as DataGridViewGroupCell;

                childcell.Index = Index;
                parentcell.AddChildCell(childcell);
                string Parent_id_new = row[i][Fstring].ToString();//父节点值
                AddRow(tb, _newcell_rowindex, Parent_id_new, Ftj, Fstring, dgv, Parentstring, Index);//递归添加子节点
            }
        }
        /// <summary>
        /// 添加子单元
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="cell"></param>
        public static void AddRow(DataTable tb, DataGridViewGroupCell cell, string Parent_id, string Ftj, string Fstring, DataGridView dgv, string Parentstring, int Index, bool isfb)
        {
            DataRow[] row = tb.Select(Parentstring + "='" + Parent_id.ToString() + "'");
            for (int i = 0; i < row.Length; i++)
            {
                DataGridViewGroupCell childcell = dgv.Rows[tb.Rows.IndexOf(row[i])].Cells[Index] as DataGridViewGroupCell;

                childcell.Index = Index;
                childcell.Isfb = isfb;
                cell.AddChildCell(childcell);
                string Parent_id_new = row[i][Fstring].ToString();//父节点值
                AddRow(tb, childcell, Parent_id_new, Ftj, Fstring, dgv, Parentstring, Index);//递归添加子节点


            }
        }
        /// <summary>
        /// 添加子单元
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="cell"></param>
        public static void AddRow(DataTable tb, DataGridViewGroupCell cell, string Parent_id, string Ftj, string Fstring, DataGridView dgv, string Parentstring, int Index)
        {
            DataRow[] row = tb.Select(Parentstring + "='" + Parent_id.ToString() + "'");
            for (int i = 0; i < row.Length; i++)
            {
                DataGridViewGroupCell childcell = dgv.Rows[tb.Rows.IndexOf(row[i])].Cells[Index] as DataGridViewGroupCell;
                childcell.Index = Index;
                cell.AddChildCell(childcell);
                string Parent_id_new = row[i][Fstring].ToString();//父节点值
                AddRow(tb, childcell, Parent_id_new, Ftj, Fstring, dgv, Parentstring, Index);//递归添加子节点
            }
        }
        /// <summary>
        /// 获得树形表
        /// </summary>
        /// <param name="tb">要排序的表</param>
        /// <returns>返回树形表</returns>
        public static DataTable SortTreeTable(DataTable tb, string Ftj, string Fstring, string Parentstring)
        {
            DataTable temp = tb.Copy();
            tb.Clear();
            DataRow[] row = temp.Select(Ftj);
            for (int i = 0; i < row.Length; i++)
            {
                DataRow ParentRow = row[i];
                string Parent_id = row[i][Fstring].ToString().Trim();
                tb.Rows.Add(row[i].ItemArray);
                SortChildTreeTable(tb, temp, ParentRow, Parent_id, Ftj, Fstring, Parentstring);
            }
            tb.AcceptChanges();
            return tb;
        }
        /// <summary>
        /// 按树形结构排序表
        /// </summary>
        /// <param name="tb">排序后表</param>
        /// <param name="InitTb">要排序的原始表</param>
        /// <param name="PatentRow">父亲行</param>
        /// <param name="Parent_id">父亲id</param>
        /// <returns></returns>
        public static void SortChildTreeTable(DataTable tb, DataTable InitTb, DataRow PatentRow, string Parent_id, string Ftj, string Fstring, string Parentstring)
        {
            DataRow[] row = InitTb.Select(Parentstring + "='" + Parent_id.ToString() + "'");//获得所有子节点v
            for (int i = 0; i < row.Length; i++)
            {
                DataRow ParentRow = row[i];
                Parent_id = row[i][Fstring].ToString().Trim();
                tb.Rows.Add(row[i].ItemArray);
                SortChildTreeTable(tb, InitTb, ParentRow, Parent_id, Ftj, Fstring, Parentstring);
            }
        }

        /// <summary>
        /// 获得病人基本信息
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="babya_id"></param>
        /// <returns></returns>
        public static DataTable GetPatInfo(string inpatient_id, string babya_id)
        {
            string sql = "select NAME,AGE,CUR_DEPT_NAME,SEX_NAME,WARD_NAME, RYZD,INPATIENT_NO,bed_no,in_date,dbo.FUN_ZY_SEEKPATFEEINFO(inpatient_id,baby_id,0) zfy from VI_ZY_VINPATIENT_BED where inpatient_id='" + inpatient_id + "'  and baby_id=" + babya_id;
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            return tb;
        }
        /// <summary>
        /// 绑定控件
        /// </summary>
        /// <param name="GroupBox1"></param>
        /// <param name="tb"></param>
        public static void Bindtext(GroupBox GroupBox1, DataTable tb)
        {
            try
            {
                for (int i = 0; i < GroupBox1.Controls.Count; i++)
                {
                    TextBox txt = GroupBox1.Controls[i] as TextBox;
                    if (txt != null)
                    {
                        Binding b = new Binding("Text", tb, txt.Tag.ToString());
                        txt.DataBindings.Add(b);
                    }
                    ComboBox comb = GroupBox1.Controls[i] as ComboBox;
                    if (comb != null)
                    {
                        Binding b1 = new Binding("SelectedValue", tb, comb.Tag.ToString());
                        comb.DataBindings.Add(b1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示信息：");
            }
        }
        public static void Bindtext(Control control, DataTable tb)
        {
            try
            {
                for (int i = 0; i < control.Controls.Count; i++)
                {
                    TextBox txt = control.Controls[i] as TextBox;

                    if (txt != null)
                    {
                        txt.DataBindings.Clear();
                        Binding b = new Binding("Text", tb, txt.Tag.ToString());
                        txt.DataBindings.Add(b);
                    }
                    ComboBox comb = control.Controls[i] as ComboBox;
                    if (comb != null)
                    {
                        comb.DataBindings.Clear();
                        Binding b1 = new Binding("SelectedValue", tb, comb.Tag.ToString());
                        comb.DataBindings.Add(b1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示信息：");
            }
        }
        /// <summary>
        /// 获得项目信息
        /// </summary>
        /// <param name="step_id"></param>
        /// <returns></returns>
        public static DataTable GetItem(string step_id, string step_exe_id, DateTime Intopathdate, string pathway_exe_id)
        {
            //测试用
            //DataTable tb = FrmMdiMain.Database.GetDataTable("select DEPT_ID,P_DEPT_ID,NAME from JC_DEPT_PROPERTY ");
            string sql = "select *,'False' 免试 from ( "
                      + "   select 'False' [check],step_item_kind_id Bsid,null Parent_id,path_step_id,pathaway_id,itemkind,mngtype ,"
                      + "  content ,py_code,wb_code,select_type,exec_type,sort ,notes order_spec,null js, "
                      + " 0 xmid,0 cjid,'' jldw,null jl, 0 xmly,null yf,null pc,null fzxh,null iszx,1 lb "
                      + " ,null EMPID_OPER,null OPER_DATE,DELETE_BIT,null zxks,  "
                      + "  null jldwid,null dwlx,null zt,null ts,null bzby,'' fz ,case when mngtype=0 then '长期' else '临时' end gllx "
                      + " ,case when exec_type=1 then '必选' else '可选' end  exectypename,'' reason,'' bzx,null path_itemUNexe_id,case when select_type=0 then '单选' else '多选' end select_typename,null path_itemexe_id "
                      + ", '' stopinfo , '' ordertypename,null price,0 psyp "
                      + "  from  dbo.PATH_STEP_ITEM_KIND where   delete_bit=0 and ITEMKIND=2  "
                      + "  union all   "
                      + "  select 'False' [check],a.path_step_item_id Bsid,a.step_item_kind_id Parent_id,a.path_step_id,a.pathaway_id,itemkind,mngtype, "
                      + "    content,py_code,wb_code,null select_type,exec_type,sort,notes order_spec,js ,"
                      + "    a.xmid,cjid,jldw,jl,a.xmly,YF,pc,isnull(fzxh,DBO.FUN_GETGUID(NEWID(),OPER_DATE)) fzxh, case when (path_itemexe_id is not null and isnull(b.delete_bit,0)=0) then '√(已执行)' else '×(未执行)' end iszx,0 lb "
                      + " , null EMPID_OPER,OPER_DATE,a.DELETE_BIT,zxks "
                      + " , jldwid,dwlx,zt,ts,bzby,'' fz,case when mngtype=0 then '长期' else '临时' end gllx "
                      + ",case when exec_type=1 then '必选' else '可选' end  exectypename ,reason,case when (path_itemUNexe_id is not null and isnull(c.delete_bit,0)=0 ) then '不执行' else '' end  bzx "
                      + ",path_itemUNexe_id ,'' select_typename,path_itemexe_id"
                      + " ,case when ISNULL(b.status_flag ,0)>=3 and mngtype=0 then '停嘱信息' else '' end stopinfo,d.typename  ordertypename ,price ,psyp "
                      + "  from  "                                               //DATEDIFF(MINUTE,'" + Intopathdate + "',GETDATE())/1440 只要停医嘱的时间大于这个阶段的下限制
                      + "       (select * from PATH_STEP_ITEM where (MNGTYPE=0 and (select isnull(TIME_DOWN,0) from PATH_STEP  where PATH_STEP_ID='" + step_id + "' )<=(case when cqyztzts is null or cqyztzts=0 then 99999 else cqyztzts end ) ) and PATH_STEP_ID!='" + step_id + "'"//不在阶段项目 但是停医嘱时间大于这个阶段
                // + "         and (select isnull(TIME_UP,0) from PATH_STEP  where PATH_STEP_ID='" + step_id + "' )>=(case when cqyztzts is null or cqyztzts=0 then 99999 else cqyztzts end )   "
                      + "        union all select * from PATH_STEP_ITEM  where PATH_STEP_ID='" + step_id + "') "
                      + "  a left join "
                      + " (select * from path_itemexe where  isnull(delete_bit,0)=0 and PATHWAY_EXE_ID='" + pathway_exe_id + "')   b  "
                      + " on a.PATH_STEP_ITEM_ID=b.PATH_STEP_ITEM_ID "
                      + "   left join   (select * from PATH_ITEMUnEXE_Record where  isnull(delete_bit,0)=0 and PATH_STEP_ID='" + step_id + "' and EXE_STEP_ID='" + step_exe_id + "') c "
                      + "  on a.PATH_STEP_ITEM_ID=c.PATH_STEP_ITEM_ID  "
                           + " left join ( select distinct GGID xmid, cast(b.ID as varchar)+'-'+MC typename,1 xmly,PSYP from VI_YP_YPCD a join YP_YPLX b on a.YPLX=b.ID  "
                           + "   union all   "
                           + "   select ORDER_ID xmid ,NAME typename,2 xmly, 0 PSYP from JC_HOITEMDICTION a join JC_ORDERTYPE b on a.ORDER_TYPE=b.CODE  where DELETE_BIT =0  ) d on a.xmid=d.xmid and a.xmly=d.xmly"
                      + " where  a.ITEMKIND=2   and a.delete_bit=0 and ISNULL(b.status_flag ,0)<=5   "//and isnull(b.delete_bit,0)=0 and isnull(c.delete_bit,0)=0  ";
                      + " ) aa  order by  mngtype,sort,fzxh,xmly,exec_type,xmid,select_type   ";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);

            //如果不在执行的路径里
            DataTable exepathstep = FrmMdiMain.Database.GetDataTable(" select PATH_STEP_ID from PATH_WAY_EXE_STEP where  EXE_PATHWAY_ID='" + pathway_exe_id + "'");
            int j = 0;
            for (int i = 0; i - j < tb.Rows.Count; i++)
            {
                DataRow[] r = exepathstep.Select("PATH_STEP_ID='" + tb.Rows[i - j]["PATH_STEP_ID"].ToString() + "'");
                if (r.Length <= 0 && tb.Rows[i - j]["lb"].ToString() == "0")//如果不在执行的路径里，并且是子
                {
                    tb.Rows.Remove(tb.Rows[i - j]);
                    j++;
                }
            }

            DataTable tempChild = tb.Copy();
            tempChild.DefaultView.RowFilter = "lb=0 ";
            tempChild = tempChild.DefaultView.ToTable();
            j = 0;
            //去掉所有子节点执行了的父亲节点
            for (int i = 0; i - j < tb.Rows.Count; i++)
            {

                //没有子节点
                DataRow[] row = tempChild.Select(" Parent_id='" + tb.Rows[i - j]["bsid"] + "'");
                if (tb.Rows[i - j]["lb"].ToString() == "1" && row.Length <= 0)//去掉没有子节点的父亲节点
                {
                    tb.Rows.Remove(tb.Rows[i - j]);
                    j++;
                }
            }

            return tb;
        }
        public static void InitDgv(string[] Columname, int[] ColWide, bool[] ReadOnly, string[] Coltype, string[] Values, DataGridView dgv)
        {
            int length = Columname.Length;
            for (int i = 0; i < length; i++)
            {
                DataGridViewColumn Col = null;
                switch (Coltype[i])
                {
                    case DgvColStype.TextBoxColumn:
                        Col = new DataGridViewTextBoxColumn();
                        break;
                    case DgvColStype.ButtonColumn:
                        Col = new DataGridViewButtonColumn();
                        break;
                    case DgvColStype.GroupColumn:
                        Col = new DataGridViewGroupColumn();
                        break;
                    case DgvColStype.CheckBoxColumn:
                        Col = new DataGridViewCheckBoxColumn();
                        break;
                    case DgvColStype.ComboBoxColumn:
                        Col = new DataGridViewComboBoxColumn();
                        break;
                    case DgvColStype.ViewLinkColumn:
                        Col = new DataGridViewLinkColumn();
                        break;
                    case DgvColStype.DateTimePickerColumn:
                        Col = new Ts_Ba_tj.DataGridViewDateTimePickerColumn();
                        break;
                    case DgvColStype.NumericUpDownColumn:
                        Col = new Ts_Ba_tj.DataGridViewNumericUpDownColumn();
                        break;
                    default:

                        break;
                }
                //if (i <= 3)
                //{
                //    Col.Frozen = true;
                //}

                Col.Name = Columname[i];
                Col.Width = ColWide[i];
                Col.DataPropertyName = Values[i];
                Col.ReadOnly = ReadOnly[i];
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns.Add(Col);
            }
        }
        public static void InitDgv(string[] Columname, int[] ColWide, string[] Coltype, string[] Values, DataGridviewEx dgv, int frozen)
        {
            int length = Columname.Length;
            for (int i = 0; i < length; i++)
            {
                DataGridViewColumn Col = new DataGridViewColumn();
                switch (Coltype[i])
                {
                    case DgvColStype.TextBoxColumn:
                        Col = new DataGridViewTextBoxColumn();
                        break;
                    case DgvColStype.ButtonColumn:
                        Col = new DataGridViewButtonColumn();
                        break;
                    case DgvColStype.GroupColumn:
                        Col = new DataGridViewGroupColumn();
                        (Col as DataGridViewGroupColumn).Onserch += new DataGridViewGroupColumn.Serch(PublicFunction_Onserch);
                        break;
                    case DgvColStype.CheckBoxColumn:
                        Col = new DataGridViewCheckBoxColumn();
                        break;
                    case DgvColStype.ComboBoxColumn:
                        Col = new DataGridViewComboBoxColumn();
                        break;
                    case DgvColStype.ViewLinkColumn:
                        Col = new DataGridViewLinkColumn();
                        break;
                    case DgvColStype.DateTimePickerColumn:
                        Col = new Ts_Ba_tj.DataGridViewDateTimePickerColumn();
                        break;
                    case DgvColStype.NumericUpDownColumn:
                        Col = new Ts_Ba_tj.DataGridViewNumericUpDownColumn();
                        break;
                    default:
                        break;
                }
                if (i <= frozen)
                {
                    Col.Frozen = true;
                }
                if (i == 11)
                {
                    // Col.DefaultCellStyle.Padding = new Padding(0, -10, 0, -10);
                    Col.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                }
                if (i == 15)
                    Col.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                Col.HeaderText = Columname[i];
                Col.Width = ColWide[i];
                Col.Name = Columname[i];
                Col.DataPropertyName = Values[i];
                if (Coltype[i] == DgvColStype.GroupColumn)
                    Col.ReadOnly = true;
                else
                    Col.ReadOnly = true;
                //if (Coltype[i] == DgvColStype.CheckBoxColumn)
                //    Col.ReadOnly = false;//复选款列可以编辑
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns.Add(Col);
            }
        }
        public static void InitDgv(string[] Columname, int[] ColWide, string[] Coltype, string[] Values, DataGridView dgv, int frozen)
        {
            int length = Columname.Length;
            for (int i = 0; i < length; i++)
            {
                DataGridViewColumn Col = new DataGridViewColumn();
                switch (Coltype[i])
                {
                    case DgvColStype.TextBoxColumn:
                        Col = new DataGridViewTextBoxColumn();
                        break;
                    case DgvColStype.ButtonColumn:
                        Col = new DataGridViewButtonColumn();
                        break;
                    case DgvColStype.GroupColumn:
                        Col = new DataGridViewGroupColumn();
                        (Col as DataGridViewGroupColumn).Onserch += new DataGridViewGroupColumn.Serch(PublicFunction_Onserch);
                        break;
                    case DgvColStype.CheckBoxColumn:
                        Col = new DataGridViewCheckBoxColumn();
                        break;
                    case DgvColStype.ComboBoxColumn:
                        Col = new DataGridViewComboBoxColumn();
                        break;
                    case DgvColStype.ViewLinkColumn:
                        Col = new DataGridViewLinkColumn();
                        break;
                    case DgvColStype.DateTimePickerColumn:
                        Col = new Ts_Ba_tj.DataGridViewDateTimePickerColumn();
                        break;
                    case DgvColStype.NumericUpDownColumn:
                        Col = new Ts_Ba_tj.DataGridViewNumericUpDownColumn();
                        break;
                    default:
                        break;
                }
                if (i <= frozen)
                {
                    Col.Frozen = true;
                }
                if (i == 11)
                {
                    // Col.DefaultCellStyle.Padding = new Padding(0, -10, 0, -10);
                    Col.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                }
                if (i == 15)
                    Col.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                Col.HeaderText = Columname[i];
                Col.Width = ColWide[i];
                Col.Name = Columname[i];
                Col.DataPropertyName = Values[i];
                if (Coltype[i] == DgvColStype.GroupColumn)
                    Col.ReadOnly = true;
                else
                    Col.ReadOnly = true;
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns.Add(Col);
            }
        }
        static void PublicFunction_Onserch(int row, int col, string values)
        {
            MessageBox.Show(values);
        }

        public static DataSet GetPathwayDs(string pathwayid)
        {
            try
            {
                //查询SQL语句
                string sSql = string.Format("SELECT * FROM [PATH_STEP] WHERE [PATHWAY_ID] = '{0}' AND [DELETED] = 0", pathwayid);
                string sSqlItem = string.Format("SELECT * FROM [PATH_STEP_RALATE] WHERE [PATHWAY_ID] = '{0}' AND [DELETED] = 0", pathwayid);
                //获取和所选路径相关的步骤和连线
                DataTable dt = FrmMdiMain.Database.GetDataTable(sSql);
                DataTable dtItem = FrmMdiMain.Database.GetDataTable(sSqlItem);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                ds.Tables.Add(dtItem);
                ////设置主键
                //dt.PrimaryKey = new DataColumn[] { dt.Columns["PATH_STEP_ID"] };
                //dtItem.PrimaryKey = new DataColumn[] { dtItem.Columns["PATH_STEP_RALATE_ID"] };
                ////从DataTable加载图像
                //pathWay1.LoadItem_FromDataTable(dt, dtItem);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("初始化失败：" + ex.Message);
            }

        }
        /// <summary>
        /// 保存临床路径医嘱
        /// </summary>
        /// <param name="view"></param>
        /// <param name="Cporder"></param>
        public static void SaveCporder(DataView view, DataTable Cporder, string inpatient_id, string bayby_id, string dept_br, string ward_id, string pathway_id,
            string PATHWAY_EXE_ID, string PATH_STEP_ID, string EXE_STEP_ID, ref ArrayList Arcfxh)
        {
            ArrayList Arlong = new ArrayList();
            ArrayList Artemp = new ArrayList();
            string sslong = "";
            string sstemp = "";
            //长期医嘱
            Cporder.DefaultView.RowFilter = "mngtype=0";
            DataTable Longorder = Cporder.DefaultView.ToTable();
            //临时医嘱
            Cporder.DefaultView.RowFilter = "mngtype=1";
            DataTable temporder = Cporder.DefaultView.ToTable();
            try
            {
                Commitorder(Longorder, view, inpatient_id, bayby_id, dept_br, ward_id, pathway_id, PATHWAY_EXE_ID, PATH_STEP_ID, EXE_STEP_ID, ref  Arlong, ref sslong);
                Commitorder(temporder, view, inpatient_id, bayby_id, dept_br, ward_id, pathway_id, PATHWAY_EXE_ID, PATH_STEP_ID, EXE_STEP_ID, ref Artemp, ref sstemp);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                for (int i = 0; i < Arlong.Count; i++)
                {
                    Arcfxh.Add(Arlong[i]);
                }
                for (int i = 0; i < Artemp.Count; i++)
                {
                    Arcfxh.Add(Artemp[i]);
                }
                if (sslong + sstemp != "")
                    throw new Exception(sslong + "\n" + sstemp);
            }

        }
        /// <summary>
        /// 记录有问题组号 add by zouchihua 2015-6-27
        /// </summary>
        public static int Error_groupid = -1;
        /// <summary>
        /// 提交医嘱到数据库
        /// </summary>
        /// <param name="tb"></param>
        private static void Commitorder(DataTable tb, DataView view, string inpatient_id, string bayby_id, string dept_br, string ward_id, string pathway_id,
            string PATHWAY_EXE_ID, string PATH_STEP_ID, string EXE_STEP_ID, ref ArrayList Arcfxh, ref string sslog)
        {
            Error_groupid = -1;
            string PATH_STEP_ITEM_ID = "";
            string strmsg = "";
            DataTable Longorder = tb;
            ArrayList psorderidarr = new ArrayList();
            ArrayList path_itemexe_idarr = new ArrayList();
            DateTime tempDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            //获得表结构
            DataTable Hisorder = FrmMdiMain.Database.GetDataTable("select * from zy_orderrecord where 1=2");
            Guid path_itemexe_id = Guid.Empty;

            int temgroup = 0;
            int SERIAL_NO = 0;
            string oldgroupid = "";
            //第一步
            string erStr = "";
            try
            {
                erStr = CommitOrderrecord(Guid.Empty, 0, new Guid(inpatient_id), 0, "", 0, 0, 0, 0, "", 1, "", 0, 0, "", "", tempDate, tempDate, 0, "", "", 0, 0, 0, 0, 0, 0, "", 0, -1, Guid.Empty, 0, 0, 0, 1, "", FrmMdiMain.Jgbm, 0, Guid.Empty, 0, -1, 1, 0, "", "1"
                    , Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), 0);
            }
            catch (Exception err)
            {
                MessageBox.Show(erStr + err.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #region//第二步
            for (int i = 0; i < Longorder.Rows.Count; i++)
            {

                #region 处理手术医嘱
                if (Longorder.Rows[i]["cjid"].ToString() == "-999")
                {
                    object[] communicateValue = new object[14];
                    communicateValue[0] = inpatient_id;
                    communicateValue[1] = ward_id;
                    communicateValue[2] = 0;
                    communicateValue[3] = "";
                    communicateValue[4] = 0;
                    communicateValue[5] = 1;//普通医生，手术申请
                    communicateValue[6] = inpatient_id;//inpatient_id
                    communicateValue[7] = Longorder.Rows[i]["CONTENT"].ToString();
                    communicateValue[8] = int.Parse(Longorder.Rows[i]["xmid"].ToString());
                    communicateValue[9] = pathway_id;
                    communicateValue[10] = PATH_STEP_ID;
                    communicateValue[11] = PATHWAY_EXE_ID;
                    communicateValue[12] = EXE_STEP_ID;
                    communicateValue[13] = Longorder.Rows[i]["Bsid"].ToString();
                    GetForm("Ts_zyys_ssgl", "Fun_Ts_zyys_sssq_cp", "手术申请", FrmMdiMain.CurrentUser.UserID, FrmMdiMain.CurrentDept.DeptId, communicateValue, true);
                    continue;
                }
                #endregion

                DataRow hisrow = Hisorder.NewRow();
                //获得执行科室，等信息
                DataRow[] selrow;
                if (Longorder.Rows[i]["xmly"].ToString() == "1")
                {
                    selrow = view.Table.Select("order_id=" + Longorder.Rows[i]["cjid"].ToString() + " and xmly=1");
                    //如果没有找到，找一个规格相同的药品
                    if (selrow == null || selrow.Length == 0)
                    {
                        selrow = view.Table.Select("项目代码=" + Longorder.Rows[i]["xmid"].ToString() + " and xmly=1");
                    }
                }
                else
                {
                    selrow = view.Table.Select("order_id=" + Longorder.Rows[i]["xmid"].ToString() + " and xmly=2");

                }

                //找到对应记录
                if ((selrow != null && selrow.Length > 0) || (Longorder.Rows[i]["xmly"].ToString() == "2" && int.Parse(Longorder.Rows[i]["xmid"].ToString()) <= 0))
                {

                    if (!(selrow.Length <= 0 || int.Parse(Longorder.Rows[i]["xmid"].ToString()) <= 0))
                    {
                        hisrow["MNGTYPE"] = Longorder.Rows[i]["mngtype"].ToString();
                        hisrow["ntype"] = selrow[0]["type"];
                        hisrow["ORDER_DOC"] = FrmMdiMain.CurrentUser.EmployeeId;
                        hisrow["HOITEM_ID"] = selrow[0]["order_id"];
                        hisrow["ITEM_CODE"] = selrow[0]["order_id"];
                        hisrow["XMLY"] = selrow[0]["XMLY"];

                        //add by zouchihua 2013-11-5 增加对皮试医嘱的处理
                        if (selrow[0]["psyp"].ToString() == "1" && Longorder.Rows[i]["免试"].ToString() == "True")
                            hisrow["ORDER_CONTEXT"] = selrow[0]["医嘱内容"] + " 「免试」";
                        else
                            hisrow["ORDER_CONTEXT"] = selrow[0]["医嘱内容"];
                        hisrow["NUM"] = Longorder.Rows[i]["jl"];
                        hisrow["DOSAGE"] = Longorder.Rows[i]["js"];
                        hisrow["UNIT"] = Longorder.Rows[i]["jldw"].ToString().Trim();
                        hisrow["order_spec"] = Longorder.Rows[i]["order_spec"];
                        hisrow["ORDER_USAGE"] = Longorder.Rows[i]["yf"];
                        hisrow["FREQUENCY"] = Longorder.Rows[i]["pc"];
                        hisrow["OPERATOR"] = FrmMdiMain.CurrentUser.EmployeeId;
                        hisrow["STATUS_FLAG"] = 0;
                        hisrow["BABY_ID"] = 0;
                        hisrow["DEPT_BR"] = dept_br;
                        hisrow["EXEC_DEPT"] = selrow[0]["DEFAULT_DEPT"];
                        hisrow["DROPSPER"] = Longorder.Rows[i]["zt"].ToString();//嘱托
                        hisrow["SERIAL_NO"] = 1; //Longorder.Rows[i]["sort"].ToString();
                        hisrow["unit"] = Longorder.Rows[i]["jldw"].ToString();//selrow[0]["单位"].ToString().Trim();

                        hisrow["FIRST_TIMES"] = GetFirsttimes(Longorder.Rows[i]["pc"].ToString(), tempDate);

                        hisrow["ps_flag"] = selrow[0]["psyp"];
                        hisrow["dwlx"] = Longorder.Rows[i]["dwlx"].ToString();
                        //hisrow["FIRST_TIMES"]=GetFirsttimes(Longorder.Rows[i]["pc"].ToString(),tempDate);
                        PATH_STEP_ITEM_ID = Longorder.Rows[i]["Bsid"].ToString();// PATH_STEP_ITEM_ID

                        if (hisrow["ntype"].ToString() == "5")
                        {
                            hisrow["dwlx"] = Convert.ToInt16(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select bbid from jc_assay where yzid=" + selrow[0]["order_id"].ToString()), "0"));
                        }

                    }
                    else//说明医嘱
                    {

                        hisrow["MNGTYPE"] = Longorder.Rows[i]["mngtype"].ToString();
                        hisrow["ntype"] = 7;
                        hisrow["ORDER_DOC"] = FrmMdiMain.CurrentUser.EmployeeId;
                        hisrow["HOITEM_ID"] = -1;
                        hisrow["ITEM_CODE"] = -1;
                        hisrow["XMLY"] = 2;
                        hisrow["ORDER_CONTEXT"] = Longorder.Rows[i]["content"];
                        hisrow["NUM"] = Longorder.Rows[i]["jl"];
                        hisrow["DOSAGE"] = Longorder.Rows[i]["js"];
                        hisrow["UNIT"] = Longorder.Rows[i]["jldw"].ToString().Trim();
                        hisrow["order_spec"] = Longorder.Rows[i]["order_spec"];
                        hisrow["ORDER_USAGE"] = Longorder.Rows[i]["yf"];
                        hisrow["FREQUENCY"] = Longorder.Rows[i]["pc"];
                        hisrow["OPERATOR"] = FrmMdiMain.CurrentUser.EmployeeId;
                        hisrow["STATUS_FLAG"] = 0;
                        hisrow["BABY_ID"] = 0;
                        hisrow["DEPT_BR"] = dept_br;
                        hisrow["EXEC_DEPT"] = FrmMdiMain.CurrentDept.DeptId;
                        hisrow["DROPSPER"] = Longorder.Rows[i]["zt"].ToString();//嘱托
                        hisrow["SERIAL_NO"] = 1; //Longorder.Rows[i]["sort"].ToString();
                        hisrow["unit"] = Longorder.Rows[i]["jldw"].ToString();//selrow[0]["单位"].ToString().Trim();
                        hisrow["FIRST_TIMES"] = GetFirsttimes(Longorder.Rows[i]["pc"].ToString(), tempDate);
                        hisrow["ps_flag"] = -1;
                        hisrow["dwlx"] = Longorder.Rows[i]["dwlx"].ToString();
                        //hisrow["FIRST_TIMES"]=GetFirsttimes(Longorder.Rows[i]["pc"].ToString(),tempDate);
                        PATH_STEP_ITEM_ID = Longorder.Rows[i]["Bsid"].ToString();// PATH_STEP_ITEM_ID

                    }

                    if (Longorder.Rows[i]["mngtype"].ToString() != "0")
                    {

                        //临时医嘱
                        hisrow["FIRST_TIMES"] = 1;
                        hisrow["ts"] = 1;
                        hisrow["zsldw"] = Longorder.Rows[i]["jldw"].ToString();//总数量单位 就是剂量单位
                        //if (selrow == null || selrow.Length == 0)
                        //    hisrow["zsldw"] = Longorder.Rows[i]["jldw"].ToString();
                        //else
                        //    hisrow["zsldw"] = selrow[0]["单位"].ToString().Trim();
                        hisrow["zsl"] = decimal.Parse(hisrow["num"].ToString()) * GetPc(Longorder.Rows[i]["pc"].ToString().Trim());


                    }
                    else
                    {
                        hisrow["zsl"] = 0;
                        hisrow["ts"] = 1;
                    }

                }
                else
                {
                    if (Longorder.Rows[i]["xmly"].ToString() == "1")
                        strmsg += "药品医嘱名称【" + Longorder.Rows[i]["content"].ToString() + "】cjid 为【" + Longorder.Rows[i]["cjid"].ToString() + "】已经停用，可能需要重新选择药房\n";
                    else
                        strmsg += "项目医嘱名称【" + Longorder.Rows[i]["content"].ToString() + "】order_id为【" + Longorder.Rows[i]["xmid"].ToString() + "】已经停用，可能需要重新选择药房\n";
                    Arcfxh.Add(Longorder.Rows[i]["fzxh"].ToString());
                    continue;
                }

                if (i == 0)
                {
                    temgroup++;
                    oldgroupid = Longorder.Rows[i]["fzxh"].ToString();
                    SERIAL_NO = 0;
                }
                else
                {
                    //如果不等于上 Oldgroupid 组号
                    if (oldgroupid != Longorder.Rows[i]["fzxh"].ToString())
                    {
                        oldgroupid = Longorder.Rows[i]["fzxh"].ToString();
                        SERIAL_NO = 0;
                        temgroup++;
                    }
                    else
                    {
                        SERIAL_NO++;
                        //temgroup++;
                    }
                }

                hisrow["SERIAL_NO"] = SERIAL_NO;
                //hisrow["FLAG"] = 1;
                path_itemexe_id = Guid.NewGuid();//项目执行id
                short ps_flag = -1;
                Guid psorderid = Guid.NewGuid();
                if (selrow.Length == 0 || selrow[0]["psyp"].ToString() != "1")
                    psorderid = Guid.Empty;
                if (selrow.Length != 0 && selrow[0]["psyp"].ToString() == "1" && Longorder.Rows[i]["免试"].ToString() != "True")
                    ps_flag = 0;
                if (Longorder.Rows[i]["免试"].ToString() == "True")
                {
                    psorderid = Guid.Empty;
                }
                decimal price = 0;
                try
                {
                    price = decimal.Parse(Longorder.Rows[i]["price"].ToString());
                }
                catch { }
                //Modify by zouchihua2015-6-27 如果发送失败，还是要提示相关错误
                try
                {
                    //第二步
                    CommitOrderrecord(Guid.Empty, 0, new Guid(inpatient_id), FrmMdiMain.CurrentDept.DeptId, ward_id, int.Parse(hisrow["mngtype"].ToString())
                         , int.Parse(hisrow["ntype"].ToString()), long.Parse(hisrow["order_doc"].ToString()), int.Parse(hisrow["hoitem_id"].ToString()), hisrow["item_code"].ToString()
                         , int.Parse(hisrow["xmly"].ToString()), hisrow["ORDER_CONTEXT"].ToString(), decimal.Parse(hisrow["num"].ToString()), decimal.Parse(hisrow["DOSAGE"].ToString()), hisrow["unit"].ToString(), hisrow["order_spec"].ToString(), tempDate, tempDate, int.Parse(hisrow["FIRST_TIMES"].ToString())
                         , hisrow["ORDER_USAGE"].ToString(), hisrow["FREQUENCY"].ToString(), FrmMdiMain.CurrentUser.EmployeeId, 0, int.Parse(hisrow["STATUS_FLAG"].ToString()), int.Parse(bayby_id), int.Parse(dept_br), int.Parse(hisrow["EXEC_DEPT"].ToString()), hisrow["DROPSPER"].ToString(),
                         int.Parse(hisrow["SERIAL_NO"].ToString()), short.Parse(ps_flag.ToString()), psorderid, short.Parse(hisrow["dwlx"].ToString()), 0, temgroup, 2, "", FrmMdiMain.Jgbm, 0, Guid.Empty, 0, -1, 1, decimal.Parse(hisrow["zsl"].ToString()), hisrow["zsldw"].ToString(), hisrow["dwlx"].ToString(), pathway_id, PATHWAY_EXE_ID,
                         PATH_STEP_ITEM_ID, PATH_STEP_ID, path_itemexe_id.ToString(), EXE_STEP_ID, price);
                }
                catch (Exception ex)
                {
                    strmsg += "项目医嘱名称【" + Longorder.Rows[i]["content"].ToString() + "】order_id为【" + Longorder.Rows[i]["xmid"].ToString() + "】" + ex.Message + "\n";
                    Arcfxh.Add(Longorder.Rows[i]["fzxh"].ToString());
                    continue;
                }

                //皮试药品
                if (selrow.Length > 0 && selrow[0]["psyp"].ToString() == "1" && Longorder.Rows[i]["免试"].ToString() != "True")
                {

                    path_itemexe_idarr.Add(path_itemexe_id);
                    psorderidarr.Add(psorderid);//保存皮试id

                    long groupid = GetYzNum(new Guid(inpatient_id), 0);
                    string sql = "insert into zy_orderrecord(order_id ,GROUP_ID,INPATIENT_ID,DEPT_ID ,WARD_ID,MNGTYPE, NTYPE , ORDER_DOC,HOITEM_ID,ITEM_CODE,ORDER_CONTEXT,NUM ,DOSAGE,"
+ " UNIT ,order_SPEC,BOOK_DATE ,ORDER_BDATE ,FIRST_TIMES , ORDER_USAGE ,FREQUENCY ,OPERATOR ,DELETE_BIT, STATUS_FLAG ,BABY_ID,"
+ " DEPT_BR , EXEC_DEPT , DROPSPER ,SERIAL_NO ,PS_FLAG ,PS_ORDERID ,DWLX,JZ_flag,xmly ,jgbm) ";
                    sql += " values (newid()," + groupid + ",'" + inpatient_id + "'," + FrmMdiMain.CurrentDept.DeptId + ",'" + (ward_id == "" ? "0" : ward_id) + "',1," + hisrow["ntype"].ToString() + "," + FrmMdiMain.CurrentUser.EmployeeId + ",-1,-1,'" + hisrow["ORDER_CONTEXT"].ToString() + "',0,1 ,"
                  + "'','',getdate(),'" + tempDate + "',0,'皮试',' '," + FrmMdiMain.CurrentUser.EmployeeId + ",0,0,0,"
                  + dept_br + "," + FrmMdiMain.CurrentDept.DeptId.ToString() + ",'',1,0,'" + psorderid + "',1,0,2," + FrmMdiMain.Jgbm + ")";
                    // MessageBox.Show(sql);
                    int j = FrmMdiMain.Database.DoCommand(sql);
                }
            }
            #endregion
            if (strmsg.Trim() != "")
            {
                if (Longorder.Rows[0]["mngtype"].ToString() != "0")
                    //MessageBox.Show(strmsg + "\n本次所有临时医嘱发送失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sslog = strmsg + "\n本次所有临时医嘱发送失败！";
                else
                    // MessageBox.Show(strmsg + "\n本次所有长期医嘱发送失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sslog = strmsg + "\n本次所有长期医嘱发送失败！\n\n";
                return;
            }

            #region 第三步
            // if (flag == 3)
            {
                CommitOrderrecord(Guid.Empty, 0, new Guid(inpatient_id), 0, "", 0, 0, 0, 0, "", 1, "", 0, 0, "", "", tempDate, tempDate, 0, "", "", 0, 0, 0, 0, 0, 0, "", 0, -1, Guid.Empty, 0, 0, 0, 3, "", FrmMdiMain.Jgbm, 0, Guid.Empty, 0, -1,
                   1, 0, "", "1", Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), Guid.Empty.ToString(), 0);

                for (int x = 0; x < psorderidarr.Count; x++)
                {
                    // decimal strDate = Convert.ToDecimal(System.DateTime.Now.ToString("yyyyMMddHHmmss.ffffff"));
                    string updatesql = " update zy_orderrecord   set  ps_orderid ='" + psorderidarr[x].ToString() + "'  where order_id in (select order_id from path_itemexe where path_itemexe_id='" + path_itemexe_idarr[x].ToString() + "') ";
                    int j = FrmMdiMain.Database.DoCommand(updatesql);
                    if (j == 0)
                    {
                        throw new Exception("系统自动生成皮试医嘱失败");
                    }
                }
            }
            #endregion

        }
        public static void GetForm(string dllName, string functionName, string chineseName, long userID, long deptID, object[] communicateValue, bool showType)
        {
            try
            {

                User _user = new User(Convert.ToInt32(userID), FrmMdiMain.Database);
                Department _dept = new Department(Convert.ToInt32(deptID), FrmMdiMain.Database);

                //获得DLL中窗体
                Form _dllform = (Form)WorkStaticFun.InstanceForm(dllName, functionName, chineseName, _user, _dept, null, FrmMdiMain.Database, ref communicateValue);
                _dllform.StartPosition = FormStartPosition.CenterScreen;
                if (showType) _dllform.ShowDialog();
                else _dllform.Show();
                //Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace.ToString());
                //Cursor = Cursors.Default;
                return;
            }
            finally
            {
                // for (int i = 0; i < 10; i++) openForm[i] = Guid.Empty;   //将已经打开的医嘱管理窗体进行初始化,如果没有这句话,在关闭医嘱窗体后再打开则会提示该医嘱窗体已经打开
                // tabControl1_SelectedIndexChanged(null, null);
            }
        }

        public static int GetPc(string pl)
        {
            DataTable tb = FrmMdiMain.Database.GetDataTable("select * from JC_FREQUENCY where name='" + pl + "'");
            if (tb.Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                return int.Parse(tb.Rows[0]["EXECNUM"].ToString().Trim());
            }
        }

        /// <summary>
        /// 获取病人最大医嘱组号
        /// </summary>
        /// <param name="BinID">病人ID</param>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public static long GetYzNum(Guid binID, int deptID)
        {
            string sSql;
            long BaseGroupID = 0;

            sSql = "select max(Group_Id)+1 as YZH from Zy_OrderRecord(nolock) where inpatient_id='" + binID.ToString() + "'";
            BaseGroupID = 1;

            DataTable myTb = FrmMdiMain.Database.GetDataTable(sSql);
            if (myTb.Rows[0]["YZH"].ToString().Trim() == "")
            {
                return BaseGroupID;
            }
            else
            {
                return Convert.ToInt32(myTb.Rows[0]["YZH"].ToString());
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
        public static string GetExectime(string exectime, string times, DateTime dt, int type)
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
        public static int GetFirsttimes(string pl, DateTime dt)
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
        public static int GetLasttimes(string pl, DateTime dt)
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
        /// <summary>
        /// 反射调用方法
        /// </summary>
        /// <param name="dllname"></param>
        /// <param name="classname"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        private static object ReflectionInvoke(string dllname, string classname, string MethodName, object[] Values)
        {
            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(Application.StartupPath + "\\" + dllname);
                Type type = assembly.GetType(classname, true, true);
                Object obj = System.Activator.CreateInstance(type);

                object returnobject = null;

                returnobject = type.InvokeMember(MethodName, BindingFlags.InvokeMethod, null, obj, Values);
                return returnobject;
            }
            catch (Exception ex) { throw ex; }
        }
        private static decimal Getzfbl(string inpatient_id, string hoitem_id, string xmly, string ORDER_CONTEXT, string ntype, int group_id)
        {
            //Modify By Tany 2015-06-18
            decimal zfbl = 1;
            try
            {
                DataTable patTb = FrmMdiMain.Database.GetDataTable("select * from zy_inpatient where inpatient_id='" + inpatient_id + "'");
                object[] Values = new object[1] { patTb.Rows[0]["inpatient_no"].ToString() };
                string fylb = ReflectionInvoke("Ts_zyys_public.dll", "Ts_zyys_public.DbQuery", "GetTsxx", Values).ToString();// myQuery.GetTsxx(patTb.Rows[0]["inpatient_no"].ToString());
                //增加自费比例的验证 Modify By Tany 2015-06-18
                #region 武汉中心医院
                if (fylb != "" && fylb != "自费")
                {
                    int type = 0;
                    if (fylb.Contains("公费"))
                        type = 1;
                    else
                        type = 2;

                    if (!ntype.Equals("7"))
                    {
                        try
                        {
                            string inpatient_no = patTb.Rows[0]["inpatient_no"].ToString();
                            object[] _Values = new object[] { type, inpatient_no, hoitem_id, xmly, ORDER_CONTEXT, fylb, zfbl };//Modify By Tany 2015-06-30 增加方法入参
                            string boolstring = ReflectionInvoke("Ts_zyys_public.dll", "Ts_zyys_public.DbQuery", "GetGfxx", _Values).ToString();
                            zfbl = Convert.ToDecimal(_Values.GetValue(6));//获取ref返回值 Modify By Tany 2015-06-30
                            //2,001064725,1276,2,特殊视力检查(点视力表）,
                            if (!bool.Parse(boolstring))
                            {
                                Error_groupid = group_id;
                                throw new Exception("【" + ORDER_CONTEXT + "】获取自付比例信息有误，不允许开立");
                            }
                            //else
                            //{
                            //    myRow["zfbl"] = zfbl;
                            //}
                        }
                        catch (Exception ex)//Modify By Tany 2015-03-18 加上捕获错误并返回，不继续操作
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        zfbl = 1;
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("方法Getzfbl出错: " + ex.Message.ToString() + " ");
            }
            return zfbl;
        }

        private static string CommitOrderrecord(Guid ID, long GROUP_ID, Guid INPATIENT_ID, long DEPT_ID, string WARD_ID, int MNGTYPE, int NTYPE,
            long ORDER_DOC, long HOITEM_ID, string ITEM_CODE, int XMLY, string ORDER_CONTEXT, decimal NUM, decimal DOSAGE, string UNIT, string SPEC, DateTime BOOK_DATE,
            DateTime ORDER_BDATE, int FIRST_TIMES, string ORDER_USAGE, string FREQUENCY, long OPERATOR, int DELETE_BIT, int STATUS_FLAG,
            long BABY_ID, long DEPT_BR, int EXEC_DEPT, string DROPSPER, int SERIAL_NO, short PS_FLAG, Guid PS_ORDERID, short DWLX, short JZ, long GROUP_TMP, int flag, string outStr, int Jgbm, int _iskdksly, Guid tsapply_id, int Apply_type, int jsd,
            int ts, decimal zsl, string zsldw, string jldwlx, string path_id, string PATHWAY_EXE_ID, string PATH_STEP_ITEM_ID, string PATH_STEP_ID, string path_itemexe_id, string EXE_STEP_ID,decimal price)
        {
            RelationalDatabase _Database = FrmMdiMain.Database;
            try
            {
                if (XMLY != 1 && XMLY != 2 && XMLY != 3)
                {
                    throw new Exception("项目来源必须等于1、2、3，请检查！");
                }
                //add by zouchihua 2015-6-27 如果是52参数，就不会调用获取自付病历了。只有武汉中心医院会调用
                int Pcount = int.Parse(Convertor.IsNull(FrmMdiMain.Database.GetDataResult(@"select count(*) gs from dbo.sysobjects a inner join syscolumns b 
                                                               on a.id=b.id left join
                                                               systypes c on b.xtype=c.xtype where a.id = object_id(N'[dbo].[SP_path_ORDERCOMMIT]') and OBJECTPROPERTY(a.id, N'IsProcedure') = 1", 30)
                                                            , "52"));
                decimal zfbl = 1;
                if (Pcount > 52 && flag == 2)//只有第二步的时候才调用，因为临床路径医嘱修改不会调用此方法
                {
                    //add by zouchihua 2015-6-27 获取自付比利，如果为-1，直接退出
                    zfbl = Getzfbl(INPATIENT_ID.ToString(), HOITEM_ID.ToString(), XMLY.ToString(), ORDER_CONTEXT, NTYPE.ToString(), (int)GROUP_TMP);
                    //如果此组号和记录的组号一致，说明是一组的，也不会开医嘱
                    if (GROUP_TMP == Error_groupid)
                        throw new Exception("公费信息有误，不允许开立");
                }

                IDbCommand cmd = _Database.GetCommand();
                cmd.CommandText = "SP_path_ORDERCOMMIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(_Database.GetParameter("@ID", ID));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_ID", GROUP_ID));
                cmd.Parameters.Add(_Database.GetParameter("@INPATIENT_ID", INPATIENT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_ID", DEPT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@WARD_ID", WARD_ID));
                cmd.Parameters.Add(_Database.GetParameter("@MNGTYPE", MNGTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@NTYPE", NTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_DOC", ORDER_DOC));
                cmd.Parameters.Add(_Database.GetParameter("@HOITEM_ID", HOITEM_ID));
                cmd.Parameters.Add(_Database.GetParameter("@ITEM_CODE", ITEM_CODE));
                cmd.Parameters.Add(_Database.GetParameter("@XMLY", XMLY));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_CONTEXT", ORDER_CONTEXT.Trim()));
                cmd.Parameters.Add(_Database.GetParameter("@NUM", NUM));
                cmd.Parameters.Add(_Database.GetParameter("@DOSAGE", DOSAGE));
                cmd.Parameters.Add(_Database.GetParameter("@UNIT", UNIT));
                cmd.Parameters.Add(_Database.GetParameter("@SPEC", SPEC));
                cmd.Parameters.Add(_Database.GetParameter("@BOOK_DATE", BOOK_DATE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_BDATE", ORDER_BDATE));
                cmd.Parameters.Add(_Database.GetParameter("@FIRST_TIMES", FIRST_TIMES));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_USAGE", ORDER_USAGE));
                cmd.Parameters.Add(_Database.GetParameter("@FREQUENCY", FREQUENCY));
                cmd.Parameters.Add(_Database.GetParameter("@OPERATOR", OPERATOR));
                cmd.Parameters.Add(_Database.GetParameter("@DELETE_BIT", DELETE_BIT));
                cmd.Parameters.Add(_Database.GetParameter("@STATUS_FLAG", STATUS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@BABY_ID", BABY_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_BR", DEPT_BR));
                cmd.Parameters.Add(_Database.GetParameter("@EXEC_DEPT", EXEC_DEPT));
                cmd.Parameters.Add(_Database.GetParameter("@DROPSPER", DROPSPER));
                cmd.Parameters.Add(_Database.GetParameter("@SERIAL_NO", SERIAL_NO));
                cmd.Parameters.Add(_Database.GetParameter("@PS_FLAG", PS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@PS_ORDERID", PS_ORDERID));
                cmd.Parameters.Add(_Database.GetParameter("@DWLX", DWLX));
                cmd.Parameters.Add(_Database.GetParameter("@JZ", JZ));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_TMP", GROUP_TMP));
                cmd.Parameters.Add(_Database.GetParameter("@FLAG", flag));
                cmd.Parameters.Add(_Database.GetParameter("@OUT_MSG", outStr));
                cmd.Parameters.Add(_Database.GetParameter("@Jgbm", Jgbm));
                cmd.Parameters.Add(_Database.GetParameter("@ISKDKSLY", _iskdksly));
                //modify by zouchihua 2011-10-31 区分本次申请产生的医嘱
                cmd.Parameters.Add(_Database.GetParameter("@tsapply_id", tsapply_id));
                cmd.Parameters.Add(_Database.GetParameter("@Apply_type", Apply_type));
                //add by zouchihua 2012-02-10 合理用药警示灯
                cmd.Parameters.Add(_Database.GetParameter("@jsd", jsd));

                //add by zouchihua 2012-06-21 临时医嘱改造，增加天数，总用量
                cmd.Parameters.Add(_Database.GetParameter("@ts", ts));
                cmd.Parameters.Add(_Database.GetParameter("@zsl", zsl));
                cmd.Parameters.Add(_Database.GetParameter("@zsldw", zsldw));
                cmd.Parameters.Add(_Database.GetParameter("@jldwlx", int.Parse(jldwlx)));

                cmd.Parameters.Add(_Database.GetParameter("@path_id", new Guid(path_id)));
                cmd.Parameters.Add(_Database.GetParameter("@PATHWAY_EXE_ID", new Guid(PATHWAY_EXE_ID)));
                cmd.Parameters.Add(_Database.GetParameter("@PATH_STEP_ITEM_ID", new Guid(PATH_STEP_ITEM_ID)));
                cmd.Parameters.Add(_Database.GetParameter("@PATH_STEP_ID", new Guid(PATH_STEP_ID)));
                cmd.Parameters.Add(_Database.GetParameter("@path_itemexe_id", new Guid(path_itemexe_id)));
                cmd.Parameters.Add(_Database.GetParameter("@EXE_STEP_ID", new Guid(EXE_STEP_ID)));
                cmd.Parameters.Add(_Database.GetParameter("@price", price));
                if (Pcount > 52)  //add by zouchihua 2015-6-27 武汉中心医院多了一个参数，为了兼容公司版本
                    cmd.Parameters.Add(_Database.GetParameter("@zfbl", zfbl));

                ((System.Data.IDataParameter)cmd.Parameters[35]).Direction = ParameterDirection.Output;
                int itemp = FrmMdiMain.Database.DoCommand(cmd);
                cmd.Dispose();
                return ((System.Data.IDataParameter)cmd.Parameters[35]).Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "插入错误");
                return "错误";
            }
        }
        #region 去多余的“0”
        public static decimal removeZero(decimal dc)
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
        #endregion

        /// <summary>
        /// 获得路径信息
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public static DataTable GetPathway(string dept_id, int Iscp)
        {
            string str = "    select a.bname fname,*,'' ts,'' fy from ( select count(*) gs,PATHWAY_name as bname from PATH_WAY where   MONOCONDITION=" + Iscp + " and isnull(DELETED,0)=0 and STATUS=21 and (DEPTID is null or DEPTID=" + dept_id + " or PATHWAY_ID in (select pathway_id from path_way_dept k where k.dept_id=" + dept_id + "))"
                       + " group by PATHWAY_name )  a left join (select * from PATH_WAY where 1=2) b on a.bname=b.PATHWAY_NAME "
                       + " union all "
                       + " select PATHWAY_NAME fname,1 gs ,cast(PATHWAY_ID as varchar(36)) bname  ,*,cast(MIN_DAYS as varchar)+'~'+cast(MAX_DAYS as varchar) ts,cast(MIN_AMOUNT as varchar)+'~'+cast(MAX_AMOUNT as varchar) fy "
                       + " from PATH_WAY where isnull(DELETED,0)=0 and MONOCONDITION=" + Iscp + "  and STATUS=21 and (DEPTID is null or DEPTID=" + dept_id + " or PATHWAY_ID in (select pathway_id from path_way_dept k where k.dept_id=" + dept_id + "))";
            DataTable tb = FrmMdiMain.Database.GetDataTable(str);
            return tb;
        }
        /// <summary>
        /// 获得路径信息
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public static DataTable GetPathway(int Iscp)
        {
            string str = "    select a.bname fname,*,'' ts,'' fy from ( select count(*) gs,PATHWAY_name as bname from PATH_WAY where   MONOCONDITION=" + Iscp + " and isnull(DELETED,0)=0 and STATUS=21 "
                       + " group by PATHWAY_name )  a left join (select * from PATH_WAY where 1=2) b on a.bname=b.PATHWAY_NAME "
                       + " union all "
                       + " select PATHWAY_NAME fname,1 gs ,cast(PATHWAY_ID as varchar(36)) bname  ,*,cast(MIN_DAYS as varchar)+'~'+cast(MAX_DAYS as varchar) ts,cast(MIN_AMOUNT as varchar)+'~'+cast(MAX_AMOUNT as varchar) fy "
                       + " from PATH_WAY where isnull(DELETED,0)=0 and MONOCONDITION=" + Iscp + "  and STATUS=21 ";
            DataTable tb = FrmMdiMain.Database.GetDataTable(str);
            return tb;
        }
        /// <summary>
        /// 获得路径适应诊断
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPathDisease()
        {
            DataTable tb = FrmMdiMain.Database.GetDataTable(" select a.*,b.PATHWAY_NAME from PATH_WAY_DISEASE a left join PATH_WAY b on a.PATHWAY_ID=b.PATHWAY_ID ");
            return tb;
        }
        public static DataTable GetPathwayRlueInfo(string pathway_id)
        {
            string str = "select  '' bz, 'False' [check],* from PATH_RULE_ITEM a left join PATH_RULE_DICT b on a.rule_id=b.rule_id where deleted=0 and b.apply_type in(0,1) and  a.PATHWAY_ID='" + pathway_id + "'";
            DataTable tb = FrmMdiMain.Database.GetDataTable(str);
            return tb;
        }
        /// <summary>
        /// 修改数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tb"></param>
        public static void databaseupdate(string sql, DataTable tb)
        {
            //数据更行到数据库
            System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection();
            connect.ConnectionString = FrmMdiMain.Database.ConnectionString;// " server=x6x8-20100320QL\\SQLEXPRESS;database=trasen_Emr_test;UID=sa;Password=sa8920993";
            connect.Open();
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
            adapter.SelectCommand = new System.Data.SqlClient.SqlCommand(sql, connect);
            System.Data.SqlClient.SqlCommandBuilder sqlcom = new System.Data.SqlClient.SqlCommandBuilder(adapter);
            //DataSet ds = new DataSet();

            //System.Data.SqlClient.SqlTransaction sqltra = connect.BeginTransaction();

            //adapter.TableMappings[0].ColumnMappings.Add("", "");
            // adapter.TableMappings.Add("df", "fdf");
            //adapter.Fill(ds);
            //ds.Tables[0].Rows[2]["note"] = "开户银行2";
            //ds.Tables[1].Rows[0]["bbid"] = 1;
            //tb.PrimaryKey = new DataColumn[] { tb.Columns["Bsid"] };
            //tb.Rows[0]["reason"] = "1";
            //tb.Rows[1]["reason"] = "1";
            //tb.Rows[2]["reason"] = "1";
            //tb.Columns["Bsid"].ColumnName = "path_step_item_id";
            //tb.Columns["Parent_id"].ColumnName = "step_item_kind_id";
            //tb.Columns["order_spec"].ColumnName = "notes";
            DataTable tbnew = tb.GetChanges(DataRowState.Modified);
            DataTable tbdel = tb.GetChanges(DataRowState.Deleted);


            adapter.InsertCommand = sqlcom.GetInsertCommand();
            adapter.DeleteCommand = sqlcom.GetDeleteCommand();
            adapter.UpdateCommand = sqlcom.GetUpdateCommand();
            int i = 0;
            if (tb.GetChanges() != null)
                i = adapter.Update(tb);
            tb.AcceptChanges();
            sqlcom.RefreshSchema();
            //tb.Columns["path_step_item_id"].ColumnName = "Bsid";
            //tb.Columns["step_item_kind_id"].ColumnName = "Parent_id";
            //tb.Columns["notes"].ColumnName = "order_spec";
            // sqltra.Commit();
            connect.Close();

        }
        /// <summary>
        /// 多表同时更新
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ds"></param>
        public static void databaseupdate(string[] sql, DataSet ds)
        {
            if (sql.Length != ds.Tables.Count)
            {
                throw new Exception(" sql语句与数据集表个数不匹配");
            }
            System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection();
            connect.ConnectionString = FrmMdiMain.Database.ConnectionString;
            connect.Open();
            //开始事物
            System.Data.SqlClient.SqlTransaction sqltra = connect.BeginTransaction();
            try
            {

                for (int i = 0; i < sql.Length; i++)
                {
                    databaseupdate(sql[i], ds.Tables[i], connect, sqltra);
                }
                sqltra.Commit();
            }
            catch (Exception ex)
            {
                sqltra.Rollback();
                throw new Exception("更新数据出错，原因:" + ex.Message);
            }

        }
        /// <summary>
        /// 修改数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tb"></param>
        private static void databaseupdate(string sql, DataTable tb, System.Data.SqlClient.SqlConnection connect, System.Data.SqlClient.SqlTransaction sqltra)
        {
            //数据更行到数据库

            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
            adapter.SelectCommand = new System.Data.SqlClient.SqlCommand(sql, connect);
            adapter.SelectCommand.Transaction = sqltra;//一定要加这句话，不然会报错
            System.Data.SqlClient.SqlCommandBuilder sqlcom = new System.Data.SqlClient.SqlCommandBuilder(adapter);


            DataTable tbnew = tb.GetChanges(DataRowState.Modified);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds);


            adapter.InsertCommand = sqlcom.GetInsertCommand();
            adapter.DeleteCommand = sqlcom.GetDeleteCommand();
            adapter.UpdateCommand = sqlcom.GetUpdateCommand();


            adapter.InsertCommand.Transaction = sqltra;
            adapter.DeleteCommand.Transaction = sqltra;
            adapter.UpdateCommand.Transaction = sqltra;
            int i = adapter.Update(tb);
            tb.AcceptChanges();
            sqlcom.RefreshSchema();
            // sqltra.Commit();
            //connect.Close();

        }
        public static DataTable GetPathBaseInfo(string pathway_id, string pathway_exeid)
        {
            string sql = "select *,cast(MIN_DAYS as varchar)+'~'+cast(MAX_DAYS as varchar) ts,cast(MIN_AMOUNT as varchar)+'~'+cast(MAX_AMOUNT as varchar) fy  "
               + " ,DATEDIFF(dd, b.DATE_BEGIN,GETDATE())+1 dqts,dbo.FUN_ZY_SEEKPATFEEINFO(b.INPATIENT_ID,0,0) dqfy  from "
                + " PATH_WAY a left join PATH_WAY_EXE b on a.PATHWAY_ID=b.PATHWAY_ID where a.PATHWAY_ID='" + pathway_id + "' and b.PATHWAY_EXE_ID='" + pathway_exeid + "'";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            return tb;
        }
        public static void UpdatePathWayStatus(RelationalDatabase rd, string pathway_exe_id, int status)
        {
            //1:进行中2:已完成3:退出4:暂停 ,
            string sql = "";
            if (status == 2 || status == 3)
                sql = "    update PATH_WAY_EXE set STATUS=" + status + ",DATE_END=getdate() where PATHWAY_EXE_ID='" + pathway_exe_id + "'";
            else
                sql = "    update PATH_WAY_EXE set STATUS=" + status + " where PATHWAY_EXE_ID='" + pathway_exe_id + "'";
            rd.DoCommand(sql);
        }
        public static void UpdatePathStepStatus(RelationalDatabase rd, string pathstep_exe_id, int status)
        {
            //2:进行中 1:已完成 
            string sql = "    update PATH_WAY_EXE_STEP set EXE_STATUS=" + status + " where EXE_STEP_ID='" + pathstep_exe_id + "'";
            rd.DoCommand(sql);
        }

        /// <summary>
        /// 获得路径外的医嘱
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <returns></returns>
        public static DataTable GetExtraOrder(string inpatient_id)
        {
            string sql = "select a.*,b.ORDER_BDATE,b.ORDER_CONTEXT,b.UNIT,b.FREQUENCY,b.NUM,b.ORDER_USAGE,b.ORDER_SPEC, "
             + " case when  MNGTYPE=0 then '长期' else '临时' end yzlx,NTYPE,DOSAGE,'' fz,group_id,dbo.fun_getEmpName(order_doc) orderdoc_name  "
             + ",case when MNGTYPE=0  then  FIRST_TIMES else null end firsttime,case when MNGTYPE=0  then  TERMINAL_TIMES else null end TERMINALtime "
             + ",case when MNGTYPE=0  then  ORDER_EDATE else null end ORDER_EDATE,case when MNGTYPE=0  then  dbo.fun_getEmpName(ORDER_EDOC) else null end ORDER_EDOC "
             + "  from Path_extraOrder a left join ZY_ORDERRECORD b on a.order_id=b.order_id where a.delete_bit=0  and a.inpatient_id='" + inpatient_id + "'  and b.DELETE_BIT=0 order by  MNGTYPE,group_id,SERIAL_NO ";
            //MessageBox.Show(sql);
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            return tb;
        }
        /// <summary>
        /// 获得阶段上下限时间
        /// </summary>
        /// <param name="step_id"></param>
        /// <returns></returns>
        public static int[] GetStepUpDowntime(string step_id)
        {
            int[] time = new int[] { 0, 0 };
            string sql = "select TIME_DOWN,TIME_UP from PATH_STEP where PATH_STEP_ID='" + step_id + "'";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                time[0] = int.Parse(tb.Rows[0]["TIME_DOWN"].ToString());
                time[1] = int.Parse(tb.Rows[0]["TIME_UP"].ToString());
            }
            return time;
        }
        /// <summary>
        /// 进入阶段时停医嘱
        /// </summary>
        /// <param name="next_step_id"></param>
        /// <param name="pathway_exe_id"></param>
        /// <param name="stoptime"></param>
        /// <param name="inpatietn_id"></param>
        public static void StopStepLogorder(string next_step_id, string pathway_exe_id, DateTime stoptime, Guid inpatietn_id)
        {
            stoptime = DateTime.Parse(stoptime.Date.ToString("yyy-MM-dd") + "  23:59:59");
            int[] UpdownTime = new int[2];
            //获得下阶段时间范围
            if (next_step_id == "")
                UpdownTime[0] = 999999;
            else
                UpdownTime = GetStepUpDowntime(next_step_id);
            //获得当前阶段执行了长期医嘱
            string sql = "select  CQYZTZTS,a.order_id,inpatient_id,GROUP_ID from path_itemexe a  join PATH_STEP_ITEM b on a.PATH_STEP_ITEM_ID=b.PATH_STEP_ITEM_ID  join ZY_ORDERRECORD c on c.ORDER_ID=a.order_id "
               + " where b.MNGTYPE=0 and a.PATHWAY_EXE_ID='" + pathway_exe_id + "' and a.status_flag=2 and a.delete_bit=0 ";
            DataTable stopLogorder = FrmMdiMain.Database.GetDataTable(sql);
            FrmMdiMain.Database.BeginTransaction();
            try
            {
                string oldgroup_id = "";
                for (int i = 0; i < stopLogorder.Rows.Count; i++)
                {
                    if (oldgroup_id != stopLogorder.Rows[i]["GROUP_ID"].ToString())
                    {
                        oldgroup_id = stopLogorder.Rows[i]["GROUP_ID"].ToString();
                        long Time = long.Parse(stopLogorder.Rows[i]["CQYZTZTS"].ToString());
                        //停时间只要小于于下个阶段的下限
                        if (Time < UpdownTime[0])
                        {
                            //停医嘱
                            StopOrders(FrmMdiMain.Database, FrmMdiMain.CurrentUser.EmployeeId, stoptime, -1, int.Parse(stopLogorder.Rows[i]["GROUP_ID"].ToString()), Guid.Empty, inpatietn_id, 0, 0);
                        }
                    }
                    else
                        continue;
                }
                FrmMdiMain.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                FrmMdiMain.Database.RollbackTransaction();
                throw ex;
            }
        }
        /// <summary>
        /// 获得要停止的医嘱
        /// </summary>
        /// <param name="next_step_id"></param>
        /// <param name="pathway_exe_id"></param>
        /// <param name="stoptime"></param>
        /// <param name="inpatietn_id"></param>
        /// <returns></returns>
        public static DataTable Getstoporder(string next_step_id, string pathway_exe_id, Guid inpatietn_id,bool lastStep)
        {

            int[] UpdownTime = new int[2];
            //获得下阶段时间范围
            if (next_step_id == "")
                UpdownTime[0] = 999999;
            else
                UpdownTime = GetStepUpDowntime(next_step_id);
            //最后阶段都要停
            if (lastStep)
                UpdownTime[0] = 0;
            //获得当前阶段执行了长期医嘱
            string sql = "select 'true' [check],'' fz,isnull(CQYZTZTS,999999) CQYZTZTS,a.*,c.*,SUBSTRING( d.NAME,CHARINDEX('-',d.NAME,0)+1,LEN(d.name)) ordertype,0  stoptype,null TERMINALTIMES,getdate() ORDEREDATE from path_itemexe a  join PATH_STEP_ITEM b on a.PATH_STEP_ITEM_ID=b.PATH_STEP_ITEM_ID  join ZY_ORDERRECORD c on c.ORDER_ID=a.order_id "
                + " left join jc_ordertype d on c.ntype=d.code "
               + " where b.MNGTYPE=0  and c.status_flag=2 and c.delete_bit=0 and a.PATHWAY_EXE_ID='" + pathway_exe_id + "'  order by group_id";//       and a.PATHWAY_EXE_ID='" + pathway_exe_id + "'//正式库时呀把条件放进去
            //MessageBox.Show(sql);
            DataTable stopLogorder = FrmMdiMain.Database.GetDataTable(sql);
            //测试 
            //return stopLogorder;

            try
            {
                int j = 0;
                for (int i = 0; i - j < stopLogorder.Rows.Count; i++)
                {

                    long Time = long.Parse(stopLogorder.Rows[i - j]["CQYZTZTS"].ToString());
                    //停时间只要小于于下个阶段的下限
                    if (Time < UpdownTime[0])
                    {
                        //停医嘱
                        //StopOrders(FrmMdiMain.Database, FrmMdiMain.CurrentUser.EmployeeId, stoptime, -1, int.Parse(stopLogorder.Rows[i]["GROUP_ID"].ToString()), Guid.Empty, inpatietn_id, 0, 0);
                    }
                    else
                    {
                        stopLogorder.Rows.Remove(stopLogorder.Rows[i - j]);
                        j++;
                    }
                }
                return stopLogorder;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 获得要停止的医嘱
        /// </summary>
        /// <param name="next_step_id"></param>
        /// <param name="pathway_exe_id"></param>
        /// <param name="stoptime"></param>
        /// <param name="inpatietn_id"></param>
        /// <returns></returns>
        public static DataTable GetstoporderEx(string next_step_id, string pathway_exe_id, Guid inpatietn_id, bool lastStep)
        {

            int[] UpdownTime = new int[2];
            //获得下阶段时间范围
            if (next_step_id == "")
                UpdownTime[0] = 999999;
            else
                UpdownTime = GetStepUpDowntime(next_step_id);
            //最后阶段都要停
            if (lastStep)
                UpdownTime[0] = 0;
            //获得当前阶段执行了长期医嘱
            string sql = "select 'true' [check],'' fz,isnull(CQYZTZTS,999999) CQYZTZTS,a.*,c.*,SUBSTRING( d.NAME,CHARINDEX('-',d.NAME,0)+1,LEN(d.name)) ordertype,0  stoptype,null TERMINALTIMES,getdate() ORDEREDATE from path_itemexe a  join PATH_STEP_ITEM b on a.PATH_STEP_ITEM_ID=b.PATH_STEP_ITEM_ID  join ZY_ORDERRECORD c on c.ORDER_ID=a.order_id "
                + " left join jc_ordertype d on c.ntype=d.code "
               + " where b.MNGTYPE=0  and c.status_flag=2 and c.delete_bit=0 and a.PATHWAY_EXE_ID='" + pathway_exe_id + "'  order by group_id";//and a.PATHWAY_EXE_ID='" + pathway_exe_id + "'//正式库时呀把条件放进去
            //MessageBox.Show(sql);
            DataTable stopLogorder = FrmMdiMain.Database.GetDataTable(sql);

            return stopLogorder;


        }
        /// <summary>
        /// 停一组医嘱
        /// </summary>
        /// <param name="DocID">操作医生ID</param>
        /// <param name="dtime">停嘱时间</param>
        /// <param name="EndNum">末日次数</param>
        /// <param name="GroupNum">医嘱组号</param>
        /// <param name="InpatientID">病人ID</param>
        /// <param name="BabyID">婴儿ID</param>
        /// <param name="sign">0=停一组医嘱记录,1=取消停一组医嘱，2=停一组中的一条记录，3=取消停一条记录</param>
        /// <returns></returns>
        public static int StopOrders(RelationalDatabase database, long DocID, DateTime dtime, int EndNum, long GroupNum, Guid OrderId, Guid InpatientID, long BabyID, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[8];
            parameters[0].Value = DocID;
            parameters[0].Text = "@DOC";
            parameters[1].Value = dtime;
            parameters[1].Text = "@DATE";
            parameters[2].Value = EndNum;
            parameters[2].Text = "@ENDNUM";
            parameters[3].Value = GroupNum;
            parameters[3].Text = "@GROUPNUM";
            parameters[4].Value = OrderId;
            parameters[4].Text = "@ORDER_ID";
            parameters[5].Value = InpatientID;
            parameters[5].Text = "@INPATIENTID";
            parameters[6].Value = BabyID;
            parameters[6].Text = "@BABYID";
            parameters[7].Value = sign;
            parameters[7].Text = "@SIGN";
            try
            {
                return database.DoCommand("SP_ZYYS_STOP_GROUP1", parameters, 20);
            }
            catch (Exception err)
            {
                throw err;
                return -1;
            }
        }
        /// <summary>
        /// 判断是否进入下个阶段
        /// </summary>
        /// <param name="INtopathtime"></param>
        /// <param name="_path_step_id"></param>
        /// <param name="sysdate"></param>
        /// <returns></returns>
        public static bool CheckIsIntoNextstep(DateTime INtopathtime, string _path_step_id, DateTime sysdate, string _path_step_exe_id)
        {
            //控制进入下阶段时间点（恰好当天结束本阶段时）
            SystemCfg cfg18002 = new SystemCfg(18002);
            int Kzsjd = int.Parse(cfg18002.Config);

            DateTime Intopath = INtopathtime;
            int[] UpdownTime = PublicFunction.GetStepUpDowntime(_path_step_id);
            TimeSpan ts1 = new TimeSpan(sysdate.Date.Ticks);
            TimeSpan ts2 = new TimeSpan(Intopath.Date.Ticks);
            int days = ts1.Subtract(ts2).Days + 1;//现在是进入路径的第几天
            int cursetpday = UpdownTime[1] / 1440;//当前阶段是第几天结束
            if (days >= cursetpday)//现在入径天数大于当前路径结束天数
            {
                if (days == cursetpday)//如果是当天就必须是19以后
                {
                    if (sysdate.Hour > Kzsjd)
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
            else
            {
                //如果进入改阶段的天数，大于阶段间隔
                int jg = (UpdownTime[1] - UpdownTime[0]) / 1440;
                string sqlstep = "select DATEDIFF(dd, BEGIN_DATE,GETDATE())+1 jrsd from PATH_WAY_EXE_STEP where EXE_STEP_ID='" + _path_step_exe_id + "'";
                DataTable tb = FrmMdiMain.Database.GetDataTable(sqlstep);
                if (tb.Rows.Count > 0)
                {
                    if (int.Parse(tb.Rows[0]["jrsd"].ToString()) >= jg)//如果进入阶段的天数，大于阶段间隔
                    {
                        if (int.Parse(tb.Rows[0]["jrsd"].ToString()) == jg)//如果是当天就必须是19以后
                        {
                            if (sysdate.Hour > Kzsjd)
                                return true;
                            else
                                return false;
                        }
                        else
                            return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
            //GCCollect();
        }
        /// <summary>
        /// GC回收资源
        /// </summary>
        public static void GCCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        /// <summary>
        /// 获得不执行原因基础表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUnexeReason()
        {
            try
            {
                DataTable tb = FrmMdiMain.Database.GetDataTable("select * from  PATH_UNEXE_REASON where delete_bit=0 and ntype=0 ");
                return tb;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 当触发控件为文本框或者组合框时设定选项网格的上边距与左边距
        /// </summary>
        /// <param name="occurTextBox">触发文本框</param>
        /// <param name="cardGrid">选项网格</param>
        /// <param name="parentCtrl">父级控件</param>
        /// <param name="oppositeTop">在父控件中的相对纵坐标</param>
        /// <param name="oppositeLeft">在父控件中的相对横坐标</param>
        public static void SetCardGridTopAndLeft(Control occurTextBox, DataGridView cardGrid, Control parentCtrl, int oppositeTop, int oppositeLeft)
        {
            try
            {
                //将网格放在触发文本框上面或下面都不合适
                if (parentCtrl.Height < cardGrid.Height + occurTextBox.Height + oppositeTop && oppositeTop < cardGrid.Height)
                {
                    #region 高度不适合
                    if (parentCtrl.Parent != null)
                    {
                        SetCardGridTopAndLeft(occurTextBox, cardGrid, parentCtrl.Parent, oppositeTop + parentCtrl.Top, oppositeLeft + parentCtrl.Left);
                    }
                    #endregion
                }
                else
                {
                    #region 高度适合
                    try
                    {
                        cardGrid.Parent = parentCtrl;//设置父控件
                        cardGrid.BringToFront();
                    }
                    catch
                    {
                        cardGrid.Parent = parentCtrl.Parent.Parent;
                        cardGrid.BringToFront();
                    }
                    if (parentCtrl.Height < cardGrid.Height + occurTextBox.Height + oppositeTop)		//如果其下边界超出父容器底边界则底部与父容器底边界对齐
                    {
                        cardGrid.Top = oppositeTop - cardGrid.Height;
                    }
                    else
                    {
                        cardGrid.Top = oppositeTop + occurTextBox.Height;
                    }
                    if (parentCtrl.Width < cardGrid.Width + oppositeLeft)
                    {
                        cardGrid.Left = oppositeLeft - (cardGrid.Width - occurTextBox.Width);
                        if (cardGrid.Left < 0)	//宽度不适合
                        {
                            if (parentCtrl.Parent != null)
                            {
                                SetCardGridTopAndLeft(occurTextBox, cardGrid, parentCtrl.Parent, oppositeTop + parentCtrl.Top, oppositeLeft + parentCtrl.Left);
                            }
                        }
                    }
                    else
                    {
                        cardGrid.Left = oppositeLeft;
                    }
                    #endregion
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 获得变异的理由
        /// </summary>
        public static DataTable GetVARIANTReason()
        {

            string sql = "select 1  [values],a.VARIANT_TYPE_ID,b.REASON '变异理由',a.VARIANT_TYPE_NAME '理由类型',case when  b.Ntype =1  then '正变异' else '负变异' end 变异类型 from PATH_VARIANT_TYPE a join PATH_REASON b  on a.VARIANT_TYPE_ID=b.VARIANT_TYPE_ID  where a.VARIANT_TYPE_ID=b.VARIANT_TYPE_ID";
            return FrmMdiMain.Database.GetDataTable(sql);
        }
    }
}
