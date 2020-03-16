using SistemaATM.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace SistemaATM.Servicos.Servicos
{
    public class ServicoEntradaDeDeposito : IServicoEntradaDeDeposito
    {
        private static bool retorno = true;       

        private static System.Timers.Timer aTimer = new System.Timers.Timer();
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {            
            aTimer.Stop();
            aTimer.Enabled = false;
            retorno = false;
        }       

        public bool EnvelopeDeDepositoRecebido(IServicoTela servicoTela)
        {
            retorno = true;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 10000;
            aTimer.Enabled = true;
            aTimer.Start();
            servicoTela.MostrarMensagemLinhaEspera("Insira o envelope de depósito com o montante informado....");
            aTimer.Stop();
            aTimer.Enabled = false;
            if (retorno == false)
                servicoTela.MostrarMensagemLinhaEspera("Envelope não inserido! Operação será cancelada!");

            return retorno;
        }
    }
}
