using Creditos.API.Data.Entities;
using Creditos.API.Models;
using System.Threading.Tasks;

namespace Creditos.API.Helpers
{
    public interface IConverterHelper
    {
        Task<Credito> ToCreditoAsync(CreditoViewModel model, bool isNew);


        CreditoViewModel ToCreditoViewModel(Credito credito);
    }
}
