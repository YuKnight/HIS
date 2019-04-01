using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;

namespace Ts_zyys_jcsq
{
    public partial class FrmBW : Form
    {
        public string orderid;
        public string ordertext="";
        public string ordertag="";
        public string xmmc;
        public string xmclass;
        private string itemcode;
        public FrmBW()
        {
            InitializeComponent();
        }

        private void FrmBW_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            //dataGridView1.ReadOnly = true;//（控件只读属性）
            this.dataGridView1.AutoGenerateColumns = false;//（自增长列）
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            //dataGridView2.ReadOnly = true;//（控件只读属性）
            this.dataGridView2.AutoGenerateColumns = false;//（自增长列）
            cmb_xmmc.Text = xmmc;
            itemcode = get_itemcode(orderid);
            cmb_bwmcBind();
            dataviewBind();
        }
        /// <summary>
        /// 根据医嘱ID获取收费编码
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        private string get_itemcode(string orderid)
        {
            string itemcode="";
            DataTable dt = new DataTable();
            string sql=string.Format(@"select D_CODE   from JC_HOITEMDICTION  where order_id='{0}'",orderid);
            dt=InstanceForm._database.GetDataTable(sql);
            itemcode=dt.Rows[0]["D_CODE"].ToString();
            return itemcode;
        }
       /// <summary>
       /// 部位分类绑定
       /// </summary>
        private void cmb_bwmcBind()
        {

                DataTable dt = new DataTable();
                string sql = string.Format("select distinct bw_class from JC_HOITEMDICTIONCHILD where order_id='{0}'", itemcode.Trim());
                dt = InstanceForm._database.GetDataTable(sql);
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("该项目没有维护对应检查部位，请联系超声诊断科");
                    this.Close();
                }
                else
                {
                    cmb_bwmc.DataSource = dt;
                    cmb_bwmc.DisplayMember = "bw_class";
                    cmb_bwmc.ValueMember = "bw_class";
                    cmb_bwmc.SelectedIndex = 0;
                }
           
         

        }
       /// <summary>
       /// 部位数据绑定
       /// </summary>
        private void dataviewBind()
        {
            //if (xmclass == "B超" || xmclass == "彩超")
            //{
            //    xmclass = "超声";
            //}
            DataTable tb = new DataTable();
            //string sql = "  select TCMX_CODE,TCMX_NAME from JCBW  where  TC_CODE=" + this.cmb_bwmc.SelectedValue.ToString()+"and XM_NAME='"+xmclass+"'";
            string sql = "  select ORDER_POSITION_code,ORDER_POSITION,BW_XS from JC_HOITEMDICTIONCHILD  where ORDER_ID='" + itemcode + "'"+"and BW_class='"+cmb_bwmc.SelectedValue+"'";
            tb = FrmMdiMain.Database.GetDataTable(sql);
            dataGridView1.DataSource = tb;
        }

        public DataTable jcfltb()
        {
            string ssqljc = string.Format(@"select distinct A.jclxid ID,
                                                 B.name NAME,
                                                 A.jclxid TYPE   
                                                 from jc_jc_item A  left outer join      
                                                 jc_jcclassdiction B 
                                                 on A.jclxid=B.ID and B.class_type=0 where A.YZID='{0}' ", orderid);
            DataTable jcfltb = FrmMdiMain.Database.GetDataTable(ssqljc);
            return jcfltb;
        }
        /// <summary>
        /// 部位分类下拉框内容变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_bwmc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataviewBind();
        }
        /// <summary>
        /// 保存部位事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnqd_Click(object sender, EventArgs e)
        {
            string txt = "";
            string tg = "";
            if (bwnum_qx()==false)
            {
                MessageBox.Show("该项目部位数量为"+num()+",请核对部位数量或是否开了组合部位！");
            }
            else
            {
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    txt = txt+ dataGridView2.Rows[i].Cells["BW_CHECK"].Value.ToString().Trim() + "|";
                    tg = tg + dataGridView2.Rows[i].Cells["BW_CHECK_CODE"].Value.ToString().Trim() + "|";
                }
                ordertext = txt;
                if (!string.IsNullOrEmpty(ordertext))
                    ordertext = ordertext.TrimEnd('|');
                ordertag = tg;
                if (!string.IsNullOrEmpty(ordertag))
                    ordertag = ordertag.TrimEnd('|');
                this.Close();
            }
            
           
        }
        /// <summary>
        /// 检查部位数量是否正确
        /// </summary>
        /// <returns></returns>
        private bool bwnum_qx()//检查部位数量是否正确
        {
            //DataTable dt = new DataTable();
            //string sSqlbw = " select bw_num  from JC_HOITEMDICTIONCHILD  where  ORDER_ID='" + itemcode + "'";
            //dt = FrmMdiMain.Database.GetDataTable(sSqlbw);
            double bwsl=0;
            if (dataGridView2.RowCount <= 0)
            {
                return false;
            }
            else
            {
                for (int i=0; i < dataGridView2.RowCount; i++)
                {
                    bwsl += Convert.ToDouble(dataGridView2.Rows[i].Cells["CHECK_BW_XS"].Value.ToString());
                }
                if (bwsl == Convert.ToDouble(num()))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }


        }

        private string num()//h获取检查部位数量
        {
            DataTable dt = new DataTable();
            string sSqlbw = " select bw_num  from JC_HOITEMDICTIONCHILD  where  ORDER_ID='" + itemcode + "'";
            dt = FrmMdiMain.Database.GetDataTable(sSqlbw);
            return dt.Rows[0][0].ToString();
        }
        /// <summary>
        /// 添加到已选部位列表
        /// </summary>
        /// <param name="tcmxname"></param>
        /// <param name="tcmxcode"></param>
        /// <param name="bw_xs"></param>
        private void dv2Add(string tcmxname,string tcmxcode,string bw_xs)
        {
            DataTable dt = new DataTable();
            DataRow row;
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "BW_CHECK";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "BW_CHECK_CODE";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CHECK_BW_XS";
            dt.Columns.Add(column);
            if (dataGridView2.RowCount <= 0)
            {
                row = dt.NewRow();
                row["BW_CHECK"] = tcmxname;
                row["BW_CHECK_CODE"] = tcmxcode;
                row["CHECK_BW_XS"] = bw_xs;
                dt.Rows.Add(row);
            }
            else
            {
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    row = dt.NewRow();
                    row["BW_CHECK"] = dataGridView2.Rows[i].Cells["BW_CHECK"].Value.ToString();
                    row["BW_CHECK_CODE"] = dataGridView2.Rows[i].Cells["BW_CHECK_CODE"].Value.ToString();
                    row["CHECK_BW_XS"] = dataGridView2.Rows[i].Cells["CHECK_BW_XS"].Value.ToString();
                    dt.Rows.Add(row);

                }
                row = dt.NewRow();
                row["BW_CHECK"] = tcmxname;
                row["BW_CHECK_CODE"] = tcmxcode;
                row["CHECK_BW_XS"] = bw_xs;
                dt.Rows.Add(row);
            }
            dataGridView2.DataSource = dt;
            
        }
        /// <summary>
        /// 判断部位是否重复
        /// </summary>
        /// <returns></returns>
        private bool NOTrepetition()
        {
           bool result=false;
           for (int i=0; i < dataGridView2.RowCount; i++)
           {
               if (dataGridView1.CurrentRow.Cells["ordertg"].Value.ToString() == dataGridView2.Rows[i].Cells["BW_CHECK_CODE"].Value.ToString())
               {
                   result = true;
               }
           }
           return result;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (NOTrepetition())
            {
                MessageBox.Show("项目部位已经存在！");
            }
            else
            {
                dv2Add(dataGridView1.CurrentRow.Cells["Ordertxt"].Value.ToString(), dataGridView1.CurrentRow.Cells["ordertg"].Value.ToString(),dataGridView1.CurrentRow.Cells["bwxs"].Value.ToString());
            }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
        }
    }
}