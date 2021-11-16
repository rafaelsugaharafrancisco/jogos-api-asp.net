﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.ViewModels
{
    public class JogoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Produtora { get; set; }

        public double Preco { get; set; }
    }
}
