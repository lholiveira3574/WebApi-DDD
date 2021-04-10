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
    public class UserUpdateTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider; 

        public UserUpdateTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider; 
        }

        [Fact(DisplayName = "Update User")]
        public async Task UpdateTest()
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
                _entity.Name = Faker.Name.First();
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);

                //Assert.NotNull(_registroAtualizado);
                //Assert.Equal(_entity.Name, _registroAtualizado.Name);
                //Assert.Equal(_entity.Email, _registroAtualizado.Email);

                _registroAtualizado.Should().NotBeNull();
                _registroAtualizado.Name.Should().Equals(_registroCriado.Name);
                _registroAtualizado.Email.Should().Equals(_registroCriado.Email);
            }
        }    
    }
}