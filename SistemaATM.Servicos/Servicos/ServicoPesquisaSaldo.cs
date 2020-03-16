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

        public IServicoBancoDeDadosDoBanco ServicoBancoDeDadosDoBanco { get; set; }

        public ServicoPesquisaSaldo(int numeroDaConta)
        {
            NumeroDaConta = numeroDaConta;
            ServicoTela = new ServicoTela();                        
            ServicoBancoDeDadosDoBanco = new ServicoBancoDeDadosDoBanco();
        }
        

        public void Executar()
        {
            var saldo = ServicoBancoDeDadosDoBanco.ConsultarSaldo(NumeroDaConta);
            ServicoTela.MostrarMensagemLinha("");
            ServicoTela.MostrarMensagem("Seu saldo é de ");
            ServicoTela.MostrarValorEmReais(saldo.ToString());
            ServicoTela.MostrarMensagemLinhaEspera("");
        }

    }
}
