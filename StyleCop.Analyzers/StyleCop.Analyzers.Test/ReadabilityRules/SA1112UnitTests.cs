﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.Analyzers.ReadabilityRules;
using TestHelper;

namespace StyleCop.Analyzers.Test.ReadabilityRules
{
    [TestClass]
    public class SA1112UnitTests : CodeFixVerifier
    {

        public string DiagnosticId { get; } = SA1112ClosingParenthesisMustBeOnLineOfOpeningParenthesis.DiagnosticId;

        [TestMethod]
        public async Task TestEmptySource()
        {
            var testCode = string.Empty;
            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestMethodWithNoParametersClosingParanthesisOnTheNextLine()
        {
            var testCode = @"
class Foo
{
    public void Bar(
)
    {

    }
}";

            var expected = new[]
                {
                    new DiagnosticResult
                    {
                        Id = this.DiagnosticId,
                        Message = "Closing parenthesis must be on line of opening parenthesis",
                        Severity = DiagnosticSeverity.Warning,
                        Locations =
                            new[]
                            {
                                new DiagnosticResultLocation("Test0.cs", 5, 1)
                            }
                    }
                };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestMethodWithNoParametersClosingParanthesisOnTheSameLine()
        {
            var testCode = @"
class Foo
{
    public void Bar()
    {

    }
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestMethodWithParametersClosingParanthesisOnTheNextLine()
        {
            var testCode = @"
class Foo
{
    public void Bar(
string s)
    {

    }
}";


            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestConstructorWithNoParametersClosingParanthesisOnTheNextLine()
        {
            var testCode = @"
class Foo
{
    public Foo(
)
    {

    }
}";

            var expected = new[]
                {
                    new DiagnosticResult
                    {
                        Id = this.DiagnosticId,
                        Message = "Closing parenthesis must be on line of opening parenthesis",
                        Severity = DiagnosticSeverity.Warning,
                        Locations =
                            new[]
                            {
                                new DiagnosticResultLocation("Test0.cs", 5, 1)
                            }
                    }
                };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestConstructorWithNoParametersClosingParanthesisOnTheSameLine()
        {
            var testCode = @"
class Foo
{
    public Foo()
    {

    }
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestConstructorWithParametersClosingParanthesisOnTheNextLine()
        {
            var testCode = @"
class Foo
{
    public Foo(
string s)
    {

    }
}";


            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestMethodCallNoParametersClosingParanthesisOnTheNextLine()
        {
            var testCode = @"
class Foo
{
    public void Bar()
    {
        var s = ToString(
);
    }
}";


            var expected = new[]
                {
                    new DiagnosticResult
                    {
                        Id = this.DiagnosticId,
                        Message = "Closing parenthesis must be on line of opening parenthesis",
                        Severity = DiagnosticSeverity.Warning,
                        Locations =
                            new[]
                            {
                                new DiagnosticResultLocation("Test0.cs", 7, 1)
                            }
                    }
                };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestMethodCallWithParametersClosingParanthesisOnTheNextLine()
        {
            var testCode = @"
class Foo
{
    public void Bar()
    {
        var s = this.Equals(new Foo()
);
    }
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestMethodCallNoParametersClosingParanthesisOnTheSameLine()
        {
            var testCode = @"
class Foo
{
    public void Bar()
    {
        var s = ToString();
    }
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestConstructorCallNoParametersClosingParanthesisOnTheNextLine()
        {
            var testCode = @"
class Foo
{
    public void Bar()
    {
        var o = new object(
);
    }
}";

            var expected = new[]
                {
                    new DiagnosticResult
                    {
                        Id = this.DiagnosticId,
                        Message = "Closing parenthesis must be on line of opening parenthesis",
                        Severity = DiagnosticSeverity.Warning,
                        Locations =
                            new[]
                            {
                                new DiagnosticResultLocation("Test0.cs", 7, 1)
                            }
                    }
                };

            await this.VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestConstructorCallWithParametersClosingParanthesisOnTheNextLine()
        {
            var testCode = @"
public class CtorWithParams
{
    public CtorWithParams(string s)
    {
    }
}
class Foo
{
    public void Bar()
    {
        var o = new CtorWithParams(string.Empty
);
    }
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestConstructorCallNoParametersClosingParanthesisOnTheSameLine()
        {
            var testCode = @"
class Foo
{
    public void Bar()
    {
        var o = new object();
    }
}";


            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestIndexerWithParametersClosingParanthesisOnTheNextLine()
        {
            var testCode = @"
class Foo
{
    public int this[int index
]
    {
        get
        {
            return 1;
        }    
    }
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestCreationOfObjectNoOpeningClosingParenthesis()
        {
            var testCode = @"
public class Foo
{
    public void Bar()
    {
        System.Collections.Generic.Dictionary<int, int> cache = new System.Collections.Generic.Dictionary<int, int> { { 3, 3 } };
    }
}";

            await this.VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new SA1112ClosingParenthesisMustBeOnLineOfOpeningParenthesis();
        }
    }
}