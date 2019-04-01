using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
namespace ts_yj_class
{
    public partial class frmqr : Form
    {

        public RelationalDatabase _DataBase;
        public bool bok = false;
        public frmqr(RelationalDatabase _DB)
        {

            InitializeComponent();
            _DataBase = _DB;

           
        }

        
        private void txtDoctor_KeyPress(object sender, KeyPressEventArgs e)
        { 
            try
            {
                Control ctrl = (Control)sender;
                if ((int)e.KeyChar != 13)
                {
                    if (ctrl.Text == this.txtDoctor.Text)
                    {
                        string[] headText = new string[] { "编码", "姓名", "拼音码", "五笔码","医生代码"};
                        string[] mappName = new string[] { "ID", "NAME", "PY_CODE", "WB_CODE","D_CODE" };
                        int[] colWidth = new int[] { 60, 80, 70, 70, 80 };
                        string[] searchFields = new string[] {  "NAME", "PY_CODE", "WB_CODE","D_CODE" };
                        TrasenFrame.Forms.FrmSelectCard selectCard = new TrasenFrame.Forms.FrmSelectCard(searchFields, headText, mappName, colWidth);
                        selectCard.sourceDataTable = _DataBase.GetDataTable("SELECT DISTINCT EMPLOYEE_ID AS ID,NAME,PY_CODE,WB_CODE,YS_CODE AS D_CODE FROM JC_EMPLOYEE_PROPERTY  WHERE DELETE_BIT=0 AND (RYLX=6 or RYLX=1)");
                        selectCard.WorkForm = this;
                        selectCard.srcControl = txtDoctor;
                        selectCard.Font = txtDoctor.Font;
                        selectCard.Width = 400;
                        selectCard.Left = this.Left;
                        selectCard.Top = this.Top;
                        selectCard.ReciveString = e.KeyChar.ToString();
                        e.Handled = true;
                        selectCard.ShowDialog();
                        if (selectCard.DialogResult == DialogResult.OK)
                        {
                            this.txtDoctor.Text = selectCard.SelectDataRow["NAME"].ToString().Trim();
                            this.txtDoctor.Tag = selectCard.SelectDataRow["ID"].ToString().Trim();
                            this.txtDoctor.Focus();
                        }
                        return;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BTGB_Click(object sender, EventArgs e)
        {
            bok = false;
            this.Close();
           
        }

        private void BTQR_Click(object sender, EventArgs e)
        {
            bok = true;
            this.Close();
        } 
    }
}