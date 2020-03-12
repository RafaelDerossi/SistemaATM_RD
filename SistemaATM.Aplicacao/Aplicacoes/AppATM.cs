using SistemaATM.Aplicacao.Interfaces;
using SistemaATM.Domain.Entidades;
using SistemaATM.Servicos.Servicos;

namespace SistemaATM.Aplicacao.Aplicacoes
{
    public class AppATM : IAppATM
    {
        public ATM LigarATM()
        {
            var servATM = new ServicoATM();           

            return servATM.LigarATM();
        }

    }
}
