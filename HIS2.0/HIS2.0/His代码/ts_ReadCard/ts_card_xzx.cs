using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace ts_ReadCard
{
    public class ts_card_xzx:Icard
    {

        #region api
        /************************端口类API *************************/
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_GetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetCOMBaud(int iComID, ref uint puiBaud);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_SetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetCOMBaud(int iComID, uint uiCurrBaud, uint uiSetBaud);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_OpenPort", CharSet = CharSet.Ansi)]
        public static extern int Syn_OpenPort(int iPortID);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_ClosePort", CharSet = CharSet.Ansi)]
        public static extern int Syn_ClosePort(int iPortID);

        /************************ SAM类API *************************/
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_GetSAMStatus", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMStatus(int iPortID, int iIfOpen);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_ResetSAM", CharSet = CharSet.Ansi)]
        public static extern int Syn_ResetSAM(int iPortID, int iIfOpen);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_GetSAMID", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMID(int iPortID, ref byte pucSAMID, int iIfOpen);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_GetSAMIDToStr", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMIDToStr(int iPortID, ref byte pcSAMID, int iIfOpen);
        /********************身份证卡类API *************************/
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_StartFindIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_StartFindIDCard(int iPortID, ref byte pucManaInfo, int iIfOpen);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_SelectIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_SelectIDCard(int iPortID, ref byte pucManaMsg, int iIfOpen);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_ReadMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_ReadCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadCard(out   IDCardData pIDCardData, int Rmode);
        /********************附加类API *****************************/
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_SendSound", CharSet = CharSet.Ansi)]
        public static extern int Syn_SendSound(int iCmdNo);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_DelPhotoFile", CharSet = CharSet.Ansi)]
        public static extern void Syn_DelPhotoFile();
        #endregion
        int iPort;

        #region 打开端口
        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="err_text"></param>
        /// <returns></returns>
        private bool Openport(out string err_text)
        {
            iPort = 0;
            for (iPort = 1001; iPort < 1017; iPort++)
            {
                if (Syn_OpenPort(iPort) == 0)
                {
                    if (Syn_GetSAMStatus(iPort, 0) == 0)
                    {
                        Syn_ClosePort(iPort);
                        err_text = "读卡器连接在" + iPort + "USB端口上";
                        return true;
                    }
                }
                Syn_ClosePort(iPort);
            }
            for (iPort = 1; iPort < 17; iPort++)
            {
                if (Syn_OpenPort(iPort) == 0)
                {
                    if (Syn_GetSAMStatus(iPort, 0) == 0)
                    {
                        Syn_ClosePort(iPort);
                        err_text = "读卡器连接在串口" + iPort + "上";
                        return true;
                    }
                }
               
            }
            Syn_ClosePort(iPort);
            err_text = "没有连接读卡器";
            return false;
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

            bool bok = Openport(out msg);
            if (bok == false)
            {
                return bok;
            }
            String sText;
            byte[] pucIIN = new byte[4];
            byte[] pucSN = new byte[8];
            int nRet = Syn_OpenPort(iPort);
            if (nRet == 0)
            {
                nRet = Syn_GetSAMStatus(iPort, 0);
                nRet = Syn_StartFindIDCard(iPort, ref pucIIN[0], 0);
                nRet = Syn_SelectIDCard(iPort, ref pucSN[0], 0);
                nRet = Syn_ReadMsg(iPort, 0, ref CardMsg);
                if ( nRet == 0)
                {
                    nRet = Syn_ClosePort(iPort);
                    nRet = Syn_ResetSAM(iPort, 0);
                    CardMsg.Address = CardMsg.Address.Trim();
                    CardMsg.Name = CardMsg.Name.Trim();
                    CardMsg.GrantDept = CardMsg.GrantDept.Trim();
                    CardMsg.Born= CardMsg.Born.Trim().Substring(0, 4) + "年" + CardMsg.Born.Trim().Substring(4, 2) + "月" + CardMsg.Born.Trim().Substring(6, 2) + "日";
                    CardMsg.Sex=CardMsg.Sex=="2"?"女":"男";
                    return true;
                   
                }
                else
                {
                    sText = "读二代证信息错误!";
                    msg = sText.ToString();
                    Syn_ClosePort(iPort);
                    return false;
                }
            }
            else
            {
                sText = "打开端口错误";
                msg = sText.ToString();
                Syn_ClosePort(iPort);
                return false;
            }

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
    }
}
