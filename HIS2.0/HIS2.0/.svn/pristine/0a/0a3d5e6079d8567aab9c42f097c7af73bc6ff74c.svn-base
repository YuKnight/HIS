using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ts_Clinicalpathway_Factory
{
   
    public partial class FrmStepselect : Form
    {
        DataTable _tb;
        public string SelectStepid;
        public FrmStepselect(DataTable tb)
        {
            InitializeComponent();
            _tb = tb;
        }
       
        private void FrmStepselect_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < _tb.Rows.Count; i++)
            {
                PublicFunction.Item item = new PublicFunction.Item();
                item.Id = _tb.Rows[i]["PATH_STEP_ID2"].ToString();
                item.Name = _tb.Rows[i]["PATH_STEP_NAME"].ToString();
                if(i==0)
                  this.checkedListBox1.Items.Add(item,true); 
                else
                  this.checkedListBox1.Items.Add(item, false); 
            }
        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
             
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (i != checkedListBox1.SelectedIndex)
                        checkedListBox1.SetItemChecked(i, false);
                    else
                        checkedListBox1.SetItemChecked(i, true);
                }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SelectStepid = ((PublicFunction.Item)this.checkedListBox1.CheckedItems[0]).Id;
            this.Close();
        }

        private void btnqx_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
   
}