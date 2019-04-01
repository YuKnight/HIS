using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ts_ReadCard
{
    public class ts_card_ShenSi:Icard
    {
        #region api
        /*
         * jianqg xiayu 神思的身份证接口,其实完全可以用新中新的
         * ,只需要安装Usb驱动,覆盖3个WltRS.dll,sdtapi.dll文件(包括读卡的dll),用神思 安装复杂,需要授权
         * /
        * 
        ************************API类 *************************/

        //0x41:	初始化端口
            //0x42:	关闭端口
            //0x43:	验证卡
            //0x44:	读基本信息
            //0x45:	读最新住址信息
            //0x46:	仅读文字信息
            //0x47:	读基本信息但不进行图像解码
        [DllImport("ShenSi_RdCard.dll")]
        public static extern int UCommand(ref byte pcmd, ref int parg0, ref int parg1, ref int parg2);
        #endregion
        private int iPort;//USB端口号
        private  int para1 = 8811, para2 = 9986;

        #region 打开端口 或关闭端口
        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="err_text"></param>
        /// <returns></returns>
        public bool Openport(out string err_text)
        {

            iPort = 0;
            //USB
            for (int i = 1001; i < 1017; i++)
            {
                if (Testport(i, true, out err_text))
                {
                    iPort = i;
                    return true;
                }
            }
            //串口
            for (int i = 1; i < 17; i++)
            {
                if (Testport(i, false, out err_text))
                {
                    iPort = i;
                    return true;
                  }

            }
            Closeport(iPort); //关闭端口或串口
            err_text = "神思读卡器连接失败";
            return false;
        }
        /// <summary>
        /// 关闭端口或串口方法
        /// </summary>
        /// <param name="port">端口或者串口号ID</param>
        /// <returns></returns>
        private bool Closeport(int port)
        {
            byte cmd = 0x42;//0x42 关闭端口参数
            int  para1 = 8811, para2 = 9986;
            int iRetVal = UCommand(ref cmd, ref port, ref para1, ref para2);
            if (iRetVal == 62171) return true;
            else return false;
        }
        #endregion
        #region 测试端口连接(打开并关闭)
        /// <summary>
        /// 测试端口连接(打开并关闭)
        /// </summary>
        private bool Testport(int portTmp,bool IsUsb, out string err_text)
        {
            byte cmd = 65;//0x41初始化端口;
            int para0 = portTmp;
            int iRetVal = UCommand(ref cmd, ref para0, ref para1, ref para2);
            string msg = "串口";
            if (IsUsb) msg = "USB";

            if (iRetVal == 62171)
            {
                Closeport(portTmp);
                err_text = "神思读卡器连接成功, 在" + portTmp.ToString() +  msg + "端口上";
                return true;
            }
            else
            {
                Closeport(portTmp);
                err_text = "";
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

            try
            {
                #region 打开端口-验证卡-读卡
                bool bok = Openport(out msg);
                if (bok == false)
                {
                    return bok;
                }

                byte cmd = 67; //0x43 //验证卡
                int nRet = UCommand(ref cmd, ref iPort, ref para1, ref para2);  //验证卡
                if (nRet != 62171)
                {
                    msg = "验证卡失败,请重新放卡再试";
                    return false;
                }
                cmd = 68;//0x44 读卡内信息
                nRet = UCommand(ref cmd, ref iPort, ref para1, ref para2);  //读卡
                Closeport(iPort);
                #endregion
                #region 读取信息
                if (nRet == 62171)
                {
                    #region 读取详细信息
                    string fileName = Application.StartupPath + "\\wx.txt";//获取文件路径
                    System.IO.StreamReader streamReader = new System.IO.StreamReader(fileName, Encoding.GetEncoding("GBK"));//将文件定义编码

                    string[] sData = streamReader.ReadToEnd().ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);//将字符串截取并存入到数组当中

                    streamReader.Close();
                    if (sData.Length >= 9)
                    {
                        CardMsg.Name = sData[0].Trim();//将身份信息赋值
                        CardMsg.Sex = sData[1].Trim();
                        CardMsg.Nation = sData[2].Trim();
                        CardMsg.Born = sData[3].Trim();
                        CardMsg.Born = Convert.ToDateTime(CardMsg.Born).ToString("yyyy年MM月dd日");
                        CardMsg.Address = sData[4].Trim();
                        CardMsg.IDCardNo = sData[5].Trim();
                        CardMsg.GrantDept = sData[6].Trim();
                        CardMsg.UserLifeBegin = sData[7].Trim();
                        CardMsg.UserLifeBegin = Convert.ToDateTime(CardMsg.UserLifeBegin).ToString("yyyyMMdd");
                        CardMsg.UserLifeEnd = sData[8].Trim();
                        CardMsg.UserLifeEnd = Convert.ToDateTime(CardMsg.UserLifeEnd).ToString("yyyyMMdd");
                        CardMsg.PhotoFileName = Application.StartupPath + "\\zp.bmp";//获取照片文件路径
                        return true;
                    }
                    else
                    {
                        msg = "读取身份证信息不完整";
                        return false;
                    }
                    #endregion
                }
                else if (nRet == -5)
                {
                    msg = "神思读卡器没有授权";
                    return false;

                }
                else
                {
                    msg = "读卡失败";
                    return false;
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("发生错误" + ex.Message);
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
            Control txtName, Control combXb, Control txtYear, Control txtMonth, Control txtDay, Control txtDz, Control txtSfz, Control comMz)
        {

            bool flag = this.ReadCard(ref CardMsg, ref msg);
            if (flag)
            {
                this.ReadCardToControl(CardMsg, txtName, combXb, txtYear, txtMonth, txtDay, txtDz, txtSfz, comMz);
            }
            else if (errAutoMsg == true)
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
