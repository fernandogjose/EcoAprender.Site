using System.Web;
using System.Web.Optimization;

namespace WebApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/layout").Include("~/Scripts/layout.js"));
            bundles.Add(new ScriptBundle("~/bundles/slideout").Include("~/Scripts/slideout.js"));
            bundles.Add(new ScriptBundle("~/bundles/portal-do-aluno").Include("~/Scripts/portal-do-aluno.js"));
            bundles.Add(new ScriptBundle("~/bundles/fale-conosco").Include("~/Scripts/fale-conosco.js"));
            bundles.Add(new ScriptBundle("~/bundles/comunicado").Include("~/Scripts/comunicado.js"));
            bundles.Add(new ScriptBundle("~/bundles/atividade").Include("~/Scripts/atividade.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootbox").Include("~/Scripts/bootbox.js"));
            bundles.Add(new ScriptBundle("~/bundles/usuario").Include("~/Scripts/usuario.js"));
            bundles.Add(new ScriptBundle("~/bundles/usuarioCadastrar").Include("~/Scripts/usuario-cadastrar.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminVideo").Include("~/Scripts/admin-video.js",
                                                                         "~/scripts/formComponent.js"));
            bundles.Add(new ScriptBundle("~/bundles/adminAtividade").Include("~/Scripts/admin-atividade.js"));
            bundles.Add(new ScriptBundle("~/bundles/adminComunicado").Include("~/Scripts/admin-comunicado.js"));
            bundles.Add(new ScriptBundle("~/bundles/adminComunicadoCadastrar").Include("~/Scripts/admin-comunicado-cadastrar.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminAtividadeCadastrar").Include("~/scripts/core/jquery.iframe-transport.js",
                                                                                      "~/scripts/core/jquery.ui.widget.js",
                                                                                      "~/scripts/core/jquery.fileupload.js",
                                                                                      "~/scripts/uploadFiles.js",
                                                                                      "~/scripts/formComponent.js"));

            bundles.Add(new ScriptBundle("~/bundles/blog").Include("~/Scripts/blog.js"));
            bundles.Add(new ScriptBundle("~/bundles/fotos").Include("~/Scripts/jquery.lightbox-0.5.min.js"));

            //--- Home
            bundles.Add(new ScriptBundle("~/bundles/home").Include("~/Scripts/blog.js", "~/Scripts/video.js"));

            bundles.Add(new StyleBundle("~/Content/fotos").Include("~/Content/css/jquery.lightbox-0.5.css"));
            bundles.Add(new StyleBundle("~/css").Include(
                "~/Content/css/slideout.css",
                "~/Content/css/componentes.css",
                "~/Content/css/mapa-do-site.css",
                "~/Content/css/navbar.css",
                "~/Content/css/blog.css",
                "~/Content/css/redes-sociais.css",
                "~/Content/css/video.css",
                "~/Content/css/atividade.css",
                "~/Content/css/usuario.css",
                "~/Content/css/pagina-interna.css",
                "~/Content/css/form-validator.css",
                "~/Content/css/portal-do-aluno.css",
                "~/Content/css/home-servicos.css",
                "~/Content/css/site.css"));
        }
    }
}
