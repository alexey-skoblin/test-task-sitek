using System;
using System.IO;
using System.Xml.Serialization;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTaskSitek.entity;

namespace TestTaskSitek.Tests.entity;

[TestClass]
[TestSubject(typeof(Address))]
public class AddressTest
{
    private const string XmlInput = @"
            <OBJECT ID=""52125811"" OBJECTID=""165085129"" OBJECTGUID=""013f6a8f-f5e2-4d8e-8e73-90ea81da21e3"" CHANGEID=""600551176"" NAME=""Кондрево"" TYPENAME=""тер."" LEVEL=""7"" OPERTYPEID=""10"" PREVID=""0"" NEXTID=""0"" UPDATEDATE=""2024-09-05"" STARTDATE=""2024-09-05"" ENDDATE=""2079-06-06"" ISACTUAL=""1"" ISACTIVE=""1""/>";

    [TestMethod]
    public void Address_Serialize_XmlAttributesAreCorrect()
    {
        var address = new Address
        {
            Id = 52125811,
            ObjectId = 165085129,
            ObjectGuid = Guid.Parse("013f6a8f-f5e2-4d8e-8e73-90ea81da21e3"),
            ChangeId = 600551176,
            Name = "Кондрево",
            TypeName = "тер.",
            Level = 7,
            OperTypeId = 10,
            PrevId = 0,
            NextId = 0,
            StartDate = new DateTime(2024, 9, 5),
            EndDate = new DateTime(2079, 6, 6),
            UpdateDate = new DateTime(2024, 9, 5),
            IsActual = true,
            IsActive = true
        };

        var serializer = new XmlSerializer(typeof(Address));

        string result;
        using (var stringWriter = new StringWriter())
        {
            serializer.Serialize(stringWriter, address);
            result = stringWriter.ToString();
        }

        StringAssert.Contains(result, @"ID=""52125811""");
        StringAssert.Contains(result, @"OBJECTID=""165085129""");
        StringAssert.Contains(result, @"OBJECTGUID=""013f6a8f-f5e2-4d8e-8e73-90ea81da21e3""");
        StringAssert.Contains(result, @"CHANGEID=""600551176""");
        StringAssert.Contains(result, @"NAME=""Кондрево""");
        StringAssert.Contains(result, @"TYPENAME=""тер.""");
        StringAssert.Contains(result, @"LEVEL=""7""");
        StringAssert.Contains(result, @"OPERTYPEID=""10""");
        StringAssert.Contains(result, @"PREVID=""0""");
        StringAssert.Contains(result, @"NEXTID=""0""");
        StringAssert.Contains(result, @"UPDATEDATE=""2024-09-05""");
        StringAssert.Contains(result, @"STARTDATE=""2024-09-05""");
        StringAssert.Contains(result, @"ENDDATE=""2079-06-06""");
        StringAssert.Contains(result, @"ISACTUAL=""1""");
        StringAssert.Contains(result, @"ISACTIVE=""1""");
    }

    [TestMethod]
    public void Address_Deserialize_XmlAttributesAreCorrect()
    {
        var serializer = new XmlSerializer(typeof(Address));

        Address result;
        using (var stringReader = new StringReader(XmlInput))
        {
            result = (Address)serializer.Deserialize(stringReader);
        }

        Assert.AreEqual(52125811, result.Id);
        Assert.AreEqual(165085129, result.ObjectId);
        Assert.AreEqual(Guid.Parse("013f6a8f-f5e2-4d8e-8e73-90ea81da21e3"), result.ObjectGuid);
        Assert.AreEqual(600551176, result.ChangeId);
        Assert.AreEqual("Кондрево", result.Name);
        Assert.AreEqual("тер.", result.TypeName);
        Assert.AreEqual(7, result.Level);
        Assert.AreEqual(10, result.OperTypeId);
        Assert.AreEqual(0, result.PrevId);
        Assert.AreEqual(0, result.NextId);
        Assert.AreEqual(new DateTime(2024, 9, 5), result.StartDate);
        Assert.AreEqual(new DateTime(2079, 6, 6), result.EndDate);
        Assert.AreEqual(new DateTime(2024, 9, 5), result.UpdateDate);
        Assert.IsTrue(result.IsActual);
        Assert.IsTrue(result.IsActive);
    }

    [TestMethod]
    public void Address_Deserialize_DatePropertiesMapCorrectly()
    {
        var serializer = new XmlSerializer(typeof(Address));

        Address result;
        using (var stringReader = new StringReader(XmlInput))
        {
            result = (Address)serializer.Deserialize(stringReader);
        }

        Assert.AreEqual("2024-09-05", result.StartDateString);
        Assert.AreEqual("2079-06-06", result.EndDateString);
        Assert.AreEqual("2024-09-05", result.UpdateDateString);
    }
}