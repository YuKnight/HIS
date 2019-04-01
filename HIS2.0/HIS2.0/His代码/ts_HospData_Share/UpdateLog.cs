using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
namespace ts_HospData_Share
{
    public class ts_update_log
    {
        public ts_update_log()
        {

        }

        private Guid _id;
        /// <summary>
        /// 主键字段
        /// </summary> 
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _czlx;
        /// <summary>
        /// 
        /// </summary> 
        public int Czlx
        {
            get { return _czlx; }
            set { _czlx = value; }
        }


        private int _czks;
        /// <summary>
        /// 
        /// </summary> 
        public int Czks
        {
            get { return _czks; }
            set { _czks = value; }
        }

        private int _czry;
        /// <summary>
        /// 
        /// </summary> 
        public int Czry
        {
            get { return _czry; }
            set { _czry = value; }
        }

        private string _cznr;
        /// <summary>
        /// 
        /// </summary> 
        public string Cznr
        {
            get { return _cznr; }
            set { _cznr = value; }
        }

        private string _ymc;
        /// <summary>
        /// 
        /// </summary> 
        public string Ymc
        {
            get { return _ymc; }
            set { _ymc = value; }
        }

        private string _ylm;
        /// <summary>
        /// 
        /// </summary> 
        public string Ylm
        {
            get { return _ylm; }
            set { _ylm = value; }
        }

        private string _yzj;
        /// <summary>
        /// 
        /// </summary> 
        public string Yzj
        {
            get { return _yzj; }
            set { _yzj = value; }
        }

        private string _djsj;
        /// <summary>
        /// 
        /// </summary> 
        public string Djsj
        {
            get { return _djsj; }
            set { _djsj = value; }
        }

        private int _djy;
        /// <summary>
        /// 
        /// </summary> 
        public int Djy
        {
            get { return _djy; }
            set { _djy = value; }
        }

        private long _djjgbm;
        /// <summary>
        /// 
        /// </summary> 
        public long Djjgbm
        {
            get { return _djjgbm; }
            set { _djjgbm = value; }
        }

        private long _mbjgbm;
        /// <summary>
        /// 
        /// </summary> 
        public long MbjgbM
        {
            get { return _mbjgbm; }
            set { _mbjgbm = value; }
        }

        private int _mbks;
        /// <summary>
        /// 
        /// </summary> 
        public int Mbks
        {
            get { return _mbks; }
            set { _mbks = value; }
        }

        private int _bwcbz;
        /// <summary>
        /// 
        /// </summary> 
        public int BwcBz
        {
            get { return _bwcbz; }
            set { _bwcbz = value; }
        }

        private string _wcsj;
        /// <summary>
        /// 
        /// </summary> 
        public string Wcsj
        {
            get { return _wcsj; }
            set { _wcsj = value; }
        }

        private int _wcczy;
        /// <summary>
        /// 
        /// </summary> 
        public int Wcczy
        {
            get { return _wcczy; }
            set { _wcczy = value; }
        }

        private string _bz;
        /// <summary>
        /// 
        /// </summary> 
        public string Bz
        {
            get { return _bz; }
            set { _bz = value; }
        }

        private int _bscbz;
        /// <summary>
        /// 
        /// </summary> 
        public int BscBz
        {
            get { return _bscbz; }
            set { _bscbz = value; }
        }

        private Guid _djid;
        /// <summary>
        /// 主键字段
        /// </summary> 
        public Guid Djid
        {
            get { return _djid; }
            set { _djid = value; }
        }

        public ts_update_log(Guid id, RelationalDatabase database)
        {
            if (id == Guid.Empty)
            {
                _czlx = 0;
                _czks = 0;
                _czry = 0;
                _cznr = "";
                _ymc = "";
                _ylm = "";
                _yzj = "";

                _djsj = DateManager.ServerDateTimeByDBType(database).ToString();
                _djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId ;
                _djjgbm = -1;
                _mbjgbm = -1;
                _mbks = 0;
                _bwcbz = 0;
                _wcsj = "";
                _wcczy = 0;
                _bz = "";
                _bscbz = 0;
                _djid = Guid.Empty;
            }
            else
            {
                string ssql = "select * from ts_update_log where id='"+id+"'";
                DataTable tb = database.GetDataTable(ssql);
                if (tb.Rows.Count != 0)
                {
                    _id = new Guid(tb.Rows[0]["id"].ToString());
                    _czlx = Convert.ToInt32(tb.Rows[0]["czlx"]);
                    _czks =Convert.ToInt32(tb.Rows[0]["czks"]);
                    _czry = Convert.ToInt32(tb.Rows[0]["czry"]);
                    _cznr = Convertor.IsNull(tb.Rows[0]["cznr"],"");
                    _ymc  = Convertor.IsNull(tb.Rows[0]["ymc"], "");
                    _ylm = Convertor.IsNull(tb.Rows[0]["ylm"], "");
                    _yzj = Convertor.IsNull(tb.Rows[0]["yzj"], "");
                    _djsj = Convertor.IsNull(tb.Rows[0]["Djsj"], "");
                    _djy = Convert.ToInt32(tb.Rows[0]["Djy"]);
                    _djjgbm = Convert.ToInt32(tb.Rows[0]["Djjgbm"]);
                    _mbjgbm = Convert.ToInt32(tb.Rows[0]["MbjgbM"]);
                    _bwcbz = Convert.ToInt32(tb.Rows[0]["BwcBz"]);
                    _wcsj = Convertor.IsNull(tb.Rows[0]["Wcsj"], "");
                    _wcczy = Convert.ToInt32(tb.Rows[0]["Wcczy"]);
                    _bz  = Convertor.IsNull(tb.Rows[0]["Bz"], "");
                    _bscbz = Convert.ToInt32(tb.Rows[0]["BscBz"]);
                    _djid = new Guid(tb.Rows[0]["djid"].ToString());
                }

            }

        }

        /// <summary>
        /// 保存日志 
        /// </summary>
        /// <param name="czlx">操作类型</param>
        /// <param name="cznr">操作内容</param>
        /// <param name="ymc">源名称 相对于主键的表名 请正确输入表名</param>
        /// <param name="ylm">源名称 相对于主键的字段名</param>
        /// <param name="yzj">表的主键ID 所修改的记录的值</param>
        /// <param name="djjgbm">登记机构编码</param>
        /// <param name="mbks">目标科室 即往来科室 主要是用来验证这个科室所属的机构编码.一般不需填写,只有当有业务往来时,才填 比如转科：请填写目的科室</param>
        /// <param name="bz">备注</param>
        /// <param name="database">数据库连接</param>
        public void Save_log(ts_HospData_Share.czlx lx, string cznr, string ymc,string ylm, string yzj, long djjgbm, int mbks,string bz,out Guid djid,RelationalDatabase database)
        {
            ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)(lx), database);
            if (ty.BscBz == 0)
            {
                _czlx = (int)(lx);
                _czks = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
                _czry = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                _cznr = cznr;
                _ymc = ymc;
                _ylm = ylm;
                _yzj = yzj;
                _djsj = DateManager.ServerDateTimeByDBType(database).ToString();
                _djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                _djjgbm = djjgbm;
                _mbjgbm = -1;
                _mbks = mbks;
                _bz = bz;
                Save(database, out djid);
            }
            else
                djid = Guid.Empty;

        }
        /// <summary>
        /// 保存日志 
        /// </summary>
        /// <param name="czlx">操作类型</param>
        /// <param name="cznr">操作内容</param>
        /// <param name="ymc">源名称 相对于主键的表名 请正确输入表名</param>
        /// <param name="ylm">源名称 相对于主键的字段名</param>
        /// <param name="yzj">表的主键ID 所修改的记录的值</param>
        /// <param name="djjgbm">登记机构编码</param>
        /// <param name="djjgbm">目标机构编码 </param>
        /// <param name="mbks">目标科室 即往来科室 主要是用来验证这个科室所属的机构编码.一般不需填写,只有当有业务往来时,才填 比如转科：请填写目的科室</param>
        /// <param name="bz">备注</param>
        /// <param name="database">数据库连接</param>
        public void Save_log(ts_HospData_Share.czlx lx, string cznr, string ymc, string ylm, string yzj, long djjgbm, long mbjgbm,int mbks, string bz, out Guid djid, RelationalDatabase database)
        {
            ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)(lx), database);
            if (ty.BscBz == 0)
            {
                _czlx = (int)(lx);
                _czks = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
                _czry = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                _cznr = cznr;
                _ymc = ymc;
                _ylm = ylm;
                _yzj = yzj;
                _djsj = DateManager.ServerDateTimeByDBType(database).ToString();
                _djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                _djjgbm = djjgbm;
                _mbjgbm = mbjgbm;
                _mbks = mbks;
                _bz = bz;
                Save(database, out djid);
            }
            else
                djid = Guid.Empty;

        }



        private void Save(RelationalDatabase database,out Guid djid)
        {
            try
            {
                int err_code=-1;
                string err_text="";
                if (_cznr == "") throw new Exception("请输入操作内容");
                if (_djjgbm == 0) throw new Exception("请输入登记机构编码");
                if (_djjgbm == 0) throw new Exception("请输入目标机构编码");
                if (_ymc == "") throw new Exception("请输入源名称");
                if (_yzj == "") throw new Exception("请输入源主键");
                if (_czlx <= 0) throw new Exception("请输入操作类型");

                ParameterEx[] parameters = new ParameterEx[17];
                parameters[0].Text = "@id";
                parameters[0].Value = _id;

                parameters[1].Text = "@czlx";
                parameters[1].Value = _czlx;

                parameters[2].Text = "@czks";
                parameters[2].Value = _czks;

                parameters[3].Text = "@czry";
                parameters[3].Value = _czry;

                parameters[4].Text = "@cznr";
                parameters[4].Value = _cznr;

                parameters[5].Text = "@ymc";
                parameters[5].Value = _ymc;

                parameters[6].Text = "@yzj";
                parameters[6].Value = _yzj;

                parameters[7].Text = "@djsj";
                parameters[7].Value = _djsj;

                parameters[8].Text = "@djy";
                parameters[8].Value = _djy;

                parameters[9].Text = "@djjgbm";
                parameters[9].Value = _djjgbm;

                parameters[10].Text = "@mbjgbm";
                parameters[10].Value = _mbjgbm;

                parameters[11].Text = "@mbks";
                parameters[11].Value = _mbks;

                parameters[12].Text = "@bz";
                parameters[12].Value = _bz;

                parameters[13].Text = "@err_code";
                parameters[13].ParaDirection = ParameterDirection.Output;
                parameters[13].DataType = System.Data.DbType.Int32;
                parameters[13].ParaSize = 100;

                parameters[14].Text = "@err_text";
                parameters[14].ParaDirection = ParameterDirection.Output;
                parameters[14].ParaSize = 100;


                parameters[15].Text = "@ylm";
                parameters[15].Value = _ylm;

                parameters[16].Text = "@djid";
                parameters[16].ParaDirection = ParameterDirection.Output;
                parameters[16].ParaSize = 100;

                database.DoCommand("SP_ts_update_log", parameters, 30);
                err_code = Convert.ToInt32(parameters[13].Value);
                err_text = Convert.ToString(parameters[14].Value);
                djid = new Guid(parameters[16].Value.ToString());
                if (err_code != 0) throw new Exception(err_text);
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }

        }

        /// <summary>
        /// 根据登记匹次来执行
        /// </summary>
        /// <param name="djid"></param>
        /// <param name="database"></param>
        public void Pexec_log(Guid djid,RelationalDatabase database,out string errtext)
        {
            errtext = "";
            try
            {
                string ssql = "select * from ts_update_log where djid='"+djid+"' and bwcbz=0 and bscbz=0";
                DataTable tb = database.GetDataTable(ssql);
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    Guid log_id=new Guid(tb.Rows[i]["id"].ToString());
                    exec_log(log_id, database);

                }
            }
            catch (System.Exception err)
            {
                errtext = err.Message;
            }

        }

        /// <summary>
        /// 根据log的ID来执行
        /// </summary>
        /// <param name="id"></param>
        /// <param name="database"></param>
        public void  exec_log(Guid id, RelationalDatabase database)
        {
            ts_update_log ts=null;
            string czmc="";
            try
            {
                ts = new ts_update_log(id, database);

                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.yp_药品字典修改))
                {
                    czmc = ts_HospData_Share.czlx.yp_药品字典修改.ToString();
                    ts_HospData_Share.yp_cd.update(ts, database);
                }
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.yp_药品合并))
                {
                    czmc = ts_HospData_Share.czlx.yp_药品合并.ToString();
                    ts_HospData_Share.yp_cd.update_hb(ts, database);
                }
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.yp_药品取消合并))
                {
                    czmc = ts_HospData_Share.czlx.yp_药品取消合并.ToString();
                    ts_HospData_Share.yp_cd.update_qxhb(ts, database);
                }

                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.yp_药品调价))
                {
                    czmc = ts_HospData_Share.czlx.yp_药品调价.ToString();
                    ts_HospData_Share.yp_tj.update(ts, database);
                }

                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.yp_药房出库单))
                {
                    czmc = ts_HospData_Share.czlx.yp_药房出库单.ToString();
                    ts_HospData_Share.yp_yfck.update(ts, database);
                }

                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.yp_药库出库单))
                {
                    czmc = ts_HospData_Share.czlx.yp_药库出库单.ToString();
                    ts_HospData_Share.yp_ykck.update(ts, database);
                }

                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.yp_药房申请领药单))
                {
                    czmc = ts_HospData_Share.czlx.yp_药房申请领药单.ToString();
                    ts_HospData_Share.yp_lysq.update(ts, database);
                }
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.yp_药房申请领药单审核))
                {
                    czmc = ts_HospData_Share.czlx.yp_药房申请领药单审核.ToString();
                    ts_HospData_Share.yp_lysq.SH(ts);
                }

                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.yp_删除药房出库单))
                {
                    czmc = ts_HospData_Share.czlx.yp_删除药房出库单.ToString();
                    ts_HospData_Share.yp_yfck.update_DeleteDj(ts, database);
                }

                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.yp_药品基础数据单表修改))
                {
                    czmc = ts_HospData_Share.czlx.yp_药品基础数据单表修改.ToString();
                    ts_HospData_Share.yp_jc.update(ts, database);
                }


                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_科室修改))
                {
                    czmc = ts_HospData_Share.czlx.jc_科室修改.ToString();
                    ts_HospData_Share.jc_ks.update(ts, database);
                }
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_人员修改))
                {
                    czmc = ts_HospData_Share.czlx.jc_人员修改.ToString();
                    ts_HospData_Share.jc_employ.update(ts, database);
                }
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_基础数据单表修改))
                {
                    czmc = ts_HospData_Share.czlx.jc_基础数据单表修改.ToString();
                    ts_HospData_Share.jc_db.update(ts, database);
                }

                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_收费项目修改))
                {
                    czmc = ts_HospData_Share.czlx.jc_收费项目修改.ToString();
                    ts_HospData_Share.jc_sfxm.update(ts, database);
                }

                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_医嘱项目修改))
                {
                    czmc = ts_HospData_Share.czlx.jc_医嘱项目修改.ToString();
                    ts_HospData_Share.jc_yzxm.update(ts, database);
                }


                //tany
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_用户修改))
                {
                    czmc = ts_HospData_Share.czlx.jc_用户修改.ToString();
                    ts_HospData_Share.pub_user.update(ts, database);
                }
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_组菜单修改))
                {
                    czmc = ts_HospData_Share.czlx.jc_组菜单修改.ToString();
                    ts_HospData_Share.pub_group.update_groupmenu(ts, database);
                }
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_组删除))
                {
                    czmc = ts_HospData_Share.czlx.jc_组删除.ToString();
                    ts_HospData_Share.pub_group.delete_group(ts, database);
                }
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_菜单删除))
                {
                    czmc = ts_HospData_Share.czlx.jc_菜单删除.ToString();
                    ts_HospData_Share.pub_menu.delete_menu(ts, database);
                }
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_菜单修改))
                {
                    czmc = ts_HospData_Share.czlx.jc_菜单修改.ToString();
                    ts_HospData_Share.pub_menu.update(ts, database);
                }
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_系统菜单修改))
                {
                    czmc = ts_HospData_Share.czlx.jc_系统菜单修改.ToString();
                    ts_HospData_Share.pub_menu.update_systemmenu(ts, database);
                }
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_修改升级文件))
                {
                    czmc = ts_HospData_Share.czlx.jc_修改升级文件.ToString();
                    ts_HospData_Share.pub_systemupdate.update(ts, database);
                }
                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_删除升级文件))
                {
                    czmc = ts_HospData_Share.czlx.jc_删除升级文件.ToString();
                    ts_HospData_Share.pub_systemupdate.delete(ts, database);
                }

                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.jc_处方模板))
                {
                    czmc = ts_HospData_Share.czlx.jc_处方模板.ToString();
                    ts_HospData_Share.jc_cfmb.update(ts, database);
                }


                if (ts.Czlx == Convert.ToInt32(ts_HospData_Share.czlx.br_病人信息同步))
                {
                    czmc = ts_HospData_Share.czlx.br_病人信息同步.ToString();
                    ts_HospData_Share.br_brxx.update(ts, database);
                }


            }
            catch (System.Exception err)
            {
                string jgmc = "";
                DataTable tb = database.GetDataTable("select jgmc from jc_jgbm where jgbm="+ts.MbjgbM+"");
                if (tb.Rows.Count > 0) jgmc = tb.Rows[0][0].ToString();
                string _sDate = DateManager.ServerDateTimeByDBType(database).ToString();
                string err1 = err.Message.ToString();err1= err1.Replace("'", " ");
                string ssql = "insert into ts_update_errlog(logid,sbyy,djsj,djy,ipdz)values('" + ts.Id + "','" + err1 + "','" + _sDate + "'," + ts.Czry + ",'" + TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress() + "') ";
                database.DoCommand(ssql);
                throw new Exception("\n\n 在向 ["+jgmc+"] 执行 ["+czmc+"] 时遇到下列问题:\n\n" +err.Message);
            }

        }

        public static DataTable Getlog(bool wc, int czlx, string djsj1, string djsj2, int czks, int czry, RelationalDatabase database)
        {
            int bwcbz = wc == true ? 1 : 0;
            string ssql = "select *,dbo.fun_getempname(czry) 登记员,dbo.fun_getempname(wcczy) 操作员,dbo.fun_getdeptname(czks) 操作科室,jgmc 目标名称 " +
                " from ts_update_log a inner join ts_update_type b on a.czlx=b.czlx inner join jc_jgbm c on a.mbjgbm=c.jgbm and a.bscbz=0  "+
                " where bwcbz=" + bwcbz + "";
            if (djsj1 != "")
                ssql = ssql + " and djsj>='" + djsj1 + "' and djsj<='" + djsj2 + "'";
            if (czks > 0)
                ssql = ssql + " and czks="+czks+"";
            if (czry > 0)
                ssql = ssql + " and czry=" + czry + "";
            if (czlx > 0)
                ssql = ssql + " and a.czlx=" + czlx + "";
            ssql = ssql + " order by a.id";
            return database.GetDataTable(ssql);
        }
        public static DataTable Getlog_err(Guid logid,RelationalDatabase database)
        {
            string ssql = "select * from ts_update_errlog where logid='" + logid +"'";
            ssql = ssql + " order by id";
            return database.GetDataTable(ssql);
        }
    }
}