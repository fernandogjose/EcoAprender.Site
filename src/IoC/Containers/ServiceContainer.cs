using Domain.Interfaces.Services;
using Domain.Services;
using Ninject;

namespace IoC.Containers
{
    public static class ServiceContainer
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<IAtividadeService>().To<AtividadeService>();
            kernel.Bind<IUsuarioService>().To<UsuarioService>();
            kernel.Bind<IComunicadoService>().To<ComunicadoService>();
            kernel.Bind<IVideoService>().To<VideoService>();
            kernel.Bind<ISugestaoService>().To<SugestaoService>();
            kernel.Bind<ISugestaoRespostaService>().To<SugestaoRespostaService>(); 
            kernel.Bind<IBlogService>().To<BlogService>();
            kernel.Bind<IChatService>().To<ChatService>();
            kernel.Bind<IChatMensagemService>().To<ChatMensagemService>();
            kernel.Bind<IGrupoService>().To<GrupoService>();
            kernel.Bind<IComunicadoLeituraUsuarioService>().To<ComunicadoLeituraUsuarioService>();
            kernel.Bind<IComunicadoConfirmarUsuarioService>().To<ComunicadoConfirmarUsuarioService>();
            kernel.Bind<IEscolaService>().To<EscolaService>();
            kernel.Bind<ILeiteService>().To<LeiteService>();
            kernel.Bind<IRefeicaoService>().To<RefeicaoService>();
            kernel.Bind<IRefeicaoTipoService>().To<RefeicaoTipoService>();
            kernel.Bind<IRefeicaoAlimentoService>().To<RefeicaoAlimentoService>();
            kernel.Bind<IRefeicaoStatusService>().To<RefeicaoStatusService>();
            kernel.Bind<IEvacuacaoService>().To<EvacuacaoService>();
            kernel.Bind<ISonoService>().To<SonoService>();
        }
    }
}