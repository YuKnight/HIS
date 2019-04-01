using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TrasenMessage
{
    internal partial class UCMessageTip : UserControl
    {
        
        public delegate void OnClickedLinkLabelHandler( object sender , TrasenMessage.MessageCommunication Message , Action action ,ref bool cancel );

        public static readonly int HEIGHT = 80;
        public static readonly int WIDTH = 360;
        public static readonly int SCORALLBAR_WIDTH = 10;

        private TrasenMessage.MessageCommunication _message;

        public TrasenMessage.MessageCommunication Message
        {
            get
            {
                return _message;
            }
        }

        private event OnClickedLinkLabelHandler clickLinkLabel;

        public event OnClickedLinkLabelHandler ClickedLinkLabel
        {
            add
            {
                clickLinkLabel += value;
            }
            remove
            {
                clickLinkLabel -= value;
            }
        }

        public bool Checked
        {
            get
            {
                return this.chkSummary.Checked;
            }
            set
            {
                this.chkSummary.Checked = value;
            }
        }

        public UCMessageTip()
        {
            InitializeComponent();
            this.llbView.LinkClicked += new LinkLabelLinkClickedEventHandler( llbView_LinkClicked );
            this.llbClose.LinkClicked += new LinkLabelLinkClickedEventHandler( llbClose_LinkClicked );
        }

        public UCMessageTip( TrasenMessage.MessageCommunication message )
        {
            InitializeComponent();
            _message = message;
            this.lblSender.Text = message.Sender;
            this.lblSendTime.Text = message.SendTime.ToString( "yyyy-MM-dd HH:mm:ss" );
            this.chkSummary.Text = message.MessageString;
            this.chkSummary.ForeColor = message.Color;

            this.llbView.LinkClicked += new LinkLabelLinkClickedEventHandler( llbView_LinkClicked );
            this.llbClose.LinkClicked += new LinkLabelLinkClickedEventHandler( llbClose_LinkClicked );
            this.lblNextTip.LinkClicked += new LinkLabelLinkClickedEventHandler( lblNextTip_LinkClicked );
        }

        void lblNextTip_LinkClicked( object sender , LinkLabelLinkClickedEventArgs e )
        {
            bool cancel = false;
            if ( this.clickLinkLabel != null )
                this.clickLinkLabel( this , _message , Action.NextTimeDeal , ref cancel );
        }

        void llbClose_LinkClicked( object sender , LinkLabelLinkClickedEventArgs e )
        {
            bool cancel = false;
            if ( this.clickLinkLabel != null )
                this.clickLinkLabel( this , _message , Action.SetReaded ,ref cancel);
        }

        void llbView_LinkClicked( object sender , LinkLabelLinkClickedEventArgs e )
        {
            bool cancel = false;
            if ( this.clickLinkLabel != null )
                this.clickLinkLabel( this , _message , Action.ViewDetail ,ref cancel);
        }

        protected override void OnSizeChanged( EventArgs e )
        {
            this.Width = WIDTH;
            this.Height = HEIGHT;
        }
    }
}
