using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using TrasenClasses.GeneralClasses; 
namespace ts_mzys_blcflr
{
    public partial class FrmZdqc : Form
    {
        public FrmZdqc()
        {
            InitializeComponent();
        }
        public List<ZdModel> list = new List<ZdModel>();
        
        public string strReturn = string.Empty;
        public string strZyReturn = string.Empty;
        public string strZxReturn = string.Empty;
        public string strZdmc = string.Empty;
        public string strZdCode = string.Empty;
        private void btnOk_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        private void FrmZdqc_Load(object sender, EventArgs e)
        {
            dgvList.DataSource = list;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= this.dgvList.Rows.Count - 1; i++)
            {
                if (dgvList.Rows[i].Cells["clXz"].Value == null)
                {
                    if (dgvList.Rows[i].Cells["clZdlx"].Value.ToString() == "D")
                    {
                        strReturn += dgvList.Rows[i].Cells["clZdmc"].Value.ToString() + "|";
                        strZdmc += dgvList.Rows[i].Cells["clZdmc"].Value.ToString() + "|";
                        strZdCode += dgvList.Rows[i].Cells["clZdcode"].Value.ToString() + "|";
                    }
                    else if (dgvList.Rows[i].Cells["clZdlx"].Value.ToString() == "B")
                    {
                        strZyReturn += dgvList.Rows[i].Cells["clZdmc"].Value.ToString() + "|";
                        strZdmc += dgvList.Rows[i].Cells["clZdmc"].Value.ToString() + "|";
                        strZdCode += dgvList.Rows[i].Cells["clZdcode"].Value.ToString() + "|";
                    }
                    else
                    {
                        strZxReturn += dgvList.Rows[i].Cells["clZdmc"].Value.ToString() + "|";
                        strZdmc += dgvList.Rows[i].Cells["clZdmc"].Value.ToString() + "|";
                        strZdCode += dgvList.Rows[i].Cells["clZdcode"].Value.ToString() + "|";
                    }
                }

                else if (dgvList.Rows[i].Cells["clXz"].Value.ToString() == "0")
                {
                    if (dgvList.Rows[i].Cells["clZdlx"].Value.ToString() == "D")
                    {
                        strReturn += dgvList.Rows[i].Cells["clZdmc"].Value.ToString() + "|";
                        strZdmc += dgvList.Rows[i].Cells["clZdmc"].Value.ToString() + "|";
                        strZdCode += dgvList.Rows[i].Cells["clZdcode"].Value.ToString() + "|";
                    }
                    else if (dgvList.Rows[i].Cells["clZdlx"].Value.ToString() == "B")
                    {
                        strZyReturn += dgvList.Rows[i].Cells["clZdmc"].Value.ToString() + "|";
                        strZdmc += dgvList.Rows[i].Cells["clZdmc"].Value.ToString() + "|";
                        strZdCode += dgvList.Rows[i].Cells["clZdcode"].Value.ToString() + "|";
                    }
                    else
                    {
                        strZxReturn += dgvList.Rows[i].Cells["clZdmc"].Value.ToString() + "|"; 
                        strZdmc += dgvList.Rows[i].Cells["clZdmc"].Value.ToString() + "|"; 
                        strZdCode += dgvList.Rows[i].Cells["clZdcode"].Value.ToString() + "|";
                    }
                }
                else
                {
                    continue;
                }
            }
            string strReturnTemp = "";
            string strZyReturnTemp = "";
            string strZxReturnTemp = "";
            string strZdCodeTemp = "";
            string strZdmcTemp = "";
            if (!string.IsNullOrEmpty(strReturn))
                strReturnTemp = strReturn.Remove(strReturn.Length - 1);
            if (!string.IsNullOrEmpty(strZyReturn))
                strZyReturnTemp = strZyReturn.Remove(strZyReturn.Length - 1);
            if (!string.IsNullOrEmpty(strZxReturn))
                strZxReturnTemp = strZxReturn.Remove(strZxReturn.Length - 1);
            if (!string.IsNullOrEmpty(strZdCode))
                strZdCodeTemp = strZdCode.Remove(strZdCode.Length - 1);


            if (Convertor.IsNull(strReturn, "") != "")
                strZdmcTemp += strReturn.Remove(strReturn.Length - 1)+" ";
            if (Convertor.IsNull(strZxReturn, "") != "")
                strZdmcTemp += "证型:" + strZxReturn;
            if (Convertor.IsNull(strZyReturn, "") != "")
                strZdmcTemp += "中医:" + strZyReturn;
            //strZdmcTemp = strZdmc.Remove(strZdmc.Length - 1);

            strReturn = strReturnTemp;
            strZyReturn = strZyReturnTemp;
            strZxReturn = strZxReturnTemp;
            strZdCode = strZdCodeTemp;
            strZdmc = strZdmcTemp;
            this.DialogResult = DialogResult.OK;
            this.Close();
        } 

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dgvList.Rows[e.RowIndex].Cells["clXz"].Value == null) dgvList.Rows[e.RowIndex].Cells["clXz"].Value  = 1;
            else
            {
                if (dgvList.Rows[e.RowIndex].Cells["clXz"].Value.ToString() == "0") dgvList.Rows[e.RowIndex].Cells["clXz"].Value  = 0;
                else  dgvList.Rows[e.RowIndex].Cells["clXz"].Value   = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}