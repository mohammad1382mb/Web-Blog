using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DTOs.Users;
using DataLayer.Entities;
using CoreLayer.Utilities;

namespace CoreLayer.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDto registerDto);
        UserDto LoginUser(UserLoginDto loginDto);
        
    }
}
