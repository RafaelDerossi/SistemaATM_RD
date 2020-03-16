using SistemaATM.Aplicacao.Aplicacoes;
using System;
using System.Threading;

namespace SistemaATM.Console
{
   public class Program
    {
        
        public static void Main(string[] args)
        {            
            //Liga o ATM
            var appATM = new AppATM();
            appATM.LigarATM();          

        }
    }
}
