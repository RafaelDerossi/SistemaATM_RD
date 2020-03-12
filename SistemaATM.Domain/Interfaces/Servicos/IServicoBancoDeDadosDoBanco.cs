
namespace SistemaATM.Domain.Interfaces.Servicos
{
   public interface IServicoBancoDeDadosDoBanco
    {        
        public bool AutenticarUsuario(int numeroDaConta, int pinInformado);

        public decimal ConsultarSaldo(int numeroDaConta);

        public bool ConsultarSaldoDisponivel(int numeroDaConta, decimal valorRequerido);

        public void Sacar(int numeroDaConta, decimal valor);

        public void Depositar(int numeroDaConta, decimal valor);
    }
}
