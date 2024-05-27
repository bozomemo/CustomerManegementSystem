using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository(CMS_DbContext dbContext) : EfRepositoryBase<UserOperationClaim, CMS_DbContext>(dbContext), IUserOperationClaimRepository
    {
    }
}
