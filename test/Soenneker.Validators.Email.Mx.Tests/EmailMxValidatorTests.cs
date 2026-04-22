using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Validators.Email.Mx.Abstract;
using Soenneker.Tests.HostedUnit;

using AwesomeAssertions;

namespace Soenneker.Validators.Email.Mx.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class EmailMxValidatorTests : HostedUnitTest
{
    private readonly IEmailMxValidator _validator;

    public EmailMxValidatorTests(Host host) : base(host)
    {
        _validator = Resolve<IEmailMxValidator>(true);
    }

    [Test]
    public async Task Validate_should_be_true()
    {
        bool result = await _validator.Validate("google.com");
        result.Should().BeTrue();
    }

    [Test]
    public async Task Validate_should_be_false()
    {
        bool result = await _validator.Validate(Faker.Random.AlphaNumeric(50) + ".com");
        result.Should().BeFalse();
    }
}
