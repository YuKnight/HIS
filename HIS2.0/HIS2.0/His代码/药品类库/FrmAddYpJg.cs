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

namespace YpClass
{
    public partial class FrmAddYpJg : Form
    {
        public  int ReturnCjid = 0;
        int _cjid = 0;
        RelationalDatabase _DataBase;
        int _employee_id = 0;
        int _deptid = 0;
        public FrmAddYpJg(int employee_id, int deptid, int cjid, RelationalDatabase DataBase)
        {
            InitializeComponent();

            _cjid = cjid;
            _DataBase = DataBase;
            Ypcj cj = new Ypcj(cjid, DataBase);
            lblpm.Text = cj.S_YPPM;
            lblspm.Text = cj.S_YPSPM;
            lblgg.Text = cj.S_YPGG;
            txtsccj.Text = cj.S_SCCJ;
            txtsccj.Tag = cj.SCCJ;
            lbldw.Text = cj.S_YPDW;

            _employee_id = employee_id;
            _deptid = deptid;

            FillYP(cj.SCCJ, cj.GGID);

            SystemCfg cfg = new SystemCfg(8028);
            if (cfg.Config == "0")
            {
                txtpfj.Enabled = false;
                txtlsj.Enabled = false;
                txtsccj.Enabled = false;
                butsave.Enabled = false;
            }
            if (cfg.Config == "1")
            {
                txtsccj.Enabled = false;
            }
           
        }

        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                this.SelectNextControl(control, true, false, true, true);
            }
        }


        public void FillYP(int sccj,int ggid)
        {
            string ssql = "select 0 序号,s_sccj 厂家,pfj 批发价,lsj 零售价,cast(bdelete as smallint) 停用,djsj 登记时间 " +
                " from yp_ypcjd where ggid=" + ggid + " ";
            if (sccj > 0)
                ssql = ssql + " and sccj=" + sccj + "";
            DataTable tb = _DataBase.GetDataTable(ssql);
            FunBase.AddRowtNo(tb);
            dataGridView1.DataSource = tb;
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            if (Convertor.IsNumeric(txtpfj.Text) == false)
            {
                MessageBox.Show("请输入批发价", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convertor.IsNumeric(txtlsj.Text) == false)
            {
                MessageBox.Show("请输入零售价", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToDecimal(txtpfj.Text) == 0)
            {
                if (MessageBox.Show("批发价为零您确认吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }
            if (Convert.ToDecimal(txtlsj.Text) == 0)
            {
                if (MessageBox.Show("零售价为零您确认吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }

            //药品所在服务器的链接
            string ssql = "select * from pub_menu where function_name='Fun_ts_yp_ypcd'";
            DataTable tbcd = _DataBase.GetDataTable(ssql);
            int cd_jgbm = Convert.ToInt32(tbcd.Rows[0]["jgbm"]);
            if (cd_jgbm == -1) cd_jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
            RelationalDatabase database = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(cd_jgbm);

            int Newcjid = 0;
            int err_code = 0;
            string err_text = "";

            Ypcj cj = new Ypcj(_cjid, database);

            ssql = "select * from yp_ypcjd where ggid="+cj.GGID+" and sccj="+Convertor.IsNull(txtsccj.Tag,"0")+" and lsj="+Math.Round(Convert.ToDecimal(txtlsj.Text),2)+" ";
            DataTable tb = database.GetDataTable(ssql);
            if (tb.Rows.Count >= 1 )
            {
                if (Convert.ToInt16(tb.Rows[0]["bdelete"]).ToString() == "1")
                {
                    if (MessageBox.Show("该价格的药品在词典中已存在,但已停用,您要启用吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                    Guid log_djid_x = Guid.Empty;
                    ts_HospData_Share.ts_update_log ts_x = new ts_HospData_Share.ts_update_log();

                    try
                    {
                        database.BeginTransaction();
                        ssql = "update yp_ypcjd set bdelete=0 where cjid=" + tb.Rows[0]["cjid"].ToString() + " ";
                        database.DoCommand(ssql);

                        ssql = "update yp_ypggd set bdelete=0 where ggid=" + tb.Rows[0]["ggid"].ToString() + " ";
                        database.DoCommand(ssql);

                        //三院数据处理
                        ts_x.Save_log(ts_HospData_Share.czlx.yp_药品字典修改, TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name + "对药品【" + cj.S_YPPM + " " + cj.S_YPGG + "  " + cj.S_SCCJ + " 】 进行修改", "yp_ypcjd", "cjid", cj.CJID.ToString(), cd_jgbm, 0, "", out log_djid_x, database);
                        database.CommitTransaction();
                    }
                    catch (System.Exception err)
                    {
                        database.RollbackTransaction();
                        MessageBox.Show("启用时出错"+err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (log_djid_x!=Guid.Empty)
                        ts_x.Pexec_log(log_djid_x, database, out err_text);

                    ReturnCjid = Convert.ToInt32(tb.Rows[0]["cjid"]);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("词典中已存在相同厂家和价格的药品,不能重复添加","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }


            Guid log_djid = Guid.Empty;
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();

            try
            {
                database.BeginTransaction();
               
                Ypcj newcj = new Ypcj();
                newcj = cj;
                newcj.CJID = 0;
                newcj.PFJ = Convert.ToDecimal(txtpfj.Text);
                newcj.LSJ = Convert.ToDecimal(txtlsj.Text);
                newcj.SCCJ =Convert.ToInt32( Convertor.IsNull(txtsccj.Tag, "0"));
                newcj.S_SCCJ = txtsccj.Text.Trim();
                newcj.MRJJ = 0;
                newcj.CJBDELETE = false;
                newcj.CJDJSJ = DateManager.ServerDateTimeByDBType(database).ToString();

               

                newcj.SaveCJ(out Newcjid, out err_code, out err_text, database);
                if (err_code != 0) throw new Exception(err_text);


                //更新药品货号
                newcj.Update_shh(newcj.GGID, out err_code, out err_text, database);
                if (err_code != 0) throw new Exception(err_text);

                //三院数据处理
                ts.Save_log(ts_HospData_Share.czlx.yp_药品字典修改, TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name + "新增【" + newcj.S_YPPM + " " + newcj.S_YPGG + "  " + newcj.S_SCCJ + " 】 价格:" + txtlsj.Text.Trim() + "", "yp_ypcjd", "cjid", Newcjid.ToString(), cd_jgbm, 0, "", out log_djid, database);


                database.CommitTransaction();


                
            }
            catch (System.Exception err)
            {
                database.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (log_djid != Guid.Empty)
            {
                ts.Pexec_log(log_djid, database, out err_text);

                this.Cursor = TrasenClasses.GeneralClasses.PubStaticFun.WaitCursor();
                System.Threading.Thread.Sleep(2 * 5000);
            }


            
            ReturnCjid = Newcjid;
            this.Close();

        }

        private void txtsccj_KeyUp(object sender, KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convertor.IsNull(control.Tag, "0") == "0" || Convertor.IsNull(control.Tag, "0") == "")))
            {
            }
            else
            {
                return;
            }

            Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 2);
            string ssql = "";
            if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
            Yp.frmShowCard(sender, ShowCardType.厂家,0, point,_deptid ,_DataBase);
            if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
            
            Ypcj cj=new Ypcj(_cjid,_DataBase);
            FillYP(0, cj.GGID);

            txtpfj.Focus();
            txtpfj.SelectAll();

        }


    }
}