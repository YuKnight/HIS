using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;

namespace ts_zyhs_yzdy
{
    public partial class testCoolPrintPreviewDialog : Form
    {
        public testCoolPrintPreviewDialog()
        {
            InitializeComponent();
        }

          //--------------------------------------------------------------------
        #region ** fields

        PrintDocument _doc;
        string title = "";

        #endregion

        public string TilteValue
        {
            get { return title; }
            set { title = value; }
        }


        //--------------------------------------------------------------------
        #region ** ctor

           
        /// <summary>
        /// Initializes a new instance of a <see cref="testCoolPrintPreviewDialog"/>.
        /// </summary>
        /// <param name="parentForm">Parent form that defines the initial size for this dialog.</param>
        public testCoolPrintPreviewDialog(Control parentForm)
        {
            InitializeComponent();
            //if (emrEdit.isCountPages == true)
            //{
            //    this._btnPrint.Enabled = false;
            //}

            _btnPageSetup.Enabled = false;
            _btnPageSetup.Visible = false;
     

            if (parentForm != null)
            {
                Size = parentForm.Size;
            }
        }
        #endregion

        //--------------------------------------------------------------------
        #region ** object model

        /// <summary>
        /// Gets or sets the <see cref="PrintDocument"/> to preview.
        /// </summary>
        public PrintDocument Document
        {
            get { return _doc; }
            set
            {
                // unhook event handlers
                if (_doc != null)
                {
                    _doc.BeginPrint -= _doc_BeginPrint;
                    _doc.EndPrint -= _doc_EndPrint;
                }

                // save the value
                _doc = value;

                // hook up event handlers
                if (_doc != null)
                {
                    _doc.BeginPrint += _doc_BeginPrint;
                    _doc.EndPrint += _doc_EndPrint;
                }


                // don't assign document to preview until this form becomes visible
                if (Visible)
                {
                    _preview.Document = Document;
                }
                
            }
        }

        #endregion

        //--------------------------------------------------------------------
        #region ** overloads

        /// <summary>
        /// Overridden to assign document to preview control only after the 
        /// initial activation.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnShown(EventArgs e)
        {
            try
            {
               
                base.OnShown(e);
                _preview.Document = Document;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.GetBaseException().ToString());
            }
        }
        /// <summary>
        /// Overridden to cancel any ongoing previews when closing form.
        /// </summary>
        /// <param name="e"><see cref="FormClosingEventArgs"/> that contains the event data.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //if (emrEdit.isCountPages == true)
            //{
            //    emrEdit.emrPageCount = _preview.PageCount;
            //    emrEdit.havePrintPages = _preview.PageCount;
            //    //MessageBox.Show("emrEdit.emrPageCount:" + emrEdit.emrPageCount.ToString());
            //}
            base.OnFormClosing(e);
            if (_preview.IsRendering && !e.Cancel)
            {
                _preview.Cancel();
            }
           
        }

        #endregion

        //--------------------------------------------------------------------
        #region ** main commands

        //void _btnPrint_Click(object sender, EventArgs e)
        //{
        //    //MessageBox.Show("已打印页数：" + emrEdit.havePrintPages.ToString());
        //    using (var dlg = new PrintDialog())
        //    {
        //        // configure dialog
        //        dlg.AllowSomePages = true;
        //        dlg.AllowSelection = true;
        //        dlg.UseEXDialog = true;
        //        dlg.Document = Document;

        //        // show allowed page range
        //        var ps = dlg.PrinterSettings;

        //        /*if (emrEdit.blContinuePrint == false || emrEdit.isCountPages == true)
        //        {
        //            ps.MinimumPage = ps.FromPage = 1;
        //            ps.MaximumPage = ps.ToPage = _preview.PageCount;
        //        }
        //        if (emrEdit.blContinuePrint == true || emrEdit.isCountPages == false)
        //        {
        //            ps.MinimumPage = ps.FromPage = emrEdit.emrPageCount;
        //            ps.MaximumPage = ps.ToPage = _preview.PageCount;
        //        }
        //        */

        //       // this.printDialog1.PrinterSettings.FromPage;//打印开始的页 
        //       // this.printDialog1.PrinterSettings.PrintRange;//打印页的范围 
        //       // this.printDialog1.PrinterSettings.ToPage;//打印的尾页 

        //        ps.MinimumPage = ps.FromPage = 1;
        //        ps.MaximumPage = ps.ToPage = _preview.PageCount;
        //        ps.PrintRange = PrintRange.AllPages;//设置打印范围 默认选项（全部、选定页、当前页、指定要打印的文档部分）

        //        //dlg.AllowSomePages = true;//打印选定的页 选项可用
        //        //dlg.AllowSelection = true;//只打印选定的页面范围 选项可用
        //        dlg.AllowCurrentPage = true;//打印当前显示页 选项可用
        //       // MessageBox.Show("总页数：" + _preview.PageCount.ToString());
        //        //MessageBox.Show(emrEdit.emrPageCount.ToString());
              
        //       // if (emrEdit.havePrintPages > 0)//续打
        //        //if (emrEdit.blContinuePrint == true && emrEdit.havePrintPages > 0)//续打
        //        //{
        //        //    //MessageBox.Show("已打印页数(aaa)：" + emrEdit.havePrintPages.ToString());
        //        //    //MessageBox.Show("续打：开始页："+emrEdit.emrPageCount.ToString());
        //        //    dlg.AllowSomePages = true;//打印选定的页 选项可用
        //        //    dlg.AllowSelection = true;//只打印选定的页面范围 选项可用

        //        //    //ps.PrintRange= PrintRange.Selection;
        //        //    ps.PrintRange = PrintRange.SomePages;//设置页面范围 选择项 为 页码

        //        //    ps.MinimumPage = ps.FromPage = emrEdit.havePrintPages;

        //        //    // ps.PrintRange = PrintRange.SomePages;//设置页面范围 选择项 为 页码
        //        //     dlg.AllowCurrentPage = true;//打印当前显示页 选项可用
        //        //     //ps.PrintRange = emrEdit.emrPageCount;
   
        //        //}
               
        //       // ps.MaximumPage = ps.ToPage = _preview.PageCount;

        //        //emrEdit.isPrint = false;
        //        // show dialog
        //        if (dlg.ShowDialog(this) == DialogResult.OK)
        //        {
        //          //  emrEdit.isPrint = true;
        //            // print selected page range
        //            _preview.Print();
        //        }
        //        else
        //        {
        //           // emrEdit.isPrint = false;
        //        }

        //    }
        //}
        void _btnPageSetup_Click(object sender, EventArgs e)
        {
            //using (var dlg = new PageSetupDialog())
            //{
            //    dlg.Document = Document;
            //    if (dlg.ShowDialog(this) == DialogResult.OK)
            //    {
            //        // to show new page layout
            //        _preview.RefreshPreview();
            //    }
            //}
        }

        #endregion

        //--------------------------------------------------------------------
        #region ** zoom

        void _btnZoom_ButtonClick(object sender, EventArgs e)
        {
            _preview.ZoomMode = _preview.ZoomMode == ZoomMode.ActualSize
                ? ZoomMode.FullPage
                : ZoomMode.ActualSize;
        }
        void _btnZoom_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == _itemActualSize)
            {
                _preview.ZoomMode = ZoomMode.ActualSize;
            }
            else if (e.ClickedItem == _itemFullPage)
            {
                _preview.ZoomMode = ZoomMode.FullPage;
            }
            else if (e.ClickedItem == _itemPageWidth)
            {
                _preview.ZoomMode = ZoomMode.PageWidth;
            }
            else if (e.ClickedItem == _itemTwoPages)
            {
                _preview.ZoomMode = ZoomMode.TwoPages;
            }
            if (e.ClickedItem == _item10)
            {
                _preview.Zoom = .1;
            }
            else if (e.ClickedItem == _item100)
            {
                _preview.Zoom = 1;
            }
            else if (e.ClickedItem == _item150)
            {
                _preview.Zoom = 1.5;
            }
            else if (e.ClickedItem == _item200)
            {
                _preview.Zoom = 2;
            }
            else if (e.ClickedItem == _item25)
            {
                _preview.Zoom = .25;
            }
            else if (e.ClickedItem == _item50)
            {
                _preview.Zoom = .5;
            }
            else if (e.ClickedItem == _item500)
            {
                _preview.Zoom = 5;
            }
            else if (e.ClickedItem == _item75)
            {
                _preview.Zoom = .75;
            }
        }
        #endregion

        //--------------------------------------------------------------------
        #region ** page navigation

        void _btnFirst_Click(object sender, EventArgs e)
        {
            _preview.StartPage = 0;
        }
        void _btnPrev_Click(object sender, EventArgs e)
        {
            _preview.StartPage--;
        }
        void _btnNext_Click(object sender, EventArgs e)
        {
            _preview.StartPage++;
        }
        void _btnLast_Click(object sender, EventArgs e)
        {
            _preview.StartPage = _preview.PageCount - 1;
        }
        void _txtStartPage_Enter(object sender, EventArgs e)
        {
            _txtStartPage.SelectAll();
        }
        void _txtStartPage_Validating(object sender, CancelEventArgs e)
        {
            CommitPageNumber();
        }
        void _txtStartPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //var c = e.KeyChar;
            //if (c == (char)13)
            //{
            //    CommitPageNumber();
            //    e.Handled = true;
            //}
            //else if (c > ' ' && !char.IsDigit(c))
            //{
            //    e.Handled = true;
            //}
        }
        void CommitPageNumber()
        {
            int page;
            if (int.TryParse(_txtStartPage.Text, out page))
            {
                _preview.StartPage = page - 1;
            }
        }
        void _preview_StartPageChanged(object sender, EventArgs e)
        {
            //var page = _preview.StartPage + 1;
           // _txtStartPage.Text = page.ToString();
        }
        private void _preview_PageCountChanged(object sender, EventArgs e)
        {
            this.Update();
            Application.DoEvents();
            _lblPageCount.Text = string.Format("of {0}", _preview.PageCount);
        }

        #endregion

        //--------------------------------------------------------------------
        #region ** job control

        void _btnCancel_Click(object sender, EventArgs e)
        {
            if (_preview.IsRendering)
            {
                _preview.Cancel();
            }
            else
            {
                Close();
            }
        }
        void _doc_BeginPrint(object sender, PrintEventArgs e)
        {
            _btnCancel.Text = "取消";
            _btnPrint.Enabled = _btnPageSetup.Enabled = false;
        }
        void _doc_EndPrint(object sender, PrintEventArgs e)
        {
            _btnCancel.Text = "关闭";
            _btnPrint.Enabled = _btnPageSetup.Enabled = true;
            //if (emrEdit.isCountPages == true)
            //{
              //  this._btnPrint.Enabled = false;
               // emrEdit.havePrintPages = _preview.PageCount;
            //    ////this.Close();
           // }
           
        }

        #endregion

        private void testCoolPrintPreviewDialog_Load(object sender, EventArgs e)
        {
           
            //emrEdit.isPrint = false;
            //if (emrEdit.isCountPages == true)
           // {
            //    emrEdit.emrPageCount = 0;
           // }

          //  if (emrEdit.isCountPages == true)
            //{
           //     this.Text = "打印预览_计算历史打印记录页数（" + this.title + "）";
           // }
           // else
            //{
             //   this.Text = "打印预览（" + this.title + "）";
          //  }
           // if (this._btnPrint.Enabled == true && emrEdit.isCountPages == true)
           // {
                //this.Close();
           // }
        }

        private void testCoolPrintPreviewDialog_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void _preview_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (emrEdit.isCountPages == true && this._btnPrint.Enabled == false && this._btnCancel.Text == "关闭")
            //{
            //    //emrEdit.havePrintPages = _preview.PageCount;//计算已打印的页数
            //    this.Close();//自动关闭计算已打印页数窗体
            //}
        }
    }
}
