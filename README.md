# Blog System

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Testing](#testing)

## Overview

This project is a simple Blog System built using .NET Core and Entity Framework Core (EF Core). It allows users to
create, update, and list posts, as well as add comments to posts. The system also tracks changes made to posts through a
history mechanism, ensuring that past versions of posts can be referenced.

## Features

- **Create Post**: Add new posts to the blog.
- **Post List**: Retrieve and display a list of all posts.
- **Update Post**: Update existing posts and track changes in the `PostHistory` table.
- **Create Comment**: Add comments to posts.
- **Post History**: Automatically store changes to posts in the `PostHistory` table whenever an update is made.

## Architecture
The project follows an **N-Layer Architecture** pattern, dividing the solution into logical layers to separate concerns:

- **Presentation Layer**: Handles the API endpoints and user interactions.
- **Application Layer**: Contains business logic and services.
- **Data Access Layer**: Manages database interactions using EF Core.

### Design Decisions
- for complete details of architecture decisions records go to [this](adr-blog-design-decisions.md) file

## Technologies Used
- **.NET Core**: Backend framework for building the application.
- **Entity Framework Core**: ORM for interacting with the database.
- **xUnit**: For unit testing.
- **SQL Server**: Database to store blog data (can be replaced with other databases supported by EF Core).
- **GitHub Actions**: For CI/CD pipeline and deployments.
- **Liara**: Deployment platform.

## Getting Started
### Prerequisites
- **.NET SDK 8.x**
- **SQL Server**

## Testing
```bash
   dotnet test
   ```

## Configuration
- Modify the database connection string in `appsettings.json` to point to your SQL Server instance.
- Adjust any other settings like logging or environment variables as needed

### Installation
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/blog-system.git
   cd blog-system
