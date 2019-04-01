using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TrasenClasses.DatabaseAccess;
namespace TrasenMessage
{
    public partial class FrmMsgBorad : Form
    {
        private class Notice
        {
            public object Content;
            public object MessageId;
            public object Title;
        }


        RelationalDatabase dataBase;

        public FrmMsgBorad(RelationalDatabase Database, object[] MessageContent, object[] MessageId)
        {
            InitializeComponent();
            ImageList imglst = new ImageList();
            imglst.ImageSize = new Size(4, 20);
            lstMsg.SmallImageList = imglst;


            dataBase = Database;


            for (int i = 0; i < MessageId.Length; i++)
            {
                Notice notice = new Notice();
                notice.Content = MessageContent[i];
                notice.MessageId = MessageId[i];
                notice.Title = dataBase.GetDataResult("select title from pub_message where msgid=" + notice.MessageId.ToString());

                ListViewItem item = new ListViewItem(notice.Title.ToString());
                item.Tag = notice;
                lstMsg.Items.Add(item);
            }

            lstMsg.DoubleClick += new EventHandler(lstMsg_DoubleClick);
            lstMsg.SelectedIndexChanged += new EventHandler(lstMsg_SelectedIndexChanged);

        }

        void lstMsg_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstMsg_DoubleClick(sender, e);
        }

        void lstMsg_DoubleClick(object sender, EventArgs e)
        {
            if (lstMsg.SelectedItems.Count == 0)
                return;

            Notice notice = (Notice)lstMsg.SelectedItems[0].Tag;
            if (notice.Content == null)
            {
                try
                {
                    this.Cursor = TrasenClasses.GeneralClasses.PubStaticFun.WaitCursor();
                    notice.Content = dataBase.GetDataResult("select content from pub_message where msgid=" + notice.MessageId.ToString());
                }
                catch
                {
                    notice.Content = null;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            //显示内容
            ShowMsgContent(notice);
            //标记为已读
            TrasenClasses.GeneralClasses.ApiFunction.WriteIniString("MessageInfo", notice.MessageId.ToString(), "1", Application.StartupPath + "\\MessageInfo.ini");

            lstMsg.SelectedItems[0].ForeColor = Color.Gray;
        }

        private void FrmMsgBorad_Load(object sender, EventArgs e)
        {
            if (lstMsg.Items.Count > 0)
            {
                lstMsg.Items[0].Selected = true;
                lstMsg_DoubleClick(null, null);
            }
        }


        private void ShowMsgContent(Notice notice)
        {
            if (notice.Content != null)
            {
                Byte[] rtf = (byte[])notice.Content;
                MemoryStream ms = new MemoryStream((byte[])notice.Content);
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                this.txtMessage.Rtf = encoding.GetString(rtf, 0, Convert.ToInt32(ms.Length));
            }
            else
            {
                this.txtMessage.Text = "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            this.Close();
        }

    }
}