
using Core.Utilities.Results;
using Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Dtos;
using Core.Utilities.Security.JWT;

namespace Business.Abstract
{
   public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
