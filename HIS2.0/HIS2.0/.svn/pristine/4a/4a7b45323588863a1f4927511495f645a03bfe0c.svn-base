using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
namespace TrasenMainWindow.Forms
{
    /// <summary>
    /// 菜单属性编辑对话框
    /// </summary>
    public class FrmMenuProperty : System.Windows.Forms.Form
    {
        /// <summary>
        /// 当前菜单编号
        /// </summary>
        private int m_currentMenuId = 0;
        /// <summary>
        /// 本窗体的数据库连接
        /// </summary>
        private RelationalDatabase db;//Add By Tany 2010-01-27
        /// <summary>
        /// 本窗体连接的机构编码
        /// </summary>
        private int jgbm;//Add By Tany 2010-01-27

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtMenuName;
        private System.Windows.Forms.TextBox txtDllName;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.TextBox txtFunctionTag;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkShowToolbar;
        private CheckBox chkIco;
        private Button btnBrowen;
        private PictureBox picIco;
        private ImageList imageList1;
        private ComboBox cmbJgbm;
        private Label label5;
        private CheckBox chk_CanUserPublicPwd;
        private IContainer components;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="MenuId"></param>
        /// <param name="_db"></param>
        /// <param name="_jgbm"></param>
        public FrmMenuProperty(int MenuId, RelationalDatabase _db, int _jgbm)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            db = _db;
            jgbm = _jgbm;
            this.Text += "【" + jgbm + "】";
            this.m_currentMenuId = MenuId;
            this.DialogResult = DialogResult.Cancel;
            AddJgbm();
            GetMenuInfo(this.m_currentMenuId);
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

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <param name="MenuId"></param>
        private void GetMenuInfo(int MenuId)
        {
            ParameterEx[] paras = new ParameterEx[1];
            paras[0].Text = "@MenuId";
            paras[0].Value = this.m_currentMenuId;

            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "up_GetMenuInfo";
            db.SetParameters(cmd, paras);

            DataRow dr = db.GetDataRow(cmd);
            if (dr != null)
            {
                this.txtMenuName.Text = dr["Name"].ToString().Trim();
                this.txtDllName.Text = dr["Dll_Name"].ToString().Trim();
                this.txtFunctionName.Text = dr["Function_Name"].ToString().Trim();
                this.txtFunctionTag.Text = dr["Function_Tag"].ToString().Trim();
                this.cmbJgbm.SelectedValue = Convert.ToInt32(dr["jgbm"]);//Add By Tany 2010-01-14

                this.chkShowToolbar.Checked = Convert.ToInt32(dr["showtoolbar"]) == 1 ? true : false;

                this.chkShowToolbar.Visible = this.txtFunctionName.Text.Trim() == "" ? false : true;
                //是否可以用公用密码 jianqg 2012-10-6 emr-his框架整合  增加
                //jianqg emr-his 整合暂时注释
                this.chk_CanUserPublicPwd.Checked = Convert.ToInt32(dr["CanUsePublicPwd"]) == 1 ? true : false;
                this.chk_CanUserPublicPwd.Visible = this.txtFunctionName.Text.Trim() == "" ? false : true;
                txtDllName.Enabled = txtFunctionName.Enabled =txtFunctionTag.Enabled = this.txtFunctionName.Text.Trim() == "" ? false : true;


                if (Convert.IsDBNull(dr["icon"]))
                    return;
                try
                {
                    object objIco = dr["icon"];
                    if (objIco != null)
                    {
                        byte[] byteIco = (byte[])objIco;
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(byteIco);

                        Image img = Image.FromStream(ms);

                        picIco.Image = img;
                        chkIco.Checked = true;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        /// <summary>
        /// 更新菜单信息
        /// </summary>
        private bool UpdateMenuInfo()
        {
            try
            {
                //jianqg emr-his 整合暂时注释  本函数 需要修改几处
                //增加参数CanUsePublicPwd jianqg 2012-10-6 emr-his框架整合  增加 
                ParameterEx[] paras = new ParameterEx[10];
                #region ...
                paras[0].Text = "@MenuId";
                paras[0].Value = this.m_currentMenuId;
                paras[1].Text = "@Name";
                paras[1].Value = txtMenuName.Text.Trim();
                paras[2].Text = "@DllName";
                paras[2].Value = this.txtDllName.Text.Trim();
                paras[3].Text = "@FunctionName";
                paras[3].Value = this.txtFunctionName.Text.Trim();
                paras[4].Text = "@DeleteBit";
                paras[4].Value = 0;
                paras[5].Text = "@ShowToolBar";
                paras[5].Value = this.chkShowToolbar.Checked ? 1 : 0;
                paras[6].Text = "@FunctionTag";
                paras[6].Value = this.txtFunctionTag.Text.Trim();
                paras[7].Text = "@Jgbm";
                paras[7].Value = this.cmbJgbm.SelectedValue;
                paras[8].Text = "@Errmsg";
                paras[8].ParaDirection = ParameterDirection.Output;
                paras[8].ParaSize = 200;

                paras[9].Text = "@CanUsePublicPwd";
                paras[9].Value = this.chk_CanUserPublicPwd.Checked ? 1 : 0;
                #endregion

                try
                {
                    //定义多院操作日志 Modify By Tany 2010-01-29
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    Guid log_djid = Guid.Empty;

                    db.BeginTransaction();

                    db.DoCommand("up_UpdateMenuInfo", paras, 30);

                    if (chkIco.Checked && Convertor.IsNull(picIco.Tag, "") != "")
                    {
                        System.IO.FileStream fs = new System.IO.FileStream(picIco.Tag.ToString(), System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
                        byte[] byteIco = new byte[fs.Length];
                        fs.Read(byteIco, 0, Convert.ToInt32(fs.Length));
                        fs.Close();

                        string sql = "update pub_menu set icon=@Ico where menu_id=@menuId";
                        IDbCommand cmd = db.GetCommand();
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;

                        IDataParameter parameter;
                        parameter = cmd.CreateParameter();
                        parameter.ParameterName = "@Ico";
                        parameter.Value = byteIco;
                        cmd.Parameters.Add(parameter);

                        parameter = cmd.CreateParameter();
                        parameter.ParameterName = "@menuId";
                        parameter.Value = m_currentMenuId;
                        cmd.Parameters.Add(parameter);

                        cmd.Transaction = db.GetTransaction();
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        if (picIco.Image != null)
                        {
                            db.DoCommand("update pub_menu set icon=null where menu_id=" + m_currentMenuId);
                        }
                    }

                    //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                    string cznr = "修改菜单:【" + txtMenuName.Text.Trim() + "】";
                    ts.Save_log(ts_HospData_Share.czlx.jc_菜单修改, cznr, "pub_menu", "menu_Id", this.m_currentMenuId.ToString(), jgbm, -999, "", out log_djid, db);

                    db.CommitTransaction();

                    try
                    {
                        //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                        string errtext = "";
                        ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_菜单修改, db);
                        if (ty.Bzx == 1 && log_djid != Guid.Empty)
                        {
                            //立即执行该操作 Modify By Tany 2010-01-29
                            ts.Pexec_log(log_djid, db, out errtext);
                        }
                        if (errtext != "")
                        {
                            throw new Exception(errtext);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("发生错误：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return true;
                }
                catch (Exception err)
                {
                    db.RollbackTransaction();
                    throw err;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMenuName = new System.Windows.Forms.TextBox();
            this.txtDllName = new System.Windows.Forms.TextBox();
            this.txtFunctionName = new System.Windows.Forms.TextBox();
            this.txtFunctionTag = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chk_CanUserPublicPwd = new System.Windows.Forms.CheckBox();
            this.cmbJgbm = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBrowen = new System.Windows.Forms.Button();
            this.picIco = new System.Windows.Forms.PictureBox();
            this.chkIco = new System.Windows.Forms.CheckBox();
            this.chkShowToolbar = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIco)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "菜单名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "动态链接库";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "调用函数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "附属值";
            // 
            // txtMenuName
            // 
            this.txtMenuName.Location = new System.Drawing.Point(92, 24);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(204, 21);
            this.txtMenuName.TabIndex = 4;
            // 
            // txtDllName
            // 
            this.txtDllName.Location = new System.Drawing.Point(92, 60);
            this.txtDllName.Name = "txtDllName";
            this.txtDllName.Size = new System.Drawing.Size(204, 21);
            this.txtDllName.TabIndex = 5;
            this.txtDllName.TextChanged += new System.EventHandler(this.txtDllName_TextChanged);
            // 
            // txtFunctionName
            // 
            this.txtFunctionName.Location = new System.Drawing.Point(92, 96);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.Size = new System.Drawing.Size(204, 21);
            this.txtFunctionName.TabIndex = 6;
            this.txtFunctionName.TextChanged += new System.EventHandler(this.txtFunctionName_TextChanged);
            // 
            // txtFunctionTag
            // 
            this.txtFunctionTag.Location = new System.Drawing.Point(92, 132);
            this.txtFunctionTag.Name = "txtFunctionTag";
            this.txtFunctionTag.Size = new System.Drawing.Size(204, 21);
            this.txtFunctionTag.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(154, 316);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 26);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(244, 316);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 26);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(320, 306);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chk_CanUserPublicPwd);
            this.tabPage1.Controls.Add(this.cmbJgbm);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnBrowen);
            this.tabPage1.Controls.Add(this.picIco);
            this.tabPage1.Controls.Add(this.chkIco);
            this.tabPage1.Controls.Add(this.chkShowToolbar);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtDllName);
            this.tabPage1.Controls.Add(this.txtMenuName);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtFunctionTag);
            this.tabPage1.Controls.Add(this.txtFunctionName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(312, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "属性";
            // 
            // chk_CanUserPublicPwd
            // 
            this.chk_CanUserPublicPwd.Location = new System.Drawing.Point(133, 202);
            this.chk_CanUserPublicPwd.Name = "chk_CanUserPublicPwd";
            this.chk_CanUserPublicPwd.Size = new System.Drawing.Size(159, 24);
            this.chk_CanUserPublicPwd.TabIndex = 10;
            this.chk_CanUserPublicPwd.Text = "公用密码可以使用该菜单";
            // 
            // cmbJgbm
            // 
            this.cmbJgbm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJgbm.FormattingEnabled = true;
            this.cmbJgbm.Location = new System.Drawing.Point(92, 168);
            this.cmbJgbm.Name = "cmbJgbm";
            this.cmbJgbm.Size = new System.Drawing.Size(204, 20);
            this.cmbJgbm.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "机构编码指向";
            // 
            // btnBrowen
            // 
            this.btnBrowen.Enabled = false;
            this.btnBrowen.Location = new System.Drawing.Point(146, 237);
            this.btnBrowen.Name = "btnBrowen";
            this.btnBrowen.Size = new System.Drawing.Size(150, 27);
            this.btnBrowen.TabIndex = 12;
            this.btnBrowen.Text = "浏览...";
            this.btnBrowen.UseVisualStyleBackColor = true;
            this.btnBrowen.Click += new System.EventHandler(this.btnBrowen_Click);
            // 
            // picIco
            // 
            this.picIco.Enabled = false;
            this.picIco.Location = new System.Drawing.Point(92, 232);
            this.picIco.Name = "picIco";
            this.picIco.Size = new System.Drawing.Size(39, 32);
            this.picIco.TabIndex = 10;
            this.picIco.TabStop = false;
            // 
            // chkIco
            // 
            this.chkIco.AutoSize = true;
            this.chkIco.Location = new System.Drawing.Point(18, 243);
            this.chkIco.Name = "chkIco";
            this.chkIco.Size = new System.Drawing.Size(48, 16);
            this.chkIco.TabIndex = 11;
            this.chkIco.Text = "图标";
            this.chkIco.UseVisualStyleBackColor = true;
            this.chkIco.CheckedChanged += new System.EventHandler(this.chkIco_CheckedChanged);
            // 
            // chkShowToolbar
            // 
            this.chkShowToolbar.Location = new System.Drawing.Point(18, 202);
            this.chkShowToolbar.Name = "chkShowToolbar";
            this.chkShowToolbar.Size = new System.Drawing.Size(104, 24);
            this.chkShowToolbar.TabIndex = 9;
            this.chkShowToolbar.Text = "在工具栏显示";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmMenuProperty
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(325, 350);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenuProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "菜单属性";
            this.Load += new System.EventHandler(this.FrmMenuProperty_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIco)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (txtMenuName.Text.Trim() == "")
            {
                MessageBox.Show("菜单名称不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (UpdateMenuInfo())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FrmMenuProperty_Load(object sender, System.EventArgs e)
        {

        }

        private void txtDllName_TextChanged(object sender, System.EventArgs e)
        {
            if (txtDllName.Text.Trim() != "" && txtFunctionName.Text.Trim() != "")
                this.chkShowToolbar.Visible = this.chk_CanUserPublicPwd.Visible = true;
            else
                this.chkShowToolbar.Visible = this.chk_CanUserPublicPwd.Visible = false;
        }

        private void txtFunctionName_TextChanged(object sender, System.EventArgs e)
        {
            if (txtDllName.Text.Trim() != "" && txtFunctionName.Text.Trim() != "")
                this.chkShowToolbar.Visible = this.chk_CanUserPublicPwd.Visible = true;
            else
                this.chkShowToolbar.Visible = this.chk_CanUserPublicPwd.Visible = false;
        }

        private void chkIco_CheckedChanged(object sender, EventArgs e)
        {
            picIco.Enabled = chkIco.Checked;
            btnBrowen.Enabled = chkIco.Checked;
        }

        private void btnBrowen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();

            openDlg.Filter = "图标文件|*.ico";
            openDlg.Multiselect = false;
            openDlg.CheckFileExists = true;

            if (openDlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Image img = Image.FromFile(openDlg.FileName);
                imageList1.Images.Add(img);
                picIco.Image = img;
                picIco.Tag = openDlg.FileName;
            }
            catch
            {
                MessageBox.Show("不合适的图片文件");
            }
        }

        private void AddJgbm()
        {
            string sql = "select * from jc_jgbm order by jgbm";
            DataTable tb = db.GetDataTable(sql);
            DataRow row = tb.NewRow();
            row["jgbm"] = -1;
            row["jgmc"] = "本地连接";
            tb.Rows.Add(row);
            cmbJgbm.DataSource = tb;
            cmbJgbm.DisplayMember = "jgmc";
            cmbJgbm.ValueMember = "jgbm";
            cmbJgbm.SelectedValue = -1;
        }
    }
}
