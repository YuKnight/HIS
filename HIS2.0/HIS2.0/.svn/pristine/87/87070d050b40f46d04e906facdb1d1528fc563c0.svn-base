using System;
using System.Data;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Classes
{
	/// <summary>
	/// ISet 的摘要说明。
	/// </summary>
	public interface ISet
	{
		/// <summary>
		/// 取得合计
		/// </summary>
		/// <param name="index">字段索引</param>
		/// <param name="filter">过滤条件</param>
		/// <returns></returns>
		decimal Sum(int index,string filter);
		/// <summary>
		/// 取得合计
		/// </summary>
		/// <param name="fieldName">字段名称</param>
		/// <param name="filter">过滤条件</param>
		/// <returns></returns>
		decimal Sum(string fieldName,string filter);
		/// <summary>
		/// 得到集合中的行数
		/// </summary>
		/// <param name="filter">更新过滤条件</param>
		/// <returns></returns>
		long Count(string filter);
		/// <summary>
		/// 添加一行
		/// </summary>
		/// <returns></returns>
		bool Add();
		/// <summary>
		/// 更新集合中的字段
		/// </summary>
		/// <param name="Items">更新的值</param>
		/// <param name="filter">更新过滤条件</param>
		/// <returns>影响的行数</returns>
		long UpdateField(ItemEx[] Items,string filter);
		/// <summary>
		/// 根据filter条件过滤表记录
		/// </summary>
		/// <param name="filter">筛选条件</param>
		/// <returns></returns>
		DataTable FilterTable(string filter);
		/// <summary>
		/// 分组并根据聚合函数表达式求值
		/// </summary>
		/// <param name="groupByFieldsName">分组方式</param>
		/// <param name="computerFieldsName">计算列数组</param>
		/// <param name="computerFormularsName">计算函数数组</param>
		/// <param name="filter">筛选条件</param>
		/// <returns></returns>
		DataTable GroupTable(string[] groupByFieldsName,string[] computerFieldsName,string[] computerFormularsName,string filter);
		/// <summary>
		/// 把对数据的更改写到数据库中去，对本集合的修改如果不调用该方法则不会写数据库
		/// </summary>
		/// <returns></returns>
		bool Flash();
	}
}
