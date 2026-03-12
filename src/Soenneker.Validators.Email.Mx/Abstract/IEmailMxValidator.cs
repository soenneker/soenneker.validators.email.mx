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

    ValueTask<bool> ValidateEmail(string email, CancellationToken cancellationToken = default);
}
