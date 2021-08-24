﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAPI.Models
{
    public class Heroi
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public IdentidadeSecreta Identidade { get; set; }
   
        public IEnumerable<HeroiBatalha> HeroiBatalhas { get; set; }
    }
}