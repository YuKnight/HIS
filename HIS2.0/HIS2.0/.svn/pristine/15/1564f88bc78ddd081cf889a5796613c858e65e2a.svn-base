using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Text;

namespace ts_mz_tjbb
{
    internal class PrintHelper
    {
        // the grid to print
        private DataGridView dataGridView;

        // the PrintDocument
        private PrintDocument printDocument;

        // center printout?
        private bool centerOnPage;

        // has a title?
        private bool hasTitle;

        // title
        private string title;

        // font
        private Font titleFont;

        // title color
        private Color titleColor;

        // use paging?
        private bool paging;

        // row printing
        private static int currentRow;

        // page printing
        private static int pageNumber;

        // page width
        private int pageWidth;

        // page height
        private int pageHeight;

        // left margin
        private int leftMargin;

        // top margin
        private int topMargin;

        // right margin
        private int rightMargin;

        // bottom margin
        private int bottomMargin;

        // y location placeholder
        private float currentY;

        // grid sizes
        private float rowHeaderHeight;
        private List<float> rowsHeight;
        private List<float> columnsWidth;
        private float dataGridViewWidth;

        // column stop points
        private List<int[]> mColumnPoints;
        private List<float> mColumnPointsWidth;
        private int mColumnPoint;

        public PrintHelper(DataGridView objDataGridView, PrintDocument objPrintDocument, bool bCenterOnPage,
            bool bHasTitle, string sTitle, Font objTitleFont, Color objTitleColor, bool bPaging)
        {
            dataGridView = objDataGridView;
            printDocument = objPrintDocument;
            centerOnPage = bCenterOnPage;
            hasTitle = bHasTitle;
            title = sTitle;
            titleFont = objTitleFont;
            titleColor = objTitleColor;
            paging = bPaging;

            pageNumber = 0;

            rowsHeight = new List<float>();
            columnsWidth = new List<float>();

            mColumnPoints = new List<int[]>();
            mColumnPointsWidth = new List<float>();

            if (!printDocument.DefaultPageSettings.Landscape)
            {
                pageWidth = printDocument.DefaultPageSettings.PaperSize.Width;
                pageHeight = printDocument.DefaultPageSettings.PaperSize.Height;
            }
            else
            {
                pageHeight = printDocument.DefaultPageSettings.PaperSize.Width;
                pageWidth = printDocument.DefaultPageSettings.PaperSize.Height;
            }

            leftMargin = printDocument.DefaultPageSettings.Margins.Left;
            topMargin = printDocument.DefaultPageSettings.Margins.Top;
            rightMargin = printDocument.DefaultPageSettings.Margins.Right;
            bottomMargin = printDocument.DefaultPageSettings.Margins.Bottom;

            currentRow = 0;
        }

        // calculate printing metrics
        private void Calculate(Graphics g)
        {
            if (pageNumber == 0)
            {
                SizeF tmpSize = new SizeF();
                Font tmpFont;
                float tmpWidth;

                dataGridViewWidth = 0;
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    tmpFont = dataGridView.ColumnHeadersDefaultCellStyle.Font;
                    if (tmpFont == null)
                        tmpFont = dataGridView.DefaultCellStyle.Font;

                    tmpSize = g.MeasureString(dataGridView.Columns[i].HeaderText, tmpFont);
                    tmpWidth = tmpSize.Width;
                    rowHeaderHeight = tmpSize.Height;

                    for (int j = 0; j < dataGridView.Rows.Count; j++)
                    {
                        tmpFont = dataGridView.Rows[j].DefaultCellStyle.Font;
                        if (tmpFont == null)
                            tmpFont = dataGridView.DefaultCellStyle.Font;

                        tmpSize = g.MeasureString("Anything", tmpFont);
                        rowsHeight.Add(tmpSize.Height);

                        tmpSize = g.MeasureString(dataGridView.Rows[j].Cells[i].EditedFormattedValue.ToString(), tmpFont);
                        if (tmpSize.Width > tmpWidth)
                            tmpWidth = tmpSize.Width;
                    }
                    if (dataGridView.Columns[i].Visible)
                        dataGridViewWidth += tmpWidth;
                    columnsWidth.Add(tmpWidth);
                }

                int k;

                int mStartPoint = 0;
                for (k = 0; k < dataGridView.Columns.Count; k++)
                    if (dataGridView.Columns[k].Visible)
                    {
                        mStartPoint = k;
                        break;
                    }

                int mEndPoint = dataGridView.Columns.Count;
                for (k = dataGridView.Columns.Count - 1; k >= 0; k--)
                    if (dataGridView.Columns[k].Visible)
                    {
                        mEndPoint = k + 1;
                        break;
                    }

                float mTempWidth = dataGridViewWidth;
                float mTempPrintArea = (float) pageWidth - (float) leftMargin - (float) rightMargin;

                if (dataGridViewWidth > mTempPrintArea)
                {
                    mTempWidth = 0.0F;
                    for (k = 0; k < dataGridView.Columns.Count; k++)
                    {
                        if (dataGridView.Columns[k].Visible)
                        {
                            mTempWidth += columnsWidth[k];
                            if (mTempWidth > mTempPrintArea)
                            {
                                mTempWidth -= columnsWidth[k];
                                mColumnPoints.Add(new int[] {mStartPoint, mEndPoint});
                                mColumnPointsWidth.Add(mTempWidth);
                                mStartPoint = k;
                                mTempWidth = columnsWidth[k];
                            }
                        }
                        mEndPoint = k + 1;
                    }
                }

                mColumnPoints.Add(new int[] {mStartPoint, mEndPoint});
                mColumnPointsWidth.Add(mTempWidth);
                mColumnPoint = 0;
            }
        }

        // header printing
        private void DrawHeader(Graphics g)
        {
            currentY = (float) topMargin;

            if (paging)
            {
                pageNumber++;
                string PageString = "Page " + pageNumber.ToString();

                StringFormat PageStringFormat = new StringFormat();
                PageStringFormat.Trimming = StringTrimming.Word;
                PageStringFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit |
                                               StringFormatFlags.NoClip;
                PageStringFormat.Alignment = StringAlignment.Far;

                Font PageStringFont = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);

                RectangleF PageStringRectangle = new RectangleF((float) leftMargin, currentY,
                    (float) pageWidth - (float) rightMargin - (float) leftMargin,
                    g.MeasureString(PageString, PageStringFont).Height);

                g.DrawString(PageString, PageStringFont, new SolidBrush(Color.Black), PageStringRectangle,
                    PageStringFormat);

                currentY += g.MeasureString(PageString, PageStringFont).Height;
            }

            if (hasTitle)
            {
                StringFormat TitleFormat = new StringFormat();
                TitleFormat.Trimming = StringTrimming.Word;
                TitleFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit |
                                          StringFormatFlags.NoClip;
                if (centerOnPage)
                    TitleFormat.Alignment = StringAlignment.Center;
                else
                    TitleFormat.Alignment = StringAlignment.Near;

                RectangleF TitleRectangle = new RectangleF((float) leftMargin, currentY,
                    (float) pageWidth - (float) rightMargin - (float) leftMargin,
                    g.MeasureString(title, titleFont).Height);

                g.DrawString(title, titleFont, new SolidBrush(titleColor), TitleRectangle, TitleFormat);

                currentY += g.MeasureString(title, titleFont).Height;
            }

            float CurrentX = (float) leftMargin;
            if (centerOnPage)
                CurrentX += (((float) pageWidth - (float) rightMargin - (float) leftMargin) -
                             mColumnPointsWidth[mColumnPoint])/2.0F;

            Color HeaderForeColor = dataGridView.ColumnHeadersDefaultCellStyle.ForeColor;
            if (HeaderForeColor.IsEmpty)
                HeaderForeColor = dataGridView.DefaultCellStyle.ForeColor;
            SolidBrush HeaderForeBrush = new SolidBrush(HeaderForeColor);

            Color HeaderBackColor = dataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            if (HeaderBackColor.IsEmpty)
                HeaderBackColor = dataGridView.DefaultCellStyle.BackColor;
            SolidBrush HeaderBackBrush = new SolidBrush(HeaderBackColor);

            Pen TheLinePen = new Pen(dataGridView.GridColor, 1);

            Font HeaderFont = dataGridView.ColumnHeadersDefaultCellStyle.Font;
            if (HeaderFont == null)
                HeaderFont = dataGridView.DefaultCellStyle.Font;

            RectangleF HeaderBounds = new RectangleF(CurrentX, currentY, mColumnPointsWidth[mColumnPoint],
                rowHeaderHeight);
            g.FillRectangle(HeaderBackBrush, HeaderBounds);

            StringFormat CellFormat = new StringFormat();
            CellFormat.Trimming = StringTrimming.Word;
            CellFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            RectangleF CellBounds;
            float ColumnWidth;
            for (int i = (int) mColumnPoints[mColumnPoint].GetValue(0);
                i < (int) mColumnPoints[mColumnPoint].GetValue(1);
                i++)
            {
                if (!dataGridView.Columns[i].Visible) continue;

                ColumnWidth = columnsWidth[i];

                if (dataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Right"))
                    CellFormat.Alignment = StringAlignment.Far;
                else if (dataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Center"))
                    CellFormat.Alignment = StringAlignment.Center;
                else
                    CellFormat.Alignment = StringAlignment.Near;

                CellBounds = new RectangleF(CurrentX, currentY, ColumnWidth, rowHeaderHeight);

                g.DrawString(dataGridView.Columns[i].HeaderText, HeaderFont, HeaderForeBrush, CellBounds, CellFormat);

                if (dataGridView.RowHeadersBorderStyle != DataGridViewHeaderBorderStyle.None)
                    g.DrawRectangle(TheLinePen, CurrentX, currentY, ColumnWidth, rowHeaderHeight);

                CurrentX += ColumnWidth;
            }

            currentY += rowHeaderHeight;
        }

        // common row printing function
        private bool DrawRows(Graphics g)
        {
            Pen TheLinePen = new Pen(dataGridView.GridColor, 1);

            Font RowFont;
            Color RowForeColor;
            Color RowBackColor;
            SolidBrush RowForeBrush;
            SolidBrush RowBackBrush;
            SolidBrush RowAlternatingBackBrush;

            StringFormat CellFormat = new StringFormat();
            CellFormat.Trimming = StringTrimming.Word;
            CellFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;

            RectangleF RowBounds;
            float CurrentX;
            float ColumnWidth;
            while (currentRow < dataGridView.Rows.Count)
            {
                if (dataGridView.Rows[currentRow].Visible)
                {
                    RowFont = dataGridView.Rows[currentRow].DefaultCellStyle.Font;
                    if (RowFont == null)
                        RowFont = dataGridView.DefaultCellStyle.Font;

                    RowForeColor = dataGridView.Rows[currentRow].DefaultCellStyle.ForeColor;
                    if (RowForeColor.IsEmpty)
                        RowForeColor = dataGridView.DefaultCellStyle.ForeColor;
                    RowForeBrush = new SolidBrush(RowForeColor);

                    RowBackColor = dataGridView.Rows[currentRow].DefaultCellStyle.BackColor;
                    if (RowBackColor.IsEmpty)
                    {
                        RowBackBrush = new SolidBrush(dataGridView.DefaultCellStyle.BackColor);
                        RowAlternatingBackBrush = new SolidBrush(dataGridView.AlternatingRowsDefaultCellStyle.BackColor);
                    }
                    else
                    {
                        RowBackBrush = new SolidBrush(RowBackColor);
                        RowAlternatingBackBrush = new SolidBrush(RowBackColor);
                    }

                    CurrentX = (float) leftMargin;
                    if (centerOnPage)
                        CurrentX += (((float) pageWidth - (float) rightMargin - (float) leftMargin) -
                                     mColumnPointsWidth[mColumnPoint])/2.0F;

                    RowBounds = new RectangleF(CurrentX, currentY, mColumnPointsWidth[mColumnPoint],
                        rowsHeight[currentRow]);

                    if (currentRow%2 == 0)
                        g.FillRectangle(RowBackBrush, RowBounds);
                    else
                        g.FillRectangle(RowAlternatingBackBrush, RowBounds);

                    for (int CurrentCell = (int) mColumnPoints[mColumnPoint].GetValue(0);
                        CurrentCell < (int) mColumnPoints[mColumnPoint].GetValue(1);
                        CurrentCell++)
                    {
                        if (!dataGridView.Columns[CurrentCell].Visible) continue;

                        if (dataGridView.Columns[CurrentCell].DefaultCellStyle.Alignment.ToString().Contains("Right"))
                            CellFormat.Alignment = StringAlignment.Far;
                        else if (
                            dataGridView.Columns[CurrentCell].DefaultCellStyle.Alignment.ToString()
                                .Contains("Center"))
                            CellFormat.Alignment = StringAlignment.Center;
                        else
                            CellFormat.Alignment = StringAlignment.Near;

                        ColumnWidth = columnsWidth[CurrentCell];
                        RectangleF CellBounds = new RectangleF(CurrentX, currentY, ColumnWidth, rowsHeight[currentRow]);

                        g.DrawString(dataGridView.Rows[currentRow].Cells[CurrentCell].EditedFormattedValue.ToString(),
                            RowFont, RowForeBrush, CellBounds, CellFormat);

                        if (dataGridView.CellBorderStyle != DataGridViewCellBorderStyle.None)
                            g.DrawRectangle(TheLinePen, CurrentX, currentY, ColumnWidth, rowsHeight[currentRow]);

                        CurrentX += ColumnWidth;
                    }
                    currentY += rowsHeight[currentRow];

                    if ((int) currentY > (pageHeight - topMargin - bottomMargin))
                    {
                        currentRow++;
                        return true;
                    }
                }
                currentRow++;
            }

            currentRow = 0;
            mColumnPoint++;

            if (mColumnPoint == mColumnPoints.Count)
            {
                mColumnPoint = 0;
                return false;
            }
            else
                return true;
        }

        // the main grid printing method
        public bool DrawDataGridView(Graphics g)
        {
            try
            {
                Calculate(g);
                DrawHeader(g);
                bool bContinue = DrawRows(g);
                return bContinue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
