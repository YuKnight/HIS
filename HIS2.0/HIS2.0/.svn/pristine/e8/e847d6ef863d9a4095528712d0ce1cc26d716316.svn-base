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

namespace ts_yf_zyfy
{
	/// <summary>
	/// Frmmxcx 的摘要说明。
	/// </summary>
	public class Frmmxcx : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.StatusBar statusBar1;
		public System.Windows.Forms.Panel panel2;
		public System.Windows.Forms.Button butok;
		private System.Windows.Forms.Button butquit;
		public System.Windows.Forms.Button butall;
		public System.Windows.Forms.Button butuall;
        public bool Bselect;
        private Panel panel12;
        private RadioButton rdTempOrder;
        private RadioButton rdAllOrder;
        private RadioButton rdLongOrder;
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
            rdAllOrder.CheckedChanged += new EventHandler( checkOrderTypeChanged );
            rdLongOrder.CheckedChanged += new EventHandler( checkOrderTypeChanged );
            rdTempOrder.CheckedChanged += new EventHandler( checkOrderTypeChanged );
		}

        private void checkOrderTypeChanged( object sender , EventArgs e )
        {
            for ( int i = 0 ; i <= panel2.Controls.Count - 1 ; i++ )
            {
                if ( panel2.Controls[i].GetType().ToString() == "TrasenClasses.GeneralControls.ButtonDataGridEx" )
                {                    
                    TrasenClasses.GeneralControls.ButtonDataGridEx mydatagrid = (TrasenClasses.GeneralControls.ButtonDataGridEx)panel2.Controls[i];
                    DataTable mytb = (DataTable)mydatagrid.DataSource;
                    if ( rdAllOrder.Checked )
                    {
                        for ( int j = 0 ; j <= mytb.Rows.Count - 1 ; j++ )
                        {
                            mytb.Rows[j]["选择"] = (short)1;
                        }
                    }
                    else
                    {
                        for ( int j = 0 ; j <= mytb.Rows.Count - 1 ; j++ )
                            mytb.Rows[j]["选择"] = (short)0;
                        
                        DataRow[] rows = mytb.Select( string.Format( "医嘱类型='{0}'" , rdLongOrder.Checked ? "长期医嘱" : "临时医嘱" ) );
                        foreach(DataRow r in rows )
                            r["选择"] = (short)1;
                        
                    }
                }

            }
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
            this.panel12 = new System.Windows.Forms.Panel();
            this.rdTempOrder = new System.Windows.Forms.RadioButton();
            this.rdAllOrder = new System.Windows.Forms.RadioButton();
            this.rdLongOrder = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.panel12 );
            this.panel1.Controls.Add( this.butuall );
            this.panel1.Controls.Add( this.butall );
            this.panel1.Controls.Add( this.butquit );
            this.panel1.Controls.Add( this.butok );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 848 , 48 );
            this.panel1.TabIndex = 0;
            // 
            // butuall
            // 
            this.butuall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butuall.ForeColor = System.Drawing.Color.Navy;
            this.butuall.Location = new System.Drawing.Point( 136 , 8 );
            this.butuall.Name = "butuall";
            this.butuall.Size = new System.Drawing.Size( 96 , 32 );
            this.butuall.TabIndex = 3;
            this.butuall.Text = "全不选(&U)";
            this.butuall.Click += new System.EventHandler( this.butuall_Click );
            // 
            // butall
            // 
            this.butall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butall.ForeColor = System.Drawing.Color.Navy;
            this.butall.Location = new System.Drawing.Point( 32 , 8 );
            this.butall.Name = "butall";
            this.butall.Size = new System.Drawing.Size( 96 , 32 );
            this.butall.TabIndex = 2;
            this.butall.Text = "全选(S)";
            this.butall.Click += new System.EventHandler( this.butall_Click );
            // 
            // butquit
            // 
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point( 696 , 8 );
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size( 96 , 32 );
            this.butquit.TabIndex = 1;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler( this.butquit_Click );
            // 
            // butok
            // 
            this.butok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butok.ForeColor = System.Drawing.Color.Navy;
            this.butok.Location = new System.Drawing.Point( 592 , 8 );
            this.butok.Name = "butok";
            this.butok.Size = new System.Drawing.Size( 96 , 32 );
            this.butok.TabIndex = 0;
            this.butok.Text = "更新(&O)";
            this.butok.Click += new System.EventHandler( this.butok_Click );
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point( 0 , 429 );
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size( 848 , 24 );
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
            this.statusBar1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0 , 48 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 848 , 381 );
            this.panel2.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.Controls.Add( this.rdTempOrder );
            this.panel12.Controls.Add( this.rdAllOrder );
            this.panel12.Controls.Add( this.rdLongOrder );
            this.panel12.Location = new System.Drawing.Point( 251 , 12 );
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size( 217 , 25 );
            this.panel12.TabIndex = 14;
            // 
            // rdTempOrder
            // 
            this.rdTempOrder.AutoSize = true;
            this.rdTempOrder.Font = new System.Drawing.Font( "Tahoma" , 9.75F );
            this.rdTempOrder.Location = new System.Drawing.Point( 82 , 4 );
            this.rdTempOrder.Name = "rdTempOrder";
            this.rdTempOrder.Size = new System.Drawing.Size( 56 , 20 );
            this.rdTempOrder.TabIndex = 1;
            this.rdTempOrder.Text = "临嘱";
            this.rdTempOrder.UseVisualStyleBackColor = true;
            // 
            // rdAllOrder
            // 
            this.rdAllOrder.AutoSize = true;
            this.rdAllOrder.Font = new System.Drawing.Font( "Tahoma" , 9.75F );
            this.rdAllOrder.Location = new System.Drawing.Point( 158 , 4 );
            this.rdAllOrder.Name = "rdAllOrder";
            this.rdAllOrder.Size = new System.Drawing.Size( 56 , 20 );
            this.rdAllOrder.TabIndex = 2;
            this.rdAllOrder.Text = "全部";
            this.rdAllOrder.UseVisualStyleBackColor = true;
            // 
            // rdLongOrder
            // 
            this.rdLongOrder.AutoSize = true;
            this.rdLongOrder.Font = new System.Drawing.Font( "Tahoma" , 9.75F );
            this.rdLongOrder.Location = new System.Drawing.Point( 3 , 4 );
            this.rdLongOrder.Name = "rdLongOrder";
            this.rdLongOrder.Size = new System.Drawing.Size( 56 , 20 );
            this.rdLongOrder.TabIndex = 0;
            this.rdLongOrder.Text = "长嘱";
            this.rdLongOrder.UseVisualStyleBackColor = true;
            // 
            // Frmmxcx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 6 , 14 );
            this.ClientSize = new System.Drawing.Size( 848 , 453 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.statusBar1 );
            this.Controls.Add( this.panel1 );
            this.Name = "Frmmxcx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择明细记录";
            this.Load += new System.EventHandler( this.Frmmxcx_Load );
            this.panel1.ResumeLayout( false );
            this.panel12.ResumeLayout( false );
            this.panel12.PerformLayout();
            this.ResumeLayout( false );

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
				if (panel2.Controls[i].GetType().ToString()=="TrasenClasses.GeneralControls.ButtonDataGridEx")
				{
					//XcjwHIS.PublicControls.XcjwButtonDataGrid mydatagrid=(XcjwHIS.PublicControls.XcjwButtonDataGrid)panel2.Controls[i];
					TrasenClasses.GeneralControls.ButtonDataGridEx mydatagrid=(TrasenClasses.GeneralControls.ButtonDataGridEx)panel2.Controls[i];
					DataTable mytb=(DataTable)mydatagrid.DataSource;
					for(int j=0;j<=mytb.Rows.Count-1;j++)
					{
						mytb.Rows[j]["选择"]=(short)_value;
					}
				}

			}
		}

		private void butuall_Click(object sender, System.EventArgs e)
		{
			SelectAll(0);
		}

		private void Frmmxcx_Load(object sender, System.EventArgs e)
		{
			for(int i=0;i<=panel2.Controls.Count-1;i++)
			{
				if (panel2.Controls[i].GetType().ToString()=="TrasenClasses.GeneralControls.ButtonDataGridEx")
				{
					TrasenClasses.GeneralControls.ButtonDataGridEx  mydatagrid=(TrasenClasses.GeneralControls.ButtonDataGridEx)panel2.Controls[i];
					//PublicStaticFun.ModifyDataGridStyle(mydatagrid,0);
					PubStaticFun.ModifyDataGridStyle(mydatagrid,0);
				}
			}
		}

	}
}
