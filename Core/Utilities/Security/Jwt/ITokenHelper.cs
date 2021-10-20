using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper // bu tokeni oluşturacak yapının interface'i.
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims); 
        //bu user bilgisine göre token üretilir. Biz burada rol bilgisini de alıyoruz unutma!!.
    }
}
