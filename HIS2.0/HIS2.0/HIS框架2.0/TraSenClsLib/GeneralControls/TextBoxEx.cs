using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace TrasenClasses.GeneralControls
{
    /// <summary>
    /// 摘要说明:获取焦点后变色，离开焦点后恢复为原背景色,回车后光标自动跳至设定控件
    /// </summary>
    public class TextBoxEx : TextBox
    {
        private Color _enterBackColor;
        private Color _oldBackColor;
        private Color _enterForeColor;
        private Color _oldForeColor;
        private Color _enabledTrueBackColor;
        private Color _enabledFalseBackColor;
        private Control _nextControl;
        private Control _previousControl;

        #region  jianqg 2012-10-6 emr&his框架整合  增加
        private bool _EnableRighKey=true;

        public const int WM_PAINT = 0x000F;//该变量标识绘制TextBox控件


        private const int WM_RBUTTONDOWN = 0x0204;//该变量表示鼠标右键的信息
        private const int WM_GETTEXT = 0x000d;//该变量表示从文本框中获取文本的信息
        private const int WM_CONTEXTMENU = 0x007B;//该变量表示右键菜单的信息


        protected override void WndProc(ref Message m)
        {
            if (!_EnableRighKey)
            {
                if (m.Msg == WM_RBUTTONDOWN || m.Msg == WM_GETTEXT || m.Msg == WM_CONTEXTMENU)//当当前处理的信息为鼠标右键、从文本框中获取文本、右键菜单以及复制信息时
                {
                    return;//直接返回，不进行处理
                }
            }
            base.WndProc(ref m);//处理消息
            if (m.Msg == WM_PAINT)
            {
                Pen pen = new Pen(Brushes.Black, 1.5f);
                using (Graphics g = this.CreateGraphics())
                {
                    g.DrawLine(pen, new Point(0, this.Size.Height - 1), new Point(this.Size.Width, this.Size.Height - 1));
                }
            }
        }
        #endregion
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// 自定义TextBox(获取焦点后变色，离开焦点后恢复为原背景色)
        /// </summary>
        /// <param name="container"></param>
        public TextBoxEx(System.ComponentModel.IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            _enterForeColor = SystemColors.WindowText;
            _enterBackColor = SystemColors.Window;
            _oldBackColor = this.BackColor;
            _oldForeColor = this.ForeColor;
            _enabledTrueBackColor = SystemColors.Window;
            _enabledFalseBackColor = SystemColors.Control;
            _nextControl = null;
            _previousControl = null;
            //jianqg 2012-10-6 emr&his框架整合  增加
            this.BackColor = SystemColors.ActiveCaptionText;
        }

        /// <summary>
        ///自定义TextBox(获取焦点后变色，离开焦点后恢复为原背景色)
        /// </summary>
        public TextBoxEx()
        {
            InitializeComponent();
            _enterForeColor = SystemColors.WindowText;
            _enterBackColor = SystemColors.Window;
            _oldBackColor = this.BackColor;
            _oldForeColor = this.ForeColor;
            _enabledTrueBackColor = SystemColors.Window;
            _enabledFalseBackColor = SystemColors.Control;
            _nextControl = null;
            _previousControl = null;
            //jianqg 2012-10-6 emr&his框架整合  增加
            _EnableRighKey = true;
            this.BackColor = SystemColors.ActiveCaptionText;
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 获得焦点后的前景色
        /// </summary>
        [Browsable(true)]
        [DefaultValue("WindowText"), Description("获取焦点后的前景色"), Category("Appearance")]
        public Color EnterForeColor
        {
            get
            {
                return _enterForeColor;
            }
            set
            {
                _enterForeColor = value;
            }
        }
        /// <summary>
        /// 获得焦点后的背景色
        /// </summary>
        [Browsable(true)]
        [DefaultValue("Window"), Description("获取焦点后的背景色"), Category("Appearance")]
        public Color EnterBackColor
        {
            get
            {
                return _enterBackColor;
            }
            set
            {
                _enterBackColor = value;
            }
        }
        /// <summary>
        /// Enabled变为True时的背景颜色
        /// </summary>
        [Browsable(true)]
        [DefaultValue("Control"), Description("Enabled变为True时的背景颜色"), Category("Appearance")]
        public Color EnabledTrueBackColor
        {
            get
            {
                return _enabledTrueBackColor;
            }
            set
            {
                _enabledTrueBackColor = value;
            }
        }
        /// <summary>
        /// Enabled变为False时的背景颜色
        /// </summary>
        [Browsable(true)]
        [DefaultValue("Window"), Description("Enabled变为False时的背景颜色"), Category("Appearance")]
        public Color EnabledFalseBackColor
        {
            get
            {
                return _enabledFalseBackColor;
            }
            set
            {
                _enabledFalseBackColor = value;
            }
        }
        /// <summary>
        /// 当SelectionStart=0时按左方向键跳至该控件
        /// </summary>
        [Browsable(true)]
        [DefaultValue("NULL"), Description("当SelectionStart=0时按左方向键跳至该控件"), Category("Behavior")]
        public Control PreviousControl
        {
            get
            {
                return _previousControl;
            }
            set
            {
                _previousControl = value;
            }
        }
        /// <summary>
        /// 当SelectionStart=SelectionLength时按右方向键跳至该控件
        /// </summary>
        [Browsable(true)]
        [DefaultValue("NULL"), Description("当SelectionStart=SelectionLength时按右方向键跳至该控件"), Category("Behavior")]
        public Control NextControl
        {
            get
            {
                return _nextControl;
            }
            set
            {
                _nextControl = value;
            }
        }
        /// <summary>
        /// 禁用TextBox右键菜单功能
        /// jianqg 2012-10-6 emr&his框架整合  增加
        /// </summary>
        [Browsable(true)]
        [DefaultValue("True"), Description("是否禁用TextBox右键菜单功能"), Category("Appearance")]
        public Boolean EnabledRightKey
        {
            get
            {
                return _EnableRighKey;
            }
            set
            {
                _EnableRighKey = value;
            }
        }
        #endregion

        #region 重写事件
        /// <summary>
        /// 重写OnKeyDown事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && this.SelectionStart == 0 && _previousControl != null && _previousControl.CanFocus)
            {
                _previousControl.Focus();
                if (_previousControl.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)) || _previousControl.GetType() == typeof(System.Windows.Forms.TextBox))//文本框
                {
                    ((TextBox)_previousControl).SelectionStart = 0;
                    ((TextBox)_previousControl).SelectAll();
                }

            }
            else if (((e.KeyCode == Keys.Right && (this.SelectionStart == this.Text.Length || this.SelectedText == this.Text)) || e.KeyCode == Keys.Enter)
                && _nextControl != null && _nextControl.CanFocus)
            {
                _nextControl.Focus();
                if (_nextControl.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)) || _nextControl.GetType() == typeof(System.Windows.Forms.TextBox))//文本框
                {
                    ((TextBox)_nextControl).SelectionStart = 0;
                    ((TextBox)_nextControl).SelectAll();
                }
            }
            base.OnKeyDown(e);
        }
        /// <summary>
        /// 重写OnEnabledChanged事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            if (this.Enabled)
            {
                this.BackColor = _enabledTrueBackColor;
            }
            else
            {
                this.BackColor = _enabledFalseBackColor;
            }
            base.OnEnabledChanged(e);
        }

        /// <summary>
        /// 重写OnEnter事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            this.ForeColor = _enterForeColor;
            this.BackColor = _enterBackColor;
            base.OnEnter(e);
        }

        /// <summary>
        ///  重写OnLeave事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            this.ForeColor = _oldForeColor;
            this.BackColor = _oldBackColor;
            base.OnLeave(e);
        }

        #endregion
    }
}
