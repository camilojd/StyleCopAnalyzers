﻿namespace StyleCop.Analyzers.Test.NamingRules
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StyleCop.Analyzers.NamingRules;
    using TestHelper;

    [TestClass]
    public class SA1300UnitTests : CodeFixVerifier
    {
        private const string DiagnosticId = SA1300ElementMustBeginWithUpperCaseLetter.DiagnosticId;
        private const string Message = "Element '{0}' must begin with an uppercase letter";

        [TestMethod]
        public async Task TestUpperCaseNamespace()
        {
            var testCode = @"public namespace Test 
{ 

}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseNamespace()
        {
            var testCode = @"public namespace test 
{ 

}";

            var expected = new[]
            {
                new DiagnosticResult
                {
                    Id = DiagnosticId,
                    Message = string.Format(Message, "test"),
                    Severity = DiagnosticSeverity.Warning,
                    Locations =
                    new []
                    {
                        new DiagnosticResultLocation("Test0.cs", 1, 18)
                    }
                }
            };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCaseClass()
        {
            var testCode = @"public class Test 
{ 

}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseClass()
        {
            var testCode = @"public class test 
{ 

}";

            var expected = new[]
            {
                new DiagnosticResult
                {
                    Id = DiagnosticId,
                    Message = string.Format(Message, "test"),
                    Severity = DiagnosticSeverity.Warning,
                    Locations =
                    new []
                    {
                        new DiagnosticResultLocation("Test0.cs", 1, 14)
                    }
                }
            };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCaseInterface()
        {
            var testCode = @"public interface Test
{

}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseInterface()
        {
            var testCode = @"public interface test
{

}";

            // Reported as SA1302
            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCaseStruct()
        {
            var testCode = @"public struct Test 
{ 

}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseStruct()
        {
            var testCode = @"public struct test 
{ 

}";

            var expected = new[]
            {
                new DiagnosticResult
                {
                    Id = DiagnosticId,
                    Message = string.Format(Message, "test"),
                    Severity = DiagnosticSeverity.Warning,
                    Locations =
                    new []
                    {
                        new DiagnosticResultLocation("Test0.cs", 1, 15)
                    }
                }
            };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCaseEnum()
        {
            var testCode = @"public enum Test 
{ 

}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseEnum()
        {
            var testCode = @"public enum test 
{ 

}";

            var expected = new[]
            {
                new DiagnosticResult
                {
                    Id = DiagnosticId,
                    Message = string.Format(Message, "test"),
                    Severity = DiagnosticSeverity.Warning,
                    Locations =
                    new []
                    {
                        new DiagnosticResultLocation("Test0.cs", 1, 13)
                    }
                }
            };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCaseDelegate()
        {
            var testCode = @"public class TestClass
{ 
public delegate void Test();
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseDelegate()
        {
            var testCode = @"public class TestClass
{ 
public delegate void test();
}";

            var expected = new[]
            {
                new DiagnosticResult
                {
                    Id = DiagnosticId,
                    Message = string.Format(Message, "test"),
                    Severity = DiagnosticSeverity.Warning,
                    Locations =
                    new []
                    {
                        new DiagnosticResultLocation("Test0.cs", 3, 22)
                    }
                }
            };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCaseEvent()
        {
            var testCode = @"public class TestClass
{
    public delegate void Test();
    Test _testEvent;
    public event Test TestEvent
    {
        add
        {
            _testEvent += value;
        }
        remove
        {
            _testEvent -= value;
        }
    }
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseEvent()
        {
            var testCode = @"public class TestClass
{
    public delegate void Test();
    Test _testEvent;
    public event Test testEvent
    {
        add
        {
            _testEvent += value;
        }
        remove
        {
            _testEvent -= value;
        }
    }
}";

            var expected = new[]
            {
                new DiagnosticResult
                {
                    Id = DiagnosticId,
                    Message = string.Format(Message, "testEvent"),
                    Severity = DiagnosticSeverity.Warning,
                    Locations =
                    new []
                    {
                        new DiagnosticResultLocation("Test0.cs", 5, 23)
                    }
                }
            };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCaseEventField()
        {
            var testCode = @"public class TestClass
{
    public delegate void Test();
    public event Test TestEvent;
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseEventField()
        {
            var testCode = @"public class TestClass
{
    public delegate void Test();
    public event Test testEvent;
}";

            var expected = new[]
            {
                new DiagnosticResult
                {
                    Id = DiagnosticId,
                    Message = string.Format(Message, "testEvent"),
                    Severity = DiagnosticSeverity.Warning,
                    Locations =
                    new []
                    {
                        new DiagnosticResultLocation("Test0.cs", 4, 23)
                    }
                }
            };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCaseMethod()
        {
            var testCode = @"public class TestClass
{
public void Test()
{

}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseMethod()
        {
            var testCode = @"public class TestClass
{
public void test()
{

}";

            var expected = new[]
            {
                new DiagnosticResult
                {
                    Id = DiagnosticId,
                    Message = string.Format(Message, "test"),
                    Severity = DiagnosticSeverity.Warning,
                    Locations =
                    new []
                    {
                        new DiagnosticResultLocation("Test0.cs", 3, 13)
                    }
                }
            };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCaseProperty()
        {
            var testCode = @"public class TestClass
{
public string Test { get; set; }
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseProperty()
        {
            var testCode = @"public class TestClass
{
public string test { get; set; }
}";

            var expected = new[]
            {
                new DiagnosticResult
                {
                    Id = DiagnosticId,
                    Message = string.Format(Message, "test"),
                    Severity = DiagnosticSeverity.Warning,
                    Locations =
                    new []
                    {
                        new DiagnosticResultLocation("Test0.cs", 3, 15)
                    }
                }
            };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCasePublicField()
        {
            var testCode = @"public class TestClass
{
public string Test;
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCaseInternalField()
        {
            var testCode = @"public class TestClass
{
internal string Test;
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCaseConstField()
        {
            var testCode = @"public class TestClass
{
const string Test;
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestUpperCaseProtectedReadOnlyField()
        {
            var testCode = @"public class TestClass
{
protected readonly string Test;
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseProtectedField()
        {
            var testCode = @"public class TestClass
{
protected string Test;
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseReadOnlyField()
        {
            var testCode = @"public class TestClass
{
readonly string test;
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCasePublicField()
        {
            var testCode = @"public class TestClass
{
public string test;
}";

            // Handled by SA1307
            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseInternalField()
        {
            var testCode = @"public class TestClass
{
internal string test;
}";

            // Handled by SA1307
            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseConstField()
        {
            var testCode = @"public class TestClass
{
const string test;
}";

            // Reported as SA1303
            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestNativeMethodsException()
        {
            var testCode = @"public class TestNativeMethods
{
public string test;
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestLowerCaseProtectedReadOnlyField()
        {
            var testCode = @"public class TestClass
{
protected readonly string test;
}";

            // Handled by SA1304
            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new SA1300ElementMustBeginWithUpperCaseLetter();
        }
    }
}
