using Sales.Shared.Entities;

namespace Sales.API.Data
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
            await CheckProvinciasAsync();
            await CheckCategoriasAsync();
        }

        public async Task CheckProvinciasAsync()
        {
            if(!_context.Provincias.Any())
            {
                _context.Provincias.Add(new Provincia { Nombre = "San José" });
                _context.Provincias.Add(new Provincia { Nombre = "Alajuela" });
                _context.Provincias.Add(new Provincia { Nombre = "Cartago" });
                _context.Provincias.Add(new Provincia { Nombre = "Heredia" });
                _context.Provincias.Add(new Provincia { Nombre = "Guanacaste" });
                _context.Provincias.Add(new Provincia { Nombre = "Puntarenas" });
                _context.Provincias.Add(new Provincia { Nombre = "Limón" });
            }

            await _context.SaveChangesAsync();
        }

        public async Task CheckCategoriasAsync()
        {
            if (!_context.Categorias.Any())
            {
                _context.Categorias.Add(new Categoria { Nombre = "Ropa" });
                _context.Categorias.Add(new Categoria { Nombre = "Comida" });
            }

            await _context.SaveChangesAsync();
        }
    }
}
