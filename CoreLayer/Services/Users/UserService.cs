using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DTOs.Users;
using CoreLayer.Services.Users;
using DataLayer;
using DataLayer.Context;
using CoreLayer.Utilities;
using DataLayer.Entities;

namespace CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;
        public UserService(BlogContext context)
        {
            _context = context;
        }

        

        public OperationResult RegisterUser(UserRegisterDto registerDto)
        {
            var isFullNameExist = _context.User.Any(u => u.UserName == registerDto.UserName);
            if (isFullNameExist)
            {
                return OperationResult.Error("نام کاربری تکراری است");
            }
            var passwordHash = registerDto.Password.EncodeToMd5();
            _context.User.Add(new User()
            { 
                FullName = registerDto.FullName,
                UserName = registerDto.UserName,
                IsDelete = false,
                CreationDate = DateTime.Now,
                Role = UserRole.User,
                Password = passwordHash
            });
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public UserDto LoginUser(UserLoginDto loginDto)
        {
            var PasswordHash = loginDto.Password.EncodeToMd5();
            var user = _context.User.FirstOrDefault(u => u.UserName == loginDto.UserName && u.Password == PasswordHash);

            if (user == null)
            {
                return null;
            }
            var userDto = new UserDto()
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Password = user.Password,
                Role = user.Role,
                RegisterDate = user.CreationDate,
                UserId = user.Id
                
            };
            return userDto;
           
        }
    }
}
