using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trasen.DbAcc;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using ts_mz_class;

namespace ts_mz_rizhi
{
    public partial class FrmMzrzCx : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        public FrmMzrzCx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent; 
            this.Text = _chineseName;

            dtBegin.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 0:00:00"));
        } 

        private void btnFind_Click(object sender, EventArgs e)
        {
            string wherestr = "";
            if (this.tx_mzh.Text.Trim() != "")
            {
                wherestr += "and mg.blh like  '%" + this.tx_mzh.Text.Trim().Replace("*", "%") + "%'";
            }
            if (this.txtDept.SelectedValue  != null )
            {
                wherestr += " and  mj.JSKSDM=" + this.txtDept.SelectedValue.ToString();
            } 
            if (this.tx_brxm.Text.Trim() != "")
            {
                wherestr += "and yb.brxm like'%" + this.tx_brxm.Text.Trim().Replace("*", "%") + "%' or yb.pym like '%" + this.tx_brxm.Text.Trim().Replace("*", "%") + "%'  or yb.wbm like '%" + this.tx_brxm.Text.Trim().Replace("*", "%") + "%'";
            }
            if (this.cmbDtType.Text.Trim() == "挂号时间")
            {
                if (this.dtBegin.Text.Trim() != "" && this.dtEnd.Text.Trim() != "")
                {
                    wherestr += " and mm.ghsj >= '" + this.dtBegin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'  and  mm.ghsj < '" + this.dtEnd.Value.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }
            }
            if (this.cmbDtType.Text.Trim() == "接诊时间")
            {
                if (this.dtBegin.Text.Trim() != "" && this.dtEnd.Text.Trim() != "")
                {
                    wherestr += " and mj.jssj >= '" + this.dtBegin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'  and mj.jssj < '" + this.dtEnd.Value.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }
            }
            if (this.cmbDtType.Text.Trim() == "诊断时间")
            {
                if (this.dtBegin.Text.Trim() != "" && this.dtEnd.Text.Trim() != "")
                {
                    wherestr += " and mm. zdsj >= '" + this.dtBegin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'  and   mm.zdsj < '" + this.dtEnd.Value.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }
            }
            QueryData(wherestr);
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetData(string strWhere)
        {
            DataTable dt = new DataTable();
            return dt;
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString();
        }

        private void FrmMzrzCx_Load(object sender, EventArgs e)
        {
            this.dgvList.AutoGenerateColumns = false;

           

            AddEventForKeyDown();
            this.dtBegin.Value = DateTime.Today;
            cmbDtType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.WindowState = FormWindowState.Maximized;
            //DataTable dtklx = DbOpt.GetDataTable("select KLX CODE,KLXMC NAME,isnull(KCD,0) KCD from JC_KLX");
            ////cmbKlx.DisplayMember = "NAME"; cmbKlx.ValueMember = "CODE"; cmbKlx.DataSource = dtklx.Copy();
            //klx.DisplayMember = "NAME";
            //klx.ValueMember = "CODE";
            //klx.DataSource = dtklx.Copy();

            //职业
            //string strSqlzy = @"select code as CODE,name as NAME,py_code as PY,wb_code as WB from JC_OCCUPATI ";
            //DataTable dtzy = DbOpt.GetDataTable(strSqlzy);
            //zy.DisplayMember = "NAME";
            //zy.ValueMember = "CODE";
            //zy.DataSource = dtzy.Copy();
            //// 分级
            //string strfenji = @"select cast(1 as tinyint) CODE,'1级' NAME union all  select cast(2 as tinyint) CODE,'2级' NAME union all  select cast(3 as tinyint) CODE,'3级' NAME ";
            //DataTable dtfenji = Trasen.DbAcc.DbOpt.GetDataTable(strfenji);
            //fenji.DisplayMember = "NAME";
            //fenji.ValueMember = "CODE";
            //fenji.DataSource = dtfenji.Copy();
            ////发热
            //string strSqlfr = @"select cast(0 as tinyint) CODE,'是' NAME  union all select cast(1 as tinyint) CODE, '否' NAME";
            //DataTable dtfr = DbOpt.GetDataTable(strSqlfr);
            //sffr.DisplayMember = "NAME";
            //sffr.ValueMember = "CODE";
            //sffr.DataSource = dtfr.Copy();
            ////初/复诊
            //string strcfz = @"select cast(0 as tinyint )CODE,'初诊' NAME union all  select cast(1  as tinyint)CODE,'复诊' NAME ";
            //DataTable dtcfz = InstanceForm.BDatabase.GetDataTable(strcfz);
            //cfz.DisplayMember = "NAME";
            //cfz.ValueMember = "CODE";
            //cfz.DataSource = dtcfz.Copy();
            //科室1  把
            string strSqlks1 = @"select DEPT_ID AS CODE, NAME,PY_CODE as PY ,WB_CODE as WB from  JC_DEPT_PROPERTY  where LAYER=3";
            DataTable dtks1 = DbOpt.GetDataTable(strSqlks1);
            txtDept.ShowCardProperty[0].ShowCardDataSource = dtks1;
            txtDept.DisplayMember = "NAME";
            txtDept.ValueMember = "CODE";
            //deptid.DisplayMember = "NAME";
            //deptid.ValueMember = "CODE";
            //deptid.DataSource = dtks1.Copy();

            this.dtBegin.Value = new DateTime(this.dtBegin.Value.Year, this.dtBegin.Value.Month, this.dtBegin.Value.Day, 00, 00, 00);
            this.dtEnd.Value = new DateTime(this.dtEnd.Value.Year, this.dtEnd.Value.Month, this.dtEnd.Value.Day, 23, 59, 59);

        
            // cmbKlx.SelectedIndex = 1;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void QueryData(string wherestr)
        {
            string str = @"SELECT
                                                ' ' 序号,
                                                mg.blh,
                                                yb.brxm,
                                                (
                                                CASE
                                                    WHEN yb.xb = 1 THEN '男'
                                                    WHEN yb.xb = 2 THEN '女'
                                                    ELSE '未知'
                                                END
                                                ) xb,
                                                yb.csrq,
                                                mm.jzrq ,
                                                mj.JSSJ,
                                                dbo.fun_getDeptname(mj.JSKSDM) ksname,
                                                mj.JSKSDM,
                                                dbo.fun_getEmpName(mj.JSYSDM) ysname,
                                                mj.JSYSDM,
                                                mm.lxdh,
                                                mm.xzdz,
                                               	(SELECT yk.KH FROM YY_KDJB AS yk WHERE mg.KDJID = yk.KDJID) kahao,
                                                  (select  NAME   from JC_OCCUPATI where CODE =mm.zy) as zy,               
                                                mg.GHSJ,
                                                 mm.jzxm ,            
                                                    CASE WHEN mm.tiwen = 0 THEN NULL ELSE mm.tiwen END tiwen,         
                                                    CASE WHEN mm.xueya = 0 THEN NULL ELSE mm.xueya END xueya,      
                                                    CASE WHEN mm.maibo = 0 THEN NULL ELSE mm.maibo END maibo,          
                                                                 mm.yxjb ,  
                                                                        (  CASE
                                                    WHEN mm.fenji = 1 THEN '1级'
                                                    WHEN mm.fenji = 2 THEN '2级'
                                                   WHEN mm.fenji = 3 THEN '3级'
                                                END )           
                                                                fenji  ,          
                                                             mm. fbrq ,             
                                                              mm.zdsj ,             
                                                               mm.lxbxjcs, 
                                                               (  CASE
                                                    WHEN mm.cfz = 0 THEN '初诊'
                                                    WHEN mm.cfz = 1 THEN '复诊'
                                                   
                                                END )cfz,               
                                                           mm.crbyq ,           
                                                                         mm.bgr ,              
                                                                    CASE WHEN mm.xinlv = 0 THEN NULL ELSE mm.xinlv END xinlv,            
                                                                      CASE WHEN mm.huxi = 0 THEN NULL ELSE mm.huxi END huxi,             
                                                                      CASE WHEN mm.ssy = 0 THEN NULL ELSE mm.ssy END ssy,           
                                                                  mm.yishi ,   
                                                                  CASE WHEN mm.MEWSdf = 0 THEN NULL ELSE mm.MEWSdf END MEWSdf,        
                                                                           CASE WHEN mm.ksxt = 0 THEN NULL ELSE mm.ksxt END ksxt,            
                                                                          mm.xybhd ,            
                                                              
                                                                   mm.brqx ,   
                                                              
                                                                  mm.fenqu,             
                                                                   mm.zhusu ,     
                                                                         mm.shenzhi ,        
                                                           ryfs ,
                                                           mg.ZDMC,
                                                                      
                                                               (  CASE
                                                    WHEN mm.sffr= 0 THEN '否'
                                                    WHEN mm.sffr = 1 THEN '是'
                                                   
                                                END )                     
                                                        sffr  
                                                      
                                                   FROM MZYS_JZJL mj
                                            INNER JOIN dbo.VI_YY_BRXX yb
                                                ON mj.BRXXID = yb.BRXXID
                                            INNER JOIN dbo.VI_MZ_GHXX mg
                                                ON mj.GHXXID = mg.GHXXID
                                                AND mj.BJSBZ = 1
                                            LEFT JOIN MZ_MZRZ mm
                                                ON mg.blh = mm.blh 
                                            where 1=1  ";
            DataTable dt = new DataTable();
            dt = DbOpt.GetDataTable(str + wherestr);
            Fun.AddRowtNo(dt);
            dgvList.DataSource = dt;
        }

        private void dgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ThrowException)
            {

            }
        } 

        /// <summary>
        /// 导出Excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.dgvList.DataSource;
            if (dt.Rows.Count == 0) return;
            ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dgvList, this.Text);
            //ExportExcel(dgvList);
         
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddEventForKeyDown()
        {
            AddEventForKeyDown(panel1);

        }

        private void AddEventForKeyDown(Control panel)
        {
            foreach (Control ct in panel.Controls)
            {
                
                if (ct is System .Windows .Forms.Button ||ct is System.Windows.Forms.TextBox || ct is System.Windows.Forms.ComboBox || ct is System.Windows.Forms.DateTimePicker||ct is Trasen.Controls.LabelTextBox)
                {
                    ct.KeyDown += new KeyEventHandler(ct_KeyDown);

                }

            }
        }

        private void ct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control control = sender as Control;
                if (control.Name == "tx_mzh")
                {

                    DateTime _now = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                    string _head = _now.Year.ToString("0000").Substring(0) + _now.Month.ToString("00") + _now.Day.ToString("00") + this.tx_mzh.Text.Trim();
                    tx_mzh.Text = _head;
                    if (tx_mzh.Text.Length != 13)
                    {
                        MessageBox.Show("门诊号必须为13位！");
                        return;
                    }
                    this.txtDept.Focus();
                }
                else
                {
                    switch (control.Name)
                    {
                       
                        case "":

                            break;
                        default:
                            SendKeys.Send("{Tab}");
                            break;

                    }


                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void ExportExcel(DataGridView dt)
        {
            if (dt == null || dt.Rows.Count == 0) return;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                return;
            }
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range;
            long totalCount = dt.Rows.Count;
            long rowRead = 0;
            float percent = 0;
            int n = 1;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].Visible)
                {
                    worksheet.Cells[1, n++] = dt.Columns[i].HeaderText;
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
                    range.Interior.ColorIndex = 15;
                    range.Font.Bold = true;
                }

            }
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                n = 1;
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    if (dt.Columns[i].Visible)
                    {
                        worksheet.Cells[r + 2, n++] = dt.Rows[r].Cells[i].Value;
                    }
                }
                rowRead++;
                percent = ((float)(100 * rowRead)) / totalCount;
            }
            xlApp.Visible = true;
        }

        private void dgvList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try {
                if (int.Parse( e.Value.ToString()) == 0)
                {
                    this.dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value=DBNull.Value;
                    
                }
            }
            catch { }
        }

    }
}
