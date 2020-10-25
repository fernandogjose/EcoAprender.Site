using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface ISonoRepository
    {
        IList<Sono> List(Sono sono);

        void Add(Sono sono);

        void Update(Sono sono);

        void Delete(Sono sono);
    }
}