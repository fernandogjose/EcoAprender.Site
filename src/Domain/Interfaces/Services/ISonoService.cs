using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface ISonoService
    {
        IList<Sono> List(Sono sono);

        void Add(Sono sono);

        void Update(Sono sono);

        void Delete(Sono sono);
    }
}
