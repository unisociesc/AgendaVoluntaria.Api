using AgendaVoluntaria.Api.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace AgendaVoluntaria.IntegrationTests
{
    public class UsersControllerTest : BaseHttpTest
    {

        public class GetAllAsync : UsersControllerTest
        {
            [Fact]

            public async Task Deve_retornar_os_usuarios()
            {
                var result = await Client.GetAsync("api/Users");
                result.EnsureSuccessStatusCode();
                Assert.NotNull(result);

                var users = JsonConvert.DeserializeObject<User[]>(await result.Content.ReadAsStringAsync());
                Assert.NotEmpty(users);
                Assert.Equal(3, users.Length);
            }
        }
    }
}
