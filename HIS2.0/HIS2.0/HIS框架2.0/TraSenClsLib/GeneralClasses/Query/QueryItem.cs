using System;
using System.Collections.Generic;
using System.Text;

namespace TrasenClasses.GeneralClasses.Query
{
    public class QueryItem
    {
        

        private string _name;
        private string _mappingFeild;
        private object _objValue;
        private SampleDataType _dataType = SampleDataType.String;
        private OperatorSymbole _opSymbole = OperatorSymbole.等于;

        public OperatorSymbole OpSymbole
        {
            get
            {
                return _opSymbole;
            }
            set
            {
                _opSymbole = value;
            }
        }
        public SampleDataType DataType
        {
            get
            {
                return _dataType;
            }
            set
            {
                _dataType = value;
            }
        }
        /// <summary>
        /// 查询字段值
        /// </summary>
        public object Value
        {
            get
            {
                return _objValue;
            }
            set
            {
                _objValue = value;
            }
        }
        /// <summary>
        /// 映射的数据库字段值
        /// </summary>
        public string MappingFeild
        {
            get
            {
                return _mappingFeild;
            }
            set
            {
                _mappingFeild = value;
            }
        }
        /// <summary>
        /// 查询条件名称
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public QueryItem()
        {
        }

        public QueryItem( string name , string mappingField , object objValue )
        {
            this._name = name;
            this._mappingFeild = mappingField;
            this._objValue = objValue;
        }

        public QueryItem( string name , string mappingField , SampleDataType dataType, object objValue )
        {
            this._name = name;
            this._mappingFeild = mappingField;
            this._objValue = objValue;
            this._dataType = dataType;
        }

        public override string ToString()
        {
            return string.Format( "Name={0},Value={1}" , this._name , this._objValue );
        }

        public string ToSqlString()
        {

            switch ( this._dataType )
            {
                case SampleDataType.DateTime:
                    switch ( this._opSymbole )
                    {
                        case OperatorSymbole.包含:
                        case OperatorSymbole.近似于:
                            throw new Exception( "日期类型不支持包含或近似于的操作" );
                        default :
                            return string.Format( "{0} {1} '{2}'" , _mappingFeild , convertSymbol( this._opSymbole ) , Convert.ToDateTime( _objValue ).ToString( "yyyy-MM-dd HH:mm:ss" ) );
                    }
                case SampleDataType.Numeric:
                    switch ( this._opSymbole )
                    {
                        case OperatorSymbole.包含:
                        case OperatorSymbole.近似于:
                            throw new Exception( "数字类型不支持包含或近似于的操作" );
                        default:
                            return string.Format( "{0} {1} {2}" , _mappingFeild , convertSymbol( this._opSymbole ) , _objValue );
                    }
                case SampleDataType.String:
                    switch ( this._opSymbole )
                    {
                        case OperatorSymbole.大于:
                        case OperatorSymbole.大于等于:
                        case OperatorSymbole.小于:
                        case OperatorSymbole.小于等于:
                            throw new Exception( "字符类型不支持大小比较的操作" );
                        case OperatorSymbole.包含:
                            return string.Format( "{0} {1} '%{2}%'" , _mappingFeild , convertSymbol( this._opSymbole ) , _objValue );
                        case OperatorSymbole.近似于:
                            return string.Format( "{0} {1} '{2}%'" , _mappingFeild , convertSymbol( this._opSymbole ) , _objValue );
                        default:
                            return string.Format( "{0} {1} '{2}'" , _mappingFeild , convertSymbol( this._opSymbole ) , _objValue );
                    }
                default:
                    return "";
            }            
        }

        private string convertSymbol( OperatorSymbole symbole )
        {
            switch ( symbole )
            {
                case OperatorSymbole.包含:
                case OperatorSymbole.近似于 :
                    return "LIKE";
                case OperatorSymbole.不等于:
                    return "<>";
                case OperatorSymbole.大于:
                    return ">";
                case OperatorSymbole.大于等于:
                    return ">=";
                case OperatorSymbole.等于:
                    return "=";
                case OperatorSymbole.小于:
                    return "<";
                case OperatorSymbole.小于等于:
                    return "<=";
            }
            throw new Exception( "未知的操作符" );
        }

    }
}
