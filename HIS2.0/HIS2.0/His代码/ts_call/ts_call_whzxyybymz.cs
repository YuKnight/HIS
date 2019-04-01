using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using System.IO;

namespace ts_call
{
    public class ts_call_whzxyybymz : Icall
    {
        public ts_call_whzxyybymz()
        {

        }

        string _winNum;
        public string WindowNum
        {
            get
            {                
                return _winNum;
            }
            set
            {
                _winNum = value;
                if (!string.IsNullOrEmpty(_winNum))
                {
                    SetXspMac();
                }
            }
        }

        string _mac = null;
        public string Mac
        {
            get
            {
                return _mac;
            }
            set
            {
                _mac = value;
            }
        }

        string _brkh;
        /// <summary>
        /// 病人卡号
        /// </summary>
        public string Brkh
        {
            get
            {
                return _brkh;
            }
            set
            {
                _brkh = value;
            }
        }

        int _qyzt;
        /// <summary>
        /// 取药状态 1:叫号标识  2：已取药标识
        /// </summary>
        public int Qyzt
        {
            get
            {
                return _qyzt;
            }
            set
            {
                _qyzt = value;
            }
        }

        #region Icall 成员
        private Thread td;
        public System.Threading.Thread CurrentThread
        {
            get
            {
                return td;
            }
            set
            {
                td = value;
            }
        }

        public void Call(DmType dmtype, string callstring)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Call(string ss, string zl)
        {

        }

        public void Call(DmType dmtype, string callstring, double je)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX)
        {
            if (string.IsNullOrEmpty(WindowNum) || string.IsNullOrEmpty(Mac) || string.IsNullOrEmpty(Brkh))
            {
                return;
            }
            if (Qyzt != 1 && Qyzt != 2)
                return;           
            string paramInfo = string.Format(@"<patient_info>
                                               <patientid>{0}</patientid>
                                               <patientname>{1}</patientname>
                                               <patientstate>{2}</patientstate>
                                               <disportnumber>{3}</disportnumber>
                                               </patient_info>", Brkh, callstring, Qyzt, WindowNum);

            Whzxyybyjh.WebServiceTerminalCall server = new global::ts_call.Whzxyybyjh.WebServiceTerminalCall();
            server.CallDrug(paramInfo, Mac);
        }

        /// <summary>
        /// 设置窗口号对应显示屏的mac
        /// </summary>
        private void SetXspMac()
        {
            string filePath = string.Format("{0}/{1}", Constant.ApplicationDirectory, "ClinicCallingNorthHospital.xml");
            if (File.Exists(filePath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNode currentNode = doc.SelectSingleNode("WhByMzjh");
                XmlNodeList nodeList = currentNode.ChildNodes;
                if (nodeList != null && nodeList.Count > 0)
                {
                    foreach (XmlNode tn in nodeList)
                    {
                        XmlElement xe = tn as XmlElement;
                        if (xe != null && xe.GetAttribute("ID") == WindowNum)
                        {
                            _mac = xe.GetAttribute("MAC");
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region Icall 成员


        public void SetPicture(string picturename)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
