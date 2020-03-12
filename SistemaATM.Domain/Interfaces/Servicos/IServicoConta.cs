using SistemaATM.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Domain.Interfaces.Servicos
{
   public interface IServicoConta
    {       
        public bool ValidarPIN(int pinInformado, Conta conta);
    }
}
