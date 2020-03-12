using SistemaATM.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaATM.Servicos.Servicos
{
    public class ServicoEntradaDeDeposito : IServicoEntradaDeDeposito
    {
        public bool EnvelopeDeDepositoRecebido()
        {
            return true;
        }
    }
}
