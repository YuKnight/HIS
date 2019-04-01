using BarcodeLib;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using TrasenCommon;
using System.Collections.Generic;
namespace Creating_Barcode
{
    /// <summary>
    /// 综合了邵阳人医的和公司原来的版本的Creating_Barcode.dll
    /// 两个版本中除了重载三个参数的方法PrintBarcodeMore有冲突外，其他相同
    /// 邵阳版本中为   PrintBarcodeMore(DataTable, string ,int)
    /// 公司的版本中为 PrintBarcodeMore(DataTable,string ,string)
    /// 两个方法已整合到当前版本中
    /// 但测试反馈，合并后打印条码混乱，所以暂不用
    /// </summary>
	public class Barcode
	{
		public string Data_Txm = "123456789";
		public string Type_Txm = "Code 128";
		public int Top_Txm = 2;
		public int Left_Txm = 2;
		public int Width_Txm = 1;
		public int Height_Txm = 100;
		public int Width_Print = 400;
		public int Height_Print = 200;
		public Color BackColor_Txm = Color.White;
		public Color ForeColor_Txm = Color.Black;
		public string Print_MachName = "";
		private int Type_Set = 0;
		private Image Image_Ok = null;
		public Image CreateBarcode(ParameterEx[] P_Ex_Lis)
		{
			Bitmap bitmap = new Bitmap(this.Width_Print, this.Height_Print);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.White);
			if (P_Ex_Lis != null)
			{
				for (int i = 0; i < P_Ex_Lis.Length; i++)
				{
					ParameterEx parameterEx = P_Ex_Lis[i];
					if (parameterEx.Info_Show == 1)
					{
						int num = 10;
						if (parameterEx.Info_font > 0)
						{
							num = parameterEx.Info_font;
						}
						string info_Text = parameterEx.Info_Text;
						if (parameterEx.Info_Max > 0)
						{
							int info_Max = parameterEx.Info_Max;
							string text = this.bSubstring(info_Text, info_Max);
							if (text != info_Text)
							{
								graphics.DrawString(text, new Font(parameterEx.Info_FontName, (float)num), Brushes.Black, new PointF((float)parameterEx.Info_Left, (float)parameterEx.Info_Top));
								graphics.DrawString(info_Text.Replace(text, ""), new Font(parameterEx.Info_FontName, (float)num), Brushes.Black, new PointF((float)parameterEx.Info_Left, (float)(parameterEx.Info_Top + num + 3)));
							}
							else
							{
								graphics.DrawString(info_Text, new Font(parameterEx.Info_FontName, (float)num), Brushes.Black, new PointF((float)parameterEx.Info_Left, (float)parameterEx.Info_Top));
							}
						}
					}
				}
			}
			BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
			barcode.RawData = this.Data_Txm.Trim();
			barcode.scale = this.Width_Txm;
			barcode.HeightTxm = this.Height_Txm;
			TYPE tYPE = TYPE.UNSPECIFIED;
			string text2 = this.Type_Txm.Trim();
			switch (text2)
			{
			case "UPC-A":
				tYPE = TYPE.UPCA;
				break;
			case "UPC-A (Numbered)":
				tYPE = TYPE.UPCA;
				break;
			case "UPC-E":
				tYPE = TYPE.UPCE;
				break;
			case "UPC 2 Digit Ext.":
				tYPE = TYPE.UPC_SUPPLEMENTAL_2DIGIT;
				break;
			case "UPC 5 Digit Ext.":
				tYPE = TYPE.UPC_SUPPLEMENTAL_5DIGIT;
				break;
			case "EAN-13":
				tYPE = TYPE.EAN13;
				break;
			case "JAN-13":
				tYPE = TYPE.JAN13;
				break;
			case "EAN-8":
				tYPE = TYPE.EAN8;
				break;
			case "Codabar":
				tYPE = TYPE.Codabar;
				break;
			case "PostNet":
				tYPE = TYPE.PostNet;
				break;
			case "Bookland/ISBN":
				tYPE = TYPE.BOOKLAND;
				break;
			case "Code 11":
				tYPE = TYPE.CODE11;
				break;
			case "Code 39":
				tYPE = TYPE.CODE39;
				break;
			case "Code 39 Extended":
				tYPE = TYPE.CODE39Extended;
				break;
			case "LOGMARS":
				tYPE = TYPE.LOGMARS;
				break;
			case "MSI":
				tYPE = TYPE.MSI_Mod10;
				break;
			case "Interleaved 2 of 5":
				tYPE = TYPE.Interleaved2of5;
				break;
			case "Standard 2 of 5":
				tYPE = TYPE.Standard2of5;
				break;
			case "Code 128":
				tYPE = TYPE.CODE128;
				break;
			case "Code 128-A":
				tYPE = TYPE.CODE128A;
				break;
			case "Code 128-B":
				tYPE = TYPE.CODE128B;
				break;
			case "Code 128-C":
				tYPE = TYPE.CODE128C;
				break;
			}
			Image image = null;
			Image result;
			try
			{
				if (tYPE != TYPE.UNSPECIFIED)
				{
					image = barcode.Encode(tYPE);
				}
			}
			catch
			{
				graphics.Dispose();
				result = null;
				return result;
			}
			if (image != null)
			{
				graphics.DrawImage(image, this.Left_Txm, this.Top_Txm, image.Width, this.Height_Txm);
			}
			graphics.Dispose();
			result = bitmap;
			return result;
		}
		private Image SaveImage(Image _image)
		{
			int num = 0;
			int thumbHeight = 0;
			Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(this.ThumbnailCallback);
			int width = _image.Width;
			int height = _image.Height;
			if (width > 110)
			{
				num = 110;
				thumbHeight = height * num / width;
			}
			Image thumbnailImage = _image.GetThumbnailImage(num, thumbHeight, callback, IntPtr.Zero );
			_image.Dispose();
			return thumbnailImage;
		}
		private bool ThumbnailCallback()
		{
			return true;
		}
		private string bSubstring(string s, int length)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(s);
			int num = 0;
			int num2 = 0;
			while (num2 < bytes.GetLength(0) && num < length)
			{
				if (num2 % 2 == 0)
				{
					num++;
				}
				else
				{
					if (bytes[num2] > 0)
					{
						num++;
					}
				}
				num2++;
			}
			if (num2 % 2 == 1)
			{
				if (bytes[num2] > 0)
				{
					num2--;
				}
				else
				{
					num2++;
				}
			}
			return Encoding.Unicode.GetString(bytes, 0, num2);
		}
		public Image CreateBarcodeLocatSet(ParameterEx[] P_Ex_Lis)
		{
			this.ReadLocatSet();
			return this.CreateBarcode(P_Ex_Lis);
		}
		private void ReadLocatSet()
		{
			try
			{
				DataSet dataSet = new DataSet();
				if (this.Type_Set == 0)
				{
					dataSet.ReadXml(Application.StartupPath + "\\TrasenBarCode.xml");
				}
				else
				{
					if (this.Type_Set == 1)
					{
						dataSet.ReadXml(Application.StartupPath + "\\TrasenBarCode1.xml");
					}
					else
					{
						if (this.Type_Set == 2)
						{
							dataSet.ReadXml(Application.StartupPath + "\\TrasenBarCode2.xml");
						}
						else
						{
							if (this.Type_Set == 3)
							{
								dataSet.ReadXml(Application.StartupPath + "\\TrasenBarCode3.xml");
							}
							else
							{
								dataSet.ReadXml(Application.StartupPath + "\\TrasenBarCode.xml");
							}
						}
					}
				}
				if (dataSet != null && dataSet.Tables != null && dataSet.Tables[0].Rows.Count > 0)
				{
					if (dataSet.Tables[0].Rows[0]["BackColor_Txm"].ToString().Trim() != "")
					{
						this.BackColor_Txm = Color.FromName(dataSet.Tables[0].Rows[0]["BackColor_Txm"].ToString().Trim());
					}
					if (dataSet.Tables[0].Rows[0]["ForeColor_Txm"].ToString().Trim() != "")
					{
						this.ForeColor_Txm = Color.FromName(dataSet.Tables[0].Rows[0]["ForeColor_Txm"].ToString().Trim());
					}
					this.Height_Txm = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Height_Txm"].ToString());
					this.Left_Txm = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Left_Txm"].ToString());
					this.Top_Txm = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Top_Txm"].ToString());
					this.Type_Txm = dataSet.Tables[0].Rows[0]["Type_Txm"].ToString().Trim();
					this.Width_Txm = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Width_Txm"].ToString());
					this.Print_MachName = dataSet.Tables[0].Rows[0]["Print_MachName"].ToString().Trim();
					this.Width_Print = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Width_Print"].ToString());
					this.Height_Print = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Height_Print"].ToString());
				}
			}
			catch
			{
			}
		}
		private DataTable OtherInfoLocatSet()
		{
			DataTable result;
			try
			{
				DataSet dataSet = new DataSet();
				if (this.Type_Set == 0)
				{
					dataSet.ReadXml(Application.StartupPath + "\\TrasenBarCodeOtherInfo.xml");
				}
				else
				{
					if (this.Type_Set == 1)
					{
						dataSet.ReadXml(Application.StartupPath + "\\TrasenBarCodeOtherInfo1.xml");
					}
					else
					{
						if (this.Type_Set == 2)
						{
							dataSet.ReadXml(Application.StartupPath + "\\TrasenBarCodeOtherInfo2.xml");
						}
						else
						{
							if (this.Type_Set == 3)
							{
								dataSet.ReadXml(Application.StartupPath + "\\TrasenBarCodeOtherInfo3.xml");
							}
							else
							{
								dataSet.ReadXml(Application.StartupPath + "\\TrasenBarCodeOtherInfo.xml");
							}
						}
					}
				}
				if (dataSet != null && dataSet.Tables != null && dataSet.Tables[0].Rows.Count > 0)
				{
					result = dataSet.Tables[0];
				}
				else
				{
					result = null;
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}
		public bool PrintBarcode(ParameterEx[] P_Ex_Lis)
		{
			bool result;
			try
			{
				this.Image_Ok = this.CreateBarcode(P_Ex_Lis);
				PrintDocument printDocument = new PrintDocument();
				printDocument.PrintPage += new PrintPageEventHandler(this.prt_PrintPage);
				PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
				if (this.Print_MachName.Trim() != "")
				{
					printDocument.PrinterSettings.PrinterName = this.Print_MachName;
				}
				printPreviewDialog.Document = printDocument;
				printPreviewDialog.Document.Print();
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public bool PrintBarcodeLocatSet(ParameterEx[] P_Ex_Lis)
		{
			this.ReadLocatSet();
			return this.PrintBarcode(P_Ex_Lis);
		}
		private void prt_PrintPage(object sender, PrintPageEventArgs e)
		{
			e.Graphics.DrawImageUnscaled(this.Image_Ok, 0, 0);
		}
		public Image CreateBarCodeByTxt(string Bar_Data, string[] Txt_Lis, bool IsPrint)
		{
			this.ReadLocatSet();
			this.Data_Txm = Bar_Data;
			Bitmap bitmap = new Bitmap(this.Width_Print, this.Height_Print);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.White);
			DataTable dataTable = this.OtherInfoLocatSet();
			if (Txt_Lis != null)
			{
				int num = 1;
				for (int i = 0; i < Txt_Lis.Length; i++)
				{
					string text = Txt_Lis[i];
					int num2 = 10;
					string familyName = "";
					int num3 = 1;
					int num4 = 1;
					int num5 = 1;
					int num6 = text.Length;
					try
					{
						if (dataTable != null && dataTable.Rows.Count > 0)
						{
							DataRow[] array = dataTable.Select("ID='" + num.ToString() + "'");
							if (array.Length > 0)
							{
								num2 = Convert.ToInt32(array[0]["Info_font"].ToString());
								familyName = array[0]["Info_FontName"].ToString();
								num3 = Convert.ToInt32(array[0]["Info_Left"].ToString());
								num4 = Convert.ToInt32(array[0]["Info_Top"].ToString());
								num5 = Convert.ToInt32(array[0]["Info_Show"].ToString());
								num6 = Convert.ToInt32(array[0]["Info_Max"].ToString());
							}
						}
					}
					catch
					{
					}
					num++;
					if (num5 == 1)
					{
						string text2 = text;
						if (num6 > 0)
						{
							int length = num6;
							string text3 = this.bSubstring(text2, length);
							if (text3 != text2)
							{
								graphics.DrawString(text3, new Font(familyName, (float)num2), Brushes.Black, new PointF((float)num3, (float)num4));
								graphics.DrawString(text2.Replace(text3, ""), new Font(familyName, (float)num2), Brushes.Black, new PointF((float)num3, (float)(num4 + num2 + 3)));
							}
							else
							{
								graphics.DrawString(text2, new Font(familyName, (float)num2), Brushes.Black, new PointF((float)num3, (float)num4));
							}
						}
					}
				}
			}
			BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
			barcode.RawData = this.Data_Txm.Trim();
			barcode.scale = this.Width_Txm;
			barcode.HeightTxm = this.Height_Txm;
			TYPE tYPE = TYPE.UNSPECIFIED;
			string text4 = this.Type_Txm.Trim();
			switch (text4)
			{
			case "UPC-A":
				tYPE = TYPE.UPCA;
				break;
			case "UPC-A (Numbered)":
				tYPE = TYPE.UPCA;
				break;
			case "UPC-E":
				tYPE = TYPE.UPCE;
				break;
			case "UPC 2 Digit Ext.":
				tYPE = TYPE.UPC_SUPPLEMENTAL_2DIGIT;
				break;
			case "UPC 5 Digit Ext.":
				tYPE = TYPE.UPC_SUPPLEMENTAL_5DIGIT;
				break;
			case "EAN-13":
				tYPE = TYPE.EAN13;
				break;
			case "JAN-13":
				tYPE = TYPE.JAN13;
				break;
			case "EAN-8":
				tYPE = TYPE.EAN8;
				break;
			case "Codabar":
				tYPE = TYPE.Codabar;
				break;
			case "PostNet":
				tYPE = TYPE.PostNet;
				break;
			case "Bookland/ISBN":
				tYPE = TYPE.BOOKLAND;
				break;
			case "Code 11":
				tYPE = TYPE.CODE11;
				break;
			case "Code 39":
				tYPE = TYPE.CODE39;
				break;
			case "Code 39 Extended":
				tYPE = TYPE.CODE39Extended;
				break;
			case "LOGMARS":
				tYPE = TYPE.LOGMARS;
				break;
			case "MSI":
				tYPE = TYPE.MSI_Mod10;
				break;
			case "Interleaved 2 of 5":
				tYPE = TYPE.Interleaved2of5;
				break;
			case "Standard 2 of 5":
				tYPE = TYPE.Standard2of5;
				break;
			case "Code 128":
				tYPE = TYPE.CODE128;
				break;
			case "Code 128-A":
				tYPE = TYPE.CODE128A;
				break;
			case "Code 128-B":
				tYPE = TYPE.CODE128B;
				break;
			case "Code 128-C":
				tYPE = TYPE.CODE128C;
				break;
			}
			Image image = null;
			Image result;
			try
			{
				if (tYPE != TYPE.UNSPECIFIED)
				{
					image = barcode.Encode(tYPE);
				}
			}
			catch
			{
				graphics.Dispose();
				result = null;
				return result;
			}
			if (image != null)
			{
				graphics.DrawImage(image, this.Left_Txm, this.Top_Txm);
			}
			graphics.Dispose();
			if (IsPrint)
			{
				try
				{
					this.Image_Ok = bitmap;
					PrintDocument printDocument = new PrintDocument();
					printDocument.PrintPage += new PrintPageEventHandler(this.prt_PrintPage);
					PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
					if (this.Print_MachName.Trim() != "")
					{
						printDocument.PrinterSettings.PrinterName = this.Print_MachName;
					}
					printPreviewDialog.Document = printDocument;
					printPreviewDialog.Document.Print();
				}
				catch
				{
				}
			}
			result = bitmap;
			return result;
		}
		private Image TxmImage(string txm_data)
		{
			BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
			barcode.RawData = txm_data.Trim();
			barcode.scale = this.Width_Txm;
			barcode.HeightTxm = this.Height_Txm;
			TYPE tYPE = TYPE.UNSPECIFIED;
			string text = this.Type_Txm.Trim();
			switch (text)
			{
			case "UPC-A":
				tYPE = TYPE.UPCA;
				break;
			case "UPC-A (Numbered)":
				tYPE = TYPE.UPCA;
				break;
			case "UPC-E":
				tYPE = TYPE.UPCE;
				break;
			case "UPC 2 Digit Ext.":
				tYPE = TYPE.UPC_SUPPLEMENTAL_2DIGIT;
				break;
			case "UPC 5 Digit Ext.":
				tYPE = TYPE.UPC_SUPPLEMENTAL_5DIGIT;
				break;
			case "EAN-13":
				tYPE = TYPE.EAN13;
				break;
			case "JAN-13":
				tYPE = TYPE.JAN13;
				break;
			case "EAN-8":
				tYPE = TYPE.EAN8;
				break;
			case "Codabar":
				tYPE = TYPE.Codabar;
				break;
			case "PostNet":
				tYPE = TYPE.PostNet;
				break;
			case "Bookland/ISBN":
				tYPE = TYPE.BOOKLAND;
				break;
			case "Code 11":
				tYPE = TYPE.CODE11;
				break;
			case "Code 39":
				tYPE = TYPE.CODE39;
				break;
			case "Code 39 Extended":
				tYPE = TYPE.CODE39Extended;
				break;
			case "LOGMARS":
				tYPE = TYPE.LOGMARS;
				break;
			case "MSI":
				tYPE = TYPE.MSI_Mod10;
				break;
			case "Interleaved 2 of 5":
				tYPE = TYPE.Interleaved2of5;
				break;
			case "Standard 2 of 5":
				tYPE = TYPE.Standard2of5;
				break;
			case "Code 128":
				tYPE = TYPE.CODE128;
				break;
			case "Code 128-A":
				tYPE = TYPE.CODE128A;
				break;
			case "Code 128-B":
				tYPE = TYPE.CODE128B;
				break;
			case "Code 128-C":
				tYPE = TYPE.CODE128C;
				break;
			}
			Image image = null;
			Image result;
			try
			{
				if (tYPE != TYPE.UNSPECIFIED)
				{
					image = barcode.Encode(tYPE);
				}
			}
			catch
			{
				result = null;
				return result;
			}
			result = image;
			return result;
		}
        private Image TxmImage( string txm_data , int width , int height )
        {
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
            barcode.RawData = txm_data.Trim();
            barcode.scale = width;
            barcode.HeightTxm = height;
            TYPE iType = TYPE.CODE128;
            return barcode.Encode( iType );
        }
        public void PrintBarcodeMore( DataTable Bar_Data , bool IsPrint )
        {
            this.PrintBarcodeMore( Bar_Data , IsPrint , 0 );
        }
        /// <summary>
        /// 邵阳版本中的方法
        /// </summary>
        /// <param name="Bar_Data"></param>
        /// <param name="IsPrint"></param>
        /// <param name="_Type_Set"></param>
		public void PrintBarcodeMore(DataTable Bar_Data, bool IsPrint, int _Type_Set)
		{
			if (Bar_Data != null && Bar_Data.Rows.Count > 0)
			{
				this.Type_Set = _Type_Set;
				this.ReadLocatSet();
				DataTable dataTable = this.OtherInfoLocatSet();
				Image[] array = new Image[Bar_Data.Rows.Count];
				for (int i = 0; i < Bar_Data.Rows.Count; i++)
				{
					Bitmap bitmap = new Bitmap(this.Width_Print, this.Height_Print);
					Graphics graphics = Graphics.FromImage(bitmap);
					graphics.Clear(Color.White);
					int num = 0;
					for (int j = 0; j < Bar_Data.Columns.Count; j++)
					{
						if (Bar_Data.Columns[j].ColumnName.ToLower() != "barcode" && Bar_Data.Columns[j].ColumnName.ToLower() != "printnum")
						{
							num++;
							int num2 = 8;
							string familyName = "";
							int num3 = 1;
							int num4 = 1;
							int num5 = 1;
							string text = Bar_Data.Rows[i][j].ToString();
							int num6 = text.Length;
							try
							{
								if (dataTable != null && dataTable.Rows.Count > 0)
								{
									DataRow[] array2 = dataTable.Select("ID='" + num.ToString() + "'");
									if (array2.Length > 0)
									{
										num2 = Convert.ToInt32(array2[0]["Info_font"].ToString());
										familyName = array2[0]["Info_FontName"].ToString();
										num3 = Convert.ToInt32(array2[0]["Info_Left"].ToString());
										num4 = Convert.ToInt32(array2[0]["Info_Top"].ToString());
										num5 = Convert.ToInt32(array2[0]["Info_Show"].ToString());
										num6 = Convert.ToInt32(array2[0]["Info_Max"].ToString());
									}
								}
							}
							catch
							{
							}
							if (num5 == 1)
							{
								string text2 = text;
								if (num6 > 0)
								{
									int length = num6;
									string text3 = this.bSubstring(text2, length);
									if (text3.Trim() != "")
									{
										if (text3 != text2)
										{
											graphics.DrawString(text3, new Font(familyName, (float)num2), Brushes.Black, new PointF((float)num3, (float)num4));
											graphics.DrawString(text2.Replace(text3, ""), new Font(familyName, (float)num2), Brushes.Black, new PointF((float)num3, (float)(num4 + num2 + 3)));
										}
										else
										{
											graphics.DrawString(text2, new Font(familyName, (float)num2), Brushes.Black, new PointF((float)num3, (float)num4));
										}
									}
								}
							}
						}
					}
					string txm_data = Bar_Data.Rows[i]["barcode"].ToString();
					int num7 = 1;
					try
					{
						num7 = Convert.ToInt32(Bar_Data.Rows[i]["printnum"].ToString());
					}
					catch
					{
					}
					if (num7 < 1)
					{
						num7 = 1;
					}
					Image image = this.TxmImage(txm_data);
					if (image != null)
					{
						graphics.DrawImage(image, this.Left_Txm, this.Top_Txm);
					}
					graphics.Dispose();
					bitmap.Tag = num7;
					array[i] = bitmap;
				}
				if (IsPrint)
				{
					Image[] array3 = array;
					for (int k = 0; k < array3.Length; k++)
					{
						Image image2 = array3[k];
						if (image2 != null)
						{
							try
							{
								this.Image_Ok = image2;
								PrintDocument printDocument = new PrintDocument();
								printDocument.PrintPage += new PrintPageEventHandler(this.prt_PrintPage);
								PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
								if (this.Print_MachName.Trim() != "")
								{
									printDocument.PrinterSettings.PrinterName = this.Print_MachName;
								}
								printPreviewDialog.Document = printDocument;
								for (int l = 0; l < Convert.ToInt32(image2.Tag.ToString()); l++)
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
				else
				{
					Form_SeeTxm form_SeeTxm = new Form_SeeTxm(array, Bar_Data, this.Print_MachName);
					form_SeeTxm.ShowDialog();
				}
			}
		}		
        /// <summary>
        /// 公司原来通用版中的方法
        /// </summary>
        /// <param name="Bar_Data"></param>
        /// <param name="IsPrint"></param>
        /// <param name="xmlFile"></param>
        public void PrintBarcodeMore(DataTable Bar_Data, bool IsPrint, string xmlFile)
		{
			if (Bar_Data != null && Bar_Data.Rows.Count > 0)
			{
				List<PrinterSet> printerInfo = OperateXML.GetPrinterInfo(xmlFile);
				List<TextSet> txtInfo = OperateXML.GetTxtInfo(xmlFile);
				List<BarcodeSet> barcode = OperateXML.GetBarcode(xmlFile);
				Image[] array = new Image[Bar_Data.Rows.Count];
				for (int i = 0; i < Bar_Data.Rows.Count; i++)
				{
					Bitmap bitmap = new Bitmap(int.Parse(printerInfo[0].Width), int.Parse(printerInfo[0].Height));
					Graphics graphics = Graphics.FromImage(bitmap);
					graphics.Clear(Color.White);
					int j;
					for (j = 0; j < Bar_Data.Columns.Count; j++)
					{
						if (Bar_Data.Columns[j].ColumnName.ToLower() != "barcode" && Bar_Data.Columns[j].ColumnName.ToLower() != "printnum" && Bar_Data.Columns[j].ColumnName.ToLower() != "条形码")
						{
							int num = 10;
							string familyName = "";
							int num2 = 1;
							int num3 = 1;
							int num4 = 0;
							int num5 = 10;
							string text = Bar_Data.Rows[i][j].ToString();
							//TextSet textSet = txtInfo.Find((TextSet t) => t.TextName == Bar_Data.Columns[j].ColumnName);
                            TextSet textSet = txtInfo.Find( delegate( TextSet t )
                            {
                                return t.TextName == Bar_Data.Columns[j].ColumnName;
                            } );
							if (textSet != null)
							{
								num = int.Parse(textSet.TextFontSize);
								familyName = textSet.TextFontName;
								num2 = int.Parse(textSet.TextX);
								num3 = int.Parse(textSet.TextY);
								num4 = 1;
							}
							if (num4 == 1)
							{
								string text2 = text;
								if (num5 > 0)
								{
									int length = num5;
									string text3 = this.bSubstring(text2, length);
									if (text3.Trim() != "")
									{
										if (text3 != text2)
										{
											graphics.DrawString(text3, new Font(familyName, (float)num), Brushes.Black, new PointF((float)num2, (float)num3));
											graphics.DrawString(text2.Replace(text3, ""), new Font(familyName, (float)num), Brushes.Black, new PointF((float)num2, (float)(num3 + num + 3)));
										}
										else
										{
											graphics.DrawString(text2, new Font(familyName, (float)num), Brushes.Black, new PointF((float)num2, (float)num3));
										}
									}
								}
							}
						}
					}
					string txm_data = Bar_Data.Rows[i]["barcode"].ToString();
					int num6 = 1;
					try
					{
						num6 = Convert.ToInt32(Bar_Data.Rows[i]["printnum"].ToString());
					}
					catch
					{
					}
					if (num6 < 1)
					{
						num6 = 1;
					}
					Image image = this.TxmImage(txm_data, int.Parse(barcode[0].BarcodeLineWidth), int.Parse(barcode[0].BarcodeHeight));
					if (image != null)
					{
						graphics.DrawImage(image, int.Parse(barcode[0].BarcodeX), int.Parse(barcode[0].BarcodeY));
					}
					graphics.Dispose();
					bitmap.Tag = num6;
					array[i] = bitmap;
				}
				if (IsPrint)
				{
					Image[] array2 = array;
					for (int l = 0; l < array2.Length; l++)
					{
						Image image2 = array2[l];
						if (image2 != null)
						{
							try
							{
								this.Image_Ok = image2;
								PrintDocument printDocument = new PrintDocument();
								printDocument.PrintPage += new PrintPageEventHandler(this.prt_PrintPage);
								PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
								if (this.Print_MachName.Trim() != "")
								{
									printDocument.PrinterSettings.PrinterName = this.Print_MachName;
								}
								printPreviewDialog.Document = printDocument;
								for (int k = 0; k < Convert.ToInt32(image2.Tag.ToString()); k++)
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
				else
				{
					Form_SeeTxm form_SeeTxm = new Form_SeeTxm(array, Bar_Data, this.Print_MachName);
					form_SeeTxm.ShowDialog();
				}
			}
		}
	}
}
