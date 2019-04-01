using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ts_zyhs_classes
{
    public partial class UcShowCard : UserControl
    {
        private int iType;

        /// <summary>
        /// 0：过滤   1：选中
        /// </summary>
        public int IType
        {
            get { return iType; }
            set { iType = value; }
        }

        /// <summary>
        /// 0：过滤   1：选中
        /// </summary>
        public string Key
        {
            get { return txtSerch.Tag == null ? "" : txtSerch.Tag.ToString(); }
            set { txtSerch.Tag = value; }
        }

        /// <summary>
        /// 0：过滤   1：选中
        /// </summary>
        public string Value
        {
            get { return  txtSerch.Text; }
            set { txtSerch.Text = value; }
        }

        public UcShowCard()
        {
            InitializeComponent();
        }


        private string[] _headtext;
        private string[] _mappingname;
        private string[] _searchfields;
        private int[] _colwidth;
        private DataTable _dtSrc;


        private DataRow _row;

        public DataRow Row
        {
            get { return _row; }
            set { _row = value; }
        }

        /// <summary>
        /// 初始化收索控件
        /// </summary>
        /// <param name="headtext">列名</param>
        /// <param name="mappingname">列字段</param>
        /// <param name="searchfields">检索字段</param>
        /// <param name="colwidth">列名宽度</param>
        /// <param name="dtSrc">待检索的数据源</param>
        public void Init(string[] headtext, string[] mappingname, string[] searchfields, int[] colwidth, DataTable dtSrc)
        {
            _headtext = headtext;
            _mappingname = mappingname;
            _searchfields = searchfields;
            _colwidth = colwidth;
            _dtSrc = dtSrc;
        }

        // 创建一个委托，返回类型为void，两个参数
        public delegate void MyDel();

        // 将创建的委托和特定事件关联,在这里特定的事件为KeyDown
        public event MyDel MyDelEvent;

        private void txtSerch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (_dtSrc == null || _dtSrc.Rows.Count <= 0)
                return;

            int nkey = (int)e.KeyChar;
            Control control = (Control)sender;

            //if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { }
            //else { return; }


            if (nkey == 8 || nkey == 46) { control.Text = ""; control.Tag = ""; return; }

            try
            {

                TrasenFrame.Forms.FrmSelectCard f2 = new TrasenFrame.Forms.FrmSelectCard(_searchfields, _headtext, _mappingname, _colwidth);

                f2.sourceDataTable = _dtSrc;

                f2.srcControl = control;
                f2.Font = control.Font;
                f2.Width = 700;
                f2.Height = 300;
                f2.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f2.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                    return;
                }
                else
                {
                    //control.Text = row["ypspm"].ToString();
                    //control.Tag = row["cjid"].ToString();
                    _row = f2.SelectDataRow;

                    if (_row != null)
                    {
                        //string swhere = "1=1 ";
                        //swhere += chkBed.Checked ? "and 床号='" + txtMxBed.Text.Trim() + "'" : "";
                        //swhere += chkZyh.Checked ? "and 住院号='" + txtMxZyh.Text.Trim() + "'" : "";
                        //swhere += chkName.Checked ? "and 姓名='" + txtMxName.Text.Trim() + "'" : "";

                        //dt.DefaultView.RowFilter = swhere;
                        try
                        {
                            MyDelEvent();
                            txtSerch.Focus();
                            txtSerch.SelectAll();
                        }
                        catch { }
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }
    }
}
