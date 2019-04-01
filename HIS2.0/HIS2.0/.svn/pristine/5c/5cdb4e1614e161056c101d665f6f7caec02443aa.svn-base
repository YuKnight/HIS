using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
namespace Ts_Clinicalpathway_Factory
{
    public partial class FrmReasonSet : Form
    {
        public FrmReasonSet()
        {
            InitializeComponent();
            this.toolStripComboBox1.SelectedIndex = 0;
        }
        //实例化一个ErrorProvider
        ErrorProvider errorUser = new ErrorProvider();
        private void FrmReasonSet_Load(object sender, EventArgs e)
        {
            
            DataTable tb = FrmMdiMain.Database.GetDataTable("select id,reason,delete_bit,case when ISNULL(delete_bit,0)=0 then 'false' else 'true' end  as delete_bit1,pym,wmb,Ntype from  Path_UNexe_Reason where Ntype="+(this.toolStripComboBox1.SelectedIndex)+" ");
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = tb;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            for (int i = 0; i<this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.LightBlue;
            }
            //设置其闪烁样式
            //BlinkIfDifferentError 当图标已经显示并且为控件设置了新的错误字符串时闪烁。 
            //AlwaysBlink 总是闪烁。 
            //NeverBlink 错误图标从不闪烁。 
            // errorUser.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;

            //错误图标的闪烁速率（以毫秒为单位）。默认为 250 毫秒
             //errorUser.BlinkRate = 1000;
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.EndEdit();
                this.BindingContext[((DataTable)this.dataGridView1.DataSource)].EndCurrentEdit();
                DataTable temp = ((DataTable)this.dataGridView1.DataSource);
                DataTable tt = temp.GetChanges();
                DataTable tdel = temp.GetChanges(DataRowState.Deleted);
                this.dataGridView1.Rows.Count.ToString();
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (temp.Rows[i].RowState == DataRowState.Deleted)
                        continue;
                    if (temp.Rows[i]["delete_bit1"].ToString() == "false")
                        temp.Rows[i]["delete_bit"] = 0;
                    else
                        temp.Rows[i]["delete_bit"] = 1;
                    if (temp.Rows[i].RowState == DataRowState.Added)
                    {
                        temp.Rows[i]["delete_bit"] = 0;
                        temp.Rows[i]["delete_bit1"] = "false";
                    }
                    if (temp.Rows[i]["pym"].ToString().Trim() == "")
                    {
                        temp.Rows[i]["pym"] = PubStaticFun.GetPYWBM(temp.Rows[i]["reason"].ToString().Trim(), 0);
                        temp.Rows[i]["wmb"] = PubStaticFun.GetPYWBM(temp.Rows[i]["reason"].ToString().Trim(), 1);
                    }
                    temp.Rows[i]["Ntype"] = this.toolStripComboBox1.SelectedIndex;
                    if (temp.Rows[i]["reason"].ToString().Trim() == "")
                        temp.Rows[i].Delete();

                    
                }
                PublicFunction.databaseupdate("select *  from  Path_UNexe_Reason where 1=2", ((DataTable)this.dataGridView1.DataSource));
                ((DataTable)this.dataGridView1.DataSource).AcceptChanges();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                FrmReasonSet_Load(null, null);
                try
                {
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0];
                }
                catch { }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.CurrentCell == null)
                    return;
                int curindex = this.dataGridView1.CurrentCell.RowIndex;
                DataTable temp = ((DataTable)this.dataGridView1.DataSource);
                //temp.Rows[curindex].Delete();
                this.dataGridView1.Rows.RemoveAt(curindex);
                //toolStripButton1_Click(null, null);
                //temp.Rows.RemoveAt(curindex);
            }
            catch { }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //this.dataGridView1.EndEdit();
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= this.dataGridView1.Rows.Count-1)
                return;
            try
            {
                this.dataGridView1.EndEdit();
                this.BindingContext[((DataTable)this.dataGridView1.DataSource)].EndCurrentEdit();
                if (e.ColumnIndex == 0)
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells["拼音码"].Value = PubStaticFun.GetPYWBM(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), 0);
                    this.dataGridView1.Rows[e.RowIndex].Cells["五笔码"].Value= PubStaticFun.GetPYWBM(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), 1);
                }
            }
            catch { }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //try
            //{
            //    ((DataTable)this.dataGridView1.DataSource).Rows[e.RowIndex]["delete_bit"] = 0;
            //    ((DataTable)this.dataGridView1.DataSource).Rows[e.RowIndex]["delete_bit1"] = "true";
            //}
            //catch { }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show("dfdf");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FrmReasonSet_Load(null, null);
        }
      

    }
}