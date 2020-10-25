using Data.Repositories;
using Domain.Interfaces.Repositories;
using Ninject;

namespace IoC.Containers
{
    public static class RepositoryContainer
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<IAtividadeRepository>().To<AtividadeRepository>();
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
            kernel.Bind<IComunicadoRepository>().To<ComunicadoRepository>();
            kernel.Bind<IVideoRepository>().To<VideoRepository>();
            kernel.Bind<ISugestaoRepository>().To<SugestaoRepository>();
            kernel.Bind<ISugestaoRespostaRepository>().To<SugestaoRespostaRepository>();
            kernel.Bind<IBlogRepository>().To<BlogRepository>();
            kernel.Bind<IChatRepository>().To<ChatRepository>();
            kernel.Bind<IChatMensagemRepository>().To<ChatMensagemRepository>();
            kernel.Bind<IGrupoRepository>().To<GrupoRepository>();
            kernel.Bind<IComunicadoLeituraUsuarioRepository>().To<ComunicadoLeituraUsuarioRepository>();
            kernel.Bind<IComunicadoConfirmarUsuarioRepository>().To<ComunicadoConfirmarUsuarioRepository>();
            kernel.Bind<IEscolaRepository>().To<EscolaRepository>();
            kernel.Bind<ILeiteRepository>().To<LeiteRepository>();
            kernel.Bind<IRefeicaoRepository>().To<RefeicaoRepository>();
            kernel.Bind<IRefeicaoTipoRepository>().To<RefeicaoTipoRepository>();
            kernel.Bind<IRefeicaoAlimentoRepository>().To<RefeicaoAlimentoRepository>();
            kernel.Bind<IRefeicaoStatusRepository>().To<RefeicaoStatusRepository>();
            kernel.Bind<IEvacuacaoRepository>().To<EvacuacaoRepository>();
            kernel.Bind<ISonoRepository>().To<SonoRepository>();
        }
    }
}