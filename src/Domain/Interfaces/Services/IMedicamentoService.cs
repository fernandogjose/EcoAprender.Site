using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IMedicamentoService
    {
        IList<Medicamento> List(Medicamento medicamento);

        void Add(Medicamento medicamento);

        void Update(Medicamento medicamento);

        void Delete(Medicamento medicamento);
    }
}
