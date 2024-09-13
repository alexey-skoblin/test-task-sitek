using System.Xml.Serialization;
using TestTaskSitek.converter;

namespace TestTaskSitek.entity;

[XmlRoot("OBJECTLEVEL")]
public class AddressLevel
{
    [XmlAttribute("LEVEL")] public int LevelNumber { get; set; }

    [XmlAttribute("NAME")] public string Name { get; set; } = "";

    [XmlIgnore] public DateTime StartDate { get; set; }

    [XmlIgnore] public DateTime EndDate { get; set; }

    [XmlIgnore] public DateTime UpdateDate { get; set; }

    [XmlAttribute("ISACTIVE")] public bool IsActive { get; set; }

    // Свойства для работы с XML-конвертацией дат
    [XmlAttribute("STARTDATE")]
    public string StartDateString
    {
        get => DateTimeFormatter.ToDateString(StartDate);
        set => StartDate = DateTimeFormatter.FromDateString(value);
    }

    [XmlAttribute("ENDDATE")]
    public string EndDateString
    {
        get => DateTimeFormatter.ToDateString(EndDate);
        set => EndDate = DateTimeFormatter.FromDateString(value);
    }

    [XmlAttribute("UPDATEDATE")]
    public string UpdateDateString
    {
        get => DateTimeFormatter.ToDateString(UpdateDate);
        set => UpdateDate = DateTimeFormatter.FromDateString(value);
    }
}