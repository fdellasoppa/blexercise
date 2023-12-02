using NUnit.Framework;

namespace BL.Students.Domain.Test.Students;

public class StudentTests
{
    [Test]
    public void ValidSSN()
    {
        // AAA-GG-SSSS
        throw new NotImplementedException();
    }

    [Test]
    public void InvalidSSNWrongFormat()
    {
        // 123-12312-1
        throw new NotImplementedException();
    }

    [Test]
    public void InvalidSSNTooShortS()
    {
        // AAA-GG-SSS
        throw new NotImplementedException();
    }

    [Test]
    public void InvalidSSNTooShortG()
    {
        // AAA-G-SSSS
        throw new NotImplementedException();
    }

    [Test]
    public void InvalidSSNTooShortA()
    {
        // AA-G-SSSS
        throw new NotImplementedException();
    }

    [Test]
    public void ValidSSNInitialZeros()
    {
        // 00A-GG-SSSS
        throw new NotImplementedException();
    }

    [Test]
    public void InvalidSSNAllNumbers()
    {
        // AAAGGSSSS
        throw new NotImplementedException();
    }

}