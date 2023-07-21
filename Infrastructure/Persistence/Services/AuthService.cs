using Application.Abstractions;
using Application.Repositories;
using Application.Results.Abstract;
using Application.Results.Concrete;
using Application.Utilities.Hashing;
using Application.Utilities.Security.JWT;
using Domain.DTOs;
using Domain.Entities;

namespace Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserDal _userDal;
        ITokenHelper _tokenHelper;
        private readonly ICustomerDal _customerDal;

        public AuthService(IUserDal userDal, ITokenHelper tokenHelper, ICustomerDal customerDal)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
            _customerDal = customerDal;
        }


        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims = _userDal.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }


        public IDataResult<User> Login(LoginDto login)
        {
            var usertocheck = _userDal.Get(p => p.Email == login.Email);
            if (usertocheck == null)
            {
                return new ErrorDataResult<User>("kullanıcı yok");
            }
            if (!HashingHelper.VerifyPasswordHash(login.Password, usertocheck.PasswordHash, usertocheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Şifreniz uyuşmuyor");
            }
            return new SuccessDataResult<User>(usertocheck, "giriş başarılı");
        }


        public IDataResult<User> Register(RegisterDto register)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(register.Password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = register.Email,
                Name = register.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _userDal.Add(user);
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<Customer> LoginCustomer(LoginDto loginCustomer)
        {
            var customerCheck = _customerDal.Get(p=>p.Email == loginCustomer.Email);
            if(customerCheck == null)
            {
                return new ErrorDataResult<Customer>("Kullanıcı bulunamadı");
            }
            if(!HashingHelper.VerifyPasswordHash(loginCustomer.Password,customerCheck.PasswordHash, customerCheck.PasswordSalt))
            {
                return new ErrorDataResult<Customer>("Şifreniz Uyuşmuyor");
            }
            return new SuccessDataResult<Customer>(customerCheck,"Giriş Başarılı");
        }

        public IResult Update(UserDto user)
        {
            var changeuser = _userDal.Get(p=> p.Id == user.Id);
            var result = HashingHelper.VerifyPasswordHash(user.Password, changeuser.PasswordHash, changeuser.PasswordSalt);
            if (result)
            {
                if (user.NewPassword != "")
                {
                    byte[] passwordHash, paswordSalt;
                    HashingHelper.CreatePasswordHash(user.NewPassword, out passwordHash, out paswordSalt);
                    changeuser.PasswordHash = passwordHash;
                    changeuser.PasswordSalt = paswordSalt;
                }

                changeuser.Name = user.Name;
                _userDal.Update(changeuser);
                return new SuccessResult("Profiliniz Güncellendi");
            }
            else
            {
                return new ErrorResult("Şifreniz mevcut şifreniz ile tutmuyor");
            }
        }
    }
}
