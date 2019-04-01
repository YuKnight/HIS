using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;
using TrasenClasses.GeneralClasses;

namespace ts_mz_class
{
    public class Klx
    {
        private int _ID;
        private int _KLX;
        private string _KLXMC;
        private short _BJEBZ;
        private short _BQFGZ;
        private short _BMM;
        private string _MRMM;
        private short _BQYBZ;
        private int _KCD;
        private int _XH;
        private long _SFXMID;
        private int _YBJKLX;
        private short _BINPUT;
        private decimal _CSJE;
        private int _MZORZY;
        private int _ISYCX;
        private RelationalDatabase database;

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        
        public int KLX
        {
            get
            {
                return _KLX;
            }
            set
            {
                _KLX = value;
            }
        }
       
        public string KLXMC
        {
            get
            {
                return _KLXMC;
            }
            set
            {
                _KLXMC = value;
            }
        }
        
        public short BJEBZ
        {
            get
            {
                return _BJEBZ;
            }
            set
            {
                _BJEBZ = value;
            }
        }
        
        public short BQFGZ
        {
            get
            {
                return _BQFGZ;
            }
            set
            {
                _BQFGZ = value;
            }
        }

        public short BMM
        {
            get
            {
                return _BMM;
            }
            set
            {
                _BMM = value;
            }
        }
       
        public string MRMM
        {
            get
            {
                return _MRMM;
            }
            set
            {
                _MRMM = value;
            }
        }
        
        public short BQYBZ
        {
            get
            {
                return _BQYBZ;
            }
            set
            {
                _BQYBZ = value;
            }
        }
        
        public int KCD
        {
            get
            {
                return _KCD;
            }
            set
            {
                _KCD = value;
            }
        }
       
        public int XH
        {
            get
            {
                return _XH;
            }
            set
            {
                _XH = value;
            }
        }
       
        public long SFXMID
        {
            get
            {
                return _SFXMID;
            }
            set
            {
                _SFXMID = value;
            }
        }
        
        public int YBJKLX
        {
            get
            {
                return _YBJKLX;
            }
            set
            {
                _YBJKLX = value;
            }
        }

        private string _dkqxh;

        public string Dkqxh
        {
            get
            {
                return _dkqxh;
            }
            set
            {
                _dkqxh = value;
            }
        }
       
        public short BINPUT
        {
            get
            {
                return _BINPUT;
            }
            set
            {
                _BINPUT = value;
            }
        }
        
        public decimal CSJE
        {
            get
            {
                return _CSJE;
            }
            set
            {
                _CSJE = value;
            }
        }
        
        public int MZORZY
        {
            get
            {
                return _MZORZY;
            }
            set
            {
                _MZORZY = value;
            }
        }
        
        public int ISYCX
        {
            get
            {
                return _ISYCX;
            }
            set
            {
                _ISYCX = value;
            }
        }

        public Klx()
        {
        }

        public Klx( int klxId , RelationalDatabase Database )
        {
            database = Database;
            DataRow row = database.GetDataRow( "select * from jc_klx where klx=" + klxId );
            Fill( row );
        }

        private Klx( DataRow row )
        {
            Fill( row );
        }

        private void Fill( DataRow row )
        {
            if ( row != null )
            {
                _ID = Convert.ToInt32( Convertor.IsNull( row["ID"] , "0" ) );
                _KLX = Convert.ToInt32( Convertor.IsNull( row["KLX"] , "0" ) );
                _KLXMC = Convert.ToString( Convertor.IsNull( row["KLXMC"] , "" ) );
                _BJEBZ = Convert.ToInt16( Convertor.IsNull( row["BJEBZ"] , "0" ) );
                _BQFGZ = Convert.ToInt16( Convertor.IsNull( row["BQFGZ"] , "0" ) );
                _BMM = Convert.ToInt16( Convertor.IsNull( row["BMM"] , "0" ) );
                _MRMM = Convert.ToString( Convertor.IsNull( row["MRMM"] , "" ) );
                _BQYBZ = Convert.ToInt16( Convertor.IsNull( row["BQYBZ"] , "0" ) );
                _KCD = Convert.ToInt32( Convertor.IsNull( row["KCD"] , "0" ) );
                _XH = Convert.ToInt32( Convertor.IsNull( row["XH"] , "0" ) );
                _SFXMID = Convert.ToInt64( Convertor.IsNull( row["SFXMID"] , "0" ) );
                _YBJKLX = Convert.ToInt32( Convertor.IsNull( row["YBJKLX"] , "0" ) );
                _BINPUT = Convert.ToInt16( Convertor.IsNull( row["BINPUT"] , "0" ) );
                _CSJE = Convert.ToDecimal( Convertor.IsNull( row["CSJE"] , "0.0" ) );
                _MZORZY = Convert.ToInt32( Convertor.IsNull( row["MZORZY"] , "0" ) );
                _ISYCX = Convert.ToInt32( Convertor.IsNull( row["ISYCX"] , "0" ) );
            }
        }

        public static List<Klx> GetList( RelationalDatabase database )
        {
            List<Klx> lstLX = new List<Klx>();
            DataTable table = database.GetDataTable( "select * from jc_klx order by id" );
            foreach ( DataRow r in table.Rows )
                lstLX.Add( new Klx( r ) );
            return lstLX;
        }

        public static Klx GetKlxById( int klxId , RelationalDatabase database )
        {
            DataRow row = database.GetDataRow( "select * from jc_klx where id=" + klxId );
            return new Klx( row );
        }
        /// <summary>
        /// 卡号长度超出设定的长度异常
        /// </summary>
        public class CardNumberOutOfSettingLengthException : Exception
        {
            public CardNumberOutOfSettingLengthException( string message ) : base( message )
            {
            }
        }
        /// <summary>
        /// 分配的卡张数超出范围异常
        /// </summary>
        public class AssignedCardPicsOverLimitException : Exception
        {
            public AssignedCardPicsOverLimitException( string message ) : base( message )
            {
            }
        }
        /// <summary>
        /// 格式化卡号
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public string FormatCardNo( string inputString )
        {
            string kh = "";
            ts_mz_class.Klx klx = new ts_mz_class.Klx( this.KLX , database );
            if ( inputString.Length > klx.KCD )
            {
                string tmp = inputString.Substring( 0 , inputString.Length - klx.KCD );
                if ( string.IsNullOrEmpty( tmp.Replace( "0" , "" ).Trim() ) )                
                    kh = inputString.Substring( inputString.Length - klx.KCD );                
                else
                    throw new CardNumberOutOfSettingLengthException( string.Format( "当前类型的卡的卡号设定为{0}位，输入的卡号过长" , this._KCD ) );
            }
            else
                kh = inputString.PadLeft( klx.KCD , '0' );
            
            return kh;
        }
        /// <summary>
        /// 根据开始卡号和张数推算最后一张卡的卡号
        /// </summary>
        /// <param name="startNumber"></param>
        /// <param name="pics"></param>
        /// <returns></returns>
        public string ComputeLastNumber( string startNumber , int pics )
        {
            try
            {
                int bit = 0;
                for ( int i = startNumber.Length - 1 ; i > -1 ; i-- )
                {
                    string s = startNumber.Substring( i );
                    if ( Convertor.IsInteger( s ) )
                        bit++;
                    else
                        break;
                }
                string tmp = startNumber.Substring( 0 , startNumber.Length - bit );

                //可分配的最大数
                long maxNum = Convert.ToInt64( Math.Pow( 10 , bit ) ) - 1;
                long startNum = Convert.ToInt64( startNumber.Substring( startNumber.Length - bit ) );
                if ( pics > maxNum )
                    throw new AssignedCardPicsOverLimitException( string.Format( "当前类型的卡的卡号长度设定为{0}位，最大能分配到{1}{2},输入的张数过大" , this._KCD , tmp , maxNum ) );
                else
                {
                    string str = Convert.ToString( startNum + pics - 1 );
                    int len = this._KCD - tmp.Length;
                    string str2 = str.PadLeft( len , '0' );
                    return string.Format( "{0}{1}" , tmp , str2 );
                }
            }
            catch ( Exception error )
            {
                return "";
            }
        }
    }
}
