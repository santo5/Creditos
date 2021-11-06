using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Creditos.API.Models
{
    public class CreditoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Fecha del credito")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Fecha { get; set; }

        [Display(Name = "Cobro")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un cobro.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CobroId { get; set; }

        public IEnumerable<SelectListItem> Cobros { get; set; }

        [Display(Name = "Nombre del cliente")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un cliente.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int NombreId { get; set; }

        public IEnumerable<SelectListItem> Nombres { get; set; }

        [Display(Name = "Valor del credito")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Valor { get; set; }

        [Display(Name = "Verificacion")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Verificacion { get; set; }
    }
}
