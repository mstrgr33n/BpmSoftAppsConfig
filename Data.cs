using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CreatioManagmentTools
{
    namespace Settings
    {
        public class Settings
        {
            public string AppsPath { get; set; }
            public string TempPath { get; set; }
            [DefaultValue(@"https://files.corporate-domain.ru")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public string BaseUrl { get; set; }
            [DefaultValue(@"/Release/")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public string InstallFilesUrl { get; set; }
            [DefaultValue(@"/ReleaseDemo/")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public string InstallDemoFilesUrl { get; set; }
            public string BaseSiteName { get; set; }
            [DefaultValue(80)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public int DefaultPort { get; set; }
            [DefaultValue("ConnectionStrings.config")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public string ConStrFileName { get; set; }
            [DefaultValue("Data Source={0};Initial Catalog={1};{2};MultipleActiveResultSets=True;Pooling=true;Max Pool Size=100")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public string MSSQLConnectionString { get; set; }
            public string MSSQLDBPath { get; set; }
            [DefaultValue("localhost")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public string MSSQLDataSource { get; set; }
            [DefaultValue("master")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public string MSSQLInitialCatalog { get; set; }
            [DefaultValue("Integrated Security=SSPI")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public string MSSQLIntegratedSecurity { get; set; }
            public string MSSQLUserID { get; set; }
            public string MSSQLPassword { get; set; }
            [DefaultValue(true)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public bool  MSSQLWindowsAuth { get; set; }
            [DefaultValue("localhost")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public string RedisHost { get; set; }
            [DefaultValue(6379)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public int RedisPort { get; set; }
            [DefaultValue("Server={0};Port={1};Database={2};User ID={3};password={4};Timeout=500; CommandTimeout=400;MaxPoolSize=1024;")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public string PSQLConnectionSctring { get; set; }
            [DefaultValue("localhost")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public string PSQLServer { get; set; }
            [DefaultValue(5432)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
            public int PSQLPort { get; set; }
            public string PSQLUserID { get; set; }
            public string PSQLPassword { get; set; }
            public string PSQLPath { get; set; }
        }

        public class MainGridData
        {
            public string DBHost { get; set; } 
            public string DBName { get; set; }
            public string RedisHost { get; set; }
            public string RedisPort { get; set; }
            public int RedisDB { get; set; }
            public string Path { get; set; }
        }
    }

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

    namespace ConnectionStrings
    {
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
    }
}
