using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Domain.Services
{
    public class SonoService : ISonoService
    {
        private readonly ISonoRepository _sonoRepository;

        public SonoService(ISonoRepository sonoRepository)
        {
            _sonoRepository = sonoRepository;
        }

        public IList<Sono> List(Sono sono)
        {
            var sonos = _sonoRepository.List(sono);
            return sonos;
        }

        public void Add(Sono sono)
        {
            _sonoRepository.Add(sono);
        }

        public void Update(Sono sono)
        {
            _sonoRepository.Update(sono);
        }

        public void Delete(Sono sono)
        {
            _sonoRepository.Delete(sono);
        }
    }
}
