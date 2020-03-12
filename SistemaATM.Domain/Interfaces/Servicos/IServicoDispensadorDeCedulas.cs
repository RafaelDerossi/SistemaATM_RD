using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Domain.Interfaces.Servicos
{
   public interface IServicoDispensadorDeCedulas
    {
        public bool DispensarCedulas(decimal valor);

        public bool TemCedulasSuficienteDisponiveis(decimal valor);
    }
}
