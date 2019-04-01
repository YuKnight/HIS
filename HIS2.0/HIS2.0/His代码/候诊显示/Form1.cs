using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mz_hzxs
{
    public partial class Frmmain : Form
    {
        public Frmmain()
        {
            InitializeComponent();
            Add_InitializeComponect("");
        }


        public void Add_InitializeComponect(string zpid)
        {
            try
            {
                tableLayoutPanel1.ColumnStyles.Clear();
                tableLayoutPanel1.RowStyles.Clear();
                xsClass cs = new xsClass("", InstanceForm.BDatabase);
                int rowcount = 0;
                double iii =Convert.ToDouble(cs.tbGroup.Rows.Count) / Convert.ToDouble( cs.PanelColCount);
                if (iii > Math.Round(Convert.ToDouble(cs.tbGroup.Rows.Count) / Convert.ToDouble(cs.PanelColCount), 0))
                    rowcount = Convert.ToInt32(Math.Round(Convert.ToDouble(cs.tbGroup.Rows.Count) / Convert.ToDouble(cs.PanelColCount), 0)) + 1;
                else
                    rowcount =Convert.ToInt32( iii);


                this.tableLayoutPanel1.ColumnCount = cs.PanelColCount;
                double colwidth = Convert.ToDouble(Convert.ToDouble(100.00) / Convert.ToDouble(cs.PanelColCount));
                for (int i = 0; i <= cs.PanelColCount-1; i++)
                {
                    this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, (float)colwidth));
                }
                this.tableLayoutPanel1.Location = new System.Drawing.Point(66, 49);
                this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                this.tableLayoutPanel1.RowCount = rowcount;
                double rowheight = Convert.ToDouble(Convert.ToDouble(100.00) / Convert.ToDouble(rowcount));
                for (int i = 0; i <= rowcount-1; i++)
                {
                    this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, (float)rowheight));
                }
                this.tableLayoutPanel1.Size = new System.Drawing.Size(415, 115);
                this.tableLayoutPanel1.TabIndex = 0;

                int nrow = 0;
                int ncol = 0;
                for (int i = 0; i <= cs.tbGroup.Rows.Count - 1; i++)
                {
                    if (nrow > cs.PanelColCount - 1)
                    {
                        nrow = nrow + 1;
                        ncol = 0;
                    }
                   
                    System.Windows.Forms.Panel _newpanel = newpanel(cs.tbGroup.Rows[i], cs.GetColumnName);
                    tableLayoutPanel1.Controls.Add(_newpanel, ncol, nrow);
                    ncol = ncol + 1;
                    tableLayoutPanel1.ColumnStyles[0].
                }
                


            }
            catch (System.Exception err)
            {

            }
            
        }

        public System.Windows.Forms.Panel newpanel(DataRow row, string[] groupname)
        {

            // 
            // dataGridView1
            // 
            System.Windows.Forms.DataGridView dataGridView1=new DataGridView();
            System.Windows.Forms.DataGridViewTextBoxColumn Column1 = new DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Column2 = new DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Column3 = new DataGridViewTextBoxColumn();
            // 
            // Column1
            // 
            Column1.FillWeight = 60F;
            Column1.HeaderText = "科室";
            
            // 
            // Column2
            // 
            Column2.HeaderText = "级别";
            // 
            // Column3
            // 
            Column3.FillWeight = 120F;
            Column3.HeaderText = "备注";


            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
             Column1,
             Column2,
             Column3});
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 23;
            dataGridView1.Size = new System.Drawing.Size(515, 70);
            dataGridView1.TabIndex = 0;
            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;


            System.Windows.Forms.Panel panelX = new Panel();
            panelX.Dock = System.Windows.Forms.DockStyle.Fill;
            panelX.Location = new System.Drawing.Point(3, 3);
            panelX.Name = "panel4";
            panelX.Size = new System.Drawing.Size(522, 99);
            panelX.TabIndex = 0;

            System.Windows.Forms.Label labtop = new System.Windows.Forms.Label();
            System.Windows.Forms.Panel panelTop=new Panel();
            System.Windows.Forms.Panel panel_fill=new Panel();

            // 
            // labtop
            // 
            labtop.BackColor = System.Drawing.SystemColors.Control;
            labtop.Dock = System.Windows.Forms.DockStyle.Fill;
            labtop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            labtop.Location = new System.Drawing.Point(0, 0);
            labtop.Name = "labtop";
            labtop.TabIndex = 0;
            labtop.Text = "内科-正主任医生";

            // 
            // panelTop
            // 
            panelTop.Controls.Add(labtop);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(515, 25);
            panelTop.TabIndex = 0;
            // 
            // panel_fill
            // 
            panel_fill.Controls.Add(dataGridView1);
            panel_fill.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_fill.Location = new System.Drawing.Point(0, 25);
            panel_fill.Name = "panel_fill";
            panel_fill.Size = new System.Drawing.Size(515, 70);
            panel_fill.TabIndex = 1;

            panelX.Controls.Add(panel_fill);
            panelX.Controls.Add(panelTop);
            

            return panelX;
        }



    }
}