using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Domain.Entidades
{
   public class BancoDeDadosDoBanco
    {
        private static BancoDeDadosDoBanco bancoDeDadosDoBanco = null;
        public static BancoDeDadosDoBanco GetInstance()
        {
            if (bancoDeDadosDoBanco == null)
            {
                bancoDeDadosDoBanco = new BancoDeDadosDoBanco();
            }
            return bancoDeDadosDoBanco;
        }

        private BancoDeDadosDoBanco()
        {
            var conta = new Conta()
            {
                NumeroDaConta = 12345,
                PIN = 54321,
                Saldo = 150
            };
            var conta2 = new Conta()
            {
                NumeroDaConta = 54321,
                PIN = 12345,
                Saldo = 1500
            };

            Contas = new List<Conta>();
            Contas.Add(conta);
            Contas.Add(conta2);

        }

        public List<Conta> Contas { get; set; }

        
    }
}
