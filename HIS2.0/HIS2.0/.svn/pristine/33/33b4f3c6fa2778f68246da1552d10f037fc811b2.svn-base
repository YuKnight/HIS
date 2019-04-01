using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

namespace SystemUpdate
{
   
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class FrmUpdate : System.Windows.Forms.Form
    {
        //自定义变量
        private string pConnectionString = "";
        private IDbConnection pConn;
        private static DataTable systemUpdateTB = null;
        private static string oldVersion = "";
        private static string newVersion = "";
        private static string systemUpdateName = "";	//系统升级程序的程序名
        private static string mainExeName = "";		//系统主程序的程序名
        private static string customDirectory = "";	//用户自定义路径
        private const int BUFFER_LENGTH = 4096;
        private const string INIFILENAME = "SYSUPDATE.INI";
        private string customReportDirectory = "";//指定的报表文件目录
        //自动生成变量
        private System.Windows.Forms.StatusBar sttbMain;
        private System.Windows.Forms.StatusBarPanel sttbDesc;
        private System.Windows.Forms.PictureBox picUpdate;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusBarPanel sttbplFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pbCurrent;
        private System.Windows.Forms.ProgressBar pbTotal;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ListBox lstInfo;
        private System.ComponentModel.IContainer components = null;

        public FrmUpdate()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmUpdate));
            this.sttbMain = new System.Windows.Forms.StatusBar();
            this.sttbplFiles = new System.Windows.Forms.StatusBarPanel();
            this.sttbDesc = new System.Windows.Forms.StatusBarPanel();
            this.picUpdate = new System.Windows.Forms.PictureBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbCurrent = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbTotal = new System.Windows.Forms.ProgressBar();
            this.btnOk = new System.Windows.Forms.Button();
            this.lstInfo = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.sttbplFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sttbDesc)).BeginInit();
            this.SuspendLayout();
            // 
            // sttbMain
            // 
            this.sttbMain.Location = new System.Drawing.Point(0, 202);
            this.sttbMain.Name = "sttbMain";
            this.sttbMain.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						this.sttbplFiles,
																						this.sttbDesc});
            this.sttbMain.ShowPanels = true;
            this.sttbMain.Size = new System.Drawing.Size(454, 24);
            this.sttbMain.TabIndex = 0;
            // 
            // sttbplFiles
            // 
            this.sttbplFiles.Text = "文件";
            this.sttbplFiles.Width = 240;
            // 
            // sttbDesc
            // 
            this.sttbDesc.Text = "正在下载最新程序...............";
            this.sttbDesc.Width = 200;
            // 
            // picUpdate
            // 
            this.picUpdate.Image = ((System.Drawing.Image)(resources.GetObject("picUpdate.Image")));
            this.picUpdate.Location = new System.Drawing.Point(4, 4);
            this.picUpdate.Name = "picUpdate";
            this.picUpdate.Size = new System.Drawing.Size(54, 40);
            this.picUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUpdate.TabIndex = 1;
            this.picUpdate.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(72, 26);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(128, 17);
            this.lblUpdate.TabIndex = 2;
            this.lblUpdate.Text = "从旧版本升级到新版本";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "发现新版本！";
            // 
            // pbCurrent
            // 
            this.pbCurrent.Location = new System.Drawing.Point(72, 52);
            this.pbCurrent.Name = "pbCurrent";
            this.pbCurrent.Size = new System.Drawing.Size(380, 18);
            this.pbCurrent.Step = 1;
            this.pbCurrent.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "当前进度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "总体进度：";
            // 
            // pbTotal
            // 
            this.pbTotal.Location = new System.Drawing.Point(72, 74);
            this.pbTotal.Name = "pbTotal";
            this.pbTotal.Size = new System.Drawing.Size(380, 18);
            this.pbTotal.Step = 1;
            this.pbTotal.TabIndex = 6;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(370, 176);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(82, 24);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "升级完成";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lstInfo
            // 
            this.lstInfo.ItemHeight = 12;
            this.lstInfo.Location = new System.Drawing.Point(2, 96);
            this.lstInfo.Name = "lstInfo";
            this.lstInfo.Size = new System.Drawing.Size(448, 76);
            this.lstInfo.TabIndex = 9;
            this.lstInfo.TabStop = false;
            // 
            // FrmUpdate
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(454, 226);
            this.Controls.Add(this.lstInfo);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.pbTotal);
            this.Controls.Add(this.pbCurrent);
            this.Controls.Add(this.picUpdate);
            this.Controls.Add(this.sttbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统升级";
            this.Load += new System.EventHandler(this.FrmUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sttbplFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sttbDesc)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

       
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="type">类型0、SQL SERVER 1、IBM DB2</param>
        /// <param name="applicationName">INI文件中段(SECTION)名称</param>
        private static string GetConnnectionString(ConnectionType type, string applicationName)
        {
            string cnnString, hostName, database, userID, password, protocol, port, strCnnType;
            switch (type)
            {
                case ConnectionType.SQLSERVER:
                    hostName = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "HOSTNAME", Application.StartupPath + "\\ClientConfig.ini"));
                    database = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "DATASOURCE", Application.StartupPath + "\\ClientConfig.ini"));
                    userID = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "USER_ID", Application.StartupPath + "\\ClientConfig.ini"));
                    password = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "PASSWORD", Application.StartupPath + "\\ClientConfig.ini"));
                    cnnString = @"packet size=4096;user id=" + userID + ";password=" + password + ";data source=" + hostName + ";persist security info=True;initial catalog=" + database;
                    break;
                case ConnectionType.IBMDB2:
                    hostName = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "HOSTNAME", Application.StartupPath + "\\ClientConfig.ini"));
                    protocol = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "PROTOCOL", Application.StartupPath + "\\ClientConfig.ini"));
                    port = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "PORT", Application.StartupPath + "\\ClientConfig.ini"));
                    database = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "DATASOURCE", Application.StartupPath + "\\ClientConfig.ini"));
                    userID = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "USER_ID", Application.StartupPath + "\\ClientConfig.ini"));
                    password = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "PASSWORD", Application.StartupPath + "\\ClientConfig.ini"));
                    strCnnType = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "CONNECTIONTYPE", Application.StartupPath + "\\ClientConfig.ini"));
                    if (strCnnType == "1")
                        cnnString = @"Provider=IBMDADB2;Database=" + database + ";HostName=" + hostName + ";Protocol=" + protocol + ";Port=" + port + ";User ID=" + userID + ";Password=" + password;
                    else
                        cnnString = @"Provider=IBMDADB2.1;User ID=" + userID + ";Password=" + password + ";Data Source=" + database + ";Mode=ReadWrite;Extended Properties=";
                    break;
                case ConnectionType.MSACCESS:
                    database = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "DATASOURCE", Application.StartupPath + "\\ClientConfig.ini"));
                    cnnString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=" + database + ";Mode=Share Deny None;Jet OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
                    break;
                default:
                    cnnString = "";
                    break;
            }
            return cnnString;
        }

        private void GetNewFile()
        {
            string serverName = ApiFunction.GetIniString("SERVER_NAME", "NAME", Application.StartupPath + "\\ClientConfig.ini");
            if (serverName == "")
            {
                System.Windows.Forms.MessageBox.Show("ClientConfig.ini中[SERVER_NAME]的NAME未设置,请启动配置程序并设置当前服务器", "错误");
                Application.Exit();
                return;
            }
            string connectionString = GetConnnectionString(ConnectionType.SQLSERVER, serverName); // ****************设置获取连接字符串**********************
            pConnectionString = connectionString;
            ConnectionType connectionType = ConnectionType.SQLSERVER;

            #region 获得系统升级DataTable
            string commandText = "select id,type,name,update_time,version,dellocalreport from pub_systemupdate where delete_bit=0";
            systemUpdateTB = new DataTable();
            IDbConnection cnn;
            IDbCommand cmd;
            IDbDataAdapter adapter;
            switch (connectionType)
            {
                case ConnectionType.SQLSERVER:
                    cnn = new SqlConnection(connectionString);
                    cmd = new SqlCommand(commandText);
                    cmd.Connection = (SqlConnection)cnn;
                    adapter = new SqlDataAdapter((SqlCommand)cmd);
                    ((SqlDataAdapter)adapter).Fill(systemUpdateTB);
                    cmd.Dispose();
                    cmd = null;
                    ((SqlDataAdapter)adapter).Dispose();
                    adapter = null;
                    break;
                default:
                    cnn = new OleDbConnection(connectionString);
                    cmd = new OleDbCommand(commandText);
                    cmd.Connection = (OleDbConnection)cnn;
                    adapter = new OleDbDataAdapter((OleDbCommand)cmd);
                    ((OleDbDataAdapter)adapter).Fill(systemUpdateTB);
                    ((OleDbDataAdapter)adapter).Dispose();
                    adapter = null;
                    break;

            }
            #endregion
        }


        private Object GetFileValue(int ID)
        {
            IDbCommand cmd;

            string commandText = "select file_value from pub_systemupdate where id=" + ID;
            try
            {
                if (pConn == null)
                {
                    pConn = new SqlConnection(pConnectionString);
                    pConn.Open();
                }
                else
                {
                    if (pConn.State == ConnectionState.Closed)
                    {
                        pConn = new SqlConnection(pConnectionString);
                        pConn.Open();
                    }
                }

                cmd = new SqlCommand(commandText);
                cmd.Connection = (SqlConnection)pConn;
                Object obj = cmd.ExecuteScalar();
                cmd.Dispose();
                cmd = null;


                return obj;
            }
            catch
            {
                return null;
            }

        }

        private void FileUpdate()
        {

            string iniFile = Application.StartupPath + "\\UpdateFile.ini";
            try
            {
                this.btnOk.Enabled = false;
                FileStream fw = null;
                pbTotal.Maximum = systemUpdateTB.Rows.Count;
                pbTotal.Value = 0;
                this.Refresh();
                for (int i = 0; i < systemUpdateTB.Rows.Count; i++)
                {
                    try
                    {
                        int id = Convert.ToInt32(systemUpdateTB.Rows[i]["ID"]);
                        string fileName = systemUpdateTB.Rows[i]["name"].ToString();
                        string localVersion = ApiFunction.GetIniString("FILEINFO", fileName, iniFile);
                        string serverVersion = systemUpdateTB.Rows[i]["Version"].ToString();
                        string fullFileName = Application.StartupPath + "\\" + fileName;
                        string exName = fileName.Substring(fileName.Length - 3, 3);
                        #region ...
                        //增加判断 Modify By Tany 2010-03-24
                        if ((File.Exists(Application.StartupPath + "\\SysUpdate.exe") && fileName.ToUpper() == "SYSUPDATE.EXE")
                            || (File.Exists(Application.StartupPath + "\\SysUpdateEx.exe") && fileName.ToUpper() == "SYSUPDATEEX.EXE"))
                        {
                            //如果升级文件是自身，跳过
                            continue;
                        }
                        if (exName.Trim().ToUpper() == "RPT")
                        {
                            fullFileName = Application.StartupPath + "\\report\\" + fileName; //当前路径下的报表文件夹
                        }
                        int flag = Convert.IsDBNull(systemUpdateTB.Rows[i]["DelLocalReport"]) ? 0 : Convert.ToInt32(systemUpdateTB.Rows[i]["DelLocalReport"]);
                        #endregion
                        if (localVersion.Trim().ToUpper() != serverVersion.Trim().ToUpper())
                        {
                            lblUpdate.Text = "从旧版本（" + localVersion + "）升级到新版本（" + serverVersion + "）";
                            //DataRow dr = this.GetFileValue(id);
                            Object obj = this.GetFileValue(id);// dr["file_value"];
                            if (obj != null && !Convert.IsDBNull(obj))
                            {
                                if (File.Exists(fullFileName))
                                {
                                    File.Delete(fullFileName);
                                }
                                #region ...
                                fw = new FileStream(fullFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                                sttbplFiles.Text = fileName;

                                byte[] buffer = (byte[])obj;
                                int fileLength = (int)buffer.Length / BUFFER_LENGTH;
                                if (fileLength * BUFFER_LENGTH < buffer.Length)
                                {
                                    fileLength++;
                                }
                                pbCurrent.Maximum = fileLength;
                                pbCurrent.Value = 0;
                                for (int j = 0; j < fileLength; j++)	//以长度为BUFFER_LENGTH字节的块进行传送
                                {
                                    if (buffer.Length - j * BUFFER_LENGTH >= BUFFER_LENGTH)
                                    {
                                        fw.Write(buffer, j * BUFFER_LENGTH, BUFFER_LENGTH);
                                    }
                                    else
                                    {
                                        fw.Write(buffer, j * BUFFER_LENGTH, buffer.Length - j * BUFFER_LENGTH);
                                    }
                                    fw.Seek(0, SeekOrigin.End);
                                    pbCurrent.Value++;
                                    this.Refresh();
                                }

                                #endregion
                                if (flag == 1)
                                {
                                    //删除指定目录下的报表文件
                                    if (File.Exists(this.CustomDirectory + "\\report\\" + fileName))
                                    {
                                        File.Delete(this.CustomDirectory + "\\report\\" + fileName);
                                    }
                                }
                                ApiFunction.WriteIniString("FILEINFO", fileName, serverVersion, iniFile);
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        this.lstInfo.Items.Add(err.Message.ToString());
                        continue;
                    }
                    finally
                    {
                        pbTotal.PerformStep();
                    }
                }

                this.sttbDesc.Text = "升级成功!";
                this.btnOk.Enabled = true;

                //btnOk_Click(null, null);	
            }
            catch (Exception err)
            {

                MessageBox.Show("升级失败：\n" + err.Message, "错误");
                //Process.Start(Application.StartupPath+ "\\"+mainExeName);
                this.Close();
            }
            finally
            {
                if (pConn != null && pConn.State == ConnectionState.Open)
                    pConn.Close();
                if (pConn != null)
                    pConn.Dispose();
            }
        }
        /// <summary>
        /// 用户自定义可改写路径
        /// </summary>
        public string CustomDirectory
        {
            get
            {
                string strDir = "";
                try
                {
                    string tmpDir = ApiFunction.GetIniString("CUSTOMDIRRECTORY", "DIRECTORY", Application.StartupPath + "\\ClientConfig.ini");
                    if (tmpDir.Trim() != "")
                    {
                        strDir = Crypto.Instance().Decrypto(tmpDir);
                    }
                    else
                    {
                        strDir = "";
                    }
                    #region 如果ini没有配置，获取数据库配置
                    if (strDir.Trim() == "")
                    {
                        IDbConnection _conn = new SqlConnection(pConnectionString);
                        try
                        {
                            _conn.Open();
                            IDbCommand _cmd = _conn.CreateCommand();
                            _cmd.CommandText = "select config from jc_config where id=0001";
                            _cmd.CommandType = CommandType.Text;
                            object obj = _cmd.ExecuteScalar();
                            strDir = obj.ToString().Trim();
                            if (strDir == "" || !Directory.Exists(strDir))
                            {
                                MessageBox.Show("参数0001配置错误", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return Application.StartupPath;
                            }
                            //写入ini
                            ApiFunction.WriteIniString("CUSTOMDIRRECTORY", "DIRECTORY", Crypto.Instance().Encrypto(strDir), Application.StartupPath + "\\ClientConfig.ini");
                        }
                        catch
                        {
                            MessageBox.Show("获取数据库自定义报表路径错误", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return Application.StartupPath;
                        }
                        finally
                        {
                            if (_conn != null && _conn.State == ConnectionState.Open)
                            {
                                _conn.Close();
                            }
                        }
                    }
                    #endregion
                    if (!Directory.Exists(strDir))			//如果该路径不存在则建立该目录
                    {
                        Directory.CreateDirectory(strDir);
                    }
                    if (!File.Exists(strDir + "\\ClientConfig.ini"))	//如果配置文件不存在则从安装目录拷贝
                    {
                        File.Copy(Application.StartupPath + "\\ClientConfig.ini", strDir + "\\ClientConfig.ini", true);
                    }

                    return strDir;
                }
                catch//(Exception err)
                {
                    MessageBox.Show("请正确设置系统配置文件路径参数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return Application.StartupPath;
                }
            }
        }
        #region 事件
        private void FrmUpdate_Load(object sender, System.EventArgs e)
        {
            Frmflash f = new Frmflash();
            f.Show();
            f.Refresh();
            GetNewFile();
            f.Close();
            FileUpdate();
            //Thread fileUpdate = new Thread(new ThreadStart(FileUpdate));
            //fileUpdate.Start();

            //FileUpdate();
        }
        #endregion

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            this.Close();
            try
            {
                Process.Start("Trasen.exe");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
