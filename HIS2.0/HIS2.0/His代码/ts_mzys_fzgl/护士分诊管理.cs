using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Diagnostics;
using ts_mzys_class;
using ts_mz_class;
using System.Net.Sockets;
using System.Threading;
using System.Media;
using System.Text;
using System.Net;
using DotNetSpeech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
namespace ts_mzys_fzgl
{
    public partial class Frmfzgl : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        private TimeSpan tmsp = new TimeSpan(100);
        private ThreadStart start;
        private Thread listenThread;
        static private bool m_bListening = false;
        static private TcpListener tcplistener;
        string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
        string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public Frmfzgl(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                tcplistener = new TcpListener(IPAddress.Any, 8889);
                start = new ThreadStart(startListen);
                listenThread = new Thread(start);
                tcplistener.Start();
                listenThread.Start();
                
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startListen()
        {
            string request = "";
            while (true)
            {
                if (tcplistener.Server.Connected==false) 
                tcplistener.Start();
                TcpClient tcpclient = tcplistener.AcceptTcpClient();
                if (tcpclient.Connected == true)
                {
                    try
                    {
                        NetworkStream newworkstream = tcpclient.GetStream();
                        byte[] buffer = new byte[504];
                        int readBytes = newworkstream.Read(buffer, 0, 504);
                        request = Encoding.Default.GetString(buffer, 0, readBytes);//Encoding.ASCII.GetString(buffer).Substring(0, readBytes);
                        if (request.Length > 0)
                        {
                            //Byte[] sendBytes = Encoding.Default.GetBytes("SERVER_MSG");
                            //newworkstream.Write(sendBytes, 0, sendBytes.Length);
                            //SoundPlayer win = new SoundPlayer();
                            //win = new SoundPlayer(Properties.Resources.Phone);
                            //win.Play();

                            //listView3.Items.Clear();
                            ListViewItem item = new ListViewItem();
                            item.Name = "bz";
                            item.Text = DateTime.Now.ToShortTimeString() + ": " + request.ToString() ;
                            // listView3.Items.Add(item);
                            listView3.Items.Insert(0, item);
                            #region 以前的语音代码注释
                           // SpeechVoiceSpeakFlags spFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;

                           // SpVoice voice = new SpVoice();
                           //// voice.Voice = voice.GetVoices("Name=Microsoft Simplified Chinese", "").Item(0);
                           // voice.Rate = 0;
                           // voice.Volume = 100;

                           // voice.Speak(request.ToString(), spFlags);
                            
                            
                            #endregion
                             
                            //Add By Zj 2012-08-07 新的语言叫号
                            ts_Caller.Icall _icall = ts_Caller.CallerFactory.NewCall(bjqxh);
                            _icall.Caller(request, _icall);
                            _icall.Call_hj();

                        }
                    }
                    catch (Exception ex)
                    {
                         
                        SpeechSynthesizer syn = new SpeechSynthesizer();
                        System.Collections.ObjectModel.ReadOnlyCollection<System.Speech.Synthesis.InstalledVoice> rr = syn.GetInstalledVoices();
                        // syn.SelectVoice("VW Wang");

                        //  System.Globalization.CultureInfo cuinfo=new System.Globalization.CultureInfo(
                        syn.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen, 2);
                       // syn.Speak("Fuck your Family");
                        syn.Speak(request.ToString());
                    }

                }



                else
                    tcplistener.Server.Connect(IPAddress.Any, 8889);
            }
        }

        private void Frmfzgl_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            cmbks.ComboBox.DataSource = Fun.GetGhks(false, InstanceForm.BDatabase); ;
            cmbks.ComboBox.ValueMember = "DEPT_ID";
            cmbks.ComboBox.DisplayMember = "NAME";
            cmbks.ComboBox.SelectedValue = InstanceForm.BCurrentDept.DeptId;

            butref1_Click(sender, e);
            butref2_Click(sender, e);

            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
        }


        private void butref1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbks.ComboBox.SelectedValue == null) return;
                if (cmbks.ComboBox.SelectedValue.ToString() == "System.Data.DataRowView") return;
                int ksdm = Convert.ToInt32(Convertor.IsNull(cmbks.ComboBox.SelectedValue, "0"));//DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString()
                string rq1 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00";
                string rq2 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59";
                int klx = 0;
                string kh = "";
                string blh = "";
                DataTable tb = MZHS_FZJL.Select_whzbr(ksdm, rq1, rq2, klx, kh, blh, InstanceForm.BDatabase).Tables[0];
                AddListView1(tb);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddListView1(DataTable tb)
        {
            listView1.Items.Clear();
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Name = "候诊号";
                item.Text = Convertor.IsNull(tb.Rows[i]["候诊号"], "");

                ListViewItem.ListViewSubItem subitem_xm = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["姓名"], ""));
                subitem_xm.Name = "姓名";
                item.SubItems.Add(subitem_xm);

                ListViewItem.ListViewSubItem subitem_ghsj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号时间"], ""));
                subitem_ghsj.Name = "挂号时间";
                item.SubItems.Add(subitem_ghsj);

                ListViewItem.ListViewSubItem subitem_ghks = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号科室"], ""));
                subitem_ghks.Name = "挂号科室";
                item.SubItems.Add(subitem_ghks);

                ListViewItem.ListViewSubItem subitem_ghjb = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号级别"], ""));
                subitem_ghjb.Name = "挂号级别";
                item.SubItems.Add(subitem_ghjb);

                ListViewItem.ListViewSubItem subitem_ghys = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号医生"], ""));
                subitem_ghys.Name = "挂号医生";
                item.SubItems.Add(subitem_ghys);


                ListViewItem.ListViewSubItem subitem_ghxxid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["ghxxid"], ""));
                subitem_ghxxid.Name = "ghxxid";
                item.SubItems.Add(subitem_ghxxid);

                ListViewItem.ListViewSubItem subitem_mzh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["门诊号"], ""));
                subitem_mzh.Name = "门诊号";
                item.SubItems.Add(subitem_mzh);

                ListViewItem.ListViewSubItem subitem_kh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["卡号"], ""));
                subitem_kh.Name = "卡号";
                item.SubItems.Add(subitem_kh);

                listView1.Items.Add(item);
            }
        }

        private void AddListView2(DataTable tb)
        {
            listView2.Items.Clear();
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Name = "候诊号";
                item.Text = Convertor.IsNull(tb.Rows[i]["候诊号"], "");

                ListViewItem.ListViewSubItem subitem_mzh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["门诊号"], ""));
                subitem_mzh.Name = "门诊号";
                item.SubItems.Add(subitem_mzh);

                ListViewItem.ListViewSubItem subitem_kh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["卡号"], ""));
                subitem_kh.Name = "卡号";
                item.SubItems.Add(subitem_kh);

                ListViewItem.ListViewSubItem subitem_xm = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["姓名"], ""));
                subitem_xm.Name = "姓名";
                item.SubItems.Add(subitem_xm);

                ListViewItem.ListViewSubItem subitem_hzks = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["候诊科室"], ""));
                subitem_hzks.Name = "候诊科室";
                item.SubItems.Add(subitem_hzks);

                ListViewItem.ListViewSubItem subitem_hzzs = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["候诊诊室"], ""));
                subitem_hzzs.Name = "候诊诊室";
                item.SubItems.Add(subitem_hzzs);

                ListViewItem.ListViewSubItem subitem_fzys = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["分诊医生"], ""));
                subitem_fzys.Name = "分诊医生";
                item.SubItems.Add(subitem_fzys);

                ListViewItem.ListViewSubItem subitem_ghsj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号时间"], ""));
                subitem_ghsj.Name = "挂号时间";
                item.SubItems.Add(subitem_ghsj);

                ListViewItem.ListViewSubItem subitem_ghks = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号科室"], ""));
                subitem_ghks.Name = "挂号科室";
                item.SubItems.Add(subitem_ghks);

                ListViewItem.ListViewSubItem subitem_ghjb = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号级别"], ""));
                subitem_ghjb.Name = "挂号级别";
                item.SubItems.Add(subitem_ghjb);

                ListViewItem.ListViewSubItem subitem_ghys = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号医生"], ""));
                subitem_ghys.Name = "挂号医生";
                item.SubItems.Add(subitem_ghys);

                ListViewItem.ListViewSubItem subitem_bz = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["备注"], ""));
                subitem_bz.Name = "备注";
                item.SubItems.Add(subitem_bz);

                ListViewItem.ListViewSubItem subitem_ghxxid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["ghxxid"], ""));
                subitem_ghxxid.Name = "ghxxid";
                item.SubItems.Add(subitem_ghxxid);

                ListViewItem.ListViewSubItem subitem_zsid= new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["zsid"], ""));
                subitem_zsid.Name = "zsid";
                item.SubItems.Add(subitem_zsid);

                ListViewItem.ListViewSubItem subitem_fzid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["FZID"], ""));
                subitem_fzid.Name = "fzid";
                item.SubItems.Add(subitem_fzid);

                int hzlx= Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["hzlx"], "0"));
                if (hzlx == 1)
                    item.ForeColor = Color.Blue;
                if (hzlx == 2)
                    item.ForeColor = Color.Green ;

                listView2.Items.Add(item);
            }
        }

        private void AddListView4(DataTable tb)
        {
            listView4.Items.Clear();
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Name = "科室";
                item.Text = Convertor.IsNull(tb.Rows[i]["科室"], "");

                ListViewItem.ListViewSubItem subitem_zs = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["诊室"], ""));
                subitem_zs.Name = "诊室";
                item.SubItems.Add(subitem_zs);

                ListViewItem.ListViewSubItem subitem_zzys = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["坐诊医生"], ""));
                subitem_zzys.Name = "坐诊医生";
                item.SubItems.Add(subitem_zzys);

                ListViewItem.ListViewSubItem subitem_dlsj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["登陆时间"], ""));
                subitem_dlsj.Name = "登陆时间";
                item.SubItems.Add(subitem_dlsj);

                ListViewItem.ListViewSubItem subitem_zjid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["zjid"], ""));
                subitem_zjid.Name = "zjid";
                item.SubItems.Add(subitem_zjid);

                listView4.Items.Add(item);
            }
        }


        private void UpdatePxxh()
        {
            try
            {
                if (listView2.Items.Count == 0)
                {
                    return;
                }
                InstanceForm.BDatabase.BeginTransaction();
                for (int i = 0; i <= listView2.Items.Count - 1; i++)
                {
                    ListViewItem item = (ListViewItem)listView2.Items[i];
                    string fzid = item.SubItems["fzid"].Text;
                    int pxxh = i + 1;
                    string ssql = "update mzhs_fzjl set pxxh=" + pxxh + " where fzid='" + fzid + "'";
                    int iii = InstanceForm.BDatabase.DoCommand(ssql);
                }
                InstanceForm.BDatabase.CommitTransaction();
                
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                throw new Exception(err.Message);
            }
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar != 13) return;
                Guid NewFzid=Guid.Empty;
                int err_code=-1;
                string err_text="";
                Control control=(Control)sender;


                int ksdm = Convert.ToInt32(Convertor.IsNull(cmbks.ComboBox.SelectedValue, "0"));
                string rq1 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00";
                string rq2 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59";
                int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue,"0"));

                if (control.Name == "txtkh")
                {
                    txtkh.Text = Fun.returnKh(klx, txtkh.Text.Trim(), InstanceForm.BDatabase);
                    txtkh.SelectAll();
                }
                if (control.Name == "txtmzh" || control.Name=="listView1")
                {
                    txtmzh.Text = Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                    txtmzh.SelectAll();
                }
                string kh = control.Name == "txtkh" ? Fun.returnKh(klx, txtkh.Text.Trim(), InstanceForm.BDatabase) : "";
                string blh = control.Name == "txtmzh" || control.Name == "listView1" ? Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase) : "";


                DataSet dset = MZHS_FZJL.Select_whzbr(ksdm, rq1, rq2, klx, kh, blh, InstanceForm.BDatabase);
                DataTable tb=dset.Tables[0];

                //如果多行，则由用户选择
                if (tb.Rows.Count>1)
                    AddListView1(tb);

                //如果找到一行。则直接候诊
                if (tb.Rows.Count == 1)
                {
                    try
                    {
                        InstanceForm.BDatabase.BeginTransaction();
                        MZHS_FZJL.AddHz(TrasenFrame.Forms.FrmMdiMain.Jgbm, new Guid(tb.Rows[0]["ghxxid"].ToString()), Convert.ToInt32(tb.Rows[0]["hzks"]), out NewFzid, out err_code, out err_text, InstanceForm.BDatabase);
                        if (NewFzid == Guid.Empty || err_code != 0)
                            throw new Exception(err_text);
                        InstanceForm.BDatabase.CommitTransaction();
                        butref1_Click(sender, e);
                        butref2_Click(sender, e);
                        control.Text = "";
                    }
                    catch (System.Exception err)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();
                        throw new Exception(err.Message);
                    }
                }

                //如果没有找到行
                if (tb.Rows.Count == 0 && ksdm!=0)
                {
                    DataTable tbxx = dset.Tables[1];
                    if (tbxx.Rows.Count == 0) throw new Exception("没有找到这个病人的挂号信息");
                    
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butref2_Click(object sender, EventArgs e)
        {
            try
            {
                int ksdm = 0;//DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString()
                string rq1 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00";
                string rq2 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59";
                int klx = 0;
                string kh = "";
                string blh = "";
                DataTable tb = MZHS_FZJL.Select_yhzbr(ksdm, rq1, rq2, klx, kh, blh, InstanceForm.BDatabase).Tables[0];
                AddListView2(tb);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butup_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView2.SelectedIndices.Count == 0) return;
                ListViewItem item = (ListViewItem)listView2.SelectedItems[0];
                int nrow = item.Index-1;
                if (nrow < 0) return;
                item.Remove();
                listView2.Items.Insert(nrow, item);
                UpdatePxxh();
                
            }
            catch (System.Exception ERR)
            {
                MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butdown_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView2.SelectedIndices.Count == 0) return;
                ListViewItem item = (ListViewItem)listView2.SelectedItems[0];
                int nrow = item.Index + 1;
                if (nrow >listView2.Items.Count-1) return;
                item.Remove();
                listView2.Items.Insert(nrow, item);
                UpdatePxxh();
            }
            catch (System.Exception ERR)
            {
                MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butqxhz_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView2.SelectedIndices.Count == 0) return;
                ListViewItem item = (ListViewItem)listView2.SelectedItems[0];
                if (MessageBox.Show(this, "您确认要取消["+item.SubItems["姓名"].Text+"]的候诊吗?", "确认", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) return;
                MZHS_FZJL.Delete_Hz(new Guid(item.SubItems["fzid"].Text), InstanceForm.BDatabase);
                item.Remove();
                UpdatePxxh();
            }
            catch (System.Exception ERR)
            {
                MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_PageGotFocus(object sender, EventArgs e)
        {
            try
            {
                int ksdm = Convert.ToInt32(Convertor.IsNull(cmbks.ComboBox.SelectedValue, "0"));
                string ssql = "select dbo.fun_getdeptname(ksdm) 科室,zjmc 诊室,dbo.fun_getempname(zzys) 坐诊医生,dlsj 登陆时间,zjid from jc_zjsz where bdlbz=1 ";
                if (ksdm > 0) ssql = ssql + " and  ksdm=" + ksdm + " ";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                AddListView4(tb);
            }
            catch (System.Exception ERR)
            {
                MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //分诊
        private void butfz_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView2.SelectedIndices.Count == 0) return;
                ListViewItem item = (ListViewItem)listView2.SelectedItems[0];
                Guid ghxxid = new Guid(item.SubItems["ghxxid"].Text);
                int ksdm = Convert.ToInt32(Convertor.IsNull(cmbks.ComboBox.SelectedValue, "0"));
                string ssql = "select dbo.fun_getdeptname(ksdm) 科室,zjmc 诊室,dbo.fun_getempname(zzys) 坐诊医生,dlsj 登陆时间,zjid from jc_zjsz where bdlbz=1 ";
                if (ksdm > 0) ssql = ssql + " and  ksdm=" + ksdm + " ";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                frmfz f = new frmfz(ghxxid, true, tb,new Guid(item.SubItems["fzid"].Text));
                f.ShowDialog();
                if (f.Bok == true) butref2_Click(sender, e);
            }
            catch (System.Exception ERR)
            {
                MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmfzgl_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                listenThread.Abort();
                listenThread = null;
                tcplistener.Stop();
                tcplistener = null;
                
                
            }
            catch 
            {
                //MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedIndices.Count == 0) return;
                ListViewItem item = (ListViewItem)listView1.SelectedItems[0];
                string blh = item.SubItems["门诊号"].Text;
                txtmzh.Text = blh;
                txtkh_KeyPress(sender,new KeyPressEventArgs((char)Keys.Enter));
            }
            catch (System.Exception ERR)
            {
                MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                butref1_Click(sender, e);
            }
            catch (System.Exception err)
            {
            }
        }



    }
}