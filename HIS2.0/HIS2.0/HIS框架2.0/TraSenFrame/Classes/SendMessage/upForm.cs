using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Classes.SendMessage
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class upForm : System.Windows.Forms.Form
	{
		
		private bool openwindow=true;
		private DataTable dt=new DataTable();
		private System.Drawing.Icon tempIcon;
		/// <summary>
		/// 操作用户ID
		/// </summary>
		public long YS=0;
		/// <summary>
		/// 所属科室ID
		/// </summary>
		public long DeptID=0;
		/// <summary>
		/// 消息归属类型（0=所有模块 1= 2= 3=(系统模块ID)）
		/// </summary>
		public int mtype=0;
		/// <summary>
		/// 弹出窗体的显示间隔时间
		/// </summary>
		public int JGSJ=-1;
		/// <summary>
		/// IP地址
		/// </summary>
		public static string AddressIP=Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
		/// <summary>
		/// 所属病区
		/// </summary>
		public string WardID="";
		/// <summary>
		/// 是否弹出消息框
		/// </summary>
		public static bool IsUp=true;
		/// <summary>
		/// 是否可以显示有新消息
		/// </summary>
		public static bool IsOpen=false;
		/// <summary>
		/// 消息主题
		/// </summary>
		public static string title="";


		private System.Windows.Forms.Timer timer1;//控制图标闪烁
		private System.Windows.Forms.Timer timer2;//控制弹出窗口开始关闭
		private System.Timers.Timer timer3;//控制消息的显示
		private System.Windows.Forms.Timer timer4;//弹出窗口开、关动态控制
		private System.Windows.Forms.Timer timer5;//控制通知、消息的实时显示
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;	
		/// <summary>
		/// GroupBox控件
		/// </summary>
		public System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.LinkLabel linkLabel1;		
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		/// <summary>
		/// LinkLabel控件
		/// </summary>
		public System.Windows.Forms.LinkLabel Lk;
		
		
		private System.ComponentModel.IContainer components;
		
		/// <summary>
		/// upForm的摘要说明
		/// </summary>
		/// <param name="MessageStr">upForm的标题</param>
		/// <param name="deptID">科室ID</param>
		/// <param name="operate">操作员</param>
		/// <param name="type">消息类型（归属）（0=所有模块 1=  2=  3=  待定(使用模块ID)）</param>
		/// <param name="interval">弹出的间隔时间</param>
		/// <param name="icon">要闪烁的图标</param>
		/// <return></return>
		public upForm(string MessageStr,long deptID,long operate,int type,int interval,Icon icon)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			
			InitializeComponent();  
			
			this.groupBox1.Text=MessageStr.Trim();
			this.DeptID=deptID;
			this.YS=operate;
			this.mtype=type;	
			this.JGSJ=interval;
			this.Icon=icon;
		
			
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		/// <summary>
		/// upForm的摘要说明
		/// </summary>
		/// <param name="MessageStr">upForm的标题</param>
		/// <param name="wardID">病区ID</param>
		/// <param name="operate">操作员</param>
		/// <param name="type">消息类型（归属）（0=所有模块 1=  2=  3=  待定(使用模块ID)）</param>
		/// <param name="interval">弹出的间隔时间</param>
		public upForm(string MessageStr,string wardID,long operate,int type,int interval)
		{
			
			InitializeComponent();  
			
			this.groupBox1.Text=MessageStr.Trim();
			this.WardID=wardID;
			this.YS=operate;
			this.mtype=type;	
			this.JGSJ=interval;	
		}

		/// <summary>
		/// upForm的摘要说明
		/// </summary>
		public upForm()
		{
			InitializeComponent();
		}


		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(upForm));
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.Lk = new System.Windows.Forms.LinkLabel();
			this.timer4 = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.timer5 = new System.Windows.Forms.Timer(this.components);
			this.timer3 = new System.Timers.Timer();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.timer3)).BeginInit();
			this.SuspendLayout();
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "关闭(&X)";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Interval = 4000;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(208, 80);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Controls.Add(this.Lk);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 17);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(202, 60);
			this.panel1.TabIndex = 2;
			this.panel1.Click += new System.EventHandler(this.mClick);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(168, 45);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(29, 17);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "关闭";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// Lk
			// 
			this.Lk.Location = new System.Drawing.Point(9, 4);
			this.Lk.Name = "Lk";
			this.Lk.Size = new System.Drawing.Size(184, 32);
			this.Lk.TabIndex = 2;
			this.Lk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lk_LinkClicked);
			// 
			// timer4
			// 
			this.timer4.Interval = 30;
			this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenu = this.contextMenu1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "消息";
			this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDown);
			// 
			// timer5
			// 
			this.timer5.Enabled = true;
			this.timer5.Interval = 3000;
			this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
			// 
			// timer3
			// 
			this.timer3.Interval = 30000;
			this.timer3.SynchronizingObject = this;
			this.timer3.Elapsed += new System.Timers.ElapsedEventHandler(this.timer3_Elapsed);
			// 
			// upForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.LightGray;
			this.ClientSize = new System.Drawing.Size(208, 80);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "upForm";
			this.Opacity = 0.8;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "消息";
			this.TopMost = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Load += new System.EventHandler(this.upFrom_Load);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.timer3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

//		/// <summary>
//		/// 应用程序的主入口点。
//		/// </summary>
//		[STAThread]
//		static void Main() 
//		{
//			Application.Run(new upForm("消息",6,0,2,10000,new System.Drawing.Icon(System.Environment.CurrentDirectory+"\\123.ico")));
//		}
		
 		

		private void upFrom_Load(object sender, System.EventArgs e)
		{	
			tempIcon=this.notifyIcon1.Icon;
			this.Text=System.DateTime.Now.ToString();
			this.Height=0;
			this.Opacity=0;			
			if(JGSJ>0) this.timer3.Interval=JGSJ;
			this.WindowState=System.Windows.Forms.FormWindowState.Normal;
			this.notifyIcon1.Visible=false;
		}

		//闪烁图标
		private void timer1_Tick(object sender, System.EventArgs e)
		{			
			if(this.notifyIcon1.Icon==tempIcon) this.notifyIcon1.Icon=this.Icon;
			else this.notifyIcon1.Icon=tempIcon;
		}
		private void menuItem1_Click(object Sender, EventArgs e) 
		{
			IsOpen=false;
			this.notifyIcon1.Visible=false;
			this.timer1.Enabled=false;
		}
	
		//开始关闭窗口
		private void timer2_Tick(object sender, System.EventArgs e)
		{
			this.timer2.Enabled=false;
			this.openwindow=false;
			this.timer4.Enabled=true;			
		}

		//‘关闭’按钮事件
		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{		
			IsOpen=false;

			this.notifyIcon1.Visible=false;	
			this.timer1.Enabled=false;

			this.openwindow=false;
			this.timer4.Enabled=true;	
		}

		private void Lk_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			mClick(null,null);		
		}
		// 显示信息		
		private  void ShowXX()
		{			
			//是否有新消息
			if(SendMessageClass.NewMessage==true)
			{
				this.notifyIcon1.Visible=true;
				this.timer1.Enabled=true;
				
				Lk.Text=title;
				Lk.LinkBehavior=System.Windows.Forms.LinkBehavior.HoverUnderline;
				Lk.Top=15;
				Lk.Left=5;	

				this.Height=0;
				this.Top=System.Windows.Forms.Screen.AllScreens[0].Bounds.Height-28;
				this.Left=System.Windows.Forms.Screen.AllScreens[0].Bounds.Width-218;
				this.openwindow=true;
				this.Opacity=0.8;
				this.TopMost=true;
				this.TopLevel=true;
				this.timer4.Enabled=true;
				this.timer2.Enabled=true;	
			}
		}
		
		private void timer3_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if(!(IsOpen && SendMessageClass.AcceptMessage)) 
			{
				this.notifyIcon1.Visible=false;	
				this.timer1.Enabled=false;
				return;
			}				
			else 
			{	
				ShowXX();
			}		
		}
		//消息及通知的实时显示
		private void timer5_Tick(object sender, System.EventArgs e)
		{	
			if(SendMessageClass.AcceptMessage==true)
			{
				//新消息
				if(IsUp )
				{		
					ShowXX();
					IsUp=false;
					timer3.Enabled=true;
				}
				//新通知
				if(SendMessageClass.NewInFormation==true)
				{
					SendMessageClass.NewInFormation=false;;
					dt=upForm.selMessage(SendMessageType.通知,mtype,DeptID);
					if(dt!=null)
					{
						FrmInform fi=new FrmInform(title);
						fi.dt=dt;
						fi.ShowDialog();
					}
				}
			}
		
		}

		//窗口开、关动态控制
		private void timer4_Tick(object sender, System.EventArgs e)
		{
			if(openwindow==true)//开
			{
				if(this.Height<80) 
				{
					this.Height+=4;
					this.Top-=4;
				}
				else this.timer4.Enabled=false;				
			}
			else//关
			{
				if(this.Opacity>0) 
				{
					this.Opacity-=0.02;
				}
				else 
				{
					this.timer4.Enabled=false;
				}
			}
		}
		private DataTable selMessage(SendMessageType sType) 
		{			
			DataTable myTb=new DataTable();
			string sSql="";
			try
			{
				sSql="SELECT A.Title 主题, Content 内容,inform 通知内容 ,case flag when 0 then '未读' else '已读' end 状态 , A.ID,Bdate 发布时间, edate 结束时间 "+
					"FROM MZ_MESSAGE A INNER JOIN MZ_MESSAGE_DEPT B ON B.P_ID = A.ID AND mtype in (0,"+mtype.ToString()+") AND bdate<'" +DateTime.Now.ToString("yyyy-MM-dd")+ " 00:00:00' AND edate >'" +DateTime.Now.ToString("yyyy-MM-dd")+ " 23:59:59' ";
				switch(sType.ToString())
				{						
					case "消息":									
						if(this.WardID.Trim()=="")
						{							
							sSql+="WHERE XTYPE=0 and (B.dept_id = 0 OR B.dept_id = "+DeptID.ToString()+") order by Bdate";
						}
						else 
						{
							sSql+="WHERE XTYPE=0 and (B.dept_id = 0 OR B.dept_id in (select dept_id from base_wardrdept where ward_id='"+WardID.Trim()+"')) order by Bdate";
						}
						break;
					case "通知":
						if(this.WardID.Trim()=="")
						{
							sSql+="WHERE XTYPE=1 and (B.dept_id = 0 OR B.dept_id = "+DeptID.ToString()+") order by Bdate";
						}
						else 
						{
							sSql+="WHERE XTYPE=1 and (B.dept_id = 0 OR B.dept_id in (select dept_id from base_wardrdept where ward_id='"+WardID.Trim()+"')) order by Bdate";
						}
						break;
					default:
						sSql+="WHERE B.dept_id = 0 order by Bdate";	
						break;			
				}
				myTb=TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sSql);
				return myTb;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString(),"错误提示：",MessageBoxButtons.OK,MessageBoxIcon.Error);		
				return null;
			}
		}
		/// <summary>
		/// 获取消息列表
		/// </summary>
		/// <param name="sType">消息类型（通知、消息）</param>
		/// <param name="MessageType">消息的归属类型（0=所有模块 1= 2=  3= 系统模块ID）</param>
		/// <param name="deptID">消息归属的科室ID</param>
		/// <param name="ipAddress">消息归属的机器IP地址</param>
		/// <returns></returns>
		public static DataTable selMessage(SendMessageType sType,int MessageType,long deptID) 
		{
			DataTable myTb=new DataTable();
			string sSql="";
			try
			{
				sSql="SELECT A.Title 主题, Content 内容,inform 通知内容,case flag when 0 then '未读' else '已读' end 状态 , A.ID,Bdate 发布时间, edate 结束时间,A.tlsj "+
					"FROM MZ_MESSAGE A INNER JOIN MZ_MESSAGE_DEPT B ON B.P_ID = A.ID AND mtype in (0,"+MessageType.ToString()+") AND bdate< '" + DateTime.Now.ToString("yyyy-MM-dd") + "  00:00:00' AND edate > '" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59' ";
				switch(sType.ToString())
				{						
					case "消息":									
												
						sSql+="WHERE XTYPE=0 and (B.dept_id = 0 OR B.dept_id = "+deptID.ToString()+") and (B.ip_address='' OR B.ip_address='"+AddressIP+"') order by book_date";
						
						break;
					case "通知":
						
						sSql+="WHERE XTYPE=1 and (B.dept_id = 0 OR B.dept_id = "+deptID.ToString()+") and (B.ip_address='' OR B.ip_address='"+AddressIP+"') order by book_date";
						
						break;
					default:
						sSql+="WHERE B.dept_id = 0 order by book_date";	
						break;			
				}
				myTb=TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sSql);
				return myTb;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString(),"错误提示：",MessageBoxButtons.OK,MessageBoxIcon.Error);		
				return null;
			}
		}

		/// <summary>
		/// 获取消息列表
		/// </summary>
		/// <param name="xType">消息类型（1=通知、0=消息）</param>
		/// <returns></returns>
		public static DataTable selMessage(int xType) 
		{
			DataTable myTb=new DataTable();
			string sSql="";
			try
			{
				sSql="SELECT A.Title 主题, Content 内容,inform 通知内容,case flag when 0 then '未读' else '已读' end 状态 ,A.ID,Bdate 发布时间, edate 结束时间,A.tlsj "+ 
                     "FROM (select * from MZ_MESSAGE where xtype="+xType+" and bdate<'" +DateTime.Now.ToString("yyyy-MM-dd") + "' 00:00:00' AND edate >'" +DateTime.Now.ToString("yyyy-MM-dd")+ " 23:59:59') A "+ 
                     "     INNER JOIN "+
	                 "     MZ_MESSAGE_DEPT B ON B.P_ID = A.ID  "+
	                 "     INNER JOIN "+
                     "     (Select dtype,d_dept_id,d_user from MZ_IPINFORMATION where use_flag=1 and IP_ADDRESS='"+upForm.AddressIP+"') C on A.mtype in (0,C.dtype) ";
				myTb=TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sSql);
				return myTb;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString(),"错误提示：",MessageBoxButtons.OK,MessageBoxIcon.Error);		
				return null;
			}
		}
		/// <summary>
		/// 获取消息列表
		/// </summary>
		/// <param name="xType">消息类型（1=通知、0=消息）</param>
		/// <param name="level">消息级别（0=普通、1=系统）</param>
		/// <returns></returns>
		public static DataTable selMessage(int xType,short level) 
		{
			DataTable myTb=new DataTable();
			string sSql="";
			try
			{
				sSql="SELECT A.Title 主题, Content 内容,inform 通知内容,case flag when 0 then '未读' else '已读' end 状态 ,A.ID,Bdate 发布时间, edate 结束时间,A.tlsj "+ 
					"FROM (select * from MZ_MESSAGE where xtype="+xType+" and level="+level+" and bdate<'" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00' AND edate >'" +DateTime.Now.ToString("yyyy-MM-dd")+ " 23:59:59') A "+ 
					"     INNER JOIN "+
					"     MZ_MESSAGE_DEPT B ON B.P_ID = A.ID  "+
					"     INNER JOIN "+
					"     (Select dtype,d_dept_id,d_user from MZ_IPINFORMATION where use_flag=1 and IP_ADDRESS='"+upForm.AddressIP+"') C on A.mtype in (0,C.dtype) ";
				myTb=TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sSql);
				return myTb;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString(),"错误提示：",MessageBoxButtons.OK,MessageBoxIcon.Error);		
				return null;
			}
		}

		private void notifyIcon1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button==MouseButtons.Left) mClick(null,null);
			else return;
		}

		/// <summary>
		/// 打开消息查询窗口																																												
		/// </summary>
		private void mClick(object sender, System.EventArgs e)
		{
			SendMessageClass.NewMessage=false;
			dt=selMessage(SendMessageType.消息);
			if(dt!=null)
			{
				FrmMessage fm=new FrmMessage();
				fm.myTb=dt;
				fm.YS=YS;
				fm.Show();			
				fm.Activate();
			}
			this.notifyIcon1.Visible=false;	
			this.timer1.Enabled=false;

			this.timer2.Enabled=false;
			this.openwindow=false;
			this.timer4.Enabled=true; 
		}

		
//		/// <summary>
//		/// 显示upForm
//		/// </summary>	
//		/// <param name="MessageStr">upForm的标题</param>
//		/// <param name="wardID">病区ID</param>
//		/// <param name="operate">操作员</param>
//		/// <param name="type">消息类型（归属）</param>
//		/// <param name="interval">弹出的间隔时间</param>
//		/// <param name="formicon">闪烁的图标</param>
//		/// <returns></returns>	
//		public static void showupform(string MessageStr,string wardID,long operate,int type,int interval,System.Drawing.Icon formicon)
//		{
//			upForm uf=new upForm();
//			uf.groupBox1.Text=MessageStr.Trim();
//			uf.WardID=wardID;
//			uf.YS=operate;
//			uf.mtype=type;	
//			uf.JGSJ=interval;
//			if(formicon!=null) uf.Icon=formicon;
//			uf.Show();
//			
//		}

		
	}

}
