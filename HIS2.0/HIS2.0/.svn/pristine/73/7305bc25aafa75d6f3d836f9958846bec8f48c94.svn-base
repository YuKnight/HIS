using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
/*
  Create by zouchiua 2012-3-14
  检索控件
*/
namespace ts_zyhs_ypxx
{
    public delegate void Mydelegte();
    
    public partial class SerchText : UserControl
    {
        public SerchText()
        {
            InitializeComponent();
           
           
        }
        Image im;
       // [Browsable(true),Category("appearance")]
       // [TagProperty("cc",0,0,0,0)]   
  [Browsable(true)]   
  [EditorAttribute("",   typeof(System.Drawing.Design.UITypeEditor))]  
        public Image textimage
        {
            get
            {
                return im;
            }
            set
            {
                im = value;
            }
        }
        private string oldstring = "";
        public DataRow row;
        public event Mydelegte TextChage;
        [Description("赋值."), Category("Property Changed")]
        public event Mydelegte fz;
        [Description("赋值后进行检索."), Category("Property Changed")]
        public event Mydelegte Js;
        public  DataTable tb = new DataTable();
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m); 
            System.Drawing.Graphics g = this.CreateGraphics();
            Brush br = new SolidBrush(Color.Black);
            Pen p = new Pen(br);
            g.DrawLine(p, new Point(0, this.textBox1.Height + 1), new Point(this.textBox1.Width, this.textBox1.Height +1));
            //g.DrawLine(p, new Point(0, this.Height - 1), new Point(this.Width, this.Height - 1));
            if (m.Msg == 0x0201)//鼠标单击
            {
                Point pt = Cursor.Position;
                Rectangle rc = this.ClientRectangle;
                rc.Height += this.dataGridView1.Height;
                rc = this.RectangleToScreen(rc);
                if (!rc.Contains(pt))
                {
                    this.dataGridView1.Visible = false;
                    this.dataGridView1.DataSource = null;
                }
            }
            base.WndProc(ref m);
        }
        /// <summary>
        /// 当触发控件为文本框或者组合框时设定选项网格的上边距与左边距
        /// </summary>
        /// <param name="occurTextBox">触发文本框</param>
        /// <param name="cardGrid">选项网格</param>
        /// <param name="parentCtrl">父级控件</param>
        /// <param name="oppositeTop">在父控件中的相对纵坐标</param>
        /// <param name="oppositeLeft">在父控件中的相对横坐标</param>
        public static void SetCardGridTopAndLeft(Control occurTextBox, DataGridView cardGrid, Control parentCtrl, int oppositeTop, int oppositeLeft)
        {
            //将网格放在触发文本框上面或下面都不合适
            if (parentCtrl.Height < cardGrid.Height + occurTextBox.Height + oppositeTop && oppositeTop < cardGrid.Height)
            {
                #region 高度不适合
                if (parentCtrl.Parent != null)
                {
                    SetCardGridTopAndLeft(occurTextBox, cardGrid, parentCtrl.Parent, oppositeTop + parentCtrl.Top, oppositeLeft + parentCtrl.Left);
                }
                #endregion
            }
            else
            {
                #region 高度适合
                cardGrid.Parent = parentCtrl;//设置父控件
                cardGrid.BringToFront();
                if (parentCtrl.Height < cardGrid.Height + occurTextBox.Height + oppositeTop)		//如果其下边界超出父容器底边界则底部与父容器底边界对齐
                {
                    cardGrid.Top = oppositeTop - cardGrid.Height;
                }
                else
                {
                    cardGrid.Top = oppositeTop + occurTextBox.Height;
                }
                if (parentCtrl.Width < cardGrid.Width + oppositeLeft)
                {
                    cardGrid.Left = oppositeLeft - (cardGrid.Width - occurTextBox.Width);
                    if (cardGrid.Left < 0)	//宽度不适合
                    {
                        if (parentCtrl.Parent != null)
                        {
                            SetCardGridTopAndLeft(occurTextBox, cardGrid, parentCtrl.Parent, oppositeTop + parentCtrl.Top, oppositeLeft + parentCtrl.Left);
                        }
                    }
                }
                else
                {
                    cardGrid.Left = oppositeLeft;
                }
                #endregion
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
             
            string ss = this.textBox1.Text;
            if ((Keys)e.KeyCode != Keys.Up && (Keys)e.KeyCode != Keys.Down && (Keys)e.KeyCode != Keys.Left && (Keys)e.KeyCode != Keys.Right && (Keys)e.KeyCode != Keys.Enter)
            {
                if (TextChage!=null)
                    TextChage();
            }
            if ((Keys)e.KeyCode == Keys.Escape || (Keys)e.KeyCode == Keys.Enter || (Keys)e.KeyCode == Keys.Left || (Keys)e.KeyCode == Keys.Right)//
            {
                 
                this.dataGridView1.Visible = false;
                //检索
                if(Js!=null)
                   Js();
                tb = null;
            }
            else
                this.dataGridView1.Visible = true;
            //上下移动
            if ((Keys)e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                if (this.dataGridView1.Rows.Count == 0)
                    return;
                if (this.dataGridView1.CurrentRow.Index == this.dataGridView1.Rows.Count - 1)
                {
                    //不做任何操作
                }
                else
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index + 1].Cells[0];
            }
            // tb.DefaultView.RowFilter = "py_code like '%" + this.textBox1.Text.Trim() + "%' or wb_code like '%" + this.textBox1.Text.Trim() + "%'";
            if (e.KeyValue == 13 || e.KeyValue == 113) return;


            TextBox btn = new TextBox();
            this.dataGridView1.Width =  this.Width;
            this.dataGridView1.DataSource = tb;
            //定位
            //定位卡片
            SetCardGridTopAndLeft((TextBox)sender, this.dataGridView1, ((TextBox)sender).Parent, ((TextBox)sender).Top, ((TextBox)sender).Left);
            return;
           
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (this.dataGridView1.CurrentRow == null)
                    { 
                        //SendKeys.Send("{Tab}");
                        if (this.dataGridView1.Visible == true)
                            this.textBox1.Text = "";
                        this.dataGridView1.Visible = false;
                    }
                    else
                        this.dataGridView1_CellDoubleClick(null, null);
                    return true;
                    break;
                case  Keys.Up:
                    
                    if (this.dataGridView1.Rows.Count == 0)
                        return true;
                    if (this.dataGridView1.CurrentRow.Index == 0)
                    {
                        //不做任何操作
                    }
                    else
                    {
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index - 1].Cells[0];
                    }
                  
                    return true;
                    break;
                case Keys.Escape:
                     
                    if (this.dataGridView1.Visible == true)
                         this.textBox1.Text = "";  
                    this.dataGridView1.Visible = false;
                    tb = null;
                    return false;
            
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            
        }
        private void SerchText_Load(object sender, EventArgs e)
        {
            this.textBox1.LostFocus += new EventHandler(textBox1_LostFocus);
            JzMouseClik(this);
        }

        void textBox1_LostFocus(object sender, EventArgs e)
        {
             //this.dataGridView1.Columns[1].AutoSizeMode
            //this.dataGridView1.Visible = false;
            //throw new Exception("The method or operation is not implemented.");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.CurrentRow == null)
            {
                if (this.dataGridView1.Visible == true)
                    this.textBox1.Text = "";  
                this.dataGridView1.Visible = false;
                return;
            }
            row = this.tb.Rows[this.dataGridView1.CurrentRow.Index];
            this.dataGridView1.Visible = false;
            this.dataGridView1.DataSource = null;
            this.textBox1.Focus();
            if (fz != null)
            {
                fz();
                if (Js != null)
                    Js();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.dataGridView1_CellDoubleClick(null,null);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

          string title = (e.RowIndex + 1).ToString();
          Brush bru = Brushes.Black;
          e.Graphics.DrawString(title, this.dataGridView1.DefaultCellStyle.Font,
          bru, e.RowBounds.Location.X + this.dataGridView1.RowHeadersWidth / 2 - 4, e.RowBounds.Location.Y + 4);
        }
        /// <summary>
        /// 失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Leave(object sender, EventArgs e)
        {
            //Point p = Cursor.Position;
            //Rectangle rc = this.ClientRectangle;
            //rc.Height += this.dataGridView1.Height;
            //rc = this.RectangleToScreen(rc);

            //if (!rc.Contains(p))
            //{
            //    this.dataGridView1.Visible = false;
            //    this.dataGridView1.DataSource = null;
            //}
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.textBox1.Focus();
        }
        public void TextLosfocus()
        {
            this.dataGridView1.Focus();
        }
        /// <summary>
        /// 循环向上找到窗体
        /// </summary>
        /// <param name="ct"></param>
        private void JzMouseClik(Control ct)
        {
            Control Parent=ct.Parent;
            if (Parent == null)
                return;
            if ((Parent as System.Windows.Forms.Form) == null)
            { 
                JzMouseClik(Parent);  
            }
            else
            {
                Parent.MouseClick += new MouseEventHandler(SerchText_MouseClick);
                SXBljzsbMouse(Parent);
                return;
            }
        }
        /// <summary>
        /// 向下遍历 加载鼠标事件
        /// </summary>
        /// <param name="ct"></param>
        private void SXBljzsbMouse(Control ct)
        {
            if (ct == null)
                return;
            for (int i = 0; i < ct.Controls.Count; i++)
            {
                if (ct.Controls[i] == this)
                    break;
                ct.Controls[i].MouseClick += new MouseEventHandler(SerchText_MouseClick);
                SXBljzsbMouse(ct.Controls[i]);
            }
        }

        void SerchText_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.dataGridView1.Visible == true)
                this.textBox1.Text = "";
            this.dataGridView1.Visible = false;
            
            this.dataGridView1.DataSource = null;
        }
      
    }
}
