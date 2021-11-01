using Creditos.API.Data;
using Creditos.API.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCobrosAsync();
            await CheckClientesAsync();
        }

        

        private async Task CheckClientesAsync()
        {
            if (!_context.Clientes.Any())
            {
                _context.Clientes.Add(new Cliente { Documento = "1038806918", Nombre = "Felipe Santiago Velasquez Florez", Direccion = "Cra 78a", Telefono = "930504146" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCobrosAsync()
        {
            if (!_context.Cobros.Any())
            {
                _context.Cobros.Add(new Cobro { Description = "Santiago5 - Andres" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
