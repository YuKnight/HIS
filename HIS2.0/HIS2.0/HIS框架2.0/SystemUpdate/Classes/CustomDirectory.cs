using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SystemUpdate
{
    public class CustomDirectory
    {
        public static string Path
        {
            get
            {
                string strDir = "";
                try
                {
                    string tmpDir = ApiFunction.GetIniString( "CUSTOMDIRRECTORY" , "DIRECTORY" , Application.StartupPath + "\\ClientConfig.ini" );
                    if ( tmpDir.Trim() != "" )
                    {
                        strDir = Crypto.Instance().Decrypto( tmpDir );
                    }
                    else
                    {
                        strDir = "";
                    }
                    #region 如果ini没有配置，获取数据库配置
                    if ( strDir.Trim() == "" )
                    {
                        Database database = new Database();
                        strDir = database.GetDbCustomDirectoryConfig();
                        if ( strDir == "" || !Directory.Exists( strDir ) )
                        {
                            throw new Exception( "参数0001配置错误" );
                        }
                        else
                        {
                            //写入ini
                            ApiFunction.WriteIniString( "CUSTOMDIRRECTORY" , "DIRECTORY" , Crypto.Instance().Encrypto( strDir ) ,
                                Application.StartupPath + "\\ClientConfig.ini" );
                        }
                    }
                    #endregion
                    if ( !Directory.Exists( strDir ) )			//如果该路径不存在则建立该目录
                    {
                        Directory.CreateDirectory( strDir );
                    }
                    if ( !File.Exists( strDir + "\\ClientConfig.ini" ) )	//如果配置文件不存在则从安装目录拷贝
                    {
                        File.Copy( Application.StartupPath + "\\ClientConfig.ini" , strDir + "\\ClientConfig.ini" , true );
                    }

                    return strDir;
                }
                catch(Exception err)
                {
                    throw err;
                }
            }
        }
    }
}
