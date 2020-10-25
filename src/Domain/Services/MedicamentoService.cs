using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Domain.Services
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IMedicamentoRepository _medicamentoRepository;

        public MedicamentoService(IMedicamentoRepository medicamentoRepository)
        {
            _medicamentoRepository = medicamentoRepository;
        }

        public IList<Medicamento> List(Medicamento medicamento)
        {
            var medicamentos = _medicamentoRepository.List(medicamento);
            return medicamentos;
        }

        public void Add(Medicamento medicamento)
        {
            _medicamentoRepository.Add(medicamento);
        }

        public void Update(Medicamento medicamento)
        {
            _medicamentoRepository.Update(medicamento);
        }

        public void Delete(Medicamento medicamento)
        {
            _medicamentoRepository.Delete(medicamento);
        }
    }
}
