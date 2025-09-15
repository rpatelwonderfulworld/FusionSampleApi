# FusionSample API

This is a **.NET 9 Web API** project for FusionSample, featuring JWT-based authentication and Swagger documentation.

---

## Features

- **JWT Authentication** (HS256) for secure endpoints
- Login endpoint `/api/Auth/login` to generate access tokens
- Example secured endpoints with `[Authorize]`
- Swagger UI for API exploration
- Clean architecture with Controllers and Middleware
- Error handling via custom middleware

---

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Git
- (Optional) Visual Studio 2022 or VS Code

---

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/rpatelwonderfulworld/FusionSampleApi.git
cd FusionSampleApi/backend/FusionSample.Api
