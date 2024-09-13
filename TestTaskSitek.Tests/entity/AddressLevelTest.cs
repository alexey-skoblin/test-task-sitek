using System;
using System.IO;
using System.Xml.Serialization;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTaskSitek.entity;

namespace TestTaskSitek.Tests.entity;

[TestClass]
[TestSubject(typeof(AddressLevel))]
public class AddressLevelTest
{
    private const string XmlInput =
        @"<OBJECTLEVEL LEVEL=""1"" NAME=""Test Object"" STARTDATE=""2024-01-01"" ENDDATE=""2024-12-31"" UPDATEDATE=""2024-06-15"" ISACTIVE=""true""/>";

    [TestMethod]
    public void AddressLevel_Serialize_XmlAttributesAreCorrect()
    {
        var addressLevel = new AddressLevel
        {
            LevelNumber = 1,
            Name = "Субъект РФ",
            StartDate = new DateTime(1900, 1, 1),
            EndDate = new DateTime(2079, 6, 6),
            UpdateDate = new DateTime(1900, 1, 1),
            IsActive = true
        };

        var serializer = new XmlSerializer(typeof(AddressLevel));

        string result;
        using (var stringWriter = new StringWriter())
        {
            serializer.Serialize(stringWriter, addressLevel);
            result = stringWriter.ToString();
        }

        StringAssert.Contains(result, @"LEVEL=""1""");
        StringAssert.Contains(result, @"NAME=""Субъект РФ""");
        StringAssert.Contains(result, @"STARTDATE=""1900-01-01""");
        StringAssert.Contains(result, @"ENDDATE=""2079-06-06""");
        StringAssert.Contains(result, @"UPDATEDATE=""1900-01-01""");
        StringAssert.Contains(result, @"ISACTIVE=""true""");
    }

    [TestMethod]
    public void ObjectLevel_Deserialize_XmlAttributesAreCorrect()
    {
        var serializer = new XmlSerializer(typeof(AddressLevel));

        AddressLevel result;
        using (var stringReader = new StringReader(XmlInput))
        {
            result = (AddressLevel)serializer.Deserialize(stringReader);
        }

        Assert.AreEqual(1, result.LevelNumber);
        Assert.AreEqual("Test Object", result.Name);
        Assert.AreEqual(new DateTime(2024, 1, 1), result.StartDate);
        Assert.AreEqual(new DateTime(2024, 12, 31), result.EndDate);
        Assert.AreEqual(new DateTime(2024, 6, 15), result.UpdateDate);
        Assert.IsTrue(result.IsActive);
    }

    [TestMethod]
    public void ObjectLevel_Deserialize_DatePropertiesMapCorrectly()
    {
        var serializer = new XmlSerializer(typeof(AddressLevel));

        AddressLevel result;
        using (var stringReader = new StringReader(XmlInput))
        {
            result = (AddressLevel)serializer.Deserialize(stringReader);
        }

        Assert.AreEqual("2024-01-01", result.StartDateString);
        Assert.AreEqual("2024-12-31", result.EndDateString);
        Assert.AreEqual("2024-06-15", result.UpdateDateString);
    }
}