using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
using System.Runtime.InteropServices;
namespace ts_zyhs_ypxx
{
	/// <summary>
	/// Frmmxcx 的摘要说明。
	/// </summary>
	public class Frmmxcx : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Panel panel1;
        public StatusBar statusBar1;
		public System.Windows.Forms.Panel panel2;
		public System.Windows.Forms.Button butok;
		private System.Windows.Forms.Button butquit;
		public System.Windows.Forms.Button butall;
		public System.Windows.Forms.Button butuall;
        public bool Bselect;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        protected static extern short GetKeyState(int vKey);
        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        const byte CtrlMask = 8;
        protected const byte VK_LSHIFT = 0xA0;
        protected const byte VK_RSHIFT = 0xA1;
        private readonly int MOUSEEVENTF_LEFTDOWN = 0x2;
        private readonly int MOUSEEVENTF_LEFTUP = 0x4;
        int ShiftBeginIndex = -1;
        int ShiftEndIndex = -1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmmxcx()
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
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.butuall = new System.Windows.Forms.Button();
            this.butall = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butok = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butuall);
            this.panel1.Controls.Add(this.butall);
            this.panel1.Controls.Add(this.butquit);
            this.panel1.Controls.Add(this.butok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 48);
            this.panel1.TabIndex = 0;
            // 
            // butuall
            // 
            this.butuall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butuall.ForeColor = System.Drawing.Color.Navy;
            this.butuall.Location = new System.Drawing.Point(136, 8);
            this.butuall.Name = "butuall";
            this.butuall.Size = new System.Drawing.Size(96, 32);
            this.butuall.TabIndex = 3;
            this.butuall.Text = "全不选(&U)";
            this.butuall.Click += new System.EventHandler(this.butuall_Click);
            // 
            // butall
            // 
            this.butall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butall.ForeColor = System.Drawing.Color.Navy;
            this.butall.Location = new System.Drawing.Point(32, 8);
            this.butall.Name = "butall";
            this.butall.Size = new System.Drawing.Size(96, 32);
            this.butall.TabIndex = 2;
            this.butall.Text = "全选(S)";
            this.butall.Click += new System.EventHandler(this.butall_Click);
            // 
            // butquit
            // 
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point(696, 8);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(96, 32);
            this.butquit.TabIndex = 1;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butok
            // 
            this.butok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butok.ForeColor = System.Drawing.Color.Navy;
            this.butok.Location = new System.Drawing.Point(592, 8);
            this.butok.Name = "butok";
            this.butok.Size = new System.Drawing.Size(96, 32);
            this.butok.TabIndex = 0;
            this.butok.Text = "更新(&O)";
            this.butok.Click += new System.EventHandler(this.butok_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 429);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(848, 24);
            this.statusBar1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 381);
            this.panel2.TabIndex = 2;
            // 
            // Frmmxcx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(848, 453);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.panel1);
            this.Name = "Frmmxcx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择明细记录";
            this.Load += new System.EventHandler(this.Frmmxcx_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void butquit_Click(object sender, System.EventArgs e)
		{
			Bselect=false;
			this.Close();
		}

		private void butok_Click(object sender, System.EventArgs e)
		{
			Bselect=true;
			this.Close();
		}

		private void butall_Click(object sender, System.EventArgs e)
		{
			SelectAll(1);

		}

		private void SelectAll(short _value)
		{
			for(int i=0;i<=panel2.Controls.Count-1;i++)
			{
				if (panel2.Controls[i].GetType().ToString()=="TrasenClasses.GeneralControls.DataGridEx")
				{
					TrasenClasses.GeneralControls.DataGridEx mydatagrid=(TrasenClasses.GeneralControls.DataGridEx)panel2.Controls[i];
					DataTable mytb=(DataTable)mydatagrid.DataSource;
					for(int j=0;j<=mytb.Rows.Count-1;j++)
					{
						mytb.Rows[j]["选"]=(short)_value;
					}
				}

			}
		}
        /// <summary>
        /// add bu zouchihua 2012-3-09 点击某行时选中行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mydatagrid_Click(object sender, EventArgs e)
        {
            
        }

		private void butuall_Click(object sender, System.EventArgs e)
		{
			SelectAll(0);
		}

		private void Frmmxcx_Load(object sender, System.EventArgs e)
		{
			for(int i=0;i<=panel2.Controls.Count-1;i++)
			{
				if (panel2.Controls[i].GetType().ToString()=="TrasenClasses.GeneralControls.DataGridEx")
				{
					TrasenClasses.GeneralControls.DataGridEx  mydatagrid=(TrasenClasses.GeneralControls.DataGridEx)panel2.Controls[i];
                    mydatagrid.MouseClick -= new MouseEventHandler(mydatagrid_MouseClick); //add by zouchihua 2012-3-10
                    mydatagrid.MouseClick += new MouseEventHandler(mydatagrid_MouseClick); //add by zouchihua 2012-3-10
					//PublicStaticFun.ModifyDataGridStyle(mydatagrid,0);
                    PubStaticFun.ModifyDataGridStyle(mydatagrid, 0);
				}
			}
		}

        void mydatagrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (butall.Visible == false)
                return;
            for (int i = 0; i <= panel2.Controls.Count - 1; i++)
            {
                if (panel2.Controls[i].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                {
                    TrasenClasses.GeneralControls.DataGridEx mydatagrid = sender as TrasenClasses.GeneralControls.DataGridEx;
                    DataTable mytb = (DataTable)mydatagrid.DataSource;
                    int curIndex = mydatagrid.CurrentCell.RowNumber;

                    #region
                    bool shift = ((GetKeyState(VK_LSHIFT) & 0x80) != 0) ||
                                     ((GetKeyState(VK_RSHIFT) & 0x80) != 0);

                    if (shift)
                    {
                        if (ShiftBeginIndex == -1)
                        {
                            ShiftBeginIndex = curIndex;
                        }
                        else
                        {
                            ShiftEndIndex = curIndex;
                            for (int ii = 0; ii < mytb.Rows.Count; ii++)
                            {
                                if (ShiftBeginIndex > ShiftEndIndex)
                                {
                                    if (ii >= ShiftEndIndex && ii <= ShiftBeginIndex)
                                        mytb.Rows[ii]["选"] = (short)1;
                                }
                                else
                                {
                                    if (ii >= ShiftBeginIndex && ii <= ShiftEndIndex)
                                        mytb.Rows[ii]["选"] = (short)1;
                                }
                            }
                            ShiftBeginIndex = -1;
                            ShiftEndIndex = -1;
                        }

                        return;
                    }
                    else
                    {
                        ShiftBeginIndex = -1;
                        ShiftEndIndex = -1;
                    }
                    #endregion

                    for (int j = 0; j <= mytb.Rows.Count - 1; j++)
                    {
                        if (j == curIndex)
                        {
                            if (mytb.Rows[j]["选"].ToString() == "1")
                                mytb.Rows[j]["选"] = (short)0;
                            else
                                mytb.Rows[j]["选"] = (short)1;
                        }
                        try
                        {
                            decimal zsl = Convert.ToDecimal(Convertor.IsNull(mytb.Compute("sum(ypsl)", "选=true"), "0"));
                            statusBar1.Text = "药品总用量:" + zsl.ToString();
                            mydatagrid.DataSource = mytb;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message); 
                        }
                    }
                }

            }
        }

	}
}
