using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace Creating_Barcode
{
	public class Form_SeeTxm11 : Form
	{
		private Image[] imageLis = null;
		private DataTable txmData = null;
		private string Print_MachName = "";
		private Image Image_Ok = null;
		private IContainer components = null;
		private Panel panel1;
		private Label label1;
		private Panel panelTxm;
		private PictureBox barcode;
		private Panel panel3;
		private CheckBox chk_One;
		private Button btnPrint;
		private DataGridView dgv_txm;
		private DataGridViewTextBoxColumn Cbarcode;
		private GroupBox groupBox1;
		private Button btn_Next;
		private Button btn_Per;
		public Form_SeeTxm11(Image[] _imageLis, DataTable _txmData, string _Print_MachName)
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
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            this.panel1 = new Panel();
            this.panelTxm = new Panel();
            this.label1 = new Label();
            this.barcode = new PictureBox();
            this.panel3 = new Panel();
            this.btnPrint = new Button();
            this.chk_One = new CheckBox();
            this.dgv_txm = new DataGridView();
            this.Cbarcode = new DataGridViewTextBoxColumn();
            this.groupBox1 = new GroupBox();
            this.btn_Per = new Button();
            this.btn_Next = new Button();
            this.panel1.SuspendLayout();
            this.panelTxm.SuspendLayout();
            ( (ISupportInitialize)this.barcode ).BeginInit();
            this.panel3.SuspendLayout();
            ( (ISupportInitialize)this.dgv_txm ).BeginInit();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.BorderStyle = BorderStyle.Fixed3D;
            this.panel1.Controls.Add( this.dgv_txm );
            this.panel1.Controls.Add( this.label1 );
            this.panel1.Dock = DockStyle.Left;
            this.panel1.Location = new Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size( 160 , 379 );
            this.panel1.TabIndex = 0;
            this.panelTxm.Controls.Add( this.groupBox1 );
            this.panelTxm.Dock = DockStyle.Fill;
            this.panelTxm.Location = new Point( 160 , 0 );
            this.panelTxm.Name = "panelTxm";
            this.panelTxm.Size = new Size( 478 , 350 );
            this.panelTxm.TabIndex = 1;
            this.label1.BorderStyle = BorderStyle.FixedSingle;
            this.label1.Dock = DockStyle.Top;
            this.label1.Location = new Point( 0 , 0 );
            this.label1.Name = "label1";
            this.label1.Size = new Size( 156 , 23 );
            this.label1.TabIndex = 0;
            this.label1.Text = "条码列表";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.barcode.BackColor = Color.Transparent;
            this.barcode.Location = new Point( 6 , 20 );
            this.barcode.Name = "barcode";
            this.barcode.Size = new Size( 90 , 48 );
            this.barcode.TabIndex = 14;
            this.barcode.TabStop = false;
            this.panel3.Controls.Add( this.btn_Next );
            this.panel3.Controls.Add( this.btn_Per );
            this.panel3.Controls.Add( this.chk_One );
            this.panel3.Controls.Add( this.btnPrint );
            this.panel3.Dock = DockStyle.Bottom;
            this.panel3.Location = new Point( 160 , 350 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size( 478 , 29 );
            this.panel3.TabIndex = 2;
            this.btnPrint.Location = new Point( 114 , 3 );
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size( 75 , 23 );
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new EventHandler( this.btnPrint_Click );
            this.chk_One.AutoSize = true;
            this.chk_One.Location = new Point( 6 , 4 );
            this.chk_One.Name = "chk_One";
            this.chk_One.Size = new Size( 48 , 16 );
            this.chk_One.TabIndex = 1;
            this.chk_One.Text = "当前";
            this.chk_One.UseVisualStyleBackColor = true;
            this.dgv_txm.AllowUserToAddRows = false;
            this.dgv_txm.AllowUserToDeleteRows = false;
            this.dgv_txm.AllowUserToResizeColumns = false;
            this.dgv_txm.AllowUserToResizeRows = false;
            dataGridViewCellStyle.BackColor = SystemColors.Menu;
            this.dgv_txm.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
            this.dgv_txm.BackgroundColor = Color.White;
            this.dgv_txm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_txm.ColumnHeadersVisible = false;
            this.dgv_txm.Columns.AddRange( new DataGridViewColumn[]
			{
				this.Cbarcode
			} );
            this.dgv_txm.Dock = DockStyle.Fill;
            this.dgv_txm.Location = new Point( 0 , 23 );
            this.dgv_txm.Name = "dgv_txm";
            this.dgv_txm.RowHeadersVisible = false;
            this.dgv_txm.RowTemplate.Height = 23;
            this.dgv_txm.Size = new Size( 156 , 352 );
            this.dgv_txm.TabIndex = 1;
            this.dgv_txm.CurrentCellChanged += new EventHandler( this.dgv_txm_CurrentCellChanged );
            this.Cbarcode.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Cbarcode.DataPropertyName = "barcode";
            this.Cbarcode.HeaderText = "barcode";
            this.Cbarcode.Name = "Cbarcode";
            this.Cbarcode.ReadOnly = true;
            this.Cbarcode.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.groupBox1.BackColor = Color.FromArgb( 224 , 224 , 224 );
            this.groupBox1.Controls.Add( this.barcode );
            this.groupBox1.Location = new Point( 6 , 3 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size( 469 , 345 );
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.btn_Per.Location = new Point( 195 , 3 );
            this.btn_Per.Name = "btn_Per";
            this.btn_Per.Size = new Size( 75 , 23 );
            this.btn_Per.TabIndex = 2;
            this.btn_Per.Text = "上一个";
            this.btn_Per.UseVisualStyleBackColor = true;
            this.btn_Per.Click += new EventHandler( this.btn_Per_Click );
            this.btn_Next.Location = new Point( 276 , 3 );
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new Size( 75 , 23 );
            this.btn_Next.TabIndex = 3;
            this.btn_Next.Text = "下一个";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new EventHandler( this.btn_Next_Click );
            base.AutoScaleDimensions = new SizeF( 6f , 12f );
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size( 638 , 379 );
            base.Controls.Add( this.panelTxm );
            base.Controls.Add( this.panel3 );
            base.Controls.Add( this.panel1 );
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "Form_SeeTxm";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "预览";
            base.Load += new EventHandler( this.Form_SeeTxm_Load );
            this.panel1.ResumeLayout( false );
            this.panelTxm.ResumeLayout( false );
            ( (ISupportInitialize)this.barcode ).EndInit();
            this.panel3.ResumeLayout( false );
            this.panel3.PerformLayout();
            ( (ISupportInitialize)this.dgv_txm ).EndInit();
            this.groupBox1.ResumeLayout( false );
            base.ResumeLayout( false );
        }
	}
}
