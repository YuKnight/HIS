using System;
using System.Data;
using System.Collections;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
namespace ts_jc_yzxmwh
{
	/// <summary>
	/// 操作类型
	/// </summary>
	public enum OP_TYPE
	{
		新增项目 = 1,
		更新项目 = 2,
		停用项目 = 3,
		启用项目 = 4
	}
	/// <summary>
	/// ChargeItem 的摘要说明。
	/// </summary>
	public class OrderItem : ICloneable
	{
		/// <summary>
		/// 实例化项目
		/// </summary>
		public OrderItem()
		{
			_order_id = 0;
			_order_name = "";
			_py_code = "";
			_wb_code = "";
            _d_code = "";
			_order_unit = "";
			_order_type_id = 0;
			_order_type_name = "";
			_delete_bit = 0;

            _fjsmbt = byte.Parse("0");//2012-11-21 增加 附加说明必填
			_execdeptList = new ArrayList();


		}
		/// <summary>
		/// 根据指定编号实例化项目
		/// </summary>
		/// <param name="ItemId"></param>
		public OrderItem(int OrderID)
		{
			try
			{
                // sql 语句增加 关于收费项目是否已删除
                string sql = @"select a.*,b.name,c.hditem_id,c.tc_flag,c.num ,e.yzid,e.jclxid,f.bbid,f.hylxid 
                        ,(select top 1 DELETE_BIT from 
                        (
                           (select DELETE_BIT from jc_hsitem  where ITEM_ID =c.hditem_id and c.TC_FLAG=0)
                           union
                           (select DELETE_BIT from jc_tc_t  where ITEM_ID =c.HDITEM_ID and c.TC_FLAG=1)
                        ) as aa) as DELETE_BIT_sfxm
                        from jc_hoitemdiction a  left join jc_ordertype b on a.order_type=b.code left join jc_hoi_hdi c on a.order_id=c.hoitem_id  
                        left join jc_jc_item e on a.order_id=e.yzid  left join jc_assay f on a.order_id=f.yzid where a.order_id = " + OrderID;
				DataRow dr = InstanceForm.BDatabase.GetDataRow(sql);
				if ( dr != null )
				{
					_order_id = OrderID;
					_order_name = Convert.IsDBNull(dr["order_name"]) ? "":dr["order_name"].ToString().Trim();
					_py_code = Convert.IsDBNull(dr["py_code"]) ? "":dr["py_code"].ToString().Trim();
					_wb_code = Convert.IsDBNull( dr["wb_code"]) ? "" : dr["wb_code"].ToString().Trim();
					_order_unit = Convert.IsDBNull(dr["order_unit"]) ? "" : dr["order_unit"].ToString();
					_order_type_id = Convert.IsDBNull(dr["order_type"]) ? 0 : Convert.ToInt32( Convertor.IsNull( dr["order_type"], "0" ) );
					_order_type_name = Convert.IsDBNull(dr["name"]) ? "" : Convertor.IsNull( dr["name"],"") ;
					_delete_bit = Convert.IsDBNull( dr["delete_bit"]) ? 0 : Convert.ToInt32( Convertor.IsNull( dr["delete_bit"],"0"));
					_default_exec_dept = Convert.ToInt32( Convertor.IsNull( dr["default_dept"],"0"));
					_usage = Convert.IsDBNull(dr["default_usage"]) ? "" : dr["default_usage"].ToString().Trim();
					_item_exec_num = Convert.IsDBNull( dr["num"] ) ? 1 : Convert.ToInt32( dr["num"] );
					bz = Convert.IsDBNull(dr["bz"]) ? "" : dr["bz"].ToString().Trim();
                    _d_code = Convert.IsDBNull(dr["d_code"]) ? "" : dr["d_code"].ToString().Trim();
                    //2012-11-21 增加 附加说明必填
                    if ( Convert.IsDBNull(dr["FJSMBT"])==false && dr["FJSMBT"].ToString()=="1" ) _fjsmbt=byte.Parse( "1");

                    else _fjsmbt = byte.Parse("0");
                    _sfxm_delete_bit =int.Parse(  Convert.IsDBNull(dr["DELETE_BIT_sfxm"]) ? "0" : dr["DELETE_BIT_sfxm"].ToString().Trim());
					if ( dr["hditem_id"] != null && !Convert.IsDBNull(dr["hditem_id"]))
					{
						_charge_item_id = Convert.IsDBNull(dr["hditem_id"]) ? 0 : Convert.ToInt32( dr["hditem_id"] );
						_match_type = Convert.IsDBNull(dr["tc_flag"]) ? 0 : Convert.ToInt32( dr["tc_flag"] );
						if ( _match_type == 0 )
							sql = "select item_name from jc_hsitem where item_id=" + _charge_item_id;
						else
							sql = "select item_name from jc_tc_t where item_id=" + _charge_item_id;

						DataRow drItem = InstanceForm.BDatabase.GetDataRow(sql);
						if ( drItem != null )
							_charge_item_name = Convert.IsDBNull(drItem[0]) ? "" : drItem[0].ToString().Trim();
						else
							_charge_item_name = "";
					}
					else
					{
						_charge_item_id = 0 ;
					}
					_execdeptList = new ArrayList();
					DataTable tableDept = this.GetExecDeptDataTable();
					for ( int i=0;i<tableDept.Rows.Count;i++)
					{
						TrasenFrame.Classes.Department dept = new TrasenFrame.Classes.Department();
						dept.DeptId = Convert.IsDBNull(tableDept.Rows[i]["dept_id"]) ? 0 : Convert.ToInt32(tableDept.Rows[i]["dept_id"]);
						dept.DeptName = Convert.IsDBNull(tableDept.Rows[i]["name"]) ? "" : tableDept.Rows[i]["name"].ToString().Trim();
						if ( dept.DeptId == _default_exec_dept ) 
							dept.Default = 1;
						_execdeptList.Add( dept );
					}
					//判断是检查还是化验项目
					this.isJCorHy = 0;
                    //////////////////////
					sql = "select * from jc_jc_item where yzid=" + OrderID;
					DataRow drTmp = InstanceForm.BDatabase.GetDataRow( sql );
					if ( drTmp != null ) isJCorHy = 1;
					sql = "select * from jc_assay where yzid=" + OrderID;
					drTmp = InstanceForm.BDatabase.GetDataRow( sql );
					if ( drTmp != null ) isJCorHy = 2;
                    this.jclx = Convert.IsDBNull(dr["jclxid"]) ? 0 : Convert.ToInt32(dr["jclxid"]);
                    // this.sample = Convert.IsDBNull(dr["bbid"]) ? "" : dr["bbid"].ToString().Trim();
                    this.sample = Convert.IsDBNull(dr["bbid"]) ? 0 : Convert.ToInt32(dr["bbid"]);
                    this.hylx = Convert.IsDBNull(dr["hylxid"]) ? 0 : Convert.ToInt32(dr["hylxid"]);
				}
				else
				{
					throw new Exception("没有对应的医嘱项目");
				}
			}
			catch(Exception err)
			{
				throw new Exception("OrderItem()/r/n" + err.Message);
			}
		}
		#region 属性
		/// <summary>
		/// 项目编号
		/// </summary>
		private int _order_id;
		/// <summary>
		/// 名称
		/// </summary>
		private string _order_name;
		/// <summary>
		/// 拼音码
		/// </summary>
		private string _py_code;
		/// <summary>
		/// 五笔码
		/// </summary>
		private string _wb_code;
        /// <summary>
        ///  数字码
        /// </summary>
        private string _d_code;
		/// <summary>
		/// 单位
		/// </summary>
		private string _order_unit;
		/// <summary>
		/// 医嘱类型编号
		/// </summary>
		private int _order_type_id;
		/// <summary>
		/// 医嘱类型名称
		/// </summary>
		private string _order_type_name;
		/// <summary>
		/// 是否删除
		/// </summary>
		private int _delete_bit;
		/// <summary>
		/// 执行科室
		/// </summary>
		private ArrayList _execdeptList;
		/// <summary>
		/// 用法
		/// </summary>
		private string _usage;
		/// <summary>
		/// 默认执行科室
		/// </summary>
		private int _default_exec_dept;
		/// <summary>
		/// 对应收费项目
		/// </summary>
		private int _charge_item_id;
		/// <summary>
		/// 对应的收费项目名称
		/// </summary>
		private string _charge_item_name;

		/// <summary>
		/// 对应方式 (0-与收费项目对应，1-与套餐项目对应)
		/// </summary>
		private int _match_type;
		/// <summary>
		/// 收费项目执行次数
		/// </summary>
		private int _item_exec_num;
		/// <summary>
		/// 检查还是化验项目
		/// </summary>
		private int isJCorHy;
		/// <summary>
		/// 检查类型
		/// </summary>
		private int jclx;
		/// <summary>
		/// 预约标记
		/// </summary>
		private int bookingBit;
		/// <summary>
		/// 化验类型
		/// </summary>
		private int hylx;
		/// <summary>
		/// 样本
		/// </summary>
		private int sample;
		/// <summary>
		/// 备注
		/// </summary>
		private string bz;
        /// <summary>
        /// 2012-11-21 增加 附加说明必填
        /// </summary>
        private byte _fjsmbt;
        /// <summary>
        /// 2012-11-21 增加 附加说明必填
        /// </summary>
        public byte FJSMBT
        {
            get
            {
                return _fjsmbt;
            }
            set
            {
                _fjsmbt = value;
            }
        }
        /// <summary>
        /// 对应的收费项目 是否已删除 2012-12-16 增加
        /// </summary>
        private int _sfxm_delete_bit;
        /// <summary>
        /// 对应的收费项目 是否已删除 2012-12-16 增加
        /// </summary>
        public int sfxm_delete_bit
        {
            get
            {
                return _sfxm_delete_bit;
            }
            set
            {
                _sfxm_delete_bit = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        /// 
		public string BZ
		{
			get
			{
				return bz;
			}
			set
			{
				bz = value;
			}
		}
		/// <summary>
		/// 样本
		/// </summary>
		public int Sample
		{
			get
			{
				return sample;
			}
			set
			{
				sample =value;
			}
		}
		/// <summary>
		/// 化验类型
		/// </summary>
		public int HYLX
		{
			get
			{
				return hylx;
			}
			set
			{
				hylx = value;
			}
		}
		/// <summary>
		/// 预约标记
		/// </summary>
		public int BookingBit
		{
			get
			{
				return bookingBit;
			}
			set
			{
				bookingBit = value;
			}
		}
		/// <summary>
		/// 检查类型
		/// </summary>
		public int JCLX
		{
			get
			{
				return jclx;
			}
			set
			{
				jclx = value;
			}
		}
		/// <summary>
		/// 检查还是化验项目(0无 1-检查 2-化验)
		/// </summary>
		public int IsJCorHY
		{
			get
			{
				return isJCorHy;
			}
			set
			{
				isJCorHy = value;
			}
		}
		/// <summary>
		/// 对应的收费项目名称
		/// </summary>
		public string ChargeItemName
		{
			get
			{
				return _charge_item_name;
			}
			set
			{
				_charge_item_name = value;
			}
		}
		/// <summary>
		/// 收费项目执行次数
		/// </summary>
		public int ItemExecNum
		{
			get
			{
				return _item_exec_num;
			}
			set
			{
				_item_exec_num = value;
			}
		}
		/// <summary>
		/// 对应方式 (0-与收费项目对应，1-与套餐项目对应)
		/// </summary>
		public int MatchType
		{
			get
			{
				return _match_type;
			}
			set
			{
				_match_type = value;
			}
		}
		/// <summary>
		/// 默认执行科室
		/// </summary>
		public int DefaultExecDept
		{
			get
			{
				return _default_exec_dept;
			}
			set
			{
				_default_exec_dept = value;
			}
		}
		/// <summary>
		/// 对应收费项目
		/// </summary>
		public int ChargeItemId
		{
			get
			{
				return _charge_item_id;
			}
			set
			{
				_charge_item_id = value;
			}
		}
		/// <summary>
		/// 用法
		/// </summary>
		public string Usage
		{
			get
			{
				return _usage;
			}
			set
			{
				_usage = value;
			}
		}
		/// <summary>
		/// 项目编号
		/// </summary>
		public int Order_Id
		{
			get
			{
				return _order_id;
			}
			set
			{
				_order_id = value;
			}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string Order_Name
		{
			get
			{
				return _order_name;
			}
			set
			{
				_order_name = value;
			}
		}
		/// <summary>
		/// 拼音码
		/// </summary>
		public string Py_Code
		{
			get
			{
				return _py_code;
			}
			set
			{
				_py_code = value;
			}
		}
		/// <summary>
		/// 五笔码
		/// </summary>
		public string Wb_Code
		{
			get
			{
				return _wb_code;
			}
			set
			{
				_wb_code = value;
			}
		}
        /// <summary>
		/// 数字码
		/// </summary>
		public string D_Code
		{
			get
			{
                return _d_code;
			}
			set
			{
                _d_code = value;
			}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string Order_Unit
		{
			get
			{
				return _order_unit;
			}
			set
			{
				_order_unit = value;
			}
		}
        
		/// <summary>
		/// 有效标记
		/// </summary>
		public int Delete_Bit
		{
			get
			{
				return _delete_bit;
			}
			set
			{
				_delete_bit = value;
			}
		}
		/// <summary>
		/// 执行科室集合
		/// </summary>
		public ArrayList ExecDeptList
		{
			get
			{
				return _execdeptList;
			}
			set
			{
				_execdeptList = value;
			}
		}
		/// <summary>
		/// 医嘱类型编号
		/// </summary>
		public int OrderTypeID
		{
			get
			{
				return _order_type_id;
			}
			set
			{
				_order_type_id = value;
			}
		}
		/// <summary>
		/// 医嘱类型名称
		/// </summary>
		public string OrderTypeName
		{
			get
			{
				return _order_type_name;
			}
			set
			{
				_order_type_name= value;
			}
		}
		#endregion
		/// <summary>
		///  保存
		/// </summary>
		/// <returns></returns>
		public bool Save(OP_TYPE OpType)
		{
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;

			try
			{
				string sql = "";
				InstanceForm.BDatabase.BeginTransaction();

				if ( OpType == OP_TYPE.新增项目)
				{
					//插入新纪录
                    sql = "insert into jc_hoitemdiction ( order_name,order_unit,order_type,default_usage,default_dept,py_code,wb_code,bz,FJSMBT,d_code)";
					sql+= " values ('" + _order_name + "','" + _order_unit + "'," + _order_type_id + ",'" + _usage + "'," +_default_exec_dept+ ",'"+_py_code+"','"+_wb_code+"','"+bz+"',"+ _fjsmbt.ToString() +",'"+_d_code+"')";
					object obj;
					InstanceForm.BDatabase.InsertRecord( sql,out obj);
					_order_id = Convert.ToInt32(obj);

				}	
				if ( OpType == OP_TYPE.更新项目 )
				{
					sql = "update jc_hoitemdiction set order_name='" + _order_name + "',order_unit='" + _order_unit + "',order_type=" + _order_type_id + ",default_usage='" + _usage + "',default_dept=" + _default_exec_dept + ",py_code='" + _py_code + "',wb_code='" + _wb_code + "',bz='"+bz+"',FJSMBT=" + _fjsmbt.ToString() + ",d_code='"+_d_code+"'";
					sql += " where order_id=" + _order_id;
					InstanceForm.BDatabase.DoCommand( sql );
				}
				//执行科室
				sql = "delete from jc_hoi_dept where order_id = " + _order_id;
				InstanceForm.BDatabase.DoCommand( sql );
				for ( int i=0;i< _execdeptList.Count; i ++)
				{
					sql = "insert into jc_hoi_dept ( order_id,exec_dept ) values (" + _order_id + "," + ((TrasenFrame.Classes.Department)_execdeptList[i]).DeptId + ")";
					InstanceForm.BDatabase.DoCommand( sql );
				}
				//与收费项目对应
				sql = "delete from jc_hoi_hdi where hoitem_id=" + _order_id ;
				InstanceForm.BDatabase.DoCommand( sql );
				if ( _match_type == 1 )
				{
					if ( _charge_item_id != 0 )
					{
						sql = "insert into jc_hoi_hdi ( hoitem_id,hditem_id,num,tc_flag,tcid ) values (" + _order_id + "," +_charge_item_id+ ","+_item_exec_num+",1," + _charge_item_id + ")";
						InstanceForm.BDatabase.DoCommand( sql );
					}
				}
				else
				{
					if ( _charge_item_id != 0 )
					{
						sql = "insert into jc_hoi_hdi ( hoitem_id,hditem_id,num,tc_flag,tcid ) values (" + _order_id + "," +_charge_item_id+ ","+_item_exec_num+",0,-1)";
						InstanceForm.BDatabase.DoCommand( sql );
					}
				}
				//同步更新检查化验表
				sql = "delete from jc_jc_item where yzid=" + _order_id;
				InstanceForm.BDatabase.DoCommand( sql );
				sql = "delete from jc_assay where yzid="+ _order_id;
				InstanceForm.BDatabase.DoCommand( sql );
				if ( this.isJCorHy == 1 )
				{
					sql = "insert into jc_jc_item(yzid,jclxid) values (" + _order_id + "," +jclx+ ")";
					InstanceForm.BDatabase.DoCommand( sql );
				}
				else if ( this.isJCorHy == 2)
				{
                    sql = "insert into jc_assay(yzid,bbid,hylxid) values (" + _order_id + "," + sample + ", " + hylx + ")";
                    InstanceForm.BDatabase.DoCommand(sql);
				}

                string _bz = "";
                if (OpType == OP_TYPE.新增项目) _bz = "新增医嘱项目:【" + _order_name + "】"; else _bz = "修改医嘱项目:【" + _order_name + "】";
                ts.Save_log(ts_HospData_Share.czlx.jc_医嘱项目修改, _bz, "jc_hoitemdiction", "order_id", _order_id.ToString(),InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);
				InstanceForm.BDatabase.CommitTransaction();
				
			}
			catch(Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				throw err;
			}


            //三院数据处理
            try
            {
                string errtext = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_医嘱项目修改, InstanceForm.BDatabase);
                if (ty.Bzx == 1 && log_djid != Guid.Empty)
                {
                    ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                }
                if (errtext != "") throw new Exception(errtext);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("保存成功 " + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            return true;

		}
		/// <summary>
		/// 设置启用、停用状态
		/// </summary>
		/// <param name="Used"></param>
		/// <returns></returns>
        public bool SetUseable(bool Used)
        {
           //2014-7-15 jianqg 增加函数，启用公共的函数
           return SetUseable(Used, InstanceForm.BDatabase, true, InstanceForm._menuTag.Jgbm);
        }
        /// <summary>
        ///  2014-7-15 jianqg 增加函数，整合收费项目联动处理医嘱项目状态（收费项目停用调用本函数，处理医嘱项目停用）
        /// 使用前 需要实例化类，主要是，_order_id，_order_name
        /// </summary>
        /// <param name="Used"></param>
        /// <param name="db">数据库连接</param>
        /// <param name="bTransaction">是否启用事务(医嘱项目直接保存用true,收费项目联动保存用false)</param>
        /// <param name="jgbm">机构编码(医嘱项目直接保存用InstanceForm._menuTag.Jgbm,收费项目联动保存传入)</param>
        /// <returns></returns>
        public bool SetUseable(bool Used, RelationalDatabase db, bool bTransaction,int jgbm)
		{
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;
            string bz = "";
			try
			{
                //InstanceForm.BDatabase.BeginTransaction();
                if (bTransaction) db.BeginTransaction();//2014-7-15 修改，采用参数判断处理
				string sql = "update jc_hoitemdiction set delete_bit=" + (Used ? "0" : "1") + " where order_id=" + this._order_id;
                //InstanceForm.BDatabase.DoCommand(sql);
                db.DoCommand(sql); //2014-7-15 修改，采用参数处理

                //三院数据处理
                bz = Used == true ? "启用医嘱项目:" + _order_name : "停用医嘱项目:" + _order_name;
                //ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, bz, "jc_hoitemdiction", "order_id", _order_id.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);
                ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, bz, "jc_hoitemdiction", "order_id", _order_id.ToString(), jgbm, 0, "", out log_djid, db);//2014-7-15 修改，采用参数处理

                //InstanceForm.BDatabase.CommitTransaction();
                if (bTransaction) db.CommitTransaction();//2014-7-15 修改，采用参数判断处理

                //三院数据处理
                try
                {
                    string errtext = "";
                    //ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, InstanceForm.BDatabase);
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, db);//2014-7-15 修改，采用参数处理
                    if (ty.Bzx == 1)
                    {
                        //ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                        ts.Pexec_log(log_djid, db, out errtext);//2014-7-15 修改，采用参数处理
                    }
                    if (errtext != "") throw new Exception(errtext);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(bz + "成功  ." + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

			
				
			}
			catch(Exception err)
			{
                //InstanceForm.BDatabase.RollbackTransaction();
                if (bTransaction) db.RollbackTransaction();//2014-7-15 修改，采用参数判断处理
				throw new Exception("Set医嘱项目Useable/" + err.Message );
			}


            return true;
		}
		#region ICloneable 成员

		public object Clone()
		{
			// TODO:  添加 ChargeItem.Clone 实现
			return new OrderItem(this._order_id);
		}

		#endregion
		/// <summary>
		/// 获取执行科室
		/// </summary>
		/// <returns></returns>
		private DataTable GetExecDeptDataTable()
		{
			string sql = "select b.dept_id,b.name  from jc_hoi_dept a left join jc_dept_property b on a.exec_dept=b.dept_id where a.order_id=" + this._order_id;
			return InstanceForm.BDatabase.GetDataTable(sql);
		}
				
	}
}
