using SistemaATM.Domain.Entidades;
using SistemaATM.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Servicos.Servicos
{
    public class ServicoDispensadorDeCedulas : IServicoDispensadorDeCedulas
    {
        public bool DispensarCedulas(decimal valor)
        {
            int qtdCedulas = (int)valor / 20;

            if (TemCedulasSuficienteDisponiveis(qtdCedulas))
            {
                var dispensadorDeCedulas = DispensadorDeCedulas.GetInstance();
                dispensadorDeCedulas.ContadorDeCedudas = dispensadorDeCedulas.ContadorDeCedudas - qtdCedulas;
                return true;
            }
            return false;
        }

        public bool TemCedulasSuficienteDisponiveis(decimal valor)
        {
            int qtdCedulas = (int)valor / 20;

            var dispensadorDeCedulas = DispensadorDeCedulas.GetInstance();
            if (qtdCedulas <= dispensadorDeCedulas.ContadorDeCedudas)
                return true;
            return false;
        }
    }
}
