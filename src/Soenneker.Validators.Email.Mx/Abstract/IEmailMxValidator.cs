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
    /// Queries whether a domain publishes at least one MX record.
    /// </summary>
    /// <param name="domain">Domain name to validate and query.</param>
    /// <param name="cancellationToken">Token used to cancel the DNS lookup.</param>
    /// <returns>A task whose result is <see langword="true"/> when the DNS response contains an MX record; otherwise, <see langword="false"/>.</returns>
    ValueTask<bool> Validate(string domain, CancellationToken cancellationToken = default);

    /// <summary>
    /// Extracts the text after the email's last at-sign and queries it for MX records.
    /// </summary>
    /// <param name="email">Email address to validate or query.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns><see langword="true"/> when a domain can be extracted and its DNS response contains an MX record; otherwise, <see langword="false"/>.</returns>
    ValueTask<bool> ValidateEmail(string email, CancellationToken cancellationToken = default);
}
