using Creditos.API.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Creditos.API.Helpers
{
    public class CombosHelper : ICombosHelper
    {

        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboCliente()
        {
            List<SelectListItem> list = _context.Clientes.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un cliente...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboCobro()
        {
            List<SelectListItem> list = _context.Cobros.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un cobro...]",
                Value = "0"
            });

            return list;
        }
    }
}
