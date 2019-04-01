using System;
using System.Collections.Generic;
using System.Text;

namespace ts_MzcfdySocket
{
    /// <summary>
    /// TCPServer产生的 Event
    /// </summary>
    /// <param name=”sender”> Event 产生对象</param>
    /// <param name=”param”>参数</param>
    public delegate void TcpServerEvent(Object sender, string param);
    /// <summary>
    /// 委托 处理服务器接受到的数据
    /// </summary>
    /// <param name=”AcceptStr”>接受到的数据</param>
    /// <param name=”sctSession”>客户端链接会话。</param>
    /// <returns></returns>
    public delegate void RecData(string AcceptStr, SocketSession sctSession);
    /// <summary>
    /// 抛出异常
    /// </summary>
    /// <param name=”e”>Exception e</param>
    /// <param name=”sender”>异常抛出者</param>
    public delegate void ThrowError(Exception e, object sender);
}
