using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;

namespace ts_mz_kgl
{
    public partial class Frmklxsz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frmklxsz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
        }

        private void Frmklxsz_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            FillData();
        }

        private void FillData()
        {
            //Modify by Kevin 2013-04-03 csje,mzorzy,isycx
            string ssql = "select klx,klxmc,bjebz,bqfgz,bqybz,binput,bmm,mrmm,kcd,xh,id,rtrim(item_name)+'  '+cast(cast(cost_price as float) as varchar(20))+'元' sfxm,csje,mzorzy,isycx from JC_KLX a left join jc_hsitemdiction b  on a.sfxmid=b.item_id order by xh";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            this.dataGridView1.DataSource = tb;
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb.Rows.Count == 0) return;

            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;
            string[] ss = new string[tb.Rows.Count];

            try
            {


                string ssql = "";

                InstanceForm.BDatabase.BeginTransaction();
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    int id = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["id"], "0"));
                    int klx = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["klx"], "0"));
                    string klxmc = tb.Rows[i]["klxmc"].ToString().Trim();
                    int bjebz = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["bjebz"], "0"));
                    int bqfgz = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["bqfgz"], "0"));
                    int bqybz = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["bqybz"], "0"));
                    int bmm = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["bmm"], "0"));
                    string mrmm = tb.Rows[i]["mrmm"].ToString().Trim();
                    int kcd = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["kcd"], "0"));
                    int xh = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["xh"], "0"));
                    int binput = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["binput"], "0"));
                    //Modify by Kevin 2013-04-03
                    //begin
                    decimal csje = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["csje"], "0"));  //初始金额
                    int mzzy = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["mzorzy"], "0"));  //门诊住院
                    int isycx = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["isycx"], "0"));  //是否一次性消费
                    //end

                    if (klx <= 0) throw new Exception("卡类型编码必填");
                    if (klxmc == "") throw new Exception("卡类型名称必填");
                    if (kcd == 0) throw new Exception("卡长度必填");
                    if (xh == 0) throw new Exception("卡排序序号必填");
                    if (bmm == 1 && mrmm == "")
                        throw new Exception("启用密码验证时,默认密码必填");
                    //Modify by Kevin 2013-04-03
                    if (mzzy < 1 && mzzy > 2)  //防止维护人员乱输入数字，造成检索错误
                        throw new Exception("输入的门诊住院数字有误,请重新输入");


                    //Modify by Kevin 2013-04-03 csje,mzorzy,isycx
                    if (id == 0)
                        ssql = "insert into JC_KLX(klx,klxmc,bjebz,bqfgz,bqybz,bmm,mrmm,kcd,xh,binput,csje,mzorzy,isycx)values(" + klx + ",'" + klxmc + "'," + bjebz + "," + bqfgz + "," + bqybz + "," + bmm + ",'" + mrmm + "'," + kcd + "," + xh + "," + binput + ",'" + csje + "'," + mzzy + "," + isycx + ")";
                    else
                        ssql = "update JC_KLX set klx=" + klx + ",klxmc='" + klxmc + "',bjebz=" + bjebz + ",bqfgz=" + bqfgz + ",bqybz=" + bqybz + ",bmm=" + bmm + ",mrmm='" + mrmm + "',kcd=" + kcd + ",xh=" + xh + ",binput=" + binput + ",csje = '" + csje + "',mzorzy = " + mzzy + ",isycx = " + isycx + " where id=" + id + "";
                    InstanceForm.BDatabase.DoCommand(ssql);

                    //三院数据处理
                    ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, "卡类型设置 【" + klxmc + " 】", "jc_klx", "klx", klx.ToString(), InstanceForm._menuTag.Jgbm, -999, "", out log_djid, InstanceForm.BDatabase);
                    ss[i] = log_djid.ToString();
                }
                InstanceForm.BDatabase.CommitTransaction();

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                //三院数据处理
                string msg = "";
                for (int i = 0; i <= ss.Length - 1; i++)
                {
                    if (Convertor.IsNull(ss[i], "") == "") continue;
                    string errtext = "";
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, InstanceForm.BDatabase);
                    if (ty.Bzx == 1)
                    {
                        ts.Pexec_log(new Guid(ss[i]), InstanceForm.BDatabase, out errtext);
                        msg = msg + errtext;
                    }
                }

                MessageBox.Show("保存成功" + msg);
                FillData();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void butdel_Click(object sender, EventArgs e)
        {
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;

            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb.Rows.Count == 0) return;
            int nrow = dataGridView1.CurrentCell.RowIndex;
            if (MessageBox.Show("您确定要删除 [" + Convertor.IsNull(tb.Rows[nrow]["klxmc"], "") + "] 吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;


            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                int id = Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["id"], "0"));
                string ssql = "delete from JC_KLX where id=" + id + "";
                InstanceForm.BDatabase.DoCommand(ssql);


                //三院数据处理
                ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, "删除卡类型:【" + tb.Rows[nrow]["klxmc"].ToString() + "】", "jc_klx", "klx", tb.Rows[nrow]["klx"].ToString(), InstanceForm._menuTag.Jgbm, -999, "", out log_djid, InstanceForm.BDatabase);


                InstanceForm.BDatabase.CommitTransaction();

                dataGridView1.Rows.Remove(dataGridView1.Rows[nrow]);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                //三院数据处理
                string msg = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, InstanceForm.BDatabase);
                if (ty.Bzx == 1 && log_djid != Guid.Empty)
                {
                    ts.Pexec_log(log_djid, InstanceForm.BDatabase, out msg);
                }

                if (msg != "")
                    MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butnew_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            DataRow row = tb.NewRow();
            tb.Rows.Add(row);
            dataGridView1.DataSource = tb;
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["卡类型编码"];
            dataGridView1.Focus();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                if (dataGridView1.CurrentCell.RowIndex != dataGridView1.Rows.Count - 1) return;
                if (dataGridView1.CurrentCell.ColumnIndex + 1 <= dataGridView1.Columns.Count - 1)
                {
                    if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex + 1].Width > 2)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex + 1];
                        return;
                    }
                }
                if (dataGridView1.CurrentCell.ColumnIndex + 1 > dataGridView1.Columns.Count - 2)
                {
                    butnew_Click(sender, e);
                }
            }
        }






    }
}