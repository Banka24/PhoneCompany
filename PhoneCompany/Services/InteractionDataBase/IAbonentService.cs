using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public interface IAbonentService
{
   Task<IEnumerable<Abonent>> GetDataAsync();
   Task<bool> AddAbonentAsync(string phoneNumber, string inn, string address);
   Task<bool> EditAbonentAsync(string phoneNumber);
   Task<bool> DeleteAbonentAsync(string phoneNumber);
}