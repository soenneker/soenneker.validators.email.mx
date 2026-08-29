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
    /// Returns true if there is a domain, and it has MX records, and returns with no errors
    /// </summary>
    /// <param name="domain"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<bool> Validate(string domain, CancellationToken cancellationToken = default);

    /// <summary>
    /// Validates email for the Email Mx Validator.
    /// </summary>
    /// <param name="email">Email address to validate or query.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>true if validates email for the Email Mx Validator; otherwise, false.</returns>
    ValueTask<bool> ValidateEmail(string email, CancellationToken cancellationToken = default);
}
