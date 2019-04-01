namespace HBCADemo
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_certBase64 = new System.Windows.Forms.Button();
			this.btn_login = new System.Windows.Forms.Button();
			this.tbox_certBase64 = new System.Windows.Forms.TextBox();
			this.tbox_password = new System.Windows.Forms.TextBox();
			this.cbox_certId = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tbox_URI = new System.Windows.Forms.TextBox();
			this.tbox_Port = new System.Windows.Forms.TextBox();
			this.tbox_IP = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btn_verifySealData = new System.Windows.Forms.Button();
			this.btn_sealData = new System.Windows.Forms.Button();
			this.btn_P7Verify = new System.Windows.Forms.Button();
			this.btn_P1Verify = new System.Windows.Forms.Button();
			this.btn_P7Sign = new System.Windows.Forms.Button();
			this.btn_P1Sign = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.tbox_result = new System.Windows.Forms.TextBox();
			this.tbox_flatData = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btn_TSS = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btn_sealVerifyFile = new System.Windows.Forms.Button();
			this.tbox_sealImageId = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.btn_sealFile = new System.Windows.Forms.Button();
			this.tbox_sourceFile = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.btn_sealImage = new System.Windows.Forms.Button();
			this.tbox_sealImageBase64 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbox_sealResultId = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.tbox_URI_TSS = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tbox_Port_TSS = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tbox_IP_TSS = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.btn_GetTSSInfo = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.tbox_TSSId = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.btn_verifyTSS = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_certBase64);
			this.groupBox1.Controls.Add(this.btn_login);
			this.groupBox1.Controls.Add(this.tbox_certBase64);
			this.groupBox1.Controls.Add(this.tbox_password);
			this.groupBox1.Controls.Add(this.cbox_certId);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(566, 124);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "登陆";
			// 
			// btn_certBase64
			// 
			this.btn_certBase64.Location = new System.Drawing.Point(352, 79);
			this.btn_certBase64.Name = "btn_certBase64";
			this.btn_certBase64.Size = new System.Drawing.Size(125, 23);
			this.btn_certBase64.TabIndex = 7;
			this.btn_certBase64.Text = "获取证书BASE64编码";
			this.btn_certBase64.UseVisualStyleBackColor = true;
			this.btn_certBase64.Click += new System.EventHandler(this.btn_certBase64_Click);
			// 
			// btn_login
			// 
			this.btn_login.Location = new System.Drawing.Point(352, 14);
			this.btn_login.Name = "btn_login";
			this.btn_login.Size = new System.Drawing.Size(75, 23);
			this.btn_login.TabIndex = 6;
			this.btn_login.Text = "登陆";
			this.btn_login.UseVisualStyleBackColor = true;
			this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
			// 
			// tbox_certBase64
			// 
			this.tbox_certBase64.Location = new System.Drawing.Point(110, 81);
			this.tbox_certBase64.Name = "tbox_certBase64";
			this.tbox_certBase64.Size = new System.Drawing.Size(227, 21);
			this.tbox_certBase64.TabIndex = 5;
			// 
			// tbox_password
			// 
			this.tbox_password.Location = new System.Drawing.Point(110, 47);
			this.tbox_password.Name = "tbox_password";
			this.tbox_password.PasswordChar = '*';
			this.tbox_password.Size = new System.Drawing.Size(227, 21);
			this.tbox_password.TabIndex = 4;
			this.tbox_password.Text = "11111111";
			// 
			// cbox_certId
			// 
			this.cbox_certId.FormattingEnabled = true;
			this.cbox_certId.Location = new System.Drawing.Point(110, 14);
			this.cbox_certId.Name = "cbox_certId";
			this.cbox_certId.Size = new System.Drawing.Size(227, 20);
			this.cbox_certId.TabIndex = 3;
			this.cbox_certId.DropDown += new System.EventHandler(this.cbox_certId_DropDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "证书BASE64编码:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(69, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "密码:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(69, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "证书:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tbox_URI);
			this.groupBox2.Controls.Add(this.tbox_Port);
			this.groupBox2.Controls.Add(this.tbox_IP);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(575, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(327, 124);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "验签服务器配置";
			// 
			// tbox_URI
			// 
			this.tbox_URI.Location = new System.Drawing.Point(82, 78);
			this.tbox_URI.Name = "tbox_URI";
			this.tbox_URI.Size = new System.Drawing.Size(155, 21);
			this.tbox_URI.TabIndex = 5;
			// 
			// tbox_Port
			// 
			this.tbox_Port.Location = new System.Drawing.Point(82, 50);
			this.tbox_Port.Name = "tbox_Port";
			this.tbox_Port.Size = new System.Drawing.Size(155, 21);
			this.tbox_Port.TabIndex = 4;
			this.tbox_Port.Text = "8000";
			// 
			// tbox_IP
			// 
			this.tbox_IP.Location = new System.Drawing.Point(82, 22);
			this.tbox_IP.Name = "tbox_IP";
			this.tbox_IP.Size = new System.Drawing.Size(155, 21);
			this.tbox_IP.TabIndex = 3;
			this.tbox_IP.Text = "221.232.224.75";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(29, 82);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 12);
			this.label6.TabIndex = 2;
			this.label6.Text = "URI:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(29, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 12);
			this.label5.TabIndex = 1;
			this.label5.Text = "端口号:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(29, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 12);
			this.label4.TabIndex = 0;
			this.label4.Text = "IP地址:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btn_verifySealData);
			this.groupBox3.Controls.Add(this.btn_sealData);
			this.groupBox3.Controls.Add(this.btn_P7Verify);
			this.groupBox3.Controls.Add(this.btn_P1Verify);
			this.groupBox3.Controls.Add(this.btn_P7Sign);
			this.groupBox3.Controls.Add(this.btn_P1Sign);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.tbox_result);
			this.groupBox3.Controls.Add(this.tbox_flatData);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Location = new System.Drawing.Point(3, 133);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(566, 310);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "签名验签";
			// 
			// btn_verifySealData
			// 
			this.btn_verifySealData.Location = new System.Drawing.Point(242, 49);
			this.btn_verifySealData.Name = "btn_verifySealData";
			this.btn_verifySealData.Size = new System.Drawing.Size(75, 23);
			this.btn_verifySealData.TabIndex = 9;
			this.btn_verifySealData.Text = "签章验签";
			this.btn_verifySealData.UseVisualStyleBackColor = true;
			this.btn_verifySealData.Click += new System.EventHandler(this.btn_verifySealData_Click);
			// 
			// btn_sealData
			// 
			this.btn_sealData.Location = new System.Drawing.Point(242, 20);
			this.btn_sealData.Name = "btn_sealData";
			this.btn_sealData.Size = new System.Drawing.Size(75, 23);
			this.btn_sealData.TabIndex = 8;
			this.btn_sealData.Text = "签章";
			this.btn_sealData.UseVisualStyleBackColor = true;
			this.btn_sealData.Click += new System.EventHandler(this.btn_sealData_Click);
			// 
			// btn_P7Verify
			// 
			this.btn_P7Verify.Location = new System.Drawing.Point(161, 49);
			this.btn_P7Verify.Name = "btn_P7Verify";
			this.btn_P7Verify.Size = new System.Drawing.Size(75, 23);
			this.btn_P7Verify.TabIndex = 7;
			this.btn_P7Verify.Text = "P7验签";
			this.btn_P7Verify.UseVisualStyleBackColor = true;
			this.btn_P7Verify.Click += new System.EventHandler(this.btn_P7Verify_Click);
			// 
			// btn_P1Verify
			// 
			this.btn_P1Verify.Location = new System.Drawing.Point(80, 48);
			this.btn_P1Verify.Name = "btn_P1Verify";
			this.btn_P1Verify.Size = new System.Drawing.Size(75, 23);
			this.btn_P1Verify.TabIndex = 6;
			this.btn_P1Verify.Text = "P1验签";
			this.btn_P1Verify.UseVisualStyleBackColor = true;
			this.btn_P1Verify.Click += new System.EventHandler(this.btn_P1Verify_Click);
			// 
			// btn_P7Sign
			// 
			this.btn_P7Sign.Location = new System.Drawing.Point(161, 20);
			this.btn_P7Sign.Name = "btn_P7Sign";
			this.btn_P7Sign.Size = new System.Drawing.Size(75, 23);
			this.btn_P7Sign.TabIndex = 5;
			this.btn_P7Sign.Text = "P7签名";
			this.btn_P7Sign.UseVisualStyleBackColor = true;
			this.btn_P7Sign.Click += new System.EventHandler(this.btn_P7Sign_Click);
			// 
			// btn_P1Sign
			// 
			this.btn_P1Sign.Location = new System.Drawing.Point(80, 19);
			this.btn_P1Sign.Name = "btn_P1Sign";
			this.btn_P1Sign.Size = new System.Drawing.Size(75, 23);
			this.btn_P1Sign.TabIndex = 4;
			this.btn_P1Sign.Text = "P1签名";
			this.btn_P1Sign.UseVisualStyleBackColor = true;
			this.btn_P1Sign.Click += new System.EventHandler(this.btn_P1Sign_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(23, 119);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 12);
			this.label8.TabIndex = 3;
			this.label8.Text = "结果:";
			// 
			// tbox_result
			// 
			this.tbox_result.Location = new System.Drawing.Point(80, 116);
			this.tbox_result.Multiline = true;
			this.tbox_result.Name = "tbox_result";
			this.tbox_result.Size = new System.Drawing.Size(432, 169);
			this.tbox_result.TabIndex = 2;
			// 
			// tbox_flatData
			// 
			this.tbox_flatData.Location = new System.Drawing.Point(80, 80);
			this.tbox_flatData.Name = "tbox_flatData";
			this.tbox_flatData.Size = new System.Drawing.Size(432, 21);
			this.tbox_flatData.TabIndex = 1;
			this.tbox_flatData.Text = "测试ABC123";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(23, 83);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 12);
			this.label7.TabIndex = 0;
			this.label7.Text = "原文:";
			// 
			// btn_TSS
			// 
			this.btn_TSS.Location = new System.Drawing.Point(75, 43);
			this.btn_TSS.Name = "btn_TSS";
			this.btn_TSS.Size = new System.Drawing.Size(75, 23);
			this.btn_TSS.TabIndex = 12;
			this.btn_TSS.Text = "时间戳";
			this.btn_TSS.UseVisualStyleBackColor = true;
			this.btn_TSS.Click += new System.EventHandler(this.btn_TSS_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btn_sealVerifyFile);
			this.groupBox4.Controls.Add(this.tbox_sealImageId);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Controls.Add(this.btn_sealFile);
			this.groupBox4.Controls.Add(this.tbox_sourceFile);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.btn_sealImage);
			this.groupBox4.Controls.Add(this.tbox_sealImageBase64);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.tbox_sealResultId);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Location = new System.Drawing.Point(575, 133);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(327, 310);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "签章";
			// 
			// btn_sealVerifyFile
			// 
			this.btn_sealVerifyFile.Location = new System.Drawing.Point(243, 143);
			this.btn_sealVerifyFile.Name = "btn_sealVerifyFile";
			this.btn_sealVerifyFile.Size = new System.Drawing.Size(75, 23);
			this.btn_sealVerifyFile.TabIndex = 11;
			this.btn_sealVerifyFile.Text = "验证签章";
			this.btn_sealVerifyFile.UseVisualStyleBackColor = true;
			this.btn_sealVerifyFile.Click += new System.EventHandler(this.btn_sealVerifyFile_Click);
			// 
			// tbox_sealImageId
			// 
			this.tbox_sealImageId.Location = new System.Drawing.Point(82, 17);
			this.tbox_sealImageId.Name = "tbox_sealImageId";
			this.tbox_sealImageId.Size = new System.Drawing.Size(155, 21);
			this.tbox_sealImageId.TabIndex = 10;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(17, 21);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(59, 12);
			this.label12.TabIndex = 9;
			this.label12.Text = "签章编号:";
			// 
			// btn_sealFile
			// 
			this.btn_sealFile.Location = new System.Drawing.Point(243, 114);
			this.btn_sealFile.Name = "btn_sealFile";
			this.btn_sealFile.Size = new System.Drawing.Size(75, 23);
			this.btn_sealFile.TabIndex = 8;
			this.btn_sealFile.Text = "文件签章";
			this.btn_sealFile.UseVisualStyleBackColor = true;
			this.btn_sealFile.Click += new System.EventHandler(this.btn_sealFile_Click);
			// 
			// tbox_sourceFile
			// 
			this.tbox_sourceFile.Location = new System.Drawing.Point(82, 115);
			this.tbox_sourceFile.Name = "tbox_sourceFile";
			this.tbox_sourceFile.Size = new System.Drawing.Size(155, 21);
			this.tbox_sourceFile.TabIndex = 7;
			this.tbox_sourceFile.Text = "E:\\1.txt";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(17, 119);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(47, 12);
			this.label11.TabIndex = 6;
			this.label11.Text = "源文件:";
			// 
			// btn_sealImage
			// 
			this.btn_sealImage.Location = new System.Drawing.Point(244, 81);
			this.btn_sealImage.Name = "btn_sealImage";
			this.btn_sealImage.Size = new System.Drawing.Size(75, 23);
			this.btn_sealImage.TabIndex = 4;
			this.btn_sealImage.Text = "获取签章图片";
			this.btn_sealImage.UseVisualStyleBackColor = true;
			this.btn_sealImage.Click += new System.EventHandler(this.btn_sealImage_Click);
			// 
			// tbox_sealImageBase64
			// 
			this.tbox_sealImageBase64.Location = new System.Drawing.Point(82, 82);
			this.tbox_sealImageBase64.Name = "tbox_sealImageBase64";
			this.tbox_sealImageBase64.Size = new System.Drawing.Size(155, 21);
			this.tbox_sealImageBase64.TabIndex = 3;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(17, 86);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(59, 12);
			this.label10.TabIndex = 2;
			this.label10.Text = "签章图片:";
			// 
			// tbox_sealResultId
			// 
			this.tbox_sealResultId.Location = new System.Drawing.Point(82, 44);
			this.tbox_sealResultId.Name = "tbox_sealResultId";
			this.tbox_sealResultId.Size = new System.Drawing.Size(155, 21);
			this.tbox_sealResultId.TabIndex = 1;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(17, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(59, 12);
			this.label9.TabIndex = 0;
			this.label9.Text = "签章结果:";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.tbox_URI_TSS);
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Controls.Add(this.tbox_Port_TSS);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.tbox_IP_TSS);
			this.groupBox5.Controls.Add(this.label13);
			this.groupBox5.Location = new System.Drawing.Point(908, 5);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(236, 122);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "时间戳服务器配置";
			// 
			// tbox_URI_TSS
			// 
			this.tbox_URI_TSS.Location = new System.Drawing.Point(75, 78);
			this.tbox_URI_TSS.Name = "tbox_URI_TSS";
			this.tbox_URI_TSS.Size = new System.Drawing.Size(155, 21);
			this.tbox_URI_TSS.TabIndex = 9;
			this.tbox_URI_TSS.Text = "/hbcaTSS/hbusiness";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(22, 82);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(29, 12);
			this.label15.TabIndex = 8;
			this.label15.Text = "URI:";
			// 
			// tbox_Port_TSS
			// 
			this.tbox_Port_TSS.Location = new System.Drawing.Point(75, 50);
			this.tbox_Port_TSS.Name = "tbox_Port_TSS";
			this.tbox_Port_TSS.Size = new System.Drawing.Size(155, 21);
			this.tbox_Port_TSS.TabIndex = 7;
			this.tbox_Port_TSS.Text = "8084";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(22, 54);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(47, 12);
			this.label14.TabIndex = 6;
			this.label14.Text = "端口号:";
			// 
			// tbox_IP_TSS
			// 
			this.tbox_IP_TSS.Location = new System.Drawing.Point(75, 22);
			this.tbox_IP_TSS.Name = "tbox_IP_TSS";
			this.tbox_IP_TSS.Size = new System.Drawing.Size(155, 21);
			this.tbox_IP_TSS.TabIndex = 5;
			this.tbox_IP_TSS.Text = "221.232.224.75";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(22, 26);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(47, 12);
			this.label13.TabIndex = 4;
			this.label13.Text = "IP地址:";
			// 
			// btn_GetTSSInfo
			// 
			this.btn_GetTSSInfo.Location = new System.Drawing.Point(75, 72);
			this.btn_GetTSSInfo.Name = "btn_GetTSSInfo";
			this.btn_GetTSSInfo.Size = new System.Drawing.Size(99, 23);
			this.btn_GetTSSInfo.TabIndex = 13;
			this.btn_GetTSSInfo.Text = "获取时间戳信息";
			this.btn_GetTSSInfo.UseVisualStyleBackColor = true;
			this.btn_GetTSSInfo.Click += new System.EventHandler(this.btn_GetTSSInfo_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.btn_verifyTSS);
			this.groupBox6.Controls.Add(this.tbox_TSSId);
			this.groupBox6.Controls.Add(this.label16);
			this.groupBox6.Controls.Add(this.btn_TSS);
			this.groupBox6.Controls.Add(this.btn_GetTSSInfo);
			this.groupBox6.Location = new System.Drawing.Point(908, 133);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(236, 171);
			this.groupBox6.TabIndex = 14;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "时间戳";
			// 
			// tbox_TSSId
			// 
			this.tbox_TSSId.Location = new System.Drawing.Point(75, 17);
			this.tbox_TSSId.Name = "tbox_TSSId";
			this.tbox_TSSId.Size = new System.Drawing.Size(155, 21);
			this.tbox_TSSId.TabIndex = 13;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(10, 21);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(47, 12);
			this.label16.TabIndex = 12;
			this.label16.Text = "时间戳:";
			// 
			// btn_verifyTSS
			// 
			this.btn_verifyTSS.Location = new System.Drawing.Point(75, 101);
			this.btn_verifyTSS.Name = "btn_verifyTSS";
			this.btn_verifyTSS.Size = new System.Drawing.Size(75, 23);
			this.btn_verifyTSS.TabIndex = 14;
			this.btn_verifyTSS.Text = "验证时间戳";
			this.btn_verifyTSS.UseVisualStyleBackColor = true;
			this.btn_verifyTSS.Click += new System.EventHandler(this.btn_verifyTSS_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1156, 455);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "HBCA Demo";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox tbox_certBase64;
		private System.Windows.Forms.TextBox tbox_password;
		private System.Windows.Forms.ComboBox cbox_certId;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_login;
		private System.Windows.Forms.Button btn_certBase64;
		private System.Windows.Forms.TextBox tbox_URI;
		private System.Windows.Forms.TextBox tbox_Port;
		private System.Windows.Forms.TextBox tbox_IP;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btn_P1Verify;
		private System.Windows.Forms.Button btn_P7Sign;
		private System.Windows.Forms.Button btn_P1Sign;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbox_result;
		private System.Windows.Forms.TextBox tbox_flatData;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btn_P7Verify;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button btn_sealImage;
		private System.Windows.Forms.TextBox tbox_sealImageBase64;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbox_sealResultId;
		private System.Windows.Forms.Button btn_sealFile;
		private System.Windows.Forms.TextBox tbox_sourceFile;
		private System.Windows.Forms.TextBox tbox_sealImageId;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button btn_verifySealData;
		private System.Windows.Forms.Button btn_sealData;
		private System.Windows.Forms.Button btn_sealVerifyFile;
		private System.Windows.Forms.Button btn_TSS;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox tbox_URI_TSS;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tbox_Port_TSS;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbox_IP_TSS;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btn_GetTSSInfo;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TextBox tbox_TSSId;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button btn_verifyTSS;
	}
}

