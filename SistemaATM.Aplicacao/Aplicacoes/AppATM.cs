using SistemaATM.Aplicacao.Interfaces;
using SistemaATM.Domain.Entidades;
using SistemaATM.Domain.Interfaces.Servicos;
using SistemaATM.Servicos.Servicos;
using System;

namespace SistemaATM.Aplicacao.Aplicacoes
{
    public class AppATM : IAppATM
    {
        public void LigarATM()
        {
            var servATM = new ServicoATM();
            servATM.LigarATM();           
        }     
    }
}
