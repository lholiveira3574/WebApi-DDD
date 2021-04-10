using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Context;
using WebApi.Data.Implementations;
using WebApi.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;

namespace WebApi.Data.Test
{
    public class UserGetAllTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider; 

        public UserGetAllTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider; 
        }

        [Fact(DisplayName = "GetAll User")]
        public async Task GetAllTest()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);

                UserEntity _entity1 = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                UserEntity _entity2 = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                UserEntity _entity3 = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                await _repositorio.InsertAsync(_entity1);
                await _repositorio.InsertAsync(_entity2);
                await _repositorio.InsertAsync(_entity3);

                var _todosRegistros = await _repositorio.SelectAsync();

                //Assert.NotNull(_todosRegistros);
                //Assert.True(_todosRegistros.Count() == 3);

                _todosRegistros.Should().NotBeNull();
                _todosRegistros.Should().HaveCount(3, because: "Existem 3 usuários cadastrados");

            }
        }    
    }
}