using Soenneker.Validators.Validator.Abstract;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Validators.Email.Mx.Abstract;

/// <summary>
/// A validation module checking for the existence of domain MX records
/// </summary>
public interface IEmailMxValidator : IValidator
{
    /// <summary>
    /// Checks whether a domain is syntactically valid and publishes at least one MX record.
    /// </summary>
    /// <param name="domain">Domain name to validate and query.</param>
    /// <param name="cancellationToken">Token used to cancel the DNS lookup.</param>
    /// <returns>A task whose result is <see langword="true"/> when MX records are present and no validation error occurs; otherwise, <see langword="false"/>.</returns>
    ValueTask<bool> Validate(string domain, CancellationToken cancellationToken = default);

    /// <summary>
    /// Validates email for the Email Mx Validator.
    /// </summary>
    /// <param name="email">Email address to validate or query.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>true if validates email for the Email Mx Validator; otherwise, false.</returns>
    ValueTask<bool> ValidateEmail(string email, CancellationToken cancellationToken = default);
}
