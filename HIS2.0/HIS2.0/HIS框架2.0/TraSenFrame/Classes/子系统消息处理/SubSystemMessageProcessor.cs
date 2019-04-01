using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using TrasenClasses.DatabaseAccess;

namespace TrasenFrame.Classes
{
    public delegate void OnAfterShowMessageDialogHandle();
    public delegate void OnCloseShowMessageDialoghandle();
    /// <summary>
    /// 子系统消息处理
    /// </summary>
    public class SubSystemMessageProcessor
    {
        private Form mdiMainForm;
        private RelationalDatabase database;
        public event OnAfterShowMessageDialogHandle AfterShowMessageDialog;
        public event OnCloseShowMessageDialoghandle CloseShowMessageDialog;

        public SubSystemMessageProcessor(Form MdiMainForm,User CurrentUser,Department CurrentDept, string RunPath, RelationalDatabase Database)
        {
            mdiMainForm = MdiMainForm;
            database = Database;
            //加载需要进行消息检测的实例
            lstMessageReader = new List<IMessageReader>();
            //构造LIS消息阅读器
            LISMessageReader lisMsgReader = new LISMessageReader();
            lisMsgReader.CurrentUser = CurrentUser;
            lisMsgReader.CurrentDept = CurrentDept;
            lisMsgReader.Database = Database;
            lisMsgReader.EnvironmentPath = RunPath;
            lstMessageReader.Add(lisMsgReader);
        }

        private List<IMessageReader> lstMessageReader;

        public void Detecting()
        {
            foreach (IMessageReader reader in lstMessageReader)
            {
                
                //如果加载到新的消息
                if (reader.Load())
                {
                    //显示消息提示窗口
                    Rectangle r = Screen.PrimaryScreen.WorkingArea;
                    Point p = new Point();
                    FrmTip fTip = new FrmTip( reader );
                    fTip.FormClosed += new FormClosedEventHandler( fTip_FormClosed );
                    p.X = r.Width - fTip.Width;
                    p.Y = r.Height - fTip.Height;
                    fTip.StartPosition = FormStartPosition.Manual;
                    fTip.Location = p;
                    fTip.TopMost = true;
                    fTip.Show();
                    if ( AfterShowMessageDialog != null )
                        AfterShowMessageDialog();
                }
            }
        }

        void fTip_FormClosed( object sender , FormClosedEventArgs e )
        {
            if ( CloseShowMessageDialog != null )
                CloseShowMessageDialog();
        }
    }
}
