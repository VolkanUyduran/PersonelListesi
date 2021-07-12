using Business.Abstract;
using Business.Utilities.Hashing;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IDirectorService _directorService;

        public AuthManager(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        public bool Login(LoginDto loginDto)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var admin = _directorService.GetList();
                foreach (var item in admin)
                {
                    if (HashingHelper.WriterVerifyPasswordHash(loginDto.AdminPassword, item.AdminPasswordHash, item.AdminPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void Register(string name, string mail, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var admin = new Director
            {
                
                Email = mail,
                AdminPasswordHash = passwordHash,
                AdminPasswordSalt = passwordSalt,
                Name=name
            };
            _directorService.Add(admin);
        }


    }
}
