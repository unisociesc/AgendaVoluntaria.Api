using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xunit;

namespace AgendaVoluntaria.Api.Services
{
    public class UserServiceTest
    {
        protected UserService ServiceUnderTest { get; }
        protected Mock<IUserRepository> UserRepositoryMock { get; }
        public UserServiceTest()
        {
            UserRepositoryMock = new Mock<IUserRepository>();
            ServiceUnderTest = new UserService(UserRepositoryMock.Object);
        }

        public class GetAllAsync : UserServiceTest
        {
            [Fact]
            public async Task Deve_retornar_todos_os_usuario()
            {
                // Arrange
                var expectedUsers = new ReadOnlyCollection<User>(new List<User>
                {
                    new User { Name = "Gabriel Meyer", Email = "ghmeyer0@gmail.com"},
                    new User { Name = "Renato Rezende", Email = "rrschiavo@gmail.com"}
                });
                UserRepositoryMock
                    .Setup(x => x.GetAllAsync())
                    .ReturnsAsync(expectedUsers);

                // Act
                var result = await ServiceUnderTest.GetAllAsync();

                // Assert
                Assert.Same(expectedUsers, result);
            }
        }
        public class GetOneByIdAsync : UserServiceTest
        {
            [Fact]
            public async Task Deve_retornar_o_usuario_esperado()
            {
                // Arrange
                var userId = Guid.NewGuid();
                var expectedUser = new User { Id = userId, Name = "Gabriel Meyer", Email = "ghmeyer0@gmail.com" };
                UserRepositoryMock
                    .Setup(x => x.GetOneByIdAsync(userId))
                    .ReturnsAsync(expectedUser);

                // Act
                var result = await ServiceUnderTest.GetOneByIdAsync(userId);

                // Assert
                Assert.Same(expectedUser, result);

            }
            [Fact]
            public async Task Deve_retornar_null_se_o_usuario_nao_existir()
            {
                // Arrange
                var userId = Guid.NewGuid();
                UserRepositoryMock
                    .Setup(x => x.GetOneByIdAsync(userId))
                    .ReturnsAsync(default(User));

                // Act
                var result = await ServiceUnderTest.GetOneByIdAsync(userId);

                // Assert
                Assert.Null(result);
            }
        }

        public class CreateAsync : UserServiceTest
        {
            [Fact]
            public async Task Deve_criar_e_retornar_o_usuario_especificado()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => ServiceUnderTest.CreateAsync(null));
            }
        }

        public class UpdateAsync : UserServiceTest
        {
            [Fact]
            public async Task Deve_atualizar_e_retornar_o_usuario_especificado()
            {
                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => ServiceUnderTest.UpdateAsync(null));
            }
        }
        public class DeleteAsync : UserServiceTest
        {
            [Fact]
            public async Task Deve_deletar_e_retornar_o_usuario_especificado()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => ServiceUnderTest.DeleteAsync(Guid.Empty));
            }
        }
    }

}
