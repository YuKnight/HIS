using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

namespace TrasenMessage
{
    public partial class DlgImmediatelyMessage : Form
    {
        [System.Runtime.InteropServices.DllImport( "user32" )]
        private static extern bool AnimateWindow( IntPtr hwnd , int dwTime , int dwFlags );
        //下面是可用的常量，根据不同的动画效果声明自己需要的
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果        
        //点击链接标签事件
        private event OnMessageContentClickedHander messageContentClicked;
        /// <summary>
        /// 点击消息内容事件
        /// </summary>
        public event OnMessageContentClickedHander MessageContentClicked
        {
            add
            {
                messageContentClicked += value;
            }
            remove
            {
                messageContentClicked -= value;
            }
        }
        private event OnSetCheckedMessageStautsHandler setCheckedMessageStatus;
        public event OnSetCheckedMessageStautsHandler SetCheckedMessageStatus
        {
            add
            {
                setCheckedMessageStatus += value;
            }
            remove
            {
                setCheckedMessageStatus -= value;
            }
        }

        /// <summary>
        /// 将收到的消息添加到消息列表
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage( TrasenMessage.MessageCommunication message )
        {
            //message.MessageId 消息标记,该标记将存储在显示该条消息的Tag属性中，
            //当用户在消息弹出窗口点击某条消息时，则应获取该ID构造出消息对象，然后对该消息做进一步的处理，如显示具体的处理界面等。。           
            this.plMessageList.Invoke( new AddListItem( addItem ) ,message );
        }

        public void Clear()
        {
            this.plMessageList.Invoke( new ClearListItem( clearItem ) );
        }

        private delegate void AddListItem( TrasenMessage.MessageCommunication message );

        private void addItem( TrasenMessage.MessageCommunication message )
        {
            UCMessageTip ucTip = new UCMessageTip( message );
            ucTip.Dock = DockStyle.Top;
            ucTip.Tag = message.MessageId;
            ucTip.ClickedLinkLabel += new UCMessageTip.OnClickedLinkLabelHandler( ucTip_ClickedLinkLabel );
            this.plMessageList.Controls.Add( ucTip );
            
        }

        private delegate void ClearListItem();
        private void clearItem()
        {
            this.plMessageList.Controls.Clear();
        }

        private void ucTip_ClickedLinkLabel( object sender , MessageCommunication Message , Action action ,ref bool cancel)
        {
            //标记消息为已读
            if ( action == Action.SetReaded )
            {
                if ( messageContentClicked != null )
                    messageContentClicked( Message.MessageId , action , ref cancel );
                if ( cancel )
                    return;

                plMessageList.Controls.Remove( (Control)sender );
                if ( plMessageList.Controls.Count == 0 )
                    this.Hide();

                return;
            }
            //下次处理
            if ( action == Action.NextTimeDeal )
            {
                plMessageList.Controls.Remove( (Control)sender );
                if ( plMessageList.Controls.Count == 0 )
                    this.Hide();
                return;
            }

            //处理消息
            if ( action == Action.ViewDetail )
            {
                plMessageList.Controls.Remove( (Control)sender );
                if ( plMessageList.Controls.Count == 0 )
                    this.Hide();
                OnMessageContentClickedHander handler = new OnMessageContentClickedHander( LinkLabelClicked );
                IAsyncResult result = handler.BeginInvoke( Message.MessageId , action, ref cancel, new AsyncCallback( CallbackMethod ) , "" );
            }
        }

        void CallbackMethod( IAsyncResult result )
        {
            OnMessageContentClickedHander handler = (OnMessageContentClickedHander)( (AsyncResult)result ).AsyncDelegate;
            bool cancel = false;
            handler.EndInvoke( ref cancel, result );
        }

        private void LinkLabelClicked( Guid messageId ,Action action ,ref bool cancel)
        {
            if ( this.messageContentClicked != null )
                this.messageContentClicked( messageId,action , ref cancel );
            
        }

        

        readonly int _offset = 6;
        /// <summary>
        /// 即时消息
        /// </summary>
        /// <param name="Message">消息内容</param>
        /// <param name="Sender">发送者</param>
        /// <param name="TimeToClose">消息自动关闭时间，单位秒（0=不关闭）</param>
        public DlgImmediatelyMessage()
        {
            InitializeComponent();

            this.Width = UCMessageTip.WIDTH + _offset;
            this.Height = UCMessageTip.HEIGHT * 3 + 20 + _offset;//20为单条消息控件上用于显示分隔的空白处的高度
            this.plMessageList.ControlAdded += new ControlEventHandler( plMessageList_ControlAdded );
            this.plMessageList.ControlRemoved += new ControlEventHandler( plMessageList_ControlRemoved );
             

        }

        private void DlgImmediatelyMessage_FormClosing( object sender , FormClosingEventArgs e )
        {
            e.Cancel = true;
            this.Hide();
        }

        private void DlgImmediatelyMessage_VisibleChanged( object sender , EventArgs e )
        {
            if ( this.Visible )
            {
                int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
                int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
                this.Location = new Point( x , y );//设置窗体在屏幕右下角显示
                AnimateWindow( this.Handle , 500 , AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE );
            }
            else
            {
                //AnimateWindow( this.Handle , 1000 , AW_BLEND | AW_HIDE ); //减淡效果。暂不用
            }
        }

        private void plMessageList_ControlRemoved( object sender , ControlEventArgs e )
        {
            int height = plMessageList.Controls.Count * UCMessageTip.HEIGHT ;
            if ( height <= plMessageList.Height )                           
            {
                this.Width = UCMessageTip.WIDTH +_offset;
                this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;                                
            }
            
        }

        private void plMessageList_ControlAdded( object sender , ControlEventArgs e )
        {
            int height = plMessageList.Controls.Count * UCMessageTip.HEIGHT;
            if ( height > plMessageList.Height )
            {
                this.Width = UCMessageTip.WIDTH + UCMessageTip.SCORALLBAR_WIDTH + _offset * 2;
                this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            }
            
        }

        private void llbAllRead_LinkClicked( object sender , LinkLabelLinkClickedEventArgs e )
        {
            bool cancel = false;
            List<Guid> lstMsgIds = new List<Guid>();
            foreach ( Control ctrl in this.plMessageList.Controls )
            {
                UCMessageTip tip = ctrl as UCMessageTip;
                if ( tip.Checked )
                {
                    lstMsgIds.Add( new Guid( tip.Tag.ToString() ) );
                }
            }

            if ( setCheckedMessageStatus != null )
                setCheckedMessageStatus( lstMsgIds,  Action.SetReaded , ref cancel);
            if ( cancel )
                return;
            //移除选中的消息
            List<Control> removeControls = new List<Control>();
            foreach ( Control ctrl in this.plMessageList.Controls )
            {
                if ( (ctrl as UCMessageTip ).Checked )
                {
                    removeControls.Add( ctrl );                    
                }
            }
            foreach ( Control ctrl in removeControls )
                plMessageList.Controls.Remove( ctrl );

            
            if ( plMessageList.Controls.Count == 0 )
                this.Hide();
        }

        private void chkBoxAll_CheckedChanged( object sender , EventArgs e )
        {
            foreach ( Control ctrl in this.plMessageList.Controls )
            {
                ( ctrl as UCMessageTip ).Checked = this.chkBoxAll.Checked;
            }
        }
    }
}