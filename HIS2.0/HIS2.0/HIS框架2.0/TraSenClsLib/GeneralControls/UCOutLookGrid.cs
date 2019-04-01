using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace TrasenClasses.GeneralControls
{
    /// <summary>
    /// jianqg 2012-10-6 emr&his框架整合  增加
    /// </summary>
    public partial class UCOutLookGrid : UserControl
    {
        public UCOutLookGrid()
        {
            InitializeComponent();
        }

        public DataSet Setds;

        public void InitUCOutLookGrid(string[] HeaderText, int[] ColWidth, int strStyle, int SortColumnIndex)
        {
            
            if (strStyle==0)
            {
                OutlookSkin();
            }
            else
            {
                OutlookDefaultSkin();
            }
            InitOutLookGrid(HeaderText, ColWidth, SortColumnIndex);

        }

        private void InitOutLookGrid(string[] HeaderText, int[] ColWidth,int SortColumnIndex)
        {
            if (Setds.Tables[0].Rows.Count > 0)
            {
                outlookGrid1.BindData(Setds, "setds");
                for (int i = 0; i < HeaderText.Length; i++)
                {
                    outlookGrid1.Columns[i].HeaderText = HeaderText[i];
                    if (ColWidth[i] == 1)
                    {
                        outlookGrid1.Columns[i].Visible = false;
                    }
                }
                GroupTemplate(SortColumnIndex);
            }
            else
            {
                outlookGrid1.BindData(null, null);
                for (int i = 0; i < HeaderText.Length; i++)
                {
                    outlookGrid1.Columns.Add(HeaderText[i], HeaderText[i]);
                    if (ColWidth[i] == 1)
                    {
                        outlookGrid1.Columns[i].Visible = false;
                    }
                }
            }
            
            
        }

        private void OutlookDefaultSkin()
        {
            this.outlookGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.outlookGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.outlookGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.outlookGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            this.outlookGrid1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.outlookGrid1.RowTemplate.Height = 23;
            this.outlookGrid1.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.outlookGrid1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.outlookGrid1.RowHeadersVisible = true;
            this.outlookGrid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.outlookGrid1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            this.outlookGrid1.AllowUserToAddRows = true;
            this.outlookGrid1.AllowUserToDeleteRows = true;
            this.outlookGrid1.AllowUserToResizeRows = true;
            this.outlookGrid1.EditMode = DataGridViewEditMode.EditOnF2;
            this.outlookGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void OutlookSkin()
        {
            this.outlookGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.outlookGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.outlookGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.outlookGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            this.outlookGrid1.GridColor = System.Drawing.SystemColors.Control;
            this.outlookGrid1.RowTemplate.Height = 19;
            this.outlookGrid1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.outlookGrid1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.outlookGrid1.RowHeadersVisible = false;
            this.outlookGrid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.outlookGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.outlookGrid1.AllowUserToAddRows = false;
            this.outlookGrid1.AllowUserToDeleteRows = false;
            this.outlookGrid1.AllowUserToResizeRows = false;
            this.outlookGrid1.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.outlookGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void GroupTemplate(int ColumnIndex)
        {
            if (Setds.Tables[0].Rows.Count > 0)
            {
                ListSortDirection direction = ListSortDirection.Ascending;
                //if (e.ColumnIndex == prevColIndex) // reverse sort order
                //    direction = prevSortDirection == ListSortDirection.Descending ? ListSortDirection.Ascending : ListSortDirection.Descending;

                // remember the column that was clicked and in which direction is ordered
                //prevColIndex = e.ColumnIndex;
                //prevSortDirection = direction;

                // set the column to be grouped
                outlookGrid1.GroupTemplate.Column = outlookGrid1.Columns[ColumnIndex];
                outlookGrid1.Sort(new DataRowComparer(ColumnIndex, direction));

            }
        }
    }

    #region Comparers - used to sort CustomerInfo objects and DataRows of a DataTable

    /// <summary>
    /// reusable custom DataRow comparer implementation, can be used to sort DataTables
    /// </summary>
    public class DataRowComparer : IComparer
    {
        ListSortDirection direction;
        int columnIndex;

        public DataRowComparer(int columnIndex, ListSortDirection direction)
        {
            this.columnIndex = columnIndex;
            this.direction = direction;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {

            DataRow obj1 = (DataRow)x;
            DataRow obj2 = (DataRow)y;
            return string.Compare(obj1[columnIndex].ToString(), obj2[columnIndex].ToString()) * (direction == ListSortDirection.Ascending ? 1 : -1);
        }
        #endregion
    }

    // custom object comparer implementation
    public class ContactInfoComparer : IComparer
    {
        private int propertyIndex;
        ListSortDirection direction;

        public ContactInfoComparer(int propertyIndex, ListSortDirection direction)
        {
            this.propertyIndex = propertyIndex;
            this.direction = direction;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            ContactInfo obj1 = (ContactInfo)x;
            ContactInfo obj2 = (ContactInfo)y;

            switch (propertyIndex)
            {
                case 1:
                    return CompareStrings(obj1.Name, obj2.Name);
                case 2:
                    return CompareDates(obj1.Date, obj2.Date);
                case 3:
                    return CompareStrings(obj1.Subject, obj2.Subject);
                case 4:
                    return CompareNumbers(obj1.Concentration, obj2.Concentration);
                default:
                    return CompareNumbers((double)obj1.Id, (double)obj2.Id);
            }
        }
        #endregion

        private int CompareStrings(string val1, string val2)
        {
            return string.Compare(val1, val2) * (direction == ListSortDirection.Ascending ? 1 : -1);
        }

        private int CompareDates(DateTime val1, DateTime val2)
        {
            if (val1 > val2) return (direction == ListSortDirection.Ascending ? 1 : -1);
            if (val1 < val2) return (direction == ListSortDirection.Ascending ? -1 : 1);
            return 0;
        }

        private int CompareNumbers(double val1, double val2)
        {
            if (val1 > val2) return (direction == ListSortDirection.Ascending ? 1 : -1);
            if (val1 < val2) return (direction == ListSortDirection.Ascending ? -1 : 1);
            return 0;
        }
    }
    #endregion Comparers

    #region ContactInfo - example business object implementation
    public class ContactInfo
    {
        public ContactInfo()
        {
        }
        public ContactInfo(int id, string name, DateTime date, string subject, double con)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.subject = subject;
            this.concentration = con;
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private double concentration;

        public double Concentration
        {
            get { return concentration; }
            set { concentration = value; }
        }

    }

    #endregion  
}
