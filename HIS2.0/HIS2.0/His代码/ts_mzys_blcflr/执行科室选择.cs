using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mzys_blcflr
{
    public partial class FrmSelectionExecDept : Form
    {
        private static DataTable datatableExecDept;

        private TrasenFrame.Classes.Department selectionExecDept;

        public TrasenFrame.Classes.Department SelectionExecDept
        {
            get
            {
                return selectionExecDept;
            }
        }

        public FrmSelectionExecDept()
        {
            InitializeComponent();
            this.Load += new EventHandler( FrmSelectionExecDept_Load );
            this.textBox1.TextChanged += new EventHandler( textBox1_TextChanged );
            this.textBox1.KeyPress += new KeyPressEventHandler( textBox1_KeyPress );
            this.dataGridView1.DoubleClick += new EventHandler( dataGridView1_DoubleClick );
            this.btnSelected.Click += new EventHandler( btnSelected_Click );
            this.textBox1.KeyDown += new KeyEventHandler( textBox1_KeyDown );
        }

        void textBox1_KeyDown( object sender , KeyEventArgs e )
        {
            switch ( e.KeyCode )
            {
                case Keys.Up:
                    if ( this.dataGridView1.CurrentCell != null )
                    {
                        if ( this.dataGridView1.CurrentCell.RowIndex > 0 )
                            this.dataGridView1.CurrentCell = this.dataGridView1[Column1.Name , this.dataGridView1.CurrentRow.Index - 1];
                    }
                    break;
                case Keys.Down:
                    if ( this.dataGridView1.CurrentCell != null )
                    {
                        if ( this.dataGridView1.CurrentCell.RowIndex < this.dataGridView1.Rows.Count-1 )
                            this.dataGridView1.CurrentCell = this.dataGridView1[Column1.Name , this.dataGridView1.CurrentRow.Index + 1];
                    }
                    break;
            }

            switch ( e.KeyCode )
            {
                case Keys.Up:
                case Keys.Down:
                    e.Handled = true;
                    textBox1.SelectionStart = textBox1.Text.Length ;
                    break;
            }
        }

        void btnSelected_Click( object sender , EventArgs e )
        {
            if ( this.dataGridView1.Rows.Count > 0 && this.dataGridView1.CurrentRow != null )
            {
                DataRow row = ( (DataRowView)this.dataGridView1.CurrentRow.DataBoundItem ).Row;
                selectionExecDept = new TrasenFrame.Classes.Department( Convert.ToInt32( row["dept_id"] ) , InstanceForm.BDatabase );
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        void dataGridView1_DoubleClick( object sender , EventArgs e )
        {
            if ( this.dataGridView1.Rows.Count > 0 && this.dataGridView1.CurrentRow !=null )
            {
                DataRow row = ( (DataRowView)this.dataGridView1.CurrentRow.DataBoundItem ).Row;
                selectionExecDept = new TrasenFrame.Classes.Department( Convert.ToInt32( row["dept_id"] ) , InstanceForm.BDatabase );
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        void textBox1_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( e.KeyChar == '\r' && this.dataGridView1.Rows.Count > 0 )
            {
                DataRow row = ( (DataRowView)this.dataGridView1.CurrentRow.DataBoundItem ).Row;
                selectionExecDept = new TrasenFrame.Classes.Department( Convert.ToInt32( row["dept_id"] ) , InstanceForm.BDatabase );
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        void textBox1_TextChanged( object sender , EventArgs e )
        {
            string strKeyword = textBox1.Text;
            strKeyword = strKeyword.Replace( "'" , "''" );
            strKeyword = strKeyword.Replace( "[" , "[[]" );            
            string strFilter = string.Format( "name like '%{0}%' or py_code like '{0}%' or wb_code like '{0}%'" , strKeyword );

            ( (DataView)this.dataGridView1.DataSource ).RowFilter = strFilter;
        }

        void FrmSelectionExecDept_Load( object sender , EventArgs e )
        {
            //获取所有科室
            if ( datatableExecDept == null )
                datatableExecDept = InstanceForm.BDatabase.GetDataTable( "select dept_id, name,py_code,wb_code from jc_dept_property where deleted=0 and layer=3 and (mz_flag = 1 or yj_flag=1 or zy_flag = 1)" );
            datatableExecDept.DefaultView.RowFilter = "";
            this.dataGridView1.DataSource = datatableExecDept.DefaultView;
        }        
    }
}