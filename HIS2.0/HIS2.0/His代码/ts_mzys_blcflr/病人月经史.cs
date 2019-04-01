using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
namespace ts_mzys_blcflr
{
    public partial class Frmbryjs : Form
    {
        RelationalDatabase _DataBase;
        string _brxxid;
        int _djy;
        int updateoradd;
        bool _mustSetMcyj = false;//需要设置末次月经
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DataBase"></param>
        /// <param name="brxm"></param>
        /// <param name="brxxid"></param>
        /// <param name="djy"></param>
        /// <param name="mustSetMcyj">需要设置末次月经</param>
        public Frmbryjs(RelationalDatabase DataBase, string brxm, string brxxid, int djy,bool mustSetMcyj)
        {
            InitializeComponent();
            _DataBase = DataBase;
            _brxxid = brxxid;
            txtname.Text = brxm;
            updateoradd = 0;//0添加  1修改
            _djy = djy;
            _mustSetMcyj = mustSetMcyj;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string djsj = DateManager.ServerDateTimeByDBType(_DataBase).ToString();
            string sql = " SELECT * from YY_BRYJS where  isnull(hycs,1)=" + this.numericUpDown1.Value.ToString() + "  and  yxbs=1 and  brxxid='" + _brxxid + @"'  ";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                MessageBox.Show("记录已经存在!");
                return;
            }
            sql = " SELECT * from YY_BRYJS where  isnull(hycs,1)<" + this.numericUpDown1.Value.ToString() + "  and  yxbs=1 and  brxxid='" + _brxxid + @"' and  mcyjsj>='" + this.dateTimePicker1.Value.ToString() + "'";
            tb = FrmMdiMain.Database.GetDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                MessageBox.Show("时间早于上次怀孕的末次月经时间，请修改时间重新保存！");
                this.dateTimePicker1.Focus();
                return;
            }
            string ss = "select   * from YY_BRYJS where yxbs=1 and abs(DATEDIFF(dd,mcyjsj,'" + this.dateTimePicker1.Value.ToString() + "'))<30  and brxxid='" + _brxxid + "'"
                + "  and  EXISTS (select   * from YY_BRYJS  where yxbs=1  and  brxxid='" + _brxxid + "')";
            DataTable temp = FrmMdiMain.Database.GetDataTable(ss);
            if (temp.Rows.Count > 0)
            {
                MessageBox.Show("相隔两次末次月经时间相差在一个月内，请修改时间后重新保存");
                return;
            }
            sql = @"insert into yy_bryjs(brxxid,mcyjsj,yxbs,brxm,djy,djsj,xgy,xgsj,hycs,sccs)
            values ('" + _brxxid + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',1,'" + txtname.Text + "'," + _djy + ",'" + djsj + "',null,null," + this.numericUpDown1.Value.ToString()+ "," + this.numericUpDown2.Value.ToString()+ ")";

            int result = Convert.ToInt32(_DataBase.DoCommand(sql));
            if (result == 1)
                MessageBox.Show("添加成功!");
             
              
            Bind();
            
        }

        private void Frmbryjs_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            string ssql = "SELECT '' 序号,ID,[brxxid],CONVERT(char, mcyjsj,23) mcyjsj,[yxbs],[brxm],dbo.fun_getEmpName(djy) [djy],[djsj],[xgy],[xgsj],'孕'+cast( isnull(hycs,1) as varchar)+'次' hycs_show,'产'+cast( isnull(sccs,0) as varchar)+'次' sccs_show,isnull(hycs,0) hycs,isnull(sccs,0) sccs    FROM [YY_BRYJS] where brxxid='" + _brxxid + "'  and yxbs=1 order by mcyjsj ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            ts_mz_class.Fun.AddRowtNo(tb);
            dataGridView1.DataSource = tb;
            GetCurrrentRow(-1);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetCurrrentRow(e.RowIndex);
        }

        private void GetCurrrentRow(int rowIndex)
        {
            if (rowIndex < 0 && dataGridView1.Rows.Count>0) 
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["末次月经时间"];
                rowIndex = dataGridView1.CurrentCell.RowIndex;
            }
            if (rowIndex > 0)
            {
                updateoradd = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);

                //  dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["末次月经时间"].Value);
            }
            if (rowIndex >= 0 && rowIndex == dataGridView1.RowCount - 1)
            {
                if (dataGridView1.Rows[rowIndex].Cells["末次月经时间"].Value != null)
                {
                    DateTime date_mcyj = new DateTime();
                    bool flag = DateTime.TryParse(dataGridView1.Rows[rowIndex].Cells["末次月经时间"].Value.ToString(), out date_mcyj);
                    if (flag) dateTimePicker1.Value = date_mcyj;
                }
                if (dataGridView1.Rows[rowIndex].Cells["怀孕次数"].Value != null)
                {
                    int  i_hycs = Convertor.IsInteger(dataGridView1.Rows[rowIndex].Cells["怀孕次数"].Value.ToString()) ? int.Parse(dataGridView1.Rows[rowIndex].Cells["怀孕次数"].Value.ToString()) : 1;
                    if (i_hycs < 1) i_hycs = 1;
                    if (i_hycs > 30) i_hycs = 30;
                    numericUpDown1.Value = i_hycs;
                }
                if (dataGridView1.Rows[rowIndex].Cells["产次"].Value != null)
                {
                    int i_sccs = Convertor.IsInteger(dataGridView1.Rows[rowIndex].Cells["产次"].Value.ToString()) ? int.Parse(dataGridView1.Rows[rowIndex].Cells["产次"].Value.ToString()) : 0;
                    if (i_sccs < 0) i_sccs = 0;
                    if (i_sccs > 30) i_sccs = 30;
                    numericUpDown2.Value = i_sccs;
                }

                this.btnSave.Visible = true;
            }
            else this.btnSave.Visible = false;
        }

        private void btnzwx_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentCell == null)
                return;
            if (
                    
                (MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                )
                return;
            updateoradd = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            //必须设置时  增加判断 2013-4-24 jianqg
            if (_mustSetMcyj)
            {
                string strSql = "select top 1 hycs  from yy_bryjs where brxxid='" + _brxxid + "'  and yxbs=1 and id <>"  + updateoradd.ToString();
                DataTable tbTmp = _DataBase.GetDataTable(strSql);
                if (tbTmp == null || tbTmp.Rows.Count == 0)
                {
                    MessageBox.Show("该科室的病人必须填写末次月经时间，删除无效!可以修改末次月经信息，点<保存>按钮。");
                    return;
                }

            }
            string sql = "update yy_bryjs set yxbs=0,mcyjsj='" + dateTimePicker1.Value.ToString() + "',xgy=" + _djy + ",xgsj=getdate() where id=" + updateoradd.ToString();
            _DataBase.DoCommand(sql);
            MessageBox.Show("删除成功!");
            Bind();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentCell == null)
                return;
            if (

                (MessageBox.Show("您确定要将修改后的信息保存吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                )
                return;
            updateoradd = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            string sql = "update yy_bryjs set mcyjsj='" + dateTimePicker1.Value.ToString() + "',hycs=" + numericUpDown1.Value.ToString() + ",sccs=" + numericUpDown2.Value.ToString() + ",xgy=" + _djy + ",xgsj=getdate()  where id=" + updateoradd.ToString();
            _DataBase.DoCommand(sql);
            MessageBox.Show("保存成功!");
            Bind();
        }


    }
}
