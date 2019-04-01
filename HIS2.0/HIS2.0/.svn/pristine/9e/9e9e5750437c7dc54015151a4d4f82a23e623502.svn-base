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
    /// FrmBedEdit 的摘要说明。
    /// </summary>
    public class FrmBedEdit : System.Windows.Forms.Form
    {
        public bool _operateCancel;
        public bool _ChangeRoom = false;
        private bool _addNew;
        private DeptInfo _deptInfo;
        private RoomInfo _roomInfo;
        private BedInfo _bedInfo;

        private System.Windows.Forms.Button btnLinkFee;
        private System.Windows.Forms.Button btnFunNurse;
        private System.Windows.Forms.Button btnManageDoc;
        private System.Windows.Forms.Button btnChargeDoc;
        private System.Windows.Forms.TextBox txtLinkFee;
        private System.Windows.Forms.TextBox txtFunNurse;
        private System.Windows.Forms.TextBox txtManageDoc;
        private System.Windows.Forms.TextBox txtChargeDoc;
        private System.Windows.Forms.TextBox txtBedNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private TrasenClasses.GeneralControls.LabelEx lblCaption;
        private System.Windows.Forms.Label lblWardInfo;
        private System.Windows.Forms.CheckBox chkPlus;
        private System.Windows.Forms.ContextMenu mnuRoom;
        private System.Windows.Forms.Button btnChangeRoom;
        private System.Windows.Forms.ComboBox cboKs;
        private System.Windows.Forms.Label label1;
        private Label lblMsg;
        private System.ComponentModel.IContainer components;


        public FrmBedEdit(DeptInfo deptInfo, RoomInfo roomInfo)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            //新增床位
            //
            _addNew = true;
            AddButtonToTextBox(this.btnChargeDoc, this.txtChargeDoc);
            AddButtonToTextBox(this.btnManageDoc, this.txtManageDoc);
            AddButtonToTextBox(this.btnFunNurse, this.txtFunNurse);
            AddButtonToTextBox(this.btnLinkFee, this.txtLinkFee);
            #region 初始化录入控件
            this.ClearTextBoxInfo(this.txtChargeDoc);
            this.ClearTextBoxInfo(this.txtManageDoc);
            this.ClearTextBoxInfo(this.txtFunNurse);
            this.ClearTextBoxInfo(this.txtLinkFee);
            #endregion
            _deptInfo = deptInfo;
            _roomInfo = roomInfo;
            _bedInfo = new BedInfo();
            lblWardInfo.Text = "病区:[" + roomInfo.WardName + "] 科室:[" + deptInfo.DeptName + "]";
            lblCaption.Text = "新增病房";
            this.Text = lblCaption.Text;
            this.txtBedNo.Text = this.GetDefaultBedNo();

            LoadWardDept(deptInfo.WardID);
        }

        public FrmBedEdit(BedInfo bedInfo)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            //修改床位
            //
            _addNew = false;
            AddButtonToTextBox(this.btnChargeDoc, this.txtChargeDoc);
            AddButtonToTextBox(this.btnManageDoc, this.txtManageDoc);
            AddButtonToTextBox(this.btnFunNurse, this.txtFunNurse);
            AddButtonToTextBox(this.btnLinkFee, this.txtLinkFee);
            _bedInfo = bedInfo;
            this.ShowBedInfo(bedInfo);
            lblWardInfo.Text = "病区:[" + bedInfo.WardName + "] 科室:[" + bedInfo.DeptName + "]";
            lblCaption.Text = "修改病房";
            this.Text = lblCaption.Text;
            this.txtBedNo.Enabled = false;
            #region 增加房间菜单
            DataTable dtRoom = InstanceForm.BDatabase.GetDataTable("select distinct(room_no) as room_no from zy_beddiction where ward_id='" + bedInfo.WardID + "' and room_no<>'" + bedInfo.RoomNo + "' order by room_no");
            for (int i = 0; i <= dtRoom.Rows.Count - 1; i++)
            {
                MenuItem mRoom = new MenuItem();
                mRoom.Text = dtRoom.Rows[i]["room_no"].ToString();
                mRoom.Click += new EventHandler(mRoom_Click);
                this.mnuRoom.MenuItems.Add(mRoom);
            }
            #endregion
            LoadWardDept(bedInfo.WardID);
            for (int i = 0; i <= this.cboKs.Items.Count - 1; i++)
            {
                cboKs.SelectedIndex = i;
                if (Convert.ToInt64(cboKs.SelectedValue) == bedInfo.DeptID)
                    break;
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
            this.btnLinkFee = new System.Windows.Forms.Button();
            this.btnFunNurse = new System.Windows.Forms.Button();
            this.btnManageDoc = new System.Windows.Forms.Button();
            this.btnChargeDoc = new System.Windows.Forms.Button();
            this.chkPlus = new System.Windows.Forms.CheckBox();
            this.txtLinkFee = new System.Windows.Forms.TextBox();
            this.txtFunNurse = new System.Windows.Forms.TextBox();
            this.txtManageDoc = new System.Windows.Forms.TextBox();
            this.txtChargeDoc = new System.Windows.Forms.TextBox();
            this.txtBedNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCaption = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblWardInfo = new System.Windows.Forms.Label();
            this.btnChangeRoom = new System.Windows.Forms.Button();
            this.mnuRoom = new System.Windows.Forms.ContextMenu();
            this.cboKs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLinkFee
            // 
            this.btnLinkFee.Location = new System.Drawing.Point(336, 218);
            this.btnLinkFee.Name = "btnLinkFee";
            this.btnLinkFee.Size = new System.Drawing.Size(31, 15);
            this.btnLinkFee.TabIndex = 37;
            this.btnLinkFee.Click += new System.EventHandler(this.btnLinkFee_Click);
            // 
            // btnFunNurse
            // 
            this.btnFunNurse.Location = new System.Drawing.Point(334, 189);
            this.btnFunNurse.Name = "btnFunNurse";
            this.btnFunNurse.Size = new System.Drawing.Size(31, 15);
            this.btnFunNurse.TabIndex = 36;
            this.btnFunNurse.Click += new System.EventHandler(this.btnFunNurse_Click);
            // 
            // btnManageDoc
            // 
            this.btnManageDoc.Location = new System.Drawing.Point(333, 150);
            this.btnManageDoc.Name = "btnManageDoc";
            this.btnManageDoc.Size = new System.Drawing.Size(31, 15);
            this.btnManageDoc.TabIndex = 35;
            this.btnManageDoc.Click += new System.EventHandler(this.btnManageDoc_Click);
            // 
            // btnChargeDoc
            // 
            this.btnChargeDoc.Location = new System.Drawing.Point(337, 113);
            this.btnChargeDoc.Name = "btnChargeDoc";
            this.btnChargeDoc.Size = new System.Drawing.Size(31, 15);
            this.btnChargeDoc.TabIndex = 34;
            this.btnChargeDoc.Click += new System.EventHandler(this.btnChargeDoc_Click);
            // 
            // chkPlus
            // 
            this.chkPlus.Enabled = false;
            this.chkPlus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPlus.Location = new System.Drawing.Point(183, 73);
            this.chkPlus.Name = "chkPlus";
            this.chkPlus.Size = new System.Drawing.Size(59, 24);
            this.chkPlus.TabIndex = 33;
            this.chkPlus.Text = "加床";
            // 
            // txtLinkFee
            // 
            this.txtLinkFee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLinkFee.BackColor = System.Drawing.SystemColors.Window;
            this.txtLinkFee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLinkFee.Location = new System.Drawing.Point(109, 214);
            this.txtLinkFee.Name = "txtLinkFee";
            this.txtLinkFee.ReadOnly = true;
            this.txtLinkFee.Size = new System.Drawing.Size(300, 26);
            this.txtLinkFee.TabIndex = 32;
            this.txtLinkFee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLinkFee_KeyDown);
            // 
            // txtFunNurse
            // 
            this.txtFunNurse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFunNurse.BackColor = System.Drawing.SystemColors.Window;
            this.txtFunNurse.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFunNurse.Location = new System.Drawing.Point(109, 178);
            this.txtFunNurse.Name = "txtFunNurse";
            this.txtFunNurse.ReadOnly = true;
            this.txtFunNurse.Size = new System.Drawing.Size(300, 26);
            this.txtFunNurse.TabIndex = 31;
            this.txtFunNurse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFunNurse_KeyDown);
            // 
            // txtManageDoc
            // 
            this.txtManageDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManageDoc.BackColor = System.Drawing.SystemColors.Window;
            this.txtManageDoc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtManageDoc.Location = new System.Drawing.Point(109, 142);
            this.txtManageDoc.Name = "txtManageDoc";
            this.txtManageDoc.ReadOnly = true;
            this.txtManageDoc.Size = new System.Drawing.Size(300, 26);
            this.txtManageDoc.TabIndex = 30;
            this.txtManageDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtManageDoc_KeyDown);
            // 
            // txtChargeDoc
            // 
            this.txtChargeDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChargeDoc.BackColor = System.Drawing.SystemColors.Window;
            this.txtChargeDoc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtChargeDoc.Location = new System.Drawing.Point(109, 106);
            this.txtChargeDoc.Name = "txtChargeDoc";
            this.txtChargeDoc.ReadOnly = true;
            this.txtChargeDoc.Size = new System.Drawing.Size(300, 26);
            this.txtChargeDoc.TabIndex = 29;
            this.txtChargeDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChargeDoc_KeyDown);
            // 
            // txtBedNo
            // 
            this.txtBedNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBedNo.Location = new System.Drawing.Point(109, 71);
            this.txtBedNo.Name = "txtBedNo";
            this.txtBedNo.Size = new System.Drawing.Size(67, 26);
            this.txtBedNo.TabIndex = 27;
            this.txtBedNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBedNo_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(31, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = "床位费";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(31, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "负责护士";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(31, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "管床医生";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(31, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "主治医生";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(31, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "床位号";
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCaption.BackColor2 = System.Drawing.Color.AliceBlue;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(479, 23);
            this.lblCaption.TabIndex = 38;
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(325, 300);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 28);
            this.btnExit.TabIndex = 39;
            this.btnExit.Text = "取消(&X)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(228, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 28);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblWardInfo
            // 
            this.lblWardInfo.AutoSize = true;
            this.lblWardInfo.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWardInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblWardInfo.Location = new System.Drawing.Point(31, 36);
            this.lblWardInfo.Name = "lblWardInfo";
            this.lblWardInfo.Size = new System.Drawing.Size(0, 19);
            this.lblWardInfo.TabIndex = 41;
            // 
            // btnChangeRoom
            // 
            this.btnChangeRoom.ContextMenu = this.mnuRoom;
            this.btnChangeRoom.Location = new System.Drawing.Point(401, 26);
            this.btnChangeRoom.Name = "btnChangeRoom";
            this.btnChangeRoom.Size = new System.Drawing.Size(77, 22);
            this.btnChangeRoom.TabIndex = 42;
            this.btnChangeRoom.Text = "转到房间";
            this.btnChangeRoom.Click += new System.EventHandler(this.btnChangeRoom_Click);
            // 
            // cboKs
            // 
            this.cboKs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKs.Enabled = false;
            this.cboKs.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboKs.Location = new System.Drawing.Point(313, 73);
            this.cboKs.Name = "cboKs";
            this.cboKs.Size = new System.Drawing.Size(97, 24);
            this.cboKs.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(240, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "所属科室";
            // 
            // lblMsg
            // 
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMsg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(29, 251);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(389, 38);
            this.lblMsg.TabIndex = 45;
            this.lblMsg.Text = "请一定按照（本病区）所在的楼层楼栋，选择正确的床位设置!否则导致床位费多记、少记!\r\n";
            // 
            // FrmBedEdit
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(479, 336);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboKs);
            this.Controls.Add(this.btnChangeRoom);
            this.Controls.Add(this.lblWardInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.btnLinkFee);
            this.Controls.Add(this.btnFunNurse);
            this.Controls.Add(this.btnManageDoc);
            this.Controls.Add(this.btnChargeDoc);
            this.Controls.Add(this.chkPlus);
            this.Controls.Add(this.txtLinkFee);
            this.Controls.Add(this.txtFunNurse);
            this.Controls.Add(this.txtManageDoc);
            this.Controls.Add(this.txtChargeDoc);
            this.Controls.Add(this.txtBedNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBedEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region AddButtonToTextBox
        private void AddButtonToTextBox(Button btnObject, TextBox txtObject)
        {
            txtObject.Controls.Add(btnObject);
            btnObject.Dock = DockStyle.Right;
            btnObject.BackColor = SystemColors.Control;
            btnObject.Cursor = Cursors.Hand;
        }
        #endregion

        #region ClearTextBoxInfo
        private void ClearTextBoxInfo(TextBox textBox)
        {
            textBox.Tag = -1;
            textBox.Text = "";
        }
        #endregion

        #region 显示病床的信息
        private void ShowBedInfo(BedInfo bedInfo)
        {
            this.txtBedNo.Tag = bedInfo.BedID;
            this.txtBedNo.Text = bedInfo.BedNo;
            this.txtChargeDoc.Text = bedInfo.ChargeDocName;
            this.txtChargeDoc.Tag = bedInfo.ChargeDocID;
            this.txtManageDoc.Text = bedInfo.ManageDocName;
            this.txtManageDoc.Tag = bedInfo.ManageDocID;
            this.txtFunNurse.Text = bedInfo.FunNurseName;
            this.txtFunNurse.Tag = bedInfo.FunNurseID;
            this.txtLinkFee.Text = bedInfo.LinkFeeName.Trim();
            this.txtLinkFee.Tag = bedInfo.LinkFeeID;
            this.chkPlus.Checked = bedInfo.IsPlus;
        }
        #endregion

        #region 保存前的数据检查
        private bool DataExists()
        {
            string sql = "";
            DataRow dr = null;
            //判断床位号是否存在
            sql = "select bed_id from zy_beddiction where ward_id='" + _bedInfo.WardID + "' and bed_no='" + _bedInfo.BedNo + "'";
            dr = InstanceForm.BDatabase.GetDataRow(sql);
            if (dr != null)
            {
                MessageBox.Show("[" + _bedInfo.WardName + "] 已经有床号为[" + _bedInfo.BedNo + "]的病床", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            sql = "select dept_id,inpatient_id from zy_beddiction where bed_id='" + _bedInfo.BedID + "'";
            dr = InstanceForm.BDatabase.GetDataRow(sql);
            if (dr != null)
            {
                if (!Convert.IsDBNull(dr["inpatient_id"]))
                    if (!Convert.IsDBNull(dr["dept_id"]))
                        if (Convert.ToInt64(dr["dept_id"]) != Convert.ToInt64(cboKs.SelectedValue))
                        {
                            MessageBox.Show("该床位有病人,不允许修改病床的所属科室", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
            }
            return true;
        }
        #endregion

        #region 保存床位信息
        private bool SaveBedInfo(BedInfo _bedInfo_old)
        {
            if (!DataExists()) return false;
            try
            {
                string sql = "";
                int plus = this.chkPlus.Checked ? 1 : 0;
                string cznr = "";
                if (_addNew)
                {
                    //新增
                    sql = "insert into zy_beddiction (ward_id,dept_id,room_no,bed_no,hoitem_id,zz_doc,zy_doc,chargenurse,isplus,isinuse)";
                    sql += " values('" + _bedInfo.WardID + "'," + _bedInfo.DeptID + ",'" + _bedInfo.RoomNo + "','" + _bedInfo.BedNo + "'," + _bedInfo.LinkFeeID + "," + _bedInfo.ChargeDocID + "," + _bedInfo.ManageDocID + "," + _bedInfo.FunNurseID + "," + plus + ",0)";
                    cznr = "增加： " + _bedInfo.WardName + _bedInfo.DeptName + "(" + _bedInfo.BedNo + "床) hoitem_id:" + _bedInfo.LinkFeeName + "(" + _bedInfo.LinkFeeID + ")";

                }
                else
                {
                    //更新
                    sql = "update zy_beddiction set zz_doc=" + _bedInfo.ChargeDocID + ",zy_doc=" + _bedInfo.ManageDocID + ",chargenurse=" + _bedInfo.FunNurseID + ",hoitem_id=" + _bedInfo.LinkFeeID + ",isplus=" + plus + ",dept_id=" + _bedInfo.DeptID;
                    sql += " where bed_id='" + _bedInfo.BedID + "'";
                    cznr = "修改：原" + _bedInfo_old.WardName + _bedInfo_old.DeptName + "(" + _bedInfo_old.BedNo + "床) hoitem_id:" + _bedInfo_old.LinkFeeName + "(" + _bedInfo_old.LinkFeeID + ")  现改为" + _bedInfo.WardName + _bedInfo.DeptName + "(" + _bedInfo.BedNo + "床) hoitem_id:" + _bedInfo.LinkFeeName + "(" + _bedInfo.LinkFeeID + ")" + " 主治医生|" + _bedInfo.ChargeDocName + "|护士|" + _bedInfo.FunNurseName + "|管床医生|" + _bedInfo.ManageDocName;

                }
                InstanceForm.BDatabase.DoCommand(sql);
                SaveLog("床位保存", cznr);

                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        private bool SaveLog(string operator_type, string contents)
        {
            return ts_jc_log.His_Log.SaveLog(operator_type, contents, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);

        }

        #region 获取默认床位号
        private string GetDefaultBedNo()
        {
            try
            {
                string sql = "select max(cast(bed_no as integer)) + 1 from zy_beddiction where ward_id='" + _roomInfo.WardID + "' and isplus=0 ";
                DataRow dr = InstanceForm.BDatabase.GetDataRow(sql);
                if (dr != null)
                    return dr[0].ToString().Length == 1 ? "0" + dr[0].ToString() : dr[0].ToString();
                else
                    return "01";
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 加载该病区的科室
        private void LoadWardDept(string WardID)
        {
            string sql = "select a.DEPT_ID,b.NAME from jc_wardrdept a inner join jc_dept_property b on a.dept_id=b.dept_id";
            sql += " where a.ward_id='" + WardID + "'";
            DataTable dtDept = InstanceForm.BDatabase.GetDataTable(sql);
            this.cboKs.DisplayMember = "NAME";
            this.cboKs.ValueMember = "DEPT_ID";
            this.cboKs.DataSource = dtDept;
        }
        #endregion

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this._operateCancel = true;
            this.Close();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            #region 重新赋值_bedInfo
            BedInfo _bedInfo_old = _bedInfo;
            _bedInfo.DeptID = Convert.ToInt64(this.cboKs.SelectedValue);//this._deptInfo.DeptID;
            _bedInfo.BedNo = this.txtBedNo.Text;
            _bedInfo.RoomNo = this._roomInfo.RoomNo;
            _bedInfo.WardID = this._roomInfo.WardID;
            _bedInfo.WardName = this._roomInfo.WardName;
            _bedInfo.ChargeDocID = Convert.ToInt64(this.txtChargeDoc.Tag);
            _bedInfo.ChargeDocName = this.txtChargeDoc.Text;
            _bedInfo.ManageDocID = Convert.ToInt64(this.txtManageDoc.Tag);
            _bedInfo.ManageDocName = this.txtManageDoc.Text;
            _bedInfo.FunNurseID = Convert.ToInt64(this.txtFunNurse.Tag);
            _bedInfo.FunNurseName = this.txtFunNurse.Text;

            SystemCfg cfg = new SystemCfg(7601);
            if (cfg != null && cfg.Config != null && cfg.Config.ToString().Trim() == "1")
            {
                if (this.txtLinkFee.Tag == null || string.Empty == this.txtLinkFee.Text.Trim())
                {
                    MessageBox.Show("床位费不能为空,请录入床位费!");
                    txtLinkFee.Focus();
                    return;
                }
            }
            _bedInfo.LinkFeeID = Convert.ToInt64(this.txtLinkFee.Tag);
            _bedInfo.LinkFeeName = this.txtLinkFee.Text;
            _bedInfo.IsPlus = this.chkPlus.Checked;
            #endregion
            if (this.SaveBedInfo(_bedInfo_old))
            {

                this._operateCancel = false;
                this.Close();
            }
        }

        private void txtChargeDoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                this.ClearTextBoxInfo(txtChargeDoc);
            else if (e.KeyCode == Keys.Enter)
                this.txtManageDoc.Focus();
            else
                this.btnChargeDoc_Click(null, null);
        }

        private void txtManageDoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                this.ClearTextBoxInfo(txtManageDoc);
            else if (e.KeyCode == Keys.Enter)
                this.txtFunNurse.Focus();
            else
                this.btnManageDoc_Click(null, null);
        }

        private void txtFunNurse_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                this.ClearTextBoxInfo(txtFunNurse);
            else if (e.KeyCode == Keys.Enter)
                this.txtLinkFee.Focus();
            else
                this.btnFunNurse_Click(null, null);
        }

        private void txtLinkFee_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                this.ClearTextBoxInfo(txtLinkFee);
            else if (e.KeyCode == Keys.Enter)
                this.btnSave.Focus();
            else
                this.btnLinkFee_Click(null, null);
        }

        private void btnChargeDoc_Click(object sender, System.EventArgs e)
        {
            string sql = "select b.employee_id as id,' ' as code,b.name,py_code,wb_code from jc_role_doctor a inner join jc_employee_property b on a.employee_id=b.employee_id where b.delete_bit=0 order by a.employee_id";
            FrmSelectCard fSelect = new FrmSelectCard(sql, 1);
            fSelect.ShowDialog();
            if (fSelect.FindResult)
            {
                this.txtChargeDoc.Text = fSelect.SelectName;
                this.txtChargeDoc.Tag = fSelect.SelectID;
            }
        }

        private void btnManageDoc_Click(object sender, System.EventArgs e)
        {
            string sql = "select b.employee_id as id,' ' as code,b.name,py_code,wb_code from jc_role_doctor a inner join jc_employee_property b on a.employee_id=b.employee_id where b.delete_bit=0 order by a.employee_id";
            FrmSelectCard fSelect = new FrmSelectCard(sql, 1);
            fSelect.ShowDialog();
            if (fSelect.FindResult)
            {
                this.txtManageDoc.Text = fSelect.SelectName;
                this.txtManageDoc.Tag = fSelect.SelectID;
            }
        }

        private void btnFunNurse_Click(object sender, System.EventArgs e)
        {
            string sql = "select b.employee_id as id,' ' as code,b.name,py_code,wb_code from jc_role_nurse a inner join jc_employee_property b on a.employee_id=b.employee_id where b.delete_bit=0 order by a.employee_id";
            FrmSelectCard fSelect = new FrmSelectCard(sql, 1);
            fSelect.ShowDialog();
            if (fSelect.FindResult)
            {
                this.txtFunNurse.Text = fSelect.SelectName;
                this.txtFunNurse.Tag = fSelect.SelectID;
            }
        }

        private void btnLinkFee_Click(object sender, System.EventArgs e)
        {
            string sql = "select  c.jgbm,b.order_id as ID,b.d_code as Code,order_name as name,b.py_code ,b.wb_code,c.price";
            sql += " from jc_hoi_hdi a inner join jc_hoitemdiction b on a.hoitem_id=b.order_id";
            sql += " inner join vi_jc_items c on a.hditem_id=c.itemid and a.tcid=c.tcid";
            sql += " inner join Jc_cwggd t on a.HOITEM_ID=t.Hoitem_id and t.delete_bit=0";
            //sql += " inner join JC_HOI_DEPT d on b.ORDER_ID=d.ORDER_ID ";
            //sql += " where b.delete_bit=0 and c.bigitemcode='" + (new SystemCfg(7029)).Config.Trim() + "' and d.EXEC_DEPT='" + InstanceForm.BCurrentDept.DeptId + "' order by b.order_id";

            sql += " where b.delete_bit=0 and c.bigitemcode='" + (new SystemCfg(7029)).Config.Trim() + "' order by order_name,b.order_id";
            FrmSelectCard fSelect = new FrmSelectCard(sql);
            fSelect.ShowDialog();
            if (fSelect.FindResult)
            {
                this.txtLinkFee.Text = fSelect.SelectName;
                this.txtLinkFee.Tag = fSelect.SelectID;
            }
        }

        private void txtBedNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (txtBedNo.Text != "" && e.KeyCode == Keys.Enter)
                this.txtChargeDoc.Focus();
        }

        private void btnChangeRoom_Click(object sender, System.EventArgs e)
        {
            btnChangeRoom.ContextMenu.Show(btnChangeRoom, new Point(0, btnChangeRoom.Height));
        }

        private void mRoom_Click(object sender, EventArgs e)
        {
            string roomNo = ((MenuItem)sender).Text;
            string sql = "";
            sql = "select inpatient_id from zy_beddiction where bed_id='" + _bedInfo.BedID + "'";
            DataRow dr = InstanceForm.BDatabase.GetDataRow(sql);
            if (!Convert.IsDBNull(dr[0]))
            {
                MessageBox.Show("该床位有病人，不允许转房!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dlgRst = MessageBox.Show("保留现有床位设置吗？", "转移", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgRst == DialogResult.Yes)
                sql = "update zy_beddiction set room_no='" + roomNo + "' where bed_id='" + _bedInfo.BedID + "'";
            else
                sql = "update zy_beddiction set room_no='" + roomNo + "',zz_doc=-1,zy_doc=-1,chargenurse=-1,hoitem_id=-1 where bed_id='" + _bedInfo.BedID + "'";
            InstanceForm.BDatabase.DoCommand(sql);
            this._ChangeRoom = true;
            this.Close();
        }
    }
}
