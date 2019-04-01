using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
namespace ts_mz_class
{
    /// <summary>
    /// ComboBox处理类，用于把常用的基础数据填充到控件内
    /// </summary>
    public class FunAddComboBox
    {
        /// <summary>
        /// 添加病人类型下拉列表
        /// </summary>
        /// <param name="all">是否添加子项目[全部]</param>
        /// <param name="brlx">病人类型</param>
        /// <param name="cmb">下拉列表控件</param>
        public static void AddBrlx(bool all, int brlx, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (brlx == 0)
                ssql = "select CODE,NAME from JC_BRLX order by defaults desc";
            else
                ssql = "select CODE,NAME from JC_BRLX where CODE=" + brlx;
            DataTable tb = _DataBase.GetDataTable(ssql);

            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["code"] = "0";
                row["name"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }

            cmb.ValueMember = "CODE";
            cmb.DisplayMember = "NAME";
            cmb.DataSource = tb;

        }
        public static void AddBrlx(bool all, int brlx, System.Windows.Forms.ComboBox cmb)
        {
            string ssql = "";
            if (brlx == 0)
                ssql = "select CODE,NAME from JC_BRLX order by defaults desc";
            else
                ssql = "select CODE,NAME from JC_BRLX where CODE=" + brlx;
            DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(ssql);

            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["code"] = "0";
                row["name"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }

            cmb.ValueMember = "CODE";
            cmb.DisplayMember = "NAME";
            cmb.DataSource = tb;

        }


        /// <summary>
        /// 添加挂号类型下拉列表
        /// </summary>
        /// <param name="all">是否添加子项目[全部]</param>
        /// <param name="ghlx">挂号类型</param>
        /// <param name="cmb">下拉列表控件</param>
        public static void AddGhlx(bool all, int ghlx, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (ghlx == 0)
                ssql = "select GHLX,GHLXMC from jc_ghlx order by XH";
            else
                ssql = "select GHLX,GHLXMC from jc_ghlx where GHLX=" + ghlx;
            DataTable tb = _DataBase.GetDataTable(ssql);

            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["GHLX"] = "0";
                row["GHLXMC"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }

            cmb.ValueMember = "GHLX";
            cmb.DisplayMember = "GHLXMC";
            cmb.DataSource = tb;

        }

        /// <summary>
        /// 添加卡类型下拉列表
        /// </summary>
        /// <param name="all">是否添加子项目[全部]</param>
        /// <param name="klx">卡类型</param>
        /// <param name="cmb">下拉列表控件</param>
        public static void AddKlx(bool all, int klx, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (klx == 0)
                ssql = "select KLX,KLXMC from JC_KLX where bqybz=1 order by XH";
            else
                ssql = "select KLX,KLXMC from JC_KLX where  bqybz=1  and klx=" + klx;
            DataTable tb = _DataBase.GetDataTable(ssql);

            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["KLX"] = "0";
                row["KLXMC"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }

            cmb.ValueMember = "KLX";
            cmb.DisplayMember = "KLXMC";
            cmb.DataSource = tb;

        }
        public static void AddKlx(bool all, int klx, System.Windows.Forms.ComboBox cmb)
        {
            string ssql = "";
            if (klx == 0)
                ssql = "select KLX,KLXMC from JC_KLX where bqybz=1 order by XH";
            else
                ssql = "select KLX,KLXMC from JC_KLX where  bqybz=1  and klx=" + klx;
            DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(ssql);

            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["KLX"] = "0";
                row["KLXMC"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }

            cmb.ValueMember = "KLX";
            cmb.DisplayMember = "KLXMC";
            cmb.DataSource = tb;

        }

        /// <summary>
        /// 添加挂号级别类型下拉列表
        /// </summary>
        /// <param name="all">是否添加子项目[全部]</param>
        /// <param name="ghjb">挂号级别</param>
        /// <param name="cmb">下拉列表控件</param>
        public static void AddGhjb(bool all, int ghjb, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (ghjb == 0)
                ssql = "SELECT TYPE_ID,idqz + '-'+ type_name AS TYPENAME from jc_doctor_type order by type_id";
            else
                ssql = "SELECT TYPE_ID,idqz + '-'+ type_name AS TYPENAME from jc_doctor_type where type_id=" + ghjb;
            DataTable tb = _DataBase.GetDataTable(ssql);

            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["TYPE_ID"] = "0";
                row["TYPENAME"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }

            cmb.ValueMember = "TYPE_ID";
            cmb.DisplayMember = "TYPENAME";
            cmb.DataSource = tb;

        }
        //获取挂号职称 Add by zp 2013-12-16
        public static void AddZcjb(bool all, int ghjb, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (ghjb == 0)
                ssql = "SELECT zcjb,idqz + '-'+ type_name AS TYPENAME from jc_doctor_type order by zcjb";
            else
                ssql = "SELECT zcjb,idqz + '-'+ type_name AS TYPENAME from jc_doctor_type where zcjb=" + ghjb;
            DataTable tb = _DataBase.GetDataTable(ssql);

            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["zcjb"] = "0";
                row["TYPENAME"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }

            cmb.ValueMember = "zcjb";
            cmb.DisplayMember = "TYPENAME";
            cmb.DataSource = tb;

        }

        /// <summary>
        /// 添加医保类型下拉列表
        /// </summary>
        /// <param name="all">是否添加子项目[全部]</param>
        /// <param name="YBLX">医保类型</param>
        /// <param name="cmb">下拉列表控件</param>
        public static void AddYblx(bool all, int YBLX, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (YBLX == 0)
                ssql = "SELECT ID,NAME FROM JC_YBLX where delete_bit=0  ORDER BY defaults ,ybjklx,id";
            else
                ssql = "SELECT ID,NAME FROM JC_YBLX where ID=" + YBLX + " ORDER BY defaults,ID";
            DataTable tb = _DataBase.GetDataTable(ssql);

            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["ID"] = "0";
                row["name"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }

            cmb.ValueMember = "ID";
            cmb.DisplayMember = "NAME";
            cmb.DataSource = tb;

        }


        /// <summary>
        /// 添加性别下拉列表
        /// </summary>
        public static void Addxb(bool all, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            //cmb.Items.Add("男");
            //cmb.Items.Add("女");
            //cmb.Items.Add("未知");
            //cmb.SelectedIndex = 0;
            string ssql = "select code,name from JC_SEXCODE";
            DataTable tb = _DataBase.GetDataTable(ssql);
            DataRow row = tb.NewRow();
            if (all == true)
            {
                row["code"] = "0";
                row["name"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.DisplayMember = "name";
            cmb.ValueMember = "code";
            cmb.DataSource = tb;
        }

        //添加收费操作员
        public static void AddOperator(bool all, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            //Modify By Zj 2012-04-18 添加人员类型8 自助终端
            string sql = @"select employee_id,name from jc_employee_property where rylx in (3,8)
                        and employee_id in(select employee_id from JC_EMP_DEPT_ROLE a ,jc_dept_property b 
                        where a.dept_id=b.dept_id and (b.jgbm is null or b.jgbm<=0  or b.jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " ) )  order by NAME ";
            DataTable tb = _DataBase.GetDataTable(sql);
            DataRow row = tb.NewRow();
            if (all == true)
            {
                row["employee_id"] = "0";
                row["name"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.DisplayMember = "name";
            cmb.ValueMember = "employee_id";
            cmb.DataSource = tb;
        }
        /// <summary>
        /// 初始化合同类型下拉列表
        /// </summary>
        /// <param name="all">是否添加"全部"</param>
        /// <param name="cmb">下拉控件</param>
        /// <param name="_DataBase">数据操作类对象</param>
        public static void AddTypeOfContract(bool all, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string sql = @"select ID,LXMC from JC_HTDWLX where BQYBZ='1'  order by ID ";
            DataTable tb = _DataBase.GetDataTable(sql);
            DataRow row = tb.NewRow();
            if (all == true)
            {
                row["ID"] = "0";
                row["LXMC"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.DisplayMember = "LXMC";
            cmb.ValueMember = "ID";
            cmb.DataSource = tb;
        }
        /// <summary>
        /// 初始化合同单位
        /// </summary>
        /// <param name="all">是否添加"全部"</param>
        /// <param name="cmb">下拉控件</param>
        /// <param name="_DataBase">数据操作类对象</param>
        public static void AddCpyOFContract(bool all, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string sql = @"select ID,DWMC,PYM,WBM from JC_HTDW where BQYBZ='1'  order by ID ";
            DataTable tb = _DataBase.GetDataTable(sql);
            DataRow row = tb.NewRow();
            if (all == true)
            {
                row["ID"] = "0";
                row["DWMC"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.DisplayMember = "DWMC";
            cmb.ValueMember = "ID";
            cmb.DataSource = tb;
        }
        
        /// <summary>
        /// 添加收费操作员 根据时间点来
        /// </summary>
        /// <param name="all"></param>
        /// <param name="cmb"></param>
        /// <param name="_DataBase"></param>
        public static void AddOperatorDate(bool all, System.Windows.Forms.ComboBox cmb, string BeginDatetime, string EndDatetime, RelationalDatabase _DataBase)
        {
            //查询卡登记表的收费员
            string ssql = @"select employee_id,name from ( select employee_id,name from jc_employee_property where rylx in (3,8) and 
                            employee_id in(select employee_id from JC_EMP_DEPT_ROLE a ,jc_dept_property b where a.dept_id=b.dept_id 
                            and (b.jgbm is null or b.jgbm<=0  or b.jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + @") and employee_id in
                             (select djy from yy_kdjb where klx = 1 and djsj >= '" + BeginDatetime + "' and djsj <= '" + EndDatetime + "' ) ) ";
            //查询发票表的收费员
            ssql += @" union all 
                         select employee_id,name from jc_employee_property where rylx in (3,8) and employee_id in 
                         (select employee_id from jc_emp_dept_role a,jc_dept_property b where a.dept_id = b.dept_id and (b.jgbm is null or b.jgbm <= 0 or b.jgbm = " + TrasenFrame.Forms.FrmMdiMain.Jgbm + @") 
                         and employee_id in (select sfy from mz_fpb where sfrq >= '" + BeginDatetime + "' and sfrq <= '" + EndDatetime + "')))  emp group by employee_id,name";
            DataTable tb = _DataBase.GetDataTable(ssql);
            DataRow row = tb.NewRow();
            if (all == true)
            {
                row["employee_id"] = "0";
                row["name"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.DisplayMember = "name";
            cmb.ValueMember = "employee_id";
            cmb.DataSource = tb;
        }
        //添加机构编码
        public static void AddJgbm(bool all, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string sql = "";
            sql = "SELECT name FROM   sysobjects  WHERE  name = N'VI_JC_JGBM'  AND type = 'V'";
            DataTable tab = _DataBase.GetDataTable(sql);
            if (tab.Rows.Count == 0)
            {
                sql = "select jgbm,jgmc from jc_jgbm where yybm>0 ";
            }
            else
                sql = "select jgbm,jgmc from vi_jc_jgbm";
            DataTable tb = _DataBase.GetDataTable(sql);
            DataRow row = tb.NewRow();
            if (all == true)
            {
                row["jgbm"] = "0";
                row["jgmc"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            tb.TableName = "tb";
            cmb.DisplayMember = "jgmc";
            cmb.ValueMember = "jgbm";
            cmb.DataSource = tb;
        }

        //添加优惠方案
        public static void AddYhfa(int klx, Guid kdjid, int brlx, int yblx, int htdwlx, string funname, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            ParameterEx[] parameters = new ParameterEx[6];
            parameters[0].Text = "@klx";
            parameters[0].Value = klx;

            parameters[1].Text = "@kdjid";
            parameters[1].Value = kdjid;

            parameters[2].Text = "@brlx";
            parameters[2].Value = brlx;

            parameters[3].Text = "@yblx";
            parameters[3].Value = yblx;

            parameters[4].Text = "@htdwlx";
            parameters[4].Value = htdwlx;

            parameters[5].Text = "@funname";
            parameters[5].Value = funname;

            DataTable tb = _DataBase.GetDataTable("SP_MZSF_GETYHLX", parameters, 30);
            cmb.ValueMember = "id";
            cmb.DisplayMember = "yhmc";
            cmb.DataSource = tb;

        }

        //添加国家编码
        public static void AddGj(bool all, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string sql = "select code,name from JC_COUNTRYC order by DEFAULTS desc";
            DataTable tb = _DataBase.GetDataTable(sql);
            DataRow row = tb.NewRow();
            if (all == true)
            {
                row["code"] = "0";
                row["name"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.DisplayMember = "name";
            cmb.ValueMember = "code";
            cmb.DataSource = tb;
        }

        //添加民族编码
        public static void AddMz(bool all, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string sql = "select code as code,name from JC_NATIONCO order by ORDERS desc";
            DataTable tb = _DataBase.GetDataTable(sql);
            DataRow row = tb.NewRow();
            if (all == true)
            {
                row["code"] = "0";
                row["name"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.DisplayMember = "name";
            cmb.ValueMember = "code";
            cmb.DataSource = tb;
        }
        //添加婚姻况编码
        public static void AddHk(bool all, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string sql = "select code,name from JC_MARITALS  ";
            DataTable tb = _DataBase.GetDataTable(sql);
            DataRow row = tb.NewRow();
            if (all == true)
            {
                row["code"] = "0";
                row["name"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.DisplayMember = "name";
            cmb.ValueMember = "code";
            cmb.DataSource = tb;
        }

        //添加合同单位类型
        public static void AddHtdwLx(bool all, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string sql = "select id,lxmc from JC_HTDWLX where bqybz=1 ";
            DataTable tb = _DataBase.GetDataTable(sql);
            DataRow row = tb.NewRow();
            if (all == true)
            {
                row["id"] = "0";
                row["lxmc"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.DisplayMember = "lxmc";
            cmb.ValueMember = "id";
            cmb.DataSource = tb;
        }
        //添加科室 Add By Zj 2012-08-01
        /// <summary>
        /// 添加科室
        /// </summary>
        /// <param name="all">是否显示全部</param>
        /// <param name="type">0 显示全部 1门诊 2住院</param>
        /// <param name="cmb"></param>
        /// <param name="_DataBase"></param>
        public static void AddDept(bool all, int type, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string sql = "SELECT DEPT_ID,NAME FROM JC_DEPT_PROPERTY WHERE LAYER=3 AND JGBM=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " ";
            switch (type)
            {
                case 1:
                    sql += " AND (MZ_FLAG=1 OR JZ_FLAG=1 OR YJ_FLAG=1)";
                    break;
                case 2:
                    sql += " AND (ZY_FLAG=1  OR YJ_FLAG=1)";
                    break;
                default:
                    break;
            }
            DataTable tb = _DataBase.GetDataTable(sql);
            DataRow row = tb.NewRow();
            if (all == true)
            {
                row["DEPT_ID"] = "0";
                row["NAME"] = "全部";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.DisplayMember = "NAME";
            cmb.ValueMember = "DEPT_ID";
            cmb.DataSource = tb;
        }
    }
}
