using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Messages
{
    public static partial class ExceptionMessages
    {
        public static string EntityDoesNotExist(string entityName) => $"{entityName} bulunamadı! Lütfen kontrol edin";

        public const string WRONG_PASSWORD = "Hatalı Parola";

        public static string EntityExistsWithTheSame(string propName, string entity) => $"Bu {propName} ile bir {entity} zaten var!";
    }
}
