using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ts_MzcfdySocket
{
    public class WinApi
    {
        /// <summary>
        /// 有新消息来时闪烁任务栏并且保持聊天记录内容滚动到最底端，QQ就是这么玩滴~
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [DllImport("user32.dll")]
        public static extern bool FlashWindow(IntPtr hWnd, bool bInvert);
    }
}
