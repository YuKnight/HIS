using System;
using System.Collections.Generic;
using System.Text;
using ts_mzys_class;
using System.Threading;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;


namespace ts_mzys_class
{
    /// <summary>
    /// 呼叫类 Add by Zp 2013-06-06
    /// </summary>
    public class VoiceHelp
    {
        
      
        /// <summary>
        /// 呼叫线程
        /// </summary>
       // private Thread threadCall = null;

        public VoiceHelp()
        {
          
        }

        /// <summary>
        /// 语音朗诵
        /// </summary>
        /// <param name="message">朗诵信息</param>
        /// <param name="msg">返回的异常信息</param>
        public void VoiceSpeak(string callString,ref string msg)
        {
            try
            {
                if (callString.Trim() == "")
                    return;

                int iErr = Jtts.jTTS_Play(callString, 0);
               
                if (Jtts.ERR_NONE != iErr)
                {
                    msg = "语音包错误!错误号:" + iErr.ToString();
                    return;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }
        /// <summary>
        /// 调整语音朗诵对象的语速
        /// </summary>
        public void VoiceRate()
        {
            try
            {
                string RateValue = ApiFunction.GetIniString("分诊系统呼叫速度调节", "Rate", Application.StartupPath + @"\ClientWindow.ini");
                uint value=2;
                uint.TryParse(RateValue, out value);
                Jtts.jTTS_SetParam(Jtts.PARAM_SPEED, value); //调节语速
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

    

       /// <summary>
       /// 初始化语音库
       /// </summary>
        public void InitializeVoiceLib()
        {
            try
            {
                int iErr = Jtts.jTTS_Init(null, null); //初始化JTTS语音库
                Jtts.JTTS_CONFIG config = new Jtts.JTTS_CONFIG();
                iErr = Jtts.jTTS_Get(out config);
                if (iErr != 0)
                {
                    throw new Exception("当前机器未安装语音包!或语音包异常!");
                }
                config.nCodePage = (ushort)Encoding.Default.CodePage;
                Jtts.jTTS_Set(ref config);
                
                VoiceRate();
            }
            catch (Exception ea)
            {
                throw new Exception("初始化语音库出现异常!原因:" + ea.Message);
            }
        }
        /// <summary>
        /// 释放语音库资源
        /// </summary>
        public void DisposeVoice()
        {
            try
            {
                Jtts.jTTS_End();
            }
            catch (Exception ea)
            {
                throw new Exception("释放语音包资源出现异常!原因:" + ea.Message);
            }
        }
        
     
    }
}
