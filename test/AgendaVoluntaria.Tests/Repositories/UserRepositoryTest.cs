using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Models.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AgendaVoluntaria.Api.Repositories
{
    public class UserRepositoryTest
    {
        protected UserRepository RepositoryUnderTest { get; }
        protected AgendaVoluntariaContext AgendaVoluntariaDatabaseMock { get; }
        private readonly INotifier notifierMock;
        private static Guid testId = new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c");
        public UserRepositoryTest()
        {
            AgendaVoluntariaDatabaseMock = SqliteAgendaVoluntariaContextFactory.GetAgendaVoluntariaContext();
            notifierMock = new Notifier();
            RepositoryUnderTest = new UserRepository(AgendaVoluntariaDatabaseMock, notifierMock);
        }
        public class GetAllAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_retornar_todos_os_usuario()
            {
                // Arrange

                // Act
                var result = await RepositoryUnderTest.GetAllAsync();

                // Assert
                Assert.Equal(3, result.Count());
            }
        }

        public class GetOneByIdAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_retornar_o_usuario_esperado()
            {
                // Arrange

                // Act
                var result = await RepositoryUnderTest.GetOneByIdAsync(testId);

                // Assert
                Assert.Equal("ghmeyer0@gmail.com", result.Email);
            }

            [Fact]
            public async Task Deve_retornar_vazio()
            {
                // Arrange
                var id = Guid.NewGuid();

                // Act 
                var result = await RepositoryUnderTest.GetOneByIdAsync(id);

                // Assert
                Assert.Null(result);
            }
        }

        public class CreateAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_criar_um_usuario()
            {
                // Arrange
                var newUser = new User
                {
                    Email = "exemplo@exemplo.com",
                    Name = "Exemplo",
                    Password = "aaaaa"
                };
                // Act
                var result = await RepositoryUnderTest.CreateAsync(newUser);

                // Assert
                Assert.Equal(1, result);
            }
        }

        public class UpdateAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_atualizar_o_usuario()
            {
                // Arrange
                var id = Guid.NewGuid();
                var updatedUser = new User
                {
                    Id = id,
                    Email = "email@exemplo.com.br",
                    Name = "Exemplo Teste",
                    Password = "senha_segura"
                };
                await AgendaVoluntariaDatabaseMock.Users.AddAsync(updatedUser);
                await AgendaVoluntariaDatabaseMock.SaveChangesAsync();

                updatedUser.Name = "Nome Alternativo";

                // Act
                var result = await RepositoryUnderTest.UpdateAsync(updatedUser);

                // Assert
                Assert.Equal(1, result);
            }
        }

        public class DeleteAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_remover_o_usuario()
            {
                // Arrange
                var id = Guid.NewGuid();
                var deletedUser = new User
                {
                    Id = id,
                    Email = "email@exemplo.com.br",
                    Name = "Exemplo Teste",
                    Password = "senha_segura"
                };
                await AgendaVoluntariaDatabaseMock.AddAsync(deletedUser);

                // Act
                var result = await RepositoryUnderTest.DeleteAsync(id);

                // Assert
                Assert.Equal(1, result);
            }

        }

    }
}
