using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EfUserDal : RepositoryBase<User, ContextDb>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using(var context = new ContextDb())
            {
                var Claims = from operationclaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationclaim.Id equals userOperationClaim.OperationClaimId
                             where (userOperationClaim.UserId == user.Id)
                             select new OperationClaim
                             {
                                 Id = operationclaim.Id,
                                 Name = operationclaim.Name,
                             };
                return Claims.ToList();
            }
        }
    }
}
