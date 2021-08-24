using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TesteAPI.Data;
using TesteAPI.Models;
using TesteAPI.Repositories.RepositoriesInterfaces;

namespace TesteAPI.Repositories
{
    public class ViloesRepository : IViloesRepository
    {
        private readonly HeroiContext _context;

        public ViloesRepository(HeroiContext context)
        {
            _context = context;

        }

        public  List<Vilao> GetViloes()
        {
            var result = _context.Viloes.ToList();
            return result;
        }


    }
}
