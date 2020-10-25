using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;
using System.Text.RegularExpressions;
using System;
using System.Text;
using System.Globalization;

namespace Application.Services
{
    public class AtividadeAppService : BaseAppService<Atividade>, IAtividadeAppService
    {
        private readonly IAtividadeService _atividadeService;

        public AtividadeAppService(IAtividadeService atividadeService)
            : base(atividadeService)
        {
            _atividadeService = atividadeService;
        }

        public void SelecionarFotoCapa(Atividade atividade)
        {
            _atividadeService.SelecionarFotoCapa(atividade);
        }

        public void SelecionarFotoResumo(Atividade atividade)
        {
            _atividadeService.SelecionarFotoResumo(atividade);
        }

        public int SalvarPorApp(Atividade atividade)
        {
            atividade = ParseParaSalvarPorApp(atividade);
            _atividadeService.Salvar(atividade);
            return atividade.Id;
        }

        private Atividade ParseParaSalvarPorApp(Atividade atividade)
        {
            var tamnhoParaCortar = atividade.CompletaApp.Length > 100 ? 100 : atividade.CompletaApp.Length;

            var atividadeAux = new Atividade
            {
                Id = atividade.Id,
                Data = atividade.Data,
                DataInclusao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                EscolaId = atividade.EscolaId,
                MetaTitle = atividade.Titulo.Replace("-", "").Trim(),
                UsuarioNome = "app",
                Titulo = atividade.Titulo,
                CompletaApp = atividade.CompletaApp,
                Completa = atividade.CompletaApp,
                Grupo = atividade.Grupo,
                Resumo = atividade.CompletaApp.Substring(0, tamnhoParaCortar),
                MetaDescription = atividade.CompletaApp.Substring(0, tamnhoParaCortar),
                Link = RemoverAcentos(atividade.Titulo),
                GrupoId = atividade.GrupoId,
                FotoCapa = "",
                FotoResumo = ""
            };

            atividadeAux.Link = _atividadeService.ObterLink(atividadeAux);

            return atividadeAux;
        }

        private string RemoverAcentos(string valor)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = valor.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }

            var resultado = sbReturn.ToString().Replace(" ", "-");
            return resultado;
        }
    }
}
