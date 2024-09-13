using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTaskSitek.converter;
using static TestTaskSitek.utility.DateTimeFormats;

namespace TestTaskSitek.Tests.converter;

[TestClass]
public class DateTimeFormatterTests
{
    [TestMethod]
    public void ToDateString_ValidDate_ReturnsCorrectString()
    {
        var date = new DateTime(2024, 9, 13);
        var result = DateTimeFormatter.ToDateString(date);
        Assert.AreEqual("2024-09-13", result);
    }

    [TestMethod]
    public void FromDateString_ValidString_ReturnsCorrectDate()
    {
        var dateString = "2024-09-13";
        var expectedDate = new DateTime(2024, 9, 13);
        var result = DateTimeFormatter.FromDateString(dateString);
        Assert.AreEqual(expectedDate, result);
    }

    [TestMethod]
    public void ToDateString_EuropeanFormat_ReturnsCorrectString()
    {
        var date = new DateTime(2024, 9, 13);
        var result = date.ToString(EuropeanDateTimeFormat);
        Assert.AreEqual("13.09.2024", result);
    }

    [TestMethod]
    public void FromDateString_EuropeanFormat_ReturnsCorrectDate()
    {
        var dateString = "13.09.2024";
        var expectedDate = new DateTime(2024, 9, 13);
        var result = DateTimeFormatter.FromDateString(dateString);
        Assert.AreEqual(expectedDate, result);
    }

    [TestMethod]
    public void ToDateString_Iso8601Format_ReturnsCorrectString()
    {
        var date = new DateTime(2024, 9, 13, 12, 34, 56);
        var result = date.ToString(Iso8601DateTimeFormat);
        Assert.AreEqual("2024-09-13T12:34:56", result);
    }

    [TestMethod]
    public void FromDateString_Iso8601Format_ReturnsCorrectDate()
    {
        var dateString = "2024-09-13T12:34:56";
        var expectedDate = new DateTime(2024, 9, 13, 12, 34, 56);
        var result = DateTimeFormatter.FromDateString(dateString);
        Assert.AreEqual(expectedDate, result);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void FromDateString_InvalidString_ThrowsFormatException()
    {
        var invalidDateString = "invalid-date";
        DateTimeFormatter.FromDateString(invalidDateString);
    }
}