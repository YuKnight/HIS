using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mz_tjbb
{
    public partial class Frm_AddDateWhere : Form
    {
        /// <summary>
        /// 保存后存储包含值的时间控件
        /// </summary>
        public List<DateTimePicker> ListDateWhere = new List<DateTimePicker>();
        /// <summary>
        /// 新增后存储在此list用于新增、删除控件
        /// </summary>
        private List<Control> Controllist = new List<Control>();
        /// <summary>
        /// 当前最后一行的开始时间控件  用于判断移除时间控件时
        /// </summary>
        private DateTimePicker currentbdtp;
        /// <summary>
        /// 当前最后一行的结束时间控件  用于判断移除时间控件时
        /// </summary>
        private DateTimePicker currentedtp;
        /// <summary>
        /// 当前最后一行的lab
        /// </summary>
        private Label currentlab;
        /// <summary>
        /// 新增时间控件 初始化为4
        /// </summary>
        private int dtpcount = 4;
        public Frm_AddDateWhere( List<DateTimePicker> _list)
        {
            this.ListDateWhere = _list;
            InitializeComponent();
        }


        private void Link_AddDateWhere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                #region 新增控件
                DateTimePicker dtp = new DateTimePicker();
                DateTimePicker etp = new DateTimePicker();
                dtp.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                etp.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                dtp.Format = DateTimePickerFormat.Custom;
                etp.Format = DateTimePickerFormat.Custom;
                dtp.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
                etp.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
                Font _font = this.dtp3.Font;
                dtp.Font = _font;
                etp.Font = _font;
                /*单数代表开始时间 复数代表结束时间*/
                this.dtpcount++;
                dtp.Tag = "dtp" + this.dtpcount.ToString();
                this.dtpcount++;
                etp.Tag = "dtp" + this.dtpcount.ToString();

                Label _lab = new Label();
                _lab.Text = "到";

                dtp.Width = 170;
                etp.Width = 170;
                //dtp.Tag = "Bdate";
                //etp.Tag = "Edate";
                Point _p = new Point();
                int _x = Link_AddDateWhere.Location.X;
                int _y = Link_AddDateWhere.Location.Y;

                _p.X = _x - 326;
                _p.Y = _y;
                dtp.Location = _p;

                _p.X = _x - 123;
                etp.Location = _p;

                _p.X = _x - 150;
                _p.Y = _y + 3;
                _lab.Location = _p;

                this.Controls.Add(dtp);
                this.Controls.Add(etp);
                this.Controls.Add(_lab);

                Controllist.Add(dtp);
                Controllist.Add(etp);
                Controllist.Add(_lab);
                #endregion

                #region 坐标更新
                Point ButPoint = new Point();
                ButPoint.Y = _y + this.dtp3.Height + (this.dtp3.Height / 2);
                ButPoint.X = _x;
                //新增日期link纵向坐标等于现有的纵向坐标+dtp的高度+dtp高度的一半
                this.Link_AddDateWhere.Location = ButPoint;
                ButPoint.X = this.Link_Remove.Location.X;
                this.Link_Remove.Location = ButPoint;
                //保存button的纵向坐标等于 button现有的纵向坐标+dtp的高度+dtp高度的一半
                ButPoint.Y = _y + 28 + this.dtp3.Height + (this.dtp3.Height / 2);
                ButPoint.X = this.but_save.Location.X;
                this.but_save.Location = ButPoint;
                ButPoint.X = this.but_Cancal.Location.X;
                this.but_Cancal.Location = ButPoint;
                #endregion
                this.Height = this.Size.Height + dtp.Size.Height + 20;
                this.currentbdtp = dtp;
                this.currentedtp = etp;
                this.currentlab = _lab;
                this.Link_Remove.Enabled = true;
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.Message, "提示");
            }
        }
        /// <summary>
        /// 存储用户保存的时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_save_Click(object sender, EventArgs e)
        {
            try
            {
                this.ListDateWhere.Add(this.dtp3);
                this.ListDateWhere.Add(this.dtp4);
                DateTimePicker dtp = null;
                foreach (Control ctr in this.Controllist)
                {
                    if (ctr is DateTimePicker)
                    {
                        dtp = (DateTimePicker)ctr;
                        this.ListDateWhere.Add(dtp);
                    }
                }
                this.Close();
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }
        /// <summary>
        /// 验证是否允许删除时间控件
        /// </summary>
        /// <returns></returns>
        private bool CheckDelDtp()
        {
            int i = 0;
            try
            {
                foreach (Control ctr in this.Controls)
                {
                    if (ctr is DateTimePicker)
                    {
                        i++;
                    }
                }
                if (i > 2)
                    return true;
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message);
            }
            return false;
        }
        /// <summary>
        /// 获取最后一行的控件
        /// </summary>
        private void SetCurrentDtp()
        {
            if (this.Controllist.Count < 3)
                return;
            this.currentbdtp = (DateTimePicker)this.Controllist[this.Controllist.Count - 3];
            this.currentedtp = (DateTimePicker)this.Controllist[this.Controllist.Count - 2];
            this.currentlab = (Label)this.Controllist[this.Controllist.Count - 1];

        }

        private void Link_Remove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.currentbdtp == null)
                return;
            if (this.Controllist.Count<1)
                return;
            this.Controls.Remove(this.currentbdtp);
            this.Controls.Remove(this.currentedtp);
            this.Controls.Remove(this.currentlab);

            this.Controllist.Remove(this.currentbdtp);
            this.Controllist.Remove(this.currentedtp);
            this.Controllist.Remove(this.currentlab);
            this.currentbdtp = null;
            this.currentedtp = null;
            this.currentlab = null;
            SetCurrentDtp();//移除后再得到最后一行允许删除的控件
            /*上移按钮控件*/
            #region 坐标更新
            int _x = Link_AddDateWhere.Location.X;
            int _y = Link_AddDateWhere.Location.Y;

            Point ButPoint = new Point();
            ButPoint.Y = _y - this.dtp3.Height- (this.dtp3.Height / 2);
            ButPoint.X = _x;
            //新增日期link纵向坐标等于现有的纵向坐标+dtp的高度+dtp高度的一半
            this.Link_AddDateWhere.Location = ButPoint;
            ButPoint.X = this.Link_Remove.Location.X;
            this.Link_Remove.Location = ButPoint;
            //保存button的纵向坐标等于 button现有的纵向坐标+dtp的高度+dtp高度的一半
            ButPoint.Y = _y - 6; //- (this.dtp1.Height / 2);
            ButPoint.X = this.but_save.Location.X;
            this.but_save.Location = ButPoint;
            ButPoint.X = this.but_Cancal.Location.X;
            this.but_Cancal.Location = ButPoint;
            #endregion
            this.Height = this.Size.Height-this.dtp3.Height - 20;
            if (!CheckDelDtp())
                this.Link_Remove.Enabled = false;
        }

        private void but_Cancal_Click(object sender, EventArgs e)
        {
            this.ListDateWhere.Clear();
            this.Close();
        }

        private void Frm_AddDateWhere_Load(object sender, EventArgs e)
        {
            dtp3.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp4.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
        }
    }
}
