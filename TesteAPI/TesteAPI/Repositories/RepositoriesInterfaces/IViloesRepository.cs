using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAPI.Models;

namespace TesteAPI.Repositories.RepositoriesInterfaces
{
    public interface IViloesRepository
    {
        List<Vilao> GetViloes();
    }
}
