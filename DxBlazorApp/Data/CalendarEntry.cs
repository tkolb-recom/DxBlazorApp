using System.Xml.Serialization;

namespace DxBlazorApp.Data;

[Serializable]
public class CalendarEntry
{
    [XmlAttribute]
    public string Employee { get; set; }

    [XmlAttribute]
    public DateTime Begin { get; set; }

    [XmlAttribute]
    public DateTime End { get; set; }
}