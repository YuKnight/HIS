using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
namespace TrasenFrame.Forms
{
    /// <summary>
    /// 选择卡
    /// </summary>
    public partial class FrmSelectCard : Form
    {
        private string[] searchFields;
        /// <summary>
        /// 需要检索得数据表
        /// </summary>
        public DataTable sourceDataTable;
        /// <summary>
        /// 
        /// </summary>
        public Form WorkForm;
        /// <summary>
        /// 
        /// </summary>
        public Control srcControl;
        /// <summary>
        /// 
        /// </summary>
        public DataRow SelectDataRow;
        /// <summary>
        /// 
        /// </summary>
        public string ReciveString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SelectSqlstring"></param>
        /// <param name="SeachFields"></param>
        /// <param name="HeaderText"></param>
        /// <param name="MappName"></param>
        public FrmSelectCard(string[] SeachFields, string[] HeaderText,string[] MappName)
        {
            InitializeComponent( );
            CreateGridStyle( HeaderText , MappName );
            
            searchFields = SeachFields;
            

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SelectSqlstring"></param>
        /// <param name="SeachFields"></param>
        /// <param name="HeaderText"></param>
        /// <param name="MappName"></param>
        /// <param name="ColWidth"></param>
        public FrmSelectCard( string[] SeachFields , string[] HeaderText , string[] MappName , int[] ColWidth )
        {
            InitializeComponent( );
            CreateGridStyle( HeaderText , MappName ,ColWidth );
            
            searchFields = SeachFields;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SelectSqlstring"></param>
        /// <param name="SeachFields"></param>
        /// <param name="HeaderText"></param>
        /// <param name="MappName"></param>
        /// <param name="ColWidth"></param>
        /// <param name="ColumnFixed"></param>
        public FrmSelectCard(  string[] SeachFields , string[] HeaderText , string[] MappName , int[] ColWidth , bool[] ColumnFixed )
        {
            InitializeComponent( );
            CreateGridStyle( HeaderText , MappName , ColWidth , ColumnFixed );
            
            searchFields = SeachFields;
           
        }
        
        #region 创建网格式样
        /// <summary>
        /// 创建网格式样
        /// </summary>
        /// <param name="HeaderText"></param>
        /// <param name="MappName"></param>
        private void CreateGridStyle(string[] HeaderText,string[] MappName)
        {
            for ( int i = 0 ; i < HeaderText.Length ; i++ )
            {
                DataGridViewTextBoxColumn dgvtxtCol = new DataGridViewTextBoxColumn();
                dgvtxtCol.HeaderText = HeaderText[i];
                dgvtxtCol.DataPropertyName = MappName[i];
                dtgrdList.Columns.Add( dgvtxtCol );
            }
        }
        /// <summary>
        /// 创建网格式样
        /// </summary>
        /// <param name="HeaderText"></param>
        /// <param name="MappName"></param>
        /// <param name="ColWdith"></param>
        private void CreateGridStyle( string[] HeaderText , string[] MappName , int[] ColWdith )
        {
            for ( int i = 0 ; i < HeaderText.Length ; i++ )
            {
                DataGridViewTextBoxColumn dgvtxtCol = new DataGridViewTextBoxColumn( );
                dgvtxtCol.HeaderText = HeaderText[i];
                dgvtxtCol.DataPropertyName = MappName[i];
                dgvtxtCol.Width = ColWdith[i];
                dgvtxtCol.Visible = ColWdith[i] == 0 ? false : true;
                dtgrdList.Columns.Add( dgvtxtCol );
            }
        }
        /// <summary>
        /// 创建网格式样
        /// </summary>
        /// <param name="HeaderText"></param>
        /// <param name="MappName"></param>
        /// <param name="ColWdith"></param>
        /// <param name="ColumnFixed"></param>
        private void CreateGridStyle( string[] HeaderText , string[] MappName , int[] ColWdith ,bool[] ColumnFixed)
        {
            for ( int i = 0 ; i < HeaderText.Length ; i++ )
            {
                DataGridViewTextBoxColumn dgvtxtCol = new DataGridViewTextBoxColumn( );
                dgvtxtCol.HeaderText = HeaderText[i];
                dgvtxtCol.DataPropertyName = MappName[i];
                dgvtxtCol.Width = ColWdith[i];
                dgvtxtCol.Visible = ColWdith[i] == 0 ? false : true;
                dgvtxtCol.Frozen = ColumnFixed[i];
                dtgrdList.Columns.Add( dgvtxtCol );
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workForm"></param>
        /// <param name="scrCtl"></param>
        /// <returns></returns>
        private Point GetScreenPoint( Form workForm , Control scrCtl )
        {
            Point ptCtl = scrCtl.Location;
            Control cCtrl = scrCtl;

            Type pType = cCtrl.Parent.GetType( );
            if ( pType == typeof( Form ) || pType.IsSubclassOf( typeof( Form ) ) )
            {
                Point pt1 = PointToScreen( ptCtl );
                return pt1;
            }
            else
            {
                Control curCtl = cCtrl;
                Point pt1 = workForm.PointToScreen( ptCtl );
                while ( 1 != 2 )
                {
                    Control parCtl = curCtl.Parent;
                    pType = parCtl.GetType( );
                    if ( pType == typeof( Form ) || pType.IsSubclassOf( typeof( Form ) ) )
                    {
                        return pt1;
                    }
                    else
                    {
                        pt1.X += parCtl.Location.X;
                        pt1.Y += parCtl.Location.Y;
                        curCtl = parCtl;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void SetFormPlace()
        {
            this.Location = GetScreenPoint( this.WorkForm , this.srcControl );
        }

        private void FrmSelectCard_Load( object sender , EventArgs e )
        {
            if ( this.WorkForm == null || this.srcControl == null )
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                SetFormPlace( );
            }
            this.dtgrdList.DataSource = sourceDataTable.DefaultView;
            this.txtSearchKey.Text = ReciveString;
            this.txtSearchKey.SelectionStart = this.txtSearchKey.Text.Length;
        }

        private void FrmSelectCard_KeyUp( object sender , KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Escape )
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close( );
            }
            
        }

        private void txtSearchKey_TextChanged( object sender , EventArgs e )
        {
            try
            {
                string sKey = txtSearchKey.Text;

                sKey = sKey.Replace( "'" , "''" );
                sKey = sKey.Replace( "[" , "[[]" );
                sKey = sKey.Replace( "]" , "[]]" );
                sKey = sKey.Replace( "%" , "[%]" );

                string filter = "";
                for ( int i = 0 ; i < searchFields.Length -1 ; i++ )
                {
                    filter += searchFields[i] + " like '" + sKey + "%' or ";
                }
                filter += searchFields[searchFields.Length-1] + " like '" + sKey + "%'";

                DataView dv = (DataView)this.dtgrdList.DataSource;
                dv.RowFilter = filter;
            }
            catch ( Exception err )
            {
                MessageBox.Show( "查询发生错误！\n详细信息:" + err.Message , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void txtSearchKey_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                DataView dv = (DataView)this.dtgrdList.DataSource;
                if ( dv.Count > 0 )
                {
                    DataRow dr = dv[dtgrdList.CurrentRow.Index].Row;
                    SelectDataRow = sourceDataTable.NewRow();
                    SelectDataRow.ItemArray = dr.ItemArray;
                    this.Close( );
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void txtSearchKey_KeyUp( object sender , KeyEventArgs e )
        {
            try
            {
                if (dtgrdList.CurrentCell == null)
                {
                    return;
                }
                if (e.KeyCode == Keys.Up)
                {
                    if (this.dtgrdList.CurrentCell.RowIndex == 0)
                        return;
                    else
                        this.dtgrdList.CurrentCell = dtgrdList[1, this.dtgrdList.CurrentCell.RowIndex - 1];
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (this.dtgrdList.CurrentCell.RowIndex == this.dtgrdList.Rows.Count - 1)
                        return;
                    else
                        this.dtgrdList.CurrentCell = dtgrdList[1, this.dtgrdList.CurrentCell.RowIndex + 1];
                }
            }
            catch(Exception err)
            {
                throw err;
            }
        }

        private void dtgrdList_DoubleClick( object sender , EventArgs e )
        {
            if ( this.dtgrdList.CurrentRow != null )
            {
                txtSearchKey_KeyPress( null , new KeyPressEventArgs( (char)13 ) );
            }
        }

        private void dtgrdList_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( ( e.KeyChar >= 'a' && e.KeyChar <= 'z' ) || ( e.KeyChar >= 'A' && e.KeyChar <= 'Z' ) )
            {
               txtSearchKey.Text += ( (char)e.KeyChar ).ToString( );
            }
            txtSearchKey.Focus( );
            txtSearchKey.SelectionStart = txtSearchKey.Text.Length;
        }

        private void dtgrdList_KeyUp( object sender , KeyEventArgs e )
        {
            txtSearchKey.Focus( );
            txtSearchKey.SelectionStart = txtSearchKey.Text.Length;
        }       
    }
}