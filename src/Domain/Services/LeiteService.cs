using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Domain.Services
{
    public class LeiteService : ILeiteService
    {
        private readonly ILeiteRepository _leiteRepository;

        public LeiteService(ILeiteRepository leiteRepository)
        {
            _leiteRepository = leiteRepository;
        }

        public IList<Leite> List(Leite leite)
        {
            var leites = _leiteRepository.List(leite);
            return leites;
        }

        public void Add(Leite leite)
        {
            _leiteRepository.Add(leite);
        }

        public void Update(Leite leite)
        {
            _leiteRepository.Update(leite);
        }

        public void Delete(Leite leite)
        {
            _leiteRepository.Delete(leite);
        }
    }
}
