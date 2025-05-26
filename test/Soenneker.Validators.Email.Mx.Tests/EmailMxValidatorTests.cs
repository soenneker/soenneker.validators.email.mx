using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Validators.Email.Mx.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

using AwesomeAssertions;

namespace Soenneker.Validators.Email.Mx.Tests;

[Collection("Collection")]
public class EmailMxValidatorTests : FixturedUnitTest
{
    private readonly IEmailMxValidator _validator;

    public EmailMxValidatorTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _validator = Resolve<IEmailMxValidator>(true);
    }

    [Fact]
    public async Task Validate_should_be_true()
    {
        bool result = await _validator.Validate("google.com");
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Validate_should_be_false()
    {
        bool result = await _validator.Validate(Faker.Random.AlphaNumeric(50) + ".com");
        result.Should().BeFalse();
    }
}
