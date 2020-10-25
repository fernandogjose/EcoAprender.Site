using Application.Services;
using Domain.Interfaces.Application;
using Ninject;

namespace IoC.Containers
{
    public static class ApplicationContainer
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<IAtividadeAppService>().To<AtividadeAppService>();
            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
            kernel.Bind<IComunicadoAppService>().To<ComunicadoAppService>();
            kernel.Bind<IVideoAppService>().To<VideoAppService>();
            kernel.Bind<ISugestaoAppService>().To<SugestaoAppService>();
            kernel.Bind<ISugestaoRespostaAppService>().To<SugestaoRespostaAppService>();
            kernel.Bind<IBlogAppService>().To<BlogAppService>();
            kernel.Bind<IChatAppService>().To<ChatAppService>();
            kernel.Bind<IChatMensagemAppService>().To<ChatMensagemAppService>();
            kernel.Bind<IGrupoAppService>().To<GrupoAppService>();
            kernel.Bind<IComunicadoLeituraUsuarioAppService>().To<ComunicadoLeituraUsuarioAppService>();
            kernel.Bind<IComunicadoConfirmarUsuarioAppService>().To<ComunicadoConfirmarUsuarioAppService>();
            kernel.Bind<IEscolaAppService>().To<EscolaAppService>();
        }
    }
}
