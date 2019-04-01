using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;

namespace ts_mz_xtsz
{
    public partial class Frmyhlx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frmyhlx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void Frmklxsz_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            FillData();
        }

        private void FillData()
        {
            string ssql = "select yhmc 优惠方案,bz 注备,bqybz 启用,id from mz_yhlx order by xh";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            this.dataGridView1.DataSource = tb;
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (tb.Rows.Count == 0) return;
                string ssql = "";

                InstanceForm.BDatabase.BeginTransaction();
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    int id = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["id"], "0"));
                    string yhmc = tb.Rows[i]["优惠方案"].ToString().Trim();
                    int bqybz = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["启用"],"0"));
                    string bz = tb.Rows[i]["备注"].ToString().Trim();

                    if (yhmc == "") throw new Exception("优惠方案名称必填");

                    if (id == 0)
                        ssql = "insert into mz_yhlx(yhmc,bz,bqybz)values('"+yhmc+"','" + bz  + "'," + bqybz  + ")";
                    else
                        ssql = "update mz_yhlx set yhmc=" + yhmc + ",bz='" + bz + "',bqybz=" + bqybz + " where id=" + id + "";
                    InstanceForm.BDatabase.DoCommand(ssql);
                }
                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("保存成功");
                FillData();
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }


        private void butdel_Click(object sender, EventArgs e)
        {
            try
            {
                
                DataTable tb = (DataTable)dataGridView1.DataSource;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                if(MessageBox.Show("删除该优惠方案，它所属的优惠项目比例都将删除。您确定要删除 ["+Convertor.IsNull(tb.Rows[nrow]["优惠方案"],"")+"] 吗 ？","询问窗",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) return;

                int id = Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["id"], "0"));
                string ssql = "delete from mz_yhlx where id=" + id + "";
                InstanceForm.BDatabase.DoCommand(ssql);
                ssql = "delete from mz_yhbl where yhlx=" + id + "";
                InstanceForm.BDatabase.DoCommand(ssql);
                dataGridView1.Rows.Remove(dataGridView1.Rows[nrow]);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["优惠方案"];
            dataGridView1.Focus();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                
                if (dataGridView1.CurrentCell.RowIndex != dataGridView1.Rows.Count-1) return;
                if (dataGridView1.CurrentCell.ColumnIndex + 1 <= dataGridView1.Columns.Count-1)
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