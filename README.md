# ActiveSSO
Azure Active Directory clone that focus on single sign-on (SSO) functionality.

# Features (Moscow)
## Must have
1. User Management: Registration, Authentication.
2. Session Management: login, logout, session timeout for SSO.
3. Register and manage applications that users can access.
4. Security handling of data (JWT, Password Hash)

## Should have
1. Audit Log: who do what to which resources when
2. Multi-factor authentication (MFA)
3. RBAC: Authorization

## Could have
1. Custom token claims
2. Integration with external identity provider

# Milestone
## Phase 1: User Authentication
1. Set up user registration and login.
2. Implement JWT-based authentication.
3. Basic session management (login, logout, session expiration).
## Phase 2: Application Management
1. Develop a module to register and manage applications.
2. Link users to applications.
## Phase 3: SSO Implementation
1. Implement SSO using OAuth 2.0 and OpenID Connect.
2. Handle SSO flow: authorization, token issuance, and validation.
3. Enable users to access multiple applications with a single login.

# Technology i learn
1. Code-first Migration using Entity Framework Core

// To learn
ASP.NET Core Web API
Entity Framework Core (EF Core)
Code-First Database Migrations
LINQ
Caching (e.g., In-memory, Redis)
Logging (e.g., Serilog, NLog)
Dependency Injection (DI)
Unit Testing (xUnit/NUnit, Moq)
Integration Testing
Input Validation (FluentValidation)
JWT Authentication
API Best Practices (Security, Performance, Documentation)





