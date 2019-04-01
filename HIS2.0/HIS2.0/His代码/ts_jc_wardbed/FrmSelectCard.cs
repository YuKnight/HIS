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
	/// FrmSelectCard 的摘要说明。
	/// </summary>
	public class FrmSelectCard : System.Windows.Forms.Form
	{
		private enum SearchType{全部,拼音,五笔,代码,名称};
		private SearchType _searchType=SearchType.全部;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.TextBox txtFind;
		private System.Windows.Forms.Label lblInfo;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.DataGrid grdResult;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private DataTable tbData=new DataTable();
		private long selectId=0;
		private string selectCode="";
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private string selectName="";
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private ComboBox comboBox1;
        private Label lblMsg;
		private bool findResult=false;

		public long SelectID
		{
			get{return selectId;}
			set{selectId=value;}
		}
		public string SelectCode
		{
			get{return selectCode.Trim();}
			set{selectCode=value;}
		}
		public string SelectName
		{
			get{return selectName.Trim();}
			set{selectName=value;}
		}
		public bool FindResult
		{
			get{return findResult;}
			set{findResult=value;}
		}
			  
		/// <summary>
		/// 实例化窗体
		/// </summary>
		/// <param name="Sql">select语句须包含ID,NAME,PY_CODE,WB_CODE名或别名)</param>
		public FrmSelectCard(string Sql)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			
			tbData=InstanceForm.BDatabase.GetDataTable(Sql);
			tbData.TableName ="AA";
			
			grdResult.TableStyles[0].MappingName="AA";
			grdResult.DataSource =tbData;
			lblType.Text="查找方式:全部";
			_searchType=SearchType.全部;
			lblInfo.Text="符合条件的纪录："+tbData.Rows.Count+"条";

            lblMsg.Text = "请按 本病区 所在 楼层楼栋 选择正确的床位设置";

			for(int i=0;i<grdResult.TableStyles[0].GridColumnStyles.Count;i++)
			{
				DataGridTextBoxColumn col=(DataGridTextBoxColumn)(grdResult.TableStyles[0].GridColumnStyles[i]);
				col.TextBox.Parent.Controls.Remove(col.TextBox);
			}
           
		}
        public FrmSelectCard(string Sql,int a)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            if (a != 1) return;
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            comboBox1.Visible = false;
            comboBox1.Location = new Point(358, 6);
            comboBox1.Width = 336;
            tbData = InstanceForm.BDatabase.GetDataTable(Sql);
            tbData.TableName = "AA";

            grdResult.TableStyles[0].MappingName = "AA";
            grdResult.DataSource = tbData;
            lblType.Text = "查找方式:全部";
            _searchType = SearchType.全部;
            lblInfo.Text = "符合条件的纪录：" + tbData.Rows.Count + "条";

            for (int i = 0; i < grdResult.TableStyles[0].GridColumnStyles.Count; i++)
            {
                DataGridTextBoxColumn col = (DataGridTextBoxColumn)(grdResult.TableStyles[0].GridColumnStyles[i]);
                col.TextBox.Parent.Controls.Remove(col.TextBox);
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
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.grdResult = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblInfo = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(61, 5);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(187, 21);
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "查找字符";
            // 
            // lblType
            // 
            this.lblType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblType.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblType.Location = new System.Drawing.Point(254, 5);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(150, 20);
            this.lblType.TabIndex = 2;
            // 
            // grdResult
            // 
            this.grdResult.AllowSorting = false;
            this.grdResult.CaptionVisible = false;
            this.grdResult.DataMember = "";
            this.grdResult.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdResult.Location = new System.Drawing.Point(6, 29);
            this.grdResult.Name = "grdResult";
            this.grdResult.ReadOnly = true;
            this.grdResult.RowHeaderWidth = 20;
            this.grdResult.Size = new System.Drawing.Size(503, 168);
            this.grdResult.TabIndex = 3;
            this.grdResult.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.grdResult.DoubleClick += new System.EventHandler(this.grdResult_DoubleClick);
            this.grdResult.CurrentCellChanged += new System.EventHandler(this.grdResult_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridTableStyle1.DataGrid = this.grdResult;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn6});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeaderWidth = 20;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "编号";
            this.dataGridTextBoxColumn1.MappingName = "id";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "代码";
            this.dataGridTextBoxColumn5.MappingName = "code";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "名称";
            this.dataGridTextBoxColumn2.MappingName = "name";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "拼音码";
            this.dataGridTextBoxColumn3.MappingName = "py_code";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "五笔码";
            this.dataGridTextBoxColumn4.MappingName = "wb_code";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "价格";
            this.dataGridTextBoxColumn6.MappingName = "price";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // lblInfo
            // 
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Location = new System.Drawing.Point(11, 200);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(171, 21);
            this.lblInfo.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(410, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(98, 20);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblMsg
            // 
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMsg.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(188, 200);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(321, 21);
            this.lblMsg.TabIndex = 6;
            // 
            // FrmSelectCard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(513, 223);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmSelectCard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmSelectCard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSelectCard_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void FrmSelectCard_Load(object sender, System.EventArgs e)
		{
            DataTable dt = InstanceForm.BDatabase.GetDataTable("select jgbm,jgmc from jc_jgbm where yybm >0");
            comboBox1.DisplayMember = "jgmc";
            comboBox1.ValueMember = "jgbm";
            comboBox1.DataSource = dt;

		}

		private void txtFind_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				string sfilter=txtFind.Text;
				sfilter=sfilter.Replace("'","''");
				sfilter=sfilter.Replace("[","[[]");
				sfilter=sfilter.Replace("%","[%]");
				sfilter=sfilter.Replace("_","[_]");
				switch(_searchType)
				{
                    case SearchType.拼音:
                        //sfilter = "py_code like '" + sfilter + "%'";
                        sfilter = "py_code like '%" + sfilter + "%'";
						break;
					case SearchType.五笔:
						sfilter="wb_code like '"+sfilter +"%'";
						break;
					case SearchType.名称:
						sfilter="name like '%"+sfilter +"%'";
						break;
					case SearchType.代码:
						sfilter="code like '"+sfilter+"%'";
						break;
				}
                if (_searchType == SearchType.全部)
                {
                    //sfilter = "(py_code like '" + sfilter + "%' or wb_code like '" + sfilter + "%' or name like '%" + sfilter + "%' or code like '" + sfilter + "%')";
                    sfilter = "(py_code like '%" + sfilter + "%' or wb_code like '" + sfilter + "%' or name like '%" + sfilter + "%' or code like '" + sfilter + "%')";
                }
				DataTable tb=tbData.Clone();
				DataRow[] rows=tbData.Select(sfilter);
				for(int i=0;i<=rows.Length-1;i++)
				{
					tb.Rows.Add(rows[i].ItemArray);
				}
				grdResult.DataSource=tb;

				for(int i=0;i<grdResult.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridTextBoxColumn col=(DataGridTextBoxColumn)(grdResult.TableStyles[0].GridColumnStyles[i]);
					col.TextBox.Parent.Controls.Remove(col.TextBox);
				}

				lblInfo.Text="符合条件的纪录："+tb.Rows.Count+"条";
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void txtFind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			DataTable tb=(DataTable)grdResult.DataSource;

			switch(e.KeyCode)
			{
				case Keys.Enter:
					if(tb!=null && tb.Rows.Count!=0)
					{
						int curRow=grdResult.CurrentRowIndex;

						if(!Convert.IsDBNull(tb.Rows[curRow]["id"]))
							selectId=Convert.ToInt64(tb.Rows[curRow]["id"]);
						else
							selectId=0;
						
						if(!Convert.IsDBNull(tb.Rows[curRow]["code"]))
							selectCode=Convert.ToString(tb.Rows[curRow]["code"]);
						else
							selectCode="";
						
						if(!Convert.IsDBNull(tb.Rows[curRow]["name"]))
							selectName=Convert.ToString(tb.Rows[curRow]["name"]);
						else
							selectName="";
						findResult=true;
						this.Close();
					}
					break;
				case Keys.Up:
					if(grdResult.CurrentRowIndex==0) return;
					grdResult.UnSelect(grdResult.CurrentRowIndex);
					grdResult.CurrentRowIndex--;
					grdResult.Select(grdResult.CurrentRowIndex);
					break;
				case Keys.Down:
					if(grdResult.CurrentRowIndex==tb.Rows.Count-1) return;
					grdResult.UnSelect(grdResult.CurrentRowIndex);
					grdResult.CurrentRowIndex++;
					grdResult.Select(grdResult.CurrentRowIndex);
					break;
				case Keys.Escape:
					findResult=false;
					this.Close();
					break;
				case Keys.F12:
					if(_searchType==SearchType.拼音)
					{
						_searchType=SearchType.五笔;
						lblType.Text="查找方式:五笔";
					}
					else if(_searchType==SearchType.五笔)
					{
						_searchType=SearchType.代码;
						lblType.Text="查找方式:代码";
					}
					else if(_searchType==SearchType.代码)
					{
						_searchType=SearchType.名称;
						lblType.Text="查找方式:名称";
					}
					else if(_searchType==SearchType.名称)
					{
						_searchType=SearchType.全部;
						lblType.Text="查找方式:全部";
					}
					else
					{
						_searchType=SearchType.拼音;
						lblType.Text="查找方式:拼音";
					}
					txtFind_TextChanged(null,null);
					break;
			}
		}

		private void grdResult_DoubleClick(object sender, System.EventArgs e)
		{
			
			int curRow=grdResult.CurrentRowIndex;

			if(!Convert.IsDBNull(grdResult[curRow,0]))
				selectId=Convert.ToInt64(grdResult[curRow,0]);
			else
				selectId=0;
			
			if(!Convert.IsDBNull(grdResult[curRow,1]))
				selectCode=Convert.ToString(grdResult[curRow,1]);
			else
				selectCode="";
			
			if(!Convert.IsDBNull(grdResult[curRow,2]))
				selectName=Convert.ToString(grdResult[curRow,2]);
			else
				selectName="";
			findResult=true;
			this.Close();
			
		}

		private void grdResult_CurrentCellChanged(object sender, System.EventArgs e)
		{
			grdResult.Select(grdResult.CurrentRowIndex);
		}

		private void FrmSelectCard_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape) this.Close();
		}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)grdResult.DataSource;
            if (dt != null && dt.Rows.Count >= 0 )
            {
                DataView dv = dt.DefaultView;
                //MessageBox.Show("jgbm = " + comboBox1.SelectedValue.ToString() + "");
                dv.RowFilter = "jgbm = "+comboBox1.SelectedValue.ToString()+""; 
                
            }

        }
	}
}
