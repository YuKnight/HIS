using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;

namespace ts_mzys_blcflr
{
    partial class Frmblcf
    {
        /// <summary>
        /// 门诊皮试项目的医嘱ID 参见jc_hoitemdiction
        /// </summary>
        private SystemCfg _cfg1008 = new SystemCfg( 1008 ); //皮试医嘱项目ID
        /// <summary>
        /// 门诊医生是否输需要开皮试用药 1要开 0不要开
        /// </summary>
        private SystemCfg _cfg3002 = new SystemCfg( 3002 );//皮试用药
        /// <summary>
        /// 当药品库存不够时,是否强制不允许继续 1强制 0不强制
        /// </summary>
        private SystemCfg _cfg3004 = new SystemCfg( 3004 );//库存控制
        /// <summary>
        /// 医生录入项目时不强制控制执行科室分方,系统自动分方 1自动分方 0不自动
        /// </summary>
        private SystemCfg _cfg3005 = new SystemCfg( 3005 );
        /// <summary>
        /// 门诊医生是否可以自由录入诊断 1可以 0不可以
        /// </summary>
        private SystemCfg _cfg3007 = new SystemCfg( 3007 );
        /// <summary>
        /// 门诊医生站启用药品用药级别控制 1启用 0不启用
        /// </summary>
        private SystemCfg _cfg3009 = new SystemCfg( 3009 ); //限制用药级别 //Add By Zj 2012-05-27
        /// <summary>
        /// 门诊医生站是否启用合理用药接口 0=否，1=是
        /// </summary>
        private SystemCfg _cfg3027 = new SystemCfg( 3027 ); //合理用药是否启用 //Add By Zj 2012-02-14
        /// <summary>
        /// 门诊医生站是否启用药房虚库存 0=否，1=是 默认为0
        /// </summary>
        private SystemCfg _cfg3029 = new SystemCfg( 3029 ); //药房虚库存是否启用 //Add By Zj 2012-02-29
        /// <summary>
        /// 门诊医生 药品处方是否需要输入备注 0不需要 1 需要录入中药备注 2 需要录入西药备注 3 都需要录入
        /// </summary>
        private SystemCfg _cfg3032 = new SystemCfg( 3032 );//中药处方是否需要录入脚注 //Add By Zj 2012-03-22
        /// <summary>
        /// 挂号有效天数
        /// </summary>
        private SystemCfg _cfg1007 = new SystemCfg( 1007 );//挂号有效天数
        /// <summary>
        /// 是否启动模板自动合并处方 自动合并处方就是如果是西药和成药 自动合在一张处方里 可以将2张模板里的处方合并在一起 0 不启用 1启用 默认为0
        /// </summary>
        private SystemCfg _cfg3039 = new SystemCfg( 3039 );//模板调用处方是否自动合并 //Add By Zj 2012-05-27
        /// <summary>
        /// 是否控制门诊医生诊断录入 
        /// <para>0 中医和西医录入一个就可以 </para> 
        /// <para>1 必须录入中医诊断和西医诊断</para>
        /// <para>2 控制必须录入证型和中医诊断以及西医诊断</para>
        /// <para>3 必须录入西医诊断</para>
        /// <para>4 必须录入中医诊断 默认为0</para>
        /// </summary>
        private SystemCfg _cfg3041 = new SystemCfg( 3041 );//是否控制必须录入中医诊断以及证型 Add By Zj 2012-06-21
        /// <summary>
        /// 门诊医生接诊是否提示确认接诊 0不提示 1提示  
        /// </summary>
        private SystemCfg _cfg3042 = new SystemCfg( 3042 );//接诊的时候是否提示确认接诊 Add By Zj 2012-07-02
        /// <summary>
        /// 门诊医生站是否能够修改拥有诊疗卡病人的基本信息 0可以 1不可以  
        /// </summary>
        private SystemCfg _cfg3043 = new SystemCfg( 3043 );//门诊医生是否能够修改拥有诊疗卡病人的基本信息 Add By Zj 2012-07-02
        /// <summary>
        /// 控制门诊医生站是否能够开多个皮试药品. 0为不控制 1 控制  
        /// </summary>
        private SystemCfg _cfg3044 = new SystemCfg( 3044 ); 
        /// <summary>
        /// 门诊医生站开处方 是否将医嘱化验类型同样的分为一张处方 0 否 1 是  
        /// </summary>
        private SystemCfg _cfg3048 = new SystemCfg( 3048 ); 
        /// <summary>
        /// 门诊医生站哪些科室可以录入病人月经史  
        /// </summary>
        private SystemCfg _cfg3050 = new SystemCfg( 3050 ); 
        /// <summary>
        /// 门诊医生站是否限制西药、中成药单张处方明细数不能超5行 0不限制 1限制 2提示
        /// </summary>
        private SystemCfg _cfg3073 = new SystemCfg( 3073 );
        /// <summary>
        /// 收费成功后打印的凭据方式 0 收费不打发票 1打发票 2打小票
        /// </summary>
        private SystemCfg _cfg1046 = new SystemCfg( 1046 );
        /// <summary>
        /// 门诊医生站是否支持代金卡扣费!重要参数,请不要随便开启 0 不开启 1开启  
        /// </summary>
        private SystemCfg _cfg3036 = new SystemCfg( 3036 );
        /// <summary>
        /// 门诊需要填写末次月经的科室
        /// </summary>
        private SystemCfg _cfg3056 = new SystemCfg( 3056 );//门诊需要填写末次月经的科室
        /// <summary>
        /// 医生站挂号是否一定要收取挂号费以后才可以开处方 add by zouchihua 2013-4-27
        /// </summary>
        private SystemCfg _cfg1084 = new SystemCfg( 1084 );//医生站挂号是否一定要收取挂号费以后才可以开处方 add by zouchihua 2013-4-27
        /// <summary>
        /// 门诊医生站是否使用药品比例控制
        /// </summary>
        private SystemCfg _cfg3057 = new SystemCfg( 3057 );//门诊医生站是否使用药品比例控制
        /// <summary>
        /// 候诊病人网格允许存储已呼叫未接诊的记录数 add by zp 2013-06-13
        /// </summary>
        private SystemCfg _cfg3067 = new SystemCfg( 3067 );
        /// <summary>
        /// 是否启用新分诊参数 Add by zp 2013-06
        /// </summary>
        private SystemCfg _cfg3070 = new SystemCfg( 3070 );
        /// <summary>
        /// 3071医生站弃号操作:0更新MZHS_FZJL表的BJZBZ;1更新为现场病人最后一位候诊
        /// </summary>
        private SystemCfg _cfg3071 = new SystemCfg( 3071 );
        /// <summary>
        /// 门诊医生站病历处方开医技项目是否调用电子申请单 0否 1是 默认0
        /// </summary>
        private SystemCfg _cfg3077 = new SystemCfg( 3077 ); //  Add by zp 2013-10-12
        /// <summary>
        /// 门诊是否启用分时段挂号 0不启用 1启用 默认为0
        /// </summary>
        private SystemCfg _cfg1099 = new SystemCfg( 1099 );// Add by zp 2013-12-07
        /// <summary>
        /// 门诊医生站处方录入药品和项目允许开在一张处方,保存后自动分方 0不允许 1允许 默认0
        /// </summary>
        private SystemCfg _cfg3081 = new SystemCfg( 3081 );// Add by zp 2014-01-06
        /// <summary>
        /// 门诊医生站保存处方后是否自动弹出关联费用框 0不开启 1开启
        /// </summary>
        private SystemCfg _cfg3082 = new SystemCfg( 3082 );//门诊医生站保存处方后自动show出关联费用框 0不开启 1开启  默认0  Add by zp 2014-01-06
        /// <summary>
        /// 静脉采血的医嘱id
        /// </summary>
        private SystemCfg _cfg7015 = new SystemCfg( 7015 ); //Add by zp 静脉采血的医嘱id 2014-01-06
        /// <summary>
        /// 静脉采血管的医嘱ID
        /// </summary>
        private SystemCfg _cfg7016 = new SystemCfg( 7016 ); //Add by zp 静脉采血管 2014-01-06
        /// <summary>
        /// 门诊医生站的采血管子费和静脉采血费自动生成是否开启 0不开启 1开启 默认0
        /// </summary>
        private SystemCfg _cfg3083 = new SystemCfg( 3083 );//Add by zp 门诊医生站的采血管子费和静脉采血费自动生成是否开启 0不开启 1开启 默认0 2014-01-06 
        /// <summary>
        /// 门诊医生在选择医嘱页面是否可以维护嘱托 1可以 0不可以
        /// </summary>
        private SystemCfg _cfg3006 = new SystemCfg( 3006 );//门诊医生在选择医嘱页面是否可以维护嘱托 1可以 0不可以
        /// <summary>
        /// 门诊医生是否可以新增维护诊断库 1可以 0不可以
        /// </summary>
        private SystemCfg _cfg3008 = new SystemCfg( 3008 );//门诊医生是否可以新增维护诊断库 1可以 0不可以
        /// <summary>
        /// 门诊退费是否启用三级审核流程 0不启用 1启用
        /// </summary>
        private SystemCfg _cfg1105 = new SystemCfg( 1105 );//门诊退费是否启用三级审核流程 0不启用 1启用 默认0 Add by zp 2014-01-17
        /// <summary>
        /// 门诊留观病人默认药房id
        /// </summary>
        private SystemCfg _cfg1106 = new SystemCfg( 1106 );//Add By zp 2014-01-10 门诊留观病人默认药房id 
        /// <summary>
        /// 门诊医生站，无处方级别的医生需开此药品 0有提示,但可以开 1要上级审核 2不准开  
        /// </summary>
        private SystemCfg _cfg3126 = new SystemCfg( 3126 );
        /// <summary>
        /// 化验项目是否根据化验分类进行自动分方0不自动分 1自动分 默认为0
        /// </summary>
        private SystemCfg _cfg3087 = new SystemCfg( 3087 );
        /// <summary>
        /// 门诊医生在开处方时35岁以上病人的必须填写血压才能保存0不验证 1验证  
        /// </summary>
        private SystemCfg _cfg3088 = new SystemCfg( 3088 );
        /// <summary>
        /// 医生开处方时，每组处方是否必须录入相应诊断 1是 0否 默认0
        /// </summary>
        private SystemCfg _cfg3098 = new SystemCfg( 3098 );
        /// <summary>
        /// 门诊医生站是否限制使用某一级别的抗生素药品(不限制急诊)  请填抗生素等级ID( YP_KSSDJ表的KSSDJID ) 默认为0不做限制 
        /// </summary>
        private SystemCfg _cfg3055 = new SystemCfg( 3055 ); //抗生素限制等级
        /// <summary>
        /// 门诊病历处方录入，强制控制不允许在一张处方内录入重复药品 0-不强制 1-强制，默认0
        /// </summary>
        private SystemCfg _cfg3155 = new SystemCfg( 3155 );  
        /// <summary>
        /// 3161 参数 门诊病历处方录入，中草药剂量默认值：为空则取词典中的剂量，默认10
        /// </summary>
        private SystemCfg _cfg3161 = new SystemCfg( 3161 );
        /// <summary>
        /// 是否必须填写复诊或初诊 0不需要，1需要 默认为0
        /// </summary>
        private SystemCfg _cfg3106 = new SystemCfg( 3106 );        
        /// <summary>
        /// 叫号时延时的长短(毫秒)
        /// </summary>
        private SystemCfg _cfg3072 = new SystemCfg( 3072 );
        /// <summary>
        /// 新分诊系统是否开放指定呼叫病人 0不开放 1开放 默认0不开放
        /// </summary>
        private SystemCfg _cfg3079 = new SystemCfg( 3079 );
        /// <summary>
        /// 门诊医生站允许使用无号挂号功能的医生编号使用,隔开 例如 ("3213","3214") 如果为空表示不限制 默认为空
        /// </summary>
        private SystemCfg _cfg3101 = new SystemCfg( 3101 );
        /// <summary>
        /// 门诊医生站是否可以选择门诊或住院药房类型 0 不可以 1 可以
        /// </summary>
        private SystemCfg _cfg3018 = new SystemCfg( 3018 );
        /// <summary>
        /// 参数1150 控制医生如果没有处方权，是否能开处方 0-不能 1-只允许开检查项目,2-允许
        /// </summary>
        private SystemCfg _cfg3164 = new SystemCfg( 3164 );
        /// <summary>
        /// 门诊医生站可以委托的医嘱项目ID 如果没有必须默认(0) 如果有多个请设置(1,2) 
        /// </summary>
        private SystemCfg _cfg3104 = new SystemCfg( 3104 );
        /// <summary>
        /// 门诊留观病人，需要统领的药品剂型(YP_YPJX)，多个用逗号隔开：例如1,3
        /// </summary>
        private SystemCfg cfg7179 = new SystemCfg( 7179 );
        /// <summary>
        /// 针对7179，药品统领的药房
        /// </summary>
        private SystemCfg cfg7180 = new SystemCfg( 7180 );
        /// <summary>
        /// 门诊医生站是否开启取药药房变化的检测 0-不开启 1-开启
        /// </summary>
        private SystemCfg _cfg3169 = new SystemCfg( 3169 );
        /// <summary>
        /// 门诊医生站连续调用模板所新开的中草药处方在保存时是否合并为一张处方(0:否 1:是)
        /// </summary>
        private SystemCfg _cfg3172 = new SystemCfg( 3172 );
        /// <summary>
        /// 3173参数  门诊医生站中药处方是否允许有不同的用法和频次 0-允许 1-不允许 默认0
        /// </summary>
        private SystemCfg _cfg3173 = new SystemCfg( 3173 );
        /// <summary>
        /// 门诊留观病人，需要统领的药品剂型
        /// </summary>
        private SystemCfg _cfg7179 = new SystemCfg( 7179 );
        /// <summary>
        /// 门诊医生站医生是否能开非本院区项目 0-否 1-是 默认1
        /// </summary>
        private SystemCfg _cfg3175 = new SystemCfg( 3175 );
        /// <summary>
        /// 允许无号的科室,-1表示所有科室都允许无号 格式:科室,科室 如:12,21
        /// </summary>
        private SystemCfg _cfg1094 = new SystemCfg( 1094 );
        /// <summary>
        /// 是否允许无号 1允许 0不允许
        /// </summary>
        private SystemCfg _cfg1017 = new SystemCfg( 1017 );
        /// <summary>
        /// 门诊医生站是否可以通过无号办理病人信息或给病人看病 1可以 0不可以
        /// </summary>
        private SystemCfg _cfg3010 = new SystemCfg( 3010 );
    }
}
