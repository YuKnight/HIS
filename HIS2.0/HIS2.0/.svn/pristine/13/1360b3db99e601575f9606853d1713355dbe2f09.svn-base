using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// DlgGridSearch 的摘要说明。
	/// </summary>
	public class DlgGridSearch : System.Windows.Forms.Form
	{
		//自定义变量
		/// <summary> 对话框结果</summary>
		public static bool DlgResult;
		/// <summary> 筛选字符串</summary>
		public static string FilterString;
		/// <summary> 排序字符串</summary>
		public static string SortString;
		//自动生成变量
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.ComboBox cmbOperation;
		private System.Windows.Forms.ComboBox cmbField;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListBox lstCondition;
		private System.Windows.Forms.Button btAdd;
		private System.Windows.Forms.Button btDel;
		private System.Windows.Forms.Button btDelAll;
		private System.Windows.Forms.Button btSure;
		private System.Windows.Forms.Button btClose;
		private System.Windows.Forms.ComboBox cmbLogic;
		private System.Windows.Forms.CheckBox chkSort;
		private System.Windows.Forms.ComboBox cmbSort;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="fieldItems">字段名称集合</param>
		/// <param name="operationItems">操作符集合</param>
		public DlgGridSearch(Item[] fieldItems,Item[] operationItems)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			DlgResult=false;
			FilterString="";
			SortString="";
			LoadInitData(fieldItems,operationItems);
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
			this.txtValue = new System.Windows.Forms.TextBox();
			this.cmbOperation = new System.Windows.Forms.ComboBox();
			this.cmbField = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbLogic = new System.Windows.Forms.ComboBox();
			this.chkSort = new System.Windows.Forms.CheckBox();
			this.cmbSort = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lstCondition = new System.Windows.Forms.ListBox();
			this.btAdd = new System.Windows.Forms.Button();
			this.btDel = new System.Windows.Forms.Button();
			this.btDelAll = new System.Windows.Forms.Button();
			this.btSure = new System.Windows.Forms.Button();
			this.btClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "字段名称";
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(171, 27);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(123, 21);
			this.txtValue.TabIndex = 3;
			this.txtValue.Text = "1";
			// 
			// cmbOperation
			// 
			this.cmbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOperation.Location = new System.Drawing.Point(111, 27);
			this.cmbOperation.Name = "cmbOperation";
			this.cmbOperation.Size = new System.Drawing.Size(58, 20);
			this.cmbOperation.TabIndex = 5;
			// 
			// cmbField
			// 
			this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbField.Location = new System.Drawing.Point(6, 27);
			this.cmbField.Name = "cmbField";
			this.cmbField.Size = new System.Drawing.Size(106, 20);
			this.cmbField.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(112, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "运算符";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(174, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 17);
			this.label3.TabIndex = 7;
			this.label3.Text = "字段名称";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(298, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 17);
			this.label4.TabIndex = 9;
			this.label4.Text = "连接逻辑";
			// 
			// cmbLogic
			// 
			this.cmbLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLogic.Location = new System.Drawing.Point(296, 27);
			this.cmbLogic.Name = "cmbLogic";
			this.cmbLogic.Size = new System.Drawing.Size(62, 20);
			this.cmbLogic.TabIndex = 8;
			// 
			// chkSort
			// 
			this.chkSort.Location = new System.Drawing.Point(362, 2);
			this.chkSort.Name = "chkSort";
			this.chkSort.Size = new System.Drawing.Size(84, 24);
			this.chkSort.TabIndex = 10;
			this.chkSort.Text = "参与排序";
			// 
			// cmbSort
			// 
			this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSort.Location = new System.Drawing.Point(360, 27);
			this.cmbSort.Name = "cmbSort";
			this.cmbSort.Size = new System.Drawing.Size(90, 20);
			this.cmbSort.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 17);
			this.label5.TabIndex = 12;
			this.label5.Text = "条件列表";
			// 
			// lstCondition
			// 
			this.lstCondition.ItemHeight = 12;
			this.lstCondition.Location = new System.Drawing.Point(6, 76);
			this.lstCondition.Name = "lstCondition";
			this.lstCondition.Size = new System.Drawing.Size(344, 232);
			this.lstCondition.TabIndex = 13;
			// 
			// btAdd
			// 
			this.btAdd.Location = new System.Drawing.Point(360, 80);
			this.btAdd.Name = "btAdd";
			this.btAdd.Size = new System.Drawing.Size(90, 26);
			this.btAdd.TabIndex = 14;
			this.btAdd.Text = "添加一个条件";
			this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
			// 
			// btDel
			// 
			this.btDel.Location = new System.Drawing.Point(360, 118);
			this.btDel.Name = "btDel";
			this.btDel.Size = new System.Drawing.Size(90, 26);
			this.btDel.TabIndex = 15;
			this.btDel.Text = "删除一个条件";
			this.btDel.Click += new System.EventHandler(this.btDel_Click);
			// 
			// btDelAll
			// 
			this.btDelAll.Location = new System.Drawing.Point(360, 156);
			this.btDelAll.Name = "btDelAll";
			this.btDelAll.Size = new System.Drawing.Size(90, 26);
			this.btDelAll.TabIndex = 16;
			this.btDelAll.Text = "删除全部条件";
			this.btDelAll.Click += new System.EventHandler(this.btDelAll_Click);
			// 
			// btSure
			// 
			this.btSure.Location = new System.Drawing.Point(360, 245);
			this.btSure.Name = "btSure";
			this.btSure.Size = new System.Drawing.Size(90, 26);
			this.btSure.TabIndex = 17;
			this.btSure.Text = "确定(&S)";
			this.btSure.Click += new System.EventHandler(this.btSure_Click);
			// 
			// btClose
			// 
			this.btClose.Location = new System.Drawing.Point(360, 283);
			this.btClose.Name = "btClose";
			this.btClose.Size = new System.Drawing.Size(90, 26);
			this.btClose.TabIndex = 18;
			this.btClose.Text = "关闭(&C)";
			this.btClose.Click += new System.EventHandler(this.btClose_Click);
			// 
			// DlgGridSearch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(456, 317);
			this.Controls.Add(this.btClose);
			this.Controls.Add(this.btSure);
			this.Controls.Add(this.btDelAll);
			this.Controls.Add(this.btDel);
			this.Controls.Add(this.btAdd);
			this.Controls.Add(this.lstCondition);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cmbSort);
			this.Controls.Add(this.chkSort);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmbLogic);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.cmbOperation);
			this.Controls.Add(this.cmbField);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgGridSearch";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "数据查找工具";
			this.ResumeLayout(false);

		}
		#endregion

		#region 加载初始数据
		private void LoadInitData(Item[] fieldItems,Item[] operationItems)
		{
			Item item=null;
			cmbField.Items.AddRange(fieldItems);
			if(fieldItems.Length>0)
			{
				cmbField.SelectedIndex =0;
			}
			cmbOperation.Items.AddRange(operationItems);
			if(operationItems.Length>0)
			{
				cmbOperation.SelectedIndex =0;
			}
			//连接逻辑
			item=new Item();
			item.Text ="并且";
			item.Value ="And";
			cmbLogic.Items.Add(item);
			item=new Item();
			item.Text ="或者";
			item.Value ="Or";
			cmbLogic.Items.Add(item);
			cmbLogic.SelectedIndex =0;
			//排序
			item=new Item();
			item.Text ="升序";
			item.Value ="Asc";
			cmbSort.Items.Add(item);
			item=new Item();
			item.Text ="降序";
			item.Value ="Desc";
			cmbSort.Items.Add(item);
			cmbSort.SelectedIndex =0;
		}
		#endregion

		#region 按钮事件
		private void btAdd_Click(object sender, System.EventArgs e)
		{
			string filterValue=txtValue.Text.Trim();
			if(filterValue=="")
			{
				MessageBox.Show("条件为空，请输入条件！","错误");
				return;
			}
			string filter="";
			Item item=null;
			if(cmbField.Items.Count>0)
			{
				item=(Item)cmbField.SelectedItem;
				FIELDINFO fieldInfo=(FIELDINFO)item.Value;
				filter+=fieldInfo.FieldName;
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
				item=new Item();
				string[] tag=new string[3];
				tag[0]=filter;
				tag[1]=((Item)cmbLogic.SelectedItem).Value.ToString();
				tag[2]="";
				string sort="";
				if(chkSort.Checked)
				{
					item=(Item)cmbField.SelectedItem;
					FIELDINFO fieldInfo=(FIELDINFO)item.Value;
					tag[2]=fieldInfo.FieldName+" "+((Item)cmbSort.SelectedItem).Value.ToString();
					if(((Item)cmbSort.SelectedItem).Value.ToString()=="Asc")
					{
						sort="↑";
					}
					else
					{
						sort="↓";
					}
				}
				item.Text =sort+cmbField.Text+" "+cmbOperation.Text+" "+filterValue+" "+cmbLogic.Text;
				item.Value =tag;
				lstCondition.Items.Add(item);
			}
		}

		private void btDel_Click(object sender, System.EventArgs e)
		{
			lstCondition.Items.Remove(lstCondition.SelectedItem);
		}

		private void btDelAll_Click(object sender, System.EventArgs e)
		{
			lstCondition.Items.Clear();
		}

		private void btSure_Click(object sender, System.EventArgs e)
		{
			if(lstCondition.Items.Count==0)
			{
				MessageBox.Show("条件为空，请输入条件！","错误");
				return;
			}
			string[] tag;
			for(int i=0;i<lstCondition.Items.Count;i++)
			{
				tag=(string[])((Item)lstCondition.Items[i]).Value;
				if(i!=lstCondition.Items.Count-1)
				{
					FilterString +=tag[0]+" "+tag[1]+" ";
					if(tag[2]!="")
					{
						SortString +=tag[2]+",";
					}
				}
				else
				{
					FilterString +=tag[0];
					if(tag[2]!="")
					{
						SortString +=tag[2];
					}
				}
			}
			DlgResult=true;
			this.Close();
		}

		private void btClose_Click(object sender, System.EventArgs e)
		{
			DlgResult=false;
			FilterString="";
			SortString="";
			this.Close();
		}
		#endregion
	}
}
