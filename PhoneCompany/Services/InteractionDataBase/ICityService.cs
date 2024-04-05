using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public interface ICityService
{
    Task<IEnumerable<City>> GetDataAsync();
    Task<decimal> GetTariffAsync(Conversation conversation);
}