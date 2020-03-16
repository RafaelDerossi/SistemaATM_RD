using SistemaATM.Domain.Entidades;
using SistemaATM.Domain.Interfaces.Servicos;
using System;

namespace SistemaATM.Servicos.Servicos
{
    public class ServicoATM : IServicoATM
    {
        public void LigarATM()
        {
            var atm = ATM.GetInstance();
            atm.ServicoTela = new ServicoTela();
            atm.ServicoTeclado = new ServicoTeclado();
            atm.ServicoDispensadorDeCedulas = new ServicoDispensadorDeCedulas();
            atm.ServicoEntradaDeDeposito = new ServicoEntradaDeDeposito();
            atm.ServicoBancoDeDadosDoBanco = new ServicoBancoDeDadosDoBanco();
            while (atm.UsuarioAutenticado == false)
            {
                AutenticarUsuario();
                SelecionarTransacao();
            }
        }

        private void AutenticarUsuario()
        {
            var atm = ATM.GetInstance();

            atm.ServicoTela.LimparTela();

            //Mostra mensagem de boas vindas
            atm.ServicoTela.MostrarMensagemLinha("Bem Vindo!");

            //
            atm.ServicoTela.MostrarMensagem("Por favor entre com o número da sua conta:");
            try
            {
                atm.numeroConta = atm.ServicoTeclado.ObterEntrada();
                atm.ServicoTela.MostrarMensagem("Informe o seu PIN:");
                try
                {
                    atm.pin = atm.ServicoTeclado.ObterEntrada();
                    //Autenticar Usuario                        
                    try
                    {
                        atm.UsuarioAutenticado = atm.ServicoBancoDeDadosDoBanco.AutenticarUsuario(atm.numeroConta, atm.pin);
                    }
                    catch (Exception ex)
                    {
                        atm.ServicoTela.MostrarMensagemLinhaEspera(ex.Message);
                    }
                }
                catch (FormatException)
                {
                    atm.ServicoTela.MostrarMensagemLinhaEspera("Formato incorreto! Informe apenas números.");
                }
                catch (Exception ex)
                {
                    atm.ServicoTela.MostrarMensagemLinhaEspera(ex.Message);
                }
            }
            catch (FormatException)
            {
                atm.ServicoTela.MostrarMensagemLinhaEspera("Formato incorreto! Informe apenas números.");
            }
        }

        public void MostrarMenu()
        {
            var atm = ATM.GetInstance();
            atm.ServicoTela.LimparTela();
            atm.ServicoTela.MostrarMensagemLinha("Menu Principal");
            atm.ServicoTela.MostrarMensagemLinha("     1 - Pesquisar Saldo");
            atm.ServicoTela.MostrarMensagemLinha("     2 - Sacar");
            atm.ServicoTela.MostrarMensagemLinha("     3 - Depositar");
            atm.ServicoTela.MostrarMensagemLinha("     4 - Sair");
            atm.ServicoTela.MostrarMensagem("Escolha uma opção:");
        }

        private void SelecionarTransacao()
        {
            var atm = ATM.GetInstance();
            while (atm.UsuarioAutenticado == true)
            {
                MostrarMenu();
                try
                {
                    int opc = atm.ServicoTeclado.ObterEntrada();

                    switch (opc)
                    {
                        case 1:

                            Transacao(new ServicoPesquisaSaldo(atm.numeroConta));

                            break;

                        case 2:

                            Transacao(new ServicoSaque(atm.numeroConta));

                            break;
                        case 3:

                            Transacao(new ServicoDeposito(atm.numeroConta));

                            break;
                        case 4:
                            atm.UsuarioAutenticado = false;
                            atm.ServicoTela.LimparTela();
                            break;

                        default:
                            break;
                    }

                }
                catch (FormatException)
                {
                    atm.ServicoTela.MostrarMensagemLinhaEspera("Formato incorreto! Informe apenas números.");
                }

            }
        }

        private void Transacao(IServicoTransacao transacao)
        {
            transacao.Executar();
        }

    }
}
