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
    public class UserGetTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider; 

        public UserGetTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider; 
        }
        
        [Fact(DisplayName = "Get User")]
        public async Task GetTest()
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
                var _registroSelecionado = await _repositorio.SelectAsync(_registroCriado.Id);

                //Assert.NotNull(_registroSelecionado);
                //Assert.Equal(_registroCriado.Name, _registroSelecionado.Name);
                //Assert.Equal(_registroCriado.Email, _registroSelecionado.Email);

                _registroSelecionado.Should().NotBeNull();
                _registroSelecionado.Name.Should().Equals(_registroCriado.Name);
                _registroSelecionado.Email.Should().Equals(_registroCriado.Email);
            }
        }    
    }
}