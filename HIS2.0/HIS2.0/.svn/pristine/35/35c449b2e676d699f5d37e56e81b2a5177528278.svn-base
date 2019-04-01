using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Reflection;
using System.IO;
namespace ts_zyhs_yzdy
{
        public delegate void Exdy();
        public partial class PrintPreviewDialogEx : PrintPreviewDialog
        {
            public event Exdy OnPrintDy;
            public PrintPreviewDialogEx()
            {
                foreach (Control ctrl in base.Controls)
                {
                     
                    if (ctrl.GetType() == typeof(ToolStrip))
                    {

                        ToolStrip tools = ctrl as ToolStrip;
                        ToolStripButton tsb = CreatePrintsetButton();
                        tools.Items.Insert(0, tsb);
                        for (int i = 0; i < tools.Items.Count; i++)
                        {
                            if (tools.Items[i].Text == "打印")
                            {
                                tools.Items[i].Visible = false;
                                
                            }
                        }
                       
                    }
                }
            }

            ToolStripButton CreatePrintsetButton()
            {
                ToolStripButton Stripbutton = new ToolStripButton();
                Stripbutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
                //Stream st= Assembly.LoadFrom(Application.StartupPath + @"\ts_zyhs_yzdy.dll").GetManifestResourceStream("ts_zyhs_yzdy.Resources.227.ico");
                Image im =ts_zyhs_yzdy.Properties.Resources._227.ToBitmap();
                Stripbutton.Image = im;
                Stripbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
                Stripbutton.Name = "printsetStripButton";
                Stripbutton.Size = new System.Drawing.Size(23, 22);
                Stripbutton.Text = "打印医嘱";
                Stripbutton.Click += new System.EventHandler(this.Stripbutton_Click);
                return Stripbutton;
            }

            private void Stripbutton_Click(object sender, EventArgs e)
            {
                if (OnPrintDy != null)
                    OnPrintDy();
                PrintDocument pd = this.Document;
                pd.Print();
                this.Close();
                //using (PrintDialog diag = new PrintDialog())
                //{
                //    diag.Document = base.Document;
                //    diag.ShowDialog();
                //}
            }
        }
}
