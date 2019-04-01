using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
namespace ts_DocGroup
{
    public partial class FrmDocGroupListModify : Form
    {
        public FrmDocGroupListModify()
        {
            InitializeComponent();
        }
        private string strGroupID;
        private FrmDocGroupList frmTemp = new FrmDocGroupList();
        private string strGroupName;
        public FrmDocGroupListModify(string strTempGroupID,FrmDocGroupList frm,string tempGroupName)
        {
            InitializeComponent();
            strGroupID = strTempGroupID;
            frmTemp = frm;
            strGroupName = tempGroupName;
        }
        private void FrmDocGroupListModify_Load(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.RowStyles[1].Height = 0;
            txtDoc.Text = strGroupName;
            BingData();
        }

        private void BingData()
        {
            string strSql = string.Format(@"SELECT  c.NAME AS DocName ,
                                                                        c.PY_CODE,
                                                                        c.WB_CODE,
                                                                        c.EMPLOYEE_ID
                                                                        ,a.GroupID
                                                           FROM    TS_DOCGROUPMANAGE a
                                                                        INNER JOIN dbo.JC_ROLE_DOCTOR b ON a.DocId = b.EMPLOYEE_ID
                                                                        INNER JOIN dbo.JC_EMPLOYEE_PROPERTY c ON b.EMPLOYEE_ID = c.EMPLOYEE_ID  
                                                          WHERE   a.GroupID ={0}", strGroupID);
            DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
            this.dgvList.DataSource = dt; 
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvList.Rows)
            {
                if (row.Index != e.RowIndex)
                    row.Cells["clSelect"].Value = 0;
            }
            if (this.dgvList.Rows[e.RowIndex].Cells["clSelect"].Value == null) this.dgvList.Rows[e.RowIndex].Cells["clSelect"].Value = "1";

            if (this.dgvList.Rows[e.RowIndex].Cells["clSelect"].Value.ToString() == "0")
                this.dgvList.Rows[e.RowIndex].Cells["clSelect"].Value = "1";
            else
                this.dgvList.Rows[e.RowIndex].Cells["clSelect"].Value = "0";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("ÄúÕæµÄÒªÉ¾³ýÂð£¿", "´ËÉ¾³ý²»¿É»Ö¸´", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string DocId = string.Empty;
                    string GroupID = string.Empty;
                    foreach (DataGridViewRow row in this.dgvList.Rows)
                    {
                        if (row.Cells["clSelect"].Value.ToString() == "1")
                        {
                            DocId = row.Cells["clDocId"].Value.ToString();
                            GroupID = row.Cells["clGoupID"].Value.ToString();
                        }
                    }
                    string strSql = string.Format(@"DELETE TS_DOCGROUPMANAGE WHERE GroupID={0} and DocId={1}", GroupID, DocId);
                    FrmMdiMain.Database.DoCommand(strSql.ToString());
                    BingData();
                }
            }
            catch
            {
                MessageBox.Show("É¾³ýÊ§°Ü");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.RowStyles[1].Height = 47;
            this.txtDept.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text)) return;
            string strSql = string.Format(@"INSERT INTO TS_DOCGROUPMANAGE VALUES({0},{1})", strGroupID, textBox1.Tag);
            FrmMdiMain.Database.DoCommand(strSql.ToString());
            BingData();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            textBox1.Tag = null;
            textBox1.Text = null;
            this.tableLayoutPanel1.RowStyles[1].Height = 0;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (this.txtDept.Tag == null)
            {
                MessageBox.Show("ÇëÑ¡Ôñ¿ÆÊÒ"); 
                this.txtDept.Focus(); 
                return;
            }
            ks_select(sender, e);
            btnSave.Focus();
        }
        private void ks_select(object sender, KeyPressEventArgs e)
        {
            try
            {
                string sqlYS = string.Format(@"SELECT  b.NAME AS DocName ,
                                                                            b.PY_CODE ,
                                                                            b.WB_CODE ,
                                                                            b.EMPLOYEE_ID
                                                               FROM    JC_ROLE_DOCTOR a
                                                                            INNER JOIN JC_EMPLOYEE_PROPERTY b ON a.EMPLOYEE_ID = b.EMPLOYEE_ID
                                                                            INNER JOIN dbo.JC_EMP_DEPT_ROLE c ON a.EMPLOYEE_ID = c.EMPLOYEE_ID
                                                             WHERE   a.DOC_ID NOT IN ( SELECT    TS_DOCGROUPMANAGE.DocId
                                                            FROM      TS_DOCGROUPMANAGE
                                                            WHERE     GroupID = {0} )  AND c.DEPT_ID = {1}", strGroupID,this.txtDept.Tag);

                 DataTable dtYLFL = FrmMdiMain.Database.GetDataTable(sqlYS);
                if ((int)e.KeyChar == 8 || (int)e.KeyChar == 46)
                {
                    textBox1.Text = "";
                    textBox1.Tag = "";
                    return;
                }

                Control control = (Control)sender;
                if ((int)e.KeyChar != 13)
                {
                    string[] headtext = new string[] { "Ò½Ê¦Ãû³Æ", "Æ´ÒôÂë", "Îå±ÊÂë", "±àºÅ", };
                    string[] mappingname = new string[] { "DocName", "PY_CODE", "WB_CODE", "EMPLOYEE_ID" };
                    string[] searchfields = new string[] { "PY_CODE", "WB_CODE" };
                    int[] colwidth = new int[] { 100, 80, 80, 1 };
                    using (FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth))
                    {
                        f.sourceDataTable = dtYLFL;
                        f.WorkForm = this;
                        f.srcControl = textBox1;
                        f.Font = textBox1.Font;
                        f.Width = 350;
                        f.ReciveString = e.KeyChar.ToString();
                        e.Handled = true;
                        if (f.ShowDialog() == DialogResult.Cancel)
                        {
                            textBox1.Focus();
                            return;
                        }
                        else
                        {
                            textBox1.Text = f.SelectDataRow["DocName"].ToString().Trim();
                            textBox1.Tag = f.SelectDataRow["EMPLOYEE_ID"].ToString();
                            e.Handled = true;
                        }
                    }
                }
            }
            catch { 
                textBox1.Focus(); 
            } 
        }

        private void ks_selectDept(object sender, KeyPressEventArgs e)
        {
            try
            {
                string sqlYS = string.Format(@"SELECT  NAME ,
                                                                            PY_CODE ,
                                                                            WB_CODE ,
                                                                            DEPT_ID
                                                               FROM    dbo.JC_DEPT_PROPERTY
                                                              WHERE   P_DEPT_ID != 0
                                                                            AND P_DEPT_ID != 1");

                DataTable dtYLFL = FrmMdiMain.Database.GetDataTable(sqlYS);
                if ((int)e.KeyChar == 8 || (int)e.KeyChar == 46)
                {
                    textBox1.Text = "";
                    textBox1.Tag = "";
                    return;
                }

                Control control = (Control)sender;
                if ((int)e.KeyChar != 13)
                {
                    string[] headtext = new string[] { "¿ÆÊÒÃû³Æ", "Æ´ÒôÂë", "Îå±ÊÂë", "±àºÅ", };
                    string[] mappingname = new string[] { "NAME", "PY_CODE", "WB_CODE", "DEPT_ID" };
                    string[] searchfields = new string[] { "PY_CODE", "WB_CODE" };
                    int[] colwidth = new int[] { 100, 80, 80, 1 };
                    using (FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth))
                    {
                        f.sourceDataTable = dtYLFL;
                        f.WorkForm = this;
                        f.srcControl = txtDept;
                        f.Font = txtDept.Font;
                        f.Width = 350;
                        f.ReciveString = e.KeyChar.ToString();
                        e.Handled = true;
                        if (f.ShowDialog() == DialogResult.Cancel)
                        {
                            txtDept.Focus();
                            return;
                        }
                        else
                        {
                            txtDept.Text = f.SelectDataRow["NAME"].ToString().Trim();
                            txtDept.Tag = f.SelectDataRow["DEPT_ID"].ToString();
                            e.Handled = true;
                        }
                    }
                }
            }
            catch
            {
                txtDept.Focus();
            }
        }

        private void txtDept_KeyPress(object sender, KeyPressEventArgs e)
        { 
            ks_selectDept(sender, e);
            this.textBox1.Focus();
        }
    }
}