using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : Entity
    {
        /// <summary>
        /// Müşteri adı (Zorunlu)
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Müşteri mail adresi (Zorunlu)
        /// </summary>
        public string CustomerEmail { get; set; } = string.Empty;
        
        /// <summary>
        /// Müşteri telefon numarası
        /// </summary>
        public string? CustomerPhone { get; set; }

        /// <summary>
        /// Müşteri şehir bilgisi
        /// </summary>
        public string? CustomerCity { get; set; }

        /// <summary>
        /// Müşteri adresi
        /// </summary>
        public string? CustomerAddress { get; set; }
    }
}
