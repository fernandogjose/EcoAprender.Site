using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class MedicamentoRealizadoService : BaseService<MedicamentoRealizado>, IMedicamentoRealizadoService
    {
        private readonly IMedicamentoRealizadoRepository _medicamentoRealizadoRepository;

        public MedicamentoRealizadoService(IMedicamentoRealizadoRepository medicamentoRealizadoRepository)
            : base(medicamentoRealizadoRepository)
        {
            _medicamentoRealizadoRepository = medicamentoRealizadoRepository;
        }
    }
}
