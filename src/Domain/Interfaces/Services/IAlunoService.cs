using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IAlunoService
    {
        IList<Aluno> List(Aluno aluno);

        void Add(Aluno aluno);

        void Update(Aluno aluno);

        void Delete(Aluno aluno);
    }
}
