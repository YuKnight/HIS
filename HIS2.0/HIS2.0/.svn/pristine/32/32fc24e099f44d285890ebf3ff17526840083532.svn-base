using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;

namespace ts_mz_cfsh
{
    public partial class FrmPreview : Form
    {
        private List<FrmReportView> lst;
        private int indx=0;

        public FrmPreview()
        {
            InitializeComponent();
        }
        public FrmPreview(List<FrmReportView> param_lst)
        {
            InitializeComponent();
            lst = param_lst;
        }

        private void FrmPreview_Load(object sender, EventArgs e)
        {
            try
            {
                M_loadReport(indx);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_front_Click(object sender, EventArgs e)
        {
            try
            {
                indx--;
                M_loadReport(indx);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                indx++;
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            try
            {
                indx++;
                M_loadReport(indx);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                indx--;
            }
        }

        private void M_loadReport(int indx)
        {
            FrmReportView frv = lst[indx];
            if (lst != null && lst.Count > 0)
            {
                frv.FormBorderStyle = FormBorderStyle.None;
                frv.Dock = DockStyle.Fill;
                frv.TopLevel = false;
                panel_content.Controls.Clear();
                panel_content.Controls.Add(frv);
                frv.Show();
            }
            M_ControlBtn();
        }
        private void M_ControlBtn()
        {
            if (indx == lst.Count - 1)
                btn_next.Enabled = false;
            else
                btn_next.Enabled = true;
            if (indx == 0)
                btn_front.Enabled = false;
            else
                btn_front.Enabled = true;
        }
    }
}