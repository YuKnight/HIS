using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using YpClass;
using ts_mz_class;
using TrasenClasses.GeneralClasses;
using System.IO;
using Aspose.Cells;

namespace ts_yf_cx
{
    public partial class Frmjmypcx : Form
    {
        public Frmjmypcx()
        {
            InitializeComponent();
        }
        private bool bpcgl = false;
        private bool _ClickQuit = false;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        public Frmjmypcx(MenuTag menuTag, string chineseName, Form mdiParent)
            : this()
        {
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = chineseName;

            Yp.AddcmbWardDept(cmbbs1, 1, 0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
            Yp.AddcmbYjks(true, cmbyjks, DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

            cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId.ToString();
            if (cmbyjks.SelectedIndex == -1)
                cmbyjks.SelectedIndex = 0;

            //CshMxGrid(this.myDataGrid1);
            //CshHzGrid(this.myDataGrid2);

            this.dtprq1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            this.dtprq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
        }

        private void Frmjmypcx_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("type"));
            dt.Rows.Add(new object[] { -1, "全部" });
            dt.Rows.Add(new object[] { 3, "出院带药" });
            dt.Rows.Add(new object[] { 5, "处方发药" });
            dt.Rows.Add(new object[] { 9, "暂存" });
            dt.Rows.Add(new object[] { 0, "统领" });
            cmbType.DataSource = dt;
            cmbType.DisplayMember = "type";
            cmbType.ValueMember = "id";
            cmbType.SelectedIndex = 0;
        }

        private void butcfcx_Click(object sender, EventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            string where = "  where 1=1 and (";
            //if (chkmzyp.Checked == true)
            //    where = where == "" ? " mzyp=1 " : where + " or mzyp=1 ";
            //if (chkdjyp.Checked == true)
            //    where = where == "" ? " djyp=1 " : where + " or djyp=1 ";
            //if (chkpsyp.Checked == true)
            //    where = where == "" ? " psyp=1 " : where + " or psyp=1 ";
            //if (chkjsyp.Checked == true)
            //    where = where == "" ? " jsyp=1 " : where + " or jsyp=1 ";
            //if (chkgzyp.Checked == true)
            //    where = where == "" ? " gzyp=1 " : where + " or gzyp=1 ";
            //if (chkwyyp.Checked == true)
            //    where = where == "" ? " wyyp=1 " : where + " or wyyp=1 ";
            //if (chkcfyp.Checked == true)
            //    where = where == "" ? " cfyp=1 " : where + " or cfyp=1 ";
            //if (chkrsyp.Checked == true)
            //    where = where == "" ? " rsyp=1 " : where + " or rsyp=1 ";
            //if (chkkss.Checked == true)
            //    where = where == "" ? " kssdjid>0 " : where + " or kssdjid=1 ";

            if (chkmzyp.Checked == true)
                where += " mzyp=1 or";
            if (chkdjyp.Checked == true)
                where += " djyp=1 or";
            if (chkpsyp.Checked == true)
                where += " psyp=1 or";
            if (chkjsyp.Checked == true)
                where += " jsyp=1 or";
            if (chkgzyp.Checked == true)
                where += " gzyp=1 or";
            if (chkwyyp.Checked == true)
                where += " wyyp=1 or";
            if (chkcfyp.Checked == true)
                where += " cfyp=1 or";
            if (chkrsyp.Checked == true)
                where += " rsyp=1 or";
            if (chkkss.Checked == true)
                where += " kssdjid>0  or";

            if (where != "  where 1=1 and (")
            {
                where = string.Format("{0}{1}", where.Remove(where.Length - 2, 2), ")");
            }
            else
            {
                where = where.Remove(where.Length - 5, 5);
            }

            try
            {
                ParameterEx[] parameters = new ParameterEx[14];
                parameters[0].Text = "@functionname";
                parameters[0].Value = _menuTag.Function_Name;

                parameters[1].Text = "@deptid";
                parameters[1].Value = Convert.ToInt32(cmbyjks.SelectedValue);

                parameters[2].Text = "@inpatient_id";
                parameters[2].Value = Convertor.IsNull(txtzyh.Tag, "");

                parameters[3].Text = "@lyks";
                parameters[3].Value = Convert.ToInt32(Convertor.IsNull(cmbbs1.SelectedValue, "0"));

                parameters[4].Text = "@mbid";
                parameters[4].Value = Convertor.IsNull(txtmb.Tag, "0");

                parameters[5].Text = "@cjid";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(txtdm.Tag, "0"));

                parameters[6].Text = "@qrrq1";
                parameters[6].Value = dtprq1.Value.ToString();

                parameters[7].Text = "@qrrq2";
                parameters[7].Value = dtprq2.Value.ToString();

                parameters[8].Text = "@qrczyh";
                parameters[8].Value = Convert.ToInt32(Convertor.IsNull(txtfyr.Tag, "0"));

                parameters[9].Text = "@fybz";
                parameters[9].Value = 1;

                parameters[10].Text = "@where";
                parameters[10].Value = where;

                int bk = 2;
                //if (rdols.Checked == true) bk = 1;
                //if (rdoall.Checked == true)
                parameters[11].Text = "@bk";
                parameters[11].Value = bk;

                parameters[12].Text = "@tlfs";
                parameters[12].Value = int.Parse(this.cmbType.SelectedValue.ToString());

                parameters[13].Text = "@type";
                //if (radioButton1.Checked)
                //    parameters[13].Value = "冲减";
                //else if (radioButton2.Checked)
                //    parameters[13].Value = "统领";
                //else
                parameters[13].Value = "全部";
                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_YF_SELECT_CX_ZYCFCX_JM", parameters, dset, "sfmx", 180);

                dgvMx.AutoGenerateColumns = false;
                Fun.AddRowtNo(dset.Tables[0]);
                dset.Tables[0].TableName = "tbmx";
                dgvMx.DataSource = dset.Tables[0];

                dset.Tables[1].TableName = "tbhz";
                Fun.AddRowtNo(dset.Tables[1]);
                dgvHz.DataSource = dset.Tables[1];

                dset.Tables[1].TableName = "yphz";
                dgvYphz.DataSource = dset.Tables[2];

                this.statusBarPanel1.Text = "金额合计:" + dset.Tables[0].Compute("sum(金额)", "").ToString();
                this.statusBarPanel2.Text = "数量合计:" + dset.Tables[0].Compute("sum(ypsl)", "").ToString();
                //this.statusBarPanel2.Text = "";
                //this.statusBarPanel3.Text = "";
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            _ClickQuit = true;
            this.Close();
        }

        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 32 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
            {

            }
            else
            {
                return;
            }

            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            DataRow row;
            Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
            switch (control.TabIndex)
            {
                case 6:
                    if (control.Text.Trim() == "") return;
                    GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                    GrdWidth = new int[] { 0, 0, 50, 200, 100, 100, 40, 0, 60, 60, 70 };
                    sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };
                    if (Convertor.IsNull(cmbyjks.SelectedValue, "0") != "0")
                        ssql = "select a.ggid,cjid,0  rowno,yppm,ypgg,dbo.fun_yp_sccj(sccj) sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_Yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and deptid=" + Convert.ToInt32(cmbyjks.SelectedValue) + " ";
                    else
                        ssql = "select a.ggid,cjid,0  rowno,yppm,ypgg,dbo.fun_yp_sccj(sccj) sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_yp_ypcd a,yp_ypbm b where a.ggid=b.ggid   ";
                    TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.智能, control.Text.Trim(), ssql);
                    f2.Location = point;
                    f2.Width = 700;
                    f2.Height = 300;
                    f2.ShowDialog(this);
                    row = f2.dataRow;
                    if (row != null)
                    {
                        this.txtdm.Text = row["yppm"].ToString();
                        this.txtdm.Tag = row["cjid"].ToString();
                    }
                    break;
                case 5:
                    if (control.Text.Trim() == "") return;
                    GrdMappingName = new string[] { "模板名称", "拼音码", "五笔码", "id" };
                    GrdWidth = new int[] { 150, 60, 60, 0 };
                    sfield = new string[] { "wbm", "pym", "", "", "" };
                    ssql = "select mbmc,pym,wbm,id from yp_yptjmb b where id>0   ";
                    TrasenFrame.Forms.Fshowcard f3 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.智能, control.Text.Trim(), ssql);
                    f3.Location = point;
                    f3.Width = 700;
                    f3.Height = 300;
                    f3.ShowDialog(this);
                    row = f3.dataRow;
                    if (row != null)
                    {
                        this.txtmb.Text = row["mbmc"].ToString();
                        this.txtmb.Tag = row["id"].ToString();
                    }
                    break;
                case 4:
                    if (control.Text.Trim() == "") return;
                    GrdMappingName = new string[] { "姓名", "拼音码", "五笔码", "id" };
                    GrdWidth = new int[] { 150, 60, 60, 0 };
                    sfield = new string[] { "wb_code", "py_code", "", "", "" };
                    ssql = "select name,py_code,wb_code,employee_id from jc_employee_property where employee_id>0   ";
                    TrasenFrame.Forms.Fshowcard f4 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                    f4.Location = point;
                    f4.Width = 700;
                    f4.Height = 300;
                    f4.ShowDialog(this);
                    row = f4.dataRow;
                    if (row != null)
                    {
                        this.txtfyr.Text = row["name"].ToString();
                        this.txtfyr.Tag = row["employee_id"].ToString();
                    }
                    break;
            }
        }

        private void buthelp_Click(object sender, EventArgs e)
        {
            TszyHIS.Inpatient inpatient = new TszyHIS.Inpatient(TszyHIS.Inpatient.GetInpatientID());
            if (inpatient.InpatientNo.ToString() != "")
            {
                txtzyh.Text = inpatient.InpatientNo;
                txtzyh.Tag = inpatient.InpatientID;
            }
        }

        private void cmbbs1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tbmx = (DataTable)dgvMx.DataSource;
                if (tbmx != null) tbmx.Clear();

                DataTable tb = (DataTable)dgvHz.DataSource;
                if (tb != null) tb.Clear();

                lblfyrq.Text = "发药日期";
                int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0"));
                bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);
            }
            catch (System.Exception err)
            {
            }
        }

        private void txtzyh_KeyUp(object sender, KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;
            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string saveDialogCaptionName = null;
                string resourcName = null;
                Dictionary<string, string> xlsDictInfo = new Dictionary<string, string>();
                DataTable dataSouce = null;
                if (tabControl1.SelectedTab == tabPage1)
                {
                    xlsDictInfo.Add("A", "序号");
                    xlsDictInfo.Add("B", "领药科室");
                    xlsDictInfo.Add("C", "类型");
                    xlsDictInfo.Add("D", "床号");
                    xlsDictInfo.Add("E", "姓名");
                    xlsDictInfo.Add("F", "住院号");
                    xlsDictInfo.Add("G", "品名");
                    xlsDictInfo.Add("H", "规格");
                    xlsDictInfo.Add("I", "数量");
                    xlsDictInfo.Add("J", "处方日期");

                    xlsDictInfo.Add("K", "年龄");
                    xlsDictInfo.Add("L", "性别");
                    xlsDictInfo.Add("M", "身份证");

                    xlsDictInfo.Add("N", "发药员");

                    xlsDictInfo.Add("O", "处方医师");
                    xlsDictInfo.Add("P", "入院诊断");
                    xlsDictInfo.Add("Q", "出院诊断");
                    xlsDictInfo.Add("R", "批次号");
                    xlsDictInfo.Add("S", "批号");
                    xlsDictInfo.Add("T", "效期");
                    saveDialogCaptionName = "明细";
                    resourcName = "ts_yf_cx.明细.xlsx";
                    dataSouce = dgvMx.DataSource as DataTable;
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    xlsDictInfo.Add("A", "序号");
                    xlsDictInfo.Add("B", "领药科室");
                    xlsDictInfo.Add("C", "剂型");
                    xlsDictInfo.Add("D", "品名");
                    xlsDictInfo.Add("E", "商品名");
                    xlsDictInfo.Add("F", "规格");
                    xlsDictInfo.Add("G", "厂家");
                    xlsDictInfo.Add("H", "单价");
                    xlsDictInfo.Add("I", "领药数");
                    xlsDictInfo.Add("J", "单位");
                    xlsDictInfo.Add("K", "药库单位");
                    xlsDictInfo.Add("L", "金额");
                    xlsDictInfo.Add("M", "货号");
                    saveDialogCaptionName = "汇总";
                    resourcName = "ts_yf_cx.汇总.xlsx";
                    dataSouce = dgvHz.DataSource as DataTable;
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {
                    xlsDictInfo.Add("A", "序号");
                    xlsDictInfo.Add("B", "剂型");
                    xlsDictInfo.Add("C", "品名");
                    xlsDictInfo.Add("D", "商品名");
                    xlsDictInfo.Add("E", "规格");
                    xlsDictInfo.Add("F", "厂家");
                    xlsDictInfo.Add("G", "单价");
                    xlsDictInfo.Add("H", "领药数");
                    xlsDictInfo.Add("I", "库存数");
                    xlsDictInfo.Add("J", "差额");
                    xlsDictInfo.Add("K", "单位");
                    xlsDictInfo.Add("L", "金额");
                    xlsDictInfo.Add("M", "货号");
                    saveDialogCaptionName = "药品汇总";
                    resourcName = "ts_yf_cx.药品汇总.xlsx";
                    dataSouce = dgvYphz.DataSource as DataTable;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel 文件(*.xls)|*.xls";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                sfd.FileName = string.Format("{0}{1}.xls", DateTime.Now.ToString("yyyyMMddhhmmss"), saveDialogCaptionName);
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Stream s = this.GetType().Assembly.GetManifestResourceStream(resourcName);
                    StreamToFile(s, sfd.FileName);
                    Workbook wb = new Workbook();
                    wb.Open(sfd.FileName);
                    int rowIndex = 2;
                    foreach (DataRow row in dataSouce.Rows)
                    {
                        foreach (KeyValuePair<string, string> temp in xlsDictInfo)
                        {
                            object val = row[temp.Value];
                            if (val is DateTime)
                            {
                                if (((DateTime)val).ToString("yyyy-MM-dd") == "0001-01-01")
                                    wb.Worksheets[0].Cells[temp.Key + rowIndex.ToString()].PutValue("");
                                else
                                    wb.Worksheets[0].Cells[temp.Key + rowIndex.ToString()].PutValue(val);
                            }
                            else
                                wb.Worksheets[0].Cells[temp.Key + rowIndex.ToString()].PutValue(val);
                        }
                        rowIndex++;
                    }
                    wb.SaveToStream();
                    wb.Save(sfd.FileName);
                    MessageBox.Show("数据导出成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static void StreamToFile(Stream stream, string fileName)
        {
            // 把 Stream 转换成 byte[] 
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始 
            stream.Seek(0, SeekOrigin.Begin);
            // 把 byte[] 写入文件 
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }
    }
}