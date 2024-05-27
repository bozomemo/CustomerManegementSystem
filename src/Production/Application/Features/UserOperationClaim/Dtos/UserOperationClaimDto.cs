using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaim.Dtos
{
    public class UserOperationClaimDto
    {
        public int UserId { get; set; }

        public string? UserEmail { get; set; }

        public int OperationClaimId { get; set; }

        public string? OperationClaimName { get; set; }
    }
}