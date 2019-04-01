using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using Ts_Visit_Class;

namespace ts_mz_class
{
    public partial class Frmyyjl : Form
    {
        public bool Bok = false;
        public DataRow ReturnRow;
        private string klx = "";
        private string kh = "";
        private string brxm = "";
        public  string ReturnNewKH = "";
 
        //public Guid YYid = Guid.Empty;

        public Frmyyjl(string chineseName,string _klx,string _kh,string _brxm)
        {
            InitializeComponent();
            this.Text = chineseName;
            klx = _klx;
            kh = _kh;
            brxm = _brxm;
            txtkh.Text = "";

            if (kh.Trim() != "")
            {
                cmbklx.SelectedValue = klx;
                txtkh.Text = Fun.returnKh(Convert.ToInt32(klx), kh);
                cmbklx.Enabled = false;
                txtkh.Enabled = false;
            }
            txtyzm.Focus();
            
        }


        private void butok_Click(object sender, EventArgs e)
        {
            ReturnNewKH = txtkh.Text;
            Bok = true;
            this.Close();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            Bok = false ;
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //DataTable tb = (DataTable)dataGridView1.DataSource;
            //int nrow = dataGridView1.CurrentCell.RowIndex;
            //ReturnRow = tb.Rows[nrow];
            //Bok = true;
            //this.Close();
        
            butok_Click_1(sender, e);
        }


        private void Frmghjl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((int)e.KeyChar == 13)
            //{
            //    DataTable tb = (DataTable)dataGridView1.DataSource;
            //    int nrow = dataGridView1.CurrentCell.RowIndex;
            //    if (tb.Rows.Count > 0)
            //    {
            //        ReturnRow = tb.Rows[nrow];
            //        Bok = true;
            //    }
            //    else
            //    {
            //        ReturnRow = null;
            //        Bok = false;
            //    }
            //    this.Close();
            //}
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //DataTable tb = (DataTable)this.dataGridView1.DataSource;
            //if (e.KeyData == Keys.Down)
            //{
                
            //    int i = dataGridView1.Rows.GetNextRow(dataGridView1.CurrentRow.Index, DataGridViewElementStates.None); //获取原选定下一行索引
            //    if (i <= tb.Rows.Count - 1 && i>=0)
            //    {
            //        dataGridView1.CurrentCell = dataGridView1["姓名", i]; //指针下移
            //        dataGridView1.Rows[i].Selected = true; //选中整行
            //    }
            //}
            //if (e.KeyData == Keys.Up)
            //{
            //    int i = dataGridView1.Rows.GetPreviousRow(dataGridView1.CurrentRow.Index, DataGridViewElementStates.None); //获取原选定下一行索引
            //    if (i <= tb.Rows.Count - 1 && i >= 0)
            //    {
            //        dataGridView1.CurrentCell = dataGridView1["姓名", i]; //指针上移
            //        dataGridView1.Rows[i].Selected = true; //选中整行
            //    }
            //}
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            //txtsfzh.Focus();
        }

        private void butquit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butcx_Click(object sender, EventArgs e)
        {
            //Modify by zouchihua 2013-5-9 如果使用公司平台调用另外方式
            if (new SystemCfg(3061).Config.Trim() == "0")
            {
                try
                {
                    int err_code = -1;
                    string err_text = "";
                    DataTable tb = mz_ghxx.YYQH(txtsfzh.Text.Trim(), kh, brxm, txtyzm.Text, "", out err_code, out err_text, TrasenFrame.Forms.FrmMdiMain.Database);
                    dataGridView1.DataSource = tb;
                    if (tb.Rows.Count > 0)
                    {
                        if (txtkh.Enabled == true)
                            txtkh.Focus();
                        else
                            butok.Focus();
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                try
                {
                    int err_code = -1;
                    string err_text = "";
                    int klx = -1;
                    if (!string.IsNullOrEmpty(this.txtkh.Text.Trim()))
                    {
                        kh = this.txtkh.Text.Trim();
                        klx = Convert.ToInt32(this.cmbklx.SelectedValue);
                    }
                    string bdate = DateManager.ServerDateTimeByDBType(TrasenFrame.Forms.FrmMdiMain.Database).ToString("yyyy-MM-dd");
                    //Modify by zp 2014-07-30
                    DataTable tb = Mz_YYgh.GetYYghInfo("", txtsfzh.Text.Trim(), kh, txtyzm.Text, Mz_YYgh.YYgh_Status.未取号记录, "", "", klx, out err_code, out err_text, TrasenFrame.Forms.FrmMdiMain.Database);
                    dataGridView1.DataSource = tb;
                    if (tb.Rows.Count > 0)
                    {
                        if (txtkh.Enabled == true)
                        {

                            txtkh.Focus();
                        }
                        else
                        {
                            butok.Focus();
                        }
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void butok_Click_1(object sender, EventArgs e)
        {
            try
            {
                //if (this.dataGridView1.Rows.Count < 1) { return; }
                //if (this.dataGridView1.SelectedRows.Count < 1) { return; }
                //this.txtkh.Text = Convertor.IsNull(this.dataGridView1.SelectedRows[0].Cells["卡号"].Value, "");
                //if (txtkh.Text.Trim() != "" && txtkh.Enabled == true)
                //{
                //    txtkh.Text = Fun.returnKh(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text);
                //    ReadCard card = new ReadCard(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text, TrasenFrame.Forms.FrmMdiMain.Database);
                //    if (card.kdjid != Guid.Empty)
                //    {
                //        MessageBox.Show(txtkh.Text + "这个卡号已有人使用,请重新确定卡号", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //}

                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (tb == null) return;
                if (tb.Rows.Count > 0)
                {
                    int nrow = dataGridView1.CurrentCell.RowIndex;
                    if (brxm.Trim()!=tb.Rows[nrow]["姓名"].ToString().Trim() && brxm.Trim()!="")
                    {
                        if (MessageBox.Show("预约姓名与当前病人姓名不一致,您确定吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    }

                    if (tb.Rows[nrow]["失效时间"].ToString()!="")
                    {
                        if (DateManager.ServerDateTimeByDBType(TrasenFrame.Forms.FrmMdiMain.Database) > Convert.ToDateTime(tb.Rows[nrow]["失效时间"].ToString()))
                        {
                            MessageBox.Show("该预约申请已失效,不能取号,请确认", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    if (Convert.ToDateTime(DateManager.ServerDateTimeByDBType(TrasenFrame.Forms.FrmMdiMain.Database).ToShortDateString()) > Convert.ToDateTime(Convert.ToDateTime(tb.Rows[nrow]["预约日期"].ToString()).ToShortDateString()))
                    {
                        MessageBox.Show("预约日期不能早于当前挂号时间,可能该预约申请已失效", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    /*限制日期 必须为预约挂号当天 Add by Zp 2013-07-29*/
                    string date = DateManager.ServerDateTimeByDBType(TrasenFrame.Forms.FrmMdiMain.Database).ToString("yyyy-MM-dd");
                    string yydate = Convert.ToDateTime(tb.Rows[nrow]["预约日期"]).ToString("yyyy-MM-dd");
                 
                    //增加时间点判断
                    if (new SystemCfg(3062).Config.Trim()=="1" && tb.Rows[nrow]["预约时点"].ToString().Trim() != "")
                    {
                        try
                        {
                            string[] ss = tb.Rows[nrow]["预约时点"].ToString().Trim().Split('-');
                            DateTime dtq= Convert.ToDateTime(DateManager.ServerDateTimeByDBType(TrasenFrame.Forms.FrmMdiMain.Database));
                       
                            if (date != yydate)
                            {
                                MessageBox.Show("对不起，您预约的日期为【" + tb.Rows[nrow]["预约日期"].ToString().Trim() + "】，必须到预约日期当天才允许取号！！","提示");
                                return;
                            }
                            /*取最后的时间点，判断与当前日志做判断 Modify By zp 2013-08-07
                             新增参数1103 限制需要提前制定分钟取号 否则作废预约记录并释放挂号资源
                             */
                            DateTime _d = Convert.ToDateTime(ss[0]); //预约时间
                            double xhfz=Convert.ToDouble((new SystemCfg(1103)).Config); //得到需提前取号的分钟数
                            DateTime xzsj = dtq.AddMinutes(xhfz);//得到最后取号时间值
 
                            if (_d < xzsj) //如果取号时间小于最后取号时间 则不允许取号 并释放限号资源
                            {
                                int _ghks = Convert.ToInt32(tb.Rows[nrow]["ghks"]);
                                int _ghjb = Convert.ToInt32(tb.Rows[nrow]["ghjb"]);
                                int _ghys = Convert.ToInt32(tb.Rows[nrow]["ghys"]);
                                Ts_Visit_Class.VisitResource _VisRes = new VisitResource(_ghks, _ghjb, _ghys, yydate, TrasenFrame.Forms.FrmMdiMain.Database);

                                FsdClass _Fsd =null;
                                if (new SystemCfg(1099).Config.Trim() == "1" && _VisRes.Resid > 0 && _d > dtq)
                                {
                                    _Fsd = new FsdClass(tb.Rows[nrow]["预约时点"].ToString().Trim(), yydate, _VisRes.Resid, TrasenFrame.Forms.FrmMdiMain.Database);
                                    _Fsd.Save(ref _Fsd, true, TrasenFrame.Forms.FrmMdiMain.Database); 
                                }
                                MessageBox.Show("对不起，您预约的时间段为【" + tb.Rows[nrow]["预约时点"].ToString().Trim() + "】,当前时间已超时!需在" + _d.AddMinutes(-xhfz) + "前取号！！", "提示");
                                return;
                            }

                        }
                        catch
                        {
                        }

                    }
                    //Add by zp 2014-07-30 对资源释放的记录进行判断 给予提示
                    if (tb.Rows[nrow]["删除标记"].ToString().Trim() == "1")
                    {
                        MessageBox.Show("选择的预约记录已作废!", "提示");
                        return;
                    }
                    ReturnRow = tb.Rows[nrow];
            
                    ReturnNewKH = Convertor.IsNull(this.dataGridView1.SelectedRows[0].Cells["卡号"].Value, "");
                    Bok = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("没有可选择的预约记录,请确认", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtsfzh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar==13)
                butcx_Click(sender, e);
        }

        private void Frmyyjl_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            FunAddComboBox.AddKlx(false, 0, cmbklx, TrasenFrame.Forms.FrmMdiMain.Database);
            txtyzm.Focus();

            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard("", cmbklx, txtkh);
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                txtkh.Text = Fun.returnKh(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text);
                this.butcx_Click(null, null);
               
            }
        }

        private void Frmyyjl_Activated(object sender, EventArgs e)
        {
            txtyzm.Focus();
        }


    }
}
