using BookStore.Core.Dto;
using BookStore.Core.Entity;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Interface.Data.Query;
using BookStore.Tests.Service.Fixtures.Address;
using BookStore.Service.Query;
using BookStore.Core.Extensions;
using Moq;

namespace BookStore.Tests.Service.Query;

[Collection(nameof(AddressTestFixtureCollection))]
public class AddressQueryServiceTests
{
    private readonly AddressTestFixture _fixture;
    private readonly IAddressQueryService _addressQueryService;

    private readonly Mock<IAddressQueryRepository> _addressQueryRepositoryMock = new Mock<IAddressQueryRepository>();

    public AddressQueryServiceTests(AddressTestFixture fixture)
    {
        _fixture = fixture;
        _addressQueryService = new AddressQueryService(_addressQueryRepositoryMock.Object);
    }

    [Fact(DisplayName = "Validating Address")]
    [Trait("Address", "Get All")]
    public async Task ValidateEntity_ShouldReturnAddress()
    {
        // Arrange         
        var address = _fixture.GetAddress();
        var addressList = new List<Address> { address };
        var expected = new List<AddressDto> { address.ToDto() };
        _addressQueryRepositoryMock
            .Setup(m => m.GetAllAsync())
            .ReturnsAsync(addressList);

        // Act
        var actual = await _addressQueryService.GetAllAsync();

        // Assert
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Theory(DisplayName = "Validating Address")]
    [Trait("Address", "GetById")]
    [InlineData("7cca8241-b083-4dc5-b8b4-3ba3feb9cc9c")]
    [InlineData("5e94b88a-67e1-4357-8e7f-8363588e2c57")]
    public async Task ValidateEntity_ShouldReturnAddressById(string id)
    {
        // Arrange
       var address = _fixture.GetByIdAddress(id);
        var expected = address.ToDto();
        _addressQueryRepositoryMock
            .Setup(m => m.GetByIdAsync(Guid.Parse(id)))
            .ReturnsAsync(address);

        // Act
        var actual = await _addressQueryService.GetByIdAsync(Guid.Parse(id));

        // Assert
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }
}