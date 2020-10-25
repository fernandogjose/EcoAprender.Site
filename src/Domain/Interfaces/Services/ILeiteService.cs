using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface ILeiteService
    {
        IList<Leite> List(Leite leite);

        void Add(Leite leite);

        void Update(Leite leite);

        void Delete(Leite leite);
    }
}
