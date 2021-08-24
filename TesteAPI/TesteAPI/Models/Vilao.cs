using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAPI.Models
{
    public class Vilao
    {

        public int Id { get; set; }
        public String Nome { get; set; }
        public List<Arma> Armas { get; set; }

    }
}
