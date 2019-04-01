using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;

namespace ts_yp_kjbb
{
    public partial class FrmReportDesigner : Form
    {

        private ReportInfo reportInfo;
        private grproLib.GridppReportClass Report = new grproLib.GridppReportClass();

        public FrmReportDesigner(ReportInfo _ReportInfo)
        {
            InitializeComponent();
            reportInfo = _ReportInfo;
            this.Load += new EventHandler(FrmReportDesigner_Load);
            this.axGRDesigner1.SaveReport += new EventHandler(axGRDesigner1_SaveReport);
            this.Text = "报表模板设计器";
        }

        void axGRDesigner1_SaveReport( object sender , EventArgs e )
        {
            axGRDesigner1.Post();
            Report.SaveToFile( reportInfo.TemplateFile );
            this.axGRDesigner1.DefaultAction = false;
        }

        void FrmReportDesigner_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(reportInfo.TemplateFile))
            {
                Report.LoadFromFile(reportInfo.TemplateFile);
                this.axGRDesigner1.Report = Report;
                this.axGRDesigner1.Reload();
            }
        }

        
    }
}