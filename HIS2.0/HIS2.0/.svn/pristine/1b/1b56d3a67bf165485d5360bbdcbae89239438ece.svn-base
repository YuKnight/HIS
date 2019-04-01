using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SystemUpdate.Forms
{
    public partial class FrmFileUpdate : Form
    { 
        private Thread thUpdate;
        
        private delegate void SetLabelTextHandle( string text );
        private event SetLabelTextHandle SetLabelText;

        private delegate void SetProgressBarValueHandle( ProgressBar progressBar, int maxValue , int currentValue );
        private event SetProgressBarValueHandle SetProgressBarValue;

        private delegate void AddListViewItemHandle( string filename , string localVersion,string serversion,string message );
        private event AddListViewItemHandle AddListViewItem;

        private delegate void UpdateComplatedHandle();
        private event UpdateComplatedHandle UpdateComplated;

        private delegate void CloseFormHandle();
        private event CloseFormHandle CloseForm;

        private delegate void SetTimeLabelTextHandle(long val);
        private event SetTimeLabelTextHandle SetTimeLabelText;

        private bool isUpdating;
        private int totalFileNum;
        private int currentIndex;
        
        private Thread thLabelTimeShow;

        
 
        public FrmFileUpdate()
        {
            InitializeComponent();
            

            this.Load += new EventHandler( FrmFileUpdate_Load );
            this.FormClosing += new FormClosingEventHandler( FrmFileUpdate_FormClosing );
            
            this.SetLabelText += new SetLabelTextHandle( FrmFileUpdate_SetLabelText );
            this.SetProgressBarValue += new SetProgressBarValueHandle( FrmFileUpdate_SetProgressBarValue );
            this.AddListViewItem += new AddListViewItemHandle( FrmFileUpdate_AddListViewItem );
            this.UpdateComplated += new UpdateComplatedHandle( FrmFileUpdate_UpdateComplated );
            this.CloseForm += new CloseFormHandle( FrmFileUpdate_CloseForm );
            this.SetTimeLabelText += new SetTimeLabelTextHandle( FrmFileUpdate_SetTimeLabelText );
        }

        void FrmFileUpdate_SetTimeLabelText(long val)
        {
            if ( val == 0 )
                lblTime.Text = "";
            else
                lblTime.Text = "已耗时: "+val.ToString()+" ms";
            
        }

        void FrmFileUpdate_CloseForm()
        {
            Classes.Logger.Write( "正在关闭线程" );
            thUpdate.Abort();
            Thread.Sleep( 3000 );
            Classes.Logger.Write( "正在关闭升级窗口" );
            this.Close();
        }

        void FrmFileUpdate_UpdateComplated()
        {
            //关闭线程
            this.Invoke(  CloseForm );
        }

        void FrmFileUpdate_FormClosing( object sender , FormClosingEventArgs e )
        {
            if ( isUpdating )
                e.Cancel = true;
        }

        void FrmFileUpdate_AddListViewItem( string filename , string localVersion , string serversion , string message )
        {
            ListViewItem item = new ListViewItem();
            item.Text = filename;
            item.SubItems.Add( localVersion );
            item.SubItems.Add( serversion );
            item.SubItems.Add( message );

            this.lstUpdateList.Items.Add( item );
            this.lstUpdateList.EnsureVisible( lstUpdateList.Items.Count - 1 );
        }

        void FrmFileUpdate_SetProgressBarValue( ProgressBar progressBar , int maxValue , int currentValue )
        {
            progressBar.Maximum = maxValue;
            progressBar.Value = currentValue;
        }

        void FrmFileUpdate_SetLabelText( string text )
        {
            lblInfo.Text = text;
        }

        void FrmFileUpdate_Load( object sender , EventArgs e )
        {
            //UpdateFile();
            //return;
            //启动升级线程
            thUpdate = new Thread( new ThreadStart( UpdateFile ) );
            thUpdate.IsBackground = true;
            Classes.Logger.Write( "升级线程启动。" );
            thUpdate.Start();
                       
        }

        void UpdateInfo_LoadingUpdateFileList( Action action , bool complated , int fileCount )
        {
            if ( action == Action.LoadingUpdateFile )
            {
                if ( !complated )
                {
                    this.lblInfo.Invoke( SetLabelText , "正在获取升级文件列表..." );
                }
                else
                {
                    this.lblInfo.Invoke( SetLabelText , string.Format( "获取升级文件列表完成..." ) );
                    Thread.Sleep( 1000 );
                }
            }
        }

        void updateInfo_UpdateProcessing( Action action , string message )
        {
            if ( action == Action.Updating )
            {
                this.pgbTotal.Invoke( SetProgressBarValue , new object[] { this.pgbTotal , Convert.ToInt32( totalFileNum ) , Convert.ToInt32( currentIndex ) } );
            }
            else if ( action == Action.CompareVersion || action == Action.DownLoadContent )
            {
                this.lblInfo.Invoke( SetLabelText , message );
                if ( action == Action.DownLoadContent )
                {
                    thLabelTimeShow = new Thread( new ThreadStart( lblTime_SetTimeLabelText ) );
                    thLabelTimeShow.IsBackground = true;
                    thLabelTimeShow.Start();
                }
            }
            else if ( action == Action.DownLoadComplete )
            {
                thLabelTimeShow.Abort();
                lblTime.Invoke( SetTimeLabelText , new object[] { 0 } );
            }
            else if ( action == Action.UpdateComplete )
            {
                string[] stemp = message.Split( "|".ToCharArray() );

                this.lblInfo.Invoke( SetLabelText , "文件" + stemp[0] + "更新完成.." );
                this.lstUpdateList.Invoke( AddListViewItem , new object[] { stemp[0] , stemp[1] , stemp[2] , stemp[3] } );
            }
            else if ( action == Action.UpdateFailed )
            {
                //if ( lstUpdateFailFiles == null )
                //    lstUpdateFailFiles = new List<string>();
                //lstUpdateFailFiles.Add( message );
            }
        }

        void updateInfo_FileUpdate( string fileName , long fileLength , long current )
        {
            string text = "正在更新文件" + fileName;
            this.lblInfo.Invoke( SetLabelText , text );
            this.pgbCurrent.Invoke( SetProgressBarValue , new object[] { this.pgbCurrent ,Convert.ToInt32( fileLength) , Convert.ToInt32( current) } );
        }

        private void UpdateFile()
        {
            isUpdating = true;

            UpdateInfo.LoadingUpdateFileList += new LoadingUpdateFileListHandle( UpdateInfo_LoadingUpdateFileList );
            //获取升级文件列表
            List<UpdateInfo> lstUpdateFileList = UpdateInfo.LoadUpdateFileList();
            totalFileNum = lstUpdateFileList.Count;
            currentIndex = 0;
            foreach ( UpdateInfo updateInfo in lstUpdateFileList )
            {
                try
                {
                    updateInfo.UpdateProcessing += new UpdateProcessingHandle( updateInfo_UpdateProcessing );
                    updateInfo.FileUpdate += new FileUpdateHandle( updateInfo_FileUpdate );
                    updateInfo.Update();
                }
                catch(Exception error)
                {
                    //记录异常 add by wangzhi 2013-06-19
                    Classes.Logger.Write( updateInfo.Name , error );
                }
                finally
                {
                    currentIndex++;
                }
            }

            isUpdating = false;
            if ( UpdateComplated != null )
                UpdateComplated();
            Classes.Logger.Write( "升级结束" );
        }


        private void lblTime_SetTimeLabelText()
        {
            long time = 0;
            
            while ( true )
            {
                time = time + 1;
                lblTime.Invoke( SetTimeLabelText , new object[] { time } );
            }
        }
        
    }
}