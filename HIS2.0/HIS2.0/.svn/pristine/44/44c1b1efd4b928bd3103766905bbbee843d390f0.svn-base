using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.IO;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using System.Text.RegularExpressions;
using Ts_zyys_jysq;
using Ts_zyys_jcsq;
using TszyHIS;
//using GoldPrinter;

namespace ts_zyhs_bryl
{
    /// <summary>
    /// frmAllPatientInfo 的摘要说明。
    /// </summary>
    public class frmBRYL : System.Windows.Forms.Form
    {
        // Fields
        private int _iJcJyQuery;

        private BaseFunc myFunc;
        private bool isAll = false;

        private DataGridEx myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private Panel panel1;
        private Panel panel2;
        private Button btnExcel;
        private Button btCancel;
        private Button button3;
        private ComboBox cmbWard;
        private Button btnRefresh;
        private TextBox txtZyh;
        private Button button2;
        private Button button1;
        private Button btSeekPat;
        private Button btnSeek;
        private Button btBljgcx;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmBRYL(string _formText)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            //InitializeComponent();

            ////
            //// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            ////
            //this.Text=_formText;

            //myFunc = new BaseFunc(); 
            this.isAll = false;
            this._iJcJyQuery = -1;
            this.InitializeComponent();
            this.Text = _formText;
            this.myFunc = new BaseFunc();

        }

        public frmBRYL(string _formText, bool _isAll)
        {
            this.isAll = false;
            this._iJcJyQuery = -1;
            this.InitializeComponent();
            this.Text = _formText;
            this.myFunc = new BaseFunc();
            this.isAll = _isAll;

        }

        public frmBRYL(string _formText, int iJcJyQuery)
        {
            this.isAll = false;
            this._iJcJyQuery = -1;
            this.InitializeComponent();
            this.Text = _formText;
            this.myFunc = new BaseFunc();
            this._iJcJyQuery = iJcJyQuery;
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtZyh = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btSeekPat = new System.Windows.Forms.Button();
            this.btnSeek = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbWard = new System.Windows.Forms.ComboBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btBljgcx = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.myDataGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 540);
            this.panel1.TabIndex = 22;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "病人信息一览表";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.RowHeadersVisible = false;
            this.myDataGrid1.Size = new System.Drawing.Size(1016, 540);
            this.myDataGrid1.TabIndex = 21;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btBljgcx);
            this.panel2.Controls.Add(this.txtZyh);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btSeekPat);
            this.panel2.Controls.Add(this.btnSeek);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.cmbWard);
            this.panel2.Controls.Add(this.btnExcel);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 540);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 57);
            this.panel2.TabIndex = 23;
            // 
            // txtZyh
            // 
            this.txtZyh.Location = new System.Drawing.Point(12, 18);
            this.txtZyh.Name = "txtZyh";
            this.txtZyh.Size = new System.Drawing.Size(146, 21);
            this.txtZyh.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(415, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "检验项目查询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "检查项目查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btSeekPat
            // 
            this.btSeekPat.Location = new System.Drawing.Point(229, 18);
            this.btSeekPat.Name = "btSeekPat";
            this.btSeekPat.Size = new System.Drawing.Size(87, 23);
            this.btSeekPat.TabIndex = 15;
            this.btSeekPat.Text = "查找病人(&Q)";
            this.btSeekPat.UseVisualStyleBackColor = true;
            this.btSeekPat.Click += new System.EventHandler(this.btSeekPat_Click);
            // 
            // btnSeek
            // 
            this.btnSeek.Location = new System.Drawing.Point(161, 18);
            this.btnSeek.Name = "btnSeek";
            this.btnSeek.Size = new System.Drawing.Size(63, 23);
            this.btnSeek.TabIndex = 14;
            this.btnSeek.Text = "查找";
            this.btnSeek.UseVisualStyleBackColor = true;
            this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.Location = new System.Drawing.Point(770, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 24);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbWard
            // 
            this.cmbWard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWard.FormattingEnabled = true;
            this.cmbWard.Location = new System.Drawing.Point(628, 19);
            this.cmbWard.Name = "cmbWard";
            this.cmbWard.Size = new System.Drawing.Size(133, 20);
            this.cmbWard.TabIndex = 12;
            this.cmbWard.SelectedValueChanged += new System.EventHandler(this.cmbWard_SelectedValueChanged);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExcel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcel.ImageIndex = 0;
            this.btnExcel.Location = new System.Drawing.Point(840, 18);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(89, 24);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Text = "导出Excel(&D)";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(935, 18);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 24);
            this.btCancel.TabIndex = 10;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(762, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(245, 40);
            this.button3.TabIndex = 9;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btBljgcx
            // 
            this.btBljgcx.Location = new System.Drawing.Point(511, 18);
            this.btBljgcx.Name = "btBljgcx";
            this.btBljgcx.Size = new System.Drawing.Size(91, 23);
            this.btBljgcx.TabIndex = 19;
            this.btBljgcx.Text = "病理结果查询";
            this.btBljgcx.UseVisualStyleBackColor = true;
            this.btBljgcx.Click += new System.EventHandler(this.btBljgcx_Click);
            // 
            // frmBRYL
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1016, 597);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmBRYL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "病人信息一览";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAllPatientInfo_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmAllPatientInfo_Load(object sender, System.EventArgs e)
        {
            this.InitJcJy();
            string commandtext = "";
            if (this.isAll)
            {
                commandtext = "select * from jc_ward where jgbm=" + FrmMdiMain.Jgbm + " order by ward_id";
            }
            else
            {
                commandtext = string.Concat(new object[] { "select * from jc_ward where jgbm=", FrmMdiMain.Jgbm, " and ward_id='", InstanceForm.BCurrentDept.WardId, "' order by ward_id" });
            }
            DataTable dataTable = FrmMdiMain.Database.GetDataTable(commandtext);
            this.cmbWard.ValueMember = "ward_id";
            this.cmbWard.DisplayMember = "ward_name";
            this.cmbWard.DataSource = dataTable;
            this.cmbWard.SelectedIndex = 0;
        }

        private void ShowData(string wardId)
        {
            string sSql;

            sSql = @"select ward_name 病区,cur_dept_name 科室,room_no 房号,bed_no 床号,inpatient_no 住院号,a.name 病人姓名,age 年龄, " +
                " sex_name 性别,case when DISCHARGETYPE=1 then yblx_name else jsfs_name end 类型,zzdoc_name 主治医生,zydoc_name 经治医生,nurs_name 责任护士,(case when b.name is null then (select top 1 name from jc_disease where coding=a.in_diagnosis) else b.name end ) 入院诊断,in_date 入院日期, " +
                " ryts 天数,hljb_name 护理级别,case when order_bw is not null and order_bw<>dbo.fun_getemptyguid() then '√' else '' end 病危, " +
                " case when order_bz is not null and order_bz<>dbo.fun_getemptyguid() then '√' else '' end 病重, " +
                " order_ys_spec 饮食," +
                " case when  (select COUNT(1) from ZY_ORDERRECORD where INPATIENT_ID=A.INPATIENT_ID and BABY_ID=A.BABY_ID and (ORDER_CONTEXT like '%陪护%' OR ORDER_CONTEXT like '%陪人%' )  AND  MNGTYPE=0 AND STATUS_FLAG=2    AND DELETE_BIT=0)=0 then '' else '√' end 陪护, " +//add by zouchihua 2013-8-1陪人陪护
                " dbo.FUN_ZYHS_GETCSMTZ(A.INPATIENT_ID,A.BABY_ID) 测生命体征, INPATIENT_ID, BABY_ID," +//add by 岳成成 2014-08-07
                " dept_id " + //Modify By Tany 2015-07-13 增加dept_id
                " from vi_zy_vinpatient_bed a left join jc_disease b on a.in_diagnosis=b.coding and isnull(a.ybjklx,0)=b.ybjklx " +
                " where ward_id='" + wardId + "' order by room_no,dbo.Fun_GetBedToOrder( (case when left( bed_no,1)='+' then '999'+ bed_no else  bed_no end) )";

            string[] GrdMappingName ={ "病区", "科室", "房号", "床号", "住院号", "病人姓名", "年龄", "性别", "类型", "主治医生", "经治医生", "责任护士", "入院诊断", "入院日期", "天数", "护理级别", "病危", "病重", "饮食", "陪护", "测生命体征", "INPATIENT_ID", "BABY_ID" };
            int[] GrdWidth ={ 6, 12, 4, 4, 9, 8, 4, 4, 8, 8, 8, 8, 14, 10, 4, 10, 4, 4, 18, 4, 12, 0, 0 };
            int[] Alignment ={ 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0 };

            myFunc.InitGridSQL(sSql, GrdMappingName, GrdWidth, Alignment, this.myDataGrid1);
            PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);
            myFunc.SelRow(this.myDataGrid1);
        }


        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid1);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string _top = "";

                //写入行头
                DataTable tb = (DataTable)myDataGrid1.DataSource;
                if (tb == null || tb.Rows.Count == 0)
                    return;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width > 0)
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                    }
                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width > 0)
                        {
                            ncol = ncol + 1;
                            myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();// 
                        }
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = Constant.HospitalName + cmbWard.Text + "病人信息一览";
                myExcel.Cells[1, 1] = ss;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                myExcel.Cells[3, 1] = _top.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //最后一行为黄色
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;

                //让Excel文件可见
                myExcel.Visible = true;

                #endregion
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbWard_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbWard.SelectedValue == null)
                return;

            ShowData(cmbWard.SelectedValue.ToString());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbWard_SelectedValueChanged(null, null);
        }

        private void btnSeek_Click(object sender, EventArgs e)
        {
            if (this.txtZyh.Text.Trim() == "")
            {
                this.txtZyh.Text = "0";
            }
            string commandtext = "";
            commandtext = " SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY    FROM vi_zy_vInpatient_All   WHERE  inpatient_no='" + this.txtZyh.Text.Trim() + "' and flag<>10   order by baby_id";
            DataTable dataTable = InstanceForm.BDatabase.GetDataTable(commandtext);
            if ((dataTable == null) || (dataTable.Rows.Count == 0))
            {
                MessageBox.Show("没有找到该病人信息，请核对住院号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.Show_Date_Inpatient(this.txtZyh.Text);
            }
        }

        private void btSeekPat_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedInpatientNO = "";
                new DlgInpatients(InstanceForm.BCurrentDept.WardId).ShowDialog();
                selectedInpatientNO = DlgInpatients.SelectedInpatientNO;
                if (selectedInpatientNO.Trim() != "")
                {
                    this.txtZyh.Text = selectedInpatientNO;
                    this.btnSeek_Click(null, null);
                }
            }
            catch
            {
            }
        }

        //检查申请
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataSource = this.myDataGrid1.DataSource as DataTable;
                if ((dataSource != null) && (dataSource.Rows.Count > 0))
                {
                    int currentRowIndex = this.myDataGrid1.CurrentRowIndex;
                    if (currentRowIndex != -1)
                    {
                        DataRow row = dataSource.Rows[currentRowIndex];
                        Ts_zyys_jcsq.InstanceForm._database = InstanceForm.BDatabase;
                        Ts_zyys_jcsq.InstanceForm._currentDept = InstanceForm.BCurrentDept;
                        Ts_zyys_jcsq.InstanceForm._currentUser = InstanceForm.BCurrentUser;
                        FrmJCSQ mjcsq = new FrmJCSQ(true);
                        mjcsq.BinID = new Guid(row["INPATIENT_ID"].ToString());
                        mjcsq.DeptID = long.Parse(row["Dept_ID"].ToString());
                        mjcsq.BabyID = long.Parse(row["BABY_ID"].ToString());
                        mjcsq._Zyid = row["住院号"].ToString();
                        mjcsq.DoHideTabOrder();
                        mjcsq.ShowDialog();
                    }
                }
            }
            catch
            {
            }
        }

        //检验申请
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataSource = this.myDataGrid1.DataSource as DataTable;
                if ((dataSource != null) && (dataSource.Rows.Count > 0))
                {
                    int currentRowIndex = this.myDataGrid1.CurrentRowIndex;
                    if (currentRowIndex != -1)
                    {
                        DataRow row = dataSource.Rows[currentRowIndex];
                        Ts_zyys_jysq.InstanceForm._database = InstanceForm.BDatabase;
                        Ts_zyys_jysq.InstanceForm._currentDept = InstanceForm.BCurrentDept;
                        Ts_zyys_jysq.InstanceForm._currentUser = InstanceForm.BCurrentUser;
                        Guid guid = new Guid(row["INPATIENT_ID"].ToString());
                        long num2 = long.Parse(row["BABY_ID"].ToString());
                        FrmJYSQ mjysq = new FrmJYSQ(guid, num2, true);
                        mjysq.BinID = new Guid(row["INPATIENT_ID"].ToString());
                        mjysq.DeptID = long.Parse(row["Dept_ID"].ToString());
                        mjysq.BabyID = long.Parse(row["BABY_ID"].ToString());
                        mjysq._Zyid = row["住院号"].ToString();
                        mjysq.ShowDialog();
                    }
                }
            }
            catch
            {
            }
        }

        private void InitJcJy()
        {
            bool flag = this._iJcJyQuery == 0;
            this.txtZyh.Visible = flag;
            this.btnSeek.Visible = flag;
            this.btSeekPat.Visible = flag;

            this.button1.Visible = flag;
            this.button2.Visible = flag;
            this.btBljgcx.Visible = flag;//Add By tany 2015-05-05
        }

        private void Show_Date_Inpatient(string Inpatient_no)
        {
            Cursor.Current = PubStaticFun.WaitCursor();

            string sSql = @"select INPATIENT_ID,BABY_ID,DEPT_ID,ward_name 病区,cur_dept_name 科室,room_no 房号,bed_no 床号,inpatient_no 住院号,a.name 病人姓名,age 年龄, " +
    " sex_name 性别,case when DISCHARGETYPE=1 then yblx_name else jsfs_name end 类型,zzdoc_name 主治医生,zydoc_name 经治医生,nurs_name 责任护士,(case when b.name is null then (select top 1 name from jc_disease where coding=a.in_diagnosis) else b.name end ) 入院诊断,in_date 入院日期, " +
    " ryts 天数,hljb_name 护理级别,case when order_bw is not null and order_bw<>dbo.fun_getemptyguid() then '√' else '' end 病危, " +
    " case when order_bz is not null and order_bz<>dbo.fun_getemptyguid() then '√' else '' end 病重, " +
    " order_ys_spec 饮食," +
    " case when  (select COUNT(1) from ZY_ORDERRECORD where INPATIENT_ID=A.INPATIENT_ID and BABY_ID=A.BABY_ID and (ORDER_CONTEXT like '%陪护%' OR ORDER_CONTEXT like '%陪人%' )  AND  MNGTYPE=0 AND STATUS_FLAG=2    AND DELETE_BIT=0)=0 then '' else '√' end 陪护, " +//add by zouchihua 2013-8-1陪人陪护
    " dbo.FUN_ZYHS_GETCSMTZ(A.INPATIENT_ID,A.BABY_ID) 测生命体征" +//add by 岳成成 2014-08-07
    " from vi_zy_vInpatient_All a left join jc_disease b on a.in_diagnosis=b.coding and isnull(a.ybjklx,0)=b.ybjklx " +
    " where inpatient_no='" + Inpatient_no + "' order by room_no,dbo.Fun_GetBedToOrder( (case when left( bed_no,1)='+' then '999'+ bed_no else  bed_no end) )";
            //            str = @"select 病区,所属科室,床号,住院号,姓名,性别,年龄,结算类型,病人类型,险种类型,待遇类型,        ''as 补缴款, 入院日期,
            //                    a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,出院日期,医保类型,工作单位,身份证,管床医生 , 费用限额 ,flag,ryts ,
            //                    isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,
            //                    (select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) 现金支付   
            //                    from (SELECT BED_NO 床号,INPATIENT_NO 住院号,NAME 姓名,SEX_NAME 性别,age 年龄,CUR_DEPT_NAME 所属科室,    
            //                    JSFS_NAME 结算类型,BRLX_NAME 病人类型,in_date 入院日期,INPATIENT_ID,Baby_ID,DEPT_ID          
            //                    ,out_date 出院日期,yblx_name 医保类型,xzlx_name 险种类型,dylx_name 待遇类型,gzdw 工作单位,social_no 身份证,WARD_NAME 病区,
            //                    zydoc_name 管床医生 , YJJ_LIMIT 费用限额,flag ,ryts    FROM vi_zy_vInpatient_All  
            //                    WHERE  inpatient_no='" + Inpatient_no + "' and flag<>10) a   order by dbo.Fun_GetBedToOrder(床号),a.INPATIENT_ID,a.Baby_ID";
            //            //WHERE WARD_ID= '"   + InstanceForm.BCurrentDept.WardId + "' and inpatient_no='" + Inpatient_no + "' and flag<>10) a   order by dbo.Fun_GetBedToOrder(床号),a.INPATIENT_ID,a.Baby_ID";


            string[] GrdMappingName ={ "病区", "科室", "房号", "床号", "住院号", "病人姓名", "年龄", "性别", "类型", "主治医生", "经治医生", "责任护士", "入院诊断", "入院日期", "天数", "护理级别", "病危", "病重", "饮食", "陪护", "测生命体征", "INPATIENT_ID", "BABY_ID" };
            int[] GrdWidth ={ 6, 12, 4, 4, 9, 8, 4, 4, 8, 8, 8, 8, 14, 10, 4, 10, 4, 4, 18, 4, 12, 0, 0 };
            int[] Alignment ={ 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0 };

            myFunc.InitGridSQL(sSql, GrdMappingName, GrdWidth, Alignment, this.myDataGrid1);
            PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);
            //myFunc.SelRow(this.myDataGrid1);
            //this.myFunc.ShowGrid(1, str, this.myDataGrid1);
            Cursor.Current = Cursors.Default;
        }

        //Add By tany 2015-05-05
        private void btBljgcx_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataSource = this.myDataGrid1.DataSource as DataTable;
                if ((dataSource != null) && (dataSource.Rows.Count > 0))
                {
                    int currentRowIndex = this.myDataGrid1.CurrentRowIndex;
                    if (currentRowIndex != -1)
                    {
                        DataRow row = dataSource.Rows[currentRowIndex];
                        Guid BinID = new Guid(row["INPATIENT_ID"].ToString());
                        string sfqy = ApiFunction.GetIniString("bl", "是否启用", Constant.ApplicationDirectory + "\\bl.ini");
                        if (sfqy == "1")
                        {
                            Ts_Bl_interface.BlFactory bf = new Ts_Bl_interface.BlFactory();
                            //bf.Create("").ShowPatBlInfo(BinID, Ts_Bl_interface.PatientSource.住院);
                            bf.Create("").ShowPatBlInfo(BinID, Ts_Bl_interface.PatientSource.住院);
                        }
                        else
                        {
                            MessageBox.Show("没有开启病理接口，请联系管理员");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
