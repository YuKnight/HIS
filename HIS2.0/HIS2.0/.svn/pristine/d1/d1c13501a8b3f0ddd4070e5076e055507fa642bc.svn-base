using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
namespace TrasenFrame.Forms
{
    /// <summary>
    /// 登录科室选择对话框
    /// </summary>
    public class FrmSelectDept : System.Windows.Forms.Form
    {
        /// <summary>
        /// 选择的科室编号
        /// </summary>
        public int SelectedDeptId = 0;
        /// <summary>
        /// 人员科室信息
        /// </summary>
        private DataTable tableDept;
        private System.Windows.Forms.ListView lvwDept;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ImageList imglst;
        private System.Windows.Forms.TextBox txtFilter;
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmSelectDept()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="EmployeeId">人员编号</param>
        public FrmSelectDept(int EmployeeId)
        {
            InitializeComponent();


            string sql = "select dept_id as ksbh,name,py_code,wb_code,d_code from jc_dept_property where deleted=0 and layer=3 and dept_id in (select dept_id from jc_emp_dept_role where employee_id = " + EmployeeId + ") and (jgbm=" + FrmMdiMain.Jgbm + " or jgbm=" + FrmMdiMain.ZxJgbm + " or '" + FrmMdiMain.CurrentUser.IsAdministrator.ToString() + "'='True')";
            if (FrmMdiMain.CurrentUser.IsAdministrator)
                sql = "select dept_id as ksbh,name,py_code,wb_code,d_code from jc_dept_property where deleted = 0 and layer=3 and (jgbm=" + FrmMdiMain.Jgbm + " or jgbm=" + FrmMdiMain.ZxJgbm + " or '" + FrmMdiMain.CurrentUser.IsAdministrator.ToString() + "'='True')";


            this.tableDept = FrmMdiMain.Database.GetDataTable(sql);
            for (int i = 0; i < tableDept.Rows.Count; i++)
            {
                Department dept = new Department();
                dept.DeptId = Convert.ToInt32(tableDept.Rows[i]["ksbh"]);
                dept.DeptName = tableDept.Rows[i]["name"].ToString().Trim();

                ListViewItem item = new ListViewItem(dept.DeptName);
                item.ImageIndex = 0;
                item.Tag = dept;
                this.lvwDept.Items.Add(item);
            }

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="user"></param>
        public FrmSelectDept(User user)
        {
            InitializeComponent();

            string sql = "select dept_id as ksbh,name,py_code,wb_code,d_code from jc_dept_property where deleted=0 and layer=3 and dept_id in (select dept_id from jc_emp_dept_role where employee_id = " + user.EmployeeId + ") and (jgbm=" + FrmMdiMain.Jgbm + " or jgbm=" + FrmMdiMain.ZxJgbm + " or '" + FrmMdiMain.CurrentUser.IsAdministrator.ToString() + "'='True')";
            if (user.IsAdministrator)
                sql = "select dept_id as ksbh,name,py_code,wb_code,d_code from jc_dept_property where deleted=0 and layer=3 and (jgbm=" + FrmMdiMain.Jgbm + " or jgbm=" + FrmMdiMain.ZxJgbm + " or '" + FrmMdiMain.CurrentUser.IsAdministrator.ToString() + "'='True')";

            this.tableDept = FrmMdiMain.Database.GetDataTable(sql);
            for (int i = 0; i < tableDept.Rows.Count; i++)
            {
                Department dept = new Department();
                dept.DeptId = Convert.ToInt32(tableDept.Rows[i]["ksbh"]);
                dept.DeptName = tableDept.Rows[i]["name"].ToString().Trim();

                ListViewItem item = new ListViewItem(dept.DeptName);
                item.ImageIndex = 0;
                item.Tag = dept;
                this.lvwDept.Items.Add(item);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmSelectDept ) );
            this.lvwDept = new System.Windows.Forms.ListView();
            this.imglst = new System.Windows.Forms.ImageList( this.components );
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvwDept
            // 
            this.lvwDept.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwDept.HideSelection = false;
            this.lvwDept.LargeImageList = this.imglst;
            this.lvwDept.Location = new System.Drawing.Point( 0 , 0 );
            this.lvwDept.Name = "lvwDept";
            this.lvwDept.Size = new System.Drawing.Size( 406 , 224 );
            this.lvwDept.SmallImageList = this.imglst;
            this.lvwDept.TabIndex = 1;
            this.lvwDept.UseCompatibleStateImageBehavior = false;
            this.lvwDept.View = System.Windows.Forms.View.List;
            this.lvwDept.KeyUp += new System.Windows.Forms.KeyEventHandler( this.lvwDept_KeyUp );
            // 
            // imglst
            // 
            this.imglst.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imglst.ImageStream" ) ) );
            this.imglst.TransparentColor = System.Drawing.Color.Transparent;
            this.imglst.Images.SetKeyName( 0 , "" );
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point( 227 , 251 );
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size( 75 , 23 );
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "选择";
            this.btnSelect.Click += new System.EventHandler( this.btnSelect_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point( 319 , 251 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75 , 23 );
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // txtFilter
            // 
            this.txtFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFilter.Location = new System.Drawing.Point( 0 , 224 );
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size( 406 , 21 );
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler( this.txtFilter_TextChanged );
            this.txtFilter.KeyUp += new System.Windows.Forms.KeyEventHandler( this.txtFilter_KeyUp );
            // 
            // FrmSelectDept
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 6 , 14 );
            this.ClientSize = new System.Drawing.Size( 406 , 281 );
            this.ControlBox = false;
            this.Controls.Add( this.txtFilter );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnSelect );
            this.Controls.Add( this.lvwDept );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectDept";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择科室";
            this.Load += new System.EventHandler( this.FrmSelectDept_Load );
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.FrmSelectDept_KeyPress );
            this.ResumeLayout( false );
            this.PerformLayout();

        }
        #endregion

        private void btnSelect_Click(object sender, System.EventArgs e)
        {
            
            if (lvwDept.Items.Count == 1)
            {
                this.SelectedDeptId = ((Department)this.lvwDept.Items[0].Tag).DeptId;
            }
            else
            {
                if (this.lvwDept.SelectedItems.Count == 0) return;
                if (this.lvwDept.Items.Count > 1 && this.lvwDept.SelectedItems.Count != 0)
                {
                    this.SelectedDeptId = ((Department)this.lvwDept.SelectedItems[0].Tag).DeptId;
                }
                else
                {
                    if (lvwDept.Items.Count == 1)
                    {
                        this.SelectedDeptId = ((Department)this.lvwDept.Items[0].Tag).DeptId;
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
   
            //选择科室的时候改变操作员的登录科室
            //Modify By Tany 2009-12-23
            FrmMdiMain.Database.DoCommand("update pub_user set login_dept = " + SelectedDeptId + " where id=" + FrmMdiMain.CurrentUser.UserID);

            this.Close();
        }

        private void FrmSelectDept_Load(object sender, System.EventArgs e)
        {
            txtFilter.Focus();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtFilter_TextChanged(object sender, System.EventArgs e)
        {
            this.lvwDept.Items.Clear();
            string sFilter = "";

            if (this.txtFilter.Text != "")
            {
                sFilter = txtFilter.Text;
                sFilter = sFilter.Replace("*", "[*]").Replace("%", "[%]").Replace("'", "''");
                sFilter = "py_code like '%" + sFilter + "%' or wb_code like '%" + sFilter + "%' or d_code like '%" + sFilter + "%'";
                try
                {
                    DataRow[] drs = this.tableDept.Select(sFilter);
                    if (drs.Length > 0)
                    {
                        for (int i = 0; i < drs.Length; i++)
                        {
                            Department dept = new Department();
                            dept.DeptId = Convert.ToInt32(drs[i]["ksbh"]);
                            dept.DeptName = drs[i]["name"].ToString().Trim();

                            ListViewItem item = new ListViewItem(dept.DeptName);
                            item.ImageIndex = 0;
                            item.Tag = dept;
                            this.lvwDept.Items.Add(item);
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                for (int i = 0; i < tableDept.Rows.Count; i++)
                {
                    Department dept = new Department();
                    dept.DeptId = Convert.ToInt32(tableDept.Rows[i]["ksbh"]);
                    dept.DeptName = tableDept.Rows[i]["name"].ToString().Trim();

                    ListViewItem item = new ListViewItem(dept.DeptName);
                    item.ImageIndex = 0;
                    item.Tag = dept;
                    this.lvwDept.Items.Add(item);
                }
            }
        }

        private void txtFilter_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lvwDept.Items.Count > 0)
            {
                lvwDept.Focus();
                lvwDept.Items[0].Selected = true;
            }
        }

        private void lvwDept_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lvwDept.Items.Count > 0)
                {
                    if (lvwDept.SelectedItems.Count != 0)
                    {
                        btnSelect_Click(null, null);
                    }
                }
            }
        }

        private void FrmSelectDept_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( this.ActiveControl.Name != txtFilter.Name && (int)e.KeyChar !=13 )
            {
                txtFilter.Focus();
                if ( (int)e.KeyChar == 8 )
                {
                    if ( txtFilter.Text.Trim() != "" )
                        txtFilter.Text = txtFilter.Text.Remove( txtFilter.Text.Length - 1 , 1 );
                }
                else
                {
                    txtFilter.Text = e.KeyChar.ToString();
                    
                }
                txtFilter.SelectionStart = txtFilter.Text.Length;
            }
        }
    }
}
