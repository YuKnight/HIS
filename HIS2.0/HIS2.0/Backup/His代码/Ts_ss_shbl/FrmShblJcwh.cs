using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace Ts_ss_shbl
{
    public partial class FrmShblJcwh : Form
    {
        public FrmShblJcwh()
        {
            InitializeComponent();
        }

        private void FrmShblJcwh_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.ComboBox.ValueMember = "TYPE";
            toolStripComboBox1.ComboBox.DisplayMember=  "TYPENAME";
            DataTable tb = FrmMdiMain.Database.GetDataTable("select TYPE,TYPENAME from ss_ShblJcsj group by TYPE,TYPENAME");
            toolStripComboBox1.ComboBox.DataSource = tb;
            toolStripComboBox1.ComboBox.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            ComboBox_SelectedIndexChanged(null, null);
        }

        void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = FrmMdiMain.Database.GetDataTable(" select *,case when ISNULL(delete_bit,0)=0 then 'false' else 'true' end  as delete_bit1 from ss_ShblJcsj  where type=" + (this.toolStripComboBox1.ComboBox.SelectedValue.ToString()) + " ");
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = tb;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.LightBlue;
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= this.dataGridView1.Rows.Count - 1)
                return;
            try
            {
                this.dataGridView1.EndEdit();
                this.BindingContext[((DataTable)this.dataGridView1.DataSource)].EndCurrentEdit();
                if (e.ColumnIndex == 0)
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells["拼音码"].Value = PubStaticFun.GetPYWBM(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), 0);
                    this.dataGridView1.Rows[e.RowIndex].Cells["五笔码"].Value = PubStaticFun.GetPYWBM(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), 1);
                }
            }
            catch { }
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
        /// <summary>
        /// 修改数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tb"></param>
        public static void databaseupdate(string sql, DataTable tb)
        {
            //数据更行到数据库
            System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection();
            connect.ConnectionString = FrmMdiMain.Database.ConnectionString;// " server=x6x8-20100320QL\\SQLEXPRESS;database=trasen_Emr_test;UID=sa;Password=sa8920993";
            connect.Open();
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
            adapter.SelectCommand = new System.Data.SqlClient.SqlCommand(sql, connect);
            System.Data.SqlClient.SqlCommandBuilder sqlcom = new System.Data.SqlClient.SqlCommandBuilder(adapter);
            //DataSet ds = new DataSet();

            //System.Data.SqlClient.SqlTransaction sqltra = connect.BeginTransaction();

            //adapter.TableMappings[0].ColumnMappings.Add("", "");
            // adapter.TableMappings.Add("df", "fdf");
            //adapter.Fill(ds);
            //ds.Tables[0].Rows[2]["note"] = "开户银行2";
            //ds.Tables[1].Rows[0]["bbid"] = 1;
            //tb.PrimaryKey = new DataColumn[] { tb.Columns["Bsid"] };
            //tb.Rows[0]["reason"] = "1";
            //tb.Rows[1]["reason"] = "1";
            //tb.Rows[2]["reason"] = "1";
            //tb.Columns["Bsid"].ColumnName = "path_step_item_id";
            //tb.Columns["Parent_id"].ColumnName = "step_item_kind_id";
            //tb.Columns["order_spec"].ColumnName = "notes";
            DataTable tbnew = tb.GetChanges(DataRowState.Modified);
            DataTable tbdel = tb.GetChanges(DataRowState.Deleted);


            adapter.InsertCommand = sqlcom.GetInsertCommand();
            adapter.DeleteCommand = sqlcom.GetDeleteCommand();
            adapter.UpdateCommand = sqlcom.GetUpdateCommand();
            int i = 0;
            if (tb.GetChanges() != null)
                i = adapter.Update(tb);
            tb.AcceptChanges();
            sqlcom.RefreshSchema();
            //tb.Columns["path_step_item_id"].ColumnName = "Bsid";
            //tb.Columns["step_item_kind_id"].ColumnName = "Parent_id";
            //tb.Columns["notes"].ColumnName = "order_spec";
            // sqltra.Commit();
            connect.Close();

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
                        temp.Rows[i]["pym"] = PubStaticFun.GetPYWBM(temp.Rows[i]["name"].ToString().Trim(), 0);
                        temp.Rows[i]["wbm"] = PubStaticFun.GetPYWBM(temp.Rows[i]["name"].ToString().Trim(), 1);
                    }
                    temp.Rows[i]["type"] = this.toolStripComboBox1.ComboBox.SelectedValue.ToString();
                    temp.Rows[i]["typename"] = this.toolStripComboBox1.ComboBox.Text.ToString();
                    if (temp.Rows[i]["name"].ToString().Trim() == "")
                        temp.Rows[i].Delete();


                }
                 databaseupdate("select *  from   ss_ShblJcsj where 1=2", ((DataTable)this.dataGridView1.DataSource));
                ((DataTable)this.dataGridView1.DataSource).AcceptChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                FrmShblJcwh_Load(null, null);
                try
                {
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0];
                }
                catch { }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}