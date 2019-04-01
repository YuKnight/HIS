using System;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.DatabaseAccess
{
	/// <summary>
	///	EntityException 实体控制层异常。在实体层发生的异常都会以EntityException异常抛出。
	/// </summary>
	public class EntityException:Exception
	{
		private ErrorTypes _errorType;
		private Exception  _errorSource;

		/// <summary>
		///		生成一个PlException异常实例
		/// </summary>
		/// <param name="message">异常信息</param>
		public EntityException(string message):base(message)
		{
			this._errorType = ErrorTypes.Unknown;
		}
		
		/// <summary>
		///		生成一个PlException异常实例
		/// </summary>
		/// <param name="message">异常信息</param>
		/// <param name="errorType">异常代码</param>
		public EntityException(string message,ErrorTypes errorType):base(message)
		{
			this._errorType = errorType;
		}

		/// <summary>
		///		生成一个PlException异常实例
		/// </summary>
		/// <param name="e">异常实例</param>
		public EntityException(Exception e):base("实体层未处理的错误！")
		{
			this._errorType=ErrorTypes.Unknown;
			this._errorSource=e;
		}

		/*属性*/
		
		/// <summary>
		///		返回当前PlExcetpion实例的错误代码(枚举类型)
		/// </summary>
		public ErrorTypes ErrorType
		{
			get{return this._errorType;}
		}
		
		/// <summary>
		///		返回引起抛出PlExcetpion的Exception。当从PlException无法得到足够的错误信息，
		///		可从这里获得引发异常的原始Exception。
		/// </summary>
		public Exception ErrorSource
		{
			get{return this._errorSource;}
		}
	}

}
