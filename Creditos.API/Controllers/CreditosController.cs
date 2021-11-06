using Creditos.API.Data;
using Creditos.API.Data.Entities;
using Creditos.API.Helpers;
using Creditos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Creditos.API.Controllers
{
    public class CreditosController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public CreditosController(DataContext context, ICombosHelper combosHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Creditos
                .Include(x => x.Nombre)
                .Include(x => x.Description)
                .ToListAsync());
        }

        public async Task<IActionResult> AddCredito()
        {

            CreditoViewModel model = new CreditoViewModel
            {

                Nombres = _combosHelper.GetComboCliente(),
                Cobros = _combosHelper.GetComboCobro()
            };
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddCredito(CreditoViewModel model)
        {
            if (ModelState.IsValid)
            {
                Credito credito = await _converterHelper.ToCreditoAsync(model, true);
                _context.Add(credito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            model.Nombres = _combosHelper.GetComboCliente();
            model.Cobros = _combosHelper.GetComboCobro();
            return View(model);
        }

        public async Task<IActionResult> EditCredito(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Credito credito = await _context.Creditos
                .Include(x => x.Description)
                .Include(x => x.Nombre)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (credito == null)
            {
                return NotFound();
            }

            CreditoViewModel model = _converterHelper.ToCreditoViewModel(credito);
            return View(model);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditCredito(int id, CreditoViewModel creditoViewModel)
        {
            if (id != creditoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Credito credito = await _converterHelper.ToCreditoAsync(creditoViewModel, false);
                _context.Update(credito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            creditoViewModel.Nombres = _combosHelper.GetComboCliente();
            creditoViewModel.Cobros = _combosHelper.GetComboCobro();
            return View(creditoViewModel);

        }

        public async Task<IActionResult> DeleteCredito(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Credito credito = await _context.Creditos
                .Include(x => x.Description)
                .Include(x => x.Nombre)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (credito == null)
            {
                return NotFound();
            }

            _context.Creditos.Remove(credito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
