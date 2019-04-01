using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mz_gh
{
    public partial class FrmNoteBookSelect : Form
    {
        public string SelectedBLB
        {
            get
            {
                string blb = "";
                for ( int i = 0 ; i < dgvNote.Rows.Count ; i++ )
                {
                    int sel = Convert.IsDBNull( dgvNote[COL_SELECTED.Name , i].Value ) ? 0 : Convert.ToInt32( dgvNote[COL_SELECTED.Name , i].Value );
                    if ( sel == 1 )
                    {
                        int itemid = Convert.IsDBNull( dgvNote[COL_ITEM_ID.Name , i].Value ) ? 0 : Convert.ToInt32( dgvNote[COL_ITEM_ID.Name , i].Value );
                        blb = blb + itemid.ToString() + ",";
                    }
                }
                if ( !String.IsNullOrEmpty( blb ) )
                    blb = blb.Remove( blb.Length - 1 , 1 );

                return blb;
            }
        }

        public FrmNoteBookSelect( string blb )
        {
            InitializeComponent();
            try
            {
                string sql = @"select 0 as selected,item_id,item_name,retail_price from jc_hsitemdiction where jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm
                    + " and item_id in (" + blb + ")";
                DataTable dtBlb = InstanceForm.BDatabase.GetDataTable( sql );

                dgvNote.DataSource = dtBlb.DefaultView;
            }
            catch ( Exception err )
            {
                MessageBox.Show( "根据参数获取病历本种类列表发生错误！\r\n" + err.Message  ,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
            this.dgvNote.KeyPress += new KeyPressEventHandler( dgvNote_KeyPress );
            
            this.dgvNote.RowPostPaint += new DataGridViewRowPostPaintEventHandler( dgvNote_RowPostPaint );

            
        }

        

        void dgvNote_RowPostPaint( object sender , DataGridViewRowPostPaintEventArgs e )
        {
            if ( dgvNote.RowHeadersVisible )
            {
                Rectangle rectangle = new Rectangle( e.RowBounds.Location.X , e.RowBounds.Location.Y , dgvNote.RowHeadersWidth - 4 , e.RowBounds.Height );
                TextRenderer.DrawText( (IDeviceContext)e.Graphics , ( e.RowIndex + 1 ).ToString() , new Font("宋体",11F, FontStyle.Bold) , rectangle , dgvNote.RowHeadersDefaultCellStyle.ForeColor , (TextFormatFlags)5 );
            }
        }

       

        void dgvNote_KeyPress( object sender , KeyPressEventArgs e )
        {
            int key = (int)e.KeyChar;
            if ( key == 13 )
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if ( key == 27 )
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else if ( key >= 48 && key <= 57 )
            {
                int num = Convert.ToInt32( e.KeyChar.ToString() );
                int rowIndex = num - 1;
                if ( rowIndex == -1 || rowIndex > dgvNote.Rows.Count -1 )
                    return;
                else
                {
                    DataView dv = (DataView)dgvNote.DataSource;
                    short status = Convert.IsDBNull( dv[rowIndex]["selected"] ) ? (short)0 : Convert.ToInt16( dv[rowIndex]["selected"] );
                    if ( status == 0 )
                    {
                        dv[rowIndex]["selected"] = (short)1;
                    }
                    else
                    {
                        dv[rowIndex]["selected"] = (short)0;
                    }
                    dv.Table.AcceptChanges();

                    
                }
            }
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}