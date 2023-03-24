using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

/*
#region xml to query
(
    //Load the xml from web service and get the items
    from element in
    XDocument.Load("https://www.dr.dk/nyheder/service/feeds/senestenyt").Element("rss").Element("channel").Elements("item")

        //Select the items to an anonymous object
    select new
    {
        Title = element.Element("title").Value,
        Link = element.Element("link").Value,
        Published = element.Element("pubDate").Value
    }
)
     //Make it a list so the query runs and it can be extended with .ForEach because it is now IEnumerable
     .ToList()
     //For every element write it to the console in an orderly fashion
     .ForEach(elmnt => { Console.WriteLine($"{elmnt.Published}: {elmnt.Title} \n \t {elmnt.Link}\n"); });
#endregion

*/

#region Dezz - Dezzerialize, Ha goteeem!
XmlSerializer XMLSeri = new XmlSerializer(typeof(Rss));

Rss reader = (Rss)XMLSeri.Deserialize(XmlReader.Create("https://www.dr.dk/nyheder/service/feeds/senestenyt"));

reader.Channel.Item.ForEach(i => Console.WriteLine($"{i.PubDate}: {i.Title} \n \t {i.Link2}\n"));


[XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
public class Link
{
    [XmlAttribute(AttributeName = "href")]
    public string Href { get; set; }
    [XmlAttribute(AttributeName = "rel")]
    public string Rel { get; set; }
    [XmlAttribute(AttributeName = "type")]
    public string Type { get; set; }
}

[XmlRoot(ElementName = "guid")]
public class Guid
{
    [XmlAttribute(AttributeName = "isPermaLink")]
    public string IsPermaLink { get; set; }
    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "item")]
public class Item
{
    [XmlElement(ElementName = "title")]
    public string Title { get; set; }
    [XmlElement(ElementName = "link")]
    public string Link2 { get; set; }
    [XmlElement(ElementName = "guid")]
    public Guid Guid { get; set; }
    [XmlElement(ElementName = "pubDate")]
    public string PubDate { get; set; }
}

[XmlRoot(ElementName = "channel")]
public class Channel
{
    [XmlElement(ElementName = "title")]
    public string Title { get; set; }
    [XmlElement(ElementName = "description")]
    public string Description { get; set; }
    [XmlElement(ElementName = "link")]
    public List<string> Link { get; set; }
    [XmlElement(ElementName = "generator")]
    public string Generator { get; set; }
    [XmlElement(ElementName = "lastBuildDate")]
    public string LastBuildDate { get; set; }
    [XmlElement(ElementName = "language")]
    public string Language { get; set; }
    [XmlElement(ElementName = "docs")]
    public string Docs { get; set; }
    [XmlElement(ElementName = "item")]
    public List<Item> Item { get; set; }
}

[XmlRoot(ElementName = "rss")]
public class Rss
{
    [XmlElement(ElementName = "channel")]
    public Channel Channel { get; set; }
    [XmlAttribute(AttributeName = "dc", Namespace = "http://www.w3.org/2000/xmlns/")]
    public string Dc { get; set; }
    [XmlAttribute(AttributeName = "content", Namespace = "http://www.w3.org/2000/xmlns/")]
    public string Content { get; set; }
    [XmlAttribute(AttributeName = "atom", Namespace = "http://www.w3.org/2000/xmlns/")]
    public string Atom { get; set; }
    [XmlAttribute(AttributeName = "version")]
    public string Version { get; set; }
}
#endregion
