using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Ts_zyys_yzgl
{
    public partial class UcApplyInfos : UserControl
    {
        private DataTable _dtYz;//特殊级抗菌药物医嘱的所有记录
        public Dictionary<string, UcApplyInfo> myCts;//key：yzid  value:特殊抗菌物原因输入控件

        public UcApplyInfos()
        {
            InitializeComponent();

            myCts = new Dictionary<string, UcApplyInfo>();
            tlpYz.CellPaint += new TableLayoutCellPaintEventHandler(tlpYz_CellPaint);
        }

        /// <summary>
        /// 自定义化初始用户控件
        /// </summary>
        /// <param name="dtYz">特殊级抗菌药物医嘱的所有记录</param>
        public UcApplyInfos(DataTable dtYz)
        {
            InitializeComponent();

            _dtYz = dtYz;
            myCts = new Dictionary<string, UcApplyInfo>();
        }

        public void DoIniCt(DataTable dtYz)
        {
            try
            {
                _dtYz = dtYz;//抗生素等级放到 该表的Memo字段存储

                DataRow[] myDrs = _dtYz.Select("MEMO=3");

                //设置属性FurNos/MixNums
                int iNum = myDrs.Length;

                tlpYz.ColumnStyles.Clear();
                tlpYz.RowStyles.Clear();

                int iColNum = 2;//列数
                int myRow = iNum % iColNum == 0 ? (iNum / iColNum) : (iNum / iColNum) + 1;//行数
                tlpYz.ColumnCount = iColNum;//永远设置两列

                //生成所有子控件（并排版布局），默认enable=false；即默认配置控件。
                int j = 0;
                int height = UcApplyInfo._hCtHeight;
                int weight = UcApplyInfo._wCtWidth;

                for (int kRow = 0; kRow < myRow; kRow++)
                {
                    tlpYz.RowStyles.Add(new RowStyle(SizeType.Absolute, height)); ;//列总长686,高总高694：2列，2行（343,347）
                    for (int kCol = 0; kCol < iColNum; kCol++)
                    {
                        tlpYz.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, weight));//为控件列划分宽度样式

                        if (!(j < iNum))
                        {
                            break;
                        }

                        string orderID = myDrs[j]["ID"].ToString().Trim();//yzid
                        string yppm = myDrs[j]["医嘱内容"].ToString().Trim();//ypName
                        string cjid = myDrs[j]["HOITEM_ID"].ToString().Trim();//cjid

                        UcApplyInfo myCt = new UcApplyInfo(yppm, cjid, orderID);
                        //myFur.btnSureClick += new MixFurnace.MySureButtonClick(myFur_btnSureClick);
                        //myFur.btnFinishClick += new MixFurnace.MySureButtonClick(myFur_btnFinishClick);
                        //myFur.btnHandClick += new MixFurnace.MySureButtonClick(myFur_btnHandClick);
                        //myFur.btnRawMtrClick += new MixFurnace.MySureButtonClick(myFur_btnRawMtrClick);
                        //myFur.btnAlLeftClick += new MixFurnace.MySureButtonClick(myFur_btnAlLeftClick);

                        //myFur.LFurNo.Text = allFurNos[j];//标识炉号信息
                        ////myFur.CFurnaceNo.Text = allFurNos[j];//标识炉号信息
                        //myFur.Enabled = false;//默认为不可操作
                        //myFur.LFurNo.ForeColor = Color.Chocolate;

                        tlpYz.Controls.Add(myCt, kCol, kRow);//添加子控件
                        myCts.Add(orderID, myCt);//暴露属性，提供调用者获取

                        j++;
                    }
                }

                tlpYz.Width = iColNum * UcApplyInfo._wCtWidth;//设置父控件宽度
                tlpYz.Height = myRow * UcApplyInfo._hCtHeight;//设置父控件高度
                tlpYz.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
                this.AutoScroll = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成子控件失败\n" + ex.Message);
                return;
            }
        }

        public void DoResetCt()
        {
            foreach (Control ct in tlpYz.Controls)
            {
                tlpYz.Controls.Remove(ct);
            }

        }

        public void DoAddCt(string yzid)
        {
            try
            {

            }
            catch { }
        }

        void tlpYz_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            try
            {
                // 重绘
                Pen pp = new Pen(Color.Purple);
                e.Graphics.DrawRectangle(pp, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                //Application.DoEvents();
            }
            catch { }
        }
    }

    /// <summary>
    /// 特殊抗菌申请实体
    /// </summary>
    public class Entity_KjSq
    {
        public string DJID;//				uniqueidentifier     not null,--登记ID
        public string INPATIENT_ID;//		uniqueidentifier     not null,--病人信息ID
        public string baby_id;//		int					 default 0,--卡登记ID
        public string order_id;//			uniqueidentifier	 not null,--医嘱id
        public string group_id;//			bigint				default 0,--医嘱组号
        public string dept_id;//			int				,				--科室
        public string zyzd;//			[varchar](100)	,				--主要诊断
        public string shyj;//				[varchar](100)	,				--审核意见
        public string apply_id;//			int				,				--申请人
        public string apply_time;//		date				,			--申请时间
        public string shr;//		int				,				--审核人
        public string shsj;//			date				,			--审核时间
        public string purp_1;//			char(1),						--1、用药目的
        public string purp_1_memo;//		[varchar](100)	,				--1、用药目的备注
        public string purp_2;//	char(1),						--2、是否已送病原学检查
        public string purp_2_memo;//	[varchar](100)	,				--2、是否已送病原学检查备注
        public string purp_3;//	char(1),						--3、是否已有细菌培养及药敏结果
        public string purp_3_memo;//	[varchar](100)	,				--3、是否已有细菌培养及药敏结果备注
        public string purp_4;//	char(1),						--4、所申请药物是否对该病原菌敏感
        public string purp_4_memo;//	[varchar](100)	,				--4、所申请药物是否对该病原菌敏感备注
        public string purp_5_memo;//	[varchar](100)	,				--5、其他

        public DataRow drYzInfo;
    }
}
