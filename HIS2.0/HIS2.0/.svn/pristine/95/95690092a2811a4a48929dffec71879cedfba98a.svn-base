using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
namespace ts_yp_ypbl
{
    public partial class FrmMain : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private DataTable Tbks;
        private DataTable Tbys;

        public FrmMain(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            AddTree();

            Tbks = InstanceForm.BDatabase.GetDataTable("select name,dept_id,py_code,wb_code from jc_dept_property where ( jgbm<=0 or jgbm=" + InstanceForm._menuTag.Jgbm + " or jgbm is null) and LAYER=3 and DELETED=0 ");
            Tbys = InstanceForm.BDatabase.GetDataTable("select name,employee_id,py_code,wb_code from jc_employee_property where employee_id in(select EMPLOYEE_ID from JC_EMP_DEPT_ROLE) ");

            
        }

        private void FrmConsole_Load( object sender , EventArgs e )
        {

            txtnf.Text = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Year.ToString();
            txtyf.Text = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Month.ToString();


            int bzybz=rdozy.Checked==true?1:0;
            int khlxid = Convert.ToInt32(Convertor.IsNull(label_title.Tag, ""));
            int ksdm=0;
            int ysdm=0;

            Select_blsz(bzybz,khlxid, ksdm, ysdm);

            Select_ywsj(khlxid,Convert.ToInt32(txtnf.Text),Convert.ToInt32(txtyf.Text), chkzjbl.Checked, rdozy.Checked,chkccbl.Checked);

            butnew_Click(sender, e);

        }


        private void AddTree()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList1;

            TreeNode node1 = treeView1.Nodes.Add("占比控制类型", "占比控制类型");

            string ssql = "select * from JC_YPKHBL_LX ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                TreeNode Cnode30 = node1.Nodes.Add("●" + Convertor.IsNull(tb.Rows[i]["khmc"], ""));
                Cnode30.Tag =  Convertor.IsNull(tb.Rows[i]["khlxid"], "");

                Cnode30.ImageIndex = 1;
            }
            node1.Expand();

            if (tb.Rows.Count == 1)
            {
                label_title.Text = Convertor.IsNull(tb.Rows[0]["khmc"], "");
                label_title.Tag = Convertor.IsNull(tb.Rows[0]["khlxid"], "");
                
            }
        }

        // 回车跳至下一个文本
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                this.SelectNextControl(control, true, false, true, true);
            }
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            try
            {
                long id = 0; int khlxid = 0; int ksdm = 0; int ysdm = 0; double khbl = 0; double yjbl = 0; int bqybz = 0; int bzybz = 0;
                string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                if (Convert.ToInt32(Convertor.IsNull(label_title.Tag,"0"))==0)
                {
                    MessageBox.Show("请选择考核类型", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convertor.IsNumeric(txtkhbl.Text)==false)
                {
                    MessageBox.Show("考核比例请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtkhbl.Focus();
                    return;
                }
                if (Convertor.IsNumeric(txtyjbl.Text) == false)
                {
                    MessageBox.Show("预警比例请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtyjbl.Focus();
                    return;
                }



                bzybz = rdozy.Checked == true ? 1 : 0;
                id = Convert.ToInt64(Convertor.IsNull(butsave.Tag, "0"));
                khlxid = Convert.ToInt32(Convertor.IsNull(label_title.Tag, "0"));
                ksdm = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));
                ysdm = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));
                khbl =  Convert.ToDouble(Convertor.IsNull(txtkhbl.Text, "0"));
                yjbl = Convert.ToDouble(Convertor.IsNull(txtyjbl.Text, "0"));
                bqybz = cmbqybz.Text == "是" ? 1 : 0;
                

                if (khbl>100 || khbl<=0)
                {
                    MessageBox.Show("考核比例设置必须在 1到 100 之间", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (yjbl > 100 || yjbl <= 0)
                {
                    MessageBox.Show("预警比例设置必须在 1到 100之间", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (yjbl>0 && yjbl>khbl)
                {
                     MessageBox.Show("预警比例不能大于考核比例", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     txtyjbl.Focus();
                    return;
                }

                string ssql="";

                ssql = "select * from jc_ypkhbl where khlxid="+khlxid+" ";
                ssql=ssql+" and ksdm="+ksdm+" and ysdm="+ysdm+" and id<>"+id+"";
                DataTable tbcx = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbcx.Rows.Count > 0)
                {
                    MessageBox.Show("已存在 "+txtks.Text.Trim()+"  "+txtys.Text.Trim()+" 的设置数据,不能添加", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (id == 0)
                    ssql = "insert into jc_ypkhbl(khlxid,ksdm,ysdm,khbl,yjbl,bqybz,bzybz,djsj,djy)values("+khlxid+","+ksdm+","+ysdm+","+khbl+","+yjbl+","+bqybz+","+bzybz+",'"+sDate+"',"+InstanceForm.BCurrentUser.EmployeeId+")";
                else
                    ssql = "update jc_ypkhbl set ksdm="+ksdm+",ysdm="+ysdm+",khbl="+khbl+",yjbl="+yjbl+",bqybz="+bqybz+",bzybz="+bzybz+" where id="+id+"";
                InstanceForm.BDatabase.DoCommand(ssql);

                MessageBox.Show("保存成功");

                butnew_Click(sender, e);
                Select_blsz(bzybz,khlxid, 0, 0);

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //查询比例设置
        private void Select_blsz(int bzybz,int khlxid,int ksdm,int ysdm)
        {
            string ssql = "select ID,dbo.fun_getDeptname(ksdm) 科室,dbo.fun_getEmpName(ysdm) 医生,KHBL 考核比例,YJBL 预警比例,(case when BQYBZ=1 then '是' else '' end) 启用,DJSJ 登记时间,dbo.fun_getEmpName(djy) 登记员,KSDM,YSDM from jc_ypkhbl where bzybz="+bzybz+" and khlxid="+khlxid+" ";
            if (ksdm > 0)
                ssql = ssql + " and ksdm=" + ksdm + " ";
            if (ysdm > 0)
                ssql = ssql + " and ysdm=" + ysdm + " ";
            DataTable tb= InstanceForm.BDatabase.GetDataTable(ssql);
            dgvClass.DataSource = tb;

        }

        //查询每月业务数据
        /// <summary>
        /// 
        /// </summary>
        /// <param name="khlxid">考核类型</param>
        /// <param name="nf">年份</param>
        /// <param name="yf">月份</param>
        /// <param name="kfqx">仅开放权限</param>
        /// <param name="bzybz">住院</param>
        /// <param name="ccbl">仅超出比例</param>
        private void Select_ywsj(int khlxid,int nf,int yf,bool kfqx,bool bzybz,bool ccbl)
        {
            DataTable tab = (DataTable)dataGridView1.DataSource;
            if (tab!=null) tab.Rows.Clear();

            int zybz = bzybz == true ? 1 : 0;
            string ssql = "	select * from ( select nf 年份,yf 月份,dbo.fun_getDeptname(ksdm) 科室,dbo.fun_getEmpName(ysdm) 医生,KHBL 考核比例,YPBL 当月比例,"+
                "  (select top 1 '是' from YP_YPKHBL_ZJ where JCID=a.JCID and BQYBZ=1 and nf=" + nf + " and yf=" + yf + ")  开放权限,jcid from yp_ypkhbl_ywsj a inner join JC_YPKHBL b on a.JCID=b.ID where   " +
                "  nf=" + nf + " and yf=" + yf + "  and khlxid="+khlxid+"  and bzybz="+zybz+") a ";
            if (kfqx == true)
                 ssql = ssql + " where 开放权限='是'";
             if (ccbl == true)
             {
                 if (kfqx==true)
                    ssql = ssql + " and 当月比例>考核比例 ";
                 else
                    ssql = ssql + " WHERE 当月比例>考核比例 ";
             }
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            dgvContent.DataSource = tb;

        }

        //查询增加权限记录
        private void Select_zj(long jcid,int nf,int yf)
        {
            string ssql = "	select KSSJ 开放起日期,JSSJ 开放止日期,(case when BQYBZ=1 then '是' else '' end) 启用,DJSJ 登记时间,dbo.fun_getempname(djy) 登记员,BZ 备注,ID,jcid,nf 年份,yf 月份 from YP_YPKHBL_ZJ  where " +
                "  nf=" + nf + " and yf=" + yf + "  and jcid=" + jcid + "  ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            dataGridView1.DataSource = tb;

        }


        #region  输入控制
        private void txtks_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                //Control control = (Control)sender;
                if ((int)e.KeyChar == 13)
                {
                    return;
                };
                if ((int)e.KeyChar == 8)
                {
                    txtks.Text = "";
                    txtks.Tag = "0";
                    return;
                };

                string[] headtext = new string[] { "项目名称", "id", "拼音码", "五笔码" };
                string[] mappingname = new string[] { "name", "dept_id", "py_code", "wb_code" };
                string[] searchfields = new string[] { "py_code", "wb_code" };
                int[] colwidth = new int[] { 300, 50, 100, 80 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbks;
                f.WorkForm = this;
                f.srcControl = toolStrip2;
                //f.Font = control.Font;
                f.Width = 600;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtks.Focus();
                }
                else
                {
                    this.txtks.Text = f.SelectDataRow["name"].ToString().Trim();
                    this.txtks.Tag = f.SelectDataRow["dept_id"].ToString().Trim();
                    txtys.Focus();

                    int bzybz = rdozy.Checked == true ? 1 : 0;
                    int khlxid = Convert.ToInt32(Convertor.IsNull(label_title.Tag, ""));
                    int ksdm = Convert.ToInt32(Convertor.IsNull(txtks.Tag,"0"));
                    int ysdm = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));
                    Select_blsz(bzybz, khlxid, ksdm, ysdm);

                }


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtys_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Control control = (Control)sender;
                if ((int)e.KeyChar == 13)
                {
                    return;
                };
                if ((int)e.KeyChar == 8)
                {
                    txtys.Text = "";
                    txtys.Tag = "0";
                    return;
                };

                string[] headtext = new string[] { "项目名称", "id", "拼音码", "五笔码" };
                string[] mappingname = new string[] { "name", "employee_id", "py_code", "wb_code" };
                string[] searchfields = new string[] { "py_code", "wb_code" };
                int[] colwidth = new int[] { 300, 50, 100, 80 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
                f.WorkForm = this;
                f.srcControl = toolStrip2;
                //f.Font = control.Font;
                f.Width = 600;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtys.Focus();
                }
                else
                {
                    this.txtys.Text = f.SelectDataRow["name"].ToString().Trim();
                    this.txtys.Tag = f.SelectDataRow["employee_id"].ToString().Trim();
                    txtkhbl.Focus();

                    int bzybz = rdozy.Checked == true ? 1 : 0;
                    int khlxid = Convert.ToInt32(Convertor.IsNull(label_title.Tag, ""));
                    int ksdm = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));
                    int ysdm = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));
                    Select_blsz(bzybz, khlxid, ksdm, ysdm);
                }


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtkhbl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                txtyjbl.Focus();
        }

        private void txtyjbl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                cmbqybz.Focus();
        }

        private void cmbqybz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                butsave.Select();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex == 1 || e.Node.ImageIndex == -1) return;
            label_title.Text = Convertor.IsNull(e.Node.Text,"");
            label_title.Tag = Convertor.IsNull(e.Node.Tag,"");

            int bzybz = rdozy.Checked == true ? 1 : 0;
            int khlxid = Convert.ToInt32(Convertor.IsNull(label_title.Tag, ""));
            int ksdm = 0;
            int ysdm = 0;
            Select_blsz(bzybz,khlxid, ksdm, ysdm);
        }

        private void rdomz_CheckedChanged(object sender, EventArgs e)
        {
            butnew_Click(sender, e);
            int bzybz = rdozy.Checked == true ? 1 : 0;
            int khlxid = Convert.ToInt32(Convertor.IsNull(label_title.Tag, ""));
            int ksdm = 0;
            int ysdm = 0;
            Select_blsz(bzybz,khlxid, ksdm, ysdm);

            int nf=Convert.ToInt32(Convertor.IsNull(txtnf.Text,"0"));
            int yf=Convert.ToInt32(Convertor.IsNull(txtyf.Text,"0"));
            Select_ywsj(khlxid, nf, yf, chkzjbl.Checked,rdozy.Checked,chkccbl.Checked);
        }
        #endregion

        private void butnew_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Convertor.IsNull(label_title.Tag, "0")) == 0)
            {
                MessageBox.Show("请选择考核类型", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtks.Text = "";
            txtks.Tag = "0";
            txtys.Text = "";
            txtys.Tag = "0";
            txtkhbl.Text = "";
            txtyjbl.Text = "";
            butsave.Tag = "0";
            cmbqybz.Text = "是";
            txtks.Focus();
        }

        private void butdel_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(Convertor.IsNull(butsave.Tag, "0"));
            if (id == 0)
            {
                MessageBox.Show("请选择要删除的记录", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("您确定要删除第" + txtks.Text + "  "+ txtys.Text+" 的设置数据吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            string ssql = "";

            try
            {
                InstanceForm.BDatabase.BeginTransaction();
                ssql = "delete from jc_ypkhbl where id=" + id + "";
                InstanceForm.BDatabase.DoCommand(ssql);

                ssql = "delete from yp_ypkhbl_ywsj where jcid=" + id + "";
                InstanceForm.BDatabase.DoCommand(ssql);

                ssql = "delete from YP_YPKHBL_ZJ where jcid=" + id + "";
                InstanceForm.BDatabase.DoCommand(ssql);

                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("删除成功");

                int bzybz = rdozy.Checked == true ? 1 : 0;
                int khlxid = Convert.ToInt32(Convertor.IsNull(label_title.Tag, ""));
                int ksdm = 0;
                int ysdm = 0;
                Select_blsz(bzybz,khlxid, ksdm, ysdm);
                butnew_Click(sender, e);

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void butquti_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dgvClass.DataSource;
                if (tb.Rows.Count == 0) return;
                if (dgvClass.CurrentCell == null) return;
                int nrow = dgvClass.CurrentCell.RowIndex;

                string ksmc = Convertor.IsNull(tb.Rows[nrow]["科室"], "");
                int ksdm = Convert.ToInt32(tb.Rows[nrow]["ksdm"]);


                string ysmc = Convertor.IsNull(tb.Rows[nrow]["医生"], "");
                int ysdm = Convert.ToInt32(tb.Rows[nrow]["ysdm"]);
                double khbl = Convert.ToDouble(tb.Rows[nrow]["考核比例"]);
                double yjbl = Convert.ToDouble(tb.Rows[nrow]["预警比例"]);
                string bqybz = Convertor.IsNull(tb.Rows[nrow]["启用"], "否");
                long id = Convert.ToInt64(Convertor.IsNull(tb.Rows[nrow]["id"], "0"));

                txtks.Text = ksmc;
                txtks.Tag = ksdm.ToString();
                txtys.Text = ysmc;
                txtys.Tag = ysdm.ToString();
                txtkhbl.Text = khbl.ToString();
                txtyjbl.Text = yjbl.ToString();
                cmbqybz.Text = bqybz.ToString();
                butsave.Tag = id.ToString();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butcx_Click(object sender, EventArgs e)
        {

            try
            {
                int khlxid = Convert.ToInt32(Convertor.IsNull(label_title.Tag, "0"));
                if (Convertor.IsNumeric(txtnf.Text) == false || Convertor.IsNumeric(txtyf.Text) == false)
                {
                    MessageBox.Show("年份和月份必须输入数字", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int nf = Convert.ToInt32(Convertor.IsNull(txtnf.Text, "0"));
                int yf = Convert.ToInt32(Convertor.IsNull(txtyf.Text, "0"));

                if (nf <= 0 || yf <= 0)
                {
                    MessageBox.Show("年份和月份都必须输入", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Select_ywsj(khlxid, nf, yf, chkzjbl.Checked, rdozy.Checked,chkccbl.Checked);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 延长权限_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dgvContent.DataSource;
            if (tb.Rows.Count == 0) return;
            if (dgvContent.CurrentCell == null) return;
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            int nrow = dgvContent.CurrentCell.RowIndex;


            long jcid = Convert.ToInt64(tb.Rows[nrow]["jcid"]);
            Frmaddbl frm = new Frmaddbl();
            frm.lblks.Text=tb.Rows[nrow]["科室"].ToString();
            frm.lblys.Text=tb.Rows[nrow]["医生"].ToString();
            frm.ShowDialog();

            if (frm.bok == false) return;

            DateTime rq1 = frm.dtprq1.Value;
            DateTime rq2 = frm.dtprq2.Value;
            int nf=Convert.ToInt32(tb.Rows[nrow]["年份"]);
            int yf=Convert.ToInt32(tb.Rows[nrow]["月份"]);
            int bqybz=frm.chkqybz.Checked==true?1:0;

            string ssql = "";
            ssql = " insert into YP_YPKHBL_ZJ(jcid,nf,yf,kssj,jssj,djsj,djy,bqybz)values(" + jcid + "," + nf + "," + yf + ",'" + rq1.ToShortDateString() + "','" + rq2.ToShortDateString() + "','" + sDate + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + bqybz + ")";
            InstanceForm.BDatabase.DoCommand(ssql);

            MessageBox.Show("保存成功");

            Select_zj(jcid, nf, yf);

        }

        private void dgvContent_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dgvContent.DataSource;
            if (tb.Rows.Count == 0) return;
            if (dgvContent.CurrentCell == null) return;
            int nrow = dgvContent.CurrentCell.RowIndex;

            long jcid = Convert.ToInt64(tb.Rows[nrow]["jcid"]);
            int nf = Convert.ToInt32(tb.Rows[nrow]["年份"]);
            int yf = Convert.ToInt32(tb.Rows[nrow]["月份"]);
            Select_zj(jcid, nf, yf);
        }

        private void 修改_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb.Rows.Count == 0) return;
            if (dataGridView1.CurrentCell == null) return;
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            int nrow = dataGridView1.CurrentCell.RowIndex;
            string ssql = "";

            long id = Convert.ToInt64(tb.Rows[nrow]["id"]);
            long jcid = Convert.ToInt64(tb.Rows[nrow]["jcid"]);
            ssql = "select *,dbo.fun_getdeptname(ksdm)  科室,dbo.fun_getempname(ysdm) 医生 from jc_ypkhbl where id="+jcid+"";
            DataTable tbjc = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tbjc.Rows.Count == 0) return;

            Frmaddbl frm = new Frmaddbl();
            frm.lblks.Text = tbjc.Rows[0]["科室"].ToString();
            frm.lblys.Text = tbjc.Rows[0]["医生"].ToString();
            frm.dtprq1.Value =Convert.ToDateTime( tb.Rows[nrow]["开放起日期"]) ;
            frm.dtprq2.Value =Convert.ToDateTime( tb.Rows[nrow]["开放止日期"]);
            frm.ShowDialog();

            if (frm.bok == false) return;

            DateTime rq1 = frm.dtprq1.Value;
            DateTime rq2 = frm.dtprq2.Value;
            int nf = Convert.ToInt32(tb.Rows[0]["年份"]);
            int yf = Convert.ToInt32(tb.Rows[0]["月份"]);
            int bqybz = frm.chkqybz.Checked == true ? 1 : 0;

           
            ssql = "update YP_YPKHBL_ZJ set kssj='"+rq1.ToShortDateString()+"', jssj='"+rq2.ToShortDateString()+"',bqybz="+bqybz+" where id="+id+"";
            InstanceForm.BDatabase.DoCommand(ssql);

            MessageBox.Show("修改成功");

            Select_zj(jcid, nf, yf);
        }

        private void 删除_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb.Rows.Count == 0) return;
            if (dataGridView1.CurrentCell == null) return;
            int nrow = dataGridView1.CurrentCell.RowIndex;
            string ssql = "";

            long id = Convert.ToInt64(tb.Rows[nrow]["id"]);
            long jcid = Convert.ToInt64(tb.Rows[nrow]["jcid"]);
            ssql = "select * from jc_ypkhbl where id=" + jcid + "";
            DataTable tbjc = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tbjc.Rows.Count == 0) return;

            if (MessageBox.Show("您确定要删除当前记录吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            int nf = Convert.ToInt32(tb.Rows[0]["年份"]);
            int yf = Convert.ToInt32(tb.Rows[0]["月份"]);

            ssql = "DELETE YP_YPKHBL_ZJ  where id=" + id + "";
            InstanceForm.BDatabase.DoCommand(ssql);

            MessageBox.Show("删除成功");

            Select_zj(jcid, nf, yf);
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)this.dgvClass.DataSource;

                // 创建Excel对象                  
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel无法启动");
                    return;
                }
                // 创建Excel工作薄
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // 列索引，行索引，总列数，总行数
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = 0;
                int RowCount = tb.Rows.Count;
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    if (dgvClass.Columns[i].Visible == true)
                        colCount = colCount + 1;
                }

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = label_title.Text;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                //查询条件
                string bz = "";
                // 设置条件
                Excel.Range rangeT = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                rangeT.MergeCells = true;
                object[,] objDataT = new object[1, 1];
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                objDataT[0, 0] = bz;
                rangeT.Value2 = objDataT;

                rangeT = xlSheet.get_Range(xlApp.Cells[3, 1], xlApp.Cells[3, colCount]);
                rangeT.MergeCells = true;
                object[,] objDataT2 = new object[1, 1];
                objDataT2[0, 0] = bz;
                rangeT.Value2 = objDataT2;




                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    if (dgvClass.Columns[i].Visible==true)
                        objData[0, colIndex++] = dgvClass.Columns[i].HeaderText;
                }
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        if (dgvClass.Columns[j].Visible==true)
                        {
                            objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString();
                        }
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butexcel2_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)this.dgvContent.DataSource;

                // 创建Excel对象                  
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel无法启动");
                    return;
                }
                // 创建Excel工作薄
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // 列索引，行索引，总列数，总行数
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = 0;
                int RowCount = tb.Rows.Count;
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    if (dgvClass.Columns[i].Visible == true)
                        colCount = colCount + 1;
                }

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = label_title.Text;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                //查询条件
                string bz = "";
                // 设置条件
                Excel.Range rangeT = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                rangeT.MergeCells = true;
                object[,] objDataT = new object[1, 1];
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                objDataT[0, 0] = bz;
                rangeT.Value2 = objDataT;

                rangeT = xlSheet.get_Range(xlApp.Cells[3, 1], xlApp.Cells[3, colCount]);
                rangeT.MergeCells = true;
                object[,] objDataT2 = new object[1, 1];
                objDataT2[0, 0] = bz;
                rangeT.Value2 = objDataT2;




                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    if (dgvContent.Columns[i].Visible == true)
                        objData[0, colIndex++] = dgvContent.Columns[i].HeaderText;
                }
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        if (dgvContent.Columns[j].Visible == true)
                        {
                            objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString();
                        }
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[4, 1], xlApp.Cells[RowCount + 4, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }





    }
}