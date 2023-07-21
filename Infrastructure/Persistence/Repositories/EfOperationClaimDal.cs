using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EfOperationClaimDal : RepositoryBase<OperationClaim, ContextDb>, IOperationClaimDal
    {
    }
}
