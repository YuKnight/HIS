using System;
using System.Data;
using System.Text;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Classes
{
	/// <summary>
	/// ZYSet 的摘要说明。
	/// </summary>
	public class TsSet:ISet
	{
		private RelationalDatabase _database = TrasenFrame.Forms.FrmMdiMain.Database;
		private DataSet _dataSet;
		/// <summary>
		/// 数据适配器
		/// </summary>
		protected IDataAdapter _dataAdapter;
		/// <summary>
		/// TsSet中DataTable
		/// </summary>
		public DataTable TsDataTable;
		/// <summary>
        /// 构造一空TsSet
		/// </summary>
		public TsSet()
		{

		}
		/// <summary>
        /// 根据IDbCommand与数据库类型构造TsSet
		/// </summary>
		/// <param name="selectCommand"></param>
		public TsSet(IDbCommand selectCommand)
		{
			_dataAdapter=_database.GetAdapter(selectCommand);
			_dataSet=new DataSet();
			_dataAdapter.Fill(_dataSet);
			TsDataTable=_dataSet.Tables[0];

		}
		/// <summary>
        ///  根据SQL语句字符串与数据库类型构造TsSet
		/// </summary>
		/// <param name="selectCommand"></param>
		/// <param name="dbType"></param>
		public TsSet(string selectCommand)
		{
			_dataAdapter=_database.GetAdapter(selectCommand);
			_dataSet=new DataSet();
			_dataAdapter.Fill(_dataSet);
			TsDataTable=_dataSet.Tables[0];
		}
		/// <summary>
		/// 设置主键
		/// </summary>
		/// <param name="table">表名称</param>
		/// <param name="colume">列名称</param>
		public void SetPrimaryKey(string table,string colume)
		{
			DataColumn[] dc={_dataSet.Tables[table].Columns[colume]};
			_dataSet.Tables[table].PrimaryKey=dc;
		}
		#region ISet 成员
		/// <summary>
		/// 取得合计
		/// </summary>
		/// <param name="index">字段索引</param>
		/// <param name="filter">过滤条件</param>
		/// <returns></returns>
		public virtual decimal Sum(int index,string filter)
		{
			// TODO:  添加 ZYSet.Sum 实现
			if(TsDataTable==null) throw new EntityException("集合未被初始化");
			if(TsDataTable.Columns.Count<=index) throw new EntityException("非法字段索引号");
			return Convert.ToDecimal(Convertor.IsNull(TsDataTable.Compute("sum("+TsDataTable.Columns[index].ColumnName.Trim()+")",filter),"0"));
		}
		/// <summary>
		/// 取得合计
		/// </summary>
		/// <param name="fieldName">字段名称</param>
		/// <param name="filter">过滤条件</param>
		/// <returns></returns>
		public virtual decimal Sum(string fieldName,string filter)
		{
			// TODO:  添加 ZYSet.Sum 实现
			if(TsDataTable==null) throw new EntityException("集合未被初始化");
			return Convert.ToDecimal(Convertor.IsNull(TsDataTable.Compute("sum("+fieldName+")",filter),"0"));
		}
		/// <summary>
		/// 得到集合中的行数
		/// </summary>
		/// <param name="filter">更新过滤条件</param>
		/// <returns></returns>
		public virtual long Count(string filter)
		{
			// TODO:  添加 ZYSet.Count 实现
			if(TsDataTable==null) throw new EntityException("集合未被初始化");
			return Convert.ToInt64(Convertor.IsNull(TsDataTable.Compute("count(*)",filter),"0"));
		}
		/// <summary>
		/// 添加一行
		/// </summary>
		/// <returns></returns>
		public virtual bool Add()
		{
			// TODO:  添加 ZYSet.Add 实现
			return false;
		}

		/// <summary>
		/// 更新集合
		/// </summary>
		/// <param name="items">需要更新的数组</param>
		/// <param name="filter">过滤条件</param>
		/// <returns>返回影响的记录数</returns>
		public virtual long UpdateField(ItemEx[] items,string filter)
		{
			if(TsDataTable==null) throw new EntityException("集合未被初始化");
			DataRow[] rows=TsDataTable.Select(filter);
			TsDataTable.BeginLoadData();
			for(long i=0;i<rows.GetLongLength(0);i++)
				for(int j=0;j<items.GetLength(0);j++)
					rows[i][items[j].Text]=items[j].Value;
			return 0;
		}
		/// <summary>
		/// 根据filter条件过滤表记录
		/// </summary>
		/// <param name="filter">筛选条件</param>
		/// <returns></returns>
		public virtual DataTable FilterTable(string filter)
		{
			// TODO:  添加 ZYSet.FilterTable 实现
			if(TsDataTable==null) throw new EntityException("集合未被初始化");
			DataTable tb=TsDataTable.Clone();
			DataRow[] rows=TsDataTable.Select(filter);
			for(int i=0;i<rows.Length;i++)
			{
				tb.Rows.Add(rows[i].ItemArray);
			}
			return tb;
		}
		/// <summary>
		/// 根据filter条件过滤表记录
		/// </summary>
		/// <param name="filter">筛选条件</param>
		/// <param name="sort">排序条件</param>
		/// <returns></returns>
		public virtual DataTable FilterTable(string filter,string sort)
		{
			// TODO:  添加 ZYSet.FilterTable 实现
			if(TsDataTable==null) throw new EntityException("集合未被初始化");
			DataTable tb=TsDataTable.Clone();
			DataRow[] rows=TsDataTable.Select(filter,sort);
			for(int i=0;i<rows.Length;i++)
			{
				tb.Rows.Add(rows[i].ItemArray);
			}
			return tb;
		}
		/// <summary>
		/// 分组并根据聚合函数表达式求值
		/// </summary>
		/// <param name="groupByFieldsName">分组方式</param>
		/// <param name="computerFieldsName">计算列数组</param>
		/// <param name="computerFormularsName">计算函数数组</param>
		/// <param name="filter">筛选条件</param>
		/// <returns></returns>
		public virtual DataTable GroupTable(string[] groupByFieldsName,string[] computerFieldsName,string[] computerFormularsName,string filter)
		{
			// TODO:  添加 ZYSet.GroupTable 实现
			if(TsDataTable==null) throw new EntityException("集合未被初始化");
			DataTable tb=this.FilterTable(filter);
			DataTable tbResult=TsDataTable.Clone();
			object[] oldValue=new object[computerFieldsName.Length];
			int i,j,m,n,k;
			for(i=0;i<tb.Rows.Count;i++)
			{
				
				
				for(j=0;j<computerFieldsName.Length;j++)		//分组计算
				{
					oldValue[j]=tb.Rows[i][computerFieldsName[j]];
					tb.Rows[i][computerFieldsName[j]]=tb.Compute(computerFormularsName[j]+"("+computerFieldsName[j]+")",GetGroupByString(groupByFieldsName,tb.Rows[i]));
				}
				bool existSameRow=false;			//存在相同行
				for(m=0;m<=tbResult.Rows.Count-1;m++)			//模拟分组计算，如果目标表tbResult中已存在相同分组条件的记录则不添加至tbResult中
				{
					for(n=0;n<groupByFieldsName.Length;n++)
					{
						//逐一比较分组条件，只要存在一个条件不相等则认为不是相同行
						if(tbResult.Rows[m][groupByFieldsName[n]].ToString()!=tb.Rows[i][groupByFieldsName[n]].ToString())
						{
							existSameRow=false;
							break;
						}
						else
						{
							existSameRow=true;
						}
					}
					if(existSameRow)//只要存在相同行，则跳出循环
					{
						break;
					}
				}
				if(!existSameRow)
				{
					tbResult.Rows.Add(tb.Rows[i].ItemArray);
				}
				//本行恢复原值
				for(j=0;j<computerFieldsName.Length;j++)		
				{
					tb.Rows[i][computerFieldsName[j]]=oldValue[j];
				}
				if(groupByFieldsName.Length ==0)	//如果分组条件为空则结果集只有一行
				{
					break;
				}
			}
			//去掉非groupByFieldsName子元素且非computerFieldsName子元素的字段
			for(k=0;k<tbResult.Columns.Count;k++)
			{
				if(!Contains(groupByFieldsName,tbResult.Columns[k].ColumnName) && !Contains(computerFieldsName,tbResult.Columns[k].ColumnName))
				{
					tbResult.Columns.Remove(tbResult.Columns[k]);
				}
			}						
			return tbResult;
		}
		/// <summary>
		/// 根据分组条件字段数组生成分组计算条件字符串
		/// </summary>
		/// <param name="groupByFieldsName"></param>
		/// <param name="dr"></param>
		/// <returns></returns>
		private string GetGroupByString(string[] groupByFieldsName,DataRow dr)
		{
			string strGroupFields="";
			//构建分组条件字符串
			for(int i=0;i<groupByFieldsName.Length;i++)
			{
				if(i==0)
				{
					if ( dr[groupByFieldsName[i]].ToString().Trim() !="")
					{
						strGroupFields+=groupByFieldsName[i]+"='"+dr[groupByFieldsName[i]].ToString().Trim()+"'";	
					}
				}
				else
				{
					if ( dr[groupByFieldsName[i]].ToString().Trim() !="")
					{
						strGroupFields+=" and "+groupByFieldsName[i]+"='"+dr[groupByFieldsName[i]].ToString().Trim()+"'";	
					}
				}
			}
			return strGroupFields;
		}
		/// <summary>
		/// 分组并根据聚合函数表达式求值
		/// </summary>
		/// <param name="groupByFieldsName">分组方式</param>
		/// <param name="computerFieldsName">计算列数组</param>
		/// <param name="computerFormularsName">计算函数数组</param>
		/// <param name="filter">过滤字段</param>
		/// <param name="removeSpilthColumn">是否移除多余字段</param>
		/// <returns></returns>
		public virtual DataTable GroupTable(string[] groupByFieldsName,string[] computerFieldsName,string[] computerFormularsName,string filter,bool removeSpilthColumn)
		{
			if(TsDataTable==null) throw new EntityException("集合未被初始化");
			DataTable tmpTable =  TsDataTable.Copy();
			DataTable newTable = TsDataTable.Clone();
			if ( computerFieldsName.Length != computerFormularsName.Length ) 
				throw new Exception ("指定的计算字段与计算规则对应不一致");

			//构造分组标志
			DataColumn colGroup = new DataColumn();
			colGroup.ColumnName="GroupFlag";
			colGroup.DataType = Type.GetType("System.Int32");
			colGroup.DefaultValue = 0;
			tmpTable.Columns.Add(colGroup);
			//构造分组结果记录
			string _filter = "GroupFlag=0";
			if (filter!="") _filter += " and " + filter;
			while ( tmpTable.Select(_filter).Length> 0 )
			{
				DataRow[] drs = tmpTable.Select(_filter);
				string selectString = GetGroupString(groupByFieldsName,drs[0]) ;
				drs = tmpTable.Select(selectString);
				if (drs.Length > 0 )
				{
					//构造分组行
					DataRow newRow = newTable.NewRow();
					for ( int i=0;i<newTable.Columns.Count;i++)
						newRow[newTable.Columns[i].ColumnName]=drs[0][newTable.Columns[i].ColumnName];
					newTable.Rows.Add(newRow);
					//根据计算规则计算值并更新当前分组行
					for(int i=0;i<computerFieldsName.Length;i++)
					{
						string computeString = computerFormularsName[i] + "(" + computerFieldsName[i] + ")";
						string computCondictionString = selectString + (filter==""?"": (" and " + filter));
						if ( selectString.Trim() == "" )
							computCondictionString = filter;
						object objValue = tmpTable.Compute(computeString,computCondictionString);
						newTable.Rows[newTable.Rows.Count-1][computerFieldsName[i]]=objValue;
					}
				}
				else
					break;
				//将分组过的纪录作标记
				for ( int i=0;i<drs.Length;i++)
					drs[i]["GroupFlag"]=1;
				
			}
			//移除非group字段和computer字段
			DataTable retTable = newTable.Copy();
			if ( removeSpilthColumn )
			{
				foreach(DataColumn col in newTable.Columns)
				{
					string columnName = col.ColumnName;
					if ( NotInColumnCollection(columnName,groupByFieldsName) && NotInColumnCollection(columnName,computerFieldsName) )
						retTable.Columns.Remove(columnName);
				}
			}
			tmpTable.Dispose();
			tmpTable = null;
			newTable.Dispose();
			newTable=null;
			return retTable;
		}
		/// <summary>
		/// 获取分组选择条件
		/// </summary>
		/// <param name="GroupFields"></param>
		/// <param name="dr"></param>
		/// <returns></returns>
		private string GetGroupString(string[] GroupFields,DataRow dr)
		{
			StringBuilder sb = new StringBuilder();
			Type type;
			for ( int i =0;i<GroupFields.Length;i++)
			{
				if (i !=0) sb.Append(" and ");
				type = dr[GroupFields[i]].GetType();
				if ( type.ToString() == "System.String" || type.ToString()=="System.DateTime")
				{
					sb.Append( GroupFields[i] + "='" + dr[GroupFields[i]].ToString().Trim() + "'");
				}
				else
				{
					sb.Append( GroupFields[i] + "=" + dr[GroupFields[i]].ToString().Trim());
				}
			}
			return sb.ToString();
		}
		/// <summary>
		/// 判断是否在列集合中
		/// </summary>
		/// <param name="columnName"></param>
		/// <param name="srcColumnNames"></param>
		/// <returns></returns>
		private bool NotInColumnCollection(string columnName,string[] srcColumnNames)
		{
			for ( int i=0; i < srcColumnNames.Length; i ++ )
			{
				if ( srcColumnNames[i].ToUpper() == columnName.ToUpper() )
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 判断array是否包括findString
		/// </summary>
		/// <param name="array"></param>
		/// <param name="findString"></param>
		/// <returns></returns>
		private bool Contains(string[] array,string findString)
		{
			for(int i=0;i<array.Length;i++)
			{
				if(findString.ToUpper().Trim()==array[i].ToUpper().Trim())
				{
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// 把对数据的更改写到数据库中去，对本集合的修改如果不调用该方法则不会写数据库
		/// </summary>
		/// <returns></returns>
		public virtual bool Flash()
		{
			if(_dataAdapter==null) throw new EntityException("数据适配器未建立");
			if(_dataSet==null) throw new EntityException("数据集合未建立");
			try
			{
				_database.CreateCommandBuilder(_dataAdapter);
				_dataAdapter.Update(_dataSet);
			}
			catch(System.Exception err)
			{
				throw new EntityException(""+err.Message);
			}
			return true;
		}

		#endregion
	}
}
