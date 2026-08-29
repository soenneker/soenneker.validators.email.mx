[![](https://img.shields.io/nuget/v/soenneker.validators.email.mx.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.email.mx/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.email.mx/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.validators.email.mx/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.validators.email.mx.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.email.mx/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.email.mx/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.validators.email.mx/actions/workflows/codeql.yml)

# Soenneker.Validators.Email.Mx

A validation module checking for the existence of domain MX records.

## Install

```bash
dotnet add package Soenneker.Validators.Email.Mx
```

## Quick start

```csharp
using Soenneker.Validators.Email.Mx.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddEmailMxValidatorAsSingleton();
```

Adds `IEmailMxValidator` as a singleton service.

## What you get

- `IEmailMxValidator` — A validation module checking for the existence of domain MX records.
- `EmailMxValidatorRegistrar` — Registers the validator that checks whether an email domain publishes MX records.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IEmailMxValidator.Validate(domain, cancellationToken)` | Checks whether a domain is syntactically valid and publishes at least one MX record. | A task whose result is `true` when MX records are present and no validation error occurs; otherwise, `false`. |
| `EmailMxValidatorRegistrar.AddEmailMxValidatorAsSingleton(services)` | Adds `IEmailMxValidator` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `EmailMxValidatorRegistrar.AddEmailMxValidatorAsScoped(services)` | Adds `IEmailMxValidator` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
