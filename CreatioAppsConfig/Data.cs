using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel;

namespace CreatioAppsConfig
{

    namespace SiteData
    {
        [XmlRoot(ElementName = "SITE")]
        public class SITE
        {
            [XmlAttribute(AttributeName = "SITE.ID")]
            public int Id { get; set; }
            [XmlAttribute(AttributeName = "SITE.NAME")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "bindings")]
            public string Bindings { get; set; }
            [XmlAttribute(AttributeName = "state")]
            public string State { get; set; }
        }

        [XmlRoot(ElementName = "appcmd")]
        public class Appcmd
        {
            [XmlElement(ElementName = "SITE")]
            public List<SITE> SITE { get; set; }
        }

    }

    namespace WorkingProcess
    {
        [XmlRoot(ElementName = "WP")]
        public class WP
        {
            [XmlAttribute(AttributeName = "WP.NAME")]
            public int ProcessId { get; set; }
            [XmlAttribute(AttributeName = "APPPOOL.NAME")]
            public string APPPOOL { get; set; }
        }

        [XmlRoot(ElementName = "appcmd")]
        public class Appcmd
        {
            [XmlElement(ElementName = "WP")]
            public List<WP> WP { get; set; }
        }

    }

    namespace APPPOOL
    {
        [XmlRoot(ElementName = "APPPOOL")]
        public class APPPOOL
        {
            [XmlAttribute(AttributeName = "APPPOOL.NAME")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "PipelineMode")]
            public string PipelineMode { get; set; }
            [XmlAttribute(AttributeName = "RuntimeVersion")]
            public string RuntimeVersion { get; set; }
            [XmlAttribute(AttributeName = "state")]
            public string State { get; set; }
        }

        [XmlRoot(ElementName = "appcmd")]
        public class Appcmd
        {
            [XmlElement(ElementName = "APPPOOL")]
            public List<APPPOOL> APPPOOL { get; set; }
        }

    }


    public class ConfigProram
    {
        public string Path { get; set; }
    }

	[XmlRoot(ElementName = "add")]
	public class Add
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "connectionString")]
		public string ConnectionString { get; set; }
	}

	[XmlRoot(ElementName = "connectionStrings")]
	public class ConnectionStrings
	{
		[XmlElement(ElementName = "add")]
		public List<Add> Add { get; set; }
        [XmlIgnore]
        public string Path { get; set; }
    }

    public class ConfigData
    {
        public string DBHost { get; set; }
        public string DBName { get; set; }
        public string RedisHost { get; set; }
        public int RedisPort { get; set; }
        public int RedisDB { get; set; }
        public string Path { get; set; }
    }


	public class GridData
    {
        List<Pair<string, string>> Data { get; set; }
    }

    public sealed class Pair<TKey, TValue>
    {
        private readonly TKey key;
        private readonly IDictionary<TKey, TValue> data;
        public Pair(TKey key, IDictionary<TKey, TValue> data)
        {
            this.key = key;
            this.data = data;
        }
        public TKey Key { get { return key; } }
        public TValue Value
        {
            get
            {
                TValue value;
                data.TryGetValue(key, out value);
                return value;
            }
            set { data[key] = value; }
        }
    }
    public class DictionaryBindingList<TKey, TValue>
        : BindingList<Pair<TKey, TValue>>
    {
        private readonly IDictionary<TKey, TValue> data;
        public DictionaryBindingList(IDictionary<TKey, TValue> data)
        {
            this.data = data;
            Reset();
        }
        public void Reset()
        {
            bool oldRaise = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            try
            {
                Clear();
                foreach (TKey key in data.Keys)
                {
                    Add(new Pair<TKey, TValue>(key, data));
                }
            }
            finally
            {
                RaiseListChangedEvents = oldRaise;
                ResetBindings();
            }
        }
    }
}
