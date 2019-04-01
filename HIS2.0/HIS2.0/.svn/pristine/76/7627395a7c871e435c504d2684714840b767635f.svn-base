using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
using TrasenClasses.DatabaseAccess;
namespace ts_yk_zjjgd
{
    public partial class Frmscjh : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private RelationalDatabase db;

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        /// <param name="menuTag">菜单对象	</param>
        /// <param name="chineseName">菜单中文名</param>
        /// <param name="mdiParent">当前窗口父对象</param>
        public Frmscjh(MenuTag menuTag,string chineseName,Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            db = InstanceForm.BDatabase;
            this.Text = _chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            this.WindowState = FormWindowState.Maximized;

        }

        private void Frmscjh_Load(object sender, EventArgs e)
        {
            #region 添加业务类型
            string ssql = " select '001' code,  '制剂计划' name union select '002' code, '加工计划' name ";
            DataTable dtYwlx = db.GetDataTable(ssql);
            cmbYwlx.ValueMember = "code";
            cmbYwlx.DisplayMember = "name";
            cmbYwlx.DataSource = dtYwlx;
            #endregion

            if (_menuTag.Function_Name == "Fun_ts_yp_scjh_zj")
            {
                cmbYwlx.SelectedValue = "001"; //制剂
            }
            else
            {
                cmbYwlx.SelectedValue = "002"; //加工
            }

            Yp.AddcmbCk(true, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);
            butref_Click(0, e);
        }

        private void butnew_Click(object sender, EventArgs e)
        {
            
            if (cmbYwlx.SelectedValue.ToString() == "002")
            {
                Guid jhid = Guid.Empty;
                Frmypjg frm = new Frmypjg(_menuTag, _chineseName, _mdiParent, jhid);
                frm.Show();
                //DialogResult result = frm.ShowDialog();
                //if (result == DialogResult.Cancel)
                //{
                //    butref_Click(0, e);
                //}
            }
            if (cmbYwlx.SelectedValue.ToString() == "001")
            {
                Guid jhid = Guid.Empty;
                Frmypzj frm = new Frmypzj(_menuTag, _chineseName, _mdiParent, jhid);
                frm.Show();
                //DialogResult result= frm.ShowDialog();
                //if (result == DialogResult.Cancel)
                //{
                //    butref_Click(0, e);
                //}
            }
        }

        //刷新
        private void butref_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdo2.Checked && chkdjsj.Checked == false)
                {
                    MessageBox.Show("查询的时间过长！");
                    return;
                }
                string ssql = " ";
                int bshbz = rdo2.Checked ? 1 : 0;
                ssql += string.Format(" and a.bshbz ={0} ", bshbz);
                int deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));//库房id
                ssql += string.Format(" and a.deptid ={0}", deptid);
                if (chkdjsj.Checked)
                {
                    string t1 = dtp1.Value.ToShortDateString() + " 00:00:01";
                    string t2 = dtp2.Value.ToShortDateString() + " 23:59:59";
                    ssql += string.Format(" and a.djrq>='{0}' and a.djrq<='{1}' ", t1, t2);
                }
                ssql += string.Format(" and bscbz <>1 and a.ywlx='{0}'", Convertor.IsNull(cmbYwlx.SelectedValue, "")); //制剂 加工
                DataTable dt = YK_ZJJG_JH.GetJhDataTable(ssql, " order by a.shrq,a.djrq ", db);
                dataGridView1.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //关闭
        private void butclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //导出
        private void butexcel_Click(object sender, EventArgs e)
        {

        }

        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo1.Checked)
            {
                cshrq.Visible = false;
                c审核员.Visible = false;
               

                crkdh.Visible = false;
                crkjhje.Visible = false;
                crkpfje.Visible = false;
                crklsje.Visible = false;
                dataGridView1.Columns["crkdh"].Visible = false;

                dataGridView1.Columns["cshrq"].Visible = false;
                dataGridView1.Columns["c审核员"].Visible = false;

                btnDel.Enabled = true;
                btnUnSh.Enabled = false;

                crkpfje.Visible = false; dataGridView1.Columns["crkpfje"].Visible = false;
                crklsje.Visible = false; dataGridView1.Columns["crklsje"].Visible = false;
                crkdh.Visible = false; dataGridView1.Columns["crkdh"].Visible = false;

                
            }
            if (rdo2.Checked)
            {
                cshrq.Visible = true;
                c审核员.Visible = true;

               
                dataGridView1.Columns["cshrq"].Visible = true;
                dataGridView1.Columns["c审核员"].Visible = true;

                crkpfje.Visible = true; dataGridView1.Columns["crkpfje"].Visible = true;
                crklsje.Visible = true; dataGridView1.Columns["crklsje"].Visible = true;
                crkdh.Visible = true; dataGridView1.Columns["crkdh"].Visible = true;

                dataGridView1.Columns["crkdh"].Visible = true;

                btnDel.Enabled = false;
                btnUnSh.Enabled = true;

                chkdjsj.Checked = true;
                dtp1.Enabled = true;
                dtp2.Enabled = true;
            }
            butref_Click(0, e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (cmbYwlx.SelectedValue.ToString() == "002")
                {
                    Guid jhid = new Guid(dataGridView1.Rows[e.RowIndex].Cells["cid"].Value.ToString());
                    Frmypjg frm = new Frmypjg(_menuTag, _chineseName, _mdiParent, jhid);
                    frm.Show();
                }
                if (cmbYwlx.SelectedValue.ToString() == "001")
                {
                    Guid jhid = new Guid(dataGridView1.Rows[e.RowIndex].Cells["cid"].Value.ToString());
                    Frmypzj frm = new Frmypzj(_menuTag, _chineseName, _mdiParent, jhid);
                    frm.Show();
                }


            }
        }

        //移除计划
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                if (rowIndex < 0) return;
                Guid jhid = new Guid(dataGridView1.Rows[rowIndex].Cells["cid"].Value.ToString());
                List<YK_ZJJG_JH> listJh = YK_ZJJG_JH.GetJhList(string.Format(" and a.id= '{0}' and a.bshbz=0", jhid),"",db);
                if (listJh.Count <= 0)
                {
                    MessageBox.Show("找不到该计划或该计划已审核，请刷新后重试！");
                    return;
                }
                YK_ZJJG_JH jh = listJh[0];
                DialogResult result = MessageBox.Show("确定要移除计划？", "移除计划", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel) return;
                db.BeginTransaction();
                
                YK_ZJJG_Class.RemoveScjh(jh, db,InstanceForm._menuTag.Jgbm);
                db.CommitTransaction();
                MessageBox.Show("移除计划成功！");
                butref_Click(0, e);
            }
            catch(Exception err)
            {
                db.RollbackTransaction();
                MessageBox.Show("移除计划失败！ "+err.Message);
            }
        }

        //取消审核
        private void btnUnSh_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                if (rowIndex < 0) return;
                Guid jhid = new Guid(dataGridView1.Rows[rowIndex].Cells["cid"].Value.ToString());
                List<YK_ZJJG_JH> listJh = YK_ZJJG_JH.GetJhList(string.Format(" and a.id= '{0}' and a.bshbz=1", jhid),"",db);
                if (listJh.Count <= 0)
                {
                    MessageBox.Show("找不到该计划或该计划未审核，请刷新后重试！");
                    return;
                }
                YK_ZJJG_JH jh = listJh[0];
                DialogResult result = MessageBox.Show("确定取消审核？", "取消审核", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel) return;
                db.BeginTransaction();
                YK_ZJJG_Class.UnShScJh(jh,db,InstanceForm._menuTag.Jgbm);
                db.CommitTransaction();
                MessageBox.Show("取消审核成功！");
                butref_Click(0, e);
            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                MessageBox.Show("取消审核失败！" + err.Message);
            }
        }

        private void cmbYwlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            butref_Click(0, e);
        }

        //窗体重新获得焦点时刷新
        private void Frmscjh_Activated(object sender, EventArgs e)
        {
            butref_Click(0, e);
        }

        private void chkdjsj_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdjsj.Checked)
            {
                dtp1.Enabled = true;
                dtp2.Enabled = true;
            }
            else
            {
                dtp1.Enabled = false;
                dtp2.Enabled = false;
            }
        }


    }
}