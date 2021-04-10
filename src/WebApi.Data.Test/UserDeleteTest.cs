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
    public class UserDeleteTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider; 

        public UserDeleteTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider; 
        }

        [Fact(DisplayName = "Delete User")]
        public async Task DeleteTest()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                var _removeu = await _repositorio.DeleteAsync(_registroCriado.Id);

                //Assert.True(_removeu);
                
                _removeu.Should().BeTrue(because: "O Usuário foi removido corretamente");
            }
        }    
    }
}