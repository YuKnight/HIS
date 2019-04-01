using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ts_ReadCard
{
    public class ts_card_iDR210 : Icard
    {
        [DllImport("GWI_IDCard_Driver.dll", EntryPoint = "IDCard_SetDeviceParam")]
        private static extern int IDCard_SetDeviceParam(String deType, String com, String aud, StringBuilder reCode);

        [DllImport("GWI_IDCard_Driver.dll", EntryPoint = "IDCard_OpenDevice")]
        private static extern int IDCard_OpenDevice(StringBuilder reCode);

        [DllImport("GWI_IDCard_Driver.dll", EntryPoint = "IDCard_ReadIDCardMsg")]
        public static extern int IDCard_ReadIDCardMsg(int dwTimeOut, StringBuilder msg, StringBuilder reCode);

        [DllImport("GWI_IDCard_Driver.dll", EntryPoint = "IDCard_CloseDevice")]
        private static extern int IDCard_CloseDevice(StringBuilder reCode);

        [DllImport("GWI_CardReader_Driver.dll", EntryPoint = "Card_GetStatus")]
        private static extern int Card_GetStatus(int dwTimeOut, ref int status, StringBuilder reCode);

        [DllImport("sdtapi.dll")]
        private static extern int ReadIINSNDN(StringBuilder serial);

        //4.1.1.	端口初始化函数
        [DllImport("sdtapi.dll", EntryPoint = "InitComm")]
        public static extern int InitComm(int iPort);

        //4.1.2.	端口关闭接口
        [DllImport("sdtapi.dll", EntryPoint = "CloseComm")]
        public static extern int CloseComm();
        #region Icard 成员

        public bool ReadCard(ref IDCardData _idcarddata, ref string msg)
        {

            int ret;
            StringBuilder data = new StringBuilder();
            string cardno = "";
            int icdev = InitComm(1001);

            if (icdev == 1)
            {
                IDCardData cardData = new IDCardData();
                //读身份证号
                StringBuilder sbMsg = new StringBuilder();
                StringBuilder sbCode = new StringBuilder();
                sbMsg.Length = 127;
                ret = IDCard_SetDeviceParam("JingLun", "1001", "9600", sbCode);
                ret = IDCard_OpenDevice(sbCode);
                ret = IDCard_ReadIDCardMsg(5000, sbMsg, sbCode);
                if (ret != 0)
                {
                    CloseComm();
                    msg = "初始化错误";
                    return false;
                }
                string personInfo = "";
                if (ret == 0)
                {
                    personInfo = sbMsg.ToString();
                    string[] personNo = personInfo.Split(new char[] { '|' });
                    cardno = personNo[4].ToString();
                    _idcarddata.Name = personNo[0].Trim();
                    _idcarddata.Sex = personNo[1].Trim();
                    _idcarddata.Nation = personNo[2].Trim();
                    string bornday = personNo[3].Trim().Substring(0, 4) + "-" + personNo[3].Trim().Substring(4, 2) + "-" + personNo[3].Trim().Substring(6, 2);
                    _idcarddata.Born = bornday;
                    _idcarddata.IDCardNo = personNo[4].Trim();
                    _idcarddata.Address = personNo[5].Trim();
                    _idcarddata.GrantDept = personNo[6].Trim();
                    _idcarddata.UserLifeBegin = personNo[7].Trim();
                    _idcarddata.UserLifeEnd = personNo[8].Trim();
                }

                //读身份证管理号
                StringBuilder serial = new StringBuilder();
                ret = (ReadIINSNDN(serial) ^ 1);
                if (ret == 0)
                {
                    string personMNo = serial.ToString();
                    _idcarddata.reserved = personMNo;
                }
                else
                {
                }
                CloseComm();
                return true;
            }
            else
                return false;
        }

        public bool ReadCardToControl(ref IDCardData CardMsg, ref string msg, bool errAutoMsg, System.Windows.Forms.Control txtName, System.Windows.Forms.Control combXb, System.Windows.Forms.Control txtYear, System.Windows.Forms.Control txtMonth, System.Windows.Forms.Control txtDay, System.Windows.Forms.Control txtDz, System.Windows.Forms.Control txtSfz, System.Windows.Forms.Control comMz)
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

        public void ReadCardToControl(IDCardData CardMsg, System.Windows.Forms.Control txtName, System.Windows.Forms.Control combXb, System.Windows.Forms.Control txtYear, System.Windows.Forms.Control txtMonth, System.Windows.Forms.Control txtDay, System.Windows.Forms.Control txtDz, System.Windows.Forms.Control txtSfz, System.Windows.Forms.Control comMz)
        {
            bool flag = false;
            PubFun.ReadCardToControl(CardMsg, txtName, combXb, txtYear, txtMonth, txtDay, txtDz, txtSfz, comMz);
        }

        #endregion
    }
}
