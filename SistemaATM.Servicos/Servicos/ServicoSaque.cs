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

        public IServicoBancoDeDadosDoBanco ServicoBancoDeDadosDoBanco { get; set; }


        public ServicoSaque(int numeroDaConta)
        {
            NumeroDaConta = numeroDaConta;
            ServicoTela = new ServicoTela();
            ServicoTeclado = new ServicoTeclado();
            ServicoDispensadorDeCedulas = new ServicoDispensadorDeCedulas();
            ServicoBancoDeDadosDoBanco = new ServicoBancoDeDadosDoBanco();
        }

        public void Executar()
        {
            int opcSaque = 0;
            while (opcSaque != 6)
            {
                ServicoTela.MostrarMensagemLinha("");
                //Mostrar opcoes
                MostrarMenuDeValores();
                //Pedir opcao
                try
                {
                    opcSaque = ServicoTeclado.ObterEntrada();
                    decimal valorSaque = 0;
                    switch (opcSaque)
                    {
                        case 1:
                            valorSaque = 20;
                            break;
                        case 2:
                            valorSaque = 40;
                            break;
                        case 3:
                            valorSaque = 60;
                            break;
                        case 4:
                            valorSaque = 100;
                            break;
                        case 5:
                            valorSaque = 200;
                            break;
                        case 6:
                            valorSaque = 0;
                            break;
                        default:
                            valorSaque = 0;
                            break;
                    }

                    if (valorSaque > 0)
                    {
                        //Consulta Saldo Diponivel
                        if (ServicoBancoDeDadosDoBanco.ConsultarSaldoDisponivel(NumeroDaConta, valorSaque))
                        {
                            //Verifica se o dispensador tem celulas suficientes
                            if (ServicoDispensadorDeCedulas.TemCedulasSuficienteDisponiveis(valorSaque))
                            {
                                try
                                {
                                    //Efetuar Saque
                                    ServicoBancoDeDadosDoBanco.Sacar(NumeroDaConta, valorSaque);
                                    //Dispensar Cedulas
                                    ServicoDispensadorDeCedulas.DispensarCedulas(valorSaque);
                                    //Avisar que saque foi realizado
                                    ServicoTela.MostrarMensagemLinhaEspera("Saque realizado com sucesso! Retire o dinheiro!");
                                    //Sair
                                    opcSaque = 6;
                                }
                                catch (Exception ex)
                                {
                                    ServicoTela.MostrarMensagemLinhaEspera(ex.Message);
                                }
                            }
                            else
                            {
                               ServicoTela.MostrarMensagemLinhaEspera("Não há cedulas suficientes para realizar este saque! Escolha um valor menor.");
                            }
                        }
                        else
                        {
                            ServicoTela.MostrarMensagemLinhaEspera("Saldo insuficiente! Escolha um valor menor.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ServicoTela.MostrarMensagemLinhaEspera(ex.Message);
                }
            }
        }

        public void MostrarMenuDeValores()
        {
            ServicoTela.LimparTela();
            ServicoTela.MostrarMensagemLinha(" ");
            ServicoTela.MostrarMensagemLinha("Menu de Valores para Saque");
            ServicoTela.MostrarMensagemLinha("     1 - R$20     4 - R$100");
            ServicoTela.MostrarMensagemLinha("     2 - R$40     5 - R$200");
            ServicoTela.MostrarMensagemLinha("     3 - R$60     6 - Cancelar Transação");
            ServicoTela.MostrarMensagem("Escolha um valor para sacar:");           
        }
    }
}
