# ADR: Architecture and Design Decisions for Blog System

- **Status**: Accepted
- **Date**: 2024-10-13

## Context
The project is a simple blog system with the following features:
- Creating posts
- Listing posts
- Creating comments
- Updating posts

The system needs to store a history of post changes when updates occur.

## Decision
1. **Architecture Style**:
    - **N-Layer Architecture** was chosen over Clean Architecture for simplicity. It divides the project into layers (e.g., Presentation, Application, and Data Access). This is appropriate given the straightforward nature of the problem.
    - **Reason**: Clean Architecture would introduce additional complexity (e.g., use cases, more abstraction layers) that is unnecessary for this small-scale project.

2. **Data Access and ORM**:
    - **EF Core** is used for data access, managing database interactions, and performing CRUD operations.
    - **Reason**: EF Core simplifies interaction with the database through LINQ and provides the necessary functionality for this project's needs without the overhead of writing raw SQL.

3. **Unit Testing**:
    - **xUnit** is used for unit testing.
    - **Reason**: xUnit is a well-supported testing framework for .NET, making it suitable for testing the core functionality without introducing extra overhead.

4. **Cross-Cutting Concerns**:
    - A **Seedwork Layer** is used for handling common concerns across different layers.
    - **Reason**: This layer helps avoid code duplication and centralizes common functionality like guards, logging, and validation.

5. **Clean Code Practices**:
    - A **Guard Class** is used to ensure validation and error handling follows clean code principles.
    - **Reason**: This promotes code readability, maintainability, and a consistent way of handling validation across the project.

## Consequences
- **Positive**: The project remains simple and easy to understand. The development process is faster due to fewer abstractions, making it suitable for small-scale requirements.
- **Negative**: The current architecture might face challenges with scalability if the requirements become more complex. Transitioning to a more layered architecture like Clean Architecture might require significant refactoring in the future.

## Next Steps
- Monitor the project's growth and reassess the architecture if the complexity increases.
- Consider introducing design patterns or architectural changes as new features or requirements are added.
