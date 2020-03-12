using SistemaATM.Domain.Entidades;
using SistemaATM.Domain.Interfaces.Servicos;


namespace SistemaATM.Servicos.Servicos
{
    public class ServicoATM : IServicoATM
    {
        public ATM LigarATM()
        {
            var atm = ATM.GetInstance();
            atm.ServicoTela = new ServicoTela();
            atm.ServicoTeclado = new ServicoTeclado();
            atm.ServicoDispensadorDeCedulas = new ServicoDispensadorDeCedulas();
            atm.ServicoEntradaDeDeposito = new ServicoEntradaDeDeposito();
            return atm;
        }
    }
}
