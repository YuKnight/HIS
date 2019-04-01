using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace SystemUpdate
{
    /// <summary>
    /// id,type,name,update_time,version,dellocalreport
    /// </summary>
    public class UpdateInfo
    {
        private const int BUFFER_LENGTH = 4096;

        private int id;
        private int type;
        /// <summary>
        /// 当前文件名
        /// </summary>
        private string name;
        private DateTime updateTime;
        private string version;
        private int dellocalreport;
        private object content;
        private bool needUpdate;
        private string downloadFolder;
        private readonly  string downloadFolder_default = ".."; //缺省值 jianqg 2013-7-2
        private Database database;


        public static event LoadingUpdateFileListHandle LoadingUpdateFileList;

        public event UpdateProcessingHandle UpdateProcessing;

        public event FileUpdateHandle FileUpdate;

        public UpdateInfo( Database Database )
        {
            database = Database;
        }
        public string DownloadFolder
        {
            get
            {
                return downloadFolder;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    downloadFolder =downloadFolder_default;// "..";
                else
                    downloadFolder = value;
            }
        }


        public bool NeedUpdate
        {
            get
            {
                return needUpdate;
            }
            set
            {
                needUpdate = value;
            }
        }

        public object Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        public int DelLocalReport
        {
            get
            {
                return dellocalreport;
            }
            set
            {
                dellocalreport = value;
            }
        }

        public string Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
            }
        }

        public DateTime UpdateTime
        {
            get
            {
                return updateTime;
            }
            set
            {
                updateTime = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        /// <summary>
        /// 更新文件
        /// </summary>
        public void Update()
        {
            string iniFile = Application.StartupPath + "\\UpdateFile.ini";           
            string folder = this.DownloadFolder;
            if ( string.IsNullOrEmpty( folder ) )
                folder = "";
            if ( folder == downloadFolder_default )
                folder = "";

            //如果folder为空，则表示当前要升级的文件时SystemUpdate.exe本身，HIS的升级程序默认在运行目录下，其他地方的同名文件则认为不是HIS的更新程序
            if ( string.IsNullOrEmpty( folder ) )
            {
                //如果是自身需要更新，退出，不在此出更新，由框架去处理升级程序的更新
                if ( ( File.Exists( Application.StartupPath + "\\SysUpdate.exe" ) && this.name.ToUpper() == "SYSUPDATE.EXE" )
                                || ( File.Exists( Application.StartupPath + "\\SysUpdateEx.exe" ) && this.name.ToUpper() == "SYSUPDATEEX.EXE" ) )
                    return;
            }

            string[] strArray = this.name.Split( ".".ToCharArray() );
            string exName = ""; //后缀名
            if ( strArray.Length > 1 )
                exName = strArray[strArray.Length - 1].ToUpper();
            string lpKeyName = this.name;
            string fullFileName = Application.StartupPath + "\\" + this.name; //本地的文件,默认是当前HIS目录
            if ( exName.ToUpper() == "RPT" )
            {
                string str = Application.StartupPath + "\\report";
                if ( !System.IO.Directory.Exists( str ) )
                    System.IO.Directory.CreateDirectory( str );
                fullFileName = Application.StartupPath + "\\report\\" + this.name; //当前路径下的报表文件夹
            }

            if ( folder != "" )
            {                
                lpKeyName = folder + "\\" + this.name;
                //如果是指定下载目录，重新构造fullFileName,
                string parentFolder = "";
                if ( this.DownloadFolder.Substring( 0 , 2 ) == downloadFolder_default ) // 
                    parentFolder = Application.StartupPath + downloadFolder.Remove( 0 , 2 ); //指定的下载目录为相对路径
                else
                    parentFolder = this.DownloadFolder;                                     //指定的下载目录为绝对路径
                //路径不存在，则创建
                if ( !System.IO.Directory.Exists( parentFolder ) )
                    System.IO.Directory.CreateDirectory( parentFolder );
                fullFileName = parentFolder + "\\" + this.name;
            }
            
            string localVersion = ApiFunction.GetIniString( "FILEINFO" , lpKeyName , iniFile );
            string serverVersion = version;                       

            if ( UpdateProcessing != null )
                UpdateProcessing( Action.CompareVersion , "比较文件版本中..." );
            //比较本地文件版本和数据库文件版本
            if ( localVersion.Trim().ToUpper() != serverVersion.Trim().ToUpper() )
            {
                try
                {
                    if ( UpdateProcessing != null )
                        UpdateProcessing( Action.DownLoadContent , "正在下载文件" + this.name + "中,请稍后......" );
                    try
                    {
                        this.content = database.GetUpdateFileContent( this.id );
                    }
                    catch
                    {
                        if ( UpdateProcessing != null )
                            UpdateProcessing( Action.DownLoadComplete , "文件" + this.name + "下载失败！" );
                        return;
                    }
                    if ( UpdateProcessing != null )
                        UpdateProcessing( Action.DownLoadComplete , "文件" + this.name + "下载完成！" );

                    Object obj = this.content;
                    if ( obj != null && !Convert.IsDBNull( obj ) )
                    {                        
                        if ( File.Exists( fullFileName ) )
                        {
                            if ( UpdateProcessing != null )
                                UpdateProcessing( Action.Updating , "文件备份中..." );
                            //备份原文件
                            BackupOldFile( fullFileName , false );
                            //删除原文件
                            File.Delete( fullFileName );

                            Classes.Logger.Write( string.Format( "旧文件{0}删除,原版本{1}" , fullFileName , localVersion ) );
                        }
                        #region 把二进制数据转为文件

                        using ( FileStream fw = new FileStream( fullFileName , FileMode.OpenOrCreate , FileAccess.ReadWrite ) )
                        {
                            try
                            {
                                byte[] buffer = (byte[])obj;
                                int fileLength = (int)buffer.Length / BUFFER_LENGTH;
                                if ( fileLength * BUFFER_LENGTH < buffer.Length )
                                {
                                    fileLength++;
                                }
                                Classes.Logger.Write( string.Format( "正在更新文件{0}，长度{1}，块{2}" , this.name , buffer.Length , fileLength ) );

                                for ( int j = 0 ; j < fileLength ; j++ )	//以长度为BUFFER_LENGTH字节的块进行传送
                                {
                                    if ( buffer.Length - j * BUFFER_LENGTH >= BUFFER_LENGTH )
                                    {
                                        fw.Write( buffer , j * BUFFER_LENGTH , BUFFER_LENGTH );
                                    }
                                    else
                                    {
                                        fw.Write( buffer , j * BUFFER_LENGTH , buffer.Length - j * BUFFER_LENGTH );
                                    }
                                    fw.Seek( 0 , SeekOrigin.End );

                                    if ( FileUpdate != null )
                                        FileUpdate( this.name , fileLength , j );
                                }
                            }
                            catch ( Exception error )
                            {
                                Classes.Logger.Write( fullFileName , error );
                                return;
                            }
                            finally
                            {
                                fw.Close();
                                fw.Dispose();
                            }
                        }
                        
                        #endregion

                        //对于报表文件，删除自定义目录下的文件即可
                        if ( dellocalreport == 1 && exName == "RPT" && string.IsNullOrEmpty(folder) )
                        {
                            //删除指定目录下的报表文件
                            string rptFile = CustomDirectory.Path + "\\report\\" + this.name;
                            if ( File.Exists( rptFile ) )
                            {
                                if ( UpdateProcessing != null )
                                    UpdateProcessing( Action.Updating , "文件备份中..." );
                                //备份文件
                                BackupOldFile( rptFile , true );
                                //删除文件
                                File.Delete( rptFile );

                                Classes.Logger.Write( string.Format( "原报表文件副本{0}已删除" , rptFile ) );
                            }
                        }
                        //将文件名及服务器版本号写入到本地的ini中
                        if ( UpdateProcessing != null )
                            UpdateProcessing( Action.Updating , "更新ini升级信息..." );

                        //MessageBox.Show("lpKeyName:" + lpKeyName + ":serverVersion:" + serverVersion);
                        ApiFunction.WriteIniString( "FILEINFO" , lpKeyName , serverVersion , iniFile );

                        if ( UpdateProcessing != null )
                        {
                            string sRet = name + "|" + localVersion + "|" + serverVersion + "|" + "更新完成...";
                            UpdateProcessing( Action.UpdateComplete , sRet );
                        }

                        Classes.Logger.Write( string.Format( "文件{0}更新完成,版本{1}" , name , serverVersion ) );
                    }
                }
                catch ( Exception error )
                {
                    if ( UpdateProcessing != null )
                        UpdateProcessing( Action.UpdateFailed , string.Format( "文件名{0},错误：{1}" , this.name , error.Message + error.StackTrace ) );

                    Classes.Logger.Write( name , error );
                }
            }
        }
        /// <summary>
        /// 备份原文件
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <param name="isRpt"></param>
        private void BackupOldFile(string fullFileName,bool isRpt)
        {
            string date = DateTime.Now.ToString( "yyyyMMdd" );
            string time = DateTime.Now.ToString( "HHmmss" );            
        }
        /// <summary>
        /// 获取升级文件列表
        /// </summary>
        /// <returns></returns>
        public static List<UpdateInfo> LoadUpdateFileList()
        {
            try
            {
                if ( LoadingUpdateFileList != null )
                    LoadingUpdateFileList( Action.LoadingUpdateFile , false ,0 );

                List<UpdateInfo> lstFileInfo = ( new Database() ).GetUpdateFileList();

                if ( LoadingUpdateFileList != null )
                    LoadingUpdateFileList( Action.LoadingUpdateFile , true , lstFileInfo.Count );

                Classes.Logger.Write( string.Format( "加载服务器端最新文件(LoadUpdateFileList),共{0}个" , lstFileInfo.Count ) );
                return lstFileInfo;
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
    }
}
