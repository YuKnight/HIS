using System;
using System.Runtime.InteropServices;

namespace ts_mzys_class
{
	/// <summary>
	/// 维护记录
	/// -------------------------------------------------------------
	/// 2004-4-5
	/// 根据jTTS_ML.h改写，封装了大部分的常量、结构和接口函数。
	/// 缺少消息和回调函数部分以及底层合成函数部分。
	/// 此代码要随着jTTS_ML.h的改动而改动。
	///								WangYi
	/// </summary>
	public class Jtts
	{
		//-----------------------------------------------------------
		//ERR_XXX 函数的返回值
		public const int ERR_NONE				= 0; 
		public const int ERR_ALREADYINIT		= 1;
		public const int ERR_NOTINIT			= 2;
		public const int ERR_MEMORY				= 3;
		public const int ERR_INVALIDHWND		= 4;
		public const int ERR_INVALIDFUNC		= 5;
		public const int ERR_OPENLIB			= 6;
		public const int ERR_READLIB			= 7;
		public const int ERR_PLAYING			= 8;
		public const int ERR_DONOTHING			= 9;
		public const int ERR_INVALIDTEXT		= 10;
		public const int ERR_CREATEFILE			= 11;
		public const int ERR_WRITEFILE			= 12;
		public const int ERR_FORMAT				= 13;
		public const int ERR_INVALIDSESSION		= 14;
		public const int ERR_TOOMANYSESSION		= 15;
		public const int ERR_MORETEXT			= 16;
		public const int ERR_CONFIG				= 17;
		public const int ERR_OPENDEVICE			= 18;
		public const int ERR_RESETDEVICE		= 19;
		public const int ERR_PAUSEDEVICE		= 20;
		public const int ERR_RESTARTDEVICE		= 21;
		public const int ERR_STARTTHREAD		= 22;
		public const int ERR_BEGINOLE			= 23;
		public const int ERR_NOTSUPPORT			= 24;
		public const int ERR_SECURITY			= 25;
		public const int ERR_CONVERT			= 26;
		public const int ERR_PARAM				= 27;
		public const int ERR_INPROGRESS			= 28;
		public const int ERR_INITSOCK			= 29;
		public const int ERR_CREATESOCK			= 30;
		public const int ERR_CONNECTSOCK		= 31;
		public const int ERR_TOOMANYCON			= 32;
		public const int ERR_CONREFUSED			= 33;
		public const int ERR_SEND				= 34;
		public const int ERR_RECEIVE			= 35;
		public const int ERR_SERVERSHUTDOWN		= 36;
		public const int ERR_OUTOFTIME			= 37;
		public const int ERR_CONFIGTTS			= 38;
		public const int ERR_SYNTHTEXT			= 39;
		public const int ERR_CONFIGVERSION		= 40;
		public const int ERR_EXPIRED			= 41;
		public const int ERR_NEEDRESTART		= 42;
		public const int ERR_CODEPAGE			= 43;
		public const int ERR_ENGINE				= 44;
		public const int ERR_CREATEEVENT		= 45;
		public const int ERR_PLAYMODE			= 46;
		public const int ERR_OPENFILE			= 47;
		public const int ERR_USERABORT			= 48;

		//---------------------------------------------------------------------------
		// 系统的设置选项

		//支持多语种
		//
		//这里列出的是系统内建的语言定义，需要安装相应音库才能真正支持, 
		//但目前并非所有语言都有相应的音库
		//
		//对于这里没有列出的语言，将来也可能会发布相应的音库，同时会分配一个数值，
		//只要安装此音库后，就可以使用。对于没有列出的语言，如果想使用，可以直接使用数值
		//
		//可以通过Lang系列函数得到所有系统中定义的（包括将来扩展的）语言数值及其描述的信息
		//
		//对于系统中真正支持的语言，可以通过jTTS_GetVoiceCount, jTTS_GetVoiceAttribute函数
		//得到所有安装的音库，并从其属性中知道其语言

        /// <summary>
        /// 汉语普通话
        /// </summary>
		public const int LANGUAGE_MANDARIN				= 0;	// 汉语普通话
        /// <summary>
        /// 广东话
        /// </summary>
		public const int LANGUAGE_CANTONESE				= 1;	// 广东话
        /// <summary>
        /// 汉化普通话
        /// </summary>
		public const int LANGUAGE_CHINESE				= LANGUAGE_MANDARIN;
        /// <summary>
        /// 美国英语
        /// </summary>
		public const int LANGUAGE_US_ENGLISH			= 10;	// 美国英语
        /// <summary>
        /// 英国英语
        /// </summary>
		public const int LANGUAGE_BRITISH_ENGLISH		= 11;	// 英国英语
        /// <summary>
        /// 英语
        /// </summary>
		public const int LANGUAGE_ENGLISH				= LANGUAGE_US_ENGLISH;
        /// <summary>
        /// 法语
        /// </summary>
		public const int LANGUAGE_FRENCH				= 20;	// 法语
        /// <summary>
        /// 加拿大法语
        /// </summary>
		public const int LANGUAGE_CANADIAN_FRENCH		= 21;	// 加拿大法语
        /// <summary>
        /// 西班牙语
        /// </summary>
		public const int LANGUAGE_SPANISH				= 30;	// 西班牙语
        /// <summary>
        /// 拉丁美洲西班牙语
        /// </summary>
		public const int LANGUAGE_LATINAMERICAN_SPANISH	= 31;	// 拉丁美洲西班牙语
        /// <summary>
        /// 葡萄牙语
        /// </summary>
		public const int LANGUAGE_PORTUGUESE			= 40;	// 葡萄牙语
        /// <summary>
        /// 巴西葡萄牙语
        /// </summary>
		public const int LANGUAGE_BRAZILIAN_PORTUGUESE	= 41;	// 巴西葡萄牙语
        /// <summary>
        /// 荷兰语
        /// </summary>
		public const int LANGUAGE_DUTCH					= 50;	// 荷兰语
        /// <summary>
        /// 比利时荷兰语
        /// </summary>
		public const int LANGUAGE_BELGIAN_DUTCH			= 51;	// 比利时荷兰语
        /// <summary>
        /// 德语
        /// </summary>
		public const int LANGUAGE_GERMAN				= 60;	// 德语
        /// <summary>
        /// 意大利语
        /// </summary>
		public const int LANGUAGE_ITALIAN				= 70;	// 意大利语
        /// <summary>
        /// 瑞典语
        /// </summary>
		public const int LANGUAGE_SWEDISH				= 80;	// 瑞典语
        /// <summary>
        /// 挪威语
        /// </summary>
		public const int LANGUAGE_NORWEGIAN				= 90;	// 挪威语
        /// <summary>
        /// 丹麦语
        /// </summary>
		public const int LANGUAGE_DANISH				= 100;	// 丹麦语
        /// <summary>
        /// 波兰语
        /// </summary>
		public const int LANGUAGE_POLISH				= 110;	// 波兰语
        /// <summary>
        /// 希腊语
        /// </summary>
		public const int LANGUAGE_GREEK					= 120;	// 希腊语
        /// <summary>
        /// 匈牙利语
        /// </summary>
		public const int LANGUAGE_HUNGARIAN				= 130;	// 匈牙利语
        /// <summary>
        /// 捷克语
        /// </summary>
		public const int LANGUAGE_CZECH					= 140;	// 捷克语
        /// <summary>
        /// 土耳其语
        /// </summary>
		public const int LANGUAGE_TURKISH				= 150;	// 土耳其语

        /// <summary>
        /// 俄语
        /// </summary>
		public const int LANGUAGE_RUSSIAN				= 500;	// 俄语
        /// <summary>
        /// 阿拉伯语
        /// </summary>
		public const int LANGUAGE_ARABIC				= 600;	// 阿拉伯语
        /// <summary>
        /// 日语
        /// </summary>
		public const int LANGUAGE_JAPANESE				= 700;	// 日语
        /// <summary>
        /// 韩语
        /// </summary>
		public const int LANGUAGE_KOREAN				= 710;	// 韩语
        /// <summary>
        /// 越南语
        /// </summary>
		public const int LANGUAGE_VIETNAMESE			= 720;	// 越南语
        /// <summary>
        /// 马来语
        /// </summary>
		public const int LANGUAGE_MALAY					= 730;	// 马来语
        /// <summary>
        /// 泰语
        /// </summary>
		public const int LANGUAGE_THAI					= 740;	// 泰语


		//--------------------------------------------------------------------------------
		//支持多领域
		// 
		//这里列出的是系统内建的领域定义，需要安装相应音库的资源包才能真正支持。
		//
		//对于这里没有列出的领域，将来也可能会发布相应的资源包，同时会分配一个数值，
		//只要安装此资源包后，就可以使用。对于没有列出的领域，如果想使用，可以直接使用数值
		//
		//可以通过Domain系列函数得到所有系统中定义的（包括将来扩展的）领域数值及其描述的信息
		//
		//对于系统中真正支持的语言，可以通过jTTS_GetVoiceCount, jTTS_GetVoiceAttribute函数
		//得到所有安装的音库，并从其属性中知道其支持的领域
		public const int DOMAIN_COMMON			= 0;		// 通用领域，新闻
		public const int DOMAIN_FINANCE			= 1;		// 金融证券
		public const int DOMAIN_WEATHER			= 2;		// 天气预报
		public const int DOMAIN_SPORTS			= 3;		// 体育赛事
		public const int DOMAIN_TRAFFIC			= 4;		// 公交信息
		public const int DOMAIN_TRAVEL			= 5;		// 旅游餐饮

		public const int DOMAIN_MIN				= 0;
		public const int DOMAIN_MAX				= 31;

		//----------------------------------------------------------------------------------
		//支持的CODEPAGE
		public const ushort CODEPAGE_GB			= 936;		// 包括GB18030, GBK, GB2312
		public const ushort CODEPAGE_BIG5			= 950;
		public const ushort CODEPAGE_SHIFTJIS		= 932;
		public const ushort CODEPAGE_ISO8859_1		= 1252;
		public const ushort CODEPAGE_UNICODE		= 1200;
		public const ushort CODEPAGE_UNICODE_BIGE	= 1201;		// BIG Endian
		public const ushort CODEPAGE_UTF8 			= 65001;
		
		//----------------------------------------------------------------------------------
		//支持的TAG
		public const int TAG_AUTO				= 0x00;	// 自动判断
		public const int TAG_JTTS				= 0x01;	// 仅处理含有jTTS 3.0支持的TAG: \read=\  
		public const int TAG_SSML				= 0x02;	// 仅处理含有SSML 的TAG: <voice gender="female" />
		public const int TAG_NONE				= 0x03;	// 没有TAG

		//-----------------------------------------------------------------------------------
		//数字读法
		public const int DIGIT_AUTO_NUMBER		= 0;
		public const int DIGIT_TELEGRAM			= 1;
		public const int DIGIT_NUMBER			= 2;
		public const int DIGIT_AUTO_TELEGRAM	= 3;
		public const int DIGIT_AUTO				= DIGIT_AUTO_NUMBER;

		//------------------------------------------------------------------------------------
		// Punc Mode
		public const short PUNC_OFF				= 0;	/* 不读符号，自动判断回车换行是否分隔符*/
		public const short PUNC_ON				= 1;	/* 读符号，  自动判断回车换行是否分隔符*/
		public const short PUNC_OFF_RTN			= 2;	/* 不读符号，强制将回车换行作为分隔符*/
		public const short PUNC_ON_RTN			= 3;	/* 读符号，  强制将回车换行作为分隔符*/

		//------------------------------------------------------------------------------------
		// EngMode
		public const int ENG_AUTO				= 0;	/* 自动方式 */
		public const int ENG_SAPI				= 1;	/* 此版本无效，等同于ENG_AUTO */
		public const int ENG_LETTER				= 2;	/* 强制单字母方式 */
		public const int ENG_LETTER_PHRASE		= 3;	/* 强制采用字母＋自录音词汇的方式 */


        //------------------------------------------音色属性------------------------------------------//
        //Gender 
        /// <summary>
        /// 女声
        /// </summary>
        public const int GENDER_FEMALE = 0;
        /// <summary>
        /// 男声
        /// </summary>
        public const int GENDER_MALE = 1;
        /// <summary>
        /// 中性
        /// </summary>
        public const int GENDER_NEUTRAL = 2;
        //AGE
        /// <summary>
        /// 婴儿小于 3岁
        /// </summary>
		public const int AGE_BABY				= 0;		//0 - 3
        /// <summary>
        /// 儿童 3-12 岁
        /// </summary>
		public const int AGE_CHILD				= 1;		//3 - 12
        /// <summary>
        /// 青年12-18
        /// </summary>
		public const int AGE_YOUNG				= 2;		//12 - 18
        /// <summary>
        /// 成年 18-60
        /// </summary>
		public const int AGE_ADULT				= 3;		//18 - 60
        /// <summary>
        /// 老年 大于60
        /// </summary>
		public const int AGE_OLD				= 4;		//60 -

        //------------------------------------音频------------------------------------------------
		//PITCH 
        /// <summary>
        /// 设置音频允许最小值
        /// </summary>
		public const int PITCH_MIN				= 0;
        /// <summary>
        /// 设置音频允许最大值
        /// </summary>
		public const int PITCH_MAX				= 9;

        //-------------------------------------音量-----------------------------------------------
		//VOLUME 
        /// <summary>
        /// 设置音量允许最小值
        /// </summary>
		public const int VOLUME_MIN				= 0;
        /// <summary>
        /// 设置音量允许最大值
        /// </summary>
		public const int VOLUME_MAX				= 9;

        //--------------------------------------语速----------------------------------------------
		//SPEED 
        /// <summary>
        /// 设置语速允许最小值
        /// </summary>
		public const int SPEED_MIN				= 0;
        /// <summary>
        /// 设置语速允许最大值
        /// </summary>
		public const int SPEED_MAX				= 9;


		//---------------------------------------------------------------------------
		//jTTS_Play状态	
		public const int STATUS_NOTINIT			= 0;
		public const int STATUS_READING			= 1;
		public const int STATUS_PAUSE			= 2;
		public const int STATUS_IDLE			= 3;

		//------------------------------------------------------------------------------------
		//jTTS_PlayToFile的文件格式
		public const int FORMAT_WAV				= 0;	// PCM Native (和音库一致，目前为16KHz, 16Bit)
		public const int FORMAT_VOX_6K			= 1;	// OKI ADPCM, 6KHz, 4bit (Dialogic Vox)
		public const int FORMAT_VOX_8K			= 2;	// OKI ADPCM, 8KHz, 4bit (Dialogic Vox)
		public const int FORMAT_ALAW_8K			= 3;	// A律, 8KHz, 8Bit
		public const int FORMAT_uLAW_8K			= 4;	// u律, 8KHz, 8Bit
		public const int FORMAT_WAV_8K8B		= 5;	// PCM, 8KHz, 8Bit
		public const int FORMAT_WAV_8K16B		= 6;	// PCM, 8KHz, 16Bit
		public const int FORMAT_WAV_16K8B		= 7;	// PCM, 16KHz, 8Bit
		public const int FORMAT_WAV_16K16B		= 8;	// PCM, 16KHz, 16Bit
		public const int FORMAT_WAV_11K8B		= 9;	// PCM, 11.025KHz, 8Bit
		public const int FORMAT_WAV_11K16B		= 10;	// PCM, 11.025KHz, 16Bit

		public const int FORMAT_FIRST			= 0;
		public const int FORMAT_LAST			= 10;

		//------------------------------------------------------------------------------------
		// jTTS_Play / jTTS_PlayToFile / jTTS_SessionStart 函数支持的dwFlag定义

		// 此项仅对jTTS_PlayToFile适用
		public const int PLAYTOFILE_DEFAULT		= 0x0000;	//默认值,写文件时只增加FORMAT_WAV_...格式的文件头
		public const int PLAYTOFILE_NOHEAD		= 0x0001;	//所有的格式都不增加文件头
		public const int PLAYTOFILE_ADDHEAD		= 0x0002;	//增加FORMAT_WAV_...格式和FORMAT_ALAW_8K,FORMAT_uLAW_8K格式的文件头

		public const int PLAYTOFILE_MASK		= 0x000F;

		// 此项仅对jTTS_Play适用
		public const int PLAY_RETURN			= 0x0000;	// 如果正在播放，返回错误
		public const int PLAY_INTERRUPT			= 0x0010;	// 如果正在播放，打断原来的播放，立即播放新的内容

		public const int PLAY_MASK				= 0x00F0;

		// 播放的内容
		public const int PLAYCONTENT_TEXT		= 0x0000;	// 播放内容为文本
		public const int PLAYCONTENT_TEXTFILE	= 0x0100;	// 播放内容为文本文件
		public const int PLAYCONTENT_AUTOFILE	= 0x0200;	// 播放内容为文件，根据后缀名采用外界Filter DLL抽取
		// 无法判断的当作文本文件

		public const int PLAYCONTENT_MASK		= 0x0F00;

		// 播放的模式，同时用于SessionStart
		public const int PLAYMODE_DEFAULT		= 0x0000;	// 在jTTS_Play下缺省异步，在jTTS_PlayToFile下缺省同步
		// jTTS_SessionStart下为主动获取数据方式
		public const int PLAYMODE_ASYNC			= 0x1000;	// 异步播放，函数立即退出
		public const int PLAYMODE_SYNC			= 0x2000;	// 同步播放，播放完成后退出

		public const int PLAYMODE_MASK			= 0xF000;


		//------------------------------------------------------------------------------------
		// jTTS_FindVoice返回的匹配级别
		public const int MATCH_LANGUAGE			= 0;	// 满足LANGUAGE，
		public const int MATCH_GENDER			= 1;	// 满足LANGUAGE, GENDER
		public const int MATCH_AGE				= 2;	// 满足LANGUAGE, GENDER, AGE
		public const int MATCH_NAME				= 3;	// 满足LANGUAGE, GENDER，AGE，NAME
		public const int MATCH_DOMAIN			= 4;	// 满足LANGUAGE, GENDER，AGE，NAME, DOMAIN，也即满足所有条件
		public const int MATCH_ALL				= 4;	// 满足所有条件

		//------------------------------------------------------------------------------------
		// InsertInfo信息
		public const int INFO_MARK				= 0;
		public const int INFO_VISEME			= 1;

		//------------------------------------------------------------------------------------
		//各种信息串的长度
		public const int VOICENAME_LEN			= 32;
		public const int VOICEID_LEN			= 40;
		public const int VENDOR_LEN				= 32;
		public const int DLLNAME_LEN			= 256;

		public const int ATTRNAME_LEN			= 32;
		public const int XMLLANG_LEN			= 256;


		//------------------------------------------------------------------------------------
		//JTTS_PARAM 在jTTS_SetParam中使用
        /// <summary>
        /// 代码集
        /// </summary>
		public const int PARAM_CODEPAGE			= 0;	// CODEPAGE_xxx
        /// <summary>
        /// 音库
        /// </summary>
		public const int PARAM_VOICEID			= 1;	// Voice ID
        /// <summary>
        /// 音频
        /// </summary>
		public const int PARAM_PITCH			= 2;	// PITCH_MIN - PITCH_MAX
		/// <summary>
        /// 音量
		/// </summary>
        public const int PARAM_VOLUME		    = 3;	// VOLUME_MIN - VOLUME_MAX
        /// <summary>
        /// 语速
        /// </summary>
		public const int PARAM_SPEED			= 4;	// SPEED_MIN - SPEED_MAX
        /// <summary>
        /// 标点符号读法
        /// </summary>
		public const int PARAM_PUNCMODE			= 5;	// PUNC_xxx  
        /// <summary>
        /// 数字读法
        /// </summary>
		public const int PARAM_DIGITMODE		= 6;	// DIGIT_xxx
        /// <summary>
        /// 英文读法
        /// </summary>
		public const int PARAM_ENGMODE			= 7;	// ENG_xxx

		public const int PARAM_TAGMODE			= 8;	// TAG_xxx
		public const int PARAM_DOMAIN		    = 9;	// DOMAIN_xxx
		public const int PARAM_TRYTIMES			= 10;	// 连接服务器重式次数
		public const int PARAM_LOADBALANCE		= 11;	// 是否使用负载均衡




        //-----------------------------------JTTS_CONFIG[初始化语音库时候通过它设置语音库的各种属性]-----------------------------------------
		//JTTS_CONFIG
		public const int JTTS_VERSION4	= 0x0004;	// version 4.0
		[StructLayout( LayoutKind.Sequential, CharSet=CharSet.Ansi )]
			public struct JTTS_CONFIG
		{
            /// <summary>
            /// 此结构的版本号目前必须设置为 4
            /// </summary>
			public ushort	wVersion;		// JTTS_VERSION4
            /// <summary>
            /// 所设置的代码集代号，系统内部缺省为 CODEPAGE_GB
            /// </summary>
			public ushort	nCodePage;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=VOICEID_LEN)]
            /// <summary>
            /// 使用的音色 音库标识系统内部缺省为中文女声音库"93A47B28-FE41-4e99-9458-7A781484A467
            /// </summary>
			public string	szVoiceID;		// 使用的音色 音库标识系统内部缺省为中文女声音库"93A47B28-FE41-4e99-9458-7A781484A467
            /// <summary>
            /// 领域设置 缺省为 DOMAIN_COMMON
            /// </summary>
			public short	nDomain;	
            /// <summary>
            /// 合成语音的基频 按照 0~9 分为 10 级 缺省值为5。数字越大基频越高
            /// </summary>
			public short	nPitch;
            /// <summary>
            /// 合成语音的音量,按照 0~9 分为 10 级,缺省值为5。数字越大音量越大
            /// </summary>
			public short	nVolume;
            /// <summary>
            /// 合成语音的语速,按照 0~9 分为 10 级,缺省值为5数字。越大语速越快
            /// </summary>
			public short	nSpeed;
            /// <summary>
            /// 标点和回车的设置,系统内部缺省为 PUNC_OFF
            /// </summary>
			public short	nPuncMode;
            /// <summary>
            /// 数字串的阅读方式,缺省为 DIGIT_AUTO_NUMBER
            /// </summary>
			public short	nDigitMode;
            /// <summary>
            /// 英文串的阅读方式,缺省为 ENG_AUTO
            /// </summary>
			public short	nEngMode;
            /// <summary>
            /// 标注的处理方式,缺省为 TAG_AUTO
            /// </summary>
			public short	nTagMode;
            /// <summary>
            /// 在连接服务器时的重试次数,有效值为 1-100。缺省为 10
            /// </summary>
			public short	nTryTimes;	    //重试次数,此成员仅用于远程合成
            /// <summary>
            /// 在远程合成期间,如果发生网络连接错误是否试另外的服务器 
            /// </summary>
			public int		bLoadBalance;	//负载平衡,此成员仅用于远程合成
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=12)] 
			public short[]	nReserved;		// 保留
		}

		//---------------------------------音色属性------------------------------------------
		//JTTS_VOICEATTRIBUTE
        /// <summary>
        /// 音色属性
        /// </summary>
		public struct JTTS_VOICEATTRIBUTE
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=VOICENAME_LEN)]
            /// <summary>
            ///音色的名称
            /// <summary>
            public string szName;					// 只能为英文名称

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=VOICEID_LEN)]
            /// <summary>
            ///音色的标识 GUID
            /// <summary>
			public string		szVoiceID;				// 音色的唯一标识
            /// <summary>
            /// 音色对应的性别：男声、女声或中性
            /// </summary>
			public short		nGender;				// GENDER_xxx
            /// <summary>
            /// 音色对应的年龄
            /// </summary>
			public short		nAge;					// AGE_xx
            /// <summary>
            /// 此音色支持的领域
            /// </summary>
			public uint		dwDomainArray;			// 由低位向高位，分别表示DOMAIN_xxx
            /// <summary>
            /// 此音色支持的语种
            /// </summary>
			public uint		nLanguage;				// 支持的语言, LANGUAGE_xxx
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=VENDOR_LEN)]
            /// <summary>
            /// 此音色的提供厂商
            /// </summary>
			public string		szVendor;				// 提供厂商
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=DLLNAME_LEN)]
            /// <summary>
            /// 此音色所使用的引擎 为 DLL 的全路径名称
            /// </summary>
			public string		szDLLName;				// 对应的DLL
            /// <summary>
            /// 引擎的版本号
            /// </summary>
			public uint		dwVersionMS;			// 引擎的版本号，对应"3.75.0.31"的前两节
			// e.g. 0x00030075 = "3.75"
			public uint		dwVersionLS;			// e.g. 0x00000031 = "0.31"
		}

		//---------------------------------------------------------------------
		// 插入信息
		public struct INSERTINFO
		{
			public int		nTag;		// 有二种：INFO_MARK, INFO_VISEME
			public uint	dwValue; 	// 具体信息：
			// MARK时，高24位mark文本偏移，低8位文本长度
			// VISEME时，表示唇型
			public uint	dwBytes;	// 在语音流的什么地方插入，必须按顺序增加
		}

		//---------------------------------------------------------------------
		//JTTS_LANGATTRIBUTE
		public struct JTTS_LANGATTRIBUTE
		{
			public int	  nValue;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=ATTRNAME_LEN)] 
			public string  szName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=ATTRNAME_LEN)] 
			public string  szEngName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=XMLLANG_LEN)] 
			public string  szXmlLang;
		}

		//---------------------------------------------------------------------
		//JTTS_DOMAINATTRIBUTE
		public struct JTTS_DOMAINATTRIBUTE
		{
			public int   nValue;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=ATTRNAME_LEN)] 
			public string  szName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=ATTRNAME_LEN)] 
			public string  szEngName;
		}



		//----------------------------------------------------------------------
		//系统函数
		[DllImport("jTTS_ML.dll")]
        ///pszLibPath   --初始化字符串 允许为NULL
        ///pcszSerialNo --字符串类型的开发序列号 允许为NULL
		public static extern int jTTS_Init(string pszLibPath, string pszSerialNO); //初始化JTTS语音包
		[DllImport("jTTS_ML.dll")]
		public static extern int jTTS_End();//释放JTTS内存资源
        /********************************函数说明********************************/
        /*jTTS_Init   设置参数为NULL时 jTTS 核心会查找注册表指定的注册项来初始化字符串或者序列号*/
        /*jTTS_End    如果实例化了多个JTTS语音包则需要执行相同次数jTTS_End函数*/


		//----------------------------------------------------------------------
		//语言和领域函数
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_GetLangCount(); //得到系统定义的语言标识数目
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_GetLangAttribute(int nIndex, out JTTS_LANGATTRIBUTE pAttribute);//得到某个语言标识的属性
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_GetLangAttributeByValue(uint nValue, out JTTS_LANGATTRIBUTE pAttribute);//根据语言标识的定义值得到其属性
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_GetDomainCount();//得到系统定义的领域标识数目
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_GetDomainAttribute(uint nIndex, out JTTS_DOMAINATTRIBUTE pAttribute);//得到某个领域标识的属性
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_GetDomainAttributeByValue(uint nValue, out JTTS_DOMAINATTRIBUTE pAttribute);//根据领域标识的定义值得到其属性
        /********************************函数说明********************************/
        /*jTTS_GetLangCount  返回系统中定义的语言标识数目*/
        /*jTTS_GetLangAttribute 参数:nIndex 语言标识的序号从0开始不应大于用jTTS_GetLangCount得到的语言标识数目
           pAttribute 函数返回时存放语言标识的详细信息
         */
        /*jTTS_GetLangAttributeByValue 参数:nValue语言标识的定义值 pAttribute函数返回时存放语言标识的详细信息*/


        //-------------------------------------------------------------
		// 音库信息函数
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_GetVoiceCount();//得到系统支持的音色数目
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_GetVoiceAttribute(int nIndex, out JTTS_VOICEATTRIBUTE Attribute);//得到某个音色的属性
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_GetVoiceAttributeByID(string pszVoiceID, out JTTS_VOICEATTRIBUTE pAttribute);//根据标识得到音色的属性
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_IsVoiceSupported(string strVoiceID);//查看系统是否支持某个音色
		[DllImport("jTTS_ML.dll")]
		public static extern int jTTS_FindVoice(int nLanguage, int nGender, int nAge, string pszName, int nDomain,
            string pszVoiceID, out ushort pwMatchFlag);//根据一系列的条件查找系统中最匹配的音色
        [DllImport("jTTS_ML.dll")]
        public static extern int jTTS_PreLoad(string pszVoiceID);//预载入某一音色的相关资源库
		//------------------------------------------------------------------------
		// 设置函数 
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_Set(ref JTTS_CONFIG pConfig);//通过结构的方式一次性设置语音合成的所有参数
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_Get(out JTTS_CONFIG pConfig);//通过结构的方式一次性获得语音合成的所有参数
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_SetParam(int nParam, uint dwValue);//设置语音合成的某种参数设置
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_GetParam(int nParam, out uint pdwValue);//设置语音合成的某种参数设置

		//------------------------------------------------------------------------
		// 播放函数
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_Play(string pcszText, uint dwFlag);//播放到设备
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_Stop();//停止播放
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_Pause();//暂停播放
		[DllImport("jTTS_ML.dll")]
        public static extern int jTTS_Resume();//恢复播放
		[DllImport("jTTS_ML.dll")]
		public static extern int jTTS_GetStatus();//得到系统当前状态 针对播放到设备
		[DllImport("jTTS_ML.dll")]
		public static extern int jTTS_PlayToFile(string pcszText, string pcszFileName, 
			uint nFormat, ref JTTS_CONFIG pConfig, 
			uint dwFlag, uint lpfnCallback, 
			uint dwUserData);
        //对文本进行语音合成将结果写入语音文件
	}
}