using System.Xml.Serialization;

namespace OPT_Faktury.Data
{
    [XmlRoot(ElementName = "Configuration")]
    public class Configuration
    {
        public Connection Connection { get; set; }
        public string BooksPath { get; set; }
        public string AuthorsPath { get; set; }
    }
    public class Connection
    {
        public string ConnectionString { get; set; }
       
    }


}
