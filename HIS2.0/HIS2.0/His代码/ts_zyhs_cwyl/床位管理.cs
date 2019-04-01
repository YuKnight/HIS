using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Runtime.InteropServices;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using TszyHIS;
using Crownwood.Magic.Docking;
using Crownwood.Magic.Common;
using ts_zyhs_ypxx;
namespace ts_zyhs_cwyl
{
    public partial class FrmCwgl : Form
    {
        
        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process,
            int minSize,
            int maxSize
        );
        private string[] stagArr;
        string bedno = "";
        string name = "";
        string sex = "";
        string age = "";
        string fb = "";
        string zyh = "";
        string bq = "";
        string tend = "";
        string zd = "";
        string ryrq = "";
        string bc = "";
        public FrmCwgl()
        {
            InitializeComponent();
        }
        DataTable BedTball;
        DataTable BedTb;
        DataTable DISEASETb;
        private void Inidata()
       {
           string sSql = "";
           sSql = @"SELECT  dbo.fun_ypfy(A.INPATIENT_ID) ypfy,a.IsQj,(select top 1 bed_no from zy_beddiction where bed_id=a.bf_id ) as BF_NO,A.ISPLUS,A.WARD_ID,A.ROOM_NO,A.BED_NO,A.INPATIENT_ID,A.ISBF,A.ISMYTS,A.BED_ID,c.inpatient_no,(select top 1 WARD_NAME from JC_WARD where WARD_ID=a.ward_id)+' '+a.BED_NO+'床' WARD_NAME ,isnull(C.OUT_MODE,0) OUT_MODE,(select top 1 convert(varchar(20),OUT_DATE,20)  from ZY_INPATIENT where INPATIENT_ID=a.inpatient_id ) out_date ," +
                           " dbo.FUN_ZY_SEEKPATFEEYE(c.inpatient_id,c.baby_id) ye,DBO.FUN_ZY_SEEKPATFEEINFO(c.inpatient_id,c.baby_id,0) zfy,ryts ,   " +
                       "       C.NAME,C.DISCHARGETYPE,C.FLAG,C.SEX_NAME,c.age,C.JSFS_NAME,C.TENDLEVEL,C.ORDER_BW,C.ORDER_BZ,dbo.fun_getdate(c.in_date) in_date,c.in_diagnosis,c.ryzd," +
                       "  OUT_DATE ,dbo.fun_getdiseasename(OUT_DIAGNOSIS,yblx ) OUT_DIAGNOSIS, " +
                       "       convert(char(41),A.INPATIENT_ID)+convert(char(11),A.Baby_ID)+convert(char(11),A.ISMYTS)  + convert(char(11),C.DEPT_ID) + convert(char(11),C.ISMY) + isnull(C.SEX_NAME,'未知') AS STAG " +
                       "  FROM ZY_BEDDICTION A LEFT JOIN (select * from vi_ZY_vInpatient_Bed where (WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' or 1=1 ))  C ON C.INPATIENT_ID=A.INPATIENT_ID AND C.Baby_ID=A.Baby_ID " +
                       " WHERE A.ISINUSE=0 and a.HOITEM_ID>0   ORDER BY a.ward_id,dbo.Fun_GetBedToOrder( (case when left(a.bed_no,1)='+' then '999'+a.bed_no else a.bed_no end) )";// (select * from ZY_vInpatient_Bed where WARD_ID='" + InstanceForm.BCurrentDept.WardId +"') Modify By Tany 2005-01-23
           //and A.WARD_ID='" + InstanceForm.BCurrentDept.WardId + "'
           BedTball = InstanceForm.BDatabase.GetDataTable(sSql, 120);
           BedTb = BedTball;
           //获得病区
           sSql = "select '9999' ward_id,'全部' ward_name union all select WARD_ID,WARD_NAME from JC_WARD ";
           this.combWard.DisplayMember = "ward_name";
           this.combWard.ValueMember = "ward_id";
           DataTable wardtb = FrmMdiMain.Database.GetDataTable(sSql);
           this.combWard.DataSource = wardtb;
          
           
       }
        private void tj(string ward_id)
        {
            //统计信息
            string sSql = "SELECT * FROM (select  COUNT(*) 今日入院  from VI_ZY_VINPATIENT a join ZY_BEDDICTION b on a.BED_ID=b.BED_ID  where b.HOITEM_ID>0  and  convert(varchar(10),IN_DATE,20)=convert(varchar(10),GETDATE(),20) and ( b.WARD_ID='" + ward_id + "' or '9999'='" + ward_id + "')     ) "
                + " A  left join  "
                + "  (select  COUNT(*) 今日出院  from VI_ZY_VINPATIENT a join ZY_BEDDICTION b on a.BED_ID=b.BED_ID where b.HOITEM_ID>0  and convert(varchar(10),OUT_DATE,20)=convert(varchar(10),GETDATE(),20)  and ( b.WARD_ID='" + ward_id + "' or '9999'='" + ward_id + "')     )  B ON 1=1 "
                + " left join  ( select  COUNT(*) 待排  from VI_ZY_VINPATIENT where flag=1 and  (  DEPT_ID in (select dept_id from JC_WARDRDEPT where WARD_ID='" + combWard.SelectedValue + "') or '9999'='" + ward_id + "') ) C on 1=1";
            DataTable jr_rctb = FrmMdiMain.Database.GetDataTable(sSql);
            if (jr_rctb.Rows.Count > 0)
            {
                this.labjrry.Text = jr_rctb.Rows[0]["今日入院"].ToString();
                this.labjrcy.Text = jr_rctb.Rows[0]["今日出院"].ToString();
                this.labdp.Text = jr_rctb.Rows[0]["待排"].ToString();
            }
            //床位数统计
            this.labzs.Text = BedTb.Rows.Count.ToString();
            BedTb.DefaultView.RowFilter = "INPATIENT_ID is not null  or ISBF=1";
            this.labyy.Text = BedTb.DefaultView.ToTable().Rows.Count.ToString();
            BedTb.DefaultView.RowFilter = "";


            this.labkc.Text = Convert.ToString(int.Parse(this.labzs.Text) - int.Parse(this.labyy.Text));
            double d = ((double.Parse(this.labyy.Text) / double.Parse(this.labzs.Text)) * 100);
            this.labzyl.Text = d.ToString("0.00") + "%";
            //统计备床数量
            string bedbc =@" select SUM(bcs) bcs,SUM(bcsys) bcsys from
(
select  case   when INPATIENT_ID is not null then 1 else 0  end bcs,
           case   when INPATIENT_ID is  null then 1 else 0  end bcsys
  from zy_beddiction where    ( WARD_ID='" + ward_id + "' or '9999'='" + ward_id + "') and HOITEM_ID<=0 ) aa   ";
            DataTable tbbedbc = FrmMdiMain.Database.GetDataTable(bedbc);
            if (tbbedbc.Rows.Count > 0)
            {
                this.label14.Text = tbbedbc.Rows[0]["bcs"].ToString();
                this.label16.Text = tbbedbc.Rows[0]["bcsys"].ToString();
            }
        }

        private void tjQy(string ward_id)
        {
            string sql="select '' 病区名称, '' 病区id, '' 床位总数, '' 占用数,'' 剩余数, '' 抢救床数,'' 剩余抢救床, '' 加床数, '' 剩余加床数 from jc_config where 1=2";
            DataTable tbtj=FrmMdiMain.Database.GetDataTable(sql);
            DataTable jr_rctb = null;
            DataTable tbtmp =(DataTable ) this.combWard.DataSource;
            for (int i = 0; i < this.combWard.Items.Count; i++)
            {
                if (tbtmp.Rows[i]["ward_id"].ToString().Trim() == "9999")
                    continue;
                DataRow r = tbtj.NewRow();
                ////统计信息
                //string sSql = "SELECT * FROM (select  COUNT(*) 今日入院  from VI_ZY_VINPATIENT a join ZY_BEDDICTION b on a.BED_ID=b.BED_ID  where convert(varchar(10),IN_DATE,20)=convert(varchar(10),GETDATE(),20) and ( b.WARD_ID='" + ward_id + "' or '9999'='" + ward_id + "')     ) "
                //    + " A  left join  "
                //    + "  (select  COUNT(*) 今日出院  from VI_ZY_VINPATIENT a join ZY_BEDDICTION b on a.BED_ID=b.BED_ID where convert(varchar(10),OUT_DATE,20)=convert(varchar(10),GETDATE(),20)  and ( b.WARD_ID='" + ward_id + "' or '9999'='" + ward_id + "')     )  B ON 1=1 "
                //    + " left join  ( select  COUNT(*) 待排  from VI_ZY_VINPATIENT where flag=1 and  (  DEPT_ID in (select dept_id from JC_WARDRDEPT where WARD_ID='" + combWard.SelectedValue + "') or '9999'='" + ward_id + "') ) C on 1=1";
                //jr_rctb = FrmMdiMain.Database.GetDataTable(sSql);
                //if (jr_rctb.Rows.Count > 0)
                //{
                //    this.labjrry.Text = jr_rctb.Rows[0]["今日入院"].ToString();
                //    this.labjrcy.Text = jr_rctb.Rows[0]["今日出院"].ToString();
                //    this.labdp.Text = jr_rctb.Rows[0]["待排"].ToString();

                //}
                //床位数统计
                r["病区名称"] = tbtmp.Rows[i]["ward_name"].ToString();
                r["病区id"] = tbtmp.Rows[i]["ward_id"].ToString();
                BedTball.DefaultView.RowFilter=" WARD_ID='" + tbtmp.Rows[i]["WARD_ID"].ToString() + "'";
                r["床位总数"] = BedTball.DefaultView.ToTable().Rows.Count.ToString();
                
                BedTball.DefaultView.RowFilter = " (INPATIENT_ID is not null  or ISBF=1)  and  WARD_ID='" + tbtmp.Rows[i]["WARD_ID"].ToString() + "'";
                r["占用数"] = BedTball.DefaultView.ToTable().Rows.Count.ToString();
                r["剩余数"] = Convert.ToInt32(r["床位总数"].ToString()) - Convert.ToInt32(r["占用数"].ToString());
                BedTball.DefaultView.RowFilter = " IsQj=1  and  WARD_ID='" + tbtmp.Rows[i]["WARD_ID"].ToString() + "'";
                r["抢救床数"] = BedTball.DefaultView.ToTable().Rows.Count.ToString();
                BedTball.DefaultView.RowFilter = " IsQj=1  and  WARD_ID='" + tbtmp.Rows[i]["WARD_ID"].ToString() + "' and (INPATIENT_ID is  null  and ISBF<>1) ";
                r["剩余抢救床"] = BedTball.DefaultView.ToTable().Rows.Count.ToString();
                BedTball.DefaultView.RowFilter = " ISPLUS=1  and  WARD_ID='" + tbtmp.Rows[i]["WARD_ID"].ToString() + "'  ";
                r["加床数"] = BedTball.DefaultView.ToTable().Rows.Count.ToString();
                BedTball.DefaultView.RowFilter = " ISPLUS=1  and  WARD_ID='" + tbtmp.Rows[i]["WARD_ID"].ToString() + "' and (INPATIENT_ID is  null  and ISBF<>1 )";
                r["剩余加床数"] = BedTball.DefaultView.ToTable().Rows.Count;
                tbtj.Rows.Add(r);
                 
            }
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = tbtj;
           
            
        }
        private void FrmCwgl_Load(object sender, EventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            try
            {
                string sSql = "";
                sSql = "select  CODING 编码,NAME 名称,py_code,wb_code from JC_DISEASE";
                DISEASETb = FrmMdiMain.Database.GetDataTable(sSql);
                this.serchText1.tb = DISEASETb;
                this.serchText1.dataGridView1.Width = 400;
                Inidata();

                tj(this.combWard.SelectedValue.ToString());
                tjQy(null);
                this.panelBed.Resize += new EventHandler(FrmCwgl_Resize);

                this.combWard.SelectedIndexChanged += new EventHandler(combWard_SelectedIndexChanged);
                this.combCwlx.SelectedIndex = 0;
                this.combCwlx.SelectedIndexChanged += new EventHandler(combCwlx_SelectedIndexChanged);


                this.dataGridView1.Columns["抢救床数"].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(160)), ((System.Byte)(122)));
                this.dataGridView1.Columns["剩余抢救床"].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                this.dataGridView1.Columns["加床数"].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(255)), ((System.Byte)(255)));
                this.dataGridView1.Columns["剩余加床数"].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(152)), ((System.Byte)(251)), ((System.Byte)(152)));
                this.dataGridView1.Columns["剩余数"].DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
                this.dataGridView1.Columns["占用数"].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(227)), ((System.Byte)(236)));
                this.dataGridView1.Columns["床位总数"].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        void combCwlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            try
            {
                string tj = " 1=1 ";
                switch (combCwlx.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1://空床
                        tj += " and inpatient_id is null and ISBF<>1";
                        break;
                    case 2://占用
                        tj += " and inpatient_id is not null or ISBF=1 ";
                        break;
                    case 3://抢救
                        tj += " and IsQj=1 ";
                        break;
                    case 4://加床
                        tj += " and ISPLUS=1 ";
                        break;
                }
                if (this.combWard.SelectedValue.ToString().Trim() != "9999")
                {
                    BedTball.DefaultView.RowFilter = tj + " and  WARD_ID='" + this.combWard.SelectedValue + "' ";
                    BedTb = BedTball.DefaultView.ToTable();
                    InitView(1, 1);
                }
                else
                {
                    BedTball.DefaultView.RowFilter = tj + " ";
                    BedTb = BedTball.DefaultView.ToTable();
                    InitView(1, 1);
                }
                GC.Collect();
            }
            catch { }
            finally {
                Cursor.Current = Cursors.Default;
            }
        }

        void combWard_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            try
            {

                if (this.combWard.SelectedValue.ToString().Trim() != "9999")
                {
                    BedTball.DefaultView.RowFilter = " WARD_ID='" + this.combWard.SelectedValue + "'";
                    BedTb = BedTball.DefaultView.ToTable();
                    InitView(1, 1);
                }
                else
                {
                    BedTball.DefaultView.RowFilter = " ";
                    BedTb = BedTball.DefaultView.ToTable();
                    InitView(1, 1);
                }
                tj(this.combWard.SelectedValue.ToString());
                this.combCwlx.SelectedIndexChanged -= new EventHandler(combCwlx_SelectedIndexChanged);
                this.combCwlx.SelectedIndex = 0;
                this.combCwlx.SelectedIndexChanged += new EventHandler(combCwlx_SelectedIndexChanged);
                this.serchText1.textBox1.Text = "";
                
            }
            catch
            { }
            finally
            {
                GC.Collect();
                Cursor.Current = Cursors.Default;
            }
        }

        void FrmCwgl_Resize(object sender, EventArgs e)
        {
            InitView(1, 1);
            this.Resize -= new EventHandler(FrmCwgl_Resize);
        }

        void FrmCwgl_ResizeEnd(object sender, EventArgs e)
        {
            
        }

        void panelBed_Resize(object sender, EventArgs e)
        {
           
        }
        private void InitView(int bit, int pxlx)//bit=0 图标 bit=1 床头卡 pxlx 0=床位号，1=病人姓名
        {
            string S_Data = "";
            string sSql = "";

            try
            {
                
                 if (bit == 1)
                {
                    int x = 9;
                    int y = 9;

                    

                    //Modify by Tany 2005-02-24
                    //增加停用标志
                    

                    this.panelBed.Controls.Clear();
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                    }

                    stagArr = new string[BedTb.Rows.Count];

                    if (BedTb.Rows.Count == 0) return;

                    for (int i = 0; i <= BedTb.Rows.Count - 1; i++)
                    {
                        Button bt = new Button();

                        bt.AllowDrop = true;
                        bt.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(227)), ((System.Byte)(236)));
                        bt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                        bt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                        bt.Size = new System.Drawing.Size(120, 185+30);//80,105
                        bt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                        bt.Location = new System.Drawing.Point(x, y);
                        bt.Click += new EventHandler(bt_Click);
                        string ypfy = BedTb.Rows[i]["ypfy"].ToString();
                        string ypbl=" ";
                        try
                        {
                            if (BedTb.Rows[i]["inpatient_id"].ToString().Trim() != "" && BedTb.Rows[i]["zfy"].ToString().Trim() != "0")
                                ypbl = (Convert.ToDecimal(Convert.ToDouble(BedTb.Rows[i]["ypfy"].ToString()) * 100 / Convert.ToDouble(BedTb.Rows[i]["zfy"].ToString()))).ToString("0.00")+ "%";
                            else
                                ypbl = "0%";
                        }
                        catch {
                           // MessageBox.Show(BedTb.Rows[i]["ypfy"].ToString() + "  :" + BedTb.Rows[i]["zfy"].ToString());
                        }
                        bt.Name = "bt" + i.ToString() + "," + BedTb.Rows[i]["WARD_NAME"].ToString() + "," + BedTb.Rows[i]["OUT_DATE"].ToString()+","
                            + BedTb.Rows[i]["OUT_DIAGNOSIS"].ToString() + "," + BedTb.Rows[i]["zfy"].ToString() + "," + BedTb.Rows[i]["ye"].ToString()
                            + "," + BedTb.Rows[i]["ryts"].ToString() + "," + "("+BedTb.Rows[i]["BF_NO"].ToString().Trim() + "床 )"
                            + "," + ypfy.ToString() + "," + ypbl + "," + BedTb.Rows[i]["inpatient_id"].ToString();
                        bt.Paint += new System.Windows.Forms.PaintEventHandler(button_Paint);
                        //bt.Click += new EventHandler(bt_Click);
                        //						bt.DoubleClick += new EventHandler(bt_DoubleClick);
                       // bt.MouseDown += new MouseEventHandler(bt_MouseDown);
                        //						bt.MouseHover += new EventHandler(bt_Click);

                        if (x + 249 >= this.panelBed.Width)
                        {
                            y = y + 114+80+30;
                            x = this.panelBed.Location.X + 9-3;
                        }
                        else
                        {
                            x = x + 129;
                        }

                        
                        int ll = 0;
                        //床号10位
                        if (BedTb.Rows[i]["bed_no"].ToString().Trim().Length <= 10)
                        {
                            ll = 10 - BedTb.Rows[i]["bed_no"].ToString().Trim().Length;
                            bt.Tag = BedTb.Rows[i]["bed_no"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["bed_no"].ToString().Trim().Substring(0, 10);
                        }
                        //姓名6位
                        if (BedTb.Rows[i]["name"].ToString().Trim().Length <= 6)
                        {
                            ll = 6 - BedTb.Rows[i]["name"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["name"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["name"].ToString().Trim().Substring(0, 6);
                        }
                        //性别2位
                        if (BedTb.Rows[i]["sex_name"].ToString().Trim().Length <= 2)
                        {
                            ll = 2 - BedTb.Rows[i]["sex_name"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["sex_name"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["sex_name"].ToString().Trim().Substring(0, 2);
                        }
                        //年龄3位
                        if (BedTb.Rows[i]["age"].ToString().Trim().Length <= 3)
                        {
                            ll = 3 - BedTb.Rows[i]["age"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["age"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["age"].ToString().Trim().Substring(0, 3);
                        }
                        //费用类别6位
                        if (BedTb.Rows[i]["jsfs_name"].ToString().Trim().Length <= 6)
                        {
                            ll = 6 - BedTb.Rows[i]["jsfs_name"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["jsfs_name"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["jsfs_name"].ToString().Trim().Substring(0, 6);
                        }
                        //住院号10位
                        if (BedTb.Rows[i]["inpatient_no"].ToString().Trim().Length <= 10)
                        {
                            ll = 10 - BedTb.Rows[i]["inpatient_no"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["inpatient_no"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["inpatient_no"].ToString().Trim().Substring(0, 10);
                        }
                        //病情10位
                        string s_bq = "";
                        if (BedTb.Rows[i]["order_bw"].ToString() != "0" && BedTb.Rows[i]["order_bw"].ToString() != "" && BedTb.Rows[i]["inpatient_no"].ToString() != "")
                            s_bq = s_bq + "*" + "病危";
                        if (BedTb.Rows[i]["order_bz"].ToString() != "0" && BedTb.Rows[i]["order_bz"].ToString() != "" && BedTb.Rows[i]["inpatient_no"].ToString() != "")
                            s_bq = s_bq + "△" + "病重";
                        if (s_bq.Length <= 10)
                        {
                            ll = 10 - s_bq.Length;
                            bt.Tag = bt.Tag + s_bq + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag += BedTb.Rows[i]["inpatient_no"].ToString().Trim().Substring(0, 10);
                        }
                        //护理10位
                        string s_hl = "";
                        switch (BedTb.Rows[i]["TENDLEVEL"].ToString())
                        {
                            case "4":
                                s_hl = "特级护理";
                                break;
                            case "3":
                                s_hl = "一级护理";
                                break;
                            case "2":
                                s_hl = "二级护理";
                                break;
                            case "1":
                                s_hl = "三级护理";
                                break;
                        }
                        if (s_hl.Length <= 10)
                        {
                            ll = 10 - s_hl.Length;
                            bt.Tag = bt.Tag + s_hl + Space(ll);
                        }
                        else
                        {
                            //bt.Tag = bt.Tag + BedTb.Rows[i]["in_diagnosis"].ToString().Trim().Substring(0, 10);
                            //Modify by Tany 2010-03-17 入院诊断名称
                            bt.Tag = bt.Tag + BedTb.Rows[i]["ryzd"].ToString().Trim().Substring(0, 10);
                        }
                        //诊断10位
                        if (BedTb.Rows[i]["ryzd"].ToString().Trim().Length <= 10)
                        {
                            ll = 10 - BedTb.Rows[i]["ryzd"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["ryzd"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["ryzd"].ToString().Trim().Substring(0, 10);
                        }
                        //入院时间10位
                        if (BedTb.Rows[i]["in_date"].ToString().Trim().Length <= 10)
                        {
                            ll = 10 - BedTb.Rows[i]["in_date"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["in_date"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["in_date"].ToString().Trim().Substring(0, 10);
                        }
                        //母婴同室6位
                        string s_myts = "";
                        if (BedTb.Rows[i]["ismyts"].ToString() == "1")
                            s_myts = "(母婴同室)";
                        else
                            s_myts = Space(6);
                        bt.Tag = bt.Tag + s_myts;
                        //包房3位
                        string s_bf = "";
                        if (BedTb.Rows[i]["isbf"].ToString() == "1")
                            s_bf ="(包)";
                        else
                            s_bf = Space(3);
                        bt.Tag = bt.Tag + s_bf;
                        //出院状态6位
                        string s_cy = "";
                        if (BedTb.Rows[i]["FLAG"].ToString() == "4")
                            s_cy = "(申请出院)";
                        else
                            s_cy = Space(6);
                        bt.Tag = bt.Tag + s_cy;


                        if (BedTb.Rows[i]["inpatient_id"].ToString().Trim() == "" || BedTb.Rows[i]["inpatient_no"].ToString().Trim()=="")
                        {
                            bt.TabIndex = 0;
                            bt.BackColor = System.Drawing.Color.WhiteSmoke; //System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(227)), ((System.Byte)(236)));

                            if (BedTb.Rows[i]["IsQj"].ToString().Trim() == "1")
                            {
                                bt.BackColor = System.Drawing.Color.Red;
                            }
                            if (BedTb.Rows[i]["ISPLUS"].ToString().Trim() == "1")
                            {
                                 bt.BackColor =System.Drawing.Color.FromArgb(((System.Byte)(152)), ((System.Byte)(251)), ((System.Byte)(152)));
                            }

                            
                        }
                        else
                        {

                            if (BedTb.Rows[i]["IsQj"].ToString().Trim() == "1")
                            {
                                bt.BackColor =System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(160)), ((System.Byte)(122))); 
                            }
                            if (BedTb.Rows[i]["ISPLUS"].ToString().Trim() == "1")
                            {
                                bt.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(255)), ((System.Byte)(255)));
                            }

                            if (this.maskedTextBox1.Text.Trim() != "")
                            {
                                if (Convert.ToDecimal(BedTb.Rows[i]["zfy"].ToString()) >= Convert.ToDecimal(this.maskedTextBox1.Text.Trim()))
                                    bt.BackColor = System.Drawing.Color.Gold;
                            }

                            int m = 0;//护理级别
                            int n = 0;//图片位置
                            int _type = 0;//类型
                            if (BedTb.Rows[i]["FLAG"].ToString() == "4")        //申请出院 	
                            {
                                //死亡
                                if (Convert.ToInt32(BedTb.Rows[i]["OUT_MODE"]) == 4)
                                {
                                    _type = 1;
                                }
                                else
                                {
                                    _type = 2;
                                }
                                n = GetBedImgNO(BedTb.Rows[i]["SEX_NAME"].ToString().Trim(), Convert.ToInt32(BedTb.Rows[i]["AGE"]), _type, Convert.ToInt32(BedTb.Rows[i]["ISMYTS"]));
                                bt.TabIndex = n;
                            }
                            else
                            {
                                m = (Convert.ToString(BedTb.Rows[i]["TENDLEVEL"]).Trim() == "" ? 0 : Convert.ToInt32(BedTb.Rows[i]["TENDLEVEL"]));  // 护理级别
                                switch (m)
                                {
                                    case 0://普通
                                        _type = 0;
                                        break;
                                    case 1://三级
                                        _type = 5;
                                        break;
                                    case 2://二级
                                        _type = 4;
                                        break;
                                    case 3://一级
                                        _type = 3;
                                        break;
                                    case 4://特级
                                        _type = 6;
                                        break;
                                    default:
                                        _type = 0;
                                        break;
                                }
                                n = GetBedImgNO(BedTb.Rows[i]["SEX_NAME"].ToString().Trim(), Convert.ToInt32(BedTb.Rows[i]["AGE"]), _type, Convert.ToInt32(BedTb.Rows[i]["ISMYTS"]));
                                bt.TabIndex = n;
                            }
                        }


                        this.toolTip1.SetToolTip(bt, "床        号：" + bt.Tag.ToString().Substring(0, 10).Trim() +
                            bt.Tag.ToString().Substring(77, 6).Trim() + bt.Tag.ToString().Substring(83, 3).Trim() + bt.Tag.ToString().Substring(86, 6).Trim() + "\n" +
                            "姓        名：" + bt.Tag.ToString().Substring(10, 6) + "\n" +
                            "性        别：" + bt.Tag.ToString().Substring(16, 2) + "\n" +
                            "年        龄：" + bt.Tag.ToString().Substring(18, 3) + "\n" +
                            "费用类别：" + bt.Tag.ToString().Substring(21, 6) + "\n" +
                            "住  院  号：" + bt.Tag.ToString().Substring(27, 10) + "\n" +
                            "病        情：" + bt.Tag.ToString().Substring(37, 10) + "\n" +
                            "护理级别：" + bt.Tag.ToString().Substring(47, 10) + "\n" +
                            "入院诊断：" + bt.Tag.ToString().Substring(57, 10) + "\n" +
                            "入院日期：" + bt.Tag.ToString().Substring(67, 10));

                        stagArr[i] = BedTb.Rows[i]["stag"].ToString();
                        this.panelBed.Controls.Add(bt);

                    }
                }

               // rtbMsg.Text = ShowMsgText();

            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           // PostMessage(this.listView1.Handle.ToInt32(), 0x020A, 0, 0);
        }
        DateTime clickTime = DateTime.Now;
        bool isClicked = false;
        string btname = "";
        void bt_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (btname == bt.Name)
            {
                if (isClicked)
                {
                    TimeSpan span = DateTime.Now - clickTime;
                    if (span.TotalMilliseconds < SystemInformation.DoubleClickTime)
                    {

                        //病区
                        string[] ss = bt.Name.Split(',');
                        if (ss[10].Trim() == "")
                            return;
                        object[] _value = new object[] { "医嘱管理查询", 0, ss[10] };
                        GetDllForm("ts_zyhs_yzgl", "Fun_ts_zyhs_yzgl_inpatient_cx", "医嘱管理查询",_value);
                        isClicked = false;
                    }
                    else
                    {
                        isClicked = true;
                        clickTime = DateTime.Now;
                    }
                }
                else
                {
                    isClicked = true;
                    clickTime = DateTime.Now;
                }
            }
            else
            {
                btname = bt.Name;
                isClicked = true;
                clickTime = DateTime.Now;
            }
             
           
        }
        private Form GetDllForm(string dllname, string functionName, string chinesename, object[] _value)
        {
            Form f = null;
            try
            {
                //string sDllName = f.Name.Remove(f.Name.LastIndexOf(f.Extension), f.Extension.Length).Trim();
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(Application.StartupPath + "\\" + dllname + ".dll");
                Type type = assembly.GetType(dllname + ".InstanceForm", true, true);
                //Type type = assembly.GetType(dllname + ".Frm_Query", true, true);
                object[] paramertes = new object[3];
                paramertes[0] = FrmMdiMain.CurrentUser.EmployeeId;
                paramertes[1] = FrmMdiMain.CurrentDept.DeptId;
                paramertes[2] = chinesename;
                Object obj = System.Activator.CreateInstance(type);
                ((IInnerCommunicate)obj).CurrentDept = FrmMdiMain.CurrentDept;
                ((IInnerCommunicate)obj).CurrentUser = FrmMdiMain.CurrentUser;
                ((IInnerCommunicate)obj).Database = FrmMdiMain.Database;
                ((IInnerCommunicate)obj).ChineseName = chinesename;
                ((IInnerCommunicate)obj).FunctionName = functionName;
                ((IInnerCommunicate)obj).CommunicateValue = _value;
                ((IInnerCommunicate)obj).InstanceWorkForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return f;
        }

        void bt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        

        /// <summary>
        /// 获得床位图片的序号
        /// </summary>
        /// <param name="_sex">性别</param>
        /// <param name="_age">年龄</param>
        /// <param name="_type">类型(0=普通1=死亡2=出院3=一级护理4=二级护理5=三级护理6=特级护理)</param>
        /// <param name="_ismy">是否母婴</param>
        /// <returns></returns>
        private int GetBedImgNO(string _sex, int _age, int _type, int _ismy)
        {
            //1=3岁以下无性别2=4~12女3=13~22女4=23~59女5=60+女6=4~12男7=13~22男8=23~59男9=60+男10=母婴
            //1-10  普通
            //11-20 死亡
            //21-30 出院
            //31-40 一级护理
            //41-50 二级护理
            //51-60 三级护理
            //61-70 特级护理
            int m = 0;//年龄段
            int n = 0;//男女差别带来的位置差
            int _rtn = 0;

            if (_sex == "男")
                n = 4;  //男从4位开始
            else
                n = 0;//女从0位开始

            //3岁以下不论男女
            if (_age <= 3)
            {
                m = 1;
                _rtn = _type * 10 + m;
            }
            if (_age > 3 && _age <= 12)
            {
                m = 2;
                _rtn = _type * 10 + m + n;
            }
            if (_age > 12 && _age <= 22)
            {
                m = 3;
                _rtn = _type * 10 + m + n;
            }
            if (_age > 22 && _age <= 59)
            {
                m = 4;
                _rtn = _type * 10 + m + n;
            }
            if (_age > 59)
            {
                m = 5;
                _rtn = _type * 10 + m + n;
            }
            //如果母婴直接取最后一位
            if (_ismy > 0)
            {
                _rtn = _type * 10 + 10;
            }

            return _rtn;
        }
        private string Space(int len)
        {
            string space = "";
            if (len > 0)
            {
                for (int i = 1; i <= len; i++)
                {
                    space += " ";
                }
            }
            return space;
        }

        private void button_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int pyl = 46;
            Button bt = (Button)sender;
            //病区
            string[] ss = bt.Name.Split(',');
            //病区
            //e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 15 + pyl, bt.Width, 15 + pyl);
            e.Graphics.DrawString(ss[1], bt.Font, Brushes.Green, 2, 2);
            e.Graphics.DrawImage(imgBED.Images[bt.TabIndex], 2, 16);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0,  pyl, bt.Width, pyl);

            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 30, 30, bt.Width, 30);
            e.Graphics.DrawString("总额:", bt.Font, Brushes.MidnightBlue,30,16);
            e.Graphics.DrawString("余额:", bt.Font, Brushes.MidnightBlue,30,31);

            e.Graphics.DrawString(ss[4], bt.Font, Brushes.Red, 35+25, 16);
            e.Graphics.DrawString(ss[5], bt.Font, Brushes.Red, 35+25, 31);
            //e.Graphics.DrawLine(System.Drawing.Pens.Gray,41,15,41, 45);
            //横线
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 15 + pyl, bt.Width, 15 + pyl);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 30 + pyl, bt.Width, 30 + pyl);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 45 + pyl, bt.Width, 45 + pyl);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 60 + pyl, bt.Width, 60 + pyl);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 75 + pyl, bt.Width, 75 + pyl);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 90 + pyl, bt.Width, 90 + pyl);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 105 + pyl, bt.Width, 105 + pyl);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 120 + pyl, bt.Width, 120 + pyl);

            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 135 + pyl, bt.Width, 135 + pyl);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 150 + pyl, bt.Width, 150 + pyl);
            //竖线
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 40, 0 + pyl, 40, 30 + pyl);
            //e.Graphics.DrawLine(System.Drawing.Pens.Black,80,0,80,20);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 20, 15 + pyl, 20, 30 + pyl);
            //e.Graphics.DrawLine(System.Drawing.Pens.Black,60,20,60,40);

            //病人信息
            bedno = bt.Tag.ToString().Substring(0, 10);
            
            name = bt.Tag.ToString().Substring(10, 6);
            sex = bt.Tag.ToString().Substring(16, 2);
            age = bt.Tag.ToString().Substring(18, 3);
            fb = bt.Tag.ToString().Substring(21, 6);
            zyh = bt.Tag.ToString().Substring(27, 10);
            bq = bt.Tag.ToString().Substring(37, 10);
            tend = bt.Tag.ToString().Substring(47, 10);
            zd = bt.Tag.ToString().Substring(57, 10);
            ryrq = bt.Tag.ToString().Substring(67, 10);
            if (bt.Tag.ToString().Substring(83, 3).Trim() != "" && name.Trim() == "")
                bc = bt.Tag.ToString().Substring(83, 3).Trim();
            else
                bc = "";

            if (bc.IndexOf("包") >=0)
            {
                bc = bc.Replace("(包)", "    ") + ss[7].Trim()  + " (包)";
            }
            e.Graphics.DrawString(bedno.Trim() + bc, bt.Font, Brushes.Red, 2, 2 + pyl);
            e.Graphics.DrawString(name, bt.Font, Brushes.MidnightBlue, 41, 2 + pyl);
            e.Graphics.DrawString(sex, bt.Font, Brushes.MidnightBlue, 2, 17 + pyl);
            e.Graphics.DrawString(age, bt.Font, Brushes.MidnightBlue, 22, 17 + pyl);
            e.Graphics.DrawString(fb, bt.Font, Brushes.MidnightBlue, 41, 17 + pyl);
            e.Graphics.DrawString(zyh, bt.Font, Brushes.MidnightBlue, 2, 32 + pyl);
            e.Graphics.DrawString(bq, bt.Font, Brushes.Red, 2, 47 + pyl);

           

            e.Graphics.DrawString(tend, bt.Font, Brushes.MidnightBlue, 2, 62 + pyl);
            e.Graphics.DrawString(zd, bt.Font, Brushes.MidnightBlue, 2, 77 + pyl);
            e.Graphics.DrawString(ryrq, bt.Font, Brushes.MidnightBlue, 2, 92 + pyl);
            if (zyh.Trim() != "")
            {
                //出院诊断
                e.Graphics.DrawString("出院诊断:" + (ss[3].Trim() == "未知诊断" ? "" : ss[3].Trim()), bt.Font, Brushes.MidnightBlue, 2, 92 + 15 + pyl);
                //出院日期
                e.Graphics.DrawString("出院日期:" + ss[2], bt.Font, Brushes.MidnightBlue, 2, 92 + 30 + pyl);
                //入院天数
                e.Graphics.DrawString(" 天数;" + ss[6], bt.Font, Brushes.Red, 50, 32 + pyl);

                e.Graphics.DrawString("药品费用:" + ss[8], bt.Font, Brushes.Red, 2, 92 + 45 + pyl);
                e.Graphics.DrawString("费用比例:" + ss[9], bt.Font, Brushes.Red, 2, 92 + 60 + pyl);
            }

            
        }

        private void serchText1_TextChage()
        {
            serchText1.BringToFront();
            DISEASETb.DefaultView.RowFilter = "py_code like '%" + this.serchText1.textBox1.Text.Trim() + "%' or wb_code like '%" + this.serchText1.textBox1.Text.Trim() + "%' or 名称 like '%" + this.serchText1.textBox1.Text.Replace("%", "") + "%'";
            this.serchText1.tb = DISEASETb.DefaultView.ToTable();
        }

        private void serchText1_fz()
        {
            if (serchText1.row == null)
                return;
            DataRow row = serchText1.row;
            this.serchText1.textBox1.Text = row["名称"].ToString().Trim();
            this.serchText1.textBox1.Tag = row["编码"].ToString().Trim();
        }

        private void serchText1_Js()
        {
            string tj = "";
            if (this.serchText1.textBox1.Tag != null && this.serchText1.textBox1.Text.Trim()!="")
                tj = " 1=1 and IN_DIAGNOSIS='" + this.serchText1.textBox1.Tag.ToString() + "'";
            else
                tj = " 1=1 ";
            if (this.combWard.SelectedValue.ToString().Trim() != "9999")
            {
                BedTball.DefaultView.RowFilter = " WARD_ID='" + this.combWard.SelectedValue + "' and " +tj;
                BedTb = BedTball.DefaultView.ToTable();
                InitView(1, 1);
            }
            else
            {
                BedTball.DefaultView.RowFilter = " " + tj;
                BedTb = BedTball.DefaultView.ToTable();
                InitView(1, 1);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dataGridView1.CurrentCell == null)
                return;
            int curindex = this.dataGridView1.CurrentCell.RowIndex;
            DataView dv=((DataTable )this.dataGridView1.DataSource).DefaultView;
            this.combWard.SelectedValue = dv[curindex]["病区id"];
            this.tabControl1.SelectedTab = this.tabPage1;
        }

    }
}