using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trasen.Base;
using DevExpress.XtraEditors;

 

namespace ts_ClinicalPathWay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("code", typeof(System.String));
            DataColumn c2 = new DataColumn("name", typeof(System.String));
            DataColumn c3 = new DataColumn("pym", typeof(System.String));
            DataColumn c4 = new DataColumn("pymName", typeof(System.String));
            dt.Columns.Add(c1); dt.Columns.Add(c2); dt.Columns.Add(c3); ; dt.Columns.Add(c4);
            DataRow dr = dt.NewRow();
            dr = dt.NewRow(); dr.ItemArray = new object[] { "1", "张山", "zs", "zs张山" }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "2", "张三", "zs", "zs张三" }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "3", "李四", "ls", "ls李四" }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "4", "李胜", "ls", "ls李胜" }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "6", "李爽", "ls", "ls李爽" }; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr.ItemArray = new object[] { "7", "王五", "ww", "ww王五" }; dt.Rows.Add(dr);
            //lookUpCmb1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            //lookUpCmb1.Properties.DisplayMember = "name";
            //lookUpCmb1.Properties.ValueMember = "code";
            //lookUpCmb1.Properties.DataSource = dt;
            //lookUpCmb1.DataSource = dt.Copy();
            //    DevExpress.XtraEditors.Controls.LookUpColumnInfo
           DevExpress.XtraEditors.Controls.LookUpColumnInfo col1=new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name",30,"名称");
     
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col2=new DevExpress.XtraEditors.Controls.LookUpColumnInfo("code",30,"代码");
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col3 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("pym",30, "拼音码");
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col4 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("pymName", 30, "");
            //lookUpCmb1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { col1, col2, col3, col4});



            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.dateTimePicker1.Value = DBNull.Value;
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat= "____年__月__日";
            this.dateTimePicker1.Text = "";
            //return;
            //this.dateUser1.Format = DateTimePickerFormat.Custom;
            //this.dateTimePicker1.CustomFormat= "____年__月__日";
            //DataTable dt = new DataTable("p1");
            //DataColumn col1 = new DataColumn("id", typeof(System.Guid));
            //DataColumn col2 = new DataColumn("xh", typeof(System.Int32));
            //dt.Columns.Add(col1); dt.Columns.Add(col2);

            //DataRow dr = dt.NewRow();
            //object t1=System.Guid.NewGuid() ;
            //dr["id"] = t1; dr["xh"] = 1;
            //dt.Rows.Add(dr);
            //DataView dv1 = new DataView(dt, "id <>'{9b84eb49-1383-4e75-926a-df232f83c758}' and id <>'{0ace2149-bbc8-448c-80ec-c110ff50b89a}'", "", DataViewRowState.CurrentRows);
            //string t = "";
            string t = pathWay1.SaveItemToXml();


            string st = @"object=Item_07ae78da-aec0-46cd-b9d1-055b22f5490e;
type=Item;
x1=551;
y1=79;
lnk1=;
x2=604;
y2=117;
lnk2=;
Text=新阶段2;
Loop=False;
IsFisrt=False;
end object.

object=Item_716b8e76-98fe-45bc-a863-f137548cbf43;
type=Item;
x1=263;
y1=62;
lnk1=;
x2=316;
y2=100;
lnk2=;
Text=新阶段1;
Loop=False;
IsFisrt=True;
end object.

end network file.
";
            this.pathWay1.LoadItem(st);
           
            
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            //dateTimePicker1.
        }

        private void button2_Click(object sender, EventArgs e)
        {

           //serialPort1.CtsHolding
            //Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();
            //gridView1.Columns.Clear();
            //Trasen.Base.CtlFun.GridViewColumnInfo(gridView1, new string[] { "tt" }, new int[] { 30 }, new string[] { "测试" });
            //DevExpress.XtraGrid.Columns.GridColumn gridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            //this.gridView1.Columns.Add(gridColumn);
            //gridColumn.Caption = "代码";
            //gridColumn.FieldName = "code";
            //gridColumn.Visible = true;
            //gridColumn.Width = 100;
            //gridColumn.VisibleIndex = 1;
            


            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //SqlConnection cn = new SqlConnection(@"packet size=4096;user id=sa;password=1234;data source=.\leim;persist security info=True;initial catalog=zyfy_ba");
            //SqlCommand cmd = new SqlCommand("select rtrim(icdcode) as code, rtrim(icd_name) as name, rtrim(icd_py) as pyCode, rtrim(icd_five) as wbCode from dict_icd", cn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);

            //DataTable dt = new DataTable();
            //da.Fill(dt);



            //this.defaultView.Columns.Clear();
            //GridColumn gridColumn = new GridColumn();
            //gridColumn.Caption = "代码";
            //gridColumn.FieldName = "code";
            //gridColumn.Visible = true;
            //this.defaultView.Columns.Add(gridColumn);

            //gridColumn = new GridColumn();
            //gridColumn.Caption = "名称";
            //gridColumn.FieldName = "name";
            //this.defaultView.Columns.Add(gridColumn);

            //gridColumn = new GridColumn();
            //gridColumn.Caption = "拼音码";
            //gridColumn.FieldName = "pyCode";
            //this.defaultView.Columns.Add(gridColumn);

            //gridColumn = new GridColumn();
            //gridColumn.Caption = "五笔码";
            //gridColumn.FieldName = "wbCode";
            //this.defaultView.Columns.Add(gridColumn);

            //this.gridControl1.DataSource = dt;

            //this.txtCode.DataBindings.Add("Text", dt, "code", true);

        }

        private void popupContainerEdit1_Enter(object sender, EventArgs e)
        {
            //if (popupContainerEdit1.Properties.PopupControl.Visible==false )
            //{
            //    popupContainerEdit1.ShowPopup();
            //}
        }

        private void popupContainerEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }

        private void popupContainerEdit1_Click(object sender, EventArgs e)
        {
            //popupContainerEdit1.ShowPopup();
        }

        private void textEdit1_Enter(object sender, EventArgs e)
        {
            //popupContainerEdit1.ShowPopup();
        }
        //protected override void DefWndProc(ref Message m)
        //{
        //    if (m.Msg == 0x0201)
        //    {
        //        MessageBox.Show(m.Msg.ToString());
        //    }
        //    else
        //    {
        //        base.DefWndProc(ref m);
        //    }
        //}

    }
}