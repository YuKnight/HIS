using System;
using System.Collections.Generic;
using System.Text;

namespace TrasenClasses.GeneralClasses.Query
{
    public class QueryItemCollection : IList<QueryItem>  
    {
        private List<QueryItem> queryItems;

        public QueryItemCollection()
        {
            queryItems = new List<QueryItem>();
        }
        public QueryItemCollection( QueryItem[] items )
        {
            queryItems = new List<QueryItem>();
            queryItems.AddRange( items );
        }

        #region IList<QueryCondiction> 成员

        public int IndexOf( QueryItem item )
        {
            return queryItems.IndexOf( item );
        }

        public void Insert( int index , QueryItem item )
        {
            queryItems.Insert( index , item );
        }

        public void RemoveAt( int index )
        {
            queryItems.RemoveAt( index );
        }

        public QueryItem this[int index]
        {
            get
            {
                return queryItems[index];
            }
            set
            {
                queryItems[index] = value;
            }
        }

        #endregion

        #region ICollection<QueryCondiction> 成员

        public void Add( QueryItem item )
        {
            queryItems.Add( item );
        }

        public void Clear()
        {
            this.queryItems.Clear();
        }

        public bool Contains( QueryItem item )
        {
            return queryItems.Contains( item );
        }

        public void CopyTo( QueryItem[] array , int arrayIndex )
        {
            queryItems.CopyTo( array , arrayIndex );
        }

        public int Count
        {
            get
            {
                return queryItems.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove( QueryItem item )
        {
            return queryItems.Remove( item );
        }

        #endregion

        #region IEnumerable<QueryCondiction> 成员

        public IEnumerator<QueryItem> GetEnumerator()
        {
            return queryItems.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return queryItems.GetEnumerator();
        }

        #endregion

        public string ToXml()
        {
            StringBuilder sbXml = new StringBuilder();
            System.Xml.XmlDocument document = new System.Xml.XmlDocument();
            System.Xml.XmlNode root = document.CreateElement( "Condictions" );

            foreach ( QueryItem qc in queryItems )
            {
                System.Xml.XmlNode node = document.CreateElement( "Condiction" );

                System.Xml.XmlAttribute attributeName = document.CreateAttribute( "Name" );
                attributeName.Value = qc.Name;

                System.Xml.XmlAttribute attributeFields = document.CreateAttribute( "MappingField" );
                attributeFields.Value = qc.MappingFeild;

                System.Xml.XmlAttribute attributeDataType = document.CreateAttribute( "DataType" );
                attributeDataType.Value = qc.DataType.ToString();

                node.Attributes.Append( attributeName );
                node.Attributes.Append( attributeFields );
                node.Attributes.Append( attributeDataType );

                node.InnerText = qc.Value == null ? "" : qc.Value.ToString();

                root.AppendChild( node );
            }
            document.AppendChild( root );
            return document.InnerXml.ToString();
        }

        public string ToWhereString()
        {
            string str = "";
            if ( queryItems.Count > 0 )
            {
                str = queryItems[0].ToSqlString();
                for ( int i = 1 ; i < queryItems.Count ; i++ )
                {
                    str += " and " + queryItems[i].ToSqlString();
                }
            }
            return str;
        }
        
        public static QueryItemCollection FromXmlString( string xmlString , bool IsOwnerFormater )
        {
            System.Xml.XmlDocument document = new System.Xml.XmlDocument();
            try
            {
                document.LoadXml( xmlString );
            }
            catch ( Exception error )
            {
                throw new Exception( "读取xml字符串错误，请检查xml字符是否合符规范" , error );
            }
            if ( document.ChildNodes.Count == 0 )
                return new QueryItemCollection();

            System.Xml.XmlNode root = document.ChildNodes[0];
            QueryItemCollection collection = new QueryItemCollection();

            foreach ( System.Xml.XmlNode node in root.ChildNodes )
            {
                QueryItem c = new QueryItem();
                if ( !IsOwnerFormater )
                {
                    c.Name = node.Name;
                    c.Value = node.InnerText;
                    c.MappingFeild = node.Name;
                    c.DataType = SampleDataType.String;
                }
                else
                {
                    try
                    {
                        c.Name = node.Attributes["Name"].Value;
                        c.MappingFeild = node.Attributes["MappingField"].Value;
                        foreach ( object obj in Enum.GetValues( typeof( SampleDataType ) ) )
                        {
                            if ( obj.ToString() == node.Attributes["DataType"].Value )
                            {
                                c.DataType = (SampleDataType)obj;
                            }
                        }
                        switch ( c.DataType )
                        {
                            case SampleDataType.String:
                                c.Value = node.InnerText;
                                break;
                            case SampleDataType.Numeric:
                                if ( node.InnerText.Trim() == "" )
                                    c.Value = 0;
                                if ( node.InnerText.IndexOfAny( new char[] { '.' } ) != -1 )
                                    c.Value = Convert.ToDecimal( node.InnerText );
                                else
                                    c.Value = Convert.ToInt32( node.InnerText );
                                break;
                            case SampleDataType.DateTime:
                                c.Value = Convert.ToDateTime( node.InnerText );
                                break;
                        }
                    }
                    catch ( Exception error )
                    {
                        throw new Exception( "解析xml发生错误，如果IsOwnerFormater=true,请确保xml子节点格式为{ <Condiction Name=xxx  MappingField=xxx DataType=xxx></Condiction> }格式" , error );
                    }
                }
                collection.Add( c );
            }
            return collection;
        }
        
    }
}
