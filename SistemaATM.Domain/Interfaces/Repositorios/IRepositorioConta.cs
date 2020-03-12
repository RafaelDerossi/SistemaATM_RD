using SistemaATM.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Domain.Interfaces.Repositorios
{
   public interface IRepositorioConta
    {
        public Conta BuscarConta(int numeroDaConta);        

        public void Creditar(Conta conta, decimal valor);

        public void Debitar(Conta conta, decimal valor);        
        
    }
}
