using SistemaATM.Domain.Interfaces.Servicos;
using System;
using System.Threading;
using System.Timers;

namespace SistemaATM.Servicos.Servicos
{
    public class ServicoDeposito : IServicoTransacao
    {
        public int NumeroDaConta { get; set; }

        public IServicoTela ServicoTela { get; set; }        

        public IServicoTeclado ServicoTeclado { get; set; }

        public IServicoEntradaDeDeposito ServicoEntradaDeDeposito { get; set; }

        public IServicoBancoDeDadosDoBanco ServicoBancoDeDadosDoBanco { get; set; }

        public ServicoDeposito(int numeroDaConta)
        {
            NumeroDaConta = numeroDaConta;
            ServicoTela = new ServicoTela();
            ServicoTeclado = new ServicoTeclado();
            ServicoEntradaDeDeposito = new ServicoEntradaDeDeposito();
            ServicoBancoDeDadosDoBanco = new ServicoBancoDeDadosDoBanco();
        }

        
       

        public void Executar()
        {
            ServicoTela.LimparTela();
            ServicoTela.MostrarMensagemLinha(" ");
            ServicoTela.MostrarMensagem("Informe um valor de depósito ou digite '0' para cancelar: ");
            try
            {
                var valorDeposito = ObtemValorDoDeposito();
                if (valorDeposito != 0)
                {                    
                    if (ServicoEntradaDeDeposito.EnvelopeDeDepositoRecebido(ServicoTela))
                    {
                        try
                        {
                            ServicoBancoDeDadosDoBanco.Depositar(NumeroDaConta, valorDeposito);
                            ServicoTela.MostrarMensagemLinhaEspera("Transação Efetuada!");
                        }
                        catch (Exception)
                        {
                            ServicoTela.MostrarMensagemLinhaEspera("Transação cancelada!");
                        }
                        
                        
                    }
                }
                else
                {
                    ServicoTela.MostrarMensagemLinhaEspera("Transação cancelada!");
                }
            }
            catch (FormatException)
            {
                ServicoTela.MostrarMensagemLinhaEspera("Formato inválido! Informe um valor válido.");
            }

        }

        public decimal ObtemValorDoDeposito()
        {
            string entrada = Console.ReadLine();
            try
            {
                decimal retorno = decimal.Parse(entrada);
                return retorno;
            }
            catch (FormatException)
            {
                throw;
            }
        }
       
    }
}
