using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_ybznsh_interface;
using TrasenHIS.BLL;
using TrasenFrame.Forms;
using TrasenClasses.DatabaseAccess;
using ts_zyhs_classes;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace ts_zyhs_yzgl
{
    public partial class FrmYbZnSh : Form
    {
        string binSql = "";
        private RelationalDatabase database;
        private BaseFunc myFunc;
        private int _iYsHs = 0;//默认医生站打开

        public FrmYbZnSh()
        {
            InitializeComponent();

            database = FrmMdiMain.Database;
            myFunc = new BaseFunc();

            btnLoad.Visible = false;
        }

        /// <summary>
        /// i：0 医生站   i：1护士站
        /// </summary>
        /// <param name="iYsHs"></param>
        public FrmYbZnSh(int iYsHs)
        {
            InitializeComponent();

            database = FrmMdiMain.Database;
            myFunc = new BaseFunc();

            btnLoad.Visible = false;

            _iYsHs = iYsHs;
        }

        public FrmYbZnSh(bool isSc)
        {
            InitializeComponent();

            database = FrmMdiMain.Database;
            myFunc = new BaseFunc();

            btnLoad.Visible = true;
        }

        //删除重审
        private void btnReLoad_Click(object sender, EventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            try
            {
                string zyh = txtZyh.Text.Trim();

                if (string.IsNullOrEmpty(zyh))
                {
                    MessageBox.Show("请输入住院号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string strSql = string.Format("select INPATIENT_ID from VI_ZY_VINPATIENT_ALL where INPATIENT_NO ='{0}' and {2}='{1}'  ", zyh, _iYsHs == 0 ? InstanceForm.BCurrentDept.DeptId.ToString() : InstanceForm.BCurrentDept.WardId, _iYsHs == 0 ? "DEPT_ID" : "ward_id");
                string inp = "";
                try
                {
                    inp = database.GetDataResult(strSql).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("未在本科室找到该住院号：" + zyh + " 的病人信息\r" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool CanAudit = ClsAuditCheck.CheckIsAuditCheck(inp, database);//是否需要智审
                if (!CanAudit)
                {
                    MessageBox.Show("该病人不满足进行智审判断条件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //1、清除已有主单据
                //2、上传该病人现有所有费用明细
                //当天新开 医嘱预审保存不计费 需要提示
                if (MessageBox.Show("建议执行完所有 今天新开医嘱 后再进行该操作！\r\r是否确认重传住院号:" + zyh + "所有费用？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    return;

                DoVaildYbFee(zyh, inp);
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        //重审已上传数据
        private void btnReCheck_Click(object sender, EventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            BmiAuditClass clsAdtChk = new BmiAuditClass();
            try
            {
                string zyh = txtZyh.Text.Trim();

                if (string.IsNullOrEmpty(zyh))
                {
                    MessageBox.Show("请输入住院号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string strSql = string.Format("select INPATIENT_ID,YBLX,XZLX from VI_ZY_VINPATIENT_ALL where INPATIENT_NO ='{0}' and {2}='{1}'  ", zyh, _iYsHs == 0 ? InstanceForm.BCurrentDept.DeptId.ToString() : InstanceForm.BCurrentDept.WardId, _iYsHs == 0 ? "DEPT_ID" : "ward_id");
                string inp = "";
                string yblx = "";
                string ybzlx = "";

                string mainID = "";
                try
                {
                    DataTable dtInp = database.GetDataTable(strSql);

                    if (dtInp == null || dtInp.Rows.Count <= 0)
                        throw new Exception("未在本科室找到该住院号：" + zyh + " 的病人信息\r");


                    inp = dtInp.Rows[0]["INPATIENT_ID"].ToString().Trim();
                    yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
                    ybzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
                }
                catch (Exception ex)
                {
                    throw new Exception("未在本科室找到该住院号：" + zyh + " 的病人信息\r" + ex.Message);
                }

                bool CanAudit = ClsAuditCheck.CheckIsAuditCheck(inp, database);//是否需要智审
                if (!CanAudit)
                {
                    MessageBox.Show("该病人不满足进行智审判断条件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string inAGENCIES_ID = "";
                if (yblx.Equals("1"))
                {
                    inAGENCIES_ID = "1";

                    mainID = inp;
                }
                else if (yblx.Equals("3") && ybzlx.Equals("55"))
                {
                    inAGENCIES_ID = "2";

                    //获取医保主单
                    DataTable dtYbDjInfo = ClsAuditCheck.GetOldYbdjInfo(zyh, yblx, ybzlx, database);
                    mainID = dtYbDjInfo.Rows[0]["akc190"] == null ? "" : dtYbDjInfo.Rows[0]["akc190"].ToString().Trim();
                }

                //inAGENCIES_ID :保险ID 1市直医保 2省直医保
                string sRet = clsAdtChk.ReCheckLoadInfo(mainID, inAGENCIES_ID);

                if (sRet.Trim().Equals("0"))
                {
                    MessageBox.Show("审核返回错误,请重新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (sRet.Trim().Equals("1"))
                {
                    MessageBox.Show("已上传费用审核通过", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("审核出错" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        //补充上传病人剩余未上传费用
        private void btnSupplyLoad_Click(object sender, EventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            try
            {
                string zyh = txtZyh.Text.Trim();

                if (string.IsNullOrEmpty(zyh))
                {
                    MessageBox.Show("请输入住院号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string strSql = string.Format("select INPATIENT_ID from ZY_INPATIENT where INPATIENT_NO ='{0}' and DEPT_ID='{1}'  ", zyh, InstanceForm.BCurrentDept.DeptId);
                string inp = "";
                try
                {
                    inp = database.GetDataResult(strSql).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("未在本科室找到该住院号：" + zyh + " 的病人信息\r" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool CanAudit = ClsAuditCheck.CheckIsAuditCheck(inp, database);//是否需要智审
                if (!CanAudit)
                {
                    MessageBox.Show("该病人不满足进行智审判断条件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("确认补传 住院号:" + zyh + " 该病人未上传费用吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    return;

                string strMsg = "";
                bool bSuc = DoVaildYbFee(new DataTable(), 9, 0, new Guid(inp), 0, true, out strMsg);

                if (!bSuc)
                {
                    MessageBox.Show(strMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("补传病人费用成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// 删除 重传,审核病人所有费用 
        /// </summary>
        /// <param name="zyh">住院号</param>
        /// <param name="inp">病人id</param>
        private void DoVaildYbFee(string zyh, string inp)
        {
            try
            {
                //删除该病人已上传的主单信息
                bool bSuc = DoDelInpFeeInfo(inp);
                if (!bSuc)
                {
                    return;
                }

                //重新上传His该病人全部费用
                //该病人 全部9  所有0  的费用
                string strMsg = "";
                bSuc = DoVaildYbFee(new DataTable(), 9, 0, new Guid(inp), 0, false, out strMsg);

                if (!bSuc)
                {
                    MessageBox.Show(strMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 删除上传费用,重置上传标志[]
        /// </summary>
        /// <param name="inpId"></param>
        /// <returns></returns>
        private bool DoDelInpFeeInfo(string inpId)
        {
            BmiAuditClass clsAdtChk = new BmiAuditClass();

            try
            {
                string inAGENCIES_ID = "";
                string ssql = string.Format("select YBLX,XZLX,INPATIENT_NO from VI_ZY_VINPATIENT_ALL where INPATIENT_ID ='{0}' ", inpId);
                string yblx = "";
                string ybzlx = "";
                string impNo = "";

                string mainID = "";
                try
                {
                    DataTable dtInp = database.GetDataTable(ssql);

                    if (dtInp == null || dtInp.Rows.Count <= 0)
                        throw new Exception("未找到该住院号的病人信息\r");

                    yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
                    ybzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
                    impNo = dtInp.Rows[0]["INPATIENT_NO"].ToString().Trim();
                    if (yblx.Equals("1"))
                    {
                        inAGENCIES_ID = "1";
                        mainID = inpId;
                    }
                    else if (yblx.Equals("3") && ybzlx.Equals("55"))
                    {
                        inAGENCIES_ID = "2";

                        //获取医保主单
                        DataTable dtYbDjInfo = ClsAuditCheck.GetOldYbdjInfo(impNo, yblx, ybzlx, database);
                        mainID = dtYbDjInfo.Rows[0]["akc190"] == null ? "" : dtYbDjInfo.Rows[0]["akc190"].ToString().Trim(); 
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("未找到该住院号的病人信息\r" + ex.Message);
                }

                string sRet = clsAdtChk.deleteClaim4Hospital(mainID, inAGENCIES_ID);
                //string sRet = "1";

                if (sRet.Trim().Equals("0"))
                {
                    throw new Exception("重审删除主单数据返回出错！");
                }
                else if (sRet.Trim().Equals("1") || sRet.Trim().Equals("2"))
                {
                    //先清除主单,再更新标志,会多传一部分费用【就控费来说：比先更新标志,在清除主单 少传数据好】
                    string strSql = string.Format(@"update ZY_YBZNSH_Info set scbz=0 where inpatient_id='{0}' ", inpId);
                    int iRet = database.DoCommand(strSql);

                    if (iRet > 0)
                    {
                        //记录重审 重置上传标志位 的数据行【并行操作 可能实际上传数据行多于实际数据行 】
                        myFunc.SaveLog(FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "医保智审", inpId + " 重审重置上传标志返回数据行【" + iRet + "行】", 1, 4);
                    }
                    else
                    {
                        throw new Exception(" 重审重置上传标志返回数据行【" + iRet + "行】");
                    }
                }

                return true;//1：成功 0：失败
            }
            catch (Exception ex)
            {
                myFunc.SaveLog(FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "医保智审", inpId + " 删除重传操作错误：" + ex.Message, 1, 4);
                MessageBox.Show("医保智审-- 删除重传操作错误：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        /// <summary>
        /// 智审控费接口调用
        /// </summary>
        /// <param name="myTb"></param>
        /// <param name="MNGType">全部9</param>
        /// <param name="Kind">所有0</param>
        /// <param name="BinID"></param>
        /// <param name="BabyID">只处理0</param>
        /// <returns></returns>
        private bool DoVaildYbFee(DataTable myTb, int MNGType, int Kind, Guid BinID, long BabyID, bool IsDelOrd, out string strMsg)
        {
            BabyID = 0;//不处理小孩医嘱和费用

            BmiAuditClass clsAdtChk = new BmiAuditClass();
            ClsAuditCheck cls = new ClsAuditCheck(database);
            strMsg = "";
            string strRet = "";

            string yblx = "";
            string ybzlx = "";
            string zyh = "";
            try
            {
                string inAGENCIES_ID = "";
                string ssql = string.Format("select YBLX,XZLX,INPATIENT_NO from VI_ZY_VINPATIENT_ALL where INPATIENT_ID ='{0}' ", BinID.ToString());
                try
                {
                    DataTable dtInp = database.GetDataTable(ssql);

                    if (dtInp == null || dtInp.Rows.Count <= 0)
                        throw new Exception("未在病人信息\r");

                    yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
                    ybzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
                    zyh = dtInp.Rows[0]["INPATIENT_NO"].ToString().Trim();
                    if (yblx.Equals("1"))
                    {
                        inAGENCIES_ID = "1";
                    }
                    else if (yblx.Equals("3") && ybzlx.Equals("55"))
                    {
                        inAGENCIES_ID = "2";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("未找到该住院号的病人信息\r" + ex.Message);
                }

                if (IsDelOrd)
                {

                    //wait to filter myTb
                    DataTable dtVal = DoGetValidateFeeInfo(myTb, MNGType, Kind);

                    //当天首次执行的医嘱   与开单时自动上传的未计费医嘱当天重复   需删除开单上传的费用
                    DataTable dtDel = cls.GetNoneFeeOrdInfo(dtVal, MNGType, Kind, BinID, BabyID);
                    if (dtDel != null && dtDel.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDel.Rows.Count; i++)
                        {
                            string ordId = dtDel.Rows[i]["order_id"].ToString();

                            strRet = clsAdtChk.deleteDetail4Hospital(BinID.ToString(), ordId, inAGENCIES_ID);

                            if (strRet.Trim().Equals("0"))
                            {
                                //日志记录wait log
                                myFunc.SaveLog(FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "医保智审", "删除医嘱明细--病人：" + BinID.ToString() + "  医嘱：" + ordId + "  返回结果：" + strRet, 1, 4);
                            }
                        }
                    }
                }

                DataTable dtFeeDetails = cls.GetPostFeeInfo(myTb, MNGType, Kind, BinID, BabyID);
                decimal sum = 0M;
                DataTable dtDetail = cls.GetDetailFeeInfo(dtFeeDetails, yblx, ybzlx, out sum);

                DataTable dtMain = ClsAuditCheck.RetAfSetMainInfo(BinID.ToString(), zyh, sum, database);

                strRet = clsAdtChk.ClaimAudit4Hospital_N(dtMain, dtDetail);

                if (strRet.Equals("0") || strRet.Equals("2"))
                {
                    ///返回： 0：审核失败
                    //1：审核结果正常
                    //2：调用步骤出错
                    //3：审核结果有违规（取消）
                    //4：审核结果有违规（保存）；申明方法如下：
                    string err = (strRet.Equals("0") ? "医保智审【审核失败！】" : "医保智审【调用步骤出错！】");
                    err = err + "\r\r返回原因：" + clsAdtChk.l_error_message;
                    throw new Exception(err + " \r\r请手动上传该病人费用到中公网！");
                }
                else if (strRet.Equals("3"))
                {
                    //取消,不保存上传费用
                    //但是his费用已经产生
                    //强行保存这部分费用
                    strRet = clsAdtChk.ClaimAudit4Hospital_S(dtMain, dtDetail);
                    string err = (strRet.Equals("0") ? "医保智审【审核失败！】" : "医保智审【调用步骤出错！】");
                    err = err + "\r\r返回原因：" + clsAdtChk.l_error_message;
                    if (strRet.Equals("0") || strRet.Equals("2"))
                    {
                        throw new Exception("数据保存成功,上传中公网数据成功！ \r\r 医保智能审核检测到存在违规数据,请停止违规医嘱,并冲正费用,再手动上传该病人所有费用到中公网！");
                    }

                    //
                    bool bSc = cls.UpdateScbz(dtDetail);
                    throw new Exception("数据保存成功,上传中公网数据成功," + (bSc ? "成功更新本地标识" : "失败更新本地标识") + "！\r\r医保智能审核检测到存在违规数据,请停止违规医嘱,并冲正费用！ \r\r请在 住院医保费用重审界面通过违规查询功能 重新查看违规明细！");
                }
                //强制提交是否需要日志记录或者相关信息 wait jchl

                strMsg = "";
                bool bSc1 = cls.UpdateScbz(dtDetail);
                if (!bSc1)
                {
                    throw new Exception("数据保存成功,上传中公网数据成功,失败更新本地标识！请手动上传该病人费用！");
                }

                return true;
            }
            catch (Exception ex)
            {
                strMsg = "医保智审" + "：" + ex.Message.ToString().Trim();
                myFunc.SaveLog(FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "医保智审", BinID.ToString() + "医保智审数据上传错误" + "：" + ex.Message.ToString().Trim(), 1, 4);
                //wait  log
                return false;
            }
        }

        /// <summary>
        /// 获取界面上 需要 进行医保智审的数据（有效的）
        /// </summary>
        /// <param name="myTb"></param>
        /// <returns></returns>
        private DataTable DoGetValidateFeeInfo(DataTable myTb, int MNGType, int Kind)
        {
            try
            {
                DataTable dtVal = myTb.Clone();

                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    //如果是选择发送
                    if (MNGType != 9 && Kind == 1)
                    {
                        if (myTb.Rows[i]["选"].ToString() == "False")
                            continue;

                        //dtVal.Rows.Add(myTb.Rows[i]);
                        dtVal.ImportRow(myTb.Rows[i]);
                    }
                }

                return dtVal;
            }
            catch
            {
                throw new Exception("输出有效的需要 进行医保智审的数据 的医嘱费用出错 ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            try
            {
                if (MessageBox.Show("是否确认操作？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    return;

//                string sql = string.Format(@"select a.INPATIENT_NO,a.INPATIENT_ID from VI_ZY_VINPATIENT_ALL a 
//                                                where a.yblx=1  and a.FLAG  in (2,6)  and datediff(DAY,'2015-01-01',IN_DATE)>=0
//                                                and exists(select 1 from ZY_YBZNSH_Info_H b where a.INPATIENT_ID=b.inpatient_id and baby_id='0' and scbz=0)
//                                                order by IN_DATE desc
//                                                ");

                string sql = string.Format(@"select a.INPATIENT_NO,a.INPATIENT_ID from ZY_INPATIENT a 
                                                where a.yblx=1  and a.FLAG=3  and datediff(DAY,'2015-01-01',IN_DATE)>=0
                                                and exists(select 1 from ZY_YBZNSH_Info b where a.INPATIENT_ID=b.inpatient_id and baby_id='0' and scbz=0)
                                                order by IN_DATE desc
                                                ");

                DataTable dtPers = database.GetDataTable(sql);

                for (int i = 0; i < dtPers.Rows.Count; i++)
                {
                    DataRow dr = dtPers.Rows[i];

                    string strInpNo = dr["INPATIENT_NO"].ToString();
                    string strInpId = dr["INPATIENT_ID"].ToString();


                    string strMsg = "";
                    try
                    {
                        bool bSuc = DoVaildYbFee(new DataTable(), 9, 0, new Guid(strInpId), strInpNo, 0, out strMsg);
                        if (!bSuc)
                        {
                            //MessageBox.Show(strInpId + "-" + strInpNo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //return;
                        }
                        else
                        {
                            if (UpdateScbz(strInpId, FrmMdiMain.CurrentUser.EmployeeId.ToString()))
                            {
                                throw new Exception("数据保存成功,上传中公网数据成功,失败更新本地标识！请手动上传该病人费用！");
                            }
                        }
                    }
                    catch
                    {
                        //wait log
                        continue;
                    }
                }
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// 智审控费接口调用
        /// </summary>
        /// <param name="myTb"></param>
        /// <param name="MNGType">全部9</param>
        /// <param name="Kind">所有0</param>
        /// <param name="BinID"></param>
        /// <param name="BabyID">只处理0</param>
        /// <returns></returns>
        private bool DoVaildYbFee(DataTable myTb, int MNGType, int Kind, Guid BinID, string zyh, long BabyID, out string strMsg)
        {
            BabyID = 0;//不处理小孩医嘱和费用

            BmiAuditClass clsAdtChk = new BmiAuditClass();
            ClsAuditCheck cls = new ClsAuditCheck(database);
            strMsg = "";
            string strRet = "";
            //string serr = "0";

            string yblx = "";
            string ybzlx = "";
            try
            {

                string inAGENCIES_ID = "";
                //string ssql = string.Format("select YBLX,XZLX,INPATIENT_NO from VI_ZY_VINPATIENT_ALL where INPATIENT_ID ='{0}' ", BinID.ToString());
                string ssql = string.Format("select YBLX,XZLX,INPATIENT_NO from ZY_INPATIENT where INPATIENT_ID ='{0}' ", BinID.ToString());
                try
                {
                    DataTable dtInp = database.GetDataTable(ssql);

                    if (dtInp == null || dtInp.Rows.Count <= 0)
                        throw new Exception("未找到该住院号的病人信息\r");

                    yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
                    ybzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
                    zyh = dtInp.Rows[0]["INPATIENT_NO"].ToString().Trim();
                    if (yblx.Equals("1"))
                    {
                        inAGENCIES_ID = "1";
                    }
                    else if (yblx.Equals("3") && ybzlx.Equals("55"))
                    {
                        inAGENCIES_ID = "2";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("未找到该住院号的病人信息\r" + ex.Message);
                }

                DataTable dtFeeDetails = GetPostFeeInfo(myTb, MNGType, Kind, BinID, BabyID);
                if (dtFeeDetails.Rows.Count <= 0)
                {
                    //throw new Exception("该病人没有需要上传的费用明细");
                    return false;
                }

                //serr += "2";
                decimal sum = 0M;
                DataTable dtDetail = cls.GetDetailFeeInfo(dtFeeDetails, yblx, ybzlx, true, out sum);
                DataTable dtMain = ClsAuditCheck.RetAfSetMainInfo(BinID.ToString(), zyh, sum, true, database);
                if (dtMain.Rows.Count != 1)
                {
                    //throw new Exception("该病人主单信息不唯一");
                    return false;
                }

                if (dtMain.Rows.Count != 1 || dtDetail.Rows.Count <= 0)
                {
                    return false;
                }

                //serr += "4";
                strRet = clsAdtChk.ClaimAudit4Hospital_S(dtMain, dtDetail);

                if (strRet.Equals("0") || strRet.Equals("2"))
                {
                    ///返回： 0：审核失败
                    //1：审核结果正常
                    //2：调用步骤出错
                    //3：审核结果有违规（取消）
                    //4：审核结果有违规（保存）；申明方法如下：
                    string err = (strRet.Equals("0") ? "医保智审【审核失败！】" : "医保智审【调用步骤出错！】");
                    err = err + "\r\r返回原因：" + clsAdtChk.l_error_message;
                    throw new Exception(err + " \r\r请手动上传该病人费用到中公网！");
                }

                return true;
            }
            catch (Exception ex)
            {
                strMsg = "医保智审数据上传错误" + "：" + ex.Message.ToString().Trim();
                myFunc.SaveLog(FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "医保智审", BinID.ToString() + "医保智审数据上传错误" + "：" + ex.Message.ToString().Trim(), 1, 4);
                //wait  log
                return false;
            }
        }

        /// <summary>
        /// 获取待上传的His明细费用(ZY_YBznsh_info_H：只上传历史数据   或者  ZY_YBznsh_info：只上传普通数据)（His待上传费用： 病人、医嘱、详细费用，此方法只获得 病人、医嘱 费用明细）
        /// </summary>
        /// <param name="myTb">选择的医嘱信息</param>
        /// <param name="MNGType">医嘱类型 0长期医嘱 1临时医嘱 2长期账单 4临时账单 9所有医嘱和账单</param>
        /// <param name="Kind">0所有 1选择 2不发送 3仅药品,(4 全部药品，5 仅口服药，6 非口服药  add by zouchihua 2012-01-13 )</param>
        /// <param name="BinID">病人inpatient_id</param>
        /// <param name="BabyID">baby_id</param>
        /// <returns></returns>
        public DataTable GetPostFeeInfo(DataTable myTb, int MNGType, int Kind, Guid BinID, long BabyID)
        {
            if (MNGType != 9 && Kind == 2)
                return null;

            DataTable dt = new DataTable();

            if (MNGType == 9 && Kind == 0)
            {
                string sql = string.Format(@"select a.XMLY,a.XMID,o.NTYPE,o.DEPT_BR,a.SDVALUE,o.ORDER_DOC,DBO.FUN_ZY_SEEKEMPLOYEENAME(o.ORDER_DOC) 下嘱医生,
                                                o.FREQUENCY 频率,a.ID,a.PRESC_DATE,o.MNGTYPE,o.FIRST_TIMES,o.TERMINAL_TIMES,o.ORDER_SPEC 规格,o.DOSAGE 剂数,e.ISANALYZED
                                                 from vi_ZY_FEE_SPECI a 
                                                inner join vi_ZY_ORDERRECORD o on a.ORDER_ID=o.ORDER_ID and o.DELETE_BIT=0 
                                                inner join vi_ZY_ORDEREXEC e on a.ORDEREXEC_ID=e.ID 
                                                where a.INPATIENT_ID='{0}' and a.DELETE_BIT=0 
                                                and exists
                                                (
                                                    select 1 from ZY_YBznsh_info_H b where b.INPATIENT_ID='{0}' and b.baby_id='{1}' and b.del_bit=0 and b.scbz=0 and a.ID=b.id
                                                )", BinID.ToString(), BabyID.ToString());

                dt = database.GetDataTable(sql);
            }
            else if (MNGType != 9 && Kind == 1)
            {
                int iSel = 0;
                string strCnd = "(";
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    //if (myTb.Rows[i]["选"].ToString() == "False")
                    //    continue;

                    strCnd += "'" + myTb.Rows[i]["Order_ID"] + "',";
                    iSel++;
                }

                if (iSel > 0)
                {
                    strCnd = strCnd.Substring(0, strCnd.Length - 1);
                    strCnd += ")";
                }
                else
                {
                    return dt;
                }

                string sql = string.Format(@"select a.XMLY,a.XMID,o.NTYPE,o.DEPT_BR,a.SDVALUE,o.ORDER_DOC,DBO.FUN_ZY_SEEKEMPLOYEENAME(o.ORDER_DOC) 下嘱医生,
                                                o.FREQUENCY 频率,a.ID,a.PRESC_DATE,o.MNGTYPE,o.FIRST_TIMES,o.TERMINAL_TIMES,o.ORDER_SPEC 规格,o.DOSAGE 剂数,e.ISANALYZED
                                                 from ZY_FEE_SPECI a 
                                                inner join ZY_ORDERRECORD o on a.ORDER_ID=o.ORDER_ID and o.DELETE_BIT=0 
                                                inner join ZY_ORDEREXEC e on a.ORDEREXEC_ID=e.ID 
                                                where 
                                                exists
                                                (
                                                   select 1 from ZY_YBznsh_info_H b where b.order_id in {0} and b.del_bit=0 and b.scbz=0 and a.ID=b.id
                                                ) and a.DELETE_BIT=0 and  a.baby_id=0
                                                ", strCnd);

                dt = database.GetDataTable(sql);
            }

            return dt;
        }

        /// <summary>
        /// 更新整个病人的费用
        /// </summary>
        /// <param name="inpID"></param>
        /// <param name="oprMan"></param>
        /// <returns></returns>
        public bool UpdateScbz(string inpID, string oprMan)
        {
            try
            {
                string sql = string.Format(@"update ZY_YBZNSH_Info_H set scbz=1,mod_man='{1}',mod_date=GETDATE() where inpatient_id='{0}' and baby_id=0 and del_bit=0", inpID, oprMan);
                database.DoCommand(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void FrmYbZnSh_Load(object sender, EventArgs e)
        {
            try
            {
                //binSql = @" SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                //         "   FROM vi_zy_vInpatient_Bed " +
                //         "  WHERE yblx=1 and WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";

                binSql = string.Format(@"SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY FROM vi_zy_vInpatient_Bed
                                         WHERE (yblx=1) and {0}='{1}' 
                                        ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID"
                                        , _iYsHs == 0 ? "DEPT_ID" : "WARD_ID", _iYsHs == 0 ? InstanceForm.BCurrentDept.DeptId.ToString() : InstanceForm.BCurrentDept.WardId);
                //WARD_ID
                LoadWard();

                string[] GrdMappingName1 ={ "床号", "姓名", "住院号", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
                int[] GrdWidth1 ={ 5, 10, 10, 0, 0, 0, 0 };
                int[] Alignment1 ={ 1, 0, 0, 0, 0, 0, 0 };
                myFunc.InitGridSQL(binSql, GrdMappingName1, GrdWidth1, Alignment1, this.myDataGrid2);

                //Modify by jchl
                DataTable dtSrc = myDataGrid2.DataSource as DataTable;
                DoInitCtr(GrdMappingName1, GrdMappingName1, new string[] { "床号", "姓名", "住院号" }, new int[] { 50, 60, 0, 0, 0, 0, 0 }, dtSrc);
            }
            catch
            { }

        }

        private void DoInitCtr(string[] headtext, string[] mappingname, string[] serchFileds, int[] cols, DataTable dtSrc)
        {
            ucShowCard1.Init(headtext, mappingname, serchFileds, cols, dtSrc);
        }

        private void LoadWard()
        {
            DataTable myTb = new DataTable();
            string sSql = "";

            cmbWard.Items.Clear();
            cmbWard.DataSource = null;

            cmbWard.SelectedIndexChanged -= new EventHandler(cmbWard_SelectedIndexChanged);

            cmbWard.Items.Add(InstanceForm.BCurrentDept.WardName);

            cmbWard.SelectedIndexChanged += new EventHandler(cmbWard_SelectedIndexChanged);
        }

        private void cmbWard_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rbIn.Checked)
            {
                binSql = string.Format(@"SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY FROM vi_zy_vInpatient_Bed
                                         WHERE yblx=1 and {0}='{1}' 
                                        ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID"
                                        , _iYsHs == 0 ? "DEPT_ID" : "WARD_ID", _iYsHs == 0 ? InstanceForm.BCurrentDept.DeptId.ToString() : InstanceForm.BCurrentDept.WardId);

                //binSql = @" SELECT   INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                //    "   FROM vi_zy_vInpatient_Bed " +
                //    "  WHERE yblx=1 and WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
            }
            else if (rbTempOut.Checked)
            {
                binSql = string.Format(@"SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY 
                                            FROM vi_zy_vInpatient_All
                                         WHERE yblx=1 and {0}='{1}' 
                                        and flag = 5 ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID"
                                        , _iYsHs == 0 ? "DEPT_ID" : "WARD_ID", _iYsHs == 0 ? InstanceForm.BCurrentDept.DeptId.ToString() : InstanceForm.BCurrentDept.WardId);

                //binSql = @" SELECT   INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                //    "   FROM vi_zy_vInpatient_All " +
                //    "  WHERE yblx=1 and WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and flag = 5 ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
            }
            else if (rbOut.Checked)
            {
                int _outMonth = Convert.ToInt32((new SystemCfg(7023)).Config) * -1;
                DateTime _outDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddMonths(_outMonth);
                //" + _outDate.Date + "
                binSql = string.Format(@" SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY 
                                          FROM vi_zy_vInpatient_All
                                          WHERE yblx=1 and {0}= '{1}' and flag in (2,6) 
                                          and out_Date>= '{2}' ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID"
                                            , _iYsHs == 0 ? "DEPT_ID" : "WARD_ID", _iYsHs == 0 ? InstanceForm.BCurrentDept.DeptId.ToString() : InstanceForm.BCurrentDept.WardId, _outDate.Date);
            }
            else if (rbTrans.Checked)
            {

                binSql = string.Format(@"SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS 住院号 
                                            FROM vi_zy_vInpatient_All
                                         WHERE yblx=1 and  flag in(1,3,4,5) and inpatient_id in (select inpatient_id from zy_transfer_dept where cancel_bit=0 and finish_bit=1 and s_dept_id in (select dept_id from jc_wardrdept where {0}='{1}'
                                        ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID"
                                        , _iYsHs == 0 ? "DEPT_ID" : "WARD_ID", _iYsHs == 0 ? InstanceForm.BCurrentDept.DeptId.ToString() : InstanceForm.BCurrentDept.WardId);//2012-4-22 Modify by zouchihua 只显示在院病人


                //binSql = @" SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS 住院号 " +
                //    "   FROM vi_zy_vInpatient_All " +
                //    "  WHERE yblx=1 and  flag in(1,3,4,5) and inpatient_id in (select inpatient_id from zy_transfer_dept where cancel_bit=0 and finish_bit=1 and s_dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')) " +
                //    "  ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";//2012-4-22 Modify by zouchihua 只显示在院病人
            }
            else if (rbTszl.Checked)
            {
                //                binSql = string.Format(@"SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS 住院号 
                //                                            FROM vi_zy_vInpatient_Bed
                //                                         WHERE yblx=1 and inpatient_id in (select inpatient_id from ZY_TS_APPLY where status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002) and (ts_dept = " + InstanceForm.BCurrentDept.DeptId + " or ts_dept in (select dept_id from jc_wardrdept where {0}='{1}'
                //                                        ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID"
                //                                        , _iYsHs == 0 ? "DEPT_ID" : "WARD_ID", _iYsHs == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardId);//2012-4-22 Modify by zouchihua 只显示在院病人

                binSql = @" SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS 住院号 " +
                    "   FROM vi_zy_vInpatient_Bed " +
                    "  WHERE yblx=1 and inpatient_id in (select inpatient_id from ZY_TS_APPLY where status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002) and (ts_dept = " + InstanceForm.BCurrentDept.DeptId + " or ts_dept in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "'))) " +
                    "   ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
            }
            if (rbTkxs.Checked)
            {
                //add by zouchihua 2014-8-16 他科医嘱
                binSql = string.Format(@"select  INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,a.INPATIENT_ID,a.Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS 住院号 from 
	                                        vi_zy_vInpatient_Bed a join  
	                                        (  select inpatient_id,baby_id from ZY_ORDERRECORD where  ISNULL(tkxs,0) in (select dept_id from JC_WARDRDEPT where WARD_ID   in (select WARD_ID from JC_WARDRDEPT where {0}='{1}' ))
	                                          group by  inpatient_id,baby_id
	                                        ) b on a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id and a.yblx=1"
                    , _iYsHs == 0 ? "DEPT_ID" : "WARD_ID", _iYsHs == 0 ? InstanceForm.BCurrentDept.DeptId.ToString() : InstanceForm.BCurrentDept.WardId);
            }

            try
            {
                string[] GrdMappingName1 ={ "床号", "姓名", "住院号", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
                int[] GrdWidth1 ={ 5, 10, 10, 0, 0, 0, 0 };
                int[] Alignment1 ={ 1, 0, 0, 0, 0, 0, 0 };
                myFunc.InitGridSQL(binSql, GrdMappingName1, GrdWidth1, Alignment1, this.myDataGrid2);

                //Modify by jchl
                DataTable dtSrc = myDataGrid2.DataSource as DataTable;
                DoInitCtr(GrdMappingName1, GrdMappingName1, new string[] { "床号", "姓名", "住院号" }, new int[] { 50, 60, 0, 0, 0, 0, 0 }, dtSrc);
            }
            catch
            { }

            myDataGrid2_CurrentCellChanged(null, null);
        }

        private void myDataGrid2_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable myTb1 = (DataTable)myDataGrid2.DataSource;
            if (myTb1 == null || myTb1.Rows.Count == 0)
            {
                return;
            }

            if ((myDataGrid2.DataSource as DataTable).DefaultView.Count <= 0)
                return;

            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            this.myDataGrid2.Select(nrow);

            DataRow dr;

            if (!ucShowCard1.Key.Trim().Equals(""))
            {
                DataRow[] drs = myTb1.Select("inpatient_id='" + ucShowCard1.Key + "'");
                if (drs.Length <= 0)
                    return;

                dr = drs[0];
            }
            else
            {
                dr = myTb1.Rows[nrow];
            }

            string zyh = dr["住院号"].ToString();
            txtZyh.Text = zyh;
        }

        private void rb_Click(object sender, System.EventArgs e)
        {
            cmbWard_SelectedIndexChanged(null, null);
        }
    }
}