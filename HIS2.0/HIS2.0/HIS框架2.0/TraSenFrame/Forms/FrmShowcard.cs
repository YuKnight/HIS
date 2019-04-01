using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
namespace TrasenFrame.Forms
{
    /// <summary>
    /// Fshowcard 的摘要说明。
    /// </summary>
    public class Fshowcard : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.RadioButton chkmh;
        private System.Windows.Forms.RadioButton chkqd;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtinput;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private TrasenClasses.GeneralControls.DataGridEx myDataGrid1;
        private FilterType _dmType;//代码类型
        private string[] _sfield ={ "", "", "", "", "" };//代码类型对应的字段
        private string _ssql = "";//SQL语句
        private RelationalDatabase database;
        /// <summary>
        /// 返回的行
        /// </summary>
        public DataRow dataRow;
        private DataTable Tb = new DataTable();
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private RadioButton chkjq;
        //private DatabaseType dbType=DatabaseType.IbmDb2;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// FrmShowCard
        /// </summary>
        /// <param name="GrdMappingName">行标头数组</param>
        /// <param name="GrdWidth">行宽度数组</param>
        /// <param name="sfield">要查找的字段数组，长度5位,根据权举的值依次放在数组的不同位置</param>
        /// <param name="dmType">查找方式权举</param>
        /// <param name="dmText">查询的字符串</param>
        /// <param name="ssql">查询的基本SQL语句。最少带一个WHERE条件</param>
        public Fshowcard(string[] GrdMappingName, int[] GrdWidth, string[] sfield, FilterType dmType, string dmText, string ssql)
        {
            InitializeComponent();

            _sfield = sfield;
            _dmType = dmType;
            _ssql = ssql;

            database = FrmMdiMain.Database;

            //this.dataGridTableStyle1.MappingName = "dataGridTableStyle1";
            //this.myDataGrid1.TableStyles[0].MappingName = "Tb";
            //myDataGrid1.TableStyles[0].AllowSorting = false; //不允许排序
            //System.Windows.Forms.DataGridTextBoxColumn aColumnTextColumn;
            //for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            //{
            //    aColumnTextColumn = new DataGridTextBoxColumn();
            //    myDataGrid1.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
            //    myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
            //    myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
            //    myDataGrid1.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
            //    myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText = "";
            //}
            //this.txtinput.Text = dmText.Trim();
            //this.txtinput.Focus();
            //this.txtinput.SelectionLength = 0;
            //this.txtinput.SelectionStart = this.txtinput.Text.Length;
            //this.cmbtype.Text = _dmType.ToString();
            //this.cmbtype.Enabled = false;
            //this.SelectRecord();
            this.Init(GrdMappingName, GrdWidth,dmText);//jiang 2012-8-8 整合




        }

        /// <summary>
        /// FrmShowCard
        /// </summary>
        /// <param name="GrdMappingName">行标头数组</param>
        /// <param name="GrdWidth">行宽度数组</param>
        /// <param name="sfield">要查找的字段数组，长度5位,根据权举的值依次放在数组的不同位置</param>
        /// <param name="dmType">查找方式权举</param>
        /// <param name="dmText">查询的字符串</param>
        /// <param name="ssql">查询的基本SQL语句。最少带一个WHERE条件</param>
        /// <param name="db">指定数据库连接</param>
        public Fshowcard(string[] GrdMappingName, int[] GrdWidth, string[] sfield, FilterType dmType, string dmText, string ssql ,RelationalDatabase db)
        {
            InitializeComponent();

            _sfield = sfield;
            _dmType = dmType;
            _ssql = ssql;

            database = db;

            //this.dataGridTableStyle1.MappingName = "dataGridTableStyle1";
            //this.myDataGrid1.TableStyles[0].MappingName = "Tb";
            //myDataGrid1.TableStyles[0].AllowSorting = false; //不允许排序
            //System.Windows.Forms.DataGridTextBoxColumn aColumnTextColumn;
            //for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            //{
            //    aColumnTextColumn = new DataGridTextBoxColumn();
            //    myDataGrid1.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
            //    myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
            //    myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
            //    myDataGrid1.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
            //    myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText = "";
            //}
            //this.txtinput.Text = dmText.Trim();
            //this.txtinput.Focus();
            //this.txtinput.SelectionLength = 0;
            //this.txtinput.SelectionStart = this.txtinput.Text.Length;
            //this.cmbtype.Text = _dmType.ToString();
            //this.cmbtype.Enabled = false;
            //this.SelectRecord();
            this.Init(GrdMappingName, GrdWidth,dmText);//jiang 2012-8-8 整合
        }
        #region  Init 初始化 公共的
        /// <summary>
        /// 初始化 公共的 jiang 2012-8-8 整合
        /// </summary>
        private void Init(string[] GrdMappingName, int[] GrdWidth,string dmText)
        {
            //Constant
            #region 处理 查询方式 jiang 2012-8-8 增加
            SearchType searchType = Constant.CustomSearchType;
            if (searchType == SearchType.精确定位) this.chkjq.Checked = true;
            else if (searchType == SearchType.前导相似)  this.chkqd.Checked = true;
            else this.chkmh.Checked = true;
            #endregion 
            #region 处理 过滤方式  jiang 2012-8-8 增加
            cmbtype.Items.Add(FilterType.五笔.ToString());
            cmbtype.Items.Add(FilterType.拼音.ToString());
            cmbtype.Items.Add(FilterType.数字.ToString());
            cmbtype.Items.Add(FilterType.自编.ToString());
            cmbtype.Items.Add(FilterType.智能.ToString());

  
            string filterType_value = Constant.GetClientConfig("FILTERTYPE");//jianqg 2012-8-8 修改 按人处理
            if (Convertor.IsNumeric(filterType_value)) _dmType=(FilterType)Convert.ToInt32(filterType_value);
            #endregion 处理 查询方式

            //foreach (string tt in _sfield)
            //    comboBox1.Items.Add(tt);
            this.dataGridTableStyle1.MappingName = "dataGridTableStyle1";
            this.myDataGrid1.TableStyles[0].MappingName = "Tb";
            myDataGrid1.TableStyles[0].AllowSorting = false; //不允许排序
            System.Windows.Forms.DataGridTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                aColumnTextColumn = new DataGridTextBoxColumn();
                myDataGrid1.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                myDataGrid1.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i];
                myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText = "";
            }
            this.txtinput.Text = dmText.Trim();
            this.txtinput.Focus();
            this.txtinput.SelectionLength = 0;
            this.txtinput.SelectionStart = this.txtinput.Text.Length;
            this.cmbtype.Text = _dmType.ToString();
            this.cmbtype.Enabled = false; //原来为false，今改为true //jianqg 2012-8-8 可以选择
            this.SelectRecord();

        }
        #endregion
        //获得条件语句
        private string sWhere()
        {
            string dm = "";
            string ss = "";
            string like1 = "", like2 = "", operator1 = "";//前导相似，后导相似，运算符 jianqg 2012-8-8 修改处理运算符
            if (chkqd.Checked == true)
            {
                like1 = ""; like2 = "%"; operator1 = " like ";
            }
            else if (chkmh.Checked == true)
            {
                like1 = "%"; like2 = "%"; operator1 = " like ";
            }
            else if (chkjq.Checked == true)
            {
                like1 = ""; like2 = ""; operator1 = " = ";
            }
            if (_sfield.Length != 5)
            {
                return "";
            }
            if (_sfield[Convert.ToInt32(cmbtype.SelectedIndex)].Trim() != "" && cmbtype.Text.Trim() != "智能") //if (_sfield[Convert.ToInt32(_dmType)].Trim() != "" && _dmType.ToString().Trim() != "智能")
            {
                //dm = "upper(" + _sfield[Convert.ToInt32(_dmType)].Trim() + ") like '" + like.Trim() + this.txtinput.Text.Trim().ToUpper() + "%'";
                //jianqg 修改 2012-8-8 
                dm = string.Format(" upper(" + _sfield[Convert.ToInt32(cmbtype.SelectedIndex)].Trim() + ") {0} '{1}{2}{3}'", new object[] { operator1, like1, this.txtinput.Text.Trim().ToUpper(), like2 });
                ss = " and " + dm.Trim();
            }
            if (cmbtype.Text.Trim() == "智能")
            {
                for (int i = 0; i <= _sfield.Length - 1; i++)
                {
                    if (_sfield[i].Trim() != "")
                    {
                        
                        //ss = ss + " upper(" + _sfield[i].Trim() + ") like '" + like.Trim() + this.txtinput.Text.Trim().ToUpper() + "%'";
                        //jianqg 修改 2012-8-8
                        dm = string.Format(" upper(" + _sfield[i].Trim() + ") {0} '{1}{2}{3}'", new object[] { operator1, like1, this.txtinput.Text.Trim().ToUpper(), like2 });
                        if (ss.Trim() != "") ss += " or ";
                        ss += dm;
           
                    }
                }
                if (ss.Trim() != "") ss = " and (" + ss + ") ";
   

            }

            return ss;
        }

        //查找记录
        private void SelectRecord()
        {
            //			Tb=null;
            string ssql = "";
            ssql = _ssql + sWhere();
            //Modify By Tany 2009-04-27 空值相当于全部查询
            //if (txtinput.Text.Trim()=="" &&  this._sfield[Convert.ToInt32(_dmType)].Trim()!="") return;
            Tb = database.GetDataTable(ssql);
            Tb.TableName = "Tb";
            if (Tb.Rows.Count != 0)
            {
                for (int i = 0; i <= Tb.Columns.Count - 1; i++)
                {
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName = Tb.Columns[i].ColumnName.Trim();
                }
            }

            this.statusBarPanel1.Text = "找到 " + Tb.Rows.Count.ToString() + " 行记录";
            this.myDataGrid1.SetDataBinding(Tb, null);
            this.myDataGrid1.Refresh();
            if (Tb.Rows.Count > 0)
            {
                this.myDataGrid1.CurrentRowIndex = 0;
                this.myDataGrid1.Select(0);
            }
        }

        //输入框的键盘按下事件
        private void txtinput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            if (nkey == 40 && this.myDataGrid1.CurrentRowIndex < Tb.Rows.Count - 1)
            {
                this.myDataGrid1.CurrentRowIndex += 1;
                this.myDataGrid1.Select(this.myDataGrid1.CurrentCell.RowNumber);
            }

            if (nkey == 38 && this.myDataGrid1.CurrentRowIndex <= Tb.Rows.Count && this.myDataGrid1.CurrentRowIndex > 0)
            {

                this.myDataGrid1.CurrentRowIndex = this.myDataGrid1.CurrentRowIndex - 1;
                this.myDataGrid1.Select(this.myDataGrid1.CurrentCell.RowNumber);
                this.txtinput.SelectionStart = this.txtinput.Text.Length;
            }

            if (nkey == 13 && this.myDataGrid1.CurrentRowIndex >= 0)
            {
                this.SelectRow(Tb.Rows[myDataGrid1.CurrentCell.RowNumber]);
            }

            if (nkey == 27)
            {
                this.dataRow = null;
                this.Close();
            }

        }

        /// <summary>
        /// 选择记录
        /// </summary>
        /// <param name="row"></param>

        public void SelectRow(DataRow row)
        {
            if (row != null)
            {
                this.dataRow = row;
                this.Close();
            }
        }

        //网格的回车或ESC事件
        private bool myDataGrid_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (Convert.ToInt32(keyData) == 13 && this.myDataGrid1.CurrentRowIndex >= 0)
            {
                this.SelectRow(Tb.Rows[myDataGrid1.CurrentCell.RowNumber]);
            }

            if (Convert.ToInt32(keyData) == 27 && this.myDataGrid1.CurrentRowIndex >= 0)
            {
                this.dataRow = null;
                this.Close();
            }
            int keyInt = Convert.ToInt32(keyData);
            if ((keyInt >= 65 && keyInt <= 90))
            {
                this.txtinput.Text = this.txtinput.Text.Trim() + Convert.ToChar(keyInt);
                this.txtinput.SelectionStart = this.txtinput.Text.Length;
                this.SelectRecord();
                this.txtinput.Focus();
            }
            if (keyInt == 8 && this.txtinput.Text.Length > 0)
            {
                this.txtinput.Text = this.txtinput.Text.Substring(0, this.txtinput.Text.Length - 1);
                this.txtinput.SelectionStart = this.txtinput.Text.Length;
                this.SelectRecord();
                this.txtinput.Focus();

            }

            return false;
        }

        // 网格行的改变事件
        private void myDataGrid_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if (Tb == null) return;
            if (Tb.Rows.Count < 0) return;
            for (int i = 0; i <= Tb.Rows.Count - 1; i++)
            {
                myDataGrid1.UnSelect(i);
            }
            myDataGrid1.Select(myDataGrid1.CurrentCell.RowNumber);
        }


        //文本框的输入事件
        private void txtinput_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int nkey = 0;
            nkey = Convert.ToInt32(e.KeyCode);

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey >= 48 & nkey <= 57)//Modify By Tany 2009-04-27 退格键
            {
                this.SelectRecord();
            }

            //屏蔽数字选择记录 Modify By Tany 2009-08-27
            //if (nkey>48 &nkey<=57 )
            //{
            //    if (Tb.Rows.Count>(nkey-49))
            //    {
            //        this.SelectRow(Tb.Rows[nkey-49]);
            //    }
            //}

        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel7 = new System.Windows.Forms.Panel();
            this.chkjq = new System.Windows.Forms.RadioButton();
            this.chkmh = new System.Windows.Forms.RadioButton();
            this.chkqd = new System.Windows.Forms.RadioButton();
            this.panel11 = new System.Windows.Forms.Panel();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtinput = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 229);
            this.panel1.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel13);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 24);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(452, 177);
            this.panel8.TabIndex = 3;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.myDataGrid1);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(452, 177);
            this.panel13.TabIndex = 3;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(452, 177);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid_CurrentCellChanged);
            this.myDataGrid1.myKeyDown += new TrasenClasses.GeneralControls.myDelegate(this.myDataGrid_myKeyDown);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.chkjq);
            this.panel7.Controls.Add(this.chkmh);
            this.panel7.Controls.Add(this.chkqd);
            this.panel7.Controls.Add(this.panel11);
            this.panel7.Controls.Add(this.statusBar1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 201);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(452, 24);
            this.panel7.TabIndex = 2;
            // 
            // chkjq
            // 
            this.chkjq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkjq.Location = new System.Drawing.Point(329, 4);
            this.chkjq.Name = "chkjq";
            this.chkjq.Size = new System.Drawing.Size(73, 16);
            this.chkjq.TabIndex = 5;
            this.chkjq.Text = "精确定位";
            // 
            // chkmh
            // 
            this.chkmh.Checked = true;
            this.chkmh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkmh.Location = new System.Drawing.Point(259, 4);
            this.chkmh.Name = "chkmh";
            this.chkmh.Size = new System.Drawing.Size(73, 16);
            this.chkmh.TabIndex = 4;
            this.chkmh.TabStop = true;
            this.chkmh.Text = "模糊查询";
            // 
            // chkqd
            // 
            this.chkqd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkqd.Location = new System.Drawing.Point(189, 4);
            this.chkqd.Name = "chkqd";
            this.chkqd.Size = new System.Drawing.Size(73, 16);
            this.chkqd.TabIndex = 3;
            this.chkqd.Text = "前导查询";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 20);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(452, 4);
            this.panel11.TabIndex = 1;
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBar1.Location = new System.Drawing.Point(0, 0);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(452, 24);
            this.statusBar1.TabIndex = 0;
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
            this.statusBarPanel2.Width = 400;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(452, 24);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtinput);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(332, 24);
            this.panel5.TabIndex = 1;
            // 
            // txtinput
            // 
            this.txtinput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtinput.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtinput.Location = new System.Drawing.Point(48, 0);
            this.txtinput.Name = "txtinput";
            this.txtinput.Size = new System.Drawing.Size(284, 21);
            this.txtinput.TabIndex = 0;
            this.txtinput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtinput_KeyDown);
            this.txtinput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtinput_KeyUp);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(48, 24);
            this.panel6.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel4.Controls.Add(this.panel10);
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(332, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 24);
            this.panel4.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.Control;
            this.panel10.Controls.Add(this.cmbtype);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(40, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(80, 24);
            this.panel10.TabIndex = 1;
            // 
            // cmbtype
            // 
            this.cmbtype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtype.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbtype.Location = new System.Drawing.Point(0, 0);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(80, 20);
            this.cmbtype.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.Control;
            this.panel9.Controls.Add(this.label2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(40, 24);
            this.panel9.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(4, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "方式";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 16);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(468, 0);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Fshowcard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(456, 229);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "Fshowcard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "选项卡";
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion


    }
}
