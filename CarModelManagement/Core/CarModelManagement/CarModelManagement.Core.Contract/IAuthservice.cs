using CarModelManagement.Core.Domain.AuthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Contract
{
    public interface IAuthservice
    {
        Task<string> Register(RegisterModel model);
        Task<string> Login(LoginModel model);
        Task<string> RegisterAdmin(RegisterModel model);
        Task<string> RegisterSuperAdmin(RegisterModel model);
    }
}
