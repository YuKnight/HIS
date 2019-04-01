using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ts_zyys_public;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using Ts_ss_class;

namespace Ts_zyys_yzgl
{
	/// <summary>
	/// FrmStop 的摘要说明。
	/// </summary>
	public class FrmStop : System.Windows.Forms.Form
	{
		public User YS=null;
		public long YS_ID=0;
        public Guid BinID = Guid.Empty;
		public long BabyID=0;
		public long DeptID=0;
		public string mznr = "";
		public DataSet ds = new DataSet();
		private Control _curActiveTextBox;
		private DbQuery myQuery=new DbQuery();
		public bool flag=false;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        public TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton radBt2;
		private System.Windows.Forms.RadioButton radBt1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbStop;
		private System.Windows.Forms.NumericUpDown numUD;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        public TextBox textBox2;
        private Label label3;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmStop()
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
            this.btOK = new System.Windows.Forms.Button();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radBt2 = new System.Windows.Forms.RadioButton();
            this.radBt1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lbStop = new System.Windows.Forms.Label();
            this.numUD = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(112, 161);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(64, 23);
            this.btOK.TabIndex = 5;
            this.btOK.Text = "确定(&O)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 21);
            this.textBox1.TabIndex = 12;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(152, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "末日执行次数:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(16, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "麻醉方式：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radBt2
            // 
            this.radBt2.Checked = true;
            this.radBt2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBt2.Location = new System.Drawing.Point(264, 48);
            this.radBt2.Name = "radBt2";
            this.radBt2.Size = new System.Drawing.Size(64, 24);
            this.radBt2.TabIndex = 10;
            this.radBt2.TabStop = true;
            this.radBt2.Text = "修改值";
            // 
            // radBt1
            // 
            this.radBt1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBt1.Location = new System.Drawing.Point(264, 16);
            this.radBt1.Name = "radBt1";
            this.radBt1.Size = new System.Drawing.Size(64, 24);
            this.radBt1.TabIndex = 9;
            this.radBt1.Text = "默认值";
            this.radBt1.CheckedChanged += new System.EventHandler(this.radBt1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "确定停医嘱";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStop
            // 
            this.lbStop.BackColor = System.Drawing.SystemColors.Window;
            this.lbStop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbStop.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStop.Location = new System.Drawing.Point(104, 24);
            this.lbStop.Name = "lbStop";
            this.lbStop.Size = new System.Drawing.Size(22, 22);
            this.lbStop.TabIndex = 4;
            this.lbStop.Text = "√";
            this.lbStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbStop.Click += new System.EventHandler(this.lbStop_Click);
            // 
            // numUD
            // 
            this.numUD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numUD.Location = new System.Drawing.Point(336, 48);
            this.numUD.Name = "numUD";
            this.numUD.Size = new System.Drawing.Size(32, 23);
            this.numUD.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.radBt2);
            this.panel1.Controls.Add(this.radBt1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbStop);
            this.panel1.Controls.Add(this.numUD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 139);
            this.panel1.TabIndex = 204;
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(72, 145);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(328, 96);
            this.dataGrid1.TabIndex = 205;
            this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dataGrid1.Visible = false;
            this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGrid1_KeyUp);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "seltb";
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "序号";
            this.dataGridTextBoxColumn5.MappingName = "ROWNO";
            this.dataGridTextBoxColumn5.Width = 20;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "数字码";
            this.dataGridTextBoxColumn6.MappingName = "D_CODE";
            this.dataGridTextBoxColumn6.Width = 20;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "名称";
            this.dataGridTextBoxColumn7.MappingName = "NAME";
            this.dataGridTextBoxColumn7.Width = 75;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "拼音码";
            this.dataGridTextBoxColumn8.MappingName = "PY_CODE";
            this.dataGridTextBoxColumn8.Width = 75;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "五笔码";
            this.dataGridTextBoxColumn9.MappingName = "WB_CODE";
            this.dataGridTextBoxColumn9.Width = 75;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(96, 99);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(160, 21);
            this.textBox2.TabIndex = 14;
            this.textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "手术名称：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmStop
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(450, 248);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "停医嘱";
            this.Load += new System.EventHandler(this.FrmStop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void lbStop_Click(object sender, System.EventArgs e)
		{
			if(lbStop.Text.Trim()=="×") lbStop.Text="√";
			else lbStop.Text="×";
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			this.mznr = this.textBox1.Text.ToString().Trim();
            if (textBox2.Text.Trim() != "")
                this.mznr = this.mznr + "下行" + this.textBox2.Text.ToString();
			if(lbStop.Text=="√")
			{
                //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
                if (new SystemCfg(6023).Config == "0")
                {
                    string dlgvalue = DlgPW.Show();
                    string pwStr = dlgvalue; //YS.Password;
                    bool bOk = InstanceForm._currentUser.CheckPassword(pwStr);
                    if (!bOk)
                    {
                        FrmMessageBox.Show("你没有通过权限确认，不能发送医嘱！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
				int num=0;
				if(this.radBt1.Checked==true) num=-1;
				else num=Convert.ToInt16(this.numUD.Value);
				//停医嘱
				try
				{
					myQuery.StopOrders(FrmMdiMain.Database,DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString(),this.YS_ID ,this.BinID,this.BabyID,num);
					MessageBox.Show("停医嘱成功！");
				}
				catch(System.Exception err)
				{
					MessageBox.Show(""+err.ToString().Trim(),"错误：",MessageBoxButtons.OK,MessageBoxIcon.Error);					
					myQuery.SaveLog(this.DeptID,this.YS_ID,"停医嘱错误",this.Text.Trim()+"，病人："+this.BinID.ToString()+"，"+this.BabyID.ToString()+"，错误："+err.ToString(),1,41);
				}
			}
			flag=true;
			this.Close();
		}

		private void radBt1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radBt1.Checked==true) this.numUD.Enabled=false;
			else this.numUD.Enabled=true;
		}

		private void textBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if( this.dataGrid1.Focus() == false && e.KeyValue == 13 )
			{
				this.btOK.Focus();
				return;
			}
			textBox1_Enter(sender,e);
			textBox1_KeyDown(sender,e);
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
		}

        private void textBox2_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (this.dataGrid1.Focus() == false && e.KeyValue == 13)
            {
                this.btOK.Focus();
                return;
            }
            textBox2_Enter(sender, e);
            textBox1_KeyDown(sender, e);
            textBox2.Focus();
            textBox2.SelectionStart = textBox2.Text.Length;
        }

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			DataGrid grid=(DataGrid)sender;
			for(int i=0;i<((DataTable)grid.DataSource).Rows.Count;i++)
			{
				grid.UnSelect(i);
			}
			grid.Select(grid.CurrentCell.RowNumber);
		}

		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			if(_curActiveTextBox!=null)
			{
				_curActiveTextBox.Focus();
				textBox1_KeyDown(_curActiveTextBox, new KeyEventArgs(Keys.Enter));
			}
		}

		private void dataGrid1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				dataGrid1_DoubleClick(null,null);
			}	
		}

		private void textBox1_Enter(object sender, System.EventArgs e)
		{
			Control control=(Control)sender;
			_curActiveTextBox=control;

			int TypeID=0;
			TypeID = Convert.ToInt32(PubFunction.CodyType.Anesthesia);
			string sSql="select 0 ROWNO, name NAME,pym PY_CODE,wbm WB_CODE,code D_CODE from vi_ss_vCALIBRATECODE where typeid="+TypeID.ToString()+" ";
			DataTable myTb=FrmMdiMain.Database.GetDataTable(sSql);
			myTb.TableName="seltb";
			ds.Tables.Clear();
			ds.Tables.Add(myTb);
		}

        private void textBox2_Enter(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            _curActiveTextBox = control;

            int TypeID = 0;
            TypeID = Convert.ToInt32(PubFunction.CodyType.Operate);
            string sSql = "select 0 ROWNO, name NAME,pym PY_CODE,wbm WB_CODE,code D_CODE from vi_ss_vCALIBRATECODE where typeid=" + TypeID.ToString() + " ";
            DataTable myTb = FrmMdiMain.Database.GetDataTable(sSql);
            myTb.TableName = "seltb";
            ds.Tables.Clear();
            ds.Tables.Add(myTb);
        }

		private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				TextBox tb=(TextBox)sender;
				bool respondKey=true;
				DataRow dr=WorkStaticFun.GetCardData(tb,e.KeyValue,1,this.dataGrid1,0,ds,"seltb",FilterType.智能,SearchType.前导相似,ref respondKey,"","");
				if(dr!=null && respondKey)
				{
					tb.Text=dr["NAME"].ToString().Trim();
					tb.Tag=dr["D_CODE"];
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + ex.StackTrace.ToString());
			}
		}

		private void FrmStop_Load(object sender, System.EventArgs e)
		{
			this.textBox1.Focus();
		}
	}
}
