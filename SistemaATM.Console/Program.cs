using SistemaATM.Aplicacao.Aplicacoes;
using System;

namespace SistemaATM.Console
{
   public class Program
    {
        static void Main(string[] args)
        {
            int numeroConta=0;
            int pin=0;
            var appBancoDeDadosDoBanco = new AppBancoDeDadosDoBanco();

            //Liga o ATM
            var appATM = new AppATM();
            var atm = appATM.LigarATM();
            

            while (atm.UsuarioAutenticado==false)
            {                
                //Mostra mensagem de boas vindas
                atm.ServicoTela.MostrarMensagemLinha("Bem Vindo!");
                
                //
                atm.ServicoTela.MostrarMensagem("Por favor entre com o número da sua conta:");
                try
                {
                    numeroConta = atm.ServicoTeclado.ObterEntrada();
                    atm.ServicoTela.MostrarMensagem("Informe o seu PIN:");
                    try
                    {
                        pin = atm.ServicoTeclado.ObterEntrada();
                        //Autenticar Usuario                        
                        try
                        {                            
                            atm.UsuarioAutenticado = appBancoDeDadosDoBanco.AutenticarUsuario(numeroConta, pin);                            
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


                while (atm.UsuarioAutenticado == true)
                {
                    atm.ServicoTela.MostrarMenu();
                    try
                    {
                        int opc = atm.ServicoTeclado.ObterEntrada();

                        switch (opc)
                        {
                            case 1:
                                var saldo = appBancoDeDadosDoBanco.ConsultarSaldo(numeroConta);
                                atm.ServicoTela.MostrarMensagemLinha("");
                                atm.ServicoTela.MostrarMensagem("Seu saldo é de ");
                                atm.ServicoTela.MostrarValorEmReais(saldo.ToString());
                                atm.ServicoTela.MostrarMensagemLinhaEspera("");
                                break;

                            case 2:
                                int opcSaque = 0;
                                while (opcSaque != 6)
                                {
                                    atm.ServicoTela.MostrarMensagemLinha("");
                                    //Mostrar opcoes
                                    atm.ServicoTela.MostrarMenuDeValores();
                                    //Pedir opcao
                                    try
                                    {
                                        opcSaque = atm.ServicoTeclado.ObterEntrada();
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
                                            if (appBancoDeDadosDoBanco.ConsultarSaldoDisponivel(numeroConta, valorSaque))
                                            {
                                                //Verifica se o dispensador tem celulas suficientes
                                                if (atm.ServicoDispensadorDeCedulas.TemCedulasSuficienteDisponiveis(valorSaque))
                                                {
                                                    try
                                                    {
                                                        //Efetuar Saque
                                                        appBancoDeDadosDoBanco.Sacar(numeroConta, valorSaque);
                                                        //Dispensar Cedulas
                                                        atm.ServicoDispensadorDeCedulas.DispensarCedulas(valorSaque);
                                                        //Avisar que saque foi realizado
                                                        atm.ServicoTela.MostrarMensagemLinhaEspera("Saque realizado com sucesso! Retire o dinheiro!");
                                                        //Sair
                                                        opcSaque = 6;
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        atm.ServicoTela.MostrarMensagemLinhaEspera(ex.Message);
                                                    }
                                                }
                                                else
                                                {
                                                    atm.ServicoTela.MostrarMensagemLinhaEspera("Não há cedulas suficientes para realizar este saque! Escolha um valor menor.");
                                                }                                                
                                            }
                                            else
                                            {
                                                atm.ServicoTela.MostrarMensagemLinhaEspera("Saldo insuficiente! Escolha um valor menor.");
                                            }                                            
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        atm.ServicoTela.MostrarMensagemLinhaEspera(ex.Message);
                                    }
                                }                                
                                break;
                            case 3:

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
                       
            
            
        }
    }
}
