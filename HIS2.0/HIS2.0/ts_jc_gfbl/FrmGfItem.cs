using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_jc_gfbl
{
    public partial class FrmGfItem : Form
    {
        public FrmGfItem()
        {
            InitializeComponent();
        }

        private void FrmGfItem_Load(object sender, EventArgs e)
        {

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;


            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ReadOnly = true;
            this.dataGridView2.AutoGenerateColumns = false;

            try
            {

                DataTable dtCnt = new DataTable();
                dtCnt.Columns.Add("ID", typeof(string));
                dtCnt.Columns.Add("NAME", typeof(string));

                dtCnt.Rows.Add(new object[] { "0", "普通公费" });
                dtCnt.Rows.Add(new object[] { "1", "特殊治疗" });
                dtCnt.Rows.Add(new object[] { "2", "特殊检查" });
                dtCnt.Rows.Add(new object[] { "3", "床位费" });
                dtCnt.Rows.Add(new object[] { "4", "床位冷暖费" });

                Addcmb(cmbJsfs, dtCnt, "ID", "NAME");
            }
            catch { }

            try
            {

                DataTable dtCnt = new DataTable();
                dtCnt.Columns.Add("ID", typeof(string));
                dtCnt.Columns.Add("NAME", typeof(string));

                dtCnt.Rows.Add(new object[] { "1", "甲类" });
                dtCnt.Rows.Add(new object[] { "2", "乙类" });

                Addcmb(cmbSl, dtCnt, "ID", "NAME");

                cmbSl.SelectedValue = "2";
            }
            catch { }

            DoQueryItems();
            DoQueryNonItems();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DoQueryItems();
        }

        private void btnQueryNon_Click(object sender, EventArgs e)
        {
            DoQueryNonItems();
        }

        private void btnPublicFee_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dataGridView1.DataSource as DataTable).Rows.Count <= 0)
                {
                    MessageBox.Show("请选择一条 未匹配项目 进行【转公费】操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string xmid = this.dataGridView1.CurrentRow.Cells["xmid_n"].Value.ToString();
                string xmly = this.dataGridView1.CurrentRow.Cells["xmly_n"].Value.ToString();
                string name = this.dataGridView1.CurrentRow.Cells["name"].Value.ToString();

                if (MessageBox.Show("项目：【" + name + "】 是否确认【转公费】操作？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    return;

                string strSql = string.Format(@"insert into JC_gf_item (id,xmly,xmid,xmfl_code,xmfl_name,del_bit,Opr_man,Opr_time) VALUES('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}')",
                    Guid.NewGuid(), xmly, xmid, cmbSl.SelectedValue.ToString().Trim(), cmbSl.Text.Trim(), "0", InstanceForm._currentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm._database));
                int iReturn = InstanceForm._database.DoCommand(strSql);

                if (iReturn <= 0)
                {
                    MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DoQueryItems();
                DoQueryNonItems();
                DoGetFocus(xmid, xmly, dataGridView2);
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelfFee_Click(object sender, EventArgs e)
        {

            try
            {
                if ((dataGridView2.DataSource as DataTable).Rows.Count <= 0)
                {
                    MessageBox.Show("请选择一条 已匹配项目 进行【转自费】操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string lx = this.dataGridView2.CurrentRow.Cells["lx"].Value.ToString();

                if (!lx.Equals("0"))
                {
                    MessageBox.Show("特治、特检等项目不能【转自费】！\n\n请先进行【取消补充】操作后,再进行【转自费】操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string xmid = this.dataGridView2.CurrentRow.Cells["xmid"].Value.ToString();
                string xmly = this.dataGridView2.CurrentRow.Cells["xmly"].Value.ToString();
                string name = this.dataGridView2.CurrentRow.Cells["item_name"].Value.ToString();

                if (MessageBox.Show("项目：【" + name + "】 是否确认【转自费】操作？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    return;

                string strSql = string.Format(@"update JC_gf_item set del_bit=1,Del_man='{0}',Del_time='{1}' where xmid='{2}' and xmly='{3}'",
                     InstanceForm._currentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm._database), xmid, xmly);
                int iReturn = InstanceForm._database.DoCommand(strSql);

                if (iReturn <= 0)
                {
                    MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DoQueryItems();
                DoQueryNonItems();
                DoGetFocus(xmid, xmly, dataGridView1);
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dataGridView2.DataSource as DataTable).Rows.Count <= 0)
                {
                    MessageBox.Show("请选择一条普通公费项目 进行【新增补充】操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string lx = Convertor.IsNull(this.dataGridView2.CurrentRow.Cells["lx"].Value, "0").Trim();

                string xmid = this.dataGridView2.CurrentRow.Cells["xmid"].Value.ToString();
                string xmly = this.dataGridView2.CurrentRow.Cells["xmly"].Value.ToString();
                string name = this.dataGridView2.CurrentRow.Cells["item_name"].Value.ToString();

                if (xmly.Equals("1"))
                {
                    MessageBox.Show("药品 不能进行【新增补充】操作\n\n请选择正确的项目进行操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!lx.Equals("0"))
                {
                    MessageBox.Show("只有普通公费项目 才能进行【新增补充】操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string lx_bcjs = cmbJsfs.SelectedValue.ToString().Trim();
                if (lx_bcjs.Equals("0"))
                {
                    MessageBox.Show("计算方式 不能选择【普通公费】", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbJsfs.Focus();
                    return;
                }

                decimal d = 0M;

                if (!string.IsNullOrEmpty(txtTsbl.Text.Trim()))
                {
                    if (!decimal.TryParse(txtTsbl.Text.Trim(), out d))
                    {
                        MessageBox.Show("【特殊比例】 只能为 数值型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTsbl.Select();
                        txtTsbl.Focus();
                        return;
                    }

                    if (d > 1)
                    {
                        MessageBox.Show("【特殊比例】 不能大于【1】", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTsbl.Select();
                        txtTsbl.Focus();
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(txtSfbl.Text.Trim()))
                {
                    if (!decimal.TryParse(txtSfbl.Text.Trim(), out d))
                    {
                        MessageBox.Show("【上浮比例】 只能为 数值型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSfbl.Select();
                        txtSfbl.Focus();
                        return;
                    }

                    if (d > 1)
                    {
                        MessageBox.Show("【上浮比例】 不能大于【1】", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSfbl.Select();
                        txtSfbl.Focus();
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(txtXj.Text.Trim()))
                {
                    if (!decimal.TryParse(txtXj.Text.Trim(), out d))
                    {
                        MessageBox.Show("【上浮比例】 只能为 数值型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtXj.Select();
                        txtXj.Focus();
                        return;
                    }
                }

                if (MessageBox.Show("项目：【" + name + "】 是否确认【新增补充】操作？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    return;

                string id = this.dataGridView2.CurrentRow.Cells["id"].Value.ToString();
                //string xmid = this.dataGridView2.CurrentRow.Cells["xmid"].Value.ToString();
                //string xmly = this.dataGridView2.CurrentRow.Cells["xmly"].Value.ToString();
                string zfbl = string.IsNullOrEmpty(txtTsbl.Text.Trim()) ? "0" : txtTsbl.Text.Trim();
                string sfbl = string.IsNullOrEmpty(txtSfbl.Text.Trim()) ? "0" : txtSfbl.Text.Trim();
                string xj = string.IsNullOrEmpty(txtXj.Text.Trim()) ? "0" : txtXj.Text.Trim();

                string lx_bc = lx_bcjs.Equals("3") ? "0" : lx_bcjs.Equals("4") ? "0" : lx_bcjs;
                string lx_bcmc = cmbJsfs.Text.ToString().Trim();

                string strSql = string.Format(@"select count(1) as num from JC_gf_itemBc where xmid='{0}' and xmly='{1}' and del_bit=0", xmid, xmly);
                int iNum = int.Parse(InstanceForm._database.GetDataResult(strSql).ToString());
                if (iNum > 0)
                {
                    MessageBox.Show("项目:" + txtName.Text + " ,已存在有效记录,请刷新已匹配项目后首拼检索确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                strSql = string.Format(@"insert into JC_gf_itemBc (id,item_id,xmly,xmid,zfbl,sfbl,xj,lx_bc,lx_bcmc,lx_bcjs,opr_man,opr_time,del_bit) VALUES('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
                     Guid.NewGuid(), id, xmly, xmid, zfbl, sfbl, xj, lx_bc, lx_bcmc, lx_bcjs, InstanceForm._currentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm._database), "0");
                int iReturn = InstanceForm._database.DoCommand(strSql);

                if (iReturn <= 0)
                {
                    MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DoQueryItems();
                DoGetFocus(xmid, xmly, dataGridView2);
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            try
            {
                if ((dataGridView2.DataSource as DataTable).Rows.Count <= 0)
                {
                    MessageBox.Show("请选择一条特殊比例项目 进行【取消补充】操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string lx = Convertor.IsNull(this.dataGridView2.CurrentRow.Cells["lx"].Value, "0").Trim();

                if (lx.Equals("0"))
                {
                    MessageBox.Show("只有特殊比例项目 才能进行【取消补充】操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string xmid = this.dataGridView2.CurrentRow.Cells["xmid"].Value.ToString();
                string xmly = this.dataGridView2.CurrentRow.Cells["xmly"].Value.ToString();
                string name = this.dataGridView2.CurrentRow.Cells["item_name"].Value.ToString();

                if (MessageBox.Show("项目：【" + name + "】 是否确认【取消补充】操作？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    return;

                string strSql = string.Format(@"update JC_gf_itemBc set del_bit=1,Del_man='{0}',Del_time='{1}' where xmid='{2}' and xmly='{3}'",
                     InstanceForm._currentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm._database), xmid, xmly);
                int iReturn = InstanceForm._database.DoCommand(strSql);

                if (iReturn <= 0)
                {
                    MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DoQueryItems();
                DoGetFocus(xmid, xmly, dataGridView2);
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoQueryItems()
        {
            try
            {
                DataTable dt = DoQueryItems("1");
                if (dt != null)
                {
                    this.dataGridView2.DataSource = dt;

                    DoFilItems();

                    (this.dataGridView2.DataSource as DataTable).AcceptChanges();
                }
            }
            catch { }
        }

        private void DoQueryNonItems()
        {
            try
            {
                DataTable dt = DoQueryNonItems("1");
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;

                    DoFilNonItems();

                    (this.dataGridView1.DataSource as DataTable).AcceptChanges();
                }
            }
            catch { }
        }

        private DataTable DoQueryItems(params object[] args)
        {
            try
            {
                string strSql = "";

                if (chkAll.Checked)
                {
                    strSql = string.Format(@"
                                                select a.name,a.gg,a.lsj,a.dw,cast(a.xmid as varchar(10)) xmid ,a.xmly,pym,wbm,b.id,
                                                c.zfbl,c.sfbl,c.xj,c.lx_bcmc,c.lx_bcjs,isnull(c.isshowmsg,0) as isshowmsg,isnull(c.issh,0) as issh,case a.xmly when  1 then '药品' when 2 then '项目' end as 类别,
                                                ISNULL(c.lx_bcjs,0) as lx ,b.xmfl_name
                                                from 
                                                (
                                                select ITEM_NAME as name,'' as gg,ITEM_UNIT as dw,COST_PRICE as lsj,ITEM_ID as xmid,2 as xmly,PY_CODE as pym,WB_CODE as wbm 
                                                from JC_HSITEMDICTION 
                                                union
                                                select S_YPPM as name,S_YPGG as gg,S_YPDW as dw,LSJ as lsj,CJID as xmid,1 as xmly ,PYM,WBM 
                                                from VI_YP_YPCD 
                                                where BDELETE=0
                                                )a
                                                inner join JC_gf_item b on a.xmid=b.xmid and a.xmly=b.xmly and b.del_bit=0
                                                left join JC_gf_itemBc c on b.id=c.item_id and c.del_bit=0 and c.lx_bcjs>0");
                }
                else
                {
                    strSql = string.Format(@"
                                                select a.name,a.gg,a.lsj,a.dw,cast(a.xmid as varchar(10)) xmid ,a.xmly,pym,wbm,b.id,
                                                c.zfbl,c.sfbl,c.xj,c.lx_bcmc,c.lx_bcjs,isnull(c.isshowmsg,0) as isshowmsg,isnull(c.issh,0) as issh,case a.xmly when  1 then '药品' when 2 then '项目' end as 类别,
                                                ISNULL(c.lx_bcjs,0) as lx ,b.xmfl_name
                                                from 
                                                (
                                                select ITEM_NAME as name,'' as gg,ITEM_UNIT as dw,COST_PRICE as lsj,ITEM_ID as xmid,2 as xmly,PY_CODE as pym,WB_CODE as wbm 
                                                from JC_HSITEMDICTION where DELETE_BIT=0 
                                                union
                                                select S_YPPM as name,S_YPGG as gg,S_YPDW as dw,LSJ as lsj,CJID as xmid,1 as xmly ,PYM,WBM 
                                                from VI_YP_YPCD 
                                                where BDELETE=0
                                                )a
                                                inner join JC_gf_item b on a.xmid=b.xmid and a.xmly=b.xmly and b.del_bit=0
                                                left join JC_gf_itemBc c on b.id=c.item_id and c.del_bit=0 and c.lx_bcjs>0");
                }


                DataTable dt = InstanceForm._database.GetDataTable(strSql);

                if (dt == null)
                {
                    return null;
                }

                DataView dv = dt.DefaultView;
                dv.Sort = "xmly,lx";

                dt = dv.ToTable();

                return dt;

            }
            catch
            {
                return null;
            }
        }

        private DataTable DoQueryNonItems(params object[] args)
        {
            try
            {
                string strSql = "";

                if (chkAll.Checked)
                {
                    strSql = string.Format(@"
                                                select a.name,a.gg,a.lsj,a.dw,cast(a.xmid as varchar(10)) xmid ,a.xmly,a.pym,a.wbm,case a.xmly when  1 then '药品' when 2 then '项目' end as 类别
                                                from 
                                                (
                                                select ITEM_NAME as name,'' as gg,ITEM_UNIT as dw,COST_PRICE as lsj,ITEM_ID as xmid,2 as xmly,PY_CODE as pym,WB_CODE as wbm 
                                                from JC_HSITEMDICTION 
                                                union
                                                select S_YPPM as name,S_YPGG as gg,S_YPDW as dw,LSJ as lsj,CJID as xmid,1 as xmly ,PYM,WBM 
                                                from VI_YP_YPCD 
                                                where BDELETE=0
                                                )a
                                                where not exists 
                                                (
                                                select 1 from JC_gf_item b where a.xmid=b.xmid and a.xmly=b.xmly and b.del_bit=0  
                                                )");
                }
                else
                {
                    strSql = string.Format(@"
                                                select a.name,a.gg,a.lsj,a.dw,cast(a.xmid as varchar(10)) xmid ,a.xmly,a.pym,a.wbm,case a.xmly when  1 then '药品' when 2 then '项目' end as 类别
                                                from 
                                                (
                                                select ITEM_NAME as name,'' as gg,ITEM_UNIT as dw,COST_PRICE as lsj,ITEM_ID as xmid,2 as xmly,PY_CODE as pym,WB_CODE as wbm 
                                                from JC_HSITEMDICTION where DELETE_BIT=0 
                                                union
                                                select S_YPPM as name,S_YPGG as gg,S_YPDW as dw,LSJ as lsj,CJID as xmid,1 as xmly ,PYM,WBM 
                                                from VI_YP_YPCD 
                                                where BDELETE=0
                                                )a
                                                where not exists 
                                                (
                                                select 1 from JC_gf_item b where a.xmid=b.xmid and a.xmly=b.xmly and b.del_bit=0  
                                                )");
                }

                DataTable dt = InstanceForm._database.GetDataTable(strSql);

                if (dt == null)
                {
                    return null;
                }

                DataView dv = dt.DefaultView;
                dv.Sort = "xmly";

                dt = dv.ToTable();

                return dt;

            }
            catch
            {
                return null;
            }
        }

        private void DoFilItems()
        {

            try
            {
                DataTable dtBind = dataGridView2.DataSource as DataTable;

                if (!string.IsNullOrEmpty(txtQueryItem.Text.Trim()))
                {
                    dtBind.DefaultView.RowFilter = " name like '%" + txtQueryItem.Text.Trim() + "%' or pym like '%" + txtQueryItem.Text.Trim() + "%' or xmid like '%" + txtQueryItem.Text.Trim() + "%'";
                }
                else
                {
                    dtBind.DefaultView.RowFilter = "";
                }

                txtQueryItem.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DoFilNonItems()
        {

            try
            {
                DataTable dtBind = dataGridView1.DataSource as DataTable;

                if (!string.IsNullOrEmpty(txtQueryNonItem.Text.Trim()))
                {
                    dtBind.DefaultView.RowFilter = " name like '%" + txtQueryNonItem.Text.Trim() + "%' or pym like '%" + txtQueryNonItem.Text.Trim() + "%' or xmid like '" + txtQueryNonItem.Text.Trim() + "%'";
                }
                else
                {
                    dtBind.DefaultView.RowFilter = "";
                }

                txtQueryNonItem.Select();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtQueryItem_TextChanged(object sender, EventArgs e)
        {
            DoFilItems();
        }

        private void txtQueryNonItem_TextChanged(object sender, EventArgs e)
        {
            DoFilNonItems();
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentCell == null)
                    return;
                this.dataGridView2.EndEdit();

                string lx = this.dataGridView2.CurrentRow.Cells["lx"].Value.ToString().Trim();

                if (lx.Equals("0"))
                {
                    btnAdd.Enabled = true;
                    btnDel.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = false;
                    btnDel.Enabled = true;
                }

                cmbJsfs.SelectedValue = Convertor.IsNull(this.dataGridView2.CurrentRow.Cells["lx"].Value, "0");
                txtName.Text = Convertor.IsNull(this.dataGridView2.CurrentRow.Cells["item_name"].Value, "");
                txtTsbl.Text = Convertor.IsNull(this.dataGridView2.CurrentRow.Cells["zfbl"].Value, "");
                txtSfbl.Text = Convertor.IsNull(this.dataGridView2.CurrentRow.Cells["sfbl"].Value, "");
                txtXj.Text = Convertor.IsNull(this.dataGridView2.CurrentRow.Cells["xj"].Value, "");

                chkIsSh.Checked = Convertor.IsNull(this.dataGridView2.CurrentRow.Cells["issh"].Value, "0").Trim().Equals("1");
                chkIsShow.Checked = Convertor.IsNull(this.dataGridView2.CurrentRow.Cells["isshowmsg"].Value, "0").Trim().Equals("1");

                //cmbYblx.SelectedValue = this.dataGridView1.CurrentRow.Cells["YBLXID"].Value.ToString();
                //cmbYbzlx.SelectedValue = this.dataGridView1.CurrentRow.Cells["ybzlx"].Value.ToString();
                //cmbSflb.SelectedValue = this.dataGridView1.CurrentRow.Cells["lx_bcjs"].Value.ToString();
                //txtGfbl.Text = this.dataGridView1.CurrentRow.Cells["zfbl"].Value.ToString();
                //txtGfbl.Text = this.dataGridView1.CurrentRow.Cells["zfbl"].Value.ToString();
                //txtBcbl.Text = this.dataGridView1.CurrentRow.Cells["sfbl"].Value.ToString();
                //txtZgxj.Text = this.dataGridView1.CurrentRow.Cells["xj"].Value.ToString();
            }
            catch { }
        }

        private void DoGetFocus(string xmid, string xmly, DataGridView dgv)
        {
            if (dgv.Columns.Contains("xmid") && dgv.Columns.Contains("xmly"))
            {

                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    if (dr.Cells["xmid"].Value.ToString().Equals(xmid) && dr.Cells["xmly"].Value.ToString().Equals(xmly))
                    {
                        dr.Selected = true;
                        dgv.CurrentCell = dr.Cells["item_name"];
                    }
                    else
                    {
                        dr.Selected = false;
                    }
                }

            }
            else if (dgv.Columns.Contains("xmid_n") && dgv.Columns.Contains("xmly_n"))
            {
                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    if (dr.Cells["xmid_n"].Value.ToString().Equals(xmid) && dr.Cells["xmly_n"].Value.ToString().Equals(xmly))
                    {
                        dr.Selected = true;
                    }
                    else
                    {
                        dr.Selected = false;
                    }
                }
            }
        }

        private void btnExportSef_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = dataGridView1.DataSource as DataTable;
                if (dt == null || dt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有数据需要导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //saveFileDialog1.OverwritePrompt
                string table = @"";

                //设置文件类型
                //书写规则例如：txt files(*.txt)|*.txt  dBase(*.dbf)
                saveFileDialog1.Filter = "Excel files(*.xls)|*.xls|All files(*.*)|*.*";
                //设置默认文件名（可以不设置）
                saveFileDialog1.FileName = "自费项目";
                //主设置默认文件extension（可以不设置）
                saveFileDialog1.DefaultExt = "dbf";
                //获取或设置一个值，该值指示如果用户省略扩展名，文件对话框是否自动在文件名中添加扩展名。（可以不设置）
                saveFileDialog1.AddExtension = true;

                //设置默认文件类型显示顺序（可以不设置）
                saveFileDialog1.FilterIndex = 1;

                //保存对话框是否记忆上次打开的目录
                saveFileDialog1.RestoreDirectory = true;

                // Show save file dialog box
                DialogResult result = saveFileDialog1.ShowDialog();
                //点了保存按钮进入
                if (result == DialogResult.OK)
                {

                    //获得文件路径
                    table = saveFileDialog1.FileName.ToString();
                }
                else
                {
                    return;
                }

                ExportExcel(dt, table);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作出错! \n\t " + ex.Message + " \n\t " + ex.StackTrace);
                return;
            }
        }

        private void btnExportPub_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = dataGridView2.DataSource as DataTable;
                if (dt == null || dt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有数据需要导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //saveFileDialog1.OverwritePrompt
                string table = @"";

                //设置文件类型
                //书写规则例如：txt files(*.txt)|*.txt  dBase(*.dbf)
                saveFileDialog1.Filter = "Excel files(*.xls)|*.xls|All files(*.*)|*.*";
                //设置默认文件名（可以不设置）
                saveFileDialog1.FileName = "公费项目";
                //主设置默认文件extension（可以不设置）
                saveFileDialog1.DefaultExt = "dbf";
                //获取或设置一个值，该值指示如果用户省略扩展名，文件对话框是否自动在文件名中添加扩展名。（可以不设置）
                saveFileDialog1.AddExtension = true;

                //设置默认文件类型显示顺序（可以不设置）
                saveFileDialog1.FilterIndex = 1;

                //保存对话框是否记忆上次打开的目录
                saveFileDialog1.RestoreDirectory = true;

                // Show save file dialog box
                DialogResult result = saveFileDialog1.ShowDialog();
                //点了保存按钮进入
                if (result == DialogResult.OK)
                {

                    //获得文件路径
                    table = saveFileDialog1.FileName.ToString();
                }
                else
                {
                    return;
                }

                ExportExcel(dt, table);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作出错! \n\t " + ex.Message + " \n\t " + ex.StackTrace);
                return;
            }
        }

        protected void ExportExcel(DataTable dt, string table)
        {
            if (dt == null || dt.Rows.Count == 0) return;
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                return;
            }
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
            //Excel.Workbook workbook = xlApp.Workbooks.Open(table, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //Excel.Worksheet worksheet = workbook.Sheets[1] as Excel.Worksheet; //第一个sheet页
            worksheet.Name = "药品项目"; //这里修改sheet名称

            try
            {
                Excel.Range range;
                long totalCount = dt.Rows.Count;
                long rowRead = 0;
                float percent = 0;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                    range = (Excel.Range)worksheet.Cells[1, i + 1];
                    range.Interior.ColorIndex = 15;
                    range.Font.Bold = true;
                    //range.NumberFormat = "0.00";
                }

                DataTable dtDec = DecCol();

                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string strValue = dt.Rows[r][i].ToString();
                        decimal dm = 0M;
                        if (dtDec.Columns.Contains(dt.Columns[i].ColumnName))
                        {
                            ((Excel.Range)worksheet.Cells[r + 2, i + 1]).NumberFormat = "0.00";
                            worksheet.Cells[r + 2, i + 1] = strValue;
                        }
                        else
                        {
                            worksheet.Cells[r + 2, i + 1] = "'" + strValue;
                            //worksheet.Cells[r + 2, i + 1] = strValue;
                        }
                    }
                    rowRead++;
                    percent = ((float)(100 * rowRead)) / totalCount;
                }
                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                workbook.Saved = true;

                if (System.IO.File.Exists(table))
                {
                    System.IO.File.Delete(table);
                }
                workbook.SaveCopyAs(table);
                workbook.Close(true, Type.Missing, Type.Missing);
                workbook = null;
                xlApp.Quit();
                xlApp = null;
            }
        }

        private DataTable DecCol()
        {
            //FCWF、FXYF、FZYF、FPJF、FPZF、FTJF、FTZF、FQTF、FXJF、FZBCF、FZBLF、FZTJF、FZTZF、FZQTF、FZXJF、FJSF、FQZF、ID、ZFBL

            DataTable dt = new DataTable();
            dt.Columns.Add("lsj", typeof(decimal));
            dt.Columns.Add("lsj_n", typeof(decimal));
            dt.Columns.Add("zfbl", typeof(decimal));
            dt.Columns.Add("sfbl", typeof(decimal));
            dt.Columns.Add("xj", typeof(decimal));

            return dt;
        }
    }
}
