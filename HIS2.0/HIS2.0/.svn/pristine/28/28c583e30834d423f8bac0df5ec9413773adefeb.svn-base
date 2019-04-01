using System;
using System.Collections.Generic;
using System.Text;
using ts_mzys_class;
using System.Threading;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using SpeechLib;


namespace ts_mzys_class
{
    /// <summary>
    /// 呼叫类 Add by Zp 2013-06-06
    /// </summary>
    public class VoiceHelp
    {
        
      
        ///// <summary>
        ///// 呼叫线程
        ///// </summary>
       // private Thread threadCall = null;

        // jianqg 修改 不限定使用捷通 2013-12-05 增加定义，并移除JTTS_ML.cs
       
        struct VoiceInfo
        {
            public bool init;//是否初始化了
            public int rate;
            public int voices;
            public int lolume;
        }
        private static VoiceInfo voiceInfo = new VoiceInfo();
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

                // jianqg 修改 不限定使用捷通 2013-12-05
                SpeechLib.SpVoice speech = new SpVoice();
                if (voiceInfo.init)
                {
                    speech.Voice = speech.GetVoices(string.Empty, string.Empty).Item(voiceInfo.voices);
                    speech.Volume = voiceInfo.lolume;
                 //   speech.Rate = voiceInfo.rate;
                }
               // speech.WaitUntilDone(-1);

                speech.Speak(callString, SpeechVoiceSpeakFlags.SVSFlagsAsync);


                //SpVoice speech1 = new SpVoice();
                //speech1.Voice = speech1.GetVoices(string.Empty, string.Empty).Item(3);
                //speech1.Rate = -1;
                //speech1.Volume = 100;
                //speech1.WaitUntilDone(-1);
                //speech1.Speak("测试", SpeechVoiceSpeakFlags.SVSFlagsAsync);//.
                //以下是 周鹏原来使用 捷通语音的 jianqg 2013-12-05  注释

              

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
                string RateValue = ApiFunction.GetIniString("分诊语音", "音速", Application.StartupPath + @"\ClientWindow.ini");
                // jianqg 修改 不限定使用捷通 2013-12-05
                int rateValue = -1;
                //语速
                bool flag_rate = int.TryParse(RateValue, out rateValue);
                if (flag_rate == false) rateValue = -1;
                
                voiceInfo.rate = rateValue;
                voiceInfo.init = true;//初始化完毕
             

                //以下是 周鹏原来使用 捷通语音的 jianqg 2013-12-05  注释
                //uint value=2;
                //uint.TryParse(RateValue, out value);
                //Jtts.jTTS_SetParam(Jtts.PARAM_SPEED, value); //调节语速


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

                // jianqg 修改 不限定使用捷通 2013-12-05
                SpVoice speech = new SpVoice();
                string VolumeValue = ApiFunction.GetIniString("分诊语音", "音量", Application.StartupPath + @"\ClientWindow.ini");
                string VoicesValue = ApiFunction.GetIniString("分诊语音", "语音库", Application.StartupPath + @"\ClientWindow.ini");
                int volumeValue = 100, voicesValue = -1;
                //音量
                bool flag_Volume = int.TryParse(VolumeValue, out volumeValue);
                if (flag_Volume == false) volumeValue = 100;
                #region // 语音库
                bool flag_Voice = int.TryParse(VoicesValue, out voicesValue);
                if (flag_Voice == false || voicesValue<0)
                {


                    int k = -1, k_jt = -1, k_ly = -1,k_ll = -1;//计算变量，捷通，lily,lili
                    foreach(ISpeechObjectToken Token in speech.GetVoices(string.Empty, string.Empty))
                    {
                    
                        //英文语音库
                        //Microsoft Anna - English (United States)
                        k++;
                        string yyk = Token.GetDescription(49);
                        //捷通
                        if (yyk.Contains("捷通") || yyk.ToUpper().Contains("JTTS")) 
                        {
                            k_jt = k;
                            //break ;
                        }
                        else if (yyk.ToLower().Contains("lili"))  
                        {
                            k_ll = k;
                            //break ;
                        }
                        else if (yyk.ToLower().Contains("lily"))
                        {
                            k_ly = k;
                            //break ;
                        }
                    }
                    if(k_jt>0) voicesValue=k_jt;
                    else if (k_ly > 0) voicesValue = k_ly;
                    else if(k_ll>0) voicesValue=k_ll;
                    if (voicesValue < 0) voicesValue = 0;
                }
                #endregion
                voiceInfo.voices = voicesValue;
                voiceInfo.lolume = volumeValue;



                //以下是 周鹏原来使用 捷通语音的 jianqg 2013-12-05  注释

                //int iErr = Jtts.jTTS_Init(null, null); //初始化JTTS语音库
                //Jtts.JTTS_CONFIG config = new Jtts.JTTS_CONFIG();
                //iErr = Jtts.jTTS_Get(out config);
                //if (iErr != 0)
                //{
                //    throw new Exception("当前机器未安装语音包!或语音包异常!");
                //}
                //config.nCodePage = (ushort)Encoding.Default.CodePage;
                //Jtts.jTTS_Set(ref config);
                
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
                //以下是 周鹏原来使用 捷通语音的 jianqg 2013-12-05  注释
                //Jtts.jTTS_End();
  
            }
            catch (Exception ea)
            {
                throw new Exception("释放语音包资源出现异常!原因:" + ea.Message);
            }
        }
        
     
    }
}
