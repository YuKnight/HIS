using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_wfsyzcx
{
    /// <summary>
    /// Form3 的摘要说明。
    /// </summary>
    public class frmYZCX : System.Windows.Forms.Form
    {

        private BaseFunc myFunc = new BaseFunc();

        private string sPaint = "";
        private int max_len0 = 0, max_len1 = 0, max_len2 = 0;//最长的医嘱长度,最长的医嘱长度(有数量单位的),最长的数量单位长度	
        private int Kind = 0;//开或停
        private Guid old_BinID = Guid.Empty;
        private long old_BabyID = 0;

        private System.Windows.Forms.Panel panel总;
        private System.Windows.Forms.Panel panel下;
        private System.Windows.Forms.Button bt退出;
        private 病人信息.PatientInfo patientInfo1;
        private 价格信息.PriceInfo priceInfo1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btOpenModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel中;
        private System.Windows.Forms.RadioButton rb所有病人;
        private System.Windows.Forms.RadioButton rb选定病人;
        private System.Windows.Forms.Button bt反选;
        private System.Windows.Forms.Button bt全选;
        private System.Windows.Forms.Button bt显示切换;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.Button tb查询;
        private System.Windows.Forms.DateTimePicker DateExecDate;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmYZCX(string _formText)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;
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
            this.panel总 = new System.Windows.Forms.Panel();
            this.panel中 = new System.Windows.Forms.Panel();
            this.rb所有病人 = new System.Windows.Forms.RadioButton();
            this.rb选定病人 = new System.Windows.Forms.RadioButton();
            this.bt反选 = new System.Windows.Forms.Button();
            this.bt全选 = new System.Windows.Forms.Button();
            this.bt显示切换 = new System.Windows.Forms.Button();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.panel下 = new System.Windows.Forms.Panel();
            this.bt退出 = new System.Windows.Forms.Button();
            this.tb查询 = new System.Windows.Forms.Button();
            this.patientInfo1 = new 病人信息.PatientInfo();
            this.priceInfo1 = new 价格信息.PriceInfo();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btOpenModel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DateExecDate = new System.Windows.Forms.DateTimePicker();
            this.panel总.SuspendLayout();
            this.panel中.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel下.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel总
            // 
            this.panel总.Controls.Add(this.panel中);
            this.panel总.Controls.Add(this.panel下);
            this.panel总.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel总.Location = new System.Drawing.Point(0, 0);
            this.panel总.Name = "panel总";
            this.panel总.Size = new System.Drawing.Size(1028, 749);
            this.panel总.TabIndex = 1;
            // 
            // panel中
            // 
            this.panel中.Controls.Add(this.rb所有病人);
            this.panel中.Controls.Add(this.rb选定病人);
            this.panel中.Controls.Add(this.bt反选);
            this.panel中.Controls.Add(this.bt全选);
            this.panel中.Controls.Add(this.bt显示切换);
            this.panel中.Controls.Add(this.myDataGrid1);
            this.panel中.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel中.Location = new System.Drawing.Point(0, 0);
            this.panel中.Name = "panel中";
            this.panel中.Size = new System.Drawing.Size(1028, 621);
            this.panel中.TabIndex = 1;
            // 
            // rb所有病人
            // 
            this.rb所有病人.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb所有病人.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb所有病人.Location = new System.Drawing.Point(776, 3);
            this.rb所有病人.Name = "rb所有病人";
            this.rb所有病人.Size = new System.Drawing.Size(72, 18);
            this.rb所有病人.TabIndex = 82;
            this.rb所有病人.Text = "所有病人";
            this.rb所有病人.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rb所有病人.UseVisualStyleBackColor = false;
            // 
            // rb选定病人
            // 
            this.rb选定病人.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb选定病人.Checked = true;
            this.rb选定病人.Location = new System.Drawing.Point(672, 3);
            this.rb选定病人.Name = "rb选定病人";
            this.rb选定病人.Size = new System.Drawing.Size(72, 18);
            this.rb选定病人.TabIndex = 81;
            this.rb选定病人.TabStop = true;
            this.rb选定病人.Text = "选定病人";
            this.rb选定病人.UseVisualStyleBackColor = false;
            // 
            // bt反选
            // 
            this.bt反选.BackColor = System.Drawing.Color.PaleGreen;
            this.bt反选.Location = new System.Drawing.Point(944, 1);
            this.bt反选.Name = "bt反选";
            this.bt反选.Size = new System.Drawing.Size(56, 20);
            this.bt反选.TabIndex = 80;
            this.bt反选.Text = "反选(&F)";
            this.bt反选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt反选.UseVisualStyleBackColor = false;
            this.bt反选.Click += new System.EventHandler(this.bt反选_Click);
            // 
            // bt全选
            // 
            this.bt全选.BackColor = System.Drawing.Color.PaleGreen;
            this.bt全选.Location = new System.Drawing.Point(872, 1);
            this.bt全选.Name = "bt全选";
            this.bt全选.Size = new System.Drawing.Size(56, 20);
            this.bt全选.TabIndex = 79;
            this.bt全选.Text = "全选(&A)";
            this.bt全选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt全选.UseVisualStyleBackColor = false;
            this.bt全选.Click += new System.EventHandler(this.bt全选_Click);
            // 
            // bt显示切换
            // 
            this.bt显示切换.BackColor = System.Drawing.Color.PaleTurquoise;
            this.bt显示切换.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt显示切换.Location = new System.Drawing.Point(2, 22);
            this.bt显示切换.Name = "bt显示切换";
            this.bt显示切换.Size = new System.Drawing.Size(16, 20);
            this.bt显示切换.TabIndex = 69;
            this.bt显示切换.UseVisualStyleBackColor = false;
            this.bt显示切换.Click += new System.EventHandler(this.bt显示切换_Click);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "未发送医嘱明细";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(1028, 621);
            this.myDataGrid1.TabIndex = 25;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.myDataGrid1_Paint);
            this.myDataGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myDataGrid1_MouseUp);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel下
            // 
            this.panel下.Controls.Add(this.bt退出);
            this.panel下.Controls.Add(this.tb查询);
            this.panel下.Controls.Add(this.patientInfo1);
            this.panel下.Controls.Add(this.priceInfo1);
            this.panel下.Controls.Add(this.progressBar1);
            this.panel下.Controls.Add(this.btOpenModel);
            this.panel下.Controls.Add(this.groupBox1);
            this.panel下.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel下.Location = new System.Drawing.Point(0, 621);
            this.panel下.Name = "panel下";
            this.panel下.Size = new System.Drawing.Size(1028, 128);
            this.panel下.TabIndex = 2;
            // 
            // bt退出
            // 
            this.bt退出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt退出.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt退出.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt退出.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt退出.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt退出.ImageIndex = 4;
            this.bt退出.Location = new System.Drawing.Point(920, 64);
            this.bt退出.Name = "bt退出";
            this.bt退出.Size = new System.Drawing.Size(80, 32);
            this.bt退出.TabIndex = 63;
            this.bt退出.Text = "退出(&E)";
            this.bt退出.Click += new System.EventHandler(this.bt退出_Click);
            // 
            // tb查询
            // 
            this.tb查询.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb查询.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tb查询.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb查询.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tb查询.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb查询.ImageIndex = 9;
            this.tb查询.Location = new System.Drawing.Point(800, 65);
            this.tb查询.Name = "tb查询";
            this.tb查询.Size = new System.Drawing.Size(80, 32);
            this.tb查询.TabIndex = 62;
            this.tb查询.Text = "查询(&C)";
            this.tb查询.Click += new System.EventHandler(this.bt查询_Click);
            // 
            // patientInfo1
            // 
            this.patientInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.patientInfo1.BackColor = System.Drawing.Color.LightGray;
            this.patientInfo1.Location = new System.Drawing.Point(0, 1);
            this.patientInfo1.Name = "patientInfo1";
            this.patientInfo1.Size = new System.Drawing.Size(460, 124);
            this.patientInfo1.TabIndex = 60;
            // 
            // priceInfo1
            // 
            this.priceInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.priceInfo1.Location = new System.Drawing.Point(464, 1);
            this.priceInfo1.Name = "priceInfo1";
            this.priceInfo1.Size = new System.Drawing.Size(312, 120);
            this.priceInfo1.TabIndex = 59;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(776, 113);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(248, 8);
            this.progressBar1.TabIndex = 58;
            // 
            // btOpenModel
            // 
            this.btOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenModel.Enabled = false;
            this.btOpenModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpenModel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btOpenModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOpenModel.ImageIndex = 1;
            this.btOpenModel.Location = new System.Drawing.Point(776, 57);
            this.btOpenModel.Name = "btOpenModel";
            this.btOpenModel.Size = new System.Drawing.Size(248, 48);
            this.btOpenModel.TabIndex = 61;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DateExecDate);
            this.groupBox1.Location = new System.Drawing.Point(776, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 48);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "最大未发送日期";
            // 
            // DateExecDate
            // 
            this.DateExecDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateExecDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DateExecDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateExecDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateExecDate.Location = new System.Drawing.Point(64, 16);
            this.DateExecDate.Name = "DateExecDate";
            this.DateExecDate.ShowUpDown = true;
            this.DateExecDate.Size = new System.Drawing.Size(104, 23);
            this.DateExecDate.TabIndex = 12;
            this.DateExecDate.Value = new System.DateTime(2003, 9, 20, 19, 22, 0, 0);
            // 
            // frmYZCX
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1028, 749);
            this.Controls.Add(this.panel总);
            this.Name = "frmYZCX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "未发送医嘱查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYZCX_Load);
            this.panel总.ResumeLayout(false);
            this.panel中.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel下.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmYZCX_Load(object sender, System.EventArgs e)
        {
            this.DateExecDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);																		//服务器当前系统日期
            //this.DateExecDate.MaxDate=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Date.AddDays(ClassStatic.Static_Exec_MaxDays).ToString()+" 23:59:59");					//系统日期    -最小
            //System.TimeSpan diff = new System.TimeSpan(ClassStatic.Static_Exec_MaxDays, 0, 0, 0);  			
            //this.DateExecDate.MinDate=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Subtract(diff).ToShortDateString()+" 23:59:59");	    //系统日期-Static_Exec_MaxDays -最大

            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();

            this.myDataGrid1.TableStyles[0].AllowSorting = false; //不允许排序
            string[] GrdMappingName ={ "status_flag","Order_ID","Group_ID","Num","Unit","Order_Usage","frequency","Dropsper","Dosage",
										"ntype","c1","exec_dept","day1","second1",  "day2","second2","item_code",
										"Inpatient_ID","Baby_ID","isMY",
										"选","床号","住院号","姓名",
										"开日期","开时间","类型","医嘱内容","开嘱医生","首次","停日期","停时间","停嘱医生","末次","发送日期","发送护士","执行科室"};
            int[] GrdWidth =     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 9, 8, 6, 6, 8, 54, 8, 0, 6, 6, 0, 0, 12, 8, 0 };
            int[] Alignment ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            this.InitGridYZ(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);

            this.Show_Data();
        }


        private void Show_Data()
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            //条件：开医嘱时间小于等于查询时间 && (最大执行日期小于查询时间 ||  没有执行过的）
            DataTable myTb = new DataTable();
            DataTable patTb = InstanceForm.BDatabase.GetDataTable("select inpatient_id,baby_id from vi_zy_vinpatient_bed where ward_id='" + InstanceForm.BCurrentDept.WardId + "' order by bed_no");
            DataTable tmpTb = new DataTable();

            progressBar1.Maximum = patTb.Rows.Count;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;

            //循环病区病人
            for (int i = 0; i < patTb.Rows.Count; i++)
            {
                tmpTb.Clear();

                tmpTb = myFunc.GetBinOrdrs("", new Guid(patTb.Rows[i]["inpatient_id"].ToString()), Convert.ToInt64(patTb.Rows[i]["baby_id"].ToString()), 0, 2, 0, this.DateExecDate.Value, InstanceForm.BCurrentDept.WardId, 0);

                if (i == 0)
                    myTb = tmpTb.Clone();

                for (int j = 0; j < tmpTb.Rows.Count; j++)
                {
                    //					DataRow dr = myTb.NewRow();
                    //					for(int k=0;k<tmpTb.Columns.Count;k++)
                    //					{
                    //						dr[k]=tmpTb.Rows[j][k];
                    //					}
                    //					myTb.Rows.Add(dr);
                    myTb.Rows.Add(tmpTb.Rows[j].ItemArray);
                }

                progressBar1.Value += 1;
            }

            //			myTb=myFunc.GetBinOrdrs("",ClassStatic.Current_BinID,Convert.ToInt32(ClassStatic.Current_BabyID),0,2,0,this.DateExecDate.Value,InstanceForm.BCurrentDept.WardId);

            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Boolean");
            col.AllowDBNull = false;
            col.ColumnName = "选";
            col.DefaultValue = false;
            myTb.Columns.Add(col);

            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.TableStyles[0].RowHeaderWidth = 5;

            CheckGrdData(myTb);
            this.myDataGrid1.DataSource = myTb;

            this.priceInfo1.ClearYpInfo();
            this.Show_Patient();

            progressBar1.Value = 0;
            Cursor.Current = Cursors.Default;
        }


        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            myDataGrid.TableStyles[0].AllowSorting = false; //不允许排序

            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "选")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            //用色彩区分医嘱的状态 
            int ColorCol = 0;		 //状态列
            e.BackColor = Color.White;
            if (Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) > 1 && Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) < 5)   //已审核
            {
                e.ForeColor = Color.Blue;
            }
            if (this.myDataGrid1[e.Row, ColorCol].ToString() == "5")   //已停止
            {
                e.ForeColor = Color.Gray;
            }

            //选择列
            if (this.myDataGrid1[e.Row, 20].ToString() == "True")
            {
                e.BackColor = Color.GreenYellow;
            }
            else
            {
                e.BackColor = Color.White;
            }
        }


        private void CheckGrdData(DataTable myTb)
        {
            if (myTb.Rows.Count == 0) return;

            string sNum = "";
            int i = 0, iDay = 0, iTime = 0, iName = 0, iType = 0;                //记录上一个显示日期和时间、姓名,类型的行号
            int l = 0, group_rows = 1;    //同组中的医嘱个数
            bool isShowDay = true;
            this.sPaint = "";

            #region 算出长度
            max_len0 = 0;
            max_len1 = 0;
            max_len2 = 0;
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                sNum = this.GetNumUnit(myTb, i);
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
                max_len0 = max_len0 > l ? max_len0 : l;
                if (sNum.Trim() != "")
                {
                    max_len1 = max_len1 > l ? max_len1 : l;
                    l = System.Text.Encoding.Default.GetByteCount(sNum);
                    max_len2 = max_len2 > l ? max_len2 : l;
                }
            }
            #endregion

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {

                #region 显示姓名
                if (i != 0)
                {
                    if (myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[iName]["Inpatient_ID"].ToString().Trim()
                        && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[iName]["Baby_ID"].ToString().Trim())
                    {
                        myTb.Rows[i]["床号"] = System.DBNull.Value;
                        myTb.Rows[i]["住院号"] = System.DBNull.Value;
                        myTb.Rows[i]["姓名"] = System.DBNull.Value;
                        isShowDay = false;
                    }
                    else
                    {
                        iName = i;
                        isShowDay = true;  //需要显示日期和时间
                    }
                }
                #endregion

                #region 显示日期时间
                myTb.Rows[i]["开日期"] = myFunc.getDate(myTb.Rows[i]["开日期"].ToString().Trim(), myTb.Rows[i]["day1"].ToString().Trim());
                myTb.Rows[i]["开时间"] = myFunc.getTime(myTb.Rows[i]["开时间"].ToString().Trim(), myTb.Rows[i]["second1"].ToString().Trim());
                myTb.Rows[i]["停日期"] = myFunc.getDate(myTb.Rows[i]["停日期"].ToString().Trim(), myTb.Rows[i]["day2"].ToString().Trim());
                myTb.Rows[i]["停时间"] = myFunc.getTime(myTb.Rows[i]["停时间"].ToString().Trim(), myTb.Rows[i]["second2"].ToString().Trim());
                if (i != 0)
                {
                    if (myTb.Rows[i]["开日期"].ToString().Trim() == myTb.Rows[iDay]["开日期"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["开日期"] = System.DBNull.Value;
                    }
                    else
                    {
                        iDay = i;
                    }

                    if (myTb.Rows[i]["开时间"].ToString().Trim() == myTb.Rows[iTime]["开时间"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["开时间"] = System.DBNull.Value;
                    }
                    else
                    {
                        iTime = i;
                    }
                }
                #endregion

                #region 显示类型
                if (i != 0)
                {
                    if (myTb.Rows[i]["类型"].ToString().Trim() == myTb.Rows[iType]["类型"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["类型"] = System.DBNull.Value;
                    }
                    else
                    {
                        iType = i;
                    }
                }
                #endregion

                #region 显示医嘱内容

                //“医嘱内容”+= “医嘱内容”+“空格”+“数量单位”
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
                sNum = this.GetNumUnit(myTb, i);
                if (sNum.Trim() != "") myTb.Rows[i]["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString().Trim() + myFunc.Repeat_Space(max_len1 - l) + sNum;
                else myTb.Rows[i]["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString().Trim() + myFunc.Repeat_Space(/*max_len0-l*/5) + sNum;//Modify By Tany 2004-10-27

                //if  ( (i==myTb.Rows.Count-1) || (i!=myTb.Rows.Count-1 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i+1]["Group_id"].ToString().Trim() ))
                if ((i == myTb.Rows.Count - 1) ||
                    (i != myTb.Rows.Count - 1 &&
                    ((myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i + 1]["Group_id"].ToString().Trim()
                    && myTb.Rows[i]["mngtype"].ToString().Trim() == myTb.Rows[i + 1]["mngtype"].ToString().Trim()
                    //										                              && myTb.Rows[i]["inpatient_id"].ToString().Trim() != myTb.Rows[i+1]["inpatient_id"].ToString().Trim()
                    //												  && myTb.Rows[i]["baby_id"].ToString().Trim() != myTb.Rows[i+1]["baby_id"].ToString().Trim()
                    )
                    ||
                    (myTb.Rows[i]["mngtype"].ToString().Trim() != myTb.Rows[i + 1]["mngtype"].ToString().Trim())
                    )
                    )
                    )
                {
                    //如果是最后一行或本行和上一行的医嘱号不一致

                    //同组中第一条医嘱的“医嘱内容”+=“用法”+“滴速”+ “频率”+“剂数”
                    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1]["医嘱内容"].ToString().Trim());
                    myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(max_len1 + max_len2 - l + 4);
                    if (myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();
                    if (myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim() + "滴/min";
                    if (myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "" && myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "1" &&
                        (Convert.ToInt16(myTb.Rows[i - group_rows + 1]["nType"]) < 4 ||
                        (Convert.ToInt16(myTb.Rows[i - group_rows + 1]["nType"]) >= 4 && myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim().ToUpper() != "QD"))
                        ) myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                    if (Convert.ToInt16(myTb.Rows[i - group_rows + 1]["Dosage"]) == 3) myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Dosage"].ToString().Trim() + "付";


                    //如果一组中的医嘱个数大于1
                    if (group_rows != 1)
                    {
                        //[3i2]0 代表第三行是一组医嘱的最后一条，该组医嘱有两条医嘱，status_flag=0
                        this.sPaint += "[" + i.ToString() + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i]["status_flag"].ToString().Trim();
                    }
                    group_rows = 1;
                }
                else
                {
                    try
                    {
                        //如果不是第一行，且本行和下一行的医嘱号一致
                        myTb.Rows[i]["开嘱医生"] = System.DBNull.Value;
                        myTb.Rows[i]["首次"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱医生"] = System.DBNull.Value;
                        myTb.Rows[i]["停日期"] = System.DBNull.Value;
                        myTb.Rows[i]["停时间"] = System.DBNull.Value;
                        myTb.Rows[i]["末次"] = System.DBNull.Value;
                        group_rows += 1;
                    }
                    catch (System.Data.OleDb.OleDbException err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }

                if (myTb.Rows[i]["类型"].ToString().Trim() == "临时医嘱" || myTb.Rows[i]["类型"].ToString().Trim() == "临时账单")
                {
                    myTb.Rows[i]["首次"] = System.DBNull.Value;
                    myTb.Rows[i]["末次"] = System.DBNull.Value;
                }

                #endregion
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private string GetNumUnit(DataTable myTb, int i)
        {
            string sNum = "";
            if (Convert.ToDecimal(myTb.Rows[i]["Num"]) == Convert.ToInt32(myTb.Rows[i]["Num"]))
            {
                sNum = String.Format("{0:F0}", myTb.Rows[i]["Num"]).Trim();
            }
            else
            {
                sNum = String.Format("{0:F3}", myTb.Rows[i]["Num"]).Trim();
            }
            //Modify By Tany 2004-10-27
            if ((sNum == "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "2" && myTb.Rows[i]["ntype"].ToString().Trim() != "3") || sNum == "0" || sNum == "")
                return "";
            else
                return "" + sNum + myTb.Rows[i]["Unit"].ToString().Trim();
        }


        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            this.Show_Patient();
        }

        private void myDataGrid1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0)
            {
                this.priceInfo1.ClearYpInfo();
                return;
            }

            //如果是医嘱内容列
            if (ncol == 27)
            {
                //显示药品信息
                myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb.Rows.Count > 0)
                {
                    string mySHH = myTb.Rows[nrow]["item_code"].ToString().Trim();
                    string myNum = myTb.Rows[nrow]["Num"].ToString().Trim();
                    string myType = myTb.Rows[nrow]["nType"].ToString().Trim();
                    string myDept_ID = myTb.Rows[nrow]["exec_dept"].ToString().Trim();
                    //有效性判断
                    if (Convert.ToInt16(myType) < 3 && Convert.ToInt16(myType) != 0)
                    {
                        //						this.priceInfo1.SetYpInfo(mySHH,myNum,myType,myDept_ID); 
                    }
                    else
                    {
                        this.priceInfo1.ClearYpInfo();

                    }
                }
            }
        }

        private void myDataGrid1_Click(object sender, System.EventArgs e)
        {
            //控制BOOL列
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0 && nrow > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            //非"选"字段
            if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() != "选") return;
            if (nrow > myTb.Rows.Count - 1) return;

            bool isResult = myTb.Rows[nrow]["选"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["选"] = isResult;
            //this.myDataGrid1.DataSource=myTb;
            //this.myDataGrid1.CurrentCell=new DataGridCell(nrow,ncol);	

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["Group_id"].ToString().Trim() == myTb.Rows[nrow]["Group_id"].ToString().Trim()
                    && myTb.Rows[i]["Inpatient_id"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_id"].ToString().Trim()
                    && myTb.Rows[i]["Baby_id"].ToString().Trim() == myTb.Rows[nrow]["Baby_id"].ToString().Trim()
                    && myTb.Rows[i]["选"].ToString() != isResult.ToString())
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                    myTb.Rows[i]["选"] = isResult;
                    //this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
                }
            }

            this.myDataGrid1.DataSource = myTb;

        }

        private void myDataGrid1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int i = 0;
            int yDelta = this.myDataGrid1.GetCellBounds(i, 0).Height + 1;
            int y = this.myDataGrid1.GetCellBounds(i, 0).Top + 2;

            int index_start = 0, index_i = 0, index_p = 0, index_end = 0;
            int start_row = 0, start_point = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[this.myDataGrid1.DataSource, this.myDataGrid1.DataMember];

            while (y < this.myDataGrid1.Height - yDelta && i < cm.Count)
            {
                y += yDelta;

                //组线
                index_start = this.sPaint.IndexOf("[" + i.ToString() + "i", 0, this.sPaint.Trim().Length);
                if (index_start >= 0)
                {
                    index_i = index_start + i.ToString().Trim().Length + 1;
                    index_end = this.sPaint.IndexOf("]", index_i, this.sPaint.Trim().Length - index_i);
                    start_row = Convert.ToInt16(this.sPaint.Substring(index_i + 1, index_end - index_i - 1));
                    if (this.max_len1 == 0) start_point = 334 + (this.max_len0 + 4) * 6;
                    else start_point = 334 + (this.max_len1 + this.max_len2 + 4) * 6;
                    switch (this.sPaint.Substring(index_end + 1, 1))
                    {
                        case "1":  //未审核
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        case "5":  //已停止
                            e.Graphics.DrawLine(System.Drawing.Pens.Gray, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        default: //已审核
                            e.Graphics.DrawLine(System.Drawing.Pens.Blue, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                    }
                }
                i++;
            }
        }


        private void Show_Patient()
        {

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb.Rows.Count == 0)
            {
                this.old_BabyID = 0;
                this.patientInfo1.ClearInpatientInfo();
                return;
            }

            //得到病人基本信息
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (this.old_BinID != new Guid(this.myDataGrid1[nrow, 17].ToString()) || this.old_BabyID != Convert.ToInt32(this.myDataGrid1[nrow, 18]))
            {
                this.old_BinID = new Guid(this.myDataGrid1[nrow, 17].ToString());
                this.old_BabyID = Convert.ToInt32(this.myDataGrid1[nrow, 18]);
                //				this.patientInfo1.SetInpatientInfo();				
            }
        }


        private void bt全选_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            int nrow = 0, j = 0;
            bool isTrue = false;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (this.rb所有病人.Checked)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["选"] = true;
                }
                else
                {
                    if (i == 0
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() != myTb.Rows[i - 1]["Baby_ID"].ToString().Trim())
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                    {
                        nrow = i;	 //新病人的行号	
                        isTrue = false;
                        for (j = i; j <= myTb.Rows.Count - 1; j++)
                        {
                            if (myTb.Rows[j]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[j]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                            {
                                if (myTb.Rows[j]["选"].ToString() == "True")
                                {
                                    isTrue = true;
                                    break;
                                }
                            }
                            else break;
                        }
                    }

                    if (myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                    {
                        this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                        myTb.Rows[i]["选"] = isTrue;
                    }
                    else isTrue = false;
                }
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private void bt反选_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            int nrow = 0, j = 0;
            bool isTrue = false;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (this.rb所有病人.Checked)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
                }
                else
                {
                    if (i == 0
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() != myTb.Rows[i - 1]["Baby_ID"].ToString().Trim())
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                    {
                        nrow = i;	 //新病人的行号	
                        isTrue = false;
                        for (j = i; j <= myTb.Rows.Count - 1; j++)
                        {
                            if (myTb.Rows[j]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[j]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                            {
                                if (myTb.Rows[j]["选"].ToString() == "True")
                                {
                                    isTrue = true;
                                    break;
                                }
                            }
                            else break;
                        }
                    }

                    if (isTrue && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                    {
                        this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                        myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
                    }
                }
            }
            this.myDataGrid1.DataSource = myTb;
        }


        private void bt显示切换_Click(object sender, System.EventArgs e)
        {
            if (this.panel中.Height == 592)
            {
                this.panel中.Height = 657;
                this.groupBox1.Location = new System.Drawing.Point(776, 0);
                this.groupBox1.Size = new System.Drawing.Size(104, 48);
                this.tb查询.Location = new System.Drawing.Point(885, 16);
                this.bt退出.Location = new System.Drawing.Point(952, 16);
                this.btOpenModel.Location = new System.Drawing.Point(880, 8);
                this.btOpenModel.Size = new System.Drawing.Size(136, 40);
                //				this.rb开医嘱转抄.Location = new System.Drawing.Point(8, 8);
                //				this.rb停医嘱转抄.Location = new System.Drawing.Point(8, 24);	
                this.progressBar1.Location = new System.Drawing.Point(776, 54);
                this.progressBar1.Size = new System.Drawing.Size(240, 8);

            }
            else
            {
                this.panel中.Height = 592;
                this.groupBox1.Location = new System.Drawing.Point(784, 0);
                this.groupBox1.Size = new System.Drawing.Size(216, 48);
                //				this.rb开医嘱转抄.Location = new System.Drawing.Point(8, 16);
                //				this.rb停医嘱转抄.Location = new System.Drawing.Point(112, 16);
                this.btOpenModel.Location = new System.Drawing.Point(784, 48);
                this.btOpenModel.Size = new System.Drawing.Size(216, 40);
                this.tb查询.Location = new System.Drawing.Point(800, 56);
                this.bt退出.Location = new System.Drawing.Point(904, 56);
                this.progressBar1.Location = new System.Drawing.Point(784, 96);
                this.progressBar1.Size = new System.Drawing.Size(216, 24);
            }
        }

        private void bt查询_Click(object sender, System.EventArgs e)
        {
            this.Show_Data();
        }

        private void bt退出_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}
