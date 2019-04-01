using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace ts_yj_tjbb
{
    public partial class FrmQueryKss : Form
    {
        public FrmQueryKss()
        {
            InitializeComponent();
        }

        private void FrmQueryKss_Load(object sender, EventArgs e)
        {

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;

            dtp1.Value = DateTime.Now.AddDays(-1);

            txtghdw.Tag = "0";
            txtghdw.Text = "";

            string strSql = "";

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "0", "全部" });
                dt.Rows.Add(new object[] { "1", "预防 - 内科高危人群" });
                dt.Rows.Add(new object[] { "2", "预防 - I类清洁切口手术" });
                dt.Rows.Add(new object[] { "3", "预防 - II类清洁污染切口手术" });
                dt.Rows.Add(new object[] { "4", "治疗 - 经验用药" });
                dt.Rows.Add(new object[] { "5", "治疗 - 药敏依据" });
                dt.Rows.Add(new object[] { "6", "治疗 - III类污染切口手术" });
                dt.Rows.Add(new object[] { "7", "治疗 - IV类污秽感染切口" });

                Addcmb(cmbYyMd, dt, "id", "name");
            }
            catch { }

            try
            {

                strSql = string.Format(@"select '0' as ID,'全部' as  name
                                            union all
                                         select ID,NAME from SS_QKDJ");
                DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql);

                Addcmb(cmbQkdj, dt, "id", "name");
            }
            catch { }
        }

        private void btnTj_Click(object sender, EventArgs e)
        {

            DataTable dt = DoQuery();

            if (dt != null)
            {
                this.dataGridView1.DataSource = dt;

                (this.dataGridView1.DataSource as DataTable).AcceptChanges();
            }

        }

        private DataTable DoQuery()
        {
            string ssql = string.Format(@"
                select b.ORDER_CONTEXT as 医嘱内容,dbo.fun_getDeptname(t.DEPT_ID) as 出院科室,
                    t.INPATIENT_NO as 病案号,t.SEX_NAME as 性别,t.AGE as 年龄,dbo.fun_getDeptname(j.DEPTID) 手术科室,
                    dbo.fun_getdiseasename(OUT_DIAGNOSIS,t.YBLX) as 第一诊断,
                     --(select top 1 DISEASE_NAME from ZY_DISEASE_MANY where INPATIENT_NO=t.INPATIENT_NO and DISEASE_MARK='第1诊断') 第一诊断,
                     --(select top 1 DISEASE_NAME from ZY_DISEASE_MANY where INPATIENT_NO=t.INPATIENT_NO and DISEASE_MARK='第2诊断') 第二诊断,
                     m.YSSS as 第一手术名称,ssicd 手术编码,k.name as 切口类型,
                    m.SSBEGINRQ as 手术开始时间,m.SSENDRQ as 手术结束时间,
                    case when CHARINDEX('术前',b.ORDER_CONTEXT,0)>0 or CHARINDEX('术中',b.ORDER_CONTEXT,0)>0 or CHARINDEX('术前',b.DROPSPER,0)>0 or CHARINDEX('术中',b.DROPSPER,0)>0 then 1 else 0 end as 术前半至一小时给药, --'' as 术后,
                     e.s_yppm as 抗菌药物品种,
                    case b.MNGTYPE when 0 then '长嘱' when 1 then '临嘱' when 5 then '出院带药' end as 医嘱类型,
                    e.s_ypgg as 规格,
                    case a.kssdjid when 1 then '非限制级' when 2 then '限制级' when 3 then '特殊级'  end as 抗菌药物等级,
                    b.ORDER_USAGE as 用法,
                    cast(b.num as varchar) +b.UNIT as 用量,
                    b.ORDER_BDATE as 开嘱时间,
                    b.ORDER_EDATE as 停嘱时间,
                    case when DATEDIFF(HOUR,b.ORDER_BDATE,b.ORDER_EDATE)<24 then 1 else 0 end as 疗程小于24小时,
                    dbo.fun_getEmpName(b.ORDER_DOC) 开嘱医生,
                    case a.type_id when 1 then '主任医生' when 2 then '副主任医生' when 3 then '主治医生' when 4 then '经治医生' end as 医生权限,
                    case a.yymd 
                    when '1' then '预防性用药' 
                    when '2' then '治疗性用药'
                    when '3' then '经验性用药'
                    when '4' then '目标性用药'
                    else '' end as 用药目的,
                    case a.yymd_xx 
                    when '1' then '内科高危人群' 
                    when '2' then 'I类清洁切口手术'
                    when '3' then 'II类清洁污染切口手术'
                    when '4' then '经验用药'
                    when '5' then '药敏依据'
                    when '6' then 'III类污染切口手术'
                    when '7' then 'IV类污秽感染切口'
                    else '' end as 用药目的补充,
                    ISNULL(g.context,'') as 目的说明,--待修改
                    case a.byjc_bit when '0' then '未送' when '1' then '已送' else '' end as 病原检查,
                    case isnull(d.ymjg,'-1') when '0' then '没有' when '1' then '已有' else '' end as 药敏结果,
                    case d.shbz when '0' then '[特]待审核' when '1' then '[特]已审核' end as 特殊审核,
                    dbo.fun_getEmpName(isnull(d.shr,'-1'))  AS 特殊审核人 ,
                    d.shsj AS 特殊审核时间 ,
                    case c.shbz when '0' then '[越]待审核' when '1' then '[越]已审核' end as 越级审核,
                    dbo.fun_getEmpName(isnull(c.shr,'-1')) AS 越级审核人 ,
                    c.shsj AS 越级审核时间 
                 from 
                (select * from VI_ZY_VINPATIENT_ALL t where t.OUT_DATE>='{0}' and t.OUT_DATE<='{1}' and t.FLAG in (2,6,10) and BABY_ID=0) t
                inner join vi_ZY_ORDERRECORD b on t.INPATIENT_ID=b.INPATIENT_ID and XMLY=1 and b.DELETE_BIT=0 and b.WZX_FLAG=0
                inner join VI_YP_YPCD e on b.HOITEM_ID=e.cjid and e.kssdjid>0 and e.BDELETE=0 and e.cjbdelete=0
                left join zy_kss_dj a on b.ORDER_ID=a.order_id and a.del_bit=0
                left join ZY_KSS_SH c on b.ORDER_ID=c.order_id and c.DEL_BIT=0
                left join zy_kss_sqb d on b.ORDER_ID=d.order_id and d.DEL_BIT=0
                left join jc_kss_yymdMemo g on a.yymd_memo=g.ID
                inner join V_JC_KSS_DEPT h on b.DEPT_ID=h.dept_id
                left join SS_APPRECORD j on b.INPATIENT_ID=j.INPATIENT_ID and j.BDELETE=0
                left join SS_QKDJ k on j.ygqkdj=k.ID
                left join ss_arrRECORD m on t.INPATIENT_ID=m.INPATIENT_ID and j.sno=m.sno
                where {2}={3} and {4}={5} and {6}={7}",
                dtp1.Value.ToString("yyyy-MM-dd"), dtp2.Value.ToString("yyyy-MM-dd")
                , Convertor.IsNull(txtghdw.Tag, "0").Equals("0") ? "0" : "j.DEPTID", Convertor.IsNull(txtghdw.Tag, "0")
                , cmbYyMd.SelectedValue.Equals("0") ? "0" : "a.yymd", cmbYyMd.SelectedValue
                , cmbQkdj.SelectedValue.ToString().Trim().Equals("0") ? "0" : "j.ygqkdj", cmbQkdj.SelectedValue
                );
            
            
            DataTable dt = InstanceForm.BDatabase.GetDataTable(ssql);

            return dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void ExportExcel(DataTable dt, string table)
        {
            if (dt == null || dt.Rows.Count == 0) return;
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                return;
            }
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
            //Excel.Workbook workbook = xlApp.Workbooks.Open(table, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //Excel.Worksheet worksheet = workbook.Sheets[1] as Excel.Worksheet; //第一个sheet页
            worksheet.Name = "武汉市公费"; //这里修改sheet名称

            try
            {
                Excel.Range range;
                long totalCount = dt.Rows.Count;
                long rowRead = 0;
                float percent = 0;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                    range = (Excel.Range)worksheet.Cells[1, i + 1];
                    range.Interior.ColorIndex = 15;
                    range.Font.Bold = true;
                    //range.NumberFormat = "0.00";
                }

                DataTable dtDec = DecCol();

                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string strValue = dt.Rows[r][i].ToString();
                        decimal dm = 0M;
                        if (dtDec.Columns.Contains(dt.Columns[i].ColumnName))
                        {
                            ((Excel.Range)worksheet.Cells[r + 2, i + 1]).NumberFormat = "0.00";
                            worksheet.Cells[r + 2, i + 1] = strValue;
                        }
                        else
                        {
                            worksheet.Cells[r + 2, i + 1] = "'" + strValue;
                            //worksheet.Cells[r + 2, i + 1] = strValue;
                        }
                    }
                    rowRead++;
                    percent = ((float)(100 * rowRead)) / totalCount;
                }
                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                workbook.Saved = true;

                if (System.IO.File.Exists(table))
                {
                    System.IO.File.Delete(table);
                }
                workbook.SaveCopyAs(table);
                workbook.Close(true, Type.Missing, Type.Missing);
                workbook = null;
                xlApp.Quit();
                xlApp = null;
            }
        }

        private DataTable DecCol()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("zje", typeof(decimal));

            return dt;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = dataGridView1.DataSource as DataTable;
                if (dt == null || dt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有数据需要导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //saveFileDialog1.OverwritePrompt
                string table = @"";

                //设置文件类型
                //书写规则例如：txt files(*.txt)|*.txt  dBase(*.dbf)
                saveFileDialog1.Filter = "Excel files(*.xls)|*.xls|All files(*.*)|*.*";
                //设置默认文件名（可以不设置）
                saveFileDialog1.FileName = "1";
                //主设置默认文件extension（可以不设置）
                saveFileDialog1.DefaultExt = "xls";
                //获取或设置一个值，该值指示如果用户省略扩展名，文件对话框是否自动在文件名中添加扩展名。（可以不设置）
                saveFileDialog1.AddExtension = true;

                //设置默认文件类型显示顺序（可以不设置）
                saveFileDialog1.FilterIndex = 1;

                //保存对话框是否记忆上次打开的目录
                saveFileDialog1.RestoreDirectory = true;

                // Show save file dialog box
                DialogResult result = saveFileDialog1.ShowDialog();
                //点了保存按钮进入
                if (result == DialogResult.OK)
                {

                    //获得文件路径
                    table = saveFileDialog1.FileName.ToString();
                }
                else
                {
                    return;
                }

                ExportExcel(dt, table);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作出错! \n\t " + ex.Message + " \n\t " + ex.StackTrace);
                return;
            }
        }

        private void txtghdw_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                int nkey = Convert.ToInt32(e.KeyCode);
                Control control = (Control)sender;

                if (control.Text.Trim() == "")
                {
                    control.Text = "";
                    control.Tag = "0";
                    return;
                }
                if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
                { }
                else
                {
                    return;
                }
                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);


                string[] GrdMappingName = new string[] { "科室", "拼音码", "五笔码", "DEPT_ID", "MZ_FLAG", "ZY_FLAG" };
                int[] GrdWidth = new int[] { 140, 60, 60, 0, 0, 0 };
                string[] sfield = new string[] { "", "PY_CODE", "WB_CODE", "", "" };

                string ssql = "select NAME ,PY_CODE ,WB_CODE ,DEPT_ID,MZ_FLAG,ZY_FLAG from JC_DEPT_PROPERTY where ZY_FLAG=1 and DELETED=0";
                Fshowcard f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "科室";
                f.Width = 500;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    (sender as Control).Tag = row["DEPT_ID"].ToString();
                    (sender as Control).Text = row["NAME"].ToString();
                    this.SelectNextControl((Control)sender, true, false, true, true);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }
    }
}