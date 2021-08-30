using Business.Abstract;
using Business.Utilities.Hashing;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IDirectorService _directorService;

        public AuthManager(IDirectorService directorService, IRoleService roleService)
        {
            _directorService = directorService;
        }

        public bool IsExitsAdmin()
        {
           return  _directorService.IsExitsAdmin();
        }

        public Director Login(LoginDto loginDto)
        {
            var user = _directorService.GetUser(loginDto);

            return user;


            //using (var hmac = new System.Security.Cryptography.HMACSHA512())
            //{
            //    var admin = _directorService.GetList();
            //    foreach (var item in admin)
            //    {
            //        //if (HashingHelper.VerifyPasswordHash(loginDto.AdminPassword, item.AdminPasswordHash, item.AdminPasswordSalt))
            //        //{
            //        //    return true;
            //        //}
            //    }
            //    return false;
            //}
        }

        public async Task Register(string name, string mail, string password, int adminRole)
        {
            //byte[] passwordHash, passwordSalt;
            //HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            //var admin = new Director
            //{
            //    RoleId = adminRole,
            //    Email = mail,
            //    AdminPasswordHash = passwordHash,
            //    AdminPasswordSalt = passwordSalt,
            //    Name = name
            //};
            //_directorService.Add(admin);


            Director newUser = new Director();

            newUser.RoleId = adminRole;
            newUser.Email = mail;
            newUser.Name = name;

            var keyNew = Helper.GeneratePassword(10);
            var hashPassowrd = Helper.EncodePassword(password, keyNew);
            newUser.AdminPasswordHash = hashPassowrd;
            newUser.AdminPasswordSalt = keyNew;

            _directorService.Add(newUser);
        }


    }
}