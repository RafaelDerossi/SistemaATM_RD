using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Domain.Interfaces.Servicos
{
   public interface IServicoTela
    {
        public void MostrarMensagem(string mensagem);

        public void MostrarMensagemLinha(string mensagem);

        public void MostrarMensagemLinhaEspera(string mensagem);

        public void MostrarValorEmReais(string mensagem);        

        public void LimparTela();

        public void Esperar();        
    }
}
