using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrasenMessage
{
    public enum Action
    {
        ViewDetail ,
        SetReaded ,
        NextTimeDeal,
    }

    /// <summary>
    /// 接收到消息的委托
    /// </summary>
    /// <param name="message"></param>
    /// <param name="MsgParamter"></param>
    public delegate void ReceviedMessageHandler(TrasenMessage.IMessageProcessor message);
    /// <summary>
    /// 消息内容点击处理委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="message"></param>
    /// <param name="MsgParamter"></param>
    public delegate void OnMessageContentClickedHander( Guid MessageId  , Action action , ref bool cancel );

    public delegate void OnSetCheckedMessageStautsHandler( List<Guid> lstMessageId,Action action,ref bool cancel );
}