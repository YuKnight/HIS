using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrasenFrame.Classes
{
    public partial class FrmTip : Form
    {
        private IMessageReader reader;
        public FrmTip(IMessageReader IReader)
        {
            InitializeComponent();
            reader = IReader;

            TrasenClasses.GeneralControls.ListViewEx lstMessage = new TrasenClasses.GeneralControls.ListViewEx();
            lstMessage.View = View.Details;
            lstMessage.Dock = DockStyle.Fill;
            lstMessage.FullRowSelect = true;
            lstMessage.HideSelection = false;
            this.plContent.Controls.Add(lstMessage);

            if (reader is LISMessageReader)
            {
                lstMessage.Columns.Add("验单号");
                lstMessage.Columns.Add("内容");
                lstMessage.Columns.Add("状态");

                lstMessage.Columns[0].Width = 0;
                lstMessage.Columns[1].Width = 300;

                foreach (MessageStruct message in reader.Messages)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = message.KeyFieldValue.ToString();
                    item.SubItems.Add(message.Content);
                    item.SubItems.Add(message.IsRead ? "已阅" : "未读");
                    item.Tag = message;
                    lstMessage.Items.Add(item);
                }
            }

            lstMessage.DoubleClick += new EventHandler(lstMessage_DoubleClick);
        }

        void lstMessage_DoubleClick(object sender, EventArgs e)
        {
            ListView lvw = (ListView)sender;
            if (lvw.SelectedItems.Count == 1)
            {
                if ( lvw.SelectedItems[0].Tag != null )
                {
                    MessageStruct message = (MessageStruct)lvw.SelectedItems[0].Tag;
                    try
                    {
                        reader.Show( message );
                        message.IsRead = true;
                        lvw.SelectedItems[0].SubItems[2].Text = "已阅";
                        lvw.SelectedItems[0].ForeColor = Color.Red;
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ListView lvw = (ListView)this.plContent.Controls[0];
            lstMessage_DoubleClick( lvw , e );
        }
    }
}