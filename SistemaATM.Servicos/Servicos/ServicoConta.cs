using SistemaATM.Domain.Entidades;
using SistemaATM.Domain.Interfaces.Repositorios;
using SistemaATM.Domain.Interfaces.Servicos;
using SistemaATM.Infra.Dados.Repositorios;
using System;


namespace SistemaATM.Servicos.Servicos
{
    public class ServicoConta : IServicoConta, IRepositorioConta
    {
        public Conta BuscarConta(int numeroDaConta)
        {
            var repConta = new RepositorioConta();
            return repConta.BuscarConta(numeroDaConta);
        }

        public bool ValidarPIN(int pinInformado, Conta conta)
        {
            if (conta.PIN == pinInformado)
                return true;
            return false;
        }

        public void Debitar(Conta conta, decimal valor)
        {
            var repConta = new RepositorioConta();
            repConta.Debitar(conta, valor);
        }

        public void Creditar(Conta conta, decimal valor)
        {
            var repConta = new RepositorioConta();
            repConta.Creditar(conta, valor);
        }        

    }
}
