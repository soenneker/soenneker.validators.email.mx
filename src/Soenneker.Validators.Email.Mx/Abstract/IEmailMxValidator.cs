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
    /// Executes the validate email operation.
    /// </summary>
    /// <param name="email">The email address.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<bool> ValidateEmail(string email, CancellationToken cancellationToken = default);
}
