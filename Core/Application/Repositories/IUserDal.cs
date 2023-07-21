using Domain.Entities;

namespace Application.Repositories
{
    public interface IUserDal : IRepository<User>
    {
        public List<OperationClaim> GetClaims(User user);
    }
}
