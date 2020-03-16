using SistemaATM.Domain.Interfaces.Servicos;

namespace SistemaATM.Domain.Entidades
{
   public class ATM
    {
        private static ATM atm = null;
        public static ATM GetInstance()
        {
            if (atm == null)
            {
                atm = new ATM();
            }
            return atm;
        }               

        private ATM()
        {
            UsuarioAutenticado = false;           
        }

        public int numeroConta { get; set; }

        public int pin { get; set; }

        public bool UsuarioAutenticado { get; set; }

        public IServicoTela ServicoTela { get; set; }

        public IServicoTeclado ServicoTeclado { get; set; }

        public IServicoDispensadorDeCedulas ServicoDispensadorDeCedulas { get; set; }

        public IServicoEntradaDeDeposito ServicoEntradaDeDeposito { get; set; }

        public IServicoBancoDeDadosDoBanco ServicoBancoDeDadosDoBanco { get; set; }

    }
}
