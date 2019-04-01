using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;

namespace TrasenFrame.Classes
{
    /// <summary>
    /// 应用程序环境对象
    /// </summary>
    public class AppEnvironment
    {
        private XmlDocument document = new XmlDocument();
        private string xmlFile = string.Format( "{0}\\AppEnviroment.xml" , System.Windows.Forms.Application.StartupPath );
        /// <summary>
        /// 构造
        /// </summary>
        public AppEnvironment()
        {
            if ( !System.IO.File.Exists( xmlFile ) )
                CreateXmlFile();
            document.Load( xmlFile );
        }

        private void CreateXmlFile()
        {
            XmlNode rootNode = document.CreateElement( "Enviroument" );

            XmlNode backImageNode = document.CreateElement( "BackgroundImage" );

            rootNode.AppendChild( backImageNode );

            document.AppendChild( rootNode );

            document.Save( xmlFile );
        }
        /// <summary>
        /// 获取背景图，如果没有找到，则返回默认的图片
        /// </summary>
        /// <param name="loginCode"></param>
        /// <returns></returns>
        public Image GetBackgroundImage( string loginCode)
        {
            string imageName = string.Empty;
            bool isFile = false;
            return GetBackgroundImage( loginCode , out imageName , out isFile );
        }
        /// <summary>
        /// 获取背景图
        /// </summary>
        /// <returns></returns>
        public Image GetBackgroundImage(string loginCode,out string ImageName ,out bool IsFile)
        {
            XmlNode rootNode = document.ChildNodes[0];
            XmlNode bkImageNode = document.GetElementsByTagName( "BackgroundImage" )[0];
            bool isFile = false;
            string imageName = "ts008.JPG"; //默认图片
            Image image = null;
            if ( TrasenFrame.Forms.FrmMdiMain.FRAMEKIND != TrasenFrame.Classes.FrameKind.公司 )
            {
                //东软的就一幅图，不能设置自定义，可以写死
                switch ( TrasenFrame.Forms.FrmMdiMain.FRAMEKIND )
                {
                    case FrameKind.东软:
                        imageName = "ehis.JPG";
                        break;
                    case FrameKind.弘麒:
                        imageName = "OnKiy.JPG";
                        break;
                }
                System.IO.Stream strm = this.GetType().Assembly.GetManifestResourceStream( "TrasenFrame.Forms.Background." + imageName );
                if ( strm != null )
                    image = Image.FromStream( strm );
            }            
            else
            {
                foreach ( XmlNode node in bkImageNode )
                {
                    if ( node.Attributes["loginCode"].Value.Equals( loginCode ) )
                    {
                        isFile = node.Attributes["imageType"].Value == "file" ? true : false;
                        imageName = node.InnerText;
                        break;
                    }
                }

                if ( isFile )
                {
                    if ( System.IO.File.Exists( imageName ) )
                        image = Image.FromFile( imageName );
                }
                if ( image == null )
                {
                    System.IO.Stream strm = this.GetType().Assembly.GetManifestResourceStream( "TrasenFrame.Forms.Background." + imageName );
                    if ( strm != null )
                        image = Image.FromStream( strm );
                }
            }
            ImageName = imageName;
            IsFile = isFile;
            return image;
        }
        /// <summary>
        /// 设置背景图
        /// </summary>
        /// <param name="loginCode"></param>
        /// <param name="imageName"></param>
        /// <param name="IsFile"></param>
        public void SetBackgroundImage( string loginCode , string imageName , bool IsFile )
        {
            XmlNode rootNode = document.ChildNodes[0];
            XmlNode bkImageNode = document.GetElementsByTagName( "BackgroundImage" )[0];
            foreach ( XmlNode node in bkImageNode.ChildNodes )
            {
                if ( node.Attributes["loginCode"].Value.Equals( loginCode ) )
                {
                    node.Attributes["imageType"].Value = ( IsFile ? "file" : "resourse" );
                    node.InnerText = imageName;
                    document.Save( xmlFile );
                    return;
                }
            }

            XmlNode subNode = document.CreateElement( "Image" );
            XmlAttribute attrLoginCode = document.CreateAttribute( "loginCode" );
            attrLoginCode.Value = loginCode;
            XmlAttribute attrType = document.CreateAttribute( "imageType" );
            attrType.Value = ( IsFile ? "file" : "resourse" );
            subNode.Attributes.Append( attrLoginCode );
            subNode.Attributes.Append( attrType );
            subNode.InnerText = imageName;

            bkImageNode.AppendChild( subNode );
            document.Save( xmlFile );
        }
    }
}
