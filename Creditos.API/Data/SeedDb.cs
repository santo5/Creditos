using Creditos.API.Data;
using Creditos.API.Data.Entities;
using Creditos.API.Helpers;
using Creditos.Common.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCobrosAsync();
            await CheckClientesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Oriana", "Ibrian", "orianaibrian29@gmail.com", "901152829", "Calle sin numero", UserType.Admin);
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = address,
                    Document = document,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
            }
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
