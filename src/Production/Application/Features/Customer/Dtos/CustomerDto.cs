using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customer.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string CustomerEmail { get; set; } = string.Empty;

        public string? CustomerPhone { get; set; }

        public string? CustomerCity { get; set; }

        public string? CustomerAddress { get; set; }
    }
}
