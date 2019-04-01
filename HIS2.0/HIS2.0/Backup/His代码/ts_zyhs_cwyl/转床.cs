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
using ts_zyhs_classes;

namespace ts_zyhs_cwyl
{
	/// <summary>
	/// 转床 的摘要说明。
	/// </summary>
	public class frmZC : System.Windows.Forms.Form
	{
		private BaseFunc myFunc;
		string old_bed_no,new_bed_no,old_bed_sex;
		long old_dept_id,new_dept_id;
        Guid old_bed_id, new_bed_id;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblOldBedNo;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.ComboBox cmbNewRoom;
		private System.Windows.Forms.ComboBox cmbNewBed;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btOK;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmZC()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//

			myFunc=new BaseFunc();
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
            this.lblOldBedNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbNewRoom = new System.Windows.Forms.ComboBox();
            this.cmbNewBed = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btExit = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(30, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "将";
            // 
            // lblOldBedNo
            // 
            this.lblOldBedNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOldBedNo.ForeColor = System.Drawing.Color.Blue;
            this.lblOldBedNo.Location = new System.Drawing.Point(56, 16);
            this.lblOldBedNo.Name = "lblOldBedNo";
            this.lblOldBedNo.Size = new System.Drawing.Size(80, 16);
            this.lblOldBedNo.TabIndex = 1;
            this.lblOldBedNo.Text = "XX";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(136, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "床";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.Blue;
            this.lblName.Location = new System.Drawing.Point(160, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(120, 16);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "病人姓名";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(16, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "转到";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(136, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "房";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(264, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "床";
            // 
            // cmbNewRoom
            // 
            this.cmbNewRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewRoom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbNewRoom.ForeColor = System.Drawing.Color.Blue;
            this.cmbNewRoom.Location = new System.Drawing.Point(48, 44);
            this.cmbNewRoom.Name = "cmbNewRoom";
            this.cmbNewRoom.Size = new System.Drawing.Size(88, 22);
            this.cmbNewRoom.TabIndex = 7;
            this.cmbNewRoom.SelectedIndexChanged += new System.EventHandler(this.cmbNewRoom_SelectedIndexChanged);
            // 
            // cmbNewBed
            // 
            this.cmbNewBed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewBed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbNewBed.ForeColor = System.Drawing.Color.Blue;
            this.cmbNewBed.Location = new System.Drawing.Point(152, 44);
            this.cmbNewBed.Name = "cmbNewBed";
            this.cmbNewBed.Size = new System.Drawing.Size(112, 22);
            this.cmbNewBed.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 8);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // btExit
            // 
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Location = new System.Drawing.Point(160, 96);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(64, 24);
            this.btExit.TabIndex = 16;
            this.btExit.Text = "退出(&E)";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(64, 96);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(64, 24);
            this.btOK.TabIndex = 15;
            this.btOK.Text = "确认(&O)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // frmZC
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(288, 133);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbNewBed);
            this.Controls.Add(this.cmbNewRoom);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOldBedNo);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(296, 160);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(296, 160);
            this.Name = "frmZC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "转床";
            this.Load += new System.EventHandler(this.frmZC_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmZC_Load(object sender, System.EventArgs e)
		{
			string sSql="";

			sSql=@"select a.bed_id,a.bed_no,a.ISBF,a.ROOM_NO,a.INPATIENT_dept,a.bedsex,b.name from zy_BedDiction a "+
				" inner join vi_zy_vInpatient_Bed b on a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id "+
				" where a.isinuse=0 and a.ward_id='"+ InstanceForm.BCurrentDept.WardId + "'" +
				"   and a.inpatient_id='"+ClassStatic.Current_BinID+"' and a.baby_id="+ClassStatic.Current_BabyID;
			DataTable bedTb=InstanceForm.BDatabase.GetDataTable(sSql);
			
			if(bedTb==null || bedTb.Rows.Count<1)
			{
				MessageBox.Show(this,"对不起，没有找到该病人的床位信息，请重新选择！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error); 
				this.Close();
				return;
			}

			if (Convert.ToInt16(bedTb.Rows[0]["isbf"])==1)
			{
				MessageBox.Show(this, "对不起，病人有包床，不允许转床！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);
				this.Close();		
				return;
			}

			lblOldBedNo.Text=bedTb.Rows[0]["bed_no"].ToString().Trim();
			lblName.Text=bedTb.Rows[0]["name"].ToString().Trim();

			old_bed_no=bedTb.Rows[0]["bed_no"].ToString().Trim();
			old_bed_id=new Guid(bedTb.Rows[0]["bed_id"].ToString());
			old_dept_id=Convert.ToInt64(bedTb.Rows[0]["inpatient_dept"]);
			old_bed_sex=bedTb.Rows[0]["bedsex"].ToString().Trim();

			LoadRoomNo();

			for(int i=0;i<cmbNewRoom.Items.Count;i++)
			{
				if(bedTb.Rows[0]["ROOM_NO"].ToString().Trim()==cmbNewRoom.Items[i].ToString().Trim())
				{
					cmbNewRoom.SelectedIndex=i;
				}
			}
		}

		private void LoadRoomNo()
		{
			string sSql="";
			DataTable roomTb=new DataTable();

            sSql = "select distinct room_no from zy_beddiction where isinuse=0 and ward_id='" + InstanceForm.BCurrentDept.WardId + "' order by room_no";
			roomTb=InstanceForm.BDatabase.GetDataTable(sSql);

			if(roomTb==null || roomTb.Rows.Count<1)
			{
				MessageBox.Show(this,"对不起，没有找到该病区的房间信息，请重新选择！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error); 
				this.Close();
				return;
			}

			cmbNewRoom.Items.Clear();
			
			cmbNewRoom.Items.Add("全部");
			for(int i=0;i<roomTb.Rows.Count;i++)
			{
				cmbNewRoom.Items.Add(roomTb.Rows[i]["room_no"].ToString().Trim());
			}
		}

		private void cmbNewRoom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sSql="";
			DataTable bedTb=new DataTable();
			string sTj="";

			cmbNewBed.DataSource=null;

			if(cmbNewRoom.Text=="全部")
			{
				sTj="";
			}
			else
			{
				sTj=" and room_no='"+ cmbNewRoom.Text + "'";
			}

			sSql="select BED_NO,BED_ID from zy_beddiction where isinuse=0 and inpatient_id is null and isbf=0 "+
				" and ward_id='"+ InstanceForm.BCurrentDept.WardId + "'"+sTj+" order by room_no,bed_no";
			bedTb=InstanceForm.BDatabase.GetDataTable(sSql);

			if(bedTb != null && bedTb.Rows.Count>0)
			{
				cmbNewBed.DataSource=bedTb;
				cmbNewBed.DisplayMember="BED_NO";
				cmbNewBed.ValueMember="BED_ID";
				cmbNewBed.SelectedIndex=0;
			}
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			string sSql="",sMsg="";

			new_bed_no=cmbNewBed.Text.Trim();//.Substring(0,1)=="加"?cmbNewBed.Text.Trim().Substring(1):cmbNewBed.Text.Trim();
            sSql = "select bed_id,INPATIENT_ID,isbf,dept_id,room_no from ZY_BEDDICTION where WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' and bed_no='" + new_bed_no + "' and isinuse=0";
			DataTable new_tempTab=InstanceForm.BDatabase.GetDataTable(sSql);
			if (new_tempTab.Rows[0]["INPATIENT_ID"].ToString().Trim()!="")
			{
				MessageBox.Show(this, "对不起，目标床位不是空床！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);						
				return;
			}
			if (Convert.ToInt16(new_tempTab.Rows[0]["isbf"].ToString())==1)
			{
				MessageBox.Show(this, "对不起，目标床位被包！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);						
				return;
			}
			new_bed_id=new Guid(new_tempTab.Rows[0]["bed_id"].ToString());
			new_dept_id=Convert.ToInt64(new_tempTab.Rows[0]["dept_id"]);

			//性别判断
			sSql=@"select * from zy_BedDiction "+
				" where ward_id='"+ InstanceForm.BCurrentDept.WardId + "'" +
				"   and room_no='" + new_tempTab.Rows[0]["room_no"].ToString().Trim() +"'" +
				"   and inpatient_id is not null "+
				"   and bedsex!='"+old_bed_sex+"'" ;            			
			DataTable tempTab=InstanceForm.BDatabase.GetDataTable(sSql);
			if  (tempTab.Rows.Count>0) 
			{
				sMsg="目标房间住有异性病人，";	
			}
	
			if (new_dept_id!=old_dept_id)
			{
                //if ( MessageBox.Show(this, "两个床位的所属科室不相同，"+sMsg+"是否确认转床？","转床", MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)==DialogResult.No) return ;
                //Modify By Tany 2016-11-21 不允许跨科室转床
                MessageBox.Show(this, "目标床位属于【" + new Department(new_dept_id, InstanceForm.BDatabase).DeptName.Trim() + "】，当前病人属于【" + new Department(old_dept_id, InstanceForm.BDatabase).DeptName.Trim() + "】\r\n两个床位的所属科室不相同，不允许操作！", "转床", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
			}
			else
			{
				if(MessageBox.Show(this, sMsg+"是否确认将 ["+old_bed_no+"床] 病人转到 ["+new_bed_no+"床] ？", "转床", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No  ) 
				{
					return ;
				}
			}

            string _outmsg = myFunc.ChangeBed("", 1, old_bed_id, new_bed_id, InstanceForm.BCurrentUser.EmployeeId, FrmMdiMain.Jgbm);

			if(_outmsg.Trim()!="")
			{
				MessageBox.Show(_outmsg);
			}

			//写日志 Add By Tany 2005-01-12
			SystemLog _systemLog=new SystemLog(-1,InstanceForm.BCurrentDept.DeptId,InstanceForm.BCurrentUser.EmployeeId,"转床",_outmsg+"把病人 "+ClassStatic.Current_BinID+" 从"+old_bed_id.ToString()+"床位代码转到"+new_bed_id.ToString()+"床位代码",DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase),1,"主机名："+System.Environment.MachineName,39);
			_systemLog.Save();
			_systemLog=null;

//			MessageBox.Show("转床成功，请重新确认病人的床位费！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);

			this.Close();
		}
	}
}
