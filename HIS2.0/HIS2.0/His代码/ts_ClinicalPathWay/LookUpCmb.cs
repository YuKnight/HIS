using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;

namespace ts_ClinicalPathWay
{
    public class LookUpCmb:LookUpEdit
    {

        private  DataTable dataSource = null;

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            //base.ButtonPressed +=new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(LookUpCmb_ButtonPressed);
        }
        /// <summary>
        /// 设置或获取文本框为下划线样式
        /// </summary>
        public DataTable DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;
            }
        }

        protected override void InitializeDefaultProperties()
        {
            base.InitializeDefaultProperties();
            base.Properties.NullText = "---请选择---";
            
        }

        public override void ShowPopup()
        {
            base.Properties.DisplayMember = "pymName";
            base.ShowPopup();
            //base.ClosePopup();
        }
        protected override void OnEditorKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            //object tt = base.PopupForm.Filter;
            
            base.OnEditorKeyDown(e);
            
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (base.Text != "")
                {
                    base.ParseEditorValue();
                }
            }
        }
        protected override void OnPopupClosed(PopupCloseMode closeMode)
        {
            base.Properties.DisplayMember = "name";
            base.OnPopupClosed(closeMode);

            this.Properties.DataSource = this.dataSource.Copy();

        }

        //protected override PopupBaseForm CreatePopupForm()
        //{
        //    DevExpress.XtraEditors.Popup.PopupLookUpEditForm  form1 = new DevExpress.XtraEditors.Popup.PopupLookUpEditForm(this);
        //    form1.ShowQueryButtonEx = form1.Properties.ShowQueryButtonEx;
        //    form1.ShowCloseButtonEx = form1.Properties.ShowCloseButtonEx;
        //    form1.ShowOkButtonEx = form1.Properties.ShowOkButtonEx;
        //    this.Properties.BestAllFit();
        //    return form1;
        //}
        
        protected override void ProcessText(DevExpress.XtraEditors.Controls.KeyPressHelper helper, bool canImmediatePopup)
        {
            //
            base.ProcessText(helper, canImmediatePopup);
            tt(helper.Text);

            //string sInputText = helper.Text;
            //DevExpress.XtraEditors.ListControls.LookUpListDataAdapter tt = base.PopupForm.Filter as DevExpress.XtraEditors.ListControls.LookUpListDataAdapter;
            
            //if (sInputText == "")
            //{

            //    tt.FilterExpression = "";
            //    PopupBaseForm f1 = base.PopupForm as PopupBaseForm;
                
            //    this.PopupForm.FilterCollectionChanged(this.Properties.DataAdapter, EventArgs.Empty);
            //}
            //base.ProcessText(helper, canImmediatePopup);
            //this.PopupForm.Filter.FilterPrefix = "";
            //if (this.Properties.DataAdapter.VisibleCount > 0)
            //{
            //    this.PopupForm.SelectedIndex = 0;
            //}



        }
        
        private void tt(string strTxt)
        {
            //this.Properties.
            
            DevExpress.XtraEditors.ListControls.LookUpListDataAdapter tt = base.PopupForm.Filter as DevExpress.XtraEditors.ListControls.LookUpListDataAdapter;
            //DevExpress.XtraEditors.ListBoxControl.il
            //tt.FilterField = "code";
            //base.PopupForm.Filter = tt;
            //base.PopupForm = new DevExpress.XtraEditors.Popup.PopupLookUpEditForm(this);
            //tt.FilterField = "";
            //tt.FilterPrefix = "%" + base.AutoSearchText;
            
            //tt.FilterExpression = "pymName like '%" + base.AutoSearchText + "%'";
            PopupLookUpEditForm t = base.PopupForm;
            //tt.Item.DataSource = null;
           // t.Filter = "";
            string t1 = "";
            //tt.FilterField = "";
            //if(dataSource ==null) return ;
            //if (base.Properties.DisplayMember.Trim() =="") return ;
            //string filder = "pym";// base.Properties.DisplayMember;
            //string strFilter=filder + " like '%" +strTxt + "%' ";
            //DataView dv = new DataView(dataSource.Copy(), strFilter, "", DataViewRowState.CurrentRows);
            //base.Properties.DataSource = dv;
           
            
        }

        
        
    }
}
