using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;

namespace ts_mz_kgl
{
    public partial class Frmbrxxcx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Guid return_kdjid = Guid.Empty;
        public Guid return_brxxid = Guid.Empty;
        public bool bok = false;
        public SystemCfg cfg1161 = new SystemCfg(1161);//Add By chencan 150108 启用卡单据使用。

        public Frmbrxxcx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            if (mdiParent != null)
                this.WindowState = FormWindowState.Maximized;

            if (InstanceForm.BDatabase == null)
                InstanceForm.BDatabase = TrasenFrame.Forms.FrmMdiMain.Database;

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void dtpfkrq2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Frmbrxxcx_Load(object sender, EventArgs e)
        {
            FunAddComboBox.AddBrlx(true, 0, cmbbrlx, InstanceForm.BDatabase);
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            FunAddComboBox.AddOperator(true, cmbdjy, InstanceForm.BDatabase);
            FunAddComboBox.AddYblx(true, 0, cmbcblx, InstanceForm.BDatabase);
            FunAddComboBox.AddGj(true, cmbgj, InstanceForm.BDatabase);
            FunAddComboBox.AddMz(true, cmbmz, InstanceForm.BDatabase);
            // chkdjsj.Checked = true;

            dtpcsrq1.Value = dtpcsrq1.Value.AddYears(-1);

            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);

            //150108 chencan/ 右键菜单添加“诊疗卡打印”
            if (cfg1161.Config == "1")
            {
                ToolStripMenuItem menuprint = new ToolStripMenuItem();
                menuprint.Text = "重打条码单";
                menuprint.Click+=new EventHandler(menuprint_Click);
                this.contextMenuStrip1.Items.Add(menuprint);
            }
        }

        private void butcx_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtkh.Text.Trim() == "" && txtbrxm.Text.Trim() == ""
                    && txtbrlxfs.Text.Trim() == "" && txtsfzh.Text.Trim() == "" && txtcsdz.Text.Trim() == "" &&
                        txtjtdz.Text.Trim() == "" && txtgzdw.Text.Trim() == "" && chkcsrq.Checked == false
                && chkdjsj.Checked == false)
                {
                    MessageBox.Show("检索的范围太大,请选择条件", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ParameterEx[] parameters = new ParameterEx[18];

                parameters[0].Text = "@klx";
                parameters[0].Value = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));

                parameters[1].Text = "@kh";
                parameters[1].Value = txtkh.Text.Trim();

                parameters[2].Text = "@brxm";
                parameters[2].Value = txtbrxm.Text.Trim();

                parameters[3].Text = "@BRLXFS";
                parameters[3].Value = txtbrlxfs.Text.Trim();

                parameters[4].Text = "@BRLX";
                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbbrlx.SelectedValue, "0")); ;

                parameters[5].Text = "@gj";
                parameters[5].Value = cmbgj.Text.Trim();

                parameters[6].Text = "@mz";
                parameters[6].Value = cmbmz.Text.Trim();

                parameters[7].Text = "@sfzh";
                parameters[7].Value = txtsfzh.Text.Trim();

                parameters[8].Text = "@cblx";
                parameters[8].Value = Convert.ToInt32(Convertor.IsNull(cmbcblx.SelectedValue, "0")); ;

                parameters[9].Text = "@zy";
                parameters[9].Value = txtzy.Text.Trim();

                parameters[10].Text = "@csdz";
                parameters[10].Value = txtcsdz.Text.Trim();

                parameters[11].Text = "@jtdz";
                parameters[11].Value = txtjtdz.Text.Trim();

                parameters[12].Text = "@gzdw";
                parameters[12].Value = txtgzdw.Text.Trim();

                parameters[13].Text = "@DJSJ1";
                parameters[13].Value = chkdjsj.Checked == true ? dtpdjsj1.Value.ToShortDateString() + " 00:00:00" : "";

                parameters[14].Text = "@DJSJ2";
                parameters[14].Value = chkdjsj.Checked == true ? dtpdjsj2.Value.ToShortDateString() + " 23:59:59" : "";

                parameters[15].Text = "@CSRQ1";
                parameters[15].Value = chkcsrq.Checked == true ? dtpcsrq1.Value.ToShortDateString() + " 00:00:00" : "";

                parameters[16].Text = "@CSRQ2";
                parameters[16].Value = chkcsrq.Checked == true ? dtpcsrq2.Value.ToShortDateString() + " 23:59:59" : "";

                parameters[17].Text = "@djy";
                parameters[17].Value = Convertor.IsNull(cmbdjy.SelectedValue, "0");

                DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("SP_MZSF_CX_BRXX", parameters, 30);

                Fun.AddRowtNo(tb);
                this.dataGridView1.DataSource = tb;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butnew_Click(object sender, EventArgs e)
        {
            Frmbrkdj frm = new Frmbrkdj(_menuTag, _chineseName, MdiParent, Guid.Empty, Guid.Empty);
            frm.ShowDialog();

            chkdjsj.Checked = true;
            butcx_Click(sender, e);

        }

        private void mnubrxx_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                if (tb == null) return;
                if (tb.Rows.Count == 0 || tb == null) return;
                int nrow = this.dataGridView1.CurrentCell.RowIndex;
                //Modify by Zj 2012-08-20 排序以后不能采用数据源的当前行 代码改为 datagridview的当前行
                //Guid kdjid = new Guid(Convertor.IsNull(tb.Rows[nrow]["kdjid"], Guid.Empty.ToString()));
                //Guid brxxid = new Guid(Convertor.IsNull(tb.Rows[nrow]["brxxid"], Guid.Empty.ToString()));

                Guid kdjid = new Guid(Convertor.IsNull(dataGridView1.CurrentRow.Cells["kdjid"].Value.ToString(), Guid.Empty.ToString()));
                Guid brxxid = new Guid(Convertor.IsNull(dataGridView1.CurrentRow.Cells["brxxid"].Value.ToString(), Guid.Empty.ToString()));


                Frmbrkdj frm = new Frmbrkdj(_menuTag, _chineseName, MdiParent, brxxid, kdjid);
                frm.ShowDialog();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnujzxx_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                if (tb == null) return;
                if (tb.Rows.Count == 0) return;
                int nrow = this.dataGridView1.CurrentCell.RowIndex;
                Guid kdjid = new Guid(Convertor.IsNull(tb.Rows[nrow]["kdjid"], Guid.Empty.ToString()));
                Guid brxxid = new Guid(Convertor.IsNull(tb.Rows[nrow]["brxxid"], Guid.Empty.ToString()));
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile( AppDomain.CurrentDomain.BaseDirectory + "ts_mzys_blcflr.dll" );
                object obj = assembly.CreateInstance( "ts_mzys_blcflr.InstanceForm" );
                
                obj.GetType().GetProperty( "Database" ).SetValue( obj , InstanceForm.BDatabase , null );
                obj.GetType().GetProperty( "CurrentDept" ).SetValue( obj , InstanceForm.BCurrentDept , null );
                obj.GetType().GetProperty( "CurrentUser" ).SetValue( obj , InstanceForm.BCurrentUser , null );
                object objForm = assembly.CreateInstance( "ts_mzys_blcflr.Frmblcf_cx" , true , System.Reflection.BindingFlags.CreateInstance ,
                    null , new object[] { _menuTag , "病历处方历史查询" , _mdiParent , brxxid , Guid.Empty }, null , null );
                ( (Form)objForm ).ShowDialog();
                
                //ts_mzys_blcflr.InstanceForm.BDatabase = InstanceForm.BDatabase;
                //ts_mzys_blcflr.InstanceForm.BCurrentDept = InstanceForm.BCurrentDept;
                //ts_mzys_blcflr.InstanceForm.BCurrentUser = InstanceForm.BCurrentUser;
                //ts_mzys_blcflr.Frmblcf_cx f = new ts_mzys_blcflr.Frmblcf_cx(_menuTag, "病历处方历史查询", _mdiParent, brxxid, Guid.Empty);
                //f.ShowDialog();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuprint_Click(object sender, EventArgs e)
        {
            if ( this.dataGridView1.CurrentCell == null )
                return;
            DataRow row = ( (DataRowView)this.dataGridView1.CurrentRow.DataBoundItem ).Row;
            string barCode = Convertor.IsNull( row["卡号"] , "" );
            if ( !string.IsNullOrEmpty( barCode ) )
                C_CardManager.M_PrintCard( barCode );
            else
                MessageBox.Show( "无条码卡可打印" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
           
        }

        private void chkdjsj_CheckedChanged(object sender, EventArgs e)
        {
            dtpdjsj1.Enabled = chkdjsj.Checked == true ? true : false;
            dtpdjsj2.Enabled = chkdjsj.Checked == true ? true : false;
        }

        private void chkcsrq_CheckedChanged(object sender, EventArgs e)
        {
            dtpcsrq1.Enabled = chkcsrq.Checked == true ? true : false;
            dtpcsrq2.Enabled = chkcsrq.Checked == true ? true : false;
        }

        private void txtzy_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "名称", "编码", "拼音码", "五笔码" };
                string[] mappingname = new string[] { "name", "code", "py_code", "wb_code" };
                string[] searchfields = new string[] { "name", "code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 70, 70, 70 };
                DataTable Tb = InstanceForm.BDatabase.GetDataTable("select code,name,py_code,wb_code from JC_OCCUPATI");
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tb;
                f.WorkForm = this;
                f.srcControl = control;
                //f.Font = control.Font;
                f.Width = 400;
                f.Left = txtzy.Left;
                f.Top = txtzy.Top + txtzy.Height;
                f.ReciveString = e.KeyChar.ToString();

                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    txtzy.Text = f.SelectDataRow["name"].ToString().Trim();
                    txtzy.Focus();

                    SendKeys.Send("{TAB}");
                }
            }
            else
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                txtkh.Text = Fun.returnKh(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text, InstanceForm.BDatabase);
        }

        private void Frmbrxxcx_Activated(object sender, EventArgs e)
        {
            if (_menuTag.Function_Name == "Fun_ts_mz_kgl_kdj")
            {

                cmbdjy.SelectedValue = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId.ToString();
            }
            else
                butnew.Visible = false;
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmbrxxcx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && butnew.Enabled == true)
            {
                butnew_Click(sender, e);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_chineseName != "病人查询") return;
                if (dataGridView1.Rows.Count == 0) return;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                return_brxxid = new Guid(tb.Rows[nrow]["brxxid"].ToString());
                return_kdjid = new Guid(Convertor.IsNull(tb.Rows[nrow]["kdjid"].ToString(), Guid.Empty.ToString()));
                bok = true;
                this.Close();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar != 13) return;

            if (control.Name == "txtkh" && control.Text.Trim() != "")
            {
                txtkh.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text, InstanceForm.BDatabase);
                butcx_Click(sender, null);
            }

            if (control.Name == "txtbrxm" && control.Text.Trim() != "")
            {
                butcx_Click(sender, null);
            }

            SendKeys.Send("{TAB}");
            return;

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                if (Convertor.IsNull(dgv.Cells["卡状态"].Value, "") == "作废")
                {
                    dgv.DefaultCellStyle.ForeColor = Color.Red;
                }
                if (Convertor.IsNull(dgv.Cells["卡状态"].Value, "") == "挂失")
                {
                    dgv.DefaultCellStyle.ForeColor = Color.DimGray;
                }
                if (Convertor.IsNull(dgv.Cells["卡状态"].Value, "") == "冻结")
                {
                    dgv.DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string swhere = "";
            if (chkdjsj.Checked)
                swhere += "登记时间：" + this.dtpdjsj1.Value.ToString() + " 到:" + dtpdjsj2.Value.ToString();
            if (chkcsrq.Checked)
                swhere += "  出生日期：" + this.dtpcsrq1.Value.ToString() + " 到:" + dtpcsrq2.Value.ToString();
            ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, Constant.HospitalName + " 病人信息统计", swhere, true, true, false, false);
            
        }




    }
}