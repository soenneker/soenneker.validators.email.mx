using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DnsClient;
using Microsoft.Extensions.Logging;
using Soenneker.DnsClient.Util.Abstract;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using Soenneker.Utils.String.Abstract;
using Soenneker.Validators.Email.Mx.Abstract;

namespace Soenneker.Validators.Email.Mx;

/// <inheritdoc cref="IEmailMxValidator"/>
public sealed class EmailMxValidator : Validator.Validator, IEmailMxValidator
{
    private readonly IStringUtil _stringUtil;
    private readonly IDnsClientUtil _dnsClientUtil;

    public EmailMxValidator(ILogger<EmailMxValidator> logger, IStringUtil stringUtil, IDnsClientUtil dnsClientUtil) : base(logger)
    {
        _stringUtil = stringUtil;
        _dnsClientUtil = dnsClientUtil;
    }

    public async ValueTask<bool> Validate(string domain, CancellationToken cancellationToken = default)
    {
        LookupClient client = await _dnsClientUtil.Get(cancellationToken: cancellationToken).NoSync();

        IDnsQueryResponse? result = await client.QueryAsync(domain, QueryType.MX, cancellationToken: cancellationToken).NoSync();

        if (result.HasError)
            return false;

        if (result.Answers.MxRecords().Any())
            return true;

        return false;
    }

    public ValueTask<bool> ValidateEmail(string email, CancellationToken cancellationToken = default)
    {
        string? domain = _stringUtil.GetDomainFromEmail(email);

        if (domain == null)
            return ValueTask.FromResult(false);

        return Validate(domain, cancellationToken);
    }
}