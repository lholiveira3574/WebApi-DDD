using System;
using System.Collections.Generic;
using WebApi.Domain.Dtos.User;

namespace WebApi.Service.Test.User
{
    public class UserTests 
    {
        public static Guid UserId { get; set; }
        public static string UserName { get; set; }   
        public static string UserEmail { get; set; }
        public static string UserNameChanged { get; set; }   
        public static string UserEmailChanged { get; set; }   
        public List<UserDto> listUserDto = new List<UserDto>();
        public UserDto userDto;
        public UserDtoCreate userDtoCreate;
        public UserDtoCreateResult userDtoCreateResult;
        public UserDtoUpdate userDtoUpdate;
        public UserDtoUpdateResult userDtoUpdateResult;

        public UserTests()
        {
            UserId = Guid.NewGuid();
            UserName = Faker.Name.FullName();
            UserEmail = Faker.Internet.Email();
            UserNameChanged = Faker.Name.FullName();
            UserEmailChanged = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                listUserDto.Add(dto);
            }

            userDto = new UserDto
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail
            };

            userDtoCreate = new UserDtoCreate
            {
                Name = UserName,
                Email = UserEmail
            };


            userDtoCreateResult = new UserDtoCreateResult
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                CreateAt = DateTime.UtcNow
            };

            userDtoUpdate = new UserDtoUpdate
            {
                Id = UserId,
                Name = UserNameChanged,
                Email = UserEmailChanged
            };

            userDtoUpdateResult = new UserDtoUpdateResult
            {
                Id = UserId,
                Name = UserNameChanged,
                Email = UserEmailChanged,
                UpdateAt = DateTime.UtcNow
            };
            
        }
    }
}