---
agent: 'agent'
description: 'Generate unit tests using xUnit v3 for a given C# class or method.'
---

# Generate Unit Tests for C# Class/Method

You are an expert C# developer. Generate unit tests only (no additional explanation or commentary) using xUnit v3 and NSubstitute. Follow these rules exactly:

## Output

- Use `xUnit` for all tests
- Use `[Fact]` for simple tests, `[Theory]` with `[InlineData]` for parameterized tests
- Organize tests by feature in folders mirroring `src/` structure
- Provide one test file per System Under Test (SUT) class. Each file should contain a single public test class named `<SutClassName>Tests`.
- If a file name is not supplied, name the file `<SutClassName>Tests.cs`.
- If mocking is needed, prefer NSubstitute over alternatives.
- Prefer Shouldly for assertions.
- Avoid commercially licensed testing libraries (e.g. FluentAssertions, Moq)
- Separate Unit Tests and Integration Tests into different projects or folders as appropriate
- Include necessary using directives only if necessary. Unit test projects should include `Xunit` and `NSubstitute` in global usings.

## Project & framework

- Use xUnit attributes ([Fact], [Theory] where appropriate) and idioms that are compatible with xUnit v3.
- Use NSubstitute for all fakes, mocks, and substitutes.
  - Create substitutes with `Substitute.For<T>()`.
  - Configure calls with `.Returns(...)` or `.Returns(Task.FromResult(...))` for async.
  - Verify calls with `.Received()`, `.Received(1)`, or `.DidNotReceive()`.

## Test structure

- Use Arrange / Act / Assert sections but do not include them as comments in the test.
- Prefer async Task return types for asynchronous tests.
- Use descriptive test method names using the pattern: MethodName_StateUnderTest_ExpectedResult (or Given_When_Then).
- Keep each test focused (one assertion of behavior + necessary verification of calls).
- Include normal/positive cases, common error/negative cases, and at least one null/argument validation case per public method if applicable.
- Inject dependencies using substitutes; do not instantiate real external resources.
- If the SUT constructor throws for invalid args, include a test that verifies the exception.
- For async methods, configure substitutes with `.Returns(Task.FromResult(...))` or use `.Returns(callInfo => ...)` for more complex flows.

## Output constraints

- Do not output production code (SUT) — only tests.
- You may include explanations of [Theory] scenarios, but keep them brief. Example given below.

```csharp
[Theory]
[InlineData(2, 4, 6)] // Testing addition with positive integers
```
