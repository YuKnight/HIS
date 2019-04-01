using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;


namespace ts_mz_tjbb
{
    public partial class Frm_MZ_RecipelofDrugsQuery : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frm_MZ_RecipelofDrugsQuery(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            try
            {

                ParameterEx[] parameters = new ParameterEx[3];



                parameters[0].Text = "@rq1";
                parameters[0].Value = dtpBjksj.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtpEjksj.Value.ToString();

                parameters[2].Text = "@Type";
                parameters[2].Value = this.comboBox1.SelectedIndex;

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("sp_MZ_RecipelofDrugsQuery", parameters, dset, "sfmx", 60);


                Fun.AddRowtNo(dset.Tables[0]);
                this.dataGridView1.DataSource = dset.Tables[0];
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (this.dataGridView1.Columns[i].Name.ToLower() == "ksdm")
                    {
                        this.dataGridView1.Columns[i].Visible = false;
                    }
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "´íÎó", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_MZ_RecipelofDrugsQuery_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            this.WindowState = FormWindowState.Maximized;
            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

        }

        private void Frm_MZ_RecipelofDrugsQuery_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Height = this.Height - this.dataGridView1.Top - 20;
            this.dataGridView1.Width = this.Width - 40;
        }
    }
}