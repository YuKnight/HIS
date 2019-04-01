using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
 
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using Ts_Clinicalpathway_Factory;
namespace Ts_Clinicalpathway_Factory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string sql = "select '-1' fname,NAME bname,NAME name,'' inpatient_no, '' bed_no,'' sex_name,null age ,null in_date,name CUR_DEPT_NAME,'' ward_name,null order_bw,null order_bz "
                      + "  from JC_DEPT_PROPERTY where ZY_FLAG=1 and DEPT_ID in (select DEPT_ID  from JC_DEPT_TYPE_RELATION where  TYPE_CODE=004) "
                      + "  union all    "
                      + "    select CUR_DEPT_NAME fname,CONVERT(  varchar(36),NEWID())  bname,NAME,INPATIENT_NO,BED_NO,SEX_NAME,AGE,IN_DATE,CUR_DEPT_NAME,WARD_NAME,ORDER_BW,ORDER_BZ from VI_ZY_VINPATIENT_BED  "
                      + "  -- where (ORDER_BW is not null or ORDER_BZ is not null)   ";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);

            this.DgvpatInfo.AutoGenerateColumns = false;
            //this.DgvpatInfo.Columns.Clear();
            //初始化dgv
            string[] Columname = new string[] { "姓名", "住院号", "床号", "性别", "年龄", "入院日期", "科室", "病区", "病危", "病重" };
            string[] Values = new string[] { "name", "INPATIENT_NO", "BED_NO", "SEX_NAME", "AGE", "IN_DATE", "CUR_DEPT_NAME", "WARD_NAME", "ORDER_BW", "ORDER_BZ" };
            int[] colwidth = new int[] { 120, 90, 40, 40, 40, 120, 120, 120, 100, 100 };
            bool[] readonly1 = new bool[] { true, true, true, true, true, true, true, true, true, true };
            string[] Coltype = new string[]{PublicFunction.DgvColStype.GroupColumn
            ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
            ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
                ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
           };
            PublicFunction.InitDgv(Columname, colwidth, Coltype, Values, this.DgvpatInfo, 1);
            this.DgvpatInfo.AutoGenerateColumns = false;
            this.DgvpatInfo.DataSource = tb;

            PublicFunction.GruopShow(tb, "fname='-1'", "bname", this.DgvpatInfo, "fname", this.DgvpatInfo.groupColumIndex, this.DgvpatInfo.Iszlfb);
        }
    }
}