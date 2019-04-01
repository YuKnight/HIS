using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Data.Odbc;
using System.Runtime.InteropServices;

namespace ts_jc_gfbl
{
    public partial class FrmExpPubFee : Form
    {
        public string _yblx = "21";//默认市医保

        public FrmExpPubFee()
        {
            InitializeComponent();
            InitInfo();
        }

        public FrmExpPubFee(string yblx)
        {
            InitializeComponent();
            InitInfo();
            _yblx = yblx;
        }

        private void InitInfo()
        {
            this.Load += new EventHandler(FrmExpPubFee_Load);
            btnQuery.Click += new EventHandler(btnQuery_Click);
            btnExport.Click += new EventHandler(btnExport_Click);

        }

        void FrmExpPubFee_Load(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.DefaultExt = "dbf";//默认后缀名

                //初始化日期21
                DateTime dtStr = DateTime.Parse(DateManager.ServerDateTimeByDBType(InstanceForm._database).AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss"));
                DateTime dtEnd = DateTime.Parse(DateManager.ServerDateTimeByDBType(InstanceForm._database).ToString("yyyy-MM-dd HH:mm:ss"));

                dtpStart.Value = dtStr;
                dtpEnd.Value = dtEnd;

            }
            catch { }

            try
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                this.dataGridView1.AutoGenerateColumns = false;
            }
            catch
            { }

            try
            {
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.AllowUserToDeleteRows = false;
                dataGridView2.ReadOnly = true;
                this.dataGridView2.AutoGenerateColumns = false;
            }
            catch
            { }
        }

        private DataTable DoQueryLdInfo(params object[] args)
        {
            string strSql = "";
            DataTable dt = new DataTable();
            if (tabControl1.SelectedTab.Name.Equals("MZ"))
            {
                strSql = string.Format(@"select c.name as RGRXM,replace(CONVERT(varchar(5), In_time, 7 ),' ','') as FJZRQ,'市八医院' as FJZYY,
                                            --d.name,
                                            t.FXYF, 
                                            t.FZYF, 
                                            t.FPJF, 
                                            t.FPZF, 
                                            t.FTJF, 
                                            t.FTZF, 
                                            t.FQTF, 
                                            t.zje as FXJF, 
                                            t.FzXYF+t.FzZYF+t.FzPJF+t.FzPZF as FZBLF, 
                                            FZTJF, 
                                            t.FZTZF, 
                                            t.FZQTF, 
                                            t.zfje as FZXJF, 
                                            t.zje-t.zfje  as FJSF,
                                            a.ylzh as DDLH,'2' as DM,a.ldh as CFBH,--(注意：只要传8位)
                                            0 as id,
                                            --CONVERT(varchar(6), In_time, 112 ) as NY,
                                            replace(CONVERT(varchar(7),DATEADD(MONTH,1,DATEADD (DAY ,-20,In_time )) , 120 ),'-','') as NY,
                                            '' as idc,c.RDWBH as DWBH,
                                            c.ZFBL as ZFBL,c.RZQK as RZQK,c.RRYLB as RYLB,c.GRJB as GRJB,dbo.fun_getDeptname( b.GHKS) as JZKS,a.ylzh,a.ldh
                                            from (select * from gf_lddj where sf_date>='{0}' and sf_date<='{1}' AND yblx='{2}' and del_bit=0)  a 
                                            inner join jc_gf_patrec c on a.ylzh=c.ylzh and a.yblx=c.gflx --and c.del_bit=0 
                                            left join MZ_GHXX b on a.brxxid=b.BRXXID and a.ghdjid=b.BLH            
                                            inner join 
                                            (
                                            select d.ylzh,d.ldh,
                                            sum(FXYF) as FXYF,
                                            sum(FzXYF) as FzXYF,
                                            sum(FzYF) as FzYF,
                                            sum(FzzYF) as FzzYF,
                                            sum(Fpzf) as Fpzf,
                                            sum(Fzpzf) as Fzpzf,
                                            sum(Fpjf) as Fpjf,
                                            sum(Fzpjf) as Fzpjf,
                                            sum(FTZF) as FTZF,
                                            sum(FzTZF) as FzTZF,
                                            sum(FTJF) as FTJF,
                                            sum(FzTJF) as FzTJF,
                                            sum(FQTF) as FQTF,
                                            sum(FZQTF) as FZQTF,
                                            sum(zje) as zje,
                                            sum(zfje) as zfje
                                            from
                                            (
                                            select 
                                            d.ylzh,d.ldh,--e.fee_type,f.name,
                                            case when e.fee_type='02' then SUM(e.zje) else 0 end as FXYF,
                                            case when e.fee_type='02' then SUM(e.zfje) else 0 end as FzXYF,
                                            case when e.fee_type='03' then SUM(e.zje) else 0 end as FzYF,
                                            case when e.fee_type='03' then SUM(e.zfje) else 0 end as FzzYF,
                                            case when e.fee_type in ('07','01') then SUM(e.zje) else 0 end as Fpzf,
                                            case when e.fee_type in ('07','01') then SUM(e.zfje) else 0 end as Fzpzf,
                                            case when e.fee_type='09' then SUM(e.zje) else 0 end as Fpjf,
                                            case when e.fee_type='09' then SUM(e.zfje) else 0 end as Fzpjf,
                                            case when e.fee_type='08' then SUM(e.zje) else 0 end as FTZF,
                                            case when e.fee_type='08' then SUM(e.zfje) else 0 end as FzTZF,
                                            case when e.fee_type='10' then SUM(e.zje) else 0 end as FTJF,
                                            case when e.fee_type='10' then SUM(e.zfje) else 0 end as FzTJF,
                                            case when e.fee_type='06' then SUM(e.zje) else 0 end as FQTF,
                                            case when e.fee_type='06' then SUM(e.zfje) else 0 end as FZQTF,
                                            SUM(e.zje) as zje,SUM(e.zfje) zfje
                                            from 
                                            gf_ld_info d 
                                            inner join
                                            gf_ld_mxinfo e on  d.ylzh=e.ylzh and d.ldh=e.ldh and d.fpid=e.fpid and e.del_bit=0 and e.cz_flag=0
                                            inner join 
                                            (
                                            select ISNULL(b.s_type,a.type) as fee_type,ISNULL(b.s_name,a.name) as name 
                                            from JC_gf_item_pfl a
                                            left join JC_gf_item_sfl b on a.id=b.pid and b.del_bit=0
                                            where a.del_bit=0
                                            )f on e.fee_type=f.fee_type
                                            where  d.del_bit=0 and d.cz_flag=0
                                            --where d.ylzh='0000110001' and d.ldh='000000002' and d.del_bit=0 and d.cz_flag=0
                                            group by d.ylzh,d.ldh,f.name,e.fee_type
                                            )d group by d.ylzh,d.ldh
                                            )t on a.ylzh=t.ylzh and a.ldh=t.ldh", args);
            }
            else if (tabControl1.SelectedTab.Name.Equals("ZY"))
            {
                strSql = string.Format(@"select a.ylzh as DDLH,b.BRXM as RGRXM,
                                        --CONVERT(varchar(5),f.IN_DATE,101)+'/'+substring(cast(year(f.IN_DATE) as varchar),3,2) as FZYRQ,
                                        --CONVERT(varchar(5),f.OUT_DATE,101)+'/'+substring(cast(year(f.OUT_DATE) as varchar),3,2) as FCYRQ,
                                        substring(cast(year(f.IN_DATE) as varchar),1,4)+'/'+SUBSTRING( CONVERT(varchar(10),f.IN_DATE,101) ,1,5)as FZYRQ,
                                        substring(cast(year(f.OUT_DATE) as varchar),1,4)+'/'+ SUBSTRING( CONVERT(varchar(10),f.OUT_DATE,101),1,5) as FCYRQ,
                                        '市八医院' as FJZYY,
                                        t.FCWF, 
                                        t.FXYF, 
                                        t.FZYF, 
                                        t.FPJF, 
                                        t.FPZF, 
                                        t.FTJF, 
                                        t.FTZF, 
                                        t.FQTF, 
                                        t.zje as FXJF, 
                                        t.Fzcwf as FZBCF, --待检验
                                        t.FzXYF+t.FzZYF+t.FzPJF+t.FzPZF as FZBLF, 
                                         t.FZTJF, 
                                        t.FZTZF, 
                                        t.FZQTF, 
                                        t.zfje as FZXJF, 
                                        t.zje-t.zfje as FJSF,
                                        '2' as DM,
                                        0 as FQZF,
                                        0 as ID,'' as IDC,
                                        --replace(CONVERT(varchar(7), a.sf_date, 120 ),'-','') as NY,
                                        replace(CONVERT(varchar(7),DATEADD(MONTH,1,DATEADD (DAY ,-20,a.sf_date )) , 120 ),'-','') as NY,
                                        e.RDWBH as DWBH,a.ldh as ZYND,e.ZFBL as ZFBL,e.RZQK as RZQK,e.RRYLB as RYLB,e.GRJB as GRJB,dbo.fun_getDeptname( f.IN_DEPT) as JZKS,f.INPATIENT_NO as ZYH
                                        from gf_zylddj a 
                                        inner join ZY_YB_DJXX b on a.ylzh=b.YLZH and a.ldh=b.JYDJH and b.DELETE_BIT=0 and b.IS_YBJS in (0,1)
                                        inner join ZY_YB_JSB c on c.CZ_FLAG=0 and c.DELETE_BIT=0 and b.DJID=c.DJXXID
                                        inner join gf_zyld_info d on c.YBJSID=d.fpid and d.del_bit=0
                                        inner join jc_gf_patrec e on a.ylzh=e.ylzh and a.yblx=e.gflx --and e.del_bit=0 
                                        inner join ZY_INPATIENT f on b.INPATIENT_ID=f.INPATIENT_ID and f.CANCEL_BIT=0
                                        inner join
                                        (
                                        select d.ylzh,d.ldh,
                                        sum(Fcwf) as Fcwf,
                                        sum(Fzcwf) as Fzcwf,
                                        sum(FXYF) as FXYF,
                                        sum(FzXYF) as FzXYF,
                                        sum(FzYF) as FzYF,
                                        sum(FzzYF) as FzzYF,
                                        sum(Fpzf) as Fpzf,
                                        sum(Fzpzf) as Fzpzf,
                                        sum(Fpjf) as Fpjf,
                                        sum(Fzpjf) as Fzpjf,
                                        sum(FTZF) as FTZF,
                                        sum(FzTZF) as FzTZF,
                                        sum(FTJF) as FTJF,
                                        sum(FzTJF) as FzTJF,
                                        sum(FQTF) as FQTF,
                                        sum(FZQTF) as FZQTF,
                                        sum(zje) as zje,
                                        sum(zfje) as zfje
                                        from
                                        (
                                        select 
                                        d.ylzh,d.ldh,--e.fee_type,f.name,
                                        case when e.fee_type in ('01') then SUM(e.zje) else 0 end as Fcwf,
                                        case when e.fee_type in ('01') then SUM(e.zfje) else 0 end as Fzcwf,
                                        case when e.fee_type='02' then SUM(e.zje) else 0 end as FXYF,
                                        case when e.fee_type='02' then SUM(e.zfje) else 0 end as FzXYF,
                                        case when e.fee_type='03' then SUM(e.zje) else 0 end as FzYF,
                                        case when e.fee_type='03' then SUM(e.zfje) else 0 end as FzzYF,
                                        case when e.fee_type in ('07') then SUM(e.zje) else 0 end as Fpzf,
                                        case when e.fee_type in ('07') then SUM(e.zfje) else 0 end as Fzpzf,
                                        case when e.fee_type='09' then SUM(e.zje) else 0 end as Fpjf,
                                        case when e.fee_type='09' then SUM(e.zfje) else 0 end as Fzpjf,
                                        case when e.fee_type='08' then SUM(e.zje) else 0 end as FTZF,
                                        case when e.fee_type='08' then SUM(e.zfje) else 0 end as FzTZF,
                                        case when e.fee_type='10' then SUM(e.zje) else 0 end as FTJF,
                                        case when e.fee_type='10' then SUM(e.zfje) else 0 end as FzTJF,
                                        case when e.fee_type='06' then SUM(e.zje) else 0 end as FQTF,
                                        case when e.fee_type='06' then SUM(e.zfje) else 0 end as FZQTF,
                                        SUM(e.zje) as zje,SUM(e.zfje) zfje
                                        from 
                                        gf_zyld_info d 
                                        inner join
                                        gf_zyld_mxinfo e on  d.ylzh=e.ylzh and d.ldh=e.ldh and d.fpid=e.fpid and e.del_bit=0 and e.cz_flag=0
                                        inner join 
                                        (
                                        select ISNULL(b.s_type,a.type) as fee_type,ISNULL(b.s_name,a.name) as name 
                                        from JC_gf_item_pfl a
                                        left join JC_gf_item_sfl b on a.id=b.pid and b.del_bit=0
                                        where a.del_bit=0
                                        )f on e.fee_type=f.fee_type
                                        where  d.del_bit=0 and d.cz_flag=0
                                        --where d.ylzh='0000110001' and d.ldh='0000005' and d.del_bit=0 and d.cz_flag=0
                                        group by d.ylzh,d.ldh,f.name,e.fee_type
                                        )d group by d.ylzh,d.ldh
                                        )t on a.ldh=t.ldh  and a.ylzh=t.ylzh
                                        where DATEDIFF(DAY,'{0}',c.YBJS_DATE)>=0 and  DATEDIFF(DAY,'{1}',c.YBJS_DATE)<=0 and a.yblx='{2}' and a.del_bit=0  ", args);
            }

            dt = FrmMdiMain.Database.GetDataTable(strSql);
            return dt;
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (tabControl1.SelectedTab.Name.Equals("MZ") ? dataGridView1.DataSource : dataGridView2.DataSource) as DataTable;
                if (dt == null || dt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有数据需要导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //saveFileDialog1.OverwritePrompt
                string table = @"";

                //设置文件类型
                //书写规则例如：txt files(*.txt)|*.txt  dBase(*.dbf)
                saveFileDialog1.Filter = "dBase(*.dbf)|*.dbf|Excel files(*.xls)|*.xls|All files(*.*)|*.*";
                //设置默认文件名（可以不设置）
                saveFileDialog1.FileName = "1";
                //主设置默认文件extension（可以不设置）
                saveFileDialog1.DefaultExt = "dbf";
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

                    //获取文件名，不带路径
                    //fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);

                    //获取文件路径，不带文件名
                    //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

                    //给文件名前加上时间
                    //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;

                    //在文件名里加字符
                    //saveFileDialog.FileName.Insert(1,"dameng");
                    //为用户使用 SaveFileDialog 选定的文件名创建读/写文件流。
                    //System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();//输出文件

                    //fs可以用于其他要写入的操作
                }
                else
                {
                    return;
                }

                ExportExcel(dt, table);
                return;

                //string connStr = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + table + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";

                //using (OdbcConnection conn = new OdbcConnection(connStr))
                //{
                //    conn.Open();
                //    OdbcCommand cmd = new OdbcCommand();
                //    cmd.Connection = conn;
                //    cmd.CommandType = CommandType.Text;


                //    //finally
                //    //{
                //    //    conn.Close();
                //    //    cmd.Dispose();
                //    //    conn.Dispose();
                //    //}
                //}

                //MessageBox.Show("操作成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作出错! \n\t " + ex.Message + " \n\t " + ex.StackTrace);
                return;
            }
        }

        void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DoQueryLdInfo(dtpStart.Value.ToString("yyyy-MM-dd"), dtpEnd.Value.ToString("yyyy-MM-dd"), _yblx);

                string strSql = "";
                if (tabControl1.SelectedTab.Name.Equals("MZ"))
                {
                    DoBindData(dt, dataGridView1);
                }
                else if (tabControl1.SelectedTab.Name.Equals("ZY"))
                {
                    DoBindData(dt, dataGridView2);
                }
            }
            catch { }
        }

        private void DoBindData(DataTable dtSrc, DataGridView grdDes)
        {
            if (dtSrc != null)
            {
                grdDes.DataSource = dtSrc;
                (grdDes.DataSource as DataTable).AcceptChanges();
            }
        }

        //private void Bind(string table)
        //{
        //    try
        //    {
        //        conn = new System.Data.Odbc.OdbcConnection();
        //        //string table = @"C:\测试例子\Dbf\prepur.dbf";
        //        string connStr = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + table + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";

        //        conn.ConnectionString = connStr;
        //        conn.Open();

        //        string sql = @"select * from " + table;

        //        OdbcDataAdapter da = new OdbcDataAdapter(sql, conn);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        this.dataGridView1.DataSource = dt.DefaultView;
        //        //MessageBox.Show(dt.Rows[0][0].ToString());
        //    }
        //    catch
        //    { }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        private void Add(DataTable dt, string table)
        {
            string connStr = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + table + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";

            using (OdbcConnection conn = new OdbcConnection(connStr))
            {
                OdbcCommand cmd = new OdbcCommand();
                try
                {
                    conn.Open();
                    cmd.Connection = conn;

                    #region 创建DBF表文件

                    #region CREATE TABLE

                    string sqlt = "";
                    if (tabControl1.SelectedTab.Name.Equals("MZ"))
                    {
                        //RGRXM	FJZRQ	FJZYY	
                        //FXYF	FZYF	FPJF	FPZF	FTJF	FTZF	FQTF	FXJF	
                        //FZBLF	FZTJF	FZTZF	FZQTF	FZXJF	FJSF	
                        //DDLH	DM	CFBH	ID	NY	IDC	DWBH	ZFBL	RZQK	RYLB	GRJB
                        sqlt = "CREATE TABLE " + table + "(" +
                            "RGRXM c(10)," +
                            "FJZRQ c(4)," +
                            "FJZYY c(12)," +
                            "FXYF n(16,2)," +
                            "FZYF n(16,2)," +
                            "FPJF n(16,2)," +
                            "FPZF n(16,2)," +
                            "FTJF n(16,2)," +
                            "FTZF n(16,2)," +
                            "FQTF n(16,2)," +
                            "FXJF n(16,2)," +
                            "FZBLF n(16,2)," +
                            "FZTJF n(16,2)," +
                            "FZTZF n(16,2)," +
                            "FZQTF n(16,2)," +
                            "FZXJF n(16,2)," +
                            "FJSF n(16,2)," +
                            "DDLH c(13)," +
                            "DM c(1)," +
                            "CFBH c(8)," +
                            "ID n(16,2)," +
                            "NY c(6)," +
                            "IDC c(8)," +
                            "DWBH c(6)," +
                            "ZFBL n(16,2)," +
                            "RZQK c(10)," +
                            "RYLB c(10)," +
                            "GRJB c(20)" +
                            ")";
                    }
                    else if (tabControl1.SelectedTab.Name.Equals("ZY"))
                    {
                        //DDLH	RGRXM	FZYRQ	FCYRQ	FJZYY
                        //FCWF	FXYF	FZYF	FPJF	FPZF	FTJF	FTZF	FQTF	FXJF
                        //FZBCF	FZBLF	FZTJF	FZTZF	FZQTF	FZXJF	FJSF	DM	FQZF
                        //ID	IDC	NY	DWBH	ZYND	ZFBL	RZQK	RYLB	GRJB
                        sqlt = "CREATE TABLE " + table + "(" +
                            "DDLH c(13)," +
                            "RGRXM c(10)," +
                            "FZYRQ c(8)," +
                            "FCYRQ c(8)," +
                            "FJZYY c(12)," +
                            "FCWF n(16,2)," +
                            "FXYF n(16,2)," +
                            "FZYF n(16,2)," +
                            "FPJF n(16,2)," +
                            "FPZF n(16,2)," +
                            "FTJF n(16,2)," +
                            "FTZF n(16,2)," +
                            "FQTF n(16,2)," +
                            "FXJF n(16,2)," +
                            "FZBCF n(16,2)," +
                            "FZBLF n(16,2)," +
                            "FZTJF n(16,2)," +
                            "FZTZF n(16,2)," +
                            "FZQTF n(16,2)," +
                            "FZXJF n(16,2)," +
                            "FJSF n(16,2)," +
                            "DM c(1)," +
                            "FQZF n(16,2)," +
                            "ID n(16,2)," +
                            "IDC c(8)," +
                            "NY c(6)," +
                            "DWBH c(6)," +
                            "ZYND c(8)," +
                            "ZFBL n(16,2)," +
                            "RZQK c(10)," +
                            "RYLB c(10)," +
                            "GRJB c(20)" +
                            ")";
                    }

                    cmd.CommandText = sqlt;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    //System.Data.OleDb.OleDbCommand OLDBComm = new System.Data.OleDb.OleDbCommand(sqlt, mOLDBConn);
                    //mOLDBConn.Open();
                    //OLDBComm.ExecuteNonQuery();
                    //OLDBComm.Dispose();
                    //mOLDBConn.Close();

                    #endregion CREATE TABLE

                    #region Delete TableDate

                    string sqld = @"delete * from " + table;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    //System.Data.OleDb.OleDbCommand OLDBCommIn = new System.Data.OleDb.OleDbCommand("delete * from " + table, mOLDBConn);
                    //mOLDBConn.Open();
                    //OLDBCommIn.ExecuteNonQuery();
                    //OLDBCommIn.Dispose();
                    //mOLDBConn.Close();

                    #endregion

                    #endregion

                    #region"Insert"

                    try
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string sql = "";
                            DataRow dr = dt.Rows[i];

                            if (tabControl1.SelectedTab.Name.Equals("MZ"))
                            {
                                sql = string.Format(@"insert into {28} (RGRXM,FJZRQ,FJZYY,FXYF,FZYF,FPJF,FPZF,FTJF,FTZF,FQTF,FXJF,FZBLF,FZTJF,FZTZF,FZQTF,FZXJF,FJSF,DDLH,DM,CFBH,ID,NY,IDC,DWBH,ZFBL,RZQK,RYLB,GRJB) 
                                                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',
                                                        '{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}',
                                                        '{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}')",
                                                    Convertor.IsNull(dr["RGRXM"], ""),
                                                    Convertor.IsNull(dr["FJZRQ"], ""),
                                                    Convertor.IsNull(dr["FJZYY"], "市八医院"),
                                                    Convertor.IsNull(dr["FXYF"], "0"),
                                                    Convertor.IsNull(dr["FZYF"], "0"),
                                                    Convertor.IsNull(dr["FPJF"], "0"),
                                                    Convertor.IsNull(dr["FPZF"], "0"),
                                                    Convertor.IsNull(dr["FTJF"], "0"),
                                                    Convertor.IsNull(dr["FTZF"], "0"),
                                                    Convertor.IsNull(dr["FQTF"], "0"),
                                                    Convertor.IsNull(dr["FXJF"], "0"),
                                                    Convertor.IsNull(dr["FZBLF"], "0"),
                                                    Convertor.IsNull(dr["FZTJF"], "0"),
                                                    Convertor.IsNull(dr["FZTZF"], "0"),
                                                    Convertor.IsNull(dr["FZQTF"], "0"),
                                                    Convertor.IsNull(dr["FZXJF"], "0"),
                                                    Convertor.IsNull(dr["FJSF"], "0"),
                                                    Convertor.IsNull(dr["DDLH"], ""),
                                                    Convertor.IsNull(dr["DM"], "2"),
                                                    Convertor.IsNull(dr["CFBH"], ""),
                                                    Convertor.IsNull(dr["ID"], "0"),
                                                    Convertor.IsNull(dr["NY"], "0"),
                                                    Convertor.IsNull(dr["IDC"], ""),
                                                    Convertor.IsNull(dr["DWBH"], ""),
                                                    Convertor.IsNull(dr["ZFBL"], "0"),
                                                    Convertor.IsNull(dr["RZQK"], ""),
                                                    Convertor.IsNull(dr["RYLB"], ""),
                                                    Convertor.IsNull(dr["GRJB"], ""),
                                                    table);
                            }
                            else if (tabControl1.SelectedTab.Name.Equals("ZY"))
                            {
                                //sql = string.Format(@"insert into {32}  
                                sql = string.Format(@"insert into {32} (DDLH,RGRXM,FZYRQ,FCYRQ,FJZYY,FCWF,FXYF,FZYF,FPJF,FPZF,FTJF,FTZF,FQTF,FXJF,FZBCF,FZBLF,FZTJF,FZTZF,FZQTF,FZXJF,FJSF,DM,FQZF,ID,IDC,NY,DWBH,ZYND,ZFBL,RZQK,RYLB,GRJB) 
                                                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',
                                                        '{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}',
                                                        '{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}')",
                                                    Convertor.IsNull(dr["DDLH"], ""),
                                                    Convertor.IsNull(dr["RGRXM"], ""),
                                                    Convertor.IsNull(dr["FZYRQ"], ""),
                                                    Convertor.IsNull(dr["FCYRQ"], ""),
                                                    Convertor.IsNull(dr["FJZYY"], "市八医院"),
                                                    Convertor.IsNull(dr["FCWF"], "0"),
                                                    Convertor.IsNull(dr["FXYF"], "0"),
                                                    Convertor.IsNull(dr["FZYF"], "0"),
                                                    Convertor.IsNull(dr["FPJF"], "0"),
                                                    Convertor.IsNull(dr["FPZF"], "0"),
                                                    Convertor.IsNull(dr["FTJF"], "0"),
                                                    Convertor.IsNull(dr["FTZF"], "0"),
                                                    Convertor.IsNull(dr["FQTF"], "0"),
                                                    Convertor.IsNull(dr["FXJF"], "0"),
                                                    Convertor.IsNull(dr["FZBCF"], "0"),
                                                    Convertor.IsNull(dr["FZBLF"], "0"),
                                                    Convertor.IsNull(dr["FZTJF"], "0"),
                                                    Convertor.IsNull(dr["FZTZF"], "0"),
                                                    Convertor.IsNull(dr["FZQTF"], "0"),
                                                    Convertor.IsNull(dr["FZXJF"], "0"),
                                                    Convertor.IsNull(dr["FJSF"], "0"),
                                                    Convertor.IsNull(dr["DM"], "2"),
                                                    Convertor.IsNull(dr["FQZF"], "0"),
                                                    Convertor.IsNull(dr["ID"], "0"),
                                                    Convertor.IsNull(dr["IDC"], ""),
                                                    Convertor.IsNull(dr["NY"], "0"),
                                                    Convertor.IsNull(dr["DWBH"], ""),
                                                    Convertor.IsNull(dr["ZYND"], ""),
                                                    Convertor.IsNull(dr["ZFBL"], "0"),
                                                    Convertor.IsNull(dr["RZQK"], ""),
                                                    Convertor.IsNull(dr["RYLB"], ""),
                                                    Convertor.IsNull(dr["GRJB"], ""),
                                                    table);
                            }

                            cmd.CommandText = sql;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    conn.Close();
                    cmd.Dispose();
                    conn.Dispose();
                }
                MessageBox.Show("suc");
            }
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
            worksheet.Name = _yblx.Equals("21") ? "武汉市公费" : _yblx.Equals("22") ? "江岸区公费" : ""; //这里修改sheet名称

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
            //FCWF、FXYF、FZYF、FPJF、FPZF、FTJF、FTZF、FQTF、FXJF、FZBCF、FZBLF、FZTJF、FZTZF、FZQTF、FZXJF、FJSF、FQZF、ID、ZFBL

            DataTable dt = new DataTable();
            dt.Columns.Add("FCWF", typeof(decimal));
            dt.Columns.Add("FXYF", typeof(decimal));
            dt.Columns.Add("FZYF", typeof(decimal));
            dt.Columns.Add("FPJF", typeof(decimal));
            dt.Columns.Add("FPZF", typeof(decimal));
            dt.Columns.Add("FTJF", typeof(decimal));
            dt.Columns.Add("FTZF", typeof(decimal));
            dt.Columns.Add("FQTF", typeof(decimal));
            dt.Columns.Add("FXJF", typeof(decimal));
            dt.Columns.Add("FZBCF", typeof(decimal));
            dt.Columns.Add("FZBLF", typeof(decimal));
            dt.Columns.Add("FZTJF", typeof(decimal));
            dt.Columns.Add("FZTZF", typeof(decimal));
            dt.Columns.Add("FZQTF", typeof(decimal));
            dt.Columns.Add("FZXJF", typeof(decimal));
            dt.Columns.Add("FJSF", typeof(decimal));
            dt.Columns.Add("FQZF", typeof(decimal));
            dt.Columns.Add("ID", typeof(decimal));
            dt.Columns.Add("ZFBL", typeof(decimal));

            return dt;
        }
    }
}