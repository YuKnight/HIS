using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using XcjwHIS.DatabaseAccessLayer;
using XcjwHIS.PubicBaseClasses;
using XcjwHIS.BussinessLogicLayer.Classes;
using System.Data.OleDb;
using XcMediHis.BaseFun ;
namespace Xc_yk_xtdz
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmxtdz : System.Windows.Forms.Form
	{
		private int _year;
		private int _month;
		private User _user;
		private Deptment _dept;
		private long _employeeID;
		private long _deptID;
		private string _functionName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblbz;
		private System.Windows.Forms.TextBox txtbz;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.ProgressBar pb;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.Button butok;
		private Form _mdiParent;
		private System.Windows.Forms.ComboBox cmbmonth;
		private System.Windows.Forms.ComboBox cmbyear;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmxtdz(long userID,long deptID,string functionName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_user =new User(userID);
			_dept=new Deptment(deptID);
			_employeeID=_user.EmployeeID;
			_deptID=_dept.DeptID;
			_functionName=functionName;
			_mdiParent=mdiParent;
			this.dtp1.Enabled=false;
			this.dtp2.Enabled=false;
			if (_functionName.Trim()=="Fxc_yk_ymjz")
			{
				this.lblbz.Visible=true;
				this.txtbz.Visible=true;
				this.label1.Text="																						"+ "系统在月结前会自动进行对帐操作,并将上次月结到当前日期内所产生的数据进行汇总结帐。 ";
			}

			if (_functionName.Trim()=="Fxc_yk_unymjz")
			{
				this.label1.Text="	   																				    "+ "注意:取消上次月结后您不能再对其数据进行恢复，在取消前请慎重考虑! ";
				this.Text="取消上次月结";
			}

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
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmbyear = new System.Windows.Forms.ComboBox();
			this.cmbmonth = new System.Windows.Forms.ComboBox();
			this.pb = new System.Windows.Forms.ProgressBar();
			this.butquit = new System.Windows.Forms.Button();
			this.butok = new System.Windows.Forms.Button();
			this.txtbz = new System.Windows.Forms.TextBox();
			this.lblbz = new System.Windows.Forms.Label();
			this.dtp2 = new System.Windows.Forms.DateTimePicker();
			this.dtp1 = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.LightYellow;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.label1.ForeColor = System.Drawing.Color.Navy;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(394, 72);
			this.label1.TabIndex = 0;
			this.label1.Text = @"                                                                                                                                               系统对帐 :                                                                                                                                                                                                                  此功能将对系统上次月结到当前的帐务进行检查，  当系统发现有数量或金额上误差时系统会弹出提示窗口以告之用户出现问题的原因，以及处理办法.";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.cmbyear);
			this.panel1.Controls.Add(this.cmbmonth);
			this.panel1.Controls.Add(this.pb);
			this.panel1.Controls.Add(this.butquit);
			this.panel1.Controls.Add(this.butok);
			this.panel1.Controls.Add(this.txtbz);
			this.panel1.Controls.Add(this.lblbz);
			this.panel1.Controls.Add(this.dtp2);
			this.panel1.Controls.Add(this.dtp1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 72);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(394, 159);
			this.panel1.TabIndex = 1;
			// 
			// cmbyear
			// 
			this.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbyear.Items.AddRange(new object[] {
														 "2005",
														 "2006",
														 "2007",
														 "2008",
														 "2009",
														 "2010",
														 "2011"});
			this.cmbyear.Location = new System.Drawing.Point(256, 77);
			this.cmbyear.Name = "cmbyear";
			this.cmbyear.Size = new System.Drawing.Size(56, 20);
			this.cmbyear.TabIndex = 11;
			this.cmbyear.Visible = false;
			this.cmbyear.SelectedIndexChanged += new System.EventHandler(this.cmbyear_SelectedIndexChanged);
			// 
			// cmbmonth
			// 
			this.cmbmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbmonth.Items.AddRange(new object[] {
														  "1",
														  "2",
														  "3",
														  "4",
														  "5",
														  "6",
														  "7",
														  "8",
														  "9",
														  "10",
														  "11",
														  "12"});
			this.cmbmonth.Location = new System.Drawing.Point(312, 77);
			this.cmbmonth.Name = "cmbmonth";
			this.cmbmonth.Size = new System.Drawing.Size(48, 20);
			this.cmbmonth.TabIndex = 10;
			this.cmbmonth.Visible = false;
			this.cmbmonth.SelectedIndexChanged += new System.EventHandler(this.cmbmonth_SelectedIndexChanged);
			// 
			// pb
			// 
			this.pb.Location = new System.Drawing.Point(256, 19);
			this.pb.Name = "pb";
			this.pb.Size = new System.Drawing.Size(96, 21);
			this.pb.TabIndex = 8;
			this.pb.Visible = false;
			// 
			// butquit
			// 
			this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butquit.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.butquit.Location = new System.Drawing.Point(256, 104);
			this.butquit.Name = "butquit";
			this.butquit.Size = new System.Drawing.Size(96, 32);
			this.butquit.TabIndex = 7;
			this.butquit.Text = "退出(&Q)";
			this.butquit.Click += new System.EventHandler(this.button2_Click);
			// 
			// butok
			// 
			this.butok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butok.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.butok.Location = new System.Drawing.Point(152, 104);
			this.butok.Name = "butok";
			this.butok.Size = new System.Drawing.Size(96, 32);
			this.butok.TabIndex = 6;
			this.butok.Text = "开始(&B)";
			this.butok.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtbz
			// 
			this.txtbz.Enabled = false;
			this.txtbz.Location = new System.Drawing.Point(120, 76);
			this.txtbz.Name = "txtbz";
			this.txtbz.Size = new System.Drawing.Size(128, 21);
			this.txtbz.TabIndex = 5;
			this.txtbz.Text = "";
			this.txtbz.Visible = false;
			// 
			// lblbz
			// 
			this.lblbz.Location = new System.Drawing.Point(44, 80);
			this.lblbz.Name = "lblbz";
			this.lblbz.Size = new System.Drawing.Size(80, 16);
			this.lblbz.TabIndex = 4;
			this.lblbz.Text = "月结区间名:";
			this.lblbz.Visible = false;
			// 
			// dtp2
			// 
			this.dtp2.Location = new System.Drawing.Point(120, 48);
			this.dtp2.Name = "dtp2";
			this.dtp2.Size = new System.Drawing.Size(128, 21);
			this.dtp2.TabIndex = 3;
			// 
			// dtp1
			// 
			this.dtp1.Location = new System.Drawing.Point(119, 19);
			this.dtp1.Name = "dtp1";
			this.dtp1.Size = new System.Drawing.Size(129, 21);
			this.dtp1.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(56, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "当前日期:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "上次月结日期:";
			// 
			// Frmxtdz
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(394, 231);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Frmxtdz";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "系统对帐";
			this.Load += new System.EventHandler(this.Frmxtdz_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>

		private void Frmxtdz_Load(object sender, System.EventArgs e)
		{
			dtp1.Value=XcDate.ServerDateTime ;
			dtp2.Value=XcDate.ServerDateTime ;
			string ssql="select * from yp_kjqj where deptid="+_deptID+" order by kjnf desc,kjyf desc";
			DataTable tb=DatabaseAccess.GetDataTable(DatabaseType.IbmDb2YP,ssql);
			if(tb.Rows.Count==0) 
			{
				ssql="select * from yp_yjks where deptid="+_dept.DeptID+" and qybz=1 ";
				DataTable tbks=DatabaseAccess.GetDataTable(DatabaseType.IbmDb2YP,ssql);
				if (tbks.Rows.Count==0) {MessageBox.Show("错误，科室可能没有启用");return;}

				dtp1.Value=Convert.ToDateTime(tbks.Rows[0]["qysj"]);
				dtp2.Value=XcDate.ServerDateTime;

				_year=XcDate.ServerDateTime.Year;
				_month=XcDate.ServerDateTime.Month;

				txtbz.Text=_year.ToString()+"年"+_month.ToString()+"月";

				if (_functionName.Trim()!="Fxc_yk_xtdz")
				{
					cmbyear.Visible=true;
					cmbmonth.Visible=true;
					cmbyear.Text=Convert.ToString(_year);
					cmbmonth.Text=Convert.ToString(_month);
				}
				return;
			}
			    dtp1.Value=Convert.ToDateTime(tb.Rows[0]["jsrq"]);
				dtp2.Value=XcDate.ServerDateTime ;
			if (tb.Rows[0]["kjyf"].ToString()=="12")
			{
				this._year=Convert.ToInt32(tb.Rows[0]["kjnf"])+1;
				this._month=1;
			}
			else
			{
				this._year=Convert.ToInt32(tb.Rows[0]["kjnf"]);
				this._month=Convert.ToInt32(tb.Rows[0]["kjyf"])+1;
			}
				txtbz.Text=_year.ToString()+"年"+_month.ToString()+"月";
		

			

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			#region 上传处方发药明细
			string stext=this.Text.Trim();
			//上传发药明细表的数据
			//this.Cursor =Cursors.WaitCursor;
			this.Text="正在上传处方发药明细.....";
			OleDbTransaction myTrans0;
			myTrans0 =DB.sConnect.BeginTransaction();
			try
			{
				int err_code=-1;
				string err_text="";
				System.Data.OleDb.OleDbCommand  mySelCmd=new System.Data.OleDb.OleDbCommand();
				mySelCmd.Connection=DB.sConnect;
				mySelCmd.Transaction=myTrans0;

				OleDbParameter parm;
				mySelCmd.Parameters.Add("@v_djrq",XcDate.ServerDateTime.ToShortDateString());
				mySelCmd.Parameters.Add("@V_DJSJ",XcDate.ServerDateTime.ToLongTimeString());
				mySelCmd.Parameters.Add("@V_DJY",_employeeID);
				mySelCmd.Parameters.Add("@v_deptid",_deptID);
				parm=mySelCmd.Parameters.Add("@err_code",OleDbType.Integer);
				parm.Direction=ParameterDirection.Output;
				parm=mySelCmd.Parameters.Add("@err_text",OleDbType.VarChar,250);
				parm.Direction=ParameterDirection.Output;
				mySelCmd.CommandText="SP_Yk_fymx_dj";
				mySelCmd.CommandType=System.Data.CommandType.StoredProcedure ;
				mySelCmd.ExecuteScalar();
				err_code=Convert.ToInt32(mySelCmd.Parameters["@err_code"].Value);
				err_text=Convert.ToString(mySelCmd.Parameters["@err_text"].Value);
				if (err_code!=0) throw new System.Exception(err_text);
				myTrans0.Commit();
				this.Text=stext;
			}
			catch(System.Exception err)
			{
				myTrans0.Rollback();
				MessageBox.Show("在上传发药明细时发生错误"+err.Message);
				return;
			}	

			#endregion

			#region 系统对账
			//系统对账
			this.Text="正在进行系统对账.....";
			try
			{
				ParameterEx[] parameters=new ParameterEx[2];
				parameters[0].Value=dtp1.Value.ToShortDateString();
				parameters[1].Value=_deptID;
				DataTable tb=DatabaseAccess.GetDataTable(DatabaseType.IbmDb2YP,"SP_Yk_XTDZ",parameters,30);
				tb.TableName="myTb"; 

				if (tb.Rows.Count>0)
				{
					this.Close();
					Frmxtdzmx f=new Frmxtdzmx(_employeeID,_deptID);
					f.MdiParent=_mdiParent;
					f.Show();
					f.FillData(tb);
					return;
				}

				if (_functionName.Trim()=="Fxc_yk_xtdz")
				{
					MessageBox.Show("系统对帐完成");
					this.Text=stext;
					this.Close();
					return;
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("出错"+err.Message );
				return;
			}
			
			#endregion

			#region 取消上次月结
			//取消上次月结
			if( _functionName.Trim()=="Fxc_yk_unymjz" && MessageBox.Show("您确定要取消上次月结吗 ？","询问窗",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
			{
				this.Text="正在取消上次月结.....";
				OleDbTransaction myTrans1;
				myTrans1 =DB.sConnect.BeginTransaction();
				try
				{
					int err_code=-1;
					string err_text="";
					System.Data.OleDb.OleDbCommand  mySelCmd=new System.Data.OleDb.OleDbCommand();
					mySelCmd.Connection=DB.sConnect;
					mySelCmd.Transaction=myTrans1;

					OleDbParameter parm;
					mySelCmd.Parameters.Add("@deptid",_deptID);
					mySelCmd.Parameters.Add("@djsj",XcDate.ServerDateTime);
					mySelCmd.Parameters.Add("@djy",_employeeID);
					parm=mySelCmd.Parameters.Add("@err_code",OleDbType.Integer);
					parm.Direction=ParameterDirection.Output;
					parm=mySelCmd.Parameters.Add("@err_text",OleDbType.VarChar,100);
					parm.Direction=ParameterDirection.Output;
					mySelCmd.CommandText="sp_Yk_unymjc";
					mySelCmd.CommandType=System.Data.CommandType.StoredProcedure ;
					mySelCmd.ExecuteScalar();
					err_code=Convert.ToInt32(mySelCmd.Parameters["@err_code"].Value);
					err_text=Convert.ToString(mySelCmd.Parameters["@err_text"].Value);
					if (err_code!=0) throw new System.Exception(err_text);
					myTrans1.Commit();
					this.Text=stext;
					MessageBox.Show(err_text);
					this.Close();
					return;

				}
				catch(System.Exception err)
				{
					myTrans1.Rollback();
					this.butok.Enabled=true;
					MessageBox.Show(err.Message);
			
				}
				
			}
			#endregion

			#region 月未结账

			if( _functionName.Trim()!="Fxc_yk_ymjz") return;
			//月未结帐
			this.Text="正在进行月未结帐.....";
			OleDbTransaction myTrans;
			myTrans =DB.sConnect.BeginTransaction();
			try
			{
				int err_code=-1;
				string err_text="";
				System.Data.OleDb.OleDbCommand  mySelCmd=new System.Data.OleDb.OleDbCommand();
				mySelCmd.Connection=DB.sConnect;
				mySelCmd.Transaction=myTrans;

				OleDbParameter parm;
				mySelCmd.Parameters.Add("@year",_year);
				mySelCmd.Parameters.Add("@month",_month);
				mySelCmd.Parameters.Add("@deptid",_deptID);
				mySelCmd.Parameters.Add("@ksrq",dtp1.Value.ToShortDateString());
				mySelCmd.Parameters.Add("@jsrq",dtp2.Value.ToShortDateString());
				mySelCmd.Parameters.Add("@djsj",XcDate.ServerDateTime);
				mySelCmd.Parameters.Add("@djy",_employeeID);
				parm=mySelCmd.Parameters.Add("@err_code",OleDbType.Integer);
				parm.Direction=ParameterDirection.Output;
				parm=mySelCmd.Parameters.Add("@err_text",OleDbType.VarChar,100);
				parm.Direction=ParameterDirection.Output;
				mySelCmd.CommandText="sp_Yk_ymjc";
				mySelCmd.CommandType=System.Data.CommandType.StoredProcedure ;
				mySelCmd.ExecuteScalar();
				err_code=Convert.ToInt32(mySelCmd.Parameters["@err_code"].Value);
				err_text=Convert.ToString(mySelCmd.Parameters["@err_text"].Value);
				if (err_code!=0) throw new System.Exception(err_text);
				myTrans.Commit();
				this.Text=stext;
				MessageBox.Show(err_text);
				this.Close();

			}
			catch(System.Exception err)
			{
				myTrans.Rollback();
				this.butok.Enabled=true;
				MessageBox.Show(err.Message);
			
			}
			#endregion


		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmbmonth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			_month=Convert.ToInt32(cmbmonth.Text);
			txtbz.Text=_year.ToString()+"年"+_month.ToString()+"月";
		}

		private void cmbyear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			_year=Convert.ToInt32(cmbyear.Text);
			txtbz.Text=_year.ToString()+"年"+_month.ToString()+"月";
		}
	}
}
