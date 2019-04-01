using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SystemUpdate
{
	/// <summary>
	/// SECURITY_ATTRIBUTES 的说明
	/// </summary>
	[StructLayout( LayoutKind.Sequential)]
	public class SECURITY_ATTRIBUTES 
	{
		/// <summary>nLength</summary>
		public int nLength; 
		/// <summary>lpSecurityDescriptor</summary>
		public int lpSecurityDescriptor; 
		/// <summary>bInheritHandle</summary>
		public int bInheritHandle; 
	}
	/// <summary>
	/// ApiFunction 的摘要说明。
	/// </summary>
	public class ApiFunction
	{
		//常数定义
		private static int WM_VSCROLL  = 0x115;
		private static int SB_LINEUP = 0;
		private static int SB_LINEDOWN = 1;
		private static int SB_PAGEUP = 2;
		private static int SB_PAGEDOWN = 3;
		/// <summary>
		/// 错误句柄
		/// </summary>
		public const int ERROR_ALREADY_EXISTS = 0183;

		//API函数申明
		[DllImport("kernel32")] 
		private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
		[DllImport("kernel32")] //EntryPoint="WritePrivateProfileString"
		private static extern int WritePrivateProfileString(string lpApplicationName ,string lpKeyName, string lpString, string lpFileName);
		/// <summary>
		/// 根据类名或者窗口名称获得句柄
		/// </summary>
		/// <param name="lpClassName">类名</param>
		/// <param name="lpWindowName">窗口名称</param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(String lpClassName,String lpWindowName);
		/// <summary>
		/// 根据句柄关闭窗口
		/// </summary>
		/// <param name="hwnd">句柄</param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern long CloseWindow(IntPtr hwnd);
		/// <summary>
		/// 获得错误信息标识
		/// </summary>
		/// <returns></returns>
		[DllImport("kernel32")]
		public static extern int GetLastError();
		/// <summary>
		/// 创建一个句柄
		/// </summary>
		/// <param name="lpMutexAttributes"></param>
		/// <param name="bInitialOwner"></param>
		/// <param name="lpName"></param>
		/// <returns></returns>
		[DllImport("kernel32")]
		public static extern IntPtr CreateMutex(SECURITY_ATTRIBUTES lpMutexAttributes,bool bInitialOwner,string lpName);
		/// <summary>
		/// 释放指定的句柄
		/// </summary>
		/// <param name="hMutex">句柄</param>
		/// <returns></returns>
		[DllImport("kernel32")]
		public static extern int ReleaseMutex(IntPtr hMutex);

		/// <summary>
		/// 发送消息
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="wMsg"></param>
		/// <param name="wParam"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hwnd ,int wMsg ,int wParam, int lParam);
		
		/// <summary>
		/// 更新消息
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern bool UpdateWindow(IntPtr hWnd);

		
		private ApiFunction()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 读取INI文件
		/// </summary>
		/// <param name="lpApplicationName">节名</param>
		/// <param name="lpKeyName">关键字</param>
		/// <param name="lpFileName">INI文件路径</param>
		/// <returns></returns>
		public static string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
		{
			System.Text.StringBuilder strReturn=new StringBuilder(255);
			int nSize=GetPrivateProfileString(lpApplicationName,lpKeyName,"",strReturn,255,lpFileName);
			return strReturn.ToString();
		}
		/// <summary>
		/// 写Ini文件
		/// </summary>
		/// <param name="lpApplicationName">节名</param>
		/// <param name="lpKeyName">关键字</param>
		/// <param name="lpString">值</param>
		/// <param name="lpFileName">INI文件路径</param>
		public static void WriteIniString(string lpApplicationName ,string lpKeyName, string lpString, string lpFileName)
		{
			WritePrivateProfileString(lpApplicationName ,lpKeyName, lpString, lpFileName);
		}
		/// <summary>
		/// 自动滚屏
		/// </summary>
		/// <param name="handle">句柄</param>
		public static void SelfSrcoll(IntPtr handle)
		{
			SendMessage(handle,WM_VSCROLL,SB_PAGEDOWN,0);
			UpdateWindow(handle);
		}
	}
}
