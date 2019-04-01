using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ts_zyys_public;
using TrasenClasses.GeneralClasses;

namespace Ts_zyys_jcsq
{
    public partial class FrmJCBWXX : Form
    {
        private DbQuery myQuery = new DbQuery();
        List<Item> litem = new List<Item>();//用于保存选中的检查部位
        string order_id = "";

        public FrmJCBWXX()
        {
            InitializeComponent();
        }

        public FrmJCBWXX(DataTable dt, List<Item> litems,string _order_id)
        {
            InitializeComponent();
            litem = litems;
            order_id = _order_id;
            BinderPositionCheckBox(dt);
        }

        private void FrmJCBWXX_Load(object sender, EventArgs e)
        {

        }

        private void BinderPositionCheckBox(DataTable dt)
        {
            //ckbPosition.Items.Clear();
            Item jcItem = null;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                jcItem = new Item();
                jcItem.Id = Convert.ToInt16(dt.Rows[i]["ID"]);

                jcItem.positionName = dt.Rows[i]["ORDER_POSITION"].ToString().Trim();
                jcItem.orderID = Convert.ToInt32(dt.Rows[i]["order_id"]);

                ckbPosition.Items.Add(jcItem);

            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (ckbPosition.SelectedItems.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请至少选择一个检查部位", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 获取选中的检查部位
        /// </summary>
        /// <returns></returns>
        public List<Item> GetPositionItem()
        {

            if (ckbPosition.CheckedItems.Count > 0)
            {
                for (int i = 0; i < ckbPosition.CheckedItems.Count; i++)
                {
                    Item bwitem = new Item();
                    bwitem.Id = ((Item)ckbPosition.CheckedItems[i]).Id;
                    bwitem.orderID = ((Item)ckbPosition.CheckedItems[i]).orderID;
                    bwitem.positionName = ((Item)ckbPosition.CheckedItems[i]).positionName;
                    litem.Add(bwitem);
                }
            }

            return litem;
        }



        private void ckbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = myQuery.GetMaxAndMinItem(order_id);
            if (dt.Rows.Count > 0)
            {
                int a = ckbPosition.CheckedItems.Count;
                int b = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["MINITEM"], "0"));
                int c = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["MAXITEM"], "0"));
                if (b != 0 && c != 0)
                {
                    if (a < b || a > c)
                    {
                        MessageBox.Show("请选择值在" + dt.Rows[0]["MINITEM"] + "和" + dt.Rows[0]["MAXITEM"]+"之间");
                        ckbPosition.SetItemChecked(ckbPosition.SelectedIndex, false);
                    }
                }
            }
           
        }

        #region 自定义项
        public class Item
        {

            private int _id;
            private string _positionName;
            private int _orderID;

            public Item()
            {
                _id = 0;
                _positionName = "";
                _orderID = 0;
            }

            /// <summary>
            /// 检查项目ID
            /// </summary>
            public int orderID
            {
                get { return _orderID; }
                set { _orderID = value; }
            }
            /// <summary>
            /// 检查部位名称
            /// </summary>
            public string positionName
            {
                get { return _positionName; }
                set { _positionName = value; }
            }
            /// <summary>
            /// 检查部位ID
            /// </summary>
            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public override string ToString()
            {
                return _positionName.Trim();
            }
        }
        #endregion
    }

}