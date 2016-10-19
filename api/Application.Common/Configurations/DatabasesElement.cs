using System.Configuration;
using System.Linq;
namespace App.Common.Configurations
{
    public class DatabasesElement : ConfigurationElementCollection//, System.Collections.Generic.IList<ConnectionStringElement>
    {
        /*public System.Collections.Generic.IList<ConnectionStringElement> Items { get; private set; }
        public DatabasesElement()
        {
            this.Items = new System.Collections.Generic.List<ConnectionStringElement>();
        }
        public int IndexOf(ConnectionStringElement item)
        {
            return this.Items.IndexOf(item);
        }

        public void Insert(int index, ConnectionStringElement item)
        {
            this.Items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.Items.RemoveAt(index);
        }

        public ConnectionStringElement this[int index]
        {
            get
            {
                return this.Items[index];
            }
            set
            {
                this.Items[index]=value;
            }
        }

        public void Add(ConnectionStringElement item)
        {
            this.Items.Add(item);
        }

        public void Clear()
        {
            this.Items.Clear();
        }

        public bool Contains(ConnectionStringElement item)
        {
            return this.Items.Contains(item);
        }

        public void CopyTo(ConnectionStringElement[] array, int arrayIndex)
        {
            this.Items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.Items.Count; }
        }

        public new bool IsReadOnly
        {
            get { return this.Items.IsReadOnly; }
        }

        public bool Remove(ConnectionStringElement item)
        {
            return this.Items.Remove(item);
        }

        public System.Collections.Generic.IEnumerator<ConnectionStringElement> GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }*/

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionStringElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConnectionStringElement)element).Name;
        }

        public ConnectionStringElement this[int index]
        {
            get
            {
                return (ConnectionStringElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        new public ConnectionStringElement this[string Name]
        {
            get
            {
                return (ConnectionStringElement)BaseGet(Name);
            }
        }
        public int IndexOf(ConnectionStringElement url)
        {
            return BaseIndexOf(url);
        }


        public void Add(ConnectionStringElement url)
        {
            BaseAdd(url);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(ConnectionStringElement url)
        {
            if (BaseIndexOf(url) >= 0)
            {
                BaseRemove(url.Name);
            }
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }

        public System.Collections.Generic.IList<ConnectionStringElement> ToList() {
            System.Collections.Generic.IList<ConnectionStringElement> items = new System.Collections.Generic.List<ConnectionStringElement>();
            object[] keys = BaseGetAllKeys();
            foreach (object key in keys) {
                var item = (ConnectionStringElement)BaseGet(key);
                items.Add(item);
            }
            return items;
        }
    }
    public class ConnectionStringElement : ConfigurationElement
    {
       /* [ConfigurationProperty("name",IsKey=true, IsRequired=true)]
        public string Name { get; set; }
        [ConfigurationProperty("database")]
        public string Database { get; set; }
        [ConfigurationProperty("server")]
        public string Server { get; set; }
        [ConfigurationProperty("port")]
        public int Port { get; set; }
        [ConfigurationProperty("userName")]
        public string UserName { get; set; }
        [ConfigurationProperty("password")]
        public string Password { get; set; }
        [ConfigurationProperty("dbType")]
        public DatabaseType DbType { get; set; }

        [ConfigurationProperty("default")]
        public bool IsDefault { get; set; }
        * */
        
         [ConfigurationProperty("name",IsKey=true, IsRequired=true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
        }
        [ConfigurationProperty("database")]
        public string Database
        {
            get
            {
                return (string)this["database"];
            }
        }
        [ConfigurationProperty("server")]
        public string Server
        {
            get
            {
                return (string)this["server"];
            }
        }
        [ConfigurationProperty("port")]
        public int Port
        {
            get
            {
                return (int)this["port"];
            }
        }
        [ConfigurationProperty("userName")]
        public string UserName
        {
            get
            {
                return (string)this["userName"];
            }
        }
        [ConfigurationProperty("password")]
        public string Password
        {
            get
            {
                return (string)this["password"];
            }
        }
        [ConfigurationProperty("dbType")]
        public DatabaseType DbType
        {
            get
            {
                return (DatabaseType)this["dbType"];
            }
        }

        [ConfigurationProperty("default")]
        public bool IsDefault
        {
            get
            {
                return (bool)this["default"];
            }
        }
    }
}
