using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.IO;
using System.Data.SqlClient;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using System.Threading;
using System.Runtime.InteropServices;

namespace ts_jc_gfbl
{
    public partial class FrmImport : Form
    {
        string _strImporTime = "";
        string _strTable = "";//异步调用textbox2.text时候使用

        string _yjexz = "";//金额限制
        string _jexz = "";//金额限制
        string _cfsl = "";//处方数量
        string _cfslM = "";//月处方数量
        string _rJcje = "";//日检查金额
        string _rZlje = "";//日治疗金额

        /// <summary>
        /// 耗时工作是否完成
        /// </summary>
        bool _isFinish = false;

        IDbfImport imp = null;

        public FrmImport()
        {
            InitializeComponent();
            InitInfo();
        }

        private void InitInfo()
        {
            this.Load += new EventHandler(FrmImport_Load);

            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
            button3.Click += new EventHandler(button3_Click);
            button4.Click += new EventHandler(button4_Click);

            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);

            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);

        }

        void FrmImport_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                this.dataGridView1.AutoGenerateColumns = true;
            }
            catch { }

            try
            {
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.AllowUserToDeleteRows = false;
                dataGridView2.ReadOnly = true;
                this.dataGridView2.AutoGenerateColumns = true;
            }
            catch { }
        }

        #region"Event"

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = openFileDialog1.FileName;
                CreateOdbcConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)// && cmbTable.SelectedValue.ToString().Length > 0)
            {
                button3.Enabled = false;
                run();
                button3.Enabled = true;
            }
            else
            {
                MessageBox.Show("请输入配置参数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;

            imp = DoGetImportObj();

            DataTable dt = imp.QueryChangeInfo(dtpStr.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));


            if (dt != null)
            {
                //Fill DataGridview with the Table
                dataGridView2.DataSource = dt;
            }
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DoImport(_strTable);
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DoFinish();
        }

        private void btnSol_Click(object sender, EventArgs e)
        {
            string strErr = "";
            try
            {
                //DataGridViewRow dgr = dataGridView2.CurrentRow;

                //if (dgr == null)
                //    return;
                string strZone = "44443";//武汉市区域编码：此处写死
                string strWhsGf = "21";//武汉市区域编码：此处写死
                string strYbjklx = "4444";
                string strSql = "";

                DataTable dt = dataGridView2.DataSource as DataTable;

                if (dt == null || dt.Rows.Count <= 0)
                    return;

                dt.DefaultView.RowFilter = "cwxx='出错'";

                foreach (DataRow dr in dt.Rows)
                {
                    int iRet = DoValid(dr["ylzh"].ToString().Trim(), strZone);

                    DoSetValueByDataRow(dr);//赋值给变量

                    //错误数据处理
                    if (iRet == 1)
                    {
                        //已存在则对比name，相同直接进行update操作,否则不update
                        DataTable dtHis = DoGetPatientInfo(dr["ylzh"].ToString().Trim(), strZone);
                        if (dtHis == null || dtHis.Rows.Count <= 0)
                        {
                            strErr += dr["ylzh"].ToString().Trim() + "\r";
                            continue;
                        }

                        DataRow drHis = dtHis.Rows[0];

                        //通过人员姓名判断是否同人
                        if (dr["RGRXM"].ToString().Trim().Equals(drHis["name"].ToString().Trim()))
                        {
                            strSql = string.Format(@"update   [jc_gf_patrec] set  
                                            [name] = '{0}',
                                            [pym] = '{1}',
                                            [wbm] = '{2}',
                                            [GRJB] = '{3}',
                                            [RZQK] = '{4}',
                                            [ZFBL] = '{5}',
                                            [RDWBH] = '{6}',
                                            [DWBH] = '{7}',
                                            [RRYLB] = '{8}',
                                            [RGRBH] = '{9}',
                                            [SFZH] = '{10}',
                                            [xb] = '{11}',
                                            [memo] = '{12}' ,
                                            [lxdh] = '{13}',
                                            [csrq] = '{14}',
                                            [GZSJ] = '{15}',
                                            [DDYY1] = '{16}',
                                            [DDYY2] = '{17}',
                                            [DDYY3] = '{18}',
                                            [bzsj] = '{19}',
                                            [xzsj] = '{20}',
                                            [ydsj] = '{21}',
                                            [ydlb] = '{22}',
                                            [memo_1] = '{23}',
                                            [memo_2] = '{24}',
                                            [memo_3] = '{25}',
                                            [gflx] = '{26}'
                                            where  ylzh= '{27}' and  [qy] = '{28}'",
                                                                RGRXM.Replace("'", ""),
                                                                PubStaticFun.GetPYWBM(RGRXM.Replace("'", ""), 0),
                                                                PubStaticFun.GetPYWBM(RGRXM.Replace("'", ""), 1),
                                                                RGRJB,
                                                                RRZQK,
                                                                RZFBL,
                                                                RDWBH,
                                                                DWBH,
                                                                RRYLB,
                                                                RGRBH,
                                                                SFZH,
                                                                RGRXB,
                                                                BZ,
                                                                NXDH.Replace("'", ""),
                                                                string.IsNullOrEmpty(RZSSJ.Trim()) ? "" : RZSSJ.Trim(),
                                                                string.IsNullOrEmpty(RGZSJ.Trim()) ? "" : RGZSJ.Trim(),
                                                                RDDY1,
                                                                RDDY2,
                                                                RDDY3,
                                                                string.IsNullOrEmpty(RBZSJ.Trim()) ? "" : RBZSJ.Trim(),
                                                                string.IsNullOrEmpty(RSZSJ.Trim()) ? "" : RSZSJ.Trim(),
                                                                string.IsNullOrEmpty(BDSJ.Trim()) ? "" : BDSJ.Trim(),
                                                                BDLB,
                                                                "",
                                                                RGRJB,
                                                                RRZQK,
                                                                strWhsGf,
                                                                DDLH,
                                                                strZone);
                            InstanceForm._database.DoCommand(strSql);
                        }
                        else
                        {
                            strErr += dr["ylzh"].ToString().Trim() + "相同的医疗证号，不同姓名 \r";
                            continue;
                        }
                    }
                    else if (iRet == 0)
                    {
                        strSql = string.Format(@"insert into jc_gf_patrec( id, ylzh,ylzh1,ylzh2, name, pym, wbm, gflx, qy, brlx, del_bit, cfsl_xz, cfslM_xz, je_xz, jcje_xz, zlje_xz,yje_xz, 
                                                                GRJB, RZQK, ZFBL, RDWBH, DWBH, RRYLB, RGRBH, SFZH, xb ,memo,
                                                                DM,lxdh, csrq,GZSJ,DDYY1,DDYY2,DDYY3,bzsj,xzsj,ydsj,ydlb,memo_1,memo_2,memo_3) 
                                                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}')",
                                                            DDLH.Replace("'", "") + strZone,
                                                            DDLH.Replace("'", ""),
                                                            DDLH.Replace("'", ""),
                                                            DDLH.Replace("'", ""),
                                                            RGRXM.Replace("'", ""),
                                                            PubStaticFun.GetPYWBM(RGRXM.Replace("'", ""), 0),
                                                            PubStaticFun.GetPYWBM(RGRXM.Replace("'", ""), 1),
                                                            strWhsGf,
                                                            strZone,
                                                            strYbjklx,
                                                            "0",
                                                            _cfsl,
                                                            _cfslM,
                                                            _jexz,
                                                            _rJcje,
                                                            _rZlje,
                                                            _yjexz,
                                                            RGRJB,
                                                            RRZQK,
                                                            RZFBL,
                                                            RDWBH,
                                                            DWBH,
                                                            RRYLB,
                                                            RGRBH,
                                                            SFZH,
                                                            RGRXB,
                                                            BZ,
                                                            "2",
                                                            NXDH.Replace("'", ""),
                                                            string.IsNullOrEmpty(RZSSJ.Trim()) ? "" : RZSSJ.Trim(),
                                                            string.IsNullOrEmpty(RGZSJ.Trim()) ? "" : RGZSJ.Trim(),
                                                            RDDY1,
                                                            RDDY2,
                                                            RDDY3,
                                                            string.IsNullOrEmpty(RBZSJ.Trim()) ? "" : RBZSJ.Trim(),
                                                            string.IsNullOrEmpty(RSZSJ.Trim()) ? "" : RSZSJ.Trim(),
                                                            string.IsNullOrEmpty(BDSJ.Trim()) ? "" : BDSJ.Trim(),
                                                            BDLB,
                                                            "",
                                                            RGRJB,
                                                            RRZQK);

                        InstanceForm._database.DoCommand(strSql);
                    }
                }

                strErr += "  其余成功!! \r";
                MessageBox.Show(strErr, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(strErr + "\r" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        private void CreateOdbcConnection()
        {
            //Reading data from DBF file
            string table = textBox1.Text;
            string connectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + table + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";
            string dir = this.textBox1.Text.Substring(0, textBox1.Text.LastIndexOf('\\'));//删除文件名
            //string connectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + table + ";";
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                OdbcDataAdapter adapter = new OdbcDataAdapter("select * from " + table, connection);
                DataTable dtPerSon = new DataTable();
                try
                {
                    //connection.Open();
                    adapter.Fill(dtPerSon);
                    if (dtPerSon != null)
                    {
                        //Fill DataGridview with the Table
                        dataGridView1.DataSource = dtPerSon;

                        (dataGridView1.DataSource as DataTable).AcceptChanges();
                    }
                    //connection.Close();
                }
                catch (Exception ex)
                {
                    //connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void run()
        {
            _isFinish = false;

            //if (thread == null)
            //    thread = new Thread(GetVisibleOfThis);
            //thread.IsBackground = true;
            //thread.Start();
            _strTable = textBox2.Text;

            backgroundWorker1.WorkerReportsProgress = true;
            //异步耗时操作开始
            backgroundWorker1.RunWorkerAsync();

            while (!_isFinish)
            {
                Thread.Sleep(200);
                if (backgroundWorker1.WorkerReportsProgress)
                {
                    IDbfImport iDbfImp = DoGetImportObj();
                    int iAll = 1;
                    int iNow = 0;
                    iDbfImp.DoGetPercent(out iAll, out iNow);
                    int iPer = (iNow * 100 / iAll);

                    progressBar1.Value = iPer;
                }
            }
        }

        public void DoImport(string table)
        {
            _isFinish = false;

            //string table = textBox2.Text;
            string connectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + table + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";
            //string connectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + textBox2.Text + ";";
            using (OdbcConnection sourceConnection = new OdbcConnection(connectionString))
            {
                //sourceConnection.Open();
                // Get data from the source table as a SqlDataReader.
                OdbcDataAdapter adapter = new OdbcDataAdapter("select * from " + table, sourceConnection);

                DataTable dtPerSon = new DataTable();
                try
                {
                    //connection.Open();
                    //adapter.Fill(dataSet);
                    adapter.Fill(dtPerSon);
                    if (dtPerSon != null)
                    {
                        imp = DoGetImportObj(true);

                        string strMsg = "";
                        imp.Import(dtPerSon, out strMsg);
                        DateTime dtNow = DateTime.Now;
                        if (DateTime.TryParse(strMsg, out dtNow))
                        {
                            //返回成功
                            _strImporTime = strMsg;
                        }
                        else
                        {
                            //返回失败
                            MessageBox.Show(strMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _isFinish = true;
                            return;
                        }
                    }
                    _isFinish = true;
                    //connection.Close();
                }
                catch (Exception ex)
                {
                    //connection.Close();
                    MessageBox.Show(ex.Message);
                    _isFinish = true;
                }
            }
        }

        public void DoFinish()
        {
            //IDbfImport 
            IDbfImport imp = DoGetImportObj();//待抽象  写死市公费上传

            DateTime dtImp = DateTime.Parse(_strImporTime);

            dtpStr.Value = dtImp.AddMinutes(-1);
            dtpEnd.Value = dtImp.AddMinutes(1);

            DataTable dt = imp.QueryChangeInfo(dtpStr.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            if (dt != null)
            {
                //Fill DataGridview with the Table
                dataGridView2.DataSource = dt;
            }

            _isFinish = true;

            this.progressBar1.Value = 0;
            MessageBox.Show("完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public IDbfImport DoGetImportObj()
        {
            if (imp == null)
            {
                imp = new PfWhs();//待抽象  写死市公费上传
            }
            return imp;
        }

        public IDbfImport DoGetImportObj(bool newImp)
        {
            imp = new PfWhs();//待抽象  写死市公费上传
            return imp;
        }

        private string DDLH;
        private string RGRXM;
        private string SFZH;
        private string RGRXB;
        private string RZSSJ;
        private string RGZSJ;
        private string RGRJB;
        private string RZFBL;
        private string RRZQK;
        private string RDDY1;
        private string RDDY2;
        private string RDDY3;
        private string RBZSJ;
        private string RSZSJ;
        private string DM;
        private string BDSJ;
        private string BDLB;
        private string NXDH;
        private string RDWBH;
        private string DWBH;
        private string RRYLB;
        private string RGRBH;
        private string BZ;

        public void DoSetValueByDataRow(DataRow dr)
        {
            try
            {
                DDLH = dr["ylzh"].ToString().Trim();
                RGRXM = dr["name"].ToString().Trim();
                SFZH = dr["SFZH"].ToString().Trim();
                RGRXB = dr["xb"].ToString().Trim();
                RZSSJ = dr["csrq"].ToString().Trim();
                RGZSJ = dr["GZSJ"].ToString().Trim();

                RGRJB = dr["GRJB"].ToString().Trim();
                RZFBL = dr["ZFBL"].ToString().Trim();
                RRZQK = dr["RZQK"].ToString().Trim();
                RDDY1 = dr["DDYY1"].ToString().Trim();
                RDDY2 = dr["DDYY2"].ToString().Trim();
                RDDY3 = dr["DDYY3"].ToString().Trim();

                RBZSJ = dr["bzsj"].ToString().Trim();
                RSZSJ = dr["xzsj"].ToString().Trim();
                DM = dr["DM"].ToString().Trim();
                BDSJ = dr["ydsj"].ToString().Trim();

                BDLB = dr["ydlb"].ToString().Trim();
                NXDH = dr["lxdh"].ToString().Trim();
                RDWBH = dr["RDWBH"].ToString().Trim();
                DWBH = dr["DWBH"].ToString().Trim();
                RRYLB = dr["RRYLB"].ToString().Trim();
                RGRBH = dr["RGRBH"].ToString().Trim();
                BZ = dr["memo"].ToString().Trim();


            }
            catch { }


            DoSetExceptValue();
        }

        public void DoSetExceptValue()
        {
            {
                string bdsj = "";
                DateTime now = DateTime.Now;
                try
                {
                    //dbf 异常数据处理
                    bdsj = string.IsNullOrEmpty(BDSJ.Trim()) ? "" : BDSJ.Trim();
                    if (!DateTime.TryParse(bdsj, out now))
                    {
                        bdsj = now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    bdsj = now.ToString("yyyy-MM-dd HH:mm:ss");
                    BDSJ = bdsj;
                }
                catch
                {
                    bdsj = now.ToString("yyyy-MM-dd HH:mm:ss");
                    BDSJ = bdsj;
                }
            }

            {
                string bdsj = "";
                DateTime now = DateTime.Now;
                try
                {
                    //dbf 异常数据处理
                    bdsj = string.IsNullOrEmpty(RBZSJ.Trim()) ? "" : RBZSJ.Trim();
                    now = DateTime.Now;
                    if (!DateTime.TryParse(bdsj, out now))
                    {
                        bdsj = now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    bdsj = now.ToString("yyyy-MM-dd HH:mm:ss");
                    RBZSJ = bdsj;
                }
                catch
                {
                    bdsj = now.ToString("yyyy-MM-dd HH:mm:ss");
                    RBZSJ = bdsj;
                }
            }

            BDSJ = RBZSJ = "";
        }

        /// <summary>
        /// 校验待处理数据
        /// </summary>
        /// <param name="strYlzh">医疗证号</param>
        /// <param name="strZone">区域</param>
        /// <returns></returns>
        public int DoValid(string strYlzh, string strZone)
        {
            string strSql = "";

            strSql = string.Format(@"select count(1) as NUM from  jc_gf_patrec where ylzh='{0}' and qy='{1}' and del_bit=0", strYlzh, strZone);

            DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
            if (dt == null || dt.Rows.Count < 0)
            {
                //DoInsertChange
                return 2;
            }

            if (dt.Rows.Count >= 1)
            {
                int iCnt = int.Parse(dt.Rows[0]["NUM"].ToString().Trim());
                if (iCnt == 0)
                {
                    //DoInsert、DoInsertChange
                    return 0;
                }
                else
                {
                    //DoUpdate、DoInsertChange or DoInsertChange
                    return 1;
                }
            }

            //DoInsert、DoInsertChange
            return 0;
        }

        private DataTable DoGetPatientInfo(string strYlzh, string strZone)
        {
            string strSql = string.Format(@"select * from  jc_gf_patrec where ylzh='{0}' and qy='{1}'", strYlzh, strZone);

            return InstanceForm._database.GetDataTable(strSql);
        }

        //API函数申明
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="lpApplicationName">节名</param>
        /// <param name="lpKeyName">关键字</param>
        /// <param name="lpFileName">INI文件路径</param>
        /// <returns></returns>
        public static string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }

        private void DoSetPubfeeCfgInfo()
        {
            _yjexz = GetIniString("ldxz", "YJEXZ", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _jexz = GetIniString("ldxz", "JEXZ", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _cfsl = GetIniString("ldxz", "CFSL", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _cfslM = GetIniString("ldxz", "CFSLM", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _rJcje = GetIniString("ldxz", "RJCJE", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _rZlje = GetIniString("ldxz", "RZLJE", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");

            //_strWhsGf = GetIniString("whsgf", "ybid", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            //_strZone = GetIniString("whsgf", "qy", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            //_strYbjklx = GetIniString("ybjklx", "ybjklx", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
        }

    }

    public interface IDbfImport
    {
        /// <summary>
        /// dbf导入的抽象
        /// </summary>
        /// <param name="dtSrc">要导入的数据源</param>
        void Import(DataTable dtSrc, out string strMsg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtStr"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        DataTable QueryChangeInfo(string dtStr, string dtEnd);

        void DoGetPercent(out int iAll, out int iNow);
    }

    /// <summary>
    /// 武汉公费
    /// </summary>
    public class PfWhs : IDbfImport
    {
        string _strZone = "44443";//武汉市区域编码：此处写死
        string _strWhsGf = "21";//武汉市区域编码：此处写死
        string _strYbjklx = "4444";

        string _yjexz = "";//金额限制
        string _jexz = "";//金额限制
        string _cfsl = "";//处方数量
        string _cfslM = "";//月处方数量
        string _rJcje = "";//日检查金额
        string _rZlje = "";//日治疗金额

        public PfWhs()
        {
            DoSetPubfeeCfgInfo();
        }

        //
        private string DDLH;
        private string RGRXM;
        private string SFZH;
        private string RGRXB;
        private string RZSSJ;
        private string RGZSJ;
        private string RGRJB;
        private string RZFBL;
        private string RRZQK;
        private string RDDY1;
        private string RDDY2;
        private string RDDY3;
        private string RBZSJ;
        private string RSZSJ;
        private string DM;
        private string BDSJ;
        private string BDLB;
        private string NXDH;
        private string RDWBH;
        private string DWBH;
        private string RRYLB;
        private string RGRBH;
        private string BZ;

        int _iAll;
        int _iNow;

        public string DoInsert()
        {
            string strSql = "";
            strSql = string.Format(@"insert into jc_gf_patrec( id, ylzh,ylzh1,ylzh2, name, pym, wbm, gflx, qy, brlx, del_bit, cfsl_xz, cfslM_xz, je_xz, jcje_xz, zlje_xz,yje_xz, 
                                                                GRJB, RZQK, ZFBL, RDWBH, DWBH, RRYLB, RGRBH, SFZH, xb ,memo,
                                                                DM,lxdh, csrq,GZSJ,DDYY1,DDYY2,DDYY3,bzsj,xzsj,ydsj,ydlb,memo_1,memo_2,memo_3) 
                                                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}')",
                                                DDLH.Replace("'", "") + _strZone,
                                                DDLH.Replace("'", ""),
                                                DDLH.Replace("'", ""),
                                                DDLH.Replace("'", ""),
                                                RGRXM.Replace("'", ""),
                                                PubStaticFun.GetPYWBM(RGRXM.Replace("'", ""), 0),
                                                PubStaticFun.GetPYWBM(RGRXM.Replace("'", ""), 1),
                                                _strWhsGf,
                                                _strZone,
                                                _strYbjklx,
                                                "0",
                                                _cfsl,
                                                _cfslM,
                                                _jexz,
                                                _rJcje,
                                                _rZlje,
                                                _yjexz,
                                                RGRJB,
                                                RRZQK,
                                                RZFBL,
                                                RDWBH,
                                                DWBH,
                                                RRYLB,
                                                RGRBH,
                                                SFZH,
                                                RGRXB,
                                                BZ,
                                                "2",
                                                NXDH.Replace("'", ""),
                                                string.IsNullOrEmpty(RZSSJ.Trim()) ? "" : RZSSJ.Trim(),
                                                string.IsNullOrEmpty(RGZSJ.Trim()) ? "" : RGZSJ.Trim(),
                                                RDDY1,
                                                RDDY2,
                                                RDDY3,
                                                string.IsNullOrEmpty(RBZSJ.Trim()) ? "" : RBZSJ.Trim(),
                                                string.IsNullOrEmpty(RSZSJ.Trim()) ? "" : RSZSJ.Trim(),
                                                string.IsNullOrEmpty(BDSJ.Trim()) ? "" : BDSJ.Trim(),
                                                BDLB,
                                                "",
                                                RGRJB,
                                                RRZQK);

            //InstanceForm._database.DoCommand(strSql);
            return strSql;
        }

        public string DoUpdate()
        {
            string strSql = "";
            strSql = string.Format(@"update   [jc_gf_patrec] set  
                                            [name] = '{0}',
                                            [pym] = '{1}',
                                            [wbm] = '{2}',
                                            [GRJB] = '{3}',
                                            [RZQK] = '{4}',
                                            [ZFBL] = '{5}',
                                            [RDWBH] = '{6}',
                                            [DWBH] = '{7}',
                                            [RRYLB] = '{8}',
                                            [RGRBH] = '{9}',
                                            [SFZH] = '{10}',
                                            [xb] = '{11}',
                                            [memo] = '{12}' ,
                                            [lxdh] = '{13}',
                                            [csrq] = '{14}',
                                            [GZSJ] = '{15}',
                                            [DDYY1] = '{16}',
                                            [DDYY2] = '{17}',
                                            [DDYY3] = '{18}',
                                            [bzsj] = '{19}',
                                            [xzsj] = '{20}',
                                            [ydsj] = '{21}',
                                            [ydlb] = '{22}',
                                            [memo_1] = '{23}',
                                            [memo_2] = '{24}',
                                            [memo_3] = '{25}',
                                            [gflx] = '{26}'
                                            where  ylzh= '{27}' and  [qy] = '{28}'",
                                                RGRXM.Replace("'", ""),
                                                PubStaticFun.GetPYWBM(RGRXM.Replace("'", ""), 0),
                                                PubStaticFun.GetPYWBM(RGRXM.Replace("'", ""), 1),
                                                RGRJB,
                                                RRZQK,
                                                RZFBL,
                                                RDWBH,
                                                DWBH,
                                                RRYLB,
                                                RGRBH,
                                                SFZH,
                                                RGRXB,
                                                BZ,
                                                NXDH.Replace("'", ""),
                                                string.IsNullOrEmpty(RZSSJ.Trim()) ? "" : RZSSJ.Trim(),
                                                string.IsNullOrEmpty(RGZSJ.Trim()) ? "" : RGZSJ.Trim(),
                                                RDDY1,
                                                RDDY2,
                                                RDDY3,
                                                string.IsNullOrEmpty(RBZSJ.Trim()) ? "" : RBZSJ.Trim(),
                                                string.IsNullOrEmpty(RSZSJ.Trim()) ? "" : RSZSJ.Trim(),
                                                string.IsNullOrEmpty(BDSJ.Trim()) ? "" : BDSJ.Trim(),
                                                BDLB,
                                                "",
                                                RGRJB,
                                                RRZQK,
                                                _strWhsGf,
                                                DDLH,
                                                _strZone);
            return strSql;
        }

        public string DoInsertChange(int iStatus, DateTime importTime)
        {
            ;
            string strSql = "";
            strSql = string.Format(@"insert into jc_gf_patrec_Change( id, ylzh, name, pym, wbm, gflx, qy, brlx, del_bit, cfsl_xz, cfslM_xz, 
                                                                je_xz, jcje_xz, zlje_xz,yje_xz, GRJB, RZQK, ZFBL, RDWBH, DWBH, RRYLB, RGRBH, SFZH, xb ,memo,
                                                                DM,lxdh, csrq,GZSJ,DDYY1,DDYY2,DDYY3,bzsj,xzsj,ydsj,ydlb,drsj,cxsj,dr_bit,memo_1,memo_2,memo_3) 
                                                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}')",
                                                DDLH.Replace("'", "") + _strZone,
                                                DDLH.Replace("'", ""),
                                                RGRXM.Replace("'", ""),
                                                PubStaticFun.GetPYWBM(RGRXM.Replace("'", ""), 0),
                                                PubStaticFun.GetPYWBM(RGRXM.Replace("'", ""), 1),
                                                _strWhsGf,
                                                _strZone,
                                                _strYbjklx,
                                                "0",
                                                _cfsl,
                                                _cfslM,
                                                _jexz,
                                                _rJcje,
                                                _rZlje,
                                                _yjexz,
                                                RGRJB,
                                                RRZQK,
                                                RZFBL,
                                                RDWBH,
                                                DWBH,
                                                RRYLB,
                                                RGRBH,
                                                SFZH,
                                                RGRXB,
                                                BZ,
                                                "2",
                                                NXDH.Replace("'", ""),
                                                string.IsNullOrEmpty(RZSSJ.Trim()) ? "" : RZSSJ.Trim(),
                                                string.IsNullOrEmpty(RGZSJ.Trim()) ? "" : RGZSJ.Trim(),
                                                RDDY1,
                                                RDDY2,
                                                RDDY3,
                                                string.IsNullOrEmpty(RBZSJ.Trim()) ? "" : RBZSJ.Trim(),
                                                string.IsNullOrEmpty(RSZSJ.Trim()) ? "" : RSZSJ.Trim(),
                                                string.IsNullOrEmpty(BDSJ.Trim()) ? "" : BDSJ.Trim(),
                                                BDLB,
                                                importTime,
                                                importTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                                iStatus,
                                                "",
                                                RGRJB,
                                                RRZQK
                                                );
            return strSql;
        }

        public void DoSetValueByDataRow(DataRow dr)
        {
            try
            {
                DDLH = dr["DDLH"].ToString().Trim();
                RGRXM = dr["RGRXM"].ToString().Trim();
                SFZH = dr["SFZH"].ToString().Trim();
                RGRXB = dr["RGRXB"].ToString().Trim();
                RZSSJ = dr["RZSSJ"].ToString().Trim();
                RGZSJ = dr["RGZSJ"].ToString().Trim();

                RGRJB = dr["RGRJB"].ToString().Trim();
                RZFBL = dr["RZFBL"].ToString().Trim();
                RRZQK = dr["RRZQK"].ToString().Trim();
                RDDY1 = dr["RDDY1"].ToString().Trim();
                RDDY2 = dr["RDDY2"].ToString().Trim();
                RDDY3 = dr["RDDY3"].ToString().Trim();
                RBZSJ = dr["RBZSJ"].ToString().Trim();
                RSZSJ = dr["RSZSJ"].ToString().Trim();
                DM = dr["DM"].ToString().Trim();
                BDSJ = dr["BDSJ"].ToString().Trim();

                BDLB = dr["BDLB"].ToString().Trim();
                NXDH = dr["NXDH"].ToString().Trim();
                RDWBH = dr["RDWBH"].ToString().Trim();
                DWBH = dr["DWBH"].ToString().Trim();
                RRYLB = dr["RRYLB"].ToString().Trim();
                RGRBH = dr["RGRBH"].ToString().Trim();
                BZ = dr["BZ"].ToString().Trim();


            }
            catch { }


            DoSetExceptValue();
        }

        public void DoSetExceptValue()
        {
            {
                string bdsj = "";
                DateTime now = DateTime.Now;
                try
                {
                    //dbf 异常数据处理
                    bdsj = string.IsNullOrEmpty(BDSJ.Trim()) ? "" : BDSJ.Trim();
                    if (!DateTime.TryParse(bdsj, out now))
                    {
                        bdsj = now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    bdsj = now.ToString("yyyy-MM-dd HH:mm:ss");
                    BDSJ = bdsj;
                }
                catch
                {
                    bdsj = now.ToString("yyyy-MM-dd HH:mm:ss");
                    BDSJ = bdsj;
                }
            }

            {
                string bdsj = "";
                DateTime now = DateTime.Now;
                try
                {
                    //dbf 异常数据处理
                    bdsj = string.IsNullOrEmpty(RBZSJ.Trim()) ? "" : RBZSJ.Trim();
                    now = DateTime.Now;
                    if (!DateTime.TryParse(bdsj, out now))
                    {
                        bdsj = now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    bdsj = now.ToString("yyyy-MM-dd HH:mm:ss");
                    RBZSJ = bdsj;
                }
                catch
                {
                    bdsj = now.ToString("yyyy-MM-dd HH:mm:ss");
                    RBZSJ = bdsj;
                }
            }

            BDSJ = RBZSJ = "";
        }

        /// <summary>
        /// 校验待处理数据
        /// </summary>
        /// <param name="strYlzh">医疗证号</param>
        /// <param name="strZone">区域</param>
        /// <returns></returns>
        public int DoValid(string strYlzh, string strZone)
        {
            string strSql = "";

            strSql = string.Format(@"select count(1) as NUM from  jc_gf_patrec where ylzh='{0}' and qy='{1}' and del_bit=0", strYlzh, strZone);

            DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
            if (dt == null || dt.Rows.Count < 0)
            {
                //DoInsertChange
                return 2;
            }

            if (dt.Rows.Count >= 1)
            {
                int iCnt = int.Parse(dt.Rows[0]["NUM"].ToString().Trim());
                if (iCnt == 0)
                {
                    //DoInsert、DoInsertChange
                    return 0;
                }
                else
                {
                    //DoUpdate、DoInsertChange or DoInsertChange
                    return 1;
                }
            }

            //DoInsert、DoInsertChange
            return 0;
        }

        private DataTable DoGetPatientInfo(string strYlzh, string strZone)
        {
            string strSql = string.Format(@"select * from  jc_gf_patrec where ylzh='{0}' and qy='{1}'", strYlzh, strZone);

            return InstanceForm._database.GetDataTable(strSql);
        }

        #region IDbfImport 成员

        public void Import(DataTable dtSrc, out string strMsg)
        {
            strMsg = "";
            DateTime importTime = DateManager.ServerDateTimeByDBType(InstanceForm._database);
            try
            {
                if (dtSrc != null)
                {
                    string strSql = "";

                    //循环处理人员信息
                    //新增的ylzh则insert，已存在则对比name后直接进行update操作
                    //获取所有update的数据，及未覆盖的数据插入
                    for (int i = 0; i < dtSrc.Rows.Count; i++)
                    {
                        _iAll = dtSrc.Rows.Count;
                        _iNow = i;
                        DataRow drSrc = dtSrc.Rows[i];

                        int iRet = DoValid(drSrc["DDLH"].ToString().Trim(), _strZone);

                        DoSetValueByDataRow(drSrc);//赋值给变量

                        //错误数据处理
                        try
                        {
                            if (iRet == 2)
                            {
                                strSql = DoInsertChange(2, importTime);
                                InstanceForm._database.DoCommand(strSql);
                            }
                            else if (iRet == 1)
                            {
                                //已存在则对比name，相同直接进行update操作,否则不update
                                DataTable dtHis = DoGetPatientInfo(drSrc["DDLH"].ToString().Trim(), _strZone);
                                if (dtHis == null || dtHis.Rows.Count <= 0)
                                {
                                    strSql = DoInsertChange(2, importTime);
                                    InstanceForm._database.DoCommand(strSql);
                                }
                                else
                                {
                                    DataRow drHis = dtHis.Rows[0];

                                    //通过人员姓名判断是否同人
                                    if (drSrc["RGRXM"].ToString().Trim().Equals(drHis["name"].ToString().Trim()))
                                    {
                                        strSql = DoUpdate();
                                        InstanceForm._database.DoCommand(strSql);

                                        strSql = DoInsertChange(1, importTime);
                                        InstanceForm._database.DoCommand(strSql);
                                    }
                                    else
                                    {
                                        strSql = DoInsertChange(2, importTime);
                                        InstanceForm._database.DoCommand(strSql);
                                    }
                                }
                            }
                            else if (iRet == 0)
                            {
                                strSql = DoInsert();
                                InstanceForm._database.DoCommand(strSql);

                                strSql = DoInsertChange(0, importTime);
                                InstanceForm._database.DoCommand(strSql);
                            }
                        }
                        catch
                        {
                            strSql = DoInsertChange(2, importTime);
                            InstanceForm._database.DoCommand(strSql);
                        }
                    }

                    strMsg = importTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
            }
        }

        public DataTable QueryChangeInfo(string dtStr, string dtEnd)
        {
            try
            {
                string sql = string.Format("select case dr_bit when '0' then '新增' when '1' then '修改' when '2' then '出错' else '其他错误' end as cwxx,* from  jc_gf_patrec_Change where drsj>='{0}' and drsj<'{1}' order by dr_bit", dtStr, dtEnd);

                return InstanceForm._database.GetDataTable(sql);
            }
            catch { }
            return null;
        }

        public void DoGetPercent(out int iAll, out int iNow)
        {
            iAll = _iAll == 0 ? 1 : _iAll;
            iNow = _iNow;
        }

        #endregion

        private void DoSetPubfeeCfgInfo()
        {
            _yjexz = GetIniString("ldxz", "YJEXZ", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _jexz = GetIniString("ldxz", "JEXZ", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _cfsl = GetIniString("ldxz", "CFSL", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _cfslM = GetIniString("ldxz", "CFSLM", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _rJcje = GetIniString("ldxz", "RJCJE", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _rZlje = GetIniString("ldxz", "RZLJE", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");

            _strWhsGf = GetIniString("whsgf", "ybid", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _strZone = GetIniString("whsgf", "qy", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _strYbjklx = GetIniString("ybjklx", "ybjklx", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
        }

        //API函数申明
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="lpApplicationName">节名</param>
        /// <param name="lpKeyName">关键字</param>
        /// <param name="lpFileName">INI文件路径</param>
        /// <returns></returns>
        public static string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }
    }
}