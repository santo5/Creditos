using Creditos.API.Data;
using Creditos.API.Data.Entities;
using Creditos.API.Models;
using System.Threading.Tasks;

namespace Creditos.API.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<Credito> ToCreditoAsync(CreditoViewModel model, bool isNew)
        {
            return new Credito
            {

                Nombre = await _context.Clientes.FindAsync(model.NombreId),
                Fecha = model.Fecha,
                Id = isNew ? 0 : model.Id,
                Valor = model.Valor,
                Verificacion = model.Verificacion,
                Description = await _context.Cobros.FindAsync(model.CobroId)

            };
        }

        public CreditoViewModel ToCreditoViewModel(Credito credito)
        {
            return new CreditoViewModel
            {
                NombreId = credito.Nombre.Id,
                Nombres = _combosHelper.GetComboCliente(),
                Fecha = credito.Fecha,
                Id = credito.Id,
                Valor = credito.Valor,
                Verificacion = credito.Verificacion,
                CobroId = credito.Description.Id,
                Cobros = _combosHelper.GetComboCobro()

            };
        }
    }
}
