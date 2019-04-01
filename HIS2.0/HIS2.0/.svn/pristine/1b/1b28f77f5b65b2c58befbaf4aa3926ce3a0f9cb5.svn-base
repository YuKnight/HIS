using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrasenFrame.Forms
{
    public partial class FrmTxtMsg : Form
    {
        public FrmTxtMsg()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string localFilePath, fileNameExt, newFileName, FilePath;   
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型   
            saveFileDialog1.Filter = "txt files(*.txt)|*.txt|All files(*.*)|*.*";

            //设置默认文件类型显示顺序   
            saveFileDialog1.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录   
            saveFileDialog1.RestoreDirectory = true;

            //点了保存按钮进入   
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径   
                localFilePath = saveFileDialog1.FileName.ToString();   

                //获取文件名，不带路径   
                fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);   

                //获取文件路径，不带文件名   
                FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));   

                //System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();//输出文件   

                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                if (!System.IO.File.Exists(localFilePath))//如果文件不存在 
                {
                    System.IO.File.Create(localFilePath).Close();
                }

                System.IO.StreamWriter sr = System.IO.File.CreateText(localFilePath);
                sr.WriteLine(txtMsg.Text.Trim());
                sr.Close();
            }
        }

        private void txtMsg_TextChanged(object sender, EventArgs e)
        {
            //if (txtMsg.ReadOnly)
            //{
            //    txtMsg.SelectionStart = txtMsg.Text.Length;
            //    txtMsg.SelectionLength = 0;
            //    txtMsg.ScrollToCaret();
            //}
        }
    }
}