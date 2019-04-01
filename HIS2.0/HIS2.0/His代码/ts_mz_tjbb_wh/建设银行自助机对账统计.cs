using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using ts_mz_class;
using System.IO;
using System.Net;

/*
 * 名称：重新开发建设银行自助机对账统计
 * 作者：Kevin
 * 日期：2014-06
 */

namespace ts_mz_tjbb
{
    public partial class FrmCCBRec : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        RelationalDatabase db = new MsSqlServer();
        private bool bDebugMode;//调试模式，1是、0不是

        public FrmCCBRec()
        {
            InitializeComponent();
        }
        //正常使用模式
        public FrmCCBRec(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            db = TrasenFrame.Forms.FrmMdiMain.Database;
            bDebugMode = false;
            
            //读取1054 获取门诊统计时间默认时间点 
            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');
            if (s.Length == 2)
            {
                StartTime.Value = Convert.ToDateTime(StartTime.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
                EndTime.Value = Convert.ToDateTime(EndTime.Value.ToShortDateString() + " " + s[1]);
            }
        }
        //调试模式
        public FrmCCBRec(RelationalDatabase adb)
        {
            InitializeComponent();
            db = adb;
            bDebugMode = true;
            string strBegin = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 00:00:00";
            string strEnd = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
            StartTime.Value = Convert.ToDateTime(strBegin);
            EndTime.Value = Convert.ToDateTime(strEnd);
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameter = new ParameterEx[2];
                parameter[0].Text = "@StratTime";
                parameter[0].Value = StartTime.Value.ToString();
                parameter[1].Text = "@EndTime";
                parameter[1].Value = EndTime.Value.ToString();

                DataSet ds = new DataSet();
                db.AdapterFillDataSet("SP_ZZ_CCB_TJ", parameter, ds, "dztj", 30);
                Fun.AddRowtNo(ds.Tables[0]);
                dataGridView1.DataSource = ds.Tables[0];

                /*
                //如果医院端与银行端数据不符合，标红显示
                if (this.dataGridView1.Rows[0].Cells["交易总金额"].ToString() != this.dataGridView1.Rows[1].Cells["交易总金额"].ToString())
                {
                    this.dataGridView1.Columns["交易总金额"].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
                if (this.dataGridView1.Rows[0].Cells["交易笔数"].ToString() != this.dataGridView1.Rows[1].Cells["交易笔数"].ToString())
                {
                    this.dataGridView1.Columns["交易笔数"].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
                 * */
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            string swhere = "";

            swhere = "对账日期从:" + StartTime.Value.ToString() + " 到:" + EndTime.Value.ToString();

            ts_jc_log.ExcelOper.ExportData_ForDataTable(dataGridView1, Constant.HospitalName + label3.Text, swhere, true, true, false, false);
        }

        private void butprint_pos_Click(object sender, EventArgs e)
        {
            throw new Exception("暂未提供该功能！");
        }

        private void OpenMx()
        {
            try
            {
                if (this.dataGridView1.Rows.Count == 0)
                    return;

                string st = StartTime.Value.ToString();
                string et = EndTime.Value.ToString();

                Guid tjid = Guid.Empty;
                FrmCCBRecMx frm = null;
                if (bDebugMode)//调试模式
                {
                    frm = new FrmCCBRecMx(this.db);
                }
                else
                {
                    frm = new FrmCCBRecMx(this._menuTag, this._chineseName, this._mdiParent);
                }
                frm.MdiParent = this._mdiParent;
                frm.Show();
                frm.CcbMxTj(st, et, tjid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OpenMx();
        }

        private void FrmCCBRec_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnOpenMx_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            OpenMx();
        }
    }
}