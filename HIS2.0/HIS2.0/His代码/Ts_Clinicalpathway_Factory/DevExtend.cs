using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Popup;
using System.Collections;
 
using System.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace Ts_Clinicalpathway_Factory
{
    [UserRepositoryItem("RegisterCustomButtonEdit")]
    public class MyCustomButtonEdit : RepositoryItemButtonEdit
    {

        private ChooseType chooseFormType;
        private SimpleButton sbSwitching;

        public ChooseType ChooseFormType
        {
            get { return chooseFormType; }
            set { chooseFormType = value; }
        }
        public enum ChooseType
        {
            /// <summary>
            /// 表示為產品選項
            /// </summary>
            ProductItems = 0,
            /// <summary>
            /// 表示為客戶選項
            /// </summary>
            CustomerItems = 1,
            /// <summary>
            /// 表示為員工選項
            /// </summary>
            EmployeeItems = 2,
            /// <summary>
            /// 表示為值日選項
            /// </summary>
            DutyItem = 3
        }
        private GridView mygridview;

        public GridView Mygridview
        {
            get { return mygridview; }
            set { mygridview = value; }
        }


        static MyCustomButtonEdit() { RegisterCustomButtonEdit(); }
        public MyCustomButtonEdit()
        {

            this.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(MyCustomButtonEdit_ButtonClick);
        }

        void MyCustomButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            switch (chooseFormType)
            {
                //是产品类型
                case ChooseType.ProductItems:
                    //ChooseINV_ITMForm f = new ChooseINV_ITMForm();
                    //if (f.ShowDialog() == DialogResult.OK)
                    //{

                    //    DataRowView rowview = f.SelectedItem as DataRowView;
                    //    if (rowview == null) return;
                    //    this.mygridview.SetFocusedValue(rowview.Row[this.mygridview.FocusedColumn.FieldName].ToString());
                    //}
                    break;
                default:
                    break;
            }
        }
        public const string CustomButtomName = "CustomButtonEdit";
        public override string EditorTypeName { get { return CustomButtomName; } }

        public static void RegisterCustomButtonEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomButtomName, typeof(CustomButtonEdit), typeof(MyCustomButtonEdit), typeof(ButtonEditViewInfo), new ButtonEditPainter(), true, null, typeof(DevExpress.Accessibility.PopupEditAccessible)));
        }

        private void InitializeComponent()
        {
            this.sbSwitching = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sbSwitching
            // 
            this.sbSwitching.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbSwitching.Location = new System.Drawing.Point(544, 20);
            this.sbSwitching.Name = "sbSwitching";
            this.sbSwitching.Size = new System.Drawing.Size(128, 24);
            this.sbSwitching.TabIndex = 7;
            this.sbSwitching.Text = "simpleButton1";
            // 
            // MyCustomButtonEdit
            // 
            this.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }

    public class CustomButtonEdit : ButtonEdit
    {
        static CustomButtonEdit() { MyCustomButtonEdit.RegisterCustomButtonEdit(); }
        public CustomButtonEdit()
        {

        }

        public override string EditorTypeName { get { return MyCustomButtonEdit.CustomButtomName; } }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new MyCustomButtonEdit Properties
        {
            get { return base.Properties as MyCustomButtonEdit; }
        }
    }

    public class StyleButtonViewInfo : ButtonEditViewInfo
    {
        public StyleButtonViewInfo(RepositoryItem item)
            : base(item)
        {


        }
        protected override void Assign(BaseControlViewInfo info)
        {
            base.Assign(info);
        }
    }
}
