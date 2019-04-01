using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Creating_Barcode
{
    public partial class Form_SeeTxm : Form
    {
        private Image[] imageLis = null;
		private DataTable txmData = null;
		private string Print_MachName = "";
		private Image Image_Ok = null;
		
		public Form_SeeTxm(Image[] _imageLis, DataTable _txmData, string _Print_MachName)
		{
			this.InitializeComponent();
			this.imageLis = _imageLis;
			this.txmData = _txmData;
			this.Print_MachName = _Print_MachName;
		}
		private void Form_SeeTxm_Load(object sender, EventArgs e)
		{
			this.dgv_txm.AutoGenerateColumns = false;
			this.dgv_txm.DataSource = this.txmData;
		}
		private void dgv_txm_CurrentCellChanged(object sender, EventArgs e)
		{
			if (this.dgv_txm.CurrentRow != null)
			{
				int index = this.dgv_txm.CurrentRow.Index;
				this.barcode.Image = this.imageLis[index];
				this.barcode.Width = this.barcode.Image.Width;
				this.barcode.Height = this.barcode.Image.Height;
				this.barcode.Location = new Point(this.groupBox1.Location.X + this.groupBox1.Width / 2 - this.barcode.Width / 2, this.groupBox1.Location.Y + this.groupBox1.Height / 2 - this.barcode.Height / 2);
			}
		}
		private void btnPrint_Click(object sender, EventArgs e)
		{
			if (this.chk_One.Checked)
			{
				if (this.dgv_txm.CurrentRow != null)
				{
					this.Image_Ok = this.imageLis[this.dgv_txm.CurrentRow.Index];
					PrintDocument printDocument = new PrintDocument();
					printDocument.PrintPage += new PrintPageEventHandler(this.prt_PrintPage);
					printDocument.DefaultPageSettings.Landscape = true;
					PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
					if (this.Print_MachName.Trim() != "")
					{
						printDocument.PrinterSettings.PrinterName = this.Print_MachName;
					}
					printPreviewDialog.Document = printDocument;
					for (int i = 0; i < Convert.ToInt32(this.Image_Ok.Tag.ToString()); i++)
					{
						printPreviewDialog.Document.Print();
					}
				}
			}
			else
			{
				Image[] array = this.imageLis;
				for (int j = 0; j < array.Length; j++)
				{
					Image image = array[j];
					if (image != null)
					{
						try
						{
							this.Image_Ok = image;
							PrintDocument printDocument = new PrintDocument();
							printDocument.PrintPage += new PrintPageEventHandler(this.prt_PrintPage);
							PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
							if (this.Print_MachName.Trim() != "")
							{
								printDocument.PrinterSettings.PrinterName = this.Print_MachName;
							}
							printPreviewDialog.Document = printDocument;
							for (int i = 0; i < Convert.ToInt32(image.Tag.ToString()); i++)
							{
								printPreviewDialog.Document.Print();
							}
						}
						catch
						{
						}
					}
				}
			}
		}
		private void prt_PrintPage(object sender, PrintPageEventArgs e)
		{
			e.Graphics.DrawImageUnscaled(this.Image_Ok, 0, 0);
		}
		private void btn_Per_Click(object sender, EventArgs e)
		{
			if (this.dgv_txm.CurrentRow != null)
			{
				if (this.dgv_txm.CurrentRow.Index != 0)
				{
					this.dgv_txm.CurrentCell = this.dgv_txm.Rows[this.dgv_txm.CurrentRow.Index - 1].Cells["Cbarcode"];
				}
			}
		}
		private void btn_Next_Click(object sender, EventArgs e)
		{
			if (this.dgv_txm.CurrentRow != null)
			{
				if (this.dgv_txm.CurrentRow.Index != this.dgv_txm.Rows.Count - 1)
				{
					this.dgv_txm.CurrentCell = this.dgv_txm.Rows[this.dgv_txm.CurrentRow.Index + 1].Cells["Cbarcode"];
				}
			}
		}
    }
}