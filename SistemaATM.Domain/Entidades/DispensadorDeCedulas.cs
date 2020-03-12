using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Domain.Entidades
{
   public class DispensadorDeCedulas
    {
        private static DispensadorDeCedulas dispensadorDeCedulas = null;
        public static DispensadorDeCedulas GetInstance()
        {
            if (dispensadorDeCedulas == null)
            {
                dispensadorDeCedulas = new DispensadorDeCedulas();
            }
            return dispensadorDeCedulas;
        }

        public const int CONTADOR_INICIAL = 50;

        public int ContadorDeCedudas { get; set; }

        private DispensadorDeCedulas()
        {
            ContadorDeCedudas = CONTADOR_INICIAL;
        }        
    }
}
