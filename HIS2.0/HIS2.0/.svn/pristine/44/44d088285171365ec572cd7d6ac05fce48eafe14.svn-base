using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenHIS.BLL;
using TrasenFrame.Classes;
using TszyHIS;
namespace TrasenHIS
{
    class patient
    {

        /// <summary>
        /// 保存和修改病人信息及入院信息
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string SaveInpatient(DataSet dset, RelationalDatabase db)
        {
            string returnInfo = "";
            //TrasenFrame.Forms.FrmMdiMain.Database = db;
            try
            {

                string inpatient_no = FormatZyh(Convertor.IsNull(dset.Tables["message"].Rows[0]["zyh"], ""), db);
                string inpatient_id = "";
                DataTable tbinpatient = db.GetDataTable("select * from zy_inpatient where inpatient_no='" + inpatient_no + "'");
                if (tbinpatient.Rows.Count > 0)
                    inpatient_id = tbinpatient.Rows[0]["inpatient_id"].ToString();
                else
                    inpatient_id = Guid.Empty.ToString();

                TszyHIS.Inpatient _inpatient = new TszyHIS.Inpatient(new Guid(inpatient_id), db);
                TszyHIS.Patient _patient = new TszyHIS.Patient(_inpatient.PatientID, db);

                //保存病人
                try
                {
                    db.BeginTransaction();

                    #region 保存病人基本信息
                    _patient.Name = Convertor.IsNull(dset.Tables[0].Rows[0]["xm"], "");
                    _patient.Sex = Convertor.IsNull(dset.Tables[0].Rows[0]["xb"], "") == "男" ? 1 : 2;
                    if (Convertor.IsNull(dset.Tables[0].Rows[0]["csrq"], "") != "")
                        _patient.Birthday = DateTime.ParseExact(dset.Tables[0].Rows[0]["csrq"].ToString(), "yyyyMMdd", null);
                    else
                        _patient.Birthday = DateTime.Now;

                    _patient.BirthPlace = "";
                    _patient.Maritals = 0;
                    _patient.Social_No = Convertor.IsNull(dset.Tables[0].Rows[0]["sfzh"], "");
                    _patient.Times = 0;
                    _patient.Clinic_No = "";
                    _patient.Home_Country = "";
                    _patient.Home_ZIP = Convertor.IsNull(dset.Tables[0].Rows[0]["jtyzbm"], "");
                    _patient.Home_Addr = Convertor.IsNull(dset.Tables[0].Rows[0]["jtdz"], "");
                    _patient.Home_Tel = Convertor.IsNull(dset.Tables[0].Rows[0]["jtdh"], "");
                    _patient.Company = Convertor.IsNull(dset.Tables[0].Rows[0]["dwmc"], "");
                    _patient.Company_Addr = Convertor.IsNull(dset.Tables[0].Rows[0]["dwdz"], "");
                    _patient.Company_Tel = "";
                    _patient.Linkman = Convertor.IsNull(dset.Tables[0].Rows[0]["lxr"], "");
                    _patient.Linkman_Tel = Convertor.IsNull(dset.Tables[0].Rows[0]["lxrdh"], "");
                    _patient.Relation = 0;
                    _patient.Linkman_Addr = Convertor.IsNull(dset.Tables[0].Rows[0]["lxrdz"], "");
                    _patient.Nationality = "";
                    _patient.Folk = "";
                    _patient.Door_Country = "";
                    _patient.Door_Street = "";
                    _patient.Job = "";
                    _patient.Native = "";
                    _patient.Bah = "";

                    if (!_patient.Save())
                    {
                        throw new Exception("病人基本信息保存失败！");
                    }
                    #endregion

                    #region 住院对象并保存
                    //判断结算方式
                    TszyHIS.DischargeMode jslx = new TszyHIS.DischargeMode();
                    jslx = TszyHIS.DischargeMode.Self_DischargeMode;

                    string gflbmc = Convertor.IsNull(dset.Tables["message"].Rows[0]["gflbmc"], "");
                    string yblxid = Convertor.IsNull(db.GetDataResult("select * from jc_ybzlx where name like '" + gflbmc + "'"), "");
                    if (yblxid != "")
                    {
                        jslx = TszyHIS.DischargeMode.Insure_DischargeMode;
                        _inpatient.YBLX = Convert.ToInt32(yblxid);
                    }

                    _inpatient.InpatientNo = inpatient_no;
                    string _sdeptid = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, Convertor.IsNull(dset.Tables["message"].Rows[0]["deptid"], ""), db);
                    if (_sdeptid == "") throw new Exception("没有找到科室匹配信息");

                    string _sDocid = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, Convertor.IsNull(dset.Tables["message"].Rows[0]["zrys"], ""), db);
                    if (_sDocid == "")
                    {
                        _sDocid = "0";
                        //throw new Exception("没有找到医生匹配信息");
                    }
                    _inpatient.Book_User = '0';


                    _inpatient.PatientID = _patient.PatientID;
                    _inpatient.DischargeType = jslx;
                    _inpatient.PatientType = 1;
                    _inpatient.KSBH = Convert.ToInt64(_sdeptid);
                    _inpatient.ZZ_Doc = Convert.ToInt64(Convertor.IsNull(_sDocid, "0"));
                    _inpatient.Clinic_Doc = Convert.ToInt64(Convertor.IsNull(_sDocid, "0"));
                    _inpatient.Clinic_Diagnosis = Convertor.IsNull(dset.Tables["message"].Rows[0]["ryzd"], "");
                    _inpatient.In_Diagnosis = Convertor.IsNull(dset.Tables["message"].Rows[0]["ryzd"], "");
                    _inpatient.In_status = 0;//入院状况

                    if (Convertor.IsNull(dset.Tables[0].Rows[0]["inhostime"], "") != "")
                        _inpatient.In_date = Convert.ToDateTime(dset.Tables[0].Rows[0]["inhostime"]);
                    else
                        _inpatient.In_date = DateTime.Now;

                    _inpatient.In_dept = Convert.ToInt64(_sdeptid);
                    _inpatient.SickDescription = "";//病人描述
                    _inpatient.Warrantor = "";//担保人
                    _inpatient.Book_User = 0;
                    _inpatient.InpatientNo = inpatient_no;
                    _inpatient.Lxr = _patient.Linkman;
                    _inpatient.Lxrgx = _patient.Relation.ToString();
                    _inpatient.Lxrdz = _patient.Linkman_Addr;
                    //inpatient.Lxrdh = _patient.Linkman_Tel;
                    //Modify By Kevin 2013-07-03
                    _inpatient.Lxrdh = Convertor.IsNull(dset.Tables["message"].Rows[0]["lxrdh"], "");
                    _inpatient.Rytj = 9; //Add By Tany 2010-03-20
                    _inpatient.Ylzh = Convertor.IsNull(dset.Tables["message"].Rows[0]["ylzh"], "");
                    _inpatient.Yjj_Limit = 0;
                    //Modify By Kevin 2013-07-30 增加病案号
                    //((ISInpatient)inpatient).InpatientBANo = Convertor.IsNull(txtBAH.Text.Trim(), txtZYH.Text.Trim());
                    _inpatient.InpatientBANo = Convertor.IsNull(dset.Tables["message"].Rows[0]["patientid"], "");
                    if (!_inpatient.Save())
                    {
                        db.RollbackTransaction();//保存失败事务回滚
                        _inpatient = null;
                        _patient = null;
                        _inpatient = null;
                    }

                    #endregion

                    db.CommitTransaction();
                    System.String[] str = { "0", "保存成功", _inpatient.PatientID.ToString(), _inpatient.InpatientID.ToString() };
                    returnInfo = HisFunctions.GetResponseString("SaveInpatient", str);
                }
                catch (Exception err)
                {
                    db.RollbackTransaction();
                    //try
                    //{
                    //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                    //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                    //}
                    //catch (System.Exception erre)
                    //{
                    //}
                    throw err;
                }

                //床位信息
                string oldbedNo = Convertor.IsNull(dset.Tables["message"].Rows[0]["bedno"], "");
                if (oldbedNo != "")
                {
                    try
                    {
                        AssignBed(dset, db);
                    }
                    catch
                    {
                    }
                }

                //管床医生
                string oldzrys = Convertor.IsNull(dset.Tables["message"].Rows[0]["zrys"], "");
                if (oldzrys != "" && oldbedNo == "")
                {
                    try
                    {
                        long docId = Convert.ToInt64(HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, oldzrys, db));
                        ChangeDOC("", 6, _inpatient.InpatientID, 0, docId, 0, TrasenFrame.Forms.FrmMdiMain.Jgbm, db);
                    }
                    catch
                    {
                    }
                }

                return returnInfo;
            }
            catch (Exception err)
            {

                throw err;
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }
        /// <summary>
        /// 保存预收款信息
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string SaveDeposits(DataSet dset, RelationalDatabase db)
        {
            //TrasenFrame.Forms.FrmMdiMain.Database = db;
            TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgmc = "";
            try
            {
                db.BeginTransaction();

                string inpatient_no = FormatZyh(Convertor.IsNull(dset.Tables["message"].Rows[0]["zyh"], ""), db);
                string inpatient_id = "";
                DataTable tbinpatient = db.GetDataTable("select * from zy_inpatient where inpatient_no='" + inpatient_no + "'");
                if (tbinpatient.Rows.Count > 0)
                    inpatient_id = tbinpatient.Rows[0]["inpatient_id"].ToString();
                else
                    inpatient_id = Guid.Empty.ToString();

                TszyHIS.Inpatient _inpatient = new TszyHIS.Inpatient(new Guid(inpatient_id), db);
                TszyHIS.Patient _patient = new TszyHIS.Patient(_inpatient.PatientID, db);
                if (Convertor.IsNull(_inpatient.InpatientID, Guid.Empty.ToString()) == Guid.Empty.ToString()) throw new Exception("没有找到病人的入院信息");

                PayMode pay;
                string yjjlx = Convertor.IsNull(dset.Tables["message"].Rows[0]["yjjlx"], "");
                pay = PayMode.Cash;
                if (yjjlx == "银行卡") pay = PayMode.Pos;
                if (yjjlx == "现金") pay = PayMode.Cash;
                if (yjjlx == "支票") pay = PayMode.Check;

                string _djybm = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, Convertor.IsNull(dset.Tables["message"].Rows[0]["djybm"], ""), db);
                if (_djybm == "") throw new Exception("没有找到登记员匹配信息");

                //找用户
                DataTable tbuser = db.GetDataTable("select * from pub_user where employee_id=" + _djybm + "");
                User _currentUser = null;
                if (tbuser.Rows.Count > 0)
                    _currentUser = new User(Convert.ToInt32(tbuser.Rows[0]["id"]), db);
                else
                    throw new Exception("没有找到登记员的登录用户信息！");

                Bills bill = new Bills(_currentUser, BillType.LSSJ, db);
                bill.BillNo = Convert.ToInt64(Convertor.IsNull(dset.Tables["message"].Rows[0]["jylsh"], "0"));
                bill.BillValue = Convert.ToDecimal(dset.Tables["message"].Rows[0]["yjj"]);

                Department _currentDept = new Department();
                ts_mz_class.ReadCard readCard = new ts_mz_class.ReadCard(Guid.Empty, db);

                DataTable tbdepostis = db.GetDataTable("select * from zy_deposits where billno=" + bill.BillNo + " and inpatient_id='" + _inpatient.InpatientID + "'");
                if (tbdepostis.Rows.Count == 0)
                {
                    _inpatient.Deposits(DepositsTrans.预交, pay,
                        Convert.ToDecimal(dset.Tables["message"].Rows[0]["yjj"]),
                        bill, "", "", "",
                      true, _currentUser, _currentDept, Convert.ToDateTime(Convertor.IsNull(dset.Tables["message"].Rows[0]["djsj"], "")), readCard);
                }

                db.CommitTransaction();

                tbdepostis = db.GetDataTable("select * from zy_deposits where billno=" + bill.BillNo + " and inpatient_id='" + _inpatient.InpatientID + "'");



                if (tbdepostis.Rows.Count > 0)
                {
                    System.String[] str = { "0", "保存成功", tbdepostis.Rows[0]["id"].ToString(), _inpatient.GetDeposits(true).ToString() };

                    return HisFunctions.GetResponseString("SaveDeposits", str);
                }
                else
                {
                    System.String[] str = { "-1", "提交后没有找到该单据记录", "", _inpatient.GetDeposits(true).ToString() };

                    return HisFunctions.GetResponseString("SaveDeposits", str);
                }
            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                throw err;
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }

        /// <summary>
        /// 更新出区和出院状态
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string SaveCyzt(DataSet dset, RelationalDatabase db)
        {
            try
            {
                //TrasenFrame.Forms.FrmMdiMain.Database = db;
                TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
                TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
                TrasenFrame.Forms.FrmMdiMain.Jgmc = "";

                db.BeginTransaction();

                string inpatient_no = FormatZyh(Convertor.IsNull(dset.Tables["message"].Rows[0]["zyh"], ""), db);
                string inpatient_id = "";
                DataTable tbinpatient = db.GetDataTable("select * from zy_inpatient where inpatient_no='" + inpatient_no + "'");
                if (tbinpatient.Rows.Count > 0)
                    inpatient_id = tbinpatient.Rows[0]["inpatient_id"].ToString();
                else
                    inpatient_id = Guid.Empty.ToString();

                TszyHIS.Inpatient _inpatient = new TszyHIS.Inpatient(new Guid(inpatient_id), db);
                TszyHIS.Patient _patient = new TszyHIS.Patient(_inpatient.PatientID, db);
                if (Convertor.IsNull(_inpatient.InpatientID, Guid.Empty.ToString()) == Guid.Empty.ToString()) throw new Exception("没有找到病人的入院信息");

                DataRow row = dset.Tables[0].Rows[0];
                string jszt = row["jszt"].ToString();
                string cyrq = row["cyrq"].ToString();
                string ksrq = row["ksrq"].ToString();
                string jsrq = row["jsrq"].ToString();
                string ylzfy = row["ylzfy"].ToString();
                string ybzf = row["ybzf"].ToString();
                string zfje = row["zfje"].ToString();
                string djrq = row["djrq"].ToString();
                string djybm = row["djybm"].ToString();
                string _djybm = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, djybm, db);
                if (_djybm == "") throw new Exception("没有找到登记员匹配信息");

                string ssql = "";
                //出区
                if (jszt == "1")
                {
                    ssql = "update  zy_inpatient set flag=5 ,out_date='" + Convert.ToDateTime(cyrq).ToShortDateString() + "' where inpatient_id='" + _inpatient.InpatientID + "' and flag<5";
                    int x = db.DoCommand(ssql);
                    if (x != 1) throw new Exception("没有更新到记录");

                    ssql = "update ZY_BEDDICTION set inpatient_id=null,baby_id=null,inpatient_dept=null,bedsex=null where INPATIENT_ID='" + _inpatient.InpatientID + "'";
                    x = db.DoCommand(ssql);
                }
                //取消出区
                if (jszt == "2")
                {
                    ssql = "update  zy_inpatient set flag=1 ,out_date=null where inpatient_id='" + _inpatient.InpatientID + "' and flag=5";
                    int x = db.DoCommand(ssql);
                    if (x != 1) throw new Exception("没有更新到记录");
                }

                //结算
                string dischargeid = Convert.ToString(db.GetDataResult("select dbo.FUN_GETGUID(newid(),getdate()) "));
                if (jszt == "3")
                {
                    //先出区
                    ssql = "update  zy_inpatient set flag=5 ,out_date='" + Convert.ToDateTime(cyrq).ToString() + "' where inpatient_id='" + _inpatient.InpatientID + "' and flag<5";
                    int x = db.DoCommand(ssql);

                    ssql = "update ZY_BEDDICTION set inpatient_id=null,baby_id=null,inpatient_dept=null,bedsex=null where INPATIENT_ID='" + _inpatient.InpatientID + "'";
                    x = db.DoCommand(ssql);

                    //结算
                    ssql = "update  zy_inpatient set flag=6 ,out_date='" + Convert.ToDateTime(cyrq).ToString() + "',discharge_date='" + Convert.ToDateTime(djrq).ToString() + "' where inpatient_id='" + _inpatient.InpatientID + "' and flag=5";
                    x = db.DoCommand(ssql);
                    if (x != 1) throw new Exception("没有更新到记录");

                    ssql = "insert into zy_discharge(id,INPATIENT_ID,DEPT_ID,NTYPE,DISCHARGE_DATE,DISCHARGE_BDATE,DISCHARGE_EDATE,USERID,DEPTOSITS,NFEE,YB_FEE,SELF_FEE,BILLNO,jgbm)" +
                        "values('" + dischargeid + "','" + _inpatient.InpatientID + "'," + _inpatient.In_dept + ",1,'" + jsrq + "','" + ksrq + "','" + jsrq + "'," + _djybm + ",0," + ylzfy + "," + ybzf + "," + zfje + ",0," + TrasenFrame.Forms.FrmMdiMain.Jgbm + ")";
                    x = db.DoCommand(ssql);
                    ssql = "update zy_deposits set discharge_bit=1 ,discharge_id='" + dischargeid + "' where inpatient_id='" + _inpatient.InpatientID + "' and discharge_bit=0";
                    x = db.DoCommand(ssql);
                    ssql = "update zy_fee_speci set discharge_bit=1 ,discharge_id='" + dischargeid + "' where inpatient_id='" + _inpatient.InpatientID + "' and discharge_bit=0";
                    x = db.DoCommand(ssql);

                    //这里需要判断，但是暂时屏蔽 Modify By Tany 2014-05-05
                    //decimal zfy = Convert.ToDecimal(Convertor.IsNull(db.GetDataResult("select  sum(sdvalue) from zy_fee_speci where  inpatient_id='" + _inpatient.InpatientID + "' and  discharge_id='" + dischargeid + "' and delete_bit=0"), "0"));
                    //decimal _zfy_oldhis = Convert.ToDecimal(ylzfy);
                    //if (zfy != _zfy_oldhis)
                    //    throw new Exception("新HIS总费用与老HIS不一致");
                }

                //取消结算
                string un_dischargeid = Convert.ToString(db.GetDataResult("select dbo.FUN_GETGUID(newid(),getdate()) "));
                if (jszt == "4")
                {
                    dischargeid = Convert.ToString(db.GetDataResult("select id from zy_discharge where inpatient_id='" + _inpatient.InpatientID + "' and cz_flag=0 "));
                    ssql = "update  zy_inpatient set flag=5 ,out_date='" + Convert.ToDateTime(cyrq).ToShortDateString() + "' where inpatient_id='" + _inpatient.InpatientID + "' and flag=6 ";
                    int x = db.DoCommand(ssql);
                    if (x != 1) throw new Exception("没有更新到记录");

                    ssql = "insert into zy_discharge(id,INPATIENT_ID,DEPT_ID,NTYPE,DISCHARGE_DATE,DISCHARGE_BDATE,DISCHARGE_EDATE,USERID,DEPTOSITS,NFEE,YB_FEE,SELF_FEE,BILLNO,jgbm,cz_id,cz_flag)" +
                        "values('" + un_dischargeid + "','" + _inpatient.InpatientID + "'," + _inpatient.In_dept + ",1,'" + jsrq + "','" + ksrq + "','" + jsrq + "'," + _djybm + ",0," + ylzfy + "," + ybzf + "," + zfje + ",0," + TrasenFrame.Forms.FrmMdiMain.Jgbm + ",'" + dischargeid + "',2)";
                    x = db.DoCommand(ssql);
                    ssql = "update zy_discharge set cz_flag=1 where id='" + dischargeid + "'";
                    x = db.DoCommand(ssql);

                    ssql = "update zy_deposits set discharge_bit=0 ,discharge_id=null where inpatient_id='" + _inpatient.InpatientID + "' and discharge_bit=1";
                    x = db.DoCommand(ssql);
                    ssql = "update zy_fee_speci set discharge_bit=0 ,discharge_id=null where inpatient_id='" + _inpatient.InpatientID + "' and discharge_bit=1";
                    x = db.DoCommand(ssql);

                    //取消结算不需要判断费用平衡
                    //decimal zfy = Convert.ToDecimal(Convertor.IsNull(db.GetDataResult("select  sum(sdvalue) from zy_fee_speci where  inpatient_id='" + _inpatient.InpatientID + "' and  discharge_id='" + dischargeid + "' and delete_bit=0"), "0"));
                    //decimal _zfy_oldhis = Convert.ToDecimal(ylzfy);
                    //if (zfy != _zfy_oldhis)
                    //    throw new Exception("新HIS总费用与老HIS不一致");
                }

                db.CommitTransaction();

                System.String[] str = { "0", "保存成功", dischargeid, "" };
                return HisFunctions.GetResponseString("SaveCyzt", str);

            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                throw err;
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }

        /// <summary>
        /// 病人出区
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string InpatientOut(DataSet dset, RelationalDatabase db)
        {
            try
            {
                //TrasenFrame.Forms.FrmMdiMain.Database = db;
                TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
                TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
                TrasenFrame.Forms.FrmMdiMain.Jgmc = "";

                db.BeginTransaction();

                string inpatient_no = FormatZyh(Convertor.IsNull(dset.Tables["message"].Rows[0]["zyh"], ""), db);
                string inpatient_id = "";
                DataTable tbinpatient = db.GetDataTable("select * from zy_inpatient where inpatient_no='" + inpatient_no + "'");
                if (tbinpatient.Rows.Count > 0)
                    inpatient_id = tbinpatient.Rows[0]["inpatient_id"].ToString();
                else
                    inpatient_id = Guid.Empty.ToString();

                TszyHIS.Inpatient _inpatient = new TszyHIS.Inpatient(new Guid(inpatient_id), db);
                TszyHIS.Patient _patient = new TszyHIS.Patient(_inpatient.PatientID, db);
                if (Convertor.IsNull(_inpatient.InpatientID, Guid.Empty.ToString()) == Guid.Empty.ToString()) throw new Exception("没有找到病人的入院信息");

                DataRow row = dset.Tables[0].Rows[0];
                string cyrq = row["outhostime"].ToString();

                string ssql = "";

                ssql = "update  zy_inpatient set flag=5 ,out_date='" + Convert.ToDateTime(cyrq).ToShortDateString() + "' where inpatient_id='" + _inpatient.InpatientID + "' and flag<5";
                int x = db.DoCommand(ssql);
                if (x != 1) throw new Exception("没有更新到记录");

                ssql = "update ZY_BEDDICTION set inpatient_id=null,baby_id=null,inpatient_dept=null,bedsex=null where INPATIENT_ID='" + _inpatient.InpatientID + "'";
                x = db.DoCommand(ssql);

                db.CommitTransaction();

                System.String[] str = { "0", "保存成功", "", "" };
                return HisFunctions.GetResponseString("InpatientOut", str);

            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                throw err;
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }

        /// <summary>
        /// 分配床位
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string AssignBed(DataSet dset, RelationalDatabase db)
        {
            string _outmsg = "";
            int _outcode = 0;
            try
            {
                //string sSql, int nMode, Guid bedID, long deptID, Guid inpatientID, long BabyID, string sex, string Room_NO, int isBF, int isMYTS, DateTime d_Date, long OperID, int isInput_ZD, int isUpdate, int isTmpin, int Jgbm
                //TrasenFrame.Forms.FrmMdiMain.Database = db;
                TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
                TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
                TrasenFrame.Forms.FrmMdiMain.Jgmc = "";

                db.BeginTransaction();

                string oldbedNo = Convertor.IsNull(dset.Tables["message"].Rows[0]["bedno"], "");
                if (oldbedNo == "")
                {
                    throw new Exception("床号bedno为空！");
                }
                string oldks = Convertor.IsNull(dset.Tables["message"].Rows[0]["deptid"], "");
                if (oldks == "")
                {
                    throw new Exception("科室deptid为空！");
                }
                string inpatient_no = FormatZyh(Convertor.IsNull(dset.Tables["message"].Rows[0]["zyh"], ""), db);
                string inpatient_id = "";
                DataTable tbinpatient = db.GetDataTable("select * from vi_ZY_vINPATIENT_all where inpatient_no='" + inpatient_no + "'");
                if (tbinpatient.Rows.Count > 0)
                    inpatient_id = tbinpatient.Rows[0]["inpatient_id"].ToString();
                else
                    throw new Exception("未找到该住院号[" + inpatient_no + "]的病人信息！");

                if (Convertor.IsNull(tbinpatient.Rows[0]["bed_id"], "") != "")
                {
                    throw new Exception("该病人已经分配床位[" + tbinpatient.Rows[0]["ward_name"].ToString() + "  " + tbinpatient.Rows[0]["bed_no"].ToString() + "床]");
                }


                string bedID = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.ZY_BEDDICTION, oldks + "||" + oldbedNo, db);
                if (bedID == "")
                {
                    throw new Exception("未找到该床号[" + oldks + "||" + oldbedNo + "]对应的床位信息！");
                }

                DataTable bedTb = db.GetDataTable("select * from zy_beddiction where bed_id='" + bedID + "'");
                if (Convertor.IsNull(bedTb.Rows[0]["inpatient_id"], "") != "")
                {
                    throw new Exception("该床位已经有病人！");
                }

                ParameterEx[] parameters = new ParameterEx[18];

                string sSql = "sp_zyhs_bedassign";
                parameters[0].Value = 1;
                parameters[0].Text = "@nmode";
                parameters[1].Value = bedID;
                parameters[1].Text = "@bedid";
                parameters[2].Value = tbinpatient.Rows[0]["ward_id"].ToString();
                parameters[2].Text = "@wardid";
                parameters[3].Value = tbinpatient.Rows[0]["dept_id"].ToString();
                parameters[3].Text = "@deptid";
                parameters[4].Value = inpatient_id;
                parameters[4].Text = "@inpatientid";
                parameters[5].Value = tbinpatient.Rows[0]["baby_id"].ToString();
                parameters[5].Text = "@babyid";
                parameters[6].Value = tbinpatient.Rows[0]["sex_name"].ToString();
                parameters[6].Text = "@sex";
                parameters[7].Value = Convertor.IsNull(bedTb.Rows[0]["room_no"], "");
                parameters[7].Text = "@roomno";
                parameters[8].Value = 0;
                parameters[8].Text = "@isbf";
                parameters[9].Value = 0;
                parameters[9].Text = "@ismyts";
                parameters[10].Value = tbinpatient.Rows[0]["in_date"].ToString();
                parameters[10].Text = "@date";
                parameters[11].Value = 0;
                parameters[11].Text = "@operid";
                parameters[12].Value = 1;
                parameters[12].Text = "@isinputzd";
                parameters[13].Value = 1;
                parameters[13].Text = "@isupdateindate";
                parameters[14].Value = 1;
                parameters[14].Text = "@tmpin";
                parameters[15].Text = "@outcode";
                parameters[15].ParaSize = 100;
                parameters[15].ParaDirection = ParameterDirection.Output;
                parameters[16].Text = "@outmsg";
                parameters[16].ParaSize = 50;
                parameters[16].ParaDirection = ParameterDirection.Output;
                parameters[17].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;
                parameters[17].Text = "@jgbm";

                db.DoCommand(sSql, parameters, 60);

                db.CommitTransaction();

                _outmsg = parameters[16].Value.ToString();
                _outcode = Convert.ToInt32(parameters[15].Value);

                //管床医生
                string oldzrys = Convertor.IsNull(dset.Tables["message"].Rows[0]["zrys"], "");
                if (oldzrys != "")
                {
                    try
                    {
                        long docId = Convert.ToInt64(HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, oldzrys, db));
                        ChangeDOC("", 6, new Guid(inpatient_id), 0, docId, 0, TrasenFrame.Forms.FrmMdiMain.Jgbm, db);
                    }
                    catch
                    {
                    }
                }

                System.String[] str = { _outcode.ToString(), _outmsg, bedID, "" };
                return HisFunctions.GetResponseString("AssignBed", str);
            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                throw (err);
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }

        /// <summary>
        /// 修改管床医生
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static bool ChangeDOC(string sSql, int nMode, Guid inpatientID, long BabyID, long DocID, long OperID, int Jgbm, RelationalDatabase db)
        {
            try
            {
                string _outmsg = "";
                int _outcode = 0;
                ParameterEx[] parameters = new ParameterEx[8];

                sSql = "sp_zyhs_docchange";
                parameters[0].Value = nMode;
                parameters[0].Text = "@nmode";
                parameters[1].Value = inpatientID;
                parameters[1].Text = "@inpatientid";
                parameters[2].Value = BabyID;
                parameters[2].Text = "@babyid";
                parameters[3].Value = DocID;
                parameters[3].Text = "@docid";
                parameters[4].Value = OperID;
                parameters[4].Text = "@operid";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].Text = "@outcode";
                parameters[5].ParaSize = 100;
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].Text = "@outmsg";
                parameters[6].ParaSize = 50;
                parameters[7].Value = Jgbm;
                parameters[7].Text = "@Jgbm";

                db.DoCommand(sSql, parameters, 60);
                _outmsg = parameters[6].Value.ToString();
                _outcode = Convert.ToInt32(parameters[5].Value);

                if (_outcode != 0)
                    throw new Exception(_outmsg);
            }
            catch (Exception err)
            {
                throw (err);
            }

            return true;
        }

        /// <summary>
        /// 更改管床医生
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string ChangeGCYS(DataSet dset, RelationalDatabase db)
        {
            //string sSql, int nMode, Guid oldbedID, Guid newbedID, long OperID, int Jgbm
            string _outmsg = "";
            int _outcode = 0;
            try
            {
                //string sSql, int nMode, Guid bedID, long deptID, Guid inpatientID, long BabyID, string sex, string Room_NO, int isBF, int isMYTS, DateTime d_Date, long OperID, int isInput_ZD, int isUpdate, int isTmpin, int Jgbm
                //TrasenFrame.Forms.FrmMdiMain.Database = db;
                TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
                TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
                TrasenFrame.Forms.FrmMdiMain.Jgmc = "";

                db.BeginTransaction();

                //管床医生
                string oldzrys = Convertor.IsNull(dset.Tables["message"].Rows[0]["zrys"], "");
                if (oldzrys == "")
                {
                    throw new Exception("责任医生代码为空！");
                }

                string inpatient_no = FormatZyh(Convertor.IsNull(dset.Tables["message"].Rows[0]["zyh"], ""), db);
                string inpatient_id = "";
                DataTable tbinpatient = db.GetDataTable("select * from vi_ZY_vINPATIENT_all where inpatient_no='" + inpatient_no + "'");
                if (tbinpatient.Rows.Count > 0)
                    inpatient_id = tbinpatient.Rows[0]["inpatient_id"].ToString();
                else
                    throw new Exception("未找到该住院号[" + inpatient_no + "]的病人信息！");

                string docId = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, oldzrys, db);
                if (docId == "")
                {
                    throw new Exception("未找到该医生[" + oldzrys + "]对应的医生信息！");
                }
                long DocID = Convert.ToInt64(docId);

                ParameterEx[] parameters = new ParameterEx[8];

                string sSql = "sp_zyhs_docchange";
                parameters[0].Value = 6;
                parameters[0].Text = "@nmode";
                parameters[1].Value = new Guid(inpatient_id);
                parameters[1].Text = "@inpatientid";
                parameters[2].Value = 0;
                parameters[2].Text = "@babyid";
                parameters[3].Value = DocID;
                parameters[3].Text = "@docid";
                parameters[4].Value = 0;
                parameters[4].Text = "@operid";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].Text = "@outcode";
                parameters[5].ParaSize = 100;
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].Text = "@outmsg";
                parameters[6].ParaSize = 50;
                parameters[7].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;
                parameters[7].Text = "@Jgbm";

                db.DoCommand(sSql, parameters, 60);

                db.CommitTransaction();

                _outmsg = parameters[6].Value.ToString();
                _outcode = Convert.ToInt32(parameters[5].Value);


                System.String[] str = { _outcode.ToString(), _outmsg, docId, "" };
                return HisFunctions.GetResponseString("ChangeGCYS", str);
            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                throw (err);
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }

        /// <summary>
        /// 转床
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string ChangeBed(DataSet dset, RelationalDatabase db)
        {
            //string sSql, int nMode, Guid oldbedID, Guid newbedID, long OperID, int Jgbm
            string _outmsg = "";
            int _outcode = 0;
            try
            {
                //string sSql, int nMode, Guid bedID, long deptID, Guid inpatientID, long BabyID, string sex, string Room_NO, int isBF, int isMYTS, DateTime d_Date, long OperID, int isInput_ZD, int isUpdate, int isTmpin, int Jgbm
                //TrasenFrame.Forms.FrmMdiMain.Database = db;
                TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
                TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
                TrasenFrame.Forms.FrmMdiMain.Jgmc = "";



                string oldbedNo = Convertor.IsNull(dset.Tables["message"].Rows[0]["bedno"], "");
                if (oldbedNo == "")
                {
                    throw new Exception("床号bedno为空！");
                }
                string oldks = Convertor.IsNull(dset.Tables["message"].Rows[0]["deptid"], "");
                if (oldks == "")
                {
                    throw new Exception("科室deptid为空！");
                }
                string inpatient_no = FormatZyh(Convertor.IsNull(dset.Tables["message"].Rows[0]["zyh"], ""), db);
                string inpatient_id = "";
                DataTable tbinpatient = db.GetDataTable("select * from vi_ZY_vINPATIENT_all where inpatient_no='" + inpatient_no + "'");
                if (tbinpatient.Rows.Count > 0)
                    inpatient_id = tbinpatient.Rows[0]["inpatient_id"].ToString();
                else
                    throw new Exception("未找到该住院号[" + inpatient_no + "]的病人信息！");

                string nowbedId = Convertor.IsNull(tbinpatient.Rows[0]["bed_id"], "");
                string bedID = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.ZY_BEDDICTION, oldks + "||" + oldbedNo, db);
                if (bedID == "")
                {
                    throw new Exception("未找到该床号[" + oldks + "||" + oldbedNo + "]对应的床位信息！");
                }

                if (nowbedId.ToUpper() == bedID.ToUpper())
                {
                    throw new Exception("病人已经在该床位上！");
                }

                DataTable bedTb = db.GetDataTable("select * from zy_beddiction where bed_id='" + bedID + "'");
                if (Convertor.IsNull(bedTb.Rows[0]["inpatient_id"], "") != "")
                {
                    throw new Exception("该床位已经有病人！");
                }

                if (Convertor.IsNull(tbinpatient.Rows[0]["bed_id"], Guid.Empty.ToString()) == Guid.Empty.ToString())
                {
                    return AssignBed(dset, db);

                }

                db.BeginTransaction();

                ParameterEx[] parameters = new ParameterEx[7];

                string sSql = "sp_zyhs_bedchange";
                parameters[0].Value = 1;
                parameters[0].Text = "@nmode";
                parameters[1].Value = Convertor.IsNull(tbinpatient.Rows[0]["bed_id"], Guid.Empty.ToString());
                parameters[1].Text = "@oldbedid";
                parameters[2].Value = bedID;
                parameters[2].Text = "@newbedid";
                parameters[3].Value = 0;
                parameters[3].Text = "@operid";
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[4].Text = "@outcode";
                parameters[4].ParaSize = 100;
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].Text = "@outmsg";
                parameters[5].ParaSize = 50;
                parameters[6].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;
                parameters[6].Text = "@Jgbm";

                db.DoCommand(sSql, parameters, 60);

                db.CommitTransaction();

                _outmsg = parameters[5].Value.ToString();
                _outcode = Convert.ToInt32(parameters[4].Value);

                System.String[] str = { _outcode.ToString(), _outmsg, bedID, "" };
                return HisFunctions.GetResponseString("ChangeBed", str);
            }
            catch (Exception err)
            {
                db.RollbackTransaction();

                throw (err);
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }

        /// <summary>
        /// 转科
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string TransDept(DataSet dset, RelationalDatabase db)
        {
            //string sSql, int nMode, Guid BinID, long BabyID, long sDept, long dDept, long OperID, DateTime transDate, Guid TransId
            string _outmsg = "";
            int _outcode = 0;
            try
            {
                //TrasenFrame.Forms.FrmMdiMain.Database = db;
                TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
                TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
                TrasenFrame.Forms.FrmMdiMain.Jgmc = "";

                db.BeginTransaction();

                string oldks = Convertor.IsNull(dset.Tables["message"].Rows[0]["deptid"], "");
                if (oldks == "")
                {
                    throw new Exception("科室deptid为空！");
                }
                string inpatient_no = FormatZyh(Convertor.IsNull(dset.Tables["message"].Rows[0]["zyh"], ""), db);
                string inpatient_id = "";
                DataTable tbinpatient = db.GetDataTable("select * from vi_ZY_vINPATIENT_all where inpatient_no='" + inpatient_no + "'");
                if (tbinpatient.Rows.Count > 0)
                    inpatient_id = tbinpatient.Rows[0]["inpatient_id"].ToString();
                else
                    throw new Exception("未找到该住院号[" + inpatient_no + "]的病人信息！");

                string nowksID = Convertor.IsNull(tbinpatient.Rows[0]["dept_id"], "");
                string ksID = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, oldks, db);
                if (ksID == "")
                {
                    throw new Exception("未找到该科室[" + oldks + "]对应的科室信息！");
                }

                if (nowksID.ToUpper() == ksID.ToUpper())
                {
                    throw new Exception("病人已经在该科室！");
                }

                //转科医嘱操作
                long BaseGroupID = 1;

                string sSql = "select max(Group_Id) as YZH from Zy_OrderRecord(nolock) where inpatient_id='" + inpatient_id + "'";

                DataTable myTb = db.GetDataTable(sSql);
                if (myTb.Rows[0]["YZH"].ToString().Trim() == "")
                {
                    BaseGroupID = 1;
                }
                else
                {
                    BaseGroupID += 1;
                }

                //构成SQL语句,并执行,默认婴儿ID为0，医嘱录入人为医生本人，默认病人科室为医生科室,中草药剂量默认为1,操作员为医生本人
                DateTime now = DateManager.ServerDateTimeByDBType(db);
                string OrderID = Convert.ToString(PubStaticFun.NewGuid());

                sSql = "INSERT INTO ZY_ORDERRECORD(" +
                    "order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,nType,Order_Doc," +
                    "HOItem_ID,xmly,Order_context,Num,Dosage,Unit,book_date," +
                    "Order_bDate,First_times,Order_Usage,frequency," +
                    "Operator,Delete_Bit,status_flag,baby_id,dept_br,exec_dept,serial_no,jgbm)" +
                    " VALUES('" + OrderID + "'," + BaseGroupID.ToString() + ",'" + inpatient_id + "'," + Convertor.IsNull(tbinpatient.Rows[0]["dept_id"], "0") + ",'" + Convertor.IsNull(tbinpatient.Rows[0]["ward_id"], "") + "',0,0," + Convertor.IsNull(tbinpatient.Rows[0]["zy_doc"], "0") + "," +
                    "-1,2,'转'+dbo.fun_getdeptname(" + ksID + "),0,1,'',GetDate()," + "'" + now.ToString() + "',1,'','1'," +
                    "" + Convertor.IsNull(tbinpatient.Rows[0]["zy_doc"], "0") + ",0,5," + "0" + "," + Convertor.IsNull(tbinpatient.Rows[0]["dept_id"], "0") + "," + Convertor.IsNull(tbinpatient.Rows[0]["dept_id"], "0") + ",0," + TrasenFrame.Forms.FrmMdiMain.Jgbm + ") ";
                db.DoCommand(sSql);

                string tran_type = "0";
                string TransID = Convert.ToString(PubStaticFun.NewGuid());
                string sSql0 = "insert into zy_transfer_dept(" +
                    "id,Inpatient_id,S_dept_id,D_dept_id,Transfer_date,Book_date,Operator,description,Baby_id,finish_bit,order_id,CANCEL_BIT,jgbm,Trans_type) " +
                    "values('" + TransID + "','" + inpatient_id + "'," + Convertor.IsNull(tbinpatient.Rows[0]["dept_id"], "0") + "," + ksID + ",'" + now.ToString() + "'," +
                    "GetDate()," + Convertor.IsNull(tbinpatient.Rows[0]["zy_doc"], "0") + ",'转',0,0,'" + OrderID + "',0 ," + TrasenFrame.Forms.FrmMdiMain.Jgbm + "," + tran_type + ")";
                db.DoCommand(sSql0);

                #region
                //if (this.lbStop.Text == "√")
                //{
                //    //停医嘱
                //    myQuery.StopOrders(FrmMdiMain.Database, this.dateTimePicker1.Value.ToString(), this.YS_ID, this.BinID, 0, num);
                //    //停账单
                //    myQuery.StopOrders_ZD(FrmMdiMain.Database, this.dateTimePicker1.Value.ToString(), this.YS_ID, this.BinID, 0, num, 0);

                //    //Modify By Tany 2011-03-07 婴儿和大人一起停医嘱
                //    if (babyTb != null && babyTb.Rows.Count > 0)
                //    {
                //        for (int i = 0; i < babyTb.Rows.Count; i++)
                //        {
                //            //停医嘱
                //            myQuery.StopOrders(FrmMdiMain.Database, this.dateTimePicker1.Value.ToString(), this.YS_ID, this.BinID, Convert.ToInt64(babyTb.Rows[i]["baby_id"]), num);
                //            //停账单
                //            myQuery.StopOrders_ZD(FrmMdiMain.Database, this.dateTimePicker1.Value.ToString(), this.YS_ID, this.BinID, Convert.ToInt64(babyTb.Rows[i]["baby_id"]), num, 0);
                //        }
                //    }
                //}
                #endregion
                //转科医嘱操作完毕

                ParameterEx[] parameters = new ParameterEx[10];

                sSql = "sp_zyhs_transferdept";
                parameters[0].Value = 1;
                parameters[0].Text = "@mode";
                parameters[1].Value = inpatient_id;
                parameters[1].Text = "@inpatient_id";
                parameters[2].Value = 0;
                parameters[2].Text = "@baby_id";
                parameters[3].Value = nowksID;
                parameters[3].Text = "@sdept_id";
                parameters[4].Value = ksID;
                parameters[4].Text = "@ddept_id";
                parameters[5].Value = 0;
                parameters[5].Text = "@operator";
                parameters[6].Value = DateTime.Now;
                parameters[6].Text = "@date";
                parameters[7].Value = TransID;
                parameters[7].Text = "@transid";
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].Text = "@outcode";
                parameters[8].ParaSize = 100;
                parameters[9].ParaDirection = ParameterDirection.Output;
                parameters[9].Text = "@outmsg";
                parameters[9].ParaSize = 50;

                db.DoCommand(sSql, parameters, 60);

                db.CommitTransaction();

                _outmsg = parameters[9].Value.ToString();
                _outcode = Convert.ToInt32(parameters[8].Value);

                System.String[] str = { _outcode.ToString(), _outmsg, ksID, "" };

                //床位信息
                string oldbedNo = Convertor.IsNull(dset.Tables["message"].Rows[0]["bedno"], "");
                if (oldbedNo != "")
                {
                    try
                    {
                        AssignBed(dset, db);
                    }
                    catch
                    {
                    }
                }

                //管床医生
                string oldzrys = Convertor.IsNull(dset.Tables["message"].Rows[0]["zrys"], "");
                if (oldzrys != "" && oldbedNo == "")
                {
                    try
                    {
                        long docId = Convert.ToInt64(HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, oldzrys, db));
                        ChangeDOC("", 6, new Guid(inpatient_id), 0, docId, 0, TrasenFrame.Forms.FrmMdiMain.Jgbm, db);
                    }
                    catch
                    {
                    }
                }

                return HisFunctions.GetResponseString("TransDept", str);
            }
            catch (Exception err)
            {
                db.RollbackTransaction();

                throw (err);
            }
            finally
            {
                //try
                //{
                //    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                //    TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                //}
                //catch
                //{
                //}
            }
        }

        public static string FormatZyh(string _no, RelationalDatabase db)
        {
            string _zero = GetEmptyZyh(db);
            string _zyh = _no;
            DateTime _now = DateManager.ServerDateTimeByDBType(db);
            string _head = "";

            //0=自然流水 1=YYYY+流水 2=YYYYMMDD+流水 3=YY+医院编码+流水
            //Modify by Tany 2009-10-30
            int cfg = Convert.ToInt32(new SystemCfg(5031, db).Config);

            switch (cfg)
            {
                case 1:
                    _head = _now.Year.ToString("0000");
                    break;
                case 2:
                    //Modify By Tany 2010-06-08 住院号第二种方式改为YYMMDD
                    _head = _now.Year.ToString("0000").Substring(2, 2) + _now.Month.ToString("00") + _now.Day.ToString("00");
                    break;
                case 3:
                    _head = _now.Year.ToString().Substring(2, 2) + "";//wxz FrmMdiMain.JgYybm.ToString();
                    break;
                default:
                    _head = "";
                    break;
            }

            try
            {
                if (_no.Length > _zero.Length - _head.Length)
                {
                    throw new Exception("住院号长度已经大于最长长度，请联系系统管理员！");
                }
                else if (_no.Length == _zero.Length - _head.Length)
                {
                    _zyh = _head + _no;
                }
                else
                {
                    _zero = _zero.Substring(0, _zero.Length - _head.Length - _no.Length);
                    _zyh = _head + _zero + _no;
                }

                return _zyh;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public static string GetEmptyZyh(RelationalDatabase db)
        {
            int _inpatientNoLength = Convert.ToInt32(new SystemCfg(5026, db).Config);
            string No = "";
            if (_inpatientNoLength <= 0)
            {
                _inpatientNoLength = 1;
            }
            for (int i = 0; i < _inpatientNoLength; i++)
            {
                No += "0";
            }
            return No;
        }



    }
}
