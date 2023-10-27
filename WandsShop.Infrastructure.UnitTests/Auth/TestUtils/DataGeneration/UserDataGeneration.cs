using WandsShop.Infrastructure.UnitTests.Auth.TestUtils.DataDTO;
using Xunit;

namespace WandsShop.Infrastructure.UnitTests.Auth.TestUtils.DataGeneration
{
    public class UserDataGeneration : TheoryData<UserTestDataDTO>
    {
        public UserDataGeneration()
        {
            for(int i = 0; i < 3; i++)
            {
                Add(new UserTestDataDTO(
                    Guid.NewGuid().ToString(),
                    $"{i}TestName",
                    $"{i}TestEmail@email.test"
                    )
                );
            }
        }
    }
}
