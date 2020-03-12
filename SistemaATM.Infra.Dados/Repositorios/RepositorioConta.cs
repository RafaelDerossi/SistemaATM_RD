using SistemaATM.Domain.Entidades;
using SistemaATM.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Infra.Dados.Repositorios
{
    public class RepositorioConta : IRepositorioConta
    {
        public Conta BuscarConta(int numeroDaConta)
        {
            var bancoDeDadosDoBanco = BancoDeDadosDoBanco.GetInstance();
            var conta = new Conta();
            conta = bancoDeDadosDoBanco.Contas.Find(c => c.NumeroDaConta == numeroDaConta);
            return conta;
        }

        public void Creditar(Conta conta, decimal valor)
        {
            var bancoDeDadosDoBanco = BancoDeDadosDoBanco.GetInstance();
            bancoDeDadosDoBanco.Contas.Remove(conta);
            conta.Saldo = conta.Saldo + valor;
            bancoDeDadosDoBanco.Contas.Add(conta);
        }

        public void Debitar(Conta conta, decimal valor)
        {
            var bancoDeDadosDoBanco = BancoDeDadosDoBanco.GetInstance();
            bancoDeDadosDoBanco.Contas.Remove(conta);
            conta.Saldo = conta.Saldo - valor;
            bancoDeDadosDoBanco.Contas.Add(conta);
        }
    }
}
