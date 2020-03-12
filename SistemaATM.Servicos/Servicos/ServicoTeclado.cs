using SistemaATM.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Servicos.Servicos
{
    public class ServicoTeclado : IServicoTeclado
    {
        public int ObterEntrada()
        {
            string entrada = Console.ReadLine();            
            try
            {
              int retorno  = int.Parse(entrada);
                return retorno;
            }
            catch (FormatException)
            {
                throw;
            }            

        }
                
    }
}
