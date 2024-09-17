using System.Xml.Serialization;
using TestTaskSitek.converter;

namespace TestTaskSitek.entity;

[XmlRoot("OBJECT")]
public class Address : IComparable<Address>
{
    [XmlAttribute("ID")] public int Id { get; set; }

    [XmlAttribute("OBJECTID")] public int ObjectId { get; set; }

    [XmlAttribute("OBJECTGUID")] public Guid ObjectGuid { get; set; }

    [XmlAttribute("CHANGEID")] public int ChangeId { get; set; }

    [XmlAttribute("NAME")] public string Name { get; set; } = "";

    [XmlAttribute("TYPENAME")] public string TypeName { get; set; } = "";

    [XmlAttribute("LEVEL")] public int Level { get; set; }

    [XmlAttribute("OPERTYPEID")] public int OperTypeId { get; set; }

    [XmlAttribute("PREVID")] public int PrevId { get; set; }

    [XmlAttribute("NEXTID")] public int NextId { get; set; }

    [XmlIgnore] public DateTime UpdateDate { get; set; }

    [XmlIgnore] public DateTime StartDate { get; set; }

    [XmlIgnore] public DateTime EndDate { get; set; }

    [XmlIgnore] public bool IsActual { get; set; }

    [XmlIgnore] public bool IsActive { get; set; }

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

    [XmlAttribute("ISACTUAL")]
    public int IsActualInt
    {
        get => IsActual ? 1 : 0;
        set => IsActual = value == 1;
    }

    [XmlAttribute("ISACTIVE")]
    public int IsActiveInt
    {
        get => IsActive ? 1 : 0;
        set => IsActive = value == 1;
    }

    public int CompareTo(Address? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}