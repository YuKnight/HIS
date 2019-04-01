using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Ts_zyys_yzgl
{
	/// <summary>
	/// 新药信息 的摘要说明。
	/// </summary>
	public class FrmNewLack : System.Windows.Forms.Form
	{
		public DataTable dt=new DataTable();
		public System.Windows.Forms.Button bt=new Button();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lbSYZ;
		private System.Windows.Forms.Label lbSPM;
		private System.Windows.Forms.Label lbPM;
		private System.Windows.Forms.Label lbYLLB;
		private System.Windows.Forms.Label lbJX;
		private System.Windows.Forms.Label lbCJ;
		private System.Windows.Forms.Label lbYB;
		private System.Windows.Forms.Label lbDJ;
		private System.Windows.Forms.Label lbZFBL;
		private System.Windows.Forms.Label lbGG;
		private System.Windows.Forms.Label lb_du;
		private System.Windows.Forms.Label lb_ma;
		private System.Windows.Forms.Label lb_jing;
		private System.Windows.Forms.Label lb_gui;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmNewLack()
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label9 = new System.Windows.Forms.Label();
			this.lbSYZ = new System.Windows.Forms.Label();
			this.lbSPM = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.lbPM = new System.Windows.Forms.Label();
			this.lbYLLB = new System.Windows.Forms.Label();
			this.lbJX = new System.Windows.Forms.Label();
			this.lbCJ = new System.Windows.Forms.Label();
			this.lbYB = new System.Windows.Forms.Label();
			this.lbDJ = new System.Windows.Forms.Label();
			this.lbZFBL = new System.Windows.Forms.Label();
			this.lbGG = new System.Windows.Forms.Label();
			this.lb_du = new System.Windows.Forms.Label();
			this.lb_ma = new System.Windows.Forms.Label();
			this.lb_jing = new System.Windows.Forms.Label();
			this.lb_gui = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Navy;
			this.label1.Location = new System.Drawing.Point(184, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 19);
			this.label1.TabIndex = 3;
			this.label1.Text = "药品名称";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.Navy;
			this.label2.Location = new System.Drawing.Point(352, 121);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 19);
			this.label2.TabIndex = 4;
			this.label2.Text = "药品规格";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.Navy;
			this.label3.Location = new System.Drawing.Point(184, 121);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 19);
			this.label3.TabIndex = 5;
			this.label3.Text = "药品剂型";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.Navy;
			this.label4.Location = new System.Drawing.Point(184, 155);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 19);
			this.label4.TabIndex = 6;
			this.label4.Text = "生产厂家";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.ForeColor = System.Drawing.Color.Navy;
			this.label5.Location = new System.Drawing.Point(350, 187);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 19);
			this.label5.TabIndex = 7;
			this.label5.Text = "单价";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.ForeColor = System.Drawing.Color.Navy;
			this.label6.Location = new System.Drawing.Point(184, 189);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 19);
			this.label6.TabIndex = 8;
			this.label6.Text = "医保类型";
			this.label6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.ForeColor = System.Drawing.Color.Navy;
			this.label7.Location = new System.Drawing.Point(448, 187);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 19);
			this.label7.TabIndex = 9;
			this.label7.Text = "自费比例";
			this.label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.ForeColor = System.Drawing.Color.Navy;
			this.label8.Location = new System.Drawing.Point(184, 224);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(66, 20);
			this.label8.TabIndex = 10;
			this.label8.Text = "适 应 症";
			this.label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.listBox1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(8, 32);
			this.listBox1.Name = "listBox1";
			this.listBox1.ScrollAlwaysVisible = true;
			this.listBox1.Size = new System.Drawing.Size(144, 319);
			this.listBox1.TabIndex = 11;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.ForeColor = System.Drawing.Color.Navy;
			this.label9.Location = new System.Drawing.Point(16, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(60, 19);
			this.label9.TabIndex = 12;
			this.label9.Text = "新药清单";
			// 
			// lbSYZ
			// 
			this.lbSYZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbSYZ.Font = new System.Drawing.Font("宋体", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbSYZ.Location = new System.Drawing.Point(192, 248);
			this.lbSYZ.Name = "lbSYZ";
			this.lbSYZ.Size = new System.Drawing.Size(368, 104);
			this.lbSYZ.TabIndex = 13;
			// 
			// lbSPM
			// 
			this.lbSPM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbSPM.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbSPM.Location = new System.Drawing.Point(256, 16);
			this.lbSPM.Name = "lbSPM";
			this.lbSPM.Size = new System.Drawing.Size(304, 24);
			this.lbSPM.TabIndex = 14;
			this.lbSPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.ForeColor = System.Drawing.Color.Navy;
			this.label12.Location = new System.Drawing.Point(184, 87);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(63, 19);
			this.label12.TabIndex = 15;
			this.label12.Text = "药理类别";
			this.label12.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label13.ForeColor = System.Drawing.Color.Navy;
			this.label13.Location = new System.Drawing.Point(184, 19);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(63, 19);
			this.label13.TabIndex = 16;
			this.label13.Text = "商品名称";
			this.label13.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbPM
			// 
			this.lbPM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbPM.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbPM.Location = new System.Drawing.Point(256, 51);
			this.lbPM.Name = "lbPM";
			this.lbPM.Size = new System.Drawing.Size(304, 22);
			this.lbPM.TabIndex = 17;
			this.lbPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbYLLB
			// 
			this.lbYLLB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbYLLB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbYLLB.Location = new System.Drawing.Point(256, 84);
			this.lbYLLB.Name = "lbYLLB";
			this.lbYLLB.Size = new System.Drawing.Size(304, 22);
			this.lbYLLB.TabIndex = 18;
			this.lbYLLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbJX
			// 
			this.lbJX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbJX.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbJX.Location = new System.Drawing.Point(256, 117);
			this.lbJX.Name = "lbJX";
			this.lbJX.Size = new System.Drawing.Size(80, 22);
			this.lbJX.TabIndex = 19;
			this.lbJX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbCJ
			// 
			this.lbCJ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbCJ.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbCJ.Location = new System.Drawing.Point(256, 151);
			this.lbCJ.Name = "lbCJ";
			this.lbCJ.Size = new System.Drawing.Size(304, 22);
			this.lbCJ.TabIndex = 20;
			this.lbCJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbYB
			// 
			this.lbYB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbYB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbYB.Location = new System.Drawing.Point(256, 184);
			this.lbYB.Name = "lbYB";
			this.lbYB.Size = new System.Drawing.Size(80, 22);
			this.lbYB.TabIndex = 21;
			this.lbYB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbDJ
			// 
			this.lbDJ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbDJ.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbDJ.Location = new System.Drawing.Point(382, 184);
			this.lbDJ.Name = "lbDJ";
			this.lbDJ.Size = new System.Drawing.Size(64, 22);
			this.lbDJ.TabIndex = 22;
			this.lbDJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbZFBL
			// 
			this.lbZFBL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbZFBL.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbZFBL.Location = new System.Drawing.Point(512, 184);
			this.lbZFBL.Name = "lbZFBL";
			this.lbZFBL.Size = new System.Drawing.Size(48, 22);
			this.lbZFBL.TabIndex = 23;
			this.lbZFBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbGG
			// 
			this.lbGG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbGG.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbGG.Location = new System.Drawing.Point(416, 118);
			this.lbGG.Name = "lbGG";
			this.lbGG.Size = new System.Drawing.Size(144, 22);
			this.lbGG.TabIndex = 24;
			this.lbGG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lb_du
			// 
			this.lb_du.AutoSize = true;
			this.lb_du.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lb_du.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lb_du.ForeColor = System.Drawing.Color.Navy;
			this.lb_du.Location = new System.Drawing.Point(424, 216);
			this.lb_du.Name = "lb_du";
			this.lb_du.Size = new System.Drawing.Size(22, 22);
			this.lb_du.TabIndex = 25;
			this.lb_du.Text = "毒";
			this.lb_du.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lb_ma
			// 
			this.lb_ma.AutoSize = true;
			this.lb_ma.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lb_ma.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lb_ma.ForeColor = System.Drawing.Color.Navy;
			this.lb_ma.Location = new System.Drawing.Point(461, 216);
			this.lb_ma.Name = "lb_ma";
			this.lb_ma.Size = new System.Drawing.Size(22, 22);
			this.lb_ma.TabIndex = 26;
			this.lb_ma.Text = "麻";
			this.lb_ma.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lb_jing
			// 
			this.lb_jing.AutoSize = true;
			this.lb_jing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lb_jing.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lb_jing.ForeColor = System.Drawing.Color.Navy;
			this.lb_jing.Location = new System.Drawing.Point(498, 216);
			this.lb_jing.Name = "lb_jing";
			this.lb_jing.Size = new System.Drawing.Size(22, 22);
			this.lb_jing.TabIndex = 27;
			this.lb_jing.Text = "精";
			this.lb_jing.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lb_gui
			// 
			this.lb_gui.AutoSize = true;
			this.lb_gui.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lb_gui.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lb_gui.ForeColor = System.Drawing.Color.Navy;
			this.lb_gui.Location = new System.Drawing.Point(535, 216);
			this.lb_gui.Name = "lb_gui";
			this.lb_gui.Size = new System.Drawing.Size(22, 22);
			this.lb_gui.TabIndex = 28;
			this.lb_gui.Text = "贵";
			this.lb_gui.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// FrmNewLack
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(592, 373);
			this.Controls.Add(this.lb_gui);
			this.Controls.Add(this.lb_jing);
			this.Controls.Add(this.lb_ma);
			this.Controls.Add(this.lb_du);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.lbGG);
			this.Controls.Add(this.lbZFBL);
			this.Controls.Add(this.lbDJ);
			this.Controls.Add(this.lbYB);
			this.Controls.Add(this.lbCJ);
			this.Controls.Add(this.lbJX);
			this.Controls.Add(this.lbYLLB);
			this.Controls.Add(this.lbPM);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.lbSPM);
			this.Controls.Add(this.lbSYZ);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FrmNewLack";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "新药信息";
			this.Load += new System.EventHandler(this.FrmNewLack_Load);
			this.Closed += new System.EventHandler(this.FrmNewLack_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmNewLack_Load(object sender, System.EventArgs e)
		{
			addItem(dt);
		
		}
		private void addItem(DataTable dd)
		{
			for(int i=0;i<dd.Rows.Count;i++)
			{
				this.listBox1.Items.Add(dd.Rows[i]["S_YPSPM"].ToString());
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			for(int i=0;i<dt.Rows.Count;i++)
			{
				if(dt.Rows[i]["S_YPSPM"].ToString()==listBox1.SelectedItem.ToString())
				{
					this.lbSPM.Text=dt.Rows[i]["S_YPSPM"].ToString().Trim();
					this.lbPM.Text=dt.Rows[i]["S_YPPM"].ToString().Trim();
					if(dt.Rows[i]["SHH"].ToString().Substring(0,2)=="CY") this.lbPM.Text+="（中成药）";
					this.lbYLLB.Text=dt.Rows[i]["YLFL"].ToString().Trim();
					this.lbJX.Text=dt.Rows[i]["S_YPJX"].ToString().Trim();
					this.lbGG.Text=dt.Rows[i]["S_YPGG"].ToString().Trim()+" /"+dt.Rows[i]["S_YPDW"].ToString().Trim();
					this.lbCJ.Text=dt.Rows[i]["S_SCCJ"].ToString().Trim();
					this.lbYB.Text=dt.Rows[i]["YBLX"].ToString().Trim();
					this.lbDJ.Text=dt.Rows[i]["LSJ"].ToString().Trim();
					this.lbZFBL.Text=dt.Rows[i]["ZFBL"].ToString().Trim();
					this.lbSYZ.Text=dt.Rows[i]["ZZBZ"].ToString().Trim();
					this.lb_du.ForeColor=(dt.Rows[i]["djyp"].ToString()=="1")? Color.Red:Color.Navy;
					this.lb_ma.ForeColor=(dt.Rows[i]["mzyp"].ToString()=="1")? Color.Red:Color.Navy;
					this.lb_jing.ForeColor=(dt.Rows[i]["jsyp"].ToString()=="1")? Color.Red:Color.Navy;
					this.lb_gui.ForeColor=(dt.Rows[i]["gzyp"].ToString()=="1")? Color.Red:Color.Navy;
					return;
				}
			}
		}

		private void FrmNewLack_Closed(object sender, System.EventArgs e)
		{
			bt.Enabled=true;
		}
	}
}
