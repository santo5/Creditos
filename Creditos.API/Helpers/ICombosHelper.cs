using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Creditos.API.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCliente();

        IEnumerable<SelectListItem> GetComboCobro();
    }
}
