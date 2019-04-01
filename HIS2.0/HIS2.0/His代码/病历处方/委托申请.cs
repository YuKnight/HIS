using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using System.Data.OleDb;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_mz_class;

namespace ts_mzys_blcflr
{
    public partial class Frmwtsqcx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private Guid ghxxid = Guid.Empty;
        private Guid brxxid = Guid.Empty;
        public bool Bload = false;
        public Frmwtsqcx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void btref_Click(object sender, EventArgs e)
        {
            try
            {

                ParameterEx[] parameters = new ParameterEx[8];
                parameters[0].Text = "@KLX";
                parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue,"0"));

                parameters[1].Text = "@kh";
                parameters[1].Value =txtkh.Text;

                parameters[2].Text = "@BRXM";
                parameters[2].Value =txtxm.Text.Trim();

                parameters[3].Text = "@BLH";
                parameters[3].Value = txtmzh.Text.Trim();

                parameters[4].Text = "@DJSJ1";
                parameters[4].Value = dtp1.Value.ToShortDateString()+" 00:00:00";

                parameters[5].Text = "@DJSJ2";
                parameters[5].Value = dtp2.Value.ToShortDateString() + " 23:59:59";

                parameters[6].Text = "@EXECDEPT";
                parameters[6].Value = InstanceForm.BCurrentDept.DeptId;

                parameters[7].Text = "@jgbm";
                parameters[7].Value = Convert.ToInt64(cmbjgbm.SelectedValue);

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZYS_SELECT_WTCX", parameters, 30);
                ts_mz_class.Fun.AddRowtNo(tb);

                dataGridView1.DataSource = tb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void Frmyjqr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Cursor.Current = PubStaticFun.WaitCursor();
                btref_Click(sender, e);
                Cursor.Current = Cursors.Default;
            }


        }

        private void buthelp_Click(object sender, EventArgs e)
        {
            try
            {

                MenuTag tag = new MenuTag();
                tag = _menuTag;
                ts_mz_kgl.Frmbrxxcx f = new ts_mz_kgl.Frmbrxxcx(tag, "病人查询", null);
                f.txtbrxm.Text = txtxm.Text;
                if (txtxm.Text.Trim() == "")
                    f.chkdjsj.Checked = true;
                f.txtbrxm.Focus();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();



                ReadCard card = new ReadCard(f.return_kdjid, InstanceForm.BDatabase);
                txtkh.Text = card.kh.Trim();
                cmbklx.SelectedValue = card.klx.ToString();
                txtkh_KeyPress(sender,new KeyPressEventArgs((Char)Keys.Enter));

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 13) return;
            Control control = (Control)sender;
            if (control.Name == "txtkh")
            {
                txtkh.Text = ts_mz_class.Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
                txtkh.SelectAll();
            }
            if (control.Name  == "txtmzh")
            {
                txtmzh.Text = ts_mz_class.Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
            }
            btref_Click(sender, e);
        }

        private void Frmyjqr_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ts_mz_class.FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            ts_mz_class.FunAddComboBox.AddJgbm(false, cmbjgbm, InstanceForm.BDatabase);

            Bload = true;
            cmbjgbm.SelectedValue = InstanceForm._menuTag.Jgbm;

            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
        }


        private void cmbjgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Bload==true)
                {
                InstanceForm.BDatabase = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(cmbjgbm.SelectedValue));

                btref_Click(sender, e);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb == null) return;
            if (tb.Rows.Count == 0) return;
            int nrow = dataGridView1.CurrentCell.RowIndex;

            int sqks = Convert.ToInt32(tb.Rows[nrow]["sqks"]);
            int sqys = Convert.ToInt32(tb.Rows[nrow]["sqys"]);
            string blh = Convert.ToString(tb.Rows[nrow]["门诊号"]);

            Frmblcf frm=new Frmblcf(_menuTag,_chineseName,_mdiParent,new Employee(sqys,InstanceForm.BDatabase),new Department(sqks,InstanceForm.BDatabase),blh);
            if (_mdiParent != null)
            {
                frm.MdiParent = _mdiParent;
            }
            frm.Show();
            frm.txtmzh_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
        }



    }
}