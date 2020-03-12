using SistemaATM.Domain.Entidades;
using SistemaATM.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Servicos.Servicos
{
    public class ServicoPesquisaSaldo : IServicoTransacao
    {
        public int NumeroDaConta { get; set; }

        public IServicoTela ServicoTela { get; set; }       

        public void Executar()
        {
            throw new NotImplementedException();
        }

    }
}
