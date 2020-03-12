using SistemaATM.Domain.Entidades;
using SistemaATM.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Servicos.Servicos
{
    public class ServicoSaque : IServicoTransacao
    {
        public int NumeroDaConta { get; set; }

        public IServicoTela ServicoTela { get; set; }        

        public IServicoTeclado ServicoTeclado { get; set; }

        public IServicoDispensadorDeCedulas ServicoDispensadorDeCedulas { get; set; }
        
        public void Executar()
        {
            throw new NotImplementedException();
        }

        public void MostrarMenuDeValores()
        {
            throw new NotImplementedException();
        }
    }
}
