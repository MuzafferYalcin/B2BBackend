using Application.Results.Abstract;
using Application.Utilities.Security.JWT;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface IAuthService
    {
        public IDataResult<AccessToken> CreateAccessToken(User user);
        public IDataResult<User> Register(RegisterDto register);
        public IDataResult<User> Login(LoginDto login);
        public IDataResult<Customer> LoginCustomer(LoginDto loginCustomer);
    }
}
