using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.GeneralControls
{
	
	/// <summary>
	/// ComboGridViewSearch 的摘要说明：网格查询区域
    /// jianqg 2012-10-6 emr&his框架整合  增加本类
	/// </summary>
	public class ComboGridViewSearch : System.Windows.Forms.UserControl
	{
		//自定义变量
		private DataGridView _mappingDataGrid;
		
		private System.Windows.Forms.Button btSearchAll;
		private System.Windows.Forms.Button btSearch;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.ComboBox cmbOperation;
		private System.Windows.Forms.ComboBox cmbField;
		private System.Windows.Forms.Button btMultiSearch;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 组合网格
		/// </summary>
		public ComboGridViewSearch()
		{
			_mappingDataGrid=null;
			
			InitializeComponent();
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
		#region 属性
		/// <summary>
		/// 与之相匹配的网格
		/// </summary>
		[DefaultValue(""),Description("与之相匹配的网格"),Category("Behavior")]
        public DataGridView MappingDataGrid
		{
			get
			{
				return _mappingDataGrid;
			}
			set
			{
				_mappingDataGrid=value;
				_mappingDataGrid.DataSourceChanged-=new EventHandler(_mappingDataGrid_DataSourceChanged);
				_mappingDataGrid.DataSourceChanged+=new EventHandler(_mappingDataGrid_DataSourceChanged);
				AddSearchFields();
			}
		}
		
		#endregion

		#region 方法
		/// <summary>
		/// 根据MappingDataGrid的TableStyles加载可供查询的项目
		/// 只支持DataSource为DataView
		/// </summary>
		private void AddSearchFields()
		{
			try
			{
				cmbField.Items.Clear();
				if(_mappingDataGrid!=null && _mappingDataGrid.DataSource!=null && (_mappingDataGrid.DataSource.GetType().IsSubclassOf(typeof(System.Data.DataView)) ||_mappingDataGrid.DataSource.GetType()==typeof(System.Data.DataView)))
				{
					Item item;
					DataView dv=(DataView)_mappingDataGrid.DataSource;
					for(int i=0;i<_mappingDataGrid.Columns.Count;i++)
					{
						if(_mappingDataGrid.Columns[i].Width>0)
						{
							item=new Item();
							item.Text =_mappingDataGrid.Columns[i].HeaderText;
							FIELDINFO fieldInfo;
							/*
							 * 加入判断，防止DataGridView自定义的列未包含在绑定的数据源的列中
							 * */
							object objCol = dv.Table.Columns[_mappingDataGrid.Columns[i].Name];
							if ( objCol != null )
							{
								fieldInfo.FieldName =_mappingDataGrid.Columns[i].Name;
								fieldInfo.FieldType =dv.Table.Columns[_mappingDataGrid.Columns[i].Name].DataType;
								item.Value =fieldInfo;
								cmbField.Items.Add(item);
							}
						}
					}
					if(cmbField.Items.Count>0)
					{
						cmbField.SelectedIndex =0;
					}
				}
			}
			catch(Exception err)
			{
				throw new Exception("AddSearchFields():" + err.Message);
			}
		}
		#endregion

		#region 重写事件
		/// <summary>
		/// 重写事件OnLoad，加载基础信息
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			Item item=null;
			//根据MappingDataGrid的TableStyles加载可供查询的项目
			AddSearchFields();

			#region 加载操作符
			cmbOperation.Items.Clear();
			item=new Item();
			item.Text ="包含";
			item.Value ="Like";
			cmbOperation.Items.Add(item);
			item=new Item();
			item.Text ="不包含";
			item.Value ="Not Like";
			cmbOperation.Items.Add(item);
			item=new Item();
			item.Text ="等于";
			item.Value ="=";
			cmbOperation.Items.Add(item);
			item=new Item();
			item.Text ="不等于";
			item.Value ="!=";
			cmbOperation.Items.Add(item);
			item=new Item();
			item.Text ="大于";
			item.Value =">";
			cmbOperation.Items.Add(item);
			item=new Item();
			item.Text ="小于";
			item.Value ="<";
			cmbOperation.Items.Add(item);
			item=new Item();
			item.Text ="大于等于";
			item.Value =">";
			cmbOperation.Items.Add(item);
			item=new Item();
			item.Text ="小于等于";
			item.Value ="<";
			cmbOperation.Items.Add(item);
			item=new Item();
			item.Text ="空";
			item.Value ="Null";
			cmbOperation.Items.Add(item);
			item=new Item();
			item.Text ="非空";
			item.Value ="Not Null";
			cmbOperation.Items.Add(item);
			cmbOperation.SelectedIndex=0;
			#endregion

			base.OnLoad (e);
		}
		#endregion

		#region 执行
		private void _mappingDataGrid_DataSourceChanged(object sender,EventArgs e)
		{
			AddSearchFields();
		}
		private void btSearch_Click(object sender, System.EventArgs e)
		{
			try
			{
				string filterValue=txtValue.Text.Trim();
				if(filterValue=="")
				{
					MessageBox.Show("条件为空，请输入条件！","错误");
					return;
				}
				if(_mappingDataGrid==null || _mappingDataGrid.DataSource==null)
				{
					return;
				}
				string filter="";
				Item item=null;
				if(cmbField.Items.Count>0)
				{
					item=(Item)cmbField.SelectedItem;
					FIELDINFO fieldInfo=(FIELDINFO)item.Value;
					filter+=fieldInfo.FieldName.ToString();
					item=(Item)cmbOperation.SelectedItem;
					if(fieldInfo.FieldType==typeof(System.String) || fieldInfo.FieldType==typeof(System.DateTime))
					{
						#region 字符串与日期类型
						switch(item.Value.ToString())
						{
							case "Like":
								filter+=" Like '%"+filterValue+"%'";
								break;
							case "Not Like":
								filter+="Not Like '%"+filterValue+"%'";
								break;
							case "=":
								filter+="='"+filterValue+"'";
								break;
							case "!=":
								filter+="<>'"+filterValue+"'";
								break;
							case ">":
								filter+=">'"+filterValue+"'";
								break;
							case "<":
								filter+="<'"+filterValue+"'";
								break;
							case ">=":
								filter+=">='"+filterValue+"'";
								break;
							case "<=":
								filter+="<='"+filterValue+"'";
								break;
							case "Null":
								filter+=" is null";
								break;
							case "Not Null":
								filter+=" is not null";
								break;
							default:
								filter="";
								MessageBox.Show("字段类型与操作符不相匹配！","错误");
								break;
						}
						#endregion
					}
					else
					{
						#region 数值类型
						switch(item.Value.ToString())
						{
							case "=":
								filter+="="+filterValue;
								break;
							case "!=":
								filter+="<>"+filterValue;
								break;
							case ">":
								filter+=">"+filterValue;
								break;
							case "<":
								filter+="<"+filterValue;
								break;
							case ">=":
								filter+=">="+filterValue;
								break;
							case "<=":
								filter+="<="+filterValue;
								break;
							case "Null":
								filter+=" is null";
								break;
							case "Not Null":
								filter+=" is not null";
								break;
							default:
								filter="";
								MessageBox.Show("字段类型与操作符不相匹配！","错误");
								break;
						}
						#endregion
					}
				}
				if(filter!="")
				{
					((DataView)_mappingDataGrid.DataSource).RowFilter =filter;
				}
			}
			catch(Exception err)
			{
                MessageBox.Show("TrasenClasses\\GeneralControls\\ComboGridViewSearch\\btSearch_Click():\n" + err.Message, "错误");
			}
		}

		private void btSearchAll_Click(object sender, System.EventArgs e)
		{
			if(_mappingDataGrid==null || _mappingDataGrid.DataSource==null)
			{
				return;
			}
			Cursor.Current =Cursors.WaitCursor;
			txtValue.Text ="";
			((DataView)_mappingDataGrid.DataSource).RowFilter ="";
			Cursor.Current=Cursors.Default;
		}
		private void btMultiSearch_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(_mappingDataGrid==null || _mappingDataGrid.DataSource==null)
				{
					return;
				}
				Item[] fieldItems=new Item[cmbField.Items.Count];
				Item[] operationItems=new Item[cmbOperation.Items.Count];
				cmbField.Items.CopyTo(fieldItems,0);
				cmbOperation.Items.CopyTo(operationItems,0);
				DlgGridSearch dlg=new DlgGridSearch(fieldItems,operationItems);
				dlg.ShowDialog();
				if(DlgGridSearch.DlgResult)
				{
					if(DlgGridSearch.FilterString!="")
					{
						((DataView)_mappingDataGrid.DataSource).RowFilter =DlgGridSearch.FilterString;
					}
					if(DlgGridSearch.SortString!="")
					{
						((DataView)_mappingDataGrid.DataSource).Sort =DlgGridSearch.SortString;
					}
				}
			}
			catch(Exception err)
			{
                MessageBox.Show("TrasenClasses\\GeneralControls\\ComboGridViewSearch\\btMultiSearch_Click():\n" + err.Message, "错误");
			}
		}
		private void txtValue_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyValue ==13)
			{
				if(txtValue.Text.Trim()=="")
				{
					btSearchAll_Click(null,null);
				}
				else
				{
					btSearch_Click(null,null);
				}
			}
		}
		#endregion 

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.btSearchAll = new System.Windows.Forms.Button();
			this.btSearch = new System.Windows.Forms.Button();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.cmbOperation = new System.Windows.Forms.ComboBox();
			this.cmbField = new System.Windows.Forms.ComboBox();
			this.btMultiSearch = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btSearchAll
			// 
			this.btSearchAll.Location = new System.Drawing.Point(328, 4);
			this.btSearchAll.Name = "btSearchAll";
			this.btSearchAll.Size = new System.Drawing.Size(42, 23);
			this.btSearchAll.TabIndex = 4;
			this.btSearchAll.Text = "全部";
			this.btSearchAll.Click += new System.EventHandler(this.btSearchAll_Click);
			// 
			// btSearch
			// 
			this.btSearch.Location = new System.Drawing.Point(284, 4);
			this.btSearch.Name = "btSearch";
			this.btSearch.Size = new System.Drawing.Size(42, 23);
			this.btSearch.TabIndex = 3;
			this.btSearch.Text = "查询";
			this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(168, 4);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(114, 21);
			this.txtValue.TabIndex = 0;
			this.txtValue.Text = "";
			this.txtValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyUp);
			// 
			// cmbOperation
			// 
			this.cmbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOperation.Location = new System.Drawing.Point(110, 4);
			this.cmbOperation.Name = "cmbOperation";
			this.cmbOperation.Size = new System.Drawing.Size(58, 20);
			this.cmbOperation.TabIndex = 2;
			// 
			// cmbField
			// 
			this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbField.Location = new System.Drawing.Point(4, 4);
			this.cmbField.Name = "cmbField";
			this.cmbField.Size = new System.Drawing.Size(106, 20);
			this.cmbField.TabIndex = 1;
			// 
			// btMultiSearch
			// 
			this.btMultiSearch.Location = new System.Drawing.Point(372, 4);
			this.btMultiSearch.Name = "btMultiSearch";
			this.btMultiSearch.Size = new System.Drawing.Size(68, 23);
			this.btMultiSearch.TabIndex = 8;
			this.btMultiSearch.Text = "混合查询";
			this.btMultiSearch.Click += new System.EventHandler(this.btMultiSearch_Click);
			// 
			// ComboGridViewSearch
			// 
			this.Controls.Add(this.btMultiSearch);
			this.Controls.Add(this.btSearchAll);
			this.Controls.Add(this.btSearch);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.cmbOperation);
			this.Controls.Add(this.cmbField);
			this.Name = "ComboGridViewSearch";
			this.Size = new System.Drawing.Size(444, 30);
			this.ResumeLayout(false);

		}
		#endregion

	}
}
