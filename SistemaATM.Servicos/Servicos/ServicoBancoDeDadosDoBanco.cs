using SistemaATM.Domain.Entidades;
using SistemaATM.Domain.Interfaces.Servicos;
using System;

namespace SistemaATM.Servicos.Servicos
{
    public class ServicoBancoDeDadosDoBanco : IServicoBancoDeDadosDoBanco
    {        
        public bool AutenticarUsuario(int numeroDaConta, int pinInformado)
        {
            if (numeroDaConta.ToString().Length==5)
            {
                if (pinInformado.ToString().Length == 5)
                {
                    var servConta = new ServicoConta();

                    //Obter a conta
                    var conta = new Conta();

                    conta = servConta.BuscarConta(numeroDaConta);

                    if (conta != null)
                    {
                        if (servConta.ValidarPIN(pinInformado, conta))
                        {
                            //Autentica Usuario
                            return true;
                        }
                        else
                        {
                            //PIN invalido
                            var ex = new Exception("PIN inválido!");
                            throw ex;                            
                        }
                    }
                    else
                    {
                        //Conta Inválida
                        var ex = new Exception("Número de conta inválido!");
                        throw ex;                        
                    }                    
                }
                else
                {
                    var ex = new Exception("PIN inválido! Informe um PIN com 5 digitos.");
                    throw ex;                    
                }                
            }
            else
            {
                var ex = new Exception("Número de conta inválido! Informe um número de conta com 5 digitos.");
                throw ex;                
            }
            
        }

        public decimal ConsultarSaldo(int numeroDaConta)
        {
            var servConta = new ServicoConta();

            //Obter a conta
            var conta = servConta.BuscarConta(numeroDaConta);
            
            if (conta != null)
            {
                return conta.Saldo;
            }
            else
            {
                var ex = new Exception("Conta não encontrata.");
                throw ex;
            }
        }

        public bool ConsultarSaldoDisponivel(int numeroDaConta, decimal valorRequerido)
        {
            var saldo = ConsultarSaldo(numeroDaConta);
            if (saldo>=valorRequerido)
            {
                return true;
            }
            else
            {
                return false;
            }            
            
        }

        public void Sacar(int numeroDaConta, decimal valor)
        {
            var saldo = ConsultarSaldo(numeroDaConta);
            if (saldo>=valor)
            {
                var servConta = new ServicoConta();
                var conta = servConta.BuscarConta(numeroDaConta);
                servConta.Debitar(conta, valor);               
            }
            else
            {
                var ex = new Exception("Saldo insuficiente! Escolha um valor menor.");
                throw ex;
            }            
        }

        public void Depositar(int numeroDaConta, decimal valor)
        {
            var servConta = new ServicoConta();
            var conta = servConta.BuscarConta(numeroDaConta);
            servConta.Creditar(conta, valor);
        }

       
    }
}
