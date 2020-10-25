using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface ILeiteRepository
    {
        IList<Leite> List(Leite leite);

        void Add(Leite leite);

        void Update(Leite leite);

        void Delete(Leite leite);
    }
}