using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;

namespace YpClass
{
    public class YP_TLFL
    {
        private string code;
        private string name;
        private bool print;
        private bool selected;

        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public bool Print
        {
            get
            {
                return print;
            }
            set
            {
                print = value;
            }
        }

        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
            }
        }

        public override string ToString()
        {
            return name;
        }

        public static List<YP_TLFL> GetList( RelationalDatabase database )
        {
            string sql = "select * from YP_TLFL order  by code";
            DataTable dt = database.GetDataTable( sql );
            List<YP_TLFL> list = new List<YP_TLFL>();
            foreach ( DataRow row in dt.Rows )
            {
                YP_TLFL t = new YP_TLFL();
                t.Code = row["CODE"].ToString().Trim();
                t.name = row["NAME"].ToString().Trim();
                t.Print = Convert.ToInt16( row["BPrint"] ) == 1 ? true : false;
                t.Selected = Convert.ToInt16( row["BSEL"] ) == 1 ? true : false;
                list.Add( t );
            }
            return list;
        }
    }
}
