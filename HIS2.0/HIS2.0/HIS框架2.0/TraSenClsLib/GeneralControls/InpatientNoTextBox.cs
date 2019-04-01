using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.GeneralControls
{
    /// <summary>
    /// InpatientNO 的摘要说明:住院号控件，只允许输入数字且位数不足8位时自动补零
    /// </summary>
    public class InpatientNoTextBox : TextBoxEx
    {
        private int _inpatientNoLength = 8;//住院号长度
        private int _inpatientNoType = 0;//住院号类型

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// InpatientNO住院号控件
        /// </summary>
        /// <param name="container"></param>
        public InpatientNoTextBox(System.ComponentModel.IContainer container)
        {
            ///
            /// Windows.Forms 类撰写设计器支持所必需的
            ///
            container.Add(this);
            InitializeComponent();
        }
        /// <summary>
        /// InpatientNO住院号控件
        /// </summary>
        public InpatientNoTextBox()
        {
            ///
            /// Windows.Forms 类撰写设计器支持所必需的
            ///
            InitializeComponent();

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

            this.SuspendLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region 属性
        /// <summary>
        /// 住院号长度(必须大于等于1)
        /// </summary>
        [DefaultValue(8), Description("住院号的长度(必须大于等于1)"), Category("自定义属性"), Browsable(true)]
        public int InpatientNoLength
        {
            get
            {
                return _inpatientNoLength;
            }
            set
            {
                _inpatientNoLength = value <= 0 ? 1 : value;
            }
        }
        /// <summary>
        /// 住院号默认类型
        /// </summary>
        [DefaultValue(0), Description("0=自然流水 1=YYYY+流水 2=YYYYMMDD+流水 3=YY+医院编码+流水"), Category("自定义属性"), Browsable(true)]
        public int InpatientNoType
        {
            get
            {
                return _inpatientNoType;
            }
            set
            {
                _inpatientNoType = value != 0 || value != 1 || value != 2 || value != 3 ? 0 : value;
            }
        }
        #endregion

        #region 重写事件
        /// <summary>
        /// 重写OnEnter事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            if (!Convertor.IsInteger(this.Text))
            {
                this.Text = computNo();
                this.SelectionStart = this.Text.Length;
            }
            //关闭中文输入法
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            base.OnEnter(e);
        }
        /// <summary>
        /// 重写OnTextChanged事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {

            string txt = computNo() + this.Text;
            this.Text = txt.Substring(txt.Length - _inpatientNoLength, _inpatientNoLength);

            this.SelectionStart = this.Text.Length;
            base.OnTextChanged(e);
        }

        /// <summary>
        /// 计算住院号
        /// </summary>
        /// <returns></returns>
        private string computNo()
        {
            string No = "";
            if (_inpatientNoLength <= 0)
            {
                _inpatientNoLength = 1;
            }
            for (int i = 0; i < _inpatientNoLength; i++)
            {
                No += "0";
            }
            return No;
        }

        #endregion
    }
}
