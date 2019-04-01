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

namespace ts_yp_tj
{
    public partial class Frmtjwhmx : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;

        public Frmtjwhmx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
        }

        //填充单据
        public void FillDj(Guid djid)
        { 
            //文号
            string ssql = "";
            ssql = string.Format(" select * from yf_tjwh where id='{0}'",djid);
            DataTable tb_wh = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb_wh.Rows.Count > 0)
            {
                DataRow row = tb_wh.Rows[0];
                txttjwh.Text = row["wh"].ToString();
                dtprq.Value = Convert.ToDateTime(row["djsj"].ToString());
                dtpsj.Value = Convert.ToDateTime(row["djsj"].ToString());
                lbldjh.Text = row["djh"].ToString();
                lbldjh.Tag = djid;
            }


            //文号明细
            ssql = string.Format(@" select
                                        c.S_YPPM 品名,c.S_YPGG 规格,
                                        c.s_sccj 厂家,
                                        S_YPJX 剂型,
                                        c.S_YPDW 单位,a.LSH 流水号,a.ZBJ 中标价,
                                        a.ZGLSJ 最高零售价,a.PXXH 排序序号,a.CJID,a.ID 
                                        from yf_tjwhmx a 
                                        inner join yf_tjwh b on a.djid=b.id 
                                        inner join yp_ypcjd c on a.cjid=c.cjid where 1=1 
                                        and a.djid='{0}'", djid
                                    );
            DataTable tb_whmx = InstanceForm.BDatabase.GetDataTable(ssql);
            dg_whmx.DataSource = tb_whmx;
        }

        private void csyp()
        {
            txtdm.Text = "";
            txtdm.Tag = null;
            lblpm.Text = "";
            lblypmc.Text = "";
            lblgg.Text = "";
            lblcj.Text = "";
            txtzbj.Text = "";
            txtzglsj.Text = "";
            txtlsh.Text = "";
        }

        //填充行
        private void FillRow(DataRow row)
        {
            int cjid = Convert.ToInt32(Convertor.IsNull(txtdm.Tag,"0"));
            if (cjid <= 0)
            {
                MessageBox.Show("没有可添加的记录！");
                txtdm.Focus();
                return;
            }

            row["cjid"] = cjid;
            row["品名"] = lblpm.Text;
            row["规格"] = lblgg.Text;
            row["厂家"] = lblcj.Text;
            row["单位"] = "";
            row["流水号"] =Convert.ToInt32(Convertor.IsNull(txtlsh.Text,"0"));
            decimal zglsj = Convert.ToDecimal(Convertor.IsNull(txtzglsj.Text,"0"));
            if (zglsj <= 0)
            {
                MessageBox.Show("最高零售价必须大于0");
                txtzglsj.Focus();
                return;
            }
            else
            {
                row["最高零售价"] = zglsj;
            }

            decimal zbj = Convert.ToDecimal(Convertor.IsNull(txtzbj.Text,"0"));
            row["中标价"] = zbj;

            DataTable tb_whmx = (DataTable)dg_whmx.DataSource;
            tb_whmx.ImportRow(row);
            dg_whmx.DataSource = tb_whmx;

        }

        //获取行
        private void GetRow(DataRow row)
        { 
            
        }



        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                this.SelectNextControl(control, true, false, true, true);
            }
        }

        private void csdj()
        { 
            
        }

        private void csdjmx()
        { 
            
        }

        //添加
        private void butadd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dg_whmx.DataSource;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(this.txtdm.Tag) == Convert.ToInt32(tb.Rows[i]["cjid"]))
                    {
                        MessageBox.Show("在当前网格中已存在这个药品的调价信息，不能重复录入");
                        return;
                    }
                }

                DataRow row = tb.NewRow();
                this.FillRow(row);
                if (row["品名"].ToString().Trim() != "")
                {
                  
                    this.csdjmx();
                    this.butadd.Enabled = true;
                    txtdm.Focus();
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //修改
        private void butdel_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dg_whmx.DataSource;
            int nrow = this.dg_whmx.CurrentCell.RowIndex;
            if (nrow >= tb.Rows.Count) return;
            if (MessageBox.Show("您确定要删除第" + Convert.ToString((nrow + 1)) + "行吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DataRow datarow = tb.Rows[nrow];
                tb.Rows.Remove(datarow);
                this.csdjmx();
            }

            this.butadd.Enabled = true;
        }

        //删除
        private void butmodif_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dg_whmx.DataSource;
                int nrow = this.dg_whmx.CurrentCell.RowIndex;
                if (nrow > tb.Rows.Count - 1) return;
                DataRow row = tb.Rows[nrow];
                this.FillRow(row);
                if (row["货号"].ToString().Trim() != "")
                {
                    DataRow nullrow = tb.NewRow();
                    this.GetRow(nullrow);
                    this.butadd.Enabled = true;
                }
                this.txtdm.Focus();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            DateTime tnow=Convert.ToDateTime(InstanceForm.BDatabase.GetDataResult(InstanceForm.BDatabase.GetServerTimeString()).ToString());
            string wh = "";//文号
            string whrq = "";
            int djh = 0;
            string djsj = "";
            string bz = "";//备注
            Guid id = Guid.Empty;
            Guid _id=Guid.Empty;
            string whdw="";

            wh = txttjwh.Text.Trim();
            whrq = txtwhrq.Text.Trim();
            djh = Convert.ToInt32(Convertor.IsNull(lbldjh.Text, "0"));
            djsj=  dtprq.Value.ToShortDateString() + dtpsj.Value.ToShortTimeString();
            id = new Guid(Convertor.IsNull(lbldjh.Tag, Guid.Empty.ToString()));
            whdw=txtwhdw.Text.Trim();

            if (wh == string.Empty)
            {
                MessageBox.Show("请输入调价文号");
                return;
            }

            DataTable tb = (DataTable)dg_whmx.DataSource;
            if (tb.Rows.Count == 0&&id!=Guid.Empty)
            {
                string ssql_del = string.Format(" delete yf_tjwh where id='{0}'",id);
                InstanceForm.BDatabase.DoCommand(ssql_del);
                ssql_del = string.Format(" delete yf_tjwhmx where djid='{0}'",id);
                InstanceForm.BDatabase.DoCommand(ssql_del);
                csdj();
                csdjmx();
                MessageBox.Show("保存成功！");
                return;
            }

            try
            {
                InstanceForm.BDatabase.BeginTransaction();
                //保存单据头
                SaveWh(id, djh, wh, whrq, whdw, InstanceForm.BCurrentUser.EmployeeId, djsj, bz, out _id, InstanceForm.BDatabase);


                //保存单据明细
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    DataRow row = tb.Rows[i];
                    SaveWhmx(new Guid(Convertor.IsNull(row["id"], Guid.Empty.ToString())),
                        _id,
                        row["流水号"].ToString(),
                        Convert.ToDecimal(row["中标价"]),
                        Convert.ToDecimal(row["最高零售价"]),
                        false,
                        Convert.ToInt32(row["cjid"]),
                        InstanceForm.BDatabase);
                }

                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("保存成功！");
                
            }
            catch(Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.ToString());
                return;
            }
            
        }

        private  static void SaveWh(Guid id,int djh,
                            string wh,string whrq,
                            string whdw,int djy,
                            string djsj,string bz,out Guid _id,
                            TrasenClasses.DatabaseAccess.RelationalDatabase db)
        {
            string ssql = "";
            if (id == Guid.Empty)
            {
                id = Guid.NewGuid();
                ssql = string.Format(@" insert into yf_tjwh(id,djh,wh,whrq,whdw,djy,djsj,bz) values
                                       '{0}',{1},'{2}','{3}','{4}',{5},'{6}','{7}' ",id,djh,wh,whrq,whdw,djy,djsj,bz);
            }
            else
            {
                ssql = string.Format(@" update yf_tjwh set wh='{0}',whrq='{1}',whdw='{2}',bz='{4}' where id='{5}' ",wh,whrq,whdw,bz,id);
            }
            _id = id;

            if (InstanceForm.BDatabase.DoCommand(ssql) <= 0)
            {
                throw new Exception("保存文号头表失败！");
            }
        }

        private static void SaveWhmx(Guid id, Guid djid,
                                string lsh, decimal zbj, decimal zglsj,
                                bool bdelete, int cjid, TrasenClasses.DatabaseAccess.RelationalDatabase db)
        {
            string ssql = "";
            if (id == Guid.Empty)
            {
                ssql = string.Format(@" insert into yf_tjwhmx(id,djid,lsh,zbj,zglsj,bdelete,cjid) values
                                    '{0}','{1}','{2}',{3},{4},0,{5}",id,djid,lsh,zbj,zglsj,cjid);
            }
            else
            {
                ssql = string.Format(@" update yf_tjwhmx set lsh='{0}',zbj={1},zglsj={2},bdelete={3} where id='{4}'",lsh,zbj,zglsj,bdelete,id);
            }
            if (InstanceForm.BDatabase.DoCommand(ssql) <= 0)
            {
                throw new Exception("保存文号明细失败！");
            }



        }

        private void Frmtjwhmx_Load(object sender, EventArgs e)
        {
            int deptid = InstanceForm.BCurrentDept.DeptId;
            string ssql = string.Format(@" select a.yppm 品名,a.ypspm 商品名,a.ypgg 规格,
                                        a.S_SCCJ 厂家,b.WBM 五笔码,b.PYM 拼音码,a.CJID 
                                        from vi_yk_kcmx a inner join YP_YPBM b on a.GGID=b.GGID
                                        where a.deptid ={0} ", deptid);
            DataTable tb_kcmx = InstanceForm.BDatabase.GetDataTable(ssql);
            txtdm.ShowCardProperty[0].ShowCardDataSource = tb_kcmx;
        }

        private void txtdm_AfterSelectedDataRow(DataRow selectedRow, ref object nextFocus)
        {
            if (selectedRow == null) return;
            int cjid = Convert.ToInt32(selectedRow["cjid"]);
            txtdm.Tag = cjid;
            lblpm.Text = selectedRow["品名"].ToString();
            lblypmc.Text = selectedRow["商品名"].ToString();
            lblgg.Text = selectedRow["规格"].ToString();
            lblcj.Text = selectedRow["厂家"].ToString();
            txtdm.Text = "";
            txtzglsj.Focus();
        }
    }
}