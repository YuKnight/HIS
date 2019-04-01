using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace ts_ReadCard
{
    public class ts_card_xzx_DKQ_A16D_HF : Icard
    {
        /*
         * jianqg 2014-7-30 增加  新中新身份证 读卡，可以读身份证，（也可以读医院卡，功能不在这实现）
         * c:\必须有license.dat
         */

        #region api
        /************************端口类API *************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetCOMBaud(int iPort, ref uint puiBaudRate);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetCOMBaud(int iPort, uint uiCurrBaud, uint uiSetBaud);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_OpenPort", CharSet = CharSet.Ansi)]
        public static extern int Syn_OpenPort(int iPort);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ClosePort", CharSet = CharSet.Ansi)]
        public static extern int Syn_ClosePort(int iPort);
        /**************************SAM类函数 **************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetMaxRFByte", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetMaxRFByte(int iPort, byte ucByte, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ResetSAM", CharSet = CharSet.Ansi)]
        public static extern int Syn_ResetSAM(int iPort, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMStatus", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMStatus(int iPort, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMID", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMID(int iPort, ref byte pucSAMID, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMIDToStr", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMIDToStr(int iPort, ref byte pcSAMID, int iIfOpen);
        /*************************身份证卡类函数 ***************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_StartFindIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_StartFindIDCard(int iPort, ref byte pucIIN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SelectIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_SelectIDCard(int iPort, ref byte pucSN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsg(int iPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg, ref uint puiPHMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsgToFile(int iPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen, ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseFPMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseFPMsg(int iPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg, ref uint puiPHMsgLen, ref byte pucFPMsg, ref uint puiFPMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseFPMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseFPMsgToFile(int iPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen, ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, ref byte pcFPMsgFileName, ref uint puiFPMsgFileLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadNewAppMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadNewAppMsg(int iPort, ref byte pucAppMsg, ref uint puiAppMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetBmp", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetBmp(int iPort, ref byte Wlt_File);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadFPMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadFPMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData, ref byte cFPhotoname);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_FindReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindReader();
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_FindUSBReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindUSBReader();
        /***********************设置附加功能函数 ************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoPath", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoPath(int iOption, ref byte cPhotoPath);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoName", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoName(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetSexType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetSexType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetNationType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetNationType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetBornType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetBornType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetUserLifeBType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeBType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetUserLifeEType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeEType(int iType, int iOption);
        /***********************M1卡操作函数 (A16D-HF) ********************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_USBHIDM1Reset", CharSet = CharSet.Ansi)]
        public static extern int Syn_USBHIDM1Reset(int iPort, ref uint pdwCardSN, ref byte pbSize);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_USBHIDM1AuthenKey", CharSet = CharSet.Ansi)]
        public static extern int Syn_USBHIDM1AuthenKey(int iPort, byte KeyType, byte BlockNo, ref byte pKey);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_USBHIDM1ReadBlock", CharSet = CharSet.Ansi)]
        public static extern int Syn_USBHIDM1ReadBlock(int iPort, byte BlockNo, ref byte pBlock);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_USBHIDM1WriteBlock", CharSet = CharSet.Ansi)]
        public static extern int Syn_USBHIDM1WriteBlock(int iPort, byte BlockNo, ref byte pBlock);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_USBHIDM1Halt", CharSet = CharSet.Ansi)]
        public static extern int Syn_USBHIDM1Halt(int iPort);

        #endregion
        int iPort;

        #region  自动寻找USB读卡器
        /// <summary>
        /// 自动寻找USB读卡器
        /// </summary>
        /// <param name="err_text"></param>
        /// <returns></returns>
        private bool FindUSBReader(out string err_text)
        {



            err_text = "";
            iPort = 0;
            string stmp;

            uint[] iBaud = new uint[1];
            iPort = Syn_FindReader();

            if (iPort > 0)
            {
                if (iPort > 1000)
                {
                    stmp = Convert.ToString(iPort);
                    stmp = Convert.ToString(System.DateTime.Now) + "  读卡器连接在USB " + stmp;
 
                }
                else
                {
                    System.Threading.Thread.Sleep(200);
                    int nRet = Syn_GetCOMBaud(iPort, ref iBaud[0]);
                    stmp = Convert.ToString(iPort);
                    stmp = Convert.ToString(System.DateTime.Now) + "  读卡器连接在COM " + stmp + ";当前波特率为 " + Convert.ToString(iBaud[0]);


                }
                return true;
            }
            else
            {
                err_text = "没有找到读卡器";
                return false;

            }
            
        }
        #endregion

        #region 读取身份证信息
        /// <summary>
        /// 读取身份证信息
        /// </summary>
        /// <param name="CardMsg">IDCardData身份证信息</param>
        /// <param name="msg">提示信息</param>
        /// <returns>返回false表示有错误</returns>
        public bool ReadCard(ref IDCardData CardMsg, ref string msg)
        {

            bool bok = FindUSBReader(out msg);
            if (bok == false)
            {
                return bok;
            }


            int nRet, nPort, iPhotoType;
            String sText;
            byte[] cPath = new byte[255];
            byte[] pucIIN = new byte[4];
            byte[] pucSN = new byte[8];
            nPort = iPort;

            Syn_SetPhotoPath(1, ref cPath[0]);	//设置照片路径	iOption 路径选项	0=C:\	1=当前路径	2=指定路径
            //cPhotoPath	绝对路径,仅在iOption=2时有效
            iPhotoType = 0;
            Syn_SetPhotoType(0); //0 = bmp ,1 = jpg , 2 = base64 , 3 = WLT ,4 = 不生成
            Syn_SetPhotoName(2); // 生成照片文件名 0=tmp 1=姓名 2=身份证号 3=姓名_身份证号 

            //Syn_SetSexType(1);	// 0=卡中存储的数据	1=解释之后的数据,男、女、未知
            Syn_SetNationType(1);// 0=卡中存储的数据	1=解释之后的数据 2=解释之后加"族"
            //Syn_SetBornType(1);			// 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            //Syn_SetUserLifeBType(1);	// 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            //Syn_SetUserLifeEType(1, 1);	// 0=YYYYMMDD(不转换),1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD,
            //// 0=长期 不转换,	1=长期转换为 有效期开始+50年           
            if (Syn_OpenPort(nPort) == 0)
            {
                if (Syn_SetMaxRFByte(nPort, 60, 0) == 0)
                {
                    nRet = Syn_StartFindIDCard(nPort, ref pucIIN[0], 0);
                    nRet = Syn_SelectIDCard(nPort, ref pucSN[0], 0);
                    nRet = Syn_ReadMsg(nPort, 0, ref CardMsg);
                    if (nRet == 0)
                    {
                        //stmp = Convert.ToString(System.DateTime.Now) + "  姓名:" + CardMsg.Name;
                        //listBox1.Items.Add(stmp);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  性别:" + CardMsg.Sex;
                        //listBox1.Items.Add(stmp);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  民族:" + CardMsg.Nation;
                        //listBox1.Items.Add(stmp);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  出生日期:" + CardMsg.Born;
                        //listBox1.Items.Add(stmp);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  地址:" + CardMsg.Address;
                        //listBox1.Items.Add(stmp);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  身份证号:" + CardMsg.IDCardNo;
                        //listBox1.Items.Add(stmp);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  发证机关:" + CardMsg.GrantDept;
                        //listBox1.Items.Add(stmp);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  有效期开始:" + CardMsg.UserLifeBegin;
                        //listBox1.Items.Add(stmp);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  有效期结束:" + CardMsg.UserLifeEnd;
                        //listBox1.Items.Add(stmp);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  照片文件名:" + CardMsg.PhotoFileName;

                        CardMsg.Address = CardMsg.Address.Trim();
                        CardMsg.Name = CardMsg.Name.Trim();
                        CardMsg.GrantDept = CardMsg.GrantDept.Trim();
                        //Syn_DelPhotoFile();
                        CardMsg.Born = CardMsg.Born.Trim().Substring(0, 4) + "年" + CardMsg.Born.Trim().Substring(4, 2) + "月" + CardMsg.Born.Trim().Substring(6, 2) + "日";
                        CardMsg.Sex = CardMsg.Sex == "2" ? "女" : "男";
                        bok= true;

                    }
                    else
                    {
                        sText = "读二代证信息错误!";
                        msg = sText.ToString();
                        bok= false;

                    }
                }
            }
            else
            {
                msg = Convert.ToString(System.DateTime.Now) + "  打开端口失败";
                bok= false;
   
            }
            Syn_ClosePort(nPort);
            return bok;

        }
        #endregion
        #region  读取身份证信息到控件
        /// <summary>
        /// 读取身份证信息到控件
        /// </summary>
        /// <param name="CardMsg"></param>
        /// <param name="msg">错误提示信息</param>
        /// <param name="errAutoMsg">错误时是否自动弹出提示窗口</param>
        /// <param name="txtName">姓名</param>
        /// <param name="combXb">性别</param>
        /// <param name="txtYear">（出生年月）年</param>
        /// <param name="txtMonth">（出生年月）月</param>
        /// <param name="txtDay">（出生年月）日</param>
        /// <param name="txtDz">住址、地址</param>
        /// <param name="txtSfz">身份证号</param>
        /// <param name="comMz">民族</param>
        /// <returns></returns>
        public bool ReadCardToControl(ref IDCardData CardMsg, ref string msg, bool errAutoMsg,
            Control txtName,Control combXb,Control txtYear,Control txtMonth,Control txtDay,Control txtDz,Control txtSfz,Control comMz )
        {

            bool flag = this.ReadCard(ref CardMsg, ref msg);
            if (flag)
            {
                this.ReadCardToControl(CardMsg, txtName, combXb, txtYear, txtMonth, txtDay, txtDz, txtSfz, comMz);
            }
            else  if (errAutoMsg == true)
            {
                MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            
            return flag;

        }
        #endregion
        #region  读取身份证信息到控件
        /// <summary>
        /// 将CardMsg信息 设置到控件
        /// </summary>
        /// <param name="CardMsg"></param>
        /// <param name="txtName">姓名</param>
        /// <param name="combXb">性别</param>
        /// <param name="txtYear">（出生年月）年</param>
        /// <param name="txtMonth">（出生年月）月</param>
        /// <param name="txtDay">（出生年月）日</param>
        /// <param name="txtDz">住址、地址</param>
        /// <param name="txtSfz">身份证号</param>
        /// <param name="comMz">民族</param>
        /// <returns></returns>
        public void ReadCardToControl(IDCardData CardMsg,
            Control txtName, Control combXb, Control txtYear, Control txtMonth, Control txtDay, Control txtDz, Control txtSfz, Control comMz)
        {

            bool flag = false;
            PubFun.ReadCardToControl(CardMsg, txtName, combXb, txtYear, txtMonth, txtDay, txtDz, txtSfz, comMz);
        }
        #endregion

         #region 带指纹
        //带指纹
        private void button31_Click(object sender, EventArgs e)
        {
            //IDCardData CardMsg = new IDCardData();
            //int nRet, nPort, iPhotoType;
            //string stmp;
            //byte[] cPath = new byte[255];
            //byte[] pucIIN = new byte[4];
            //byte[] pucSN = new byte[8];
            //byte[] ucPath = new byte[256];
            //nPort = m_iPort;
            //if (pictureBox1.Image != null)
            //{
            //    pictureBox1.Image.Dispose();
            //    pictureBox1.Image = null;
            //}
            //Syn_SetPhotoPath(0, ref cPath[0]);	//设置照片路径	iOption 路径选项	0=C:	1=当前路径	2=指定路径
            ////cPhotoPath	绝对路径,仅在iOption=2时有效
            //iPhotoType = 0;
            //Syn_SetPhotoType(0); //0 = bmp ,1 = jpg , 2 = base64 , 3 = WLT ,4 = 不生成
            //Syn_SetPhotoName(2); // 生成照片文件名 0=tmp 1=姓名 2=身份证号 3=姓名_身份证号 

            //Syn_SetSexType(1);	// 0=卡中存储的数据	1=解释之后的数据,男、女、未知
            //Syn_SetNationType(1);// 0=卡中存储的数据	1=解释之后的数据 2=解释之后加"族"
            //Syn_SetBornType(1);			// 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            //Syn_SetUserLifeBType(1);	// 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            //Syn_SetUserLifeEType(1, 1);	// 0=YYYYMMDD(不转换),1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD,
            //// 0=长期 不转换,	1=长期转换为 有效期开始+50年           
            //if (Syn_OpenPort(nPort) == 0)
            //{
            //    if (Syn_SetMaxRFByte(nPort, 60, 0) == 0)
            //    {
            //        nRet = Syn_StartFindIDCard(nPort, ref pucIIN[0], 0);
            //        nRet = Syn_SelectIDCard(nPort, ref pucSN[0], 0);
            //        nRet = Syn_ReadFPMsg(nPort, 0, ref CardMsg, ref ucPath[0]);
            //        if (nRet == 0 || nRet == 1)
            //        {
            //            stmp = Convert.ToString(System.DateTime.Now) + "  姓名:" + CardMsg.Name;
            //            listBox1.Items.Add(stmp);
            //            stmp = Convert.ToString(System.DateTime.Now) + "  性别:" + CardMsg.Sex;
            //            listBox1.Items.Add(stmp);
            //            stmp = Convert.ToString(System.DateTime.Now) + "  民族:" + CardMsg.Nation;
            //            listBox1.Items.Add(stmp);
            //            stmp = Convert.ToString(System.DateTime.Now) + "  出生日期:" + CardMsg.Born;
            //            listBox1.Items.Add(stmp);
            //            stmp = Convert.ToString(System.DateTime.Now) + "  地址:" + CardMsg.Address;
            //            listBox1.Items.Add(stmp);
            //            stmp = Convert.ToString(System.DateTime.Now) + "  身份证号:" + CardMsg.IDCardNo;
            //            listBox1.Items.Add(stmp);
            //            stmp = Convert.ToString(System.DateTime.Now) + "  发证机关:" + CardMsg.GrantDept;
            //            listBox1.Items.Add(stmp);
            //            stmp = Convert.ToString(System.DateTime.Now) + "  有效期开始:" + CardMsg.UserLifeBegin;
            //            listBox1.Items.Add(stmp);
            //            stmp = Convert.ToString(System.DateTime.Now) + "  有效期结束:" + CardMsg.UserLifeEnd;
            //            listBox1.Items.Add(stmp);
            //            stmp = Convert.ToString(System.DateTime.Now) + "  照片文件名:" + CardMsg.PhotoFileName;
            //            listBox1.Items.Add(stmp);
            //            ASCIIEncoding encoding = new ASCIIEncoding();
            //            stmp = Convert.ToString(System.DateTime.Now) + "  指纹信息文件名:" + encoding.GetString(ucPath, 0, 256);  //Convert.ToString(ucPath[0]);
            //            listBox1.Items.Add(stmp);
            //            if (iPhotoType == 0 || iPhotoType == 1)
            //            {
            //                pictureBox1.Image = Image.FromFile(CardMsg.PhotoFileName);
            //            }
            //        }
            //        else
            //        {
            //            stmp = Convert.ToString(System.DateTime.Now) + "  读取身份证信息错误";
            //            listBox1.Items.Add(stmp);
            //        }
            //    }
            //}
            //else
            //{
            //    stmp = Convert.ToString(System.DateTime.Now) + "  打开端口失败";
            //    listBox1.Items.Add(stmp);
            //}
            //Syn_ClosePort(nPort);
        }
         #endregion
    }
}
