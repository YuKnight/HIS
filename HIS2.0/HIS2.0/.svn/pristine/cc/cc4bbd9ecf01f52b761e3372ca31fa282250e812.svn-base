using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
namespace ts_zyhs_gzrzbb
{
    public partial class FrmZybrrbb_new : Form
    {
        BindingManagerBase bm;
        public FrmZybrrbb_new()
        {
            InitializeComponent();
             
        }

        private void FrmZybrrbb_new_Load(object sender, EventArgs e)
        {
            string sql = "select '0' WARD_ID,'全部' WARD_NAME   union all select WARD_ID,WARD_NAME from JC_WARD";
            if(InstanceForm.BCurrentDept.WardId!="")
                sql = " select WARD_ID,WARD_NAME from JC_WARD where ward_id='" + InstanceForm.BCurrentDept.WardId + "'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
            this.comboBox1.ValueMember = "WARD_ID";
            this.comboBox1.DisplayMember = "WARD_NAME";
            this.comboBox1.DataSource = tb;
            if (InstanceForm.BCurrentDept.WardId.Trim() != "")
                this.comboBox1.SelectedValue = InstanceForm.BCurrentDept.WardId;
            initdata();
            this.comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            initdata();
        }
        private void initdata()
        {
            this.Cursor = PubStaticFun.WaitCursor();
            try
            {
                GetGZRZ(this.comboBox1.SelectedValue.ToString(), dateTimePicker1.Value);
                //dtPat = GetPat(InstanceForm.BCurrentDept.WardId, dTimeP_Date.Value);

                //this.DGrid_In.DataSource = DataRowToDataTable(dtPat, 4);
                //this.DGrid_Out.DataSource = DataRowToDataTable(dtPat, 1);
                //this.DGrid_SW.DataSource = DataRowToDataTable(dtPat, 3);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        /// <summary>
        /// 工作日志
        /// </summary>
        /// <param name="wardID"></param>
        /// <param name="dtime"></param>
        /// <returns></returns>
        private DataTable GetGZRZ(string wardID, DateTime dtime)
        {
            //ZY_WARDRBB中有记录的先取，没记录取ZY_WARDGZRZ
            DataTable dt = new DataTable();
            string sql="";
            sql = "select ' '+c.name deptname,a.* " +
                "from ZY_WARDRBB a " +
                "     inner join jc_WARDRDEPT b on a.dept_id = b.dept_id and ward_id='" + wardID + "' " +
                "     left join  jc_dept_property c on b.dept_id = c.dept_id " +
                "where a.book_date = '" + dtime.Date + "' and isnull(del,0)=0 order by c.dept_id ";
            if(wardID=="0")
                sql = "select ' '+c.name deptname,a.* " +
                "from ZY_WARDRBB a " +
                "     inner join jc_WARDRDEPT b on a.dept_id = b.dept_id " +
                "     left join  jc_dept_property c on b.dept_id = c.dept_id " +
                "where a.book_date = '" + dtime.Date + "' and isnull(del,0)=0 order by c.dept_id ";
            dt = InstanceForm.BDatabase.GetDataTable(sql);
            
            if (dt.Rows.Count == 0)
            {
                if (wardID != "0")
                //Modify by zouchihua 增加了单间人数，病重人数，输液人数，留观人数
                sql = "select ' '+c.name deptname,a.*,null oper_l,null oper_m,null oper_s,null BWQJ, null djrs,null bzrs,null syrs,null lgrs,null qmsybcs,null skcw,null szcw,null lsjw   " +
                     "  ,null qjcg ,null qjsw,null qt,null kcs, null del,0 book_user,null cyzzyzcrs,null sss,null  EDSurgical,null DSurgical " +
                    " from ZY_WARDGZRZ a " +
                    "     inner join jc_WARDRDEPT b on a.dept_id = b.dept_id and ward_id='" + wardID + "' " +
                    "     left join  jc_dept_property c on b.dept_id = c.dept_id " +
                    "where a.book_date = '" + dtime.Date + "' order by c.dept_id ";
                else
                sql = "select ' '+c.name deptname,a.*,null oper_l,null oper_m,null oper_s,null BWQJ, null djrs,null bzrs,null syrs,null lgrs,null qmsybcs,null skcw,null szcw,null lsjw   " +
                "  ,null qjcg ,null qjsw,null qt,null kcs, null del,0 book_user,null cyzzyzcrs,null sss,null  EDSurgical,null DSurgical " +
               " from ZY_WARDGZRZ a " +
               "     inner join jc_WARDRDEPT b on a.dept_id = b.dept_id  " +
               "     left join  jc_dept_property c on b.dept_id = c.dept_id " +
               "where a.book_date = '" + dtime.Date + "' order by c.dept_id ";
                dt = InstanceForm.BDatabase.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i].SetAdded();
                }
            }
            bm = this.BindingContext[dt, ""];
            int count = 0;
            for (int i = 0; i < this.groupBox1.Controls.Count; i++)
            {
                if ((this.groupBox1.Controls[i] as TextBox) != null)
                {
                    BindControl(this.groupBox1.Controls[i], dt, null);
                }
                if (i == 11)
                    break;
            }
            for (int i = this.groupBox1.Controls.Count - 1; i >= 0; i--)
            {
                if ((this.groupBox1.Controls[i] as TextBox) != null)
                    BindControl(this.groupBox1.Controls[i], dt, null);
                if (i == 12)
                    break;
            }
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = dt;
            bm.Position = bm.Position;
            return dt;
        }
        /// <summary>
        /// 绑定控件
        /// </summary>
        /// <param name="ct">控件</param>
        /// <param name="tb">内存表</param>
        /// <param name="str">绑定字段</param>
        private void BindControl(Control ct, DataTable tb, string str)
        {
            try
            {
                if ((ct as TextBox) != null)
                {
                    ct.Text = "";
                    ct.DataBindings.Clear();
                    ct.DataBindings.Add("Text", tb, ct.Tag.ToString());
                    ct.TextChanged -= new EventHandler(ct_TextChanged);
                    ct.TextChanged += new EventHandler(ct_TextChanged);
                }
            }
            catch { }
        }

        void ct_Leave(object sender, EventArgs e)
        {
            //bm.EndCurrentEdit();
        }

        void  ct_TextChanged(object sender, EventArgs e)
        {
            
            
            TextBox ct = (sender as TextBox);
            ct.TextChanged -= new EventHandler(ct_TextChanged);
           
            if ((sender as TextBox).Text.Trim() == "")
            {
                ((DataTable)this.dataGridView1.DataSource).Rows[bm.Position][(sender as TextBox).Tag.ToString()] = DBNull.Value;
            }
            bm.Position = bm.Position;
            bm.EndCurrentEdit();
            this.BindingContext[this.dataGridView1.DataSource].EndCurrentEdit();
           
           switch ((sender as TextBox).Name)
           {
               case "txtYy":
               case "txtryrc":
               case "txtQtzr":
               case "txtTkzy":
               case "txtCyrc":
                   this.txtXybs.Text = Convert.ToString(int.Parse(this.txtYy.Text == "" ? "0" : this.txtYy.Text) + int.Parse(this.txtryrc.Text == "" ? "0" : this.txtryrc.Text) + int.Parse(this.txtQtzr.Text == "" ? "0" : this.txtQtzr.Text)
                       - int.Parse(this.txtTkzy.Text == "" ? "0" : this.txtTkzy.Text) - int.Parse(this.txtCyrc.Text == "" ? "0" : this.txtCyrc.Text));
                   bm.EndCurrentEdit();
                   this.BindingContext[this.dataGridView1.DataSource].EndCurrentEdit();
                   break;
               case "txtZy":
               case "txtHz":
               case "txtWy":
               case "txtSw":
               case "txtQt":

                   txtCyrc.Text = Convert.ToString(int.Parse(this.txtZy.Text == "" ? "0" : this.txtZy.Text) + int.Parse(this.txtHz.Text == "" ? "0" : this.txtHz.Text) + int.Parse(this.txtWy.Text == "" ? "0" : this.txtWy.Text)
                       + int.Parse(this.txtSw.Text == "" ? "0" : this.txtSw.Text) + int.Parse(this.txtQt.Text == "" ? "0" : this.txtQt.Text));
                   bm.EndCurrentEdit();
                   this.BindingContext[this.dataGridView1.DataSource].EndCurrentEdit();
                   break;
              
               case "TxtQjcg":
               case "txtQjsw":
                   this.txtQjrc.Text = Convert.ToString(int.Parse(this.TxtQjcg.Text == "" ? "0" : this.TxtQjcg.Text) + int.Parse(this.txtQjsw.Text == "" ? "0" : this.txtQjsw.Text));
                   bm.EndCurrentEdit();
                   this.BindingContext[this.dataGridView1.DataSource].EndCurrentEdit();
                   break;
           }
           this.BindingContext[this.dataGridView1.DataSource].EndCurrentEdit();
           bm.EndCurrentEdit();
           ct.TextChanged += new EventHandler(ct_TextChanged);
          
            //bm.EndCurrentEdit();
            //((DataTable)this.dataGridView1.DataSource).EndInit()
 	        //throw new Exception("The method or operation is not implemented.");
        }
        //数据验证
        private int Validate(DataRow dr)
        {
            int YY = Convert.ToInt32(Convertor.IsNull(dr["YY"], "0"));
            int IN = Convert.ToInt32(Convertor.IsNull(dr["IN"], "0"));
            int OUT = Convert.ToInt32(Convertor.IsNull(dr["OUTALL"], "0"));
            int OUTZY = Convert.ToInt32(Convertor.IsNull(dr["OUTZY"], "0"));
            int OUTHZ = Convert.ToInt32(Convertor.IsNull(dr["OUTHZ"], "0"));
            int OUTWY = Convert.ToInt32(Convertor.IsNull(dr["OUTWY"], "0"));
            int OUTSW = Convert.ToInt32(Convertor.IsNull(dr["OUTSW"], "0"));
            int TRANSIN = Convert.ToInt32(Convertor.IsNull(dr["TRANSIN"], "0"));
            int TRANSOUT = Convert.ToInt32(Convertor.IsNull(dr["TRANSOUT"], "0"));
            int NOW = Convert.ToInt32(Convertor.IsNull(dr["NOW"], "0"));
            int QT = Convert.ToInt32(Convertor.IsNull(dr["qt"], "0"));
            if (OUT != OUTZY + OUTHZ + OUTWY + OUTSW+QT)
            {
                MessageBox.Show("出院合计错误！请检查。", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 6;//OUTALL
            }
            if (NOW != YY + IN + TRANSIN - OUT - TRANSOUT)
            {
                MessageBox.Show("本日住院人数计算错误！请检查数据。", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 19;//NOW
            }
            return -1;
        }
        private void txtdeptname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.SelectNextControl((Control)sender, true, false, true, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if(Validate(((DataTable)this.dataGridView1.DataSource).Rows[0])!=-1)
                        return;
                }
                catch { }


                string sql = "select * from ZY_WARDRBB where book_date='" + dateTimePicker1.Value.AddDays(-1).ToShortDateString()+ "'";
                DataTable temp = FrmMdiMain.Database.GetDataTable(sql);
                if (temp.Rows.Count > 0)
                {
                    if (temp.Rows[0]["NOW"].ToString() != this.txtYy.Text.Trim())
                    {
                        if (MessageBox.Show("昨日现有人数与今日原有人数不符，是否继续？",
                    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                      return;
                        
                    }
                }
                bm.Position = bm.Position;
                this.bm.EndCurrentEdit();
                databaseupdate("select * from ZY_WARDRBB where 1=2", (DataTable)this.dataGridView1.DataSource);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 修改数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tb"></param>
        private void databaseupdate(string sql, DataTable tb)
        {
            //数据更行到数据库
            System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection();
            connect.ConnectionString = TrasenFrame.Forms.FrmMdiMain.Database.ConnectionString;// " server=x6x8-20100320QL\\SQLEXPRESS;database=trasen_Emr_test;UID=sa;Password=sa8920993";
            connect.Open();
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
            adapter.SelectCommand = new System.Data.SqlClient.SqlCommand(sql, connect);
            System.Data.SqlClient.SqlCommandBuilder sqlcom = new System.Data.SqlClient.SqlCommandBuilder(adapter);
            DataTable newtb = new DataTable();
            newtb.TableName = "tb";
            adapter.Fill(newtb);
            adapter.InsertCommand = sqlcom.GetInsertCommand();
            adapter.DeleteCommand = sqlcom.GetDeleteCommand();
            adapter.UpdateCommand = sqlcom.GetUpdateCommand();
            int i = adapter.Update(tb);
            tb.AcceptChanges();
            sqlcom.RefreshSchema();
            connect.Close();
            
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            bm.Position = bm.Position;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            initdata();
            GetGZRZ(this.comboBox1.SelectedValue.ToString(), dateTimePicker1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}