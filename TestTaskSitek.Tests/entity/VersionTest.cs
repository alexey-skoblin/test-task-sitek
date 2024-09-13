using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTaskSitek.parser;

namespace TestTaskSitek.Tests.entity;

[TestClass]
[TestSubject(typeof(Version))]
public class VersionTest
{
    private const string JsonObject =
        "{\"VersionId\":20240910,\"TextVersion\":\"\\u0411\\u0414 \\u0424\\u0418\\u0410\\u0421 \\u043E\\u0442 10.09.2024\",\"FiasCompleteDbfUrl\":\"\",\"FiasCompleteXmlUrl\":\"\",\"FiasDeltaDbfUrl\":\"\",\"FiasDeltaXmlUrl\":\"\",\"Kladr4ArjUrl\":\"https://fias-file.nalog.ru/downloads/2024.09.10/base.arj\",\"Kladr47ZUrl\":\"https://fias-file.nalog.ru/downloads/2024.09.10/base.7z\",\"GarXMLFullURL\":\"https://fias-file.nalog.ru/downloads/2024.09.10/gar_xml.zip\",\"GarXMLDeltaURL\":\"https://fias-file.nalog.ru/downloads/2024.09.10/gar_delta_xml.zip\",\"ExpDate\":\"2024-09-10T00:00:00\",\"Date\":\"10.09.2024\"}";

    [TestMethod]
    public void Version_Parse_VersionId_ReturnsCorrectValue()
    {
        var version = new JsonParser<TestTaskSitek.entity.Version>().Parse(JsonObject);
        var versionId = version.Id;
        Assert.AreEqual(20240910, versionId);
    }

    [TestMethod]
    public void Version_Parse_TextVersion_ReturnsCorrectValue()
    {
        var version = new JsonParser<TestTaskSitek.entity.Version>().Parse(JsonObject);
        var textVersion = version.Text;
        Assert.AreEqual("БД ФИАС от 10.09.2024", textVersion);
    }

    [TestMethod]
    public void Version_Parse_FiasCompleteDbfUrl_ReturnsEmptyString()
    {
        var version = new JsonParser<TestTaskSitek.entity.Version>().Parse(JsonObject);
        var fiasCompleteDbfUrl = version.FiasCompleteDbfUrl;
        Assert.AreEqual(string.Empty, fiasCompleteDbfUrl);
    }

    [TestMethod]
    public void Version_Parse_FiasCompleteXmlUrl_ReturnsEmptyString()
    {
        var version = new JsonParser<TestTaskSitek.entity.Version>().Parse(JsonObject);
        var fiasCompleteXmlUrl = version.FiasCompleteXmlUrl;
        Assert.AreEqual(string.Empty, fiasCompleteXmlUrl);
    }

    [TestMethod]
    public void Version_Parse_FiasDeltaDbfUrl_ReturnsEmptyString()
    {
        var version = new JsonParser<TestTaskSitek.entity.Version>().Parse(JsonObject);
        var fiasDeltaDbfUrl = version.FiasDeltaDbfUrl;
        Assert.AreEqual(string.Empty, fiasDeltaDbfUrl);
    }

    [TestMethod]
    public void Version_Parse_FiasDeltaXmlUrl_ReturnsEmptyString()
    {
        var version = new JsonParser<TestTaskSitek.entity.Version>().Parse(JsonObject);
        var fiasDeltaXmlUrl = version.FiasDeltaXmlUrl;
        Assert.AreEqual(string.Empty, fiasDeltaXmlUrl);
    }

    [TestMethod]
    public void Version_Parse_Kladr4ArjUrl_ReturnsCorrectValue()
    {
        var version = new JsonParser<TestTaskSitek.entity.Version>().Parse(JsonObject);
        var kladr4ArjUrl = version.Kladr4ArjUrl;
        Assert.AreEqual("https://fias-file.nalog.ru/downloads/2024.09.10/base.arj", kladr4ArjUrl);
    }

    [TestMethod]
    public void Version_Parse_Kladr47ZUrl_ReturnsCorrectValue()
    {
        var version = new JsonParser<TestTaskSitek.entity.Version>().Parse(JsonObject);
        var kladr47ZUrl = version.Kladr47ZUrl;
        Assert.AreEqual("https://fias-file.nalog.ru/downloads/2024.09.10/base.7z", kladr47ZUrl);
    }

    [TestMethod]
    public void Version_Parse_GarXMLFullURL_ReturnsCorrectValue()
    {
        var version = new JsonParser<TestTaskSitek.entity.Version>().Parse(JsonObject);
        var garXmlFullUrl = version.GarXmlFullUrl;
        Assert.AreEqual("https://fias-file.nalog.ru/downloads/2024.09.10/gar_xml.zip", garXmlFullUrl);
    }

    [TestMethod]
    public void Version_Parse_GarXMLDeltaURL_ReturnsCorrectValue()
    {
        var version = new JsonParser<TestTaskSitek.entity.Version>().Parse(JsonObject);
        var garXmlDeltaUrl = version.GarXmlDeltaUrl;
        Assert.AreEqual("https://fias-file.nalog.ru/downloads/2024.09.10/gar_delta_xml.zip", garXmlDeltaUrl);
    }

    [TestMethod]
    public void Version_Parse_ExpDate_ReturnsCorrectValue()
    {
        var version = new JsonParser<TestTaskSitek.entity.Version>().Parse(JsonObject);
        var expDate = version.ExpDate;
        Assert.AreEqual(DateTime.Parse("2024-09-10T00:00:00"), expDate);
    }

    [TestMethod]
    public void Version_Parse_Date_ReturnsCorrectValue()
    {
        var version = new JsonParser<TestTaskSitek.entity.Version>().Parse(JsonObject);
        var date = version.Date;
        Assert.AreEqual(new DateTime(2024, 9, 10), date);
    }
}