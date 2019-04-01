using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using YpClass;
using System.Net.Sockets;

namespace ts_yf_yfjh
{
    public partial class FrmStation : Form
    {
        public static MenuTag menuTag;
        public static string chineseName;
        public static Form mdiParent;
        public FrmStation(MenuTag _menuTag, string _chineseName, Form _mdiParent)
        {
            InitializeComponent();
            menuTag = _menuTag;
            chineseName = _chineseName;
            mdiParent = _mdiParent;
        }

        public FrmStation()
        {
            InitializeComponent();
        }

        private void FrmStation_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Init();
            SelectFyjh(dataGridView3);
            InitFyck();
            //InitConfig();
        }

        private void Init()
        {
            try
            {
                //查询当天已打印处方的的待领药处方
                string stime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd") + " 00:00:00";
                string etime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd") + " 23:59:59";

                string sql = "select a.fph,a.zje,a.brxm,a.blh,a.fpid,a.dnlsh,a.brxxid from MZ_FPB a where a.JLZT=0 and BSCBZ = 0 ";
                sql += "and FPID in (select FPID from MZ_CFB b where b.XMLY=1 and b.BSCBZ = 0 and b.ZXKS = '" + Convert.ToInt32(InstanceForm.BCurrentDept.DeptId) + "' and b.BPYBZ = 1 ";
                sql += "and b.BSFBZ = 1 and b.BFYBZ = 0 and b.SFRQ >= '" + stime + "' and b.SFRQ <= '" + etime + "') and fpid not in (select fpid from YF_FYJH c where c.dept = '" + InstanceForm.BCurrentDept.DeptId + "' and c.[time] >= '" + stime + "' and c.[time] <= '" + etime + "')";

                DataTable dt = InstanceForm.BDatabase.GetDataTable(sql, 60);
                dataGridView1.DataSource = dt;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void InitFyck()
        {
            DataTable dt = MZYF.Get_fyck("", "", InstanceForm.BDatabase);
            dt.TableName = "tab";
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "CODE";
            comboBox1.DisplayMember = "NAME";
            //comboBox1.Text = "";
        }

        private void InitConfig()
        {
            ////int iii = 0;   //
            //if (InstanceForm.BCurrentDept.DeptId == 4011)  //门诊西药房
            //{
            //    if (TrasenFrame.Classes.SystemCfg(10086).Config == 1)  //没有关闭自动关闭发送参数
            //    {
            //        this.button4.Text = "停止";
            //        GetXsnr();  //直接启动
            //        //iii = 1;
            //    }
            //    else
            //    {
            //        this.button4.Text = "开始";
            //    }
            //}
            //if (InstanceForm.BCurrentDept.DeptId == 4012)  //门诊中药房
            //{
            //    if (TrasenFrame.Classes.SystemCfg(10087).Config == 1)
            //    {
            //        this.button4.Text = "停止";
            //        GetXsnr();
            //        //iii = 1;
            //    }
            //    else
            //    {
            //        this.button4.Text = "开始";
            //    }
            //}
            //return iii;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.Rows.Count > 0)
                {
                    Guid fpid = new Guid(Convertor.IsNull(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["fpid"].Value.ToString(), Guid.Empty.ToString()));
                    DataTable dt = MZYF.SelectMzcfk(menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, Guid.Empty, "", "", 0, "", "", 0, 0, "", "", "", 0, "", "", 0, 0, "", "", "", 0, 0, fpid, Guid.Empty, 0, InstanceForm.BDatabase);
                    this.dataGridView2.DataSource = dt;

                    //隐藏不需要显示的数据
                    this.dataGridView2.Columns[0].Visible = false;
                    this.dataGridView2.Columns[1].Visible = false;
                    this.dataGridView2.Columns[2].Visible = false;
                    this.dataGridView2.Columns[4].Visible = false;
                    this.dataGridView2.Columns[5].Visible = false;
                    this.dataGridView2.Columns[8].Visible = false;
                    this.dataGridView2.Columns[14].Visible = false;
                    this.dataGridView2.Columns[15].Visible = false;
                    this.dataGridView2.Columns[16].Visible = false;
                    for (int i = 40; i <= 65; i++)
                    {
                        this.dataGridView2.Columns[i].Visible = false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    this.button1.Enabled = false;
                    if (numericUpDown1.Value == 0)
                    {
                        MessageBox.Show("请设置待刷新时间");
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        this.numericUpDown1.Enabled = false;
                        this.timer1.Interval = Convert.ToInt32(numericUpDown1.Value) * 1000;    //每隔多少秒刷新           
                        this.timer1.Enabled = true;  //启动时钟
                        timer1.Tick += new EventHandler(timer1_Tick);  //注册时间
                    }
                }
                else
                {
                    this.button1.Enabled = true;
                    checkBox1.Checked = false;
                    this.numericUpDown1.Enabled = true;
                    this.timer1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                this.button1.Enabled = true;
                checkBox1.Checked = false;
                this.numericUpDown1.Enabled = true;
                this.timer1.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void InsertFyjh(DataGridView dgv)
        {
            try
            {
                int xsbz = 0;
                string blh = Convertor.IsNull(dgv.Rows[dgv.CurrentCell.RowIndex].Cells["blh"].Value.ToString(), "");  //病历号
                string ssql = "select count(*) as sl from yf_fyjh where blh = '" + blh + "'";
                DataTable d = InstanceForm.BDatabase.GetDataTable(ssql, 30);
                int sl = Convert.ToInt32(d.Rows[0]["sl"]);
                if (sl > 0)
                {
                    xsbz = 5;
                }
                Guid fpid = new Guid(Convertor.IsNull(dgv.Rows[dgv.CurrentCell.RowIndex].Cells["fpid"].Value.ToString(), Guid.Empty.ToString()));  //发票ID
                string fph = Convertor.IsNull(dgv.Rows[dgv.CurrentCell.RowIndex].Cells["fph"].Value.ToString(), "");  //发票号
                decimal zje = Convert.ToDecimal(dgv.Rows[dgv.CurrentCell.RowIndex].Cells["zje"].Value);  //总金额
                string brxm = Convertor.IsNull(dgv.Rows[dgv.CurrentCell.RowIndex].Cells["brxm"].Value.ToString(), "");  //病人姓名
                string dnlsh = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells["dnlsh"].Value);  //电脑流水号
                Guid brxxid = new Guid(Convertor.IsNull(dgv.Rows[dgv.CurrentCell.RowIndex].Cells["BRXXID"].Value.ToString(), Guid.Empty.ToString()));
                string time = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");  //日期
                string pdxh = "";

                string lyck = comboBox1.Text.ToString();  //发药窗口
                int dept = InstanceForm.BCurrentDept.DeptId;  //部门
                string deptname = InstanceForm.BCurrentDept.DeptName;

                ParameterEx[] parameters = new ParameterEx[13];
                parameters[0].Text = "@FPID";
                parameters[0].DataType = System.Data.DbType.Guid;
                parameters[0].Value = fpid;

                parameters[1].Text = "@FPH";
                parameters[1].Value = fph;

                parameters[2].Text = "@ZJE";
                parameters[2].DataType = System.Data.DbType.Decimal;
                parameters[2].Value = zje;

                parameters[3].Text = "@BRXM";
                parameters[3].Value = brxm;

                parameters[4].Text = "@DNLSH";
                parameters[4].DataType = System.Data.DbType.Int64;
                parameters[4].Value = dnlsh;

                parameters[5].Text = "@BRXXID";
                parameters[5].DataType = System.Data.DbType.Guid;
                parameters[5].Value = brxxid;

                parameters[6].Text = "@XSBZ";
                parameters[6].DataType = System.Data.DbType.Int32;
                parameters[6].Value = xsbz;

                parameters[7].Text = "@TIME";
                parameters[7].Value = time;

                parameters[8].Text = "@PDXH";
                parameters[8].Value = pdxh;

                parameters[9].Text = "@BLH";
                parameters[9].Value = blh;

                parameters[10].Text = "@LYCK";
                parameters[10].Value = lyck;

                parameters[11].Text = "@DEPT";
                parameters[11].DataType = System.Data.DbType.Int32;
                parameters[11].Value = dept;

                parameters[12].Text = "@DEPTNAME";
                parameters[12].Value = deptname;

                //InstanceForm.BDatabase.BeginTransaction();
                int iii = InstanceForm.BDatabase.DoCommand("SP_YF_FYJH", parameters, 60);
                //InstanceForm.BDatabase.CommitTransaction();

                if (iii <= 0)
                {
                    //InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show("移动到排队显示区失败");
                }
            }
            catch (System.Exception ex)
            {
                // InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectFyjh(DataGridView dgv)
        {
            try
            {
                //查询当天显示屏显示部分内容
                string stime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd") + " 00:00:00";
                string etime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd") + " 23:59:59";

                string sql = "select a.fph as '发票号',a.zje as '金额',a.brxm as '姓名',a.blh as '病历号',a.dnlsh as '电脑流水号',a.pdxh as '排队序号',a.lyck as '领药窗口' from yf_fyjh a where a.xsbz = 0 and a.[time] >= '" + stime + "' and a.[time] <= '" + etime + "' and dept = '" + InstanceForm.BCurrentDept.DeptId + "' order by pdxh desc";
                DataTable dt = InstanceForm.BDatabase.GetDataTable(sql, 60);
                dgv.DataSource = dt;

                //dgv.Columns[0].Visible = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Close();
            //ts_yf_mzfy.Frmpyck f = new ts_yf_mzfy.Frmpyck(menuTag, chineseName, mdiParent);
            //f.ShowDialog();
            if (dataGridView1.Rows.Count > 0)
            {
                InsertFyjh(dataGridView1);
                SelectFyjh(dataGridView3);
                Init();
                this.dataGridView2.DataSource = null;  //清空datagridview2网格数据
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            InsertFyjh(dataGridView1);
            SelectFyjh(dataGridView3);
            Init();
        }

        private void GetXsnr()
        {
            //GetPort();  
            //DataSet ds = new DataSet();
            try
            {
                //this.button4.Enabled = false;
                int iii = 1; //1代表显示屏 用于监听端口判断显示屏和语音

                string msg = Convert.ToString(iii) + "|" + Convert.ToString(InstanceForm.BCurrentDept.DeptId);

                //string sql = "select top 5 PDXH,BRXM,FPH,BLH,FYCK from yf_fyjh where xsbz = 0 and lyck = '" + deptid + "' order by pdxh asc";
                ////InstanceForm.BDatabase.AdapterFillDataSet(sql, ds, "yf_fyjh", 60);
                ////DataTable dt = ds.Tables[1];
                //DataTable dt = InstanceForm.BDatabase.GetDataTable(sql, 60);
                //string msg = GetSendMsg(dt);
                SendPort(msg);

            }
            catch (System.Exception ex)
            {
                //this.button4.Enabled = true
                this.button4.Text = "开始";
                MessageBox.Show(ex.ToString());
            }
        }

        private string GetSendMsg(DataTable tb)
        {
            if (tb.Rows.Count == 0) return "";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                sb.Append(tb.Rows[i]["PDXH"].ToString());
                sb.Append("|");
                sb.Append(tb.Rows[i]["BRXM"].ToString());
                sb.Append("|");
                sb.Append(tb.Rows[i]["FPH"].ToString());
                sb.Append("|");
                sb.Append(tb.Rows[i]["BLH"].ToString());
                sb.Append("|");
                sb.Append(tb.Rows[i]["FYCK"].ToString());
                sb.Append("*");
            }
            return sb.ToString();

        }

        private void SendPort(String msg)
        {
            try
            {
                if (msg != "")
                {
                    string ip = "127.0.0.1";  //传服务器IP
                    Int32 port = 8889;  //传服务器端口
                    TcpClient client = new TcpClient(ip, port);
                    Byte[] data = System.Text.Encoding.Default.GetBytes(msg);
                    NetworkStream stream = client.GetStream();  //得到网络流
                    stream.Write(data, 0, data.Length);

                    stream.Close();
                    client.Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GetPort()
        {
            //
            //string ssql = "select * from jc_zjsz where zjid=" + Dqcf.ZsID + "";
            //DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);
            //if (tab.Rows.Count == 0)
            //{
            //    return;
            //}
            //if (Convertor.IsNull(tab.Rows[0]["txip"], "") == "" || Convertor.IsNull(tab.Rows[0]["txdk"], "") == "")
            //{
            //    return;
            //}

            //TcpClient client = new TcpClient(Convertor.IsNull(tab.Rows[0]["txip"], ""), Convert.ToInt32(Convertor.IsNull(tab.Rows[0]["txdk"], "")));
            TcpClient client = new TcpClient("127.0.0.1", 8889);
            client.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            GetXsnr();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked == true)
                {
                    this.button4.Enabled = false;
                    if (numericUpDown2.Value == 0)
                    {
                        MessageBox.Show("请设置显示间隔时间");
                        return;
                    }
                    this.numericUpDown2.Enabled = false;
                    this.timer2.Interval = Convert.ToInt32(numericUpDown2.Value) * 1000;    //每隔多少秒刷新           
                    this.timer2.Enabled = true;  //启动时钟
                    timer2.Tick += new EventHandler(timer2_Tick);
                }
                else
                {
                    this.Enabled = true;
                    this.numericUpDown2.Enabled = true;
                    this.timer2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                this.numericUpDown2.Enabled = true;
                this.timer2.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView2.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView3.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    if (this.button4.Text == "开始")
            //    {
            //        if (InstanceForm.BCurrentDept.DeptId == "4011")
            //        {
            //            string sql = "update jc_config set config = 1 where id = 10086";
            //            InstanceForm.BDatabase.DoCommand(sql, 60);
            //        }
            //        if (InstanceForm.BCurrentDept.DeptId == "4012")
            //        {
            //            string sql = "update jc_config set config = 1 where id = 10087";
            //            InstanceForm.BDatabase.DoCommand(sql, 60);
            //        }
            //        this.button4.Text = "停止";
            //        GetXsnr();
            //    }
            //    if (this.button4.Text == "停止")
            //    {
            //        if (InstanceForm.BCurrentDept.DeptId == "4011")
            //        {
            //            string sql = "update jc_config set config = 0 where id = 10086";
            //            InstanceForm.BDatabase.DoCommand(sql, 60);
            //        }
            //        if (InstanceForm.BCurrentDept.DeptId == "4012")
            //        {
            //            string sql = "update jc_config set config = 0 where id = 10087";
            //            InstanceForm.BDatabase.DoCommand(sql, 60);
            //        }
            //        this.button4.Text = "开始";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13)
            {
                button3_Click(sender, e);
            }
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            button3_Click(sender, e);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView3.Rows.Count == 0)
            {
                return;
            }
            string fp = this.dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string bl = this.dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[3].Value.ToString();
            string sql = "update YF_FYJH set xsbz = 1 where fph = '" + fp + "' and blh = '" + bl + "'";
            int iii = InstanceForm.BDatabase.DoCommand(sql);
            SelectFyjh(dataGridView3);
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView3.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < this.dataGridView3.Rows.Count; i++)
            {
                string fp = this.dataGridView3.Rows[i].Cells[0].Value.ToString();
                string bl = this.dataGridView3.Rows[i].Cells[3].Value.ToString();
                string sql = "update YF_FYJH set xsbz = 1 where fph = '" + fp + "' and blh = '" + bl + "'";
                int iii = InstanceForm.BDatabase.DoCommand(sql);
            }
            SelectFyjh(dataGridView3);
        }

    }
}