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
    public class UserExistsTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider; 

        public UserExistsTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider; 
        }            

        [Fact(DisplayName = "User Exists")]
        public async Task UserExistTest()
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
                var _registroExiste = await _repositorio.ExistsAsync(_registroCriado.Id);

                //Assert.True(_registroExiste);

                _registroExiste.Should().BeTrue(because: "O Usuário foi encontrado");
            }
        }      
    }
}