using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
namespace ts_jc_wardbed
{
    /// <summary>
    /// FrmAddBed 的摘要说明。
    /// </summary>
    public class FrmAddBed : System.Windows.Forms.Form
    {
        private DataSet _dataSet;
        private DeptInfo _deptInfo;
        private RoomInfo _roomInfo;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNum;
        private TrasenClasses.GeneralControls.DataGridEx dtgrdBed;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGrid showCard;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private LabelEx lblCaption;
        private System.Windows.Forms.TextBox txtStartNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSameSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFlag;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.ComponentModel.IContainer components;

        public FrmAddBed(DeptInfo deptInfo, RoomInfo roomInfo)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            _deptInfo = deptInfo;
            _roomInfo = roomInfo;

            lblCaption.Text = "当前病区 [" + deptInfo.WardName + "] 当前科室 [" + deptInfo.DeptName + "] 房间 [" + roomInfo.RoomNo + "]";
            InitGrid();
            LoadData();
            try
            {
                DataRow dr = InstanceForm.BDatabase.GetDataRow("select max(cast(bed_no as integer))+1 from zy_beddiction where ward_id='" + deptInfo.WardID + "'");
                if (Convertor.IsNumeric(dr[0].ToString()))
                {
                    int _no = Convert.ToInt32(dr[0]);
                    if (_no.ToString().Length == 1)
                        txtStartNo.Text = "0" + _no.ToString();
                    else
                        txtStartNo.Text = _no.ToString();
                }
                else
                {
                    txtStartNo.Text = "01";
                }
            }
            catch
            {
                txtStartNo.Text = "01";
            }
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
            this.components = new System.ComponentModel.Container();
            this.lblCaption = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.dtgrdBed = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.showCard = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.txtStartNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFlag = new System.Windows.Forms.TextBox();
            this.btnSameSet = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdBed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showCard)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor1 = System.Drawing.SystemColors.Desktop;
            this.lblCaption.BackColor2 = System.Drawing.Color.AliceBlue;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(681, 21);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "添加床位";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtgrdBed
            // 
            this.dtgrdBed.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgrdBed.CaptionVisible = false;
            this.dtgrdBed.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dtgrdBed.DataMember = "";
            this.dtgrdBed.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtgrdBed.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgrdBed.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgrdBed.Location = new System.Drawing.Point(0, 21);
            this.dtgrdBed.Name = "dtgrdBed";
            this.dtgrdBed.Size = new System.Drawing.Size(681, 337);
            this.dtgrdBed.TabIndex = 1;
            this.dtgrdBed.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dtgrdBed.myKeyDown += new TrasenClasses.GeneralControls.myDelegate(this.dtgrdBed_myKeyDown);
            this.dtgrdBed.Click += new System.EventHandler(this.dtgrdBed_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dtgrdBed;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(270, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 27);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "增加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(514, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 27);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(601, 368);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 27);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "数量";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(39, 15);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(41, 21);
            this.txtNum.TabIndex = 6;
            this.txtNum.Text = "1";
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // showCard
            // 
            this.showCard.AllowSorting = false;
            this.showCard.BackgroundColor = System.Drawing.Color.Azure;
            this.showCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.showCard.CaptionVisible = false;
            this.showCard.DataMember = "";
            this.showCard.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.showCard.Location = new System.Drawing.Point(162, 122);
            this.showCard.Name = "showCard";
            this.showCard.ReadOnly = true;
            this.showCard.RowHeaderWidth = 20;
            this.showCard.Size = new System.Drawing.Size(430, 168);
            this.showCard.TabIndex = 7;
            this.showCard.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.showCard.Visible = false;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.AliceBlue;
            this.dataGridTableStyle2.DataGrid = this.showCard;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "行号";
            this.dataGridTextBoxColumn1.MappingName = "ROWNO";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 30;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "编号";
            this.dataGridTextBoxColumn2.MappingName = "ITEMCODE";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 0;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "名称";
            this.dataGridTextBoxColumn3.MappingName = "ITEMNAME";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 150;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "数字码";
            this.dataGridTextBoxColumn4.MappingName = "D_CODE";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "拼音码";
            this.dataGridTextBoxColumn5.MappingName = "PY_CODE";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "五笔码";
            this.dataGridTextBoxColumn6.MappingName = "WB_CODE";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "价格";
            this.dataGridTextBoxColumn7.MappingName = "ITEMPRICE";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 75;
            // 
            // txtStartNo
            // 
            this.txtStartNo.Location = new System.Drawing.Point(151, 15);
            this.txtStartNo.Name = "txtStartNo";
            this.txtStartNo.Size = new System.Drawing.Size(30, 21);
            this.txtStartNo.TabIndex = 8;
            this.txtStartNo.Text = "01";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "本次起始号";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFlag);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNum);
            this.groupBox1.Controls.Add(this.txtStartNo);
            this.groupBox1.Location = new System.Drawing.Point(4, 359);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 44);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "增加床位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "床头标注";
            // 
            // txtFlag
            // 
            this.txtFlag.Location = new System.Drawing.Point(240, 15);
            this.txtFlag.Name = "txtFlag";
            this.txtFlag.Size = new System.Drawing.Size(22, 21);
            this.txtFlag.TabIndex = 10;
            // 
            // btnSameSet
            // 
            this.btnSameSet.Location = new System.Drawing.Point(343, 368);
            this.btnSameSet.Name = "btnSameSet";
            this.btnSameSet.Size = new System.Drawing.Size(88, 27);
            this.btnSameSet.TabIndex = 11;
            this.btnSameSet.Text = "应用相同设置";
            this.btnSameSet.Click += new System.EventHandler(this.btnSameSet_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(438, 368);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 26);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "重置";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FrmAddBed
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(681, 406);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSameSet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.showCard);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtgrdBed);
            this.Controls.Add(this.lblCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddBed";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加病床";
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdBed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showCard)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private const int COL_BED_NO = 0;
        private const int COL_PLUS = 1;
        private const int COL_ZZ_DOC = 2;
        private const int COL_ZZ_DOC_NAME = 3;
        private const int COL_ZY_DOC = 4;
        private const int COL_ZY_DOC_NAME = 5;
        private const int COL_CHARGE_NURSE = 6;
        private const int COL_NURSE_NAME = 7;
        private const int COL_HOITEM_ID = 8;
        private const int COL_HOITEM_NAME = 9;

        #region 初始化网格
        private void InitGrid()
        {	//						0			1		2				3			4				5				6				7			8	
            string[] HeaderText ={ "床位号", "加床", "zz_doc", "主治医生", "zy_doc", "管床医生", "charge_nurse", "负责护士", "hoitem_id", "床位费" };
            string[] MappingName ={ "bed_no", "plus", "zz_doc", "zz_doc_name", "zy_doc", "zy_doc_name", "charge_nurse", "nurse_name", "hoitem_id", "hoitem_name" };
            int[] ColWidth ={ 50, 35, 0, 75, 0, 75, 0, 60, 0, 300 };
            int[] Style =	{ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            DataTable dtTmp = new DataTable();
            for (int i = 0; i <= HeaderText.Length - 1; i++)
            {
                if (Style[i] == 0)
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(i);
                    colText.HeaderText = HeaderText[i];
                    colText.MappingName = MappingName[i];
                    colText.Width = ColWidth[i];
                    colText.NullText = "";
                    colText.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(colText_CheckCellEnabled);

                    this.dtgrdBed.TableStyles[0].GridColumnStyles.Add(colText);
                }
                else
                {
                    DataGridBoolColumn boolCol = new DataGridBoolColumn();
                    boolCol.HeaderText = HeaderText[i];
                    boolCol.MappingName = MappingName[i];
                    boolCol.Width = ColWidth[i];
                    boolCol.NullValue = (short)0;
                    boolCol.TrueValue = (short)1;
                    boolCol.FalseValue = (short)0;
                    boolCol.ReadOnly = true;
                    this.dtgrdBed.TableStyles[0].GridColumnStyles.Add(boolCol);
                }
                DataColumn colData = new DataColumn(MappingName[i]);
                if (Style[i] == 1)
                {
                    colData.DefaultValue = (short)0;
                    colData.DataType = Type.GetType("System.Int16");
                }
                dtTmp.Columns.Add(colData);
            }
            this.dtgrdBed.DataSource = dtTmp;
        }
        #endregion

        #region 加载数据
        private void LoadData()
        {
            _dataSet = new DataSet();
            _dataSet.Tables.Clear();
            //医生
            ParameterEx[] parameter = new ParameterEx[1];
            parameter[0].Text = "@V_FUN_NAME";
            parameter[0].Value = "FX_GET_DOCTOR";
            DataTable dtDoctor = new DataTable();
            dtDoctor = InstanceForm.BDatabase.GetDataTable("SP_JC_GET_INFO", parameter, 30);
            dtDoctor.TableName = "DIC_DOCTOR";
            _dataSet.Tables.Add(dtDoctor);
            //护士
            parameter = new ParameterEx[1];
            parameter[0].Text = "@V_FUN_NAME";
            parameter[0].Value = "FX_GET_NURSE";
            DataTable dtNurse = new DataTable();
            dtNurse = InstanceForm.BDatabase.GetDataTable("SP_JC_GET_INFO", parameter, 30);
            dtNurse.TableName = "DIC_NURSE";
            _dataSet.Tables.Add(dtNurse);
            //床位费类医嘱
            parameter = new ParameterEx[1];
            parameter[0].Text = "@V_FUN_NAME";
            parameter[0].Value = "FX_GET_BED_ORDER";
            DataTable dtBed = new DataTable();
            dtBed = InstanceForm.BDatabase.GetDataTable("SP_JC_GET_INFO", parameter, 30);
            dtBed.TableName = "DIC_BED_ORDER";
            _dataSet.Tables.Add(dtBed);
        }
        #endregion

        #region 保存前的数据检查
        private bool DataExists(BedInfo bedInfo)
        {
            string sql = "";
            DataRow dr = null;
            //判断床位号是否存在
            sql = "select bed_id from zy_beddiction where ward_id='" + bedInfo.WardID + "' and bed_no='" + bedInfo.BedNo + "'";
            dr = InstanceForm.BDatabase.GetDataRow(sql);
            if (dr != null)
            {
                MessageBox.Show("[" + bedInfo.WardName + "] 已经有床号为[" + bedInfo.BedNo + "]的病床", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        private void colText_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;
            e.ForeColor = Color.Black;
            if (e.Row % 2 == 1)
                e.BackColor = Color.Azure;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private bool dtgrdBed_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {

            DataRow dr = null;
            bool respondKey = true;
            DataGridCell grdCell = dtgrdBed.CurrentCell;
            int currRow = grdCell.RowNumber;
            int currCol = grdCell.ColumnNumber;
            DataGridTextBoxColumn dgtCol = (DataGridTextBoxColumn)dtgrdBed.TableStyles[0].GridColumnStyles[currCol];
            int keyInt = (int)keyData;
            if (currRow == ((DataTable)dtgrdBed.DataSource).Rows.Count) return true;

            if (currCol == COL_ZZ_DOC_NAME || currCol == COL_ZY_DOC_NAME)
            {
                dr = WorkStaticFun.GetCardData(dtgrdBed, (int)keyData, currCol, showCard, 0, _dataSet, "DIC_DOCTOR", FilterType.拼音, SearchType.前导相似, ref respondKey, "", "");
            }
            if (currCol == COL_NURSE_NAME)
            {
                dr = WorkStaticFun.GetCardData(dtgrdBed, (int)keyData, currCol, showCard, 0, _dataSet, "DIC_NURSE", FilterType.拼音, SearchType.前导相似, ref respondKey, "", "");
            }
            if (currCol == COL_HOITEM_NAME)
            {
                dr = WorkStaticFun.GetCardData(dtgrdBed, (int)keyData, currCol, showCard, 0, _dataSet, "DIC_BED_ORDER", FilterType.拼音, SearchType.前导相似, ref respondKey, "", "");
            }

            //BackSpace,Delete必须响应
            //if(keyInt==8 || keyInt==46) return false;
            if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right) return true;
            if (keyData == Keys.Enter)
            {
                #region Enter
                if (dr != null)
                {
                    long _itemId = Convert.ToInt64(dr["itemcode"]);
                    string _itemName = dr["itemname"].ToString().Trim();
                    dgtCol.TextBox.Text = _itemName;
                    switch (currCol)
                    {
                        case COL_ZZ_DOC_NAME:
                            ((DataTable)dtgrdBed.DataSource).Rows[currRow]["zz_doc"] = _itemId;
                            ((DataTable)dtgrdBed.DataSource).Rows[currRow]["zz_doc_name"] = _itemName;
                            break;
                        case COL_ZY_DOC_NAME:
                            ((DataTable)dtgrdBed.DataSource).Rows[currRow]["zy_doc"] = _itemId;
                            ((DataTable)dtgrdBed.DataSource).Rows[currRow]["zy_doc_name"] = _itemName;
                            break;
                        case COL_NURSE_NAME:
                            ((DataTable)dtgrdBed.DataSource).Rows[currRow]["charge_nurse"] = _itemId;
                            ((DataTable)dtgrdBed.DataSource).Rows[currRow]["nurse_name"] = _itemName;
                            break;
                        case COL_HOITEM_NAME:
                            ((DataTable)dtgrdBed.DataSource).Rows[currRow]["hoitem_id"] = _itemId;
                            ((DataTable)dtgrdBed.DataSource).Rows[currRow]["hoitem_name"] = _itemName;
                            if (currRow == ((DataTable)dtgrdBed.DataSource).Rows.Count)
                            {
                                ((DataTable)dtgrdBed.DataSource).Rows.Add(((DataTable)dtgrdBed.DataSource).NewRow());
                            }
                            dtgrdBed.CurrentCell = new DataGridCell(currRow + 1, COL_BED_NO);
                            break;
                    }
                    if (currCol == COL_BED_NO) dtgrdBed.CurrentCell = new DataGridCell(currRow, COL_ZZ_DOC_NAME);
                    if (currCol == COL_ZZ_DOC_NAME) dtgrdBed.CurrentCell = new DataGridCell(currRow, COL_ZY_DOC_NAME);
                    if (currCol == COL_ZY_DOC_NAME) dtgrdBed.CurrentCell = new DataGridCell(currRow, COL_NURSE_NAME);
                    if (currCol == COL_NURSE_NAME) dtgrdBed.CurrentCell = new DataGridCell(currRow, COL_HOITEM_NAME);
                    if (currCol == COL_HOITEM_NAME)
                    {
                        if (currRow == ((DataTable)dtgrdBed.DataSource).Rows.Count)
                            return true;
                        else
                            dtgrdBed.CurrentCell = new DataGridCell(currRow + 1, COL_BED_NO);
                    }

                    return true;
                }
                else
                {

                    if (currCol == COL_BED_NO) dtgrdBed.CurrentCell = new DataGridCell(currRow, COL_ZZ_DOC_NAME);
                    return true;
                }
                #endregion
            }
            if (keyData == Keys.Delete || keyData == Keys.Back)
            {
                #region Delete
                if (currCol == COL_BED_NO)
                    ((DataTable)dtgrdBed.DataSource).Rows[currRow]["bed_no"] = "";
                if (currCol == COL_ZZ_DOC_NAME)
                {
                    ((DataTable)dtgrdBed.DataSource).Rows[currRow]["zz_doc"] = "";
                    ((DataTable)dtgrdBed.DataSource).Rows[currRow]["zz_doc_name"] = "";
                }
                if (currCol == COL_ZY_DOC_NAME)
                {
                    ((DataTable)dtgrdBed.DataSource).Rows[currRow]["zy_doc"] = "";
                    ((DataTable)dtgrdBed.DataSource).Rows[currRow]["zy_doc_name"] = "";
                }
                if (currCol == COL_NURSE_NAME)
                {
                    ((DataTable)dtgrdBed.DataSource).Rows[currRow]["charge_nurse"] = "";
                    ((DataTable)dtgrdBed.DataSource).Rows[currRow]["nurse_name"] = "";
                }
                if (currCol == COL_HOITEM_NAME)
                {
                    ((DataTable)dtgrdBed.DataSource).Rows[currRow]["hoitem_id"] = "";
                    ((DataTable)dtgrdBed.DataSource).Rows[currRow]["hoitem_name"] = "";
                }
                #endregion
            }
            return false;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            int bedNum = Convert.ToInt32(txtNum.Text);
            int bedStart = Convert.ToInt32(txtStartNo.Text);

            for (int i = 0; i < bedNum; i++)
            {
                string bedNo = bedStart.ToString();
                if (bedNo.Length == 1) bedNo = "0" + bedNo;

                DataRow drNew = ((DataTable)dtgrdBed.DataSource).NewRow();
                drNew["bed_no"] = txtFlag.Text + bedNo;
                drNew["plus"] = (short)0;
                ((DataTable)dtgrdBed.DataSource).Rows.Add(drNew);
                bedStart++;
            }

        }

        private void btnSameSet_Click(object sender, System.EventArgs e)
        {
            int count = ((DataTable)dtgrdBed.DataSource).Rows.Count;
            if (count == 0) return;

            long zz_doc = -1;
            if (!Convert.IsDBNull(((DataTable)dtgrdBed.DataSource).Rows[0]["zz_doc"]))
                zz_doc = Convert.ToInt64(((DataTable)dtgrdBed.DataSource).Rows[0]["zz_doc"]);
            string zz_doc_name = ((DataTable)dtgrdBed.DataSource).Rows[0]["zz_doc_name"].ToString();

            long zy_doc = -1;
            if (!Convert.IsDBNull(((DataTable)dtgrdBed.DataSource).Rows[0]["zy_doc"]))
                zy_doc = Convert.ToInt64(((DataTable)dtgrdBed.DataSource).Rows[0]["zy_doc"]);
            string zy_doc_name = ((DataTable)dtgrdBed.DataSource).Rows[0]["zy_doc_name"].ToString();


            long charge_nurse = -1;
            if (!Convert.IsDBNull(((DataTable)dtgrdBed.DataSource).Rows[0]["charge_nurse"]))
                charge_nurse = Convert.ToInt64(((DataTable)dtgrdBed.DataSource).Rows[0]["charge_nurse"]);
            string nurse_name = ((DataTable)dtgrdBed.DataSource).Rows[0]["nurse_name"].ToString();

            long hoitem_id = -1;
            if (!Convert.IsDBNull(((DataTable)dtgrdBed.DataSource).Rows[0]["hoitem_id"]))
                hoitem_id = Convert.ToInt64(((DataTable)dtgrdBed.DataSource).Rows[0]["hoitem_id"]);
            string hoitem_name = ((DataTable)dtgrdBed.DataSource).Rows[0]["hoitem_name"].ToString();

            for (int i = 1; i <= count - 1; i++)
            {
                ((DataTable)dtgrdBed.DataSource).Rows[i]["zz_doc"] = zz_doc;
                ((DataTable)dtgrdBed.DataSource).Rows[i]["zz_doc_name"] = zz_doc_name;

                ((DataTable)dtgrdBed.DataSource).Rows[i]["zy_doc"] = zy_doc;
                ((DataTable)dtgrdBed.DataSource).Rows[i]["zy_doc_name"] = zy_doc_name;

                ((DataTable)dtgrdBed.DataSource).Rows[i]["charge_nurse"] = charge_nurse;
                ((DataTable)dtgrdBed.DataSource).Rows[i]["nurse_name"] = nurse_name;

                ((DataTable)dtgrdBed.DataSource).Rows[i]["hoitem_id"] = hoitem_id;
                ((DataTable)dtgrdBed.DataSource).Rows[i]["hoitem_name"] = hoitem_name;
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SystemCfg cfg = new SystemCfg(7601);
            bool sfbt = cfg != null && cfg.Config != null && cfg.Config.ToString().Trim() == "1" ? true : false;
            string bedNo = "";
            int count = ((DataTable)dtgrdBed.DataSource).Rows.Count;

            try
            {
                string strCws = string.Format("select CWS from jc_dept_property where DEPT_ID='{0}'", _deptInfo.DeptID);
                string strUnPlusCws = string.Format("select count(1) as Num from zy_beddiction where dept_id='{0}' and ISPLUS=0", _deptInfo.DeptID);

                int iCws = int.Parse(InstanceForm.BDatabase.GetDataResult(strCws).ToString());
                int iNonPlus = int.Parse(InstanceForm.BDatabase.GetDataResult(strUnPlusCws).ToString());

                if (iCws != 0)
                {
                    int myNonPlusCw = 0;
                    for (int i = 0; i <= count - 1; i++)
                    {
                        DataTable dtCw = dtgrdBed.DataSource as DataTable;
                        if (Convert.ToInt32(dtCw.Rows[i]["plus"]) == 0)
                        {
                            ++myNonPlusCw;
                        }
                    }

                    if (iCws < iNonPlus + myNonPlusCw)
                    {
                        MessageBox.Show("本次添加床位已大于该科室编制床位数：" + iCws + ",请添加加床!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch { }

            for (int i = 0; i <= count - 1; i++)
            {
                bedNo = ((DataTable)dtgrdBed.DataSource).Rows[i]["bed_no"].ToString().Trim();
                DataRow[] drs = ((DataTable)dtgrdBed.DataSource).Select("bed_no='" + bedNo + "'");
                if (drs.Length > 1)
                {
                    MessageBox.Show("床位号" + bedNo + "有重复!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (sfbt) //床位费为必填项
                {
                    object hoitem = ((DataTable)dtgrdBed.DataSource).Rows[i]["hoitem_id"];
                    if (hoitem == null || hoitem.ToString().Trim() == string.Empty || Convert.ToInt64(hoitem)<=0) //Modify By Tany 2015-04-20 增加<=0的判断
                    {
                        MessageBox.Show("床位费不能为空,请录入床位费!");
                        return;
                    }
                }
            }

            for (int i = 0; i <= count - 1; i++)
            {
                bedNo = ((DataTable)dtgrdBed.DataSource).Rows[i]["bed_no"].ToString().Trim();
                int sel = Convert.ToInt32(((DataTable)dtgrdBed.DataSource).Rows[dtgrdBed.CurrentRowIndex]["plus"]);
                if (bedNo != "")
                {
                    #region GetData
                    string zz_doc_name = ((DataTable)dtgrdBed.DataSource).Rows[i]["zz_doc_name"].ToString();
                    long zz_doc = -1;
                    if (!Convert.IsDBNull(((DataTable)dtgrdBed.DataSource).Rows[i]["zz_doc"]))
                        if (((DataTable)dtgrdBed.DataSource).Rows[i]["zz_doc"].ToString() != "")
                            zz_doc = Convert.ToInt64(((DataTable)dtgrdBed.DataSource).Rows[i]["zz_doc"]);

                    string zy_doc_name = ((DataTable)dtgrdBed.DataSource).Rows[i]["zy_doc_name"].ToString();
                    long zy_doc = -1;
                    if (!Convert.IsDBNull(((DataTable)dtgrdBed.DataSource).Rows[i]["zy_doc"]))
                        if (((DataTable)dtgrdBed.DataSource).Rows[i]["zy_doc"].ToString() != "")
                            zy_doc = Convert.ToInt64(((DataTable)dtgrdBed.DataSource).Rows[i]["zy_doc"]);

                    string nurse_name = ((DataTable)dtgrdBed.DataSource).Rows[i]["nurse_name"].ToString();
                    long charge_nurse = -1;
                    if (!Convert.IsDBNull(((DataTable)dtgrdBed.DataSource).Rows[i]["charge_nurse"]))
                        if (((DataTable)dtgrdBed.DataSource).Rows[i]["charge_nurse"].ToString() != "")
                            charge_nurse = Convert.ToInt64(((DataTable)dtgrdBed.DataSource).Rows[i]["charge_nurse"]);

                    string hoitem_name = ((DataTable)dtgrdBed.DataSource).Rows[i]["hoitem_name"].ToString();
                    long hoitem_id = -1;

                    if (!Convert.IsDBNull(((DataTable)dtgrdBed.DataSource).Rows[i]["hoitem_id"]))
                        if (((DataTable)dtgrdBed.DataSource).Rows[i]["hoitem_id"].ToString() != "")
                            hoitem_id = Convert.ToInt64(((DataTable)dtgrdBed.DataSource).Rows[i]["hoitem_id"]);
                    #endregion

                    if (bedNo.Trim() != "")
                    {
                        #region InitBed
                        BedInfo bedInfo = new BedInfo();
                        bedInfo.WardID = _deptInfo.WardID;
                        bedInfo.WardName = _deptInfo.WardName;
                        bedInfo.DeptID = _deptInfo.DeptID;
                        bedInfo.DeptName = _deptInfo.DeptName;
                        bedInfo.RoomNo = _roomInfo.RoomNo;
                        bedInfo.BedNo = bedNo;
                        bedInfo.ChargeDocID = zz_doc;
                        bedInfo.ChargeDocName = zz_doc_name;
                        bedInfo.ManageDocID = zy_doc;
                        bedInfo.ManageDocName = zy_doc_name;
                        bedInfo.FunNurseID = charge_nurse;
                        bedInfo.FunNurseName = nurse_name;
                        bedInfo.LinkFeeID = hoitem_id;
                        bedInfo.LinkFeeName = hoitem_name;
                        bedInfo.IsInuse = false;
                        bedInfo.IsPlus = false;
                        int plus = sel;
                        #endregion
                        if (DataExists(bedInfo))
                        {
                            int _jgbm = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select jgbm from jc_DEpt_property where dept_id = " + bedInfo.DeptID.ToString()));
                            string sql = "insert into zy_beddiction (bed_id,ward_id,dept_id,room_no,bed_no,hoitem_id,zz_doc,zy_doc,chargenurse,isplus,isinuse,pxxh,jgbm)";
                            sql += " values(DBO.FUN_GETGUID(NEWID(),GETDATE()),'" + bedInfo.WardID + "'," + bedInfo.DeptID + ",'" + bedInfo.RoomNo + "','" + bedInfo.BedNo + "'," + bedInfo.LinkFeeID + "," + bedInfo.ChargeDocID + "," + bedInfo.ManageDocID + "," + bedInfo.FunNurseID + "," + plus + ",0,0," + _jgbm + ")";
                            InstanceForm.BDatabase.DoCommand(sql);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            ((DataTable)dtgrdBed.DataSource).Rows.Clear();
        }

        private void dtgrdBed_Click(object sender, System.EventArgs e)
        {
            if (((DataTable)dtgrdBed.DataSource).Rows.Count == 0) return;
            if (dtgrdBed.CurrentRowIndex == ((DataTable)dtgrdBed.DataSource).Rows.Count) return;
            if (dtgrdBed.CurrentCell.ColumnNumber == COL_PLUS)
            {
                int sel = Convert.ToInt32(((DataTable)dtgrdBed.DataSource).Rows[dtgrdBed.CurrentRowIndex]["plus"]);
                ((DataTable)dtgrdBed.DataSource).Rows[dtgrdBed.CurrentRowIndex]["plus"] = sel == 1 ? (short)0 : (short)1;

                DataTable dtCw = dtgrdBed.DataSource as DataTable;
                if (Convert.ToInt32(dtCw.Rows[dtgrdBed.CurrentRowIndex]["plus"]) == 1)
                {
                    if (!dtCw.Rows[dtgrdBed.CurrentRowIndex]["bed_no"].ToString().Trim().Contains("+"))
                    {
                        dtCw.Rows[dtgrdBed.CurrentRowIndex]["bed_no"] = "+" + dtCw.Rows[dtgrdBed.CurrentRowIndex]["bed_no"].ToString();
                    }
                }
            }
        }
    }
}
