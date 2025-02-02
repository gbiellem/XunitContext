﻿#region TestExceptionSample

public static class GlobalSetup
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void Setup()
    {
        XunitContext.EnableExceptionCapture();
    }
}

[Trait("Category", "Integration")]
public class TestExceptionSample :
    XunitContextBase
{
    [Fact]
    public void Usage()
    {
        //This tests will fail
        Assert.False(true);
    }

    public TestExceptionSample(ITestOutputHelper output) :
        base(output)
    {
    }

    public override void Dispose()
    {
        var theExceptionThrownByTest = Context.TestException;
        var testDisplayName = Context.Test.DisplayName;
        var testCase = Context.Test.TestCase;
        base.Dispose();
    }
}
#endregion
