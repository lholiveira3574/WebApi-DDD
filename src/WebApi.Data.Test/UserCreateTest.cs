using System;
using System.Threading.Tasks;
using WebApi.Data.Context;
using WebApi.Data.Implementations;
using WebApi.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;

namespace WebApi.Data.Test
{
    public class UserCreateTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider; 

        public UserCreateTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider; 
        }

        [Fact(DisplayName = "Create User")]
        public async Task CreateTest()
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
                
                //Assert.NotNull(_registroCriado);
                //Assert.Equal(_entity.Email, _registroCriado.Email);
                //Assert.Equal(_entity.Name, _registroCriado.Name);
                //Assert.False(_registroCriado.Id == Guid.Empty);

                _registroCriado.Should().NotBeNull();
                _registroCriado.Email.Should().Equals(_entity.Email);
                _registroCriado.Name.Should().Equals(_entity.Name);
                _registroCriado.Id.Should().NotBeEmpty();
            }
        }
    }
}