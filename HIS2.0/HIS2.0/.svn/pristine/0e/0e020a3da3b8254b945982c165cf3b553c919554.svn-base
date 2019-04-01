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

namespace ts_yf_tjbb
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmysyytj : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Button buttj;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.GroupBox groupBox2;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.RadioButton rdo1;
		private System.Windows.Forms.RadioButton rdo2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblypmc;
		private System.Windows.Forms.TextBox txtypmc;
		private System.Windows.Forms.DataGridTextBoxColumn 厂家;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn 科室;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmysyytj(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtypmc = new System.Windows.Forms.TextBox();
            this.lblypmc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.厂家 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.科室 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtypmc);
            this.groupBox1.Controls.Add(this.lblypmc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdo2);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.buttj);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.rdo1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // txtypmc
            // 
            this.txtypmc.Location = new System.Drawing.Point(442, 29);
            this.txtypmc.Name = "txtypmc";
            this.txtypmc.Size = new System.Drawing.Size(162, 21);
            this.txtypmc.TabIndex = 16;
            this.txtypmc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // lblypmc
            // 
            this.lblypmc.Location = new System.Drawing.Point(384, 34);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(64, 17);
            this.lblypmc.TabIndex = 15;
            this.lblypmc.Text = "药品名称";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(101, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "从";
            // 
            // rdo2
            // 
            this.rdo2.Location = new System.Drawing.Point(16, 42);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(88, 24);
            this.rdo2.TabIndex = 13;
            this.rdo2.Text = "住院病人";
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo1_CheckedChanged);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(754, 26);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(64, 32);
            this.butquit.TabIndex = 11;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(690, 26);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(64, 32);
            this.butprint.TabIndex = 10;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // buttj
            // 
            this.buttj.Location = new System.Drawing.Point(626, 26);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(64, 32);
            this.buttj.TabIndex = 9;
            this.buttj.Text = "统计(&T)";
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(253, 31);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(112, 21);
            this.dtp2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(236, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(125, 31);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(110, 21);
            this.dtp1.TabIndex = 3;
            // 
            // rdo1
            // 
            this.rdo1.Checked = true;
            this.rdo1.Location = new System.Drawing.Point(16, 20);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(96, 24);
            this.rdo1.TabIndex = 12;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "门诊病人";
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo1_CheckedChanged);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 502);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(944, 23);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 150;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 1000;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(944, 422);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计情况";
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(938, 402);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.myDataGrid1_Navigate);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.厂家,
            this.dataGridTextBoxColumn16,
            this.科室,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "序号";
            this.dataGridTextBoxColumn4.Width = 30;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "品名";
            this.dataGridTextBoxColumn9.Width = 150;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "商品名";
            this.dataGridTextBoxColumn10.Width = 150;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "规格";
            this.dataGridTextBoxColumn11.Width = 75;
            // 
            // 厂家
            // 
            this.厂家.Format = "";
            this.厂家.FormatInfo = null;
            this.厂家.HeaderText = "厂家";
            this.厂家.Width = 0;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "单价";
            this.dataGridTextBoxColumn16.Width = 65;
            // 
            // 科室
            // 
            this.科室.Format = "";
            this.科室.FormatInfo = null;
            this.科室.HeaderText = "科室";
            this.科室.Width = 75;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "医生";
            this.dataGridTextBoxColumn17.Width = 80;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "数量";
            this.dataGridTextBoxColumn1.Width = 60;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "单位";
            this.dataGridTextBoxColumn2.Width = 40;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "金额";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // Frmysyytj
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmysyytj";
            this.Text = "医生用药情况统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmxspm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>


		private void Frmxspm_Load(object sender, System.EventArgs e)
		{
			try
			{
				dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
				dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
				//初始化
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");

				

			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}


		}

		private void buttj_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				this.buttj.Enabled=false;
				ParameterEx[] parameters=new ParameterEx[4];
				parameters[0].Value=this.rdo1.Checked==true?0:1;
				parameters[1].Value=Convert.ToInt32(Convertor.IsNull(this.txtypmc.Tag,"0"));
				parameters[2].Value=dtp1.Value.ToShortDateString();
				parameters[3].Value=dtp2.Value.ToShortDateString();
				



				parameters[0].Text="@type";
				parameters[1].Text="@cjid";
				parameters[2].Text="@dtp1";
				parameters[3].Text="@dtp2";


				DataTable tb=InstanceForm.BDatabase.GetDataTable("SP_Yf_tj_ysyytj",parameters,30);
				FunBase.AddRowtNo(tb);
				tb.TableName="Tb";

                DataView dv = new DataView();
                dv.Table = tb;

				this.myDataGrid1.DataSource=dv;
				this.buttj.Enabled=true;

                this.statusBarPanel1.Text = "数量合计:"+tb.Compute("sum(数量)","").ToString();
                this.statusBarPanel2.Text = "金额合计:" + tb.Compute("sum(金额)", "").ToString();
			}
			catch(System.Exception err)
			{
				this.buttj.Enabled=true;
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string title="";
				string where1="";
				if (rdo1.Checked==true)
				 title="门诊医生用药情况统计";
				else
				 title="住院医生用药情况统计";

				where1="日期:"+dtp1.Value.ToShortDateString();
				where1=where1+" 到:"+dtp2.Value.ToShortDateString();


                DataView dv = (DataView)this.myDataGrid1.DataSource;
				//DataTable tb=(DataTable)this.myDataGrid1.DataSource;
                DataTable tb = dv.Table;
				ts_Yk_ReportView.Dataset1 Dset=new ts_Yk_ReportView.Dataset1();

                

				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.医生用药情况统计.NewRow();
					myrow["ypmc"]=Convert.ToString(tb.Rows[i]["品名"]);
					myrow["ypspm"]=Convert.ToString(tb.Rows[i]["商品名"]);
					myrow["ypgg"]=Convert.ToString(tb.Rows[i]["规格"]);
					myrow["sccj"]=Convert.ToString(tb.Rows[i]["厂家"]);
					myrow["lsj"]=Convert.ToDecimal(tb.Rows[i]["单价"]);
					myrow["ksmc"]=Convert.ToString(tb.Rows[i]["科室"]);
					myrow["ysmc"]=Convert.ToString(tb.Rows[i]["医生"]);
					myrow["ypsl"]=Convert.ToDecimal(tb.Rows[i]["数量"]);
					myrow["ypdw"]=Convert.ToString(tb.Rows[i]["单位"]);
					myrow["lsje"]=Convert.ToDecimal(tb.Rows[i]["金额"]);
					myrow["xh"]=Convert.ToInt32(tb.Rows[i]["序号"]);
					Dset.医生用药情况统计.Rows.Add(myrow);

				}

				ParameterEx[] parameters=new ParameterEx[2];
				parameters[0].Text="swhere";
				parameters[0].Value=where1.Trim();
				parameters[1].Text="title";
				parameters[1].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+title.Trim();
				
				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.医生用药情况统计,Constant.ApplicationDirectory+"\\Report\\YF_医生用药情况统计.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();
	
				
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void rdo1_CheckedChanged(object sender, System.EventArgs e)
		{
            DataView dv = (DataView)this.myDataGrid1.DataSource;

            dv.Table.Clear();
			//tb.Rows.Clear();

			if (rdo1.Checked==true)
				this.科室.Width=0;
			else
				this.科室.Width=80;
		}


		//输入框控制事件
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;

			if (control.Text.Trim()=="" )
			{
				control.Text="";
				control.Tag="0";
			}

			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)=="")))
			{
				
			}
			else
			{
				return;
			}

			string[] GrdMappingName;
			int[] GrdWidth;
			string[]sfield;
			string ssql="";
			DataRow row;
				
			Point point=new Point(this.Location.X+control.Location.X,this.Location.Y+control.Location.Y+control.Height*3 );
			switch(control.TabIndex)
			{
				case 16:
					if (control.Text.Trim()=="") return;
					GrdMappingName=new string[] {"ggid","cjid","行号","品名","规格","厂家","单位","DWBL","批发价","零售价","货号"};
					GrdWidth=new int[] {0,0,50,200,100,100,40,0,60,60,70};
					sfield=new string[] {"wbm","pym","szm","ywm","ypbm"};
                    ssql = "select distinct a.ggid,cjid,0  rowno,s_ypspm,s_ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from yp_ypcjd a,yp_ypbm b where a.ggid=b.ggid  ";
					TrasenFrame.Forms.Fshowcard f2=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,Constant.CustomFilterType,control.Text.Trim(),ssql);
					f2.Location=point;
					f2.ShowDialog(this);
					row=f2.dataRow;
					if (row!=null) 
					{
						this.txtypmc.Text=row["s_ypspm"].ToString();
						this.txtypmc.Tag=row["cjid"].ToString();
						this.txtypmc.Focus();
					}
					break;

			}

		}

		private void myDataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}



	}
}
