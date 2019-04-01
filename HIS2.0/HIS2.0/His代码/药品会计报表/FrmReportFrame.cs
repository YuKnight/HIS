using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using ts_yp_kjbb.Condiction;
using grproLib;

namespace ts_yp_kjbb
{   
    public partial class FrmReportFrame : Form
    {
        private RelationalDatabase database;

        private FrmReportDesigner frmDesigner;

        

        public FrmReportFrame( RelationalDatabase Database )
        {
            InitializeComponent();

            database = Database;
            this.Text = "会计报表";
            lvwReportName.DoubleClick += new EventHandler( lvwReportName_DoubleClick );

            if ( !InstanceForm.BCurrentUser.IsAdministrator )
                btnTemplateSet.Visible = false;
        }

        private void lvwReportName_DoubleClick( object sender , EventArgs e )
        {
            ReportInfo ri = (ReportInfo)lvwReportName.SelectedItems[0].Tag;

            foreach ( Crownwood.Magic.Controls.TabPage t in this.tabControl1.TabPages )
            {
                if ( t.Title == ri.ReportName )
                {
                    this.tabControl1.SelectedTab = t;
                    return;
                }
            }

            UCReport ucReport = new UCReport();
            ucReport.InitializeControl( ri );
           
            Crownwood.Magic.Controls.TabPage page = new Crownwood.Magic.Controls.TabPage();
            page.Title = ri.ReportName;
            page.Controls.Add( ucReport );
            page.Tag = ri;
            this.tabControl1.TabPages.Add( page );
            ucReport.Dock = DockStyle.Fill;
            ucReport.CloseReport += delegate( ReportInfo r )
            {
                this.tabControl1.TabPages.Remove( this.tabControl1.SelectedTab );
            };
            this.tabControl1.SelectedTab = page;
        }

        private void FrmReportFrame_Load( object sender , EventArgs e )
        {                      
            foreach ( ReportInfo ri in Reports.ReportList )
            {
                ListViewItem item = new ListViewItem();
                item.Text = ri.ReportName;
                item.ImageIndex = 0;
                item.Tag = ri;

                lvwReportName.Items.Add( item );
            }
        }

        private void btnTemplateSet_Click( object sender , EventArgs e )
        {
            if ( this.tabControl1.SelectedTab == null )
                return;
            ReportInfo ri = (ReportInfo)this.tabControl1.SelectedTab.Tag;
            frmDesigner = new FrmReportDesigner( ri );
            frmDesigner.ShowDialog();
        }
       
        
    }
}