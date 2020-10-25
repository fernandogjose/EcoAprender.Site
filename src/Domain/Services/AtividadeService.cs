using System;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class AtividadeService : BaseService<Atividade>, IAtividadeService
    {
        private readonly IAtividadeRepository _atividadeRepository;
        public AtividadeService(IAtividadeRepository atividadeRepository)
            : base(atividadeRepository)
        {
            _atividadeRepository = atividadeRepository;
        }

        public override void Add(Atividade model)
        {
            var atividade = _atividadeRepository.GetAll(x => x.Titulo == model.Titulo && x.Resumo == model.Resumo).ToList();
            if (atividade.Any()) return;
            base.Add(model);
        }
        public override void Validate(Atividade model)
        {
            //if (ValidarTituloDuplicado(model.Id, model.Titulo) > 0)
            //{
            //    throw new CommonException(
            //        new Error
            //        {
            //            Mensagem = "O título já foi cadastrado no sistema."
            //        });
            //}
        }

        public int ValidarTituloDuplicado(int id, string titulo)
        {
            return _atividadeRepository.GetAll(x => x.Titulo == titulo && x.Id != id).Count();
        }

        public string ObterLink(Atividade atividade)
        {
            var linkResult = atividade.Link;
            var linkDuplicado = _atividadeRepository.GetAll(x => x.Link == atividade.Link && x.Id != atividade.Id).Any();

            do
            {
                linkResult = string.Format("{0}-{1}", linkResult, DateTime.Now.ToString("dd-MM-yyyy"));
                linkDuplicado = _atividadeRepository.GetAll(x => x.Link == linkResult && x.Id != atividade.Id).Any();
            } while (linkDuplicado);

            return linkResult;
        }

        public void SelecionarFotoCapa(Atividade atividade)
        {
            _atividadeRepository.SelecionarFotoCapa(atividade);
        }

        public void SelecionarFotoResumo(Atividade atividade)
        {
            _atividadeRepository.SelecionarFotoResumo(atividade);
        }

        public void Salvar(Atividade atividade)
        {
            _atividadeRepository.Salvar(atividade);
        }
    }
}
