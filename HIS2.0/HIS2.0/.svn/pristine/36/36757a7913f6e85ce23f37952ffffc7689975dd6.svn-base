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
namespace Ts_zyys_yzgl
{
    /// <summary>
    /// 医嘱滴量维护
    /// 蔡成 2013-05-28
    /// </summary>
    public partial class FrmYZDLList : Form
    {
        private string _chineseName;
        private Form _mdiParent;
        private MenuTag _menuTag;
        public static FrmYZDLList frmmain = null; 
        public FrmYZDLList()
        {
            InitializeComponent();
        }

        public FrmYZDLList( string chineseName, Form mdiParent)
        { 
            this._chineseName = chineseName;
            this._mdiParent = mdiParent;
            frmmain = this;
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        } 
        private int ID = -1;
        public bool isOK=false;

        private void btnFind_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void GetList()
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select [ID],[NAME],[PYM],[WBM],(case [ISUSER] when 1 then '使用' else '停用' end) as UserState from [JC_YZDL] where 1=1 {0}", GetWhere());
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                this.dataGridView1.DataSource = dt;
            }
            catch
            {
                
            }
        }

        private string GetWhere()
        {
            string strWhere = " and 1=1";
            if (!string.IsNullOrEmpty(txtName.Text))
            { 
                strWhere = " and name like '%"+txtName.Text+"%'";
            }
            return strWhere;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmYZDLModify FrmAction = new FrmYZDLModify("Add", this, ID);
            FrmAction.ShowDialog();
            if (isOK)
            {
                GetList();
            }
        } 

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick(null, new DataGridViewCellEventArgs(this.dataGridView1.CurrentCell.ColumnIndex,this.dataGridView1.CurrentCell.RowIndex));
            FrmYZDLModify FrmAction = new FrmYZDLModify("Update", this, ID);
            FrmAction.ShowDialog();
            if (isOK)
            {
                GetList();
            }
        } 

        private void Delete()
        {
            String strSql = string.Format(@"delete from [JC_YZDL] where ID={0}", ID);
            if(DialogResult.Yes== MessageBox.Show("是否要删除本条信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
                int Ireturn=FrmMdiMain.Database.DoCommand(strSql);
                if (Ireturn > 0)
                {
                    GetList();
                }
                else {
                    MessageBox.Show("删除有错");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick(null, new DataGridViewCellEventArgs(this.dataGridView1.CurrentCell.ColumnIndex, this.dataGridView1.CurrentCell.RowIndex));
            Delete();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                this.dataGridView1.EndEdit();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["clCheck"].Value = 0;
                }
                this.dataGridView1.CurrentRow.Cells[0].Value = 1;
                ID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["clID"].Value.ToString());
            }
            catch { }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridView1 != null)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, rect, dataGridView1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                //隔行换色
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
            } 
        }

        private void FrmYZDLList_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            GetList();
        }

    }
}