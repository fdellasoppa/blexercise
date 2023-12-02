using BL.Students.Domain.Students;
using FluentAssertions;
using NUnit.Framework;

namespace BL.Students.Domain.Test.Students;

public class StudentTests
{
    [Test]
    public void ValidSSN()
    {
        // AAA-GG-SSSS
        var student = new Student(
            new StudentId(new Guid()),
            string.Empty,
            SocialSecurityNumber.Create("123-45-6789"));

        student.SSN.Value.Should().BeEquivalentTo("123-45-6789");
    }

    [Test]
    public void InvalidSSNWrongFormat()
    {
        // 123-12312-1
        var student = new Student(
            new StudentId(new Guid()),
            string.Empty,
            SocialSecurityNumber.Create("123-12312-1"));

        student.SSN.Should().BeNull();
    }

    [Test]
    public void InvalidSSNTooShortS()
    {
        // AAA-GG-SSS
        var student = new Student(
            new StudentId(new Guid()),
            string.Empty,
            SocialSecurityNumber.Create("123-12-123"));

        student.SSN.Should().BeNull();
    }

    [Test]
    public void InvalidSSNTooShortG()
    {
        // AAA-G-SSSS
        var student = new Student(
            new StudentId(new Guid()),
            string.Empty,
            SocialSecurityNumber.Create("123-1-1234"));

        student.SSN.Should().BeNull();
    }

    [Test]
    public void InvalidSSNTooShortA()
    {
        // AA-GG-SSSS
        var student = new Student(
            new StudentId(new Guid()),
            string.Empty,
            SocialSecurityNumber.Create("12-12-1234"));

        student.SSN.Should().BeNull();
    }

    [Test]
    public void ValidSSNInitialZeros()
    {
        // 00A-GG-SSSS
        var student = new Student(
            new StudentId(new Guid()),
            string.Empty,
            SocialSecurityNumber.Create("001-12-1234"));

        student.SSN.Value.Should().BeEquivalentTo("001-12-1234");
    }

    [Test]
    public void ValidSSNAllNumbers()
    {
        // AAAGGSSSS
        var student = new Student(
            new StudentId(new Guid()),
            string.Empty,
            SocialSecurityNumber.Create("123456789")!);

        student.SSN.Value.Should().BeEquivalentTo("123-45-6789");
    }

    [Test]
    public void InvalidSSNTooShort()
    {
        var student = new Student(
            new StudentId(new Guid()),
            string.Empty,
            SocialSecurityNumber.Create("12345678"));

        student.SSN.Should().BeNull();
    }

    [Test]
    public void InvalidSSNTooLong()
    {
        var student = new Student(
            new StudentId(new Guid()),
            string.Empty,
            SocialSecurityNumber.Create("123-45-67890"));

        student.SSN.Should().BeNull();
    }

    [Test]
    public void InvalidSSNTooManyHyphens()
    {
        var student = new Student(
            new StudentId(new Guid()),
            string.Empty,
            SocialSecurityNumber.Create("123-45-67-8"));

        student.SSN.Should().BeNull();
    }

    [Test]
    public void InvalidSSNLetter()
    {
        var student = new Student(
            new StudentId(new Guid()),
            string.Empty,
            SocialSecurityNumber.Create("123-45-678O"));

        student.SSN.Should().BeNull();
    }

}