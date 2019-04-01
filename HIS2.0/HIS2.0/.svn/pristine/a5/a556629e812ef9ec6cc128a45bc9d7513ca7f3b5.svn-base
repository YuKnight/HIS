using System.Diagnostics;
using System.Data;
using System.Collections;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Text;
using System.Globalization;
using System.Net.Sockets;

namespace TrasenFrame.Classes
{
    #region "FTP client class"
    /// <summary>
    /// A wrapper class for .NET 2.0 FTP
    /// </summary>
    /// <remarks>
    /// This class does not hold open an FTP connection but
    /// instead is stateless: for each FTP request it
    /// connects, performs the request and disconnects.
    /// </remarks>
    public class FtpClient
    {
        #region Delegated & Events
        //Download Progress Changed Event
        public delegate void DownloadProgressChangedHandler(object sender, DownloadProgressChangedArgs e);
        public event DownloadProgressChangedHandler OnDownloadProgressChanged;

        //Download Completed Event
        public delegate void DownloadCompletedHandler(object sender, DownloadCompletedArgs e);
        public event DownloadCompletedHandler OnDownloadCompleted;

        //New Server Message Event
        public delegate void NewMessageHandler(object sender, NewMessageEventArgs e);
        public event NewMessageHandler OnNewMessageReceived;

        //Upload Progress Changed Event
        //Download Progress Changed Event
        public delegate void UploadProgressChangedHandler(object sender, UploadProgressChangedArgs e);
        public event UploadProgressChangedHandler OnUploadProgressChanged;

        //Upload Completed Event
        public delegate void UploadCompletedHandler(object sender, UploadCompletedArgs e);
        public event UploadCompletedHandler OnUploadCompleted;
        #endregion

        #region "CONSTRUCTORS"
        /// <summary>
        /// Blank constructor
        /// </summary>
        /// <remarks>Hostname, username and password must be set manually</remarks>
        public FtpClient()
        {
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="Hostname">FTP地址</param>
        public FtpClient(string Hostname)
        {
            _hostname = Hostname;
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="Hostname">地址</param>
        /// <param name="Username">用户名</param>
        /// <param name="Password">密码</param>
        public FtpClient(string Hostname, string Username, string Password)
        {
            _hostname = Hostname;
            _username = Username;
            _password = Password;
        }
        #endregion

        #region "目录函数"
        /// <summary>
        /// 返回简单目录的集合
        /// </summary>
        /// <param name="directory">Directory to list, e.g. /pub</param>
        /// <returns>A list of filenames and directories as a List(of String)</returns>
        /// <remarks>For a detailed directory listing, use ListDirectoryDetail</remarks>
        public List<string> ListDirectory(string directory)
        {
            //return a simple list of filenames in directory
            System.Net.FtpWebRequest ftp = GetRequest(GetDirectory(directory));
            //Set request to do simple list
            ftp.Method = System.Net.WebRequestMethods.Ftp.ListDirectory;
            //Give Message of Command
            NewMessageEventArgs e = new NewMessageEventArgs("COMMAND", "List Directory", "NLST");
            OnNewMessageReceived(this, e);

            string str = GetStringResponse(ftp);
            //replace CRLF to CR, remove last instance
            str = str.Replace("\r\n", "\r").TrimEnd('\r');
            //split the string into a list
            List<string> result = new List<string>();
            result.AddRange(str.Split('\r'));
            return result;
        }

        /// <summary>
        /// Return a detailed directory listing
        /// </summary>
        /// <param name="directory">Directory to list, e.g. /pub/etc</param>
        /// <returns>An FTPDirectory object</returns>
        public FTPdirectory ListDirectoryDetail(string directory)
        {
            System.Net.FtpWebRequest ftp = GetRequest(GetDirectory(directory));
            //Set request to do simple list
            ftp.Method = System.Net.WebRequestMethods.Ftp.ListDirectoryDetails;
            //Give Message of Command
            NewMessageEventArgs e = new NewMessageEventArgs("COMMAND", "List Directory Details", "LIST");
            OnNewMessageReceived(this, e);
            string str = GetStringResponse(ftp);
            //replace CRLF to CR, remove last instance
            str = str.Replace("\r\n", "\r").TrimEnd('\r');
            //split the string into a list
            return new FTPdirectory(str, _lastDirectory);
        }

        #endregion

        #region "Upload: File transfer TO ftp server"
        /// <summary>
        /// Copy a local file to the FTP server
        /// </summary>
        /// <param name="localFilename">Full path of the local file</param>
        /// <param name="targetFilename">Target filename, if required</param>
        /// <returns></returns>
        /// <remarks>If the target filename is blank, the source filename is used
        /// (assumes current directory). Otherwise use a filename to specify a name
        /// or a full path and filename if required.</remarks>
        public bool Upload(string localFilename, string targetFilename)
        {
            //1. check source
            if (!File.Exists(localFilename))
            {
                throw (new ApplicationException("File " + localFilename + " not found"));
            }
            //copy to FI
            FileInfo fi = new FileInfo(localFilename);
          
            return Upload(fi, targetFilename);
        }


        #region Upload Variables
        System.Net.FtpWebRequest UploadFTPRequest = null;
        FileStream UploadFileStream = null;
        Stream UploadStream = null;
        bool UploadCanceled = false;
        FileInfo UploadFileInfo = null;
        #endregion

        ///// <summary>
        ///// Upload a local file to the FTP server
        ///// </summary>
        ///// <param name="fi">Source file</param>
        ///// <param name="targetFilename">Target filename (optional)</param>
        ///// <returns></returns>
        //public bool Upload(FileInfo fi, string targetFilename)
        //{
        //    //copy the file specified to target file: target file can be full path or just filename (uses current dir)

        //    //1. check target
        //    string target;
        //    if (targetFilename.Trim() == "")
        //    {
        //        //Blank target: use source filename & current dir
        //        target = this.CurrentDirectory + fi.Name;
        //    }
        //    else if (targetFilename.Contains("/"))
        //    {
        //        //If contains / treat as a full path
        //        target = AdjustDir(targetFilename);
        //    }
        //    else
        //    {
        //        //otherwise treat as filename only, use current directory
        //        target = CurrentDirectory + targetFilename;
        //    }

        //    string URI = Hostname + target;



        //    //perform copy
        //    UploadFTPRequest = GetRequest(URI);

        //    //Set request to upload a file in binary
        //    UploadFTPRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
        //    UploadFTPRequest.UseBinary = true;
        //    //Notify FTP of the expected size
        //    UploadFTPRequest.ContentLength = fi.Length;
        //    UploadFileInfo = fi;

        //    //create byte array to store: ensure at least 1 byte!
        //    const int BufferSize = 2048; //缓冲大小设置为2kb 
        //    byte[] content = new byte[BufferSize - 1 + 1];
        //    //int dataRead;

        //    //open file for reading
        //    using (UploadFileStream = fi.OpenRead())
        //    {
        //        try
        //        {
        //            #region dyw
        //            ////open request to send
        //            //using (UploadStream = UploadFTPRequest.GetRequestStream())
        //            //{

        //            //    //Get File Size
        //            //    Int64 TotalBytesUploaded = 0;
        //            //    Int64 FileSize = fi.Length;
        //            //    do
        //            //    {
        //            //        if (UploadCanceled)
        //            //        {
        //            //            UploadCanceled = false;
        //            //            return false;
        //            //        }
        //            //        dataRead = UploadFileStream.Read(content, 0, BufferSize);
        //            //        UploadStream.Write(content, 0, dataRead);
        //            //        TotalBytesUploaded += dataRead;

        //            //        System.Windows.Forms.Application.DoEvents();
        //            //    } while (!(dataRead < BufferSize));

        //            //    UploadStream.Close();
        //            //} 
        //            #endregion
        //            //modify by zjf 20120803 更改上传方式
        //            string hostAddr = new SystemCfg(11052).Config;//服务器IP
        //            string remotepath = new SystemCfg(11053).Config;//服务器FTP文件夹路径
        //            string localFile = fi.Directory.FullName + "\\" + fi.Name;
        //            string remoteFile = remotepath + "\\" + targetFilename.Replace("/", "\\");
        //            if (!EmrBaseClass.GeneralClasses.mfsrvclient.PutFileToServer(hostAddr, localFile, remoteFile))
        //            {
        //                return false;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return false;
        //        }
        //        finally
        //        {
        //            //ensure file closed
        //            UploadFileStream.Close();
        //        }

        //    }
        //    UploadFTPRequest = null;
        //    return true;

        //}

        /// <summary>
        /// Upload a local file to the FTP server
        /// </summary>
        /// <param name="fi">Source file</param>
        /// <param name="targetFilename">Target filename (optional)</param>
        /// <returns></returns>
        public bool Upload(FileInfo fi, string targetFilename)
        {
            //copy the file specified to target file: target file can be full path or just filename (uses current dir)

            //1. check target
            string target;
            if (targetFilename.Trim() == "")
            {
                //Blank target: use source filename & current dir
                target = this.CurrentDirectory + fi.Name;
            }
            else if (targetFilename.Contains("/"))
            {
                //If contains / treat as a full path
                target = AdjustDir(targetFilename);
            }
            else
            {
                //otherwise treat as filename only, use current directory
                target = CurrentDirectory + targetFilename;
            }

            string URI = Hostname + target;



            //perform copy
            UploadFTPRequest = GetRequest(URI);

            //Set request to upload a file in binary
            UploadFTPRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            UploadFTPRequest.UseBinary = true;
            //Notify FTP of the expected size
            UploadFTPRequest.ContentLength = fi.Length;
            UploadFileInfo = fi;

            //create byte array to store: ensure at least 1 byte!
            const int BufferSize = 2048; //缓冲大小设置为2kb 
            byte[] content = new byte[BufferSize - 1 + 1];
            int dataRead;

            //modify by zjf 2013-6-29 参数控制病历文件存取的方式  0.FTP;1.服务程序;2.先使用FTP,失败了再调用服务程序 
            string upflag = "0";
            //open file for reading
            using (UploadFileStream = fi.OpenRead())
            {
                try
                {
                    #region dyw  FTP
                    //open request to send
                    using ( UploadStream = UploadFTPRequest.GetRequestStream() )
                    {

                        //Get File Size
                        Int64 TotalBytesUploaded = 0;
                        Int64 FileSize = fi.Length;
                        do
                        {
                            if ( UploadCanceled )
                            {
                                UploadCanceled = false;
                                return false;
                            }
                            dataRead = UploadFileStream.Read( content , 0 , BufferSize );
                            UploadStream.Write( content , 0 , dataRead );
                            TotalBytesUploaded += dataRead;

                            System.Windows.Forms.Application.DoEvents();
                        } while ( !( dataRead < BufferSize ) );

                        UploadStream.Close();
                    }
                    #endregion
                }
                catch ( Exception ex )
                {
                    if ( upflag != "2" )
                    {
                        MessageBox.Show( ex.Message );
                        return false;
                    }
                }
                finally
                {
                    //ensure file closed
                    UploadFileStream.Close();
                }

            }
            UploadFTPRequest = null;
            return true;

        }

        public bool UpLoad(byte[] FileBytes, string targetFilename, string localFilename)
        {
            try
            {
                if (FileBytes == null)
                {
                    throw (new ApplicationException("文件内容部能为空"));
                }
                string target;
                if (targetFilename.Trim() == "")
                {
                    //Blank target: use source filename & current dir
                    target = this.CurrentDirectory + localFilename;
                }
                else if (targetFilename.Contains("/"))
                {
                    //If contains / treat as a full path
                    target = AdjustDir(targetFilename);
                }
                else
                {
                    //otherwise treat as filename only, use current directory
                    target = CurrentDirectory + targetFilename;
                }

                string URI = Hostname + target;
                //perform copy
                UploadFTPRequest = GetRequest(URI);

                //Set request to upload a file in binary
                UploadFTPRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
                UploadFTPRequest.UseBinary = true;

                UploadStream = UploadFTPRequest.GetRequestStream();

                MemoryStream mem = new MemoryStream(FileBytes);

                const int BufferSize = 2048;
                byte[] buffer = new byte[BufferSize - 1 + 1];

                int bytesRead = 0;
                int TotalRead = 0;
                while (true)
                {
                    bytesRead = mem.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    TotalRead += bytesRead;
                    UploadStream.Write(buffer, 0, bytesRead);
                }
                UploadStream.Close();
                UploadFTPRequest = null;
                mem.Close();
                mem.Dispose();
                FileBytes = null;
                return true;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

        }

        public bool UploadP(FileInfo fi, string targetFilename)
        {
            //copy the file specified to target file: target file can be full path or just filename (uses current dir)

            //1. check target
            string target;
            if (targetFilename.Trim() == "")
            {
                //Blank target: use source filename & current dir
                target = this.CurrentDirectory + fi.Name;
            }
            else if (targetFilename.Contains("/"))
            {
                //If contains / treat as a full path
                target = AdjustDir(targetFilename);
            }
            else
            {
                //otherwise treat as filename only, use current directory
                target = CurrentDirectory + targetFilename;
            }

            string URI = Hostname + target;
            //perform copy
            UploadFTPRequest = GetRequest(URI);

            //Set request to upload a file in binary
            UploadFTPRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            UploadFTPRequest.UseBinary = true;
            //Notify FTP of the expected size
            UploadFTPRequest.ContentLength = fi.Length;
            UploadFileInfo = fi;

            //create byte array to store: ensure at least 1 byte!
            const int BufferSize = 2048;
            byte[] content = new byte[BufferSize - 1 + 1];
            int dataRead;

            //open file for reading
            using (UploadFileStream = fi.OpenRead())
            {
                try
                {
                    //open request to send
                    using (UploadStream = UploadFTPRequest.GetRequestStream())
                    {
                        //Give Message of Command
                        NewMessageEventArgs e = new NewMessageEventArgs("COMMAND", "Upload File", "STOR");
                        OnNewMessageReceived(this, e);

                        //Get File Size
                        Int64 TotalBytesUploaded = 0;
                        Int64 FileSize = fi.Length;
                        do
                        {
                            if (UploadCanceled)
                            {
                                NewMessageEventArgs CancelMessage = new NewMessageEventArgs("RESPONSE", "Upload Canceled.", "CANCEL");
                                OnNewMessageReceived(this, CancelMessage);
                                UploadCanceled = false;
                                return false;
                            }

                            dataRead = UploadFileStream.Read(content, 0, BufferSize);
                            UploadStream.Write(content, 0, dataRead);
                            TotalBytesUploaded += dataRead;
                            //Declare Event
                            UploadProgressChangedArgs DownloadProgress = new UploadProgressChangedArgs(TotalBytesUploaded, FileSize);

                            //Progress changed, Raise the event.
                            OnUploadProgressChanged(this, DownloadProgress);

                            System.Windows.Forms.Application.DoEvents();
                        } while (!(dataRead < BufferSize));

                        //Get Message and Raise Event
                        NewMessageEventArgs UPloadResponse = new NewMessageEventArgs("RESPONSE", "File Uploaded!", "STOR");
                        OnNewMessageReceived(this, UPloadResponse);

                        //Declare Event
                        UploadCompletedArgs Args = new UploadCompletedArgs("Successful", true);
                        //Raise Event
                        OnUploadCompleted(this, Args);

                        UploadStream.Close();
                    }

                }
                catch (Exception ex)
                {
                    //Declare Event
                    UploadCompletedArgs Args = new UploadCompletedArgs("Error: " + ex.Message, false);
                    //Raise Event
                    OnUploadCompleted(this, Args);
                }
                finally
                {
                    //ensure file closed
                    UploadFileStream.Close();
                }

            }


            UploadFTPRequest = null;
            return true;

        }

        public void CancelUpload(string UploadFileName)
        {
            if (UploadFileStream != null)
            {
                UploadFileStream.Close();
                UploadFTPRequest.Abort();
                //UploadFileInfo.Delete();
                UploadCanceled = true;
                UploadFTPRequest = null;
                this.FtpDelete(UploadFileName);
                MessageBox.Show("Upload Canceled");
            }
        }
        #endregion

        #region "Download: File transfer FROM ftp server"
        /// <summary>
        /// Copy a file from FTP server to local
        /// </summary>
        /// <param name="sourceFilename">Target filename, if required</param>
        /// <param name="localFilename">Full path of the local file</param>
        /// <returns></returns>
        /// <remarks>Target can be blank (use same filename), or just a filename
        /// (assumes current directory) or a full path and filename</remarks>
        public bool Download(string sourceFilename, string localFilename, bool PermitOverwrite)
        {
            //2. determine target file
            FileInfo fi = new FileInfo(localFilename);
            return this.Download(sourceFilename, fi, PermitOverwrite);
        }

        //Version taking an FtpFileInfo
        public bool Download(FTPfileInfo file, string localFilename, bool PermitOverwrite)
        {
            return this.Download(file.FullName, localFilename, PermitOverwrite);
        }

        //Another version taking FtpFileInfo and FileInfo
        public bool Download(FTPfileInfo file, FileInfo localFI, bool PermitOverwrite)
        {
            return this.Download(file.FullName, localFI, PermitOverwrite);
        }

        #region Download Variables
        System.Net.FtpWebRequest DownloadFTPRequest = null;
        FtpWebResponse DownloadResponse = null;
        Stream DownloadResponseStream = null;
        FileStream DownloadFileStream = null;
        FileInfo TargetFileInfo = null;
        bool DownloadCanceled = false;

        #endregion
        ////Version taking string/FileInfo
        //public bool Download(string sourceFilename, FileInfo targetFI, bool PermitOverwrite)
        //{
        //    //1. check target
        //    if (targetFI.Exists && !(PermitOverwrite))
        //    {
        //        throw (new ApplicationException("Target file already exists"));
        //    }

        //    //2. check source
        //    string target;
        //    if (sourceFilename.Trim() == "")
        //    {
        //        throw (new ApplicationException("File not specified"));
        //    }
        //    else if (sourceFilename.Contains("/"))
        //    {
        //        //treat as a full path
        //        target = AdjustDir(sourceFilename);
        //    }
        //    else
        //    {
        //        //treat as filename only, use current directory
        //        target = CurrentDirectory + sourceFilename;
        //    }

        //    string URI = Hostname + target;

        //    //3. perform copy
        //    #region dyw
        //    //DownloadFTPRequest = GetRequest(URI);

        //    ////Set request to download a file in binary mode
        //    //DownloadFTPRequest.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;
        //    //DownloadFTPRequest.UseBinary = true;
        //    //TargetFileInfo = targetFI;
        //    ////open request and get response stream
        //    //using (DownloadResponse = (FtpWebResponse)DownloadFTPRequest.GetResponse())
        //    //{
        //    //    using (DownloadResponseStream = DownloadResponse.GetResponseStream())
        //    //    {
        //    //        //System.Security.AccessControl.FileSecurity fileSecurity = new System.Security.AccessControl.FileSecurity(targetFI.FullName, System.Security.AccessControl.AccessControlSections.All);
        //    //        //targetFI.SetAccessControl(fileSecurity);
        //    //        //loop to read & write to file
        //    //        using (DownloadFileStream = new FileStream(targetFI.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        //    //        {
        //    //            try
        //    //            {
        //    //                //Give Message of Command
        //    //                byte[] buffer = new byte[2048];
        //    //                int read = 0;
        //    //                Int64 TotalBytesRead = 0;
        //    //                Int64 FileSize = this.GetFileSize(sourceFilename);
        //    //                DownloadCanceled = false;
        //    //                do
        //    //                {
        //    //                    if (DownloadCanceled)
        //    //                    {
        //    //                        DownloadCanceled = false;
        //    //                        return false;
        //    //                    }

        //    //                    read = DownloadResponseStream.Read(buffer, 0, buffer.Length);
        //    //                    DownloadFileStream.Write(buffer, 0, read);
        //    //                    TotalBytesRead += read;
        //    //                    System.Windows.Forms.Application.DoEvents();

        //    //                } while (!(read == 0));
        //    //                DownloadResponseStream.Close();
        //    //                DownloadFileStream.Flush();
        //    //                DownloadFileStream.Close();
        //    //                DownloadFileStream = null;
        //    //                DownloadResponseStream = null;
        //    //            }
        //    //            catch (Exception ex)
        //    //            {
        //    //                //catch error and delete file only partially downloaded
        //    //                DownloadFileStream.Close();
        //    //                //delete target file as it's incomplete
        //    //                targetFI.Delete();
        //    //                throw new Exception(ex.Message);
        //    //            }
        //    //        }
        //    //        if (DownloadFileStream != null)
        //    //            DownloadResponseStream.Close();
        //    //    }
        //    //    if (DownloadFileStream != null)
        //    //        DownloadResponse.Close();
        //    //} 
        //    #endregion


        //    //modify by zjf 20120803 修改下载服务文件的方式
        //    string hostAddr = new SystemCfg(11052).Config;//服务器IP
        //    string remotepath = new SystemCfg(11053).Config;//服务器FTP文件夹路径
        //    string localFile = targetFI.Directory.FullName + "\\" + targetFI.Name;
        //    string remoteFile = remotepath.Replace("\\\\", "\\") + target.Replace("/", "\\");
        //    if (!EmrBaseClass.GeneralClasses.mfsrvclient.GetFileFromServer(hostAddr, remoteFile, localFile))
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        //Version taking string/FileInfo
        public bool Download(string sourceFilename, FileInfo targetFI, bool PermitOverwrite)
        {
            //1. check target
            if (targetFI.Exists && !(PermitOverwrite))
            {
                throw (new ApplicationException("Target file already exists"));
            }

            //2. check source
            string target;
            if (sourceFilename.Trim() == "")
            {
                throw (new ApplicationException("File not specified"));
            }
            else if (sourceFilename.Contains("/"))
            {
                //treat as a full path
                target = AdjustDir(sourceFilename);
            }
            else
            {
                //treat as filename only, use current directory
                target = CurrentDirectory + sourceFilename;
            }

            string URI = Hostname + target;

            //modify by zjf 2013-6-29 参数控制病历文件存取的方式  0.FTP;1.服务程序;2.先使用FTP,失败了再调用服务程序 
            string upflag = "0";

            //3. perform copy
            if (upflag == "0")
            {
                #region dyw

                DownloadFTPRequest = GetRequest(URI);

                //Set request to download a file in binary mode
                DownloadFTPRequest.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;
                DownloadFTPRequest.UseBinary = true;
                TargetFileInfo = targetFI;
                //open request and get response stream
                using (DownloadResponse = (FtpWebResponse)DownloadFTPRequest.GetResponse())
                {
                    using (DownloadResponseStream = DownloadResponse.GetResponseStream())
                    {
                        //System.Security.AccessControl.FileSecurity fileSecurity = new System.Security.AccessControl.FileSecurity(targetFI.FullName, System.Security.AccessControl.AccessControlSections.All);
                        //targetFI.SetAccessControl(fileSecurity);
                        //loop to read & write to file
                        using (DownloadFileStream = new FileStream(targetFI.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            try
                            {
                                //Give Message of Command
                                byte[] buffer = new byte[2048];
                                int read = 0;
                                Int64 TotalBytesRead = 0;
                                Int64 FileSize = this.GetFileSize(sourceFilename);
                                DownloadCanceled = false;
                                do
                                {
                                    if (DownloadCanceled)
                                    {
                                        DownloadCanceled = false;
                                        return false;
                                    }

                                    read = DownloadResponseStream.Read(buffer, 0, buffer.Length);
                                    DownloadFileStream.Write(buffer, 0, read);
                                    TotalBytesRead += read;
                                    System.Windows.Forms.Application.DoEvents();

                                } while (!(read == 0));
                                DownloadResponseStream.Close();
                                DownloadFileStream.Flush();
                                DownloadFileStream.Close();
                                DownloadFileStream = null;
                                DownloadResponseStream = null;
                            }
                            catch (Exception ex)
                            {
                                //catch error and delete file only partially downloaded
                                DownloadFileStream.Close();
                                //delete target file as it's incomplete
                                targetFI.Delete();
                                throw new Exception(ex.Message);
                            }
                        }
                        if (DownloadFileStream != null)
                            DownloadResponseStream.Close();
                    }
                    if (DownloadFileStream != null)
                        DownloadResponse.Close();
                }

                #endregion
            }
            
            return true;
        }

        public bool DownloadP(string sourceFilename, FileInfo targetFI, bool PermitOverwrite)
        {
            //1. check target
            if (targetFI.Exists && !(PermitOverwrite))
            {
                throw (new ApplicationException("Target file already exists"));
            }

            //2. check source
            string target;
            if (sourceFilename.Trim() == "")
            {
                throw (new ApplicationException("File not specified"));
            }
            else if (sourceFilename.Contains("/"))
            {
                //treat as a full path
                target = AdjustDir(sourceFilename);
            }
            else
            {
                //treat as filename only, use current directory
                target = CurrentDirectory + sourceFilename;
            }

            string URI = Hostname + target;

            //3. perform copy
            DownloadFTPRequest = GetRequest(URI);

            //Set request to download a file in binary mode
            DownloadFTPRequest.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;
            DownloadFTPRequest.UseBinary = true;
            TargetFileInfo = targetFI;
            //open request and get response stream
            using (DownloadResponse = (FtpWebResponse)DownloadFTPRequest.GetResponse())
            {
                using (DownloadResponseStream = DownloadResponse.GetResponseStream())
                {
                    //System.Security.AccessControl.FileSecurity fileSecurity = new System.Security.AccessControl.FileSecurity(targetFI.FullName, System.Security.AccessControl.AccessControlSections.All);
                    //targetFI.SetAccessControl(fileSecurity);
                    //loop to read & write to file
                    using (DownloadFileStream = new FileStream(targetFI.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        try
                        {
                            //Give Message of Command
                            NewMessageEventArgs e = new NewMessageEventArgs("COMMAND", "Download File", "RETR");
                            OnNewMessageReceived(this, e);
                            byte[] buffer = new byte[2048];
                            int read = 0;
                            Int64 TotalBytesRead = 0;
                            Int64 FileSize = this.GetFileSize(sourceFilename);
                            DownloadCanceled = false;
                            do
                            {
                                if (DownloadCanceled)
                                {
                                    NewMessageEventArgs CancelMessage = new NewMessageEventArgs("RESPONSE", "Download Canceled.", "CANCEL");

                                    DownloadCanceled = false;
                                    OnNewMessageReceived(this, CancelMessage);
                                    return false;
                                }

                                read = DownloadResponseStream.Read(buffer, 0, buffer.Length);
                                DownloadFileStream.Write(buffer, 0, read);
                                TotalBytesRead += read;
                                //Declare Event
                                DownloadProgressChangedArgs DownloadProgress = new DownloadProgressChangedArgs(TotalBytesRead, FileSize);

                                //Progress changed, Raise the event.
                                OnDownloadProgressChanged(this, DownloadProgress);

                                System.Windows.Forms.Application.DoEvents();

                            } while (!(read == 0));


                            //Get Message and Raise Event
                            NewMessageEventArgs NewMessageArgs = new NewMessageEventArgs("RESPONSE", DownloadResponse.StatusDescription, DownloadResponse.StatusCode.ToString());
                            OnNewMessageReceived(this, NewMessageArgs);

                            //Declare Event
                            DownloadCompletedArgs Args = new DownloadCompletedArgs("Successful", true);
                            //Raise Event
                            OnDownloadCompleted(this, Args);

                            DownloadResponseStream.Close();
                            DownloadFileStream.Flush();
                            DownloadFileStream.Close();
                            DownloadFileStream = null;
                            DownloadResponseStream = null;
                        }
                        catch (Exception ex)
                        {
                            //catch error and delete file only partially downloaded
                            DownloadFileStream.Close();
                            //delete target file as it's incomplete
                            targetFI.Delete();

                            //Decalre Event for Error
                            DownloadCompletedArgs DownloadCompleted = new DownloadCompletedArgs("Error: " + ex.Message, false);
                            //Raise Event
                            OnDownloadCompleted(this, DownloadCompleted);
                        }
                    }
                    if (DownloadFileStream != null)
                        DownloadResponseStream.Close();
                }
                if (DownloadFileStream != null)
                    DownloadResponse.Close();
            }
            return true;
        }
        public void CancelDownload()
        {
            if (DownloadFileStream != null)
            {
                DownloadFileStream.Close();

                DownloadFTPRequest.Abort();

                DownloadResponse.Close();
                DownloadResponseStream.Close();
                //DownloadFileStream = null;
                //DownloadResponseStream = null;
                TargetFileInfo.Delete();
                DownloadCanceled = true;
                MessageBox.Show("Download Canceled");
            }
        }
        #endregion

        #region "Other functions: Delete rename etc."
        /// <summary>
        /// Delete remote file
        /// </summary>
        /// <param name="filename">filename or full path</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool FtpDelete(string filename)
        {
            //Determine if file or full path
            //modify by zjf 2013-6-29 参数控制病历文件存取的方式  0.FTP;1.服务程序;2.先使用FTP,失败了再调用服务程序 
            string upflag = "0";
            if (upflag == "0")
            {
                #region dyw
                string URI = this.Hostname + GetFullPath(filename);
                System.Net.FtpWebRequest ftp = GetRequest(URI);
                //Set request to delete
                ftp.Method = System.Net.WebRequestMethods.Ftp.DeleteFile;
                try
                {
                    //get response but ignore it
                    string str = GetStringResponse(ftp);

                }
                catch (Exception)
                {
                    return false;
                }
                #endregion
            }            
            return true;
        }


        /// <summary>
        /// Modify by dyw 2010 判断文件是否在远程FTP服务器上存在
        /// </summary>
        /// <param name="filename">全路径名</param>
        /// <returns>1：标识文件存在  2：新建目录失败。 3：网络其他错误  4：其他错误</returns>
        /// <remarks>Note this only works for files </remarks>
        public int FtpFileExists(string filename)
        {
            //Try to obtain filesize: if we get error msg containing "550"
            //the file does not exist
            try
            {
                long size = GetFileSize(filename);
                return 1;

            }
            catch (Exception ex)
            {
                //only handle expected not-found exception
                if (ex is System.Net.WebException)
                {
                    //file does not exist/no rights error = 550
                    if (ex.Message.Contains("550"))
                    {
                        //clear
                        return 2;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                        return 3;
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return 4;
                }
            }
        }

        #region 原来的
        //public bool FtpFileExists(string filename)
        //{
        //    //Try to obtain filesize: if we get error msg containing "550"
        //    //the file does not exist
        //    try
        //    {
        //        long size = GetFileSize(filename);
        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        //only handle expected not-found exception
        //        if (ex is System.Net.WebException)
        //        {
        //            //file does not exist/no rights error = 550
        //            if (ex.Message.Contains("550"))
        //            {
        //                //clear
        //                return false;
        //            }
        //            else
        //            {
        //                System.Windows.Forms.MessageBox.Show(ex.Message);
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            System.Windows.Forms.MessageBox.Show(ex.Message);
        //            return false;
        //        }
        //    }
        //}
        #endregion
        /// <summary>
        /// 得到远程文件大小
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        /// <remarks>Throws an exception if file does not exist</remarks>
        public long GetFileSize(string filename)
        {
            string path;
            if (filename.Contains("/"))
            {
                path = AdjustDir(filename);
            }
            else
            {
                path = this.CurrentDirectory + filename;
            }
            string URI = this.Hostname + path;
            System.Net.FtpWebRequest ftp = GetRequest(URI);
            //Try to get info on file/dir?
            ftp.Method = System.Net.WebRequestMethods.Ftp.GetFileSize;
            string tmp = this.GetStringResponse(ftp);
            //Give Message of Command

            //NewMessageEventArgs e = new NewMessageEventArgs("COMMAND", "Get File Size", "SIZE");
            //OnNewMessageReceived(this, e);
            return GetSize(ftp);
        }
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="sourceFilename"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        public bool FtpRename(string sourceFilename, string newName)
        {
            //Does file exist?
            string source = GetFullPath(sourceFilename);
            if (FtpFileExists(source) != 1)
            {
                throw (new FileNotFoundException("文件 " + source + " 找不到"));
            }

            //build target name, ensure it does not exist
            string target = GetFullPath(newName);
            if (target == source)
            {
                throw (new ApplicationException("文件名相同不能修改"));
            }
            else if (FtpFileExists(target) == 1)
            {
                throw (new ApplicationException("修改的名称【" + target + " 】已经存在"));
            }

            //perform rename
            string URI = this.Hostname + source;

            System.Net.FtpWebRequest ftp = GetRequest(URI);
            //Set request to delete
            ftp.Method = System.Net.WebRequestMethods.Ftp.Rename;
            ftp.RenameTo = target;
            try
            {

                string str = GetStringResponse(ftp);

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool FtpCreateDirectory(string dirpath)
        {
            //perform create
            string URI = this.Hostname + AdjustDir(dirpath);
            System.Net.FtpWebRequest ftp = GetRequest(URI);
            //Set request to MkDir
            ftp.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory;
            try
            {
                string str = GetStringResponse(ftp);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool FtpDeleteDirectory(string dirpath)
        {
            //perform remove
            string URI = this.Hostname + AdjustDir(dirpath);
            System.Net.FtpWebRequest ftp = GetRequest(URI);
            //Set request to RmDir
            ftp.Method = System.Net.WebRequestMethods.Ftp.RemoveDirectory;
            try
            {
                //get response but ignore it
                string str = GetStringResponse(ftp);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region "private supporting fns"
        //Get the basic FtpWebRequest object with the
        //common settings and security
        private FtpWebRequest GetRequest(string URI)
        {
            //create request
            FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(URI);
            //Set the login details
            result.Credentials = GetCredentials();
            //Do not keep alive (stateless mode)
            result.KeepAlive = false;
            return result;
        }

        /// <summary>
        /// Get the credentials from username/password
        /// </summary>
        private System.Net.ICredentials GetCredentials()
        {
            return new System.Net.NetworkCredential(Username, Password);
        }

        /// <summary>
        /// returns a full path using CurrentDirectory for a relative file reference
        /// </summary>
        private string GetFullPath(string file)
        {
            if (file.Contains("/"))
            {
                return AdjustDir(file);
            }
            else
            {
                return this.CurrentDirectory + file;
            }
        }

        /// <summary>
        /// Amend an FTP path so that it always starts with /
        /// </summary>
        /// <param name="path">Path to adjust</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string AdjustDir(string path)
        {
            return ((path.StartsWith("/")) ? "" : "/").ToString() + path;
        }

        private string GetDirectory(string directory)
        {
            string URI;
            if (directory == "")
            {
                //build from current
                URI = Hostname + this.CurrentDirectory;
                _lastDirectory = this.CurrentDirectory;
            }
            else
            {
                if (!directory.StartsWith("/"))
                {
                    throw (new ApplicationException("Directory should start with /"));
                }
                URI = this.Hostname + directory;
                _lastDirectory = directory;
            }
            return URI;
        }

        //stores last retrieved/set directory
        private string _lastDirectory = "";

        /// <summary>
        /// Obtains a response stream as a string
        /// </summary>
        /// <param name="ftp">current FTP request</param>
        /// <returns>String containing response</returns>
        /// <remarks>FTP servers typically return strings with CR and
        /// not CRLF. Use respons.Replace(vbCR, vbCRLF) to convert
        /// to an MSDOS string</remarks>
        private string GetStringResponse(FtpWebRequest ftp)
        {
            //Get the result, streaming to a string
            string result = "";
            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                long size = response.ContentLength;
                using (Stream datastream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(datastream, Encoding.GetEncoding("GB2312")))
                    {
                        _WelcomeMessage = response.WelcomeMessage;
                        _ExitMessage = response.ExitMessage;
                        result = sr.ReadToEnd();
                        sr.Close();
                    }

                    datastream.Close();
                }
                response.Close();
            }
            return result;
        }

        /// <summary>
        /// 得到文件大小
        /// </summary>
        /// <param name="ftp"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private long GetSize(FtpWebRequest ftp)
        {
            long size;
            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                size = response.ContentLength;
                response.Close();
            }

            return size;
        }
        #endregion

        #region "Properties"
        private string _hostname;
        /// <summary>
        /// Hostname
        /// </summary>
        /// <value></value>
        /// <remarks>Hostname can be in either the full URL format
        /// ftp://ftp.myhost.com or just ftp.myhost.com
        /// </remarks>
        public string Hostname
        {
            get
            {
                if (_hostname.StartsWith("ftp://"))
                {
                    return _hostname;
                }
                else
                {
                    return "ftp://" + _hostname;
                }
            }
            set
            {
                _hostname = value;
            }
        }
        private string _username;
        /// <summary>
        /// Username property
        /// </summary>
        /// <value></value>
        /// <remarks>Can be left blank, in which case 'anonymous' is returned</remarks>
        public string Username
        {
            get
            {
                return (_username == "" ? "anonymous" : _username);
            }
            set
            {
                _username = value;
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        /// <summary>
        /// The CurrentDirectory value
        /// </summary>
        /// <remarks>Defaults to the root '/'</remarks>
        private string _currentDirectory = "/";
        public string CurrentDirectory
        {
            get
            {
                //return directory, ensure it ends with /
                return _currentDirectory + ((_currentDirectory.EndsWith("/")) ? "" : "/").ToString();
            }
            set
            {
                if (!value.StartsWith("/"))
                {
                    throw (new ApplicationException("Directory should start with /"));
                }
                _currentDirectory = value;
            }
        }
        #endregion

        #region Server Messages
        string _WelcomeMessage, _ExitMessage;
        public string WelcomeMessage
        {
            get
            {
                return _WelcomeMessage;
            }
            set
            {
                _WelcomeMessage = value;
            }
        }
        public string ExitMessage
        {
            get
            {
                return _ExitMessage;
            }
            set
            {
                _ExitMessage = value;
            }
        }
        #endregion

    }
    #endregion

    #region "FTP file info class"
    /// <summary>
    /// Represents a file or directory entry from an FTP listing
    /// </summary>
    /// <remarks>
    /// This class is used to parse the results from a detailed
    /// directory list from FTP. It supports most formats of
    /// </remarks>
    public class FTPfileInfo
    {

        //Stores extended info about FTP file

        #region "Properties"
        /// <summary>
        /// 全名
        /// </summary>
        public string FullName
        {
            get
            {
                return Path + Filename;
            }
        }
        /// <summary>
        /// 文件名
        /// </summary>
        public string Filename
        {
            get
            {
                return _filename;
            }
        }
        /// <summary>
        /// 路径
        /// </summary>
        public string Path
        {
            get
            {
                return _path;
            }
        }
        /// <summary>
        /// 文件类型
        /// </summary>
        public DirectoryEntryTypes FileType
        {
            get
            {
                return _fileType;
            }
        }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long Size
        {
            get
            {
                return _size;
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime FileDateTime
        {
            get
            {
                return _fileDateTime;
            }
        }
        public string Permission
        {
            get
            {
                return _permission;
            }
        }
        public string Extension
        {
            get
            {
                int i = this.Filename.LastIndexOf(".");
                if (i >= 0 && i < (this.Filename.Length - 1))
                {
                    return this.Filename.Substring(i + 1);
                }
                else
                {
                    return "";
                }
            }
        }
        public string NameOnly
        {
            get
            {
                int i = this.Filename.LastIndexOf(".");
                if (i > 0)
                {
                    return this.Filename.Substring(0, i);
                }
                else
                {
                    return this.Filename;
                }
            }
        }
        private string _filename;
        private string _path;
        private DirectoryEntryTypes _fileType;
        private long _size;
        private DateTime _fileDateTime;
        private string _permission;

        #endregion

        /// <summary>
        /// Identifies entry as either File or Directory
        /// </summary>
        public enum DirectoryEntryTypes
        {
            File,
            Directory
        }

        /// <summary>
        /// Constructor taking a directory listing line and path
        /// </summary>
        /// <param name="line">The line returned from the detailed directory list</param>
        /// <param name="path">Path of the directory</param>
        /// <remarks></remarks>
        public FTPfileInfo(string line, string path)
        {
            //parse line
            Match m = GetMatchingRegex(line);
            if (m == null)
            {
                //failed
                throw (new ApplicationException("Unable to parse line: " + line));
            }
            else
            {
                _filename = m.Groups["name"].Value;
                _path = path;

                Int64.TryParse(m.Groups["size"].Value, out _size);
                //_size = System.Convert.ToInt32(m.Groups["size"].Value);

                _permission = m.Groups["permission"].Value;
                string _dir = m.Groups["dir"].Value;
                if (_dir != "" && _dir != "-")
                {
                    _fileType = DirectoryEntryTypes.Directory;
                }
                else
                {
                    _fileType = DirectoryEntryTypes.File;
                }

                try
                {
                    _fileDateTime = DateTime.Parse(m.Groups["timestamp"].Value);
                }
                catch (Exception)
                {
                    _fileDateTime = Convert.ToDateTime(null);
                }

            }
        }

        private Match GetMatchingRegex(string line)
        {
            Regex rx;
            Match m;
            for (int i = 0; i <= _ParseFormats.Length - 1; i++)
            {
                rx = new Regex(_ParseFormats[i]);
                m = rx.Match(line);
                if (m.Success)
                {
                    return m;
                }
            }
            return null;
        }

        #region "Regular expressions for parsing LIST results"
        /// <summary>
        /// List of REGEX formats for different FTP server listing formats
        /// </summary>
        /// <remarks>
        /// The first three are various UNIX/LINUX formats, fourth is for MS FTP
        /// in detailed mode and the last for MS FTP in 'DOS' mode.
        /// I wish VB.NET had support for Const arrays like C# but there you go
        /// </remarks>
        private static string[] _ParseFormats = new string[] { 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\w+\\s+\\w+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{4})\\s+(?<name>.+)", 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\d+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{4})\\s+(?<name>.+)", 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\d+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{1,2}:\\d{2})\\s+(?<name>.+)", 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\w+\\s+\\w+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{1,2}:\\d{2})\\s+(?<name>.+)", 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})(\\s+)(?<size>(\\d+))(\\s+)(?<ctbit>(\\w+\\s\\w+))(\\s+)(?<size2>(\\d+))\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{2}:\\d{2})\\s+(?<name>.+)", 
            "(?<timestamp>\\d{2}\\-\\d{2}\\-\\d{2}\\s+\\d{2}:\\d{2}[Aa|Pp][mM])\\s+(?<dir>\\<\\w+\\>){0,1}(?<size>\\d+){0,1}\\s+(?<name>.+)" };
        #endregion
    }
    #endregion

    #region "FTP Directory class"
    /// <summary>
    /// Stores a list of files and directories from an FTP result
    /// </summary>
    /// <remarks></remarks>
    public class FTPdirectory : List<FTPfileInfo>
    {


        public FTPdirectory()
        {
            //creates a blank directory listing
        }

        /// <summary>
        /// Constructor: create list from a (detailed) directory string
        /// </summary>
        /// <param name="dir">directory listing string</param>
        /// <param name="path"></param>
        /// <remarks></remarks>
        public FTPdirectory(string dir, string path)
        {
            foreach (string line in dir.Replace("\n", "").Split(System.Convert.ToChar('\r')))
            {
                //parse
                if (line != "")
                {
                    this.Add(new FTPfileInfo(line, path));
                }
            }
        }

        /// <summary>
        /// Filter out only files from directory listing
        /// </summary>
        /// <param name="ext">optional file extension filter</param>
        /// <returns>FTPdirectory listing</returns>
        public FTPdirectory GetFiles(string ext)
        {
            return this.GetFileOrDir(FTPfileInfo.DirectoryEntryTypes.File, ext);
        }

        /// <summary>
        /// Returns a list of only subdirectories
        /// </summary>
        /// <returns>FTPDirectory list</returns>
        /// <remarks></remarks>
        public FTPdirectory GetDirectories()
        {
            return this.GetFileOrDir(FTPfileInfo.DirectoryEntryTypes.Directory, "");
        }

        //internal: share use function for GetDirectories/Files
        private FTPdirectory GetFileOrDir(FTPfileInfo.DirectoryEntryTypes type, string ext)
        {
            FTPdirectory result = new FTPdirectory();
            foreach (FTPfileInfo fi in this)
            {
                if (fi.FileType == type)
                {
                    if (ext == "")
                    {
                        result.Add(fi);
                    }
                    else if (ext == fi.Extension)
                    {
                        result.Add(fi);
                    }
                }
            }
            return result;

        }

        public bool FileExists(string filename)
        {
            foreach (FTPfileInfo ftpfile in this)
            {
                if (ftpfile.Filename == filename)
                {
                    return true;
                }
            }
            return false;
        }

        private const char slash = '/';

        public static string GetParentDirectory(string dir)
        {
            string tmp = dir.TrimEnd(slash);
            int i = tmp.LastIndexOf(slash);
            if (i > 0)
            {
                return tmp.Substring(0, i - 1);
            }
            else
            {
                throw (new ApplicationException("No parent for root"));
            }
        }
    }
    #endregion

    #region Events
    public class DownloadProgressChangedArgs : EventArgs
    {
        //Private Members
        private Int64 _BytesDownload;
        private Int64 _TotalBytes;

        //Constructor
        public DownloadProgressChangedArgs(Int64 BytesDownload, Int64 TotleBytes)
        {
            this._BytesDownload = BytesDownload;
            this._TotalBytes = TotleBytes;
        }

        //Public Members
        public Int64 BytesDownloaded { get { return _BytesDownload; } }
        public Int64 TotleBytes { get { return _TotalBytes; } }
    }

    public class DownloadCompletedArgs : EventArgs
    {
        //Private Members
        private bool _DownloadedCompleted;
        private string _DownloadStatus;

        //Constructor
        public DownloadCompletedArgs(string Status, bool Completed)
        {
            this._DownloadedCompleted = Completed;
            this._DownloadStatus = Status;
        }

        //Public Members
        public String DownloadStatus { get { return _DownloadStatus; } }
        public bool DownloadCompleted { get { return _DownloadedCompleted; } }
    }

    public class NewMessageEventArgs : EventArgs
    {
        //Private Members
        private string _Message;
        private string _StatusCode;
        private string _Type;

        //Constructor
        public NewMessageEventArgs(string Type, string Status, string Code)
        {
            this._Message = Status;
            this._StatusCode = Code;
            this._Type = Type;
        }

        //Public Members
        public string StatusMessage { get { return _Message; } }
        public string StatusCode { get { return _StatusCode; } }
        public string StatusType { get { return _Type; } }
    }

    public class UploadProgressChangedArgs : EventArgs
    {
        //Private Members
        private Int64 _BytesUpload;
        private Int64 _TotalBytes;

        //Constructor
        public UploadProgressChangedArgs(Int64 BytesUpload, Int64 TotleBytes)
        {
            this._BytesUpload = BytesUpload;
            this._TotalBytes = TotleBytes;
        }

        //Public Members
        public Int64 BytesUploaded { get { return _BytesUpload; } }
        public Int64 TotleBytes { get { return _TotalBytes; } }
    }

    public class UploadCompletedArgs : EventArgs
    {
        //Private Members
        private bool _UploadCompleted;
        private string _UploadStatus;

        //Constructor
        public UploadCompletedArgs(string Status, bool Completed)
        {
            this._UploadCompleted = Completed;
            this._UploadStatus = Status;
        }

        //Public Members
        public String UploadStatus { get { return _UploadStatus; } }
        public bool UploadCompleted { get { return _UploadCompleted; } }
    }
    #endregion



}
