[![](https://img.shields.io/nuget/v/soenneker.validators.email.mx.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.email.mx/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.email.mx/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.validators.email.mx/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.validators.email.mx.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.email.mx/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.email.mx/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.validators.email.mx/actions/workflows/codeql.yml)

# Soenneker.Validators.Email.Mx

Queries DNS for MX records on a domain or on the domain extracted from an email-shaped string.

## Install

```bash
dotnet add package Soenneker.Validators.Email.Mx
```

## Registration

```csharp
using Soenneker.Validators.Email.Mx.Registrars;
using Microsoft.Extensions.DependencyInjection;

services.AddEmailMxValidatorAsSingleton();
```

`AddEmailMxValidatorAsScoped()` is also available. The scoped validator still reuses the singleton DNS client utility; disposing the scope does not discard that shared DNS client state. The singleton registration uses singleton dependencies throughout.

## Query a domain

```csharp
using Soenneker.Validators.Email.Mx.Abstract;

bool hasMx = await validator.Validate(
    "example.com",
    cancellationToken);
```

The result is `true` when the DNS response contains at least one MX answer and `false` when the response reports an error or contains no MX answers. The method does not validate or normalize domain syntax before querying.

## Query an email domain

```csharp
bool hasMx = await validator.ValidateEmail(
    "person@example.com",
    cancellationToken);
```

`ValidateEmail` extracts the text after the last `@`. It returns `false` when non-empty text cannot be extracted on both sides, then delegates to the domain query. This is not mailbox syntax validation and does not trim input or normalize internationalized domain names.

## What an MX result means

A `true` result proves only that the resolver returned an MX record. It does not prove that a mailbox exists, accepts mail, or belongs to a user. The validator does not connect to an SMTP server and does not apply the implicit-A/AAAA fallback used by mail delivery when MX records are absent.

DNS response errors are returned as `false`. Transport failures and cancellation from the DNS client propagate to the caller. DNS answers can change and may be cached by the underlying resolver, so do not persist this result as permanent deliverability state.
