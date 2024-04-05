using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public interface IAbonentService
{
   Task<IEnumerable<Abonent>> GetDataAsync();
   Task<bool> AddAbonent(string phoneNumber, string inn, string address);
}