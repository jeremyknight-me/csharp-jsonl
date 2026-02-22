---
description: 'Guidelines for building C# applications'
applyTo: '**/*.cs'
---

# C# Development Copilot Instructions

## C# Coding Practices

- Always use the latest C# version.
- Run `dotnet format` to auto-format code according to conventions established in `.editorconfig`
- Use analyzers to catch violations during build
- Only test code that you control and that has business logic; do not test framework code
- Keep classes focused on a single responsibility
- Use Dependency Injection for managing dependencies
- Prefer composition over inheritance
- Use async/await for I/O-bound operations
- Keep methods short and focused; ideally under 20 lines
- Keep argument lists short; consider using parameter objects if more than 4 parameters are needed
- Use Domain-Driven Design (DDD) principles where applicable

## Naming Conventions

- Apply naming conventions defined in `.editorconfig`.
- Follow PascalCase for component names, method names, and public members.
- Private fields should use camelCase with underscore prefix (`_fieldName`).
- Use camelCase for local variables.
- Prefix interface names with "I" (e.g., IUserService).
- Use `var` for built-in types and when type is apparent
- Suffix async methods with `Async` (e.g., `GetByIdAsync`)

## Formatting

- Prefer file-scoped namespace declarations and single-line using directives.
- Insert a newline before the opening curly brace of any code block (e.g., after `if`, `for`, `while`, `foreach`, `using`, `try`, etc.).
- Ensure that the final return statement of a method is on its own line.
- Use pattern matching and switch expressions wherever possible.
- Use `nameof` instead of string literals when referring to member names.
- Ensure that XML doc comments are created for any members that would trigger CS1591. When applicable, include `<example>` and `<code>` documentation in the comments.

## Nullable Reference Types

- Declare variables non-nullable, and check for `null` at entry points.
- Always use `is null` or `is not null` instead of `== null` or `!= null`.
- Trust the C# null annotations and don't add null checks when the type system says a value cannot be null.

## Testing Conventions

- Use `xUnit` for all tests
- Organize tests by feature in folders mirroring `src/` structure
- Do not name test classes with "Tests" suffix; do use "Tests" suffix for folder names if needed
  - Example: `ProductServiceTests/ProductService_Constructor.cs`
- Use `[Fact]` for simple tests, `[Theory]` with `[InlineData]` for parameterized tests
- Name test classes `ClassName_MethodName.cs`
- Name test methods `DoesSomething_GivenSomeCondition` (Given, When, Then)
- Reading the full class name and method name should form a proper sentence describing the use case being tested.
  - Example `ProductService_Constructor._ReturnsInstanceGivenValidInputs`
- Separate Unit Tests and Integration Tests into different projects or folders as appropriate
- If mocking is needed, prefer NSubstitute over alternatives.
- Prefer Shouldly for assertions.
- Avoid commercially licensed testing libraries (e.g. FluentAssertions, Moq)
