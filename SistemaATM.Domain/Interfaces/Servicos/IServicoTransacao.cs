using SistemaATM.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Domain.Interfaces.Servicos
{    
   public interface IServicoTransacao
    {
        public int NumeroDaConta { get; set; }

        public IServicoTela ServicoTela{ get; set; }        

        public void Executar();
    }
}
