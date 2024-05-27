using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CustomerRepository(CMS_DbContext dbContext) : EfRepositoryBase<Customer, CMS_DbContext>(dbContext), ICustomerRepository
    {
    }
}
