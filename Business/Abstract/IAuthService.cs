using Entities.Concrete;
using Entities.Dto;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public  interface IAuthService
    {
        Task Register(string name, string mail, string password, int adminRole);
        Director Login(LoginDto loginDto);
        bool IsExitsAdmin();
    }
} 
