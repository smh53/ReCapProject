using Core.Entities.User;
using System.Collections.Generic;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaim> opertaionClaims); // giriş yapınca kullanıcı burası çalışacak
    }
}