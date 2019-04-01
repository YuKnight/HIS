using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
namespace ts_zyhs_ypxx
{
    public partial class FrmZcyGl : Form
    {
        
        ts_zyhs_classes.BaseFunc baseFun = new ts_zyhs_classes.BaseFunc();
        public FrmZcyGl()
        {
            InitializeComponent();
            this.cmbzxks.ValueMember = "";
            string sSql = "";
            DataTable  yfTb =ZcyBill.Getzxks();
            if (yfTb == null || yfTb.Rows.Count == 0)
            {
                return;
            }
            cmbzxks.DisplayMember = "KSMC";
            cmbzxks.ValueMember = "DEPTID";
            cmbzxks.DataSource = yfTb;
            this.dataGridView1.AutoGenerateColumns = false;
            this.cmbzxks.SelectedValueChanged += new EventHandler(cmbzxks_SelectedValueChanged);
            this.checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
            this.radioButton1.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
        }

        void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button5_Click(null, null);
        }

        void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button5_Click(null, null);
            if (checkBox1.Checked)
                button4.Enabled = false;
            else
                button4.Enabled = true;
        }

        void cmbzxks_SelectedValueChanged(object sender, EventArgs e)
        {
            FrmZcyGl_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                this.BindingContext[tb].EndCurrentEdit();
                DataRow[] _rows=tb.Select("选择=1");
                if (_rows.Length==0)
                {
                    MessageBox.Show("没有选择任何行");
                    return;
                }
                decimal j = 0;
                DataTable fyyf = null; ;//发送到药房
                DataTable Xyfjy = null;//向药房借药
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (Xyfjy != null)
                        Xyfjy.Clear();
                    if (Xyfjy != null)
                        fyyf.Clear();
                    if (tb.Rows[i]["请求数量"].ToString() == "" || tb.Rows[i]["选择"].ToString() == "0")
                        continue;
                    if (int.Parse(tb.Rows[i]["请求数量"].ToString()) > 0)
                    {
                        DataSet dset = ZcyBill.GetFsypxx(int.Parse(tb.Rows[i]["cjid"].ToString()), InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId
                           , InstanceForm.BCurrentDept.WardId, int.Parse(cmbzxks.SelectedValue.ToString()),
                          (long)(decimal.Parse(tb.Rows[i]["暂存数量"].ToString())), long.Parse(tb.Rows[i]["请求数量"].ToString()), ref j);
                        if (fyyf == null)
                            fyyf = dset.Tables[0].Clone();
                        if (dset.Tables[1].Rows.Count > 0)
                        {
                            //每次都是一条记录
                            dset.Tables[1].Rows[0]["单位"] = tb.Rows[i]["单位"];
                            dset.Tables[1].Rows[0]["DWBL"] = tb.Rows[i]["DWBL"];
                            dset.Tables[1].Rows[0]["dwbl"] = tb.Rows[i]["xdwbl"];//现在的单位比例
                            dset.Tables[1].Rows[0]["zxdw"] = tb.Rows[i]["xzxdw"];
                            dset.Tables[1].Rows[0]["单价"] = tb.Rows[i]["lsj"];
                            dset.Tables[1].Rows[0]["zcykcid"] = tb.Rows[i]["id"].ToString();
                        }
                        if (Xyfjy == null)
                            Xyfjy = dset.Tables[1].Clone();
                        fyyf.Merge(dset.Tables[0]);
                        Xyfjy.Merge(dset.Tables[1]);
                         
                        ZcyBill.Scjydj(Xyfjy, 3, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId
                                        , int.Parse(this.cmbzxks.SelectedValue.ToString()));
                        baseFun.SendYPzcgl(fyyf, FrmMdiMain.CurrentDept.WardId, FrmMdiMain.CurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), Convert.ToInt64(cmbzxks.SelectedValue.ToString()), 0, FrmMdiMain.Jgbm);
                    }
                }
                this.FrmZcyGl_Load(null, null);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        
           
        }

        public void FrmZcyGl_Load(object sender, EventArgs e)
        {
           
            this.dataGridView1.DataSource=ZcyBill.GetZcyCk(InstanceForm.BCurrentDept.WardDeptId,int.Parse(this.cmbzxks.SelectedValue.ToString()));
            DataTable tb=(DataTable)this.dataGridView1.DataSource;
            //增加一行合计
            DataRow r = tb.NewRow();
            decimal hjje = 0;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                hjje += decimal.Parse(tb.Rows[i]["金额"].ToString());
            }
            r["药品品名"] = "合计";
            r["金额"] = hjje;
            tb.Rows.Add(r);
            this.dataGridView1.Rows[this.dataGridView1.Rows.Count-1].DefaultCellStyle.BackColor = Color.Yellow;
            this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].DefaultCellStyle.Font =new  System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Blue;
            this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmXzyp frmxzyp = new FrmXzyp(int.Parse(cmbzxks.SelectedValue.ToString()));
            frmxzyp.tb = (DataTable)this.dataGridView1.DataSource;
            if (frmxzyp.ShowDialog() == DialogResult.OK)
            {
                FrmZcyGl_Load(null, null);
            }
          }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
               
                decimal j = 0;
             
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                this.BindingContext[tb].EndCurrentEdit();
                DataRow[] _rows= tb.Select("选择=1");
                if (_rows.Length== 0)
                {
                    MessageBox.Show("没有选择任何行");
                    return;
                }
                DataTable XyfHy = null;//向药房hauan药
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (tb.Rows[i]["还药数量"].ToString() == "" || tb.Rows[i]["选择"].ToString() == "0")
                        continue;
                    if (int.Parse(tb.Rows[i]["还药数量"].ToString()) > 0)
                    {
                        //获得表结果
                        DataSet dset = ZcyBill.GetFsypxx(int.Parse(tb.Rows[i]["cjid"].ToString()), InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId
                              , InstanceForm.BCurrentDept.WardId, int.Parse(cmbzxks.SelectedValue.ToString()),
                             (long)(0), long.Parse("1"), ref j);
                        if (XyfHy == null)
                            XyfHy = dset.Tables[1].Clone();
                        if (dset.Tables[1].Rows.Count > 0)
                        {
                            //每次都是一条记录
                            dset.Tables[1].Rows[0]["单位"] = tb.Rows[i]["单位"];
                            dset.Tables[1].Rows[0]["DWBL"] = tb.Rows[i]["DWBL"];
                            dset.Tables[1].Rows[0]["dwbl"] = tb.Rows[i]["xdwbl"];//现在的单位比例
                            dset.Tables[1].Rows[0]["zxdw"] = tb.Rows[i]["xzxdw"];
                            dset.Tables[1].Rows[0]["单价"] = tb.Rows[i]["lsj"];
                            dset.Tables[1].Rows[0]["zcykcid"] = tb.Rows[i]["id"].ToString();
                            dset.Tables[1].Rows[0]["数量"] = tb.Rows[i]["还药数量"].ToString();
                        }
                        XyfHy.Merge(dset.Tables[1]);
                    }
                }
                ZcyBill.Scjydj(XyfHy, 4, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId
                                              , int.Parse(this.cmbzxks.SelectedValue.ToString()));
                this.FrmZcyGl_Load(null, null);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Visible = true;
            int deptly= InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId;
            int shzt=checkBox1.Checked?1:0;
            int ywlx=this.radioButton1.Checked?3:4;
            string time1=this.dateTimePicker1.Value.ToShortDateString();
            string time2=this.dateTimePicker2.Value.AddDays(1).ToShortDateString();
            DataTable tb = ZcyBill.SelecDj(shzt, ywlx, time1, time2, int.Parse(this.cmbzxks.SelectedValue.ToString()), deptly);
            this.dataGridView2.AutoGenerateColumns = true;
            this.dataGridView2.DataSource = tb;
            this.dataGridView2.Columns[this.dataGridView2.Columns.Count - 1].Visible = false;
            this.dataGridView2.Columns[this.dataGridView2.Columns.Count - 2].Visible = false;
           
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (this.dataGridView2.Rows[e.RowIndex].Cells["审核状态"].Value.ToString() == "×")
                    e.CellStyle.BackColor = Color.Yellow;
                else
                    e.CellStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.CurrentCell == null)
                return;
            int curindex = this.dataGridView2.CurrentCell.RowIndex;
            string id = this.dataGridView2.Rows[curindex].Cells["id"].Value.ToString();
            int ywlx = this.radioButton1.Checked ? 3 : 4;
            string kcid = this.dataGridView2.Rows[curindex].Cells["kcid"].Value.ToString();
            decimal sl=decimal.Parse(this.dataGridView2.Rows[curindex].Cells["数量"].Value.ToString());
            int ydwbl = int.Parse(this.dataGridView2.Rows[curindex].Cells["单位比例"].Value.ToString());
            ZcyBill.QxDj(id, ywlx, kcid, sl, ydwbl);
            button5_Click(null, null);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           // return;
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if(e.RowIndex<0)
                return;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "还药数量")
            {
                decimal zcsl = 0;
                try
                {
                    if (this.dataGridView1.Rows[e.RowIndex].Cells["还药数量"].Value.ToString() == "")
                        return;
                    zcsl = decimal.Parse(this.dataGridView1.Rows[e.RowIndex].Cells["还药数量"].Value.ToString());
                     if (zcsl <= 0)
                        throw new Exception("ddd");
                }
                catch
                {
                  
                    //this.dataGridView1.EndEdit();
                    
                    this.dataGridView1.Rows[e.RowIndex].Cells["还药数量"].Value = DBNull.Value;
                   this.BindingContext[(DataTable)this.dataGridView1.DataSource].EndCurrentEdit();
                    MessageBox.Show(" 请输入大于零的整数");
                    return;
                }
                //医院不需要控制
                //if (decimal.Parse(this.dataGridView1.Rows[e.RowIndex].Cells["暂存数量"].Value.ToString()) >= 0)
                //{
                   
                //    MessageBox.Show("只有暂存数量小于0时，才可以还药");

                //    this.dataGridView1.Rows[e.RowIndex].Cells["还药数量"].Value = DBNull.Value;
                //    this.BindingContext[(DataTable)this.dataGridView1.DataSource].EndCurrentEdit();
                //  //  this.dataGridView1.EndEdit();
                //    return;
                //}
                //else
                //    if (Math.Abs(decimal.Parse(this.dataGridView1.Rows[e.RowIndex].Cells["暂存数量"].Value.ToString())) <
                //       decimal.Parse(this.dataGridView1.Rows[e.RowIndex].Cells["还药数量"].Value.ToString())
                //        )
                //    {
                      
                //        MessageBox.Show("您输入的数字过大，最多只能输入" + Math.Abs(decimal.Parse(this.dataGridView1.Rows[e.RowIndex].Cells["暂存数量"].Value.ToString())));

                //        this.dataGridView1.Rows[e.RowIndex].Cells["还药数量"].Value = DBNull.Value;
                //        this.BindingContext[(DataTable)this.dataGridView1.DataSource].EndCurrentEdit();
                //      //  this.dataGridView1.EndEdit();
                //        return;
                //    }
            }
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "借药数量")
            {

                decimal zcsl = 0;
                try
                {
                    if (this.dataGridView1.Rows[e.RowIndex].Cells["还药数量"].Value.ToString() == "")
                        return;
                    zcsl = decimal.Parse(this.dataGridView1.Rows[e.RowIndex].Cells["还药数量"].Value.ToString());
                    if (zcsl <= 0)
                        throw new Exception("ddd");
                }
                catch
                {

                    //this.dataGridView1.EndEdit();

                    this.dataGridView1.Rows[e.RowIndex].Cells["还药数量"].Value = DBNull.Value;
                    this.BindingContext[(DataTable)this.dataGridView1.DataSource].EndCurrentEdit();
                    MessageBox.Show(" 请输入大于零的整数");
                    return;
                }
            }
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "请求数量")
            {
                decimal zcsl = 0;
                try
                {
                    if (this.dataGridView1.Rows[e.RowIndex].Cells["请求数量"].Value.ToString() == "")
                        return;
                    zcsl = decimal.Parse(this.dataGridView1.Rows[e.RowIndex].Cells["请求数量"].Value.ToString());
                    //if (zcsl <= 0)
                    //    throw new Exception("ddd");
                    if (zcsl < 0)//请求数量小于0时，表示是发送负数的
                    { }
                    decimal j = 0;
                    //如果暂存数量大于等于请求数量，就取实际的数量
                    //if ((long)(decimal.Parse(tb.Rows[e.RowIndex]["暂存数量"].ToString())) >= long.Parse(tb.Rows[e.RowIndex]["请求数量"].ToString())
                    //    && (long)(decimal.Parse(tb.Rows[e.RowIndex]["暂存数量"].ToString())) >= 0)
                    {
                        DataSet dset = ZcyBill.GetFsypxx_new(int.Parse(tb.Rows[e.RowIndex]["cjid"].ToString()), InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId
                               , InstanceForm.BCurrentDept.WardId, int.Parse(cmbzxks.SelectedValue.ToString()),
                              (long)(decimal.Parse(tb.Rows[e.RowIndex]["暂存数量"].ToString())), long.Parse(tb.Rows[e.RowIndex]["请求数量"].ToString()), ref j);
                        this.dataGridView1.CellValueChanged-=new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
                        this.dataGridView1.Rows[e.RowIndex].Cells["请求数量"].Value = j;
                       
                        this.BindingContext[(DataTable)this.dataGridView1.DataSource].EndCurrentEdit();
                        this.dataGridView1.EndEdit();
                        this.dataGridView1.CellValueChanged+= new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
                    }
                  
                   

                }
                catch
                {
                    MessageBox.Show(" 请输入大于零的整数");
                    this.dataGridView1.Rows[e.RowIndex].Cells["请求数量"].Value = DBNull.Value;
                    this.BindingContext[(DataTable)this.dataGridView1.DataSource].EndCurrentEdit();
                    return;
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
           // this.Parent.FindForm().Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                this.button1.Enabled = true;
                this.button2.Visible = true;
                this.button3.Enabled = true;
            }
            else
            {
                this.button1.Enabled = false;
                this.button2.Visible = false;
                this.button3.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                string fileter = " pym like '%" + this.textBox1.Text + "%'  or  wbm like '%" + this.textBox1.Text + "%'"
                                  + " or 药品品名 like '%" + this.textBox1.Text + "%'";
                DataRow[] _row= tb.Select(fileter);
                if (_row.Length > 0)
                {
                    int i = tb.Rows.IndexOf(_row[0]);
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells[1];
                }
            }
            catch(Exception ex) { }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.FrmZcyGl_Load(null, null);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
              // if(this.dataGridView1.Rows[i].Cells["Column1"].Value.ToString()=="1")
                this.dataGridView1.Rows[i].Cells["Column1"].Value = 1;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if(this.dataGridView1.Rows[i].Cells["Column1"].Value.ToString()=="1")
                   this.dataGridView1.Rows[i].Cells["Column1"].Value = 0;
                else
                   this.dataGridView1.Rows[i].Cells["Column1"].Value = 1;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                this.BindingContext[(DataTable)this.dataGridView1.DataSource].EndCurrentEdit();
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    tb.Rows[i]["zcjs"] = tb.Rows[i]["暂存基数"];
                }
                tb.Rows[tb.Rows.Count-1].AcceptChanges();
                ZcyBill.Databaseupdate("select * from Zy_ZcyKcmx where 1=2", (DataTable)this.dataGridView1.DataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                this.请求数量.DefaultCellStyle.BackColor = System.Drawing.Color.MintCream;
                this.借药数量.DefaultCellStyle.BackColor = System.Drawing.Color.Maroon;
                this.还药数量.DefaultCellStyle.BackColor = System.Drawing.Color.Honeydew;
                this.暂存基数.DefaultCellStyle.BackColor = System.Drawing.Color.SeaShell;
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;
                string name = this.dataGridView1.Columns[e.ColumnIndex].Name;
                if (name == "还药数量" || name == "请求数量" || name == "暂存基数" || name == "借药数量")
                {
                    if (name == "还药数量")
                        e.CellStyle.BackColor = System.Drawing.Color.Honeydew;
                    if (name == "请求数量")
                        e.CellStyle.BackColor = System.Drawing.Color.MintCream;
                    if (name == "暂存基数")
                        e.CellStyle.BackColor = System.Drawing.Color.SeaShell;
                    if (name == "借药数量")
                        e.CellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))); ;
                    return;
                }
                if (decimal.Parse(this.dataGridView1.Rows[e.RowIndex].Cells["暂存数量"].Value.ToString()) < 0)
                {
                    e.CellStyle.BackColor = Color.LightPink;
                    // e.Handled = true;
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                    // e.Handled = true;
                }
            }
            catch { }
        }

        private void FrmZcyGl_Activated(object sender, EventArgs e)
        {
            this.FrmZcyGl_Load(null, null);
        }
        /// <summary>
        /// 借药
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                this.BindingContext[tb].EndCurrentEdit();
                DataRow[] _rows = tb.Select("选择=1");
                if (_rows.Length == 0)
                {
                    MessageBox.Show("没有选择任何行");
                    return;
                }
                decimal j = 0;
                DataTable fyyf = null; ;//发送到药房
                DataTable Xyfjy = null;//向药房借药
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (Xyfjy != null)
                        Xyfjy.Clear();
                    if (Xyfjy != null)
                        fyyf.Clear();
                    if (tb.Rows[i]["借药数量"].ToString() == "" || tb.Rows[i]["选择"].ToString() == "0")
                        continue;
                    if (int.Parse(tb.Rows[i]["借药数量"].ToString()) > 0)
                    {
                        DataSet dset = ZcyBill.GetFsypxx(int.Parse(tb.Rows[i]["cjid"].ToString()), InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId
                           , InstanceForm.BCurrentDept.WardId, int.Parse(cmbzxks.SelectedValue.ToString()),
                          1000000, long.Parse(tb.Rows[i]["借药数量"].ToString()), ref j);
                        if (fyyf == null)
                            fyyf = dset.Tables[0].Clone();
                        if (dset.Tables[1].Rows.Count > 0)
                        {
                            //每次都是一条记录
                            dset.Tables[1].Rows[0]["单位"] = tb.Rows[i]["单位"];
                            dset.Tables[1].Rows[0]["DWBL"] = tb.Rows[i]["DWBL"];
                            dset.Tables[1].Rows[0]["dwbl"] = tb.Rows[i]["xdwbl"];//现在的单位比例
                            dset.Tables[1].Rows[0]["zxdw"] = tb.Rows[i]["xzxdw"];
                            dset.Tables[1].Rows[0]["单价"] = tb.Rows[i]["lsj"];
                            dset.Tables[1].Rows[0]["zcykcid"] = tb.Rows[i]["id"].ToString();
                            dset.Tables[1].Rows[0]["数量"] = long.Parse(tb.Rows[i]["借药数量"].ToString());//数量更改借药数量
                        }
                        else
                        {
                            DataRow row = dset.Tables[1].NewRow();
                            row["单位"] = tb.Rows[i]["单位"];
                            row["DWBL"] = tb.Rows[i]["DWBL"];
                            row["dwbl"] = tb.Rows[i]["xdwbl"];//现在的单位比例
                            row["zxdw"] = tb.Rows[i]["xzxdw"];
                            row["单价"] = tb.Rows[i]["lsj"];
                            row["zcykcid"] = tb.Rows[i]["id"].ToString();
                            row["数量"] = long.Parse(tb.Rows[i]["借药数量"].ToString());//数量更改借药数量
                            row["cjid"] = tb.Rows[i]["cjid"];
                            dset.Tables[1].Rows.Add(row);
                        }
                        if (Xyfjy == null)
                            Xyfjy = dset.Tables[1].Clone();
                        fyyf.Merge(dset.Tables[0]);
                        Xyfjy.Merge(dset.Tables[1]);

                        ZcyBill.Scjydj(Xyfjy, 3, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId
                                        , int.Parse(this.cmbzxks.SelectedValue.ToString()));
                        //baseFun.SendYPzcgl(fyyf, FrmMdiMain.CurrentDept.WardId, FrmMdiMain.CurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), Convert.ToInt64(cmbzxks.SelectedValue.ToString()), 0, FrmMdiMain.Jgbm);
                    }
                }
                this.FrmZcyGl_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
        
    }
}