using Domain.Entities;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Domain.Interfaces.Application
{
    public interface IComunicadoAppService : IBaseAppService<Comunicado>
    {
        IList<ComunicadoRelatorioViewModel> Relatorio(Comunicado request);
    }
}
