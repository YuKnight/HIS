using EmrVSHISInterface;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using Ts_zyys_jysq.Properties;
using Ts_zyys_public;
using ts_zyhs_jyddy;
using TrasenClasses.DatabaseAccess;

namespace Ts_zyys_jysq
{
    public partial class Inpatient_tz : Form
    {
        public  string brzz_ot ="";
        public  string brzz_cgz = "";
        public  string brzz_cmy = "";
        public  string brzz_cdqx = "";
        public  string brzz_fx = "";
        public  string brzz_ogi ="";
        public  string brzz_wqt = "";
        public  string brzz_wcdcx = "";
        public  string brzz_wybns = "";
        public  string brzz_fny = "";
        public string brlx = "";
        public Guid BinID = Guid.Empty;
        public  bool  isclose=false;
        RelationalDatabase database;



        public Inpatient_tz(RelationalDatabase _database)
        {
            database = _database;
            InitializeComponent();
        }

        private void Inpatient_tz_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btn_tj_Click(object sender, EventArgs e)
        {
            if (chk_ot.Checked)
            {
                brzz_ot = chk_ot.Text;
            }
            if (chk_cgz.Checked)
            {
                brzz_cgz = chk_cgz.Text;
            }
            if (chk_cmy.Checked)
            {
                brzz_cmy = chk_cmy.Text;
            }
            if (chk_cdqx.Checked)
            {
                brzz_cdqx = chk_cdqx.Text;
            }
            if (chk_fx.Checked)
            {
                brzz_fx = chk_fx.Text;
            }
            if (chk_ogi.Checked)
            {
                brzz_ogi = chk_ogi.Text;
            }
            if (chk_wqt.Checked)
            {
                brzz_wqt = chk_wqt.Text;
            }
            brzz_wcdcx = cmb_wcdcx.Text;
            brzz_wybns = cmb_wybns.Text;
            brzz_fny = cmb_fny.Text;
            brlx = comboBox1.Text;
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请选择病人类型！");
                return;
            }
            if (cmb_fny.Text == "")
            {
                MessageBox.Show("请选择病人指征(腹内压)！");
                return;
            }
            if (cmb_wybns.Text == "")
            {
                MessageBox.Show("请选择病人指征(喂养不耐受)！");
                return;
            }
            if (cmb_wcdcx.Text == "")
            {
                MessageBox.Show("请选择病人指征(胃肠道出血)！");
                return;
            }
            DataTable dt=null;
            try
            {
                string sql = string.Format(@"select inpatient_id from zy_jy_brtz where inpatient_id='{0}'", BinID);
                dt = database.GetDataTable(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string sql_tz = string.Format(@"update  zy_jy_brtz set 
                                                       vomiting='{1}',
                                                       paralyticileus='{2}',
                                                       Bowelsoundsweakened='{3}',
                                                       intestinalischemia='{4}',
                                                       diarrhea='{5}',
                                                       Ogilvie='{6}',
                                                       Gastroparesis='{7}',
                                                       Gastrointestinalbleeding='{8}',
                                                       Feedingintolerance='{9}',
                                                       Intraperitonealpressure='{10}',
                                                       brlx='{11}'
                                                       where INPATIENT_ID='{0}'
                                                       ", BinID, brzz_ot, brzz_cgz, brzz_cmy, brzz_cdqx, brzz_fx, brzz_ogi, brzz_wqt, brzz_wcdcx, brzz_wybns, brzz_fny,brlx);
                    database.DoCommand(sql_tz);
                    this.Close();
                }
                else
                {
                    string sql_tz = string.Format(@"insert into zy_jy_brtz(
                                                     INPATIENT_ID,
                                                     vomiting,
                                                     paralyticileus,
                                                     Bowelsoundsweakened,
                                                     intestinalischemia,
                                                     diarrhea,
                                                     Ogilvie,
                                                     Gastroparesis,
                                                     Gastrointestinalbleeding,
                                                     Feedingintolerance,
                                                     Intraperitonealpressure,brlx) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')"
                                                     , BinID, brzz_ot, brzz_cgz, brzz_cmy, brzz_cdqx, brzz_fx, brzz_ogi, brzz_wqt, brzz_wcdcx, brzz_wybns, brzz_fny,brlx);
                    database.DoCommand(sql_tz);
                    this.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("未提交病人指征,将无法开此项目,是否关闭", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            else
            {
                isclose = true;
                this.Close();
            }
        }
    }
}