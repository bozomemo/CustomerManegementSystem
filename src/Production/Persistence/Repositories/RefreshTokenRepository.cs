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
    public class RefreshTokenRepository(CMS_DbContext dbContext) : EfRepositoryBase<RefreshToken, CMS_DbContext>(dbContext), IRefreshTokenRepository
    {
    }
}
