using SistemaATM.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Domain.Entidades
{
   public class Conta
    {
        public int NumeroDaConta { get; set; }

        public int PIN { get; set; }

        public decimal Saldo { get; set; }
        
    }
}
