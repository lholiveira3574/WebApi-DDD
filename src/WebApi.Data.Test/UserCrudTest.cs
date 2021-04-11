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
    public class UserCrudTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider; 

        public UserCrudTest(DbTest dbTest)
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

        [Fact(DisplayName = "User Exists")]
        public async Task UserExistsTest()
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