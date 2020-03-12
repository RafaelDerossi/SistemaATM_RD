using SistemaATM.Domain.Interfaces.Servicos;
using System;


namespace SistemaATM.Servicos.Servicos
{
    public class ServicoTela : IServicoTela
    {
        public void MostrarMensagem(string mensagem)
        {
            Console.Write(mensagem);            
        }

        public void MostrarMensagemLinha(string mensagem)
        {
            Console.WriteLine(mensagem);            
        }

        public void MostrarMensagemLinhaEspera(string mensagem)
        {
            Console.WriteLine(mensagem);
            Esperar();
        }

        public void MostrarMenu()
        {
            LimparTela();
            MostrarMensagemLinha("Menu Principal");
            MostrarMensagemLinha("     1 - Consultar Saldo");
            MostrarMensagemLinha("     2 - Sacar");
            MostrarMensagemLinha("     3 - Depositar");
            MostrarMensagemLinha("     4 - Sair");
            MostrarMensagem("Escolha uma opção:");
        }
                
        public void MostrarValorEmReais(string mensagem)
        {
            Console.WriteLine("R$" + mensagem);
        }

        public void MostrarMenuDeValores()
        {
            LimparTela();
            MostrarMensagemLinha(" ");
            MostrarMensagemLinha("Menu de Valores para Saque");
            MostrarMensagemLinha("     1 - R$20     4 - R$100");
            MostrarMensagemLinha("     2 - R$40     5 - R$200");
            MostrarMensagemLinha("     3 - R$60     6 - Cancelar Transação");            
            MostrarMensagem("Escolha um valor para sacar:");
        }
        
        public void LimparTela()
        {
            Console.Clear();
        }

        public void Esperar()
        {
            Console.ReadLine();
        }

    }
}
