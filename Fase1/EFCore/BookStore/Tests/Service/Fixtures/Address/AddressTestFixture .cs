using AddressEntity = BookStore.Core.Entity.Address;

namespace BookStore.Tests.Service.Fixtures.Address;

public class AddressTestFixture
{
    private readonly Faker _faker = new Faker();

    public AddressEntity GetAddress()
    {
        return new AddressEntity
        {
            Street = _faker.Random.String2(10),
            City = _faker.Random.String2(8),
            State = _faker.Random.String2(6),
            ZipCode = _faker.Random.String2(4),
            Country = _faker.Random.String2(10)
        };
    }

    public AddressEntity GetByIdAddress(string id)
    {
        return new AddressEntity
        {
            Street = _faker.Random.String2(10),
            City = _faker.Random.String2(8),
            State = _faker.Random.String2(6),
            ZipCode = _faker.Random.String2(4),
            Country = _faker.Random.String2(10)
        };
    }
}