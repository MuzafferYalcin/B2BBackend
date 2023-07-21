using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EfUserOperationClaimDal : RepositoryBase<UserOperationClaim, ContextDb>, IUserOperationClaimDal
    {
    }
}
