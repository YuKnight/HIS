using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ts_ss_class;

namespace Ts_ss_shbl
{
	/// <summary>
	/// Fbasesearch 的摘要说明。
	/// </summary>
    public class Fbasesearch : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		private System.Data.DataTable Tb=new System.Data.DataTable();
		private System.Data.DataView seldataview=new DataView();
		public string sName;
		public string Code;
		public string Search;
		public int TypeID;
		public string Select_SSql;
		public System.Windows.Forms.TextBox dd;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtdm;
		private myDataGrid.myDataGrid GrdSel;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.Button button1;
        private DataGridTextBoxColumn dataGridTextBoxColumn5;
		public Control control=new Control();
		public Fbasesearch()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.GrdSel.CurrentCellChanged+=new EventHandler(GrdSel_CurrentCellChanged);
			this.Select_SSql="";
			this.sName="";
			this.Code="";
			this.Tb.Reset();

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
			this.label1 = new System.Windows.Forms.Label();
			this.txtdm = new System.Windows.Forms.TextBox();
			this.GrdSel = new myDataGrid.myDataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.GrdSel)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label1.Location = new System.Drawing.Point(16, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 26;
			this.label1.Text = "输入查询代码";
			// 
			// txtdm
			// 
			this.txtdm.Location = new System.Drawing.Point(108, 12);
			this.txtdm.Name = "txtdm";
			this.txtdm.Size = new System.Drawing.Size(84, 21);
			this.txtdm.TabIndex = 0;
			this.txtdm.TextChanged += new System.EventHandler(this.txtdm_TextChanged);
			this.txtdm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdm_KeyDown);
			// 
			// GrdSel
			// 
			this.GrdSel.BackgroundColor = System.Drawing.Color.White;
			this.GrdSel.CaptionVisible = false;
			this.GrdSel.DataMember = "";
			this.GrdSel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.GrdSel.Location = new System.Drawing.Point(8, 40);
			this.GrdSel.Name = "GrdSel";
			this.GrdSel.ReadOnly = true;
			this.GrdSel.Size = new System.Drawing.Size(416, 296);
			this.GrdSel.TabIndex = 27;
			this.GrdSel.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
			this.GrdSel.myKeyDown += new myDataGrid.myDelegate(this.GrdSel_myKeyDown);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.GrdSel;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "编码";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 60;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "名称";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.ReadOnly = true;
			this.dataGridTextBoxColumn2.Width = 150;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "拼音码";
			this.dataGridTextBoxColumn3.NullText = "";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			this.dataGridTextBoxColumn3.Width = 60;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "五笔码";
			this.dataGridTextBoxColumn4.NullText = "";
			this.dataGridTextBoxColumn4.ReadOnly = true;
			this.dataGridTextBoxColumn4.Width = 60;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "登录号";
			this.dataGridTextBoxColumn5.Width = 60;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(304, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 28;
			this.button1.Text = "关闭";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Fbasesearch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(430, 339);
			this.ControlBox = false;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.GrdSel);
			this.Controls.Add(this.txtdm);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Location = new System.Drawing.Point(1500, 1500);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Fbasesearch";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "代码查询";
			this.Load += new System.EventHandler(this.Fbasesearch_Load);
			this.Activated += new System.EventHandler(this.Fbasesearch_Activated);
			((System.ComponentModel.ISupportInitialize)(this.GrdSel)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion



		private void Fbasesearch_Load(object sender, System.EventArgs e)
		{
			this.txtdm.Text=this.Search.ToString().Trim();
			this.txtdm.Select(this.txtdm.TextLength,0);
			this.Code ="0";
			this.sName="";
			
		}

		private void txtdm_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (txtdm.Text.ToString().Trim()!="")
				{
                    string ssql = "select code,name 名称,pym 拼音码,wbm 五笔码,RECORDID 工号 from vi_ss_vCALIBRATECODE where typeid=" + TypeID + " and ( upper(name) like '%" + txtdm.Text.ToString().Trim().ToUpper() + "%' or left(upper(wbm)," + txtdm.Text.Length + ")='" + txtdm.Text.ToString().Trim().ToUpper() + "' or left(upper(pym)," + txtdm.Text.Length + ")='" + txtdm.Text.ToString().Trim().ToUpper() + "')";
					Tb=PubFunction.ExecsqlTable(ssql) ;
					Tb.TableName="Tb";
//					GrdSel.TableStyles[0].MappingName=Tb.TableName   ;
//					GrdSel.SetDataBinding(Tb,null);
//					GrdSel.Refresh();

					this.dataGridTableStyle1.MappingName ="dataGridTableStyle1";
					this.GrdSel.TableStyles[0].MappingName="Tb";
					this.GrdSel.TableStyles[0].GridColumnStyles[0].MappingName=Tb.Columns["CODE"].ColumnName.Trim();
					this.GrdSel.TableStyles[0].GridColumnStyles[1].MappingName=Tb.Columns["名称"].ColumnName.Trim();
					this.GrdSel.TableStyles[0].GridColumnStyles[2].MappingName=Tb.Columns["拼音码"].ColumnName.Trim();
					this.GrdSel.TableStyles[0].GridColumnStyles[3].MappingName=Tb.Columns["五笔码"].ColumnName.Trim();
                    this.GrdSel.TableStyles[0].GridColumnStyles[4].MappingName = Tb.Columns["工号"].ColumnName.Trim();
					this.GrdSel.SetDataBinding(Tb,null);
					this.GrdSel.Refresh();

					if (Tb.Rows.Count>0)
					{
						this.GrdSel.CurrentRowIndex=0;
						this.GrdSel.Select(this.GrdSel.CurrentRowIndex);
					}
				}
			}
			catch
			{
			}
		}

		private void txtdm_KeyDown(object sender, KeyEventArgs e)
		{
			
			if (Convert.ToInt32(e.KeyCode)==40 && this.GrdSel.CurrentRowIndex<Tb.Rows.Count -1)
			{
				this.GrdSel.CurrentRowIndex+=1;
			}

			if (Convert.ToInt32(e.KeyCode)==38 && this.GrdSel.CurrentRowIndex<=Tb.Rows.Count && this.GrdSel.CurrentRowIndex>0)
			{
				
				this.GrdSel.CurrentRowIndex=this.GrdSel.CurrentRowIndex-1;
			}

			if (Convert.ToInt32(e.KeyCode)==13 && this.GrdSel.CurrentRowIndex>=0)
			{
				this.Code =Convert.ToString(Tb.Rows[GrdSel.CurrentCell.RowNumber]["code"].ToString());
				this.sName=Convert.ToString(Tb.Rows[GrdSel.CurrentCell.RowNumber]["名称"].ToString());
				textill();
				this.Close();
			}
			if (Convert.ToInt32(e.KeyCode)==27)
			{
				this.Code="0";
				if(TypeID==3) this.Code="";
				this.sName="";
				this.Close();
				textill();
			}
		}

		private void textill()
		{
			control.Tag=Convert.ToString(this.Code.Trim()) ;
			control.Text=sName.Trim();
		}

		private void GrdSel_CurrentCellChanged(object sender, EventArgs e)
		{
			if(Tb==null) return;
			if(Tb.Rows.Count <0) return;
			for(int i=0;i<Tb.Rows.Count-1;i++)
			{
				GrdSel.UnSelect(i);
			}
			if(this.GrdSel.CurrentRowIndex>=0)
				this.GrdSel.Select(this.GrdSel.CurrentRowIndex);
		}

		private void Fbasesearch_Activated(object sender, System.EventArgs e)
		{
		
		}

		private bool GrdSel_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{
			if (Convert.ToInt32(keyData)==13 && this.GrdSel.CurrentRowIndex>=0)
			{
				this.Code =Convert.ToString(Tb.Rows[GrdSel.CurrentCell.RowNumber]["code"].ToString());
				this.sName=Convert.ToString(Tb.Rows[GrdSel.CurrentCell.RowNumber]["名称"].ToString());
				textill();
				this.Close();
			}
			if (Convert.ToInt32(keyData)==27)
			{
				this.Code="0";
				this.sName="";
				this.Close();
				textill();
			}
			return true;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
