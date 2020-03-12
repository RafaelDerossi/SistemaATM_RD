using SistemaATM.Aplicacao.Interfaces;
using SistemaATM.Servicos.Servicos;

namespace SistemaATM.Aplicacao.Aplicacoes
{
    public class AppBancoDeDadosDoBanco : IAppBancoDeDadosDoBanco
    {       
        public bool AutenticarUsuario(int numeroDaConta, int pinInformado)
        {
            var servBancoDeDadosDoBanco = new ServicoBancoDeDadosDoBanco();
            if (servBancoDeDadosDoBanco.AutenticarUsuario(numeroDaConta, pinInformado))
                return true;
            return false;
        }

        public decimal ConsultarSaldo(int numeroDaConta)
        {
            var servBancoDeDadosDoBanco = new ServicoBancoDeDadosDoBanco();
            return servBancoDeDadosDoBanco.ConsultarSaldo(numeroDaConta);                
        }

        public bool ConsultarSaldoDisponivel(int numeroDaConta, decimal valorRequerido)
        {
            var servBancoDeDadosDoBanco = new ServicoBancoDeDadosDoBanco();
            return servBancoDeDadosDoBanco.ConsultarSaldoDisponivel(numeroDaConta,valorRequerido);
        }

        public void Sacar(int numeroDaConta, decimal valor)
        {
            var servBancoDeDadosDoBanco = new ServicoBancoDeDadosDoBanco();
            try
            {
                servBancoDeDadosDoBanco.Sacar(numeroDaConta, valor);
            }
            catch (System.Exception)
            {
                throw;
            }            
        }

        public void Depositar(int numeroDaConta, decimal valor)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
