using SistemaATM.Domain.Interfaces.Servicos;
using System;

namespace SistemaATM.Servicos.Servicos
{
    public class ServicoDeposito : IServicoTransacao
    {
        public int NumeroDaConta { get; set; }

        public IServicoTela ServicoTela { get; set; }        

        public IServicoTeclado ServicoTeclado { get; set; }


        public IServicoEntradaDeDeposito ServicoEntradaDeDeposito { get; set; }
        public void Executar()
        {
            throw new NotImplementedException();
        }


        public void InformaValorDoDeposito()
        {
            throw new NotImplementedException();
        }
    }
}
