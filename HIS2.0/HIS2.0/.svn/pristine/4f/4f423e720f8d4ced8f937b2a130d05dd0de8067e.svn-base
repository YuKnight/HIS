using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;


namespace ts_yp_tj
{
    public partial class Frmpltj : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        //●-匹配  ☆-录入
        private string strpp = "●";
        private string strlr = "☆";
        private string strjj = "×";
        private DataTable tb_whmx = new DataTable();

        public Frmpltj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }

        private void Frmpltj_Load(object sender, EventArgs e)
        {
            this.dg_tjmx.DataError += new DataGridViewDataErrorEventHandler(dg_tjmx_DataError);

            int deptid = InstanceForm.BCurrentDept.DeptId;
            string ssql = string.Format(@" select a.yppm 品名,a.ypspm 商品名,a.ypgg 规格,
                                        a.S_SCCJ 厂家,b.WBM 五笔码,b.PYM 拼音码,a.CJID 
                                        from vi_yk_kcmx a inner join YP_YPBM b on a.GGID=b.GGID
                                        where a.deptid ={0} ",deptid);
            DataTable tb_kcmx = InstanceForm.BDatabase.GetDataTable(ssql);
            txtdm.ShowCardProperty[0].ShowCardDataSource = tb_kcmx;

            ssql = string.Format(@" select cast(b.zglsj as decimal(15,2)) 最高零售价,cast(b.zbj as decimal(15,2)) 中标价,a.djsj 登记日期,
                                a.wh 文号,a.whrq 文号日期,b.id,b.cjid from yf_tjwh a inner join yf_tjwhmx b on a.id=b.djid ");
            tb_whmx = InstanceForm.BDatabase.GetDataTable(ssql);
            dg_tjmx.ShowCardProperty[0].ShowCardDataSource = tb_whmx;
            txttjwh.Focus();
            
        }

        void dg_tjmx_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
            if (tb_tjmx.Rows[e.RowIndex][e.ColumnIndex] is DBNull)
            {
                return;
            }
            if (e.RowIndex >= 0)
            {
                //tb_tjmx.Rows[e.RowIndex][e.ColumnIndex] = DBNull.Value;
                dg_tjmx.Rows[e.RowIndex].Cells[e.RowIndex].Value = tb_tjmx.Rows[e.RowIndex][e.ColumnIndex];
                
            }
            else
            {
                dg_tjmx.CancelEdit();
            }
        }

        #region 添加属性查询树
        /// <summary>
        /// 添加药品类型树
        /// </summary>
        private void AddTreeYplx()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList1;

            DataTable tb = Yp.SelectYPLX(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                TreeNode node = treeView1.Nodes.Add(tb.Rows[i]["mc"].ToString());
                node.Tag = " and yplx=" + Convert.ToInt32(tb.Rows[i]["id"]) + "";
                node.ImageIndex = 0;
                DataTable tbc = Yp.SelectYpzlx(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(tb.Rows[i]["id"]), InstanceForm.BDatabase);
                for (int j = 0; j <= tbc.Rows.Count - 1; j++)
                {
                    TreeNode Cnode = node.Nodes.Add(tbc.Rows[j]["mc"].ToString());
                    Cnode.Tag = " and yplx=" + Convert.ToInt32(tb.Rows[i]["id"]) + " and ypzlx=" + Convert.ToInt32(tbc.Rows[j]["id"]);
                    Cnode.ImageIndex = 1;
                }
                node.Expand();
            }

            TreeNode node1 = treeView1.Nodes.Add("没有分类的药品");
            node1.ImageIndex = 1;
            node1.Tag = " and (yplx=0 or ypzlx=0) ";
        }


        /// <summary>
        /// 添加药品剂型树
        /// </summary>
        private void AddTreeYpjx()
        {
            this.treeView1.Nodes.Clear();
            //			DataTable tb=Yp.SelectYPLX(InstanceForm.BCurrentDept.DeptId);
            //			for(int i=0 ;i<=tb.Rows.Count-1;i++)
            //			{
            TreeNode node = treeView1.Nodes.Add("剂型");
            node.Tag = "";
            //				node.Tag=" and yplx="+Convert.ToInt32(tb.Rows[i]["id"])+"";
            //				node.ImageIndex=0;
            //				DataTable tbc=Yp.SelectYpjx(Convert.ToInt32(tb.Rows[i]["id"]));
            DataTable tbc = Yp.SelectYpjx(0, InstanceForm.BDatabase);
            for (int j = 0; j <= tbc.Rows.Count - 1; j++)
            {
                TreeNode Cnode = node.Nodes.Add(tbc.Rows[j]["mc"].ToString());
                Cnode.Tag = "  and ypjx=" + Convert.ToInt32(tbc.Rows[j]["id"]);
                //Cnode.Tag=" and yplx="+Convert.ToInt32(tb.Rows[i]["id"])+" and ypjx="+Convert.ToInt32(tbc.Rows[j]["id"]);
                Cnode.ImageIndex = 1;
            }
            node.Expand();

            TreeNode node1 = treeView1.Nodes.Add("没有分类的药品");
            node1.ImageIndex = 1;
            node1.Tag = " and (ypjx=0 or ypjx not in(select id from yp_ypjx) ) ";
            //			}
        }


        /// <summary>
        /// 添加属性标志树
        /// </summary>
        private void AddTreeYpsx()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList1;
            TreeNode node = treeView1.Nodes.Add("属性状态");
            node.Tag = "";
            TreeNode Cnode2 = node.Nodes.Add("毒剧药品");
            Cnode2.Tag = " and djyp=1 ";
            Cnode2.ImageIndex = 1;
            TreeNode Cnode3 = node.Nodes.Add("麻醉药品");
            Cnode3.Tag = " and mzyp=1 ";
            Cnode3.ImageIndex = 1;
            TreeNode Cnode4 = node.Nodes.Add("皮试药品");
            Cnode4.Tag = " and psyp=1 ";
            Cnode4.ImageIndex = 1;
            TreeNode Cnode5 = node.Nodes.Add("精神药品");
            Cnode5.Tag = " and jsyp=1 ";
            Cnode5.ImageIndex = 1;
            TreeNode Cnode6 = node.Nodes.Add("贵重药品");
            Cnode6.Tag = " and gzyp=1 ";
            Cnode6.ImageIndex = 1;

            TreeNode Cnode20 = node.Nodes.Add("外用药品");
            Cnode20.Tag = " and wyyp=1 ";
            Cnode20.ImageIndex = 1;

            TreeNode Cnode7 = node.Nodes.Add("处方药品");
            Cnode7.Tag = " and cfyp=1 ";
            Cnode7.ImageIndex = 1;

            TreeNode Cnode21 = node.Nodes.Add("妊娠药品");
            Cnode21.Tag = " and rsyp=1 ";
            Cnode21.ImageIndex = 1;

            TreeNode Cnode22 = node.Nodes.Add("中标药品");
            Cnode22.Tag = " and zbzt=1 ";
            Cnode22.ImageIndex = 1;

            TreeNode Cnode32 = node.Nodes.Add("基本药物");
            Cnode32.Tag = " and GJJBYW=1 ";
            Cnode32.ImageIndex = 1;

            TreeNode Cnode33 = node.Nodes.Add("高危药品");
            Cnode33.Tag = " and GWYP=1 ";
            Cnode33.ImageIndex = 1;

            TreeNode Cnode13 = node.Nodes.Add("停用的药品");
            Cnode13.Tag = " and b.BDELETE=1 ";
            Cnode13.ImageIndex = 1;

            TreeNode Cnode14 = node.Nodes.Add("★按包装取整");
            Cnode14.Tag = " and lyfs=1 ";
            Cnode14.ImageIndex = 1;
            TreeNode Cnode15 = node.Nodes.Add("★按含量累计");
            Cnode15.Tag = " and lyfs=2 ";
            Cnode15.ImageIndex = 1;

            TreeNode Cnode16 = node.Nodes.Add("●正主任医师用药");
            Cnode16.Tag = " and cfjb=1 ";
            Cnode16.ImageIndex = 1;
            TreeNode Cnode17 = node.Nodes.Add("●副正主任医师用药");
            Cnode17.Tag = " and cfjb=2 ";
            Cnode17.ImageIndex = 1;
            TreeNode Cnode18 = node.Nodes.Add("●主治医师用药");
            Cnode18.Tag = " and cfjb=3 ";
            Cnode18.ImageIndex = 1;
            TreeNode Cnode19 = node.Nodes.Add("●经治医师用药");
            Cnode19.Tag = " and cfjb=4 ";
            Cnode19.ImageIndex = 1;

            //统领分类
            string ssql = "select * from yp_tlfl ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                TreeNode Cnode30 = node.Nodes.Add("※" + Convertor.IsNull(tb.Rows[i]["name"], ""));
                Cnode30.Tag = " and a.tlfl='" + Convertor.IsNull(tb.Rows[i]["code"], "") + "' ";

                Cnode30.ImageIndex = 1;
            }

            //modefy by lwl 2011-10-19
            //抗生素等级
            string ksssql = "select * from YP_KSSDJ";
            DataTable dt = InstanceForm.BDatabase.GetDataTable(ksssql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode Cnode31 = node.Nodes.Add("★" + Convertor.IsNull(dt.Rows[i]["KSSDJMC"], ""));
                Cnode31.Tag = " and a.KSSDJID='" + Convertor.IsNull(dt.Rows[i]["KSSDJID"], "") + "' ";

                Cnode31.ImageIndex = 1;
            }




            node.Expand();


        }

        /// <summary>
        /// 添加药理分类树
        /// </summary>
        /// <param name="tb">药理分类表</param>
        /// <param name="treeNode">当前节点</param>
        /// <param name="fid">父ID</param>
        private void AddTreeYlfl(DataTable tb, TreeNode treeNode, long fid)
        {
            treeNode.Nodes.Clear();
            DataRow[] rows = tb.Select(" fid=" + fid + "");
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                TreeNode Cnode = treeNode.Nodes.Add(rows[i]["flmc"].ToString());
                Cnode.Tag = " and ylfl=" + Convert.ToInt64(rows[i]["id"]) + " ";
                Cnode.Tag = " and ylfl in(select id from dbo.fun_tlfl_child(" + Convertor.IsNull(rows[i]["id"], "") + ")) ";
                if (rows[i]["yjdbz"].ToString() == "1") Cnode.ImageIndex = 1; else Cnode.ImageIndex = 0;
                AddTreeYlfl(tb, Cnode, Convert.ToInt64(rows[i]["id"]));
            }
        }



        /// <summary>
        /// 药品属性选项卡改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex.ToString())
            {
                case "0":
                    this.AddTreeYpsx();
                    break;
                case "1":
                    this.AddTreeYplx();
                    break;
                case "2":
                    this.AddTreeYpjx();
                    break;
                case "3":
                    this.treeView1.Nodes.Clear();
                    this.treeView1.ImageList = this.imageList1;
                    TreeNode node = treeView1.Nodes.Add("药理分类目录");
                    node.Tag = " and ylfl<>-1 ";
                    node.ImageIndex = 0;

                    TreeNode nodenull = treeView1.Nodes.Add("☆ 没有分类的药品");
                    nodenull.Tag = " and ylfl=0 ";
                    nodenull.ImageIndex = 1;

                    DataTable tb = Yp.SelectYlfl(InstanceForm.BDatabase);
                    this.AddTreeYlfl(tb, node, 0);
                    node.Expand();
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void csdj(int shbz,Guid id)
        {
            DateTime tnow = Convert.ToDateTime(InstanceForm.BDatabase.GetDataRow(InstanceForm.BDatabase.GetServerTimeString())[0].ToString());//服务器时间
            if (shbz == 0)
            {
                if (id == Guid.Empty)
                {
                    lbldjh.Text = "";
                    lblsdjh.Text = "";
                    txttjwh.Text = "";
                    dtprq.Value = tnow;
                    dtpsj.Value = tnow;
                    txtbz.Text = "";
                    txttjxs.Text = "";
                    chkbljzx.Checked = false;
                    lbldjh.Tag = null;
                }

                txtbz.Enabled = true;//备注
                dtprq.Enabled = true;//日期
                dtpsj.Enabled = true;//时间
                txttjxs.Enabled = true;//系数
                chkbljzx.Enabled = true;//立即执行
                txttjwh.Enabled = true;//文号
                btnqxmx.Enabled = true;
                btnzx.Enabled = true;
            

            }
            else
            {
                txttjwh.Enabled = false;
                dtprq.Enabled = false;
                dtpsj.Enabled = false;
                txtbz.Enabled = false;
                txttjxs.Enabled = false;
                chkbljzx.Enabled = false;
                btnqxmx.Enabled = false;
                btnzx.Enabled = false;
            }
        }

        private void csdjmx(int shbz)
        { 
            
        }

        public void FillDj(Guid id,int zxbz)
        {
            int deptid = InstanceForm.BCurrentDept.DeptId;
            Guid zxdjid = Guid.Empty; //执行单据id
            string ssql = "";

            if (id == Guid.Empty)
            {
                col调价数量.Visible = false;
            }
            else
            {
                col调价数量.Visible = true;
            }
            if (zxbz == 0)
            {
                colss.Visible = true;
            }
            else
            {
                colss.Visible = false;
            }
            
            #region 获取调价头信息
           
            ssql = string.Format(" select * from yf_tj where id='{0}'", id);
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                DataRow row = tb.Rows[0];
                lbldjh.Text = row["djh"].ToString();
                lbldjh.Tag = id;
                //lblsdjh.Text = row["sdjh"].ToString();
                DateTime zxsj = Convert.ToDateTime(row["zxrq"].ToString());
                dtprq.Value = zxsj;
                dtpsj.Value = zxsj;
                chkbljzx.Checked = Convert.ToBoolean(row["bljzx"]);
                txttjwh.Text = row["tjwh"].ToString();
                txttjxs.Text = row["tjxs"].ToString();
                txtbz.Text = row["bz"].ToString();

                zxdjid = new Guid(Convertor.IsNull(row["zxdjid"], Guid.Empty.ToString()));
            }
            #endregion


            if (zxbz == 0)//未执行
            {
                #region
                ssql = string.Format(@" select 

                                     0 选择, b.id, 0 序号,
                                    (case b.id when (b.id is null or b.id=dbo.FUN_GETEMPTYGUID() then 0 else 1)
                                     a.yppm 品名,a.ypspm 商品名,a.ypgg 规格,a.s_sccj 厂家,s_ypdw 单位,
                                    a.pfj 原批发价,a.pfj 现批发价,
                                    a.lsj 原零售价, cast(b.xlsj as decimal(15,2)) 现零售价,
                                    '公' 公,
                                    '↑' ss,
                                    cast( cast(c.zglsj as decimal(15,2)) as varchar(10)) 最高零售价,
                                    a.mrjj 原进价, 
                                    (case b.mrjhj when null then a.mrjj else cast(b.mrjhj as decimal(15,2)) end) 现进价, 
                                    a.kcl 药库库存,  
                                    a.kcl 调价数量,
                                    cast(0 as decimal(15,2)) 全院库存, 
                                    
                                   
                                    cast((b.xlsj-a.lsj)*a.kcl as decimal(15,2))  调零售金额,
                                    cast((b.mrjhj-b.scjhj)*a.kcl as decimal(15,2)) 调进价金额,
                                    
                                    a.txm 货号, 
                                    a.cjid,a.zxdw,a.dwbl ydwbl,
                                    b.whmxid 
                                    from VI_YK_KCMX a left join yf_tjmx b on a.cjid=b.cjid and a.deptid=b.deptid and b.djid='{1}'
                                    left join yf_tjwhmx c on b.whmxid=c.id  
                                    where a.deptid={0} order by b.id desc 
                                    ", deptid,id);
                DataTable tb_tjmx = InstanceForm.BDatabase.GetDataTable(ssql);
                dg_tjmx.DataSource=tb_tjmx;
                #endregion
            }
            else//已执行
            {
             
                #region 调价明细
                ssql = string.Format(@" select 0 选择, b.id, 0 序号,
                                     a.yppm 品名,a.ypspm 商品名,a.ypgg 规格,a.s_sccj 厂家,s_ypdw 单位,
                                    b.ypfj 原批发价,b.xpfj 现批发价,
                                    b.ylsj 原零售价, cast(b.xlsj as decimal(15,2)) 现零售价,
                                     '公' 公,
                                    '↑' ss,
                                     cast( cast(c.zglsj as decimal(15,2)) as varchar(10)) 最高零售价,
                                    cast(b.scjhj as decimal(15,2)) 原进价, 
                                    cast(b.mrjhj as decimal(15,2)) 现进价, 
                                    a.kcl 药库库存,  
                                    b.tjsl 调价数量,
                                    cast(0 as decimal(15,2)) 全院库存, 
                                   
                                    cast((b.xlsj-b.xlsj)*b.tjsl as decimal(15,2)) 调零售金额,
                                    cast((b.mrjhj-b.scjhj)*b.tjsl as decimal(15,2)) 调进货金额,
                                    a.txm 货号, 
                                    a.cjid,a.zxdw,b.ydwbl,
                                    b.whmxid 
                                    from VI_YK_KCMX a inner join yf_tjmx b on a.cjid=b.cjid and a.deptid=b.deptid and b.djid='{1}'
                                    left join yf_tjwhmx c on b.whmxid=c.id  
                                    where a.deptid={0} 
                                    ", deptid, id);
                DataTable tb_tjmx = InstanceForm.BDatabase.GetDataTable(ssql);
                dg_tjmx.DataSource = tb_tjmx;
                #endregion

                #region 批次明细
                ssql = string.Format(" select ");
                #endregion
            }

            csdj(zxbz,id);
           
        }

        private void txtdm_KeyPress(object sender, KeyPressEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyChar);
            if (nkey == 13)
            {
                btndw_Click(0, e);
            }
         
        }

        //保存明细
        private void btnSavemx_Click(object sender, EventArgs e)
        {
            int cjid = Convert.ToInt32(Convertor.IsNull(txtdm.SelectedValue,"0"));
            if (cjid <= 0) return;

            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;

            int index = 0;
            for (int i = 0; i < tb_tjmx.Rows.Count; i++)
            {
                if (Convert.ToInt32(tb_tjmx.Rows[i]["cjid"]) == cjid)
                {
                    index = i;
                    break;
                }
            }

            //if (txtxlsj.Text != "" || lblzglsj.Text != ""||txtxjhj.Text!="")
            //{
            //    if (txtxlsj.Text != "")
            //    {
            //        tb_tjmx.Rows[index]["现零售价"] = Convert.ToDecimal(txtxlsj.Text);
            //        tb_tjmx.Rows[index]["匹录"] = strlr;
            //    }
            //    else
            //    { 
                    
            //    }

            //    DataRow newrow = tb_tjmx.NewRow();
            //    newrow.ItemArray = tb_tjmx.Rows[index].ItemArray;
            //    tb_tjmx.Rows[index].Delete();
            //    tb_tjmx.AcceptChanges();
            //    tb_tjmx.Rows.InsertAt(newrow, 0);
            //    dg_tjmx.DataSource = tb_tjmx;
            //}

            csdjmx(0);
            txtdm.Focus();
        }

        //保存调价
        private void btnzx_Click(object sender, EventArgs e)
        {
            string ssql = "";
            bool bpltj = true;
            int err_code=0;
			string err_text="";
            DateTime tnow=Convert.ToDateTime(InstanceForm.BDatabase.GetDataResult(InstanceForm.BDatabase.GetServerTimeString()));
            bool bljzx = chkbljzx.Checked;
            string tjwh = txttjwh.Text;
            string bz = txtbz.Text;
            decimal tjxs = Convert.ToDecimal(Convertor.IsNull(txttjxs.Text,"1"));//调价系数
            DateTime zxsj = Convert.ToDateTime(dtprq.Value.ToShortDateString()+" "+dtpsj.Value.ToShortTimeString());
            int djy=InstanceForm.BCurrentUser.EmployeeId;
            string ywlx="005";
            Guid djid= new Guid(Convertor.IsNull(lbldjh.Tag,Guid.Empty.ToString()));//djid
            Guid djid_out;
            bool wcbz=false;
            int deptid=InstanceForm.BCurrentDept.DeptId;
            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;

            DataRow[] rows=new DataRow[]{};
            if (djid == Guid.Empty)
            {
                rows = tb_tjmx.Select(string.Format("匹录 in ('{0}','{1}','{2}')", strpp, strlr, strjj));
            }
            else
            {
                rows = tb_tjmx.Select(string.Format("匹录 in ('{0}','{1}','{2}') or (id is not null or id <>'00000000-0000-0000-0000-000000000000' ) ", strpp, strlr, strjj));
            }
           
            if (rows.Length <= 0)
            {
                MessageBox.Show("没有要保存的记录！");
                return;
            }
            if (!bljzx)//不立即执行
            {
                if (tnow > zxsj)
                {
                    MessageBox.Show("非立即执行,执行时间必须大于当前服务器时间！");
                    return;
                }
            }

            #region 判断未审核单据

            if (bljzx)
            {
                if (rows.Length > 0) ssql = rows[0]["cjid"].ToString();
                for (int i = 1; i < rows.Length; i++)
                {
                    ssql = ssql + "," + rows[i]["cjid"].ToString();
                }
                DataTable tbsh = YF_TJ_TJMX.SelectWsh(ssql, out err_text, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                if (tbsh.Rows.Count > 0)
                {
                    Frmwshdj f = new Frmwshdj(_menuTag, _chineseName, _mdiParent);
                    Point point = new Point(400, 500);
                    f.Location = point;
                    f.tb = tbsh;
                    f.lblbz.Text = "";
                    f.ShowDialog();
                    return;
                }
            }
            #endregion


            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid _DJID = Guid.Empty;
            Guid _DJID_ZX = Guid.Empty;
            string sdjh = "";

            try
            {
                InstanceForm.BDatabase.BeginTransaction();
                long djh = lbldjh.Text == "" ? Yp.SeekNewDjh("005", Convert.ToInt64(InstanceForm.BCurrentDept.DeptId), InstanceForm.BDatabase) : Convert.ToInt64(lbldjh.Text);//单据号
                if (!bljzx)//不立即执行
                {
                    #region 调价头
                    YF_TJ_TJMX.SaveDJ(djid,
                       ywlx,
                       djh,
                       tjwh,
                       djy,
                       tnow.ToString(),
                       zxsj.ToString(),
                       0,
                       0,
                       deptid,
                       bz,
                       out djid_out,
                       out err_code,
                       out err_text,
                       InstanceForm._menuTag.Jgbm,
                       InstanceForm.BDatabase, bljzx,
                       Convert.ToDecimal(Convertor.IsNull(txttjxs.Text, "1")),
                       bpltj);
                    if (err_code != 0)
                    {
                        throw new System.Exception(err_text);
                    }
                    #endregion

                    #region 调价明细
                    for (int i = 0; i < rows.Length; i++)
                    {
                        
                        DataRow row = rows[i];
                        bool ppbz = false;
                        if (row["匹录"].ToString() == strpp)
                            ppbz = true;
                        Guid whmxid = new Guid(Convertor.IsNull(row["whmxid"], Guid.Empty.ToString()));
                        decimal tpfje = (Convert.ToDecimal(row["现批发价"]) - Convert.ToDecimal(row["原批发价"])) * Convert.ToDecimal(row["药库库存"]);

                        Guid _djmxid=new Guid(Convertor.IsNull(row["id"], Guid.Empty.ToString()));
                        if(_djmxid!=Guid.Empty&&row["匹录"].ToString()=="")//如果被取消 ，则要删除
                        {
                             ssql = string.Format(" delete yf_tjmx where id= '{0}'",_djmxid);
                            if(InstanceForm.BDatabase.DoCommand(ssql)<=0)
                            {
                                throw new Exception("取消调价明细失败");
                            }
                        }
                        else
                        {
                            decimal xlsj = 0;
                            if (row["现零售价"] is DBNull)
                            {
                                if (ppbz)
                                {
                                    xlsj = Convert.ToDecimal(Convert.ToDecimal(Convertor.IsNull(row["最高零售价"], "0")) * tjxs);
                                }
                                else
                                {
                                    xlsj = Convert.ToDecimal(row["原零售价"]);
                                }
                            }

                            YF_TJ_TJMX.SaveDJMX(new Guid(Convertor.IsNull(row["id"], Guid.Empty.ToString())),
                                         djid_out,
                                         Convert.ToInt32(row["cjid"]),
                                         Convert.ToDecimal(0),//调价数量
                                         row["单位"].ToString(),
                                         Convert.ToInt32(row["ydwbl"]),
                                         Convert.ToDecimal(row["原批发价"]),
                                         Convert.ToDecimal(row["现批发价"]),
                                         tpfje,
                                         Convert.ToDecimal(row["原零售价"]),
                                         Convert.ToDecimal(Convertor.IsNull(row["现零售价"], row["原零售价"].ToString())),
                                         Convert.ToDecimal(Convertor.IsNull(row["调价金额"],"0")),
                                         Convert.ToInt64(deptid),
                                         djh,
                                         ywlx,
                                         Convert.ToDecimal(row["原进货价"]),
                                         Convert.ToDecimal(Convertor.IsNull(row["现进价"],row["原进价"].ToString())),
                                         "",
                                         out err_code,
                                         out err_text,
                                         InstanceForm.BDatabase,
                                         ppbz,
                                         whmxid,
                                         Convert.ToDecimal(Convertor.IsNull(row["最高零售价"], "0"))
                                         );
                            if (err_code != 0)
                            {
                                throw new System.Exception(err_text);
                            }
                        }
                    }
                    #endregion

                    FillDj(djid_out, 0);


                }//立即执行
                else
                {
                    #region 调价头
                    YF_TJ_TJMX.SaveDJ(djid,
                        ywlx,
                        djh,
                        tjwh,
                        djy,
                        tnow.ToString(),
                        tnow.ToString(),
                        1,
                        0,
                        deptid,
                        bz,
                        out djid_out,
                        out err_code,
                        out err_text,
                        InstanceForm._menuTag.Jgbm,
                        InstanceForm.BDatabase, bljzx,
                        Convert.ToDecimal(Convertor.IsNull(txttjxs.Text, "1")),
                        bpltj);
                    if (err_code != 0)
                    {
                        throw new System.Exception(err_text);
                    }
                    #endregion

                    #region 调价明细
                    for (int i = 0; i < rows.Length; i++)
                    {
                        DataRow row = rows[i];
                        bool ppbz = false;
                        if (row["匹录"].ToString() == strpp)
                            ppbz = true;
                        Guid whmxid = new Guid(Convertor.IsNull(row["whmxid"], Guid.Empty.ToString()));
                        decimal tpfje = (Convert.ToDecimal(row["现批发价"]) - Convert.ToDecimal(row["原批发价"])) * Convert.ToDecimal(row["药库库存"]);
                        decimal tlsje = (Convert.ToDecimal(row["现零售价"]) - Convert.ToDecimal(row["原零售价"])) * Convert.ToDecimal(row["药库库存"]);
                        YF_TJ_TJMX.SaveDJMX(new Guid(Convertor.IsNull(row["id"], Guid.Empty.ToString())),
                                     djid_out,
                                     Convert.ToInt32(row["cjid"]),
                                     Convert.ToDecimal(row["调价数量"]),
                                     row["单位"].ToString(),
                                     Convert.ToInt32(row["ydwbl"]),
                                     Convert.ToDecimal(row["原批发价"]),
                                     Convert.ToDecimal(row["现批发价"]),
                                     tpfje,
                                     Convert.ToDecimal(row["原零售价"]),
                                     Convert.ToDecimal(row["现零售价"]),
                                     Convert.ToDecimal(Convertor.IsNull(row["调零售金额"], "0")),
                                     Convert.ToInt64(deptid),
                                     djh,
                                     ywlx,
                                     Convert.ToDecimal(row["原进价"]),
                                     Convert.ToDecimal(Convertor.IsNull(row["现进价"], row["原进价"].ToString())),
                                     "",
                                     out err_code,
                                     out err_text,
                                     InstanceForm.BDatabase,
                                     ppbz,
                                     whmxid,
                                     Convert.ToDecimal(Convertor.IsNull(row["最高零售价"], "0"))
                                     );
                        if (err_code != 0)
                        {
                            throw new System.Exception(err_text);
                        }
                        
                     
                    #region 保存单据 单据明细 修改字典
                    YF_TJ_TJMX.ExecQytj(djid_out, InstanceForm.BCurrentDept.DeptId, out sdjh, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                    if (err_code != 0) { throw new System.Exception(err_text); }
                    #endregion

                    #region 三院数据处理
                    ts.Save_log(ts_HospData_Share.czlx.yp_药品调价, InstanceForm.BCurrentDept.DeptName + "调价,调价文号:" + txttjwh.Text, "YF_TJ", "ID", djid.ToString(), InstanceForm._menuTag.Jgbm, -999, "", out _DJID, InstanceForm.BDatabase);
                    #endregion

                    #region 如果有中心机构且当前机构不是中心机构 则发送调价
                    if (InstanceForm._menuTag.Jgbm != TrasenFrame.Forms.FrmMdiMain.ZxJgbm && TrasenFrame.Forms.FrmMdiMain.ZxJgbm > 0)
                    ts.Save_log(ts_HospData_Share.czlx.yp_药品调价, "调整中心的药品字典价格: 调价科室 " + InstanceForm.BCurrentDept.DeptName + " 调价单号:" + djh + " 调价文号:" + txttjwh.Text, "YF_TJ", "ID", djid.ToString(), InstanceForm._menuTag.Jgbm, TrasenFrame.Forms.FrmMdiMain.ZxJgbm, 0, "仅更新中心药品字典", out _DJID_ZX, InstanceForm.BDatabase);
                     #endregion
            }
                    #endregion

                    FillDj(djid_out, 1);

                 }
                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("保存成功！");
                

            }
            catch (Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.ToString());
                return;
            }
        }

        //点击调价明细 
        private void dg_tjmx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                if (rowIndex < 0 || e.ColumnIndex < 0) return;
                DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
                DataRow row = tb_tjmx.Rows[rowIndex];
                int cjid = Convert.ToInt32(row["cjid"]);
                string yppm = row["品名"].ToString();//品名
                string ypgg = row["规格"].ToString();
                string ypspm = row["商品名"].ToString();//商品名
                decimal kcl = Convert.ToDecimal(Convertor.IsNull(row["药库库存"], "0"));
                string ypdw = row["单位"].ToString();
                string ypcj = row["厂家"].ToString();
                string hh = row["货号"].ToString();
                decimal ylsj = Convert.ToDecimal(row["原零售价"]);
                bool bxlsj = (row["现零售价"] is DBNull) ? false : true; //是否已经录入现零售价
                decimal xlsj = Convert.ToDecimal(Convertor.IsNull(row["现零售价"], "0"));

                decimal yjhj = Convert.ToDecimal(Convertor.IsNull(row["原进价"], "0"));
                bool bxjhj = (row["现进价"] is DBNull) ? false : true;
                decimal xjhj = Convert.ToDecimal(Convertor.IsNull(row["现进价"], "0"));//现进货价

                bool bzglsj = (row["最高零售价"] is DBNull) ? false : true;
                lblpm.Text = yppm;
                lblypmc.Text = ypspm;
                lblgg.Text = ypgg;
                lblcj.Text = ypcj;
                lblhh.Text = hh;
                lblylsj.Text = ylsj.ToString();
                lblyjhj.Text = yjhj.ToString();
                lblkc.Text = kcl.ToString();
                lbldw.Text = ypdw;
                //txtdm.SelectedValue = cjid;
                //txtdm.Text = "";
                txtdm.Tag = cjid;
                if (bxjhj)
                {
                    txtxjhj.Text = xjhj.ToString();
                }
                if (bxlsj)
                {
                    txtxlsj.Text = xlsj.ToString();
                }

                #region 废弃代码
                if (dg_tjmx.Columns[e.ColumnIndex].Name == "col最高零售价")//匹配录入文号
                {
                    //DataTable tb_whmx_temp = tb_whmx.Clone();
                    //DataRow[] rows_temp = tb_whmx.Select(string.Format("cjid={0}", cjid));
                    //for (int i = 0; i < rows_temp.Length; i++)
                    //{
                    //    tb_whmx_temp.ImportRow(rows_temp[i]);
                    //}
                    //dg_tjmx.ShowCardProperty[0].ShowCardDataSource = tb_whmx_temp;


                    //dg_tjmx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = " ";
                    //dg_tjmx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    //dg_tjmx.ShowCellErrors = false;

                }
                #endregion

                #region 上升
                if (dg_tjmx.Columns[e.ColumnIndex].Name == "colss")
                {
                    if (bxjhj || bzglsj || bxlsj)
                    {
                        DataRow newrow = tb_tjmx.NewRow();
                        newrow.ItemArray = tb_tjmx.Rows[e.RowIndex].ItemArray;
                        tb_tjmx.Rows[e.RowIndex].Delete();
                        tb_tjmx.AcceptChanges();
                        tb_tjmx.Rows.InsertAt(newrow, 0);
                        dg_tjmx.DataSource = tb_tjmx;
                        txtdm.Focus();
                    }
                }
                #endregion

                #region 公式
                if (dg_tjmx.Columns[e.ColumnIndex].Name == "col公")
                {
                    Rectangle rec = this.dg_tjmx.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    int x = pnlDjmx.Location.X;
                    int y = pnlDjmx.Location.Y;
                    Point p = new Point(x + rec.X, y + rec.Y - 30);
                    pnlgs.Location = p;
                    if ((p.Y + pnlgs.Size.Height + 100) > dg_pcmx.Size.Height)
                    {
                        pnlgs.Location = new Point(x + rec.X, x + rec.Y - pnlgs.Size.Height);
                    }
                    pnlgs.Visible = true;
                    decimal jhj = Convert.ToDecimal(row["原进价"]);
                    txtyjhj_gs.Text = jhj.ToString();
                    pnlgs.Tag = rowIndex;

                    txtxs_gs.Focus();
                }
                else
                {
                    pnlgs.Visible = false;
                }
                #endregion

                #region 中标文号
                string ssql = string.Format(@" select a.cjid,a.lsh 流水号,a.zbj 中标价,a.zglsj 最高零售价,b.s_ypjx 剂型,
                                            c.djsj 登记日期 
                                            from yf_tjwhmx a inner join vi_yp_ypcd b on a.cjid=b.cjid 
                                            inner join yf_tjwh c on a.djid=c.id 
                                            where a.cjid={0} ",cjid);
                DataTable tb_whmx = InstanceForm.BDatabase.GetDataTable(ssql);
                dgwhmx.DataSource = tb_whmx;

                #endregion

            }
            catch (Exception err)
            {
                MessageBox.Show("发生错误:"+err.ToString());
            }

        }

        private int ppms = 0;//

        private void txtdm_AfterSelectedDataRow(DataRow selectedRow, ref object nextFocus)
        {
            if (selectedRow == null) return;
            csdjmx(0);
            int cjid = Convert.ToInt32(selectedRow["cjid"]);
            FindRow(cjid, ppms);
            txtdm.Text = "";
            txtdm.Tag = cjid;
        }

        private void FindRow(int cjid, int ppms)
        { 
            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
            for (int i = 0; i < tb_tjmx.Rows.Count; i++)
            {
                DataRow row = tb_tjmx.Rows[i];
                if (cjid == Convert.ToInt32(row["cjid"]))
                {
                    txtxlsj.Focus();
                    dg_tjmx.CurrentCell= dg_tjmx.Rows[i].Cells["col现零售价"];
                    dg_tjmx.Focus();
                    return;
                }
            }
        }

        private void btnpp_Click(object sender, EventArgs e)
        {

        }

        //定位
        private void btndw_Click(object sender, EventArgs e)
        {
            int cjid = Convert.ToInt32(Convertor.IsNull(txtdm.Tag, "0"));
            if (cjid > 0)
            {
                FindRow(cjid, ppms);
                this.txtdm.Text = "";
            }
        }

        private void chkpp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtxlsj_KeyUp(object sender, KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            TextBox txtBox = (TextBox)sender;
            if (nkey != 13 && txtBox.Text.Trim() != "-" && txtBox.Text.Trim() != ".")
            {
                if (!Convertor.IsNumeric(txtBox.Text))
                {
                    txtBox.Text = "";
                }
            }
        }

        //取消
        private void btnqxmx_Click(object sender, EventArgs e)
        {
            int cjid = Convert.ToInt32(Convertor.IsNull(txtdm.Tag,"0"));
            if (cjid <= 0)
            {
                MessageBox.Show("没有要取消的记录！");
            }
            DataTable tb_tjmx=(DataTable)dg_tjmx.DataSource;
            for (int i = 0; i < tb_tjmx.Rows.Count;i++ )
            {
                if (Convert.ToInt32(tb_tjmx.Rows[i]["cjid"]) == cjid)
                {
                    tb_tjmx.Rows[i]["现进价"] = DBNull.Value;
                    tb_tjmx.Rows[i]["现零售价"] = DBNull.Value;
                    tb_tjmx.Rows[i]["最高零售价"] = DBNull.Value;
                    tb_tjmx.Rows[i]["whmxid"] = DBNull.Value;
                    tb_tjmx.Rows[i]["匹录"] = "";
                    return;
                }
            }
        }

        //匹配调价文号明细
        private void dg_tjmx_AfterSelectedDataRow(DataRow selectedRow, ref object nextFocus)
        {
            //if (selectedRow == null) return;
            //decimal zglsj = Convert.ToDecimal(selectedRow["最高零售价"]);
            //Guid whmxid = new Guid(selectedRow["id"].ToString());
            //int rowIndex = dg_tjmx.CurrentCell.RowIndex;
            //dg_tjmx.Rows[rowIndex].Cells["col最高零售价"].Value = zglsj;
            //dg_tjmx.Rows[rowIndex].Cells["colwhmxid"].Value = whmxid;
            //dg_tjmx.Rows[rowIndex].Cells["col现零售价"].Value = Convert.ToDecimal(zglsj* Convert.ToDecimal(Convertor.IsNull(txttjxs.Text,"1")));

            ////int rowIndex = dg_tjmx.CurrentCell.RowIndex;
            //int colIndex = dg_tjmx.CurrentCell.ColumnIndex;

            //DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
            //tb_tjmx.Rows[rowIndex]["最高零售价"] = zglsj;
            //tb_tjmx.Rows[rowIndex]["whmxid"] = whmxid;

            //dg_tjmx.DataSource = tb_tjmx;
            //this.BindingContext[tb_tjmx].EndCurrentEdit();
            //dg_tjmx.EndEdit();

        }

        private void dg_tjmx_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void dg_tjmx_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            return;
            if (dg_tjmx.Rows.Count <= 0) return;

            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            string colName = dg_tjmx.Columns[colIndex].Name;

            if (colName == "col最高零售价")
            {
                return;
            }
            if (Convertor.IsNull(dg_tjmx.Rows[rowIndex].Cells[colIndex].Value, "") == string.Empty)
            {
                if (colName == "col现零售价"&&Convertor.IsNull(dg_tjmx.Rows[rowIndex].Cells["col匹录"].Value,"")==strlr)
                {
                    tb_tjmx.Rows[rowIndex]["匹录"] = "";
                }
                //if (colName == "col最高零售价" && Convertor.IsNull(dg_tjmx.Rows[rowIndex].Cells["col匹录"].Value, "") == strpp)
                //{
                //    tb_tjmx.Rows[rowIndex]["匹录"] = "";
                //    tb_tjmx.Rows[rowIndex]["whmxid"] = DBNull.Value;
                //}
                if (colName == "col现进价" && Convertor.IsNull(dg_tjmx.Rows[rowIndex].Cells["col匹录"].Value, "") == strjj)
                {
                    tb_tjmx.Rows[rowIndex]["匹录"] = "";
                }
                dg_tjmx.DataSource = tb_tjmx;

                return;
            } 
            decimal value = Convert.ToDecimal(dg_tjmx.Rows[rowIndex].Cells[colIndex].Value);
            tb_tjmx.Rows[rowIndex][colIndex] = value;
            if (colName == "col现零售价")
            {
                tb_tjmx.Rows[rowIndex]["匹录"] = strlr;
                tb_tjmx.Rows[rowIndex]["最高零售价"] = DBNull.Value;
                tb_tjmx.Rows[rowIndex]["whmxid"] = DBNull.Value;
            }
            if (colName == "col最高零售价")
            {
                tb_tjmx.Rows[rowIndex]["匹录"] = strpp;
                tb_tjmx.Rows[rowIndex]["whmxid"] = dg_tjmx.Rows[rowIndex].Cells["colwhmxid"].Value;
                tb_tjmx.Rows[rowIndex]["现零售价"] = Convert.ToDecimal(value*Convert.ToDecimal(Convertor.IsNull( txttjxs.Text,"1")));
            }
            if (colName == "col现进价")
            {
                if (Convertor.IsNull(tb_tjmx.Rows[rowIndex]["匹录"], "") == "")
                {
                    tb_tjmx.Rows[rowIndex]["匹录"] = strjj;
                }
            }

            //判断为空

            dg_tjmx.DataSource = tb_tjmx;
            txtdm.Focus();


        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl2.SelectedTab.Text == "在途单据")
                {
                    DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;

                    Guid djid = new Guid(Convertor.IsNull(lbldjh.Tag, Guid.Empty.ToString()));//djid
                    string ssql = string.Format(" select * from yf_tj where id='{0}' and wcbj = 1 ", djid);
                    DataTable tb_wc = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb_wc.Rows.Count > 0)
                    {
                        return;
                    }

                    DataRow[] rows = new DataRow[] { };
                    if (djid == Guid.Empty)
                    {
                        rows = tb_tjmx.Select(string.Format("选择 =1"));
                    }
                    else
                    {
                        rows = tb_tjmx.Select(string.Format("选择 =1  or (id is not null or id <>'00000000-0000-0000-0000-000000000000' ) ", strpp, strlr, strjj));
                    }

                    ssql = "";
                    if (rows.Length > 0) ssql = rows[0]["cjid"].ToString();
                    for (int i = 1; i < rows.Length; i++)
                    {
                        ssql = ssql + "," + rows[i]["cjid"].ToString();
                    }
                    string err_text = "";
                    DataTable tbsh = YF_TJ_TJMX.SelectWsh(ssql, out err_text, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

                    dg_ztdj.DataSource = tbsh;
                }
                if (tabControl2.SelectedTab.Text == "批次明细")
                {
                    DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
                    Guid djid = new Guid(Convertor.IsNull(lbldjh.Tag, Guid.Empty.ToString()));//djid
                    string ssql = string.Format(" select * from yf_tj where id='{0}' and wcbj = 1 ", djid);
                    DataTable tb_wz = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb_wz.Rows.Count > 0)
                    {
                        Guid zxdjid = new Guid(tb_wz.Rows[0]["zxdjid"].ToString());
                        ssql = string.Format(@"  select dbo.fun_getDeptname(b.deptid) 科室,
                                            b.yppm 药品名称,b.ypgg 规格,b.sccj 厂家,
                                            b.ypsl 数量,b.ypdw 单位,a.ylsj 原零售价,a.xlsj 现零售价,
                                            a.scjhj 原进价,a.mrjhj 现进价, b.yppch 批次号,b.ypph 批号,rtrim(b.ypxq) 效期
                                            from yf_tjmx a 
                                            inner join yk_djmx b on a.cjid=b.cjid  and a.deptid=b.deptid and b.djid='{1}'
                                            where a.djid='{0}'  ", djid, zxdjid);
                        DataTable tb_pcmx = InstanceForm.BDatabase.GetDataTable(ssql);
                        dg_pcmx.DataSource = tb_pcmx;

                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void dg_tjmx_MouseDown(object sender, MouseEventArgs e)
        {
             
        }

        private void dg_tjmx_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //e.Control.Text = "";
            
        }

        private void dg_tjmx_DataGridViewCellKeyPress(object sender, DataGridViewCell cell, KeyPressEventArgs e)
        {
            //e.KeyChar = (char)Keys.F2;
            //e.Handled = true ;
            //SendKeys.Send("{F2}"); 
        }

        private void txtxs_gs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control col = (Control)sender;
            if (e.KeyChar == 13)
            {
                if (col.Name == txtxs_gs.Name)
                {
                    if (Convertor.IsNumeric(txtxs_gs.Text))
                    {
                        txtje_gs.Focus();
                    }
                }

                if (col.Name == txtje_gs.Name)
                {
                    if (Convertor.IsNumeric(txtje_gs.Text))
                    {
                        btnok_gs.Focus();
                    }
                }
            }
        }

        private void txtxs_gs_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Name == txtxs_gs.Name)
            {
                if (Convertor.IsNumeric(txtxs_gs.Text.Trim()))
                {
                    txtxs_gs.Text = Convert.ToDecimal(txtxs_gs.Text).ToString("0.000");
                    txtje_gs.Focus();
                }
                else
                {
                    txtxs_gs.Text = "1.000";
                    return;
                }

            }
            if (txt.Name == txtje_gs.Name)
            {
                if (Convertor.IsNumeric(txtje_gs.Text.Trim()))
                {
                    txtje_gs.Text = Convert.ToDecimal(txtje_gs.Text).ToString("0.00");
                    btnok_gs.Focus();
                }
                else
                {
                    txtje_gs.Text = "0.00";
                }
            }
        }

        //公式确定
        private void btnok_gs_Click(object sender, EventArgs e)
        {
            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
            decimal jhj = Convert.ToDecimal(txtyjhj_gs.Text);
            decimal xs = Convert.ToDecimal(txtxs_gs.Text);
            decimal je = Convert.ToDecimal(Convertor.IsNull(txtje_gs.Text,"0"));
            decimal xlsj = Convert.ToDecimal(jhj * xs) + je;
            int rowIndex =Convert.ToInt32(pnlgs.Tag);
            tb_tjmx.Rows[rowIndex]["现零售价"] = xlsj;
            tb_tjmx.Rows[rowIndex]["匹录"] = strlr;
            dg_pcmx.DataSource = tb_tjmx;
            pnlgs.Visible = false;

            txtyjhj_gs.Text = "";
            txtxs_gs.Text = "";
            txtje_gs.Text = "";

        }

        //公式取消
        private void btnqx_gs_Click(object sender, EventArgs e)
        {
            pnlgs.Visible = false;

            txtyjhj_gs.Text = "";
            txtxs_gs.Text = "";
            txtje_gs.Text = "";
        }

        private void chkycfl_CheckedChanged(object sender, EventArgs e)
        {
            pnlfl.Visible = !chkycfl.Checked;
        }

        private void txtje_gs_Leave(object sender, EventArgs e)
        {
            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
            decimal jhj = Convert.ToDecimal(txtyjhj_gs.Text);
            decimal xs = Convert.ToDecimal(Convertor.IsNull(txtxs_gs.Text,"0.000"));
            txtxs_gs.Text = xs.ToString("0.000");
            decimal je = Convert.ToDecimal(Convertor.IsNull(txtje_gs.Text, "0.00"));
            txtje_gs.Text = je.ToString("0.00");
            decimal xlsj = Convert.ToDecimal(jhj * xs) + je;
            txtxlsj.Text = xlsj.ToString("0.00");

        }
    }
}