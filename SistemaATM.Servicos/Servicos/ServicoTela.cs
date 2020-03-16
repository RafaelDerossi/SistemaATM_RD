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
                
        public void MostrarValorEmReais(string mensagem)
        {
            Console.WriteLine("R$" + mensagem);
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
