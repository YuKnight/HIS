using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using Ts_zyys_public;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace Ts_zyys_jcsq
{
    public partial class FrmGroup : Form
    {
        #region 自定义项
        /// <summary>
        /// 自定义项
        /// </summary>
         
        #endregion

       public  Ts_zyys_jcsq.FrmJCSQ.Item[] _item;
        public Ts_zyys_jcsq.FrmJCSQBW.Item[] _itemBW;
        public FrmGroup(Ts_zyys_jcsq.FrmJCSQ.Item[] item)
        {
            InitializeComponent();
            _item = item;
        }

        public FrmGroup(Ts_zyys_jcsq.FrmJCSQBW.Item[] itemBW)
        {
            InitializeComponent();
            _itemBW = itemBW;
        }

        private void FrmGroup_Load(object sender, EventArgs e)
        {
            string sql = "select  -1 id ,' ' name union all select  1 id ,'1' name union select 2 id ,'2' name union all select 3 id ,'3' name  union all select 4 id ,'4 'name  union all select 5 id ,'5 'name   union all select 6 id ,'6' name   union all select 7 id ,'7' name  union all select 8 id ,'8' name ";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            DataGridViewComboBoxColumn dbc = (DataGridViewComboBoxColumn)this.dataGridView1.Columns[2];
            dbc.DataSource = tb;
            dbc.DisplayMember = "name";
            dbc.ValueMember = "id";

            //Modify jchl
            //Guid jc_no= Guid.NewGuid();
            int jc_no = DbQuery.UpdateNowNoAndGetNewNo(13,InstanceForm._database);

            for (int i = 0; i < _item.Length;i++ )
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[i].Cells["项目名称"].Value = _item[i].orderName;
                this.dataGridView1.Rows[i].Cells["组号"].Value = 1;// _item[i].groupid;
                this.dataGridView1.Rows[i].Cells["执行科室"].Value = _item[i].execDept;
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                _item[i].jc_no = jc_no;
            }
           // this.dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.Programmatic;
           // this.dataGridView1.Sort(this.dataGridView1.Columns[3], ListSortDirection.Ascending);

            //执行科室相同的不能分在医嘱  
            int zh=1;
            string  zxks = "0";
            int jcno =DbQuery.UpdateNowNoAndGetNewNo(13,InstanceForm._database);
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (i == 0)
                {
                    zxks = this.dataGridView1.Rows[i].Cells["执行科室"].Value.ToString();
                    _item[i].jc_no = jcno;
                }
                else
                {
                    if (zxks != this.dataGridView1.Rows[i].Cells["执行科室"].Value.ToString())
                    {
                        zxks = this.dataGridView1.Rows[i].Cells["执行科室"].Value.ToString();
                        zh++;
                        jcno = DbQuery.UpdateNowNoAndGetNewNo(13, InstanceForm._database);
                        this.dataGridView1.Rows[i].Cells["组号"].Value = zh;
                        _item[i].jc_no = jcno;
                    }
                    else
                    {
                        this.dataGridView1.Rows[i].Cells["组号"].Value = zh;
                        _item[i].jc_no = jcno;
                    }
                }
            }
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                switch (this.dataGridView1.Rows[i].Cells["组号"].Value.ToString())
                {
                    case "1":
                        this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                        break;
                    case "2": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                        break;
                    case "3": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                        break;
                    case "4": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                        break;
                    case "5": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                        break;
                    case "6": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Brown;
                        break;
                    case "7": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        break;
                    case "8": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        break;
                    default:
                        this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        break;
                }
            }
        }

        private void btnfz_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = 0;
                int start = 0;//选中开始位置
                int zh = -2;//记录组号
                String zxks = "0";
                int jc_no=DbQuery.UpdateNowNoAndGetNewNo(13,InstanceForm._database);
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    if ((this.dataGridView1.Rows[i].Cells["选择"].Value == null ? "-1" : this.dataGridView1.Rows[i].Cells["选择"].Value.ToString()) == "1") 
                    {
                        flag++;
                        if (flag == 1)
                        {
                            zh = (int)this.dataGridView1.Rows[i].Cells["组号"].Value;
                            _item[i].jc_no = jc_no;
                            start = i;
                            zxks=this.dataGridView1.Rows[i].Cells["执行科室"].Value.ToString();
                        }
                        else
                        {
                            if (zxks == this.dataGridView1.Rows[i].Cells["执行科室"].Value.ToString())
                            {
                                this.dataGridView1.Rows[i].Cells["组号"].Value = zh;
                                _item[i].jc_no = jc_no;
                            }
                        }
                    }
                    else
                        if (this.dataGridView1.Rows[i].Cells["组号"].Value.ToString() == zh.ToString())
                        {
                            this.dataGridView1.Rows[i].Cells["组号"].Value = -1;
                            _item[i].jc_no = DbQuery.UpdateNowNoAndGetNewNo(13, InstanceForm._database); ;
                        }
                }
                for (int j = 0; j < start; j++)
                {
                    if (this.dataGridView1.Rows[j].Cells["组号"].Value.ToString() == zh.ToString())
                    {
                        this.dataGridView1.Rows[j].Cells["组号"].Value = -1;
                        _item[j].jc_no = DbQuery.UpdateNowNoAndGetNewNo(13, InstanceForm._database);
                    }
                }
                    for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                    {
                        switch (this.dataGridView1.Rows[i].Cells["组号"].Value.ToString())
                        {
                            case "1":
                                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                                break;
                            case "2": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                                break;
                            case "3": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                                break;
                            case "4": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                                break;
                            case "5": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                                break;
                            case "6": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Brown;
                                break;
                            case "7": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                                break;
                            case "8": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                                break;
                            default:
                                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                break;
                        }
                    }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.CurrentCell == null)
                return;
            try
            {
                if (this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["组号"].Value.ToString() == "-1")
                {
                    _item[this.dataGridView1.CurrentCell.RowIndex].jc_no = DbQuery.UpdateNowNoAndGetNewNo(13, InstanceForm._database);
                    return;
                }
            }
            catch { }
            if (this.dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                int flag = 0;
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    if (i != this.dataGridView1.CurrentCell.RowIndex && this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["组号"].Value.ToString() == this.dataGridView1.Rows[i].Cells["组号"].Value.ToString())
                    {
                        for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                        {
                            if (this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["执行科室"].Value.ToString() != this.dataGridView1.Rows[j].Cells["执行科室"].Value.ToString()
                                &&
                                this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["组号"].Value.ToString() == this.dataGridView1.Rows[j].Cells["组号"].Value.ToString()
                                )
                            {
                               //如果找到组号相同，执行科室不同
                                _item[this.dataGridView1.CurrentCell.RowIndex].jc_no = DbQuery.UpdateNowNoAndGetNewNo(13, InstanceForm._database); 
                                this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["组号"].Value = -1;
                                return;
                            }
                        }
                        _item[this.dataGridView1.CurrentCell.RowIndex].jc_no = _item[i].jc_no;
                        flag = 1;
                    }
                    switch (this.dataGridView1.Rows[i].Cells["组号"].Value.ToString())
                    {
                        case "1":
                            this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                            break;
                        case "2": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                            break;
                        case "3": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                            break;
                        case "4": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                            break;
                        case "5": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                            break;
                        case "6": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Brown;
                            break;
                        case "7": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            break;
                        case "8": this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                            break;
                    }
                }
                if (flag == 0)
                    _item[this.dataGridView1.CurrentCell.RowIndex].jc_no = DbQuery.UpdateNowNoAndGetNewNo(13, InstanceForm._database); 
            }
        }

        private void btnqx_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].Cells["选择"].Value = 1;
            }
        }

        private void btnfs_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if ((this.dataGridView1.Rows[i].Cells["选择"].Value == null ? "-1" : this.dataGridView1.Rows[i].Cells["选择"].Value.ToString()) == "1") 
                 this.dataGridView1.Rows[i].Cells["选择"].Value = 0;
                else
                 this.dataGridView1.Rows[i].Cells["选择"].Value = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //string zh = this.dataGridView1.Rows[e.RowIndex].Cells["组号"].ToString();
            //string zxks = this.dataGridView1.Rows[e.RowIndex].Cells["执行科室"].ToString();

            //for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            //{
            //    if (i != e.RowIndex && zxks != this.dataGridView1.Rows[i].Cells["执行科室"].ToString() && zh == this.dataGridView1.Rows[i].Cells["组号"].ToString())
            //    {
            //        this.dataGridView1.Rows[e.RowIndex].Cells["组号"].Value = -1;
            //        MessageBox.Show("不能将执行科室不同的医嘱设置为同组");
            //    }
                 
            //}
        }
        
    }
}